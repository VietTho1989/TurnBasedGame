using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawStateAcceptIdentity : DataIdentity
{

    #region SyncVar

    public SyncListUInt accepts = new SyncListUInt();

    private void OnAcceptsChanged(SyncListUInt.Operation op, int index, uint item)
    {
        if (this.netData.clientData != null)
        {
            IdentityUtils.onSyncListChange(this.netData.clientData.accepts, this.accepts, op, index);
        }
        else
        {
            // Debug.LogError ("clientData null");
        }
    }

    public SyncListUInt refuses = new SyncListUInt();

    private void OnRefusesChanged(SyncListUInt.Operation op, int index, uint item)
    {
        if (this.netData.clientData != null)
        {
            IdentityUtils.onSyncListChange(this.netData.clientData.refuses, this.refuses, op, index);
        }
        else
        {
            // Debug.LogError ("clientData null");
        }
    }

    #endregion

    #region NetData

    private NetData<RequestDrawStateAccept> netData = new NetData<RequestDrawStateAccept>();

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
            // Debug.Log ("clientData null");
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
        if (data is RequestDrawStateAccept)
        {
            RequestDrawStateAccept requestDrawStateAccept = data as RequestDrawStateAccept;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, requestDrawStateAccept.makeSearchInforms());
                IdentityUtils.InitSync(this.accepts, requestDrawStateAccept.accepts.vs);
                IdentityUtils.InitSync(this.refuses, requestDrawStateAccept.refuses.vs);
            }
            this.getDataSize();
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(requestDrawStateAccept);
                }
                else
                {
                    Debug.LogError("observer null");
                }
            }
            return;
        }
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is RequestDrawStateAccept)
        {
            // RequestDrawStateAccept requestDrawStateAccept = data as RequestDrawStateAccept;
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
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, System.Collections.Generic.List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is RequestDrawStateAccept)
        {
            switch ((RequestDrawStateAccept.Property)wrapProperty.n)
            {
                case RequestDrawStateAccept.Property.accepts:
                    IdentityUtils.UpdateSyncList(this.accepts, syncs, GlobalCast<T>.CastingUInt32);
                    break;
                case RequestDrawStateAccept.Property.refuses:
                    IdentityUtils.UpdateSyncList(this.refuses, syncs, GlobalCast<T>.CastingUInt32);
                    break;
                default:
                    Debug.LogError("Unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
    }

    #endregion

    #region Answer

    public void requestAnswer(uint userId, RequestDrawStateAccept.Answer answer)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRequestDrawStateAcceptAnswer(this.netId, userId, answer);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void answer(uint userId, RequestDrawStateAccept.Answer answer)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.answer(userId, answer);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

}