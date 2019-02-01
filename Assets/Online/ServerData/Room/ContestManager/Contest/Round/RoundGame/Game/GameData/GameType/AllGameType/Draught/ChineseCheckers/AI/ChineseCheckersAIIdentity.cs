using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace ChineseCheckers
{
    public class ChineseCheckersAIIdentity : DataIdentity
    {

        #region SyncVar

        #region type

        [SyncVar(hook = "onChangeType")]
        public ChineseCheckersAI.Type type;

        public void onChangeType(ChineseCheckersAI.Type newType)
        {
            this.type = newType;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.type.v = newType;
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

        #region time

        [SyncVar(hook = "onChangeTime")]
        public System.Int32 time;

        public void onChangeTime(System.Int32 newTime)
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

        #region node

        [SyncVar(hook = "onChangeNode")]
        public System.Int32 node;

        public void onChangeNode(System.Int32 newNode)
        {
            this.node = newNode;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.node.v = newNode;
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

        private NetData<ChineseCheckersAI> netData = new NetData<ChineseCheckersAI>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeType(this.type);
                this.onChangeDepth(this.depth);
                this.onChangeTime(this.time);
                this.onChangeNode(this.node);
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
                ret += GetDataSize(this.type);
                ret += GetDataSize(this.depth);
                ret += GetDataSize(this.time);
                ret += GetDataSize(this.node);
                ret += GetDataSize(this.pickBestMove);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is ChineseCheckersAI)
            {
                ChineseCheckersAI chineseCheckersAI = data as ChineseCheckersAI;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, chineseCheckersAI.makeSearchInforms());
                    this.type = chineseCheckersAI.type.v;
                    this.depth = chineseCheckersAI.depth.v;
                    this.time = chineseCheckersAI.time.v;
                    this.node = chineseCheckersAI.node.v;
                    this.pickBestMove = chineseCheckersAI.pickBestMove.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(chineseCheckersAI);
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
            if (data is ChineseCheckersAI)
            {
                // ChineseCheckersAI chineseCheckersAI = data as ChineseCheckersAI;
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
            if (wrapProperty.p is ChineseCheckersAI)
            {
                switch ((ChineseCheckersAI.Property)wrapProperty.n)
                {
                    case ChineseCheckersAI.Property.type:
                        this.type = (ChineseCheckersAI.Type)wrapProperty.getValue();
                        break;
                    case ChineseCheckersAI.Property.depth:
                        this.depth = (System.Int32)wrapProperty.getValue();
                        break;
                    case ChineseCheckersAI.Property.time:
                        this.time = (System.Int32)wrapProperty.getValue();
                        break;
                    case ChineseCheckersAI.Property.node:
                        this.node = (System.Int32)wrapProperty.getValue();
                        break;
                    case ChineseCheckersAI.Property.pickBestMove:
                        this.pickBestMove = (System.Int32)wrapProperty.getValue();
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

        #region type

        public void requestChangeType(uint userId, ChineseCheckersAI.Type newType)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdChineseCheckersAIChangeType(this.netId, userId, newType);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeType(uint userId, ChineseCheckersAI.Type newType)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeType(userId, newType);
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
                clientConnect.CmdChineseCheckersAIChangeDepth(this.netId, userId, newDepth);
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

        #region time

        public void requestChangeTime(uint userId, int newTime)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdChineseCheckersAIChangeTime(this.netId, userId, newTime);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeTime(uint userId, int newTime)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeTime(userId, newTime);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region node

        public void requestChangeNode(uint userId, int newNode)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdChineseCheckersAIChangeNode(this.netId, userId, newNode);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeNode(uint userId, int newNode)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeNode(userId, newNode);
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
                clientConnect.CmdChineseCheckersAIChangePickBestMove(this.netId, userId, newPickBestMove);
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