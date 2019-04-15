using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AccountDeviceUI : UIHaveTransformDataBehavior<AccountDeviceUI.UIData>
{

    #region UIData

    public class UIData : AccountUI.UIData.Sub
    {

        public VP<EditData<AccountDevice>> editAccountDevice;

        public VP<RequestChangeStringUI.UIData> imei;

        public VP<RequestChangeStringUI.UIData> deviceName;

        public VP<RequestChangeEnumUI.UIData> deviceType;

        #region customName

        public VP<RequestChangeStringUI.UIData> customName;

        public void makeRequestChangeCustomName(RequestChangeUpdate<string>.UpdateData update, string newCustomName)
        {
            // Find
            AccountDevice accountDevice = null;
            {
                EditData<AccountDevice> editAccountDevice = this.editAccountDevice.v;
                if (editAccountDevice != null)
                {
                    accountDevice = editAccountDevice.show.v.data;
                }
                else
                {
                    Debug.LogError("editAccountDevice null: " + this);
                }
            }
            // Process
            if (accountDevice != null)
            {
                accountDevice.requestChangeCustomName(accountDevice.getRequestAccountUserId(), newCustomName);
            }
            else
            {
                Debug.LogError("accountDevice null: " + this);
            }
        }

        #endregion

        #region avatarUrl

        public VP<RequestChangeStringUI.UIData> avatarUrl;

        public void makeRequestChangeAvatarUrl(RequestChangeUpdate<string>.UpdateData update, string newAvatarUrl)
        {
            // Find
            AccountDevice accountDevice = null;
            {
                EditData<AccountDevice> editAccountDevice = this.editAccountDevice.v;
                if (editAccountDevice != null)
                {
                    accountDevice = editAccountDevice.show.v.data;
                }
                else
                {
                    Debug.LogError("editAccountDevice null: " + this);
                }
            }
            // Process
            if (accountDevice != null)
            {
                accountDevice.requestChangeAvatarUrl(accountDevice.getRequestAccountUserId(), newAvatarUrl);
            }
            else
            {
                Debug.LogError("accountDevice null: " + this);
            }
        }

        public void makeAvatarUrl()
        {
            if (this.avatarUrl.v == null)
            {
                RequestChangeStringUI.UIData newAvatarUrl = new RequestChangeStringUI.UIData();
                {
                    newAvatarUrl.uid = this.avatarUrl.makeId();
                    // event
                    newAvatarUrl.updateData.v.request.v = makeRequestChangeAvatarUrl;
                }
                this.avatarUrl.v = newAvatarUrl;
            }
        }

        #endregion

        public VP<UIRectTransform.ShowType> showType;

        #region Constructor

        public enum Property
        {
            editAccountDevice,
            imei,
            deviceName,
            deviceType,
            customName,
            avatarUrl,
            showType
        }

        public UIData() : base()
        {
            this.editAccountDevice = new VP<EditData<AccountDevice>>(this, (byte)Property.editAccountDevice, new EditData<AccountDevice>());
            // imei
            {
                this.imei = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.imei, new RequestChangeStringUI.UIData());
                this.imei.v.updateData.v.canRequestChange.v = false;
            }
            // deviceName
            {
                this.deviceName = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.deviceName, new RequestChangeStringUI.UIData());
                this.deviceName.v.updateData.v.canRequestChange.v = false;
            }
            // deviceType
            {
                this.deviceType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.deviceType, new RequestChangeEnumUI.UIData());
                // options
                {
                    foreach (DeviceType type in System.Enum.GetValues(typeof(DeviceType)))
                    {
                        this.deviceType.v.options.add(type.ToString());
                    }
                }
            }
            // customName
            {
                this.customName = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.customName, new RequestChangeStringUI.UIData());
                // event
                this.customName.v.updateData.v.request.v = makeRequestChangeCustomName;
            }
            // avatarUrl
            {
                this.avatarUrl = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.avatarUrl, new RequestChangeStringUI.UIData());
                // event
                this.avatarUrl.v.updateData.v.request.v = makeRequestChangeAvatarUrl;
            }
            this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
        }

        #endregion

        public override Account.Type getType()
        {
            return Account.Type.DEVICE;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Account Device");

    public Text lbImei;
    private static readonly TxtLanguage txtImei = new TxtLanguage("Imei");

    public Text lbDeviceName;
    private static readonly TxtLanguage txtDeviceName = new TxtLanguage("Device Name");

    public Text lbDeviceType;
    private static readonly TxtLanguage txtDeviceType = new TxtLanguage("Device type");

    public Text lbCustomName;
    private static readonly TxtLanguage txtCustomName = new TxtLanguage("Custom name");

    public Text lbAvatarUrl;
    private static readonly TxtLanguage txtAvatarUrl = new TxtLanguage("Avatar url");

    static AccountDeviceUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Tài khoản thiết bị");
            txtImei.add(Language.Type.vi, "Imei");
            txtDeviceName.add(Language.Type.vi, "Tên thiết bị");
            txtDeviceType.add(Language.Type.vi, "Tên loại thiết bị");
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
                EditData<AccountDevice> editAccountDevice = this.data.editAccountDevice.v;
                if (editAccountDevice != null)
                {
                    editAccountDevice.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editAccountDevice);
                        // request
                        Server.State.Type serverState = RequestChange.GetServerState(editAccountDevice);
                        {
                            RequestChange.RefreshUIWithCanEdit(this.data.imei.v, editAccountDevice, serverState, needReset, editData => editData.imei.v, false);
                            RequestChange.RefreshUIWithCanEdit(this.data.deviceName.v, editAccountDevice, serverState, needReset, editData => editData.deviceName.v, false);
                            RequestChange.RefreshUIWithCanEdit(this.data.deviceType.v, editAccountDevice, serverState, needReset, editData => editData.deviceType.v, false);
                            RequestChange.RefreshUI(this.data.customName.v, editAccountDevice, serverState, needReset, editData => editData.customName.v);
                            RequestChange.RefreshUI(this.data.avatarUrl.v, editAccountDevice, serverState, needReset, editData => editData.avatarUrl.v);
                        }
                        needReset = false;
                    }
                }
                else
                {
                    Debug.LogError("editAccountDevice null: " + this);
                }
                // UI Size
                {
                    float deltaY = 0;
                    // header
                    UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                    // imei
                    UIUtils.SetLabelContentPosition(lbImei, this.data.imei.v, ref deltaY);
                    // deviceName
                    UIUtils.SetLabelContentPosition(lbDeviceName, this.data.deviceName.v, ref deltaY);
                    // deviceType
                    UIUtils.SetLabelContentPosition(lbDeviceType, this.data.deviceType.v, ref deltaY);
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
                    if (lbImei != null)
                    {
                        lbImei.text = txtImei.get();
                        Setting.get().setLabelTextSize(lbImei);
                    }
                    else
                    {
                        Debug.LogError("lbImei null: " + this);
                    }
                    if (lbDeviceName != null)
                    {
                        lbDeviceName.text = txtDeviceName.get();
                        Setting.get().setLabelTextSize(lbDeviceName);
                    }
                    else
                    {
                        Debug.LogError("lbDeviceName null: " + this);
                    }
                    if (lbDeviceType != null)
                    {
                        lbDeviceType.text = txtDeviceType.get();
                        Setting.get().setLabelTextSize(lbDeviceType);
                    }
                    else
                    {
                        Debug.LogError("lbDeviceType null: " + this);
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
    public RequestChangeEnumUI requestEnumPrefab;

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
                uiData.editAccountDevice.allAddCallBack(this);
                uiData.imei.allAddCallBack(this);
                uiData.deviceName.allAddCallBack(this);
                uiData.deviceType.allAddCallBack(this);
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
            // editAccountDevice
            {
                if (data is EditData<AccountDevice>)
                {
                    EditData<AccountDevice> editAccountDevice = data as EditData<AccountDevice>;
                    // Child
                    {
                        editAccountDevice.show.allAddCallBack(this);
                        editAccountDevice.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is AccountDevice)
                    {
                        AccountDevice accountDevice = data as AccountDevice;
                        // Parent
                        {
                            DataUtils.addParentCallBack(accountDevice, this, ref this.server);
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
                            case UIData.Property.imei:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.deviceName:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, UIConstants.RequestEnumRect);
                                break;
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
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.deviceType:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
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
                uiData.editAccountDevice.allRemoveCallBack(this);
                uiData.imei.allRemoveCallBack(this);
                uiData.deviceName.allRemoveCallBack(this);
                uiData.deviceType.allRemoveCallBack(this);
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
            // editAccountDevice
            {
                if (data is EditData<AccountDevice>)
                {
                    EditData<AccountDevice> editAccountDevice = data as EditData<AccountDevice>;
                    // Child
                    {
                        editAccountDevice.show.allRemoveCallBack(this);
                        editAccountDevice.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is AccountDevice)
                    {
                        AccountDevice accountDevice = data as AccountDevice;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(accountDevice, this, ref this.server);
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
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
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
                case UIData.Property.editAccountDevice:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.imei:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.deviceName:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.deviceType:
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
            // editAccountDevice
            {
                if (wrapProperty.p is EditData<AccountDevice>)
                {
                    switch ((EditData<AccountDevice>.Property)wrapProperty.n)
                    {
                        case EditData<AccountDevice>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<AccountDevice>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<AccountDevice>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<AccountDevice>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<AccountDevice>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<AccountDevice>.Property.editType:
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
                    if (wrapProperty.p is AccountDevice)
                    {
                        switch ((AccountDevice.Property)wrapProperty.n)
                        {
                            case AccountDevice.Property.imei:
                                dirty = true;
                                break;
                            case AccountDevice.Property.deviceName:
                                dirty = true;
                                break;
                            case AccountDevice.Property.deviceType:
                                dirty = true;
                                break;
                            case AccountDevice.Property.customName:
                                dirty = true;
                                break;
                            case AccountDevice.Property.avatarUrl:
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
            if (wrapProperty.p is RequestChangeEnumUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}