using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationRoundStateEnd : EliminationRound.State
	{

		#region Constructor

		public enum Property
		{

		}

		public EliminationRoundStateEnd() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.End;
		}

	}
}