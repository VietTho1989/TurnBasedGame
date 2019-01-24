using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestStateLoadUpdate : UpdateBehavior<ContestStateLoad>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Chuyen sang start
					Contest contest = this.data.findDataInParent<Contest>();
					if (contest != null) {
						ContestStateStart start = new ContestStateStart ();
						{
							start.uid = contest.state.makeId ();
						}
						contest.state.v = start;
					} else {
						Debug.LogError ("contest null: " + this);
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
			if (data is ContestStateLoad) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is ContestStateLoad) {
				ContestStateLoad contestStateLoad = data as ContestStateLoad;
				// Child
				{

				}
				this.setDataNull (contestStateLoad);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is ContestStateLoad) {
				switch ((ContestStateLoad.Property)wrapProperty.n) {
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