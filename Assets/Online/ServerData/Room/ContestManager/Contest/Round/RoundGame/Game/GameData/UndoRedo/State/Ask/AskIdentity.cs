using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace UndoRedo
{
    public class AskIdentity : DataIdentity
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

        #region cancels

        public SyncListUInt cancels = new SyncListUInt();

        private void OnCancelsChanged(SyncListUInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.cancels, this.cancels, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #endregion

        #region NetData

        private NetData<Ask> netData = new NetData<Ask>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.accepts.Callback += OnAcceptsChanged;
            this.cancels.Callback += OnCancelsChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.accepts, this.accepts);
                IdentityUtils.refresh(this.netData.clientData.cancels, this.cancels);
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
                ret += GetDataSize(this.cancels);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Ask)
            {
                Ask ask = data as Ask;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, ask.makeSearchInforms());
                    IdentityUtils.InitSync(this.accepts, ask.accepts.vs);
                    IdentityUtils.InitSync(this.cancels, ask.cancels.vs);
                }
                this.getDataSize();
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(ask);
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
            if (data is Ask)
            {
                // Ask ask = data as Ask;
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
            if (wrapProperty.p is Ask)
            {
                switch ((Ask.Property)wrapProperty.n)
                {
                    case Ask.Property.requestInform:
                        break;
                    case Ask.Property.whoCanAsks:
                        break;
                    case Ask.Property.accepts:
                        IdentityUtils.UpdateSyncList(this.accepts, syncs, GlobalCast<T>.CastingUInt32);
                        break;
                    case Ask.Property.cancels:
                        IdentityUtils.UpdateSyncList(this.cancels, syncs, GlobalCast<T>.CastingUInt32);
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

        #region answer

        public void requestAnswer(uint userId, Ask.Answer answer)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdUndoRedoAskAnswer(this.netId, userId, answer);
            }
            else
            {
                Debug.LogError("Cannot find userIdentity: " + this);
            }
        }

        public void answer(uint userId, Ask.Answer answer)
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
}