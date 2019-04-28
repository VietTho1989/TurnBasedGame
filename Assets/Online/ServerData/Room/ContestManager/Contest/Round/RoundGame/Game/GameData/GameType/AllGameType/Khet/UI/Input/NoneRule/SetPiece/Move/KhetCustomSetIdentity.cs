using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Khet.NoneRule
{
	public class KhetCustomSetIdentity : DataIdentity
	{

		#region SyncVar

		#region position

		[SyncVar(hook="onChangePosition")]
		public System.Int32 position;

		public void onChangePosition(System.Int32 newPosition)
		{
			this.position = newPosition;
			if (this.netData.clientData != null) {
				this.netData.clientData.position.v = newPosition;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region player

		[SyncVar(hook="onChangePlayer")]
		public Common.Player player;

		public void onChangePlayer(Common.Player newPlayer)
		{
			this.player = newPlayer;
			if (this.netData.clientData != null) {
				this.netData.clientData.player.v = newPlayer;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region piece

		[SyncVar(hook="onChangePiece")]
		public Common.Piece piece;

		public void onChangePiece(Common.Piece newPiece)
		{
			this.piece = newPiece;
			if (this.netData.clientData != null) {
				this.netData.clientData.piece.v = newPiece;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<KhetCustomSet> netData = new NetData<KhetCustomSet>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangePosition(this.position);
				this.onChangePlayer(this.player);
				this.onChangePiece(this.piece);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.position);
				ret += GetDataSize (this.player);
				ret += GetDataSize (this.piece);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is KhetCustomSet) {
				KhetCustomSet khetCustomSet = data as KhetCustomSet;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, khetCustomSet.makeSearchInforms ());
					this.position = khetCustomSet.position.v;
					this.player = khetCustomSet.player.v;
					this.piece = khetCustomSet.piece.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (khetCustomSet);
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
			if (data is KhetCustomSet) {
				// KhetCustomSet khetCustomSet = data as KhetCustomSet;
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
			if (wrapProperty.p is KhetCustomSet) {
				switch ((KhetCustomSet.Property)wrapProperty.n) {
				case KhetCustomSet.Property.position:
					this.position = (System.Int32)wrapProperty.getValue ();
					break;
				case KhetCustomSet.Property.player:
					this.player = (Common.Player)wrapProperty.getValue ();
					break;
				case KhetCustomSet.Property.piece:
					this.piece = (Common.Piece)wrapProperty.getValue ();
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