using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TimeControl.Normal;
using TimeControl.HourGlass;

namespace TimeControl
{
	public class TimeControlUpdate : UpdateBehavior<TimeControl>
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
			if (data is TimeControl) {
				TimeControl timeControls = data as TimeControl;
				// Update
				{
					UpdateUtils.makeUpdate<TimeReportUpdate, TimeControl> (timeControls, this.transform);
				}
				// Child
				{
					timeControls.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			if (data is TimeControl.Sub) {
				TimeControl.Sub sub = data as TimeControl.Sub;
				{
					switch (sub.getType ()) {
					case TimeControl.Sub.Type.Normal:
						{
							TimeControlNormal normal = sub as TimeControlNormal;
							UpdateUtils.makeUpdate<TimeControlNormalUpdate, TimeControlNormal> (normal, this.transform);
						}
						break;
					case TimeControl.Sub.Type.HourGlass:
						{
							TimeControlHourGlass hourGlass = sub as TimeControlHourGlass;
							UpdateUtils.makeUpdate<TimeControlHourGlassUpdate, TimeControlHourGlass> (hourGlass, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
					}
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is TimeControl) {
				TimeControl timeControls = data as TimeControl;
				// Update
				{
					timeControls.removeCallBackAndDestroy (typeof(TimeReportUpdate));
				}
				// Child
				{
					timeControls.sub.allRemoveCallBack (this);
				}
				this.setDataNull (timeControls);
				return;
			}
			if (data is TimeControl.Sub) {
				TimeControl.Sub sub = data as TimeControl.Sub;
				{
					switch (sub.getType ()) {
					case TimeControl.Sub.Type.Normal:
						{
							TimeControlNormal normal = sub as TimeControlNormal;
							normal.removeCallBackAndDestroy (typeof(TimeControlNormalUpdate));
						}
						break;
					case TimeControl.Sub.Type.HourGlass:
						{
							TimeControlHourGlass hourGlass = sub as TimeControlHourGlass;
							hourGlass.removeCallBackAndDestroy (typeof(TimeControlHourGlassUpdate));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
					}
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
			if (wrapProperty.p is TimeControl) {
				switch ((TimeControl.Property)wrapProperty.n) {
				case TimeControl.Property.isEnable:
					break;
				case TimeControl.Property.aiCanTimeOut:
					break;
				case TimeControl.Property.timeOutPlayers:
					break;
				case TimeControl.Property.sub:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case TimeControl.Property.use:
					break;
				case TimeControl.Property.timeReport:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is TimeControl.Sub) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}