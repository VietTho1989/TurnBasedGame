using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Seirawan.NoneRule
{
    public class SeirawanCustomHandIdentity : DataIdentity
    {

        #region SyncVar

        #region piece

        [SyncVar(hook = "onChangePiece")]
        public Common.Piece piece;

        public void onChangePiece(Common.Piece newPiece)
        {
            this.piece = newPiece;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.piece.v = newPiece;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<SeirawanCustomHand> netData = new NetData<SeirawanCustomHand>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangePiece(this.piece);
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
                ret += GetDataSize(this.piece);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is SeirawanCustomHand)
            {
                SeirawanCustomHand seirawanCustomHand = data as SeirawanCustomHand;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, seirawanCustomHand.makeSearchInforms());
                    this.piece = seirawanCustomHand.piece.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(seirawanCustomHand);
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
            if (data is SeirawanCustomHand)
            {
                // SeirawanCustomHand seirawanCustomHand = data as SeirawanCustomHand;
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
            if (wrapProperty.p is SeirawanCustomHand)
            {
                switch ((SeirawanCustomHand.Property)wrapProperty.n)
                {
                    case SeirawanCustomHand.Property.piece:
                        this.piece = (Common.Piece)wrapProperty.getValue();
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