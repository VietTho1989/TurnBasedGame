using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class FriendStateRequestIdentity : DataIdentity
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

    #region refuses

    public SyncListUInt refuses = new SyncListUInt();

    private void OnRefusesChanged(SyncListUInt.Operation op, int index)
    {
        if (this.netData.clientData != null)
        {
            IdentityUtils.onSyncListChange(this.netData.clientData.refuses, this.refuses, op, index);
        }
        else
        {
            // Debug.LogError ("clientData null: " + this);
        }
    }
    #endregion

    #endregion

    #region NetData

    private NetData<FriendStateRequest> netData = new NetData<FriendStateRequest>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void addSyncListCallBack()
    {
        base.addSyncListCallBack();
        this.accepts.Callback += OnAcceptsChanged;
        this.refuses.Callback += OnRefusesChanged;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            IdentityUtils.refresh(this.netData.clientData.accepts, this.accepts);
            IdentityUtils.refresh(this.netData.clientData.refuses, this.refuses);
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
            ret += GetDataSize(this.refuses);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is FriendStateRequest)
        {
            FriendStateRequest friendStateRequest = data as FriendStateRequest;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, friendStateRequest.makeSearchInforms());
                IdentityUtils.InitSync(this.accepts, friendStateRequest.accepts.vs);
                IdentityUtils.InitSync(this.refuses, friendStateRequest.refuses.vs);
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(friendStateRequest);
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
        if (data is FriendStateRequest)
        {
            // FriendStateRequest friendStateRequest = data as FriendStateRequest;
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
        if (wrapProperty.p is FriendStateRequest)
        {
            switch ((FriendStateRequest.Property)wrapProperty.n)
            {
                case FriendStateRequest.Property.accepts:
                    IdentityUtils.UpdateSyncList(this.accepts, syncs, GlobalCast<T>.CastingUInt32);
                    break;
                case FriendStateRequest.Property.refuses:
                    IdentityUtils.UpdateSyncList(this.refuses, syncs, GlobalCast<T>.CastingUInt32);
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

    #region accept

    public void requestAccept(uint userId)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdFriendStateRequestAccept(this.netId, userId);
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
            clientConnect.CmdFriendStateRequestRefuse(this.netId, userId);
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

    #region cancel

    public void requestCancel(uint userId)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdFriendStateRequestCancel(this.netId, userId);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void cancel(uint userId)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.cancel(userId);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

}