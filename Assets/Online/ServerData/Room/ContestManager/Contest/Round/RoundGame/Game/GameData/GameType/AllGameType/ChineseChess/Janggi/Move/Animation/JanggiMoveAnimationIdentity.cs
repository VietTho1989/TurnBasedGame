using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
	public class JanggiMoveAnimationIdentity : DataIdentity
	{

		#region SyncVar

		#region fromX

		[SyncVar(hook="onChangeFromX")]
		public System.SByte fromX;

		public void onChangeFromX(System.SByte newFromX)
		{
			this.fromX = newFromX;
			if (this.netData.clientData != null) {
				this.netData.clientData.fromX.v = newFromX;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region fromY

		[SyncVar(hook="onChangeFromY")]
		public System.SByte fromY;

		public void onChangeFromY(System.SByte newFromY)
		{
			this.fromY = newFromY;
			if (this.netData.clientData != null) {
				this.netData.clientData.fromY.v = newFromY;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region toX

		[SyncVar(hook="onChangeToX")]
		public System.SByte toX;

		public void onChangeToX(System.SByte newToX)
		{
			this.toX = newToX;
			if (this.netData.clientData != null) {
				this.netData.clientData.toX.v = newToX;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region toY

		[SyncVar(hook="onChangeToY")]
		public System.SByte toY;

		public void onChangeToY(System.SByte newToY)
		{
			this.toY = newToY;
			if (this.netData.clientData != null) {
				this.netData.clientData.toY.v = newToY;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region stones

		public SyncListUInt stones = new SyncListUInt();

		private void OnStonesChanged(SyncListUInt.Operation op, int index)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.stones, this.stones, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
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

		private NetData<JanggiMoveAnimation> netData = new NetData<JanggiMoveAnimation>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.stones.Callback += OnStonesChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeFromX(this.fromX);
				this.onChangeFromY(this.fromY);
				this.onChangeToX(this.toX);
				this.onChangeToY(this.toY);
				IdentityUtils.refresh(this.netData.clientData.stones, this.stones);
				this.onChangeDuration(this.duration);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.fromX);
				ret += GetDataSize (this.fromY);
				ret += GetDataSize (this.toX);
				ret += GetDataSize (this.toY);
				ret += GetDataSize (this.stones);
				ret += GetDataSize (this.duration);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is JanggiMoveAnimation) {
				JanggiMoveAnimation janggiMoveAnimation = data as JanggiMoveAnimation;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, janggiMoveAnimation.makeSearchInforms ());
					this.fromX = janggiMoveAnimation.fromX.v;
					this.fromY = janggiMoveAnimation.fromY.v;
					this.toX = janggiMoveAnimation.toX.v;
					this.toY = janggiMoveAnimation.toY.v;
					IdentityUtils.InitSync(this.stones, janggiMoveAnimation.stones.vs);
					this.duration = janggiMoveAnimation.duration.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (janggiMoveAnimation);
					} else {
						Debug.LogError ("observer null: " + this);
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is JanggiMoveAnimation) {
				// JanggiMoveAnimation janggiMoveAnimation = data as JanggiMoveAnimation;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.setCheckChangeData (null);
					} else {
						Debug.LogError ("observer null: " + this);
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
			if (wrapProperty.p is JanggiMoveAnimation) {
				switch ((JanggiMoveAnimation.Property)wrapProperty.n) {
				case JanggiMoveAnimation.Property.fromX:
					this.fromX = (System.SByte)wrapProperty.getValue ();
					break;
				case JanggiMoveAnimation.Property.fromY:
					this.fromY = (System.SByte)wrapProperty.getValue ();
					break;
				case JanggiMoveAnimation.Property.toX:
					this.toX = (System.SByte)wrapProperty.getValue ();
					break;
				case JanggiMoveAnimation.Property.toY:
					this.toY = (System.SByte)wrapProperty.getValue ();
					break;
				case JanggiMoveAnimation.Property.stones:
					IdentityUtils.UpdateSyncList (this.stones, syncs, GlobalCast<T>.CastingUInt32);
					break;
				case JanggiMoveAnimation.Property.duration:
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