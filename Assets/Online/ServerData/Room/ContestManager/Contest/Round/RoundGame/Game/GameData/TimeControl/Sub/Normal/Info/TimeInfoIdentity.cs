using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace TimeControl.Normal
{
    public class TimeInfoIdentity : DataIdentity
    {

        #region SyncVar

        #region lagCompensation

        [SyncVar(hook = "onChangeLagCompensation")]
        public System.Single lagCompensation;

        public void onChangeLagCompensation(System.Single newLagCompensation)
        {
            this.lagCompensation = newLagCompensation;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.lagCompensation.v = newLagCompensation;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<TimeInfo> netData = new NetData<TimeInfo>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeLagCompensation(this.lagCompensation);
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
                ret += GetDataSize(this.lagCompensation);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is TimeInfo)
            {
                TimeInfo timeInfo = data as TimeInfo;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, timeInfo.makeSearchInforms());
                    this.lagCompensation = timeInfo.lagCompensation.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(timeInfo);
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
            if (data is TimeInfo)
            {
                // TimeInfo timeInfo = data as TimeInfo;
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
            if (wrapProperty.p is TimeInfo)
            {
                switch ((TimeInfo.Property)wrapProperty.n)
                {
                    case TimeInfo.Property.timePerTurn:
                        break;
                    case TimeInfo.Property.totalTime:
                        break;
                    case TimeInfo.Property.overTimePerTurn:
                        break;
                    case TimeInfo.Property.lagCompensation:
                        this.lagCompensation = (System.Single)wrapProperty.getValue();
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

        #region change timePerTurnType

        public void requestChangeTimePerTurnType(uint userId, int newTimePerTurnType)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdTimeInfoChangeTimePerTurnType(this.netId, userId, newTimePerTurnType);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeTimePerTurnType(uint userId, int newTimePerTurnType)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeTimePerTurnType(userId, newTimePerTurnType);
            }
            else
            {
                Debug.LogError("serverData null");
            }
        }

        #endregion

        #region change totalTimeType

        public void requestChangeTotalTimeType(uint userId, int newTotalTimeType)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdTimeInfoChangeTotalTimeType(this.netId, userId, newTotalTimeType);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeTotalTimeType(uint userId, int newTotalTimeType)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeTotalTimeType(userId, newTotalTimeType);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region change overTimePerTurnType

        public void requestChangeOverTimePerTurnType(uint userId, int newOverTimePerTurnType)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdTimeInfoChangeOverTimePerTurnType(this.netId, userId, newOverTimePerTurnType);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeOverTimePerTurnType(uint userId, int newOverTimePerTurnType)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeOverTimePerTurnType(userId, newOverTimePerTurnType);
            }
            else
            {
                Debug.LogError("serverData null");
            }
        }


        #endregion

        #region change lagCompensation

        public void requestChangeLagCompensation(uint userId, float newLagCompensation)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdTimeInfoChangeLagCompensation(this.netId, userId, newLagCompensation);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeLagCompensation(uint userId, float newLagCompensation)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeLagCompensation(userId, newLagCompensation);
            }
            else
            {
                Debug.LogError("serverData null");
            }
        }

        #endregion

    }
}