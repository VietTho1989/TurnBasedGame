using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace RussianDraught.NoneRule
{
    public class RussianDraughtCustomMoveIdentity : DataIdentity
    {

        #region SyncVar

        #region fromSquare

        [SyncVar(hook = "onChangeFromSquare")]
        public System.Int32 fromSquare;

        public void onChangeFromSquare(System.Int32 newFromSquare)
        {
            this.fromSquare = newFromSquare;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.fromSquare.v = newFromSquare;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region destX

        [SyncVar(hook = "onChangeDestSquare")]
        public System.Int32 destSquare;

        public void onChangeDestSquare(System.Int32 newDestSquare)
        {
            this.destSquare = newDestSquare;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.destSquare.v = newDestSquare;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<RussianDraughtCustomMove> netData = new NetData<RussianDraughtCustomMove>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeFromSquare(this.fromSquare);
                this.onChangeDestSquare(this.destSquare);
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
                ret += GetDataSize(this.fromSquare);
                ret += GetDataSize(this.destSquare);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is RussianDraughtCustomMove)
            {
                RussianDraughtCustomMove russianDraughtCustomMove = data as RussianDraughtCustomMove;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, russianDraughtCustomMove.makeSearchInforms());
                    this.fromSquare = russianDraughtCustomMove.fromSquare.v;
                    this.destSquare = russianDraughtCustomMove.destSquare.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(russianDraughtCustomMove);
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
            if (data is RussianDraughtCustomMove)
            {
                // RussianDraughtCustomMove russianDraughtCustomMove = data as RussianDraughtCustomMove;
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
            if (wrapProperty.p is RussianDraughtCustomMove)
            {
                switch ((RussianDraughtCustomMove.Property)wrapProperty.n)
                {
                    case RussianDraughtCustomMove.Property.fromSquare:
                        this.fromSquare = (System.Int32)wrapProperty.getValue();
                        break;
                    case RussianDraughtCustomMove.Property.destSquare:
                        this.destSquare = (System.Int32)wrapProperty.getValue();
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