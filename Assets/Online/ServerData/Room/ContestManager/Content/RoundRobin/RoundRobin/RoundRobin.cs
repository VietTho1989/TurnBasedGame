using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobin : Data
	{

		#region State

		public abstract class State : Data
		{

			public enum Type
			{
				Load,
				Start,
				Play,
				End
			}

			public abstract Type getType();

		}

		public VP<State> state;

		#endregion

		public VP<int> index;

		public LP<RoundContest> roundContests;

		#region Constructor

		public enum Property
		{
			state,
			index,
			roundContests
		}

		public RoundRobin() : base()
		{
			this.state = new VP<State> (this, (byte)Property.state, new RoundRobinStateLoad ());
			this.index = new VP<int> (this, (byte)Property.index, 0);
			this.roundContests = new LP<RoundContest> (this, (byte)Property.roundContests);
		}

		#endregion

	}
}