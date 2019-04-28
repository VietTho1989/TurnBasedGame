using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
	public class InternationalDraughtMoveAnimationIdentity : DataIdentity
	{

		#region SyncVar

		#region move

		[SyncVar(hook="onChangeMove")]
		public System.UInt64 move;

		public void onChangeMove(System.UInt64 newMove)
		{
			this.move = newMove;
			if (this.netData.clientData != null) {
				this.netData.clientData.move.v = newMove;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region duration

		[SyncVar(hook="onChangeDuration")]
		public float duration;

		public void onChangeDuration(float newDuration)
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

		private NetData<InternationalDraughtMoveAnimation> netData = new NetData<InternationalDraughtMoveAnimation>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMove (this.move);
				this.onChangeDuration (this.duration);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.move);
				ret += GetDataSize (this.duration);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is InternationalDraughtMoveAnimation) {
				InternationalDraughtMoveAnimation internationalDraughtMoveAnimation = data as InternationalDraughtMoveAnimation;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, internationalDraughtMoveAnimation.makeSearchInforms ());
					this.move = internationalDraughtMoveAnimation.move.v;
					this.duration = internationalDraughtMoveAnimation.duration.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (internationalDraughtMoveAnimation);
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
			if (data is InternationalDraughtMoveAnimation) {
				// InternationalDraughtMoveAnimation internationalDraughtMoveAnimation = data as InternationalDraughtMoveAnimation;
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
			if (wrapProperty.p is InternationalDraughtMoveAnimation) {
				switch ((InternationalDraughtMoveAnimation.Property)wrapProperty.n) {
				case InternationalDraughtMoveAnimation.Property.pos:
					break;
				case InternationalDraughtMoveAnimation.Property.move:
					this.move = (System.UInt64)wrapProperty.getValue ();
					break;
				case InternationalDraughtMoveAnimation.Property.duration:
					this.duration = (float)wrapProperty.getValue ();
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