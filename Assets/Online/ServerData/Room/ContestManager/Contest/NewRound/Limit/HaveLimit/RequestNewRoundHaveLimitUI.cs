using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RequestNewRoundHaveLimitUI : UIHaveTransformDataBehavior<RequestNewRoundHaveLimitUI.UIData>
    {

        #region UIData

        public class UIData : SingleContestFactoryUI.UIData.NewRoundLimitUI
        {

            public VP<EditData<RequestNewRoundHaveLimit>> editHaveLimit;

            public VP<UIRectTransform.ShowType> showType;

            #region maxRound

            public VP<RequestChangeIntUI.UIData> maxRound;

            public void makeRequestChangeMaxRound(RequestChangeUpdate<int>.UpdateData update, int newMaxRound)
            {
                // Find
                RequestNewRoundHaveLimit haveLimit = null;
                {
                    EditData<RequestNewRoundHaveLimit> editHaveLimit = this.editHaveLimit.v;
                    if (editHaveLimit != null)
                    {
                        haveLimit = editHaveLimit.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editHaveLimit null: " + this);
                    }
                }
                // Process
                if (haveLimit != null)
                {
                    haveLimit.requestChangeMaxRound(Server.getProfileUserId(haveLimit), newMaxRound);
                }
                else
                {
                    Debug.LogError("haveLimit null: " + this);
                }
            }

            #endregion

            #region enoughScoreStop

            public VP<RequestChangeBoolUI.UIData> enoughScoreStop;

            public void makeRequestEnoughScoreStop(RequestChangeUpdate<bool>.UpdateData update, bool newEnoughScoreStop)
            {
                // Find
                RequestNewRoundHaveLimit haveLimit = null;
                {
                    EditData<RequestNewRoundHaveLimit> editHaveLimit = this.editHaveLimit.v;
                    if (editHaveLimit != null)
                    {
                        haveLimit = editHaveLimit.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editHaveLimit null: " + this);
                    }
                }
                // Process
                if (haveLimit != null)
                {
                    haveLimit.requestChangeEnoughScoreStop(Server.getProfileUserId(haveLimit), newEnoughScoreStop);
                }
                else
                {
                    Debug.LogError("haveLimit null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editHaveLimit,
                showType,
                maxRound,
                enoughScoreStop
            }

            public UIData() : base()
            {
                this.editHaveLimit = new VP<EditData<RequestNewRoundHaveLimit>>(this, (byte)Property.editHaveLimit, new EditData<RequestNewRoundHaveLimit>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // maxRound
                {
                    this.maxRound = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.maxRound, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.maxRound.v.limit.makeId();
                            have.min.v = 1;
                            have.max.v = 25;
                        }
                        this.maxRound.v.limit.v = have;
                    }
                    // event
                    this.maxRound.v.updateData.v.request.v = makeRequestChangeMaxRound;
                }
                // enoughScoreStop
                {
                    this.enoughScoreStop = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.enoughScoreStop, new RequestChangeBoolUI.UIData());
                    this.enoughScoreStop.v.updateData.v.request.v = makeRequestEnoughScoreStop;
                }
            }

            #endregion

            public override RequestNewRound.Limit.Type getType()
            {
                return RequestNewRound.Limit.Type.HaveLimit;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {

                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Have limit rounds");

        public Text lbMaxRound;
        private static readonly TxtLanguage txtMaxRound = new TxtLanguage("Max round count");

        public Text lbEnoughScoreStop;
        private static readonly TxtLanguage txtEnoughScoreStop = new TxtLanguage("Enough score stop");

        static RequestNewRoundHaveLimitUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Số vòng có giới hạn");
                txtMaxRound.add(Language.Type.vi, "Số vòng tối đa");
                txtEnoughScoreStop.add(Language.Type.vi, "Đủ điểm thì dừng");
            }
            // rect
            {
                maxRoundRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                enoughScoreStopRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
            }
        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<RequestNewRoundHaveLimit> editHaveLimit = this.data.editHaveLimit.v;
                    if (editHaveLimit != null)
                    {
                        editHaveLimit.update();
                        // get show
                        RequestNewRoundHaveLimit show = editHaveLimit.show.v.data;
                        RequestNewRoundHaveLimit compare = editHaveLimit.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editHaveLimit.compareOtherType.v.data != null)
                                    {
                                        if (editHaveLimit.compareOtherType.v.data.GetType() != show.GetType())
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
                                    // maxRound
                                    {
                                        RequestChangeIntUI.UIData maxRound = this.data.maxRound.v;
                                        if (maxRound != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = maxRound.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.maxRound.v;
                                                updateData.canRequestChange.v = editHaveLimit.canEdit.v;
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
                                                    maxRound.showDifferent.v = true;
                                                    maxRound.compare.v = compare.maxRound.v;
                                                }
                                                else
                                                {
                                                    maxRound.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("maxRound null: " + this);
                                        }
                                    }
                                    // enoughScoreStop
                                    {
                                        RequestChangeBoolUI.UIData enoughScoreStop = this.data.enoughScoreStop.v;
                                        if (enoughScoreStop != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = enoughScoreStop.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.enoughScoreStop.v;
                                                updateData.canRequestChange.v = editHaveLimit.canEdit.v;
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
                                                    enoughScoreStop.showDifferent.v = true;
                                                    enoughScoreStop.compare.v = compare.enoughScoreStop.v;
                                                }
                                                else
                                                {
                                                    enoughScoreStop.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("enoughScoreStop null: " + this);
                                        }
                                    }
                                }
                                // reset
                                if (needReset)
                                {
                                    needReset = false;
                                    // maxRound
                                    {
                                        RequestChangeIntUI.UIData maxRound = this.data.maxRound.v;
                                        if (maxRound != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = maxRound.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = show.maxRound.v;
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("maxRound null: " + this);
                                        }
                                    }
                                    // enoughScoreStop
                                    {
                                        RequestChangeBoolUI.UIData enoughScoreStop = this.data.enoughScoreStop.v;
                                        if (enoughScoreStop != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = enoughScoreStop.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = show.enoughScoreStop.v;
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("enoughScoreStop null: " + this);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("show null: " + this);
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // Header
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
                            // maxRound
                            {
                                if (this.data.maxRound.v != null)
                                {
                                    if (lbMaxRound != null)
                                    {
                                        UIRectTransform.SetPosY(lbMaxRound.rectTransform, deltaY);
                                        lbMaxRound.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbMaxRound null");
                                    }
                                    UIRectTransform.SetPosY(this.data.maxRound.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbMaxRound != null)
                                    {
                                        lbMaxRound.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbMaxRound null");
                                    }
                                }
                            }
                            // enoughScoreStop
                            {
                                if (this.data.enoughScoreStop.v != null)
                                {
                                    if (lbEnoughScoreStop != null)
                                    {
                                        UIRectTransform.SetPosY(lbEnoughScoreStop.rectTransform, deltaY);
                                        lbEnoughScoreStop.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbEnoughScoreStop null");
                                    }
                                    UIRectTransform.SetPosY(this.data.enoughScoreStop.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbEnoughScoreStop != null)
                                    {
                                        lbEnoughScoreStop.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbEnoughScoreStop null");
                                    }
                                }
                            }
                            // set
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
                                Debug.LogError("lbTitle null");
                            }
                            if (lbMaxRound != null)
                            {
                                lbMaxRound.text = txtMaxRound.get();
                            }
                            else
                            {
                                Debug.LogError("lbMaxRound null");
                            }
                            if (lbEnoughScoreStop != null)
                            {
                                lbEnoughScoreStop.text = txtEnoughScoreStop.get();
                            }
                            else
                            {
                                Debug.LogError("lbEnoughScoreStop null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editHaveLimit null: " + this);
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

        public RequestChangeIntUI requestIntPrefab;
        public RequestChangeBoolUI requestBoolPrefab;

        private static readonly UIRectTransform maxRoundRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform enoughScoreStopRect = new UIRectTransform(UIConstants.RequestBoolRect);

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
                    uiData.editHaveLimit.allAddCallBack(this);
                    uiData.maxRound.allAddCallBack(this);
                    uiData.enoughScoreStop.allAddCallBack(this);
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
                // editHaveLimit
                {
                    if (data is EditData<RequestNewRoundHaveLimit>)
                    {
                        EditData<RequestNewRoundHaveLimit> editHaveLimit = data as EditData<RequestNewRoundHaveLimit>;
                        // Child
                        {
                            editHaveLimit.show.allAddCallBack(this);
                            editHaveLimit.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is RequestNewRoundHaveLimit)
                        {
                            RequestNewRoundHaveLimit haveLimit = data as RequestNewRoundHaveLimit;
                            // Parent
                            {
                                DataUtils.addParentCallBack(haveLimit, this, ref this.server);
                            }
                            needReset = true;
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
                // maxRound
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
                                case UIData.Property.maxRound:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, maxRoundRect);
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
                // enoughScoreStop
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
                                case UIData.Property.enoughScoreStop:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, enoughScoreStopRect);
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
            }
            Debug.LogError("Don't process: " + data + "; " + this);
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
                    uiData.editHaveLimit.allRemoveCallBack(this);
                    uiData.maxRound.allRemoveCallBack(this);
                    uiData.enoughScoreStop.allRemoveCallBack(this);
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
                // editHaveLimit
                {
                    if (data is EditData<RequestNewRoundHaveLimit>)
                    {
                        EditData<RequestNewRoundHaveLimit> editHaveLimit = data as EditData<RequestNewRoundHaveLimit>;
                        // Child
                        {
                            editHaveLimit.show.allRemoveCallBack(this);
                            editHaveLimit.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is RequestNewRoundHaveLimit)
                        {
                            RequestNewRoundHaveLimit haveLimit = data as RequestNewRoundHaveLimit;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(haveLimit, this, ref this.server);
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
                // maxRound
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                    }
                    return;
                }
                // enoughScoreStop
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
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
                    case UIData.Property.editHaveLimit:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.maxRound:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.enoughScoreStop:
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
                // editHaveLimit
                {
                    if (wrapProperty.p is EditData<RequestNewRoundHaveLimit>)
                    {
                        switch ((EditData<RequestNewRoundHaveLimit>.Property)wrapProperty.n)
                        {
                            case EditData<RequestNewRoundHaveLimit>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<RequestNewRoundHaveLimit>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<RequestNewRoundHaveLimit>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<RequestNewRoundHaveLimit>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<RequestNewRoundHaveLimit>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<RequestNewRoundHaveLimit>.Property.editType:
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
                        if (wrapProperty.p is RequestNewRoundHaveLimit)
                        {
                            switch ((RequestNewRoundHaveLimit.Property)wrapProperty.n)
                            {
                                case RequestNewRoundHaveLimit.Property.maxRound:
                                    dirty = true;
                                    break;
                                case RequestNewRoundHaveLimit.Property.enoughScoreStop:
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Parent
                        {
                            if (wrapProperty.p is Server)
                            {
                                Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                                return;
                            }
                        }
                    }
                }
                // maxRound
                if (wrapProperty.p is RequestChangeIntUI.UIData)
                {
                    return;
                }
                // enoughScoreStop
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}