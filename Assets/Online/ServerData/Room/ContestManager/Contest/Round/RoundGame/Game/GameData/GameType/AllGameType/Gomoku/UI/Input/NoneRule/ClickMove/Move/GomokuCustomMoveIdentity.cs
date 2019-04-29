using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Gomoku.NoneRule
{
    public class GomokuCustomMoveIdentity : DataIdentity
    {

        #region SyncVar

        #region from

        [SyncVar(hook = "onChangeFrom")]
        public System.Int32 from;

        public void onChangeFrom(System.Int32 newFrom)
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
        public System.Int32 dest;

        public void onChangeDest(System.Int32 newDest)
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

        private NetData<GomokuCustomMove> netData = new NetData<GomokuCustomMove>();

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
            if (data is GomokuCustomMove)
            {
                GomokuCustomMove gomokuCustomMove = data as GomokuCustomMove;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, gomokuCustomMove.makeSearchInforms());
                    this.from = gomokuCustomMove.from.v;
                    this.dest = gomokuCustomMove.dest.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(gomokuCustomMove);
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
            if (data is GomokuCustomMove)
            {
                // GomokuCustomMove gomokuCustomMove = data as GomokuCustomMove;
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
            if (wrapProperty.p is GomokuCustomMove)
            {
                switch ((GomokuCustomMove.Property)wrapProperty.n)
                {
                    case GomokuCustomMove.Property.from:
                        this.from = (System.Int32)wrapProperty.getValue();
                        break;
                    case GomokuCustomMove.Property.dest:
                        this.dest = (System.Int32)wrapProperty.getValue();
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