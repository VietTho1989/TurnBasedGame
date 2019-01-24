using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobinStateLoad : RoundRobin.State
	{

		#region Constructor

		public enum Property
		{

		}

		public RoundRobinStateLoad() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Load;
		}

	}
}