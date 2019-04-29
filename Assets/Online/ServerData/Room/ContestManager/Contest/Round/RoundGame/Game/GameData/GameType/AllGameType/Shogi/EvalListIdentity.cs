using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Shogi
{
    public class EvalListIdentity : DataIdentity
    {

        #region SyncVar

        #region list0

        public SyncListInt list0 = new SyncListInt();

        private void OnList0Changed(SyncList<int>.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.list0, this.list0, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region list1

        public SyncListInt list1 = new SyncListInt();

        private void OnList1Changed(SyncList<int>.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.list1, this.list1, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region listToSquareHand

        public SyncListInt listToSquareHand = new SyncListInt();

        private void OnListToSquareHandChanged(SyncList<int>.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.listToSquareHand, this.listToSquareHand, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region squareHandToList

        public SyncListInt squareHandToList = new SyncListInt();

        private void OnSquareHandToListChanged(SyncList<System.Int32>.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.squareHandToList, this.squareHandToList, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<EvalList> netData = new NetData<EvalList>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.list0.Callback += OnList0Changed;
            this.list1.Callback += OnList1Changed;
            this.listToSquareHand.Callback += OnListToSquareHandChanged;
            this.squareHandToList.Callback += OnSquareHandToListChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.list0, this.list0);
                IdentityUtils.refresh(this.netData.clientData.list1, this.list1);
                IdentityUtils.refresh(this.netData.clientData.listToSquareHand, this.listToSquareHand);
                IdentityUtils.refresh(this.netData.clientData.squareHandToList, this.squareHandToList);
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
                ret += GetDataSize(this.list0);
                ret += GetDataSize(this.list1);
                ret += GetDataSize(this.listToSquareHand);
                ret += GetDataSize(this.squareHandToList);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is EvalList)
            {
                EvalList evalList = data as EvalList;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, evalList.makeSearchInforms());
                    IdentityUtils.InitSync(this.list0, evalList.list0.vs);
                    IdentityUtils.InitSync(this.list1, evalList.list1.vs);
                    IdentityUtils.InitSync(this.listToSquareHand, evalList.listToSquareHand.vs);
                    IdentityUtils.InitSync(this.squareHandToList, evalList.squareHandToList.vs);
                }
                this.getDataSize();
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(evalList);
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
            if (data is EvalList)
            {
                // EvalList evalList = data as EvalList;
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
            if (wrapProperty.p is EvalList)
            {
                switch ((EvalList.Property)wrapProperty.n)
                {
                    case EvalList.Property.list0:
                        IdentityUtils.UpdateSyncList(this.list0, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case EvalList.Property.list1:
                        IdentityUtils.UpdateSyncList(this.list1, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case EvalList.Property.listToSquareHand:
                        IdentityUtils.UpdateSyncList(this.listToSquareHand, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case EvalList.Property.squareHandToList:
                        IdentityUtils.UpdateSyncList(this.squareHandToList, syncs, GlobalCast<T>.CastingInt32);
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