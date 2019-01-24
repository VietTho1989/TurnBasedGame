using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateSurrender : GamePlayer.State
{

	#region State

	public abstract class State : Data
	{

		public enum Type
		{
			None,
			Ask
		}

		public abstract Type getType ();

	}

	public VP<State> state;

	#endregion

	#region Constructor

	public enum Property
	{
		state
	}

	public GamePlayerStateSurrender() : base()
	{
		this.state = new VP<State> (this, (byte)Property.state, new GamePlayerStateSurrenderNone ());
	}

	#endregion

	public override Type getType ()
	{
		return Type.Surrender;
	}

}