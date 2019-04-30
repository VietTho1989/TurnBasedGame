using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace GameManager.Match.Lobby
{
    public class StateStartUpdate : UpdateBehavior<StateStart>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // Check can start
                    bool canStart = false;
                    {
                        ContestManagerStateLobby lobby = this.data.findDataInParent<ContestManagerStateLobby>();
                        if (lobby != null)
                        {
                            if (lobby.IsCanStart())
                            {
                                canStart = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("lobby null: " + this);
                        }
                    }
                    // Process
                    if (canStart)
                    {
                        if (this.data.time.v >= this.data.duration.v)
                        {
                            // chuyen contestManager state sang play
                            ContestManager contestManager = this.data.findDataInParent<ContestManager>();
                            if (contestManager != null)
                            {
                                ContestManagerStatePlay contestManagerStatePlay = new ContestManagerStatePlay();
                                {
                                    contestManagerStatePlay.uid = contestManager.state.makeId();
                                    // teams
                                    {
                                        ContestManagerStateLobby lobby = this.data.findDataInParent<ContestManagerStateLobby>();
                                        if (lobby != null)
                                        {
                                            // randomTeamIndex
                                            contestManagerStatePlay.randomTeamIndex.v = lobby.randomTeamIndex.v;
                                            // get lobbyTeams
                                            List<LobbyTeam> lobbyTeams = new List<LobbyTeam>();
                                            {
                                                lobbyTeams.AddRange(lobby.teams.vs);
                                            }
                                            // Copy to contestManagerStatePlay
                                            {
                                                int random = Random.Range(0, int.MaxValue);
                                                int teamIndex = 0;
                                                while (lobbyTeams.Count > 0)
                                                {
                                                    int chosenTeamIndex = lobby.randomTeamIndex.v ? random % lobbyTeams.Count : 0;
                                                    if (chosenTeamIndex >= 0 && chosenTeamIndex < lobbyTeams.Count)
                                                    {
                                                        LobbyTeam lobbyTeam = lobbyTeams[chosenTeamIndex];
                                                        // Make new team
                                                        {
                                                            MatchTeam team = new MatchTeam();
                                                            {
                                                                team.uid = contestManagerStatePlay.teams.makeId();
                                                                {
                                                                    team.teamIndex.v = teamIndex;// lobbyTeam.teamIndex.v;
                                                                    teamIndex++;
                                                                }
                                                                // state: ko can
                                                                // players
                                                                {
                                                                    foreach (LobbyPlayer lobbyPlayer in lobbyTeam.players.vs)
                                                                    {
                                                                        TeamPlayer teamPlayer = new TeamPlayer();
                                                                        {
                                                                            teamPlayer.uid = team.players.makeId();
                                                                            // playerIndex
                                                                            teamPlayer.playerIndex.v = lobbyPlayer.playerIndex.v;
                                                                            // inform
                                                                            {
                                                                                GamePlayer.Inform inform = DataUtils.cloneData(lobbyPlayer.inform.v) as GamePlayer.Inform;
                                                                                {
                                                                                    inform.uid = teamPlayer.inform.makeId();
                                                                                }
                                                                                teamPlayer.inform.v = inform;
                                                                            }
                                                                        }
                                                                        team.players.add(teamPlayer);
                                                                    }
                                                                }
                                                            }
                                                            contestManagerStatePlay.teams.add(team);
                                                        }
                                                        lobbyTeams.RemoveAt(chosenTeamIndex);
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("chosenTeamIndex error: " + chosenTeamIndex);
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("lobby null: " + this);
                                        }
                                    }
                                    // content
                                    {
                                        ContestManagerStateLobby lobby = this.data.findDataInParent<ContestManagerStateLobby>();
                                        if (lobby != null)
                                        {
                                            ContestManagerContent content = lobby.contentFactory.v.makeContent();
                                            {
                                                content.uid = contestManagerStatePlay.content.makeId();
                                            }
                                            contestManagerStatePlay.content.v = content;
                                        }
                                        else
                                        {
                                            Debug.LogError("lobby null: " + this);
                                        }
                                    }
                                }
                                contestManager.state.v = contestManagerStatePlay;
                            }
                            else
                            {
                                Debug.LogError("contest null: " + this);
                            }
                        }
                        else
                        {
                            // wait not enough time
                        }
                    }
                    else
                    {
                        // quay tro ve normal
                        ContestManagerStateLobby lobby = this.data.findDataInParent<ContestManagerStateLobby>();
                        if (lobby != null)
                        {
                            StateNormal stateNormal = new StateNormal();
                            {
                                stateNormal.uid = lobby.state.makeId();
                            }
                            lobby.state.v = stateNormal;
                        }
                        else
                        {
                            Debug.LogError("lobby null: " + this);
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
            return false;
        }

        #endregion

        #region Task

        private Routine startTimeCoroutine;

        void Awake()
        {
            if (Routine.IsNull(startTimeCoroutine))
            {
                startTimeCoroutine = CoroutineManager.StartCoroutine(updateStartTime(), this.gameObject);
            }
            else
            {
                Debug.LogError("Why routine != null");
            }
        }

        public override List<Routine> getRoutineList()
        {
            List<Routine> ret = new List<Routine>();
            {
                ret.Add(startTimeCoroutine);
            }
            return ret;
        }

        public IEnumerator updateStartTime()
        {
            while (true)
            {
                yield return new Wait(1f);
                if (this.data != null)
                {
                    this.data.time.v = this.data.time.v + 1;
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        #endregion

        #region implement callBacks

        private ContestManagerStateLobby contestManagerStateLobby = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is StateStart)
            {
                StateStart stateStart = data as StateStart;
                // Parent
                {
                    DataUtils.addParentCallBack(stateStart, this, ref this.contestManagerStateLobby);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is ContestManagerStateLobby)
                {
                    ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
                    // Child
                    {
                        contestManagerStateLobby.teams.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is LobbyTeam)
                    {
                        LobbyTeam lobbyTeam = data as LobbyTeam;
                        // Child
                        {
                            lobbyTeam.players.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is LobbyPlayer)
                        {
                            LobbyPlayer lobbyPlayer = data as LobbyPlayer;
                            // Child
                            {
                                lobbyPlayer.inform.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is GamePlayer.Inform)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is StateStart)
            {
                StateStart stateStart = data as StateStart;
                // Parent
                {
                    DataUtils.removeParentCallBack(stateStart, this, ref this.contestManagerStateLobby);
                }
                this.setDataNull(stateStart);
                return;
            }
            // Parent
            {
                if (data is ContestManagerStateLobby)
                {
                    ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
                    // Child
                    {
                        contestManagerStateLobby.teams.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is LobbyTeam)
                    {
                        LobbyTeam lobbyTeam = data as LobbyTeam;
                        // Child
                        {
                            lobbyTeam.players.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is LobbyPlayer)
                        {
                            LobbyPlayer lobbyPlayer = data as LobbyPlayer;
                            // Child
                            {
                                lobbyPlayer.inform.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is GamePlayer.Inform)
                        {
                            return;
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
            if (wrapProperty.p is StateStart)
            {
                switch ((StateStart.Property)wrapProperty.n)
                {
                    case StateStart.Property.time:
                        dirty = true;
                        break;
                    case StateStart.Property.duration:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                if (wrapProperty.p is ContestManagerStateLobby)
                {
                    switch ((ContestManagerStateLobby.Property)wrapProperty.n)
                    {
                        case ContestManagerStateLobby.Property.state:
                            break;
                        case ContestManagerStateLobby.Property.teams:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ContestManagerStateLobby.Property.gameType:
                            break;
                        case ContestManagerStateLobby.Property.randomTeamIndex:
                            break;
                        case ContestManagerStateLobby.Property.contentFactory:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is LobbyTeam)
                    {
                        switch ((LobbyTeam.Property)wrapProperty.n)
                        {
                            case LobbyTeam.Property.teamIndex:
                                break;
                            case LobbyTeam.Property.players:
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
                        if (wrapProperty.p is LobbyPlayer)
                        {
                            switch ((LobbyPlayer.Property)wrapProperty.n)
                            {
                                case LobbyPlayer.Property.playerIndex:
                                    break;
                                case LobbyPlayer.Property.inform:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case LobbyPlayer.Property.isReady:
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is GamePlayer.Inform)
                        {
                            if (wrapProperty.p is Human)
                            {
                                switch ((Human.Property)wrapProperty.n)
                                {
                                    case Human.Property.playerId:
                                        dirty = true;
                                        break;
                                    case Human.Property.account:
                                        break;
                                    case Human.Property.state:
                                        break;
                                    case Human.Property.email:
                                        break;
                                    case Human.Property.phoneNumber:
                                        break;
                                    case Human.Property.status:
                                        break;
                                    case Human.Property.birthday:
                                        break;
                                    case Human.Property.sex:
                                        break;
                                    case Human.Property.connection:
                                        break;
                                    case Human.Property.ban:
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                            }
                            return;
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}