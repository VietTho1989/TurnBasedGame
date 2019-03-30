using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class MakeContestManagerUpdate : UpdateBehavior<Room>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                if (this.data.contestManagers.vs.Count == 0)
                {
                    ContestManager contestManager = new ContestManager();
                    {
                        contestManager.uid = this.data.contestManagers.makeId();
                    }
                    this.data.contestManagers.add(contestManager);
                }
                else
                {
                    // Find
                    bool needMakeNewContestManager = true;
                    {
                        // Check all contestManager end
                        if (needMakeNewContestManager)
                        {
                            // Find
                            bool allContestManagerEnd = true;
                            {
                                foreach (ContestManager contestManager in this.data.contestManagers.vs)
                                {
                                    // check contestManager end
                                    bool isEnd = false;
                                    {
                                        if (contestManager.state.v is ContestManagerStatePlay)
                                        {
                                            ContestManagerStatePlay contestManagerStatePlay = contestManager.state.v as ContestManagerStatePlay;
                                            if (contestManagerStatePlay.state.v is ContestManagerStatePlayEnd)
                                            {
                                                isEnd = true;
                                            }
                                        }
                                    }
                                    // Process
                                    if (!isEnd)
                                    {
                                        allContestManagerEnd = false;
                                        break;
                                    }
                                }
                            }
                            // Process
                            if (!allContestManagerEnd)
                            {
                                needMakeNewContestManager = false;
                            }
                        }
                        // Check request make new contestManager
                        if (needMakeNewContestManager)
                        {
                            // Find
                            bool alreadyAccept = false;
                            {
                                RequestNewContestManager requestNewContestManager = this.data.requestNewContestManager.v;
                                if (requestNewContestManager != null)
                                {
                                    if (requestNewContestManager.state.v is RequestNewContestManagerStateAccept)
                                    {
                                        alreadyAccept = true;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("requestNewContestManager null: " + this);
                                }
                            }
                            // Process
                            if (!alreadyAccept)
                            {
                                needMakeNewContestManager = false;
                            }
                        }
                    }
                    // Process
                    if (needMakeNewContestManager)
                    {
                        ContestManager contestManager = new ContestManager();
                        {
                            contestManager.uid = this.data.contestManagers.makeId();
                            contestManager.index.v = this.data.contestManagers.vs.Count;
                            // state
                            {
                                if (contestManager.state.v is ContestManagerStateLobby)
                                {
                                    ContestManagerStateLobby contestManagerStateLobby = contestManager.state.v as ContestManagerStateLobby;
                                    // get last state play
                                    ContestManagerStatePlay lastContestManagerStatePlay = null;
                                    {
                                        if (this.data.contestManagers.vs.Count > 0)
                                        {
                                            ContestManager lastContestManager = this.data.contestManagers.vs[this.data.contestManagers.vs.Count - 1];
                                            lastContestManagerStatePlay = lastContestManager.state.v as ContestManagerStatePlay;
                                        }
                                    }
                                    // Process
                                    if (lastContestManagerStatePlay != null)
                                    {
                                        // state: ko can
                                        //teams
                                        {
                                            foreach (MatchTeam matchTeam in lastContestManagerStatePlay.teams.vs)
                                            {
                                                LobbyTeam lobbyTeam = new LobbyTeam();
                                                {
                                                    lobbyTeam.uid = contestManagerStateLobby.teams.makeId();
                                                    lobbyTeam.teamIndex.v = matchTeam.teamIndex.v;
                                                    // players
                                                    {
                                                        foreach (TeamPlayer teamPlayer in matchTeam.players.vs)
                                                        {
                                                            LobbyPlayer lobbyPlayer = new LobbyPlayer();
                                                            {
                                                                lobbyPlayer.uid = lobbyTeam.players.makeId();
                                                                lobbyPlayer.playerIndex.v = teamPlayer.playerIndex.v;
                                                                // inform
                                                                {
                                                                    GamePlayer.Inform inform = DataUtils.cloneData(teamPlayer.inform.v) as GamePlayer.Inform;
                                                                    {
                                                                        inform.uid = lobbyPlayer.inform.makeId();
                                                                    }
                                                                    lobbyPlayer.inform.v = inform;
                                                                }
                                                                // isReady: ko can
                                                            }
                                                            lobbyTeam.players.add(lobbyPlayer);
                                                        }
                                                    }
                                                }
                                                contestManagerStateLobby.teams.add(lobbyTeam);
                                            }
                                        }
                                        //gameType: ko can
                                        contestManagerStateLobby.randomTeamIndex.v = lastContestManagerStatePlay.randomTeamIndex.v;
                                        // contentFactory
                                        {
                                            ContestManagerContentFactory contentFactory = lastContestManagerStatePlay.content.v.makeContentFactory();
                                            {
                                                contentFactory.uid = contestManagerStateLobby.contentFactory.makeId();
                                            }
                                            contestManagerStateLobby.contentFactory.v = contentFactory;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("lastContestManagerStatePlay null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("why contestManager state not lobby: " + this);
                                }
                            }
                        }
                        this.data.contestManagers.add(contestManager);
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

    public override void onAddCallBack<T>(T data)
    {
        if (data is Room)
        {
            Room room = data as Room;
            // Child
            {
                room.requestNewContestManager.allAddCallBack(this);
                room.contestManagers.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is RequestNewContestManager)
            {
                dirty = true;
                return;
            }
            // ContestManager
            {
                if (data is ContestManager)
                {
                    ContestManager contestManager = data as ContestManager;
                    // Child
                    {
                        contestManager.state.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is ContestManager.State)
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
        if (data is Room)
        {
            Room room = data as Room;
            // Child
            {
                room.requestNewContestManager.allRemoveCallBack(this);
                room.contestManagers.allRemoveCallBack(this);
            }
            this.setDataNull(room);
            return;
        }
        // Child
        {
            if (data is RequestNewContestManager)
            {
                return;
            }
            // ContestManager
            {
                if (data is ContestManager)
                {
                    ContestManager contestManager = data as ContestManager;
                    // Child
                    {
                        contestManager.state.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is ContestManager.State)
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
        if (wrapProperty.p is Room)
        {
            switch ((Room.Property)wrapProperty.n)
            {
                case Room.Property.changeRights:
                    break;
                case Room.Property.name:
                    break;
                case Room.Property.password:
                    break;
                case Room.Property.users:
                    break;
                case Room.Property.state:
                    break;
                case Room.Property.requestNewContestManager:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case Room.Property.contestManagers:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case Room.Property.timeCreated:
                    break;
                case Room.Property.chatRoom:
                    break;
                case Room.Property.allowHint:
                    break;
                case Room.Property.allowLoadHistory:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is RequestNewContestManager)
            {
                switch ((RequestNewContestManager.Property)wrapProperty.n)
                {
                    case RequestNewContestManager.Property.state:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // ContestManager
            {
                if (wrapProperty.p is ContestManager)
                {
                    switch ((ContestManager.Property)wrapProperty.n)
                    {
                        case ContestManager.Property.state:
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
                    if (wrapProperty.p is ContestManager.State)
                    {
                        ContestManager.State state = wrapProperty.p as ContestManager.State;
                        switch (state.getType())
                        {
                            case ContestManager.State.Type.Lobby:
                                break;
                            case ContestManager.State.Type.Play:
                                {
                                    switch ((ContestManagerStatePlay.Property)wrapProperty.n)
                                    {
                                        case ContestManagerStatePlay.Property.teams:
                                            break;
                                        case ContestManagerStatePlay.Property.content:
                                            break;
                                        case ContestManagerStatePlay.Property.state:
                                            dirty = true;
                                            break;
                                        default:
                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                            break;
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                break;
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