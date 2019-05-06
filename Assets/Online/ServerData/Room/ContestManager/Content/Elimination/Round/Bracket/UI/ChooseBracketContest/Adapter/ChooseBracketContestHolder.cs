using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class ChooseBracketContestHolder : SriaHolderBehavior<ChooseBracketContestHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<BracketContest>> bracketContest;

            public LP<ChooseBracketContestTeamUI.UIData> teams;

            #region Constructor

            public enum Property
            {
                bracketContest,
                teams
            }

            public UIData() : base()
            {
                this.bracketContest = new VP<ReferenceData<BracketContest>>(this, (byte)Property.bracketContest, new ReferenceData<BracketContest>(null));
                this.teams = new LP<ChooseBracketContestTeamUI.UIData>(this, (byte)Property.teams);
            }

            #endregion

            public void updateView(ChooseBracketContestAdapter.UIData myParams)
            {
                // Find
                BracketContest bracketContest = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.bracketContests.Count)
                    {
                        bracketContest = myParams.bracketContests[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.bracketContest.v = new ReferenceData<BracketContest>(bracketContest);
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
                            ChooseBracketContestHolder chooseBracketContestHolder = this.findCallBack<ChooseBracketContestHolder>();
                            if (chooseBracketContestHolder != null)
                            {
                                isProcess = chooseBracketContestHolder.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("chooseBracketContestHolder null: " + this);
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

        #region state

        private static readonly TxtLanguage txtLoad = new TxtLanguage("Loading");
        private static readonly TxtLanguage txtStart = new TxtLanguage("Starting");
        private static readonly TxtLanguage txtPlay = new TxtLanguage("Playing");
        private static readonly TxtLanguage txtEnd = new TxtLanguage("End");

        #endregion

        static ChooseBracketContestHolder()
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
                    BracketContest bracketContest = this.data.bracketContest.v.data;
                    if (bracketContest != null)
                    {
                        // tvIndex
                        {
                            if (tvIndex != null)
                            {
                                tvIndex.text = "" + (bracketContest.index.v + 1);
                            }
                            else
                            {
                                Debug.LogError("tvIndex null: " + this);
                            }
                        }
                        // teams
                        {
                            // get old
                            List<ChooseBracketContestTeamUI.UIData> oldTeams = new List<ChooseBracketContestTeamUI.UIData>();
                            {
                                oldTeams.AddRange(this.data.teams.vs);
                            }
                            // Update
                            {
                                foreach (int teamIndex in bracketContest.teamIndexs.vs)
                                {
                                    // find
                                    ChooseBracketContestTeamUI.UIData teamUIData = null;
                                    {
                                        // find old
                                        if (oldTeams.Count > 0)
                                        {
                                            teamUIData = oldTeams[0];
                                        }
                                        // make new
                                        if (teamUIData == null)
                                        {
                                            teamUIData = new ChooseBracketContestTeamUI.UIData();
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
                                        teamUIData.bracketContest.v = new ReferenceData<BracketContest>(bracketContest);
                                        teamUIData.teamIndex.v = teamIndex;
                                    }
                                }
                            }
                            // remove old
                            foreach (ChooseBracketContestTeamUI.UIData oldTeam in oldTeams)
                            {
                                this.data.teams.remove(oldTeam);
                            }
                        }
                        // tvState
                        {
                            if (tvState != null)
                            {
                                switch (bracketContest.contest.v.state.v.getType())
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
                                        Debug.LogError("unknown type: " + bracketContest.contest.v.state.v.getType());
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
                            // teams
                            {
                                foreach (ChooseBracketContestTeamUI.UIData team in this.data.teams.vs)
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
                                    BracketUI.UIData bracketUIData = this.data.findDataInParent<BracketUI.UIData>();
                                    if (bracketUIData != null)
                                    {
                                        BracketContestUI.UIData bracketContestUIData = bracketUIData.bracketContestUIData.v;
                                        if (bracketContestUIData != null)
                                        {
                                            if (bracketContestUIData.bracketContest.v.data == bracketContest)
                                            {
                                                isAlreadyShow = true;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("bracketContestUIData null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("bracketUIData null");
                                    }
                                }
                                btnShow.interactable = !isAlreadyShow;
                            }
                            else
                            {
                                Debug.LogError("btmShow null");
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
                        Debug.LogError("bracketContest null: " + this);
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

        public ChooseBracketContestTeamUI teamPrefab;
        private static readonly UIRectTransform teamRect = new UIRectTransform();

        private BracketUI.UIData bracketUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.bracketUIData);
                }
                // Child
                {
                    uiData.bracketContest.allAddCallBack(this);
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
                if(data is BracketUI.UIData)
                {
                    BracketUI.UIData bracketUIData = data as BracketUI.UIData;
                    // Child
                    {
                        bracketUIData.bracketContestUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is BracketContestUI.UIData)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                // bracketContest
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
                    if (data is Contest)
                    {
                        dirty = true;
                        return;
                    }
                }
                // teamUIData
                {
                    if (data is ChooseBracketContestTeamUI.UIData)
                    {
                        ChooseBracketContestTeamUI.UIData teamUIData = data as ChooseBracketContestTeamUI.UIData;
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.bracketUIData);
                }
                // Child
                {
                    uiData.bracketContest.allRemoveCallBack(this);
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
                if (data is BracketUI.UIData)
                {
                    BracketUI.UIData bracketUIData = data as BracketUI.UIData;
                    // Child
                    {
                        bracketUIData.bracketContestUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is BracketContestUI.UIData)
                {
                    return;
                }
            }
            // Child
            {
                // bracketContest
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
                    if (data is Contest)
                    {
                        return;
                    }
                }
                // teamUIData
                {
                    if (data is ChooseBracketContestTeamUI.UIData)
                    {
                        ChooseBracketContestTeamUI.UIData teamUIData = data as ChooseBracketContestTeamUI.UIData;
                        // Child
                        {
                            TransformData.RemoveCallBack(teamUIData, this);
                        }
                        // UI
                        {
                            teamUIData.removeCallBackAndDestroy(typeof(ChooseBracketContestTeamUI));
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
                    case UIData.Property.bracketContest:
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
                if (wrapProperty.p is BracketUI.UIData)
                {
                    switch ((BracketUI.UIData.Property)wrapProperty.n)
                    {
                        case BracketUI.UIData.Property.bracket:
                            break;
                        case BracketUI.UIData.Property.bracketContestUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case BracketUI.UIData.Property.chooseBracketContestUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is BracketContestUI.UIData)
                {
                    switch ((BracketContestUI.UIData.Property)wrapProperty.n)
                    {
                        case BracketContestUI.UIData.Property.bracketContest:
                            dirty = true;
                            break;
                        case BracketContestUI.UIData.Property.contestUIData:
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
                // bracketContest
                {
                    if (wrapProperty.p is BracketContest)
                    {
                        switch ((BracketContest.Property)wrapProperty.n)
                        {
                            case BracketContest.Property.isActive:
                                dirty = true;
                                break;
                            case BracketContest.Property.index:
                                dirty = true;
                                break;
                            case BracketContest.Property.teamIndexs:
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
                    if (wrapProperty.p is ChooseBracketContestTeamUI.UIData)
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

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {
                UIUtils.SetButtonOnClick(btnShow, onClickBtnShow);
            }
        }

        public bool useShortKey(Event e)
        {
            bool isProcess = false;
            {
                if (e.isKey && e.type == EventType.KeyUp)
                {
                    switch (e.keyCode)
                    {
                        case KeyCode.S:
                            {
                                if (btnShow != null && btnShow.gameObject.activeInHierarchy && btnShow.interactable)
                                {
                                    this.onClickBtnShow();
                                    isProcess = true;
                                }
                                else
                                {
                                    Debug.LogError("cannot click");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return isProcess;
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnShow()
        {
            if (this.data != null)
            {
                BracketContest bracketContest = this.data.bracketContest.v.data;
                if (bracketContest != null)
                {
                    BracketUI.UIData bracketUIData = this.data.findDataInParent<BracketUI.UIData>();
                    if (bracketUIData != null)
                    {
                        BracketContestUI.UIData bracketContestUIData = bracketUIData.bracketContestUIData.v;
                        if (bracketContestUIData != null)
                        {
                            bracketContestUIData.bracketContest.v = new ReferenceData<BracketContest>(bracketContest);
                        }
                        else
                        {
                            Debug.LogError("bracketContestUIData null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("bracketRobinUIData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("bracketContest null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}