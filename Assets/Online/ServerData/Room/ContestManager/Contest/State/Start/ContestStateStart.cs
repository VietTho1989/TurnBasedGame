using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestStateStart : ContestState
	{

		#region Constructor

		public enum Property
		{

		}

		public ContestStateStart() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Start;
		}

	}
}