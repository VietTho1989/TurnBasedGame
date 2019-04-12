using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AccountAdminUI : UIHaveTransformDataBehavior<AccountAdminUI.UIData>
{

    #region UIData

    public class UIData : AccountUI.UIData.Sub
    {

        public VP<EditData<AccountAdmin>> editAccountAdmin;

        #region customName

        public VP<RequestChangeStringUI.UIData> customName;

        public void makeRequestChangeCustomName(RequestChangeUpdate<string>.UpdateData update, string newCustomName)
        {
            // Find
            AccountAdmin accountAdmin = null;
            {
                EditData<AccountAdmin> editAccountAdmin = this.editAccountAdmin.v;
                if (editAccountAdmin != null)
                {
                    accountAdmin = editAccountAdmin.show.v.data;
                }
                else
                {
                    Debug.LogError("editAccountAdmin null: " + this);
                }
            }
            // Process
            if (accountAdmin != null)
            {
                accountAdmin.requestChangeCustomName(accountAdmin.getRequestAccountUserId(), newCustomName);
            }
            else
            {
                Debug.LogError("accountAdmin null: " + this);
            }
        }

        #endregion

        #region avatarUrl

        public VP<RequestChangeStringUI.UIData> avatarUrl;

        public void makeRequestChangeAvatarUrl(RequestChangeUpdate<string>.UpdateData update, string newAvatarUrl)
        {
            // Find
            AccountAdmin accountAdmin = null;
            {
                EditData<AccountAdmin> editAccountAdmin = this.editAccountAdmin.v;
                if (editAccountAdmin != null)
                {
                    accountAdmin = editAccountAdmin.show.v.data;
                }
                else
                {
                    Debug.LogError("editAccountAdmin null: " + this);
                }
            }
            // Process
            if (accountAdmin != null)
            {
                accountAdmin.requestChangeAvatarUrl(accountAdmin.getRequestAccountUserId(), newAvatarUrl);
            }
            else
            {
                Debug.LogError("accountAdmin null: " + this);
            }
        }

        #endregion

        public VP<UIRectTransform.ShowType> showType;

        #region Constructor

        public enum Property
        {
            editAccountAdmin,
            customName,
            avatarUrl,
            showType
        }

        public UIData() : base()
        {
            this.editAccountAdmin = new VP<EditData<AccountAdmin>>(this, (byte)Property.editAccountAdmin, new EditData<AccountAdmin>());
            // customName
            {
                this.customName = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.customName, new RequestChangeStringUI.UIData());
                this.customName.v.updateData.v.request.v = makeRequestChangeCustomName;
            }
            // avatarUrl
            {
                this.avatarUrl = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.avatarUrl, new RequestChangeStringUI.UIData());
                this.avatarUrl.v.updateData.v.request.v = makeRequestChangeAvatarUrl;
            }
            this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
        }

        #endregion

        public override Account.Type getType()
        {
            return Account.Type.Admin;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Account Admin");

    public Text lbCustomName;
    private static readonly TxtLanguage txtCustomName = new TxtLanguage("Custom name");

    public Text lbAvatarUrl;
    private static readonly TxtLanguage txtAvatarUrl = new TxtLanguage("Avatar url");

    static AccountAdminUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Tài khoản admin");
            txtCustomName.add(Language.Type.vi, "Tên");
            txtAvatarUrl.add(Language.Type.vi, "Đường dẫn avatar");
        }
        // rect
        {

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
                EditData<AccountAdmin> editAccountAdmin = this.data.editAccountAdmin.v;
                if (editAccountAdmin != null)
                {
                    editAccountAdmin.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editAccountAdmin);
                        // request
                        Server.State.Type serverState = RequestChange.GetServerState(editAccountAdmin);
                        {
                            RequestChange.RefreshUI(this.data.customName.v, editAccountAdmin, serverState, needReset, editData => editData.customName.v);
                            RequestChange.RefreshUI(this.data.avatarUrl.v, editAccountAdmin, serverState, needReset, editData => editData.avatarUrl.v);
                        }
                        needReset = false;
                    }
                }
                // UISize
                {
                    float deltaY = 0;
                    // header
                    UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                    // customName
                    UIUtils.SetLabelContentPosition(lbCustomName, this.data.customName.v, ref deltaY);
                    // avatarUrl
                    UIUtils.SetLabelContentPosition(lbAvatarUrl, this.data.avatarUrl.v, ref deltaY);
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
                    if (lbCustomName != null)
                    {
                        lbCustomName.text = txtCustomName.get();
                        Setting.get().setLabelTextSize(lbCustomName);
                    }
                    else
                    {
                        Debug.LogError("lbCustomName null: " + this);
                    }
                    if (lbAvatarUrl != null)
                    {
                        lbAvatarUrl.text = txtAvatarUrl.get();
                        Setting.get().setLabelTextSize(lbAvatarUrl);
                    }
                    else
                    {
                        Debug.LogError("lbAvatarUrl null: " + this);
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

    public RequestChangeStringUI requestStringPrefab;

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
                uiData.editAccountAdmin.allAddCallBack(this);
                uiData.customName.allAddCallBack(this);
                uiData.avatarUrl.allAddCallBack(this);
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
            // editAccountAdmin
            {
                if (data is EditData<AccountAdmin>)
                {
                    EditData<AccountAdmin> editAccountAdmin = data as EditData<AccountAdmin>;
                    // Child
                    {
                        editAccountAdmin.show.allAddCallBack(this);
                        editAccountAdmin.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is AccountAdmin)
                    {
                        AccountAdmin accountAdmin = data as AccountAdmin;
                        // Parent
                        {
                            DataUtils.addParentCallBack(accountAdmin, this, ref this.server);
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
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.customName:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.avatarUrl:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, UIConstants.RequestEnumRect);
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
                uiData.editAccountAdmin.allRemoveCallBack(this);
                uiData.customName.allRemoveCallBack(this);
                uiData.avatarUrl.allRemoveCallBack(this);
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
            // editAccountAdmin
            {
                if (data is EditData<AccountAdmin>)
                {
                    EditData<AccountAdmin> editAccountAdmin = data as EditData<AccountAdmin>;
                    // Child
                    {
                        editAccountAdmin.show.allRemoveCallBack(this);
                        editAccountAdmin.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is AccountAdmin)
                    {
                        AccountAdmin accountAdmin = data as AccountAdmin;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(accountAdmin, this, ref this.server);
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
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeStringUI));
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
                case UIData.Property.editAccountAdmin:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.customName:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.avatarUrl:
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
            // editAccountAdmin
            {
                if (wrapProperty.p is EditData<AccountAdmin>)
                {
                    switch ((EditData<AccountAdmin>.Property)wrapProperty.n)
                    {
                        case EditData<AccountAdmin>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<AccountAdmin>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<AccountAdmin>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<AccountAdmin>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<AccountAdmin>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<AccountAdmin>.Property.editType:
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
                    if (wrapProperty.p is AccountAdmin)
                    {
                        switch ((AccountAdmin.Property)wrapProperty.n)
                        {
                            case AccountAdmin.Property.customName:
                                dirty = true;
                                break;
                            case AccountAdmin.Property.avatarUrl:
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
            if (wrapProperty.p is RequestChangeStringUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
    }

    #endregion

}