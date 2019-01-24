using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class ActionNoneUpdate : UpdateBehavior<ActionNone>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// file
					for (int i = this.data.selectFiles.vs.Count - 1; i >= 0; i--) {
						FileSystemInfo file = this.data.selectFiles.vs [i];
						if (!(file != null && file.Exists)) {
							this.data.selectFiles.removeAt (i);
						}
					}
					// state
					if (this.data.selectFiles.vs.Count == 0) {
						this.data.state.v = ActionNone.State.None;
					}
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
			if (data is ActionNone) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is ActionNone) {
				ActionNone actionNone = data as ActionNone;
				// Child
				{

				}
				this.setDataNull (actionNone);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is ActionNone) {
				switch ((ActionNone.Property)wrapProperty.n) {
				case ActionNone.Property.selectFiles:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}