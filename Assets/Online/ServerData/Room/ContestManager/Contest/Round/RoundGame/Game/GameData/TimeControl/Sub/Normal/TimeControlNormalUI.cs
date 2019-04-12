using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TimeControl.Normal;

namespace TimeControl.Normal
{
    public class TimeControlNormalUI : UIHaveTransformDataBehavior<TimeControlNormalUI.UIData>
    {

        #region UIData

        public class UIData : TimeControlUI.UIData.Sub, EditDataUI.UIData<TimeControlNormal>
        {

            public VP<EditData<TimeControlNormal>> editTimeControlNormal;

            public VP<UIRectTransform.ShowType> showType;

            #region generalInfo

            public VP<TimeInfoUI.UIData> generalInfo;

            #endregion

            #region playerTimeInfos

            // TODO Can hoan thien

            #endregion

            #region Constructor

            public enum Property
            {
                editTimeControlNormal,
                showType,
                generalInfo
            }

            public UIData() : base()
            {
                this.editTimeControlNormal = new VP<EditData<TimeControlNormal>>(this, (byte)Property.editTimeControlNormal, new EditData<TimeControlNormal>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                this.generalInfo = new VP<TimeInfoUI.UIData>(this, (byte)Property.generalInfo, new TimeInfoUI.UIData());
            }

            #endregion

            public override TimeControl.Sub.Type getType()
            {
                return TimeControl.Sub.Type.Normal;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {

                }
                return isProcess;
            }

            #region implement interface

            public EditData<TimeControlNormal> getEditData()
            {
                return this.editTimeControlNormal.v;
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Time Control Normal");

        static TimeControlNormalUI()
        {
            txtTitle.add(Language.Type.vi, "Điều Khiển Thời Gian Bình Thường");
        }

        #endregion

        #region Refresh

        protected bool needReset = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<TimeControlNormal> editTimeControlNormal = this.data.editTimeControlNormal.v;
                    if (editTimeControlNormal != null)
                    {
                        // update
                        editTimeControlNormal.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editTimeControlNormal);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editTimeControlNormal);
                                // set origin
                                {
                                    EditDataUI.RefreshChildUI(this.data, this.data.generalInfo.v, editData => editData.generalInfo.v);
                                }
                                needReset = false;
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                            // generalInfo
                            deltaY += UIRectTransform.SetPosY(this.data.generalInfo.v, deltaY);
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
                                Debug.LogError("lbTitle null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editTimeControlNormal null: " + this);
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

        public TimeInfoUI timeInfoPrefab;

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
                    uiData.editTimeControlNormal.allAddCallBack(this);
                    uiData.generalInfo.allAddCallBack(this);
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
                // editTimeControlNormal
                {
                    if (data is EditData<TimeControlNormal>)
                    {
                        EditData<TimeControlNormal> editTimeControlNormal = data as EditData<TimeControlNormal>;
                        // Child
                        {
                            editTimeControlNormal.show.allAddCallBack(this);
                            editTimeControlNormal.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is TimeControlNormal)
                        {
                            TimeControlNormal timeControlNormal = data as TimeControlNormal;
                            // Parent
                            {
                                DataUtils.addParentCallBack(timeControlNormal, this, ref this.server);
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
                // timeInfo
                {
                    if (data is TimeInfoUI.UIData)
                    {
                        TimeInfoUI.UIData timeInfoUIData = data as TimeInfoUI.UIData;
                        // UI
                        {
                            WrapProperty wrapProperty = timeInfoUIData.p;
                            if (wrapProperty != null)
                            {
                                switch ((UIData.Property)wrapProperty.n)
                                {
                                    case UIData.Property.generalInfo:
                                        UIUtils.Instantiate(timeInfoUIData, timeInfoPrefab, this.transform);
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
                        // Child
                        {
                            TransformData.AddCallBack(timeInfoUIData, this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is TransformData)
                    {
                        dirty = true;
                        return;
                    }
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
                    uiData.editTimeControlNormal.allRemoveCallBack(this);
                    uiData.generalInfo.allRemoveCallBack(this);
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
                // editTimeControlNormal
                {
                    if (data is EditData<TimeControlNormal>)
                    {
                        EditData<TimeControlNormal> editTimeControlNormal = data as EditData<TimeControlNormal>;
                        // Child
                        {
                            editTimeControlNormal.show.allRemoveCallBack(this);
                            editTimeControlNormal.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is TimeControlNormal)
                        {
                            TimeControlNormal timeControlNormal = data as TimeControlNormal;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(timeControlNormal, this, ref this.server);
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
                // timeInfoUI
                {
                    if (data is TimeInfoUI.UIData)
                    {
                        TimeInfoUI.UIData timeInfoUIData = data as TimeInfoUI.UIData;
                        // Child
                        {
                            TransformData.RemoveCallBack(timeInfoUIData, this);
                        }
                        // UI
                        {
                            timeInfoUIData.removeCallBackAndDestroy(typeof(TimeInfoUI));
                        }
                        return;
                    }
                    // Child
                    if (data is TransformData)
                    {
                        return;
                    }
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
                    case UIData.Property.editTimeControlNormal:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.generalInfo:
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
                // editTimeControlNormal
                {
                    if (wrapProperty.p is EditData<TimeControlNormal>)
                    {
                        switch ((EditData<TimeControlNormal>.Property)wrapProperty.n)
                        {
                            case EditData<TimeControlNormal>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<TimeControlNormal>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<TimeControlNormal>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<TimeControlNormal>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<TimeControlNormal>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<TimeControlNormal>.Property.editType:
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
                        if (wrapProperty.p is TimeControlNormal)
                        {
                            switch ((TimeControlNormal.Property)wrapProperty.n)
                            {
                                case TimeControlNormal.Property.generalInfo:
                                    dirty = true;
                                    break;
                                case TimeControlNormal.Property.playerTimeInfos:
                                    dirty = true;
                                    break;
                                case TimeControlNormal.Property.playerTotalTimes:
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
                // timeInfoUI
                {
                    if (wrapProperty.p is TimeInfoUI.UIData)
                    {
                        return;
                    }
                    // Child
                    if (wrapProperty.p is TransformData)
                    {
                        switch ((TransformData.Property)wrapProperty.n)
                        {
                            case TransformData.Property.anchoredPosition:
                                break;
                            case TransformData.Property.anchorMin:
                                break;
                            case TransformData.Property.anchorMax:
                                break;
                            case TransformData.Property.pivot:
                                break;
                            case TransformData.Property.offsetMin:
                                break;
                            case TransformData.Property.offsetMax:
                                break;
                            case TransformData.Property.sizeDelta:
                                break;
                            case TransformData.Property.rotation:
                                break;
                            case TransformData.Property.scale:
                                break;
                            case TransformData.Property.size:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
        }

        #endregion

    }
}