using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Reversi
{
    public class ReversiIdentity : DataIdentity
    {

        #region SyncVar

        #region side

        [SyncVar(hook = "onChangeSide")]
        public System.Int32 side;

        public void onChangeSide(System.Int32 newSide)
        {
            this.side = newSide;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.side.v = newSide;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region white

        [SyncVar(hook = "onChangeWhite")]
        public System.UInt64 white;

        public void onChangeWhite(System.UInt64 newWhite)
        {
            this.white = newWhite;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.white.v = newWhite;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region black

        [SyncVar(hook = "onChangeBlack")]
        public System.UInt64 black;

        public void onChangeBlack(System.UInt64 newBlack)
        {
            this.black = newBlack;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.black.v = newBlack;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region nMoveNum

        [SyncVar(hook = "onChangeNMoveNum")]
        public System.SByte nMoveNum;

        public void onChangeNMoveNum(System.SByte newNMoveNum)
        {
            this.nMoveNum = newNMoveNum;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.nMoveNum.v = newNMoveNum;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region moves

        public SyncListSByte moves = new SyncListSByte();

        private void OnMovesChanged(SyncListSByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.moves, this.moves, op, index, MySByte.sbyteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region changes

        public SyncListUInt64 changes = new SyncListUInt64();

        private void OnChangesChanged(SyncListUInt64.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.changes, this.changes, op, index, MyUInt64.uLongConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region oldSides

        public SyncListInt oldSides = new SyncListInt();

        private void OnOldSidesChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.oldSides, this.oldSides, op, index);
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

        private NetData<Reversi> netData = new NetData<Reversi>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.moves.Callback += OnMovesChanged;
            this.changes.Callback += OnChangesChanged;
            this.oldSides.Callback += OnOldSidesChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeSide(this.side);
                this.onChangeWhite(this.white);
                this.onChangeBlack(this.black);
                this.onChangeNMoveNum(this.nMoveNum);
                IdentityUtils.refresh(this.netData.clientData.moves, this.moves, MySByte.sbyteConvert);
                IdentityUtils.refresh(this.netData.clientData.changes, this.changes, MyUInt64.uLongConvert);
                IdentityUtils.refresh(this.netData.clientData.oldSides, this.oldSides);
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
                ret += GetDataSize(this.side);
                ret += GetDataSize(this.white);
                ret += GetDataSize(this.black);
                ret += GetDataSize(this.nMoveNum);
                ret += GetDataSize(this.moves);
                ret += GetDataSize(this.changes);
                ret += GetDataSize(this.oldSides);
                ret += GetDataSize(this.isCustom);
                return ret;
            }
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Reversi)
            {
                Reversi reversi = data as Reversi;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, reversi.makeSearchInforms());
                    this.side = reversi.side.v;
                    this.white = reversi.white.v;
                    this.black = reversi.black.v;
                    this.nMoveNum = reversi.nMoveNum.v;
                    IdentityUtils.InitSync(this.moves, reversi.moves, MySByte.mySByteConvert);
                    IdentityUtils.InitSync(this.changes, reversi.changes, MyUInt64.myUInt64Convert);
                    IdentityUtils.InitSync(this.oldSides, reversi.oldSides.vs);
                    this.isCustom = reversi.isCustom.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(reversi);
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
            if (data is Reversi)
            {
                // Reversi reversi = data as Reversi;
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
            if (wrapProperty.p is Reversi)
            {
                switch ((Reversi.Property)wrapProperty.n)
                {
                    case Reversi.Property.side:
                        this.side = (System.Int32)wrapProperty.getValue();
                        break;
                    case Reversi.Property.white:
                        this.white = (System.UInt64)wrapProperty.getValue();
                        break;
                    case Reversi.Property.black:
                        this.black = (System.UInt64)wrapProperty.getValue();
                        break;
                    case Reversi.Property.nMoveNum:
                        this.nMoveNum = (System.SByte)wrapProperty.getValue();
                        break;
                    case Reversi.Property.moves:
                        IdentityUtils.UpdateSyncList(this.moves, syncs, GlobalCast<T>.CastingMySByte);
                        break;
                    case Reversi.Property.changes:
                        IdentityUtils.UpdateSyncList(this.changes, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case Reversi.Property.oldSides:
                        IdentityUtils.UpdateSyncList(this.oldSides, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Reversi.Property.isCustom:
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