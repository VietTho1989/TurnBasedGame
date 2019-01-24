using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class BracketStatePlay : Bracket.State
	{

		#region Constructor

		public enum Property
		{

		}

		public BracketStatePlay() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Play;
		}

	}
}