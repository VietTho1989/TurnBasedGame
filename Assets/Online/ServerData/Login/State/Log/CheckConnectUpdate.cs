using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class CheckConnectUpdate : UpdateBehavior<Log>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					bool isConnect = FindObjectOfType<ClientConnectIdentity> () != null;
					if (isConnect) {
						if (!(this.data.connectState.v is HaveConnect)) {
							HaveConnect haveConnect = new HaveConnect ();
							{
								haveConnect.uid = this.data.connectState.makeId ();
							}
							this.data.connectState.v = haveConnect;
						}
					} else {
						if (!(this.data.connectState.v is NotConnect)) {
							NotConnect notConnect = new NotConnect ();
							{
								notConnect.uid = this.data.connectState.makeId ();
							}
							this.data.connectState.v = notConnect;
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
			if (data is Log) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Log) {
				Log log = data as Log;
				{

				}
				this.setDataNull (log);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is Log) {
				switch ((Log.Property)wrapProperty.n) {
				case Log.Property.connectState:
					dirty = true;
					break;
				case Log.Property.step:
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
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}