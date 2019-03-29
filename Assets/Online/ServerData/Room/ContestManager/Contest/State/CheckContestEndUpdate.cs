using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class CheckContestEndUpdate : UpdateBehavior<Contest>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // init newTeamResults
                    List<TeamResult> newTeamResults = new List<TeamResult>();
                    {
                        foreach (MatchTeam team in this.data.teams.vs)
                        {
                            TeamResult newTeamResult = new TeamResult();
                            {
                                newTeamResult.teamIndex.v = team.teamIndex.v;
                            }
                            newTeamResults.Add(newTeamResult);
                        }
                    }
                    // Check contest end
                    bool isContestEnd = true;
                    {
                        // check all round end
                        if (isContestEnd)
                        {
                            bool allRoundEnd = true;
                            {
                                foreach (Round round in this.data.rounds.vs)
                                {
                                    if (round.state.v is RoundStateEnd)
                                    {
                                        RoundStateEnd roundStateEnd = round.state.v as RoundStateEnd;
                                        // add score
                                        foreach (TeamResult newTeamResult in newTeamResults)
                                        {
                                            newTeamResult.score.v += roundStateEnd.getResult(newTeamResult.teamIndex.v);
                                        }
                                    }
                                    else
                                    {
                                        allRoundEnd = false;
                                    }
                                }
                            }
                            Debug.LogError("allRoundEnd: " + allRoundEnd);
                            if (!allRoundEnd)
                            {
                                isContestEnd = false;
                            }
                        }
                        // check can make more round
                        if (isContestEnd)
                        {
                            bool canMakeMoreRound = true;
                            {
                                RequestNewRound requestNewRound = this.data.requestNewRound.v;
                                if (requestNewRound != null)
                                {
                                    canMakeMoreRound = requestNewRound.isCanMakeNewRound();
                                }
                                else
                                {
                                    Debug.LogError("requestNewRound null: " + this);
                                }
                            }
                            if (canMakeMoreRound)
                            {
                                isContestEnd = false;
                            }
                            else
                            {
                                Debug.LogError("cannot make new round: " + this);
                            }
                        }
                    }
                    // edit teamResult
                    {
                        if (this.data.teams.vs.Count == 2)
                        {
                            if (newTeamResults.Count == 2)
                            {
                                switch (this.data.calculateScore.v.getType())
                                {
                                    case CalculateScore.Type.Sum:
                                        break;
                                    case CalculateScore.Type.WinLoseDraw:
                                        {
                                            CalculateScoreWinLoseDraw winLoseDraw = this.data.calculateScore.v as CalculateScoreWinLoseDraw;
                                            // win
                                            if (newTeamResults[0].score.v > newTeamResults[1].score.v)
                                            {
                                                newTeamResults[0].score.v = winLoseDraw.winScore.v;
                                                newTeamResults[1].score.v = winLoseDraw.loseScore.v;
                                            }
                                            // lose
                                            else if (newTeamResults[0].score.v < newTeamResults[1].score.v)
                                            {
                                                newTeamResults[0].score.v = winLoseDraw.loseScore.v;
                                                newTeamResults[1].score.v = winLoseDraw.winScore.v;
                                            }
                                            else
                                            {
                                                newTeamResults[0].score.v = winLoseDraw.drawScore.v;
                                                newTeamResults[1].score.v = winLoseDraw.drawScore.v;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + this.data.calculateScore.v.getType() + "; " + this);
                                        break;
                                }
                            }
                        }
                    }
                    // Process
                    {
                        if (isContestEnd)
                        {
                            // Find End
                            ContestStateEnd end = null;
                            {
                                if (this.data.state.v is ContestStateEnd)
                                {
                                    // find old
                                    end = this.data.state.v as ContestStateEnd;
                                }
                                else
                                {
                                    // make new
                                    end = new ContestStateEnd();
                                    {
                                        end.uid = this.data.state.makeId();
                                    }
                                    this.data.state.v = end;
                                }
                            }
                            // Update Property
                            {
                                // get old
                                List<TeamResult> oldTeamResults = new List<TeamResult>();
                                {
                                    oldTeamResults.AddRange(end.teamResults.vs);
                                }
                                // Update
                                {
                                    foreach (TeamResult newTeamResult in newTeamResults)
                                    {
                                        // Find TeamResult
                                        TeamResult teamResult = null;
                                        {
                                            // find old
                                            if (oldTeamResults.Count > 0)
                                            {
                                                teamResult = oldTeamResults[0];
                                            }
                                            // make new
                                            if (teamResult == null)
                                            {
                                                teamResult = new TeamResult();
                                                {
                                                    teamResult.uid = end.teamResults.makeId();
                                                }
                                                end.teamResults.add(teamResult);
                                            }
                                            else
                                            {
                                                oldTeamResults.Remove(teamResult);
                                            }
                                        }
                                        // Update
                                        {
                                            teamResult.teamIndex.v = newTeamResult.teamIndex.v;
                                            teamResult.score.v = newTeamResult.score.v;
                                        }
                                    }
                                }
                                // Remove old
                                foreach (TeamResult oldTeamResult in oldTeamResults)
                                {
                                    end.teamResults.remove(oldTeamResult);
                                }
                            }
                        }
                        else
                        {
                            // Find play
                            ContestStatePlay play = null;
                            {
                                if (this.data.state.v is ContestStatePlay)
                                {
                                    // find old
                                    play = this.data.state.v as ContestStatePlay;
                                }
                                else
                                {
                                    // make new
                                    play = new ContestStatePlay();
                                    {
                                        play.uid = this.data.state.makeId();
                                    }
                                    this.data.state.v = play;
                                }
                            }
                            // Update Property
                            {

                            }
                        }
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

        private CheckCanMakeNewRoundChange<Contest> checkCanMakeNewRoundChange = new CheckCanMakeNewRoundChange<Contest>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is Contest)
            {
                Contest contest = data as Contest;
                // CheckChange
                {
                    checkCanMakeNewRoundChange.addCallBack(this);
                    checkCanMakeNewRoundChange.setData(contest);
                }
                // Child
                {
                    contest.rounds.allAddCallBack(this);
                    contest.requestNewRound.allAddCallBack(this);
                    contest.calculateScore.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // CheckChange
            if (data is CheckCanMakeNewRoundChange<Contest>)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // Round
                {
                    if (data is Round)
                    {
                        Round round = data as Round;
                        // Child
                        {
                            round.state.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is RoundState)
                        {
                            RoundState roundState = data as RoundState;
                            // Child
                            {
                                switch (roundState.getType())
                                {
                                    case RoundState.Type.Load:
                                        break;
                                    case RoundState.Type.Start:
                                        break;
                                    case RoundState.Type.Play:
                                        break;
                                    case RoundState.Type.End:
                                        {
                                            RoundStateEnd end = roundState as RoundStateEnd;
                                            end.teamResults.allAddCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + roundState.getType() + "; " + this);
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
                // requestNewRound
                {
                    if (data is RequestNewRound)
                    {
                        RequestNewRound requestNewRound = data as RequestNewRound;
                        // Child
                        {
                            requestNewRound.limit.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is RequestNewRound.Limit)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is CalculateScore)
                {
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is Contest)
            {
                Contest contest = data as Contest;
                // CheckChange
                {
                    checkCanMakeNewRoundChange.removeCallBack(this);
                    checkCanMakeNewRoundChange.setData(null);
                }
                // Child
                {
                    contest.rounds.allRemoveCallBack(this);
                    contest.requestNewRound.allRemoveCallBack(this);
                    contest.calculateScore.allRemoveCallBack(this);
                }
                this.setDataNull(contest);
                return;
            }
            // CheckChange
            if (data is CheckCanMakeNewRoundChange<Contest>)
            {
                return;
            }
            // Child
            {
                // round
                {
                    if (data is Round)
                    {
                        Round round = data as Round;
                        // Child
                        {
                            round.state.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is RoundState)
                        {
                            RoundState roundState = data as RoundState;
                            // Child
                            {
                                switch (roundState.getType())
                                {
                                    case RoundState.Type.Load:
                                        break;
                                    case RoundState.Type.Start:
                                        break;
                                    case RoundState.Type.Play:
                                        break;
                                    case RoundState.Type.End:
                                        {
                                            RoundStateEnd end = roundState as RoundStateEnd;
                                            end.teamResults.allRemoveCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + roundState.getType() + "; " + this);
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
                // requestNewRound
                {
                    if (data is RequestNewRound)
                    {
                        RequestNewRound requestNewRound = data as RequestNewRound;
                        // Child
                        {
                            requestNewRound.limit.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is RequestNewRound.Limit)
                    {
                        return;
                    }
                }
                if (data is CalculateScore)
                {
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
            if (wrapProperty.p is Contest)
            {
                switch ((Contest.Property)wrapProperty.n)
                {
                    case Contest.Property.state:
                        break;
                    case Contest.Property.calculateScore:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case Contest.Property.playerPerTeam:
                        break;
                    case Contest.Property.teams:
                        dirty = true;
                        break;
                    case Contest.Property.roundFactory:
                        break;
                    case Contest.Property.rounds:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case Contest.Property.requestNewRound:
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
            // CheckChange
            if (wrapProperty.p is CheckCanMakeNewRoundChange<Contest>)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // round
                {
                    if (wrapProperty.p is Round)
                    {
                        switch ((Round.Property)wrapProperty.n)
                        {
                            case Round.Property.state:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case Round.Property.index:
                                break;
                            case Round.Property.roundGames:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is RoundState)
                        {
                            RoundState roundState = wrapProperty.p as RoundState;
                            // Child
                            {
                                switch (roundState.getType())
                                {
                                    case RoundState.Type.Load:
                                        break;
                                    case RoundState.Type.Start:
                                        break;
                                    case RoundState.Type.Play:
                                        break;
                                    case RoundState.Type.End:
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
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + roundState.getType() + "; " + this);
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
                // requestNewRound
                {
                    if (wrapProperty.p is RequestNewRound)
                    {
                        switch ((RequestNewRound.Property)wrapProperty.n)
                        {
                            case RequestNewRound.Property.state:
                                break;
                            case RequestNewRound.Property.limit:
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
                    if (wrapProperty.p is RequestNewRound.Limit)
                    {
                        RequestNewRound.Limit limit = wrapProperty.p as RequestNewRound.Limit;
                        switch (limit.getType())
                        {
                            case RequestNewRound.Limit.Type.NoLimit:
                                {
                                    switch ((RequestNewRoundNoLimit.Property)wrapProperty.n)
                                    {
                                        case RequestNewRoundNoLimit.Property.isStopMakeMoreRound:
                                            dirty = true;
                                            break;
                                        default:
                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                            break;
                                    }
                                }
                                break;
                            case RequestNewRound.Limit.Type.HaveLimit:
                                {
                                    switch ((RequestNewRoundHaveLimit.Property)wrapProperty.n)
                                    {
                                        case RequestNewRoundHaveLimit.Property.maxRound:
                                            dirty = true;
                                            break;
                                        case RequestNewRoundHaveLimit.Property.enoughScoreStop:
                                            dirty = true;
                                            break;
                                        default:
                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                            break;
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + limit.getType() + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                if (wrapProperty.p is CalculateScore)
                {
                    CalculateScore calculateScore = wrapProperty.p as CalculateScore;
                    switch (calculateScore.getType())
                    {
                        case CalculateScore.Type.Sum:
                            break;
                        case CalculateScore.Type.WinLoseDraw:
                            {
                                switch ((CalculateScoreWinLoseDraw.Property)wrapProperty.n)
                                {
                                    case CalculateScoreWinLoseDraw.Property.winScore:
                                        dirty = true;
                                        break;
                                    case CalculateScoreWinLoseDraw.Property.loseScore:
                                        dirty = true;
                                        break;
                                    case CalculateScoreWinLoseDraw.Property.drawScore:
                                        dirty = true;
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + calculateScore + "; " + this);
                            break;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}