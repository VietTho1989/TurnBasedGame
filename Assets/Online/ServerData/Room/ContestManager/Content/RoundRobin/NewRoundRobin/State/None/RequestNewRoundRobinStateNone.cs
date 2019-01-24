using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RequestNewRoundRobinStateNone : RequestNewRoundRobin.State
	{

		#region Constructor

		public enum Property
		{

		}

		public RequestNewRoundRobinStateNone() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.None;
		}

	}
}