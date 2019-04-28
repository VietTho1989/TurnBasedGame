using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
	public class NineMenMorrisMoveIdentity : DataIdentity
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

		#endregion

		#region NetData

		private NetData<NineMenMorrisMove> netData = new NetData<NineMenMorrisMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMoved(this.moved);
				this.onChangeMoved_to(this.moved_to);
				this.onChangeAction(this.action);
				this.onChangeMill(this.mill);
				this.onChangeRemoved(this.removed);
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
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is NineMenMorrisMove) {
				NineMenMorrisMove nineMenMorrisMove = data as NineMenMorrisMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, nineMenMorrisMove.makeSearchInforms ());
					this.moved = nineMenMorrisMove.moved.v;
					this.moved_to = nineMenMorrisMove.moved_to.v;
					this.action = nineMenMorrisMove.action.v;
					this.mill = nineMenMorrisMove.mill.v;
					this.removed = nineMenMorrisMove.removed.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (nineMenMorrisMove);
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
			if (data is NineMenMorrisMove) {
				// NineMenMorrisMove nineMenMorrisMove = data as NineMenMorrisMove;
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
			if (wrapProperty.p is NineMenMorrisMove) {
				switch ((NineMenMorrisMove.Property)wrapProperty.n) {
				case NineMenMorrisMove.Property.moved:
					this.moved = (System.Int32)wrapProperty.getValue ();
					break;
				case NineMenMorrisMove.Property.moved_to:
					this.moved_to = (System.Int32)wrapProperty.getValue ();
					break;
				case NineMenMorrisMove.Property.action:
					this.action = (Common.NMMAction)wrapProperty.getValue ();
					break;
				case NineMenMorrisMove.Property.mill:
					this.mill = (System.Boolean)wrapProperty.getValue ();
					break;
				case NineMenMorrisMove.Property.removed:
					this.removed = (System.Int32)wrapProperty.getValue ();
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