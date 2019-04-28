using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
    public class InternationalDraughtIdentity : DataIdentity
    {

        #region SyncVar

        #region node

        [SyncVar]
        public int node;

        #endregion

        #region lastMove

        [SyncVar(hook = "onChangeLastMove")]
        public System.UInt64 lastMove;

        public void onChangeLastMove(System.UInt64 newLastMove)
        {
            this.lastMove = newLastMove;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.lastMove.v = newLastMove;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

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

        #region captureSize

        [SyncVar(hook = "onChangeCaptureSize")]
        public System.Int32 captureSize;

        public void onChangeCaptureSize(System.Int32 newCaptureSize)
        {
            this.captureSize = newCaptureSize;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.captureSize.v = newCaptureSize;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region captureSquares

        public SyncListInt captureSquares = new SyncListInt();

        private void OnCaptureSquaresChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.captureSquares, this.captureSquares, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<InternationalDraught> netData = new NetData<InternationalDraught>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.captureSquares.Callback += OnCaptureSquaresChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeLastMove(this.lastMove);
                this.onChangePly(this.ply);
                this.onChangeCaptureSize(this.captureSize);
                IdentityUtils.refresh(this.netData.clientData.captureSquares, this.captureSquares);
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
                ret += GetDataSize(this.lastMove);
                ret += GetDataSize(this.ply);
                ret += GetDataSize(this.captureSize);
                ret += GetDataSize(this.captureSquares);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is InternationalDraught)
            {
                InternationalDraught internationalDraught = data as InternationalDraught;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, internationalDraught.makeSearchInforms());
                    this.node = internationalDraught.node.vs.Count;
                    this.lastMove = internationalDraught.lastMove.v;
                    this.ply = internationalDraught.ply.v;
                    this.captureSize = internationalDraught.captureSize.v;
                    IdentityUtils.InitSync(this.captureSquares, internationalDraught.captureSquares.vs);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(internationalDraught);
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
            if (data is InternationalDraught)
            {
                // InternationalDraught internationalDraught = data as InternationalDraught;
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
            if (wrapProperty.p is InternationalDraught)
            {
                switch ((InternationalDraught.Property)wrapProperty.n)
                {
                    case InternationalDraught.Property.node:
                        {
                            InternationalDraught internationalDraught = wrapProperty.p as InternationalDraught;
                            this.node = internationalDraught.node.vs.Count;
                        }
                        break;
                    case InternationalDraught.Property.var:
                        break;
                    case InternationalDraught.Property.lastMove:
                        this.lastMove = (System.UInt64)wrapProperty.getValue();
                        break;
                    case InternationalDraught.Property.ply:
                        this.ply = (System.Int32)wrapProperty.getValue();
                        break;
                    case InternationalDraught.Property.captureSize:
                        this.captureSize = (System.Int32)wrapProperty.getValue();
                        break;
                    case InternationalDraught.Property.captureSquares:
                        IdentityUtils.UpdateSyncList(this.captureSquares, syncs, GlobalCast<T>.CastingInt32);
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