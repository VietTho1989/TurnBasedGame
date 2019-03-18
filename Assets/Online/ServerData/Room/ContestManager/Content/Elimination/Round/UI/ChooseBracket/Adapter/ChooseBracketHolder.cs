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

        #region txt

        private static readonly TxtLanguage txtByes = new TxtLanguage();

        private static readonly TxtLanguage txtPlaying = new TxtLanguage();
        private static readonly TxtLanguage txtWinner = new TxtLanguage();
        private static readonly TxtLanguage txtLoser = new TxtLanguage();

        public Text tvShow;
        public static readonly TxtLanguage txtShow = new TxtLanguage();

        static ChooseBracketHolder()
        {
            // txt
            {
                txtByes.add(Language.Type.vi, "Dư ra");

                txtPlaying.add(Language.Type.vi, "Đang chơi");
                txtWinner.add(Language.Type.vi, "Đội thắng");
                txtLoser.add(Language.Type.vi, "Đội thua");

                txtShow.add(Language.Type.vi, "Hiện");
            }
            // rect
            {
                // bracketContestRect
                {
                    // anchoredPosition: (-12.0, -40.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (34.0, -70.0); offsetMax: (-58.0, -40.0); sizeDelta: (-92.0, 30.0);
                    bracketContestRect.anchoredPosition = new Vector3(-12.0f, -40.0f, 0.0f);
                    bracketContestRect.anchorMin = new Vector2(0.0f, 1.0f);
                    bracketContestRect.anchorMax = new Vector2(1.0f, 1.0f);
                    bracketContestRect.pivot = new Vector2(0.5f, 1.0f);
                    bracketContestRect.offsetMin = new Vector2(34.0f, -70.0f);
                    bracketContestRect.offsetMax = new Vector2(-58.0f, -40.0f);
                    bracketContestRect.sizeDelta = new Vector2(-92.0f, 30.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Text tvIndex;
        public Text tvState;
        public Text tvByes;

        public Button btnShow;

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
                        // bracketContests
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
                        // tvByes
                        {
                            if (tvByes != null)
                            {
                                if (bracket.byeTeamIndexs.vs.Count > 0)
                                {
                                    StringBuilder builder = new StringBuilder();
                                    {
                                        for (int i = 0; i < bracket.byeTeamIndexs.vs.Count; i++)
                                        {
                                            int byeTeamIndex = bracket.byeTeamIndexs.vs[i];
                                            builder.Append("" + byeTeamIndex);
                                            if (i != bracket.byeTeamIndexs.vs.Count - 1)
                                            {
                                                builder.Append(", ");
                                            }
                                        }
                                    }
                                    tvByes.text = txtByes.get("Byes") + ": " + builder.ToString();
                                }
                                else
                                {
                                    tvByes.text = "";
                                }
                            }
                            else
                            {
                                Debug.LogError("tvByes null: " + this);
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // state
                            {
                                deltaY += 40;
                            }
                            // bracketContests
                            {
                                foreach (ChooseBracketBracketContestUI.UIData bracketContest in this.data.bracketContests.vs)
                                {
                                    deltaY += UIRectTransform.SetPosY(bracketContest, deltaY);
                                }
                            }
                            // bye
                            {
                                if (tvByes != null)
                                {
                                    if (!string.IsNullOrEmpty(tvByes.text))
                                    {
                                        UIRectTransform.SetPosY(tvByes.rectTransform, deltaY);
                                        deltaY += 20;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("tvByes null");
                                }
                            }
                            // set
                            this.setHolderSize(Mathf.Max(40, deltaY));
                        }
                        // btnShow
                        {
                            if (btnShow != null)
                            {
                                bool isAlreadyShow = false;
                                {
                                    EliminationRoundUI.UIData eliminationRoundUIData = this.data.findDataInParent<EliminationRoundUI.UIData>();
                                    if (eliminationRoundUIData != null)
                                    {
                                        BracketUI.UIData bracketUIData = eliminationRoundUIData.bracketUIData.v;
                                        if (bracketUIData != null)
                                        {
                                            if (bracketUIData.bracket.v.data == bracket)
                                            {
                                                isAlreadyShow = true;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("bracketUIData null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("eliminationRoundUIData null");
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
                                Debug.LogError("tvShow null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("bracket null: " + this);
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
        private static readonly UIRectTransform bracketContestRect = new UIRectTransform();

        private EliminationRoundUI.UIData eliminationRoundUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.eliminationRoundUIData);
                }
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
            // Parent
            {
                if(data is EliminationRoundUI.UIData)
                {
                    EliminationRoundUI.UIData eliminationRoundUIData = data as EliminationRoundUI.UIData;
                    // Child
                    {
                        eliminationRoundUIData.bracketUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is BracketUI.UIData)
                {
                    dirty = true;
                    return;
                }
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
                // bracketContestUIData
                {
                    if (data is ChooseBracketBracketContestUI.UIData)
                    {
                        ChooseBracketBracketContestUI.UIData bracketContestUIData = data as ChooseBracketBracketContestUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(bracketContestUIData, bracketContestPrefab, this.transform, bracketContestRect);
                        }
                        // Child
                        {
                            TransformData.AddCallBack(bracketContestUIData, this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if(data is TransformData)
                    {
                        dirty = true;
                        return;
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.eliminationRoundUIData);
                }
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
            // Parent
            {
                if (data is EliminationRoundUI.UIData)
                {
                    EliminationRoundUI.UIData eliminationRoundUIData = data as EliminationRoundUI.UIData;
                    // Child
                    {
                        eliminationRoundUIData.bracketUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is BracketUI.UIData)
                {
                    return;
                }
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
                // bracketContestUIData
                {
                    if (data is ChooseBracketBracketContestUI.UIData)
                    {
                        ChooseBracketBracketContestUI.UIData bracketContestUIData = data as ChooseBracketBracketContestUI.UIData;
                        // Child
                        {
                            TransformData.RemoveCallBack(bracketContestUIData, this);
                        }
                        // UI
                        {
                            bracketContestUIData.removeCallBackAndDestroy(typeof(ChooseBracketBracketContestUI));
                        }
                        return;
                    }
                    // Child
                    if(data is TransformData)
                    {
                        return;
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
            // Parent
            {
                if (wrapProperty.p is EliminationRoundUI.UIData)
                {
                    switch ((EliminationRoundUI.UIData.Property)wrapProperty.n)
                    {
                        case EliminationRoundUI.UIData.Property.eliminationRound:
                            break;
                        case EliminationRoundUI.UIData.Property.bracketUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EliminationRoundUI.UIData.Property.chooseBracketUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is BracketUI.UIData)
                {
                    switch ((BracketUI.UIData.Property)wrapProperty.n)
                    {
                        case BracketUI.UIData.Property.bracket:
                            dirty = true;
                            break;
                        case BracketUI.UIData.Property.bracketContestUIData:
                            break;
                        case BracketUI.UIData.Property.chooseBracketContestUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
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
                // bracketContestUIData
                {
                    if (wrapProperty.p is ChooseBracketBracketContestUI.UIData)
                    {
                        return;
                    }
                    // Child
                    if(wrapProperty.p is TransformData)
                    {
                        switch ((TransformData.Property)wrapProperty.n)
                        {
                            case TransformData.Property.anchoredPosition:
                                break;
                            case TransformData.Property.anchorMin:
                                break;
                            case TransformData.Property.anchorMax:
                                break;
                            case TransformData.Property.pivot:
                                break;
                            case TransformData.Property.offsetMin:
                                break;
                            case TransformData.Property.offsetMax:
                                break;
                            case TransformData.Property.sizeDelta:
                                break;
                            case TransformData.Property.rotation:
                                break;
                            case TransformData.Property.scale:
                                break;
                            case TransformData.Property.size:
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