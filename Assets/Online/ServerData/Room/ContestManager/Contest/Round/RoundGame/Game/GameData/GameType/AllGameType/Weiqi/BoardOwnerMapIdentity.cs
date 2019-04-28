using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
    public class BoardOwnerMapIdentity : DataIdentity
    {

        #region SyncVar

        #region playouts

        [SyncVar(hook = "onChangePlayouts")]
        public System.Int32 playouts;

        public void onChangePlayouts(System.Int32 newPlayouts)
        {
            this.playouts = newPlayouts;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.playouts.v = newPlayouts;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region map

        public SyncListInt map = new SyncListInt();

        private void OnMapChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.map, this.map, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<BoardOwnerMap> netData = new NetData<BoardOwnerMap>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.map.Callback += OnMapChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangePlayouts(this.playouts);
                IdentityUtils.refresh(this.netData.clientData.map, this.map);
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
                ret += GetDataSize(this.playouts);
                ret += GetDataSize(this.map);
                return ret;
            }
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is BoardOwnerMap)
            {
                BoardOwnerMap boardOwnerMap = data as BoardOwnerMap;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, boardOwnerMap.makeSearchInforms());
                    this.playouts = boardOwnerMap.playouts.v;
                    IdentityUtils.InitSync(this.map, boardOwnerMap.map.vs);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(boardOwnerMap);
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
            if (data is BoardOwnerMap)
            {
                // BoardOwnerMap boardOwnerMap = data as BoardOwnerMap;
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
            if (wrapProperty.p is BoardOwnerMap)
            {
                switch ((BoardOwnerMap.Property)wrapProperty.n)
                {
                    case BoardOwnerMap.Property.playouts:
                        this.playouts = (System.Int32)wrapProperty.getValue();
                        break;
                    case BoardOwnerMap.Property.map:
                        IdentityUtils.UpdateSyncList(this.map, syncs, GlobalCast<T>.CastingInt32);
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