using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Cai ham nay cung check co nguoi ra vao hay ko nua
 * */
public class RoomCheckChangeAdminChange<K> : Data, ValueChangeCallBack where K : Data
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

    public RoomCheckChangeAdminChange() : base()
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
                room.users.allAddCallBack(this);
            }
            this.notifyChange();
            return;
        }
        // RoomUser
        {
            if (data is RoomUser)
            {
                RoomUser roomUser = data as RoomUser;
                // Child
                {
                    roomUser.inform.allAddCallBack(this);
                }
                this.notifyChange();
                return;
            }
            if (data is Human)
            {
                this.notifyChange();
                return;
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
                room.users.allRemoveCallBack(this);
            }
            return;
        }
        // RoomUser
        {
            if (data is RoomUser)
            {
                RoomUser roomUser = data as RoomUser;
                // Child
                {
                    roomUser.inform.allRemoveCallBack(this);
                }
                return;
            }
            if (data is Human)
            {
                return;
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
                case Room.Property.name:
                    break;
                case Room.Property.password:
                    break;
                case Room.Property.users:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        this.notifyChange();
                    }
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
        // RoomUser
        {
            if (wrapProperty.p is RoomUser)
            {
                switch ((RoomUser.Property)wrapProperty.n)
                {
                    case RoomUser.Property.role:
                        this.notifyChange();
                        break;
                    case RoomUser.Property.inform:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            this.notifyChange();
                        }
                        break;
                    case RoomUser.Property.state:
                        this.notifyChange();
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            if (wrapProperty.p is Human)
            {
                switch ((Human.Property)wrapProperty.n)
                {
                    case Human.Property.playerId:
                        this.notifyChange();
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
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    #endregion

}