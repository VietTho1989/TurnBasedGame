using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewContestManagerStateNone : RequestNewContestManager.State
	{

		#region Constructor

		public enum Property
		{

		}

		public RequestNewContestManagerStateNone() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.None;
		}

	}
}