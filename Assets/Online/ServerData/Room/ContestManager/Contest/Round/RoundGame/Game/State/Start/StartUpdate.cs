using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class StartUpdate : UpdateBehavior<Start>
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
			if (data is Start) {
				Start start = data as Start;
				// Child
				{
					start.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Start.Sub) {
				Start.Sub sub = data as Start.Sub;
				// Update
				{
					switch (sub.getType ()) {
					case Start.Sub.Type.Normal:
						{
							StartNormal startNormal = sub as StartNormal;
							UpdateUtils.makeUpdate<StartNormalUpdate, StartNormal> (startNormal, this.transform);
						}
						break;
					default:
						Debug.LogError ("Don't process: " + sub.getType () + "; " + this);
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
			if (data is Start) {
				Start start = data as Start;
				// Child
				{
					start.sub.allRemoveCallBack (this);
				}
				this.setDataNull (start);
				return;
			}
			// Child
			if (data is Start.Sub) {
				Start.Sub sub = data as Start.Sub;
				// Update
				{
					switch (sub.getType ()) {
					case Start.Sub.Type.Normal:
						{
							StartNormal startNormal = sub as StartNormal;
							startNormal.removeCallBackAndDestroy (typeof(StartNormalUpdate));
						}
						break;
					default:
						Debug.LogError ("Don't process: " + sub.getType () + "; " + this);
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
			if (wrapProperty.p is Start) {
				switch ((Start.Property)wrapProperty.n) {
				case Start.Property.sub:
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
			if (wrapProperty.p is Start.Sub) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}