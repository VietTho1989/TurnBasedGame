using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class ActionEditUpdate : UpdateBehavior<ActionEdit>
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
			if (data is ActionEdit) {
				ActionEdit actionEdit = data as ActionEdit;
				// Child
				{
					actionEdit.state.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is ActionEdit.State) {
				ActionEdit.State state = data as ActionEdit.State;
				// Update
				{
					switch (state.getType ()) {
					case ActionEdit.State.Type.Start:
						{
							ActionEditStart start = state as ActionEditStart;
							UpdateUtils.makeUpdate<ActionEditStartUpdate, ActionEditStart> (start, this.transform);
						}
						break;
					case ActionEdit.State.Type.Process:
						{
							ActionEditProcess process = state as ActionEditProcess;
							UpdateUtils.makeUpdate<ActionEditProcessUpdate, ActionEditProcess> (process, this.transform);
						}
						break;
					case ActionEdit.State.Type.Success:
						{
							ActionEditSuccess success = state as ActionEditSuccess;
							UpdateUtils.makeUpdate<ActionEditSuccessUpdate, ActionEditSuccess> (success, this.transform);
						}
						break;
					case ActionEdit.State.Type.Fail:
						{
							ActionEditFail fail = state as ActionEditFail;
							UpdateUtils.makeUpdate<ActionEditFailUpdate, ActionEditFail> (fail, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + state.getType () + "; " + this);
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
			if (data is ActionEdit) {
				ActionEdit actionEdit = data as ActionEdit;
				// Child
				{
					actionEdit.state.allRemoveCallBack (this);
				}
				this.setDataNull (actionEdit);
				return;
			}
			// Child
			if (data is ActionEdit.State) {
				ActionEdit.State state = data as ActionEdit.State;
				// Update
				{
					switch (state.getType ()) {
					case ActionEdit.State.Type.Start:
						{
							ActionEditStart start = state as ActionEditStart;
							start.removeCallBackAndDestroy (typeof(ActionEditStartUpdate));
						}
						break;
					case ActionEdit.State.Type.Process:
						{
							ActionEditProcess process = state as ActionEditProcess;
							process.removeCallBackAndDestroy (typeof(ActionEditProcessUpdate));
						}
						break;
					case ActionEdit.State.Type.Success:
						{
							ActionEditSuccess success = state as ActionEditSuccess;
							success.removeCallBackAndDestroy (typeof(ActionEditSuccessUpdate));
						}
						break;
					case ActionEdit.State.Type.Fail:
						{
							ActionEditFail fail = state as ActionEditFail;
							fail.removeCallBackAndDestroy (typeof(ActionEditFailUpdate));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + state.getType () + "; " + this);
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
			if (wrapProperty.p is ActionEdit) {
				switch ((ActionEdit.Property)wrapProperty.n) {
				case ActionEdit.Property.action:
					break;
				case ActionEdit.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case ActionEdit.Property.files:
					break;
				case ActionEdit.Property.destDir:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is ActionEdit.State) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion


	}
}