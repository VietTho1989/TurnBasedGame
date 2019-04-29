using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Shogi
{
    public class ShogiAIIdentity : DataIdentity
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

        #region skillLevel

        [SyncVar(hook = "onChangeSkillLevel")]
        public System.Int32 skillLevel;

        public void onChangeSkillLevel(System.Int32 newSkillLevel)
        {
            this.skillLevel = newSkillLevel;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.skillLevel.v = newSkillLevel;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region mr

        [SyncVar(hook = "onChangeMr")]
        public System.Int32 mr;

        public void onChangeMr(System.Int32 newMr)
        {
            this.mr = newMr;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.mr.v = newMr;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region duration

        [SyncVar(hook = "onChangeDuration")]
        public System.Int32 duration;

        public void onChangeDuration(System.Int32 newDuration)
        {
            this.duration = newDuration;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.duration.v = newDuration;
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

        #endregion

        #region NetData

        private NetData<ShogiAI> netData = new NetData<ShogiAI>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeDepth(this.depth);
                this.onChangeSkillLevel(this.skillLevel);
                this.onChangeMr(this.mr);
                this.onChangeDuration(this.duration);
                this.onChangeUseBook(this.useBook);
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
                ret += GetDataSize(this.skillLevel);
                ret += GetDataSize(this.mr);
                ret += GetDataSize(this.duration);
                ret += GetDataSize(this.useBook);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is ShogiAI)
            {
                ShogiAI shogiAI = data as ShogiAI;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, shogiAI.makeSearchInforms());
                    this.depth = shogiAI.depth.v;
                    this.skillLevel = shogiAI.skillLevel.v;
                    this.mr = shogiAI.mr.v;
                    this.duration = shogiAI.duration.v;
                    this.useBook = shogiAI.useBook.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(shogiAI);
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
            if (data is ShogiAI)
            {
                // ShogiAI shogiAI = data as ShogiAI;
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
            if (wrapProperty.p is ShogiAI)
            {
                switch ((ShogiAI.Property)wrapProperty.n)
                {
                    case ShogiAI.Property.depth:
                        this.depth = (System.Int32)wrapProperty.getValue();
                        break;
                    case ShogiAI.Property.skillLevel:
                        this.skillLevel = (System.Int32)wrapProperty.getValue();
                        break;
                    case ShogiAI.Property.mr:
                        this.mr = (System.Int32)wrapProperty.getValue();
                        break;
                    case ShogiAI.Property.duration:
                        this.duration = (System.Int32)wrapProperty.getValue();
                        break;
                    case ShogiAI.Property.useBook:
                        this.useBook = (System.Boolean)wrapProperty.getValue();
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

        #region depth

        public void requestChangeDepth(uint userId, int newDepth)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdShogiAIChangeDepth(this.netId, userId, newDepth);
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

        #region skillLevel

        public void requestChangeSkillLevel(uint userId, int newSkillLevel)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdShogiAIChangeSkillLevel(this.netId, userId, newSkillLevel);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeSkillLevel(uint userId, int newSkillLevel)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeSkillLevel(userId, newSkillLevel);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region mr

        public void requestChangeMr(uint userId, int newMr)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdShogiAIChangeMr(this.netId, userId, newMr);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeMr(uint userId, int newMr)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeMr(userId, newMr);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region duration

        public void requestChangeDuration(uint userId, int newDuration)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdShogiAIChangeDuration(this.netId, userId, newDuration);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeDuration(uint userId, int newDuration)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeDuration(userId, newDuration);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region useBook

        public void requestChangeUseBook(uint userId, bool newUseBook)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdShogiAIChangeUseBook(this.netId, userId, newUseBook);
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

    }
}