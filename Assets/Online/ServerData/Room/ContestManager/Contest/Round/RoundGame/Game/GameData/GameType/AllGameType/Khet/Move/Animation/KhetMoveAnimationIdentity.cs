using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
    public class KhetMoveAnimationIdentity : DataIdentity
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

        #region playerToMove

        [SyncVar(hook = "onChangePlayerToMove")]
        public System.Int32 playerToMove;

        public void onChangePlayerToMove(System.Int32 newPlayerToMove)
        {
            this.playerToMove = newPlayerToMove;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.playerToMove.v = newPlayerToMove;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region board

        public SyncListByte board = new SyncListByte();

        private void OnBoardChanged(SyncListByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.board, this.board, op, index, MyByte.byteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region laserTargetIndex

        [SyncVar(hook = "onChangeLaserTargetIndex")]
        public System.Int32 laserTargetIndex;

        public void onChangeLaserTargetIndex(System.Int32 newLaserTargetIndex)
        {
            this.laserTargetIndex = newLaserTargetIndex;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.laserTargetIndex.v = newLaserTargetIndex;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region laserTargetSquare

        [SyncVar(hook = "onChangeLaserTargetSquare")]
        public System.Byte laserTargetSquare;

        public void onChangeLaserTargetSquare(System.Byte newLaserTargetSquare)
        {
            this.laserTargetSquare = newLaserTargetSquare;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.laserTargetSquare.v = newLaserTargetSquare;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region laserTargetPiece

        [SyncVar(hook = "onChangeLaserTargetPiece")]
        public System.Int32 laserTargetPiece;

        public void onChangeLaserTargetPiece(System.Int32 newLaserTargetPiece)
        {
            this.laserTargetPiece = newLaserTargetPiece;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.laserTargetPiece.v = newLaserTargetPiece;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region isKill

        [SyncVar(hook = "onChangeIsKill")]
        public System.Boolean isKill;

        public void onChangeIsKill(System.Boolean newIsKill)
        {
            this.isKill = newIsKill;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isKill.v = newIsKill;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region silverLine

        public SyncListInt silverLine = new SyncListInt();

        private void OnSilverLineChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.silverLine, this.silverLine, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region redLine

        public SyncListInt redLine = new SyncListInt();

        private void OnRedLineChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.redLine, this.redLine, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region moveTime

        [SyncVar(hook = "onChangeMoveTime")]
        public System.Single moveTime;

        public void onChangeMoveTime(System.Single newMoveTime)
        {
            this.moveTime = newMoveTime;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.moveTime.v = newMoveTime;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region rotateTime

        [SyncVar(hook = "onChangeRotateTime")]
        public System.Single rotateTime;

        public void onChangeRotateTime(System.Single newRotateTime)
        {
            this.rotateTime = newRotateTime;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.rotateTime.v = newRotateTime;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region laserTime

        [SyncVar(hook = "onChangeLaserTime")]
        public System.Single laserTime;

        public void onChangeLaserTime(System.Single newLaserTime)
        {
            this.laserTime = newLaserTime;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.laserTime.v = newLaserTime;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<KhetMoveAnimation> netData = new NetData<KhetMoveAnimation>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.board.Callback += OnBoardChanged;
            this.silverLine.Callback += OnSilverLineChanged;
            this.redLine.Callback += OnRedLineChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeMove(this.move);
                this.onChangePlayerToMove(this.playerToMove);
                IdentityUtils.refresh(this.netData.clientData.board, this.board, MyByte.byteConvert);
                this.onChangeLaserTargetIndex(this.laserTargetIndex);
                this.onChangeLaserTargetSquare(this.laserTargetSquare);
                this.onChangeLaserTargetPiece(this.laserTargetPiece);
                this.onChangeIsKill(this.isKill);
                IdentityUtils.refresh(this.netData.clientData.silverLine, this.silverLine);
                IdentityUtils.refresh(this.netData.clientData.redLine, this.redLine);
                this.onChangeMoveTime(this.moveTime);
                this.onChangeRotateTime(this.rotateTime);
                this.onChangeLaserTime(this.laserTime);
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
                ret += GetDataSize(this.playerToMove);
                ret += GetDataSize(this.board);
                ret += GetDataSize(this.laserTargetIndex);
                ret += GetDataSize(this.laserTargetSquare);
                ret += GetDataSize(this.laserTargetPiece);
                ret += GetDataSize(this.isKill);
                ret += GetDataSize(this.silverLine);
                ret += GetDataSize(this.redLine);
                ret += GetDataSize(this.moveTime);
                ret += GetDataSize(this.rotateTime);
                ret += GetDataSize(this.laserTime);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is KhetMoveAnimation)
            {
                KhetMoveAnimation khetMoveAnimation = data as KhetMoveAnimation;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, khetMoveAnimation.makeSearchInforms());
                    this.move = khetMoveAnimation.move.v;
                    this.playerToMove = khetMoveAnimation.playerToMove.v;
                    IdentityUtils.InitSync(this.board, khetMoveAnimation.board, MyByte.myByteConvert);
                    this.laserTargetIndex = khetMoveAnimation.laserTargetIndex.v;
                    this.laserTargetSquare = khetMoveAnimation.laserTargetSquare.v;
                    this.laserTargetPiece = khetMoveAnimation.laserTargetPiece.v;
                    this.isKill = khetMoveAnimation.isKill.v;
                    IdentityUtils.InitSync(this.silverLine, khetMoveAnimation.silverLine.vs);
                    IdentityUtils.InitSync(this.redLine, khetMoveAnimation.redLine.vs);
                    this.moveTime = khetMoveAnimation.moveTime.v;
                    this.rotateTime = khetMoveAnimation.rotateTime.v;
                    this.laserTime = khetMoveAnimation.laserTime.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(khetMoveAnimation);
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
            if (data is KhetMoveAnimation)
            {
                // KhetMoveAnimation khetMoveAnimation = data as KhetMoveAnimation;
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
            if (wrapProperty.p is KhetMoveAnimation)
            {
                switch ((KhetMoveAnimation.Property)wrapProperty.n)
                {
                    case KhetMoveAnimation.Property.move:
                        this.move = (System.UInt32)wrapProperty.getValue();
                        break;
                    case KhetMoveAnimation.Property.playerToMove:
                        this.playerToMove = (System.Int32)wrapProperty.getValue();
                        break;
                    case KhetMoveAnimation.Property.board:
                        IdentityUtils.UpdateSyncList(this.board, syncs, GlobalCast<T>.CastingMyByte);
                        break;
                    case KhetMoveAnimation.Property.laserTargetIndex:
                        this.laserTargetIndex = (System.Int32)wrapProperty.getValue();
                        break;
                    case KhetMoveAnimation.Property.laserTargetSquare:
                        this.laserTargetSquare = (System.Byte)wrapProperty.getValue();
                        break;
                    case KhetMoveAnimation.Property.laserTargetPiece:
                        this.laserTargetPiece = (System.Int32)wrapProperty.getValue();
                        break;
                    case KhetMoveAnimation.Property.isKill:
                        this.isKill = (System.Boolean)wrapProperty.getValue();
                        break;
                    case KhetMoveAnimation.Property.silverLine:
                        IdentityUtils.UpdateSyncList(this.silverLine, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case KhetMoveAnimation.Property.redLine:
                        IdentityUtils.UpdateSyncList(this.redLine, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case KhetMoveAnimation.Property.moveTime:
                        this.moveTime = (System.Single)wrapProperty.getValue();
                        break;
                    case KhetMoveAnimation.Property.rotateTime:
                        this.rotateTime = (System.Single)wrapProperty.getValue();
                        break;
                    case KhetMoveAnimation.Property.laserTime:
                        this.laserTime = (System.Single)wrapProperty.getValue();
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