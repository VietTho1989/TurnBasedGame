using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class BracketContest : Data
	{

		public VP<bool> isActive;

		public VP<int> index;

		public LP<int> teamIndexs;

		public VP<Contest> contest;

		#region Constructor

		public enum Property
		{
			isActive,
			index,
			teamIndexs,
			contest
		}

		public BracketContest() : base()
		{
			this.isActive = new VP<bool> (this, (byte)Property.isActive, true);
			this.index = new VP<int> (this, (byte)Property.index, 0);
			this.teamIndexs = new LP<int> (this, (byte)Property.teamIndexs);
			this.contest = new VP<Contest> (this, (byte)Property.contest, new Contest ());
		}

		#endregion

		public float getResult(int teamIndex)
		{
			if (this.teamIndexs.vs.Contains (teamIndex)) {
				if (this.contest.v.state.v.getType () == ContestState.Type.End) {
					ContestStateEnd contestStateEnd = this.contest.v.state.v as ContestStateEnd;
					int contestTeamIndex = this.teamIndexs.vs.IndexOf (teamIndex);
					return contestStateEnd.getTeamResult (contestTeamIndex);
				}
			} else {
				// Debug.LogError ("teamIndex not in roundGames: " + teamIndex + "; " + this);
			}
			return 0;
		}

	}
}