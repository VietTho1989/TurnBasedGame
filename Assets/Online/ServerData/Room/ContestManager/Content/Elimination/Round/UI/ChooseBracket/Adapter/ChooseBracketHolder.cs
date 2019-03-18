using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class ChooseBracketHolder : SriaHolderBehavior<ChooseBracketHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<Bracket>> bracket;

            public LP<ChooseBracketBracketContestUI.UIData> bracketContests;

            #region Constructor

            public enum Property
            {
                bracket,
                bracketContests
            }

            public UIData() : base()
            {
                this.bracket = new VP<ReferenceData<Bracket>>(this, (byte)Property.bracket, new ReferenceData<Bracket>(null));
                this.bracketContests = new LP<ChooseBracketBracketContestUI.UIData>(this, (byte)Property.bracketContests);
            }

            #endregion

            public void updateView(ChooseBracketAdapter.UIData myParams)
            {
                // Find
                Bracket bracket = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.brackets.Count)
                    {
                        bracket = myParams.brackets[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.bracket.v = new ReferenceData<Bracket>(bracket);
            }

        }

        #endregion

        #region Refresh

        #region txt

        public static readonly TxtLanguage txtByes = new TxtLanguage();

        public static readonly TxtLanguage txtPlaying = new TxtLanguage();
        public static readonly TxtLanguage txtWinner = new TxtLanguage();
        public static readonly TxtLanguage txtLoser = new TxtLanguage();

        public Text tvShow;
        public static readonly TxtLanguage txtShow = new TxtLanguage();

        static ChooseBracketHolder()
        {
            txtByes.add(Language.Type.vi, "Dư ra");

            txtPlaying.add(Language.Type.vi, "Đang chơi");
            txtWinner.add(Language.Type.vi, "Đội thắng");
            txtLoser.add(Language.Type.vi, "Đội thua");

            txtShow.add(Language.Type.vi, "Hiện");
        }

        #endregion

        public Text tvIndex;
        public Text tvState;
        public Text tvByes;

        public override void refresh()
        {
            base.refresh();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Bracket bracket = this.data.bracket.v.data;
                    if (bracket != null)
                    {
                        // tvIndex
                        {
                            if (tvIndex != null)
                            {
                                tvIndex.text = "" + (bracket.index.v + 1);
                            }
                            else
                            {
                                Debug.LogError("tvIndex null: " + this);
                            }
                        }
                        // tvByes
                        {
                            if (tvByes != null)
                            {
                                StringBuilder builder = new StringBuilder();
                                {
                                    foreach (int byeTeamIndex in bracket.byeTeamIndexs.vs)
                                    {
                                        builder.Append("" + byeTeamIndex + ", ");
                                    }
                                }
                                tvByes.text = txtByes.get("Byes") + ": " + builder.ToString();
                            }
                            else
                            {
                                Debug.LogError("tvByes null: " + this);
                            }
                        }
                        // teams
                        {
                            // get old
                            List<ChooseBracketBracketContestUI.UIData> oldBracketContests = new List<ChooseBracketBracketContestUI.UIData>();
                            {
                                oldBracketContests.AddRange(this.data.bracketContests.vs);
                            }
                            // Update
                            {
                                // get active list
                                List<BracketContest> bracketContests = new List<BracketContest>();
                                {
                                    foreach (BracketContest bracketContest in bracket.bracketContests.vs)
                                    {
                                        if (bracketContest.isActive.v)
                                        {
                                            bracketContests.Add(bracketContest);
                                        }
                                    }
                                }
                                // Update
                                foreach (BracketContest bracketContest in bracketContests)
                                {
                                    // find
                                    ChooseBracketBracketContestUI.UIData bracketContestUIData = null;
                                    {
                                        // find old
                                        if (oldBracketContests.Count > 0)
                                        {
                                            bracketContestUIData = oldBracketContests[0];
                                        }
                                        // make new
                                        if (bracketContestUIData == null)
                                        {
                                            bracketContestUIData = new ChooseBracketBracketContestUI.UIData();
                                            {
                                                bracketContestUIData.uid = this.data.bracketContests.makeId();
                                            }
                                            this.data.bracketContests.add(bracketContestUIData);
                                        }
                                        else
                                        {
                                            oldBracketContests.Remove(bracketContestUIData);
                                        }
                                    }
                                    // update
                                    {
                                        bracketContestUIData.bracketContest.v = new ReferenceData<BracketContest>(bracketContest);
                                    }
                                }
                            }
                            // remove old
                            foreach (ChooseBracketBracketContestUI.UIData oldBracketContest in oldBracketContests)
                            {
                                this.data.bracketContests.remove(oldBracketContest);
                            }
                        }
                        // tvState
                        {
                            if (tvState != null)
                            {
                                Bracket.State state = bracket.state.v;
                                if (state != null)
                                {
                                    switch (state.getType())
                                    {
                                        case Bracket.State.Type.Play:
                                            tvState.text = txtPlaying.get("Playing");
                                            break;
                                        case Bracket.State.Type.End:
                                            {
                                                BracketStateEnd bracketStateEnd = state as BracketStateEnd;
                                                // winner
                                                StringBuilder winnerBuilder = new StringBuilder();
                                                {
                                                    winnerBuilder.Append(txtWinner.get("Winner") + ": ");
                                                    foreach (int winner in bracketStateEnd.winTeamIndexs.vs)
                                                    {
                                                        winnerBuilder.Append(winner + ", ");
                                                    }
                                                }
                                                // loser
                                                StringBuilder loserBuilder = new StringBuilder();
                                                {
                                                    loserBuilder.Append(txtLoser.get("Loser") + ": ");
                                                    foreach (int loser in bracketStateEnd.loseTeamIndexs.vs)
                                                    {
                                                        loserBuilder.Append(loser + ", ");
                                                    }
                                                }
                                                tvState.text = winnerBuilder.ToString() + "\n" + loserBuilder.ToString();
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("state null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("tvStatate null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("bracket null: " + this);
                    }
                    // txt
                    {
                        if (tvShow != null)
                        {
                            tvShow.text = txtShow.get("Show");
                        }
                        else
                        {
                            Debug.LogError("tvShow null: " + this);
                        }
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

        public ChooseBracketBracketContestUI bracketContestPrefab;
        public Transform bracketContestContainer;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.bracket.allAddCallBack(this);
                    uiData.bracketContests.allAddCallBack(this);
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
                // bracket
                {
                    if (data is Bracket)
                    {
                        Bracket bracket = data as Bracket;
                        // Child
                        {
                            bracket.bracketContests.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is BracketContest)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is ChooseBracketBracketContestUI.UIData)
                {
                    ChooseBracketBracketContestUI.UIData bracketContestUIData = data as ChooseBracketBracketContestUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(bracketContestUIData, bracketContestPrefab, bracketContestContainer);
                    }
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
                    uiData.bracket.allRemoveCallBack(this);
                    uiData.bracketContests.allRemoveCallBack(this);
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
                // bracket
                {
                    if (data is Bracket)
                    {
                        Bracket bracket = data as Bracket;
                        // Child
                        {
                            bracket.bracketContests.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is BracketContest)
                    {
                        return;
                    }
                }
                if (data is ChooseBracketBracketContestUI.UIData)
                {
                    ChooseBracketBracketContestUI.UIData bracketContestUIData = data as ChooseBracketBracketContestUI.UIData;
                    // UI
                    {
                        bracketContestUIData.removeCallBackAndDestroy(typeof(ChooseBracketBracketContestUI));
                    }
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
                    case UIData.Property.bracket:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.bracketContests:
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
                // bracket
                {
                    if (wrapProperty.p is Bracket)
                    {
                        switch ((Bracket.Property)wrapProperty.n)
                        {
                            case Bracket.Property.isActive:
                                break;
                            case Bracket.Property.state:
                                dirty = true;
                                break;
                            case Bracket.Property.index:
                                dirty = true;
                                break;
                            case Bracket.Property.bracketContests:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case Bracket.Property.byeTeamIndexs:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is BracketContest)
                    {
                        switch ((BracketContest.Property)wrapProperty.n)
                        {
                            case BracketContest.Property.isActive:
                                dirty = true;
                                break;
                            case BracketContest.Property.index:
                                break;
                            case BracketContest.Property.teamIndexs:
                                break;
                            case BracketContest.Property.contest:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                }
                if (wrapProperty.p is ChooseBracketBracketContestUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnShow()
        {
            if (this.data != null)
            {
                Bracket bracket = this.data.bracket.v.data;
                if (bracket != null)
                {
                    EliminationRoundUI.UIData eliminationRoundUIData = this.data.findDataInParent<EliminationRoundUI.UIData>();
                    if (eliminationRoundUIData != null)
                    {
                        BracketUI.UIData bracketUIData = eliminationRoundUIData.bracketUIData.v;
                        if (bracketUIData != null)
                        {
                            bracketUIData.bracket.v = new ReferenceData<Bracket>(bracket);
                        }
                        else
                        {
                            Debug.LogError("bracketUIData null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("bracketUIData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("bracket null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}