using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StepStartUpdate : UpdateBehavior<StepStart>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Log log = this.data.findDataInParent<Log> ();
					if (log != null) {
						StepGetData stepGetData = new StepGetData ();
						{
							stepGetData.uid = log.step.makeId ();
						}
						log.step.v = stepGetData;
					} else {
						Debug.LogError ("log null: " + this);
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
			if (data is StepStart) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is StepStart) {
				StepStart stepStart = data as StepStart;
				{

				}
				this.setDataNull (stepStart);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is StepStart) {
				switch ((StepStart.Property)wrapProperty.n) {
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