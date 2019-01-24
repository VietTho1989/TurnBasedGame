using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class PlayUpdate : UpdateBehavior<Play>
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
			if (data is Play) {
				Play play = data as Play;
				// Child
				{
					play.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Play.Sub) {
				Play.Sub sub = data as Play.Sub;
				// Update
				{
					switch (sub.getType ()) {
					case Play.Sub.Type.Normal:
						{
							PlayNormal playNormal = sub as PlayNormal;
							UpdateUtils.makeUpdate<PlayNormalUpdate, PlayNormal> (playNormal, this.transform);
						}
						break;
					case Play.Sub.Type.Pause:
						{
							PlayPause playPause = sub as PlayPause;
							UpdateUtils.makeUpdate<PlayPauseUpdate, PlayPause> (playPause, this.transform);
						}
						break;
					case Play.Sub.Type.UnPause:
						{
							PlayUnPause playUnPause = sub as PlayUnPause;
							UpdateUtils.makeUpdate<PlayUnPauseUpdate, PlayUnPause> (playUnPause, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
					}
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Play) {
				Play play = data as Play;
				// Child
				{
					play.sub.allRemoveCallBack (this);
				}
				this.setDataNull (play);
				return;
			}
			// Child
			if (data is Play.Sub) {
				Play.Sub sub = data as Play.Sub;
				// Update
				{
					switch (sub.getType ()) {
					case Play.Sub.Type.Normal:
						{
							PlayNormal playNormal = sub as PlayNormal;
							playNormal.removeCallBackAndDestroy (typeof(PlayNormalUpdate));
						}
						break;
					case Play.Sub.Type.Pause:
						{
							PlayPause playPause = sub as PlayPause;
							playPause.removeCallBackAndDestroy (typeof(PlayPauseUpdate));
						}
						break;
					case Play.Sub.Type.UnPause:
						{
							PlayUnPause playUnPause = sub as PlayUnPause;
							playUnPause.removeCallBackAndDestroy (typeof(PlayUnPauseUpdate));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
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
			if (wrapProperty.p is Play) {
				switch ((Play.Property)wrapProperty.n) {
				case Play.Property.sub:
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
			if (wrapProperty.p is Play.Sub) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}