using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class ChooseRoundRobinHolder : SriaHolderBehavior<ChooseRoundRobinHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<RoundRobin>> roundRobin;

            #region Constructor

            public enum Property
            {
                roundRobin
            }

            public UIData() : base()
            {
                this.roundRobin = new VP<ReferenceData<RoundRobin>>(this, (byte)Property.roundRobin, new ReferenceData<RoundRobin>(null));
            }

            #endregion

            public void updateView(ChooseRoundRobinAdapter.UIData myParams)
            {
                // Find
                RoundRobin roundRobin = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.roundRobins.Count)
                    {
                        roundRobin = myParams.roundRobins[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.roundRobin.v = new ReferenceData<RoundRobin>(roundRobin);
            }

        }

        #endregion

        #region txt

        public Text tvShow;
        private static readonly TxtLanguage txtShow = new TxtLanguage();

        static ChooseRoundRobinHolder()
        {
            txtShow.add(Language.Type.vi, "Hiện");
        }

        #endregion

        #region Refresh

        public Text tvIndex;

        public Button btnShow;

        public override void refresh()
        {
            base.refresh();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RoundRobin roundRobin = this.data.roundRobin.v.data;
                    if (roundRobin != null)
                    {
                        // tvIndex
                        {
                            if (tvIndex != null)
                            {
                                tvIndex.text = "" + (roundRobin.index.v + 1);
                            }
                            else
                            {
                                Debug.LogError("tvIndex null: " + this);
                            }
                        }
                        // btnShow
                        {
                            if (btnShow != null)
                            {
                                bool isAlreadyShow = false;
                                {
                                    RoundRobinContentUI.UIData roundRobinContentUIData = this.data.findDataInParent<RoundRobinContentUI.UIData>();
                                    if (roundRobinContentUIData != null)
                                    {
                                        RoundRobinUI.UIData roundRobinUIData = roundRobinContentUIData.roundRobinUIData.v;
                                        if (roundRobinUIData != null)
                                        {
                                            if (roundRobinUIData.roundRobin.v.data == roundRobin)
                                            {
                                                isAlreadyShow = true;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("roundRobinUIData null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("roundRobinContentUIData null");
                                    }
                                }
                                btnShow.interactable = !isAlreadyShow;
                            }
                            else
                            {
                                Debug.LogError("btnShow null");
                            }
                        }
                        // txt
                        {
                            if (tvShow != null)
                            {
                                tvShow.text = txtShow.get("Show");
                            }
                            else
                            {
                                Debug.LogError("tvShow null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("roundRobin null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        #endregion

        #region implement callBacks

        private RoundRobinContentUI.UIData roundRobinContentUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.roundRobinContentUIData);
                }
                // Child
                {
                    uiData.roundRobin.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if(data is Setting)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is RoundRobinContentUI.UIData)
                {
                    RoundRobinContentUI.UIData roundRobinContentUIData = data as RoundRobinContentUI.UIData;
                    // Child
                    {
                        roundRobinContentUIData.roundRobinUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is RoundRobinUI.UIData)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            if (data is RoundRobin)
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.roundRobinContentUIData);
                }
                // Child
                {
                    uiData.roundRobin.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if(data is Setting)
            {
                return;
            }
            // Parent
            {
                if (data is RoundRobinContentUI.UIData)
                {
                    RoundRobinContentUI.UIData roundRobinContentUIData = data as RoundRobinContentUI.UIData;
                    // Child
                    {
                        roundRobinContentUIData.roundRobinUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is RoundRobinUI.UIData)
                {
                    return;
                }
            }
            // Child
            if (data is RoundRobin)
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
                    case UIData.Property.roundRobin:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Setting
            if(wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        dirty = true;
                        break;
                    case Setting.Property.style:
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
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                if (wrapProperty.p is RoundRobinContentUI.UIData)
                {
                    switch ((RoundRobinContentUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundRobinContentUI.UIData.Property.roundRobinContent:
                            break;
                        case RoundRobinContentUI.UIData.Property.roundRobinUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case RoundRobinContentUI.UIData.Property.chooseRoundRobinUIData:
                            break;
                        case RoundRobinContentUI.UIData.Property.requestNewRoundRobinUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is RoundRobinUI.UIData)
                {
                    switch ((RoundRobinUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundRobinUI.UIData.Property.roundRobin:
                            dirty = true;
                            break;
                        case RoundRobinUI.UIData.Property.roundContestUIData:
                            break;
                        case RoundRobinUI.UIData.Property.chooseRoundContestUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // Child
            if (wrapProperty.p is RoundRobin)
            {
                switch ((RoundRobin.Property)wrapProperty.n)
                {
                    case RoundRobin.Property.state:
                        dirty = true;
                        break;
                    case RoundRobin.Property.index:
                        dirty = true;
                        break;
                    case RoundRobin.Property.roundContests:
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

        public void onClickBtnShow()
        {
            if (this.data != null)
            {
                RoundRobin roundRobin = this.data.roundRobin.v.data;
                if (roundRobin != null)
                {
                    RoundRobinContentUI.UIData roundRobinContentUIData = this.data.findDataInParent<RoundRobinContentUI.UIData>();
                    if (roundRobinContentUIData != null)
                    {
                        RoundRobinUI.UIData roundRobinUIData = roundRobinContentUIData.roundRobinUIData.v;
                        if (roundRobinUIData != null)
                        {
                            roundRobinUIData.roundRobin.v = new ReferenceData<RoundRobin>(roundRobin);
                        }
                        else
                        {
                            Debug.LogError("roundRobinUIData null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("roundRobinContentUIData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("roundRobin null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}