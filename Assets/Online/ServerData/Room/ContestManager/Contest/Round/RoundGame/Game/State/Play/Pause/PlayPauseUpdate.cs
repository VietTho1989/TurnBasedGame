using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class PlayPauseUpdate : UpdateBehavior<PlayPause>
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
			if (data is PlayPause) {
				PlayPause playPause = data as PlayPause;
				// Child
				{
					playPause.human.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Human) {
				Human human = data as Human;
				// Update
				{
					UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is PlayPause) {
				PlayPause playPause = data as PlayPause;
				// Child
				{
					playPause.human.allRemoveCallBack (this);
				}
				this.setDataNull (playPause);
				return;
			}
			// Child
			if (data is Human) {
				Human human = data as Human;
				// Update
				{
					human.removeCallBackAndDestroy (typeof(HumanUpdate));
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
			if (wrapProperty.p is PlayPause) {
				switch ((PlayPause.Property)wrapProperty.n) {
				case PlayPause.Property.human:
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
			if (wrapProperty.p is Human) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}