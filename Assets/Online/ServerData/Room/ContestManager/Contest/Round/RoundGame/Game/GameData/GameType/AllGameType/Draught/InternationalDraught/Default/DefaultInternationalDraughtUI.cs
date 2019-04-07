using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
    public class DefaultInternationalDraughtUI : UIHaveTransformDataBehavior<DefaultInternationalDraughtUI.UIData>
    {

        #region UIData

        public class UIData : DefaultGameTypeUI
        {

            public VP<EditData<DefaultInternationalDraught>> editDefaultInternationalDraught;

            public VP<UIRectTransform.ShowType> showType;

            #region variant

            public VP<RequestChangeEnumUI.UIData> variant;

            public void makeRequestChangeVariant(RequestChangeUpdate<int>.UpdateData update, int newVariant)
            {
                // Find
                DefaultInternationalDraught defaultInternationalDraught = null;
                {
                    EditData<DefaultInternationalDraught> editDefaultInternationalDraught = this.editDefaultInternationalDraught.v;
                    if (editDefaultInternationalDraught != null)
                    {
                        defaultInternationalDraught = editDefaultInternationalDraught.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultInternationalDraught null: " + this);
                    }
                }
                // Process
                if (defaultInternationalDraught != null)
                {
                    defaultInternationalDraught.requestChangeVariant(Server.getProfileUserId(defaultInternationalDraught), newVariant);
                }
                else
                {
                    Debug.LogError("defaultInternationalDraught null: " + this);
                }
            }

            #endregion

            public VP<MiniGameDataUI.UIData> miniGameDataUIData;

            #region Constructor

            public enum Property
            {
                editDefaultInternationalDraught,
                showType,
                variant,
                miniGameDataUIData
            }

            public UIData() : base()
            {
                this.editDefaultInternationalDraught = new VP<EditData<DefaultInternationalDraught>>(this, (byte)Property.editDefaultInternationalDraught, new EditData<DefaultInternationalDraught>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                {
                    this.variant = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.variant, new RequestChangeEnumUI.UIData());
                    // event
                    this.variant.v.updateData.v.request.v = makeRequestChangeVariant;
                    {
                        this.variant.v.options.add("Normal");
                        this.variant.v.options.add("Killer");
                        this.variant.v.options.add("Breakthrough");
                    }
                }
                this.miniGameDataUIData = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUIData, new MiniGameDataUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.InternationalDraught;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Default International Draughts");

        public Text lbVariant;
        private static readonly TxtLanguage txtVariant = new TxtLanguage("Variant");

        static DefaultInternationalDraughtUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Mặc Định Cờ Đam Kiểu Quốc Tế");
                txtVariant.add(Language.Type.vi, "Thể loại");
            }
            // rect
            {
                variantRect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
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
                    EditData<DefaultInternationalDraught> editDefaultInternationalDraught = this.data.editDefaultInternationalDraught.v;
                    if (editDefaultInternationalDraught != null)
                    {
                        editDefaultInternationalDraught.update();
                        // get show
                        DefaultInternationalDraught show = editDefaultInternationalDraught.show.v.data;
                        DefaultInternationalDraught compare = editDefaultInternationalDraught.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editDefaultInternationalDraught.compareOtherType.v.data != null)
                                    {
                                        if (editDefaultInternationalDraught.compareOtherType.v.data.GetType() != show.GetType())
                                        {
                                            isDifferent = true;
                                        }
                                    }
                                }
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                            }
                            else
                            {
                                Debug.LogError("different null: " + this);
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
                                    // variant
                                    {
                                        RequestChangeEnumUI.UIData variant = this.data.variant.v;
                                        if (variant != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = variant.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.variant.v;
                                                updateData.canRequestChange.v = editDefaultInternationalDraught.canEdit.v;
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
                                                    variant.showDifferent.v = true;
                                                    variant.compare.v = compare.variant.v;
                                                }
                                                else
                                                {
                                                    variant.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("variant null: " + this);
                                        }
                                    }
                                }
                                // reset?
                                if (needReset)
                                {
                                    needReset = false;
                                    // variant
                                    {
                                        RequestChangeEnumUI.UIData variant = this.data.variant.v;
                                        if (variant != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = variant.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = show.variant.v;
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("boardSize null: " + this);
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
                                                // Find InternationalDraught
                                                InternationalDraught internationalDraught = gameData.gameType.newOrOld<InternationalDraught>();
                                                {
                                                    // Make new internationalDraught to update
                                                    InternationalDraught newInternationalDraught = (InternationalDraught)show.makeDefaultGameType();
                                                    // Copy
                                                    DataUtils.copyData(internationalDraught, newInternationalDraught);
                                                }
                                                gameData.gameType.v = internationalDraught;
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
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            {
                                switch (this.data.showType.v)
                                {
                                    case UIRectTransform.ShowType.Normal:
                                        {
                                            if (lbTitle != null)
                                            {
                                                lbTitle.gameObject.SetActive(true);
                                            }
                                            else
                                            {
                                                Debug.LogError("lbTitle null");
                                            }
                                            deltaY += UIConstants.HeaderHeight;
                                        }
                                        break;
                                    case UIRectTransform.ShowType.HeadLess:
                                        {
                                            if (lbTitle != null)
                                            {
                                                lbTitle.gameObject.SetActive(false);
                                            }
                                            else
                                            {
                                                Debug.LogError("lbTitle null");
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown showType: " + this.data.showType.v);
                                        break;
                                }
                            }
                            // miniGameDataUI
                            {
                                UIRectTransform.SetPosY(this.data.miniGameDataUIData.v, deltaY + UIConstants.DefaultMiniGameDataUIPadding);
                                deltaY += UIConstants.DefaultMiniGameDataUISize;
                            }
                            // variant
                            {
                                if (this.data.variant.v != null)
                                {
                                    if (lbVariant != null)
                                    {
                                        lbVariant.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY(lbVariant.rectTransform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbVariant null");
                                    }
                                    UIRectTransform.SetPosY(this.data.variant.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbVariant != null)
                                    {
                                        lbVariant.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbVariant null");
                                    }
                                }
                            }
                            // Set
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get();
                            }
                            else
                            {
                                Debug.LogError("lbTitle null: " + this);
                            }
                            if (lbVariant != null)
                            {
                                lbVariant.text = txtVariant.get();
                            }
                            else
                            {
                                Debug.LogError("lbVariatn null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editDefaultInternationalDraught null: " + this);
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
        public static readonly UIRectTransform variantRect = new UIRectTransform(UIConstants.RequestEnumRect);

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
                    uiData.editDefaultInternationalDraught.allAddCallBack(this);
                    uiData.variant.allAddCallBack(this);
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
                // editDefaultInternationalDraught
                {
                    if (data is EditData<DefaultInternationalDraught>)
                    {
                        EditData<DefaultInternationalDraught> editDefaultInternationalDraught = data as EditData<DefaultInternationalDraught>;
                        // Child
                        {
                            editDefaultInternationalDraught.show.allAddCallBack(this);
                            editDefaultInternationalDraught.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultInternationalDraught)
                        {
                            DefaultInternationalDraught defaultInternationalDraught = data as DefaultInternationalDraught;
                            // Parent
                            {
                                DataUtils.addParentCallBack(defaultInternationalDraught, this, ref this.server);
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
                                case UIData.Property.variant:
                                    {
                                        UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, variantRect);
                                    }
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
                    uiData.editDefaultInternationalDraught.allRemoveCallBack(this);
                    uiData.variant.allRemoveCallBack(this);
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
                // editDefaultInternationalDraught
                {
                    if (data is EditData<DefaultInternationalDraught>)
                    {
                        EditData<DefaultInternationalDraught> editDefaultInternationalDraught = data as EditData<DefaultInternationalDraught>;
                        // Child
                        {
                            editDefaultInternationalDraught.show.allRemoveCallBack(this);
                            editDefaultInternationalDraught.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultInternationalDraught)
                        {
                            DefaultInternationalDraught defaultInternationalDraught = data as DefaultInternationalDraught;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(defaultInternationalDraught, this, ref this.server);
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
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
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
                    case UIData.Property.editDefaultInternationalDraught:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.variant:
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
                // EditDefaultInternationalDraught
                {
                    if (wrapProperty.p is EditData<DefaultInternationalDraught>)
                    {
                        switch ((EditData<DefaultInternationalDraught>.Property)wrapProperty.n)
                        {
                            case EditData<DefaultInternationalDraught>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<DefaultInternationalDraught>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultInternationalDraught>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultInternationalDraught>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<DefaultInternationalDraught>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<DefaultInternationalDraught>.Property.editType:
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
                        if (wrapProperty.p is DefaultInternationalDraught)
                        {
                            switch ((DefaultInternationalDraught.Property)wrapProperty.n)
                            {
                                case DefaultInternationalDraught.Property.variant:
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
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
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