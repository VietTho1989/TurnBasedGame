using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserTopic : Topic
{

	#region Constructor

	public enum Property
	{

	}

	public UserTopic() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.User;
	}

	public override bool isCanSendNormalMessage (uint userId)
	{
        return Server.getProfileUserId(this) == userId;
	}

	#region Message

	public void addUserAction(uint userId, UserActionMessage.Action action)
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
					UserActionMessage userActionMessage = new UserActionMessage ();
					{
						userActionMessage.uid = chatMessage.content.makeId ();
						userActionMessage.userId.v = userId;
						userActionMessage.action.v = action;
					}
					chatMessage.content.v = userActionMessage;
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