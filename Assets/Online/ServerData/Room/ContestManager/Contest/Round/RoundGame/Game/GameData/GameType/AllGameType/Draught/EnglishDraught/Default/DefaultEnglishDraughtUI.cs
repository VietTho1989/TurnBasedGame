using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught
{
    public class DefaultEnglishDraughtUI : UIHaveTransformDataBehavior<DefaultEnglishDraughtUI.UIData>
    {

        #region UIData

        public class UIData : DefaultGameTypeUI
        {

            public VP<EditData<DefaultEnglishDraught>> editDefaultEnglishDraught;

            public VP<UIRectTransform.ShowType> showType;

            #region threeMoveRandom

            public VP<RequestChangeBoolUI.UIData> threeMoveRandom;

            public void makeRequestChangeThreeMoveRandom(RequestChangeUpdate<bool>.UpdateData update, bool newThreeMoveRandom)
            {
                // Find
                DefaultEnglishDraught defaultEnglishDraught = null;
                {
                    EditData<DefaultEnglishDraught> editDefaultEnglishDraught = this.editDefaultEnglishDraught.v;
                    if (editDefaultEnglishDraught != null)
                    {
                        defaultEnglishDraught = editDefaultEnglishDraught.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultEnglishDraught null: " + this);
                    }
                }
                // Process
                if (defaultEnglishDraught != null)
                {
                    defaultEnglishDraught.requestChangeThreeMoveRandom(Server.getProfileUserId(defaultEnglishDraught), newThreeMoveRandom);
                }
                else
                {
                    Debug.LogError("defaultEnglishDraught null: " + this);
                }
            }

            #endregion

            #region maxPly

            public VP<RequestChangeIntUI.UIData> maxPly;

            public void makeRequestChangeMaxPly(RequestChangeUpdate<int>.UpdateData update, int newMaxPly)
            {
                // Find
                DefaultEnglishDraught defaultEnglishDraught = null;
                {
                    EditData<DefaultEnglishDraught> editDefaultEnglishDraught = this.editDefaultEnglishDraught.v;
                    if (editDefaultEnglishDraught != null)
                    {
                        defaultEnglishDraught = editDefaultEnglishDraught.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultEnglishDraught null: " + this);
                    }
                }
                // Process
                if (defaultEnglishDraught != null)
                {
                    defaultEnglishDraught.requestChangeMaxPly(Server.getProfileUserId(defaultEnglishDraught), newMaxPly);
                }
                else
                {
                    Debug.LogError("defaultEnglishDraught null: " + this);
                }
            }

            #endregion

            public VP<MiniGameDataUI.UIData> miniGameDataUIData;

            #region Constructor

            public enum Property
            {
                editDefaultEnglishDraught,
                showType,
                threeMoveRandom,
                maxPly,
                miniGameDataUIData
            }

            public UIData() : base()
            {
                this.editDefaultEnglishDraught = new VP<EditData<DefaultEnglishDraught>>(this, (byte)Property.editDefaultEnglishDraught, new EditData<DefaultEnglishDraught>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                {
                    this.threeMoveRandom = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.threeMoveRandom, new RequestChangeBoolUI.UIData());
                    // event
                    this.threeMoveRandom.v.updateData.v.request.v = makeRequestChangeThreeMoveRandom;
                }
                {
                    this.maxPly = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.maxPly, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.maxPly.v.limit.makeId();
                            have.min.v = 100;
                            have.max.v = 500;
                        }
                        this.maxPly.v.limit.v = have;
                    }
                    // event
                    this.maxPly.v.updateData.v.request.v = makeRequestChangeMaxPly;
                }
                this.miniGameDataUIData = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUIData, new MiniGameDataUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.EnglishDraught;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Default English Draughts");

        public Text lbThreeMoveRandom;
        private static readonly TxtLanguage txtThreeMoveRandom = new TxtLanguage("Three moves random");

        public Text lbMaxPly;
        private static readonly TxtLanguage txtMaxPly = new TxtLanguage("Max ply");

        static DefaultEnglishDraughtUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Mặc Định Cờ Đam Kiểu Anh");
                txtThreeMoveRandom.add(Language.Type.vi, "Ba nước đầu ngẫu nhiên");
                txtMaxPly.add(Language.Type.vi, "Số nước đi không tiến triễn sẽ hoà cờ");
            }
            // rect
            {
                threeMoveRandomRect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                maxPlyRect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
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
                    EditData<DefaultEnglishDraught> editDefaultEnglishDraught = this.data.editDefaultEnglishDraught.v;
                    if (editDefaultEnglishDraught != null)
                    {
                        editDefaultEnglishDraught.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editDefaultEnglishDraught);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editDefaultEnglishDraught);
                                // set origin
                                {
                                    RequestChange.RefreshUI(this.data.threeMoveRandom.v, editDefaultEnglishDraught, serverState, needReset, editData => editData.threeMoveRandom.v);
                                    RequestChange.RefreshUI(this.data.maxPly.v, editDefaultEnglishDraught, serverState, needReset, editData => editData.maxPly.v);
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
                                                // Find EnglishDraught
                                                EnglishDraught englishDraught = gameData.gameType.newOrOld<EnglishDraught>();
                                                {
                                                    // Make new englishDraught to update
                                                    EnglishDraught newEnglishDraught = null;
                                                    {
                                                        DefaultEnglishDraught show = editDefaultEnglishDraught.show.v.data;
                                                        if (show != null)
                                                        {
                                                            DefaultEnglishDraught defaultEnglishDraught = (DefaultEnglishDraught)DataUtils.cloneData(show);
                                                            {
                                                                defaultEnglishDraught.threeMoveRandom.v = false;
                                                            }
                                                            newEnglishDraught = (EnglishDraught)defaultEnglishDraught.makeDefaultGameType();
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("show null");
                                                        }
                                                    }
                                                    // Copy
                                                    DataUtils.copyData(englishDraught, newEnglishDraught);
                                                }
                                                gameData.gameType.v = englishDraught;
                                            }
                                        }
                                    }
                                }
                                this.data.miniGameDataUIData.v = miniGameDataUIData;
                            }
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
                            // threeMoveRandom
                            {
                                if (this.data.threeMoveRandom.v != null)
                                {
                                    if (lbThreeMoveRandom != null)
                                    {
                                        lbThreeMoveRandom.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY(lbThreeMoveRandom.rectTransform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbThreeMoveRandom null");
                                    }
                                    UIRectTransform.SetPosY(this.data.threeMoveRandom.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbThreeMoveRandom != null)
                                    {
                                        lbThreeMoveRandom.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbThreeMoveRandom null");
                                    }
                                }
                            }
                            // maxPly
                            {
                                if (this.data.maxPly.v != null)
                                {
                                    if (lbMaxPly != null)
                                    {
                                        lbMaxPly.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY(lbMaxPly.rectTransform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbMaxPly null");
                                    }
                                    UIRectTransform.SetPosY(this.data.maxPly.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbMaxPly != null)
                                    {
                                        lbMaxPly.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbMaxPly null");
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
                                Setting.get().setTitleTextSize(lbTitle);
                            }
                            else
                            {
                                Debug.LogError("lbTitle null: " + this);
                            }
                            if (lbThreeMoveRandom != null)
                            {
                                lbThreeMoveRandom.text = txtThreeMoveRandom.get();
                                Setting.get().setLabelTextSize(lbThreeMoveRandom);
                            }
                            else
                            {
                                Debug.LogError("lbThreeMoveRandom null: " + this);
                            }
                            if (lbMaxPly != null)
                            {
                                lbMaxPly.text = txtMaxPly.get();
                                Setting.get().setLabelTextSize(lbMaxPly);
                            }
                            else
                            {
                                Debug.LogError("lbMaxPlay null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editDefaultEnglishDraught null: " + this);
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
        public RequestChangeIntUI requestIntPrefab;

        public static readonly UIRectTransform threeMoveRandomRect = new UIRectTransform(UIConstants.RequestBoolRect);
        public static readonly UIRectTransform maxPlyRect = new UIRectTransform(UIConstants.RequestRect);

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
                    uiData.editDefaultEnglishDraught.allAddCallBack(this);
                    uiData.threeMoveRandom.allAddCallBack(this);
                    uiData.maxPly.allAddCallBack(this);
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
                // editDefaultEnglishDraught
                {
                    if (data is EditData<DefaultEnglishDraught>)
                    {
                        EditData<DefaultEnglishDraught> editDefaultEnglishDraught = data as EditData<DefaultEnglishDraught>;
                        // Child
                        {
                            editDefaultEnglishDraught.show.allAddCallBack(this);
                            editDefaultEnglishDraught.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultEnglishDraught)
                        {
                            DefaultEnglishDraught defaultEnglishDraught = data as DefaultEnglishDraught;
                            // Parent
                            {
                                DataUtils.addParentCallBack(defaultEnglishDraught, this, ref this.server);
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
                                case UIData.Property.threeMoveRandom:
                                    {
                                        UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, threeMoveRandomRect);
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
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.maxPly:
                                    {
                                        UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, maxPlyRect);
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
                    uiData.editDefaultEnglishDraught.allRemoveCallBack(this);
                    uiData.threeMoveRandom.allRemoveCallBack(this);
                    uiData.maxPly.allRemoveCallBack(this);
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
                // editDefaultEnglishDraught
                {
                    if (data is EditData<DefaultEnglishDraught>)
                    {
                        EditData<DefaultEnglishDraught> editDefaultEnglishDraught = data as EditData<DefaultEnglishDraught>;
                        // Child
                        {
                            editDefaultEnglishDraught.show.allRemoveCallBack(this);
                            editDefaultEnglishDraught.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultEnglishDraught)
                        {
                            DefaultEnglishDraught defaultEnglishDraught = data as DefaultEnglishDraught;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(defaultEnglishDraught, this, ref this.server);
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
                    case UIData.Property.editDefaultEnglishDraught:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.threeMoveRandom:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.maxPly:
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
                    case Setting.Property.contentTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
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
                // EditDefaultEnglishDraught
                {
                    if (wrapProperty.p is EditData<DefaultEnglishDraught>)
                    {
                        switch ((EditData<DefaultEnglishDraught>.Property)wrapProperty.n)
                        {
                            case EditData<DefaultEnglishDraught>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<DefaultEnglishDraught>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultEnglishDraught>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultEnglishDraught>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<DefaultEnglishDraught>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<DefaultEnglishDraught>.Property.editType:
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
                        if (wrapProperty.p is DefaultEnglishDraught)
                        {
                            switch ((DefaultEnglishDraught.Property)wrapProperty.n)
                            {
                                case DefaultEnglishDraught.Property.threeMoveRandom:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultEnglishDraught.Property.maxPly:
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
                if (wrapProperty.p is RequestChangeIntUI.UIData)
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