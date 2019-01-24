using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobinStatePlay : RoundRobin.State
	{

		#region Constructor

		public enum Property
		{

		}

		public RoundRobinStatePlay() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Play;
		}

	}
}