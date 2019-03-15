using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rights;

namespace GameManager.Match.Swap
{
    public class SwapUpdate : UpdateBehavior<Swap>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // check right allow
                    bool rightAllow = false;
                    {
                        Room room = this.data.findDataInParent<Room>();
                        if (room != null)
                        {
                            ChangeRights changeRights = room.changeRights.v;
                            if (changeRights != null)
                            {
                                ChangeGamePlayerRight changeGamePlayerRight = changeRights.changeGamePlayerRight.v;
                                if (changeGamePlayerRight != null)
                                {
                                    if (changeGamePlayerRight.canChange.v)
                                    {
                                        rightAllow = true;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("changeGamePlayerRight null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("changeRights null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("room null: " + this);
                        }
                    }
                    // Process
                    if (rightAllow)
                    {
                        // find need remove
                        List<SwapRequest> needRemoveSwapRequests = new List<SwapRequest>();
                        {
                            foreach (SwapRequest swapRequest in this.data.swapRequests.vs)
                            {
                                // find can keep
                                bool canKeep = true;
                                {
                                    // player exist?
                                    if (canKeep)
                                    {
                                        // find
                                        bool playerExist = false;
                                        {
                                            ContestManagerStatePlay contestManagerStatePlay = swapRequest.findDataInParent<ContestManagerStatePlay>();
                                            if (contestManagerStatePlay != null)
                                            {
                                                if (swapRequest.teamIndex.v >= 0 && swapRequest.teamIndex.v < contestManagerStatePlay.teams.vs.Count)
                                                {
                                                    MatchTeam matchTeam = contestManagerStatePlay.teams.vs[swapRequest.teamIndex.v];
                                                    if (swapRequest.playerIndex.v >= 0 && swapRequest.playerIndex.v < matchTeam.players.vs.Count)
                                                    {
                                                        playerExist = true;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("playerIndex error: " + swapRequest.playerIndex.v + "; " + this);
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("teamIndex error: " + swapRequest.teamIndex.v + "; " + this);
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("contestManagerPlay null: " + this);
                                            }
                                        }
                                        // process
                                        if (!playerExist)
                                        {
                                            canKeep = false;
                                        }
                                        else
                                        {
                                            Debug.LogError("player not exist: " + swapRequest.teamIndex.v + "; " + swapRequest.playerIndex.v + "; " + this);
                                        }
                                    }
                                }
                                // Process
                                if (!canKeep)
                                {
                                    needRemoveSwapRequests.Add(swapRequest);
                                }
                                else
                                {
                                    Debug.LogError("Cannot keep: " + swapRequest + "; " + this);
                                }
                            }
                        }
                        // remove
                        foreach (SwapRequest needRemoveSwapRequest in needRemoveSwapRequests)
                        {
                            this.data.swapRequests.remove(needRemoveSwapRequest);
                        }
                    }
                    else
                    {
                        this.data.swapRequests.clear();
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
        private ContestManagerStatePlay contestManagerStatePlay = null;

        private ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay> contestManagerStatePlayTeamCheckChange = new ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is Swap)
            {
                Swap swap = data as Swap;
                // Parent
                {
                    DataUtils.addParentCallBack(swap, this, ref this.room);
                    DataUtils.addParentCallBack(swap, this, ref this.contestManagerStatePlay);
                }
                // Child
                {
                    swap.swapRequests.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                // Room
                {
                    if (data is Room)
                    {
                        Room room = data as Room;
                        // Child
                        {
                            room.changeRights.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // ChangeRights
                    {
                        if (data is ChangeRights)
                        {
                            ChangeRights changeRights = data as ChangeRights;
                            // Child
                            {
                                changeRights.changeGamePlayerRight.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is ChangeGamePlayerRight)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
                // ContestManagerStatePlay
                {
                    if (data is ContestManagerStatePlay)
                    {
                        ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                        // CheckChange
                        {
                            contestManagerStatePlayTeamCheckChange.addCallBack(this);
                            contestManagerStatePlayTeamCheckChange.setData(contestManagerStatePlay);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if (data is ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            if (data is SwapRequest)
            {
                SwapRequest swapRequest = data as SwapRequest;
                // Update
                {
                    UpdateUtils.makeUpdate<SwapRequestUpdate, SwapRequest>(swapRequest, this.transform);
                }
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is Swap)
            {
                Swap swap = data as Swap;
                // Parent
                {
                    DataUtils.removeParentCallBack(swap, this, ref this.room);
                    DataUtils.removeParentCallBack(swap, this, ref this.contestManagerStatePlay);
                }
                // Child
                {
                    swap.swapRequests.allRemoveCallBack(this);
                }
                this.setDataNull(swap);
                return;
            }
            // Parent
            {
                // Room
                {
                    if (data is Room)
                    {
                        Room room = data as Room;
                        // Child
                        {
                            room.changeRights.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // ChangeRights
                    {
                        if (data is ChangeRights)
                        {
                            ChangeRights changeRights = data as ChangeRights;
                            // Child
                            {
                                changeRights.changeGamePlayerRight.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is ChangeGamePlayerRight)
                        {
                            return;
                        }
                    }
                }
                // ContestManagerStatePlay
                {
                    if (data is ContestManagerStatePlay)
                    {
                        // ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                        // CheckChange
                        {
                            contestManagerStatePlayTeamCheckChange.removeCallBack(this);
                            contestManagerStatePlayTeamCheckChange.setData(null);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>)
                    {
                        return;
                    }
                }
            }
            // Child
            if (data is SwapRequest)
            {
                SwapRequest swapRequest = data as SwapRequest;
                // Update
                {
                    swapRequest.removeCallBackAndDestroy(typeof(SwapRequestUpdate));
                }
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is Swap)
            {
                switch ((Swap.Property)wrapProperty.n)
                {
                    case Swap.Property.swapRequests:
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
            // Parent
            {
                // Room
                {
                    if (wrapProperty.p is Room)
                    {
                        switch ((Room.Property)wrapProperty.n)
                        {
                            case Room.Property.changeRights:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
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
                                break;
                            case Room.Property.contestManagers:
                                break;
                            case Room.Property.timeCreated:
                                break;
                            case Room.Property.chatRoom:
                                break;
                            case Room.Property.allowHint:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // ChangeRights
                    {
                        if (wrapProperty.p is ChangeRights)
                        {
                            switch ((ChangeRights.Property)wrapProperty.n)
                            {
                                case ChangeRights.Property.undoRedoRight:
                                    break;
                                case ChangeRights.Property.changeGamePlayerRight:
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
                        if (wrapProperty.p is ChangeGamePlayerRight)
                        {
                            switch ((ChangeGamePlayerRight.Property)wrapProperty.n)
                            {
                                case ChangeGamePlayerRight.Property.canChange:
                                    dirty = true;
                                    break;
                                case ChangeGamePlayerRight.Property.canChangePlayerLeft:
                                    break;
                                case ChangeGamePlayerRight.Property.needAdminAccept:
                                    break;
                                case ChangeGamePlayerRight.Property.onlyAdminNeed:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
                // ContestManagerStatePlay
                {
                    if (wrapProperty.p is ContestManagerStatePlay)
                    {
                        return;
                    }
                    // CheckChange
                    if (wrapProperty.p is ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            if (wrapProperty.p is SwapRequest)
            {
                switch ((SwapRequest.Property)wrapProperty.n)
                {
                    case SwapRequest.Property.state:
                        break;
                    case SwapRequest.Property.teamIndex:
                        dirty = true;
                        break;
                    case SwapRequest.Property.playerIndex:
                        dirty = true;
                        break;
                    case SwapRequest.Property.inform:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}