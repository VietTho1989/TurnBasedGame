using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class CheckCanMakeNewContestManagerChange<K> : Data, ValueChangeCallBack where K : Data
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

        public CheckCanMakeNewContestManagerChange() : base()
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
                    DataUtils.removeParentCallBack(this.data, this, ref this.room);
                }
                // set new 
                {
                    this.data = newData;
                    DataUtils.addParentCallBack(this.data, this, ref this.room);
                }
            }
            else
            {
                Debug.LogError("the same: " + this + ", " + data + ", " + newData);
            }
        }

        #region implement callBacks

        private Room room = null;

        public void onAddCallBack<T>(T data) where T : Data
        {
            if (data is Room)
            {
                Room room = data as Room;
                // Child
                {
                    room.requestNewContestManager.allAddCallBack(this);
                    room.contestManagers.allAddCallBack(this);
                }
                this.notifyChange();
                return;
            }
            // Child
            {
                if (data is RequestNewContestManager)
                {
                    this.notifyChange();
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
                        this.notifyChange();
                        return;
                    }
                    // Child
                    if (data is ContestManager.State)
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
            if (data is Room)
            {
                Room room = data as Room;
                // Child
                {
                    room.requestNewContestManager.allRemoveCallBack(this);
                    room.contestManagers.allRemoveCallBack(this);
                }
                this.room = null;
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
                    if (data is ContestManager.State)
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
                            this.notifyChange();
                        }
                        break;
                    case Room.Property.contestManagers:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            this.notifyChange();
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
                            case ContestManager.Property.index:
                                break;
                            case ContestManager.Property.state:
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
                                        case ContestManagerStatePlay.Property.state:
                                            this.notifyChange();
                                            break;
                                        case ContestManagerStatePlay.Property.teams:
                                            break;
                                        case ContestManagerStatePlay.Property.content:
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
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        #endregion

    }
}