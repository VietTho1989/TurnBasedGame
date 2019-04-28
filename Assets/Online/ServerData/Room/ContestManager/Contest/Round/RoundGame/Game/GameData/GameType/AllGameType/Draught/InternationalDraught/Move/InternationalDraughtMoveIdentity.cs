using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
	public class InternationalDraughtMoveIdentity : DataIdentity
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

		#endregion

		#region NetData

		private NetData<InternationalDraughtMove> netData = new NetData<InternationalDraughtMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMove(this.move);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.move);
				return ret;
			}
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is InternationalDraughtMove) {
				InternationalDraughtMove internationalDraughtMove = data as InternationalDraughtMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, internationalDraughtMove.makeSearchInforms ());
					this.move = internationalDraughtMove.move.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (internationalDraughtMove);
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
			if (data is InternationalDraughtMove) {
				// InternationalDraughtMove internationalDraughtMove = data as InternationalDraughtMove;
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
			if (wrapProperty.p is InternationalDraughtMove) {
				switch ((InternationalDraughtMove.Property)wrapProperty.n) {
				case InternationalDraughtMove.Property.move:
					this.move = (System.UInt64)wrapProperty.getValue ();
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