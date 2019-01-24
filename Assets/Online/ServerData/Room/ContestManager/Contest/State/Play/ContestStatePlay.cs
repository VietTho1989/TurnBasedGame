using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestStatePlay : ContestState
	{

		#region Constructor

		public enum Property
		{

		}

		public ContestStatePlay() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Play;
		}

	}
}