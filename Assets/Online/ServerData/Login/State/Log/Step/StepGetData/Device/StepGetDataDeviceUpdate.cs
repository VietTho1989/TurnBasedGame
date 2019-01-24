using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StepGetDataDeviceUpdate : UpdateBehavior<StepGetDataDevice>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Login login = this.data.findDataInParent<Login> ();
					if (login != null) {
						if (login.account.v != null && login.account.v is AccountDevice) {
							{
								AccountDevice accountDevice = login.account.v as AccountDevice;
								accountDevice.imei.v = SystemInfo.deviceUniqueIdentifier;
								accountDevice.deviceName.v = SystemInfo.deviceName;
								accountDevice.deviceType.v = (int)SystemInfo.deviceType;
							}
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
						}
					} else {
						Debug.LogError ("login null: " + this);
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
			if (data is StepGetDataDevice) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is StepGetDataDevice) {
				StepGetDataDevice stepGetDataDevice = data as StepGetDataDevice;
				{

				}
				this.setDataNull (stepGetDataDevice);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is StepGetDataDevice) {
				switch ((StepGetDataDevice.Property)wrapProperty.n) {
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