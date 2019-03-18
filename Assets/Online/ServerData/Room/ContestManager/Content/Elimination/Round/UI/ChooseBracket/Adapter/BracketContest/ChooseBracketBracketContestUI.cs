using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class ChooseBracketBracketContestUI : UIHaveTransformDataBehavior<ChooseBracketBracketContestUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<BracketContest>> bracketContest;

            #region Constructor

            public enum Property
            {
                bracketContest
            }

            public UIData() : base()
            {
                this.bracketContest = new VP<ReferenceData<BracketContest>>(this, (byte)Property.bracketContest, new ReferenceData<BracketContest>(null));
            }

            #endregion

        }

        #endregion

        #region txt

        public static readonly TxtLanguage txtContest = new TxtLanguage();

        public static readonly TxtLanguage txtTeam = new TxtLanguage();
        public static readonly TxtLanguage txtScore = new TxtLanguage();
        public static readonly TxtLanguage txtNotEnd = new TxtLanguage();

        static ChooseBracketBracketContestUI()
        {
            txtContest.add(Language.Type.vi, "Trận");

            txtTeam.add(Language.Type.vi, "Đội");
            txtScore.add(Language.Type.vi, "Điểm");
            txtNotEnd.add(Language.Type.vi, "chưa kết thúc");
        }

        #endregion

        #region Refresh

        public Text tvIndex;
        public Text tvBracketContest;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    BracketContest bracketContest = this.data.bracketContest.v.data;
                    if (bracketContest != null)
                    {
                        // tvIndex
                        {
                            if (tvIndex != null)
                            {
                                tvIndex.text = txtContest.get("Match") + (bracketContest.index.v + 1);
                            }
                            else
                            {
                                Debug.LogError("tvIndex null: " + this);
                            }
                        }
                        // tvBracketContest
                        {
                            if (tvBracketContest != null)
                            {
                                StringBuilder builder = new StringBuilder();
                                {
                                    foreach (int teamIndex in bracketContest.teamIndexs.vs)
                                    {
                                        if (bracketContest.contest.v.state.v.getType() == ContestState.Type.End)
                                        {
                                            builder.AppendLine(txtTeam.get("Team") + ": " + teamIndex + ", " + txtScore.get("Score") + ": " + bracketContest.getResult(teamIndex));
                                        }
                                        else
                                        {
                                            builder.AppendLine(txtTeam.get("Team") + ": " + teamIndex + ", " + txtScore.get("Score") + ": " + txtNotEnd.get("not end"));
                                        }
                                    }
                                }
                                tvBracketContest.text = builder.ToString();
                            }
                            else
                            {
                                Debug.LogError("tvBracketContest null: " + this);
                            }
                        }
                        // UI
                        {
                            float deltaY = bracketContest.teamIndexs.vs.Count * 14 + 16;
                            // tvBracketContest
                            {
                                if (tvBracketContest != null)
                                {
                                    UIRectTransform.SetHeight(tvBracketContest.rectTransform, bracketContest.teamIndexs.vs.Count * 14);
                                }
                                else
                                {
                                    Debug.LogError("tvBracketContest null");
                                }
                            }
                            // set
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                        }
                    }
                    else
                    {
                        Debug.LogError("bracketContest null: " + this);
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
                    uiData.bracketContest.allAddCallBack(this);
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
                if (data is BracketContest)
                {
                    BracketContest bracketContest = data as BracketContest;
                    // Child
                    {
                        bracketContest.contest.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Contest)
                    {
                        Contest contest = data as Contest;
                        // Child
                        {
                            contest.state.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is ContestState)
                        {
                            ContestState contestState = data as ContestState;
                            // Child
                            {
                                switch (contestState.getType())
                                {
                                    case ContestState.Type.Load:
                                        break;
                                    case ContestState.Type.Start:
                                        break;
                                    case ContestState.Type.Play:
                                        break;
                                    case ContestState.Type.End:
                                        {
                                            ContestStateEnd contestStateEnd = contestState as ContestStateEnd;
                                            contestStateEnd.teamResults.allAddCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + contestState.getType() + "; " + this);
                                        break;
                                }
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is TeamResult)
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
                    uiData.bracketContest.allRemoveCallBack(this);
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
                if (data is BracketContest)
                {
                    BracketContest bracketContest = data as BracketContest;
                    // Child
                    {
                        bracketContest.contest.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Contest)
                    {
                        Contest contest = data as Contest;
                        // Child
                        {
                            contest.state.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is ContestState)
                        {
                            ContestState contestState = data as ContestState;
                            // Child
                            {
                                switch (contestState.getType())
                                {
                                    case ContestState.Type.Load:
                                        break;
                                    case ContestState.Type.Start:
                                        break;
                                    case ContestState.Type.Play:
                                        break;
                                    case ContestState.Type.End:
                                        {
                                            ContestStateEnd contestStateEnd = contestState as ContestStateEnd;
                                            contestStateEnd.teamResults.allRemoveCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + contestState.getType() + "; " + this);
                                        break;
                                }
                            }
                            return;
                        }
                        // Child
                        if (data is TeamResult)
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
                    case UIData.Property.bracketContest:
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
                if (wrapProperty.p is BracketContest)
                {
                    switch ((BracketContest.Property)wrapProperty.n)
                    {
                        case BracketContest.Property.isActive:
                            break;
                        case BracketContest.Property.index:
                            dirty = true;
                            break;
                        case BracketContest.Property.teamIndexs:
                            dirty = true;
                            break;
                        case BracketContest.Property.contest:
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
                // Child
                {
                    if (wrapProperty.p is Contest)
                    {
                        switch ((Contest.Property)wrapProperty.n)
                        {
                            case Contest.Property.state:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case Contest.Property.calculateScore:
                                break;
                            case Contest.Property.playerPerTeam:
                                break;
                            case Contest.Property.teams:
                                break;
                            case Contest.Property.roundFactory:
                                break;
                            case Contest.Property.rounds:
                                break;
                            case Contest.Property.requestNewRound:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is ContestState)
                        {
                            ContestState contestState = wrapProperty.p as ContestState;
                            // Child
                            {
                                switch (contestState.getType())
                                {
                                    case ContestState.Type.Load:
                                        break;
                                    case ContestState.Type.Start:
                                        break;
                                    case ContestState.Type.Play:
                                        break;
                                    case ContestState.Type.End:
                                        {
                                            switch ((ContestStateEnd.Property)wrapProperty.n)
                                            {
                                                case ContestStateEnd.Property.teamResults:
                                                    {
                                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                                        dirty = true;
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                    break;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + contestState.getType() + "; " + this);
                                        break;
                                }
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is TeamResult)
                        {
                            switch ((TeamResult.Property)wrapProperty.n)
                            {
                                case TeamResult.Property.teamIndex:
                                    dirty = true;
                                    break;
                                case TeamResult.Property.score:
                                    dirty = true;
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

    }
}