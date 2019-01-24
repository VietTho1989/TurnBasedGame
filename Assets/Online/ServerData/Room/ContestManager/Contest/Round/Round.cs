using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class Round : Data
	{

		#region state

		public VP<RoundState> state;

		public VP<CalculateScore> calculateScore;

		#endregion

		public VP<int> index;

		public LP<RoundGame> roundGames;

		#region Constructor

		public enum Property
		{
			state,
			calculateScore,
			index,
			roundGames
		}

		public Round() : base()
		{
			this.state = new VP<RoundState> (this, (byte)Property.state, new RoundStateLoad ());
			this.calculateScore = new VP<CalculateScore> (this, (byte)Property.calculateScore, new CalculateScoreSum ());
			this.index = new VP<int> (this, (byte)Property.index, 0);
			this.roundGames = new LP<RoundGame> (this, (byte)Property.roundGames);
		}

		#endregion

	}
}