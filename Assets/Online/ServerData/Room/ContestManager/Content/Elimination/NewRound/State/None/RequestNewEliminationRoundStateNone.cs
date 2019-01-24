using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class RequestNewEliminationRoundStateNone : RequestNewEliminationRound.State
	{

		#region Constructor

		public enum Property
		{

		}

		public RequestNewEliminationRoundStateNone() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.None;
		}

	}
}