using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class BtnRoundRobinUI : UIBehavior<BtnRoundRobinUI.UIData>
    {

        #region UIData

        public class UIData : RoomBtnUI.UIData.Sub
        {

            public VP<ReferenceData<RoundRobinUI.UIData>> roundRobinUIData;

            #region Constructor

            public enum Property
            {
                roundRobinUIData
            }

            public UIData() : base()
            {
                this.roundRobinUIData = new VP<ReferenceData<RoundRobinUI.UIData>>(this, (byte)Property.roundRobinUIData, new ReferenceData<RoundRobinUI.UIData>(null));
            }

            #endregion

            public override Type getType()
            {
                return Type.RoundRobin;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtRoundRobin = new TxtLanguage("Round-robin Match");

        static BtnRoundRobinUI()
        {
            txtRoundRobin.add(Language.Type.vi, "Trận đấu");
        }

        #endregion

        #region Refresh

        public Text tvRoundRobin;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RoundRobinUI.UIData roundRobinUIData = this.data.roundRobinUIData.v.data;
                    if (roundRobinUIData != null)
                    {
                        // tvRoundRobin
                        {
                            if (tvRoundRobin != null)
                            {
                                int roundContestIndex = 0;
                                int roundContestCount = 1;
                                {
                                    // roundContestIndex
                                    {
                                        RoundContestUI.UIData roundContestUIData = roundRobinUIData.roundContestUIData.v;
                                        if (roundContestUIData != null)
                                        {
                                            RoundContest roundContest = roundContestUIData.roundContest.v.data;
                                            if (roundContest != null)
                                            {
                                                roundContestIndex = roundContest.index.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("roundContest null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("roundContestUIData null: " + this);
                                        }
                                    }
                                    // roundContestCount
                                    {
                                        RoundRobin roundRobin = roundRobinUIData.roundRobin.v.data;
                                        if (roundRobin != null)
                                        {
                                            roundContestCount = roundRobin.roundContests.vs.Count;
                                        }
                                        else
                                        {
                                            // Debug.LogError ("roundContest null: " + this);
                                        }
                                    }
                                }
                                tvRoundRobin.text = txtRoundRobin.get() + " " + (roundContestIndex + 1) + "/" + roundContestCount;
                            }
                            else
                            {
                                Debug.LogError("tvRoundRobin null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("roundRobinUIData null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
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
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.roundRobinUIData.allAddCallBack(this);
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
                if (data is RoundRobinUI.UIData)
                {
                    RoundRobinUI.UIData roundRobinUIData = data as RoundRobinUI.UIData;
                    // Child
                    {
                        roundRobinUIData.roundRobin.allAddCallBack(this);
                        roundRobinUIData.roundContestUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is RoundRobin)
                    {
                        dirty = true;
                        return;
                    }
                    // roundContestUIData
                    {
                        if (data is RoundContestUI.UIData)
                        {
                            RoundContestUI.UIData roundContestUIData = data as RoundContestUI.UIData;
                            // Child
                            {
                                roundContestUIData.roundContest.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is RoundContest)
                        {
                            dirty = true;
                            return;
                        }
                    }
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
                    uiData.roundRobinUIData.allRemoveCallBack(this);
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
                if (data is RoundRobinUI.UIData)
                {
                    RoundRobinUI.UIData roundRobinUIData = data as RoundRobinUI.UIData;
                    // Child
                    {
                        roundRobinUIData.roundRobin.allRemoveCallBack(this);
                        roundRobinUIData.roundContestUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is RoundRobin)
                    {
                        return;
                    }
                    // roundContestUIData
                    {
                        if (data is RoundContestUI.UIData)
                        {
                            RoundContestUI.UIData roundContestUIData = data as RoundContestUI.UIData;
                            // Child
                            {
                                roundContestUIData.roundContest.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is RoundContest)
                        {
                            return;
                        }
                    }
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
                    case UIData.Property.roundRobinUIData:
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
                if (wrapProperty.p is RoundRobinUI.UIData)
                {
                    switch ((RoundRobinUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundRobinUI.UIData.Property.roundRobin:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case RoundRobinUI.UIData.Property.roundContestUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case RoundRobinUI.UIData.Property.chooseRoundContestUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is RoundRobin)
                    {
                        switch ((RoundRobin.Property)wrapProperty.n)
                        {
                            case RoundRobin.Property.state:
                                break;
                            case RoundRobin.Property.index:
                                break;
                            case RoundRobin.Property.roundContests:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // roundContestUIData
                    {
                        if (wrapProperty.p is RoundContestUI.UIData)
                        {
                            switch ((RoundContestUI.UIData.Property)wrapProperty.n)
                            {
                                case RoundContestUI.UIData.Property.roundContest:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case RoundContestUI.UIData.Property.contestUIData:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is RoundContest)
                        {
                            switch ((RoundContest.Property)wrapProperty.n)
                            {
                                case RoundContest.Property.index:
                                    dirty = true;
                                    break;
                                case RoundContest.Property.teamIndexs:
                                    break;
                                case RoundContest.Property.contest:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnRoundRobin()
        {
            if (this.data != null)
            {
                RoundRobinUI.UIData roundRobinUIData = this.data.roundRobinUIData.v.data;
                if (roundRobinUIData != null)
                {
                    ChooseRoundContestUI.UIData chooseRoundContestUIData = roundRobinUIData.chooseRoundContestUIData.newOrOld<ChooseRoundContestUI.UIData>();
                    {

                    }
                    roundRobinUIData.chooseRoundContestUIData.v = chooseRoundContestUIData;
                }
                else
                {
                    Debug.LogError("roundRobinUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}