using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalRoomContainerUpdate : UpdateBehavior<GlobalRoomContainer>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {

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

	public override void onAddCallBack<T> (T data)
	{
		if (data is GlobalRoomContainer) {
			GlobalRoomContainer globalRoomContainer = data as GlobalRoomContainer;
			// Child
			{
				globalRoomContainer.rooms.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is Room) {
			Room room = data as Room;
			// Update
			{
				UpdateUtils.makeUpdate<RoomUpdate, Room> (room, this.transform);
			}
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is GlobalRoomContainer) {
			GlobalRoomContainer globalRoomContainer = data as GlobalRoomContainer;
			// Child
			{
				globalRoomContainer.rooms.allRemoveCallBack (this);
			}
			this.setDataNull (globalRoomContainer);
			return;
		}
		// Child
		if (data is Room) {
			Room room = data as Room;
			// Update
			{
				room.removeCallBackAndDestroy (typeof(RoomUpdate));
			}
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is GlobalRoomContainer) {
			switch ((GlobalRoomContainer.Property)wrapProperty.n) {
			case GlobalRoomContainer.Property.rooms:
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
		if (wrapProperty.p is Room) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}