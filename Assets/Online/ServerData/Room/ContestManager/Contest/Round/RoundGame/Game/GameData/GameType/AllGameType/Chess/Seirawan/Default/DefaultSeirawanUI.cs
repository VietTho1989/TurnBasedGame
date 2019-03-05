using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan
{
    public class DefaultSeirawanUI : UIHaveTransformDataBehavior<DefaultSeirawanUI.UIData>
    {

        #region UIData

        public class UIData : DefaultGameTypeUI
        {

            public VP<EditData<DefaultSeirawan>> editDefaultSeirawan;

            #region chess960

            public VP<RequestChangeBoolUI.UIData> chess960;

            public void makeRequestChangeChess960(RequestChangeUpdate<bool>.UpdateData update, bool newChess960)
            {
                // Find
                DefaultSeirawan defaultSeirawan = null;
                {
                    EditData<DefaultSeirawan> editDefaultSeirawan = this.editDefaultSeirawan.v;
                    if (editDefaultSeirawan != null)
                    {
                        defaultSeirawan = editDefaultSeirawan.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultSeirawan null: " + this);
                    }
                }
                // Process
                if (defaultSeirawan != null)
                {
                    defaultSeirawan.requestChangeChess960(Server.getProfileUserId(defaultSeirawan), newChess960);
                }
                else
                {
                    Debug.LogError("defaultSeirawan null: " + this);
                }
            }

            #endregion

            public VP<MiniGameDataUI.UIData> miniGameDataUIData;

            #region Constructor

            public enum Property
            {
                editDefaultSeirawan,
                chess960,
                miniGameDataUIData
            }

            public UIData() : base()
            {
                this.editDefaultSeirawan = new VP<EditData<DefaultSeirawan>>(this, (byte)Property.editDefaultSeirawan, new EditData<DefaultSeirawan>());
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
                return GameType.Type.Seirawan;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        public Text lbChess960;
        public static readonly TxtLanguage txtChess960 = new TxtLanguage();

        static DefaultSeirawanUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Mặc Định Cờ Seirawan");
                txtChess960.add(Language.Type.vi, "Chess960");
            }
            // rect
            {
                chess960Rect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
            }
        }

        #endregion

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
                    EditData<DefaultSeirawan> editDefaultSeirawan = this.data.editDefaultSeirawan.v;
                    if (editDefaultSeirawan != null)
                    {
                        editDefaultSeirawan.update();
                        // get show
                        DefaultSeirawan show = editDefaultSeirawan.show.v.data;
                        DefaultSeirawan compare = editDefaultSeirawan.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editDefaultSeirawan.compareOtherType.v.data != null)
                                    {
                                        if (editDefaultSeirawan.compareOtherType.v.data.GetType() != show.GetType())
                                        {
                                            isDifferent = true;
                                        }
                                    }
                                }
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                            }
                            else
                            {
                                Debug.LogError("differentIndicator null: " + this);
                            }
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = Server.State.Type.Connect;
                                {
                                    Server server = show.findDataInParent<Server>();
                                    if (server != null)
                                    {
                                        if (server.state.v != null)
                                        {
                                            serverState = server.state.v.getType();
                                        }
                                        else
                                        {
                                            Debug.LogError("server state null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("server null: " + this);
                                    }
                                }
                                // set origin
                                {
                                    // chess960
                                    {
                                        RequestChangeBoolUI.UIData chess960 = this.data.chess960.v;
                                        if (chess960 != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = chess960.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.chess960.v;
                                                updateData.canRequestChange.v = editDefaultSeirawan.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    chess960.showDifferent.v = true;
                                                    chess960.compare.v = compare.chess960.v;
                                                }
                                                else
                                                {
                                                    chess960.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("chess960 null: " + this);
                                        }
                                    }
                                }
                                // reset?
                                if (needReset)
                                {
                                    needReset = false;
                                    // chess960
                                    {
                                        RequestChangeBoolUI.UIData chess960 = this.data.chess960.v;
                                        if (chess960 != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = chess960.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = show.chess960.v;
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("chess960 null: " + this);
                                        }
                                    }
                                }
                            }
                            // miniGameDataUIData
                            if (miniGameDataDirty)
                            {
                                miniGameDataDirty = false;
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
                                                // Find Seirawan
                                                Seirawan seirawan = gameData.gameType.newOrOld<Seirawan>();
                                                {
                                                    // Make new seirawan
                                                    Seirawan newSeirawan = (Seirawan)show.makeDefaultGameType();
                                                    {
                                                        if (newSeirawan.chess960.v)
                                                        {
                                                            for (Common.Rank y = Common.Rank.RANK_8; y >= Common.Rank.RANK_1; --y)
                                                            {
                                                                for (Common.File x = Common.File.FILE_A; x <= Common.File.FILE_H; ++x)
                                                                {
                                                                    Common.Square square = Common.make_square(x, y);
                                                                    Common.Piece piece = newSeirawan.piece_on(square);
                                                                    if (piece != Common.Piece.NO_PIECE && piece != Common.Piece.W_PAWN && piece != Common.Piece.B_PAWN)
                                                                    {
                                                                        newSeirawan.setPieceOn(square, Common.Piece.PIECE_NB);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    // Copy
                                                    DataUtils.copyData(seirawan, newSeirawan);
                                                }
                                                gameData.gameType.v = seirawan;
                                            }
                                        }
                                    }
                                }
                                this.data.miniGameDataUIData.v = miniGameDataUIData;
                            }
                        }
                        else
                        {
                            Debug.LogError("show null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("editDefaultSeirawan null: " + this);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Default Seirawan");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbChess960 != null)
                        {
                            lbChess960.text = txtChess960.get("Chess960");
                        }
                        else
                        {
                            Debug.LogError("lbChess960 null: " + this);
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

        public RequestChangeBoolUI requestBoolPrefab;
        public static readonly UIRectTransform chess960Rect = new UIRectTransform(UIConstants.RequestBoolRect);

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
                    uiData.editDefaultSeirawan.allAddCallBack(this);
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
                // editDefaultSeirawan
                {
                    if (data is EditData<DefaultSeirawan>)
                    {
                        EditData<DefaultSeirawan> editDefaultSeirawan = data as EditData<DefaultSeirawan>;
                        // Child
                        {
                            editDefaultSeirawan.show.allAddCallBack(this);
                            editDefaultSeirawan.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultSeirawan)
                        {
                            DefaultSeirawan defaultSeirawan = data as DefaultSeirawan;
                            // Parent
                            {
                                DataUtils.addParentCallBack(defaultSeirawan, this, ref this.server);
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
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, chess960Rect);
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
                            {
                                gameData.gameType.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // GameType
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
                    uiData.editDefaultSeirawan.allRemoveCallBack(this);
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
                // editDefaultSeirawan
                {
                    if (data is EditData<DefaultSeirawan>)
                    {
                        EditData<DefaultSeirawan> editDefaultSeirawan = data as EditData<DefaultSeirawan>;
                        // Child
                        {
                            editDefaultSeirawan.show.allRemoveCallBack(this);
                            editDefaultSeirawan.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultSeirawan)
                        {
                            DefaultSeirawan defaultSeirawan = data as DefaultSeirawan;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(defaultSeirawan, this, ref this.server);
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
                            {
                                gameData.gameType.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // GameType
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
                    case UIData.Property.editDefaultSeirawan:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
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
                // EditDefaultSeirawan
                {
                    if (wrapProperty.p is EditData<DefaultSeirawan>)
                    {
                        switch ((EditData<DefaultSeirawan>.Property)wrapProperty.n)
                        {
                            case EditData<DefaultSeirawan>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<DefaultSeirawan>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultSeirawan>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultSeirawan>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<DefaultSeirawan>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<DefaultSeirawan>.Property.editType:
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
                        if (wrapProperty.p is DefaultSeirawan)
                        {
                            switch ((DefaultSeirawan.Property)wrapProperty.n)
                            {
                                case DefaultSeirawan.Property.chess960:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Parent
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