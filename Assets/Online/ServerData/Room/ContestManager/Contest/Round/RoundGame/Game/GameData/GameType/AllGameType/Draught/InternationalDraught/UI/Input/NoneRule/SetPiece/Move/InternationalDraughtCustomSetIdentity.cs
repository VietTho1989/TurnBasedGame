using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught.NoneRule
{
	public class InternationalDraughtCustomSetIdentity : DataIdentity
	{

		#region SyncVar

		#region square

		[SyncVar(hook="onChangeSquare")]
		public System.Int32 square;

		public void onChangeSquare(System.Int32 newSquare)
		{
			this.square = newSquare;
			if (this.netData.clientData != null) {
				this.netData.clientData.square.v = newSquare;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region piece

		[SyncVar(hook="onChangePieceSide")]
		public Common.Piece_Side pieceSide;

		public void onChangePieceSide(Common.Piece_Side newPieceSide)
		{
			this.pieceSide = newPieceSide;
			if (this.netData.clientData != null) {
				this.netData.clientData.pieceSide.v = newPieceSide;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<InternationalDraughtCustomSet> netData = new NetData<InternationalDraughtCustomSet>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeSquare (this.square);
				this.onChangePieceSide (this.pieceSide);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.square);
				ret += GetDataSize (this.pieceSide);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is InternationalDraughtCustomSet) {
				InternationalDraughtCustomSet internationalDraughtCustomSet = data as InternationalDraughtCustomSet;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, internationalDraughtCustomSet.makeSearchInforms ());
					this.square = internationalDraughtCustomSet.square.v;
					this.pieceSide = internationalDraughtCustomSet.pieceSide.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (internationalDraughtCustomSet);
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
			if (data is InternationalDraughtCustomSet) {
				// InternationalDraughtCustomSet internationalDraughtCustomSet = data as InternationalDraughtCustomSet;
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
			if (wrapProperty.p is InternationalDraughtCustomSet) {
				switch ((InternationalDraughtCustomSet.Property)wrapProperty.n) {
				case InternationalDraughtCustomSet.Property.square:
					this.square = (System.Int32)wrapProperty.getValue ();
					break;
				case InternationalDraughtCustomSet.Property.pieceSide:
					this.pieceSide = (Common.Piece_Side)wrapProperty.getValue ();
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