using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawStateAskIdentity : DataIdentity
{

    #region SyncVar

    public SyncListUInt accepts = new SyncListUInt();

    private void OnAcceptsChanged(SyncListUInt.Operation op, int index)
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

    private void OnRefusesChanged(SyncListUInt.Operation op, int index)
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

    private NetData<RequestDrawStateAsk> netData = new NetData<RequestDrawStateAsk>();

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
        if (data is RequestDrawStateAsk)
        {
            RequestDrawStateAsk requestDrawStateAsk = data as RequestDrawStateAsk;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, requestDrawStateAsk.makeSearchInforms());
                IdentityUtils.InitSync(this.accepts, requestDrawStateAsk.accepts.vs);
                IdentityUtils.InitSync(this.refuses, requestDrawStateAsk.refuses.vs);
            }
            this.getDataSize();
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(requestDrawStateAsk);
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
        if (data is RequestDrawStateAsk)
        {
            // RequestDrawStateAsk requestDrawStateAsk = data as RequestDrawStateAsk;
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
        if (wrapProperty.p is RequestDrawStateAsk)
        {
            switch ((RequestDrawStateAsk.Property)wrapProperty.n)
            {
                case RequestDrawStateAsk.Property.accepts:
                    IdentityUtils.UpdateSyncList(this.accepts, syncs, GlobalCast<T>.CastingUInt32);
                    break;
                case RequestDrawStateAsk.Property.refuses:
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

    #region Answer

    public void requestAnswer(uint userId, RequestDrawStateAsk.Answer answer)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRequestDrawStateAskAnswer(this.netId, userId, answer);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void answer(uint userId, RequestDrawStateAsk.Answer answer)
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