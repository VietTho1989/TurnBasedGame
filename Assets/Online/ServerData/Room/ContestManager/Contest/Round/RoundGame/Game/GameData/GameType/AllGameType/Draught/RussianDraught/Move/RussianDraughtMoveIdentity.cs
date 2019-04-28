using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
{
    public class RussianDraughtMoveIdentity : DataIdentity
    {

        #region SyncVar

        #region m

        public SyncListUShort m = new SyncListUShort();

        private void OnMChanged(SyncListUShort.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.m, this.m, op, index, MyUShort.ushortConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region path

        public SyncListByte path = new SyncListByte();

        private void OnPathChanged(SyncListByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.path, this.path, op, index, MyByte.byteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region l

        [SyncVar(hook = "onChangeL")]
        public System.Byte l;

        public void onChangeL(System.Byte newL)
        {
            this.l = newL;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.l.v = newL;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<RussianDraughtMove> netData = new NetData<RussianDraughtMove>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.m.Callback += OnMChanged;
            this.path.Callback += OnPathChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.m, this.m, MyUShort.ushortConvert);
                IdentityUtils.refresh(this.netData.clientData.path, this.path, MyByte.byteConvert);
                this.onChangeL(this.l);
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
                ret += GetDataSize(this.m);
                ret += GetDataSize(this.path);
                ret += GetDataSize(this.l);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is RussianDraughtMove)
            {
                RussianDraughtMove russianDraughtMove = data as RussianDraughtMove;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, russianDraughtMove.makeSearchInforms());
                    IdentityUtils.InitSync(this.m, russianDraughtMove.m, MyUShort.myUShortConvert);
                    IdentityUtils.InitSync(this.path, russianDraughtMove.path, MyByte.myByteConvert);
                    this.l = russianDraughtMove.l.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(russianDraughtMove);
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
            if (data is RussianDraughtMove)
            {
                // RussianDraughtMove russianDraughtMove = data as RussianDraughtMove;
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
            if (wrapProperty.p is RussianDraughtMove)
            {
                switch ((RussianDraughtMove.Property)wrapProperty.n)
                {
                    case RussianDraughtMove.Property.m:
                        IdentityUtils.UpdateSyncList(this.m, syncs, GlobalCast<T>.CastingMyUShort);
                        break;
                    case RussianDraughtMove.Property.path:
                        IdentityUtils.UpdateSyncList(this.path, syncs, GlobalCast<T>.CastingMyByte);
                        break;
                    case RussianDraughtMove.Property.l:
                        this.l = (System.Byte)wrapProperty.getValue();
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