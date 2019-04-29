using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Banqi.NoneRule
{
    public class BanqiCustomSetIdentity : DataIdentity
    {

        #region SyncVar

        #region x

        [SyncVar(hook = "onChangeX")]
        public System.Int32 x;

        public void onChangeX(System.Int32 newX)
        {
            this.x = newX;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.x.v = newX;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region y

        [SyncVar(hook = "onChangeY")]
        public System.Int32 y;

        public void onChangeY(System.Int32 newY)
        {
            this.y = newY;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.y.v = newY;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region color

        [SyncVar(hook = "onChangeColor")]
        public Token.Ecolor color;

        public void onChangeColor(Token.Ecolor newColor)
        {
            this.color = newColor;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.color.v = newColor;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region type

        [SyncVar(hook = "onChangeType")]
        public Token.Type type;

        public void onChangeType(Token.Type newType)
        {
            this.type = newType;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.type.v = newType;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region isFaceUp

        [SyncVar(hook = "onChangeIsFaceUp")]
        public System.Boolean isFaceUp;

        public void onChangeIsFaceUp(System.Boolean newIsFaceUp)
        {
            this.isFaceUp = newIsFaceUp;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isFaceUp.v = newIsFaceUp;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<BanqiCustomSet> netData = new NetData<BanqiCustomSet>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeX(this.x);
                this.onChangeY(this.y);
                this.onChangeColor(this.color);
                this.onChangeType(this.type);
                this.onChangeIsFaceUp(this.isFaceUp);
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
                ret += GetDataSize(this.x);
                ret += GetDataSize(this.y);
                ret += GetDataSize(this.color);
                ret += GetDataSize(this.type);
                ret += GetDataSize(this.isFaceUp);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is BanqiCustomSet)
            {
                BanqiCustomSet banqiCustomSet = data as BanqiCustomSet;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, banqiCustomSet.makeSearchInforms());
                    this.x = banqiCustomSet.x.v;
                    this.y = banqiCustomSet.y.v;
                    this.color = banqiCustomSet.color.v;
                    this.type = banqiCustomSet.type.v;
                    this.isFaceUp = banqiCustomSet.isFaceUp.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(banqiCustomSet);
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
            if (data is BanqiCustomSet)
            {
                // BanqiCustomSet banqiCustomSet = data as BanqiCustomSet;
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
            if (wrapProperty.p is BanqiCustomSet)
            {
                switch ((BanqiCustomSet.Property)wrapProperty.n)
                {
                    case BanqiCustomSet.Property.x:
                        this.x = (System.Int32)wrapProperty.getValue();
                        break;
                    case BanqiCustomSet.Property.y:
                        this.y = (System.Int32)wrapProperty.getValue();
                        break;
                    case BanqiCustomSet.Property.color:
                        this.color = (Token.Ecolor)wrapProperty.getValue();
                        break;
                    case BanqiCustomSet.Property.type:
                        this.type = (Token.Type)wrapProperty.getValue();
                        break;
                    case BanqiCustomSet.Property.isFaceUp:
                        this.isFaceUp = (System.Boolean)wrapProperty.getValue();
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