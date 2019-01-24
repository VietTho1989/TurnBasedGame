using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestStateLoad : ContestState
	{

		#region Constructor

		public enum Property
		{

		}

		public ContestStateLoad() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Load;
		}

	}
}