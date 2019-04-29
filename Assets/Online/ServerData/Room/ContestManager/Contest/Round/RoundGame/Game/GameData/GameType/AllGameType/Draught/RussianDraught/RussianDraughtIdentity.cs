using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace RussianDraught
{
    public class RussianDraughtIdentity : DataIdentity
    {

        #region SyncVar

        #region Board

        public SyncListInt Board = new SyncListInt();

        private void OnBoardChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.Board, this.Board, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region num_wpieces

        [SyncVar(hook = "onChangeNum_wpieces")]
        public System.UInt32 num_wpieces;

        public void onChangeNum_wpieces(System.UInt32 newNum_wpieces)
        {
            this.num_wpieces = newNum_wpieces;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.num_wpieces.v = newNum_wpieces;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region num_bpieces

        [SyncVar(hook = "onChangeNum_bpieces")]
        public System.UInt32 num_bpieces;

        public void onChangeNum_bpieces(System.UInt32 newNum_bpieces)
        {
            this.num_bpieces = newNum_bpieces;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.num_bpieces.v = newNum_bpieces;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region Color

        [SyncVar(hook = "onChangeColor")]
        public System.Int32 Color;

        public void onChangeColor(System.Int32 newColor)
        {
            this.Color = newColor;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.Color.v = newColor;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region g_root_mb

        [SyncVar(hook = "onChangeG_root_mb")]
        public System.Int32 g_root_mb;

        public void onChangeG_root_mb(System.Int32 newG_root_mb)
        {
            this.g_root_mb = newG_root_mb;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.g_root_mb.v = newG_root_mb;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region realdepth

        [SyncVar(hook = "onChangeRealdepth")]
        public System.Int32 realdepth;

        public void onChangeRealdepth(System.Int32 newRealdepth)
        {
            this.realdepth = newRealdepth;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.realdepth.v = newRealdepth;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region RepNum

        public SyncListUInt64 RepNum = new SyncListUInt64();

        private void OnRepNumChanged(SyncListUInt64.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.RepNum, this.RepNum, op, index, MyUInt64.uLongConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region HASH_KEY

        [SyncVar(hook = "onChangeHASH_KEY")]
        public System.UInt64 HASH_KEY;

        public void onChangeHASH_KEY(System.UInt64 newHASH_KEY)
        {
            this.HASH_KEY = newHASH_KEY;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.HASH_KEY.v = newHASH_KEY;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region p_list

        public SyncListUInt p_list = new SyncListUInt();

        private void OnP_listChanged(SyncListUInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.p_list, this.p_list, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region indices

        public SyncListUInt indices = new SyncListUInt();

        private void OnIndicesChanged(SyncListUInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.indices, this.indices, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region g_pieces

        public SyncListInt g_pieces = new SyncListInt();

        private void OnG_piecesChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.g_pieces, this.g_pieces, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region Reversible

        public SyncListBool Reversible = new SyncListBool();

        private void OnReversibleChanged(SyncListBool.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.Reversible, this.Reversible, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region c_num

        public SyncListUInt c_num = new SyncListUInt();

        private void OnC_numChanged(SyncListUInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.c_num, this.c_num, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
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

        private NetData<RussianDraught> netData = new NetData<RussianDraught>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.Board.Callback += OnBoardChanged;
            this.RepNum.Callback += OnRepNumChanged;
            this.p_list.Callback += OnP_listChanged;
            this.indices.Callback += OnIndicesChanged;
            this.g_pieces.Callback += OnG_piecesChanged;
            this.Reversible.Callback += OnReversibleChanged;
            this.c_num.Callback += OnC_numChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.Board, this.Board);
                this.onChangeNum_wpieces(this.num_wpieces);
                this.onChangeNum_bpieces(this.num_bpieces);
                this.onChangeColor(this.Color);
                this.onChangeG_root_mb(this.g_root_mb);
                this.onChangeRealdepth(this.realdepth);
                IdentityUtils.refresh(this.netData.clientData.RepNum, this.RepNum, MyUInt64.uLongConvert);
                this.onChangeHASH_KEY(this.HASH_KEY);
                IdentityUtils.refresh(this.netData.clientData.p_list, this.p_list);
                IdentityUtils.refresh(this.netData.clientData.indices, this.indices);
                IdentityUtils.refresh(this.netData.clientData.g_pieces, this.g_pieces);
                IdentityUtils.refresh(this.netData.clientData.Reversible, this.Reversible);
                IdentityUtils.refresh(this.netData.clientData.c_num, this.c_num);
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
                ret += GetDataSize(this.Board);
                ret += GetDataSize(this.num_wpieces);
                ret += GetDataSize(this.num_bpieces);
                ret += GetDataSize(this.Color);
                ret += GetDataSize(this.g_root_mb);
                ret += GetDataSize(this.realdepth);
                ret += GetDataSize(this.RepNum);
                ret += GetDataSize(this.HASH_KEY);
                ret += GetDataSize(this.p_list);
                ret += GetDataSize(this.indices);
                ret += GetDataSize(this.g_pieces);
                ret += GetDataSize(this.Reversible);
                ret += GetDataSize(this.c_num);
                ret += GetDataSize(this.isCustom);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is RussianDraught)
            {
                RussianDraught russianDraught = data as RussianDraught;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, russianDraught.makeSearchInforms());
                    IdentityUtils.InitSync(this.Board, russianDraught.Board.vs);
                    this.num_wpieces = russianDraught.num_wpieces.v;
                    this.num_bpieces = russianDraught.num_bpieces.v;
                    this.Color = russianDraught.Color.v;
                    this.g_root_mb = russianDraught.g_root_mb.v;
                    this.realdepth = russianDraught.realdepth.v;
                    IdentityUtils.InitSync(this.RepNum, russianDraught.RepNum, MyUInt64.myUInt64Convert);
                    this.HASH_KEY = russianDraught.HASH_KEY.v;
                    IdentityUtils.InitSync(this.p_list, russianDraught.p_list.vs);
                    IdentityUtils.InitSync(this.indices, russianDraught.indices.vs);
                    IdentityUtils.InitSync(this.g_pieces, russianDraught.g_pieces.vs);
                    IdentityUtils.InitSync(this.Reversible, russianDraught.Reversible.vs);
                    IdentityUtils.InitSync(this.c_num, russianDraught.c_num.vs);
                    this.isCustom = russianDraught.isCustom.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(russianDraught);
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
            if (data is RussianDraught)
            {
                // RussianDraught russianDraught = data as RussianDraught;
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
            if (wrapProperty.p is RussianDraught)
            {
                switch ((RussianDraught.Property)wrapProperty.n)
                {
                    case RussianDraught.Property.Board:
                        IdentityUtils.UpdateSyncList(this.Board, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case RussianDraught.Property.num_wpieces:
                        this.num_wpieces = (System.UInt32)wrapProperty.getValue();
                        break;
                    case RussianDraught.Property.num_bpieces:
                        this.num_bpieces = (System.UInt32)wrapProperty.getValue();
                        break;
                    case RussianDraught.Property.Color:
                        this.Color = (System.Int32)wrapProperty.getValue();
                        break;
                    case RussianDraught.Property.g_root_mb:
                        this.g_root_mb = (System.Int32)wrapProperty.getValue();
                        break;
                    case RussianDraught.Property.realdepth:
                        this.realdepth = (System.Int32)wrapProperty.getValue();
                        break;
                    case RussianDraught.Property.RepNum:
                        IdentityUtils.UpdateSyncList(this.RepNum, syncs, GlobalCast<T>.CastingMyUInt64);
                        break;
                    case RussianDraught.Property.HASH_KEY:
                        this.HASH_KEY = (System.UInt64)wrapProperty.getValue();
                        break;
                    case RussianDraught.Property.p_list:
                        IdentityUtils.UpdateSyncList(this.p_list, syncs, GlobalCast<T>.CastingUInt32);
                        break;
                    case RussianDraught.Property.indices:
                        IdentityUtils.UpdateSyncList(this.indices, syncs, GlobalCast<T>.CastingUInt32);
                        break;
                    case RussianDraught.Property.g_pieces:
                        IdentityUtils.UpdateSyncList(this.g_pieces, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case RussianDraught.Property.Reversible:
                        IdentityUtils.UpdateSyncList(this.Reversible, syncs, GlobalCast<T>.CastingBool);
                        break;
                    case RussianDraught.Property.c_num:
                        IdentityUtils.UpdateSyncList(this.c_num, syncs, GlobalCast<T>.CastingUInt32);
                        break;
                    case RussianDraught.Property.isCustom:
                        this.isCustom = (bool)wrapProperty.getValue();
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