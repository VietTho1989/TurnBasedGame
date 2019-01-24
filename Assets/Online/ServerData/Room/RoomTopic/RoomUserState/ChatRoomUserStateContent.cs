using UnityEngine;
using System.Collections;

public class ChatRoomUserStateContent : ChatMessage.Content
{

	public VP<uint> userId;

	#region Action

	public enum Action
	{
		Create,
		Join,
		Left,
		Disconnect,
		Kick,
		UnKick,
		Ban
	}

	public VP<Action> action;

	#endregion

	#region Constructor

	public enum Property
	{
		userId,
		action
	}

	public ChatRoomUserStateContent() : base()
	{
		this.userId = new VP<uint> (this, (byte)Property.userId, 0);
		this.action = new VP<Action> (this, (byte)Property.action, Action.Create);
	}

	#endregion

	public override Type getType ()
	{
		return Type.RoomUserState;
	}

}