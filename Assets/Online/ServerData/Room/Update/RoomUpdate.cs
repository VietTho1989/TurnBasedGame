using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class RoomUpdate : UpdateBehavior<Room>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// ContestManager
				{
					// Find
					bool needUpdate = false;
					{
						Room.State state = this.data.state.v;
						if (state != null) {
							switch (state.getType ()) {
							case Room.State.Type.Normal:
								{
									RoomStateNormal roomStateNormal = state as RoomStateNormal;
									if (roomStateNormal.state.v is RoomStateNormalNormal) {
										needUpdate = true;
									}
								}
								break;
							case Room.State.Type.End:
								break;
							default:
								Debug.LogError ("unknown type: " + state.getType () + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("state null: " + this);
						}
					}
					// Process
					if (needUpdate) {
						// contestManager
						foreach (ContestManager contestManager in this.data.contestManagers.vs) {
							UpdateUtils.makeUpdate<ContestManagerUpdate, ContestManager> (contestManager, this.transform);
							contestManager.removeCallBackAndDestroy (typeof(ContestManagerNotFreezeUpdate));
						}
						// requestNewContestManager
						{
							RequestNewContestManager requestNewContestManager = this.data.requestNewContestManager.v;
							if (requestNewContestManager != null) {
								UpdateUtils.makeUpdate<RequestNewContestManagerUpdate, RequestNewContestManager> (requestNewContestManager, this.transform);
							} else {
								Debug.LogError ("requestNewContestManager null: " + this);
							}
						}
						// MakeContestManager
						UpdateUtils.makeUpdate<MakeContestManagerUpdate, Room> (this.data, this.transform);
					} else {
						// contestManager
						foreach (ContestManager contestManager in this.data.contestManagers.vs) {
							contestManager.removeCallBackAndDestroy (typeof(ContestManagerUpdate));
							UpdateUtils.makeUpdate<ContestManagerNotFreezeUpdate, ContestManager> (contestManager, this.transform);
						}
						// requestNewContestManager
						{
							RequestNewContestManager requestNewContestManager = this.data.requestNewContestManager.v;
							if (requestNewContestManager != null) {
								requestNewContestManager.removeCallBackAndDestroy (typeof(RequestNewContestManagerUpdate));
							} else {
								Debug.LogError ("requestNewContestManager null: " + this);
							}
						}
						// MakeContestManager
						this.data.removeCallBackAndDestroy (typeof(MakeContestManagerUpdate));
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
			// Update
			{
				UpdateUtils.makeUpdate<RoomStateCheckActiveUserUpdate, Room> (room, this.transform);
				UpdateUtils.makeUpdate<RoomUserRoleAdminUpdate, Room>(room, this.transform);
			}
			// Child
			{
				room.roomInform.allAddCallBack (this);
				room.users.allAddCallBack (this);
				room.state.allAddCallBack (this);
				// contestManagers
				{
					room.requestNewContestManager.allAddCallBack (this);
					room.contestManagers.allAddCallBack (this);
				}
				room.chatRoom.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is RoomInform) {
				RoomInform roomInform = data as RoomInform;
				// Update
				{
					UpdateUtils.makeUpdate<RoomInformUpdate, RoomInform> (roomInform, this.transform);
				}
				dirty = true;
				return;
			}
			if (data is RoomUser) {
				RoomUser roomUser = data as RoomUser;
				// Update
				{
					UpdateUtils.makeUpdate<RoomUserUpdate, RoomUser> (roomUser, this.transform);
				}
				dirty = true;
				return;
			}
			if (data is Room.State) {
				Room.State state = data as Room.State;
				// Update
				{
					switch (state.getType ()) {
					case Room.State.Type.Normal:
						{
							RoomStateNormal roomStateNormal = state as RoomStateNormal;
							UpdateUtils.makeUpdate<RoomStateNormalUpdate, RoomStateNormal> (roomStateNormal, this.transform);
						}
						break;
					case Room.State.Type.End:
						{
							RoomStateEnd roomStateEnd = state as RoomStateEnd;
							UpdateUtils.makeUpdate<RoomStateEndUpdate, RoomStateEnd> (roomStateEnd, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + state.getType () + "; " + this);
						break;
					}
				}
				dirty = true;
				return;
			}
			// contestManager
			{
				if (data is RequestNewContestManager) {
					dirty = true;
					return;
				}
				if (data is ContestManager) {
					// ContestManager contestManager = data as ContestManager;
					// Update
					{
						
					}
					dirty = true;
					return;
				}
			}
			if (data is ChatRoom) {
				ChatRoom chatRoom = data as ChatRoom;
				// Update
				{
					UpdateUtils.makeUpdate<ChatRoomUpdate, ChatRoom> (chatRoom, this.transform);
				}
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Room) {
			Room room = data as Room;
			// Update
			{
				room.removeCallBackAndDestroy (typeof(RoomStateCheckActiveUserUpdate));
				room.removeCallBackAndDestroy(typeof(RoomUserRoleAdminUpdate));
				room.removeCallBackAndDestroy (typeof(MakeContestManagerUpdate));
			}
			// Child
			{
				room.roomInform.allRemoveCallBack (this);
				room.users.allRemoveCallBack (this);
				room.state.allRemoveCallBack (this);
				// contestManager
				{
					room.requestNewContestManager.allRemoveCallBack (this);
					room.contestManagers.allRemoveCallBack (this);
				}
				room.chatRoom.allRemoveCallBack (this);
			}
			// set data null
			this.setDataNull (room);
			return;
		}
		// Child
		{
			if (data is RoomInform) {
				RoomInform roomInform = data as RoomInform;
				// Update
				{
					roomInform.removeCallBackAndDestroy (typeof(RoomInformUpdate));
				}
				return;
			}
			if (data is RoomUser) {
				RoomUser roomUser = data as RoomUser;
				// Update
				{
					roomUser.removeCallBackAndDestroy (typeof(RoomUserUpdate));
				}
				return;
			}
			if (data is Room.State) {
				Room.State state = data as Room.State;
				// Update
				{
					switch (state.getType ()) {
					case Room.State.Type.Normal:
						{
							RoomStateNormal roomStateNormal = state as RoomStateNormal;
							roomStateNormal.removeCallBackAndDestroy (typeof(RoomStateNormalUpdate));
						}
						break;
					case Room.State.Type.End:
						{
							RoomStateEnd roomStateEnd = state as RoomStateEnd;
							roomStateEnd.removeCallBackAndDestroy (typeof(RoomStateEndUpdate));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + state.getType () + "; " + this);
						break;
					}
				}
				return;
			}
			// ContestManager
			{
				if (data is RequestNewContestManager) {
					RequestNewContestManager requestNewContestManager = data as RequestNewContestManager;
					// Update
					{
						requestNewContestManager.removeCallBackAndDestroy (typeof(RequestNewContestManagerUpdate));
					}
					return;
				}
				if (data is ContestManager) {
					ContestManager contestManager = data as ContestManager;
					// Update
					{
						contestManager.removeCallBackAndDestroy (typeof(ContestManagerNotFreezeUpdate));
						contestManager.removeCallBackAndDestroy (typeof(ContestManagerUpdate));
					}
					return;
				}
			}
			if (data is ChatRoom) {
				ChatRoom chatRoom = data as ChatRoom;
				// Update
				{
					chatRoom.removeCallBackAndDestroy (typeof(ChatRoomUpdate));
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
		if (wrapProperty.p is Room) {
			switch ((Room.Property)wrapProperty.n) {
			case Room.Property.roomInform:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Room.Property.name:
				break;
			case Room.Property.password:
				break;
			case Room.Property.users:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
				}
				break;
			case Room.Property.state:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Room.Property.requestNewContestManager:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Room.Property.contestManagers:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Room.Property.timeCreated:
				break;
			case Room.Property.chatRoom:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is RoomInform) {
				return;
			}
			if (wrapProperty.p is RoomUser) {
				return;
			}
			if (wrapProperty.p is Room.State) {
				if (wrapProperty.p is RoomStateNormal) {
					switch ((RoomStateNormal.Property)wrapProperty.n) {
					case RoomStateNormal.Property.state:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
				}
				return;
			}
			// contestManager
			{
				if (wrapProperty.p is RequestNewContestManager) {
					return;
				}
				if (wrapProperty.p is ContestManager) {
					return;
				}
			}
			if (wrapProperty.p is ChatRoom) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}