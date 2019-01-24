using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RequestNewRoundRobinStateAccept : RequestNewRoundRobin.State
	{

		#region Constructor

		public enum Property
		{

		}

		public RequestNewRoundRobinStateAccept() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Accept;
		}

	}
}