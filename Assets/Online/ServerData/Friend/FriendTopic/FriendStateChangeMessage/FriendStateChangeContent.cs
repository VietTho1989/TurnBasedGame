using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendStateChangeContent : ChatMessage.Content
{

	public VP<uint> userId;

	#region Action

	public enum Action
	{
		Request,
		Accept,
		Refuse,
		Cancel,
		UnFriend,
		Ban,
		UnBan
	}

	public VP<Action> action;

	#endregion

	#region Constructor

	public enum Property
	{
		userId,
		action
	}

	public FriendStateChangeContent() : base()
	{
		this.userId = new VP<uint> (this, (byte)Property.userId, 0);
		this.action = new VP<Action> (this, (byte)Property.action, Action.Request);
	}

	#endregion

	public override Type getType ()
	{
		return Type.FriendStateChange;
	}

}