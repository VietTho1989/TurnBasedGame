using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireMoveIdentity : DataIdentity
	{

		#region SyncVar

		#region From

		[SyncVar(hook="onChangeFrom")]
		public System.Byte From;

		public void onChangeFrom(System.Byte newFrom)
		{
			this.From = newFrom;
			if (this.netData.clientData != null) {
				this.netData.clientData.From.v = newFrom;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region To

		[SyncVar(hook="onChangeTo")]
		public System.Byte To;

		public void onChangeTo(System.Byte newTo)
		{
			this.To = newTo;
			if (this.netData.clientData != null) {
				this.netData.clientData.To.v = newTo;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region Count

		[SyncVar(hook="onChangeCount")]
		public System.Byte Count;

		public void onChangeCount(System.Byte newCount)
		{
			this.Count = newCount;
			if (this.netData.clientData != null) {
				this.netData.clientData.Count.v = newCount;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region Extra

		[SyncVar(hook="onChangeExtra")]
		public System.Byte Extra;

		public void onChangeExtra(System.Byte newExtra)
		{
			this.Extra = newExtra;
			if (this.netData.clientData != null) {
				this.netData.clientData.Extra.v = newExtra;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<SolitaireMove> netData = new NetData<SolitaireMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeFrom(this.From);
				this.onChangeTo(this.To);
				this.onChangeCount(this.Count);
				this.onChangeExtra(this.Extra);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.From);
				ret += GetDataSize (this.To);
				ret += GetDataSize (this.Count);
				ret += GetDataSize (this.Extra);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is SolitaireMove) {
				SolitaireMove solitaireMove = data as SolitaireMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, solitaireMove.makeSearchInforms ());
					this.From = solitaireMove.From.v;
					this.To = solitaireMove.To.v;
					this.Count = solitaireMove.Count.v;
					this.Extra = solitaireMove.Extra.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (solitaireMove);
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
			if (data is SolitaireMove) {
				// SolitaireMove solitaireMove = data as SolitaireMove;
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
			if (wrapProperty.p is SolitaireMove) {
				switch ((SolitaireMove.Property)wrapProperty.n) {
				case SolitaireMove.Property.From:
					this.From = (System.Byte)wrapProperty.getValue ();
					break;
				case SolitaireMove.Property.To:
					this.To = (System.Byte)wrapProperty.getValue ();
					break;
				case SolitaireMove.Property.Count:
					this.Count = (System.Byte)wrapProperty.getValue ();
					break;
				case SolitaireMove.Property.Extra:
					this.Extra = (System.Byte)wrapProperty.getValue ();
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