using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalRoomContainerUI : UIBehavior<GlobalRoomContainerUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<GlobalRoomContainer>> globalRoomContainer;

        public VP<RoomContainerUI.UIData> roomContainerUIData;

        #region Constructor

        public enum Property
        {
            globalRoomContainer,
            roomContainerUIData
        }

        public UIData() : base()
        {
            this.globalRoomContainer = new VP<ReferenceData<GlobalRoomContainer>>(this, (byte)Property.globalRoomContainer, new ReferenceData<GlobalRoomContainer>(null));
            this.roomContainerUIData = new VP<RoomContainerUI.UIData>(this, (byte)Property.roomContainerUIData, new RoomContainerUI.UIData());
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // roomContainerUIData
                if (!isProcess)
                {
                    RoomContainerUI.UIData roomContainerUIData = this.roomContainerUIData.v;
                    if (roomContainerUIData != null)
                    {
                        isProcess = roomContainerUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("roomContainerUIData null");
                    }
                }
            }
            return isProcess;
        }

        public MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            MainUI.UIData.AllowShowBanner ret = MainUI.UIData.AllowShowBanner.ForceShow;
            {
                RoomContainerUI.UIData roomContainerUIData = this.roomContainerUIData.v;
                if (roomContainerUIData != null)
                {
                    ret = roomContainerUIData.getAllowShowBanner();
                }
                else
                {
                    Debug.LogError("roomContainerUIData null");
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
                GlobalRoomContainer globalRoomContainer = this.data.globalRoomContainer.v.data;
                if (globalRoomContainer != null)
                {
                    // roomContainerUIData
                    {
                        RoomContainerUI.UIData roomContainerUIData = this.data.roomContainerUIData.v;
                        if (roomContainerUIData != null)
                        {
                            // rooms
                            {
                                // get list
                                List<ReferenceData<Room>> referenceRooms = new List<ReferenceData<Room>>();
                                {
                                    foreach (Room room in globalRoomContainer.rooms.vs)
                                    {
                                        referenceRooms.Add(new ReferenceData<Room>(room));
                                    }
                                }
                                // update
                                roomContainerUIData.rooms.copyList(referenceRooms);
                            }
                            // profileId
                            roomContainerUIData.profileId.v = Server.getProfileUserId(globalRoomContainer);
                        }
                        else
                        {
                            Debug.LogError("roomContainerUIData null");
                        }
                    }
                }
                else
                {
                    // Debug.LogError("globalRoomContainer null");
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

    public RoomContainerUI roomContainerPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.globalRoomContainer.allAddCallBack(this);
                uiData.roomContainerUIData.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is GlobalRoomContainer)
            {
                dirty = true;
                return;
            }
            if (data is RoomContainerUI.UIData)
            {
                RoomContainerUI.UIData roomContainerUIData = data as RoomContainerUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(roomContainerUIData, roomContainerPrefab, this.transform);
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
                uiData.globalRoomContainer.allRemoveCallBack(this);
                uiData.roomContainerUIData.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is GlobalRoomContainer)
            {
                return;
            }
            if (data is RoomContainerUI.UIData)
            {
                RoomContainerUI.UIData roomContainerUIData = data as RoomContainerUI.UIData;
                // UI
                {
                    roomContainerUIData.removeCallBackAndDestroy(typeof(RoomContainerUI));
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
                case UIData.Property.globalRoomContainer:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.roomContainerUIData:
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
            if (wrapProperty.p is GlobalRoomContainer)
            {
                switch ((GlobalRoomContainer.Property)wrapProperty.n)
                {
                    case GlobalRoomContainer.Property.rooms:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is RoomContainerUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}