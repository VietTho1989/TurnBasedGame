using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class BtnContestUI : UIHaveTransformDataBehavior<BtnContestUI.UIData>
    {

        #region UIData

        public class UIData : RoomBtnUI.UIData.Sub
        {

            public VP<ReferenceData<ContestUI.UIData>> contestUIData;

            #region Constructor

            public enum Property
            {
                contestUIData
            }

            public UIData() : base()
            {
                this.contestUIData = new VP<ReferenceData<ContestUI.UIData>>(this, (byte)Property.contestUIData, new ReferenceData<ContestUI.UIData>(null));
            }

            #endregion

            public override Type getType()
            {
                return Type.Contest;
            }

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            BtnContestUI btnContestUI = this.findCallBack<BtnContestUI>();
                            if (btnContestUI != null)
                            {
                                isProcess = btnContestUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("btnContestUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtContest = new TxtLanguage("Set");

        static BtnContestUI()
        {
            txtContest.add(Language.Type.vi, "Hiệp");
        }

        #endregion

        #region Refresh

        public Text tvContest;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ContestUI.UIData contestUIData = this.data.contestUIData.v.data;
                    if (contestUIData != null)
                    {
                        // tvContest
                        {
                            if (tvContest != null)
                            {
                                int roundIndex = 0;
                                int roundCount = 1;
                                {
                                    // roundIndex
                                    {
                                        RoundUI.UIData roundUIData = contestUIData.roundUIData.v;
                                        if (roundUIData != null)
                                        {
                                            Round round = roundUIData.round.v.data;
                                            if (round != null)
                                            {
                                                roundIndex = round.index.v;
                                            }
                                            else
                                            {
                                                // Debug.LogError("round null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("roundUIData null: " + this);
                                        }
                                    }
                                    // roundCount
                                    {
                                        Contest contest = contestUIData.contest.v.data;
                                        if (contest != null)
                                        {
                                            roundCount = contest.rounds.vs.Count;
                                        }
                                        else
                                        {
                                            // Debug.LogError ("contest null: " + this);
                                        }
                                    }
                                }
                                tvContest.text = txtContest.get() + " " + (roundIndex + 1) + "/" + roundCount;
                            }
                            else
                            {
                                Debug.LogError("tvContest null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("contestUIData null: " + this);
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
                    uiData.contestUIData.allAddCallBack(this);
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
                if (data is ContestUI.UIData)
                {
                    ContestUI.UIData contestUIData = data as ContestUI.UIData;
                    // Child
                    {
                        contestUIData.contest.allAddCallBack(this);
                        contestUIData.roundUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Contest)
                    {
                        dirty = true;
                        return;
                    }
                    // roundUIData
                    {
                        if (data is RoundUI.UIData)
                        {
                            RoundUI.UIData roundUIData = data as RoundUI.UIData;
                            // Child
                            {
                                roundUIData.round.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is Round)
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
                    uiData.contestUIData.allRemoveCallBack(this);
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
                if (data is ContestUI.UIData)
                {
                    ContestUI.UIData contestUIData = data as ContestUI.UIData;
                    // Child
                    {
                        contestUIData.contest.allRemoveCallBack(this);
                        contestUIData.roundUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Contest)
                    {
                        return;
                    }
                    // roundUIData
                    {
                        if (data is RoundUI.UIData)
                        {
                            RoundUI.UIData roundUIData = data as RoundUI.UIData;
                            // Child
                            {
                                roundUIData.round.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is Round)
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
                    case UIData.Property.contestUIData:
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
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is ContestUI.UIData)
                {
                    switch ((ContestUI.UIData.Property)wrapProperty.n)
                    {
                        case ContestUI.UIData.Property.contest:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ContestUI.UIData.Property.roundUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ContestUI.UIData.Property.chooseRoundUIData:
                            break;
                        case ContestUI.UIData.Property.isAutoNewRound:
                            break;
                        case ContestUI.UIData.Property.requestNewRoundUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is Contest)
                    {
                        switch ((Contest.Property)wrapProperty.n)
                        {
                            case Contest.Property.state:
                                break;
                            case Contest.Property.playerPerTeam:
                                break;
                            case Contest.Property.teams:
                                break;
                            case Contest.Property.roundFactory:
                                break;
                            case Contest.Property.rounds:
                                dirty = true;
                                break;
                            case Contest.Property.requestNewRound:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // roundUIData
                    {
                        if (wrapProperty.p is RoundUI.UIData)
                        {
                            switch ((RoundUI.UIData.Property)wrapProperty.n)
                            {
                                case RoundUI.UIData.Property.round:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case RoundUI.UIData.Property.roundGameUIData:
                                    break;
                                case RoundUI.UIData.Property.chooseRoundGameUIData:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is Round)
                        {
                            switch ((Round.Property)wrapProperty.n)
                            {
                                case Round.Property.state:
                                    break;
                                case Round.Property.index:
                                    dirty = true;
                                    break;
                                case Round.Property.roundGames:
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

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnContest()
        {
            if (this.data != null)
            {
                ContestUI.UIData contestUIData = this.data.contestUIData.v.data;
                if (contestUIData != null)
                {
                    ChooseRoundUI.UIData chooseRoundUIData = contestUIData.chooseRoundUIData.newOrOld<ChooseRoundUI.UIData>();
                    {

                    }
                    contestUIData.chooseRoundUIData.v = chooseRoundUIData;
                }
                else
                {
                    Debug.LogError("contestUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}