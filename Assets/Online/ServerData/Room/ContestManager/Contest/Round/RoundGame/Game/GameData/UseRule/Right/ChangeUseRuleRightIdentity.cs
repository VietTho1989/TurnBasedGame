using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class ChangeUseRuleRightIdentity : DataIdentity
{

    #region SyncVar

    #region canChange

    [SyncVar(hook = "onChangeCanChange")]
    public System.Boolean canChange;

    public void onChangeCanChange(System.Boolean newCanChange)
    {
        this.canChange = newCanChange;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.canChange.v = newCanChange;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region onlyAdmin

    [SyncVar(hook = "onChangeOnlyAdmin")]
    public System.Boolean onlyAdmin;

    public void onChangeOnlyAdmin(System.Boolean newOnlyAdmin)
    {
        this.onlyAdmin = newOnlyAdmin;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.onlyAdmin.v = newOnlyAdmin;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region needAdmin

    [SyncVar(hook = "onChangeNeedAdmin")]
    public System.Boolean needAdmin;

    public void onChangeNeedAdmin(System.Boolean newNeedAdmin)
    {
        this.needAdmin = newNeedAdmin;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.needAdmin.v = newNeedAdmin;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region needAccept

    [SyncVar(hook = "onChangeNeedAccept")]
    public System.Boolean needAccept;

    public void onChangeNeedAccept(System.Boolean newNeedAccept)
    {
        this.needAccept = newNeedAccept;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.needAccept.v = newNeedAccept;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<ChangeUseRuleRight> netData = new NetData<ChangeUseRuleRight>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeCanChange(this.canChange);
            this.onChangeOnlyAdmin(this.onlyAdmin);
            this.onChangeNeedAdmin(this.needAdmin);
            this.onChangeNeedAccept(this.needAccept);
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
            ret += GetDataSize(this.canChange);
            ret += GetDataSize(this.onlyAdmin);
            ret += GetDataSize(this.needAdmin);
            ret += GetDataSize(this.needAccept);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is ChangeUseRuleRight)
        {
            ChangeUseRuleRight changeUseRuleRight = data as ChangeUseRuleRight;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, changeUseRuleRight.makeSearchInforms());
                this.canChange = changeUseRuleRight.canChange.v;
                this.onlyAdmin = changeUseRuleRight.onlyAdmin.v;
                this.needAdmin = changeUseRuleRight.needAdmin.v;
                this.needAccept = changeUseRuleRight.needAccept.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(changeUseRuleRight);
                }
                else
                {
                    Debug.LogError("observer null: " + this);
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is ChangeUseRuleRight)
        {
            // ChangeUseRuleRight changeUseRuleRight = data as ChangeUseRuleRight;
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.setCheckChangeData(null);
                }
                else
                {
                    Debug.LogError("observer null: " + this);
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
        if (wrapProperty.p is ChangeUseRuleRight)
        {
            switch ((ChangeUseRuleRight.Property)wrapProperty.n)
            {
                case ChangeUseRuleRight.Property.canChange:
                    this.canChange = (System.Boolean)wrapProperty.getValue();
                    break;
                case ChangeUseRuleRight.Property.onlyAdmin:
                    this.onlyAdmin = (System.Boolean)wrapProperty.getValue();
                    break;
                case ChangeUseRuleRight.Property.needAdmin:
                    this.needAdmin = (System.Boolean)wrapProperty.getValue();
                    break;
                case ChangeUseRuleRight.Property.needAccept:
                    this.needAccept = (System.Boolean)wrapProperty.getValue();
                    break;
                default:
                    Debug.LogError("Unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region canChange

    public void requestChangeCanChange(uint userId, bool newCanChange)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdChangeUseRuleRightChangeCanChange(this.netId, userId, newCanChange);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void changeCanChange(uint userId, bool newCanChange)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeCanChange(userId, newCanChange);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region onlyAdmin

    public void requestChangeOnlyAdmin(uint userId, bool newOnlyAdmin)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdChangeUseRuleRightChangeOnlyAdmin(this.netId, userId, newOnlyAdmin);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void changeOnlyAdmin(uint userId, bool newOnlyAdmin)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeOnlyAdmin(userId, newOnlyAdmin);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region needAdmin

    public void requestChangeNeedAdmin(uint userId, bool newNeedAdmin)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdChangeUseRuleRightChangeNeedAdmin(this.netId, userId, newNeedAdmin);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void changeNeedAdmin(uint userId, bool newNeedAdmin)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeNeedAdmin(userId, newNeedAdmin);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region needAccept

    public void requestChangeNeedAccept(uint userId, bool newNeedAccept)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdChangeUseRuleRightChangeNeedAccept(this.netId, userId, newNeedAccept);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void changeNeedAccept(uint userId, bool newNeedAccept)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeNeedAccept(userId, newNeedAccept);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

}