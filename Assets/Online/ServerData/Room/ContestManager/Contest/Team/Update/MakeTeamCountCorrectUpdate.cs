using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class MakeTeamCountCorrectUpdate : UpdateBehavior<Contest>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    int playerPerTeam = this.data.getPlayerPerTeam();
                    int playerPerGame = this.data.roundFactory.v.getPlayerCountPerGame();
                    // get old team
                    List<MatchTeam> oldTeams = new List<MatchTeam>();
                    {
                        oldTeams.AddRange(this.data.teams.vs);
                    }
                    // Update
                    {
                        for (int i = 0; i < playerPerGame; i++)
                        {
                            // find Team
                            MatchTeam team = null;
                            {
                                // get old
                                if (oldTeams.Count > 0)
                                {
                                    team = oldTeams[0];
                                }
                                // Make new
                                if (team == null)
                                {
                                    team = new MatchTeam();
                                    {
                                        team.uid = this.data.teams.makeId();
                                    }
                                    this.data.teams.add(team);
                                }
                                else
                                {
                                    oldTeams.Remove(team);
                                }
                            }
                            // Update
                            {
                                team.teamIndex.v = i;
                                // state: ko duoc update
                                // players
                                {
                                    // get old
                                    List<TeamPlayer> oldTeamPlayers = new List<TeamPlayer>();
                                    {
                                        oldTeamPlayers.AddRange(team.players.vs);
                                    }
                                    // Update
                                    {
                                        for (int j = 0; j < playerPerTeam; j++)
                                        {
                                            // Find teamPlayer
                                            TeamPlayer teamPlayer = null;
                                            {
                                                // find old
                                                if (oldTeamPlayers.Count > 0)
                                                {
                                                    teamPlayer = oldTeamPlayers[0];
                                                }
                                                // Make new
                                                if (teamPlayer == null)
                                                {
                                                    teamPlayer = new TeamPlayer();
                                                    {
                                                        teamPlayer.uid = team.players.makeId();
                                                    }
                                                    team.players.add(teamPlayer);
                                                }
                                                else
                                                {
                                                    oldTeamPlayers.Remove(teamPlayer);
                                                }
                                            }
                                            // Update
                                            {
                                                teamPlayer.playerIndex.v = j;
                                                // inform
                                                if (teamPlayer.inform.v == null || teamPlayer.inform.v is EmptyInform)
                                                {
                                                    Human human = new Human();
                                                    {
                                                        human.uid = teamPlayer.inform.makeId();
                                                        // playerId
                                                        {
                                                            // get admin
                                                            uint playerId = 0;
                                                            {
                                                                RoomUser admin = Room.findAdmin(this.data);
                                                                if (admin != null)
                                                                {
                                                                    Human adminHuman = admin.inform.v;
                                                                    if (adminHuman != null)
                                                                    {
                                                                        playerId = adminHuman.playerId.v;
                                                                    }
                                                                    else
                                                                    {
                                                                        Debug.LogError("adminHuman null: " + this);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("admin null: " + this);
                                                                }
                                                            }
                                                            human.playerId.v = playerId;
                                                        }
                                                    }
                                                    teamPlayer.inform.v = human;
                                                }
                                            }
                                        }
                                    }
                                    // Remove not use
                                    foreach (TeamPlayer oldTeamPlayer in oldTeamPlayers)
                                    {
                                        team.players.remove(oldTeamPlayer);
                                    }
                                }
                            }
                        }
                    }
                    // remove not use
                    foreach (MatchTeam oldTeam in oldTeams)
                    {
                        this.data.teams.remove(oldTeam);
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

        private CheckContestTeamChange<Contest> checkContestTeamChange = new CheckContestTeamChange<Contest>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is Contest)
            {
                Contest contest = data as Contest;
                // CheckChange
                {
                    checkContestTeamChange.addCallBack(this);
                    checkContestTeamChange.setData(contest);
                }
                // Child
                {
                    contest.roundFactory.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // CheckChange
            if (data is CheckContestTeamChange<Contest>)
            {
                dirty = true;
                return;
            }
            // Child
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
                    dirty = true;
                    return;
                }
                // Child
                {
                    // Normal Round Factory
                    {
                        if (data is GameFactory)
                        {
                            GameFactory gameFactory = data as GameFactory;
                            // Child
                            {
                                gameFactory.gameDataFactory.allAddCallBack(this);
                            }
                            dirty = true;
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
                                            Debug.LogError("Unknown type: " + gameDataFactory.getType() + "; " + this);
                                            break;
                                    }
                                }
                                dirty = true;
                                return;
                            }
                            // Child
                            {
                                // PostureGameDataFactory
                                {
                                    if (data is GameData)
                                    {
                                        dirty = true;
                                        return;
                                    }
                                }
                            }
                        }
                    }
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
                    checkContestTeamChange.removeCallBack(this);
                    checkContestTeamChange.setData(null);
                }
                // Child
                {
                    contest.roundFactory.allRemoveCallBack(this);
                }
                this.setDataNull(contest);
                return;
            }
            // CheckChange
            if (data is CheckContestTeamChange<Contest>)
            {
                return;
            }
            // Child
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
                    // Normal Round Factory
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
                                            Debug.LogError("Unknown type: " + gameDataFactory.getType() + "; " + this);
                                            break;
                                    }
                                }
                                return;
                            }
                            // Child
                            {
                                // PostureGameDataFactory
                                {
                                    if (data is GameData)
                                    {
                                        return;
                                    }
                                }
                            }
                        }
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
                            dirty = true;
                        }
                        break;
                    case Contest.Property.rounds:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            if (wrapProperty.p is CheckContestTeamChange<Contest>)
            {
                dirty = true;
                return;
            }
            // Child
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
                                                dirty = true;
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
                    // Normal Round Factory
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
                                                        dirty = true;
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
                                            Debug.LogError("Unknown type: " + gameDataFactory.getType() + "; " + this);
                                            break;
                                    }
                                }
                                return;
                            }
                            // Child
                            {
                                // PostureGameDataFactory
                                {
                                    if (wrapProperty.p is GameData)
                                    {
                                        switch ((GameData.Property)wrapProperty.n)
                                        {
                                            case GameData.Property.gameType:
                                                dirty = true;
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
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}