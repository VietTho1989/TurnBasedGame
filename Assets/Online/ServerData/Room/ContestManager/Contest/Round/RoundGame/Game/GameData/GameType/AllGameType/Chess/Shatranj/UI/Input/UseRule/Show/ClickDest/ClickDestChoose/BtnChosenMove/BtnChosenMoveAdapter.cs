using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace Shatranj.UseRule
{
    public class BtnChosenMoveAdapter : SRIA<BtnChosenMoveAdapter.UIData, BtnChosenMoveHolder.UIData>
    {

        #region UIData

        [Serializable]
        public class UIData : BaseParams
        {

            public LP<BtnChosenMoveHolder.UIData> holders;

            public LP<ReferenceData<ShatranjMove>> moves;

            public VP<BtnChosenMoveHolder.OnClick> onClick;

            #region Constructor

            public enum Property
            {
                holders,
                moves,
                onClick
            }

            public UIData() : base()
            {
                this.holders = new LP<BtnChosenMoveHolder.UIData>(this, (byte)Property.holders);
                this.moves = new LP<ReferenceData<ShatranjMove>>(this, (byte)Property.moves);
                this.onClick = new VP<BtnChosenMoveHolder.OnClick>(this, (byte)Property.onClick, null);
            }

            #endregion

            [NonSerialized]
            public List<ShatranjMove> shatranjMoves = new List<ShatranjMove>();

            public void reset()
            {
                this.shatranjMoves.Clear();
            }

        }

        #endregion

        #region Adapter

        public BtnChosenMoveHolder holderPrefab;

        protected override BtnChosenMoveHolder.UIData CreateViewsHolder(int itemIndex)
        {
            BtnChosenMoveHolder.UIData uiData = new BtnChosenMoveHolder.UIData();
            {
                // add
                {
                    uiData.uid = this.data.holders.makeId();
                    this.data.holders.add(uiData);
                }
                // MakeUI
                if (holderPrefab != null)
                {
                    uiData.Init(holderPrefab.gameObject, itemIndex);
                    uiData.onClick.v = this.data.onClick.v;
                }
                else
                {
                    Debug.LogError("holderPrefab null: " + this);
                }
            }
            return uiData;
        }

        protected override void UpdateViewsHolder(BtnChosenMoveHolder.UIData newOrRecycled)
        {
            newOrRecycled.updateView(_Params);
        }

        #endregion

        #region txt

        public Text tvNoMoves;
        private static readonly TxtLanguage txtNoMoves = new TxtLanguage("Don't have any moves");

        static BtnChosenMoveAdapter()
        {
            txtNoMoves.add(Language.Type.vi, "Không có nước đi nào cả");
        }

        #endregion

        #region Refresh

        public GameObject noMoves;

        public override void refresh()
        {
            if (dirty)
            {
                if (this.Initialized)
                {
                    dirty = false;
                    if (this.data != null)
                    {
                        List<ShatranjMove> shatranjMoves = new List<ShatranjMove>();
                        // get
                        {
                            foreach (ReferenceData<ShatranjMove> move in this.data.moves.vs)
                            {
                                shatranjMoves.Add(move.data);
                            }
                        }
                        // Make list
                        {
                            int min = Mathf.Min(shatranjMoves.Count, _Params.shatranjMoves.Count);
                            // Update
                            {
                                for (int i = 0; i < min; i++)
                                {
                                    if (shatranjMoves[i] != _Params.shatranjMoves[i])
                                    {
                                        // change param
                                        _Params.shatranjMoves[i] = shatranjMoves[i];
                                        // Update holder
                                        foreach (BtnChosenMoveHolder.UIData holder in this.data.holders.vs)
                                        {
                                            if (holder.ItemIndex == i)
                                            {
                                                holder.shatranjMove.v = new ReferenceData<ShatranjMove>(shatranjMoves[i]);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            // Add or Remove
                            {
                                if (shatranjMoves.Count > min)
                                {
                                    // Add
                                    int insertCount = shatranjMoves.Count - min;
                                    List<ShatranjMove> addItems = shatranjMoves.GetRange(min, insertCount);
                                    _Params.shatranjMoves.AddRange(addItems);
                                    InsertItems(min, insertCount, false, false);
                                }
                                else
                                {
                                    // Remove
                                    int deleteCount = _Params.shatranjMoves.Count - min;
                                    if (deleteCount > 0)
                                    {
                                        RemoveItems(min, deleteCount, false, false);
                                        _Params.shatranjMoves.RemoveRange(min, deleteCount);
                                    }
                                }
                            }
                        }
                        // NoMoves
                        {
                            if (noMoves != null)
                            {
                                bool haveAny = false;
                                {
                                    foreach (BtnChosenMoveHolder.UIData holder in this.data.holders.vs)
                                    {
                                        BtnChosenMoveHolder holderUI = holder.findCallBack<BtnChosenMoveHolder>();
                                        if (holderUI != null)
                                        {
                                            if (holderUI.gameObject.activeSelf)
                                            {
                                                haveAny = true;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("holderUI null: " + this);
                                        }
                                    }
                                }
                                noMoves.SetActive(!haveAny);
                            }
                            else
                            {
                                Debug.LogError("noMoves null: " + this);
                            }
                        }
                        // onClick
                        {
                            foreach (BtnChosenMoveHolder.UIData holder in this.data.holders.vs)
                            {
                                holder.onClick.v = this.data.onClick.v;
                            }
                        }
                        // txt
                        {
                            if (tvNoMoves != null)
                            {
                                tvNoMoves.text = txtNoMoves.get();
                            }
                            else
                            {
                                Debug.LogError("tvNoMoves null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError("not initalized: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                Setting.get().addCallBack(this);
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().removeCallBack(this);
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
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
            if (wrapProperty.p is UIData)
            {
                switch ((UIData.Property)wrapProperty.n)
                {
                    case UIData.Property.holders:
                        break;
                    case UIData.Property.moves:
                        dirty = true;
                        break;
                    case UIData.Property.onClick:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Setting
            if (wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        dirty = true;
                        break;
                    case Setting.Property.style:
                        break;
                    case Setting.Property.contentTextSize:
                        break;
                    case Setting.Property.titleTextSize:
                        break;
                    case Setting.Property.labelTextSize:
                        break;
                    case Setting.Property.buttonSize:
                        break;
                    case Setting.Property.itemSize:
                        break;
                    case Setting.Property.confirmQuit:
                        break;
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    case Setting.Property.defaultChosenGame:
                        break;
                    case Setting.Property.defaultRoomName:
                        break;
                    case Setting.Property.defaultChatRoomStyle:
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