using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace GameManager.Match.RoundRobin
{
    public class RoundRobinFactoryIdentity : DataIdentity
    {

        #region SyncVar

        #region teamCount

        [SyncVar(hook = "onChangeTeamCount")]
        public System.Int32 teamCount;

        public void onChangeTeamCount(System.Int32 newTeamCount)
        {
            this.teamCount = newTeamCount;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.teamCount.v = newTeamCount;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region needReturnRound

        [SyncVar(hook = "onChangeNeedReturnRound")]
        public System.Boolean needReturnRound;

        public void onChangeNeedReturnRound(System.Boolean newNeedReturnRound)
        {
            this.needReturnRound = newNeedReturnRound;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.needReturnRound.v = newNeedReturnRound;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<RoundRobinFactory> netData = new NetData<RoundRobinFactory>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeTeamCount(this.teamCount);
                this.onChangeNeedReturnRound(this.needReturnRound);
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
                ret += GetDataSize(this.teamCount);
                ret += GetDataSize(this.needReturnRound);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is RoundRobinFactory)
            {
                RoundRobinFactory roundRobinFactory = data as RoundRobinFactory;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, roundRobinFactory.makeSearchInforms());
                    this.teamCount = roundRobinFactory.teamCount.v;
                    this.needReturnRound = roundRobinFactory.needReturnRound.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(roundRobinFactory);
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
            if (data is RoundRobinFactory)
            {
                // RoundRobinFactory roundRobinFactory = data as RoundRobinFactory;
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
            if (wrapProperty.p is RoundRobinFactory)
            {
                switch ((RoundRobinFactory.Property)wrapProperty.n)
                {
                    case RoundRobinFactory.Property.singleContestFactory:
                        break;
                    case RoundRobinFactory.Property.teamCount:
                        this.teamCount = (System.Int32)wrapProperty.getValue();
                        break;
                    case RoundRobinFactory.Property.needReturnRound:
                        this.needReturnRound = (System.Boolean)wrapProperty.getValue();
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

        #region teamCount

        public void requestChangeTeamCount(uint userId, int newTeamCount)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdRoundRobinFactoryChangeTeamCount(this.netId, userId, newTeamCount);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeTeamCount(uint userId, int newTeamCount)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeTeamCount(userId, newTeamCount);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region needReturnRound

        public void requestChangeNeedReturnRound(uint userId, bool newNeedReturnRound)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdRoundRobinFactoryChangeNeedReturnRound(this.netId, userId, newNeedReturnRound);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeNeedReturnRound(uint userId, bool newNeedReturnRound)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeNeedReturnRound(userId, newNeedReturnRound);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}