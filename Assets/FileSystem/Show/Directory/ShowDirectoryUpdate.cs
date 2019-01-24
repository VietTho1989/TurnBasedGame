using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class ShowDirectoryUpdate : UpdateBehavior<ShowDirectory>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					switch (this.data.state.v) {
					case ShowDirectory.State.Load:
						{
							this.data.refresh ();
						}
						break;
					case ShowDirectory.State.Normal:
						break;
					case ShowDirectory.State.Fail:
						break;
					default:
						Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
						break;
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
			if (data is ShowDirectory) {
				ShowDirectory showDirectory = data as ShowDirectory;
				// Update
				{
					UpdateUtils.makeUpdate<ShowDirectoryObserverUpdate, ShowDirectory> (showDirectory, this.transform);
				}
				// Child
				{
					showDirectory.directoryHistory.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is DirectoryHistory) {
				DirectoryHistory directoryHistory = data as DirectoryHistory;
				// Update
				{
					UpdateUtils.makeUpdate<DirectoryHistoryUpdate, DirectoryHistory> (directoryHistory, this.transform);
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is ShowDirectory) {
				ShowDirectory showDirectory = data as ShowDirectory;
				// Update
				{
					showDirectory.removeCallBackAndDestroy (typeof(ShowDirectoryObserverUpdate));
				}
				// Child
				{
					showDirectory.directoryHistory.allRemoveCallBack (this);
				}
				this.setDataNull (showDirectory);
				return;
			}
			// Child
			if (data is DirectoryHistory) {
				DirectoryHistory directoryHistory = data as DirectoryHistory;
				// Update
				{
					directoryHistory.removeCallBackAndDestroy (typeof(DirectoryHistoryUpdate));
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
			if (wrapProperty.p is ShowDirectory) {
				switch ((ShowDirectory.Property)wrapProperty.n) {
				case ShowDirectory.Property.state:
					dirty = true;
					break;
				case ShowDirectory.Property.directory:
					{
						dirty = true;
						if (this.data != null) {
							this.data.state.v = ShowDirectory.State.Load;
							this.data.files.clear ();
							// clear selected file
							{
								FileSystemBrowser fileSystemBrowser = this.data.findDataInParent<FileSystemBrowser> ();
								if (fileSystemBrowser != null) {
									Action action = fileSystemBrowser.action.v;
									if (action != null) {
										if (action is ActionNone) {
											ActionNone actionNone = action as ActionNone;
											if (actionNone.state.v == ActionNone.State.None) {
												actionNone.selectFiles.clear ();
											}
										}
									} else {
										Debug.LogError ("action null: " + this);
									}
								} else {
									Debug.LogError ("fileSystemBrowser null: " + this);
								}
							}
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
					break;
				case ShowDirectory.Property.directoryHistory:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
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
			// Child
			if (wrapProperty.p is DirectoryHistory) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}