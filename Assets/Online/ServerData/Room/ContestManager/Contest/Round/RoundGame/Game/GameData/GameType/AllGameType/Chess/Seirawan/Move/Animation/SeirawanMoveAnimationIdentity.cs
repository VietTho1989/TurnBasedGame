using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Seirawan
{
    public class SeirawanMoveAnimationIdentity : DataIdentity
    {

        #region SyncVar

        #region board

        public SyncListInt board = new SyncListInt();

        private void OnBoardChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.board, this.board, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region inHand

        public SyncListBool inHand = new SyncListBool();

        private void OnInHandChanged(SyncListBool.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.inHand, this.inHand, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region move

        [SyncVar(hook = "onChangeMove")]
        public System.Int32 move;

        public void onChangeMove(System.Int32 newMove)
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

        #region chess960

        [SyncVar(hook = "onChangeChess960")]
        public System.Boolean chess960;

        public void onChangeChess960(System.Boolean newChess960)
        {
            this.chess960 = newChess960;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.chess960.v = newChess960;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
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

        private NetData<SeirawanMoveAnimation> netData = new NetData<SeirawanMoveAnimation>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.board.Callback += OnBoardChanged;
            this.inHand.Callback += OnInHandChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.board, this.board);
                IdentityUtils.refresh(this.netData.clientData.inHand, this.inHand);
                this.onChangeMove(this.move);
                this.onChangeChess960(this.chess960);
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
                ret += GetDataSize(this.board);
                ret += GetDataSize(this.inHand);
                ret += GetDataSize(this.move);
                ret += GetDataSize(this.chess960);
                ret += GetDataSize(this.duration);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is SeirawanMoveAnimation)
            {
                SeirawanMoveAnimation seirawanMoveAnimation = data as SeirawanMoveAnimation;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, seirawanMoveAnimation.makeSearchInforms());
                    IdentityUtils.InitSync(this.board, seirawanMoveAnimation.board.vs);
                    IdentityUtils.InitSync(this.inHand, seirawanMoveAnimation.inHand.vs);
                    this.move = seirawanMoveAnimation.move.v;
                    this.chess960 = seirawanMoveAnimation.chess960.v;
                    this.duration = seirawanMoveAnimation.duration.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(seirawanMoveAnimation);
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
            if (data is SeirawanMoveAnimation)
            {
                // SeirawanMoveAnimation seirawanMoveAnimation = data as SeirawanMoveAnimation;
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
            if (wrapProperty.p is SeirawanMoveAnimation)
            {
                switch ((SeirawanMoveAnimation.Property)wrapProperty.n)
                {
                    case SeirawanMoveAnimation.Property.board:
                        IdentityUtils.UpdateSyncList(this.board, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case SeirawanMoveAnimation.Property.inHand:
                        IdentityUtils.UpdateSyncList(this.inHand, syncs, GlobalCast<T>.CastingBool);
                        break;
                    case SeirawanMoveAnimation.Property.move:
                        this.move = (System.Int32)wrapProperty.getValue();
                        break;
                    case SeirawanMoveAnimation.Property.chess960:
                        this.chess960 = (System.Boolean)wrapProperty.getValue();
                        break;
                    case SeirawanMoveAnimation.Property.duration:
                        this.duration = (float)wrapProperty.getValue();
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