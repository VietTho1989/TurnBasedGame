using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class ActionEditStartUpdate : UpdateBehavior<ActionEditStart>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ActionEdit actionEdit = this.data.findDataInParent<ActionEdit> ();
					if (actionEdit != null) {
						ActionEditProcess process = new ActionEditProcess ();
						{
							process.uid = actionEdit.state.makeId ();
							process.files.vs.AddRange (actionEdit.files.vs);
						}
						actionEdit.state.v = process;
					} else {
						Debug.LogError ("actionEdit null: " + this);
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
			if (data is ActionEditStart) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is ActionEditStart) {
				ActionEditStart actionEditStart = data as ActionEditStart;
				// Child
				{

				}
				this.setDataNull (actionEditStart);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is ActionEditStart) {
				switch ((ActionEditStart.Property)wrapProperty.n) {
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