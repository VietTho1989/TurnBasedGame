using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class EliminationFactoryIdentity : DataIdentity
    {

        #region SyncVar

        #region initTeamCounts

        public SyncListUInt initTeamCounts = new SyncListUInt();

        private void OnInitTeamCountsChanged(SyncListUInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.initTeamCounts, this.initTeamCounts, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #endregion

        #region NetData

        private NetData<EliminationFactory> netData = new NetData<EliminationFactory>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.initTeamCounts.Callback += OnInitTeamCountsChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.initTeamCounts, this.initTeamCounts);
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
                ret += GetDataSize(this.initTeamCounts);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is EliminationFactory)
            {
                EliminationFactory eliminationFactory = data as EliminationFactory;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, eliminationFactory.makeSearchInforms());
                    IdentityUtils.InitSync(this.initTeamCounts, eliminationFactory.initTeamCounts.vs);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(eliminationFactory);
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
            if (data is EliminationFactory)
            {
                // EliminationFactory eliminationFactory = data as EliminationFactory;
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
            if (wrapProperty.p is EliminationFactory)
            {
                switch ((EliminationFactory.Property)wrapProperty.n)
                {
                    case EliminationFactory.Property.singleContestFactory:
                        break;
                    case EliminationFactory.Property.initTeamCounts:
                        IdentityUtils.UpdateSyncList(this.initTeamCounts, syncs, GlobalCast<T>.CastingUInt32);
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

        #region initTeamCountLength

        public void requestChangeInitTeamCountLength(uint userId, int newLength)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdEliminationFactoryChangeInitTeamCountLength(this.netId, userId, newLength);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeInitTeamCountLength(uint userId, int newLength)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeInitTeamCountLength(userId, newLength);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region initTeamCount by index

        public void requestChangeInitTeamCount(uint userId, int index, uint newInitTeamCount)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdEliminationFactoryChangeInitTeamCount(this.netId, userId, index, newInitTeamCount);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeInitTeamCount(uint userId, int index, uint newInitTeamCount)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeInitTeamCount(userId, index, newInitTeamCount);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}