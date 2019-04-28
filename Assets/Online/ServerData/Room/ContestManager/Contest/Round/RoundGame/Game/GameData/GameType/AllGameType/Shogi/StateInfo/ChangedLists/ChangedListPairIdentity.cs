using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
    public class ChangedListPairIdentity : DataIdentity
    {
        #region SyncVar

        #region newList

        public SyncListInt newList = new SyncListInt();

        private void OnNewListChanged(SyncList<int>.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.newList, this.newList, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region oldlist

        public SyncListInt oldlist = new SyncListInt();

        private void OnOldlistChanged(SyncList<int>.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.oldlist, this.oldlist, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<ChangedListPair> netData = new NetData<ChangedListPair>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.newList.Callback += OnNewListChanged;
            this.oldlist.Callback += OnOldlistChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.newList, this.newList);
                IdentityUtils.refresh(this.netData.clientData.oldlist, this.oldlist);
            }
            else
            {
                // Debug.Log ("clientData null");
            }
        }

        public override int refreshDataSize()
        {
            int ret = GetDataSize(this.netId);
            {
                ret += GetDataSize(this.newList);
                ret += GetDataSize(this.oldlist);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is ChangedListPair)
            {
                ChangedListPair changedListPair = data as ChangedListPair;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, changedListPair.makeSearchInforms());
                    IdentityUtils.InitSync(this.newList, changedListPair.newList.vs);
                    IdentityUtils.InitSync(this.oldlist, changedListPair.oldlist.vs);
                }
                this.getDataSize();
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(changedListPair);
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
            if (data is ChangedListPair)
            {
                // ChangedListPair changedListPair = data as ChangedListPair;
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
            if (wrapProperty.p is ChangedListPair)
            {
                switch ((ChangedListPair.Property)wrapProperty.n)
                {
                    case ChangedListPair.Property.newList:
                        IdentityUtils.UpdateSyncList(this.newList, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case ChangedListPair.Property.oldlist:
                        IdentityUtils.UpdateSyncList(this.oldlist, syncs, GlobalCast<T>.CastingInt32);
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