using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
	public class ProcessUpdate : UpdateBehavior<Process>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Find history
					History history = null;
					{
						Game game = this.data.findDataInParent<Game> ();
						if (game != null) {
							history = game.history.v;
						} else {
							Debug.LogError ("game null: " + this);
						}
					}
					if (history != null) {
						bool isFinishProcess = true;
						// Process
						{
							history.changePosition (this.data.index.v);
						}
						// chuyen sang resolved
						if (isFinishProcess) {
							UndoRedoAction undoRedoAction = this.data.findDataInParent<UndoRedoAction> ();
							if (undoRedoAction != null) {
								Resolved resolved = new Resolved ();
								{
									resolved.uid = undoRedoAction.state.makeId ();
								}
								undoRedoAction.state.v = resolved;
							} else {
								Debug.LogError ("undoRedoAction ");
							}

							// TODO khi chuyen ve ma da checkmate thi no se khong set ai
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

		private Game game = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is Process) {
				Process process = data as Process;
				// Parent
				{
					DataUtils.addParentCallBack (process, this, ref this.game);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is Game) {
					Game game = data as Game;
					// Child
					{
						game.history.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is History) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Process) {
				Process process = data as Process;
				// Parent
				{
					DataUtils.removeParentCallBack (process, this, ref this.game);
				}
				this.setDataNull (process);
				return;
			}
			// Parent
			{
				if (data is Game) {
					Game game = data as Game;
					// Child
					{
						game.history.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is History) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is Process) {
				switch ((Process.Property)wrapProperty.n) {
				case Process.Property.index:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				if (wrapProperty.p is Game) {
					switch ((Game.Property)wrapProperty.n) {
					case Game.Property.gamePlayers:
						break;
					case Game.Property.requestDraw:
						break;
					case Game.Property.state:
						break;
					case Game.Property.gameData:
						break;
					case Game.Property.history:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case Game.Property.gameAction:
						break;
					case Game.Property.undoRedoRequest:
						break;
					case Game.Property.chatRoom:
						break;
					case Game.Property.animationData:
						break;
					default:
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is History) {
					switch ((History.Property)wrapProperty.n) {
					case History.Property.isActive:
						break;
					case History.Property.changes:
						dirty = true;
						break;
					case History.Property.position:
						dirty = true;
						break;
					case History.Property.changeCount:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}