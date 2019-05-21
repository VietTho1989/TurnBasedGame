using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
{
    public class DefaultFairyChessUI : UIHaveTransformDataBehavior<DefaultFairyChessUI.UIData>
    {

        #region UIData

        public class UIData : DefaultGameTypeUI
        {

            public VP<EditData<DefaultFairyChess>> editDefaultFairyChess;

            public VP<UIRectTransform.ShowType> showType;

            #region variantType

            public VP<RequestChangeEnumUI.UIData> variantType;

            public void makeRequestChangeVariantType(RequestChangeUpdate<int>.UpdateData update, int newVariantType)
            {
                // Find
                DefaultFairyChess defaultFairyChess = null;
                {
                    EditData<DefaultFairyChess> editDefaultFairyChess = this.editDefaultFairyChess.v;
                    if (editDefaultFairyChess != null)
                    {
                        defaultFairyChess = editDefaultFairyChess.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultFairyChess null: " + this);
                    }
                }
                // Process
                if (defaultFairyChess != null)
                {
                    // Find variantType
                    Common.VariantType variantType = Common.VariantType.asean;
                    {
                        if (newVariantType >= 0 && newVariantType < VariantMap.EnableVariants.Length)
                        {
                            variantType = VariantMap.EnableVariants[newVariantType];
                        }
                    }
                    defaultFairyChess.requestChangeVariantType(Server.getProfileUserId(defaultFairyChess), variantType);
                }
                else
                {
                    Debug.LogError("defaultFairyChess null: " + this);
                }
            }

            #endregion

            #region chess960

            public VP<RequestChangeBoolUI.UIData> chess960;

            public void makeRequestChangeChess960(RequestChangeUpdate<bool>.UpdateData update, bool newChess960)
            {
                // Find
                DefaultFairyChess defaultFairyChess = null;
                {
                    EditData<DefaultFairyChess> editDefaultFairyChess = this.editDefaultFairyChess.v;
                    if (editDefaultFairyChess != null)
                    {
                        defaultFairyChess = editDefaultFairyChess.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultFairyChess null: " + this);
                    }
                }
                // Process
                if (defaultFairyChess != null)
                {
                    defaultFairyChess.requestChangeChess960(Server.getProfileUserId(defaultFairyChess), newChess960);
                }
                else
                {
                    Debug.LogError("defaultFairyChess null: " + this);
                }
            }

            #endregion

            public VP<MiniGameDataUI.UIData> miniGameDataUIData;

            #region Constructor

            public enum Property
            {
                editDefaultFairyChess,
                showType,
                variantType,
                chess960,
                miniGameDataUIData
            }

            public UIData() : base()
            {
                this.editDefaultFairyChess = new VP<EditData<DefaultFairyChess>>(this, (byte)Property.editDefaultFairyChess, new EditData<DefaultFairyChess>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // variantType
                {
                    this.variantType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.variantType, new RequestChangeEnumUI.UIData());
                    // event
                    this.variantType.v.updateData.v.request.v = makeRequestChangeVariantType;
                    {
                        for (int i = 0; i < VariantMap.EnableVariants.Length; i++)
                        {
                            this.variantType.v.options.add(VariantMap.EnableVariants[i].ToString());
                        }
                    }
                }
                // chess960
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
                return GameType.Type.FairyChess;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.FairyChess ? 1 : 0;
        }

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Default Fairy Chess");

        public Text lbVariantType;
        private static readonly TxtLanguage txtVariantType = new TxtLanguage("Variant type");

        public Text lbChess960;
        private static readonly TxtLanguage txtChess960 = new TxtLanguage("Chess960");

        static DefaultFairyChessUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Biến Thể Cờ Vua Mặc Định");
                txtVariantType.add(Language.Type.vi, "Thể loại");
                txtChess960.add(Language.Type.vi, "Chess960");
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
                    EditData<DefaultFairyChess> editDefaultFairyChess = this.data.editDefaultFairyChess.v;
                    if (editDefaultFairyChess != null)
                    {
                        editDefaultFairyChess.update();
                        // UI
                        {
                            // differentIndicator
                            RequestChange.ShowDifferentTitle(lbTitle, editDefaultFairyChess);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editDefaultFairyChess);
                                // set origin
                                {
                                    RequestChange.RefreshUI(this.data.variantType.v, editDefaultFairyChess, serverState, needReset, editData => VariantMap.getEnableVariantIndex(editData.variantType.v));
                                    RequestChange.RefreshUI(this.data.chess960.v, editDefaultFairyChess, serverState, needReset, editData => editData.chess960.v);
                                }
                                needReset = false;
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
                                                // Find FairyChess
                                                FairyChess fairyChess = gameData.gameType.newOrOld<FairyChess>();
                                                {
                                                    // Make new fairyChess
                                                    FairyChess newFairyChess = null;
                                                    {
                                                        DefaultFairyChess show = editDefaultFairyChess.show.v.data;
                                                        if (show != null)
                                                        {
                                                            newFairyChess = (FairyChess)show.makeDefaultGameType();
                                                            if (newFairyChess.chess960.v)
                                                            {
                                                                for (Common.Rank y = Common.Rank.RANK_8; y >= Common.Rank.RANK_1; --y)
                                                                {
                                                                    for (Common.File x = Common.File.FILE_A; x <= Common.File.FILE_H; ++x)
                                                                    {
                                                                        // Common.Square square = Common.make_square (x, y);
                                                                        // Common.Piece piece = newFairyChess.piece_on (square);
                                                                        // TODO Can hoan thien
                                                                        /*if (piece != Common.Piece.NO_PIECE && piece != Common.Piece.W_PAWN && piece != Common.Piece.B_PAWN) {
                                                                            newFairyChess.setPieceOn (square, Common.Piece.PIECE_NB);
                                                                        }*/
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
                                                    DataUtils.copyData(fairyChess, newFairyChess);
                                                }
                                                gameData.gameType.v = fairyChess;
                                            }
                                        }
                                    }
                                }
                                this.data.miniGameDataUIData.v = miniGameDataUIData;
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
                                // variantType
                                UIUtils.SetLabelContentPosition(lbVariantType, this.data.variantType.v, ref deltaY);
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
                                if (lbVariantType != null)
                                {
                                    lbVariantType.text = txtVariantType.get();
                                    Setting.get().setLabelTextSize(lbVariantType);
                                }
                                else
                                {
                                    Debug.LogError("lbVariantType null: " + this);
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

        public RequestChangeEnumUI requestEnumPrefab;

        public RequestChangeBoolUI requestBoolPrefab;

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
                    uiData.editDefaultFairyChess.allAddCallBack(this);
                    uiData.variantType.allAddCallBack(this);
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
                // editDefaultFairyChess
                {
                    if (data is EditData<DefaultFairyChess>)
                    {
                        EditData<DefaultFairyChess> editDefaultFairyChess = data as EditData<DefaultFairyChess>;
                        // Child
                        {
                            editDefaultFairyChess.show.allAddCallBack(this);
                            editDefaultFairyChess.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultFairyChess)
                        {
                            DefaultFairyChess defaultFairyChess = data as DefaultFairyChess;
                            // Parent
                            {
                                DataUtils.addParentCallBack(defaultFairyChess, this, ref this.server);
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
                // variantType
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.variantType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
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
                // chess960
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
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
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
                    uiData.editDefaultFairyChess.allRemoveCallBack(this);
                    uiData.variantType.allRemoveCallBack(this);
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
                // editDefaultFairyChess
                {
                    if (data is EditData<DefaultFairyChess>)
                    {
                        EditData<DefaultFairyChess> editDefaultFairyChess = data as EditData<DefaultFairyChess>;
                        // Child
                        {
                            editDefaultFairyChess.show.allRemoveCallBack(this);
                            editDefaultFairyChess.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultFairyChess)
                        {
                            DefaultFairyChess defaultFairyChess = data as DefaultFairyChess;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(defaultFairyChess, this, ref this.server);
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
                // variantType
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                    }
                    return;
                }
                // chess960
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
                    case UIData.Property.editDefaultFairyChess:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.variantType:
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
                // EditDefaultFairyChess
                {
                    if (wrapProperty.p is EditData<DefaultFairyChess>)
                    {
                        switch ((EditData<DefaultFairyChess>.Property)wrapProperty.n)
                        {
                            case EditData<DefaultFairyChess>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<DefaultFairyChess>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultFairyChess>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultFairyChess>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<DefaultFairyChess>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<DefaultFairyChess>.Property.editType:
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
                        if (wrapProperty.p is DefaultFairyChess)
                        {
                            switch ((DefaultFairyChess.Property)wrapProperty.n)
                            {
                                case DefaultFairyChess.Property.variantType:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultFairyChess.Property.chess960:
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
                // variantType
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
                {
                    return;
                }
                // chess960
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