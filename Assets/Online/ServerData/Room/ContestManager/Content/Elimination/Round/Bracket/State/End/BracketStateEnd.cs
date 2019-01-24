using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class BracketStateEnd : Bracket.State
	{

		public LP<int> winTeamIndexs;

		public LP<int> loseTeamIndexs;

		#region Constructor

		public enum Property
		{
			winTeamIndexs,
			loseTeamIndexs
		}

		public BracketStateEnd() : base()
		{
			this.winTeamIndexs = new LP<int> (this, (byte)Property.winTeamIndexs);
			this.loseTeamIndexs = new LP<int> (this, (byte)Property.loseTeamIndexs);
		}

		#endregion

		public override Type getType ()
		{
			return Type.End;
		}

	}
}