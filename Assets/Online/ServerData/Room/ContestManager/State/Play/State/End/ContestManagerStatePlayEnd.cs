using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestManagerStatePlayEnd : ContestManagerStatePlay.State
	{

		public LP<TeamResult> teamResults;

		#region Constructor

		public enum Property
		{
			teamResults
		}

		public ContestManagerStatePlayEnd() : base()
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