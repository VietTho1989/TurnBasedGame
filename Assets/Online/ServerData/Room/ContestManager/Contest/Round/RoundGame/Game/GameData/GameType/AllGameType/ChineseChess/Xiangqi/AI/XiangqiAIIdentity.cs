using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Xiangqi
{
    public class XiangqiAIIdentity : DataIdentity
    {

        #region SyncVar

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

        #region lngLimitTime

        [SyncVar(hook = "onChangeThinkTime")]
        public System.Int32 thinkTime;

        public void onChangeThinkTime(System.Int32 newThinkTime)
        {
            this.thinkTime = newThinkTime;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.thinkTime.v = newThinkTime;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region useBook

        [SyncVar(hook = "onChangeUseBook")]
        public System.Boolean useBook;

        public void onChangeUseBook(System.Boolean newUseBook)
        {
            this.useBook = newUseBook;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.useBook.v = newUseBook;
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

        private NetData<XiangqiAI> netData = new NetData<XiangqiAI>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeDepth(this.depth);
                this.onChangeThinkTime(this.thinkTime);
                this.onChangeUseBook(this.useBook);
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
                ret += GetDataSize(this.depth);
                ret += GetDataSize(this.thinkTime);
                ret += GetDataSize(this.useBook);
                ret += GetDataSize(this.pickBestMove);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is XiangqiAI)
            {
                XiangqiAI xiangqiAI = data as XiangqiAI;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, xiangqiAI.makeSearchInforms());
                    this.depth = xiangqiAI.depth.v;
                    this.thinkTime = xiangqiAI.thinkTime.v;
                    this.useBook = xiangqiAI.useBook.v;
                    this.pickBestMove = xiangqiAI.pickBestMove.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(xiangqiAI);
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
            if (data is XiangqiAI)
            {
                // XiangqiAI xiangqiAI = data as XiangqiAI;
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
            if (wrapProperty.p is XiangqiAI)
            {
                switch ((XiangqiAI.Property)wrapProperty.n)
                {
                    case XiangqiAI.Property.depth:
                        this.depth = (System.Int32)wrapProperty.getValue();
                        break;
                    case XiangqiAI.Property.thinkTime:
                        this.thinkTime = (System.Int32)wrapProperty.getValue();
                        break;
                    case XiangqiAI.Property.useBook:
                        this.useBook = (System.Boolean)wrapProperty.getValue();
                        break;
                    case XiangqiAI.Property.pickBestMove:
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

        #region Depth

        public void requestChangeDepth(uint userId, int newDepth)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdXiangqiAIChangeDepth(this.netId, userId, newDepth);
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

        #region Change ThinkTime

        public void requestChangeThinkTime(uint userId, int newThinkTime)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdXiangqiAIChangeThinkTime(this.netId, userId, newThinkTime);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeThinkTime(uint userId, int newThinkTime)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeThinkTime(userId, newThinkTime);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region Change UseBook

        public void requestChangeUseBook(uint userId, bool newUseBook)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdXiangqiAIChangeUseBook(this.netId, userId, newUseBook);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeUseBook(uint userId, bool newUseBook)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeUseBook(userId, newUseBook);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region Change PickBestMove

        public void requestChangePickBestMove(uint userId, int newPickBestMove)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdXiangqiAIChangePickBestMove(this.netId, userId, newPickBestMove);
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