using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UndoRedo;

public class UndoRedoActionUpdate : GameActionsUpdate.Sub<UndoRedoAction>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				if (this.data.state.v == null) {
					Start start = new Start ();
					{
						start.uid = this.data.state.makeId ();
					}
					this.data.state.v = start;
				}
			} else {
				// Debug.LogError ("null");
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
		if (data is UndoRedoAction) {
			UndoRedoAction undoRedoAction = data as UndoRedoAction;
			// Child
			{
				undoRedoAction.state.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is UndoRedoAction.State) {
			UndoRedoAction.State state = data as UndoRedoAction.State;
			// Update
			{
				switch (state.getType ()) {
				case UndoRedoAction.State.Type.Start:
					{
						Start start = state as Start;
						UpdateUtils.makeUpdate<StartUpdate, Start> (start, this.transform);
					}
					break;
				case UndoRedoAction.State.Type.Process:
					{
						Process process = state as Process;
						UpdateUtils.makeUpdate<ProcessUpdate, Process> (process, this.transform);
					}
					break;
				case UndoRedoAction.State.Type.Resolved:
					{
						Resolved resolved = state as Resolved;
						UpdateUtils.makeUpdate<ResolvedUpdate, Resolved> (resolved, this.transform);
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
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UndoRedoAction) {
			UndoRedoAction undoRedoAction = data as UndoRedoAction;
			// Child
			{
				undoRedoAction.state.allRemoveCallBack (this);
			}
			this.setDataNull (undoRedoAction);
			return;
		}
		// Child
		if (data is UndoRedoAction.State) {
			UndoRedoAction.State state = data as UndoRedoAction.State;
			// Update
			{
				switch (state.getType ()) {
				case UndoRedoAction.State.Type.Start:
					{
						Start start = state as Start;
						start.removeCallBackAndDestroy (typeof(StartUpdate));
					}
					break;
				case UndoRedoAction.State.Type.Process:
					{
						Process process = state as Process;
						process.removeCallBackAndDestroy (typeof(ProcessUpdate));
					}
					break;
				case UndoRedoAction.State.Type.Resolved:
					{
						Resolved resolved = state as Resolved;
						resolved.removeCallBackAndDestroy (typeof(ResolvedUpdate));
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType () + "; " + this);
					break;
				}
			}
			return;
		}
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UndoRedoAction) {
			switch ((UndoRedoAction.Property)wrapProperty.n) {
			case UndoRedoAction.Property.state:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UndoRedoAction.Property.requestInform:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		if (wrapProperty.p is UndoRedoAction.State) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}