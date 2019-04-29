using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace GameManager.Match
{
    public class CalculateScoreWinLoseDrawIdentity : DataIdentity
    {

        #region SyncVar

        #region winScore

        [SyncVar(hook = "onChangeWinScore")]
        public System.Single winScore;

        public void onChangeWinScore(System.Single newWinScore)
        {
            this.winScore = newWinScore;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.winScore.v = newWinScore;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region loseScore

        [SyncVar(hook = "onChangeLoseScore")]
        public System.Single loseScore;

        public void onChangeLoseScore(System.Single newLoseScore)
        {
            this.loseScore = newLoseScore;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.loseScore.v = newLoseScore;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region drawScore

        [SyncVar(hook = "onChangeDrawScore")]
        public System.Single drawScore;

        public void onChangeDrawScore(System.Single newDrawScore)
        {
            this.drawScore = newDrawScore;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.drawScore.v = newDrawScore;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<CalculateScoreWinLoseDraw> netData = new NetData<CalculateScoreWinLoseDraw>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeWinScore(this.winScore);
                this.onChangeLoseScore(this.loseScore);
                this.onChangeDrawScore(this.drawScore);
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
                ret += GetDataSize(this.winScore);
                ret += GetDataSize(this.loseScore);
                ret += GetDataSize(this.drawScore);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is CalculateScoreWinLoseDraw)
            {
                CalculateScoreWinLoseDraw calculateScoreWinLoseDraw = data as CalculateScoreWinLoseDraw;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, calculateScoreWinLoseDraw.makeSearchInforms());
                    this.winScore = calculateScoreWinLoseDraw.winScore.v;
                    this.loseScore = calculateScoreWinLoseDraw.loseScore.v;
                    this.drawScore = calculateScoreWinLoseDraw.drawScore.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(calculateScoreWinLoseDraw);
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
            if (data is CalculateScoreWinLoseDraw)
            {
                // CalculateScoreWinLoseDraw calculateScoreWinLoseDraw = data as CalculateScoreWinLoseDraw;
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
            if (wrapProperty.p is CalculateScoreWinLoseDraw)
            {
                switch ((CalculateScoreWinLoseDraw.Property)wrapProperty.n)
                {
                    case CalculateScoreWinLoseDraw.Property.winScore:
                        this.winScore = (System.Single)wrapProperty.getValue();
                        break;
                    case CalculateScoreWinLoseDraw.Property.loseScore:
                        this.loseScore = (System.Single)wrapProperty.getValue();
                        break;
                    case CalculateScoreWinLoseDraw.Property.drawScore:
                        this.drawScore = (System.Single)wrapProperty.getValue();
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

        #region winScore

        public void requestChangeWinScore(uint userId, float newWinScore)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdCalculateScoreWinLoseDrawChangeWinScore(this.netId, userId, newWinScore);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeWinScore(uint userId, float newWinScore)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeWinScore(userId, newWinScore);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region loseScore

        public void requestChangeLoseScore(uint userId, float newLoseScore)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdCalculateScoreWinLoseDrawChangeLoseScore(this.netId, userId, newLoseScore);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeLoseScore(uint userId, float newLoseScore)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeLoseScore(userId, newLoseScore);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region drawScore

        public void requestChangeDrawScore(uint userId, float newDrawScore)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdCalculateScoreWinLoseDrawChangeDrawScore(this.netId, userId, newDrawScore);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeDrawScore(uint userId, float newDrawScore)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeDrawScore(userId, newDrawScore);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}