using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Reversi.NoneRule
{
    public class ReversiCustomMoveIdentity : DataIdentity
    {

        #region SyncVar

        #region from

        [SyncVar(hook = "onChangeFrom")]
        public sbyte from;

        public void onChangeFrom(sbyte newFrom)
        {
            this.from = newFrom;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.from.v = newFrom;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region dest

        [SyncVar(hook = "onChangeDest")]
        public sbyte dest;

        public void onChangeDest(sbyte newDest)
        {
            this.dest = newDest;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.dest.v = newDest;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<ReversiCustomMove> netData = new NetData<ReversiCustomMove>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeFrom(this.from);
                this.onChangeDest(this.dest);
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
                ret += GetDataSize(this.from);
                ret += GetDataSize(this.dest);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is ReversiCustomMove)
            {
                ReversiCustomMove reversiCustomMove = data as ReversiCustomMove;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, reversiCustomMove.makeSearchInforms());
                    this.from = reversiCustomMove.from.v;
                    this.dest = reversiCustomMove.dest.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(reversiCustomMove);
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
            if (data is ReversiCustomMove)
            {
                // ReversiCustomMove reversiCustomMove = data as ReversiCustomMove;
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
            if (wrapProperty.p is ReversiCustomMove)
            {
                switch ((ReversiCustomMove.Property)wrapProperty.n)
                {
                    case ReversiCustomMove.Property.from:
                        this.from = (sbyte)wrapProperty.getValue();
                        break;
                    case ReversiCustomMove.Property.dest:
                        this.dest = (sbyte)wrapProperty.getValue();
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