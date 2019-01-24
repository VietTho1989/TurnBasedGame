using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundStateNone : RequestNewRound.State
	{

		#region Constructor

		public enum Property
		{

		}

		public RequestNewRoundStateNone() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.None;
		}

	}
}