using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan
{
    public class SeirawanIdentity : DataIdentity
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

        #region handScore

        public SyncListInt handScore = new SyncListInt();

        private void OnHandScoreChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.handScore, this.handScore, op, index);
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
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<Seirawan> netData = new NetData<Seirawan>();

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
            this.inHand.Callback += OnInHandChanged;
            this.handScore.Callback += OnHandScoreChanged;
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
                IdentityUtils.refresh(this.netData.clientData.inHand, this.inHand);
                IdentityUtils.refresh(this.netData.clientData.handScore, this.handScore);
                IdentityUtils.refresh(this.netData.clientData.pieceCount, this.pieceCount);
                IdentityUtils.refresh(this.netData.clientData.pieceList, this.pieceList);
                IdentityUtils.refresh(this.netData.clientData.index, this.index);
                IdentityUtils.refresh(this.netData.clientData.castlingRightsMask, this.castlingRightsMask);
                IdentityUtils.refresh(this.netData.clientData.castlingRookSquare, this.castlingRookSquare);
                IdentityUtils.refresh(this.netData.clientData.castlingPath, this.castlingPath, MyUInt64.uLongConvert);
                this.onChangeGamePly(this.gamePly);
                this.onChangeSideToMove(this.sideToMove);
                this.onChangeChess960(this.chess960);
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
                ret += GetDataSize(this.byTypeBB);
                ret += GetDataSize(this.byColorBB);
                ret += GetDataSize(this.inHand);
                ret += GetDataSize(this.handScore);
                ret += GetDataSize(this.pieceCount);
                ret += GetDataSize(this.pieceList);
                ret += GetDataSize(this.index);
                ret += GetDataSize(this.castlingRightsMask);
                ret += GetDataSize(this.castlingRookSquare);
                ret += GetDataSize(this.castlingPath);
                ret += GetDataSize(this.gamePly);
                ret += GetDataSize(this.sideToMove);
                ret += GetDataSize(this.chess960);
                ret += GetDataSize(this.isCustom);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Seirawan)
            {
                Seirawan seirawan = data as Seirawan;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, seirawan.makeSearchInforms());
                    IdentityUtils.InitSync(this.board, seirawan.board.vs);
                    IdentityUtils.InitSync(this.byTypeBB, seirawan.byTypeBB, MyUInt64.myUInt64Convert);
                    IdentityUtils.InitSync(this.byColorBB, seirawan.byColorBB, MyUInt64.myUInt64Convert);
                    IdentityUtils.InitSync(this.inHand, seirawan.inHand.vs);
                    IdentityUtils.InitSync(this.handScore, seirawan.handScore.vs);
                    IdentityUtils.InitSync(this.pieceCount, seirawan.pieceCount.vs);
                    IdentityUtils.InitSync(this.pieceList, seirawan.pieceList.vs);
                    IdentityUtils.InitSync(this.index, seirawan.index.vs);
                    IdentityUtils.InitSync(this.castlingRightsMask, seirawan.castlingRightsMask.vs);
                    IdentityUtils.InitSync(this.castlingRookSquare, seirawan.castlingRookSquare.vs);
                    IdentityUtils.InitSync(this.castlingPath, seirawan.castlingPath, MyUInt64.myUInt64Convert);
                    this.gamePly = seirawan.gamePly.v;
                    this.sideToMove = seirawan.sideToMove.v;
                    this.st = seirawan.st.vs.Count;
                    this.chess960 = seirawan.chess960.v;
                    this.isCustom = seirawan.isCustom.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(seirawan);
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
            if (data is Seirawan)
            {
                // Seirawan seirawan = data as Seirawan;
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
            if (wrapProperty.p is Seirawan)
            {
                switch ((Seirawan.Property)wrapProperty.n)
                {
                    case Seirawan.Property.board:
                        IdentityUtils.UpdateSyncList(this.board, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Seirawan.Property.byTypeBB:
                        IdentityUtils.UpdateSyncList(this.byTypeBB, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case Seirawan.Property.byColorBB:
                        IdentityUtils.UpdateSyncList(this.byColorBB, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case Seirawan.Property.inHand:
                        IdentityUtils.UpdateSyncList(this.inHand, syncs, GlobalCast<T>.CastingBool);
                        break;
                    case Seirawan.Property.handScore:
                        IdentityUtils.UpdateSyncList(this.handScore, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Seirawan.Property.pieceCount:
                        IdentityUtils.UpdateSyncList(this.pieceCount, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Seirawan.Property.pieceList:
                        IdentityUtils.UpdateSyncList(this.pieceList, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Seirawan.Property.index:
                        IdentityUtils.UpdateSyncList(this.index, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Seirawan.Property.castlingRightsMask:
                        IdentityUtils.UpdateSyncList(this.castlingRightsMask, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Seirawan.Property.castlingRookSquare:
                        IdentityUtils.UpdateSyncList(this.castlingRookSquare, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Seirawan.Property.castlingPath:
                        IdentityUtils.UpdateSyncList(this.castlingPath, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case Seirawan.Property.gamePly:
                        this.gamePly = (System.Int32)wrapProperty.getValue();
                        break;
                    case Seirawan.Property.sideToMove:
                        this.sideToMove = (System.Int32)wrapProperty.getValue();
                        break;
                    case Seirawan.Property.st:
                        {
                            Seirawan seirawan = wrapProperty.p as Seirawan;
                            this.st = seirawan.st.vs.Count;
                        }
                        break;
                    case Seirawan.Property.chess960:
                        this.chess960 = (System.Boolean)wrapProperty.getValue();
                        break;
                    case Seirawan.Property.isCustom:
                        this.isCustom = (System.Boolean)wrapProperty.getValue();
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