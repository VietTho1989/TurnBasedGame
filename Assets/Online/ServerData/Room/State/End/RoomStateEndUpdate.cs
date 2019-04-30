using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class RoomStateEndUpdate : UpdateBehavior<RoomStateEnd>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                startRoutine(ref this.removeRoutine, TaskRemove());
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

    #region Routine Remove

    private Routine removeRoutine;

    public override List<Routine> getRoutineList()
    {
        List<Routine> ret = new List<Routine>();
        {
            ret.Add(removeRoutine);
        }
        return ret;
    }

    public IEnumerator TaskRemove()
    {
        if (this.data != null)
        {
            yield return new Wait(60f);
            if (this.data != null)
            {
                RoomContainer roomContainer = this.data.findDataInParent<RoomContainer>();
                if (roomContainer != null)
                {
                    Room room = this.data.findDataInParent<Room>();
                    if (room != null)
                    {
                        switch (roomContainer.getType())
                        {
                            case RoomContainer.Type.Global:
                                {
                                    GlobalRoomContainer globalRoomContainer = roomContainer as GlobalRoomContainer;
                                    globalRoomContainer.rooms.remove(room);
                                }
                                break;
                            case RoomContainer.Type.Limit:
                                {
                                    LimitRoomContainer limitRoomContainer = roomContainer as LimitRoomContainer;
                                    limitRoomContainer.rooms.remove(room);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + roomContainer.getType());
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("room null");
                    }
                }
                else
                {
                    Debug.LogError("roomContainer null");
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is RoomStateEnd)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is RoomStateEnd)
        {
            RoomStateEnd roomStateEnd = data as RoomStateEnd;
            // Child
            {

            }
            this.setDataNull(roomStateEnd);
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
        if (wrapProperty.p is RoomStateEnd)
        {
            switch ((RoomStateEnd.Property)wrapProperty.n)
            {
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