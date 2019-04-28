using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class BanqiMoveAnimationIdentity : DataIdentity
	{

		#region SyncVar

		#region fromX

		[SyncVar(hook="onChangeFromX")]
		public System.Int32 fromX;

		public void onChangeFromX(System.Int32 newFromX)
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
		public System.Int32 fromY;

		public void onChangeFromY(System.Int32 newFromY)
		{
			this.fromY = newFromY;
			if (this.netData.clientData != null) {
				this.netData.clientData.fromY.v = newFromY;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region destX

		[SyncVar(hook="onChangeDestX")]
		public System.Int32 destX;

		public void onChangeDestX(System.Int32 newDestX)
		{
			this.destX = newDestX;
			if (this.netData.clientData != null) {
				this.netData.clientData.destX.v = newDestX;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region destY

		[SyncVar(hook="onChangeDestY")]
		public System.Int32 destY;

		public void onChangeDestY(System.Int32 newDestY)
		{
			this.destY = newDestY;
			if (this.netData.clientData != null) {
				this.netData.clientData.destY.v = newDestY;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region state

		[SyncVar(hook="onChangeState")]
		public System.String state;

		public void onChangeState(System.String newState)
		{
			this.state = newState;
			if (this.netData.clientData != null) {
				this.netData.clientData.state.v = newState;
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

		private NetData<BanqiMoveAnimation> netData = new NetData<BanqiMoveAnimation>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeFromX(this.fromX);
				this.onChangeFromY(this.fromY);
				this.onChangeDestX(this.destX);
				this.onChangeDestY(this.destY);
				this.onChangeState(this.state);
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
				ret += GetDataSize (this.destX);
				ret += GetDataSize (this.destY);
				ret += GetDataSize (this.state);
				ret += GetDataSize (this.duration);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is BanqiMoveAnimation) {
				BanqiMoveAnimation banqiMoveAnimation = data as BanqiMoveAnimation;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, banqiMoveAnimation.makeSearchInforms ());
					this.fromX = banqiMoveAnimation.fromX.v;
					this.fromY = banqiMoveAnimation.fromY.v;
					this.destX = banqiMoveAnimation.destX.v;
					this.destY = banqiMoveAnimation.destY.v;
					this.state = banqiMoveAnimation.state.v;
					this.duration = banqiMoveAnimation.duration.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (banqiMoveAnimation);
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
			if (data is BanqiMoveAnimation) {
				// BanqiMoveAnimation banqiMoveAnimation = data as BanqiMoveAnimation;
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
			if (wrapProperty.p is BanqiMoveAnimation) {
				switch ((BanqiMoveAnimation.Property)wrapProperty.n) {
				case BanqiMoveAnimation.Property.fromX:
					this.fromX = (System.Int32)wrapProperty.getValue ();
					break;
				case BanqiMoveAnimation.Property.fromY:
					this.fromY = (System.Int32)wrapProperty.getValue ();
					break;
				case BanqiMoveAnimation.Property.destX:
					this.destX = (System.Int32)wrapProperty.getValue ();
					break;
				case BanqiMoveAnimation.Property.destY:
					this.destY = (System.Int32)wrapProperty.getValue ();
					break;
				case BanqiMoveAnimation.Property.state:
					this.state = (System.String)wrapProperty.getValue ();
					break;
				case BanqiMoveAnimation.Property.duration:
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