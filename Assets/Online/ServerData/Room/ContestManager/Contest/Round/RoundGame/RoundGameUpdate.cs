using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundGameUpdate : UpdateBehavior<RoundGame>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {

				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is RoundGame) {
				RoundGame roundGame = data as RoundGame;
				// Update
				{
					UpdateUtils.makeUpdate<MakeGamePlayerUpdate, RoundGame> (roundGame, this.transform);
				}
				// Child
				{
					roundGame.game.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Game) {
				Game game = data as Game;
				// Update
				{
					UpdateUtils.makeUpdate<GameUpdate, Game> (game, this.transform);
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RoundGame) {
				RoundGame roundGame = data as RoundGame;
				// Update
				{
					roundGame.removeCallBackAndDestroy (typeof(MakeGamePlayerUpdate));
				}
				// Child
				{
					roundGame.game.allRemoveCallBack (this);
				}
				this.setDataNull (roundGame);
				return;
			}
			// Child
			if (data is Game) {
				Game game = data as Game;
				// Update
				{
					game.removeCallBackAndDestroy (typeof(GameUpdate));
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RoundGame) {
				switch ((RoundGame.Property)wrapProperty.n) {
				case RoundGame.Property.index:
					break;
				case RoundGame.Property.playerInTeam:
					break;
				case RoundGame.Property.playerInGame:
					break;
				case RoundGame.Property.game:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is Game) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}