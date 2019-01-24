using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationRoundStatePlay : EliminationRound.State
	{

		#region Constructor

		public enum Property
		{

		}

		public EliminationRoundStatePlay() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Play;
		}

	}
}