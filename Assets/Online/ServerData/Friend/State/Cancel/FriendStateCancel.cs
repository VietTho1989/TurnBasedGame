using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendStateCancel : Friend.State
{

	public enum State
	{
		Start,
		End
	}

	public VP<State> state;

	#region Constructor

	public enum Property
	{
		state
	}

	public FriendStateCancel() : base()
	{
		this.state = new VP<State> (this, (byte)Property.state, State.Start);
	}

	#endregion

	public override Type getType ()
	{
		return Type.Cancel;
	}

}