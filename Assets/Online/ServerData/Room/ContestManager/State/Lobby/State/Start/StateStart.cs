using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Lobby
{
	public class StateStart : ContestManagerStateLobby.State
	{

		public VP<float> time;

		public VP<float> duration;

		#region Constructor

		public enum Property
		{
			time,
			duration
		}

		public StateStart() : base()
		{
			this.time = new VP<float> (this, (byte)Property.time, 0);
			this.duration = new VP<float> (this, (byte)Property.duration, 3);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Start;
		}

	}
}