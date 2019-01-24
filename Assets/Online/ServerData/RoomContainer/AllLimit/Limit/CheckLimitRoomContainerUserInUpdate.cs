using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckLimitRoomContainerUserInUpdate : UpdateBehavior<LimitRoomContainer>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// get list user in limitRoomContainer
				HashSet<uint> userIds = new HashSet<uint>();
				{
					for (int i = this.data.users.vs.Count - 1; i >= 0; i--) {
						Human human = this.data.users.vs [i];
						if (human.state.v.state.v == UserState.State.Offline) {
							this.data.users.removeAt (i);
						} else {
							userIds.Add (human.playerId.v);
						}
					}
				}
				// remove all user in room not in limitContainer
				foreach (Room room in this.data.rooms.vs) {
					if (room.state.v.getType () == Room.State.Type.Normal) {
						foreach (RoomUser roomUser in room.users.vs) {
							if (roomUser.isInsideRoom ()) {
								if (!userIds.Contains (roomUser.inform.v.playerId.v)) {
									Debug.LogError ("not inside roomLimitContainer any more: " + roomUser);
									roomUser.state.v = RoomUser.State.LEFT;
								}
							}
						}
					}
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

	public override void onAddCallBack<T> (T data)
	{
		if (data is LimitRoomContainer) {
			LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
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
			// room
			{
				if (data is Room) {
					Room room = data as Room;
					// Child
					{
						room.users.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is RoomUser) {
						RoomUser roomUser = data as RoomUser;
						// Child
						{
							roomUser.inform.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// human o duoi
				}
			}
			// human
			{
				if (data is Human) {
					Human human = data as Human;
					// Child
					{
						human.state.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is UserState) {
					dirty = true;
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is LimitRoomContainer) {
			LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
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
			// room
			{
				if (data is Room) {
					Room room = data as Room;
					// Child
					{
						room.users.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is RoomUser) {
						RoomUser roomUser = data as RoomUser;
						// Child
						{
							roomUser.inform.allRemoveCallBack (this);
						}
						return;
					}
					// human o duoi
				}
			}
			// human
			{
				if (data is Human) {
					Human human = data as Human;
					// Child
					{
						human.state.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is UserState) {
					return;
				}
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
			// room
			{
				if (wrapProperty.p is Room) {
					switch ((Room.Property)wrapProperty.n) {
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
							ValueChangeUtils.replaceCallBack (this, syncs);
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
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is RoomUser) {
						switch ((RoomUser.Property)wrapProperty.n) {
						case RoomUser.Property.role:
							break;
						case RoomUser.Property.inform:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case RoomUser.Property.state:
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// human o duoi
				}
			}
			// human
			{
				if (wrapProperty.p is Human) {
					switch ((Human.Property)wrapProperty.n) {
					case Human.Property.playerId:
						dirty = true;
						break;
					case Human.Property.account:
						break;
					case Human.Property.state:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
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
					case Human.Property.ban:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is UserState) {
					switch ((UserState.Property)wrapProperty.n) {
					case UserState.Property.state:
						dirty = true;
						break;
					case UserState.Property.hide:
						break;
					case UserState.Property.time:
						break;
					default:
						break;
					}
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}