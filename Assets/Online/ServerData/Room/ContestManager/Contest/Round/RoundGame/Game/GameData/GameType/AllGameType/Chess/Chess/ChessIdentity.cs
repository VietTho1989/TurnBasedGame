using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Chess
{
    public class ChessIdentity : DataIdentity
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

        public SyncListUInt64 byColorBB = new SyncListUInt64();

        private void OnByColorBBChanged(SyncListStruct<MyUInt64>.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.byColorBB, byColorBB, op, index, MyUInt64.uLongConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #region PieceCount

        public SyncListInt pieceCount = new SyncListInt();

        private void OnPieceCountChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.pieceCount, pieceCount, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region PieceList

        public SyncListInt pieceList = new SyncListInt();

        private void OnPieceListChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.pieceList, pieceList, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region index

        public SyncListInt index = new SyncListInt();

        private void OnIndexChanged(SyncListInt.Operation op, int i)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.index, index, op, i);
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
                IdentityUtils.onSyncListChange(this.netData.clientData.castlingRightsMask, castlingRightsMask, op, index);
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

        private void OnCastlingPathChanged(SyncListStruct<MyUInt64>.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.castlingPath, castlingPath, op, index, MyUInt64.uLongConvert);
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
                // Debug.LogError ("clientData null: " + this);
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
                // Debug.LogError ("clientData null: " + this);
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
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region isCustom

        [SyncVar(hook = "onChangeIsCustom")]
        public System.Boolean isCustom;

        public void onChangeIsCustom(System.Boolean newIsCustom)
        {
            this.isCustom = newIsCustom;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isCustom.v = newIsCustom;
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<Chess> netData = new NetData<Chess>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.board.Callback += OnBoardChanged;
            this.byTypeBB.Callback += OnByTypeBBChanged;
            this.byColorBB.Callback += OnByColorBBChanged;
            this.pieceCount.Callback += OnPieceCountChanged;
            this.pieceList.Callback += OnPieceListChanged;
            this.index.Callback += OnIndexChanged;
            this.castlingRightsMask.Callback += OnCastlingRightsMaskChanged;
            this.castlingRookSquare.Callback += OnCastlingRookSquareChanged;
            this.castlingPath.Callback += OnCastlingPathChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.board, this.board);
                IdentityUtils.refresh(this.netData.clientData.byTypeBB, this.byTypeBB, MyUInt64.uLongConvert);
                IdentityUtils.refresh(this.netData.clientData.byColorBB, this.byColorBB, MyUInt64.uLongConvert);
                IdentityUtils.refresh(this.netData.clientData.pieceCount, this.pieceCount);
                IdentityUtils.refresh(this.netData.clientData.pieceList, this.pieceList);
                IdentityUtils.refresh(this.netData.clientData.index, this.index);
                IdentityUtils.refresh(this.netData.clientData.castlingRightsMask, this.castlingRightsMask);
                IdentityUtils.refresh(this.netData.clientData.castlingRookSquare, this.castlingRookSquare);
                IdentityUtils.refresh(this.netData.clientData.castlingPath, castlingPath, MyUInt64.uLongConvert);
                this.onChangeGamePly(this.gamePly);
                this.onChangeSideToMove(this.sideToMove);
                this.onChangeChess960(this.chess960);
                this.onChangeIsCustom(this.isCustom);
            }
            else
            {
                // Debug.Log ("clientData null: " + this);
            }
        }

        public override int refreshDataSize()
        {
            int ret = GetDataSize(this.netId);
            {
                ret += GetDataSize(this.board);
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
                ret += GetDataSize(this.st);
                ret += GetDataSize(this.chess960);
                ret += GetDataSize(this.isCustom);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Chess)
            {
                Chess chess = data as Chess;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, chess.makeSearchInforms());
                    IdentityUtils.InitSync(this.board, chess.board.vs);
                    IdentityUtils.InitSync(this.byTypeBB, chess.byTypeBB, MyUInt64.myUInt64Convert);
                    IdentityUtils.InitSync(this.byColorBB, chess.byColorBB, MyUInt64.myUInt64Convert);
                    IdentityUtils.InitSync(this.pieceCount, chess.pieceCount.vs);
                    IdentityUtils.InitSync(this.pieceList, chess.pieceList.vs);
                    IdentityUtils.InitSync(this.index, chess.index.vs);
                    IdentityUtils.InitSync(this.castlingRightsMask, chess.castlingRightsMask.vs);
                    IdentityUtils.InitSync(this.castlingRookSquare, chess.castlingRookSquare.vs);
                    IdentityUtils.InitSync(this.castlingPath, chess.castlingPath, MyUInt64.myUInt64Convert);
                    this.gamePly = chess.gamePly.v;
                    this.sideToMove = chess.sideToMove.v;
                    this.st = chess.st.vs.Count;
                    this.chess960 = chess.chess960.v;
                    this.isCustom = chess.isCustom.v;
                }
                this.getDataSize();
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(chess);
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
            if (data is Chess)
            {
                // Chess chess = data as Chess;
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
            if (wrapProperty.p is Chess)
            {
                switch ((Chess.Property)wrapProperty.n)
                {
                    case Chess.Property.board:
                        IdentityUtils.UpdateSyncList(this.board, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Chess.Property.byTypeBB:
                        IdentityUtils.UpdateSyncList(this.byTypeBB, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case Chess.Property.byColorBB:
                        IdentityUtils.UpdateSyncList(this.byColorBB, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case Chess.Property.pieceCount:
                        IdentityUtils.UpdateSyncList(this.pieceCount, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Chess.Property.pieceList:
                        IdentityUtils.UpdateSyncList(this.pieceList, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Chess.Property.index:
                        IdentityUtils.UpdateSyncList(this.index, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Chess.Property.castlingRightsMask:
                        IdentityUtils.UpdateSyncList(this.castlingRightsMask, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Chess.Property.castlingRookSquare:
                        IdentityUtils.UpdateSyncList(this.castlingRookSquare, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Chess.Property.castlingPath:
                        IdentityUtils.UpdateSyncList(this.castlingPath, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case Chess.Property.gamePly:
                        this.gamePly = (int)wrapProperty.getValue();
                        break;
                    case Chess.Property.sideToMove:
                        this.sideToMove = (int)wrapProperty.getValue();
                        break;
                    case Chess.Property.chess960:
                        this.chess960 = (bool)wrapProperty.getValue();
                        break;
                    case Chess.Property.st:
                        {
                            Chess chess = wrapProperty.p as Chess;
                            this.st = chess.st.vs.Count;
                        }
                        break;
                    case Chess.Property.isCustom:
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