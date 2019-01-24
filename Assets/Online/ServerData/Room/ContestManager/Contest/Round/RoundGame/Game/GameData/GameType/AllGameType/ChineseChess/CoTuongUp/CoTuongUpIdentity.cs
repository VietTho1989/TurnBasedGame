using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp
{
	public class CoTuongUpIdentity : DataIdentity
	{

		#region SyncVar

		#region allowViewCapture

		[SyncVar(hook="onChangeAllowViewCapture")]
		public System.Boolean allowViewCapture;

		public void onChangeAllowViewCapture(System.Boolean newAllowViewCapture)
		{
			this.allowViewCapture = newAllowViewCapture;
			if (this.netData.clientData != null) {
				this.netData.clientData.allowViewCapture.v = newAllowViewCapture;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region allowWatcherViewHidden

		[SyncVar(hook="onChangeAllowWatcherViewHidden")]
		public System.Boolean allowWatcherViewHidden;

		public void onChangeAllowWatcherViewHidden(System.Boolean newAllowWatcherViewHidden)
		{
			this.allowWatcherViewHidden = newAllowWatcherViewHidden;
			if (this.netData.clientData != null) {
				this.netData.clientData.allowWatcherViewHidden.v = newAllowWatcherViewHidden;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region allowOnlyFlip

		[SyncVar(hook="onChangeAllowOnlyFlip")]
		public System.Boolean allowOnlyFlip;

		public void onChangeAllowOnlyFlip(System.Boolean newAllowOnlyFlip)
		{
			this.allowOnlyFlip = newAllowOnlyFlip;
			if (this.netData.clientData != null) {
				this.netData.clientData.allowOnlyFlip.v = newAllowOnlyFlip;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region plyDraw

		[SyncVar(hook="onChangePlyDraw")]
		public System.UInt32 plyDraw;

		public void onChangePlyDraw(System.UInt32 newPlyDraw)
		{
			this.plyDraw = newPlyDraw;
			if (this.netData.clientData != null) {
				this.netData.clientData.plyDraw.v = newPlyDraw;
			} else {
				// Debug.LogError ("clientData null: "+this);
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

		#region side

		[SyncVar(hook="onChangeSide")]
		public System.Byte side;

		public void onChangeSide(System.Byte newSide)
		{
			this.side = newSide;
			if (this.netData.clientData != null) {
				this.netData.clientData.side.v = newSide;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region nodes

		[SyncVar]
		public int nodes;

		#endregion

		#region isCustom

		[SyncVar(hook="onChangeIsCustom")]
		public bool isCustom;

		public void onChangeIsCustom(bool newIsCustom)
		{
			this.isCustom = newIsCustom;
			if (this.netData.clientData != null) {
				this.netData.clientData.isCustom.v = newIsCustom;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<CoTuongUp> netData = new NetData<CoTuongUp>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeAllowViewCapture (this.allowViewCapture);
				this.onChangeAllowWatcherViewHidden (this.allowWatcherViewHidden);
				this.onChangeAllowOnlyFlip (this.allowOnlyFlip);
				this.onChangePlyDraw (this.plyDraw);
				this.onChangeTurn (this.turn);
				this.onChangeSide (this.side);
				this.onChangeIsCustom (this.isCustom);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.allowViewCapture);
				ret += GetDataSize (this.allowWatcherViewHidden);
				ret += GetDataSize (this.allowOnlyFlip);
				ret += GetDataSize (this.plyDraw);
				ret += GetDataSize (this.turn);
				ret += GetDataSize (this.side);
				ret += GetDataSize (this.isCustom);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is CoTuongUp) {
				CoTuongUp coTuongUp = data as CoTuongUp;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, coTuongUp.makeSearchInforms ());
					this.allowWatcherViewHidden = coTuongUp.allowWatcherViewHidden.v;
					this.allowOnlyFlip = coTuongUp.allowOnlyFlip.v;
					this.plyDraw = coTuongUp.plyDraw.v;
					this.turn = coTuongUp.turn.v;
					this.side = coTuongUp.side.v;
					this.nodes = coTuongUp.nodes.vs.Count;
					this.isCustom = coTuongUp.isCustom.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (coTuongUp);
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
			if (data is CoTuongUp) {
				// CoTuongUp coTuongUp = data as CoTuongUp;
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
			if (wrapProperty.p is CoTuongUp) {
				switch ((CoTuongUp.Property)wrapProperty.n) {
				case CoTuongUp.Property.allowViewCapture:
					this.allowViewCapture = (System.Boolean)wrapProperty.getValue ();
					break;
				case CoTuongUp.Property.allowWatcherViewHidden:
					this.allowWatcherViewHidden = (System.Boolean)wrapProperty.getValue ();
					break;
				case CoTuongUp.Property.allowOnlyFlip:
					this.allowOnlyFlip = (System.Boolean)wrapProperty.getValue ();
					break;
				case CoTuongUp.Property.plyDraw:
					this.plyDraw = (System.UInt32)wrapProperty.getValue ();
					break;
				case CoTuongUp.Property.turn:
					this.turn = (System.Int32)wrapProperty.getValue ();
					break;
				case CoTuongUp.Property.side:
					this.side = (System.Byte)wrapProperty.getValue ();
					break;
				case CoTuongUp.Property.nodes:
					{
						CoTuongUp coTuongUp = wrapProperty.p as CoTuongUp;
						this.nodes = coTuongUp.nodes.vs.Count;
					}
					break;
				case CoTuongUp.Property.isCustom:
					this.isCustom = (bool)wrapProperty.getValue ();
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