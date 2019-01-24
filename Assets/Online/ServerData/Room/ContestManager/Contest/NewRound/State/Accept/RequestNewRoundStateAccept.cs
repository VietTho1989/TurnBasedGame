using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundStateAccept : RequestNewRound.State
	{

		#region Constructor

		public enum Property
		{

		}

		public RequestNewRoundStateAccept() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Accept;
		}

	}
}