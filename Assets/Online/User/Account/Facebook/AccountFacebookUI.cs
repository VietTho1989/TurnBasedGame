using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AccountFacebookUI : UIHaveTransformDataBehavior<AccountFacebookUI.UIData>
{

    #region UIData

    public class UIData : AccountUI.UIData.Sub
    {

        public VP<EditData<AccountFacebook>> editAccountFacebook;

        public VP<RequestChangeStringUI.UIData> userId;

        public VP<RequestChangeStringUI.UIData> firstName;

        public VP<RequestChangeStringUI.UIData> lastName;

        public VP<UIRectTransform.ShowType> showType;

        #region Constructor

        public enum Property
        {
            editAccountFacebook,
            userId,
            firstName,
            lastName,
            showType
        }

        public UIData() : base()
        {
            this.editAccountFacebook = new VP<EditData<AccountFacebook>>(this, (byte)Property.editAccountFacebook, new EditData<AccountFacebook>());
            this.userId = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.userId, new RequestChangeStringUI.UIData());
            this.firstName = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.firstName, new RequestChangeStringUI.UIData());
            this.lastName = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.lastName, new RequestChangeStringUI.UIData());
            this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
        }

        #endregion

        public override Account.Type getType()
        {
            return Account.Type.FACEBOOK;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Account Facebook");

    public Text lbUserId;
    private static readonly TxtLanguage txtUserId = new TxtLanguage("User ID");

    public Text lbFirstName;
    private static readonly TxtLanguage txtFirstName = new TxtLanguage("First name");

    public Text lbLastName;
    private static readonly TxtLanguage txtLastName = new TxtLanguage("Last name");

    static AccountFacebookUI()
    {
        txtTitle.add(Language.Type.vi, "Tài Khoản Facebook");
        txtUserId.add(Language.Type.vi, "Id người dùng");
        txtFirstName.add(Language.Type.vi, "Tên riêng");
        txtLastName.add(Language.Type.vi, "Họ");
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
                EditData<AccountFacebook> editAccountFacebook = this.data.editAccountFacebook.v;
                if (editAccountFacebook != null)
                {
                    editAccountFacebook.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editAccountFacebook);
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editAccountFacebook);
                            // set origin
                            {
                                RequestChange.RefreshUIWithCanEdit(this.data.userId.v, editAccountFacebook, serverState, needReset, editData => editData.userId.v, false);
                                RequestChange.RefreshUIWithCanEdit(this.data.firstName.v, editAccountFacebook, serverState, needReset, editData => editData.firstName.v, false);
                                RequestChange.RefreshUIWithCanEdit(this.data.lastName.v, editAccountFacebook, serverState, needReset, editData => editData.lastName.v, false);
                            }
                            needReset = false;
                        }
                    }
                }
                else
                {
                    Debug.LogError("editAccountFacebook null: " + this);
                }
                // UI
                {
                    float deltaY = 0;
                    // header
                    {
                        switch (this.data.showType.v)
                        {
                            case UIRectTransform.ShowType.Normal:
                                {
                                    if (lbTitle != null)
                                    {
                                        lbTitle.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbTitle null");
                                    }
                                    deltaY += UIConstants.HeaderHeight;
                                }
                                break;
                            case UIRectTransform.ShowType.HeadLess:
                                {
                                    if (lbTitle != null)
                                    {
                                        lbTitle.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbTitle null");
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + this.data.showType.v);
                                break;
                        }
                    }
                    // userId
                    {
                        if (this.data.userId.v != null)
                        {
                            if (lbUserId != null)
                            {
                                lbUserId.gameObject.SetActive(true);
                            }
                            else
                            {
                                Debug.LogError("lbUserId null");
                            }
                            UIRectTransform.SetPosY(this.data.userId.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbUserId != null)
                            {
                                lbUserId.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbUserId null");
                            }
                        }
                    }
                    // firstName
                    {
                        if (this.data.firstName.v != null)
                        {
                            if (lbFirstName != null)
                            {
                                lbFirstName.gameObject.SetActive(true);
                            }
                            else
                            {
                                Debug.LogError("lbFirstName null");
                            }
                            UIRectTransform.SetPosY(this.data.firstName.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbFirstName != null)
                            {
                                lbFirstName.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbFirstName null");
                            }
                        }
                    }
                    // lastName
                    {
                        if (this.data.lastName.v != null)
                        {
                            if (lbLastName != null)
                            {
                                lbLastName.gameObject.SetActive(true);
                            }
                            else
                            {
                                Debug.LogError("lbLastName null");
                            }
                            UIRectTransform.SetPosY(this.data.lastName.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbLastName != null)
                            {
                                lbLastName.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbLastName null");
                            }
                        }
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
                    if (lbUserId != null)
                    {
                        lbUserId.text = txtUserId.get();
                        Setting.get().setLabelTextSize(lbUserId);
                    }
                    else
                    {
                        Debug.LogError("lbUserId null: " + this);
                    }
                    if (lbFirstName != null)
                    {
                        lbFirstName.text = txtFirstName.get();
                        Setting.get().setLabelTextSize(lbFirstName);
                    }
                    else
                    {
                        Debug.LogError("lbFirstName null: " + this);
                    }
                    if (lbLastName != null)
                    {
                        lbLastName.text = txtLastName.get();
                        Setting.get().setLabelTextSize(lbLastName);
                    }
                    else
                    {
                        Debug.LogError("lbLastName null: " + this);
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
                uiData.editAccountFacebook.allAddCallBack(this);
                uiData.userId.allAddCallBack(this);
                uiData.firstName.allAddCallBack(this);
                uiData.lastName.allAddCallBack(this);
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
            // editAccountFacebook
            {
                if (data is EditData<AccountFacebook>)
                {
                    EditData<AccountFacebook> editAccountFacebook = data as EditData<AccountFacebook>;
                    // Child
                    {
                        editAccountFacebook.show.allAddCallBack(this);
                        editAccountFacebook.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is AccountFacebook)
                    {
                        AccountFacebook accountFacebook = data as AccountFacebook;
                        // Parent
                        {
                            DataUtils.addParentCallBack(accountFacebook, this, ref this.server);
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
                            case UIData.Property.userId:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.firstName:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.lastName:
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
                uiData.editAccountFacebook.allRemoveCallBack(this);
                uiData.userId.allRemoveCallBack(this);
                uiData.firstName.allRemoveCallBack(this);
                uiData.lastName.allRemoveCallBack(this);
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
            // editAccountFacebook
            {
                if (data is EditData<AccountFacebook>)
                {
                    EditData<AccountFacebook> editAccountFacebook = data as EditData<AccountFacebook>;
                    // Child
                    {
                        editAccountFacebook.show.allRemoveCallBack(this);
                        editAccountFacebook.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is AccountFacebook)
                    {
                        AccountFacebook accountFacebook = data as AccountFacebook;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(accountFacebook, this, ref this.server);
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
                case UIData.Property.editAccountFacebook:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.userId:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.firstName:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.lastName:
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
            // editAccountFacebook
            {
                if (wrapProperty.p is EditData<AccountFacebook>)
                {
                    switch ((EditData<AccountFacebook>.Property)wrapProperty.n)
                    {
                        case EditData<AccountFacebook>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<AccountFacebook>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<AccountFacebook>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<AccountFacebook>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<AccountFacebook>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<AccountFacebook>.Property.editType:
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
                    if (wrapProperty.p is AccountFacebook)
                    {
                        switch ((AccountFacebook.Property)wrapProperty.n)
                        {
                            case AccountFacebook.Property.userId:
                                dirty = true;
                                break;
                            case AccountFacebook.Property.firstName:
                                dirty = true;
                                break;
                            case AccountFacebook.Property.lastName:
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