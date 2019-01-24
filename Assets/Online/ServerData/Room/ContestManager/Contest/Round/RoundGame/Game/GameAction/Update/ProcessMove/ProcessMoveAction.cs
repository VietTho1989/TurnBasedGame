using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProcessMoveAction : GameAction
{

	#region state
	
	public enum State
	{
		Process,
		Processing,
		WaitEnd,
		End
	}

	public VP<State> state;

	#endregion

	public VP<InputData> inputData;

	#region Constructor

	public enum Property
	{
		state,
		inputData
	}

	public ProcessMoveAction() : base()
	{
		this.state = new VP<State> (this, (byte)Property.state, State.Process);
		this.inputData = new VP<InputData> (this, (byte)Property.inputData, new InputData ());
	}

	#endregion

	public override Type getType ()
	{
		return Type.ProcessMove;
	}

}