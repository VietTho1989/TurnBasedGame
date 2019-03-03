using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Shatranj
{
    public class DefaultShatranjUI : UIBehavior<DefaultShatranjUI.UIData>, HaveTransformData
    {

        #region UIData

        public class UIData : DefaultGameTypeUI
        {

            public VP<EditData<DefaultShatranj>> editDefaultShatranj;

            #region chess960

            public VP<RequestChangeBoolUI.UIData> chess960;

            public void makeRequestChangeChess960(RequestChangeUpdate<bool>.UpdateData update, bool newChess960)
            {
                // Find
                DefaultShatranj defaultShatranj = null;
                {
                    EditData<DefaultShatranj> editDefaultShatranj = this.editDefaultShatranj.v;
                    if (editDefaultShatranj != null)
                    {
                        defaultShatranj = editDefaultShatranj.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultShatranj null: " + this);
                    }
                }
                // Process
                if (defaultShatranj != null)
                {
                    defaultShatranj.requestChangeChess960(Server.getProfileUserId(defaultShatranj), newChess960);
                }
                else
                {
                    Debug.LogError("defaultShatranj null: " + this);
                }
            }

            #endregion

            public VP<MiniGameDataUI.UIData> miniGameDataUIData;

            #region Constructor

            public enum Property
            {
                editDefaultShatranj,
                chess960,
                miniGameDataUIData
            }

            public UIData() : base()
            {
                this.editDefaultShatranj = new VP<EditData<DefaultShatranj>>(this, (byte)Property.editDefaultShatranj, new EditData<DefaultShatranj>());
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
                return GameType.Type.Shatranj;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static TxtLanguage txtTitle = new TxtLanguage();

        public Text lbChess960;
        public static TxtLanguage txtChess960 = new TxtLanguage();

        static DefaultShatranjUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Mặc Định Cờ Ba Tư");
                txtChess960.add(Language.Type.vi, "Chess960");
            }
            // rect
            {
                chess960Rect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
            }
        }

        #endregion

        #region TransformData

        public TransformData transformData = new TransformData();

        private void updateTransformData()
        {
            this.transformData.update(this.transform);
        }

        public TransformData getTransformData()
        {
            return this.transformData;
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
                    EditData<DefaultShatranj> editDefaultShatranj = this.data.editDefaultShatranj.v;
                    if (editDefaultShatranj != null)
                    {
                        editDefaultShatranj.update();
                        // get show
                        DefaultShatranj show = editDefaultShatranj.show.v.data;
                        DefaultShatranj compare = editDefaultShatranj.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editDefaultShatranj.compareOtherType.v.data != null)
                                    {
                                        if (editDefaultShatranj.compareOtherType.v.data.GetType() != show.GetType())
                                        {
                                            isDifferent = true;
                                        }
                                    }
                                }
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                            }
                            else
                            {
                                Debug.LogError("lbTitle null: " + this);
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
                                                updateData.canRequestChange.v = editDefaultShatranj.canEdit.v;
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
                                                // Find Shatranj
                                                Shatranj shatranj = gameData.gameType.newOrOld<Shatranj>();
                                                {
                                                    // Make new shatranj
                                                    Shatranj newShatranj = (Shatranj)show.makeDefaultGameType();
                                                    {
                                                        if (newShatranj.chess960.v)
                                                        {
                                                            for (Common.Rank y = Common.Rank.RANK_8; y >= Common.Rank.RANK_1; --y)
                                                            {
                                                                for (Common.File x = Common.File.FILE_A; x <= Common.File.FILE_H; ++x)
                                                                {
                                                                    Common.Square square = Common.make_square(x, y);
                                                                    Common.Piece piece = newShatranj.piece_on(square);
                                                                    if (piece != Common.Piece.NO_PIECE && piece != Common.Piece.W_PAWN && piece != Common.Piece.B_PAWN)
                                                                    {
                                                                        newShatranj.setPieceOn(square, Common.Piece.PIECE_NB);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    // Copy
                                                    DataUtils.copyData(shatranj, newShatranj);
                                                }
                                                gameData.gameType.v = shatranj;
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
                        Debug.LogError("editDefaultShatranj null: " + this);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Default Shatranj");
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
            updateTransformData();
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
                // Global
                Global.get().addCallBack(this);
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.editDefaultShatranj.allAddCallBack(this);
                    uiData.chess960.allAddCallBack(this);
                    uiData.miniGameDataUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Global
            if (data is Global)
            {
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
                // editDefaultShatranj
                {
                    if (data is EditData<DefaultShatranj>)
                    {
                        EditData<DefaultShatranj> editDefaultShatranj = data as EditData<DefaultShatranj>;
                        // Child
                        {
                            editDefaultShatranj.show.allAddCallBack(this);
                            editDefaultShatranj.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultShatranj)
                        {
                            DefaultShatranj defaultShatranj = data as DefaultShatranj;
                            // Parent
                            {
                                DataUtils.addParentCallBack(defaultShatranj, this, ref this.server);
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
                // Global
                Global.get().removeCallBack(this);
                // Setting
                Setting.get().removeCallBack(this);
                // Child
                {
                    uiData.editDefaultShatranj.allRemoveCallBack(this);
                    uiData.chess960.allRemoveCallBack(this);
                    uiData.miniGameDataUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Global
            if (data is Global)
            {
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Child
            {
                // editDefaultShatranj
                {
                    if (data is EditData<DefaultShatranj>)
                    {
                        EditData<DefaultShatranj> editDefaultShatranj = data as EditData<DefaultShatranj>;
                        // Child
                        {
                            editDefaultShatranj.show.allRemoveCallBack(this);
                            editDefaultShatranj.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultShatranj)
                        {
                            DefaultShatranj defaultShatranj = data as DefaultShatranj;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(defaultShatranj, this, ref this.server);
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
                    case UIData.Property.editDefaultShatranj:
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
            // Global
            if (wrapProperty.p is Global)
            {
                Global.OnValueTransformChange(wrapProperty, this);
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
                // EditDefaultShatranj
                {
                    if (wrapProperty.p is EditData<DefaultShatranj>)
                    {
                        switch ((EditData<DefaultShatranj>.Property)wrapProperty.n)
                        {
                            case EditData<DefaultShatranj>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<DefaultShatranj>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultShatranj>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultShatranj>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<DefaultShatranj>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<DefaultShatranj>.Property.editType:
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
                        if (wrapProperty.p is DefaultShatranj)
                        {
                            switch ((DefaultShatranj.Property)wrapProperty.n)
                            {
                                case DefaultShatranj.Property.chess960:
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