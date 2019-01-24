using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomUserRoleAdminUpdate : UpdateBehavior<Room>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// Check already havve admin
				bool alreadyHaveAdmin = false;
				{
					RoomUser admin = this.data.findAdmin ();
					if (admin != null) {
						alreadyHaveAdmin = true;
					} else {
						Debug.LogError ("admin null: " + this);
					}
				}
				// Make new admin
				if (!alreadyHaveAdmin) {
					for (int i = 0; i < this.data.users.vs.Count; i++) {
						RoomUser roomUser = this.data.users.vs [i];
						if (roomUser.isInsideRoom ()) {
							roomUser.role.v = RoomUser.Role.ADMIN;
							break;
						}
					}
				} else {
					// Debug.Log ("already have admin");
				}
			} else {
				Debug.LogError ("room null");
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
		if (data is Room) {
			Room room = data as Room;
			{
				room.users.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		if (data is RoomUser) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Room) {
			Room room = data as Room;
			{
				room.users.allRemoveCallBack (this);
			}
			// set data null
			this.setDataNull (room);
			return;
		}
		if (data is RoomUser) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is Room) {
			switch ((Room.Property)wrapProperty.n) {
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
				break;
			case Room.Property.contestManagers:
				break;
			case Room.Property.timeCreated:
				break;
			case Room.Property.chatRoom:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		if (wrapProperty.p is RoomUser) {
			switch ((RoomUser.Property)wrapProperty.n) {
			case RoomUser.Property.role:
				dirty = true;
				break;
			case RoomUser.Property.inform:
				dirty = true;
				break;
			case RoomUser.Property.state:
				dirty = true;
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}