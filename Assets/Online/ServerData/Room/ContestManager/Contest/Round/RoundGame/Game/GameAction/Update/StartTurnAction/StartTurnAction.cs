using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTurnAction : GameAction
{
	
	public enum State
	{
		Start,
		Process,
		End
	}
	public VP<State> state;

	#region Constructor

	public enum Property
	{
		state
	}

	public StartTurnAction() : base()
	{
		this.state = new VP<State> (this, (byte)Property.state, State.Start);
	}

	#endregion

	public override Type getType ()
	{
		return Type.StartTurn;
	}

}