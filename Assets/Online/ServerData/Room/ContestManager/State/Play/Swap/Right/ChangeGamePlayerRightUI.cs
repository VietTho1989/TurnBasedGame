using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class ChangeGamePlayerRightUI : UIHaveTransformDataBehavior<ChangeGamePlayerRightUI.UIData>
    {

        #region UIData

        public class UIData : Data, EditDataUI.UIData<ChangeGamePlayerRight>
        {

            public VP<EditData<ChangeGamePlayerRight>> editChangeGamePlayerRight;

            #region canChange

            public VP<RequestChangeBoolUI.UIData> canChange;

            public void makeRequestChangeCanChange(RequestChangeUpdate<bool>.UpdateData update, bool newCanChange)
            {
                // Find
                ChangeGamePlayerRight changeGamePlayerRight = null;
                {
                    EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = this.editChangeGamePlayerRight.v;
                    if (editChangeGamePlayerRight != null)
                    {
                        changeGamePlayerRight = editChangeGamePlayerRight.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChangeGamePlayerRight null: " + this);
                    }
                }
                // Process
                if (changeGamePlayerRight != null)
                {
                    changeGamePlayerRight.requestChangeCanChange(Server.getProfileUserId(changeGamePlayerRight), newCanChange);
                }
                else
                {
                    Debug.LogError("changeGamePlayerRight null: " + this);
                }
            }

            #endregion

            #region canChangePlayerLeft

            public VP<RequestChangeBoolUI.UIData> canChangePlayerLeft;

            public void makeRequestChangeCanChangePlayerLeft(RequestChangeUpdate<bool>.UpdateData update, bool newCanChangePlayerLeft)
            {
                // Find
                ChangeGamePlayerRight changeGamePlayerRight = null;
                {
                    EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = this.editChangeGamePlayerRight.v;
                    if (editChangeGamePlayerRight != null)
                    {
                        changeGamePlayerRight = editChangeGamePlayerRight.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChangeGamePlayerRight null: " + this);
                    }
                }
                // Process
                if (changeGamePlayerRight != null)
                {
                    changeGamePlayerRight.requestChangeCanChangePlayerLeft(Server.getProfileUserId(changeGamePlayerRight), newCanChangePlayerLeft);
                }
                else
                {
                    Debug.LogError("changeGamePlayerRight null: " + this);
                }
            }

            #endregion

            #region needAdminAccept

            public VP<RequestChangeBoolUI.UIData> needAdminAccept;

            public void makeRequestChangeNeedAdminAccept(RequestChangeUpdate<bool>.UpdateData update, bool newNeedAdminAccept)
            {
                // Find
                ChangeGamePlayerRight changeGamePlayerRight = null;
                {
                    EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = this.editChangeGamePlayerRight.v;
                    if (editChangeGamePlayerRight != null)
                    {
                        changeGamePlayerRight = editChangeGamePlayerRight.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChangeGamePlayerRight null: " + this);
                    }
                }
                // Process
                if (changeGamePlayerRight != null)
                {
                    changeGamePlayerRight.requestChangeNeedAdminAccept(Server.getProfileUserId(changeGamePlayerRight), newNeedAdminAccept);
                }
                else
                {
                    Debug.LogError("changeGamePlayerRight null: " + this);
                }
            }

            #endregion

            #region onlyAdminNeed

            public VP<RequestChangeBoolUI.UIData> onlyAdminNeed;

            public void makeRequestChangeOnlyAdminNeed(RequestChangeUpdate<bool>.UpdateData update, bool newOnlyAdminNeed)
            {
                // Find
                ChangeGamePlayerRight changeGamePlayerRight = null;
                {
                    EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = this.editChangeGamePlayerRight.v;
                    if (editChangeGamePlayerRight != null)
                    {
                        changeGamePlayerRight = editChangeGamePlayerRight.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChangeGamePlayerRight null: " + this);
                    }
                }
                // Process
                if (changeGamePlayerRight != null)
                {
                    changeGamePlayerRight.requestChangeOnlyAdminNeed(Server.getProfileUserId(changeGamePlayerRight), newOnlyAdminNeed);
                }
                else
                {
                    Debug.LogError("changeGamePlayerRight null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editChangeGamePlayerRight,
                canChange,
                canChangePlayerLeft,
                needAdminAccept,
                onlyAdminNeed
            }

            public UIData() : base()
            {
                this.editChangeGamePlayerRight = new VP<EditData<ChangeGamePlayerRight>>(this, (byte)Property.editChangeGamePlayerRight, new EditData<ChangeGamePlayerRight>());
                // canChange
                {
                    this.canChange = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.canChange, new RequestChangeBoolUI.UIData());
                    this.canChange.v.updateData.v.request.v = makeRequestChangeCanChange;
                }
                // canChangePlayerLeft
                {
                    this.canChangePlayerLeft = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.canChangePlayerLeft, new RequestChangeBoolUI.UIData());
                    this.canChangePlayerLeft.v.updateData.v.request.v = makeRequestChangeCanChangePlayerLeft;
                }
                // needAdminAccept
                {
                    this.needAdminAccept = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.needAdminAccept, new RequestChangeBoolUI.UIData());
                    this.needAdminAccept.v.updateData.v.request.v = makeRequestChangeNeedAdminAccept;
                }
                // onlyAdminNeed
                {
                    this.onlyAdminNeed = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.onlyAdminNeed, new RequestChangeBoolUI.UIData());
                    this.onlyAdminNeed.v.updateData.v.request.v = makeRequestChangeOnlyAdminNeed;
                }
            }

            #endregion

            #region implement base

            public EditData<ChangeGamePlayerRight> getEditData()
            {
                return this.editChangeGamePlayerRight.v;
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Change Game Player Rights");

        public Text lbCanChange;
        private static readonly TxtLanguage txtCanChange = new TxtLanguage("Can change");

        public Text lbCanChangePlayerLeft;
        private static readonly TxtLanguage txtCanChangePlayerLeft = new TxtLanguage("Can change player left");

        public Text lbNeedAdminAccept;
        private static readonly TxtLanguage txtNeedAdminAccept = new TxtLanguage("Need admin accepted");

        public Text lbOnlyAdminNeed;
        private static readonly TxtLanguage txtOnlyAdminNeed = new TxtLanguage("Only admin needed");

        static ChangeGamePlayerRightUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Quyền Thay Đổi Người Chơi");
                txtCanChange.add(Language.Type.vi, "Có thể đổi");
                txtCanChangePlayerLeft.add(Language.Type.vi, "Có thể đổi người đã rời");
                txtNeedAdminAccept.add(Language.Type.vi, "Cần admin chấp nhận");
                txtOnlyAdminNeed.add(Language.Type.vi, "Chỉ cần admin");
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
                    EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = this.data.editChangeGamePlayerRight.v;
                    if (editChangeGamePlayerRight != null)
                    {
                        editChangeGamePlayerRight.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editChangeGamePlayerRight);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editChangeGamePlayerRight);
                                // set origin
                                {
                                    RequestChange.RefreshUI(this.data.canChange.v, editChangeGamePlayerRight, serverState, needReset, editData => editData.canChange.v);
                                    RequestChange.RefreshUI(this.data.canChangePlayerLeft.v, editChangeGamePlayerRight, serverState, needReset, editData => editData.canChangePlayerLeft.v);
                                    RequestChange.RefreshUI(this.data.needAdminAccept.v, editChangeGamePlayerRight, serverState, needReset, editData => editData.needAdminAccept.v);
                                    RequestChange.RefreshUI(this.data.onlyAdminNeed.v, editChangeGamePlayerRight, serverState, needReset, editData => editData.onlyAdminNeed.v);
                                }
                            }
                            needReset = false;
                        }
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, UIRectTransform.ShowType.Normal, ref deltaY);
                        // canChange
                        UIUtils.SetLabelContentPosition(lbCanChange, this.data.canChange.v, ref deltaY);
                        // canChangePlayerLeft
                        UIUtils.SetLabelContentPosition(lbCanChangePlayerLeft, this.data.canChangePlayerLeft.v, ref deltaY);
                        // needAdminAccept
                        UIUtils.SetLabelContentPosition(lbNeedAdminAccept, this.data.needAdminAccept.v, ref deltaY);
                        // onlyAdminNeed
                        UIUtils.SetLabelContentPosition(lbOnlyAdminNeed, this.data.onlyAdminNeed.v, ref deltaY);
                        // set height
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
                            Debug.LogError("lbTitle null");
                        }
                        if (lbCanChange != null)
                        {
                            lbCanChange.text = txtCanChange.get();
                            Setting.get().setLabelTextSize(lbCanChange);
                        }
                        else
                        {
                            Debug.LogError("lbCanChange null");
                        }
                        if (lbCanChangePlayerLeft != null)
                        {
                            lbCanChangePlayerLeft.text = txtCanChangePlayerLeft.get();
                            Setting.get().setLabelTextSize(lbCanChangePlayerLeft);
                        }
                        else
                        {
                            Debug.LogError("lbCanChangePlayerLeft null");
                        }
                        if (lbNeedAdminAccept != null)
                        {
                            lbNeedAdminAccept.text = txtNeedAdminAccept.get();
                            Setting.get().setLabelTextSize(lbNeedAdminAccept);
                        }
                        else
                        {
                            Debug.LogError("lbNeedAdminAccept null");
                        }
                        if (lbOnlyAdminNeed != null)
                        {
                            lbOnlyAdminNeed.text = txtOnlyAdminNeed.get();
                            Setting.get().setLabelTextSize(lbOnlyAdminNeed);
                        }
                        else
                        {
                            Debug.LogError("lbOnlyAdminNeed null");
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
                    uiData.editChangeGamePlayerRight.allAddCallBack(this);
                    uiData.canChange.allAddCallBack(this);
                    uiData.canChangePlayerLeft.allAddCallBack(this);
                    uiData.needAdminAccept.allAddCallBack(this);
                    uiData.onlyAdminNeed.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if(data is Setting)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // editChangeGamePlayerRight
                {
                    if (data is EditData<ChangeGamePlayerRight>)
                    {
                        EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = data as EditData<ChangeGamePlayerRight>;
                        // Child
                        {
                            editChangeGamePlayerRight.show.allAddCallBack(this);
                            editChangeGamePlayerRight.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is ChangeGamePlayerRight)
                        {
                            ChangeGamePlayerRight changeGamePlayerRight = data as ChangeGamePlayerRight;
                            // Parent
                            {
                                DataUtils.addParentCallBack(changeGamePlayerRight, this, ref this.server);
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
                // canChange, canChangePlayerLeft, needAdminAccept, onlyAdminNeed
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
                                case UIData.Property.canChange:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.canChangePlayerLeft:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.needAdminAccept:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.onlyAdminNeed:
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
                    uiData.editChangeGamePlayerRight.allRemoveCallBack(this);
                    uiData.canChange.allRemoveCallBack(this);
                    uiData.canChangePlayerLeft.allRemoveCallBack(this);
                    uiData.needAdminAccept.allRemoveCallBack(this);
                    uiData.onlyAdminNeed.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if(data is Setting)
            {
                return;
            }
            // Child
            {
                // editChangeGamePlayerRight
                {
                    if (data is EditData<ChangeGamePlayerRight>)
                    {
                        EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = data as EditData<ChangeGamePlayerRight>;
                        // Child
                        {
                            editChangeGamePlayerRight.show.allRemoveCallBack(this);
                            editChangeGamePlayerRight.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is ChangeGamePlayerRight)
                        {
                            ChangeGamePlayerRight changeGamePlayerRight = data as ChangeGamePlayerRight;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(changeGamePlayerRight, this, ref this.server);
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
                // canChange, canChangePlayerLeft, needAdminAccept, onlyAdminNeed
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
                    case UIData.Property.editChangeGamePlayerRight:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.canChange:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.canChangePlayerLeft:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.needAdminAccept:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.onlyAdminNeed:
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
            if(wrapProperty.p is Setting)
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
                    case Setting.Property.defaultChosenGame:
                        break;
                    case Setting.Property.defaultRoomName:
                        break;
                    case Setting.Property.defaultChatRoomStyle:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                // editChangeGamePlayerRight
                {
                    if (wrapProperty.p is EditData<ChangeGamePlayerRight>)
                    {
                        switch ((EditData<ChangeGamePlayerRight>.Property)wrapProperty.n)
                        {
                            case EditData<ChangeGamePlayerRight>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<ChangeGamePlayerRight>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ChangeGamePlayerRight>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ChangeGamePlayerRight>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<ChangeGamePlayerRight>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<ChangeGamePlayerRight>.Property.editType:
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
                        if (wrapProperty.p is ChangeGamePlayerRight)
                        {
                            switch ((ChangeGamePlayerRight.Property)wrapProperty.n)
                            {
                                case ChangeGamePlayerRight.Property.canChange:
                                    dirty = true;
                                    break;
                                case ChangeGamePlayerRight.Property.canChangePlayerLeft:
                                    dirty = true;
                                    break;
                                case ChangeGamePlayerRight.Property.needAdminAccept:
                                    dirty = true;
                                    break;
                                case ChangeGamePlayerRight.Property.onlyAdminNeed:
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
                // canChange, canChangePlayerLeft, needAdminAccept, onlyAdminNeed
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
        }

        #endregion

    }
}