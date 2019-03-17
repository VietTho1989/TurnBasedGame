using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class TeamResult : Data
	{

		public VP<int> teamIndex;

		public VP<float> score;

		#region Constructor

		public enum Property
		{
			teamIndex,
			score
		}

		public TeamResult() : base()
		{
			this.teamIndex = new VP<int>(this, (byte)Property.teamIndex, 0);
			this.score = new VP<float>(this, (byte)Property.score, 0);
		}

		#endregion

	}
}