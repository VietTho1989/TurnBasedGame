using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
    public class HexAIUI : UIHaveTransformDataBehavior<HexAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<HexAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region limitTime

            public VP<RequestChangeIntUI.UIData> limitTime;

            public void makeRequestChangeLimitTime(RequestChangeUpdate<int>.UpdateData update, int newLimitTime)
            {
                // Find hexAI
                HexAI hexAI = null;
                {
                    EditData<HexAI> editHexAI = this.editAI.v;
                    if (editHexAI != null)
                    {
                        hexAI = editHexAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editHexAI null: " + this);
                    }
                }
                // Process
                if (hexAI != null)
                {
                    hexAI.requestChangeLimitTime(Server.getProfileUserId(hexAI), newLimitTime);
                }
                else
                {
                    Debug.LogError("hexAI null: " + this);
                }
            }

            #endregion

            #region firstMoveCenter

            public VP<RequestChangeBoolUI.UIData> firstMoveCenter;

            public void makeRequestChangeFirstMoveCenter(RequestChangeUpdate<bool>.UpdateData update, bool newFirstMoveCenter)
            {
                // Find hexAI
                HexAI hexAI = null;
                {
                    EditData<HexAI> editHexAI = this.editAI.v;
                    if (editHexAI != null)
                    {
                        hexAI = editHexAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editHexAI null: " + this);
                    }
                }
                // Process
                if (hexAI != null)
                {
                    hexAI.requestChangeFirstMoveCenter(Server.getProfileUserId(hexAI), newFirstMoveCenter);
                }
                else
                {
                    Debug.LogError("hexAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                limitTime,
                firstMoveCenter
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<HexAI>>(this, (byte)Property.editAI, new EditData<HexAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // limitTime
                {
                    this.limitTime = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.limitTime, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.limitTime.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = Hex.MAX_LIMIT_TIME;
                        }
                        this.limitTime.v.limit.v = have;
                    }
                    // event
                    this.limitTime.v.updateData.v.request.v = makeRequestChangeLimitTime;
                }
                // firstMoveCenter
                {
                    this.firstMoveCenter = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.firstMoveCenter, new RequestChangeBoolUI.UIData());
                    this.firstMoveCenter.v.updateData.v.request.v = makeRequestChangeFirstMoveCenter;
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Hex;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Hex AI");

        public Text lbLimitTime;
        private static readonly TxtLanguage txtLimitTime = new TxtLanguage("Limit time");

        public Text lbFirstMoveCenter;
        private static readonly TxtLanguage txtFirstMoveCenter = new TxtLanguage("First move center");

        static HexAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Hex AI");
                txtLimitTime.add(Language.Type.vi, "Thời gian giới hạn");
                txtFirstMoveCenter.add(Language.Type.vi, "Nước đầu tiên vào trung tâm");
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
                    EditData<HexAI> editHexAI = this.data.editAI.v;
                    if (editHexAI != null)
                    {
                        // update
                        editHexAI.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editHexAI);
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editHexAI);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.limitTime.v, editHexAI, serverState, needReset, editData => editData.limitTime.v);
                                RequestChange.RefreshUI(this.data.firstMoveCenter.v, editHexAI, serverState, needReset, editData => editData.firstMoveCenter.v);
                            }
                            needReset = false;
                        }
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                        // limitTime
                        UIUtils.SetLabelContentPosition(lbLimitTime, this.data.limitTime.v, ref deltaY);
                        // firstMoveCenter
                        UIUtils.SetLabelContentPosition(lbFirstMoveCenter, this.data.firstMoveCenter.v, ref deltaY);
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
                        if (lbLimitTime != null)
                        {
                            lbLimitTime.text = txtLimitTime.get();
                            Setting.get().setLabelTextSize(lbLimitTime);
                        }
                        else
                        {
                            Debug.LogError("lbLimitTime null: " + this);
                        }
                        if (lbFirstMoveCenter != null)
                        {
                            lbFirstMoveCenter.text = txtFirstMoveCenter.get();
                            Setting.get().setLabelTextSize(lbFirstMoveCenter);
                        }
                        else
                        {
                            Debug.LogError("lbFirstMoveCenter null: " + this);
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
                    uiData.editAI.allAddCallBack(this);
                    uiData.limitTime.allAddCallBack(this);
                    uiData.firstMoveCenter.allAddCallBack(this);
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
                // editAI
                {
                    if (data is EditData<HexAI>)
                    {
                        EditData<HexAI> editAI = data as EditData<HexAI>;
                        // Child
                        {
                            editAI.show.allAddCallBack(this);
                            editAI.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is HexAI)
                        {
                            HexAI hexAI = data as HexAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(hexAI, this, ref this.server);
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
                                case UIData.Property.limitTime:
                                    {
                                        UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
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
                                case UIData.Property.firstMoveCenter:
                                    {
                                        UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
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
                    uiData.editAI.allRemoveCallBack(this);
                    uiData.limitTime.allRemoveCallBack(this);
                    uiData.firstMoveCenter.allRemoveCallBack(this);
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
                // editAI
                {
                    if (data is EditData<HexAI>)
                    {
                        EditData<HexAI> editAI = data as EditData<HexAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is HexAI)
                        {
                            HexAI hexAI = data as HexAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(hexAI, this, ref this.server);
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
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                    }
                    return;
                }
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
                    case UIData.Property.editAI:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.limitTime:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.firstMoveCenter:
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
                // editAI
                {
                    if (wrapProperty.p is EditData<HexAI>)
                    {
                        switch ((EditData<HexAI>.Property)wrapProperty.n)
                        {
                            case EditData<HexAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<HexAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<HexAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<HexAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<HexAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<HexAI>.Property.editType:
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
                        if (wrapProperty.p is HexAI)
                        {
                            switch ((HexAI.Property)wrapProperty.n)
                            {
                                case HexAI.Property.limitTime:
                                    dirty = true;
                                    break;
                                case HexAI.Property.firstMoveCenter:
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
                if (wrapProperty.p is RequestChangeIntUI.UIData)
                {
                    return;
                }
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