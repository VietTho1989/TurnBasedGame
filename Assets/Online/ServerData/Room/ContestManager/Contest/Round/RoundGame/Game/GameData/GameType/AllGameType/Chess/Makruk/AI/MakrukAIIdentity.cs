using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Makruk
{
    public class MakrukAIIdentity : DataIdentity
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

        #region duration

        [SyncVar(hook = "onChangeDuration")]
        public System.Int64 duration;

        public void onChangeDuration(System.Int64 newDuration)
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

        #endregion

        #region NetData

        private NetData<MakrukAI> netData = new NetData<MakrukAI>();

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
                this.onChangeDuration(this.duration);
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
                ret += GetDataSize(this.duration);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is MakrukAI)
            {
                MakrukAI makrukAI = data as MakrukAI;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, makrukAI.makeSearchInforms());
                    this.depth = makrukAI.depth.v;
                    this.skillLevel = makrukAI.skillLevel.v;
                    this.duration = makrukAI.duration.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(makrukAI);
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
            if (data is MakrukAI)
            {
                // MakrukAI makrukAI = data as MakrukAI;
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
            if (wrapProperty.p is MakrukAI)
            {
                switch ((MakrukAI.Property)wrapProperty.n)
                {
                    case MakrukAI.Property.depth:
                        this.depth = (System.Int32)wrapProperty.getValue();
                        break;
                    case MakrukAI.Property.skillLevel:
                        this.skillLevel = (System.Int32)wrapProperty.getValue();
                        break;
                    case MakrukAI.Property.duration:
                        this.duration = (System.Int64)wrapProperty.getValue();
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

        #region Change Depth

        public void requestChangeDepth(uint userId, int newDepth)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdMakrukAIChangeDepth(this.netId, userId, newDepth);
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

        #region Change SkillLevel

        public void requestChangeSkillLevel(uint userId, int newSkillLevel)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdMakrukAIChangeSkillLevel(this.netId, userId, newSkillLevel);
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

        #region Change Duration

        public void requestChangeDuration(uint userId, long newDuration)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdMakrukAIChangeDuration(this.netId, userId, newDuration);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeDuration(uint userId, long newDuration)
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

    }
}