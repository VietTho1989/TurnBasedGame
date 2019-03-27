using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
    public class KhetIdentity : DataIdentity
    {

        #region SyncVar

        #region _playerToMove

        [SyncVar(hook = "onChange_playerToMove")]
        public System.Int32 _playerToMove;

        public void onChange_playerToMove(System.Int32 new_playerToMove)
        {
            this._playerToMove = new_playerToMove;
            if (this.netData.clientData != null)
            {
                this.netData.clientData._playerToMove.v = new_playerToMove;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region _checkmate

        [SyncVar(hook = "onChange_checkmate")]
        public System.Boolean _checkmate;

        public void onChange_checkmate(System.Boolean new_checkmate)
        {
            this._checkmate = new_checkmate;
            if (this.netData.clientData != null)
            {
                this.netData.clientData._checkmate.v = new_checkmate;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region _drawn

        [SyncVar(hook = "onChange_drawn")]
        public System.Boolean _drawn;

        public void onChange_drawn(System.Boolean new_drawn)
        {
            this._drawn = new_drawn;
            if (this.netData.clientData != null)
            {
                this.netData.clientData._drawn.v = new_drawn;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region _moveNumber

        [SyncVar(hook = "onChange_moveNumber")]
        public System.Int32 _moveNumber;

        public void onChange_moveNumber(System.Int32 new_moveNumber)
        {
            this._moveNumber = new_moveNumber;
            if (this.netData.clientData != null)
            {
                this.netData.clientData._moveNumber.v = new_moveNumber;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region _board

        public SyncListByte _board = new SyncListByte();

        private void On_boardChanged(SyncListByte.Operation op, int index, MyByte item)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData._board, this._board, op, index, MyByte.byteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region _pharaohPositions

        public SyncListInt _pharaohPositions = new SyncListInt();

        private void On_pharaohPositionsChanged(SyncListInt.Operation op, int index, int item)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData._pharaohPositions, this._pharaohPositions, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region khetSubCount

        [SyncVar(hook = "onChangeKhetSubCount")]
        public int khetSubCount;

        public void onChangeKhetSubCount(int newKhetSubCount)
        {
            this.khetSubCount = newKhetSubCount;
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

        #region startPos

        [SyncVar(hook = "onChangeStartPos")]
        public DefaultKhet.StartPos startPos;

        public void onChangeStartPos(DefaultKhet.StartPos newStartPos)
        {
            this.startPos = newStartPos;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.startPos.v = newStartPos;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<Khet> netData = new NetData<Khet>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this._board.Callback += On_boardChanged;
            this._pharaohPositions.Callback += On_pharaohPositionsChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChange_playerToMove(this._playerToMove);
                this.onChange_checkmate(this._checkmate);
                this.onChange_drawn(this._drawn);
                this.onChange_moveNumber(this._moveNumber);
                IdentityUtils.refresh(this.netData.clientData._board, this._board, MyByte.byteConvert);
                IdentityUtils.refresh(this.netData.clientData._pharaohPositions, this._pharaohPositions);
                this.onChangeKhetSubCount(this.khetSubCount);
                this.onChangeIsCustom(this.isCustom);
                this.onChangeStartPos(this.startPos);
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
                ret += GetDataSize(this._playerToMove);
                ret += GetDataSize(this._checkmate);
                ret += GetDataSize(this._drawn);
                ret += GetDataSize(this._moveNumber);
                ret += GetDataSize(this._board);
                ret += GetDataSize(this._pharaohPositions);
                ret += GetDataSize(this.khetSubCount);
                ret += GetDataSize(this.isCustom);
                ret += GetDataSize(this.startPos);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Khet)
            {
                Khet khet = data as Khet;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, khet.makeSearchInforms());
                    this._playerToMove = khet._playerToMove.v;
                    this._checkmate = khet._checkmate.v;
                    this._drawn = khet._drawn.v;
                    this._moveNumber = khet._moveNumber.v;
                    IdentityUtils.InitSync(this._board, khet._board, MyByte.myByteConvert);
                    IdentityUtils.InitSync(this._pharaohPositions, khet._pharaohPositions.vs);
                    this.khetSubCount = khet.khetSub.vs.Count;
                    this.isCustom = khet.isCustom.v;
                    this.startPos = khet.startPos.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(khet);
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
            if (data is Khet)
            {
                // Khet khet = data as Khet;
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
            if (wrapProperty.p is Khet)
            {
                switch ((Khet.Property)wrapProperty.n)
                {
                    case Khet.Property._playerToMove:
                        this._playerToMove = (System.Int32)wrapProperty.getValue();
                        break;
                    case Khet.Property._checkmate:
                        this._checkmate = (System.Boolean)wrapProperty.getValue();
                        break;
                    case Khet.Property._drawn:
                        this._drawn = (System.Boolean)wrapProperty.getValue();
                        break;
                    case Khet.Property._moveNumber:
                        this._moveNumber = (System.Int32)wrapProperty.getValue();
                        break;
                    case Khet.Property._laser:
                        break;
                    case Khet.Property._board:
                        IdentityUtils.UpdateSyncList(this._board, syncs, GlobalCast<T>.CastingMyByte);
                        break;
                    case Khet.Property._pharaohPositions:
                        IdentityUtils.UpdateSyncList(this._pharaohPositions, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Khet.Property.khetSub:
                        {
                            Khet khet = wrapProperty.p as Khet;
                            this.khetSubCount = khet.khetSub.vs.Count;
                        }
                        break;
                    case Khet.Property.isCustom:
                        this.isCustom = (System.Boolean)wrapProperty.getValue();
                        break;
                    case Khet.Property.startPos:
                        this.startPos = (DefaultKhet.StartPos)wrapProperty.getValue();
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