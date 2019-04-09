using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.HourGlass
{
    public class TimeControlHourGlassUI : UIHaveTransformDataBehavior<TimeControlHourGlassUI.UIData>
    {

        #region UIData

        public class UIData : TimeControlUI.UIData.Sub
        {

            public VP<EditData<TimeControlHourGlass>> editTimeControlHourGlass;

            public VP<UIRectTransform.ShowType> showType;

            #region initTime

            public VP<RequestChangeFloatUI.UIData> initTime;

            public void makeRequestChangeInitTime(RequestChangeUpdate<float>.UpdateData update, float newInitTime)
            {
                // Find
                TimeControlHourGlass timeControlHourGlass = null;
                {
                    EditData<TimeControlHourGlass> editTimeControlHourGlass = this.editTimeControlHourGlass.v;
                    if (editTimeControlHourGlass != null)
                    {
                        timeControlHourGlass = editTimeControlHourGlass.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editTimeControlHourGlass null: " + this);
                    }
                }
                // Process
                if (timeControlHourGlass != null)
                {
                    timeControlHourGlass.requestChangeInitTime(Server.getProfileUserId(timeControlHourGlass), newInitTime);
                }
                else
                {
                    Debug.LogError("timeControlHourGlass null: " + this);
                }
            }

            #endregion

            #region lagCompensation

            public VP<RequestChangeFloatUI.UIData> lagCompensation;

            public void makeRequestChangeLagCompensation(RequestChangeUpdate<float>.UpdateData update, float newLagCompensation)
            {
                // Find
                TimeControlHourGlass timeControlHourGlass = null;
                {
                    EditData<TimeControlHourGlass> editTimeControlHourGlass = this.editTimeControlHourGlass.v;
                    if (editTimeControlHourGlass != null)
                    {
                        timeControlHourGlass = editTimeControlHourGlass.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editTimeControlHourGlass null: " + this);
                    }
                }
                // Process
                if (timeControlHourGlass != null)
                {
                    timeControlHourGlass.requestChangeLagCompensation(Server.getProfileUserId(timeControlHourGlass), newLagCompensation);
                }
                else
                {
                    Debug.LogError("timeControlHourGlass null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editTimeControlHourGlass,
                showType,
                initTime,
                lagCompensation
            }

            public UIData() : base()
            {
                this.editTimeControlHourGlass = new VP<EditData<TimeControlHourGlass>>(this, (byte)Property.editTimeControlHourGlass, new EditData<TimeControlHourGlass>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // initTime
                {
                    this.initTime = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.initTime, new RequestChangeFloatUI.UIData());
                    // event
                    this.initTime.v.updateData.v.request.v = makeRequestChangeInitTime;
                }
                // lagCompensation
                {
                    this.lagCompensation = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.lagCompensation, new RequestChangeFloatUI.UIData());
                    // event
                    this.lagCompensation.v.updateData.v.request.v = makeRequestChangeLagCompensation;
                }
            }

            #endregion

            public override TimeControl.Sub.Type getType()
            {
                return TimeControl.Sub.Type.HourGlass;
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Time Control Hourglass");

        public Text lbInitTime;
        private static readonly TxtLanguage txtInitTime = new TxtLanguage("Init time");

        public Text lbLagCompensation;
        private static readonly TxtLanguage txtLagCompensation = new TxtLanguage("Lag compensation");

        static TimeControlHourGlassUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Điểu Khiển Thời Gian Đồng Hồ Cát");
                txtInitTime.add(Language.Type.vi, "Thời gian ban đầu");
                txtLagCompensation.add(Language.Type.vi, "Bồi thường lag");
            }
            // rect
            {
                initTimeRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                lagCompensationRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
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
                    EditData<TimeControlHourGlass> editTimeControlHourGlass = this.data.editTimeControlHourGlass.v;
                    if (editTimeControlHourGlass != null)
                    {
                        editTimeControlHourGlass.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editTimeControlHourGlass);
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editTimeControlHourGlass);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.initTime.v, editTimeControlHourGlass, serverState, needReset, editData => editData.initTime.v);
                                RequestChange.RefreshUI(this.data.lagCompensation.v, editTimeControlHourGlass, serverState, needReset, editData => editData.lagCompensation.v);
                            }
                            needReset = false;
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
                            // initTime
                            {
                                if (this.data.initTime.v != null)
                                {
                                    if (lbInitTime != null)
                                    {
                                        UIRectTransform.SetPosY(lbInitTime.rectTransform, deltaY);
                                        lbInitTime.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbInitTime null");
                                    }
                                    UIRectTransform.SetPosY(this.data.initTime.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbInitTime != null)
                                    {
                                        lbInitTime.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbInitTime null");
                                    }
                                }
                            }
                            // lagCompensation
                            {
                                if (this.data.lagCompensation.v != null)
                                {
                                    if (lbLagCompensation != null)
                                    {
                                        UIRectTransform.SetPosY(lbLagCompensation.rectTransform, deltaY);
                                        lbLagCompensation.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbLagCompensation null");
                                    }
                                    UIRectTransform.SetPosY(this.data.lagCompensation.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbLagCompensation != null)
                                    {
                                        lbLagCompensation.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbLagCompensation null");
                                    }
                                }
                            }
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
                            if (lbInitTime != null)
                            {
                                lbInitTime.text = txtInitTime.get();
                                Setting.get().setLabelTextSize(lbInitTime);
                            }
                            else
                            {
                                Debug.LogError("lbInitTime null: " + this);
                            }
                            if (lbLagCompensation != null)
                            {
                                lbLagCompensation.text = txtLagCompensation.get();
                                Setting.get().setLabelTextSize(lbLagCompensation);
                            }
                            else
                            {
                                Debug.LogError("lbLagCompensation null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editTimeControlHourGlass null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public RequestChangeFloatUI requestFloatPrefab;

        private static readonly UIRectTransform initTimeRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform lagCompensationRect = new UIRectTransform(UIConstants.RequestRect);

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
                    uiData.editTimeControlHourGlass.allAddCallBack(this);
                    uiData.initTime.allAddCallBack(this);
                    uiData.lagCompensation.allAddCallBack(this);
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
                // editTimeControlHourGlass
                {
                    if (data is EditData<TimeControlHourGlass>)
                    {
                        EditData<TimeControlHourGlass> editTimeControlHourGlass = data as EditData<TimeControlHourGlass>;
                        // Child
                        {
                            editTimeControlHourGlass.show.allAddCallBack(this);
                            editTimeControlHourGlass.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is TimeControlHourGlass)
                        {
                            TimeControlHourGlass timeControlHourGlass = data as TimeControlHourGlass;
                            // Parent
                            {
                                DataUtils.addParentCallBack(timeControlHourGlass, this, ref this.server);
                            }
                            dirty = true;
                            needReset = true;
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
                if (data is RequestChangeFloatUI.UIData)
                {
                    RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.initTime:
                                    {
                                        UIUtils.Instantiate(requestChange, requestFloatPrefab, this.transform, initTimeRect);
                                    }
                                    break;
                                case UIData.Property.lagCompensation:
                                    {
                                        UIUtils.Instantiate(requestChange, requestFloatPrefab, this.transform, lagCompensationRect);
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
                    uiData.editTimeControlHourGlass.allRemoveCallBack(this);
                    uiData.initTime.allRemoveCallBack(this);
                    uiData.lagCompensation.allRemoveCallBack(this);
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
                // editTimeControlHourGlass
                {
                    if (data is EditData<TimeControlHourGlass>)
                    {
                        EditData<TimeControlHourGlass> editTimeControlHourGlass = data as EditData<TimeControlHourGlass>;
                        // Child
                        {
                            editTimeControlHourGlass.show.allRemoveCallBack(this);
                            editTimeControlHourGlass.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is TimeControlHourGlass)
                        {
                            TimeControlHourGlass timeControlHourGlass = data as TimeControlHourGlass;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(timeControlHourGlass, this, ref this.server);
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
                if (data is RequestChangeFloatUI.UIData)
                {
                    RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeFloatUI));
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
                    case UIData.Property.editTimeControlHourGlass:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.initTime:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.lagCompensation:
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
                // editTimeControlHourGlass
                {
                    if (wrapProperty.p is EditData<TimeControlHourGlass>)
                    {
                        switch ((EditData<TimeControlHourGlass>.Property)wrapProperty.n)
                        {
                            case EditData<TimeControlHourGlass>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<TimeControlHourGlass>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<TimeControlHourGlass>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<TimeControlHourGlass>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<TimeControlHourGlass>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<TimeControlHourGlass>.Property.editType:
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
                        if (wrapProperty.p is TimeControlHourGlass)
                        {
                            switch ((TimeControlHourGlass.Property)wrapProperty.n)
                            {
                                case TimeControlHourGlass.Property.initTime:
                                    dirty = true;
                                    break;
                                case TimeControlHourGlass.Property.lagCompensation:
                                    dirty = true;
                                    break;
                                case TimeControlHourGlass.Property.playerTimes:
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
                if (wrapProperty.p is RequestChangeFloatUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}