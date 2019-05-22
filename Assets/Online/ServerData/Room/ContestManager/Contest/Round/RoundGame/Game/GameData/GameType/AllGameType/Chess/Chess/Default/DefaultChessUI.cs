using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
    public class DefaultChessUI : UIHaveTransformDataBehavior<DefaultChessUI.UIData>
    {

        #region UIData

        public class UIData : DefaultGameTypeUI
        {

            public VP<EditData<DefaultChess>> editDefaultChess;

            public VP<UIRectTransform.ShowType> showType;

            #region chess960

            public VP<RequestChangeBoolUI.UIData> chess960;

            public void makeRequestChangeChess960(RequestChangeUpdate<bool>.UpdateData update, bool newChess960)
            {
                // Find
                DefaultChess defaultChess = null;
                {
                    EditData<DefaultChess> editDefaultChess = this.editDefaultChess.v;
                    if (editDefaultChess != null)
                    {
                        defaultChess = editDefaultChess.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultChess null: " + this);
                    }
                }
                // Process
                if (defaultChess != null)
                {
                    defaultChess.requestChangeChess960(Server.getProfileUserId(defaultChess), newChess960);
                }
                else
                {
                    Debug.LogError("defaultChess null: " + this);
                }
            }

            #endregion

            public VP<MiniGameDataUI.UIData> miniGameDataUIData;

            #region Constructor

            public enum Property
            {
                editDefaultChess,
                showType,
                chess960,
                miniGameDataUIData
            }

            public UIData() : base()
            {
                this.editDefaultChess = new VP<EditData<DefaultChess>>(this, (byte)Property.editDefaultChess, new EditData<DefaultChess>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                {
                    this.chess960 = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.chess960, new RequestChangeBoolUI.UIData());
                    // event
                    this.chess960.v.updateData.v.request.v = makeRequestChangeChess960;
                }
                this.miniGameDataUIData = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUIData, new MiniGameDataUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.CHESS;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Default Chess");

        public Text lbChess960;
        private static readonly TxtLanguage txtChess960 = new TxtLanguage("Chess960");

        static DefaultChessUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Cờ Vua Mặc Định");
                txtChess960.add(Language.Type.vi, "Cờ ngẫu nhiên Fischer");
            }
        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.CHESS ? 1 : 0;
        }

        #region Refresh

        private bool needReset = true;
        private bool miniGameDataDirty = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<DefaultChess> editDefaultChess = this.data.editDefaultChess.v;
                    if (editDefaultChess != null)
                    {
                        editDefaultChess.update();
                        // UI
                        {
                            // differentIndicator
                            RequestChange.ShowDifferentTitle(lbTitle, editDefaultChess);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editDefaultChess);
                                // set origin
                                {
                                    RequestChange.RefreshUI(this.data.chess960.v, editDefaultChess, serverState, needReset, editData => editData.chess960.v);
                                }
                                needReset = false;
                            }
                            // miniGameDataUIData
                            if (miniGameDataDirty)
                            {
                                // find miniGameDataUIData
                                MiniGameDataUI.UIData miniGameDataUIData = this.data.miniGameDataUIData.newOrOld<MiniGameDataUI.UIData>();
                                {
                                    // gameData
                                    {
                                        // Find GameData
                                        GameData gameData = null;
                                        {
                                            // Find old
                                            if (miniGameDataUIData.gameData.v.data != null)
                                            {
                                                gameData = miniGameDataUIData.gameData.v.data;
                                            }
                                            // Make new
                                            if (gameData == null)
                                            {
                                                gameData = new GameData();
                                                miniGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                        }
                                        // Update Property
                                        {
                                            // GameType
                                            {
                                                // Find Chess
                                                Chess chess = gameData.gameType.newOrOld<Chess>();
                                                {
                                                    // Make new chess
                                                    Chess newChess = null;
                                                    {
                                                        DefaultChess show = editDefaultChess.show.v.data;
                                                        if (show != null)
                                                        {
                                                            newChess = show.makeDefaultGameType() as Chess;
                                                            if (newChess.chess960.v)
                                                            {
                                                                for (Common.Rank y = Common.Rank.RANK_8; y >= Common.Rank.RANK_1; --y)
                                                                {
                                                                    for (Common.File x = Common.File.FILE_A; x <= Common.File.FILE_H; ++x)
                                                                    {
                                                                        Common.Square square = Common.make_square(x, y);
                                                                        Common.Piece piece = newChess.piece_on(square);
                                                                        if (piece != Common.Piece.NO_PIECE && piece != Common.Piece.W_PAWN && piece != Common.Piece.B_PAWN)
                                                                        {
                                                                            newChess.setPieceOn(square, Common.Piece.PIECE_NB);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("show null");
                                                        }
                                                    }
                                                    // Copy
                                                    DataUtils.copyData(chess, newChess);
                                                }
                                                gameData.gameType.v = chess;
                                            }
                                        }
                                    }
                                }
                                this.data.miniGameDataUIData.v = miniGameDataUIData;
                                miniGameDataDirty = false;
                            }
                            // UI
                            {
                                float deltaY = 0;
                                // header
                                UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                                // miniGameDataUI
                                {
                                    UIRectTransform.SetPosY(this.data.miniGameDataUIData.v, deltaY + UIConstants.DefaultMiniGameDataUIPadding);
                                    deltaY += UIConstants.DefaultMiniGameDataUISize;
                                }
                                // chess960
                                UIUtils.SetLabelContentPosition(lbChess960, this.data.chess960.v, ref deltaY);
                                // Set
                                UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                            }
                            // txt
                            {
                                if (lbTitle != null)
                                {
                                    lbTitle.text = txtTitle.get();
                                    Setting.get().setTitleTextSize(lbTitle);
                                }
                                else
                                {
                                    Debug.LogError("lbTitle null: " + this);
                                }
                                if (lbChess960 != null)
                                {
                                    lbChess960.text = txtChess960.get();
                                    Setting.get().setLabelTextSize(lbChess960);
                                }
                                else
                                {
                                    Debug.LogError("lbChess960 null: " + this);
                                }
                            }
                        }
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public MiniGameDataUI miniGameDataUIPrefab;

        private Server server = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.editDefaultChess.allAddCallBack(this);
                    uiData.chess960.allAddCallBack(this);
                    uiData.miniGameDataUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // editDefaultChess
                {
                    if (data is EditData<DefaultChess>)
                    {
                        EditData<DefaultChess> editDefaultChess = data as EditData<DefaultChess>;
                        // Child
                        {
                            editDefaultChess.show.allAddCallBack(this);
                            editDefaultChess.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultChess)
                        {
                            DefaultChess defaultChess = data as DefaultChess;
                            // Parent
                            {
                                DataUtils.addParentCallBack(defaultChess, this, ref this.server);
                            }
                            needReset = true;
                            miniGameDataDirty = true;
                            dirty = true;
                            return;
                        }
                        // Parent
                        {
                            if (data is Server)
                            {
                                dirty = true;
                                return;
                            }
                        }
                    }
                }
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.chess960:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("wrapProperty null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
                // MiniGameDataUIData
                {
                    if (data is MiniGameDataUI.UIData)
                    {
                        MiniGameDataUI.UIData miniGameDataUIData = data as MiniGameDataUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(miniGameDataUIData, miniGameDataUIPrefab, this.transform, UIConstants.MiniGameDataUIRect);
                        }
                        // Child
                        {
                            miniGameDataUIData.gameData.allAddCallBack(this);
                        }
                        miniGameDataDirty = true;
                        dirty = true;
                        return;
                    }
                    // GameData
                    {
                        if (data is GameData)
                        {
                            GameData gameData = data as GameData;
                            // Child
                            {
                                gameData.gameType.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        {
                            data.addCallBackAllChildren(this);
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().removeCallBack(this);
                // Child
                {
                    uiData.editDefaultChess.allRemoveCallBack(this);
                    uiData.chess960.allRemoveCallBack(this);
                    uiData.miniGameDataUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Child
            {
                // editDefaultChess
                {
                    if (data is EditData<DefaultChess>)
                    {
                        EditData<DefaultChess> editDefaultChess = data as EditData<DefaultChess>;
                        // Child
                        {
                            editDefaultChess.show.allRemoveCallBack(this);
                            editDefaultChess.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultChess)
                        {
                            DefaultChess defaultChess = data as DefaultChess;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(defaultChess, this, ref this.server);
                            }
                            return;
                        }
                        // Parent
                        {
                            if (data is Server)
                            {
                                return;
                            }
                        }
                    }
                }
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
                    }
                    return;
                }
                // MiniGameDataUIData
                {
                    if (data is MiniGameDataUI.UIData)
                    {
                        MiniGameDataUI.UIData miniGameDataUIData = data as MiniGameDataUI.UIData;
                        // UI
                        {
                            miniGameDataUIData.removeCallBackAndDestroy(typeof(MiniGameDataUI));
                        }
                        // Child
                        {
                            miniGameDataUIData.gameData.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // GameData
                    {
                        if (data is GameData)
                        {
                            GameData gameData = data as GameData;
                            // Child
                            {
                                gameData.gameType.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        {
                            data.removeCallBackAllChildren(this);
                            return;
                        }
                    }
                }
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is UIData)
            {
                switch ((UIData.Property)wrapProperty.n)
                {
                    case UIData.Property.editDefaultChess:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.chess960:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.miniGameDataUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Setting
            if (wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        dirty = true;
                        break;
                    case Setting.Property.style:
                        break;
                    case Setting.Property.contentTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.buttonSize:
                        dirty = true;
                        break;
                    case Setting.Property.itemSize:
                        dirty = true;
                        break;
                    case Setting.Property.confirmQuit:
                        break;
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                // EditDefaultChess
                {
                    if (wrapProperty.p is EditData<DefaultChess>)
                    {
                        switch ((EditData<DefaultChess>.Property)wrapProperty.n)
                        {
                            case EditData<DefaultChess>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<DefaultChess>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultChess>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultChess>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<DefaultChess>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<DefaultChess>.Property.editType:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is DefaultChess)
                        {
                            switch ((DefaultChess.Property)wrapProperty.n)
                            {
                                case DefaultChess.Property.chess960:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        if (wrapProperty.p is Server)
                        {
                            Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                            return;
                        }
                    }
                }
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
                }
                // MiniGameDataUIData
                {
                    if (wrapProperty.p is MiniGameDataUI.UIData)
                    {
                        switch ((MiniGameDataUI.UIData.Property)wrapProperty.n)
                        {
                            case MiniGameDataUI.UIData.Property.gameData:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case MiniGameDataUI.UIData.Property.board:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // GameData
                    {
                        if (wrapProperty.p is GameData)
                        {
                            switch ((GameData.Property)wrapProperty.n)
                            {
                                case GameData.Property.gameType:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case GameData.Property.useRule:
                                    break;
                                case GameData.Property.turn:
                                    break;
                                case GameData.Property.timeControl:
                                    break;
                                case GameData.Property.lastMove:
                                    break;
                                case GameData.Property.state:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // GameType
                        {
                            if (Generic.IsAddCallBackInterface<T>())
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                            }
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}