using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
    public class PosIdentity : DataIdentity
    {

        #region SyncVar

        #region p_piece

        public SyncListUInt64 p_piece = new SyncListUInt64();

        private void OnP_pieceChanged(SyncListUInt64.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.p_piece, this.p_piece, op, index, MyUInt64.uLongConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region p_side

        public SyncListUInt64 p_side = new SyncListUInt64();

        private void OnP_sideChanged(SyncListStruct<MyUInt64>.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.p_side, this.p_side, op, index, MyUInt64.uLongConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region p_all

        [SyncVar(hook = "onChangeP_all")]
        public System.UInt64 p_all;

        public void onChangeP_all(System.UInt64 newP_all)
        {
            this.p_all = newP_all;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.p_all.v = newP_all;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region p_turn

        [SyncVar(hook = "onChangeP_turn")]
        public System.Int32 p_turn;

        public void onChangeP_turn(System.Int32 newP_turn)
        {
            this.p_turn = newP_turn;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.p_turn.v = newP_turn;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<Pos> netData = new NetData<Pos>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.p_piece.Callback += OnP_pieceChanged;
            this.p_side.Callback += OnP_sideChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.p_piece, this.p_piece, MyUInt64.uLongConvert);
                IdentityUtils.refresh(this.netData.clientData.p_side, this.p_side, MyUInt64.uLongConvert);
                this.onChangeP_all(this.p_all);
                this.onChangeP_turn(this.p_turn);
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
                ret += GetDataSize(this.p_piece);
                ret += GetDataSize(this.p_side);
                ret += GetDataSize(this.p_all);
                ret += GetDataSize(this.p_turn);
                return ret;
            }
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Pos)
            {
                Pos pos = data as Pos;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, pos.makeSearchInforms());
                    IdentityUtils.InitSync(this.p_piece, pos.p_piece, MyUInt64.myUInt64Convert);
                    IdentityUtils.InitSync(this.p_side, pos.p_side, MyUInt64.myUInt64Convert);
                    this.p_all = pos.p_all.v;
                    this.p_turn = pos.p_turn.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(pos);
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
            if (data is Pos)
            {
                // Pos pos = data as Pos;
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
            if (wrapProperty.p is Pos)
            {
                switch ((Pos.Property)wrapProperty.n)
                {
                    case Pos.Property.p_piece:
                        IdentityUtils.UpdateSyncList(this.p_piece, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case Pos.Property.p_side:
                        IdentityUtils.UpdateSyncList(this.p_side, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case Pos.Property.p_all:
                        this.p_all = (System.UInt64)wrapProperty.getValue();
                        break;
                    case Pos.Property.p_turn:
                        this.p_turn = (System.Int32)wrapProperty.getValue();
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