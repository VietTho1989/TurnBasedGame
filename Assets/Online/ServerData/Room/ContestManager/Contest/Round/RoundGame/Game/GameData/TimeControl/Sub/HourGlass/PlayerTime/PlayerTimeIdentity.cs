using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace TimeControl.HourGlass
{
    public class PlayerTimeIdentity : DataIdentity
    {

        #region SyncVar

        #region playerIndex

        [SyncVar(hook = "onChangePlayerIndex")]
        public System.Int32 playerIndex;

        public void onChangePlayerIndex(System.Int32 newPlayerIndex)
        {
            this.playerIndex = newPlayerIndex;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.playerIndex.v = newPlayerIndex;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region serverTime

        [SyncVar(hook = "onChangeServerTime")]
        public System.Single serverTime;

        public void onChangeServerTime(System.Single newServerTime)
        {
            this.serverTime = newServerTime;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.serverTime.v = newServerTime;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region clientTime

        [SyncVar(hook = "onChangeClientTime")]
        public System.Single clientTime;

        public void onChangeClientTime(System.Single newClientTime)
        {
            this.clientTime = newClientTime;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.clientTime.v = newClientTime;
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

        private NetData<PlayerTime> netData = new NetData<PlayerTime>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangePlayerIndex(this.playerIndex);
                this.onChangeServerTime(this.serverTime);
                this.onChangeClientTime(this.clientTime);
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
                ret += GetDataSize(this.playerIndex);
                ret += GetDataSize(this.serverTime);
                ret += GetDataSize(this.clientTime);
                ret += GetDataSize(this.lagCompensation);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is PlayerTime)
            {
                PlayerTime playerTime = data as PlayerTime;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, playerTime.makeSearchInforms());
                    this.playerIndex = playerTime.playerIndex.v;
                    this.serverTime = playerTime.serverTime.v;
                    this.clientTime = playerTime.clientTime.v;
                    this.lagCompensation = playerTime.lagCompensation.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(playerTime);
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
            if (data is PlayerTime)
            {
                // PlayerTime playerTime = data as PlayerTime;
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
            if (wrapProperty.p is PlayerTime)
            {
                switch ((PlayerTime.Property)wrapProperty.n)
                {
                    case PlayerTime.Property.playerIndex:
                        this.playerIndex = (System.Int32)wrapProperty.getValue();
                        break;
                    case PlayerTime.Property.serverTime:
                        this.serverTime = (System.Single)wrapProperty.getValue();
                        break;
                    case PlayerTime.Property.clientTime:
                        this.clientTime = (System.Single)wrapProperty.getValue();
                        break;
                    case PlayerTime.Property.lagCompensation:
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

    }
}