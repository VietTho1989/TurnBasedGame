using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class Bracket : Data
	{

		public VP<bool> isActive;

		#region State

		public abstract class State : Data
		{

			public enum Type
			{
				Play,
				End
			}

			public abstract Type getType();

		}

		public VP<State> state;

		#endregion

		public VP<int> index;

		#region eliminationContest

		public LP<BracketContest> bracketContests;

		#endregion

		public LP<int> byeTeamIndexs;

		#region Constructor

		public enum Property
		{
			isActive,
			state,
			index,
			bracketContests,
			byeTeamIndexs
		}

		public Bracket() : base()
		{
			this.isActive = new VP<bool> (this, (byte)Property.isActive, true);
			this.state = new VP<State> (this, (byte)Property.state, new BracketStatePlay ());
			this.index = new VP<int> (this, (byte)Property.index, 0);
			this.bracketContests = new LP<BracketContest> (this, (byte)Property.bracketContests);
			this.byeTeamIndexs = new LP<int> (this, (byte)Property.byeTeamIndexs);
		}

		#endregion

	}
}