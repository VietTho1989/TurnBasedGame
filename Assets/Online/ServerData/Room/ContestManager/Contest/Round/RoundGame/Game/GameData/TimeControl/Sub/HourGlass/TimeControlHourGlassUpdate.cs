using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.HourGlass
{
	public class TimeControlHourGlassUpdate : UpdateBehavior<TimeControlHourGlass>
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
			if (data is TimeControlHourGlass) {
				TimeControlHourGlass timeControlHourGlass = data as TimeControlHourGlass;
				// Update
				{
					UpdateUtils.makeUpdate<MakePlayerTimesUpdate, TimeControlHourGlass> (timeControlHourGlass, this.transform);
					UpdateUtils.makeUpdate<IncreasePlayerTimeUpdate, TimeControlHourGlass> (timeControlHourGlass, this.transform);
					UpdateUtils.makeUpdate<CheckTimeOutUpdate, TimeControlHourGlass> (timeControlHourGlass, this.transform);
					UpdateUtils.makeUpdate<MakeTimeReportDeltaUpdate, TimeControlHourGlass> (timeControlHourGlass, this.transform);
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don' process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is TimeControlHourGlass) {
				TimeControlHourGlass timeControlHourGlass = data as TimeControlHourGlass;
				// Update
				{
					timeControlHourGlass.removeCallBackAndDestroy (typeof(MakePlayerTimesUpdate));
					timeControlHourGlass.removeCallBackAndDestroy (typeof(IncreasePlayerTimeUpdate));
					timeControlHourGlass.removeCallBackAndDestroy (typeof(CheckTimeOutUpdate));
					timeControlHourGlass.removeCallBackAndDestroy (typeof(MakeTimeReportDeltaUpdate));
				}
				this.setDataNull (timeControlHourGlass);
				return;
			}
			Debug.LogError ("Don' process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is TimeControlHourGlass) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}