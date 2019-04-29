using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace TimeControl.Normal
{
    public class TotalTimeInfoLimitIdentity : DataIdentity
    {

        #region SyncVar

        #region totalTime

        [SyncVar(hook = "onChangeTotalTime")]
        public System.Single totalTime;

        public void onChangeTotalTime(System.Single newTotalTime)
        {
            this.totalTime = newTotalTime;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.totalTime.v = newTotalTime;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<TotalTimeInfo.Limit> netData = new NetData<TotalTimeInfo.Limit>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeTotalTime(this.totalTime);
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
                ret += GetDataSize(this.totalTime);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is TotalTimeInfo.Limit)
            {
                TotalTimeInfo.Limit limit = data as TotalTimeInfo.Limit;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, limit.makeSearchInforms());
                    this.totalTime = limit.totalTime.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(limit);
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
            if (data is TotalTimeInfo.Limit)
            {
                // Limit limit = data as Limit;
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
            if (wrapProperty.p is TotalTimeInfo.Limit)
            {
                switch ((TotalTimeInfo.Limit.Property)wrapProperty.n)
                {
                    case TotalTimeInfo.Limit.Property.totalTime:
                        this.totalTime = (System.Single)wrapProperty.getValue();
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

        #region Change TotalTime

        public void requestChangeTotalTime(uint userId, float newTotalTime)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdTotalTimeInfoLimitChangeTotalTime(this.netId, userId, newTotalTime);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeTotalTime(uint userId, float newTotalTime)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeTotalTime(userId, newTotalTime);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}