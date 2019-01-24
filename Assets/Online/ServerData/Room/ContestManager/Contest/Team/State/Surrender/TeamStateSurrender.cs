using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class TeamStateSurrender : TeamState
	{

		#region Constructor

		public enum Property
		{

		}

		public TeamStateSurrender() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Surrender;
		}

	}
}