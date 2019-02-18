using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;

public class LoginUI : UIBehavior<LoginUI.UIData>
{

    #region UIData

    public class UIData : NormalUI.UIData.Sub
    {

        public VP<ReferenceData<Server>> server;

        #region AccountType

        public VP<RequestChangeEnumUI.UIData> accountType;

        public void makeRequestChangeAccountType(RequestChangeUpdate<int>.UpdateData update, int newAccountType)
        {
            if (this.accountType.v != null)
            {
                this.accountType.v.updateData.v.origin.v = newAccountType;
            }
            else
            {
                Debug.LogError("newAccountType null: " + this);
            }
        }

        #endregion

        #region AccountUI

        public VP<AccountUI.UIData> accountUIData;

        #endregion

        public VP<LoginStateUI.UIData> loginStateUI;

        #region Constructor

        public enum Property
        {
            server,
            accountType,
            accountUIData,
            loginStateUI
        }

        public UIData() : base()
        {
            this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
            // accountType
            {
                this.accountType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.accountType, new RequestChangeEnumUI.UIData());
                this.accountType.v.updateData.v.canRequestChange.v = true;
                // options
                {
                    for (int i = 0; i < Account.LoginTypes.Length; i++)
                    {
                        this.accountType.v.options.add(Account.LoginTypes[i].ToString());
                    }
                }
                this.accountType.v.updateData.v.request.v = makeRequestChangeAccountType;
            }
            // accountUIData
            {
                this.accountUIData = new VP<AccountUI.UIData>(this, (byte)Property.accountUIData, new AccountUI.UIData());
                this.accountUIData.v.isLogin.v = true;
                // edit
                {
                    // origin
                    // show
                    // compare
                    // compareOtherType
                    this.accountUIData.v.editAccount.v.canEdit.v = true;
                    this.accountUIData.v.editAccount.v.editType.v = EditType.Immediate;
                    this.accountUIData.v.subNeedHeader.v = false;
                }
            }
            this.loginStateUI = new VP<LoginStateUI.UIData>(this, (byte)Property.loginStateUI, new LoginStateUI.UIData());
        }

        #endregion

        public override Type getType()
        {
            return Type.Login;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        LoginUI loginUI = this.findCallBack<LoginUI>();
                        if (loginUI != null)
                        {
                            loginUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("loginUI null: " + this);
                        }
                        isProcess = true;
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt, rect

    public Text tvBack;
    public static readonly TxtLanguage txtBack = new TxtLanguage();

    public Text lbAccountType;
    public static readonly TxtLanguage txtAccountType = new TxtLanguage();

    static LoginUI()
    {
        // txt
        {
            txtBack.add(Language.Type.vi, "Quay Lại");
            txtAccountType.add(Language.Type.vi, "Loại Tài Khoản");
        }
        // rect
        {

        }
    }

    #endregion

    #region Refresh

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // Find Login
                Login login = null;
                {
                    Server server = this.data.server.v.data;
                    if (server != null)
                    {
                        if (server.state.v != null && server.state.v is Server.State.Offline)
                        {
                            Server.State.Offline offline = server.state.v as Server.State.Offline;
                            login = offline.login.v;
                        }
                    }
                    else
                    {
                        Debug.Log("server null: " + this);
                    }
                }
                // Process
                if (login != null)
                {
                    bool canEdit = false;
                    {
                        if (login.state.v != null)
                        {
                            if (login.state.v.getType() == Login.State.Type.None)
                            {
                                canEdit = true;
                            }
                        }
                    }
                    // account
                    {
                        // Logic
                        {
                            // Find chosen accountType
                            Account.Type accountType = Account.Type.DEVICE;
                            {
                                RequestChangeEnumUI.UIData enumAccountType = this.data.accountType.v;
                                if (enumAccountType != null)
                                {
                                    accountType = Account.getLoginType(enumAccountType.updateData.v.current.v);
                                    // canEdit?
                                    enumAccountType.updateData.v.canRequestChange.v = canEdit;
                                }
                                else
                                {
                                    Debug.LogError("enumAccountType null: " + this);
                                }
                            }
                            // Process
                            if (canEdit)
                            {
                                bool needNew = true;
                                {
                                    if (login.account.v != null)
                                    {
                                        if (login.account.v.getType() == accountType)
                                        {
                                            needNew = false;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("login account null: " + this);
                                    }
                                }
                                if (needNew)
                                {
                                    switch (accountType)
                                    {
                                        case Account.Type.DEVICE:
                                            {
                                                AccountDevice accountDevice = new AccountDevice();
                                                {
                                                    accountDevice.uid = login.account.makeId();
                                                    accountDevice.imei.v = SystemInfo.deviceUniqueIdentifier;
                                                    accountDevice.deviceName.v = SystemInfo.deviceName;
                                                    accountDevice.deviceType.v = (int)SystemInfo.deviceType;
                                                    accountDevice.customName.v = "";
                                                }
                                                login.account.v = accountDevice;
                                            }
                                            break;
                                        case Account.Type.EMAIL:
                                            {
                                                AccountEmail accountEmail = new AccountEmail();
                                                {
                                                    accountEmail.uid = login.account.makeId();
                                                    // TODO Sau nay can phai load tu preference ra
                                                    accountEmail.email.v = "";
                                                    accountEmail.password.v = "";
                                                    accountEmail.customName.v = "";
                                                    accountEmail.avatarUrl.v = "";
                                                }
                                                login.account.v = accountEmail;
                                            }
                                            break;
                                        case Account.Type.FACEBOOK:
                                            {
                                                AccountFacebook accountFacebook = new AccountFacebook();
                                                {
                                                    accountFacebook.uid = login.account.makeId();
                                                }
                                                login.account.v = accountFacebook;
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown accountType: " + accountType + "; " + this);
                                            break;
                                    }
                                }
                            }
                        }
                        // Update accountUIData
                        {
                            AccountUI.UIData accountUIData = this.data.accountUIData.v;
                            if (accountUIData != null)
                            {
                                EditData<Account> editAccount = accountUIData.editAccount.v;
                                if (editAccount != null)
                                {
                                    // canEdit
                                    editAccount.canEdit.v = canEdit;
                                    // origin
                                    editAccount.origin.v = new ReferenceData<Account>(login.account.v);
                                }
                                else
                                {
                                    Debug.LogError("editAccount null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("accountUIData null: " + this);
                            }
                        }
                    }
                    // loginStateUI
                    if (this.data.loginStateUI.v != null)
                    {
                        this.data.loginStateUI.v.login.v = new ReferenceData<Login>(login);
                    }
                    else
                    {
                        Debug.LogError("loginStateUI null: " + this);
                    }
                }
                else
                {
                    Debug.Log("login null: " + this);
                }
                // UI
                {
                    if (contentContainer != null)
                    {
                        float deltaY = 0;
                        // accountType
                        {
                            if (this.data.accountType.v != null)
                            {
                                if (lbAccountType != null)
                                {
                                    lbAccountType.gameObject.SetActive(true);
                                }
                                else
                                {
                                    Debug.LogError("lbAccountType null");
                                }
                                deltaY += UIConstants.ItemHeight - 5;
                            }
                            else
                            {
                                if (lbAccountType != null)
                                {
                                    lbAccountType.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbAccountType null");
                                }
                            }
                        }
                        // accountUIData
                        deltaY += UIRectTransform.SetPosY(this.data.accountUIData.v, deltaY);
                        // loginStateUI
                        deltaY += UIRectTransform.SetPosY(this.data.loginStateUI.v, deltaY);
                        // set size
                        UIRectTransform.SetHeight((RectTransform)contentContainer.transform, deltaY);
                    }
                    else
                    {
                        Debug.LogError("contentContainer null");
                    }
                }
                // txt
                {
                    if (tvBack != null)
                    {
                        tvBack.text = txtBack.get("Back");
                    }
                    else
                    {
                        // Debug.LogError("tvBack null: " + this);
                    }
                    if (lbAccountType != null)
                    {
                        lbAccountType.text = txtAccountType.get("Account Type");
                    }
                    else
                    {
                        Debug.LogError("lbAccountType null: " + this);
                    }
                }
            }
            else
            {
                Debug.Log("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public Transform contentContainer;

    public RequestChangeEnumUI requestEnumPrefab;
    private static readonly UIRectTransform accountTypeRect = new UIRectTransform(UIConstants.RequestEnumRect, (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);

    public AccountUI accountUIPrefab;
    public LoginStateUI loginStateUIPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.server.allAddCallBack(this);
                uiData.accountType.allAddCallBack(this);
                uiData.accountUIData.allAddCallBack(this);
                uiData.loginStateUI.allAddCallBack(this);
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
            // Server
            {
                if (data is Server)
                {
                    Server server = data as Server;
                    // Child
                    {
                        server.state.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Server.State)
                    {
                        Server.State serverState = data as Server.State;
                        // Child
                        {
                            if (serverState is Server.State.Offline)
                            {
                                Server.State.Offline offline = serverState as Server.State.Offline;
                                offline.login.allAddCallBack(this);
                            }
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is Login)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // accountType
            {
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
                                case UIData.Property.accountType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, contentContainer, accountTypeRect);
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
                    // Child
                    {
                        requestChange.updateData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is RequestChangeIntUpdate.UpdateData)
                {
                    dirty = true;
                    return;
                }
            }
            // accountUIData
            if (data is AccountUI.UIData)
            {
                AccountUI.UIData accountUIData = data as AccountUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(accountUIData, accountUIPrefab, contentContainer);
                }
                // Child
                {
                    TransformData.AddCallBack(accountUIData, this);
                }
                dirty = true;
                return;
            }
            // LoginStateUIData
            if (data is LoginStateUI.UIData)
            {
                LoginStateUI.UIData loginStateUIData = data as LoginStateUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(loginStateUIData, loginStateUIPrefab, contentContainer);
                }
                // Child
                {
                    TransformData.RemoveCallBack(loginStateUIData, this);
                }
                dirty = true;
                return;
            }
            // Child
            if(data is TransformData)
            {
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
                uiData.server.allRemoveCallBack(this);
                uiData.accountType.allRemoveCallBack(this);
                uiData.accountUIData.allRemoveCallBack(this);
                uiData.loginStateUI.allRemoveCallBack(this);
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
            // Server
            {
                if (data is Server)
                {
                    Server server = data as Server;
                    // Child
                    {
                        server.state.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Server.State)
                    {
                        Server.State serverState = data as Server.State;
                        // Child
                        {
                            if (serverState is Server.State.Offline)
                            {
                                Server.State.Offline offline = serverState as Server.State.Offline;
                                offline.login.allRemoveCallBack(this);
                            }
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is Login)
                        {
                            return;
                        }
                    }
                }
            }
            // accountType
            {
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                    }
                    // Child
                    {
                        requestChange.updateData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is RequestChangeIntUpdate.UpdateData)
                {
                    return;
                }
            }
            // accountUIData
            if (data is AccountUI.UIData)
            {
                AccountUI.UIData accountUIData = data as AccountUI.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(accountUIData, this);
                }
                // UI
                {
                    accountUIData.removeCallBackAndDestroy(typeof(AccountUI));
                }
                return;
            }
            // LoginStateUIData
            if (data is LoginStateUI.UIData)
            {
                LoginStateUI.UIData loginStateUIData = data as LoginStateUI.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(loginStateUIData, this);
                }
                // UI
                {
                    loginStateUIData.removeCallBackAndDestroy(typeof(LoginStateUI));
                }
                return;
            }
            // Child
            if(data is TransformData)
            {
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
                case UIData.Property.server:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.accountType:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.accountUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.loginStateUI:
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
            // Server
            {
                if (wrapProperty.p is Server)
                {
                    switch ((Server.Property)wrapProperty.n)
                    {
                        case Server.Property.serverConfig:
                            break;
                        case Server.Property.startState:
                            break;
                        case Server.Property.type:
                            break;
                        case Server.Property.profile:
                            break;
                        case Server.Property.state:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Server.Property.users:
                            break;
                        case Server.Property.globalChat:
                            break;
                        case Server.Property.friendWorld:
                            break;
                        case Server.Property.guilds:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is Server.State)
                    {
                        if (wrapProperty.p is Server.State.Offline)
                        {
                            switch ((Server.State.Offline.Property)wrapProperty.n)
                            {
                                case Server.State.Offline.Property.login:
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
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is Login)
                        {
                            switch ((Login.Property)wrapProperty.n)
                            {
                                case Login.Property.state:
                                    dirty = true;
                                    break;
                                case Login.Property.account:
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
            }
            // accountType
            {
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
                {
                    switch ((RequestChangeEnumUI.UIData.Property)wrapProperty.n)
                    {
                        case RequestChangeEnumUI.UIData.Property.updateData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case RequestChangeEnumUI.UIData.Property.options:
                            break;
                        case RequestChangeEnumUI.UIData.Property.showDifferent:
                            break;
                        case RequestChangeEnumUI.UIData.Property.compare:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is RequestChangeIntUpdate.UpdateData)
                {
                    switch ((RequestChangeIntUpdate.UpdateData.Property)wrapProperty.n)
                    {
                        case RequestChangeUpdate<int>.UpdateData.Property.origin:
                            dirty = true;
                            break;
                        case RequestChangeUpdate<int>.UpdateData.Property.current:
                            dirty = true;
                            break;
                        case RequestChangeUpdate<int>.UpdateData.Property.canRequestChange:
                            break;
                        case RequestChangeUpdate<int>.UpdateData.Property.changeState:
                            break;
                        case RequestChangeUpdate<int>.UpdateData.Property.serverState:
                            break;
                        case RequestChangeUpdate<int>.UpdateData.Property.request:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // accountUIData
            if (wrapProperty.p is AccountUI.UIData)
            {
                return;
            }
            // LoginStateUIData
            if (wrapProperty.p is LoginStateUI.UIData)
            {
                return;
            }
            // Child
            if(wrapProperty.p is TransformData)
            {
                switch ((TransformData.Property)wrapProperty.n)
                {
                    case TransformData.Property.position:
                        break;
                    case TransformData.Property.rotation:
                        break;
                    case TransformData.Property.scale:
                        break;
                    case TransformData.Property.size:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            ServerManager.UIData.OnClick onClick = this.data.findDataInParent<ServerManager.UIData.OnClick>();
            if (onClick != null)
            {
                onClick.onClickReturn();
            }
            else
            {
                Debug.LogError("onClick null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }
}