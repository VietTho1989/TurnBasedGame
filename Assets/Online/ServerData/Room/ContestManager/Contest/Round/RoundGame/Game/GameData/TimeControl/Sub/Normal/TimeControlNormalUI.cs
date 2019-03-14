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

        public class UIData : TimeControlUI.UIData.Sub
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

        }

        #endregion

        #region Refresh

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        static TimeControlNormalUI()
        {
            txtTitle.add(Language.Type.vi, "Điều Khiển Thời Gian Bình Thường");
        }

        #endregion

        private bool needReset = true;

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
                        // get show
                        TimeControlNormal show = editTimeControlNormal.show.v.data;
                        TimeControlNormal compare = editTimeControlNormal.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editTimeControlNormal.compareOtherType.v.data != null)
                                    {
                                        if (editTimeControlNormal.compareOtherType.v.data.GetType() != show.GetType())
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
                                        // Debug.LogError ("server null: " + this);
                                    }
                                    if (serverState == Server.State.Type.Offline)
                                    {
                                        Debug.LogError("serverState: " + serverState + "; " + compare + "; " + this);
                                    }
                                }
                                // set origin
                                {
                                    // generalInfo
                                    {
                                        TimeInfoUI.UIData generalInfo = this.data.generalInfo.v;
                                        if (generalInfo != null)
                                        {
                                            EditData<TimeInfo> editGeneralInfo = generalInfo.editTimeInfo.v;
                                            if (editGeneralInfo != null)
                                            {
                                                // origin
                                                {
                                                    TimeInfo originTimeInfo = null;
                                                    {
                                                        TimeControlNormal originTimeControlNormal = editTimeControlNormal.origin.v.data;
                                                        if (originTimeControlNormal != null)
                                                        {
                                                            originTimeInfo = originTimeControlNormal.generalInfo.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("originTimeControlNormal null: " + this);
                                                        }
                                                    }
                                                    editGeneralInfo.origin.v = new ReferenceData<TimeInfo>(originTimeInfo);
                                                }
                                                // show
                                                {
                                                    TimeInfo showTimeInfo = null;
                                                    {
                                                        TimeControlNormal showTimeControlNormal = editTimeControlNormal.show.v.data;
                                                        if (showTimeControlNormal != null)
                                                        {
                                                            showTimeInfo = showTimeControlNormal.generalInfo.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("showTimeControlNormal null: " + this);
                                                        }
                                                    }
                                                    editGeneralInfo.show.v = new ReferenceData<TimeInfo>(showTimeInfo);
                                                }
                                                // compare
                                                {
                                                    TimeInfo compareTimeInfo = null;
                                                    {
                                                        TimeControlNormal compareTimeControlNormal = editTimeControlNormal.compare.v.data;
                                                        if (compareTimeControlNormal != null)
                                                        {
                                                            compareTimeInfo = compareTimeControlNormal.generalInfo.v;
                                                        }
                                                        else
                                                        {
                                                            // Debug.LogError ("compareTimeControlNormal null: " + this);
                                                        }
                                                    }
                                                    editGeneralInfo.compare.v = new ReferenceData<TimeInfo>(compareTimeInfo);
                                                }
                                                // compare other type
                                                {
                                                    TimeInfo compareOtherTypeTimeInfo = null;
                                                    {
                                                        TimeControlNormal compareOtherTypeTimeControlNormal = (TimeControlNormal)editTimeControlNormal.compareOtherType.v.data;
                                                        if (compareOtherTypeTimeControlNormal != null)
                                                        {
                                                            compareOtherTypeTimeInfo = compareOtherTypeTimeControlNormal.generalInfo.v;
                                                        }
                                                    }
                                                    editGeneralInfo.compareOtherType.v = new ReferenceData<Data>(compareOtherTypeTimeInfo);
                                                }
                                                // canEdit
                                                editGeneralInfo.canEdit.v = editTimeControlNormal.canEdit.v;
                                                // editType
                                                editGeneralInfo.editType.v = editTimeControlNormal.editType.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("editGeneralInfo null: " + this);
                                            }
                                            generalInfo.showType.v = UIRectTransform.ShowType.HeadLess;
                                        }
                                        else
                                        {
                                            Debug.LogError("generalInfo null");
                                        }
                                    }
                                }
                                // reset?
                                if (needReset)
                                {
                                    needReset = false;
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
                            // generalInfo
                            {
                                deltaY += UIRectTransform.SetPosY(this.data.generalInfo.v, deltaY);
                            }
                            // set
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get("Time Control Normal");
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