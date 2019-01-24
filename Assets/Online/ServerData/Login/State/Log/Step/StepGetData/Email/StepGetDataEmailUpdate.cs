using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StepGetDataEmailUpdate : UpdateBehavior<StepGetDataEmail>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// chuyen sange login step
					{
						Log log = this.data.findDataInParent<Log> ();
						if (log != null) {
							StepLogin stepLogin = new StepLogin ();
							{
								stepLogin.uid = log.step.makeId ();
							}
							log.step.v = stepLogin;
						} else {
							Debug.LogError ("log null: " + this);
						}
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
			if (data is StepGetDataEmail) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is StepGetDataEmail) {
				StepGetDataEmail stepGetDataEmail = data as StepGetDataEmail;
				{

				}
				this.setDataNull (stepGetDataEmail);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is StepGetDataEmail) {
				switch ((StepGetDataEmail.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't porcess: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}