using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace ChineseCheckers
{
    public class ChineseCheckersIdentity : DataIdentity
    {

        #region SyncVar

        #region _squares

        public SyncListByte _squares = new SyncListByte();

        private void On_squaresChanged(SyncListByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData._squares, this._squares, op, index, MyByte.byteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region _turn

        [SyncVar(hook = "onChange_turn")]
        public System.Byte _turn;

        public void onChange_turn(System.Byte new_turn)
        {
            this._turn = new_turn;
            if (this.netData.clientData != null)
            {
                this.netData.clientData._turn.v = new_turn;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region isCustom

        [SyncVar(hook = "onChangeIsCustom")]
        public System.Boolean isCustom;

        public void onChangeIsCustom(System.Boolean newIsCustom)
        {
            this.isCustom = newIsCustom;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isCustom.v = newIsCustom;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<ChineseCheckers> netData = new NetData<ChineseCheckers>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this._squares.Callback += On_squaresChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData._squares, this._squares, MyByte.byteConvert);
                this.onChange_turn(this._turn);
                this.onChangeIsCustom(this.isCustom);
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
                ret += GetDataSize(this._squares);
                ret += GetDataSize(this._turn);
                ret += GetDataSize(this.isCustom);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is ChineseCheckers)
            {
                ChineseCheckers chineseCheckers = data as ChineseCheckers;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, chineseCheckers.makeSearchInforms());
                    IdentityUtils.InitSync(this._squares, chineseCheckers._squares, MyByte.myByteConvert);
                    this._turn = chineseCheckers._turn.v;
                    this.isCustom = chineseCheckers.isCustom.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(chineseCheckers);
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
            if (data is ChineseCheckers)
            {
                // ChineseCheckers chineseCheckers = data as ChineseCheckers;
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
            if (wrapProperty.p is ChineseCheckers)
            {
                switch ((ChineseCheckers.Property)wrapProperty.n)
                {
                    case ChineseCheckers.Property._squares:
                        IdentityUtils.UpdateSyncList(this._squares, syncs, GlobalCast<T>.CastingMyByte);
                        break;
                    case ChineseCheckers.Property._turn:
                        this._turn = (System.Byte)wrapProperty.getValue();
                        break;
                    case ChineseCheckers.Property.isCustom:
                        this.isCustom = (System.Boolean)wrapProperty.getValue();
                        break;
                    default:
                        Debug.LogError("Unknown wrapProperty: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}