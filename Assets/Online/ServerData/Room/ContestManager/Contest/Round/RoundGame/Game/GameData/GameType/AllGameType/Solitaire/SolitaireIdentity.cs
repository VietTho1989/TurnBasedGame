using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireIdentity : DataIdentity
	{

		#region SyncVar

		#region movesAvailableCount

		[SyncVar(hook="onChangeMovesAvailableCount")]
		public System.Int32 movesAvailableCount;

		public void onChangeMovesAvailableCount(System.Int32 newMovesAvailableCount)
		{
			this.movesAvailableCount = newMovesAvailableCount;
			if (this.netData.clientData != null) {
				this.netData.clientData.movesAvailableCount.v = newMovesAvailableCount;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region drawCount

		[SyncVar(hook="onChangeDrawCount")]
		public System.Int32 drawCount;

		public void onChangeDrawCount(System.Int32 newDrawCount)
		{
			this.drawCount = newDrawCount;
			if (this.netData.clientData != null) {
				this.netData.clientData.drawCount.v = newDrawCount;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region roundCount

		[SyncVar(hook="onChangeRoundCount")]
		public System.Int32 roundCount;

		public void onChangeRoundCount(System.Int32 newRoundCount)
		{
			this.roundCount = newRoundCount;
			if (this.netData.clientData != null) {
				this.netData.clientData.roundCount.v = newRoundCount;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region foundationCount

		[SyncVar(hook="onChangeFoundationCount")]
		public System.Int32 foundationCount;

		public void onChangeFoundationCount(System.Int32 newFoundationCount)
		{
			this.foundationCount = newFoundationCount;
			if (this.netData.clientData != null) {
				this.netData.clientData.foundationCount.v = newFoundationCount;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<Solitaire> netData = new NetData<Solitaire>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMovesAvailableCount(this.movesAvailableCount);
				this.onChangeDrawCount(this.drawCount);
				this.onChangeRoundCount(this.roundCount);
				this.onChangeFoundationCount(this.foundationCount);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.movesAvailableCount);
				ret += GetDataSize (this.drawCount);
				ret += GetDataSize (this.roundCount);
				ret += GetDataSize (this.foundationCount);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is Solitaire) {
				Solitaire solitaire = data as Solitaire;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, solitaire.makeSearchInforms ());
					this.movesAvailableCount = solitaire.movesAvailableCount.v;
					this.drawCount = solitaire.drawCount.v;
					this.roundCount = solitaire.roundCount.v;
					this.foundationCount = solitaire.foundationCount.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (solitaire);
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
			if (data is Solitaire) {
				// Solitaire solitaire = data as Solitaire;
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
			if (wrapProperty.p is Solitaire) {
				switch ((Solitaire.Property)wrapProperty.n) {
				case Solitaire.Property.piles:
					break;
				case Solitaire.Property.cards:
					break;
				case Solitaire.Property.movesAvailable:
					break;
				case Solitaire.Property.movesAvailableCount:
					this.movesAvailableCount = (System.Int32)wrapProperty.getValue ();
					break;
				case Solitaire.Property.drawCount:
					this.drawCount = (System.Int32)wrapProperty.getValue ();
					break;
				case Solitaire.Property.roundCount:
					this.roundCount = (System.Int32)wrapProperty.getValue ();
					break;
				case Solitaire.Property.foundationCount:
					this.foundationCount = (System.Int32)wrapProperty.getValue ();
					break;
				case Solitaire.Property.solvedMoves:
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