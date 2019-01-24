using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
	public class PlayerTotalTime : Data
	{

		public VP<int> playerIndex;

		public VP<float> serverTime;

		public VP<float> clientTime;

		#region Constructor

		public enum Property
		{
			playerIndex,
			serverTime,
			clientTime
		}

		public PlayerTotalTime() : base()
		{
			this.playerIndex = new VP<int> (this, (byte)Property.playerIndex, 0);
			this.serverTime = new VP<float> (this, (byte)Property.serverTime, 0);
			this.clientTime = new VP<float> (this, (byte)Property.clientTime, 0);
		}

		#endregion

	}
}