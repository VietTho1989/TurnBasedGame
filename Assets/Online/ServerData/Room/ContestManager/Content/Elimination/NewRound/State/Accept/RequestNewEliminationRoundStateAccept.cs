using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class RequestNewEliminationRoundStateAccept : RequestNewEliminationRound.State
	{

		#region Constructor

		public enum Property
		{

		}

		public RequestNewEliminationRoundStateAccept() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Accept;
		}

	}
}