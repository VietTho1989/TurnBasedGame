using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientInputSend : ClientInput.Sub
{

	#region State

	public enum State
	{
		Send,
		Sending
	}

	public VP<State> state;

	#endregion

	public VP<GameMove> gameMove;

	public VP<float> clientTimeSend;

	#region Constructor

	public enum Property
	{
		state,
		gameMove,
		clientTimeSend
	}

	public ClientInputSend () : base()
	{
		this.state = new VP<State> (this, (byte)Property.state, State.Send);
		this.gameMove = new VP<GameMove> (this, (byte)Property.gameMove, new NonMove ());
		this.clientTimeSend = new VP<float> (this, (byte)Property.clientTimeSend, 0);
	}

	#endregion

	public override Type getType ()
	{
		return Type.Send;
	}

}