using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundGame : Data
	{

		public VP<int> index;

		/** sap xep theo thu tu: so thu 0 la playerIndex cua team 0*/
		public LP<int> playerInTeam;

		/** player index cua playerInTeam o tren trong game*/
		public LP<int> playerInGame;

		public VP<Game> game;

		#region Constructor

		public enum Property
		{
			index,
			playerInTeam,
			playerInGame,
			game
		}

		public RoundGame() : base()
		{
			this.index = new VP<int> (this, (byte)Property.index, 0);
			this.playerInTeam = new LP<int> (this, (byte)Property.playerInTeam);
			this.playerInGame = new LP<int> (this, (byte)Property.playerInGame);
			this.game = new VP<Game> (this, (byte)Property.game, new Game ());
		}

		#endregion

		public float getTeamScore(int teamIndex)
		{
			float ret = 0;
			{
				if (teamIndex >= 0 && teamIndex < this.playerInGame.vs.Count) {
					int playerIndex = this.playerInGame.vs [teamIndex];
					Game game = this.game.v;
					if (game != null) {
						// get state end
						if (game.state.v is GameState.End) {
							GameState.End end = game.state.v as GameState.End;
							// get result
							GameState.Result result = end.findResult (playerIndex);
							if (result != null) {
								ret = result.score.v;
							} else {
								Debug.LogError ("result null: " + this);
							}
						}
					} else {
						Debug.LogError ("game null: " + this);
					}
				}
			}
			return ret;
		}

	}
}