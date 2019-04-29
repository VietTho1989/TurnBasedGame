using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace EnglishDraught
{
    public class EnglishDraughtMoveIdentity : DataIdentity
    {

        #region SyncVar

        #region SrcDst

        [SyncVar(hook = "onChangeSrcDst")]
        public System.UInt64 SrcDst;

        public void onChangeSrcDst(System.UInt64 newSrcDst)
        {
            this.SrcDst = newSrcDst;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.SrcDst.v = newSrcDst;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region cPath

        public SyncListByte cPath = new SyncListByte();

        private void OnCPathChanged(SyncListByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.cPath, this.cPath, op, index, MyByte.byteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #endregion

        #region NetData

        private NetData<EnglishDraughtMove> netData = new NetData<EnglishDraughtMove>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.cPath.Callback += OnCPathChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeSrcDst(this.SrcDst);
                IdentityUtils.refresh(this.netData.clientData.cPath, this.cPath, MyByte.byteConvert);
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
                ret += GetDataSize(this.SrcDst);
                ret += GetDataSize(this.cPath);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is EnglishDraughtMove)
            {
                EnglishDraughtMove englishDraughtMove = data as EnglishDraughtMove;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, englishDraughtMove.makeSearchInforms());
                    this.SrcDst = englishDraughtMove.SrcDst.v;
                    IdentityUtils.InitSync(this.cPath, englishDraughtMove.cPath, MyByte.myByteConvert);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(englishDraughtMove);
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
            if (data is EnglishDraughtMove)
            {
                // EnglishDraughtMove englishDraughtMove = data as EnglishDraughtMove;
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
            if (wrapProperty.p is EnglishDraughtMove)
            {
                switch ((EnglishDraughtMove.Property)wrapProperty.n)
                {
                    case EnglishDraughtMove.Property.SrcDst:
                        this.SrcDst = (System.UInt64)wrapProperty.getValue();
                        break;
                    case EnglishDraughtMove.Property.cPath:
                        IdentityUtils.UpdateSyncList(this.cPath, syncs, GlobalCast<T>.CastingMyByte);
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