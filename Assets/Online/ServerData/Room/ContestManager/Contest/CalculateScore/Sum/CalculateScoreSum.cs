using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class CalculateScoreSum : CalculateScore
	{

		#region Constructor

		public enum Property
		{

		}

		public CalculateScoreSum() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Sum;
		}

	}
}