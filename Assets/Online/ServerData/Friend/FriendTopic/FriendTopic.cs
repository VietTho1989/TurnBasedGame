using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendTopic : Topic
{

	#region Constructor

	public enum Property
	{

	}

	public FriendTopic() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Friend;
	}

	public override bool isCanSendNormalMessage (uint userId)
	{
		Friend friend = this.findDataInParent<Friend> ();
		if (friend != null) {
			if (friend.state.v.getType () == Friend.State.Type.Accept) {
				return friend.user1.v.playerId.v == userId || friend.user2.v.playerId.v == userId;
			} else {
				return false;
			}
		} else {
			Debug.LogError ("friend null: " + this);
			return false;
		}
	}

	#region FriendStateChange

	public void addFriendState(uint userId, FriendStateChangeContent.Action action)
	{
		ChatRoom chatRoom = this.findDataInParent<ChatRoom> ();
		if (chatRoom != null) {
			// Add player
			chatRoom.addPlayer (userId);
			// Make new message
			ChatMessage chatMessage = new ChatMessage ();
			{
				chatMessage.uid = chatRoom.messages.makeId ();
				// state
				chatMessage.state.v = ChatMessage.State.Normal;
				// time
				chatMessage.time.v = Global.getRealTimeInMiliSeconds ();
				// content
				{
					FriendStateChangeContent content = new FriendStateChangeContent ();
					{
						content.uid = chatMessage.content.makeId ();
						content.userId.v = userId;
						content.action.v = action;
					}
					chatMessage.content.v = content;
				}
			}
			// Add
			chatRoom.messages.add (chatMessage);
		} else {
			Debug.LogError ("chatRoom null: " + this);
		}
	}

	#endregion

}