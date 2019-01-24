using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserActionMessage : ChatMessage.Content
{

	public VP<uint> userId;

	#region Action

	public enum Action
	{
		Register,
		Login,
		Logout,
		Disconnect,
		Banned,
		UnBanned
	}

	public VP<Action> action;

	#endregion

	#region Constructor

	public enum Property
	{
		userId,
		action
	}

	public UserActionMessage() : base()
	{
		this.userId = new VP<uint> (this, (byte)Property.userId, 0);
		this.action = new VP<Action> (this, (byte)Property.action, Action.Register);
	}

	#endregion

	public override Type getType ()
	{
		return Type.UserAction;
	}

}