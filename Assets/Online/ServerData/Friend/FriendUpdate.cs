using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendUpdate : UpdateBehavior<Friend>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {

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
		if (data is Friend) {
			Friend friend = data as Friend;
			// Update
			{
				UpdateUtils.makeUpdate<FriendStateUpdate, Friend> (friend, this.transform);
			}
			// Child
			{
				friend.user1.allAddCallBack (this);
				friend.user2.allAddCallBack (this);
				friend.chatRoom.allAddCallBack (this);
			}
			return;
		}
		if (data is Human) {
			Human human = data as Human;
			{
				UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
			}
			return;
		}
		if (data is ChatRoom) {
			ChatRoom chatRoom = data as ChatRoom;
			{
				UpdateUtils.makeUpdate<ChatRoomUpdate, ChatRoom> (chatRoom, this.transform);
			}
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Friend) {
			Friend friend = data as Friend;
			// Update
			{
				friend.removeCallBackAndDestroy (typeof(FriendStateUpdate));
			}
			// Child
			{
				friend.user1.allRemoveCallBack (this);
				friend.user2.allRemoveCallBack (this);
				friend.chatRoom.allRemoveCallBack (this);
			}
			// set data null
			this.setDataNull (friend);
			return;
		}
		if (data is Human) {
			Human human = data as Human;
			{
				human.removeCallBackAndDestroy (typeof(HumanUpdate));
			}
			return;
		}
		if (data is ChatRoom) {
			ChatRoom chatRoom = data as ChatRoom;
			{
				chatRoom.removeCallBackAndDestroy (typeof(ChatRoomUpdate));
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
		if (wrapProperty.p is Friend) {
			switch ((Friend.Property)wrapProperty.n) {
			case Friend.Property.state:
				break;
			case Friend.Property.user1:
				ValueChangeUtils.replaceCallBack (this, syncs);
				break;
			case Friend.Property.user2:
				ValueChangeUtils.replaceCallBack (this, syncs);
				break;
			case Friend.Property.time:
				break;
			case Friend.Property.chatRoom:
				ValueChangeUtils.replaceCallBack (this, syncs);
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