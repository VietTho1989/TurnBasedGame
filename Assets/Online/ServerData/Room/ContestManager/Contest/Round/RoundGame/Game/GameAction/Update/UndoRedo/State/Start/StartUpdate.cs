using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
	public class StartUpdate : UpdateBehavior<Start>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Find History
					History history = null;
					{
						Game game = this.data.findDataInParent<Game> ();
						if (game != null) {
							history = game.history.v;
						} else {
							Debug.LogError ("game null: " + this);
						}
					}
					// Process
					if (history != null) {
						// find index
						int index = -1;
						{
							UndoRedoAction undoRedoAction = this.data.findDataInParent<UndoRedoAction> ();
							if (undoRedoAction != null) {
								RequestInform requestInform = undoRedoAction.requestInform.v;
								if (requestInform != null) {
									index = requestInform.getIndex ();
								} else {
									Debug.LogError ("requestInform null: " + this);
								}
							} else {
								Debug.LogError ("undoRedoAction null: " + this);
							}
						}
						// Change to state process
						{
							UndoRedoAction undoRedoAction = this.data.findDataInParent<UndoRedoAction> ();
							if (undoRedoAction != null) {
								Process process = new Process ();
								{
									process.uid = undoRedoAction.state.makeId ();
									process.index.v = index;
								}
								undoRedoAction.state.v = process;
							} else {
								Debug.LogError ("undoRedoAction null: " + this);
							}
						}
					} else {
						Debug.LogError ("history null: " + this);
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
			if (data is Start) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Start) {
				Start start = data as Start;
				{

				}
				this.setDataNull (start);
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