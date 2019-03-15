using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class SwapRequestStateAskUpdate : UpdateBehavior<SwapRequestStateAsk>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    bool isHumanStillInsideRoom = true;
                    uint newHumanId = Data.UNKNOWN_ID;
                    {
                        SwapRequest swapRequest = this.data.findDataInParent<SwapRequest>();
                        if (swapRequest != null)
                        {
                            if (swapRequest.inform.v is Human)
                            {
                                Human human = swapRequest.inform.v as Human;
                                newHumanId = human.playerId.v;
                                // find
                                bool isInsideRoom = false;
                                {
                                    RoomUser roomUser = Room.findUser(human.playerId.v, this.data);
                                    if (roomUser != null)
                                    {
                                        if (roomUser.isInsideRoom())
                                        {
                                            isInsideRoom = true;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("roomUser null: " + this);
                                    }
                                }
                                // process
                                if (!isInsideRoom)
                                {
                                    isHumanStillInsideRoom = false;
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("swapRequest null: " + this);
                        }
                    }
                    if (!isHumanStillInsideRoom)
                    {
                        // cancel
                        SwapRequest swapRequest = this.data.findDataInParent<SwapRequest>();
                        if (swapRequest != null)
                        {
                            SwapRequestStateCancel swapRequestStateCancel = new SwapRequestStateCancel();
                            {
                                swapRequestStateCancel.uid = swapRequest.state.makeId();
                                swapRequestStateCancel.whoCancel.v.playerId.v = newHumanId;
                            }
                            swapRequest.state.v = swapRequestStateCancel;
                        }
                        else
                        {
                            Debug.LogError("swapRequest null: " + this);
                        }
                    }
                    else
                    {
                        HashSet<uint> whoCanAsks = SwapRequestStateAsk.WhoCanAsk(this.data);
                        // update human
                        {
                            // get old
                            List<Human> oldHumans = new List<Human>();
                            {
                                oldHumans.AddRange(this.data.whoCanAsks.vs);
                            }
                            // Update
                            {
                                foreach (uint userId in whoCanAsks)
                                {
                                    // find Human
                                    Human human = null;
                                    {
                                        // find old
                                        if (oldHumans.Count > 0)
                                        {
                                            human = oldHumans[0];
                                        }
                                        // make new
                                        if (human == null)
                                        {
                                            human = new Human();
                                            {
                                                human.uid = this.data.whoCanAsks.makeId();
                                            }
                                            this.data.whoCanAsks.add(human);
                                        }
                                        else
                                        {
                                            oldHumans.Remove(human);
                                        }
                                    }
                                    // Update
                                    {
                                        human.playerId.v = userId;
                                    }
                                }
                            }
                            // Remove old
                            foreach (Human oldHuman in oldHumans)
                            {
                                this.data.whoCanAsks.remove(oldHuman);
                            }
                        }
                        // accepts
                        {
                            // remove who cannot ask
                            for (int i = this.data.accepts.vs.Count - 1; i >= 0; i--)
                            {
                                if (!whoCanAsks.Contains(this.data.accepts.vs[i]))
                                {
                                    Debug.LogError("not contains: " + this.data.accepts.vs[i]);
                                    this.data.accepts.removeAt(i);
                                }
                            }
                            // check all accept
                            bool allAccept = true;
                            {
                                foreach (uint userId in whoCanAsks)
                                {
                                    if (!this.data.accepts.vs.Contains(userId))
                                    {
                                        allAccept = false;
                                        break;
                                    }
                                }
                            }
                            // Process
                            if (allAccept)
                            {
                                SwapRequest swapRequest = this.data.findDataInParent<SwapRequest>();
                                if (swapRequest != null)
                                {
                                    // change inform
                                    {
                                        ContestManagerStatePlay contestManagerStatePlay = this.data.findDataInParent<ContestManagerStatePlay>();
                                        if (contestManagerStatePlay != null)
                                        {
                                            TeamPlayer teamPlayer = contestManagerStatePlay.findPlayer(swapRequest.teamIndex.v, swapRequest.playerIndex.v);
                                            if (teamPlayer != null)
                                            {
                                                GamePlayer.Inform newInform = DataUtils.cloneData(swapRequest.inform.v) as GamePlayer.Inform;
                                                {
                                                    newInform.uid = teamPlayer.inform.makeId();
                                                }
                                                teamPlayer.inform.v = newInform;
                                            }
                                            else
                                            {
                                                Debug.LogError("teamPlayer null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("contestManagerStatePlay null: " + this);
                                        }
                                    }
                                    // chuyen sang state accept
                                    SwapRequestStateAccept swapRequestStateAccept = new SwapRequestStateAccept();
                                    {
                                        swapRequestStateAccept.uid = swapRequest.state.makeId();
                                    }
                                    swapRequest.state.v = swapRequestStateAccept;
                                }
                                else
                                {
                                    Debug.LogError("swapRequest null: " + this);
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

        private Room room = null;
        private RoomCheckChangeAdminChange<SwapRequestStateAsk> roomCheckAdminChange = new RoomCheckChangeAdminChange<SwapRequestStateAsk>();

        private ContestManagerStatePlay contestManagerStatePlay = null;
        private ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay> contestManagerStatePlayTeamCheckChange = new ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is SwapRequestStateAsk)
            {
                SwapRequestStateAsk swapRequestStateAsk = data as SwapRequestStateAsk;
                // CheckChange
                {
                    roomCheckAdminChange.addCallBack(this);
                    roomCheckAdminChange.setData(swapRequestStateAsk);
                }
                // Parent
                {
                    DataUtils.addParentCallBack(swapRequestStateAsk, this, ref this.room);
                    DataUtils.addParentCallBack(swapRequestStateAsk, this, ref this.contestManagerStatePlay);
                    // ko xu ly swapRequest inform: mac nhien coi nhu se khong doi
                }
                // Child
                {
                    swapRequestStateAsk.whoCanAsks.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // CheckChange
            if (data is RoomCheckChangeAdminChange<SwapRequestStateAsk>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                // room
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
                    // changeRights
                    {
                        if (data is Rights.ChangeRights)
                        {
                            Rights.ChangeRights changeRights = data as Rights.ChangeRights;
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
                // contestManagerStatePlay
                {
                    if (data is ContestManagerStatePlay)
                    {
                        ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                        // Child
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
            if (data is Human)
            {
                Human human = data as Human;
                // Update
                {
                    UpdateUtils.makeUpdate<HumanUpdate, Human>(human, this.transform);
                }
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is SwapRequestStateAsk)
            {
                SwapRequestStateAsk swapRequestStateAsk = data as SwapRequestStateAsk;
                // CheckChange
                {
                    roomCheckAdminChange.removeCallBack(this);
                    roomCheckAdminChange.setData(null);
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(swapRequestStateAsk, this, ref this.room);
                    DataUtils.removeParentCallBack(swapRequestStateAsk, this, ref this.contestManagerStatePlay);
                    // ko xu ly swapRequest inform: mac nhien coi nhu se khong doi
                }
                // Child
                {
                    swapRequestStateAsk.whoCanAsks.allRemoveCallBack(this);
                }
                this.setDataNull(swapRequestStateAsk);
                return;
            }
            // CheckChange
            if (data is RoomCheckChangeAdminChange<SwapRequestStateAsk>)
            {
                return;
            }
            // Parent
            {
                // room
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
                    // changeRights
                    {
                        if (data is Rights.ChangeRights)
                        {
                            Rights.ChangeRights changeRights = data as Rights.ChangeRights;
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
                // contestManagerStatePlay
                {
                    if (data is ContestManagerStatePlay)
                    {
                        // ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                        // Child
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
            if (data is Human)
            {
                Human human = data as Human;
                // Update
                {
                    human.removeCallBackAndDestroy(typeof(HumanUpdate));
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
            if (wrapProperty.p is SwapRequestStateAsk)
            {
                switch ((SwapRequestStateAsk.Property)wrapProperty.n)
                {
                    case SwapRequestStateAsk.Property.whoCanAsks:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case SwapRequestStateAsk.Property.accepts:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            if (wrapProperty.p is RoomCheckChangeAdminChange<SwapRequestStateAsk>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                // room
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
                    // changeRights
                    {
                        if (wrapProperty.p is Rights.ChangeRights)
                        {
                            switch ((Rights.ChangeRights.Property)wrapProperty.n)
                            {
                                case Rights.ChangeRights.Property.undoRedoRight:
                                    break;
                                case Rights.ChangeRights.Property.changeGamePlayerRight:
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
                                    break;
                                case ChangeGamePlayerRight.Property.canChangePlayerLeft:
                                    dirty = true;
                                    break;
                                case ChangeGamePlayerRight.Property.needAdminAccept:
                                    dirty = true;
                                    break;
                                case ChangeGamePlayerRight.Property.onlyAdminNeed:
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
                // contestManagerStatePlay
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
            if (wrapProperty.p is Human)
            {
                Human.onUpdateSyncPlayerIdChange(wrapProperty, this);
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}