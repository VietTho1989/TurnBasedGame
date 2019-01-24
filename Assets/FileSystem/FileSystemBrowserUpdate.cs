using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class FileSystemBrowserUpdate : UpdateBehavior<FileSystemBrowser>
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
			if (data is FileSystemBrowser) {
				FileSystemBrowser fileSystemBrowser = data as FileSystemBrowser;
				// Child
				{
					fileSystemBrowser.action.allAddCallBack (this);
					fileSystemBrowser.show.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Action) {
					Action action = data as Action;
					// Update
					{
						switch (action.getType ()) {
						case Action.Type.None:
							{
								ActionNone actionNone = action as ActionNone;
								UpdateUtils.makeUpdate<ActionNoneUpdate, ActionNone> (actionNone, this.transform);
							}
							break;
						case Action.Type.Edit:
							{
								ActionEdit actionEdit = action as ActionEdit;
								UpdateUtils.makeUpdate<ActionEditUpdate, ActionEdit> (actionEdit, this.transform);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + action.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				if (data is Show) {
					Show show = data as Show;
					// Update
					{
						switch (show.getType ()) {
						case Show.Type.Single:
							{
								SingleShow singleShow = show as SingleShow;
								UpdateUtils.makeUpdate<SingleShowUpdate, SingleShow> (singleShow, this.transform);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + show.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is FileSystemBrowser) {
				FileSystemBrowser fileSystemBrowser = data as FileSystemBrowser;
				// Child
				{
					fileSystemBrowser.action.allRemoveCallBack (this);
					fileSystemBrowser.show.allRemoveCallBack (this);
				}
				this.setDataNull (fileSystemBrowser);
				return;
			}
			// Child
			{
				if (data is Action) {
					Action action = data as Action;
					// Update
					{
						switch (action.getType ()) {
						case Action.Type.None:
							{
								ActionNone actionNone = action as ActionNone;
								actionNone.removeCallBackAndDestroy (typeof(ActionNoneUpdate));
							}
							break;
						case Action.Type.Edit:
							{
								ActionEdit actionEdit = action as ActionEdit;
								actionEdit.removeCallBackAndDestroy (typeof(ActionEditUpdate));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + action.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is Show) {
					Show show = data as Show;
					// Update
					{
						switch (show.getType ()) {
						case Show.Type.Single:
							{
								SingleShow singleShow = show as SingleShow;
								singleShow.removeCallBackAndDestroy (typeof(SingleShowUpdate));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + show.getType () + "; " + this);
							break;
						}
					}
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
			if (wrapProperty.p is FileSystemBrowser) {
				switch ((FileSystemBrowser.Property)wrapProperty.n) {
				case FileSystemBrowser.Property.action:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case FileSystemBrowser.Property.show:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + data + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is Action) {
					return;
				}
				if (wrapProperty.p is Show) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}