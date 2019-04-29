using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace FairyChess
{
    public class FairyChessIdentity : DataIdentity
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

        #region unpromotedBoard

        public SyncListInt unpromotedBoard = new SyncListInt();

        private void OnUnpromotedBoardChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.unpromotedBoard, this.unpromotedBoard, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region byTypeBB

        public SyncListUInt64 byTypeBB = new SyncListUInt64();

        private void OnByTypeBBChanged(SyncListUInt64.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.byTypeBB, this.byTypeBB, op, index, MyUInt64.uLongConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region byColorBB

        public SyncListUInt64 byColorBB = new SyncListUInt64();

        private void OnByColorBBChanged(SyncListUInt64.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.byColorBB, this.byColorBB, op, index, MyUInt64.uLongConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region pieceCount

        public SyncListInt pieceCount = new SyncListInt();

        private void OnPieceCountChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.pieceCount, this.pieceCount, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region pieceList

        public SyncListInt pieceList = new SyncListInt();

        private void OnPieceListChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.pieceList, this.pieceList, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region index

        public SyncListInt index = new SyncListInt();

        private void OnIndexChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.index, this.index, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region castlingRightsMask

        public SyncListInt castlingRightsMask = new SyncListInt();

        private void OnCastlingRightsMaskChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.castlingRightsMask, this.castlingRightsMask, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region castlingRookSquare

        public SyncListInt castlingRookSquare = new SyncListInt();

        private void OnCastlingRookSquareChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.castlingRookSquare, this.castlingRookSquare, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region castlingPath

        public SyncListUInt64 castlingPath = new SyncListUInt64();

        private void OnCastlingPathChanged(SyncListUInt64.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.castlingPath, this.castlingPath, op, index, MyUInt64.uLongConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region gamePly

        [SyncVar(hook = "onChangeGamePly")]
        public System.Int32 gamePly;

        public void onChangeGamePly(System.Int32 newGamePly)
        {
            this.gamePly = newGamePly;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.gamePly.v = newGamePly;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region sideToMove

        [SyncVar(hook = "onChangeSideToMove")]
        public System.Int32 sideToMove;

        public void onChangeSideToMove(System.Int32 newSideToMove)
        {
            this.sideToMove = newSideToMove;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.sideToMove.v = newSideToMove;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region variantType

        [SyncVar(hook = "onChangeVariantType")]
        public System.Int32 variantType;

        public void onChangeVariantType(System.Int32 newVariantType)
        {
            this.variantType = newVariantType;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.variantType.v = newVariantType;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region st

        [SyncVar]
        public int st;

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

        #region promotedPieces

        [SyncVar(hook = "onChangePromotedPieces")]
        public System.UInt64 promotedPieces;

        public void onChangePromotedPieces(System.UInt64 newPromotedPieces)
        {
            this.promotedPieces = newPromotedPieces;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.promotedPieces.v = newPromotedPieces;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region isCustom

        [SyncVar(hook = "onChangeIsCustom")]
        public bool isCustom;

        public void onChangeIsCustom(bool newIsCustom)
        {
            this.isCustom = newIsCustom;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isCustom.v = newIsCustom;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<FairyChess> netData = new NetData<FairyChess>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.board.Callback += OnBoardChanged;
            this.unpromotedBoard.Callback += OnUnpromotedBoardChanged;
            this.byTypeBB.Callback += OnByTypeBBChanged;
            this.byColorBB.Callback += OnByColorBBChanged;
            this.pieceCount.Callback += OnPieceCountChanged;
            this.pieceList.Callback += OnPieceListChanged;
            this.index.Callback += OnIndexChanged;
            this.castlingRightsMask.Callback += OnCastlingRightsMaskChanged;
            this.castlingRookSquare.Callback += OnCastlingRookSquareChanged;
            this.castlingPath.Callback += OnCastlingPathChanged;
            this.pieceCountInHand.Callback += OnPieceCountInHandChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.board, this.board);
                IdentityUtils.refresh(this.netData.clientData.unpromotedBoard, this.unpromotedBoard);
                IdentityUtils.refresh(this.netData.clientData.byTypeBB, this.byTypeBB, MyUInt64.uLongConvert);
                IdentityUtils.refresh(this.netData.clientData.byColorBB, this.byColorBB, MyUInt64.uLongConvert);
                IdentityUtils.refresh(this.netData.clientData.pieceCount, this.pieceCount);
                IdentityUtils.refresh(this.netData.clientData.pieceList, this.pieceList);
                IdentityUtils.refresh(this.netData.clientData.index, this.index);
                IdentityUtils.refresh(this.netData.clientData.castlingRightsMask, this.castlingRightsMask);
                IdentityUtils.refresh(this.netData.clientData.castlingRookSquare, this.castlingRookSquare);
                IdentityUtils.refresh(this.netData.clientData.castlingPath, this.castlingPath, MyUInt64.uLongConvert);
                this.onChangeGamePly(this.gamePly);
                this.onChangeSideToMove(this.sideToMove);
                this.onChangeVariantType(this.variantType);
                this.onChangeChess960(this.chess960);
                IdentityUtils.refresh(this.netData.clientData.pieceCountInHand, this.pieceCountInHand);
                this.onChangePromotedPieces(this.promotedPieces);
                this.onChangeIsCustom(this.isCustom);
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
                ret += GetDataSize(this.unpromotedBoard);
                ret += GetDataSize(this.byTypeBB);
                ret += GetDataSize(this.byColorBB);
                ret += GetDataSize(this.pieceCount);
                ret += GetDataSize(this.pieceList);
                ret += GetDataSize(this.index);
                ret += GetDataSize(this.castlingRightsMask);
                ret += GetDataSize(this.castlingRookSquare);
                ret += GetDataSize(this.castlingPath);
                ret += GetDataSize(this.gamePly);
                ret += GetDataSize(this.sideToMove);
                ret += GetDataSize(this.variantType);
                ret += GetDataSize(this.chess960);
                ret += GetDataSize(this.pieceCountInHand);
                ret += GetDataSize(this.promotedPieces);
                ret += GetDataSize(this.isCustom);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is FairyChess)
            {
                FairyChess fairyChess = data as FairyChess;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, fairyChess.makeSearchInforms());
                    IdentityUtils.InitSync(this.board, fairyChess.board.vs);
                    IdentityUtils.InitSync(this.unpromotedBoard, fairyChess.unpromotedBoard.vs);
                    IdentityUtils.InitSync(this.byTypeBB, fairyChess.byTypeBB, MyUInt64.myUInt64Convert);
                    IdentityUtils.InitSync(this.byColorBB, fairyChess.byColorBB, MyUInt64.myUInt64Convert);
                    IdentityUtils.InitSync(this.pieceCount, fairyChess.pieceCount.vs);
                    IdentityUtils.InitSync(this.pieceList, fairyChess.pieceList.vs);
                    IdentityUtils.InitSync(this.index, fairyChess.index.vs);
                    IdentityUtils.InitSync(this.castlingRightsMask, fairyChess.castlingRightsMask.vs);
                    IdentityUtils.InitSync(this.castlingRookSquare, fairyChess.castlingRookSquare.vs);
                    IdentityUtils.InitSync(this.castlingPath, fairyChess.castlingPath, MyUInt64.myUInt64Convert);
                    this.gamePly = fairyChess.gamePly.v;
                    this.sideToMove = fairyChess.sideToMove.v;
                    this.variantType = fairyChess.variantType.v;
                    this.st = fairyChess.st.vs.Count;
                    this.chess960 = fairyChess.chess960.v;
                    IdentityUtils.InitSync(this.pieceCountInHand, fairyChess.pieceCountInHand.vs);
                    this.promotedPieces = fairyChess.promotedPieces.v;
                    this.isCustom = fairyChess.isCustom.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(fairyChess);
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
            if (data is FairyChess)
            {
                // FairyChess fairyChess = data as FairyChess;
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
            if (wrapProperty.p is FairyChess)
            {
                switch ((FairyChess.Property)wrapProperty.n)
                {
                    case FairyChess.Property.board:
                        IdentityUtils.UpdateSyncList(this.board, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case FairyChess.Property.unpromotedBoard:
                        IdentityUtils.UpdateSyncList(this.unpromotedBoard, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case FairyChess.Property.byTypeBB:
                        IdentityUtils.UpdateSyncList(this.byTypeBB, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case FairyChess.Property.byColorBB:
                        IdentityUtils.UpdateSyncList(this.byColorBB, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case FairyChess.Property.pieceCount:
                        IdentityUtils.UpdateSyncList(this.pieceCount, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case FairyChess.Property.pieceList:
                        IdentityUtils.UpdateSyncList(this.pieceList, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case FairyChess.Property.index:
                        IdentityUtils.UpdateSyncList(this.index, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case FairyChess.Property.castlingRightsMask:
                        IdentityUtils.UpdateSyncList(this.castlingRightsMask, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case FairyChess.Property.castlingRookSquare:
                        IdentityUtils.UpdateSyncList(this.castlingRookSquare, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case FairyChess.Property.castlingPath:
                        IdentityUtils.UpdateSyncList(this.castlingPath, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case FairyChess.Property.gamePly:
                        this.gamePly = (System.Int32)wrapProperty.getValue();
                        break;
                    case FairyChess.Property.sideToMove:
                        this.sideToMove = (System.Int32)wrapProperty.getValue();
                        break;
                    case FairyChess.Property.variantType:
                        this.variantType = (System.Int32)wrapProperty.getValue();
                        break;
                    case FairyChess.Property.st:
                        {
                            FairyChess fairyChess = wrapProperty.p as FairyChess;
                            this.st = fairyChess.st.vs.Count;
                        }
                        break;
                    case FairyChess.Property.chess960:
                        this.chess960 = (System.Boolean)wrapProperty.getValue();
                        break;
                    case FairyChess.Property.pieceCountInHand:
                        IdentityUtils.UpdateSyncList(this.pieceCountInHand, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case FairyChess.Property.promotedPieces:
                        this.promotedPieces = (System.UInt64)wrapProperty.getValue();
                        break;
                    case FairyChess.Property.isCustom:
                        this.isCustom = (bool)wrapProperty.getValue();
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