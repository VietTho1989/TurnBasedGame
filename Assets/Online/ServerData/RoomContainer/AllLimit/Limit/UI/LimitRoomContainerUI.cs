using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LimitRoomContainerUI : UIBehavior<LimitRoomContainerUI.UIData>
{

	#region UIData

	public class UIData : AllLimitRoomContainersUI.UIData.Sub
	{

		public VP<ReferenceData<LimitRoomContainer>> limitRoomContainer;

		public VP<RoomContainerUI.UIData> roomContainerUIData;

		#region Constructor

		public enum Property
		{
			limitRoomContainer,
			roomContainerUIData
		}

		public UIData() : base()
		{
			this.limitRoomContainer = new VP<ReferenceData<LimitRoomContainer>>(this, (byte)Property.limitRoomContainer, new ReferenceData<LimitRoomContainer>(null));
			this.roomContainerUIData = new VP<RoomContainerUI.UIData>(this, (byte)Property.roomContainerUIData, new RoomContainerUI.UIData());
		}

		#endregion

		public override Type getType ()
		{
			return Type.Limit;
		}

		public override bool processEvent (Event e)
		{
			bool isProcess = false;
			{
				// roomContainerUIData
				if (!isProcess) {
					RoomContainerUI.UIData roomContainerUIData = this.roomContainerUIData.v;
					if (roomContainerUIData != null) {
						isProcess = roomContainerUIData.processEvent (e);
					} else {
						Debug.LogError ("roomContainerUIData null");
					}
				}
			}
			return isProcess;
		}

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				LimitRoomContainer limitRoomContainer = this.data.limitRoomContainer.v.data;
				if (limitRoomContainer != null) {
					// roomContainerUIData
					{
						RoomContainerUI.UIData roomContainerUIData = this.data.roomContainerUIData.v;
						if (roomContainerUIData != null) {
							// rooms
							{
								// get list
								List<ReferenceData<Room>> referenceRooms = new List<ReferenceData<Room>> ();
								{
									foreach (Room room in limitRoomContainer.rooms.vs) {
										referenceRooms.Add (new ReferenceData<Room> (room));
									}
								}
								// update
								roomContainerUIData.rooms.copyList (referenceRooms);
							}
							// profileId
							roomContainerUIData.profileId.v = Server.getProfileUserId (limitRoomContainer);
						} else {
							Debug.LogError ("roomContainerUIData null");
						}
					}
				} else {
					Debug.LogError ("limitRoomContainer null");
				}
			} else {
				Debug.LogError ("data null");
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public RoomContainerUI roomContainerPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.limitRoomContainer.allAddCallBack (this);
				uiData.roomContainerUIData.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is LimitRoomContainer) {
				dirty = true;
				return;
			}
			if (data is RoomContainerUI.UIData) {
				RoomContainerUI.UIData roomContainerUIData = data as RoomContainerUI.UIData;
				// UI
				{
					UIUtils.Instantiate (roomContainerUIData, roomContainerPrefab, this.transform);
				}
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.limitRoomContainer.allRemoveCallBack (this);
				uiData.roomContainerUIData.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is LimitRoomContainer) {
				return;
			}
			if (data is RoomContainerUI.UIData) {
				RoomContainerUI.UIData roomContainerUIData = data as RoomContainerUI.UIData;
				// UI
				{
					roomContainerUIData.removeCallBackAndDestroy (typeof(RoomContainerUI));
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.limitRoomContainer:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.roomContainerUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is LimitRoomContainer) {
				switch ((LimitRoomContainer.Property)wrapProperty.n) {
				case LimitRoomContainer.Property.maxUserCount:
					break;
				case LimitRoomContainer.Property.userCount:
					break;
				case LimitRoomContainer.Property.users:
					break;
				case LimitRoomContainer.Property.gameTypes:
					break;
				case LimitRoomContainer.Property.rooms:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is RoomContainerUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don''t process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}