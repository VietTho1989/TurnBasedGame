using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
    public class KhetSubIdentity : DataIdentity
    {

        #region SyncVar

        #region _hashes

        public SyncListUInt64 _hashes = new SyncListUInt64();

        private void On_hashesChanged(SyncListUInt64.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData._hashes, this._hashes, op, index, MyUInt64.uLongConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region _moves

        public SyncListUInt _moves = new SyncListUInt();

        private void On_movesChanged(SyncListUInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData._moves, this._moves, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region _captureSquare

        public SyncListByte _captureSquare = new SyncListByte();

        private void On_captureSquareChanged(SyncListByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData._captureSquare, this._captureSquare, op, index, MyByte.byteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region _captureLocation

        public SyncListInt _captureLocation = new SyncListInt();

        private void On_captureLocationChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData._captureLocation, this._captureLocation, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region _movesWithoutCapture

        public SyncListInt _movesWithoutCapture = new SyncListInt();

        private void On_movesWithoutCaptureChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData._movesWithoutCapture, this._movesWithoutCapture, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<KhetSub> netData = new NetData<KhetSub>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this._hashes.Callback += On_hashesChanged;
            this._moves.Callback += On_movesChanged;
            this._captureSquare.Callback += On_captureSquareChanged;
            this._captureLocation.Callback += On_captureLocationChanged;
            this._movesWithoutCapture.Callback += On_movesWithoutCaptureChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData._hashes, this._hashes, MyUInt64.uLongConvert);
                IdentityUtils.refresh(this.netData.clientData._moves, this._moves);
                IdentityUtils.refresh(this.netData.clientData._captureSquare, this._captureSquare, MyByte.byteConvert);
                IdentityUtils.refresh(this.netData.clientData._captureLocation, this._captureLocation);
                IdentityUtils.refresh(this.netData.clientData._movesWithoutCapture, this._movesWithoutCapture);
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
                ret += GetDataSize(this._hashes);
                ret += GetDataSize(this._moves);
                ret += GetDataSize(this._captureSquare);
                ret += GetDataSize(this._captureLocation);
                ret += GetDataSize(this._movesWithoutCapture);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is KhetSub)
            {
                KhetSub khetSub = data as KhetSub;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, khetSub.makeSearchInforms());
                    IdentityUtils.InitSync(this._hashes, khetSub._hashes, MyUInt64.myUInt64Convert);
                    IdentityUtils.InitSync(this._moves, khetSub._moves.vs);
                    IdentityUtils.InitSync(this._captureSquare, khetSub._captureSquare, MyByte.myByteConvert);
                    IdentityUtils.InitSync(this._captureLocation, khetSub._captureLocation.vs);
                    IdentityUtils.InitSync(this._movesWithoutCapture, khetSub._movesWithoutCapture.vs);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(khetSub);
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
            if (data is KhetSub)
            {
                // KhetSub khetSub = data as KhetSub;
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
            if (wrapProperty.p is KhetSub)
            {
                switch ((KhetSub.Property)wrapProperty.n)
                {
                    case KhetSub.Property._hashes:
                        IdentityUtils.UpdateSyncList(this._hashes, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case KhetSub.Property._moves:
                        IdentityUtils.UpdateSyncList(this._moves, syncs, GlobalCast<T>.CastingUInt32);
                        break;
                    case KhetSub.Property._captureSquare:
                        IdentityUtils.UpdateSyncList(this._captureSquare, syncs, GlobalCast<T>.CastingMyByte);
                        break;
                    case KhetSub.Property._captureLocation:
                        IdentityUtils.UpdateSyncList(this._captureLocation, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case KhetSub.Property._movesWithoutCapture:
                        IdentityUtils.UpdateSyncList(this._movesWithoutCapture, syncs, GlobalCast<T>.CastingInt32);
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