using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class LogUpdate : UpdateBehavior<Log>
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
			if (data is Log) {
				Log log = data as Log;
				// Update
				{
					UpdateUtils.makeUpdate<CheckConnectUpdate, Log> (log, this.transform);
					UpdateUtils.makeUpdate<CheckTimeOutUpdate, Log> (log, this.transform);
				}
				// Child
				{
					log.connectState.allAddCallBack (this);
					log.step.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Log.ConnectState) {
					Log.ConnectState connectState = data as Log.ConnectState;
					// Update
					{
						switch (connectState.getType ()) {
						case Log.ConnectState.Type.NotConnect:
							{
								NotConnect notConnect = connectState as NotConnect;
								UpdateUtils.makeUpdate<NotConnectUpdate, NotConnect> (notConnect, this.transform);
							}
							break;
						case Log.ConnectState.Type.HaveConnect:
							{
								HaveConnect haveConnect = connectState as HaveConnect;
								UpdateUtils.makeUpdate<HaveConnectUpdate, HaveConnect> (haveConnect, this.transform);
							}
							break;
						default:
							Debug.LogError ("Unknown type: " + connectState.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				if (data is Log.Step) {
					Log.Step step = data as Log.Step;
					// Update
					{
						switch (step.getType ()) {
						case Log.Step.Type.Start:
							{
								StepStart stepStart = step as StepStart;
								UpdateUtils.makeUpdate<StepStartUpdate, StepStart> (stepStart, this.transform);
							}
							break;
						case Log.Step.Type.GetData:
							{
								StepGetData stepGetData = step as StepGetData;
								UpdateUtils.makeUpdate<StepGetDataUpdate, StepGetData> (stepGetData, this.transform);
							}
							break;
						case Log.Step.Type.Login:
							{
								StepLogin stepLogin = step as StepLogin;
								UpdateUtils.makeUpdate<StepLoginUpdate, StepLogin> (stepLogin, this.transform);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + step.getType () + "; " + this);
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
			if (data is Log) {
				Log log = data as Log;
				// Update
				{
					log.removeCallBackAndDestroy (typeof(CheckConnectUpdate));
					log.removeCallBackAndDestroy (typeof(CheckTimeOutUpdate));
				}
				// Child
				{
					log.connectState.allRemoveCallBack (this);
					log.step.allRemoveCallBack (this);
				}
				this.setDataNull (log);
				return;
			}
			// Child
			{
				if (data is Log.ConnectState) {
					Log.ConnectState connectState = data as Log.ConnectState;
					// Update
					{
						switch (connectState.getType ()) {
						case Log.ConnectState.Type.NotConnect:
							{
								NotConnect notConnect = connectState as NotConnect;
								notConnect.removeCallBackAndDestroy (typeof(NotConnectUpdate));
							}
							break;
						case Log.ConnectState.Type.HaveConnect:
							{
								HaveConnect haveConnect = connectState as HaveConnect;
								haveConnect.removeCallBackAndDestroy (typeof(HaveConnectUpdate));
							}
							break;
						default:
							Debug.LogError ("Unknown type: " + connectState.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is Log.Step) {
					Log.Step step = data as Log.Step;
					// Update
					{
						switch (step.getType ()) {
						case Log.Step.Type.Start:
							{
								StepStart stepStart = step as StepStart;
								stepStart.removeCallBackAndDestroy (typeof(StepStartUpdate));
							}
							break;
						case Log.Step.Type.GetData:
							{
								StepGetData stepGetData = step as StepGetData;
								stepGetData.removeCallBackAndDestroy (typeof(StepGetDataUpdate));
							}
							break;
						case Log.Step.Type.Login:
							{
								StepLogin stepLogin = step as StepLogin;
								stepLogin.removeCallBackAndDestroy (typeof(StepLoginUpdate));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + step.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if(WrapProperty.checkError(wrapProperty)){
				return;
			}
			if (wrapProperty.p is Log) {
				switch ((Log.Property)wrapProperty.n) {
				case Log.Property.connectState:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Log.Property.step:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Log.Property.time:
					break;
				case Log.Property.timeOut:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is Log.ConnectState) {
					return;
				}
				if (wrapProperty.p is Log.Step) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}