using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class DirectoryHistory : Data
	{

		public VP<bool> isActive;
		public LP<DirectoryChange> history;
		public VP<int> position;

		#region Constructor

		public enum Property
		{
			isActive,
			history,
			position
		}

		public DirectoryHistory() : base()
		{
			this.isActive = new VP<bool> (this, (byte)Property.isActive, true);
			this.history = new LP<DirectoryChange> (this, (byte)Property.history);
			this.position = new VP<int> (this, (byte)Property.position, -1);
		}

		#endregion

		public void reset()
		{
			this.isActive.v = true;
			this.history.clear ();
			this.position.v = -1;
		}

		private void clearFuture()
		{
			for (int i = this.history.vs.Count - 1; i >= 0; i--) {
				DirectoryChange change = this.history.vs [i];
				if (change.position.v > this.position.v) {
					this.history.remove (change);
				}
			}
		}

		public void makeDirectoryChange(DirectoryInfo oldValue, DirectoryInfo newValue){
			// Debug.Log ("makeHistoryValueChange: " + valueProperty + ", " + oldValue + ", " + newValue);
			if (!isActive.v) {
				// Debug.LogError ("the history isn't active");
				return;
			}
			// Clear futures: all change have position larger than current index
			this.clearFuture();
			// Make change
			DirectoryChange newChange = new DirectoryChange ();
			{
				newChange.uid = this.history.makeId ();
				newChange.oldDir.v = oldValue;
				newChange.newDir.v = newValue;
				// Position
				{
					this.position.v++;
					newChange.position.v = this.position.v;
				}
				newChange.time.v = Global.getRealTimeInMiliSeconds ();
			}
			this.history.add (newChange);
		}

		#region Undo Redo

		public enum Operation
		{
			Undo,
			Redo
		}

		public void processUndoRedo(Operation operation)
		{
			if (this.isActive.v) {
				this.isActive.v = false;
				{
					switch (operation) {
					case Operation.Undo:
						this.processUndo ();
						break;
					case Operation.Redo:
						this.processRedo ();
						break;
					default:
						Debug.LogError ("unknown operation: " + operation);
						break;
					}
				}
				this.isActive.v = true;
			} else {
				Debug.LogError ("Why history isn't active");
			}
		}

		private void processUndo()
		{
			Debug.LogError ("processUndo");
			// Find undoIndex
			int undoIndex = this.position.v - 1;
			// Make undo changes
			if (undoIndex >= -1 && undoIndex < this.position.v) {
				// Find Undo Changes
				List<DirectoryChange> undoChanges = new List<DirectoryChange>();
				{
					for (int i = this.history.vs.Count - 1; i >= 0; i--) {
						DirectoryChange checkUndoChange = this.history.vs [i];
						if (checkUndoChange.position.v > undoIndex && checkUndoChange.position.v <= this.position.v) {
							undoChanges.Add (checkUndoChange);
						}
					}
					// change position
					this.position.v = undoIndex;
				}
				// Process Undo Changes
				{
					// Sort by position, who smaller go first: undoChanges
					{
						undoChanges.Sort (delegate(DirectoryChange x, DirectoryChange y) {
							return x.position.v.CompareTo(y.position.v);
						});
					}
					// Make undo
					{
						ShowDirectory showDirectory = this.findDataInParent<ShowDirectory> ();
						if (showDirectory != null) {
							for (int i = undoChanges.Count - 1; i >= 0; i--) {
								DirectoryChange undoChange = undoChanges [i];
								// change to oldValue
								showDirectory.directory.v = undoChange.oldDir.v;
							}
						} else {
							Debug.LogError ("showDirectory null: " + this);
						}
					}
				}
			} else {
				Debug.LogError ("Cannot undo: " + undoIndex + ", " + this.position.v);
			}
		}

		private void processRedo()
		{
			Debug.LogError ("processRedo");
			// Find undoIndex
			int redoIndex = this.position.v+1;
			// Undo the gameData
			if (redoIndex > this.position.v && redoIndex <= this.history.vs.Count - 1) {
				// Find Undo Changes
				List<DirectoryChange> redoChanges = new List<DirectoryChange> ();
				{
					for (int i = this.history.vs.Count - 1; i >= 0; i--) {
						DirectoryChange checkRedoChange = this.history.vs [i];
						if (checkRedoChange.position.v > this.position.v && checkRedoChange.position.v <= redoIndex) {
							redoChanges.Add (checkRedoChange);
						}
					}
					// change position
					this.position.v = redoIndex;
				}
				// Process Undo Changes
				{
					// Sort by position, who smaller go first: undoChanges
					{
						redoChanges.Sort (delegate(DirectoryChange x, DirectoryChange y) {
							return x.position.v.CompareTo (y.position.v);
						});
					}
					// Make redo
					{
						ShowDirectory showDirectory = this.findDataInParent<ShowDirectory> ();
						if (showDirectory != null) {
							for (int i = 0; i < redoChanges.Count; i++) {
								DirectoryChange redoChange = redoChanges [i];
								showDirectory.directory.v = redoChange.newDir.v;
							}
						} else {
							Debug.LogError ("showDirectory null: " + this);
						}
					}
				}
			} else {
				Debug.LogError ("Cannot redo: " + redoIndex + ", " + this.position.v);
			}
		}

		#endregion

	}
}