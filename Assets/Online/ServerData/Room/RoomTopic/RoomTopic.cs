using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomTopic : Topic
{

	#region Constructor

	public enum Property
	{

	}

	public RoomTopic() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Room;
	}

	public override bool isCanSendNormalMessage (uint userId)
	{
		Room room = this.findDataInParent<Room> ();
		if (room != null) {
			RoomUser roomUser = room.findUser (userId);
			if (roomUser != null) {
				return roomUser.isInsideRoom ();
			} else {
				Debug.LogError ("roomUser null: " + this);
				return false;
			}
		} else {
			Debug.LogError ("room null: " + this);
			return false;
		}
	}

	#region RoomUserState

	public void addRoomUserState(uint userId, ChatRoomUserStateContent.Action action)
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
					ChatRoomUserStateContent content = new ChatRoomUserStateContent ();
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