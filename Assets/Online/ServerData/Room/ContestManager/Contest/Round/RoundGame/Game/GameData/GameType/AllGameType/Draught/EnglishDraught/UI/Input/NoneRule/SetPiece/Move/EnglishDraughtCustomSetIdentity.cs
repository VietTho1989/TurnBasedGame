using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace EnglishDraught.NoneRule
{
    public class EnglishDraughtCustomSetIdentity : DataIdentity
    {

        #region SyncVar

        #region square

        [SyncVar(hook = "onChangeSquare")]
        public System.Int32 square;

        public void onChangeSquare(System.Int32 newSquare)
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
        public byte piece;

        public void onChangePiece(byte newPiece)
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

        private NetData<EnglishDraughtCustomSet> netData = new NetData<EnglishDraughtCustomSet>();

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
            if (data is EnglishDraughtCustomSet)
            {
                EnglishDraughtCustomSet englishDraughtCustomSet = data as EnglishDraughtCustomSet;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, englishDraughtCustomSet.makeSearchInforms());
                    this.square = englishDraughtCustomSet.square.v;
                    this.piece = englishDraughtCustomSet.piece.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(englishDraughtCustomSet);
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
            if (data is EnglishDraughtCustomSet)
            {
                // EnglishDraughtCustomSet englishDraughtCustomSet = data as EnglishDraughtCustomSet;
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
            if (wrapProperty.p is EnglishDraughtCustomSet)
            {
                switch ((EnglishDraughtCustomSet.Property)wrapProperty.n)
                {
                    case EnglishDraughtCustomSet.Property.square:
                        this.square = (System.Int32)wrapProperty.getValue();
                        break;
                    case EnglishDraughtCustomSet.Property.piece:
                        this.piece = (byte)wrapProperty.getValue();
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