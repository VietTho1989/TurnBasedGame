using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Shogi
{
    public class ChangedListsIdentity : DataIdentity
    {

        #region SyncVar

        #region listindex

        public SyncListInt listindex = new SyncListInt();

        private void OnListindexChanged(SyncList<System.Int32>.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.listindex, this.listindex, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region size

        [SyncVar(hook = "onChangeSize")]
        public System.UInt64 size;

        public void onChangeSize(System.UInt64 newSize)
        {
            this.size = newSize;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.size.v = newSize;
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<ChangedLists> netData = new NetData<ChangedLists>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.listindex.Callback += OnListindexChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.listindex, this.listindex);
                this.onChangeSize(this.size);
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
                ret += GetDataSize(this.listindex);
                ret += GetDataSize(this.size);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is ChangedLists)
            {
                ChangedLists changedLists = data as ChangedLists;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, changedLists.makeSearchInforms());
                    IdentityUtils.InitSync(this.listindex, changedLists.listindex.vs);
                    this.size = changedLists.size.v;
                }
                this.getDataSize();
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(changedLists);
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
            if (data is ChangedLists)
            {
                // ChangedLists changedLists = data as ChangedLists;
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
            if (wrapProperty.p is ChangedLists)
            {
                switch ((ChangedLists.Property)wrapProperty.n)
                {
                    case ChangedLists.Property.listindex:
                        IdentityUtils.UpdateSyncList(this.listindex, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case ChangedLists.Property.size:
                        this.size = (ulong)wrapProperty.getValue();
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