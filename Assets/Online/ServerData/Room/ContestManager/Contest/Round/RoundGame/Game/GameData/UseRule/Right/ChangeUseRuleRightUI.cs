using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChangeUseRuleRightUI : UIHaveTransformDataBehavior<ChangeUseRuleRightUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<EditData<ChangeUseRuleRight>> editChangeUseRuleRight;

        #region canChange

        public VP<RequestChangeBoolUI.UIData> canChange;

        public void makeRequestChangeCanChange(RequestChangeUpdate<bool>.UpdateData update, bool newCanChange)
        {

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

    }

    #endregion

    #region Refresh

    #region txt

    public Text lbTitle;
    public static readonly TxtLanguage txtTitle = new TxtLanguage();

    public Text lbCanChange;
    public static readonly TxtLanguage txtCanChange = new TxtLanguage();

    public Text lbOnlyAdmin;
    public static readonly TxtLanguage txtOnlyAdmin = new TxtLanguage();

    public Text lbNeedAdmin;
    public static readonly TxtLanguage txtNeedAdmin = new TxtLanguage();

    public Text lbNeedAccept;
    public static readonly TxtLanguage txtNeedAccept = new TxtLanguage();

    static ChangeUseRuleRightUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Quyền Thay Đổi Luật");
            txtCanChange.add(Language.Type.vi, "Có thể đổi");
            txtOnlyAdmin.add(Language.Type.vi, "Chỉ admin");
            txtNeedAdmin.add(Language.Type.vi, "Cần admin");
            txtNeedAccept.add(Language.Type.vi, "Cần chấp nhận");
        }
        // rect
        {
            canChangeRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
            onlyAdminRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
            needAdminRect.setPosY(UIConstants.HeaderHeight + 2 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
            needAcceptRect.setPosY(UIConstants.HeaderHeight + 3 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
        }
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
                EditData<ChangeUseRuleRight> editChangeUseRuleRight = this.data.editChangeUseRuleRight.v;
                if (editChangeUseRuleRight != null)
                {
                    editChangeUseRuleRight.update();
                    // get show
                    ChangeUseRuleRight show = editChangeUseRuleRight.show.v.data;
                    ChangeUseRuleRight compare = editChangeUseRuleRight.compare.v.data;
                    if (show != null)
                    {
                        // different
                        if (lbTitle != null)
                        {
                            bool isDifferent = false;
                            {
                                if (editChangeUseRuleRight.compareOtherType.v.data != null)
                                {
                                    if (editChangeUseRuleRight.compareOtherType.v.data.GetType() != show.GetType())
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
                                    Debug.LogError("server null: " + this);
                                }
                            }
                            // set origin
                            {
                                // canChange
                                {
                                    RequestChangeBoolUI.UIData canChange = this.data.canChange.v;
                                    if (canChange != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = canChange.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.canChange.v;
                                            updateData.canRequestChange.v = false;// editChangeUseRuleRight.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                canChange.showDifferent.v = true;
                                                canChange.compare.v = compare.canChange.v;
                                            }
                                            else
                                            {
                                                canChange.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("canChange null: " + this);
                                    }
                                }
                                // onlyAdmin
                                {
                                    RequestChangeBoolUI.UIData onlyAdmin = this.data.onlyAdmin.v;
                                    if (onlyAdmin != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = onlyAdmin.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.onlyAdmin.v;
                                            updateData.canRequestChange.v = editChangeUseRuleRight.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                onlyAdmin.showDifferent.v = true;
                                                onlyAdmin.compare.v = compare.onlyAdmin.v;
                                            }
                                            else
                                            {
                                                onlyAdmin.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("onlyAdmin null: " + this);
                                    }
                                }
                                // needAdmin
                                {
                                    RequestChangeBoolUI.UIData needAdmin = this.data.needAdmin.v;
                                    if (needAdmin != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = needAdmin.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.needAdmin.v;
                                            updateData.canRequestChange.v = editChangeUseRuleRight.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                needAdmin.showDifferent.v = true;
                                                needAdmin.compare.v = compare.needAdmin.v;
                                            }
                                            else
                                            {
                                                needAdmin.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("needAdmin null: " + this);
                                    }
                                }
                                // needAccept
                                {
                                    RequestChangeBoolUI.UIData needAccept = this.data.needAccept.v;
                                    if (needAccept != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = needAccept.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.needAccept.v;
                                            updateData.canRequestChange.v = editChangeUseRuleRight.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                needAccept.showDifferent.v = true;
                                                needAccept.compare.v = compare.needAccept.v;
                                            }
                                            else
                                            {
                                                needAccept.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("needAccept null: " + this);
                                    }
                                }
                            }
                        }
                        // reset
                        if (needReset)
                        {
                            needReset = false;
                            // canChange
                            {
                                RequestChangeBoolUI.UIData canChange = this.data.canChange.v;
                                if (canChange != null)
                                {
                                    // update
                                    RequestChangeUpdate<bool>.UpdateData updateData = canChange.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = show.canChange.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("canChange null: " + this);
                                }
                            }
                            // onlyAdmin
                            {
                                RequestChangeBoolUI.UIData onlyAdmin = this.data.onlyAdmin.v;
                                if (onlyAdmin != null)
                                {
                                    // update
                                    RequestChangeUpdate<bool>.UpdateData updateData = onlyAdmin.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = show.onlyAdmin.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("onlyAdmin null: " + this);
                                }
                            }
                            // needAdmin
                            {
                                RequestChangeBoolUI.UIData needAdmin = this.data.needAdmin.v;
                                if (needAdmin != null)
                                {
                                    // update
                                    RequestChangeUpdate<bool>.UpdateData updateData = needAdmin.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = show.needAdmin.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("needAdmin null: " + this);
                                }
                            }
                            // needAccept
                            {
                                RequestChangeBoolUI.UIData needAccept = this.data.needAccept.v;
                                if (needAccept != null)
                                {
                                    // update
                                    RequestChangeUpdate<bool>.UpdateData updateData = needAccept.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = show.needAccept.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("needAccept null: " + this);
                                }
                            }
                        }
                    }
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get("Change Use Rule Right");
                    }
                    else
                    {
                        Debug.LogError("lbTitle null: " + this);
                    }
                    if (lbCanChange != null)
                    {
                        lbCanChange.text = txtCanChange.get("Can change");
                    }
                    else
                    {
                        Debug.LogError("lbCanChange null: " + this);
                    }
                    if (lbOnlyAdmin != null)
                    {
                        lbOnlyAdmin.text = txtOnlyAdmin.get("Only admin");
                    }
                    else
                    {
                        Debug.LogError("lbOnlyAdmin null: " + this);
                    }
                    if (lbNeedAdmin != null)
                    {
                        lbNeedAdmin.text = txtNeedAdmin.get("Need admin");
                    }
                    else
                    {
                        Debug.LogError("lbNeedAdmin null: " + this);
                    }
                    if (lbNeedAccept != null)
                    {
                        lbNeedAccept.text = txtNeedAccept.get("Need accept");
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

    private static readonly UIRectTransform canChangeRect = new UIRectTransform(UIConstants.RequestBoolRect);
    private static readonly UIRectTransform onlyAdminRect = new UIRectTransform(UIConstants.RequestBoolRect);
    private static readonly UIRectTransform needAdminRect = new UIRectTransform(UIConstants.RequestBoolRect);
    private static readonly UIRectTransform needAcceptRect = new UIRectTransform(UIConstants.RequestBoolRect);

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
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, canChangeRect);
                                break;
                            case UIData.Property.onlyAdmin:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, onlyAdminRect);
                                break;
                            case UIData.Property.needAdmin:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, needAdminRect);
                                break;
                            case UIData.Property.needAccept:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, needAcceptRect);
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