using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.HourGlass
{
	public class PlayerTime : Data
	{
		public const float DefaultTime = 60f;
		public const float DefaultLagCompensation = 30f;

		public VP<int> playerIndex;

		public VP<float> serverTime;

		public VP<float> clientTime;

		public VP<float> lagCompensation;

		#region Constructor

		public enum Property
		{
			playerIndex,
			serverTime,
			clientTime,
			lagCompensation
		}

		public PlayerTime() : base()
		{
			this.playerIndex = new VP<int> (this, (byte)Property.playerIndex, 0);
			this.serverTime = new VP<float> (this, (byte)Property.serverTime, DefaultTime);
			this.clientTime = new VP<float> (this, (byte)Property.clientTime, DefaultTime);
			{
				this.lagCompensation = new VP<float> (this, (byte)Property.lagCompensation, DefaultLagCompensation);
				this.lagCompensation.nh = 0;
			}
		}

		#endregion

		public override string ToString ()
		{
			return string.Format ("[PlayerTime: {0}, {1}, {2}, {3}]", this.playerIndex.v, this.serverTime.v, this.clientTime.v, this.lagCompensation.v);
		}

	}
}