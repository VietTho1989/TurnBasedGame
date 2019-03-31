using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class RoomInformGameTypeUpdate : UpdateBehavior<RoomInform>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // contest
                {
                    // find
                    ContestManager.State.Type contestStateType = ContestManager.State.Type.Lobby;
                    GameType.Type gameTypeType = GameType.Type.CHESS;
                    {
                        Room room = this.data.findDataInParent<Room>();
                        if (room != null)
                        {
                            if (room.contestManagers.vs.Count > 0)
                            {
                                ContestManager contestManager = room.contestManagers.vs[room.contestManagers.vs.Count - 1];
                                // state
                                {
                                    ContestManager.State contestManagerState = contestManager.state.v;
                                    if (contestManagerState != null)
                                    {
                                        switch (contestManagerState.getType())
                                        {
                                            case ContestManager.State.Type.Lobby:
                                                {
                                                    contestStateType = ContestManager.State.Type.Lobby;
                                                    // gameType
                                                    {
                                                        ContestManagerStateLobby lobby = contestManagerState as ContestManagerStateLobby;
                                                        gameTypeType = lobby.gameType.v;
                                                    }
                                                }
                                                break;
                                            case ContestManager.State.Type.Play:
                                                {
                                                    contestStateType = ContestManager.State.Type.Play;
                                                    // gameType
                                                    {
                                                        ContestManagerStatePlay play = contestManagerState as ContestManagerStatePlay;
                                                        gameTypeType = play.gameTypeType.v;
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unkown type: " + contestManagerState.getType() + "; " + this);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("contestManagerState null: " + this);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("room null: " + this);
                        }
                    }
                    // set
                    {
                        this.data.contestStateType.v = contestStateType;
                        this.data.gameType.v = gameTypeType;
                    }
                }
                // password
                {
                    bool isHavePassword = false;
                    {
                        Room room = this.data.findDataInParent<Room>();
                        if (room != null)
                        {
                            if (!string.IsNullOrEmpty(room.password.v))
                            {
                                isHavePassword = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("room null: " + this);
                        }
                    }
                    this.data.isHavePassword.v = isHavePassword;
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

    private Room room = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is RoomInform)
        {
            RoomInform roomInform = data as RoomInform;
            // Parent
            {
                DataUtils.addParentCallBack(roomInform, this, ref this.room);
            }
            dirty = true;
            return;
        }
        // Parent
        {
            if (data is Room)
            {
                Room room = data as Room;
                // Child
                {
                    room.contestManagers.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
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
                if (data is ContestManager.State)
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
        if (data is RoomInform)
        {
            RoomInform roomInform = data as RoomInform;
            // Parent
            {
                DataUtils.removeParentCallBack(roomInform, this, ref this.room);
            }
            this.setDataNull(roomInform);
            return;
        }
        // Parent
        {
            if (data is Room)
            {
                Room room = data as Room;
                // Child
                {
                    room.contestManagers.allRemoveCallBack(this);
                }
                return;
            }
            // Child
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
                if (data is ContestManager.State)
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
        if (wrapProperty.p is RoomInform)
        {
            switch ((RoomInform.Property)wrapProperty.n)
            {
                case RoomInform.Property.creator:
                    break;
                case RoomInform.Property.userCount:
                    break;
                case RoomInform.Property.contestStateType:
                    break;
                case RoomInform.Property.gameType:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Parent
        {
            if (wrapProperty.p is Room)
            {
                switch ((Room.Property)wrapProperty.n)
                {
                    case Room.Property.roomInform:
                        break;
                    case Room.Property.changeRights:
                        break;
                    case Room.Property.name:
                        break;
                    case Room.Property.password:
                        dirty = true;
                        break;
                    case Room.Property.users:
                        break;
                    case Room.Property.state:
                        break;
                    case Room.Property.requestNewContestManager:
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
                    case Room.Property.chatInGame:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is ContestManager)
                {
                    switch ((ContestManager.Property)wrapProperty.n)
                    {
                        case ContestManager.Property.index:
                            break;
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
                if (wrapProperty.p is ContestManager.State)
                {
                    ContestManager.State state = wrapProperty.p as ContestManager.State;
                    switch (state.getType())
                    {
                        case ContestManager.State.Type.Lobby:
                            {
                                switch ((ContestManagerStateLobby.Property)wrapProperty.n)
                                {
                                    case ContestManagerStateLobby.Property.state:
                                        break;
                                    case ContestManagerStateLobby.Property.teams:
                                        break;
                                    case ContestManagerStateLobby.Property.gameType:
                                        dirty = true;
                                        break;
                                    case ContestManagerStateLobby.Property.randomTeamIndex:
                                        break;
                                    case ContestManagerStateLobby.Property.contentFactory:
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                            }
                            break;
                        case ContestManager.State.Type.Play:
                            {
                                switch ((ContestManagerStatePlay.Property)wrapProperty.n)
                                {
                                    case ContestManagerStatePlay.Property.state:
                                        break;
                                    case ContestManagerStatePlay.Property.isForceEnd:
                                        break;
                                    case ContestManagerStatePlay.Property.teams:
                                        break;
                                    case ContestManagerStatePlay.Property.swap:
                                        break;
                                    case ContestManagerStatePlay.Property.content:
                                        break;
                                    case ContestManagerStatePlay.Property.contentTeamResult:
                                        break;
                                    case ContestManagerStatePlay.Property.gameTypeType:
                                        dirty = true;
                                        break;
                                    case ContestManagerStatePlay.Property.randomTeamIndex:
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}