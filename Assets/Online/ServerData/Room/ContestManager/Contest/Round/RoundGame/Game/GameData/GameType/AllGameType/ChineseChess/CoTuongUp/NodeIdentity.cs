using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace CoTuongUp
{
    public class NodeIdentity : DataIdentity
    {

        #region SyncVar

        #region ply

        [SyncVar(hook = "onChangePly")]
        public System.Int32 ply;

        public void onChangePly(System.Int32 newPly)
        {
            this.ply = newPly;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.ply.v = newPly;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region pieces

        public SyncListByte pieces = new SyncListByte();

        private void OnPiecesChanged(SyncListByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.pieces, this.pieces, op, index, MyByte.byteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region captures

        public SyncListByte captures = new SyncListByte();

        private void OnCapturesChanged(SyncListByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.captures, this.captures, op, index, MyByte.byteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #endregion

        #region NetData

        private NetData<Node> netData = new NetData<Node>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.pieces.Callback += OnPiecesChanged;
            this.captures.Callback += OnCapturesChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangePly(this.ply);
                IdentityUtils.refresh(this.netData.clientData.pieces, this.pieces, MyByte.byteConvert);
                IdentityUtils.refresh(this.netData.clientData.captures, this.captures, MyByte.byteConvert);
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
                ret += GetDataSize(this.ply);
                ret += GetDataSize(this.pieces);
                ret += GetDataSize(this.captures);
                return ret;
            }
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Node)
            {
                Node node = data as Node;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, node.makeSearchInforms());
                    this.ply = node.ply.v;
                    IdentityUtils.InitSync(this.pieces, node.pieces, MyByte.myByteConvert);
                    IdentityUtils.InitSync(this.captures, node.captures, MyByte.myByteConvert);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(node);
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
            if (data is Node)
            {
                // Node node = data as Node;
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
            if (wrapProperty.p is Node)
            {
                switch ((Node.Property)wrapProperty.n)
                {
                    case Node.Property.ply:
                        this.ply = (System.Int32)wrapProperty.getValue();
                        break;
                    case Node.Property.pieces:
                        IdentityUtils.UpdateSyncList(this.pieces, syncs, GlobalCast<T>.CastingMyByte);
                        break;
                    case Node.Property.captures:
                        IdentityUtils.UpdateSyncList(this.captures, syncs, GlobalCast<T>.CastingMyByte);
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