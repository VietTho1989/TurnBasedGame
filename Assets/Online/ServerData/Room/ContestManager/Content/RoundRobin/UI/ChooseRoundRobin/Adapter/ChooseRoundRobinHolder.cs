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

            public LP<ChooseRoundRobinTeamUI.UIData> teams;

            #region Constructor

            public enum Property
            {
                roundRobin,
                teams
            }

            public UIData() : base()
            {
                this.roundRobin = new VP<ReferenceData<RoundRobin>>(this, (byte)Property.roundRobin, new ReferenceData<RoundRobin>(null));
                this.teams = new LP<ChooseRoundRobinTeamUI.UIData>(this, (byte)Property.teams);
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

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ChooseRoundRobinHolder chooseRoundRobinHolder = this.findCallBack<ChooseRoundRobinHolder>();
                            if (chooseRoundRobinHolder != null)
                            {
                                isProcess = chooseRoundRobinHolder.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("chooseRoundRobinHolder null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text tvShow;
        private static readonly TxtLanguage txtShow = new TxtLanguage("Show");

        #region txt

        private static readonly TxtLanguage txtLoad = new TxtLanguage("Loading");
        private static readonly TxtLanguage txtStart = new TxtLanguage("Starting");
        private static readonly TxtLanguage txtPlay = new TxtLanguage("Playing");
        private static readonly TxtLanguage txtEnd = new TxtLanguage("End");

        #endregion

        static ChooseRoundRobinHolder()
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
                        // tvState
                        {
                            if (tvState != null)
                            {
                                switch (roundRobin.state.v.getType())
                                {
                                    case RoundRobin.State.Type.Load:
                                        tvState.text = txtLoad.get();
                                        break;
                                    case RoundRobin.State.Type.Start:
                                        tvState.text = txtStart.get();
                                        break;
                                    case RoundRobin.State.Type.Play:
                                        tvState.text = txtPlay.get();
                                        break;
                                    case RoundRobin.State.Type.End:
                                        tvState.text = txtEnd.get();
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + roundRobin.state.v.getType());
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("tvState null");
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
                                tvShow.text = txtShow.get();
                            }
                            else
                            {
                                Debug.LogError("tvShow null");
                            }
                        }
                        // teams
                        {
                            // get team list
                            List<TeamResult> teamResults = new List<TeamResult>();
                            {
                                // get
                                ContestManagerStatePlay play = roundRobin.findDataInParent<ContestManagerStatePlay>();
                                if (play != null)
                                {
                                    RoundRobinContent roundRobinContent = roundRobin.findDataInParent<RoundRobinContent>();
                                    if (roundRobinContent != null)
                                    {
                                        foreach(MatchTeam matchTeam in play.teams.vs)
                                        {
                                            TeamResult teamResult = new TeamResult();
                                            {
                                                teamResult.teamIndex.v = matchTeam.teamIndex.v;
                                                // score
                                                {
                                                    float score = 0;
                                                    {
                                                        foreach (RoundRobin check in roundRobinContent.roundRobins.vs)
                                                        {
                                                            if (check.index.v <= roundRobin.index.v)
                                                            {
                                                                if (check.state.v.getType() == RoundRobin.State.Type.End)
                                                                {
                                                                    RoundRobinStateEnd end = check.state.v as RoundRobinStateEnd;
                                                                    score += end.getResult(matchTeam.teamIndex.v);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    teamResult.score.v = score;
                                                }
                                            }
                                            teamResults.Add(teamResult);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("roundRobinContent null");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("play null");
                                }
                                // sort
                                teamResults.Sort(delegate (TeamResult p1, TeamResult p2)
                                {
                                    return p2.score.v.CompareTo(p1.score.v);
                                });
                            }
                            // make UI
                            {
                                // get old
                                List<ChooseRoundRobinTeamUI.UIData> oldTeamUIDatas = new List<ChooseRoundRobinTeamUI.UIData>();
                                {
                                    oldTeamUIDatas.AddRange(this.data.teams.vs);
                                }
                                // make UI
                                {
                                    foreach (TeamResult teamResult in teamResults)
                                    {
                                        // find UI
                                        ChooseRoundRobinTeamUI.UIData teamUIData = null;
                                        bool needAdd = false;
                                        {
                                            // find old
                                            if (oldTeamUIDatas.Count > 0)
                                            {
                                                teamUIData = oldTeamUIDatas[0];
                                            }
                                            // make new
                                            if (teamUIData == null)
                                            {
                                                teamUIData = new ChooseRoundRobinTeamUI.UIData();
                                                {
                                                    teamUIData.uid = this.data.teams.makeId();
                                                }
                                                needAdd = true;
                                            }
                                            else
                                            {
                                                oldTeamUIDatas.Remove(teamUIData);
                                            }
                                        }
                                        // update
                                        {
                                            teamUIData.teamIndex.v = teamResult.teamIndex.v;
                                            teamUIData.score.v = teamResult.score.v;
                                        }
                                        // add
                                        if (needAdd)
                                        {
                                            this.data.teams.add(teamUIData);
                                        }
                                    }
                                }
                                // remove old
                                foreach(ChooseRoundRobinTeamUI.UIData teamUIData in oldTeamUIDatas)
                                {
                                    this.data.teams.remove(teamUIData);
                                }
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // teams
                            {
                                foreach(ChooseRoundRobinTeamUI.UIData team in this.data.teams.vs)
                                {
                                    deltaY += UIRectTransform.SetPosY(team, deltaY);
                                }
                            }
                            // set
                            this.setHolderSize(Mathf.Max(30, deltaY));
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

        public ChooseRoundRobinTeamUI teamPrefab;
        private static readonly UIRectTransform teamRect = new UIRectTransform();

        private ChooseRoundRobinHolderScoreCheckChange<RoundRobin> chooseRoundRobinHolderScoreCheckChange = new ChooseRoundRobinHolderScoreCheckChange<RoundRobin>();

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
                    uiData.teams.allAddCallBack(this);
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
            {
                // roundRobin
                {
                    if (data is RoundRobin)
                    {
                        RoundRobin roundRobin = data as RoundRobin;
                        // checkChange
                        {
                            chooseRoundRobinHolderScoreCheckChange.addCallBack(this);
                            chooseRoundRobinHolderScoreCheckChange.setData(roundRobin);
                        }
                        dirty = true;
                        return;
                    }
                    // checkChange
                    if (data is ChooseRoundRobinHolderScoreCheckChange<RoundRobin>)
                    {
                        dirty = true;
                        return;
                    }
                }
                if(data is ChooseRoundRobinTeamUI.UIData)
                {
                    ChooseRoundRobinTeamUI.UIData teamUIData = data as ChooseRoundRobinTeamUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(teamUIData, teamPrefab, this.transform, teamRect);
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.roundRobinContentUIData);
                }
                // Child
                {
                    uiData.roundRobin.allRemoveCallBack(this);
                    uiData.teams.allRemoveCallBack(this);
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
            {
                // roundRobin
                {
                    if (data is RoundRobin)
                    {
                        // checkChange
                        {
                            chooseRoundRobinHolderScoreCheckChange.removeCallBack(this);
                            chooseRoundRobinHolderScoreCheckChange.setData(null);
                        }
                        return;
                    }
                    // checkChange
                    if (data is ChooseRoundRobinHolderScoreCheckChange<RoundRobin>)
                    {
                        return;
                    }
                }
                if (data is ChooseRoundRobinTeamUI.UIData)
                {
                    ChooseRoundRobinTeamUI.UIData teamUIData = data as ChooseRoundRobinTeamUI.UIData;
                    // UI
                    {
                        teamUIData.removeCallBackAndDestroy(typeof(ChooseRoundRobinTeamUI));
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
                    case UIData.Property.roundRobin:
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
            {
                // roundRobin
                {
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
                    // checkChange
                    if (wrapProperty.p is ChooseRoundRobinHolderScoreCheckChange<RoundRobin>)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (wrapProperty.p is ChooseRoundRobinTeamUI.UIData)
                {
                    return;
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