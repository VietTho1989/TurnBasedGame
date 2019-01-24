using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestStateEnd : ContestState
	{
		
		#region getTeamResult

		public LP<TeamResult> teamResults;

		public float getTeamResult(int teamIndex)
		{
			foreach (TeamResult teamResult in this.teamResults.vs) {
				if (teamResult.teamIndex.v == teamIndex) {
					return teamResult.score.v;
				}
			}
			return 0;
		}

		#endregion

		#region Constructor

		public enum Property
		{
			teamResults
		}

		public ContestStateEnd() : base()
		{
			this.teamResults = new LP<TeamResult> (this, (byte)Property.teamResults);
		}

		#endregion

		public override Type getType ()
		{
			return Type.End;
		}

	}
}