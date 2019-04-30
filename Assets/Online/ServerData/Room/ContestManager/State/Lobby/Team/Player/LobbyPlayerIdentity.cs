using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace GameManager.Match
{
    public class LobbyPlayerIdentity : DataIdentity
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

        #region isReady

        [SyncVar(hook = "onChangeIsReady")]
        public System.Boolean isReady;

        public void onChangeIsReady(System.Boolean newIsReady)
        {
            this.isReady = newIsReady;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isReady.v = newIsReady;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<LobbyPlayer> netData = new NetData<LobbyPlayer>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangePlayerIndex(this.playerIndex);
                this.onChangeIsReady(this.isReady);
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
                ret += GetDataSize(this.isReady);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is LobbyPlayer)
            {
                LobbyPlayer lobbyPlayer = data as LobbyPlayer;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, lobbyPlayer.makeSearchInforms());
                    this.playerIndex = lobbyPlayer.playerIndex.v;
                    this.isReady = lobbyPlayer.isReady.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(lobbyPlayer);
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
            if (data is LobbyPlayer)
            {
                // LobbyPlayer lobbyPlayer = data as LobbyPlayer;
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
            if (wrapProperty.p is LobbyPlayer)
            {
                switch ((LobbyPlayer.Property)wrapProperty.n)
                {
                    case LobbyPlayer.Property.playerIndex:
                        this.playerIndex = (System.Int32)wrapProperty.getValue();
                        break;
                    case LobbyPlayer.Property.inform:
                        break;
                    case LobbyPlayer.Property.isReady:
                        this.isReady = (System.Boolean)wrapProperty.getValue();
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

        #region isReady

        public void requestSetReady(uint userId, bool newReady)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdLobbyPlayerSetReady(this.netId, userId, newReady);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void setReady(uint userId, bool newReady)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.setReady(userId, newReady);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region adminChangeHuman

        public void requestAdminChangeHuman(uint userId, uint humanId)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdLobbyPlayerAdminChangeHuman(this.netId, userId, humanId);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void adminChangeHuman(uint userId, uint humanId)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.adminChangeHuman(userId, humanId);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region admin change empty

        public void requestAdminChangeEmpty(uint userId)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdLobbyPlayerAdminChangeEmpty(this.netId, userId);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void adminChangeEmpty(uint userId)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.adminChangeEmpty(userId);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region admin change computer

        public void requestAdminChangeComputer(uint userId, Computer computer)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                byte[] computerBytes = Data.MakeBinary(computer);
                if (computerBytes != null)
                {
                    clientConnect.CmdLobbyPlayerAdminChangeComputer(this.netId, userId, computerBytes);
                }
                else
                {
                    Debug.LogError("computerBytes null");
                }
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void adminChangeComputer(uint userId, Computer computer)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.adminChangeComputer(userId, computer);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region normalSet

        public void requestNormalSet(uint userId)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdLobbyPlayerNormalSet(this.netId, userId);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void normalSet(uint userId)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.normalSet(userId);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region normalEmpty

        public void requestNormalEmpty(uint userId)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdLobbyPlayerIdentityNormalEmpty(this.netId, userId);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void normalEmpty(uint userId)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.normalEmpty(userId);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}