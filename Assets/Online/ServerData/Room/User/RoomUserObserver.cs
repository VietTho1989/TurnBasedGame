using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class RoomUserObserver : GameObserver.CheckChange
{

	public RoomUserObserver(GameObserver gameObserver) : base(gameObserver)
	{

	}

	#region setData

	public RoomUser data = null;

	public override void setData(Data newData)
	{
		// set
		if (this.data != newData) {
			// remove old
			{
				DataUtils.removeParentCallBack (this.data, this, ref this.room);
			}
			// set new 
			{
				this.data = newData as RoomUser;
				DataUtils.addParentCallBack (this.data, this, ref this.room);
			}
		} else {
			// Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
		}
	}


	public override Type getType ()
	{
		return Type.RoomUser;
	}

	#endregion

	#region implement callBacks

	private Room room = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is Room) {
			Room room = data as Room;
			// Child
			{
				room.users.allAddCallBack (this);
			}
			// dirty = true;
			// needRefresh = true;
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
				// dirty = true;
				// needRefresh = true;
				return;
			}
			// Child
			if (data is Human) {
				// dirty = true;
				// needRefresh = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
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
					roomUser.inform.v.removeCallBack (this);
				}
				return;
			}
			// Child
			if (data is Human) {
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
		if (wrapProperty.p is Room) {
			switch ((Room.Property)wrapProperty.n) {
			case Room.Property.name:
				break;
			case Room.Property.password:
				break;
			case Room.Property.users:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					gameObserver.dirty = true;
					gameObserver.needRefresh = true;
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
		// Child
		{
			if (wrapProperty.p is RoomUser) {
				switch ((RoomUser.Property)wrapProperty.n) {
				case RoomUser.Property.role:
					break;
				case RoomUser.Property.inform:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						gameObserver.dirty = true;
						gameObserver.needRefresh = true;
					}
					break;
				case RoomUser.Property.state:
					{
						gameObserver.dirty = true;
						gameObserver.needRefresh = true;
					}
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is Human) {
				switch ((Human.Property)wrapProperty.n) {
				case Human.Property.playerId:
					break;
				case Human.Property.account:
					break;
				case Human.Property.state:
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
					{
						gameObserver.dirty = true;
						gameObserver.needRefresh = true;
					}
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public override void refreshObserverConnections ()
	{
		gameObserver.allConnections.Clear ();
		if (this.data != null) {
			Room room = this.data.findDataInParent<Room> ();
			if (room != null) {
				// all add roomUser connection in room
				foreach (RoomUser roomUser in room.users.vs) {
					if (roomUser.inform.v.connection.v != null) {
						gameObserver.allConnections.Add (roomUser.inform.v.connection.v);
					} else {
						// Debug.LogError ("RoomUser connection null: " + roomUser + "; " + this);
					}
				}
			} else {
				Debug.LogError ("room null: " + this);
			}
		} else {
			Debug.LogError ("room null: " + this);
		}
		// Debug.LogError ("refreshObserverConnections: " + this.data);
	}

	public override void onChangeParentObservers (Dictionary<int, NetworkConnection>.ValueCollection parentObserver)
	{
		gameObserver.dirty = true;
		gameObserver.needRefresh = true;
	}

}