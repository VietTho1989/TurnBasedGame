using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class SwapRequestIdentity : DataIdentity
    {

        #region SyncVar

        #region teamIndex

        [SyncVar(hook = "onChangeTeamIndex")]
        public System.Int32 teamIndex;

        public void onChangeTeamIndex(System.Int32 newTeamIndex)
        {
            this.teamIndex = newTeamIndex;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.teamIndex.v = newTeamIndex;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

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

        #endregion

        #region NetData

        private NetData<SwapRequest> netData = new NetData<SwapRequest>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeTeamIndex(this.teamIndex);
                this.onChangePlayerIndex(this.playerIndex);
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
                ret += GetDataSize(this.teamIndex);
                ret += GetDataSize(this.playerIndex);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is SwapRequest)
            {
                SwapRequest swapRequest = data as SwapRequest;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, swapRequest.makeSearchInforms());
                    this.teamIndex = swapRequest.teamIndex.v;
                    this.playerIndex = swapRequest.playerIndex.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(swapRequest);
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
            if (data is SwapRequest)
            {
                // SwapRequest swapRequest = data as SwapRequest;
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
            if (wrapProperty.p is SwapRequest)
            {
                switch ((SwapRequest.Property)wrapProperty.n)
                {
                    case SwapRequest.Property.state:
                        break;
                    case SwapRequest.Property.teamIndex:
                        this.teamIndex = (System.Int32)wrapProperty.getValue();
                        break;
                    case SwapRequest.Property.playerIndex:
                        this.playerIndex = (System.Int32)wrapProperty.getValue();
                        break;
                    case SwapRequest.Property.inform:
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