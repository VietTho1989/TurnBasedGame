using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku
{
    public class GomokuIdentity : DataIdentity
    {

        #region SyncVar

        #region boardSize

        [SyncVar(hook = "onChangeBoardSize")]
        public System.Int32 boardSize;

        public void onChangeBoardSize(System.Int32 newBoardSize)
        {
            this.boardSize = newBoardSize;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.boardSize.v = newBoardSize;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region gs

        public SyncListByte gs = new SyncListByte();

        private void OnGsChanged(SyncListByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.gs, this.gs, op, index, MyByte.byteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region player

        [SyncVar(hook = "onChangePlayer")]
        public System.Int32 player;

        public void onChangePlayer(System.Int32 newPlayer)
        {
            this.player = newPlayer;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.player.v = newPlayer;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region winningPlayer

        [SyncVar(hook = "onChangeWinningPlayer")]
        public System.Int32 winningPlayer;

        public void onChangeWinningPlayer(System.Int32 newWinningPlayer)
        {
            this.winningPlayer = newWinningPlayer;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.winningPlayer.v = newWinningPlayer;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region lastMove

        public SyncListInt lastMove = new SyncListInt();

        private void OnLastMoveChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.lastMove, this.lastMove, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region winSize

        [SyncVar(hook = "onChangeWinSize")]
        public System.Int32 winSize;

        public void onChangeWinSize(System.Int32 newWinSize)
        {
            this.winSize = newWinSize;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.winSize.v = newWinSize;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region winCoord

        public SyncListInt winCoord = new SyncListInt();

        private void OnWinCoordChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.winCoord, this.winCoord, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
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

        private NetData<Gomoku> netData = new NetData<Gomoku>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.gs.Callback += OnGsChanged;
            this.lastMove.Callback += OnLastMoveChanged;
            this.winCoord.Callback += OnWinCoordChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeBoardSize(this.boardSize);
                IdentityUtils.refresh(this.netData.clientData.gs, this.gs, MyByte.byteConvert);
                this.onChangePlayer(this.player);
                this.onChangeWinningPlayer(this.winningPlayer);
                IdentityUtils.refresh(this.netData.clientData.lastMove, this.lastMove);
                this.onChangeWinSize(this.winSize);
                IdentityUtils.refresh(this.netData.clientData.winCoord, this.winCoord);
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
                ret += GetDataSize(this.boardSize);
                ret += GetDataSize(this.gs);
                ret += GetDataSize(this.player);
                ret += GetDataSize(this.winningPlayer);
                ret += GetDataSize(this.lastMove);
                ret += GetDataSize(this.winSize);
                ret += GetDataSize(this.winCoord);
                ret += GetDataSize(this.isCustom);
                return ret;
            }
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Gomoku)
            {
                Gomoku gomoku = data as Gomoku;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, gomoku.makeSearchInforms());
                    this.boardSize = gomoku.boardSize.v;
                    IdentityUtils.InitSync(this.gs, gomoku.gs, MyByte.myByteConvert);
                    this.player = gomoku.player.v;
                    this.winningPlayer = gomoku.winningPlayer.v;
                    IdentityUtils.InitSync(this.lastMove, gomoku.lastMove.vs);
                    this.winSize = gomoku.winSize.v;
                    IdentityUtils.InitSync(this.winCoord, gomoku.winCoord.vs);
                    this.isCustom = gomoku.isCustom.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(gomoku);
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
            if (data is Gomoku)
            {
                // Gomoku gomoku = data as Gomoku;
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
            if (wrapProperty.p is Gomoku)
            {
                switch ((Gomoku.Property)wrapProperty.n)
                {
                    case Gomoku.Property.boardSize:
                        this.boardSize = (System.Int32)wrapProperty.getValue();
                        break;
                    case Gomoku.Property.gs:
                        IdentityUtils.UpdateSyncList(this.gs, syncs, GlobalCast<T>.CastingMyByte);
                        break;
                    case Gomoku.Property.player:
                        this.player = (System.Int32)wrapProperty.getValue();
                        break;
                    case Gomoku.Property.winningPlayer:
                        this.winningPlayer = (System.Int32)wrapProperty.getValue();
                        break;
                    case Gomoku.Property.lastMove:
                        IdentityUtils.UpdateSyncList(this.lastMove, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Gomoku.Property.winSize:
                        this.winSize = (System.Int32)wrapProperty.getValue();
                        break;
                    case Gomoku.Property.winCoord:
                        IdentityUtils.UpdateSyncList(this.winCoord, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Gomoku.Property.isCustom:
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