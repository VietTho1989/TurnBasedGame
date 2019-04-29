using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Weiqi
{
    public class GroupIdentity : DataIdentity
    {

        #region SyncVar

        #region lib

        public SyncListInt lib = new SyncListInt();

        private void OnLibChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.lib, this.lib, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region libs

        [SyncVar(hook = "onChangeLibs")]
        public System.Int32 libs;

        public void onChangeLibs(System.Int32 newLibs)
        {
            this.libs = newLibs;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.libs.v = newLibs;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<Group> netData = new NetData<Group>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.lib.Callback += OnLibChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.lib, this.lib);
                this.onChangeLibs(this.libs);
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
                ret += GetDataSize(this.lib);
                ret += GetDataSize(this.libs);
                return ret;
            }
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Group)
            {
                Group group = data as Group;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, group.makeSearchInforms());
                    IdentityUtils.InitSync(this.lib, group.lib.vs);
                    this.libs = group.libs.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(group);
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
            if (data is Group)
            {
                // Group group = data as Group;
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
            if (wrapProperty.p is Group)
            {
                switch ((Group.Property)wrapProperty.n)
                {
                    case Group.Property.lib:
                        IdentityUtils.UpdateSyncList(this.lib, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Group.Property.libs:
                        this.libs = (System.Int32)wrapProperty.getValue();
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