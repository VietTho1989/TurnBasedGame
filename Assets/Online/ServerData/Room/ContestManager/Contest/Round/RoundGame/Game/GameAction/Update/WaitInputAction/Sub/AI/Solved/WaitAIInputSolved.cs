using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaitAIInputSolved : WaitAIInput.Sub
{

	#region State

	public enum State
	{
		Search,
		Searching
	}

	public VP<State> state;

	#endregion

	#region Constructor

	public enum Property
	{
		state
	}

	public WaitAIInputSolved() : base()
	{
		this.state = new VP<State> (this, (byte)Property.state, State.Search);
	}

	#endregion

	public override Type getType ()
	{
		return Type.Solved;
	}

}