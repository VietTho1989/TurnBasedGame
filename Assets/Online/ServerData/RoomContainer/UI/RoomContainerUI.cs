using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomContainerUI : UIBehavior<RoomContainerUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<uint> profileId;

        public LP<ReferenceData<Room>> rooms;

        #region Sub

        public abstract class Sub : Data
        {

            public enum Type
            {
                RoomList,
                RoomUI
            }

            public abstract Type getType();

            public abstract bool processEvent(Event e);

            public abstract MainUI.UIData.AllowShowBanner getAllowShowBanner();

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            profileId,
            rooms,
            sub
        }

        public UIData() : base()
        {
            this.profileId = new VP<uint>(this, (byte)Property.profileId, 0);
            this.rooms = new LP<ReferenceData<Room>>(this, (byte)Property.rooms);
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // sub
                if (!isProcess)
                {
                    Sub sub = this.sub.v;
                    if (sub != null)
                    {
                        isProcess = sub.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("sub null");
                    }
                }
            }
            return isProcess;
        }

        public MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            MainUI.UIData.AllowShowBanner ret = MainUI.UIData.AllowShowBanner.ForceShow;
            {
                Sub sub = this.sub.v;
                if (sub != null)
                {
                    ret = sub.getAllowShowBanner();
                }
                else
                {
                    Debug.LogError("sub null");
                }
            }
            return ret;
        }

    }

    #endregion

    public override int getStartAllocate()
    {
        return 1;
    }

    #region Refresh

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // find room you inside
                Room room = null;
                {
                    foreach (ReferenceData<Room> referenceRoom in this.data.rooms.vs)
                    {
                        Room checkRoom = referenceRoom.data;
                        // Debug.LogError ("checkRoom: " + checkRoom);
                        if (checkRoom != null && checkRoom.state.v.getType() == Room.State.Type.Normal)
                        {
                            foreach (RoomUser roomUser in checkRoom.users.vs)
                            {
                                if (roomUser.inform.v.playerId.v == this.data.profileId.v)
                                {
                                    if (roomUser.isInsideRoom())
                                    {
                                        room = checkRoom;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Debug.LogError("room null or end");
                        }
                    }
                }
                // process
                if (room != null)
                {
                    RoomUI.UIData roomUIData = this.data.sub.newOrOld<RoomUI.UIData>();
                    {
                        roomUIData.room.v = new ReferenceData<Room>(room);
                    }
                    this.data.sub.v = roomUIData;
                }
                else
                {
                    RoomListUI.UIData roomListUIData = this.data.sub.newOrOld<RoomListUI.UIData>();
                    {

                    }
                    this.data.sub.v = roomListUIData;
                }
            }
            else
            {
                // Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public RoomListUI roomListPrefab;
    public RoomUI roomPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.rooms.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            // rooms
            {
                if (data is Room)
                {
                    Room room = data as Room;
                    // Child
                    {
                        room.users.allAddCallBack(this);
                    }
                    dirty = true;
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
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Human)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.RoomList:
                            {
                                RoomListUI.UIData roomListUIData = sub as RoomListUI.UIData;
                                UIUtils.Instantiate(roomListUIData, roomListPrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.RoomUI:
                            {
                                RoomUI.UIData roomUIData = sub as RoomUI.UIData;
                                UIUtils.Instantiate(roomUIData, roomPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType());
                            break;
                    }
                }
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.rooms.allRemoveCallBack(this);
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            // rooms
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
                            roomUser.inform.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Human)
                    {
                        return;
                    }
                }
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.RoomList:
                            {
                                RoomListUI.UIData roomListUIData = sub as RoomListUI.UIData;
                                roomListUIData.removeCallBackAndDestroy(typeof(RoomListUI));
                            }
                            break;
                        case UIData.Sub.Type.RoomUI:
                            {
                                RoomUI.UIData roomUIData = sub as RoomUI.UIData;
                                roomUIData.removeCallBackAndDestroy(typeof(RoomUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType());
                            break;
                    }
                }
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
        if (wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.profileId:
                    dirty = true;
                    break;
                case UIData.Property.rooms:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.sub:
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
            // rooms
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
                            break;
                        case Room.Property.users:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Room.Property.state:
                            dirty = true;
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
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
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
                                    dirty = true;
                                }
                                break;
                            case RoomUser.Property.state:
                                dirty = true;
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
                        Human.onUpdateSyncPlayerIdChange(wrapProperty, this);
                        return;
                    }
                }
            }
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}