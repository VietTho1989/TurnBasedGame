using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class OnlyRoomPlayerObserver : GameObserver.CheckChange
{

    public OnlyRoomPlayerObserver(GameObserver gameObserver) : base(gameObserver)
    {

    }

    #region setData

    public Room data = null;

    public override void setData(Data newData)
    {
        // set
        if (this.data != newData)
        {
            // remove old
            if (this.data != null)
            {
                this.data.removeCallBack(this);
            }
            // set new 
            {
                this.data = newData as Room;
                if (this.data != null)
                {
                    this.data.addCallBack(this);
                }
            }
        }
        else
        {
            // Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
        }
    }


    public override Type getType()
    {
        return Type.OnlyRoomPlayer;
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
                room.users.allAddCallBack(this);
            }
            // dirty = true;
            // needRefresh = true;
            return;
        }
        // Child
        {
            if (data is RoomUser)
            {
                RoomUser roomUser = data as RoomUser;
                // Child
                {
                    roomUser.inform.allAddCallBack(this);
                }
                // dirty = true;
                // needRefresh = true;
                return;
            }
            // Child
            if (data is Human)
            {
                // dirty = true;
                // needRefresh = true;
                return;
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
                room.users.allRemoveCallBack(this);
            }
            return;
        }
        // Child
        {
            if (data is RoomUser)
            {
                RoomUser roomUser = data as RoomUser;
                // Child
                {
                    roomUser.inform.v.removeCallBack(this);
                }
                return;
            }
            // Child
            if (data is Human)
            {
                return;
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
                case Room.Property.name:
                    break;
                case Room.Property.password:
                    break;
                case Room.Property.users:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        gameObserver.dirty = true;
                        gameObserver.needRefresh = true;
                    }
                    break;
                case Room.Property.state:
                    break;
                case Room.Property.contestManagers:
                    break;
                case Room.Property.timeCreated:
                    break;
                case Room.Property.chatRoom:
                    break;
                default:
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is RoomUser)
            {
                switch ((RoomUser.Property)wrapProperty.n)
                {
                    case RoomUser.Property.role:
                        break;
                    case RoomUser.Property.inform:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            gameObserver.dirty = true;
                            gameObserver.needRefresh = true;
                        }
                        break;
                    case RoomUser.Property.state:
                        {
                            gameObserver.dirty = true;
                            gameObserver.needRefresh = true;
                        }
                        break;
                    default:
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
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
                        {
                            gameObserver.dirty = true;
                            gameObserver.needRefresh = true;
                        }
                        break;
                    default:
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region Global

    public override void refreshObserverConnections()
    {
        gameObserver.allConnections.Clear();
        if (this.data != null)
        {
            foreach (RoomUser roomUser in this.data.users.vs)
            {
                if (roomUser.isInsideRoom())
                {
                    if (roomUser.inform.v.connection.v != null)
                    {
                        gameObserver.allConnections.Add(roomUser.inform.v.connection.v);
                    }
                    else
                    {
                        // Debug.LogError ("RoomUser connection null: " + roomUser + "; " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("this roomUser not in room: " + roomUser + "; " + this);
                }
            }
        }
        else
        {
            Debug.LogError("room null: " + this);
        }
    }

    public override void onChangeParentObservers(System.Collections.ObjectModel.ReadOnlyCollection<NetworkConnection> parentObserver)
    {
        gameObserver.dirty = true;
        gameObserver.needRefresh = true;
    }

    #endregion

}