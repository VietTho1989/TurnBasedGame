using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace GameManager.Match
{
    public class ContestManagerIdentity : DataIdentity
    {

        #region SyncVar

        #region index

        [SyncVar(hook = "onChangeIndex")]
        public System.Int32 index;

        public void onChangeIndex(System.Int32 newIndex)
        {
            this.index = newIndex;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.index.v = newIndex;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<ContestManager> netData = new NetData<ContestManager>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeIndex(this.index);
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
                ret += GetDataSize(this.index);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is ContestManager)
            {
                ContestManager contestManager = data as ContestManager;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, contestManager.makeSearchInforms());
                    this.index = contestManager.index.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        // find room
                        Room room = null;
                        {
                            if (contestManager.getDataParent() is Room)
                            {
                                room = contestManager.getDataParent() as Room;
                            }
                            else
                            {
                                Debug.LogError("why parent not room: " + this);
                            }
                        }
                        if (room != null)
                        {
                            observer.checkChange = new OnlyRoomPlayerObserver(observer);
                            observer.setCheckChangeData(room);
                        }
                        else
                        {
                            Debug.LogError("room null: " + this);
                            observer.checkChange = new FollowParentObserver(observer);
                            observer.setCheckChangeData(contestManager);
                        }
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
            if (data is ContestManager)
            {
                // ContestManager contestManager = data as ContestManager;
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
            if (wrapProperty.p is ContestManager)
            {
                switch ((ContestManager.Property)wrapProperty.n)
                {
                    case ContestManager.Property.index:
                        this.index = (System.Int32)wrapProperty.getValue();
                        break;
                    case ContestManager.Property.state:
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

    }
}