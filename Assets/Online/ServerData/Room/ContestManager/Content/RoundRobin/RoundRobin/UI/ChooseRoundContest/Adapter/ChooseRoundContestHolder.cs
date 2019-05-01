using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class ChooseRoundContestHolder : SriaHolderBehavior<ChooseRoundContestHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<RoundContest>> roundContest;

            public LP<ChooseRoundContestTeamUI.UIData> teams;

            #region Constructor

            public enum Property
            {
                roundContest,
                teams
            }

            public UIData() : base()
            {
                this.roundContest = new VP<ReferenceData<RoundContest>>(this, (byte)Property.roundContest, new ReferenceData<RoundContest>(null));
                this.teams = new LP<ChooseRoundContestTeamUI.UIData>(this, (byte)Property.teams);
            }

            #endregion

            public void updateView(ChooseRoundContestAdapter.UIData myParams)
            {
                // Find
                RoundContest roundContest = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.roundContests.Count)
                    {
                        roundContest = myParams.roundContests[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.roundContest.v = new ReferenceData<RoundContest>(roundContest);
            }

        }

        #endregion

        #region txt

        public Text tvShow;
        private static readonly TxtLanguage txtShow = new TxtLanguage("Show");

        #region state

        private static readonly TxtLanguage txtLoad = new TxtLanguage("Loading");
        private static readonly TxtLanguage txtStart = new TxtLanguage("Starting");
        private static readonly TxtLanguage txtPlay = new TxtLanguage("Playing");
        private static readonly TxtLanguage txtEnd = new TxtLanguage("End");

        #endregion

        static ChooseRoundContestHolder()
        {
            // txt
            {
                txtShow.add(Language.Type.vi, "Hiện");
                // state
                {
                    txtLoad.add(Language.Type.vi, "Đang Tải");
                    txtStart.add(Language.Type.vi, "Bắt Đầu");
                    txtPlay.add(Language.Type.vi, "Đang Chơi");
                    txtEnd.add(Language.Type.vi, "Kết Thúc");
                }
            }
            // rect
            {
                // teamRect
                {
                    // anchoredPosition: (-46.0, 0.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (30.0, -30.0); offsetMax: (-122.0, 0.0); sizeDelta: (-152.0, 30.0);
                    teamRect.anchoredPosition = new Vector3(-46.0f, 0.0f, 0.0f);
                    teamRect.anchorMin = new Vector2(0.0f, 1.0f);
                    teamRect.anchorMax = new Vector2(1.0f, 1.0f);
                    teamRect.pivot = new Vector2(0.5f, 1.0f);
                    teamRect.offsetMin = new Vector2(30.0f, -30.0f);
                    teamRect.offsetMax = new Vector2(-122.0f, 0.0f);
                    teamRect.sizeDelta = new Vector2(-152.0f, 30.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Text tvIndex;
        public Text tvState;

        public Button btnShow;

        public override void refresh()
        {
            base.refresh();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RoundContest roundContest = this.data.roundContest.v.data;
                    if (roundContest != null)
                    {
                        // tvIndex
                        {
                            if (tvIndex != null)
                            {
                                tvIndex.text = "" + (roundContest.index.v + 1);
                            }
                            else
                            {
                                Debug.LogError("tvIndex null: " + this);
                            }
                        }
                        // teams
                        {
                            // get old
                            List<ChooseRoundContestTeamUI.UIData> oldTeams = new List<ChooseRoundContestTeamUI.UIData>();
                            {
                                oldTeams.AddRange(this.data.teams.vs);
                            }
                            // Update
                            {
                                foreach (int teamIndex in roundContest.teamIndexs.vs)
                                {
                                    // find
                                    ChooseRoundContestTeamUI.UIData teamUIData = null;
                                    {
                                        // find old
                                        if (oldTeams.Count > 0)
                                        {
                                            teamUIData = oldTeams[0];
                                        }
                                        // make new
                                        if (teamUIData == null)
                                        {
                                            teamUIData = new ChooseRoundContestTeamUI.UIData();
                                            {
                                                teamUIData.uid = this.data.teams.makeId();
                                            }
                                            this.data.teams.add(teamUIData);
                                        }
                                        else
                                        {
                                            oldTeams.Remove(teamUIData);
                                        }
                                    }
                                    // update
                                    {
                                        teamUIData.roundContest.v = new ReferenceData<RoundContest>(roundContest);
                                        teamUIData.teamIndex.v = teamIndex;
                                    }
                                }
                            }
                            // remove old
                            foreach (ChooseRoundContestTeamUI.UIData oldTeam in oldTeams)
                            {
                                this.data.teams.remove(oldTeam);
                            }
                        }
                        // tvState
                        {
                            if (tvState != null)
                            {
                                switch (roundContest.contest.v.state.v.getType())
                                {
                                    case ContestState.Type.Load:
                                        tvState.text = txtLoad.get();
                                        break;
                                    case ContestState.Type.Start:
                                        tvState.text = txtStart.get();
                                        break;
                                    case ContestState.Type.Play:
                                        tvState.text = txtPlay.get();
                                        break;
                                    case ContestState.Type.End:
                                        tvState.text = txtEnd.get();
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + roundContest.contest.v.state.v.getType());
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("tvStatate null: " + this);
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // team
                            {
                                foreach (ChooseRoundContestTeamUI.UIData team in this.data.teams.vs)
                                {
                                    deltaY += UIRectTransform.SetPosY(team, deltaY);
                                }
                            }
                            // set
                            this.setHolderSize(Mathf.Max(30, deltaY));
                        }
                        // btnShow
                        {
                            if (btnShow != null)
                            {
                                bool isAlreadyShow = false;
                                {
                                    RoundRobinUI.UIData roundRobinUIData = this.data.findDataInParent<RoundRobinUI.UIData>();
                                    if (roundRobinUIData != null)
                                    {
                                        RoundContestUI.UIData roundContestUIData = roundRobinUIData.roundContestUIData.v;
                                        if (roundContestUIData != null)
                                        {
                                            if (roundContestUIData.roundContest.v.data == roundContest)
                                            {
                                                isAlreadyShow = true;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("roundContestUIData null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("roundRobinUIData null");
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
                                tvShow.text = txtShow.get();
                            }
                            else
                            {
                                Debug.LogError("tvShow null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("roundContest null: " + this);
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

        public ChooseRoundContestTeamUI teamPrefab;
        private static readonly UIRectTransform teamRect = new UIRectTransform();

        private RoundRobinUI.UIData roundRobinUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.roundRobinUIData);
                }
                // Child
                {
                    uiData.roundContest.allAddCallBack(this);
                    uiData.teams.allAddCallBack(this);
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
                if(data is RoundRobinUI.UIData)
                {
                    RoundRobinUI.UIData roundRobinUIData = data as RoundRobinUI.UIData;
                    // Child
                    {
                        roundRobinUIData.roundContestUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is RoundContestUI.UIData)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                // roundContest
                {
                    if (data is RoundContest)
                    {
                        RoundContest roundContest = data as RoundContest;
                        // Child
                        {
                            roundContest.contest.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Contest)
                    {
                        dirty = true;
                        return;
                    }
                }
                // teamUIData
                {
                    if (data is ChooseRoundContestTeamUI.UIData)
                    {
                        ChooseRoundContestTeamUI.UIData teamUIData = data as ChooseRoundContestTeamUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(teamUIData, teamPrefab, this.transform, teamRect);
                        }
                        // Child
                        {
                            TransformData.AddCallBack(teamUIData, this);
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.roundRobinUIData);
                }
                // Child
                {
                    uiData.roundContest.allRemoveCallBack(this);
                    uiData.teams.allRemoveCallBack(this);
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
                if (data is RoundRobinUI.UIData)
                {
                    RoundRobinUI.UIData roundRobinUIData = data as RoundRobinUI.UIData;
                    // Child
                    {
                        roundRobinUIData.roundContestUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is RoundContestUI.UIData)
                {
                    return;
                }
            }
            // Child
            {
                // roundContest
                {
                    if (data is RoundContest)
                    {
                        RoundContest roundContest = data as RoundContest;
                        // Child
                        {
                            roundContest.contest.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Contest)
                    {
                        return;
                    }
                }
                // teamUIData
                {
                    if (data is ChooseRoundContestTeamUI.UIData)
                    {
                        ChooseRoundContestTeamUI.UIData teamUIData = data as ChooseRoundContestTeamUI.UIData;
                        // Child
                        {
                            TransformData.RemoveCallBack(teamUIData, this);
                        }
                        // UI
                        {
                            teamUIData.removeCallBackAndDestroy(typeof(ChooseRoundContestTeamUI));
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
                    case UIData.Property.roundContest:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.teams:
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
                if (wrapProperty.p is RoundRobinUI.UIData)
                {
                    switch ((RoundRobinUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundRobinUI.UIData.Property.roundRobin:
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
                if (wrapProperty.p is RoundContestUI.UIData)
                {
                    switch ((RoundContestUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundContestUI.UIData.Property.roundContest:
                            dirty = true;
                            break;
                        case RoundContestUI.UIData.Property.contestUIData:
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
                // roundContest
                {
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
                    if (wrapProperty.p is Contest)
                    {
                        switch ((Contest.Property)wrapProperty.n)
                        {
                            case Contest.Property.state:
                                dirty = true;
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
                    }
                }
                // teamUIData
                {
                    if (wrapProperty.p is ChooseRoundContestTeamUI.UIData)
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

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnShow()
        {
            if (this.data != null)
            {
                RoundContest roundContest = this.data.roundContest.v.data;
                if (roundContest != null)
                {
                    RoundRobinUI.UIData roundRobinUIData = this.data.findDataInParent<RoundRobinUI.UIData>();
                    if (roundRobinUIData != null)
                    {
                        RoundContestUI.UIData roundContestUIData = roundRobinUIData.roundContestUIData.v;
                        if (roundContestUIData != null)
                        {
                            roundContestUIData.roundContest.v = new ReferenceData<RoundContest>(roundContest);
                        }
                        else
                        {
                            Debug.LogError("roundContestUIData null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("roundRobinUIData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("roundContest null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}