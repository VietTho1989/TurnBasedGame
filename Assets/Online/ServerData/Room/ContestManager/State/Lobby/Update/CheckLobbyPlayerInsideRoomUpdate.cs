using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class CheckLobbyPlayerInsideRoomUpdate : UpdateBehavior<ContestManagerStateLobby>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // get all userId inside room
                    HashSet<uint> allInsideRoom = new HashSet<uint>();
                    {
                        Room room = this.data.findDataInParent<Room>();
                        if (room != null)
                        {
                            foreach (RoomUser roomUser in room.users.vs)
                            {
                                if (roomUser.isInsideRoom())
                                {
                                    Human human = roomUser.inform.v;
                                    if (human != null)
                                    {
                                        allInsideRoom.Add(human.playerId.v);
                                    }
                                    else
                                    {
                                        Debug.LogError("human null: " + this);
                                    }
                                }
                                else
                                {
                                    // not inside room, maybe: being kicked
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("room null: " + this);
                        }
                    }
                    // Check all lobbyPlayer
                    {
                        foreach (LobbyTeam team in this.data.teams.vs)
                        {
                            foreach (LobbyPlayer player in team.players.vs)
                            {
                                if (player.inform.v is Human)
                                {
                                    Human human = player.inform.v as Human;
                                    if (!(allInsideRoom.Contains(human.playerId.v)))
                                    {
                                        // Debug.LogError ("not inside room any more: " + human);
                                        // chuyen sang empty
                                        EmptyInform emptyInform = new EmptyInform();
                                        {
                                            emptyInform.uid = player.inform.makeId();
                                        }
                                        player.inform.v = emptyInform;
                                    }
                                }
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

        private RoomCheckChangeAdminChange<ContestManagerStateLobby> roomCheckAdminChange = new RoomCheckChangeAdminChange<ContestManagerStateLobby>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is ContestManagerStateLobby)
            {
                ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
                // CheckChange
                {
                    roomCheckAdminChange.addCallBack(this);
                    roomCheckAdminChange.setData(contestManagerStateLobby);
                }
                // Child
                {
                    contestManagerStateLobby.teams.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // CheckChange
            if (data is RoomCheckChangeAdminChange<ContestManagerStateLobby>)
            {
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
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is ContestManagerStateLobby)
            {
                ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
                // CheckChange
                {
                    roomCheckAdminChange.removeCallBack(this);
                    roomCheckAdminChange.setData(null);
                }
                // Child
                {
                    contestManagerStateLobby.teams.allRemoveCallBack(this);
                }
                this.setDataNull(contestManagerStateLobby);
                return;
            }
            // CheckChange
            if (data is RoomCheckChangeAdminChange<ContestManagerStateLobby>)
            {
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
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
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
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            if (wrapProperty.p is RoomCheckChangeAdminChange<ContestManagerStateLobby>)
            {
                dirty = true;
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}