using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace HEX.NoneRule
{
    public class HexCustomSetIdentity : DataIdentity
    {

        #region SyncVar

        #region square

        [SyncVar(hook = "onChangeSquare")]
        public ushort square;

        public void onChangeSquare(ushort newSquare)
        {
            this.square = newSquare;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.square.v = newSquare;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region piece

        [SyncVar(hook = "onChangePiece")]
        public Common.Color piece;

        public void onChangePiece(Common.Color newPiece)
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

        private NetData<HexCustomSet> netData = new NetData<HexCustomSet>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeSquare(this.square);
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
                ret += GetDataSize(this.square);
                ret += GetDataSize(this.piece);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is HexCustomSet)
            {
                HexCustomSet hexCustomSet = data as HexCustomSet;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, hexCustomSet.makeSearchInforms());
                    this.square = hexCustomSet.square.v;
                    this.piece = hexCustomSet.piece.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(hexCustomSet);
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
            if (data is HexCustomSet)
            {
                // HexCustomSet hexCustomSet = data as HexCustomSet;
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
            if (wrapProperty.p is HexCustomSet)
            {
                switch ((HexCustomSet.Property)wrapProperty.n)
                {
                    case HexCustomSet.Property.square:
                        this.square = (ushort)wrapProperty.getValue();
                        break;
                    case HexCustomSet.Property.piece:
                        this.piece = (Common.Color)wrapProperty.getValue();
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