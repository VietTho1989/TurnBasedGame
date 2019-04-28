using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class PlayUnPauseIdentity : DataIdentity
	{

		#region SyncVar

		#region time

		[SyncVar(hook="onChangeTime")]
		public System.Single time;

		public void onChangeTime(System.Single newTime)
		{
			this.time = newTime;
			if (this.netData.clientData != null) {
				this.netData.clientData.time.v = newTime;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region duration

		[SyncVar(hook="onChangeDuration")]
		public System.Single duration;

		public void onChangeDuration(System.Single newDuration)
		{
			this.duration = newDuration;
			if (this.netData.clientData != null) {
				this.netData.clientData.duration.v = newDuration;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<PlayUnPause> netData = new NetData<PlayUnPause>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeTime(this.time);
				this.onChangeDuration(this.duration);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.time);
				ret += GetDataSize (this.duration);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is PlayUnPause) {
				PlayUnPause playUnPause = data as PlayUnPause;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, playUnPause.makeSearchInforms ());
					this.time = playUnPause.time.v;
					this.duration = playUnPause.duration.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (playUnPause);
					} else {
						Debug.LogError ("observer null");
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is PlayUnPause) {
				// PlayUnPause playUnPause = data as PlayUnPause;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.setCheckChangeData (null);
					} else {
						Debug.LogError ("observer null");
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
			if (wrapProperty.p is PlayUnPause) {
				switch ((PlayUnPause.Property)wrapProperty.n) {
				case PlayUnPause.Property.human:
					break;
				case PlayUnPause.Property.time:
					this.time = (System.Single)wrapProperty.getValue ();
					break;
				case PlayUnPause.Property.duration:
					this.duration = (System.Single)wrapProperty.getValue ();
					break;
				default:
					Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion
	}
}