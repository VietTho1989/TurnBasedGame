using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace GameManager.Match
{
    public class NormalRoundFactoryIdentity : DataIdentity
    {

        #region SyncVar

        #region isChangeSideBetweenRound

        [SyncVar(hook = "onChangeIsChangeSideBetweenRound")]
        public System.Boolean isChangeSideBetweenRound;

        public void onChangeIsChangeSideBetweenRound(System.Boolean newIsChangeSideBetweenRound)
        {
            this.isChangeSideBetweenRound = newIsChangeSideBetweenRound;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isChangeSideBetweenRound.v = newIsChangeSideBetweenRound;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region isSwitchPlayer

        [SyncVar(hook = "onChangeIsSwitchPlayer")]
        public System.Boolean isSwitchPlayer;

        public void onChangeIsSwitchPlayer(System.Boolean newIsSwitchPlayer)
        {
            this.isSwitchPlayer = newIsSwitchPlayer;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isSwitchPlayer.v = newIsSwitchPlayer;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region isDifferentInTeam

        [SyncVar(hook = "onChangeIsDifferentInTeam")]
        public System.Boolean isDifferentInTeam;

        public void onChangeIsDifferentInTeam(System.Boolean newIsDifferentInTeam)
        {
            this.isDifferentInTeam = newIsDifferentInTeam;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isDifferentInTeam.v = newIsDifferentInTeam;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<NormalRoundFactory> netData = new NetData<NormalRoundFactory>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeIsChangeSideBetweenRound(this.isChangeSideBetweenRound);
                this.onChangeIsSwitchPlayer(this.isSwitchPlayer);
                this.onChangeIsDifferentInTeam(this.isDifferentInTeam);
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
                ret += GetDataSize(this.isChangeSideBetweenRound);
                ret += GetDataSize(this.isSwitchPlayer);
                ret += GetDataSize(this.isDifferentInTeam);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is NormalRoundFactory)
            {
                NormalRoundFactory normalRoundFactory = data as NormalRoundFactory;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, normalRoundFactory.makeSearchInforms());
                    this.isChangeSideBetweenRound = normalRoundFactory.isChangeSideBetweenRound.v;
                    this.isSwitchPlayer = normalRoundFactory.isSwitchPlayer.v;
                    this.isDifferentInTeam = normalRoundFactory.isDifferentInTeam.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(normalRoundFactory);
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
            if (data is NormalRoundFactory)
            {
                // NormalRoundFactory normalRoundFactory = data as NormalRoundFactory;
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
            if (wrapProperty.p is NormalRoundFactory)
            {
                switch ((NormalRoundFactory.Property)wrapProperty.n)
                {
                    case NormalRoundFactory.Property.gameFactory:
                        break;
                    case NormalRoundFactory.Property.isChangeSideBetweenRound:
                        this.isChangeSideBetweenRound = (System.Boolean)wrapProperty.getValue();
                        break;
                    case NormalRoundFactory.Property.isSwitchPlayer:
                        this.isSwitchPlayer = (System.Boolean)wrapProperty.getValue();
                        break;
                    case NormalRoundFactory.Property.isDifferentInTeam:
                        this.isDifferentInTeam = (System.Boolean)wrapProperty.getValue();
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

        #region isChangeSideBetweenRound

        public void requestChangeIsChangeSideBetweenRound(uint userId, bool newIsChangeSideBetweenRound)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdNormalRoundFactoryChangeIsChangeSideBetweenRound(this.netId, userId, newIsChangeSideBetweenRound);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeIsChangeSideBetweenRound(uint userId, bool newIsChangeSideBetweenRound)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeIsChangeSideBetweenRound(userId, newIsChangeSideBetweenRound);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region isSwitchPlayer

        public void requestChangeIsSwitchPlayer(uint userId, bool newIsSwitchPlayer)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdNormalRoundFactoryChangeIsSwitchPlayer(this.netId, userId, newIsSwitchPlayer);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeIsSwitchPlayer(uint userId, bool newIsSwitchPlayer)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeIsSwitchPlayer(userId, newIsSwitchPlayer);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region isDifferentInTeam

        public void requestChangeIsDifferentInTeam(uint userId, bool newIsDifferentInTeam)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdNormalRoundFactoryChangeIsDifferentInTeam(this.netId, userId, newIsDifferentInTeam);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeIsDifferentInTeam(uint userId, bool newIsDifferentInTeam)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeIsDifferentInTeam(userId, newIsDifferentInTeam);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region calculateScore

        public void requestChangeCalculateScoreType(uint userId, int newCalculateScoreType)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdNormalRoundFactoryChangeCalculateScoreType(this.netId, userId, newCalculateScoreType);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeCalculateScoreType(uint userId, int newCalculateScoreType)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeCalculateScoreType(userId, newCalculateScoreType);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}