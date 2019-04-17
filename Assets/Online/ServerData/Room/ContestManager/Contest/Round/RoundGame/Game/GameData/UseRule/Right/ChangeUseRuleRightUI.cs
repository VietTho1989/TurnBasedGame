using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChangeUseRuleRightUI : UIHaveTransformDataBehavior<ChangeUseRuleRightUI.UIData>
{

    #region UIData

    public class UIData : Data, EditDataUI.UIData<ChangeUseRuleRight>
    {

        public VP<EditData<ChangeUseRuleRight>> editChangeUseRuleRight;

        #region canChange

        public VP<RequestChangeBoolUI.UIData> canChange;

        public void makeRequestChangeCanChange(RequestChangeUpdate<bool>.UpdateData update, bool newCanChange)
        {
            // Find
            ChangeUseRuleRight changeUseRuleRight = null;
            {
                EditData<ChangeUseRuleRight> editChangeUseRuleRight = this.editChangeUseRuleRight.v;
                if (editChangeUseRuleRight != null)
                {
                    changeUseRuleRight = editChangeUseRuleRight.show.v.data;
                }
                else
                {
                    Debug.LogError("editChangeUseRuleRight null: " + this);
                }
            }
            // Process
            if (changeUseRuleRight != null)
            {
                changeUseRuleRight.requestChangeCanChange(Server.getProfileUserId(changeUseRuleRight), newCanChange);
            }
            else
            {
                Debug.LogError("changeUseRuleRight null: " + this);
            }
        }

        #endregion

        #region onlyAdmin

        public VP<RequestChangeBoolUI.UIData> onlyAdmin;

        public void makeRequestChangeOnlyAdmin(RequestChangeUpdate<bool>.UpdateData update, bool newOnlyAdmin)
        {
            // Find
            ChangeUseRuleRight changeUseRuleRight = null;
            {
                EditData<ChangeUseRuleRight> editChangeUseRuleRight = this.editChangeUseRuleRight.v;
                if (editChangeUseRuleRight != null)
                {
                    changeUseRuleRight = editChangeUseRuleRight.show.v.data;
                }
                else
                {
                    Debug.LogError("editChangeUseRuleRight null: " + this);
                }
            }
            // Process
            if (changeUseRuleRight != null)
            {
                changeUseRuleRight.requestChangeOnlyAdmin(Server.getProfileUserId(changeUseRuleRight), newOnlyAdmin);
            }
            else
            {
                Debug.LogError("changeUseRuleRight null: " + this);
            }
        }

        #endregion

        #region needAdmin

        public VP<RequestChangeBoolUI.UIData> needAdmin;

        public void makeRequestChangeNeedAdmin(RequestChangeUpdate<bool>.UpdateData update, bool newNeedAdmin)
        {
            // Find
            ChangeUseRuleRight changeUseRuleRight = null;
            {
                EditData<ChangeUseRuleRight> editChangeUseRuleRight = this.editChangeUseRuleRight.v;
                if (editChangeUseRuleRight != null)
                {
                    changeUseRuleRight = editChangeUseRuleRight.show.v.data;
                }
                else
                {
                    Debug.LogError("editChangeUseRuleRight null: " + this);
                }
            }
            // Process
            if (changeUseRuleRight != null)
            {
                changeUseRuleRight.requestChangeNeedAdmin(Server.getProfileUserId(changeUseRuleRight), newNeedAdmin);
            }
            else
            {
                Debug.LogError("changeUseRuleRight null: " + this);
            }
        }

        #endregion

        #region needAccept

        public VP<RequestChangeBoolUI.UIData> needAccept;

        public void makeRequestChangeNeedAccept(RequestChangeUpdate<bool>.UpdateData update, bool newNeedAccept)
        {
            // Find
            ChangeUseRuleRight changeUseRuleRight = null;
            {
                EditData<ChangeUseRuleRight> editChangeUseRuleRight = this.editChangeUseRuleRight.v;
                if (editChangeUseRuleRight != null)
                {
                    changeUseRuleRight = editChangeUseRuleRight.show.v.data;
                }
                else
                {
                    Debug.LogError("editChangeUseRuleRight null: " + this);
                }
            }
            // Process
            if (changeUseRuleRight != null)
            {
                changeUseRuleRight.requestChangeNeedAccept(Server.getProfileUserId(changeUseRuleRight), newNeedAccept);
            }
            else
            {
                Debug.LogError("changeUseRuleRight null: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            editChangeUseRuleRight,
            canChange,
            onlyAdmin,
            needAdmin,
            needAccept
        }

        public UIData() : base()
        {
            this.editChangeUseRuleRight = new VP<EditData<ChangeUseRuleRight>>(this, (byte)Property.editChangeUseRuleRight, new EditData<ChangeUseRuleRight>());
            // canChange
            {
                this.canChange = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.canChange, new RequestChangeBoolUI.UIData());
                this.canChange.v.updateData.v.request.v = makeRequestChangeCanChange;
            }
            // onlyAdmin
            {
                this.onlyAdmin = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.onlyAdmin, new RequestChangeBoolUI.UIData());
                this.onlyAdmin.v.updateData.v.request.v = makeRequestChangeOnlyAdmin;
            }
            // needAdmin
            {
                this.needAdmin = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.needAdmin, new RequestChangeBoolUI.UIData());
                this.needAdmin.v.updateData.v.request.v = makeRequestChangeNeedAdmin;
            }
            // needAccept
            {
                this.needAccept = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.needAccept, new RequestChangeBoolUI.UIData());
                this.needAccept.v.updateData.v.request.v = makeRequestChangeNeedAccept;
            }
        }

        #endregion

        #region implement base

        public EditData<ChangeUseRuleRight> getEditData()
        {
            return this.editChangeUseRuleRight.v;
        }

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Change Right");

    public Text lbCanChange;
    private static readonly TxtLanguage txtCanChange = new TxtLanguage("Can change");

    public Text lbOnlyAdmin;
    private static readonly TxtLanguage txtOnlyAdmin = new TxtLanguage("Only admin");

    public Text lbNeedAdmin;
    private static readonly TxtLanguage txtNeedAdmin = new TxtLanguage("Need admin");

    public Text lbNeedAccept;
    private static readonly TxtLanguage txtNeedAccept = new TxtLanguage("Need accept");

    static ChangeUseRuleRightUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Quyền Thay Đổi");
            txtCanChange.add(Language.Type.vi, "Có thể đổi");
            txtOnlyAdmin.add(Language.Type.vi, "Chỉ admin");
            txtNeedAdmin.add(Language.Type.vi, "Cần admin");
            txtNeedAccept.add(Language.Type.vi, "Cần chấp nhận");
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
                EditData<ChangeUseRuleRight> editChangeUseRuleRight = this.data.editChangeUseRuleRight.v;
                if (editChangeUseRuleRight != null)
                {
                    editChangeUseRuleRight.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editChangeUseRuleRight);
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editChangeUseRuleRight);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.canChange.v, editChangeUseRuleRight, serverState, needReset, editData => editData.canChange.v);
                                RequestChange.RefreshUI(this.data.onlyAdmin.v, editChangeUseRuleRight, serverState, needReset, editData => editData.onlyAdmin.v);
                                RequestChange.RefreshUI(this.data.needAdmin.v, editChangeUseRuleRight, serverState, needReset, editData => editData.needAdmin.v);
                                RequestChange.RefreshUI(this.data.needAccept.v, editChangeUseRuleRight, serverState, needReset, editData => editData.needAccept.v);
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
                    // onlyAdmin
                    UIUtils.SetLabelContentPosition(lbOnlyAdmin, this.data.onlyAdmin.v, ref deltaY);
                    // needAdmin
                    UIUtils.SetLabelContentPosition(lbNeedAdmin, this.data.needAdmin.v, ref deltaY);
                    // needAccept
                    UIUtils.SetLabelContentPosition(lbNeedAccept, this.data.needAccept.v, ref deltaY);
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
                        Debug.LogError("lbTitle null: " + this);
                    }
                    if (lbCanChange != null)
                    {
                        lbCanChange.text = txtCanChange.get();
                        Setting.get().setLabelTextSize(lbCanChange);
                    }
                    else
                    {
                        Debug.LogError("lbCanChange null: " + this);
                    }
                    if (lbOnlyAdmin != null)
                    {
                        lbOnlyAdmin.text = txtOnlyAdmin.get();
                        Setting.get().setLabelTextSize(lbOnlyAdmin);
                    }
                    else
                    {
                        Debug.LogError("lbOnlyAdmin null: " + this);
                    }
                    if (lbNeedAdmin != null)
                    {
                        lbNeedAdmin.text = txtNeedAdmin.get();
                        Setting.get().setLabelTextSize(lbNeedAdmin);
                    }
                    else
                    {
                        Debug.LogError("lbNeedAdmin null: " + this);
                    }
                    if (lbNeedAccept != null)
                    {
                        lbNeedAccept.text = txtNeedAccept.get();
                        Setting.get().setLabelTextSize(lbNeedAccept);
                    }
                    else
                    {
                        Debug.LogError("lbNeedAccept null: " + this);
                    }
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
                uiData.editChangeUseRuleRight.allAddCallBack(this);
                uiData.canChange.allAddCallBack(this);
                uiData.onlyAdmin.allAddCallBack(this);
                uiData.needAdmin.allAddCallBack(this);
                uiData.needAccept.allAddCallBack(this);
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
            // editChangeUseRuleRight
            {
                if (data is EditData<ChangeUseRuleRight>)
                {
                    EditData<ChangeUseRuleRight> editChangeUseRuleRight = data as EditData<ChangeUseRuleRight>;
                    // Child
                    {
                        editChangeUseRuleRight.show.allAddCallBack(this);
                        editChangeUseRuleRight.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is ChangeUseRuleRight)
                    {
                        ChangeUseRuleRight changeUseRuleRight = data as ChangeUseRuleRight;
                        // Parent
                        {
                            DataUtils.addParentCallBack(changeUseRuleRight, this, ref this.server);
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
            // canChange, onlyAdmin, needAdmin, needAccept
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
                            case UIData.Property.onlyAdmin:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                break;
                            case UIData.Property.needAdmin:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                break;
                            case UIData.Property.needAccept:
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
                uiData.editChangeUseRuleRight.allRemoveCallBack(this);
                uiData.canChange.allRemoveCallBack(this);
                uiData.onlyAdmin.allRemoveCallBack(this);
                uiData.needAdmin.allRemoveCallBack(this);
                uiData.needAccept.allRemoveCallBack(this);
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
            // editChangeUseRuleRight
            {
                if (data is EditData<ChangeUseRuleRight>)
                {
                    EditData<ChangeUseRuleRight> editChangeUseRuleRight = data as EditData<ChangeUseRuleRight>;
                    // Child
                    {
                        editChangeUseRuleRight.show.allRemoveCallBack(this);
                        editChangeUseRuleRight.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is ChangeUseRuleRight)
                    {
                        ChangeUseRuleRight changeUseRuleRight = data as ChangeUseRuleRight;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(changeUseRuleRight, this, ref this.server);
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
            // canChange, onlyAdmin, needAdmin, needAccept
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
                case UIData.Property.editChangeUseRuleRight:
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
                case UIData.Property.onlyAdmin:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.needAdmin:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.needAccept:
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
            // editChangeUseRuleRight
            {
                if (wrapProperty.p is EditData<ChangeUseRuleRight>)
                {
                    switch ((EditData<ChangeUseRuleRight>.Property)wrapProperty.n)
                    {
                        case EditData<ChangeUseRuleRight>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<ChangeUseRuleRight>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<ChangeUseRuleRight>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<ChangeUseRuleRight>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<ChangeUseRuleRight>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<ChangeUseRuleRight>.Property.editType:
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
                    if (wrapProperty.p is ChangeUseRuleRight)
                    {
                        switch ((ChangeUseRuleRight.Property)wrapProperty.n)
                        {
                            case ChangeUseRuleRight.Property.canChange:
                                dirty = true;
                                break;
                            case ChangeUseRuleRight.Property.onlyAdmin:
                                dirty = true;
                                break;
                            case ChangeUseRuleRight.Property.needAdmin:
                                dirty = true;
                                break;
                            case ChangeUseRuleRight.Property.needAccept:
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
            // canChange, onlyAdmin, needAdmin, needAccept
            if (wrapProperty.p is RequestChangeBoolUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}