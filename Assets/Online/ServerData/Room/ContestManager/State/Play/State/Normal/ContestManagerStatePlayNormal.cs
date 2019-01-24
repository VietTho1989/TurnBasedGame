using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestManagerStatePlayNormal : ContestManagerStatePlay.State
	{

		#region Constructor

		public enum Property
		{

		}

		public ContestManagerStatePlayNormal() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Normal;
		}

	}
}