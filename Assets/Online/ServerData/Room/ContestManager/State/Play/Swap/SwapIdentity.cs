using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class SwapIdentity : DataIdentity
    {

        #region SyncVar

        #endregion

        #region NetData

        private NetData<Swap> netData = new NetData<Swap>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
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
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Swap)
            {
                Swap swap = data as Swap;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, swap.makeSearchInforms());
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(swap);
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
            if (data is Swap)
            {
                // Swap swap = data as Swap;
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
            if (wrapProperty.p is Swap)
            {
                switch ((Swap.Property)wrapProperty.n)
                {
                    case Swap.Property.swapRequests:
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

        #region change human

        public void requestChangeHuman(uint userId, int teamIndex, int playerIndex, uint newHumanId)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdSwapIdentityChangeHuman(this.netId, userId, teamIndex, playerIndex, newHumanId);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeHuman(uint userId, int teamIndex, int playerIndex, uint newHumanId)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeHuman(userId, teamIndex, playerIndex, newHumanId);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region change computer

        public void requestChangeComputer(uint userId, int teamIndex, int playerIndex, Computer newComputer)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                string strComputer = StringSerializationAPI.Serialize(typeof(Computer), newComputer);
                clientConnect.CmdSwapIdentityChangeComputer(this.netId, userId, teamIndex, playerIndex, strComputer);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeComputer(uint userId, int teamIndex, int playerIndex, Computer newComputer)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeComputer(userId, teamIndex, playerIndex, newComputer);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}