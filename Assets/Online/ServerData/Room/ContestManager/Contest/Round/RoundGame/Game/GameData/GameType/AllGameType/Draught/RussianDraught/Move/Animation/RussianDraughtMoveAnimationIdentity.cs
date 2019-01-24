using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
{
	public class RussianDraughtMoveAnimationIdentity : DataIdentity
	{

		#region SyncVar

		#region Board

		public SyncListInt Board = new SyncListInt();

		private void OnBoardChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.Board, this.Board, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
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

		private NetData<RussianDraughtMoveAnimation> netData = new NetData<RussianDraughtMoveAnimation>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.Board.Callback += OnBoardChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				IdentityUtils.refresh(this.netData.clientData.Board, this.Board);
				this.onChangeDuration (this.duration);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.Board);
				ret += GetDataSize (this.duration);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is RussianDraughtMoveAnimation) {
				RussianDraughtMoveAnimation russianDraughtMoveAnimation = data as RussianDraughtMoveAnimation;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, russianDraughtMoveAnimation.makeSearchInforms ());
					IdentityUtils.InitSync(this.Board, russianDraughtMoveAnimation.Board.vs);
					this.duration = russianDraughtMoveAnimation.duration.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (russianDraughtMoveAnimation);
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
			if (data is RussianDraughtMoveAnimation) {
				// RussianDraughtMoveAnimation russianDraughtMoveAnimation = data as RussianDraughtMoveAnimation;
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
			if (wrapProperty.p is RussianDraughtMoveAnimation) {
				switch ((RussianDraughtMoveAnimation.Property)wrapProperty.n) {
				case RussianDraughtMoveAnimation.Property.Board:
					IdentityUtils.UpdateSyncList (this.Board, syncs, GlobalCast<T>.CastingInt32);
					break;
				case RussianDraughtMoveAnimation.Property.move:
					break;
				case RussianDraughtMoveAnimation.Property.duration:
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