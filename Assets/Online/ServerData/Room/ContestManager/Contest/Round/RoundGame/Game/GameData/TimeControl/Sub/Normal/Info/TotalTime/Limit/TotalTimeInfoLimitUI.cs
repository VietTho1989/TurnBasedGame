using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
    public class TotalTimeInfoLimitUI : UIBehavior<TotalTimeInfoLimitUI.UIData>
    {

        #region UIData

        public class UIData : TotalTimeInfoUI.UIData.Sub
        {

            public VP<EditData<TotalTimeInfo.Limit>> editLimit;

            public VP<UIRectTransform.ShowType> showType;

            #region perTurn

            public VP<RequestChangeFloatUI.UIData> totalTime;

            public void makeRequestChangeTotalTime(RequestChangeUpdate<float>.UpdateData update, float newTotalTime)
            {
                // Find
                TotalTimeInfo.Limit limit = null;
                {
                    EditData<TotalTimeInfo.Limit> editLimit = this.editLimit.v;
                    if (editLimit != null)
                    {
                        limit = editLimit.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editLimit null: " + this);
                    }
                }
                // Process
                if (limit != null)
                {
                    limit.requestChangeTotalTime(Server.getProfileUserId(limit), newTotalTime);
                }
                else
                {
                    Debug.LogError("limit null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editLimit,
                showType,
                totalTime
            }

            public UIData() : base()
            {
                this.editLimit = new VP<EditData<TotalTimeInfo.Limit>>(this, (byte)Property.editLimit, new EditData<TotalTimeInfo.Limit>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // totalTime
                {
                    this.totalTime = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.totalTime, new RequestChangeFloatUI.UIData());
                    // event
                    this.totalTime.v.updateData.v.request.v = makeRequestChangeTotalTime;
                }
            }

            #endregion

            public override TotalTimeInfo.Type getType()
            {
                return TotalTimeInfo.Type.Limit;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Total Time Limit");

        public Text lbTotalTime;
        private static readonly TxtLanguage txtTotalTime = new TxtLanguage("Total time");

        static TotalTimeInfoLimitUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Tổng Thời Gian Giới Hạn");
                txtTotalTime.add(Language.Type.vi, "Tổng thời gian");
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
                    EditData<TotalTimeInfo.Limit> editLimit = this.data.editLimit.v;
                    if (editLimit != null)
                    {
                        editLimit.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editLimit);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editLimit);
                                // set origin
                                {
                                    RequestChange.RefreshUI(this.data.totalTime.v, editLimit, serverState, needReset, editData => editData.totalTime.v);
                                }
                                needReset = false;
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                            // totalTime
                            UIUtils.SetLabelContentPosition(lbTotalTime, this.data.totalTime.v, ref deltaY);
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
                            if (lbTotalTime != null)
                            {
                                lbTotalTime.text = txtTotalTime.get();
                                Setting.get().setLabelTextSize(lbTotalTime);
                            }
                            else
                            {
                                Debug.LogError("lbTotalTime null: " + this);
                            }
                            txtTotalTime.add(Language.Type.vi, "Tổng thời gian");
                        }
                    }
                    else
                    {
                        Debug.LogError("editLimit null: " + this);
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
                    uiData.editLimit.allAddCallBack(this);
                    uiData.totalTime.allAddCallBack(this);
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
                // editLimit
                {
                    if (data is EditData<TotalTimeInfo.Limit>)
                    {
                        EditData<TotalTimeInfo.Limit> editLimit = data as EditData<TotalTimeInfo.Limit>;
                        // Child
                        {
                            editLimit.show.allAddCallBack(this);
                            editLimit.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is TotalTimeInfo.Limit)
                        {
                            TotalTimeInfo.Limit limit = data as TotalTimeInfo.Limit;
                            // Parent
                            {
                                DataUtils.addParentCallBack(limit, this, ref this.server);
                            }
                            needReset = true;
                            dirty = true;
                            return;
                        }
                        // Parent
                        if (data is Server)
                        {
                            dirty = true;
                            return;
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
                                case UIData.Property.totalTime:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestFloat, this.transform, UIConstants.RequestRect);
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
                    uiData.editLimit.allRemoveCallBack(this);
                    uiData.totalTime.allRemoveCallBack(this);
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
                // editLimit
                {
                    if (data is EditData<TotalTimeInfo.Limit>)
                    {
                        EditData<TotalTimeInfo.Limit> editLimit = data as EditData<TotalTimeInfo.Limit>;
                        // Child
                        {
                            editLimit.show.allRemoveCallBack(this);
                            editLimit.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is TotalTimeInfo.Limit)
                        {
                            TotalTimeInfo.Limit limit = data as TotalTimeInfo.Limit;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(limit, this, ref this.server);
                            }
                            return;
                        }
                        // Parent
                        if (data is Server)
                        {
                            return;
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
                    case UIData.Property.editLimit:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.totalTime:
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
                    case Setting.Property.itemSize:
                        dirty = true;
                        break;
                    case Setting.Property.confirmQuit:
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
                // editLimit
                {
                    if (wrapProperty.p is EditData<TotalTimeInfo.Limit>)
                    {
                        switch ((EditData<TotalTimeInfo.Limit>.Property)wrapProperty.n)
                        {
                            case EditData<TotalTimeInfo.Limit>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<TotalTimeInfo.Limit>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<TotalTimeInfo.Limit>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<TotalTimeInfo.Limit>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<TotalTimeInfo.Limit>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<TotalTimeInfo.Limit>.Property.editType:
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
                        if (wrapProperty.p is TotalTimeInfo.Limit)
                        {
                            switch ((TotalTimeInfo.Limit.Property)wrapProperty.n)
                            {
                                case TotalTimeInfo.Limit.Property.totalTime:
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