using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught.NoneRule
{
	public class EnglishDraughtCustomMoveIdentity : DataIdentity
	{

		#region SyncVar

		#region fromSquare

		[SyncVar(hook="onChangeFromSquare")]
		public System.Int32 fromSquare;

		public void onChangeFromSquare(System.Int32 newFromSquare)
		{
			this.fromSquare = newFromSquare;
			if (this.netData.clientData != null) {
				this.netData.clientData.fromSquare.v = newFromSquare;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region destX

		[SyncVar(hook="onChangeDestSquare")]
		public System.Int32 destSquare;

		public void onChangeDestSquare(System.Int32 newDestSquare)
		{
			this.destSquare = newDestSquare;
			if (this.netData.clientData != null) {
				this.netData.clientData.destSquare.v = newDestSquare;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<EnglishDraughtCustomMove> netData = new NetData<EnglishDraughtCustomMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeFromSquare (this.fromSquare);
				this.onChangeDestSquare (this.destSquare);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.fromSquare);
				ret += GetDataSize (this.destSquare);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is EnglishDraughtCustomMove) {
				EnglishDraughtCustomMove englishDraughtCustomMove = data as EnglishDraughtCustomMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, englishDraughtCustomMove.makeSearchInforms ());
					this.fromSquare = englishDraughtCustomMove.fromSquare.v;
					this.destSquare = englishDraughtCustomMove.destSquare.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (englishDraughtCustomMove);
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
			if (data is EnglishDraughtCustomMove) {
				// EnglishDraughtCustomMove englishDraughtCustomMove = data as EnglishDraughtCustomMove;
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
			if (wrapProperty.p is EnglishDraughtCustomMove) {
				switch ((EnglishDraughtCustomMove.Property)wrapProperty.n) {
				case EnglishDraughtCustomMove.Property.fromSquare:
					this.fromSquare = (System.Int32)wrapProperty.getValue ();
					break;
				case EnglishDraughtCustomMove.Property.destSquare:
					this.destSquare = (System.Int32)wrapProperty.getValue ();
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