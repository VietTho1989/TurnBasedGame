using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * TODO Co le nen loai bo nhung nguoi mat ket noi nua
 * */
public class HumanConnectionCheckInsideRoomUpdate : UpdateBehavior<History>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Room room = this.data.findDataInParent<Room>();
                if (room != null)
                {
                    if (room.allowLoadHistory.v)
                    {
                        for (int i = this.data.humanConnections.vs.Count - 1; i >= 0; i--)
                        {
                            HumanConnection humanConnection = this.data.humanConnections.vs[i];
                            // find inside room
                            bool isInsideRoom = false;
                            {
                                RoomUser roomUser = room.users.getInList(humanConnection.playerId.v);
                                if (roomUser != null && roomUser.isInsideRoom())
                                {
                                    isInsideRoom = true;
                                }
                            }
                            // process
                            if (!isInsideRoom)
                            {
                                Debug.LogError("not inside room anymore: " + humanConnection.playerId.v + "; " + this);
                                this.data.humanConnections.removeAt(i);
                            }
                        }
                    }
                    else
                    {
                        this.data.humanConnections.clear();
                    }
                }
                else
                {
                    Debug.LogError("room null: " + this);
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

    private RoomCheckChangeAdminChange<History> roomCheckAdminChange = new RoomCheckChangeAdminChange<History>();
    private Room room = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is History)
        {
            History history = data as History;
            // CheckChange
            {
                roomCheckAdminChange.addCallBack(this);
                roomCheckAdminChange.setData(history);
            }
            // Parent
            {
                DataUtils.addParentCallBack(history, this, ref this.room);
            }
            dirty = true;
            return;
        }
        // CheckChange
        if (data is RoomCheckChangeAdminChange<History>)
        {
            dirty = true;
            return;
        }
        // Parent
        if (data is Room)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is History)
        {
            History history = data as History;
            // CheckChange
            {
                roomCheckAdminChange.removeCallBack(this);
                roomCheckAdminChange.setData(null);
            }
            // Parent
            {
                DataUtils.removeParentCallBack(history, this, ref this.room);
            }
            this.setDataNull(history);
            return;
        }
        // CheckChange
        if (data is RoomCheckChangeAdminChange<History>)
        {
            return;
        }
        // Parent
        if (data is Room)
        {
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
        if (wrapProperty.p is History)
        {
            return;
        }
        // CheckChange
        if (wrapProperty.p is RoomCheckChangeAdminChange<History>)
        {
            dirty = true;
            return;
        }
        // Parent
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
                case Room.Property.allowLoadHistory:
                    dirty = true;
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