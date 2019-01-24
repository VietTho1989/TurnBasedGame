using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class SingleShowUpdate : UpdateBehavior<SingleShow>
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
			if (data is SingleShow) {
				SingleShow singleShow = data as SingleShow;
				// Child
				{
					singleShow.showDirectory.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is ShowDirectory) {
				ShowDirectory showDirectory = data as ShowDirectory;
				// Update
				{
					UpdateUtils.makeUpdate<ShowDirectoryUpdate, ShowDirectory> (showDirectory, this.transform);
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is SingleShow) {
				SingleShow singleShow = data as SingleShow;
				// Child
				{
					singleShow.showDirectory.allRemoveCallBack (this);
				}
				this.setDataNull (singleShow);
				return;
			}
			// Child
			if (data is ShowDirectory) {
				ShowDirectory showDirectory = data as ShowDirectory;
				// Update
				{
					showDirectory.removeCallBackAndDestroy (typeof(ShowDirectoryUpdate));
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
			if (wrapProperty.p is SingleShow) {
				switch ((SingleShow.Property)wrapProperty.n) {
				case SingleShow.Property.showDirectory:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is ShowDirectory) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}