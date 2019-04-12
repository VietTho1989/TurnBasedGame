using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
    public class TimePerTurnInfoNoLimitUI : UIBehavior<TimePerTurnInfoNoLimitUI.UIData>
    {

        #region UIData

        public class UIData : TimePerTurnInfoUI.UIData.Sub
        {

            public VP<EditData<TimePerTurnInfo.NoLimit>> editNoLimit;

            public VP<UIRectTransform.ShowType> showType;

            #region Constructor

            public enum Property
            {
                editNoLimit,
                showType
            }

            public UIData() : base()
            {
                this.editNoLimit = new VP<EditData<TimePerTurnInfo.NoLimit>>(this, (byte)Property.editNoLimit, new EditData<TimePerTurnInfo.NoLimit>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            }

            #endregion

            public override TimePerTurnInfo.Type getType()
            {
                return TimePerTurnInfo.Type.NoLimit;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Time Per Turn No Limit");

        static TimePerTurnInfoNoLimitUI()
        {
            txtTitle.add(Language.Type.vi, "Thời Gian Mỗi Lượt Không Giới Hạn");
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
                    EditData<TimePerTurnInfo.NoLimit> editNoLimit = this.data.editNoLimit.v;
                    if (editNoLimit != null)
                    {
                        editNoLimit.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editNoLimit);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editNoLimit);
                                // set origin
                                {

                                }
                                needReset = false;
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
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
                        Debug.LogError("editNoLimit null: " + this);
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
                    uiData.editNoLimit.allAddCallBack(this);
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
                // editNoLimit
                {
                    if (data is EditData<TimePerTurnInfo.NoLimit>)
                    {
                        EditData<TimePerTurnInfo.NoLimit> editNoLimit = data as EditData<TimePerTurnInfo.NoLimit>;
                        // Child
                        {
                            editNoLimit.show.allAddCallBack(this);
                            editNoLimit.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is TimePerTurnInfo.NoLimit)
                        {
                            TimePerTurnInfo.NoLimit noLimit = data as TimePerTurnInfo.NoLimit;
                            // Parent
                            {
                                DataUtils.addParentCallBack(noLimit, this, ref this.server);
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
                    uiData.editNoLimit.allRemoveCallBack(this);
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
                // editNoLimit
                {
                    if (data is EditData<TimePerTurnInfo.NoLimit>)
                    {
                        EditData<TimePerTurnInfo.NoLimit> editNoLimit = data as EditData<TimePerTurnInfo.NoLimit>;
                        // Child
                        {
                            editNoLimit.show.allRemoveCallBack(this);
                            editNoLimit.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is TimePerTurnInfo.NoLimit)
                        {
                            TimePerTurnInfo.NoLimit noLimit = data as TimePerTurnInfo.NoLimit;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(noLimit, this, ref this.server);
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
                    case UIData.Property.editNoLimit:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
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
                // editNoLimit
                {
                    if (wrapProperty.p is EditData<TimePerTurnInfo.NoLimit>)
                    {
                        switch ((EditData<TimePerTurnInfo.NoLimit>.Property)wrapProperty.n)
                        {
                            case EditData<TimePerTurnInfo.NoLimit>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<TimePerTurnInfo.NoLimit>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<TimePerTurnInfo.NoLimit>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<TimePerTurnInfo.NoLimit>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<TimePerTurnInfo.NoLimit>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<TimePerTurnInfo.NoLimit>.Property.editType:
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
                        if (wrapProperty.p is TimePerTurnInfo.NoLimit)
                        {
                            switch ((TimePerTurnInfo.NoLimit.Property)wrapProperty.n)
                            {
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
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}