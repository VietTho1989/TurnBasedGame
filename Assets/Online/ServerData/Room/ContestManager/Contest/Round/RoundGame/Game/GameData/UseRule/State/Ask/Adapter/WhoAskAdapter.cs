using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace RequestUseRule
{
    public class WhoAskAdapter : SRIA<WhoAskAdapter.UIData, WhoAskHolder.UIData>
    {

        #region UIData

        [Serializable]
        public class UIData : BaseParams
        {

            public VP<ReferenceData<RequestChangeUseRuleStateAsk>> requestChangeUseRuleStateAsk;

            public LP<WhoAskHolder.UIData> holders;

            #region Constructor

            public enum Property
            {
                requestChangeUseRuleStateAsk,
                holders
            }

            public UIData() : base()
            {
                this.requestChangeUseRuleStateAsk = new VP<ReferenceData<RequestChangeUseRuleStateAsk>>(this, (byte)Property.requestChangeUseRuleStateAsk, new ReferenceData<RequestChangeUseRuleStateAsk>(null));
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

        #region Refresh

        #region txt

        public Text tvNoHumans;
        public static readonly TxtLanguage txtNoHumans = new TxtLanguage();

        static WhoAskAdapter()
        {
            txtNoHumans.add(Language.Type.vi, "Không có người nào hỏi cả");
        }

        #endregion

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
                        RequestChangeUseRuleStateAsk requestChangeUseRuleStateAsk = this.data.requestChangeUseRuleStateAsk.v.data;
                        if (requestChangeUseRuleStateAsk != null)
                        {
                            List<Human> humans = new List<Human>();
                            // get
                            {
                                RequestChangeUseRule requestChangeUseRule = requestChangeUseRuleStateAsk.findDataInParent<RequestChangeUseRule>();
                                if (requestChangeUseRule != null)
                                {
                                    humans.AddRange(requestChangeUseRule.whoCanAsks.vs);
                                }
                                else
                                {
                                    Debug.LogError("requestChangeUseRule null: " + this);
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
                                tvNoHumans.text = txtNoHumans.get("Don't have any askers");
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

        private RequestChangeUseRule requestChangeUseRule = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.requestChangeUseRuleStateAsk.allAddCallBack(this);
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
                if (data is RequestChangeUseRuleStateAsk)
                {
                    RequestChangeUseRuleStateAsk requestChangeUseRuleStateAsk = data as RequestChangeUseRuleStateAsk;
                    // Parent
                    {
                        DataUtils.addParentCallBack(requestChangeUseRuleStateAsk, this, ref this.requestChangeUseRule);
                    }
                    dirty = true;
                    return;
                }
                // Parent
                if (data is RequestChangeUseRule)
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
                    uiData.requestChangeUseRuleStateAsk.allRemoveCallBack(this);
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
                if (data is RequestChangeUseRuleStateAsk)
                {
                    RequestChangeUseRuleStateAsk requestChangeUseRuleStateAsk = data as RequestChangeUseRuleStateAsk;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(requestChangeUseRuleStateAsk, this, ref this.requestChangeUseRule);
                    }
                    return;
                }
                // Parent
                if (data is RequestChangeUseRule)
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
                    case UIData.Property.requestChangeUseRuleStateAsk:
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
                if (wrapProperty.p is RequestChangeUseRuleStateAsk)
                {
                    return;
                }
                // Parent
                if (wrapProperty.p is RequestChangeUseRule)
                {
                    switch ((RequestChangeUseRule.Property)wrapProperty.n)
                    {
                        case RequestChangeUseRule.Property.state:
                            break;
                        case RequestChangeUseRule.Property.whoCanAsks:
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