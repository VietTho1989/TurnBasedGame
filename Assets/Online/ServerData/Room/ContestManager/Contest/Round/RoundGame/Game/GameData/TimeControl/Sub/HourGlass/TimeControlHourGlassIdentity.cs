using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace TimeControl.HourGlass
{
    public class TimeControlHourGlassIdentity : DataIdentity
    {

        #region SyncVar

        #region initTime

        [SyncVar(hook = "onChangeInitTime")]
        public System.Single initTime;

        public void onChangeInitTime(System.Single newInitTime)
        {
            this.initTime = newInitTime;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.initTime.v = newInitTime;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

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

        private NetData<TimeControlHourGlass> netData = new NetData<TimeControlHourGlass>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeInitTime(this.initTime);
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
                ret += GetDataSize(this.initTime);
                ret += GetDataSize(this.lagCompensation);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is TimeControlHourGlass)
            {
                TimeControlHourGlass timeControlHourGlass = data as TimeControlHourGlass;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, timeControlHourGlass.makeSearchInforms());
                    this.initTime = timeControlHourGlass.initTime.v;
                    this.lagCompensation = timeControlHourGlass.lagCompensation.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(timeControlHourGlass);
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
            if (data is TimeControlHourGlass)
            {
                // TimeControlHourGlass timeControlHourGlass = data as TimeControlHourGlass;
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
            if (wrapProperty.p is TimeControlHourGlass)
            {
                switch ((TimeControlHourGlass.Property)wrapProperty.n)
                {
                    case TimeControlHourGlass.Property.initTime:
                        this.initTime = (System.Single)wrapProperty.getValue();
                        break;
                    case TimeControlHourGlass.Property.lagCompensation:
                        this.lagCompensation = (System.Single)wrapProperty.getValue();
                        break;
                    case TimeControlHourGlass.Property.playerTimes:
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

        #region initTime

        public void requestChangeInitTime(uint userId, float newInitTime)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdTimeControlHourGlassChangeInitTime(this.netId, userId, newInitTime);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeInitTime(uint userId, float newInitTime)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeInitTime(userId, newInitTime);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region lagCompensation

        public void requestChangeLagCompensation(uint userId, float newLagCompensation)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdTimeControlHourGlassChangeLagCompensation(this.netId, userId, newLagCompensation);
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
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}