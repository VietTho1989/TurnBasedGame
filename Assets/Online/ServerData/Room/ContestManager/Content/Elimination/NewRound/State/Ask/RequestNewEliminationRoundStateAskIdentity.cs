using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace GameManager.Match.Elimination
{
    public class RequestNewEliminationRoundStateAskIdentity : DataIdentity
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

        private NetData<RequestNewEliminationRoundStateAsk> netData = new NetData<RequestNewEliminationRoundStateAsk>();

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
            if (data is RequestNewEliminationRoundStateAsk)
            {
                RequestNewEliminationRoundStateAsk requestNewEliminationRoundStateAsk = data as RequestNewEliminationRoundStateAsk;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, requestNewEliminationRoundStateAsk.makeSearchInforms());
                    IdentityUtils.InitSync(this.accepts, requestNewEliminationRoundStateAsk.accepts.vs);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(requestNewEliminationRoundStateAsk);
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
            if (data is RequestNewEliminationRoundStateAsk)
            {
                // RequestNewEliminationRoundStateAsk requestNewEliminationRoundStateAsk = data as RequestNewEliminationRoundStateAsk;
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
            if (wrapProperty.p is RequestNewEliminationRoundStateAsk)
            {
                switch ((RequestNewEliminationRoundStateAsk.Property)wrapProperty.n)
                {
                    case RequestNewEliminationRoundStateAsk.Property.whoCanAsks:
                        break;
                    case RequestNewEliminationRoundStateAsk.Property.accepts:
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
                clientConnect.CmdRequestNewEliminationRoundStateAskAccept(this.netId, userId);
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

        #region cancel

        public void requestCancel(uint userId)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdRequestNewEliminationRoundStateAskCancel(this.netId, userId);
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
}