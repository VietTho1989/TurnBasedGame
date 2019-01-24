using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundStateStart : RoundState
	{

		#region Constructor

		public enum Property
		{

		}

		public RoundStateStart() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Start;
		}

	}
}