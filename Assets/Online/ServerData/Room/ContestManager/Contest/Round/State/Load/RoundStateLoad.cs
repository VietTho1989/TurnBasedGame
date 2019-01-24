using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundStateLoad : RoundState
	{

		#region Constructor

		public enum Property
		{

		}

		public RoundStateLoad() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Load;
		}

	}
}