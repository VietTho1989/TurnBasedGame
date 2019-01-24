using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
	public class TimeControlNormalUpdate : UpdateBehavior<TimeControlNormal>
	{

		#region update

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
			if (data is TimeControlNormal) {
				TimeControlNormal timeControlNormal = data as TimeControlNormal;
				// Update
				{
					UpdateUtils.makeUpdate<MakePlayerTotalTimesUpdate, TimeControlNormal> (timeControlNormal, this.transform);
					UpdateUtils.makeUpdate<IncreasePlayerTotalTimeUpdate, TimeControlNormal> (timeControlNormal, this.transform);
					UpdateUtils.makeUpdate<CheckTimeOutUpdate, TimeControlNormal> (timeControlNormal, this.transform);
					UpdateUtils.makeUpdate<MakeTimeReportDeltaUpdate, TimeControlNormal> (timeControlNormal, this.transform);
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is TimeControlNormal) {
				TimeControlNormal timeControlNormal = data as TimeControlNormal;
				// Update
				{
					timeControlNormal.removeCallBackAndDestroy(typeof(MakePlayerTotalTimesUpdate));
					timeControlNormal.removeCallBackAndDestroy (typeof(IncreasePlayerTotalTimeUpdate));
					timeControlNormal.removeCallBackAndDestroy (typeof(CheckTimeOutUpdate));
					timeControlNormal.removeCallBackAndDestroy (typeof(MakeTimeReportDeltaUpdate));
				}
				this.setDataNull (timeControlNormal);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is TimeControlNormal) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}