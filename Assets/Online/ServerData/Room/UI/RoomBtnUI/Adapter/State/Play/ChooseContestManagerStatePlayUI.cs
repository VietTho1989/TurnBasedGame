using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class ChooseContestManagerStatePlayUI : UIHaveTransformDataBehavior<ChooseContestManagerStatePlayUI.UIData>
    {

        #region UIData

        public class UIData : ChooseContestManagerHolder.UIData.StateUI
        {

            public VP<ReferenceData<ContestManagerStatePlay>> contestManagerStatePlay;

            public LP<ChooseContestManagerTeamUI.UIData> teams;

            #region Constructor

            public enum Property
            {
                contestManagerStatePlay,
                teams
            }

            public UIData() : base()
            {
                this.contestManagerStatePlay = new VP<ReferenceData<ContestManagerStatePlay>>(this, (byte)Property.contestManagerStatePlay, new ReferenceData<ContestManagerStatePlay>(null));
                this.teams = new LP<ChooseContestManagerTeamUI.UIData>(this, (byte)Property.teams);
            }

            #endregion

            public override ContestManager.State.Type getType()
            {
                return ContestManager.State.Type.Play;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtPlaying = new TxtLanguage();
        private static readonly TxtLanguage txtEnd = new TxtLanguage();

        static ChooseContestManagerStatePlayUI()
        {
            txtPlaying.add(Language.Type.vi, "Đang Chơi");
            txtEnd.add(Language.Type.vi, "Đã Kết Thúc");
        }

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ContestManagerStatePlay contestManagerStatePlay = this.data.contestManagerStatePlay.v.data;
                    if (contestManagerStatePlay != null)
                    {
                        // title
                        {
                            if (lbTitle != null)
                            {
                                switch (contestManagerStatePlay.state.v.getType())
                                {
                                    case ContestManagerStatePlay.State.Type.Normal:
                                        lbTitle.text = txtPlaying.get("Playing");
                                        break;
                                    case ContestManagerStatePlay.State.Type.End:
                                        lbTitle.text = txtEnd.get("End");
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + contestManagerStatePlay.state.v.getType());
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                        }
                        // teams
                        {
                            // get old
                            List<ChooseContestManagerTeamUI.UIData> oldTeams = new List<ChooseContestManagerTeamUI.UIData>();
                            {
                                oldTeams.AddRange(this.data.teams.vs);
                            }
                            // Update
                            {
                                // get teams
                                List<MatchTeam> matchTeams = new List<MatchTeam>();
                                {
                                    matchTeams.AddRange(contestManagerStatePlay.teams.vs);

                                }
                                foreach (MatchTeam matchTeam in matchTeams)
                                {
                                    // find
                                    ChooseContestManagerTeamUI.UIData teamUIData = null;
                                    {
                                        // find old
                                        if (oldTeams.Count > 0)
                                        {
                                            teamUIData = oldTeams[0];
                                        }
                                        // make new
                                        if (teamUIData == null)
                                        {
                                            teamUIData = new ChooseContestManagerTeamUI.UIData();
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
                                        teamUIData.matchTeam.v = new ReferenceData<MatchTeam>(matchTeam);
                                    }
                                }
                            }
                            // Remove old
                            foreach (ChooseContestManagerTeamUI.UIData oldTeam in oldTeams)
                            {
                                this.data.teams.remove(oldTeam);
                            }
                        }
                        // UI
                        {
                            float deltaY = 20;
                            // teams
                            {
                                foreach (ChooseContestManagerTeamUI.UIData teamUIData in this.data.teams.vs)
                                {
                                    deltaY += UIRectTransform.SetPosY(teamUIData, deltaY);
                                }
                            }
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                        }
                    }
                    else
                    {
                        Debug.LogError("contestManagerStatePlay null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public ChooseContestManagerTeamUI teamPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.contestManagerStatePlay.allAddCallBack(this);
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
            // Child
            {
                if (data is ContestManagerStatePlay)
                {
                    dirty = true;
                    return;
                }
                if (data is ChooseContestManagerTeamUI.UIData)
                {
                    ChooseContestManagerTeamUI.UIData teamUIData = data as ChooseContestManagerTeamUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(teamUIData, teamPrefab, this.transform);
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
                    uiData.contestManagerStatePlay.allRemoveCallBack(this);
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
            // Child
            {
                if (data is ContestManagerStatePlay)
                {
                    return;
                }
                if (data is ChooseContestManagerTeamUI.UIData)
                {
                    ChooseContestManagerTeamUI.UIData teamUIData = data as ChooseContestManagerTeamUI.UIData;
                    // UI
                    {
                        teamUIData.removeCallBackAndDestroy(typeof(ChooseContestManagerTeamUI));
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
                    case UIData.Property.contestManagerStatePlay:
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
            // Child
            {
                if (wrapProperty.p is ContestManagerStatePlay)
                {
                    switch ((ContestManagerStatePlay.Property)wrapProperty.n)
                    {
                        case ContestManagerStatePlay.Property.state:
                            dirty = true;
                            break;
                        case ContestManagerStatePlay.Property.isForceEnd:
                            break;
                        case ContestManagerStatePlay.Property.teams:
                            dirty = true;
                            break;
                        case ContestManagerStatePlay.Property.content:
                            break;
                        case ContestManagerStatePlay.Property.contentTeamResult:
                            break;
                        case ContestManagerStatePlay.Property.randomTeamIndex:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is ChooseContestManagerTeamUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}