using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class CheckCanMakeNewRoundChange<K> : Data, ValueChangeCallBack where K : Data
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

        public CheckCanMakeNewRoundChange() : base()
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
                    DataUtils.removeParentCallBack(this.data, this, ref this.contest);
                }
                // set new 
                {
                    this.data = newData;
                    DataUtils.addParentCallBack(this.data, this, ref this.contest);
                }
            }
            else
            {
                Debug.LogError("the same: " + this + ", " + data + ", " + newData);
            }
        }

        #region implement callBacks

        private Contest contest = null;

        public void onAddCallBack<T>(T data) where T : Data
        {
            if (data is Contest)
            {
                Contest contest = data as Contest;
                // Child
                {
                    contest.roundFactory.allAddCallBack(this);
                    contest.rounds.allAddCallBack(this);
                    contest.requestNewRound.allAddCallBack(this);
                }
                this.notifyChange();
                return;
            }
            // Child
            {
                // roundFactory
                {
                    if (data is RoundFactory)
                    {
                        RoundFactory roundFactory = data as RoundFactory;
                        // Child
                        {
                            switch (roundFactory.getType())
                            {
                                case RoundFactory.Type.Normal:
                                    {
                                        NormalRoundFactory normalRoundFactory = roundFactory as NormalRoundFactory;
                                        normalRoundFactory.gameFactory.allAddCallBack(this);
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + roundFactory.getType() + "; " + this);
                                    break;
                            }
                        }
                        this.notifyChange();
                        return;
                    }
                    // Child
                    {
                        // NormalRoundFactory
                        {
                            if (data is GameFactory)
                            {
                                GameFactory gameFactory = data as GameFactory;
                                // Child
                                {
                                    gameFactory.gameDataFactory.allAddCallBack(this);
                                }
                                this.notifyChange();
                                return;
                            }
                            // Child
                            {
                                if (data is GameDataFactory)
                                {
                                    GameDataFactory gameDataFactory = data as GameDataFactory;
                                    // Child
                                    {
                                        switch (gameDataFactory.getType())
                                        {
                                            case GameDataFactory.Type.Default:
                                                break;
                                            case GameDataFactory.Type.Posture:
                                                {
                                                    PostureGameDataFactory postureGameDataFactory = gameDataFactory as PostureGameDataFactory;
                                                    postureGameDataFactory.gameData.allAddCallBack(this);
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + gameDataFactory.getType() + "; " + this);
                                                break;
                                        }
                                    }
                                    this.notifyChange();
                                    return;
                                }
                                // Child
                                if (data is GameData)
                                {
                                    this.notifyChange();
                                    return;
                                }
                            }
                        }
                    }
                }
                // round
                {
                    if (data is Round)
                    {
                        Round round = data as Round;
                        // Child
                        {
                            round.state.allAddCallBack(this);
                        }
                        this.notifyChange();
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
                                            RoundStateEnd roundStateEnd = roundState as RoundStateEnd;
                                            roundStateEnd.teamResults.allAddCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + roundState.getType() + "; " + this);
                                        break;
                                }
                            }
                            this.notifyChange();
                            return;
                        }
                        // Child
                        if (data is TeamResult)
                        {
                            this.notifyChange();
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
                        this.notifyChange();
                        return;
                    }
                    // Child
                    if (data is RequestNewRound.Limit)
                    {
                        this.notifyChange();
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
        {
            if (data is Contest)
            {
                Contest contest = data as Contest;
                // Child
                {
                    contest.roundFactory.allRemoveCallBack(this);
                    contest.rounds.allRemoveCallBack(this);
                    contest.requestNewRound.allRemoveCallBack(this);
                }
                this.contest = null;
                return;
            }
            // Child
            {
                // roundFactory
                {
                    if (data is RoundFactory)
                    {
                        RoundFactory roundFactory = data as RoundFactory;
                        // Child
                        {
                            switch (roundFactory.getType())
                            {
                                case RoundFactory.Type.Normal:
                                    {
                                        NormalRoundFactory normalRoundFactory = roundFactory as NormalRoundFactory;
                                        normalRoundFactory.gameFactory.allRemoveCallBack(this);
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + roundFactory.getType() + "; " + this);
                                    break;
                            }
                        }
                        return;
                    }
                    // Child
                    {
                        // NormalRoundFactory
                        {
                            if (data is GameFactory)
                            {
                                GameFactory gameFactory = data as GameFactory;
                                // Child
                                {
                                    gameFactory.gameDataFactory.allRemoveCallBack(this);
                                }
                                return;
                            }
                            // Child
                            {
                                if (data is GameDataFactory)
                                {
                                    GameDataFactory gameDataFactory = data as GameDataFactory;
                                    // Child
                                    {
                                        switch (gameDataFactory.getType())
                                        {
                                            case GameDataFactory.Type.Default:
                                                break;
                                            case GameDataFactory.Type.Posture:
                                                {
                                                    PostureGameDataFactory postureGameDataFactory = gameDataFactory as PostureGameDataFactory;
                                                    postureGameDataFactory.gameData.allRemoveCallBack(this);
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + gameDataFactory.getType() + "; " + this);
                                                break;
                                        }
                                    }
                                    return;
                                }
                                // Child
                                if (data is GameData)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
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
                                            RoundStateEnd roundStateEnd = roundState as RoundStateEnd;
                                            roundStateEnd.teamResults.allRemoveCallBack(this);
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
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
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
                    case Contest.Property.playerPerTeam:
                        break;
                    case Contest.Property.teams:
                        break;
                    case Contest.Property.roundFactory:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            this.notifyChange();
                        }
                        break;
                    case Contest.Property.rounds:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            this.notifyChange();
                        }
                        break;
                    case Contest.Property.requestNewRound:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            this.notifyChange();
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
                // roundFactory
                {
                    if (wrapProperty.p is RoundFactory)
                    {
                        RoundFactory roundFactory = wrapProperty.p as RoundFactory;
                        // Child
                        {
                            switch (roundFactory.getType())
                            {
                                case RoundFactory.Type.Normal:
                                    {
                                        switch ((NormalRoundFactory.Property)wrapProperty.n)
                                        {
                                            case NormalRoundFactory.Property.gameFactory:
                                                {
                                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                                    this.notifyChange();
                                                }
                                                break;
                                            case NormalRoundFactory.Property.isChangeSideBetweenRound:
                                                break;
                                            case NormalRoundFactory.Property.isSwitchPlayer:
                                                break;
                                            case NormalRoundFactory.Property.isDifferentInTeam:
                                                break;
                                            default:
                                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                break;
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + roundFactory.getType() + "; " + this);
                                    break;
                            }
                        }
                        return;
                    }
                    // Child
                    {
                        // NormalRoundFactory
                        {
                            if (wrapProperty.p is GameFactory)
                            {
                                switch ((GameFactory.Property)wrapProperty.n)
                                {
                                    case GameFactory.Property.timeControl:
                                        break;
                                    case GameFactory.Property.gameDataFactory:
                                        {
                                            ValueChangeUtils.replaceCallBack(this, syncs);
                                            this.notifyChange();
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
                                if (wrapProperty.p is GameDataFactory)
                                {
                                    GameDataFactory gameDataFactory = wrapProperty.p as GameDataFactory;
                                    // Child
                                    {
                                        switch (gameDataFactory.getType())
                                        {
                                            case GameDataFactory.Type.Default:
                                                {
                                                    switch ((DefaultGameDataFactory.Property)wrapProperty.n)
                                                    {
                                                        case DefaultGameDataFactory.Property.defaultGameType:
                                                            this.notifyChange();
                                                            break;
                                                        case DefaultGameDataFactory.Property.useRule:
                                                            break;
                                                        default:
                                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                            break;
                                                    }
                                                }
                                                break;
                                            case GameDataFactory.Type.Posture:
                                                {
                                                    switch ((PostureGameDataFactory.Property)wrapProperty.n)
                                                    {
                                                        case PostureGameDataFactory.Property.gameData:
                                                            {
                                                                ValueChangeUtils.replaceCallBack(this, syncs);
                                                                this.notifyChange();
                                                            }
                                                            break;
                                                        case PostureGameDataFactory.Property.useRule:
                                                            break;
                                                        default:
                                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                            break;
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + gameDataFactory.getType() + "; " + this);
                                                break;
                                        }
                                    }
                                    return;
                                }
                                // Child
                                if (wrapProperty.p is GameData)
                                {
                                    switch ((GameData.Property)wrapProperty.n)
                                    {
                                        case GameData.Property.gameType:
                                            this.notifyChange();
                                            break;
                                        case GameData.Property.useRule:
                                            break;
                                        case GameData.Property.turn:
                                            break;
                                        case GameData.Property.timeControl:
                                            break;
                                        case GameData.Property.lastMove:
                                            break;
                                        case GameData.Property.state:
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
                // round
                {
                    if (wrapProperty.p is Round)
                    {
                        switch ((Round.Property)wrapProperty.n)
                        {
                            case Round.Property.state:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    this.notifyChange();
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
                                    this.notifyChange();
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
                                            this.notifyChange();
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
                                            this.notifyChange();
                                            break;
                                        case RequestNewRoundHaveLimit.Property.enoughScoreStop:
                                            this.notifyChange();
                                            break;
                                        default:
                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                            break;
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("Unknown type: " + limit.getType() + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        #endregion

    }
}