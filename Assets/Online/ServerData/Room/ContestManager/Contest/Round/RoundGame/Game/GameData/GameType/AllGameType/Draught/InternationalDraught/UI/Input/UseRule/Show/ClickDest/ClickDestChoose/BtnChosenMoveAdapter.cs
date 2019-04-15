using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace InternationalDraught.UseRule
{
    public class BtnChosenMoveAdapter : SRIA<BtnChosenMoveAdapter.UIData, BtnChosenMoveHolder.UIData>
    {

        #region UIData

        [Serializable]
        public class UIData : BaseParams
        {

            public LP<BtnChosenMoveHolder.UIData> holders;

            public LP<ReferenceData<InternationalDraughtMove>> moves;

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
                this.moves = new LP<ReferenceData<InternationalDraughtMove>>(this, (byte)Property.moves);
                this.onClick = new VP<BtnChosenMoveHolder.OnClick>(this, (byte)Property.onClick, null);
            }

            #endregion

            [NonSerialized]
            public List<InternationalDraughtMove> internationalDraughtMoves = new List<InternationalDraughtMove>();

            public void reset()
            {
                this.internationalDraughtMoves.Clear();
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
                        List<InternationalDraughtMove> internationalDraughtMoves = new List<InternationalDraughtMove>();
                        // get
                        {
                            foreach (ReferenceData<InternationalDraughtMove> move in this.data.moves.vs)
                            {
                                internationalDraughtMoves.Add(move.data);
                            }
                        }
                        // Make list
                        {
                            int min = Mathf.Min(internationalDraughtMoves.Count, _Params.internationalDraughtMoves.Count);
                            // Update
                            {
                                for (int i = 0; i < min; i++)
                                {
                                    if (internationalDraughtMoves[i] != _Params.internationalDraughtMoves[i])
                                    {
                                        // change param
                                        _Params.internationalDraughtMoves[i] = internationalDraughtMoves[i];
                                        // Update holder
                                        foreach (BtnChosenMoveHolder.UIData holder in this.data.holders.vs)
                                        {
                                            if (holder.ItemIndex == i)
                                            {
                                                holder.internationalDraughtMove.v = new ReferenceData<InternationalDraughtMove>(internationalDraughtMoves[i]);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            // Add or Remove
                            {
                                if (internationalDraughtMoves.Count > min)
                                {
                                    // Add
                                    int insertCount = internationalDraughtMoves.Count - min;
                                    List<InternationalDraughtMove> addItems = internationalDraughtMoves.GetRange(min, insertCount);
                                    _Params.internationalDraughtMoves.AddRange(addItems);
                                    InsertItems(min, insertCount, false, false);
                                }
                                else
                                {
                                    // Remove
                                    int deleteCount = _Params.internationalDraughtMoves.Count - min;
                                    if (deleteCount > 0)
                                    {
                                        RemoveItems(min, deleteCount, false, false);
                                        _Params.internationalDraughtMoves.RemoveRange(min, deleteCount);
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