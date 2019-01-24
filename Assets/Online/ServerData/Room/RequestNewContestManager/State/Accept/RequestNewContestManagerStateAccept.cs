using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewContestManagerStateAccept : RequestNewContestManager.State
	{

		#region Constructor

		public enum Property
		{

		}

		public RequestNewContestManagerStateAccept() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Accept;
		}

	}
}