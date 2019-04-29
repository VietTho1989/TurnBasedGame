using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

namespace Solitaire
{
    public class CardIdentity : DataIdentity
    {

        #region SyncVar

        #region Suit

        [SyncVar(hook = "onChangeSuit")]
        public System.Byte Suit;

        public void onChangeSuit(System.Byte newSuit)
        {
            this.Suit = newSuit;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.Suit.v = newSuit;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region Rank

        [SyncVar(hook = "onChangeRank")]
        public System.Byte Rank;

        public void onChangeRank(System.Byte newRank)
        {
            this.Rank = newRank;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.Rank.v = newRank;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region IsOdd

        [SyncVar(hook = "onChangeIsOdd")]
        public System.Byte IsOdd;

        public void onChangeIsOdd(System.Byte newIsOdd)
        {
            this.IsOdd = newIsOdd;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.IsOdd.v = newIsOdd;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region IsRed

        [SyncVar(hook = "onChangeIsRed")]
        public System.Byte IsRed;

        public void onChangeIsRed(System.Byte newIsRed)
        {
            this.IsRed = newIsRed;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.IsRed.v = newIsRed;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region Foundation

        [SyncVar(hook = "onChangeFoundation")]
        public System.Byte Foundation;

        public void onChangeFoundation(System.Byte newFoundation)
        {
            this.Foundation = newFoundation;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.Foundation.v = newFoundation;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region Value

        [SyncVar(hook = "onChangeValue")]
        public System.Byte Value;

        public void onChangeValue(System.Byte newValue)
        {
            this.Value = newValue;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.Value.v = newValue;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<Card> netData = new NetData<Card>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeSuit(this.Suit);
                this.onChangeRank(this.Rank);
                this.onChangeIsOdd(this.IsOdd);
                this.onChangeIsRed(this.IsRed);
                this.onChangeFoundation(this.Foundation);
                this.onChangeValue(this.Value);
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
                ret += GetDataSize(this.Suit);
                ret += GetDataSize(this.Rank);
                ret += GetDataSize(this.IsOdd);
                ret += GetDataSize(this.IsRed);
                ret += GetDataSize(this.Foundation);
                ret += GetDataSize(this.Value);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Card)
            {
                Card card = data as Card;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, card.makeSearchInforms());
                    this.Suit = card.Suit.v;
                    this.Rank = card.Rank.v;
                    this.IsOdd = card.IsOdd.v;
                    this.IsRed = card.IsRed.v;
                    this.Foundation = card.Foundation.v;
                    this.Value = card.Value.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(card);
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
            if (data is Card)
            {
                // Card card = data as Card;
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
            if (wrapProperty.p is Card)
            {
                switch ((Card.Property)wrapProperty.n)
                {
                    case Card.Property.Suit:
                        this.Suit = (System.Byte)wrapProperty.getValue();
                        break;
                    case Card.Property.Rank:
                        this.Rank = (System.Byte)wrapProperty.getValue();
                        break;
                    case Card.Property.IsOdd:
                        this.IsOdd = (System.Byte)wrapProperty.getValue();
                        break;
                    case Card.Property.IsRed:
                        this.IsRed = (System.Byte)wrapProperty.getValue();
                        break;
                    case Card.Property.Foundation:
                        this.Foundation = (System.Byte)wrapProperty.getValue();
                        break;
                    case Card.Property.Value:
                        this.Value = (System.Byte)wrapProperty.getValue();
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