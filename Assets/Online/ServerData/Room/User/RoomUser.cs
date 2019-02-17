using UnityEngine;
using System.Collections;

public class RoomUser : Data
{

	public enum Role
	{
		ADMIN,
		NORMAL
	}

	public VP<Role> role;

	#region Inform

	public VP<Human> inform;

	public bool isCorrectUser(User user){
		return inform.v.playerId.v == user.uid;
	}

	#endregion

	#region State

	public enum State
	{
		NORMAL,
		LEFT,
		KICK
	}

	public VP<State> state;

	public bool isInsideRoom()
	{
		switch (this.state.v) {
		case State.NORMAL:
			return true;
		case State.LEFT:
			return false;
		case State.KICK:
			return false;
		default:
			Debug.LogError ("unknown state: " + this.state.v);
			break;
		}
		return true;
	}

	#endregion

	#region Constructor

	public enum Property
	{
		role,
		inform,
		state
	}

	public RoomUser() : base()
	{
		this.role = new VP<Role> (this, (byte)Property.role, Role.NORMAL);
		this.inform = new VP<Human> (this, (byte)Property.inform, new Human ());
		this.state = new VP<State> (this, (byte)Property.state, State.NORMAL);
	}

	public override string ToString ()
	{
		return string.Format ("[RoomUser: {0}]", this.inform.v);
	}

	#endregion

	#region static

	public static RoomUser getYourRoomUser(Data data){
		Server server = data.findDataInParent<Server> ();
		if (server != null) {
			// Check player in room
			Room room = data.findDataInParent<Room>();
			if (room != null) {
				for (int i = 0; i < room.users.vs.Count; i++) {
					RoomUser roomUser = room.users.vs [i];
					if (roomUser.inform.v.playerId.v == server.profileId.v) {
						return roomUser;
					}
				}
			} else {
				// Debug.LogError ("room null");
			}
		} else {
			// Debug.LogError ("server null");
		}
		return null;
	}

	#endregion

	#region Operation

	public void requestLeaveRoom()
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.leaveRoom ();
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is RoomUserIdentity) {
						RoomUserIdentity roomUserIdentity = dataIdentity as RoomUserIdentity;
						roomUserIdentity.requestLeaveRoom ();
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				} else {
					Debug.LogError ("cannot find dataIdentity");
				}
			}
		} else {
			Debug.LogError ("You cannot request");
		}
	}

	public void leaveRoom()
	{
		// Debug.Log ("leave room");
		if (this.isInsideRoom ()) {
			this.state.v = RoomUser.State.LEFT;
			// Add left message
			{
				// Find RoomTopic
				RoomTopic roomTopic = null;
				{
					Room room = this.findDataInParent<Room> ();
					if (room != null) {
						ChatRoom chatRoom = room.chatRoom.v;
						if (chatRoom != null) {
							roomTopic = chatRoom.topic.v as RoomTopic;
						} else {
							Debug.LogError ("chatRoom null: " + this);
						}
					} else {
						Debug.LogError ("room null: " + this);
					}
				}
				if (roomTopic != null) {
					roomTopic.addRoomUserState (this.inform.v.playerId.v, ChatRoomUserStateContent.Action.Left);
				} else {
					Debug.LogError ("roomTopic null: " + this);
				}
			}
		} else {
			Debug.LogError ("not inside room: " + this);
		}
	}

	#endregion

	#region Kick

	public bool isCanKick(uint adminId)
	{
		if (this.state.v == State.NORMAL) {
			// the same person?
			if (this.inform.v.playerId.v == adminId) {
				Debug.Log ("the same id, cannot kick: " + adminId + "; " + this);
				return false;
			}
			// role
			if (this.role.v != Role.NORMAL) {
				Debug.LogError ("isAdmin, cannot kick: " + this);
				return false;
			}
			// check is admin
			{
				bool isAdmin = false;
				{
					RoomUser admin = Room.findAdmin (this);
					if (admin != null) {
						if (admin.inform.v.playerId.v == adminId) {
							isAdmin = true;
						}
					} else {
						Debug.LogError ("admin null: " + this);
					}
				}
				if (!isAdmin) {
					Debug.LogError ("not admin, cannot kick");
					return false;
				}
			}
			return true;
		} else {
			Debug.LogError ("not correct state: " + this.state.v + "; " + this);
			return false;
		}
	}

	public void requestKick(uint adminId)
	{
		Debug.LogError ("requestKick: " + adminId + "; " + this);
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.kick (adminId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is RoomUserIdentity) {
						RoomUserIdentity roomUserIdentity = dataIdentity as RoomUserIdentity;
						roomUserIdentity.requestKick (adminId);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				} else {
					Debug.LogError ("cannot find dataIdentity");
				}
			}
		} else {
			Debug.LogError ("You cannot request");
		}
	}

	public void kick(uint adminId)
	{
		if (isCanKick (adminId)) {
			this.state.v = State.KICK;
			// Add kick message
			{
				// Find RoomTopic
				RoomTopic roomTopic = null;
				{
					Room room = this.findDataInParent<Room> ();
					if (room != null) {
						ChatRoom chatRoom = room.chatRoom.v;
						if (chatRoom != null) {
							roomTopic = chatRoom.topic.v as RoomTopic;
						} else {
							Debug.LogError ("chatRoom null: " + this);
						}
					} else {
						Debug.LogError ("room null: " + this);
					}
				}
				if (roomTopic != null) {
					roomTopic.addRoomUserState (this.inform.v.playerId.v, ChatRoomUserStateContent.Action.Kick);
				} else {
					Debug.LogError ("roomTopic null: " + this);
				}
			}
		} else {
			Debug.LogError ("Cannot kick: " + this + "; " + adminId);
		}
	}

	#endregion

	#region UnKick

	public bool isCanUnKick(uint adminId)
	{
		if (this.state.v == State.KICK) {
			// the same person?
			if (this.inform.v.playerId.v == adminId) {
				Debug.LogError ("the same id, cannot kick: " + adminId + "; " + this);
				return false;
			}
			// check is admin
			{
				bool isAdmin = false;
				{
					RoomUser admin = Room.findAdmin (this);
					if (admin != null) {
						if (admin.inform.v.playerId.v == adminId) {
							isAdmin = true;
						}
					} else {
						Debug.LogError ("admin null: " + this);
					}
				}
				if (!isAdmin) {
					Debug.LogError ("not admin, cannot kick");
					return false;
				}
			}
			return true;
		} else {
			Debug.LogError ("not correct state: " + this.state.v + "; " + this);
			return false;
		}
	}


	public void requestUnKick(uint adminId)
	{
		Debug.LogError ("requestUnKick: " + adminId + "; " + this);
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.unKick (adminId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is RoomUserIdentity) {
						RoomUserIdentity roomUserIdentity = dataIdentity as RoomUserIdentity;
						roomUserIdentity.requestUnKick (adminId);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				} else {
					Debug.LogError ("cannot find dataIdentity");
				}
			}
		} else {
			Debug.LogError ("You cannot request");
		}
	}

	public void unKick(uint adminId)
	{
		if (isCanUnKick (adminId)) {
			this.state.v = State.LEFT;
			// Add left message
			{
				// Find RoomTopic
				RoomTopic roomTopic = null;
				{
					Room room = this.findDataInParent<Room> ();
					if (room != null) {
						ChatRoom chatRoom = room.chatRoom.v;
						if (chatRoom != null) {
							roomTopic = chatRoom.topic.v as RoomTopic;
						} else {
							Debug.LogError ("chatRoom null: " + this);
						}
					} else {
						Debug.LogError ("room null: " + this);
					}
				}
				if (roomTopic != null) {
					roomTopic.addRoomUserState (this.inform.v.playerId.v, ChatRoomUserStateContent.Action.UnKick);
				} else {
					Debug.LogError ("roomTopic null: " + this);
				}
			}
		} else {
			Debug.LogError ("Cannot unKick: " + this + "; " + adminId);
		}
	}

	#endregion

}