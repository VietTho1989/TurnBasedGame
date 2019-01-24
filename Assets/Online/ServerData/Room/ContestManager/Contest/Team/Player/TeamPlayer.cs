using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class TeamPlayer : Data
	{

		public VP<int> playerIndex;

		public VP<GamePlayer.Inform> inform;

		#region Constructor

		public enum Property
		{
			playerIndex,
			inform
		}

		public TeamPlayer() : base()
		{
			this.playerIndex = new VP<int> (this, (byte)Property.playerIndex, 0);
			this.inform = new VP<GamePlayer.Inform> (this, (byte)Property.inform, new EmptyInform ());
		}

		#endregion

	}
}