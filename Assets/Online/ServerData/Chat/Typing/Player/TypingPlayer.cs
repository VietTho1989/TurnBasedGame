using UnityEngine;
using System.Collections;

public class TypingPlayer : Data
{

	public VP<uint> playerId;

	public enum State
	{
		Start,
		Normal,
		NextReceive
	}
	public VP<State> state;

	#region Constructor

	public enum Property
	{
		playerId,
		state
	}

	public TypingPlayer() : base()
	{
		this.playerId = new VP<uint> (this, (byte)Property.playerId, 0);
		this.state = new VP<State> (this, (byte)Property.state, State.Start);
	}

	#endregion

}