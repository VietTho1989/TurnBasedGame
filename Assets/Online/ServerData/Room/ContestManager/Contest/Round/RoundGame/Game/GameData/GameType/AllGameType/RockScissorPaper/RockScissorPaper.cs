using UnityEngine;
using System.Collections;

public class RockScissorPaper : Data
{
	#region Player

	public class Player : Data
	{
		public enum State
		{
			NONE,
			ROCK,
			SCISSOR,
			PAPER
		}
		public VP<State> state;

		public enum Result
		{
			NONE,
			WIN,
			LOSE,
			DRAW
		}
		public VP<Result> result;

		#region Constructor

		public enum Property
		{
			state,
			result
		}

		public Player() : base()
		{
			this.state = new VP<State>(this, (byte)Property.state, State.NONE);
			this.result = new VP<Result>(this, (byte)Property.result, Result.NONE);
		}

		#endregion

	}

	public LP<Player> players;

	#endregion

	#region Constructor

	public enum Property
	{
		players
	}

	public RockScissorPaper() : base()
	{
		this.players = new LP<Player> (this, (byte)Property.players);
	}

	#endregion

}