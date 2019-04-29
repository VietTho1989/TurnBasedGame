using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class RequestChangeUseRuleStateAskIdentity : DataIdentity
{

    #region SyncVar

    #region accepts

    public SyncListUInt accepts = new SyncListUInt();

    private void OnAcceptsChanged(SyncListUInt.Operation op, int index)
    {
        if (this.netData.clientData != null)
        {
            IdentityUtils.onSyncListChange(this.netData.clientData.accepts, this.accepts, op, index);
        }
        else
        {
            // Debug.LogError ("clientData null: " + this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<RequestChangeUseRuleStateAsk> netData = new NetData<RequestChangeUseRuleStateAsk>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void addSyncListCallBack()
    {
        base.addSyncListCallBack();
        this.accepts.Callback += OnAcceptsChanged;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            IdentityUtils.refresh(this.netData.clientData.accepts, this.accepts);
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
            ret += GetDataSize(this.accepts);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is RequestChangeUseRuleStateAsk)
        {
            RequestChangeUseRuleStateAsk requestChangeUseRuleStateAsk = data as RequestChangeUseRuleStateAsk;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, requestChangeUseRuleStateAsk.makeSearchInforms());
                IdentityUtils.InitSync(this.accepts, requestChangeUseRuleStateAsk.accepts.vs);
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(requestChangeUseRuleStateAsk);
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
        if (data is RequestChangeUseRuleStateAsk)
        {
            // RequestChangeUseRuleStateAsk requestChangeUseRuleStateAsk = data as RequestChangeUseRuleStateAsk;
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
        if (wrapProperty.p is RequestChangeUseRuleStateAsk)
        {
            switch ((RequestChangeUseRuleStateAsk.Property)wrapProperty.n)
            {
                case RequestChangeUseRuleStateAsk.Property.accepts:
                    IdentityUtils.UpdateSyncList(this.accepts, syncs, GlobalCast<T>.CastingUInt32);
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

    #region accept

    public void requestAccept(uint userId)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRequestChangeUseRuleStateAskAccept(this.netId, userId);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void accept(uint userId)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.accept(userId);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region refuse

    public void requestRefuse(uint userId)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRequestChangeUseRuleStateAskRefuse(this.netId, userId);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void refuse(uint userId)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.refuse(userId);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

}