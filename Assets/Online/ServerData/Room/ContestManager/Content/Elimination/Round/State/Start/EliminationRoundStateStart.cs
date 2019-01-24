using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationRoundStateStart : EliminationRound.State
	{

		#region Constructor

		public enum Property
		{

		}

		public EliminationRoundStateStart() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Start;
		}

	}
}