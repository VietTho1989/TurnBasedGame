using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Khet
{
    public class KhetAIIdentity : DataIdentity
    {

        #region SyncVar

        #region infinite

        [SyncVar(hook = "onChangeInfinite")]
        public System.Boolean infinite;

        public void onChangeInfinite(System.Boolean newInfinite)
        {
            this.infinite = newInfinite;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.infinite.v = newInfinite;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region moveTime

        [SyncVar(hook = "onChangeMoveTime")]
        public System.Int32 moveTime;

        public void onChangeMoveTime(System.Int32 newMoveTime)
        {
            this.moveTime = newMoveTime;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.moveTime.v = newMoveTime;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region depth

        [SyncVar(hook = "onChangeDepth")]
        public System.Int32 depth;

        public void onChangeDepth(System.Int32 newDepth)
        {
            this.depth = newDepth;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.depth.v = newDepth;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region pickBestMove

        [SyncVar(hook = "onChangePickBestMove")]
        public System.Int32 pickBestMove;

        public void onChangePickBestMove(System.Int32 newPickBestMove)
        {
            this.pickBestMove = newPickBestMove;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.pickBestMove.v = newPickBestMove;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<KhetAI> netData = new NetData<KhetAI>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeInfinite(this.infinite);
                this.onChangeMoveTime(this.moveTime);
                this.onChangeDepth(this.depth);
                this.onChangePickBestMove(this.pickBestMove);
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
                ret += GetDataSize(this.infinite);
                ret += GetDataSize(this.moveTime);
                ret += GetDataSize(this.depth);
                ret += GetDataSize(this.pickBestMove);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is KhetAI)
            {
                KhetAI khetAI = data as KhetAI;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, khetAI.makeSearchInforms());
                    this.infinite = khetAI.infinite.v;
                    this.moveTime = khetAI.moveTime.v;
                    this.depth = khetAI.depth.v;
                    this.pickBestMove = khetAI.pickBestMove.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(khetAI);
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
            if (data is KhetAI)
            {
                // KhetAI khetAI = data as KhetAI;
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
            if (wrapProperty.p is KhetAI)
            {
                switch ((KhetAI.Property)wrapProperty.n)
                {
                    case KhetAI.Property.infinite:
                        this.infinite = (System.Boolean)wrapProperty.getValue();
                        break;
                    case KhetAI.Property.moveTime:
                        this.moveTime = (System.Int32)wrapProperty.getValue();
                        break;
                    case KhetAI.Property.depth:
                        this.depth = (System.Int32)wrapProperty.getValue();
                        break;
                    case KhetAI.Property.pickBestMove:
                        this.pickBestMove = (System.Int32)wrapProperty.getValue();
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

        #region infinite

        public void requestChangeInfinite(uint userId, bool newInfinite)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdKhetAIChangeInfinite(this.netId, userId, newInfinite);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeInfinite(uint userId, bool newInfinite)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeInfinite(userId, newInfinite);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region moveTime

        public void requestChangeMoveTime(uint userId, int newMoveTime)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdKhetAIChangeMoveTime(this.netId, userId, newMoveTime);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeMoveTime(uint userId, int newMoveTime)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeMoveTime(userId, newMoveTime);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region depth

        public void requestChangeDepth(uint userId, int newDepth)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdKhetAIChangeDepth(this.netId, userId, newDepth);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeDepth(uint userId, int newDepth)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeDepth(userId, newDepth);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region pickBestMove

        public void requestChangePickBestMove(uint userId, int newPickBestMove)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdKhetAIChangePickBestMove(this.netId, userId, newPickBestMove);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changePickBestMove(uint userId, int newPickBestMove)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changePickBestMove(userId, newPickBestMove);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}