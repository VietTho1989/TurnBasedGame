using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobinStateStart : RoundRobin.State
	{

		#region Constructor

		public enum Property
		{

		}

		public RoundRobinStateStart() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Start;
		}

	}
}