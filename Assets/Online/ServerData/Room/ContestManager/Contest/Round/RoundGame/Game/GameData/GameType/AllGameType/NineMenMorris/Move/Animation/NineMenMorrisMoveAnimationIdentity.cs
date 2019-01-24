using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
	public class NineMenMorrisMoveAnimationIdentity : DataIdentity
	{

		#region SyncVar

		#region moved

		[SyncVar(hook="onChangeMoved")]
		public System.Int32 moved;

		public void onChangeMoved(System.Int32 newMoved)
		{
			this.moved = newMoved;
			if (this.netData.clientData != null) {
				this.netData.clientData.moved.v = newMoved;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region moved_to

		[SyncVar(hook="onChangeMoved_to")]
		public System.Int32 moved_to;

		public void onChangeMoved_to(System.Int32 newMoved_to)
		{
			this.moved_to = newMoved_to;
			if (this.netData.clientData != null) {
				this.netData.clientData.moved_to.v = newMoved_to;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region action

		[SyncVar(hook="onChangeAction")]
		public Common.NMMAction action;

		public void onChangeAction(Common.NMMAction newAction)
		{
			this.action = newAction;
			if (this.netData.clientData != null) {
				this.netData.clientData.action.v = newAction;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region mill

		[SyncVar(hook="onChangeMill")]
		public System.Boolean mill;

		public void onChangeMill(System.Boolean newMill)
		{
			this.mill = newMill;
			if (this.netData.clientData != null) {
				this.netData.clientData.mill.v = newMill;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region removed

		[SyncVar(hook="onChangeRemoved")]
		public System.Int32 removed;

		public void onChangeRemoved(System.Int32 newRemoved)
		{
			this.removed = newRemoved;
			if (this.netData.clientData != null) {
				this.netData.clientData.removed.v = newRemoved;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region board

		public SyncListInt board = new SyncListInt();

		private void OnBoardChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.board, this.board, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region turn

		[SyncVar(hook="onChangeTurn")]
		public System.Int32 turn;

		public void onChangeTurn(System.Int32 newTurn)
		{
			this.turn = newTurn;
			if (this.netData.clientData != null) {
				this.netData.clientData.turn.v = newTurn;
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

		#region positioningDuration

		[SyncVar(hook="onChangePositioningDuration")]
		public System.Single positioningDuration;

		public void onChangePositioningDuration(System.Single newPositioningDuration)
		{
			this.positioningDuration = newPositioningDuration;
			if (this.netData.clientData != null) {
				this.netData.clientData.positioningDuration.v = newPositioningDuration;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region moveDuration

		[SyncVar(hook="onChangeMoveDuration")]
		public System.Single moveDuration;

		public void onChangeMoveDuration(System.Single newMoveDuration)
		{
			this.moveDuration = newMoveDuration;
			if (this.netData.clientData != null) {
				this.netData.clientData.moveDuration.v = newMoveDuration;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region removedDuration

		[SyncVar(hook="onChangeRemovedDuration")]
		public System.Single removedDuration;

		public void onChangeRemovedDuration(System.Single newRemovedDuration)
		{
			this.removedDuration = newRemovedDuration;
			if (this.netData.clientData != null) {
				this.netData.clientData.removedDuration.v = newRemovedDuration;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<NineMenMorrisMoveAnimation> netData = new NetData<NineMenMorrisMoveAnimation>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.board.Callback += OnBoardChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMoved(this.moved);
				this.onChangeMoved_to(this.moved_to);
				this.onChangeAction(this.action);
				this.onChangeMill(this.mill);
				this.onChangeRemoved(this.removed);
				IdentityUtils.refresh(this.netData.clientData.board, this.board);
				this.onChangeTurn(this.turn);
				this.onChangeDuration(this.duration);
				this.onChangePositioningDuration(this.positioningDuration);
				this.onChangeMoveDuration(this.moveDuration);
				this.onChangeRemovedDuration(this.removedDuration);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.moved);
				ret += GetDataSize (this.moved_to);
				ret += GetDataSize (this.action);
				ret += GetDataSize (this.mill);
				ret += GetDataSize (this.removed);
				ret += GetDataSize (this.board);
				ret += GetDataSize (this.turn);
				ret += GetDataSize (this.duration);
				ret += GetDataSize (this.positioningDuration);
				ret += GetDataSize (this.moveDuration);
				ret += GetDataSize (this.removedDuration);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is NineMenMorrisMoveAnimation) {
				NineMenMorrisMoveAnimation nineMenMorrisMoveAnimation = data as NineMenMorrisMoveAnimation;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, nineMenMorrisMoveAnimation.makeSearchInforms ());
					this.moved = nineMenMorrisMoveAnimation.moved.v;
					this.moved_to = nineMenMorrisMoveAnimation.moved_to.v;
					this.action = nineMenMorrisMoveAnimation.action.v;
					this.mill = nineMenMorrisMoveAnimation.mill.v;
					this.removed = nineMenMorrisMoveAnimation.removed.v;
					IdentityUtils.InitSync(this.board, nineMenMorrisMoveAnimation.board.vs);
					this.turn = nineMenMorrisMoveAnimation.turn.v;
					this.duration = nineMenMorrisMoveAnimation.duration.v;
					this.positioningDuration = nineMenMorrisMoveAnimation.positioningDuration.v;
					this.moveDuration = nineMenMorrisMoveAnimation.moveDuration.v;
					this.removedDuration = nineMenMorrisMoveAnimation.removedDuration.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (nineMenMorrisMoveAnimation);
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
			if (data is NineMenMorrisMoveAnimation) {
				// NineMenMorrisMoveAnimation nineMenMorrisMoveAnimation = data as NineMenMorrisMoveAnimation;
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
			if (wrapProperty.p is NineMenMorrisMoveAnimation) {
				switch ((NineMenMorrisMoveAnimation.Property)wrapProperty.n) {
				case NineMenMorrisMoveAnimation.Property.moved:
					this.moved = (System.Int32)wrapProperty.getValue ();
					break;
				case NineMenMorrisMoveAnimation.Property.moved_to:
					this.moved_to = (System.Int32)wrapProperty.getValue ();
					break;
				case NineMenMorrisMoveAnimation.Property.action:
					this.action = (Common.NMMAction)wrapProperty.getValue ();
					break;
				case NineMenMorrisMoveAnimation.Property.mill:
					this.mill = (System.Boolean)wrapProperty.getValue ();
					break;
				case NineMenMorrisMoveAnimation.Property.removed:
					this.removed = (System.Int32)wrapProperty.getValue ();
					break;
				case NineMenMorrisMoveAnimation.Property.board:
					IdentityUtils.UpdateSyncList (this.board, syncs, GlobalCast<T>.CastingInt32);
					break;
				case NineMenMorrisMoveAnimation.Property.turn:
					this.turn = (System.Int32)wrapProperty.getValue ();
					break;
				case NineMenMorrisMoveAnimation.Property.duration:
					this.duration = (System.Single)wrapProperty.getValue ();
					break;
				case NineMenMorrisMoveAnimation.Property.positioningDuration:
					this.positioningDuration = (System.Single)wrapProperty.getValue ();
					break;
				case NineMenMorrisMoveAnimation.Property.moveDuration:
					this.moveDuration = (System.Single)wrapProperty.getValue ();
					break;
				case NineMenMorrisMoveAnimation.Property.removedDuration:
					this.removedDuration = (System.Single)wrapProperty.getValue ();
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