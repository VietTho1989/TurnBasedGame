using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
	public class SwapRequest : Data
	{

		#region State

		public abstract class State : Data
		{

			public enum Type
			{
				Ask,
				Accept,
				Cancel
			}

			public abstract Type getType ();

		}

		public VP<State> state;

		#endregion

		public VP<int> teamIndex;

		public VP<int> playerIndex;

		public VP<GamePlayer.Inform> inform;

		#region Constructor

		public enum Property
		{
			state,
			teamIndex,
			playerIndex,
			inform
		}

		public SwapRequest() : base()
		{
			this.state = new VP<State>(this, (byte)Property.state, new SwapRequestStateAsk());
			this.teamIndex = new VP<int> (this, (byte)Property.teamIndex, 0);
			this.playerIndex = new VP<int> (this, (byte)Property.playerIndex, 0);
			this.inform = new VP<GamePlayer.Inform> (this, (byte)Property.inform, new EmptyInform ());
		}

		#endregion

	}
}