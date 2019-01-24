using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationRoundStateLoad : EliminationRound.State
	{

		#region Constructor

		public enum Property
		{

		}

		public EliminationRoundStateLoad() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Load;
		}

	}
}