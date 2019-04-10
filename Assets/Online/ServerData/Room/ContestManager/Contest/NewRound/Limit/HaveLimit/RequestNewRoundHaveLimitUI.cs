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
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editHaveLimit);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editHaveLimit);
                                // set origin
                                {
                                    RequestChange.RefreshUI(this.data.maxRound.v, editHaveLimit, serverState, needReset, editData => editData.maxRound.v);
                                    RequestChange.RefreshUI(this.data.enoughScoreStop.v, editHaveLimit, serverState, needReset, editData => editData.enoughScoreStop.v);
                                }
                                needReset = false;
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // Header
                            UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                            // maxRound
                            UIUtils.SetLabelContentPosition(lbMaxRound, this.data.maxRound.v, ref deltaY);
                            // enoughScoreStop
                            UIUtils.SetLabelContentPosition(lbEnoughScoreStop, this.data.enoughScoreStop.v, ref deltaY);
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
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
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