using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Janggi
{
    public class JanggiAIIdentity : DataIdentity
    {

        #region SyncVar

        #region maxVisitCount

        [SyncVar(hook = "onChangeMaxVisitCount")]
        public System.Int32 maxVisitCount;

        public void onChangeMaxVisitCount(System.Int32 newMaxVisitCount)
        {
            this.maxVisitCount = newMaxVisitCount;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.maxVisitCount.v = newMaxVisitCount;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<JanggiAI> netData = new NetData<JanggiAI>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeMaxVisitCount(this.maxVisitCount);
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
                ret += GetDataSize(this.maxVisitCount);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is JanggiAI)
            {
                JanggiAI janggiAI = data as JanggiAI;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, janggiAI.makeSearchInforms());
                    this.maxVisitCount = janggiAI.maxVisitCount.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(janggiAI);
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
            if (data is JanggiAI)
            {
                // JanggiAI janggiAI = data as JanggiAI;
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
            if (wrapProperty.p is JanggiAI)
            {
                switch ((JanggiAI.Property)wrapProperty.n)
                {
                    case JanggiAI.Property.maxVisitCount:
                        this.maxVisitCount = (System.Int32)wrapProperty.getValue();
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

        #region maxVisitCount

        public void requestChangeMaxVisitCount(uint userId, int newMaxVisitCount)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdJanggiAIChangeMaxVisitCount(this.netId, userId, newMaxVisitCount);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeMaxVisitCount(uint userId, int newMaxVisitCount)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeMaxVisitCount(userId, newMaxVisitCount);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}