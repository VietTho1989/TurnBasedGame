using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match.RoundRobin;

namespace GameManager.Match
{
    public class ChooseRoundRobinHolderScoreCheckChange<K> : Data, ValueChangeCallBack where K : Data
    {

        public VP<int> change;

        private void notifyChange()
        {
            this.change.v = this.change.v + 1;
        }

        #region Constructor

        public enum Property
        {
            change
        }

        public ChooseRoundRobinHolderScoreCheckChange() : base()
        {
            this.change = new VP<int>(this, (byte)Property.change, 0);
        }

        #endregion

        public K data;

        public void setData(K newData)
        {
            if (this.data != newData)
            {
                // remove old
                {
                    DataUtils.removeParentCallBack(this.data, this, ref this.contestManagerStatePlay);
                }
                // set new 
                {
                    this.data = newData;
                    DataUtils.addParentCallBack(this.data, this, ref this.contestManagerStatePlay);
                }
            }
            else
            {
                Debug.LogError("the same: " + this + ", " + data + ", " + newData);
            }
        }

        #region implement callBacks

        private ContestManagerStatePlay contestManagerStatePlay = null;

        public void onAddCallBack<T>(T data) where T : Data
        {
            if(data is ContestManagerStatePlay)
            {
                ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                // Child
                {
                    contestManagerStatePlay.teams.allAddCallBack(this);
                    contestManagerStatePlay.content.allAddCallBack(this);
                }
                this.notifyChange();
                return;
            }
            // Child
            {
                // teams
                if (data is MatchTeam)
                {
                    this.notifyChange();
                    return;
                }
                // content
                {
                    if(data is ContestManagerContent)
                    {
                        ContestManagerContent contestManagerContent = data as ContestManagerContent;
                        // Child
                        {
                            switch (contestManagerContent.getType())
                            {
                                case ContestManagerContent.Type.Single:
                                    break;
                                case ContestManagerContent.Type.RoundRobin:
                                    {
                                        RoundRobinContent roundRobinContent = contestManagerContent as RoundRobinContent;
                                        roundRobinContent.roundRobins.allAddCallBack(this);
                                    }
                                    break;
                                case ContestManagerContent.Type.Elimination:
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + contestManagerContent.getType());
                                    break;
                            }
                        }
                        this.notifyChange();
                        return;
                    }
                    // Child
                    {
                        if(data is RoundRobin.RoundRobin)
                        {
                            RoundRobin.RoundRobin roundRobin = data as RoundRobin.RoundRobin;
                            // Child
                            {
                                roundRobin.state.allAddCallBack(this);
                            }
                            this.notifyChange();
                            return;
                        }
                        // Child
                        {
                            if(data is RoundRobin.RoundRobin.State)
                            {
                                RoundRobin.RoundRobin.State state = data as RoundRobin.RoundRobin.State;
                                // Child
                                {
                                    switch (state.getType())
                                    {
                                        case RoundRobin.RoundRobin.State.Type.Load:
                                            break;
                                        case RoundRobin.RoundRobin.State.Type.Start:
                                            break;
                                        case RoundRobin.RoundRobin.State.Type.Play:
                                            break;
                                        case RoundRobin.RoundRobin.State.Type.End:
                                            {
                                                RoundRobinStateEnd end = state as RoundRobinStateEnd;
                                                end.teamResults.allAddCallBack(this);
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + state.getType());
                                            break;
                                    }
                                }
                                this.notifyChange();
                                return;
                            }
                            // Child
                            if(data is TeamResult)
                            {
                                this.notifyChange();
                                return;
                            }
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
        {
            if (data is ContestManagerStatePlay)
            {
                ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                // Child
                {
                    contestManagerStatePlay.teams.allRemoveCallBack(this);
                    contestManagerStatePlay.content.allRemoveCallBack(this);
                }
                // set data null
                {
                    if (this.contestManagerStatePlay == contestManagerStatePlay)
                    {
                        this.contestManagerStatePlay = null;
                    }
                }
                return;
            }
            // Child
            {
                // teams
                if (data is MatchTeam)
                {
                    return;
                }
                // content
                {
                    if (data is ContestManagerContent)
                    {
                        ContestManagerContent contestManagerContent = data as ContestManagerContent;
                        // Child
                        {
                            switch (contestManagerContent.getType())
                            {
                                case ContestManagerContent.Type.Single:
                                    break;
                                case ContestManagerContent.Type.RoundRobin:
                                    {
                                        RoundRobinContent roundRobinContent = contestManagerContent as RoundRobinContent;
                                        roundRobinContent.roundRobins.allRemoveCallBack(this);
                                    }
                                    break;
                                case ContestManagerContent.Type.Elimination:
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + contestManagerContent.getType());
                                    break;
                            }
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is RoundRobin.RoundRobin)
                        {
                            RoundRobin.RoundRobin roundRobin = data as RoundRobin.RoundRobin;
                            // Child
                            {
                                roundRobin.state.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        {
                            if (data is RoundRobin.RoundRobin.State)
                            {
                                RoundRobin.RoundRobin.State state = data as RoundRobin.RoundRobin.State;
                                // Child
                                {
                                    switch (state.getType())
                                    {
                                        case RoundRobin.RoundRobin.State.Type.Load:
                                            break;
                                        case RoundRobin.RoundRobin.State.Type.Start:
                                            break;
                                        case RoundRobin.RoundRobin.State.Type.Play:
                                            break;
                                        case RoundRobin.RoundRobin.State.Type.End:
                                            {
                                                RoundRobinStateEnd end = state as RoundRobinStateEnd;
                                                end.teamResults.allRemoveCallBack(this);
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + state.getType());
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
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is ContestManagerStatePlay)
            {
                switch ((ContestManagerStatePlay.Property)wrapProperty.n)
                {
                    case ContestManagerStatePlay.Property.state:
                        break;
                    case ContestManagerStatePlay.Property.isForceEnd:
                        break;
                    case ContestManagerStatePlay.Property.teams:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            this.notifyChange();
                        }
                        break;
                    case ContestManagerStatePlay.Property.swap:
                        break;
                    case ContestManagerStatePlay.Property.content:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            this.notifyChange();
                        }
                        break;
                    case ContestManagerStatePlay.Property.contentTeamResult:
                        break;
                    case ContestManagerStatePlay.Property.gameTypeType:
                        break;
                    case ContestManagerStatePlay.Property.randomTeamIndex:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                // teams
                if (wrapProperty.p is MatchTeam)
                {
                    switch ((MatchTeam.Property)wrapProperty.n)
                    {
                        case MatchTeam.Property.teamIndex:
                            this.notifyChange();
                            break;
                        case MatchTeam.Property.state:
                            break;
                        case MatchTeam.Property.players:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }

                    this.notifyChange();
                    return;
                }
                // content
                {
                    if (wrapProperty.p is ContestManagerContent)
                    {
                        ContestManagerContent contestManagerContent = wrapProperty.p as ContestManagerContent;
                        // Child
                        {
                            switch (contestManagerContent.getType())
                            {
                                case ContestManagerContent.Type.Single:
                                    break;
                                case ContestManagerContent.Type.RoundRobin:
                                    {
                                        switch ((RoundRobinContent.Property)wrapProperty.n)
                                        {
                                            case RoundRobinContent.Property.singleContestFactory:
                                                break;
                                            case RoundRobinContent.Property.roundRobins:
                                                {
                                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                                    this.notifyChange();
                                                }
                                                break;
                                            case RoundRobinContent.Property.requestNewRoundRobin:
                                                break;
                                            case RoundRobinContent.Property.needReturnRound:
                                                break;
                                            default:
                                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                break;
                                        }
                                    }
                                    break;
                                case ContestManagerContent.Type.Elimination:
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + contestManagerContent.getType());
                                    break;
                            }
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is RoundRobin.RoundRobin)
                        {
                            switch ((RoundRobin.RoundRobin.Property)wrapProperty.n)
                            {
                                case RoundRobin.RoundRobin.Property.state:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        this.notifyChange();
                                    }
                                    break;
                                case RoundRobin.RoundRobin.Property.index:
                                    break;
                                case RoundRobin.RoundRobin.Property.roundContests:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        {
                            if (wrapProperty.p is RoundRobin.RoundRobin.State)
                            {
                                RoundRobin.RoundRobin.State state = wrapProperty.p as RoundRobin.RoundRobin.State;
                                // Child
                                {
                                    switch (state.getType())
                                    {
                                        case RoundRobin.RoundRobin.State.Type.Load:
                                            break;
                                        case RoundRobin.RoundRobin.State.Type.Start:
                                            break;
                                        case RoundRobin.RoundRobin.State.Type.Play:
                                            break;
                                        case RoundRobin.RoundRobin.State.Type.End:
                                            {
                                                switch ((RoundRobinStateEnd.Property)wrapProperty.n)
                                                {
                                                    case RoundRobinStateEnd.Property.teamResults:
                                                        {
                                                            ValueChangeUtils.replaceCallBack(this, syncs);
                                                            this.notifyChange();
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                        break;
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + state.getType());
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
                                        this.notifyChange();
                                        break;
                                    case TeamResult.Property.score:
                                        this.notifyChange();
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
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}