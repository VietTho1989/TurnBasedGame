using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RoundStateEndUI : UIHaveTransformDataBehavior<RoundStateEndUI.UIData>
    {

        #region UIData

        public class UIData : RoundState.UIData
        {

            public VP<ReferenceData<RoundStateEnd>> roundStateEnd;

            public LP<TeamResultUI.UIData> teamResults;

            #region Constructor

            public enum Property
            {
                roundStateEnd,
                teamResults
            }

            public UIData() : base()
            {
                this.roundStateEnd = new VP<ReferenceData<RoundStateEnd>>(this, (byte)Property.roundStateEnd, new ReferenceData<RoundStateEnd>(null));
                this.teamResults = new LP<TeamResultUI.UIData>(this, (byte)Property.teamResults);
            }

            #endregion

            public override RoundState.Type getType()
            {
                return RoundState.Type.End;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtEnd = new TxtLanguage("End");

        static RoundStateEndUI()
        {
            txtEnd.add(Language.Type.vi, "Kết Thúc");
        }

        #endregion

        #region Refresh

        public Text tvEnd;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RoundStateEnd roundStateEnd = this.data.roundStateEnd.v.data;
                    if (roundStateEnd != null)
                    {
                        // tvEnd
                        if (tvEnd != null)
                        {
                            tvEnd.text = txtEnd.get();
                        }
                        else
                        {
                            Debug.LogError("tvEnd null: " + this);
                        }
                        // teamResults
                        {
                            // get list
                            List<TeamResult> teamResults = new List<TeamResult>();
                            {
                                teamResults.AddRange(roundStateEnd.teamResults.vs);
                                teamResults.Sort(delegate (TeamResult p1, TeamResult p2)
                                {
                                    return p1.teamIndex.v.CompareTo(p2.teamIndex.v);
                                });
                            }
                            // make UI
                            {
                                // get old
                                List<TeamResultUI.UIData> oldTeamResults = new List<TeamResultUI.UIData>();
                                {
                                    oldTeamResults.AddRange(this.data.teamResults.vs);
                                }
                                // make
                                {
                                    foreach(TeamResult teamResult in teamResults)
                                    {
                                        // find UI
                                        TeamResultUI.UIData teamResultUIData = null;
                                        bool needAdd = false;
                                        {
                                            // find old
                                            if (oldTeamResults.Count > 0)
                                            {
                                                teamResultUIData = oldTeamResults[0];
                                            }
                                            // make new
                                            if (teamResultUIData == null)
                                            {
                                                teamResultUIData = new TeamResultUI.UIData();
                                                {
                                                    teamResultUIData.uid = this.data.teamResults.makeId();
                                                }
                                                needAdd = true;
                                            }
                                            else
                                            {
                                                oldTeamResults.Remove(teamResultUIData);
                                            }
                                        }
                                        // Update
                                        {
                                            teamResultUIData.teamResult.v = new ReferenceData<TeamResult>(teamResult);
                                        }
                                        // add
                                        if (needAdd)
                                        {
                                            this.data.teamResults.add(teamResultUIData);
                                        }
                                    }
                                }
                                // remove old
                                foreach(TeamResultUI.UIData oldTeamResult in oldTeamResults)
                                {
                                    this.data.teamResults.remove(oldTeamResult);
                                }
                            }
                        }
                        // UI
                        {
                            float deltaY = 20;
                            // teamResults
                            {
                                foreach(TeamResultUI.UIData teamResultUIData in this.data.teamResults.vs)
                                {
                                    deltaY += UIRectTransform.SetPosY(teamResultUIData, deltaY);
                                }
                            }
                            // set
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                        }
                    }
                    else
                    {
                        Debug.LogError("roundStateEnd null: " + this);
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

        public TeamResultUI teamResultPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.roundStateEnd.allAddCallBack(this);
                    uiData.teamResults.allAddCallBack(this);
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
                // roundStateEnd
                {
                    if (data is RoundStateEnd)
                    {
                        RoundStateEnd roundStateEnd = data as RoundStateEnd;
                        // Child
                        {
                            roundStateEnd.teamResults.allAddCallBack(this);
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
                if(data is TeamResultUI.UIData)
                {
                    TeamResultUI.UIData teamResultUIData = data as TeamResultUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(teamResultUIData, teamResultPrefab, this.transform);
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
                    uiData.roundStateEnd.allRemoveCallBack(this);
                    uiData.teamResults.allRemoveCallBack(this);
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
                // roundStateEnd
                {
                    if (data is RoundStateEnd)
                    {
                        RoundStateEnd roundStateEnd = data as RoundStateEnd;
                        // Child
                        {
                            roundStateEnd.teamResults.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is TeamResult)
                    {
                        return;
                    }
                }
                if (data is TeamResultUI.UIData)
                {
                    TeamResultUI.UIData teamResultUIData = data as TeamResultUI.UIData;
                    // UI
                    {
                        teamResultUIData.removeCallBackAndDestroy(typeof(TeamResultUI));
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
                    case UIData.Property.roundStateEnd:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.teamResults:
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
                // roundStateEnd
                {
                    if (wrapProperty.p is RoundStateEnd)
                    {
                        switch ((RoundStateEnd.Property)wrapProperty.n)
                        {
                            case RoundStateEnd.Property.teamResults:
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
                if (wrapProperty.p is TeamResultUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}