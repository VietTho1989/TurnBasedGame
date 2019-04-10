using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Rights
{
    public class HaveLimitUI : UIHaveTransformDataBehavior<HaveLimitUI.UIData>
    {

        #region UIData

        public class UIData : Limit.UIData
        {

            public VP<EditData<HaveLimit>> editHaveLimit;

            public VP<UIRectTransform.ShowType> showType;

            #region limit

            public VP<RequestChangeIntUI.UIData> limit;

            public void makeRequestChangeLimit(RequestChangeUpdate<int>.UpdateData update, int newLimit)
            {
                // Find
                HaveLimit haveLimit = null;
                {
                    EditData<HaveLimit> editHaveLimit = this.editHaveLimit.v;
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
                    haveLimit.requestChangeLimit(Server.getProfileUserId(haveLimit), newLimit);
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
                limit
            }

            public UIData() : base()
            {
                this.editHaveLimit = new VP<EditData<HaveLimit>>(this, (byte)Property.editHaveLimit, new EditData<HaveLimit>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // limit
                {
                    this.limit = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.limit, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.limit.v.limit.makeId();
                            have.min.v = 1;
                            have.max.v = 30;
                        }
                        this.limit.v.limit.v = have;
                    }
                    // event
                    this.limit.v.updateData.v.request.v = makeRequestChangeLimit;
                }
            }

            #endregion

            public override Limit.Type getType()
            {
                return Limit.Type.HaveLimit;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage("Have Limit");

        public Text lbLimit;
        public static readonly TxtLanguage txtLimit = new TxtLanguage("Limit");

        static HaveLimitUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Có Giới Hạn");
                txtLimit.add(Language.Type.vi, "Giời hạn");
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
                    EditData<HaveLimit> editHaveLimit = this.data.editHaveLimit.v;
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
                                    RequestChange.RefreshUI(this.data.limit.v, editHaveLimit, serverState, needReset, editData => editData.limit.v);
                                }
                                needReset = false;
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                            // limit
                            UIUtils.SetLabelContentPosition(lbLimit, this.data.limit.v, ref deltaY);
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
                            if (lbLimit != null)
                            {
                                lbLimit.text = txtLimit.get();
                                Setting.get().setLabelTextSize(lbLimit);
                            }
                            else
                            {
                                Debug.LogError("lbLimit null: " + this);
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
                    uiData.limit.allAddCallBack(this);
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
                    if (data is EditData<HaveLimit>)
                    {
                        EditData<HaveLimit> editHaveLimit = data as EditData<HaveLimit>;
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
                        if (data is HaveLimit)
                        {
                            HaveLimit haveLimit = data as HaveLimit;
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
                // limit
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
                                case UIData.Property.limit:
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
                    uiData.limit.allRemoveCallBack(this);
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
                    if (data is EditData<HaveLimit>)
                    {
                        EditData<HaveLimit> editHaveLimit = data as EditData<HaveLimit>;
                        // Child
                        {
                            editHaveLimit.show.allRemoveCallBack(this);
                            editHaveLimit.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is HaveLimit)
                        {
                            HaveLimit haveLimit = data as HaveLimit;
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
                // limit
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
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
                    case UIData.Property.limit:
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
                // editHaveLimit
                {
                    if (wrapProperty.p is EditData<HaveLimit>)
                    {
                        switch ((EditData<HaveLimit>.Property)wrapProperty.n)
                        {
                            case EditData<HaveLimit>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<HaveLimit>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<HaveLimit>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<HaveLimit>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<HaveLimit>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<HaveLimit>.Property.editType:
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
                        if (wrapProperty.p is HaveLimit)
                        {
                            switch ((HaveLimit.Property)wrapProperty.n)
                            {
                                case HaveLimit.Property.limit:
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
                // limit
                if (wrapProperty.p is RequestChangeIntUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}