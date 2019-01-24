using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class MatchTeam : Data
	{

		#region sort

		public enum Sort
		{
			TeamIndex,
			Score
		}


		#endregion

		public VP<int> teamIndex;

		public VP<TeamState> state;

		#region players

		public LP<TeamPlayer> players;

		public TeamPlayer findPlayer(int playerIndex)
		{
			return this.players.vs.Find (player => player.playerIndex.v == playerIndex);
		}

		#endregion

		#region Constructor

		public enum Property
		{
			teamIndex,
			state,
			players
		}

		public MatchTeam() : base()
		{
			this.teamIndex = new VP<int> (this, (byte)Property.teamIndex, 0);
			this.state = new VP<TeamState> (this, (byte)Property.state, new TeamStateNormal ());
			this.players = new LP<TeamPlayer> (this, (byte)Property.players);
		}

		#endregion

		public void copy(MatchTeam otherMatchTeam)
		{
			if (otherMatchTeam != null) {
				foreach (TeamPlayer player in this.players.vs) {
					TeamPlayer otherPlayer = otherMatchTeam.findPlayer (player.playerIndex.v);
					if (otherPlayer != null) {
						DataUtils.copyData (player, otherPlayer);
					} else {
						Debug.LogError ("otherPlayer null: " + this);
					}
				}
			} else {
				Debug.LogError ("otherMatchTeam null: " + this);
			}
		}

	}
}