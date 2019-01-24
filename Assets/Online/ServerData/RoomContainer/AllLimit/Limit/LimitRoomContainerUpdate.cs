using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LimitRoomContainerUpdate : UpdateBehavior<LimitRoomContainer>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				this.data.userCount.v = this.data.users.vs.Count;
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
		if (data is LimitRoomContainer) {
			LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
			// Update
			{
				UpdateUtils.makeUpdate<CheckLimitRoomContainerUserInUpdate, LimitRoomContainer> (limitRoomContainer, this.transform);
			}
			// Child
			{
				limitRoomContainer.users.allAddCallBack (this);
				limitRoomContainer.rooms.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is Human) {
				Human human = data as Human;
				// Update
				{
					UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
				}
				dirty = true;
				return;
			}
			if (data is Room) {
				Room room = data as Room;
				// Update
				{
					UpdateUtils.makeUpdate<RoomUpdate, Room> (room, this.transform);
				}
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is LimitRoomContainer) {
			LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
			// Update
			{
				limitRoomContainer.removeCallBackAndDestroy (typeof(CheckLimitRoomContainerUserInUpdate));
			}
			// Child
			{
				limitRoomContainer.users.allRemoveCallBack (this);
				limitRoomContainer.rooms.allRemoveCallBack (this);
			}
			this.setDataNull (limitRoomContainer);
			return;
		}
		// Child
		{
			if (data is Human) {
				Human human = data as Human;
				// Update
				{
					human.removeCallBackAndDestroy (typeof(HumanUpdate));
				}
				return;
			}
			if (data is Room) {
				Room room = data as Room;
				// Update
				{
					room.removeCallBackAndDestroy (typeof(RoomUpdate));
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
		if (wrapProperty.p is LimitRoomContainer) {
			switch ((LimitRoomContainer.Property)wrapProperty.n) {
			case LimitRoomContainer.Property.maxUserCount:
				break;
			case LimitRoomContainer.Property.userCount:
				break;
			case LimitRoomContainer.Property.users:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case LimitRoomContainer.Property.gameTypes:
				break;
			case LimitRoomContainer.Property.rooms:
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
			if (wrapProperty.p is Human) {
				return;
			}
			if (wrapProperty.p is Room) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}