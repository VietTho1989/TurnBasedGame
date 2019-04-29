using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace GameManager.Match.Lobby
{
    public class StateStartIdentity : DataIdentity
    {

        #region SyncVar

        #region time

        [SyncVar(hook = "onChangeTime")]
        public System.Single time;

        public void onChangeTime(System.Single newTime)
        {
            this.time = newTime;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.time.v = newTime;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region duration

        [SyncVar(hook = "onChangeDuration")]
        public System.Single duration;

        public void onChangeDuration(System.Single newDuration)
        {
            this.duration = newDuration;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.duration.v = newDuration;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<StateStart> netData = new NetData<StateStart>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeTime(this.time);
                this.onChangeDuration(this.duration);
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
                ret += GetDataSize(this.time);
                ret += GetDataSize(this.duration);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is StateStart)
            {
                StateStart stateStart = data as StateStart;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, stateStart.makeSearchInforms());
                    this.time = stateStart.time.v;
                    this.duration = stateStart.duration.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(stateStart);
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
            if (data is StateStart)
            {
                // StateStart stateStart = data as StateStart;
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
            if (wrapProperty.p is StateStart)
            {
                switch ((StateStart.Property)wrapProperty.n)
                {
                    case StateStart.Property.time:
                        this.time = (System.Single)wrapProperty.getValue();
                        break;
                    case StateStart.Property.duration:
                        this.duration = (System.Single)wrapProperty.getValue();
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

    }
}