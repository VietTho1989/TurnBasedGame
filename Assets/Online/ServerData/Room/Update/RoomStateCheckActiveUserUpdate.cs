using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomStateCheckActiveUserUpdate : UpdateBehavior<Room>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// Remove left player
				for (int i = this.data.users.vs.Count - 1; i >= 0; i--) {
					RoomUser roomUser = this.data.users.vs [i];
					if (roomUser.state.v == RoomUser.State.LEFT) {
						switch (roomUser.role.v) {
						case RoomUser.Role.NORMAL:
							this.data.users.remove (roomUser);
							break;
						case RoomUser.Role.ADMIN:
							{
								// admin: freeze won't be removed
								if (this.data.state.v.getType () == Room.State.Type.Normal) {
									RoomStateNormal roomStateNormal = this.data.state.v as RoomStateNormal;
									if (roomStateNormal.state.v.getType () == RoomStateNormal.State.Type.Normal) {
										this.data.users.remove (roomUser);
									} else {
										Debug.LogError ("freeze not remove admin: " + this);
									}
								}
							}
							break;
						default:
							Debug.LogError ("unknown role: " + roomUser.role.v + "; " + this);
							break;
						}
					}
					// make left other
					{
						// Check offline
						if (roomUser.state.v == RoomUser.State.NORMAL) {
							bool isOffline = false;
							{
								Human human = roomUser.inform.v;
								if (human != null) {
									if (human.state.v != null && human.state.v.state.v == UserState.State.Offline) {
										isOffline = true;
									}
								} else {
									Debug.LogError ("human null: " + this);
								}
							}
							if (isOffline) {
								roomUser.state.v = RoomUser.State.LEFT;
								// Add disconnect message
								{
									// Find RoomTopic
									RoomTopic roomTopic = null;
									{
										ChatRoom chatRoom = this.data.chatRoom.v;
										if (chatRoom != null) {
											roomTopic = chatRoom.topic.v as RoomTopic;
										} else {
											Debug.LogError ("chatRoom null: " + this);
										}
									}
									if (roomTopic != null) {
										roomTopic.addRoomUserState (roomUser.inform.v.playerId.v, ChatRoomUserStateContent.Action.Disconnect);
									} else {
										Debug.LogError ("roomTopic null: " + this);
									}
								}
							}
						}
						// Check is banned
						if (roomUser.state.v == RoomUser.State.NORMAL) {
							bool isBan = false;
							{
								Human human = roomUser.inform.v;
								if (human != null) {
									if (human.ban.v != null && human.ban.v.getType () == Ban.Type.Ban) {
										isBan = true;
									}
								} else {
									Debug.LogError ("human null: " + this);
								}
							}
							if (isBan) {
								roomUser.state.v = RoomUser.State.KICK;
								// Add disconnect message
								{
									// Find RoomTopic
									RoomTopic roomTopic = null;
									{
										ChatRoom chatRoom = this.data.chatRoom.v;
										if (chatRoom != null) {
											roomTopic = chatRoom.topic.v as RoomTopic;
										} else {
											Debug.LogError ("chatRoom null: " + this);
										}
									}
									if (roomTopic != null) {
										roomTopic.addRoomUserState (roomUser.inform.v.playerId.v, ChatRoomUserStateContent.Action.Ban);
									} else {
										Debug.LogError ("roomTopic null: " + this);
									}
								}
							}
						}
					}
				}
				// Check have active user
				if (!this.data.isHaveActiveUser ()) {
					// find can end?
					bool canEnd = false;
					{
						if (this.data.state.v is RoomStateNormal) {
							RoomStateNormal roomStateNormal = this.data.state.v as RoomStateNormal;
							if (roomStateNormal.state.v is RoomStateNormalNormal) {
								canEnd = true;
							} else {
								Debug.LogError ("you are freezing, cannot end: " + this);
							}
						}
					}
					// Process
					if (canEnd) {
						RoomStateEnd roomStateEnd = new RoomStateEnd ();
						{
							roomStateEnd.uid = this.data.state.makeId ();
						}
						this.data.state.v = roomStateEnd;
					}
				} 
			} else {
				Debug.LogError ("data null: " + this);
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
			// Chil
			{
				room.state.allAddCallBack (this);
				room.users.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// Child
			if (data is Room.State) {
				dirty = true;
				return;
			}
			// RoomUser
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
				// Child
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
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Room) {
			Room room = data as Room;
			// Child
			{
				room.state.allRemoveCallBack (this);
				room.users.allRemoveCallBack (this);
			}
			// set data null
			this.setDataNull (room);
			return;
		}
		// Child
		{
			if (data is Room.State) {
				return;
			}
			// RoomUser
			{
				if (data is RoomUser) {
					RoomUser roomUser = data as RoomUser;
					// Child
					{
						roomUser.inform.allRemoveCallBack (this);
					}
					return;
				}
				// Child
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
				dirty = true;
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
			if (wrapProperty.p is Room.State) {
				Room.State state = wrapProperty.p as Room.State;
				switch (state.getType ()) {
				case Room.State.Type.Normal:
					{
						switch ((RoomStateNormal.Property)wrapProperty.n) {
						case RoomStateNormal.Property.state:
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					}
					break;
				case Room.State.Type.End:
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType () + "; " + this);
					break;
				}
				return;
			}
			// RoomUser
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
				// Child
				{
					if (wrapProperty.p is Human) {
						switch ((Human.Property)wrapProperty.n) {
						case Human.Property.playerId:
							break;
						case Human.Property.account:
							break;
						case Human.Property.state:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
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
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					{
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
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
					}
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}