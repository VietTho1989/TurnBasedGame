using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
    public class ShogiMoveAnimationIdentity : DataIdentity
    {

        #region SyncVar

        #region playerIndex

        [SyncVar(hook = "onChangePlayerIndex")]
        public System.Int32 playerIndex;

        public void onChangePlayerIndex(System.Int32 newPlayerIndex)
        {
            this.playerIndex = newPlayerIndex;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.playerIndex.v = newPlayerIndex;
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region piece

        public SyncListInt piece = new SyncListInt();

        private void OnPieceChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.piece, this.piece, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region hand

        public SyncListUInt hand = new SyncListUInt();

        private void OnHandChanged(SyncListUInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.hand, this.hand, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

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

        private NetData<ShogiMoveAnimation> netData = new NetData<ShogiMoveAnimation>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.piece.Callback += OnPieceChanged;
            this.hand.Callback += OnHandChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangePlayerIndex(this.playerIndex);
                IdentityUtils.refresh(this.netData.clientData.piece, this.piece);
                IdentityUtils.refresh(this.netData.clientData.hand, this.hand);
                this.onChangeMove(this.move);
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
                ret += GetDataSize(this.playerIndex);
                ret += GetDataSize(this.piece);
                ret += GetDataSize(this.hand);
                ret += GetDataSize(this.move);
                ret += GetDataSize(this.duration);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is ShogiMoveAnimation)
            {
                ShogiMoveAnimation shogiMoveAnimation = data as ShogiMoveAnimation;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, shogiMoveAnimation.makeSearchInforms());
                    this.playerIndex = shogiMoveAnimation.playerIndex.v;
                    IdentityUtils.InitSync(this.piece, shogiMoveAnimation.piece.vs);
                    IdentityUtils.InitSync(this.hand, shogiMoveAnimation.hand.vs);
                    this.move = shogiMoveAnimation.move.v;
                    this.duration = shogiMoveAnimation.duration.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(shogiMoveAnimation);
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
            if (data is ShogiMoveAnimation)
            {
                // ShogiMoveAnimation shogiMoveAnimation = data as ShogiMoveAnimation;
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
            if (wrapProperty.p is ShogiMoveAnimation)
            {
                switch ((ShogiMoveAnimation.Property)wrapProperty.n)
                {
                    case ShogiMoveAnimation.Property.piece:
                        IdentityUtils.UpdateSyncList(this.piece, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case ShogiMoveAnimation.Property.hand:
                        IdentityUtils.UpdateSyncList(this.hand, syncs, GlobalCast<T>.CastingUInt32);
                        break;
                    case ShogiMoveAnimation.Property.playerIndex:
                        this.playerIndex = (System.Int32)wrapProperty.getValue();
                        break;
                    case ShogiMoveAnimation.Property.move:
                        this.move = (System.UInt32)wrapProperty.getValue();
                        break;
                    case ShogiMoveAnimation.Property.duration:
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