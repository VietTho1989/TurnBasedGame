using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
    public class TimePerTurnInfoUI : UIHaveTransformDataBehavior<TimePerTurnInfoUI.UIData>
    {

        #region UIData

        public class UIData : Data, EditDataUI.UIData<TimePerTurnInfo>
        {

            public VP<EditData<TimePerTurnInfo>> editTimePerTurnInfo;

            public VP<UIRectTransform.ShowType> showType;

            #region sub

            public abstract class Sub : Data
            {

                public abstract TimePerTurnInfo.Type getType();

            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                editTimePerTurnInfo,
                showType,
                sub
            }

            public UIData() : base()
            {
                this.editTimePerTurnInfo = new VP<EditData<TimePerTurnInfo>>(this, (byte)Property.editTimePerTurnInfo, new EditData<TimePerTurnInfo>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            }

            #endregion

            #region implement interface

            public EditData<TimePerTurnInfo> getEditData()
            {
                return this.editTimePerTurnInfo.v;
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Time Per Turn");

        static TimePerTurnInfoUI()
        {
            txtTitle.add(Language.Type.vi, "Thời Gian Mỗi Lượt");
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
                    EditData<TimePerTurnInfo> editTimePerTurnInfo = this.data.editTimePerTurnInfo.v;
                    if (editTimePerTurnInfo != null)
                    {
                        editTimePerTurnInfo.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editTimePerTurnInfo);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editTimePerTurnInfo);
                                // set origin
                                {
                                    // sub
                                    {
                                        TimePerTurnInfo show = editTimePerTurnInfo.show.v.data;
                                        TimePerTurnInfo compare = editTimePerTurnInfo.compare.v.data;
                                        if (show != null)
                                        {
                                            switch (show.getType())
                                            {
                                                case TimePerTurnInfo.Type.Limit:
                                                    {
                                                        TimePerTurnInfo.Limit haveLimit = show as TimePerTurnInfo.Limit;
                                                        // UIData
                                                        TimePerTurnInfoLimitUI.UIData haveLimitUIData = this.data.sub.newOrOld<TimePerTurnInfoLimitUI.UIData>();
                                                        {
                                                            EditData<TimePerTurnInfo.Limit> editHaveLimit = haveLimitUIData.editLimit.v;
                                                            if (editHaveLimit != null)
                                                            {
                                                                // origin
                                                                editHaveLimit.origin.v = new ReferenceData<TimePerTurnInfo.Limit>((TimePerTurnInfo.Limit)editTimePerTurnInfo.origin.v.data);
                                                                // show
                                                                editHaveLimit.show.v = new ReferenceData<TimePerTurnInfo.Limit>(haveLimit);
                                                                // compare
                                                                editHaveLimit.compare.v = new ReferenceData<TimePerTurnInfo.Limit>((TimePerTurnInfo.Limit)compare);
                                                                // compareOtherType
                                                                editHaveLimit.compareOtherType.v = new ReferenceData<Data>(editTimePerTurnInfo.compareOtherType.v.data);
                                                                // canEdit
                                                                editHaveLimit.canEdit.v = editTimePerTurnInfo.canEdit.v;
                                                                // editType
                                                                editHaveLimit.editType.v = editTimePerTurnInfo.editType.v;
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("editHaveLimit null: " + this);
                                                            }
                                                            haveLimitUIData.showType.v = UIRectTransform.ShowType.HeadLess;
                                                        }
                                                        this.data.sub.v = haveLimitUIData;
                                                    }
                                                    break;
                                                case TimePerTurnInfo.Type.NoLimit:
                                                    {
                                                        TimePerTurnInfo.NoLimit noLimit = show as TimePerTurnInfo.NoLimit;
                                                        // UIData
                                                        TimePerTurnInfoNoLimitUI.UIData noLimitUIData = this.data.sub.newOrOld<TimePerTurnInfoNoLimitUI.UIData>();
                                                        {
                                                            EditData<TimePerTurnInfo.NoLimit> editNoLimit = noLimitUIData.editNoLimit.v;
                                                            if (editNoLimit != null)
                                                            {
                                                                // origin
                                                                editNoLimit.origin.v = new ReferenceData<TimePerTurnInfo.NoLimit>((TimePerTurnInfo.NoLimit)editTimePerTurnInfo.origin.v.data);
                                                                // show
                                                                editNoLimit.show.v = new ReferenceData<TimePerTurnInfo.NoLimit>(noLimit);
                                                                // compare
                                                                editNoLimit.compare.v = new ReferenceData<TimePerTurnInfo.NoLimit>((TimePerTurnInfo.NoLimit)compare);
                                                                // compareOtherType
                                                                editNoLimit.compareOtherType.v = new ReferenceData<Data>(editTimePerTurnInfo.compareOtherType.v.data);
                                                                // canEdit
                                                                editNoLimit.canEdit.v = editTimePerTurnInfo.canEdit.v;
                                                                // editType
                                                                editNoLimit.editType.v = editTimePerTurnInfo.editType.v;
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("editNoLimit null: " + this);
                                                            }
                                                            noLimitUIData.showType.v = UIRectTransform.ShowType.HeadLess;
                                                        }
                                                        this.data.sub.v = noLimitUIData;
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown type: " + show.getType() + "; " + this);
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("show null");
                                        }
                                    }
                                }
                                needReset = false;
                            }
                        }
                    }
                    else
                    {
                        // Debug.LogError ("editTimePerTurnInfo null: " + this);
                    }
                    // UISize
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                        // sub
                        {
                            deltaY += UIRectTransform.SetPosY(this.data.sub.v, deltaY);
                        }
                        // set
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

        public TimePerTurnInfoNoLimitUI noLimitPrefab;
        public TimePerTurnInfoLimitUI limitPrefab;

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
                    uiData.editTimePerTurnInfo.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
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
                // EditData
                {
                    if (data is EditData<TimePerTurnInfo>)
                    {
                        EditData<TimePerTurnInfo> editTimePerTurnInfo = data as EditData<TimePerTurnInfo>;
                        // Child
                        {
                            editTimePerTurnInfo.show.allAddCallBack(this);
                            editTimePerTurnInfo.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is TimePerTurnInfo)
                        {
                            TimePerTurnInfo timePerTurnInfo = data as TimePerTurnInfo;
                            // Parent
                            {
                                DataUtils.addParentCallBack(timePerTurnInfo, this, ref this.server);
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
                // Sub
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case TimePerTurnInfo.Type.Limit:
                                {
                                    TimePerTurnInfoLimitUI.UIData limitUIData = sub as TimePerTurnInfoLimitUI.UIData;
                                    UIUtils.Instantiate(limitUIData, limitPrefab, this.transform);
                                }
                                break;
                            case TimePerTurnInfo.Type.NoLimit:
                                {
                                    TimePerTurnInfoNoLimitUI.UIData noLimitUIData = sub as TimePerTurnInfoNoLimitUI.UIData;
                                    UIUtils.Instantiate(noLimitUIData, noLimitPrefab, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                break;
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
                    uiData.editTimePerTurnInfo.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
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
                // EditData
                {
                    if (data is EditData<TimePerTurnInfo>)
                    {
                        EditData<TimePerTurnInfo> editTimePerTurnInfo = data as EditData<TimePerTurnInfo>;
                        // Child
                        {
                            editTimePerTurnInfo.show.allRemoveCallBack(this);
                            editTimePerTurnInfo.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is TimePerTurnInfo)
                        {
                            TimePerTurnInfo timePerTurnInfo = data as TimePerTurnInfo;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(timePerTurnInfo, this, ref this.server);
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
                // Sub
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case TimePerTurnInfo.Type.Limit:
                                {
                                    TimePerTurnInfoLimitUI.UIData limitUIData = sub as TimePerTurnInfoLimitUI.UIData;
                                    limitUIData.removeCallBackAndDestroy(typeof(TimePerTurnInfoLimitUI));
                                }
                                break;
                            case TimePerTurnInfo.Type.NoLimit:
                                {
                                    TimePerTurnInfoNoLimitUI.UIData noLimitUIData = sub as TimePerTurnInfoNoLimitUI.UIData;
                                    noLimitUIData.removeCallBackAndDestroy(typeof(TimePerTurnInfoNoLimitUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
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
                    case UIData.Property.editTimePerTurnInfo:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.sub:
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
                // EditData
                {
                    if (wrapProperty.p is EditData<TimePerTurnInfo>)
                    {
                        switch ((EditData<TimePerTurnInfo>.Property)wrapProperty.n)
                        {
                            case EditData<TimePerTurnInfo>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<TimePerTurnInfo>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<TimePerTurnInfo>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<TimePerTurnInfo>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<TimePerTurnInfo>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<TimePerTurnInfo>.Property.editType:
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
                        if (wrapProperty.p is TimePerTurnInfo)
                        {
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
                // Sub
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}