using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
    public class TimePerTurnInfoUI : UIBehavior<TimePerTurnInfoUI.UIData>, HaveTransformData
    {

        #region UIData

        public class UIData : Data
        {

            public VP<EditData<TimePerTurnInfo>> editTimePerTurnInfo;

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
                sub
            }

            public UIData() : base()
            {
                this.editTimePerTurnInfo = new VP<EditData<TimePerTurnInfo>>(this, (byte)Property.editTimePerTurnInfo, new EditData<TimePerTurnInfo>());
                this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        static TimePerTurnInfoUI()
        {
            txtTitle.add(Language.Type.vi, "Thời Gian Mỗi Lượt");
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
                        // get show
                        TimePerTurnInfo show = editTimePerTurnInfo.show.v.data;
                        TimePerTurnInfo compare = editTimePerTurnInfo.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editTimePerTurnInfo.compareOtherType.v.data != null)
                                    {
                                        if (editTimePerTurnInfo.compareOtherType.v.data.GetType() != show.GetType())
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
                                        Debug.LogError("server null: " + serverState + "; " + this);
                                    }
                                }
                                // set origin
                                {
                                    // sub
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
                                                    }
                                                    this.data.sub.v = noLimitUIData;
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + show.getType() + "; " + this);
                                                break;
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
                            // Debug.LogError ("show null: " + this);
                        }
                    }
                    else
                    {
                        // Debug.LogError ("editTimePerTurnInfo null: " + this);
                    }
                    // UISize
                    {
                        float deltaY = UIConstants.HeaderHeight;
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
                            lbTitle.text = txtTitle.get("Time Per Turn");
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
            updateTransformData();
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
                // Global
                Global.get().addCallBack(this);
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
                // Global
                Global.get().removeCallBack(this);
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