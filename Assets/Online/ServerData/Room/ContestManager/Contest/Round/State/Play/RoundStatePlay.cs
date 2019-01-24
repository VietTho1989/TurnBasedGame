using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundStatePlay : RoundState
	{

		#region Constructor

		public enum Property
		{

		}

		public RoundStatePlay() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Play;
		}

	}
}