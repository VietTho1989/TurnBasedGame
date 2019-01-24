using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomManagerUpdate : UpdateBehavior<RoomManager>
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
		if (data is RoomManager) {
			RoomManager roomManager = data as RoomManager;
			// Child
			{
				roomManager.globalRoomContainer.allAddCallBack (this);
				roomManager.allLimitRoomContainers.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is GlobalRoomContainer) {
				GlobalRoomContainer globalRoomContainer = data as GlobalRoomContainer;
				// Update
				{
					UpdateUtils.makeUpdate<GlobalRoomContainerUpdate, GlobalRoomContainer> (globalRoomContainer, this.transform);
				}
				dirty = true;
				return;
			}
			if (data is AllLimitRoomContainers) {
				AllLimitRoomContainers allLimitRoomContainers = data as AllLimitRoomContainers;
				// Update
				{
					UpdateUtils.makeUpdate<AllLimitRoomContainersUpdate, AllLimitRoomContainers> (allLimitRoomContainers, this.transform);
				}
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is RoomManager) {
			RoomManager roomManager = data as RoomManager;
			// Child
			{
				roomManager.globalRoomContainer.allRemoveCallBack (this);
				roomManager.allLimitRoomContainers.allRemoveCallBack (this);
			}
			this.setDataNull (roomManager);
			return;
		}
		// Child
		{
			if (data is GlobalRoomContainer) {
				GlobalRoomContainer globalRoomContainer = data as GlobalRoomContainer;
				// Update
				{
					globalRoomContainer.removeCallBackAndDestroy (typeof(GlobalRoomContainerUpdate));
				}
				return;
			}
			if (data is AllLimitRoomContainers) {
				AllLimitRoomContainers allLimitRoomContainers = data as AllLimitRoomContainers;
				// Update
				{
					allLimitRoomContainers.removeCallBackAndDestroy (typeof(AllLimitRoomContainersUpdate));
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
		if (wrapProperty.p is RoomManager) {
			switch ((RoomManager.Property)wrapProperty.n) {
			case RoomManager.Property.globalRoomContainer:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case RoomManager.Property.allLimitRoomContainers:
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
			if (wrapProperty.p is GlobalRoomContainer) {
				return;
			}
			if (wrapProperty.p is AllLimitRoomContainers) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}