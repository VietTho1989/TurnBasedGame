using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class DirectoryHistoryUpdate : UpdateBehavior<DirectoryHistory>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {

				} else {
					Debug.LogError ("data null");
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private ShowDirectory showDirectory = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is DirectoryHistory) {
				DirectoryHistory directoryHistory = data as DirectoryHistory;
				// Parent
				{
					DataUtils.addParentCallBack (directoryHistory, this, ref this.showDirectory);
				}
				dirty = true;
				return;
			}
			// Parent
			if (data is ShowDirectory) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is DirectoryHistory) {
				DirectoryHistory directoryHistory = data as DirectoryHistory;
				// Parent
				{
					DataUtils.removeParentCallBack (directoryHistory, this, ref this.showDirectory);
				}
				this.setDataNull (directoryHistory);
				return;
			}
			// Parent
			if (data is ShowDirectory) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is DirectoryHistory) {
				switch ((DirectoryHistory.Property)wrapProperty.n) {
				case DirectoryHistory.Property.isActive:
					break;
				case DirectoryHistory.Property.history:
					break;
				case DirectoryHistory.Property.position:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			if (wrapProperty.p is ShowDirectory) {
				switch ((ShowDirectory.Property)wrapProperty.n) {
				case ShowDirectory.Property.state:
					break;
				case ShowDirectory.Property.directory:
					{
						for (int syncCount = 0; syncCount < syncs.Count; syncCount++) {
							Sync<T> sync = syncs [syncCount];
							if (sync is SyncSet<T>) {
								SyncSet<T> syncSet = (SyncSet<T>)sync;
								// Update
								if (syncSet.olds.Count == syncSet.news.Count) {
									for (int i = 0; i < syncSet.olds.Count; i++) {
										DirectoryInfo oldDir = (DirectoryInfo)(object)syncSet.olds [i];
										DirectoryInfo newDir = (DirectoryInfo)(object)syncSet.news [i];
										if (this.data != null) {
											this.data.makeDirectoryChange (oldDir, newDir);
										} else {
											Debug.LogError ("data null: " + this);
										}
									}
								} else {
									Debug.LogError ("count error: " + this);
								}
							}
						}
						dirty = true;
					}
					break;
				case ShowDirectory.Property.files:
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