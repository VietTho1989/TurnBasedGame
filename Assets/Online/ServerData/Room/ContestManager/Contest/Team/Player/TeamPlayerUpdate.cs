using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class TeamPlayerUpdate : UpdateBehavior<TeamPlayer>
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
			if (data is TeamPlayer) {
				TeamPlayer teamPlayer = data as TeamPlayer;
				// Child
				{
					teamPlayer.inform.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is GamePlayer.Inform) {
				GamePlayer.Inform inform = data as GamePlayer.Inform;
				// Update
				{
					if (inform is Human) {
						Human human = inform as Human;
						UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
					}
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is TeamPlayer) {
				TeamPlayer teamPlayer = data as TeamPlayer;
				// Child
				{
					teamPlayer.inform.allAddCallBack (this);
				}
				this.setDataNull (teamPlayer);
				return;
			}
			// Child
			if (data is GamePlayer.Inform) {
				GamePlayer.Inform inform = data as GamePlayer.Inform;
				// Update
				{
					if (inform is Human) {
						Human human = inform as Human;
						human.removeCallBackAndDestroy (typeof(HumanUpdate));
					}
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
			if (wrapProperty.p is TeamPlayer) {
				switch ((TeamPlayer.Property)wrapProperty.n) {
				case TeamPlayer.Property.playerIndex:
					break;
				case TeamPlayer.Property.inform:
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
			if (wrapProperty.p is GamePlayer.Inform) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}