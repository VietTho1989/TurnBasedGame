using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
    public class HexIdentity : DataIdentity
    {

        #region SyncVar

        #region boardSize

        [SyncVar(hook = "onChangeBoardSize")]
        public System.UInt16 boardSize;

        public void onChangeBoardSize(System.UInt16 newBoardSize)
        {
            this.boardSize = newBoardSize;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.boardSize.v = newBoardSize;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region board

        public SyncListSByte board = new SyncListSByte();

        private void OnBoardChanged(SyncListSByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.board, this.board, op, index, MySByte.sbyteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region isSwitch

        [SyncVar(hook = "onChangeIsSwitch")]
        public System.Boolean isSwitch;

        public void onChangeIsSwitch(System.Boolean newIsSwitch)
        {
            this.isSwitch = newIsSwitch;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isSwitch.v = newIsSwitch;
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

        #region playerIndex

        [SyncVar(hook = "onChangePlayerIndex")]
        public int playerIndex;

        public void onChangePlayerIndex(int newPlayerIndex)
        {
            this.playerIndex = newPlayerIndex;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.playerIndex.v = newPlayerIndex;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<Hex> netData = new NetData<Hex>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.board.Callback += OnBoardChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeBoardSize(this.boardSize);
                IdentityUtils.refresh(this.netData.clientData.board, this.board, MySByte.sbyteConvert);
                this.onChangeIsSwitch(this.isSwitch);
                this.onChangeIsCustom(this.isCustom);
                this.onChangePlayerIndex(this.playerIndex);
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
                ret += GetDataSize(this.boardSize);
                ret += GetDataSize(this.board);
                ret += GetDataSize(this.isSwitch);
                ret += GetDataSize(this.isCustom);
                ret += GetDataSize(this.playerIndex);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Hex)
            {
                Hex hex = data as Hex;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, hex.makeSearchInforms());
                    this.boardSize = hex.boardSize.v;
                    IdentityUtils.InitSync(this.board, hex.board, MySByte.mySByteConvert);
                    this.isSwitch = hex.isSwitch.v;
                    this.isCustom = hex.isCustom.v;
                    this.playerIndex = hex.playerIndex.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(hex);
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
            if (data is Hex)
            {
                // Hex hex = data as Hex;
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
            if (wrapProperty.p is Hex)
            {
                switch ((Hex.Property)wrapProperty.n)
                {
                    case Hex.Property.boardSize:
                        this.boardSize = (System.UInt16)wrapProperty.getValue();
                        break;
                    case Hex.Property.board:
                        IdentityUtils.UpdateSyncList(this.board, syncs, GlobalCast<T>.CastingMySByte);
                        break;
                    case Hex.Property.isSwitch:
                        this.isSwitch = (System.Boolean)wrapProperty.getValue();
                        break;
                    case Hex.Property.isCustom:
                        this.isCustom = (System.Boolean)wrapProperty.getValue();
                        break;
                    case Hex.Property.playerIndex:
                        this.playerIndex = (System.Int32)wrapProperty.getValue();
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