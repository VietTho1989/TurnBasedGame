using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace RequestBlindFold
{
    public class WhoAskAdapter : SRIA<WhoAskAdapter.UIData, WhoAskHolder.UIData>
    {

        #region UIData

        [Serializable]
        public class UIData : BaseParams
        {

            public VP<ReferenceData<RequestChangeBlindFoldStateAsk>> requestChangeBlindFoldStateAsk;

            public LP<WhoAskHolder.UIData> holders;

            #region Constructor

            public enum Property
            {
                requestChangeBlindFoldStateAsk,
                holders
            }

            public UIData() : base()
            {
                this.requestChangeBlindFoldStateAsk = new VP<ReferenceData<RequestChangeBlindFoldStateAsk>>(this, (byte)Property.requestChangeBlindFoldStateAsk, new ReferenceData<RequestChangeBlindFoldStateAsk>(null));
                this.holders = new LP<WhoAskHolder.UIData>(this, (byte)Property.holders);
            }

            #endregion

            [NonSerialized]
            public List<Human> humans = new List<Human>();

            public void reset()
            {
                this.humans.Clear();
            }

        }

        #endregion

        #region Adapter

        public WhoAskHolder holderPrefab;

        protected override WhoAskHolder.UIData CreateViewsHolder(int itemIndex)
        {
            WhoAskHolder.UIData uiData = new WhoAskHolder.UIData();
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
                }
                else
                {
                    Debug.LogError("holderPrefab null: " + this);
                }
            }
            return uiData;
        }

        protected override void UpdateViewsHolder(WhoAskHolder.UIData newOrRecycled)
        {
            newOrRecycled.updateView(_Params);
        }

        #endregion

        #region txt

        public Text tvNoHumans;
        private static readonly TxtLanguage txtNoHumans = new TxtLanguage("Don't have any askers");

        static WhoAskAdapter()
        {
            txtNoHumans.add(Language.Type.vi, "Không có người nào hỏi cả");
        }

        #endregion

        #region Refresh

        public GameObject noHumans;

        public override void refresh()
        {
            if (dirty)
            {
                if (this.Initialized)
                {
                    dirty = false;
                    if (this.data != null)
                    {
                        RequestChangeBlindFoldStateAsk requestChangeBlindFoldStateAsk = this.data.requestChangeBlindFoldStateAsk.v.data;
                        if (requestChangeBlindFoldStateAsk != null)
                        {
                            List<Human> humans = new List<Human>();
                            // get
                            {
                                RequestChangeBlindFold requestChangeBlindFold = requestChangeBlindFoldStateAsk.findDataInParent<RequestChangeBlindFold>();
                                if (requestChangeBlindFold != null)
                                {
                                    humans.AddRange(requestChangeBlindFold.whoCanAsks.vs);
                                }
                                else
                                {
                                    Debug.LogError("requestChangeBlindFold null: " + this);
                                }
                            }
                            // Make list
                            {
                                int min = Mathf.Min(humans.Count, _Params.humans.Count);
                                // Update
                                {
                                    for (int i = 0; i < min; i++)
                                    {
                                        if (humans[i] != _Params.humans[i])
                                        {
                                            // change param
                                            _Params.humans[i] = humans[i];
                                            // Update holder
                                            foreach (WhoAskHolder.UIData holder in this.data.holders.vs)
                                            {
                                                if (holder.ItemIndex == i)
                                                {
                                                    holder.human.v = new ReferenceData<Human>(humans[i]);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                // Add or Remove
                                {
                                    if (humans.Count > min)
                                    {
                                        // Add
                                        int insertCount = humans.Count - min;
                                        List<Human> addItems = humans.GetRange(min, insertCount);
                                        _Params.humans.AddRange(addItems);
                                        InsertItems(min, insertCount, false, false);
                                    }
                                    else
                                    {
                                        // Remove
                                        int deleteCount = _Params.humans.Count - min;
                                        if (deleteCount > 0)
                                        {
                                            RemoveItems(min, deleteCount, false, false);
                                            _Params.humans.RemoveRange(min, deleteCount);
                                        }
                                    }
                                }
                            }
                            // NoRooms
                            {
                                if (noHumans != null)
                                {
                                    bool haveAny = false;
                                    {
                                        foreach (WhoAskHolder.UIData holder in this.data.holders.vs)
                                        {
                                            if (holder.human.v.data != null)
                                            {
                                                WhoAskHolder holderUI = holder.findCallBack<WhoAskHolder>();
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
                                    }
                                    noHumans.SetActive(!haveAny);
                                }
                                else
                                {
                                    Debug.LogError("noHumans null: " + this);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("server null: " + this);
                        }
                        // txt
                        {
                            if (tvNoHumans != null)
                            {
                                tvNoHumans.text = txtNoHumans.get();
                            }
                            else
                            {
                                Debug.LogError("tvNoHumans null: " + this);
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
                    Debug.LogError("not initalized: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private RequestChangeBlindFold requestChangeBlindFold = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.requestChangeBlindFoldStateAsk.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting)
            {
                dirty = true;
                return;
            }
            // Child
            {
                if (data is RequestChangeBlindFoldStateAsk)
                {
                    RequestChangeBlindFoldStateAsk requestChangeBlindFoldStateAsk = data as RequestChangeBlindFoldStateAsk;
                    // Parent
                    {
                        DataUtils.addParentCallBack(requestChangeBlindFoldStateAsk, this, ref this.requestChangeBlindFold);
                    }
                    dirty = true;
                    return;
                }
                // Parent
                if (data is RequestChangeBlindFold)
                {
                    dirty = true;
                    return;
                }
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
                // Child
                {
                    uiData.requestChangeBlindFoldStateAsk.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Child
            {
                if (data is RequestChangeBlindFoldStateAsk)
                {
                    RequestChangeBlindFoldStateAsk requestChangeBlindFoldStateAsk = data as RequestChangeBlindFoldStateAsk;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(requestChangeBlindFoldStateAsk, this, ref this.requestChangeBlindFold);
                    }
                    return;
                }
                // Parent
                if (data is RequestChangeBlindFold)
                {
                    return;
                }
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
                    case UIData.Property.requestChangeBlindFoldStateAsk:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.holders:
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
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is RequestChangeBlindFoldStateAsk)
                {
                    return;
                }
                // Parent
                if (wrapProperty.p is RequestChangeBlindFold)
                {
                    switch ((RequestChangeBlindFold.Property)wrapProperty.n)
                    {
                        case RequestChangeBlindFold.Property.state:
                            break;
                        case RequestChangeBlindFold.Property.whoCanAsks:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}