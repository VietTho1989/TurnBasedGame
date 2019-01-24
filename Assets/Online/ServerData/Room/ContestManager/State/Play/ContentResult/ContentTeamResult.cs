using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContentTeamResult : Data
	{

		public VP<bool> isEnd;

		#region teamResults

		public LP<TeamResult> teamResults;

		public float getResult(int teamIndex)
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
			isEnd,
			teamResults
		}

		public ContentTeamResult() : base()
		{
			this.isEnd = new VP<bool> (this, (byte)Property.isEnd, false);
			this.teamResults = new LP<TeamResult> (this, (byte)Property.teamResults);
		}

		#endregion

	}
}