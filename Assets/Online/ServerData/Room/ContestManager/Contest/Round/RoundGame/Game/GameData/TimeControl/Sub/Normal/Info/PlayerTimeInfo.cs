using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
	public class PlayerTimeInfo : Data
	{

		public VP<int> playerIndex;

		public VP<TimeInfo> timeInfo;

		#region Constructor

		public enum Property
		{
			playerIndex,
			timeInfo
		}

		public PlayerTimeInfo() : base()
		{
			this.playerIndex = new VP<int> (this, (byte)Property.playerIndex, 0);
			this.timeInfo = new VP<TimeInfo> (this, (byte)Property.timeInfo, new TimeInfo ());
		}

		#endregion

	}
}