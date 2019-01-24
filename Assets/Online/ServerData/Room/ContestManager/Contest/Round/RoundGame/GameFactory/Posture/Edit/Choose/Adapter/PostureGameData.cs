using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Posture
{
	public class PostureGameData : Data
	{
		public VP<int> postureIndex;

		public VP<string> name;

		public VP<GameData> gameData;

		#region Constructor

		public enum Property
		{
			postureIndex,
			name,
			gameData
		}

		public PostureGameData() : base()
		{
			this.postureIndex = new VP<int> (this, (byte)Property.postureIndex, -1);
			this.name = new VP<string> (this, (byte)Property.name, "");
			this.gameData = new VP<GameData> (this, (byte)Property.gameData, new GameData ());
		}

		#endregion

	}
}