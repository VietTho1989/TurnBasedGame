using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace FairyChess
{
    public class FairyChessMoveAnimationIdentity : DataIdentity
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

        #region pieceCountInHand

        public SyncListInt pieceCountInHand = new SyncListInt();

        private void OnPieceCountInHandChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.pieceCountInHand, this.pieceCountInHand, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region promoteOrDropPiece

        [SyncVar(hook = "onChangePromoteOrDropPiece")]
        public Common.Piece promoteOrDropPiece;

        public void onChangePromoteOrDropPiece(Common.Piece newPromoteOrDropPiece)
        {
            this.promoteOrDropPiece = newPromoteOrDropPiece;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.promoteOrDropPiece.v = newPromoteOrDropPiece;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
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

        private NetData<FairyChessMoveAnimation> netData = new NetData<FairyChessMoveAnimation>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.board.Callback += OnBoardChanged;
            this.pieceCountInHand.Callback += OnPieceCountInHandChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.board, this.board);
                IdentityUtils.refresh(this.netData.clientData.pieceCountInHand, this.pieceCountInHand);
                this.onChangePromoteOrDropPiece(this.promoteOrDropPiece);
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
                ret += GetDataSize(this.board);
                ret += GetDataSize(this.pieceCountInHand);
                ret += GetDataSize(this.promoteOrDropPiece);
                ret += GetDataSize(this.move);
                ret += GetDataSize(this.duration);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is FairyChessMoveAnimation)
            {
                FairyChessMoveAnimation fairyChessMoveAnimation = data as FairyChessMoveAnimation;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, fairyChessMoveAnimation.makeSearchInforms());
                    IdentityUtils.InitSync(this.board, fairyChessMoveAnimation.board.vs);
                    IdentityUtils.InitSync(this.pieceCountInHand, fairyChessMoveAnimation.pieceCountInHand.vs);
                    this.promoteOrDropPiece = fairyChessMoveAnimation.promoteOrDropPiece.v;
                    this.move = fairyChessMoveAnimation.move.v;
                    this.duration = fairyChessMoveAnimation.duration.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(fairyChessMoveAnimation);
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
            if (data is FairyChessMoveAnimation)
            {
                // FairyChessMoveAnimation fairyChessMoveAnimation = data as FairyChessMoveAnimation;
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
            if (wrapProperty.p is FairyChessMoveAnimation)
            {
                switch ((FairyChessMoveAnimation.Property)wrapProperty.n)
                {
                    case FairyChessMoveAnimation.Property.board:
                        IdentityUtils.UpdateSyncList(this.board, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case FairyChessMoveAnimation.Property.pieceCountInHand:
                        IdentityUtils.UpdateSyncList(this.pieceCountInHand, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case FairyChessMoveAnimation.Property.promoteOrDropPiece:
                        this.promoteOrDropPiece = (Common.Piece)wrapProperty.getValue();
                        break;
                    case FairyChessMoveAnimation.Property.move:
                        this.move = (System.Int32)wrapProperty.getValue();
                        break;
                    case FairyChessMoveAnimation.Property.duration:
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