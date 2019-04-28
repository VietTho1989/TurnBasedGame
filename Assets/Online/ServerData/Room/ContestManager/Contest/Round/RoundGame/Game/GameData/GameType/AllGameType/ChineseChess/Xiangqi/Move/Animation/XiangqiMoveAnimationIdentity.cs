using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
    public class XiangqiMoveAnimationIdentity : DataIdentity
    {

        #region SyncVar

        #region move

        [SyncVar(hook = "onChangeMove")]
        public System.UInt32 move;

        public void onChangeMove(System.UInt32 newMove)
        {
            this.move = newMove;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.move.v = newMove;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region ucpcSquares

        public SyncListByte ucpcSquares = new SyncListByte();

        private void OnUcpcSquaresChanged(SyncListByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.ucpcSquares, this.ucpcSquares, op, index, MyByte.byteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region duration

        [SyncVar(hook = "onChangeDuration")]
        public float duration;

        public void onChangeDuration(float newDuration)
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

        private NetData<XiangqiMoveAnimation> netData = new NetData<XiangqiMoveAnimation>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.ucpcSquares.Callback += OnUcpcSquaresChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeMove(this.move);
                IdentityUtils.refresh(this.netData.clientData.ucpcSquares, this.ucpcSquares, MyByte.byteConvert);
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
                ret += GetDataSize(this.move);
                ret += GetDataSize(this.ucpcSquares);
                ret += GetDataSize(this.duration);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is XiangqiMoveAnimation)
            {
                XiangqiMoveAnimation xiangqiMoveAnimation = data as XiangqiMoveAnimation;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, xiangqiMoveAnimation.makeSearchInforms());
                    this.move = xiangqiMoveAnimation.move.v;
                    IdentityUtils.InitSync(this.ucpcSquares, xiangqiMoveAnimation.ucpcSquares, MyByte.myByteConvert);
                    this.duration = xiangqiMoveAnimation.duration.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(xiangqiMoveAnimation);
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
            if (data is XiangqiMoveAnimation)
            {
                // XiangqiMoveAnimation xiangqiMoveAnimation = data as XiangqiMoveAnimation;
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
            if (wrapProperty.p is XiangqiMoveAnimation)
            {
                switch ((XiangqiMoveAnimation.Property)wrapProperty.n)
                {
                    case XiangqiMoveAnimation.Property.move:
                        this.move = (System.UInt32)wrapProperty.getValue();
                        break;
                    case XiangqiMoveAnimation.Property.ucpcSquares:
                        IdentityUtils.UpdateSyncList(this.ucpcSquares, syncs, GlobalCast<T>.CastingMyByte);
                        break;
                    case XiangqiMoveAnimation.Property.duration:
                        this.duration = (float)wrapProperty.getValue();
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

    }
}