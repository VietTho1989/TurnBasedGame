using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace EnglishDraught
{
    public class EnglishDraughtIdentity : DataIdentity
    {

        #region SyncVar

        #region Sqs

        public SyncListByte Sqs = new SyncListByte();

        private void OnSqsChanged(SyncListByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.Sqs, this.Sqs, op, index, MyByte.byteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region nPSq

        [SyncVar(hook = "onChangeNPSq")]
        public System.Int16 nPSq;

        public void onChangeNPSq(System.Int16 newNPSq)
        {
            this.nPSq = newNPSq;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.nPSq.v = newNPSq;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region eval

        [SyncVar(hook = "onChangeEval")]
        public System.Int16 eval;

        public void onChangeEval(System.Int16 newEval)
        {
            this.eval = newEval;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.eval.v = newEval;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region nWhite

        [SyncVar(hook = "onChangeNWhite")]
        public System.Byte nWhite;

        public void onChangeNWhite(System.Byte newNWhite)
        {
            this.nWhite = newNWhite;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.nWhite.v = newNWhite;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region nBlack

        [SyncVar(hook = "onChangeNBlack")]
        public System.Byte nBlack;

        public void onChangeNBlack(System.Byte newNBlack)
        {
            this.nBlack = newNBlack;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.nBlack.v = newNBlack;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region SideToMove

        [SyncVar(hook = "onChangeSideToMove")]
        public System.Byte SideToMove;

        public void onChangeSideToMove(System.Byte newSideToMove)
        {
            this.SideToMove = newSideToMove;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.SideToMove.v = newSideToMove;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region extra

        [SyncVar(hook = "onChangeExtra")]
        public System.Byte extra;

        public void onChangeExtra(System.Byte newExtra)
        {
            this.extra = newExtra;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.extra.v = newExtra;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region HashKey

        [SyncVar(hook = "onChangeHashKey")]
        public System.UInt64 HashKey;

        public void onChangeHashKey(System.UInt64 newHashKey)
        {
            this.HashKey = newHashKey;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.HashKey.v = newHashKey;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region ply

        [SyncVar(hook = "onChangePly")]
        public System.UInt32 ply;

        public void onChangePly(System.UInt32 newPly)
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

        #region RepNum

        public SyncListInt64 RepNum = new SyncListInt64();

        private void OnRepNumChanged(SyncListInt64.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.RepNum, this.RepNum, op, index, MyInt64.longConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region maxPly

        [SyncVar(hook = "onChangeMaxPly")]
        public System.UInt32 maxPly;

        public void onChangeMaxPly(System.UInt32 newMaxPly)
        {
            this.maxPly = newMaxPly;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.maxPly.v = newMaxPly;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region turn

        [SyncVar(hook = "onChangeTurn")]
        public System.UInt32 turn;

        public void onChangeTurn(System.UInt32 newTurn)
        {
            this.turn = newTurn;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.turn.v = newTurn;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region isCustom

        [SyncVar(hook = "onChangeIsCustom")]
        public bool isCustom;

        public void onChangeIsCustom(bool newIsCustom)
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

        private NetData<EnglishDraught> netData = new NetData<EnglishDraught>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.Sqs.Callback += OnSqsChanged;
            this.RepNum.Callback += OnRepNumChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.Sqs, this.Sqs, MyByte.byteConvert);
                this.onChangeNPSq(this.nPSq);
                this.onChangeEval(this.eval);
                this.onChangeNWhite(this.nWhite);
                this.onChangeNBlack(this.nBlack);
                this.onChangeSideToMove(this.SideToMove);
                this.onChangeExtra(this.extra);
                this.onChangeHashKey(this.HashKey);
                this.onChangePly(this.ply);
                IdentityUtils.refresh(this.netData.clientData.RepNum, this.RepNum, MyInt64.longConvert);
                this.onChangeMaxPly(this.maxPly);
                this.onChangeTurn(this.turn);
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
                ret += GetDataSize(this.Sqs);
                ret += GetDataSize(this.nPSq);
                ret += GetDataSize(this.eval);
                ret += GetDataSize(this.nWhite);
                ret += GetDataSize(this.nBlack);
                ret += GetDataSize(this.SideToMove);
                ret += GetDataSize(this.extra);
                ret += GetDataSize(this.HashKey);
                ret += GetDataSize(this.ply);
                ret += GetDataSize(this.RepNum);
                ret += GetDataSize(this.maxPly);
                ret += GetDataSize(this.turn);
                ret += GetDataSize(this.isCustom);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is EnglishDraught)
            {
                EnglishDraught englishDraught = data as EnglishDraught;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, englishDraught.makeSearchInforms());
                    IdentityUtils.InitSync(this.Sqs, englishDraught.Sqs, MyByte.myByteConvert);
                    this.nPSq = englishDraught.nPSq.v;
                    this.eval = englishDraught.eval.v;
                    this.nWhite = englishDraught.nWhite.v;
                    this.nBlack = englishDraught.nBlack.v;
                    this.SideToMove = englishDraught.SideToMove.v;
                    this.extra = englishDraught.extra.v;
                    this.HashKey = englishDraught.HashKey.v;
                    this.ply = englishDraught.ply.v;
                    IdentityUtils.InitSync(this.RepNum, englishDraught.RepNum, MyInt64.myInt64Convert);
                    this.maxPly = englishDraught.maxPly.v;
                    this.turn = englishDraught.turn.v;
                    this.isCustom = englishDraught.isCustom.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(englishDraught);
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
            if (data is EnglishDraught)
            {
                // EnglishDraught englishDraught = data as EnglishDraught;
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
            if (wrapProperty.p is EnglishDraught)
            {
                switch ((EnglishDraught.Property)wrapProperty.n)
                {
                    case EnglishDraught.Property.Sqs:
                        IdentityUtils.UpdateSyncList(this.Sqs, syncs, GlobalCast<T>.CastingMyByte);
                        break;
                    case EnglishDraught.Property.C:
                        break;
                    case EnglishDraught.Property.nPSq:
                        this.nPSq = (System.Int16)wrapProperty.getValue();
                        break;
                    case EnglishDraught.Property.eval:
                        this.eval = (System.Int16)wrapProperty.getValue();
                        break;
                    case EnglishDraught.Property.nWhite:
                        this.nWhite = (System.Byte)wrapProperty.getValue();
                        break;
                    case EnglishDraught.Property.nBlack:
                        this.nBlack = (System.Byte)wrapProperty.getValue();
                        break;
                    case EnglishDraught.Property.SideToMove:
                        this.SideToMove = (System.Byte)wrapProperty.getValue();
                        break;
                    case EnglishDraught.Property.extra:
                        this.extra = (System.Byte)wrapProperty.getValue();
                        break;
                    case EnglishDraught.Property.HashKey:
                        this.HashKey = (System.UInt64)wrapProperty.getValue();
                        break;
                    case EnglishDraught.Property.ply:
                        this.ply = (System.UInt32)wrapProperty.getValue();
                        break;
                    case EnglishDraught.Property.RepNum:
                        IdentityUtils.UpdateSyncList(this.RepNum, syncs, GlobalCast<T>.CastingMyInt64);
                        break;
                    case EnglishDraught.Property.maxPly:
                        this.maxPly = (System.UInt32)wrapProperty.getValue();
                        break;
                    case EnglishDraught.Property.turn:
                        this.turn = (System.UInt32)wrapProperty.getValue();
                        break;
                    case EnglishDraught.Property.isCustom:
                        this.isCustom = (bool)wrapProperty.getValue();
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