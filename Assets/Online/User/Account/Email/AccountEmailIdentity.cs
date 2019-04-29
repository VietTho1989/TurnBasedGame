using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class AccountEmailIdentity : DataIdentity
{

    #region SyncVar

    #region email

    [SyncVar(hook = "onChangeEmail")]
    public System.String email;

    public void onChangeEmail(System.String newEmail)
    {
        this.email = newEmail;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.email.v = newEmail;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region password

    [SyncVar(hook = "onChangePassword")]
    public System.String password;

    public void onChangePassword(System.String newPassword)
    {
        this.password = newPassword;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.password.v = newPassword;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region customName

    [SyncVar(hook = "onChangeCustomName")]
    public System.String customName;

    public void onChangeCustomName(System.String newCustomName)
    {
        this.customName = newCustomName;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.customName.v = newCustomName;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region avatarUrl

    [SyncVar(hook = "onChangeAvatarUrl")]
    public System.String avatarUrl;

    public void onChangeAvatarUrl(System.String newAvatarUrl)
    {
        this.avatarUrl = newAvatarUrl;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.avatarUrl.v = newAvatarUrl;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<AccountEmail> netData = new NetData<AccountEmail>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeEmail(this.email);
            this.onChangePassword(this.password);
            this.onChangeCustomName(this.customName);
            this.onChangeAvatarUrl(this.avatarUrl);
        }
        else
        {
            Debug.Log("clientData null");
        }
    }

    public override int refreshDataSize()
    {
        int ret = GetDataSize(this.netId);
        {
            ret += GetDataSize(this.email);
            ret += GetDataSize(this.password);
            ret += GetDataSize(this.customName);
            ret += GetDataSize(this.avatarUrl);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is AccountEmail)
        {
            AccountEmail accountEmail = data as AccountEmail;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, accountEmail.makeSearchInforms());
                this.email = accountEmail.email.v;
                this.password = "";
                this.customName = accountEmail.customName.v;
                this.avatarUrl = accountEmail.avatarUrl.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(accountEmail);
                }
                else
                {
                    Debug.LogError("observer null");
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is AccountEmail)
        {
            // AccountEmail accountEmail = data as AccountEmail;
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.setCheckChangeData(null);
                }
                else
                {
                    Debug.LogError("observer null");
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is AccountEmail)
        {
            switch ((AccountEmail.Property)wrapProperty.n)
            {
                case AccountEmail.Property.email:
                    this.email = (System.String)wrapProperty.getValue();
                    break;
                case AccountEmail.Property.password:
                    this.password = ""; //(System.String)wrapProperty.getValue ();
                    break;
                case AccountEmail.Property.customName:
                    this.customName = (System.String)wrapProperty.getValue();
                    break;
                case AccountEmail.Property.avatarUrl:
                    this.avatarUrl = (System.String)wrapProperty.getValue();
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region password

    /**
	 * Client request
	 * */
    public void requestChangePassword(uint userId, string newPassword, string oldPassword)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdAccountEmailChangePassword(this.netId, userId, newPassword, oldPassword);
        }
        else
        {
            Debug.LogError("Cannot find userIdentity: " + this);
        }
    }

    /**
	* Server process
	 * */
    public void changePassword(uint userId, string newPassword, string oldPassword)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changePassword(userId, newPassword, oldPassword);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region customName

    public void requestChangeCustomName(uint userId, string newCustomName)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdAccountEmailChangeCustomName(this.netId, userId, newCustomName);
        }
        else
        {
            Debug.LogError("Cannot find userIdentity: " + this);
        }
    }

    public void changeCustomName(uint userId, string newCustomName)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeCustomName(userId, newCustomName);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region avatarUrl

    public void requestChangeAvatarUrl(uint userId, string newAvatarUrl)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdAccountEmailChangeAvatarUrl(this.netId, userId, newAvatarUrl);
        }
        else
        {
            Debug.LogError("Cannot find userIdentity: " + this);
        }
    }

    public void changeAvatarUrl(uint userId, string newAvatarUrl)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeAvatarUrl(userId, newAvatarUrl);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

}