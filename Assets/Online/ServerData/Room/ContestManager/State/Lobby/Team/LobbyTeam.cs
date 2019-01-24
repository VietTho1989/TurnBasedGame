using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class LobbyTeam : Data
	{

		public VP<int> teamIndex;

		public LP<LobbyPlayer> players;

		#region Constructor

		public enum Property
		{
			teamIndex,
			players
		}

		public LobbyTeam() : base()
		{
			this.teamIndex = new VP<int> (this, (byte)Property.teamIndex, 0);
			this.players = new LP<LobbyPlayer> (this, (byte)Property.players);
		}

		#endregion

	}
}