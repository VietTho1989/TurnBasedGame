using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class TeamStateNormal : TeamState
	{

		#region Constructor

		public enum Property
		{

		}

		public TeamStateNormal() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Normal;
		}

	}
}