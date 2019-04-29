using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Janggi
{
    public class JanggiIdentity : DataIdentity
    {

        #region SyncVar

        #region stones

        public SyncListUInt stones = new SyncListUInt();

        private void OnStonesChanged(SyncListUInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.stones, this.stones, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region targets

        public SyncListUInt targets = new SyncListUInt();

        private void OnTargetsChanged(SyncListUInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.targets, this.targets, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region blocks

        public SyncListUInt blocks = new SyncListUInt();

        private void OnBlocksChanged(SyncListUInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.blocks, this.blocks, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region positions

        public Common.SyncListPos positions = new Common.SyncListPos();

        private void OnPositionsChanged(Common.SyncListPos.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.positions, this.positions, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region isMyTurn

        [SyncVar(hook = "onChangeIsMyTurn")]
        public System.Boolean isMyTurn;

        public void onChangeIsMyTurn(System.Boolean newIsMyTurn)
        {
            this.isMyTurn = newIsMyTurn;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isMyTurn.v = newIsMyTurn;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region Point

        [SyncVar(hook = "onChangePoint")]
        public System.Int32 Point;

        public void onChangePoint(System.Int32 newPoint)
        {
            this.Point = newPoint;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.Point.v = newPoint;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region isMyFirst

        [SyncVar(hook = "onChangeIsMyFirst")]
        public System.Boolean isMyFirst;

        public void onChangeIsMyFirst(System.Boolean newIsMyFirst)
        {
            this.isMyFirst = newIsMyFirst;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isMyFirst.v = newIsMyFirst;
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

        private NetData<Janggi> netData = new NetData<Janggi>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.stones.Callback += OnStonesChanged;
            this.targets.Callback += OnTargetsChanged;
            this.blocks.Callback += OnBlocksChanged;
            this.positions.Callback += OnPositionsChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.stones, this.stones);
                IdentityUtils.refresh(this.netData.clientData.targets, this.targets);
                IdentityUtils.refresh(this.netData.clientData.blocks, this.blocks);
                IdentityUtils.refresh(this.netData.clientData.positions, this.positions);
                this.onChangeIsMyTurn(this.isMyTurn);
                this.onChangePoint(this.Point);
                this.onChangeIsMyFirst(this.isMyFirst);
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
                ret += GetDataSize(this.stones);
                ret += GetDataSize(this.targets);
                ret += GetDataSize(this.blocks);
                ret += GetDataSize(this.positions);
                ret += GetDataSize(this.isMyTurn);
                ret += GetDataSize(this.Point);
                ret += GetDataSize(this.isMyFirst);
                ret += GetDataSize(this.isCustom);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Janggi)
            {
                Janggi janggi = data as Janggi;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, janggi.makeSearchInforms());
                    IdentityUtils.InitSync(this.stones, janggi.stones.vs);
                    IdentityUtils.InitSync(this.targets, janggi.targets.vs);
                    IdentityUtils.InitSync(this.blocks, janggi.blocks.vs);
                    IdentityUtils.InitSync(this.positions, janggi.positions.vs);
                    this.isMyTurn = janggi.isMyTurn.v;
                    this.Point = janggi.Point.v;
                    this.isMyFirst = janggi.isMyFirst.v;
                    this.isCustom = janggi.isCustom.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(janggi);
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
            if (data is Janggi)
            {
                // Janggi janggi = data as Janggi;
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
            if (wrapProperty.p is Janggi)
            {
                switch ((Janggi.Property)wrapProperty.n)
                {
                    case Janggi.Property.stones:
                        IdentityUtils.UpdateSyncList(this.stones, syncs, GlobalCast<T>.CastingUInt32);
                        break;
                    case Janggi.Property.targets:
                        IdentityUtils.UpdateSyncList(this.targets, syncs, GlobalCast<T>.CastingUInt32);
                        break;
                    case Janggi.Property.blocks:
                        IdentityUtils.UpdateSyncList(this.blocks, syncs, GlobalCast<T>.CastingUInt32);
                        break;
                    case Janggi.Property.positions:
                        IdentityUtils.UpdateSyncList(this.positions, syncs, GlobalCast<T>.CastingJanggi_Common_Pos);
                        break;
                    case Janggi.Property.isMyTurn:
                        this.isMyTurn = (System.Boolean)wrapProperty.getValue();
                        break;
                    case Janggi.Property.Point:
                        this.Point = (System.Int32)wrapProperty.getValue();
                        break;
                    case Janggi.Property.isMyFirst:
                        this.isMyFirst = (System.Boolean)wrapProperty.getValue();
                        break;
                    case Janggi.Property.isCustom:
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