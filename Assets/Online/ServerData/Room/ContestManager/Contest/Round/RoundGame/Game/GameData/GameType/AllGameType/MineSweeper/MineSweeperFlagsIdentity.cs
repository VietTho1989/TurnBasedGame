using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
    public class MineSweeperFlagsIdentity : DataIdentity
    {


        #region SyncVar

        #region myFlags

        public SyncListUShort myFlags = new SyncListUShort();

        private void OnMyFlagsChanged(SyncListUShort.Operation op, int index, MyUShort item)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.myFlags, this.myFlags, op, index, MyUShort.ushortConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<MineSweeperFlags> netData = new NetData<MineSweeperFlags>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.myFlags.Callback += OnMyFlagsChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.myFlags, this.myFlags, MyUShort.ushortConvert);
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
                ret += GetDataSize(this.myFlags);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is MineSweeperFlags)
            {
                MineSweeperFlags mineSweeperFlags = data as MineSweeperFlags;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, mineSweeperFlags.makeSearchInforms());
                    IdentityUtils.InitSync(this.myFlags, mineSweeperFlags.myFlags, MyUShort.myUShortConvert);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(mineSweeperFlags);
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
            if (data is MineSweeperFlags)
            {
                // MineSweeperFlags mineSweeperFlags = data as MineSweeperFlags;
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
            if (wrapProperty.p is MineSweeperFlags)
            {
                switch ((MineSweeperFlags.Property)wrapProperty.n)
                {
                    case MineSweeperFlags.Property.myFlags:
                        IdentityUtils.UpdateSyncList(this.myFlags, syncs, GlobalCast<T>.CastingMyUShort);
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