using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Janggi.NoneRule
{
	public class JanggiCustomSetIdentity : DataIdentity
	{

		#region SyncVar

		#region x

		[SyncVar(hook="onChangeX")]
		public System.Int32 x;

		public void onChangeX(System.Int32 newX)
		{
			this.x = newX;
			if (this.netData.clientData != null) {
				this.netData.clientData.x.v = newX;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region y

		[SyncVar(hook="onChangeY")]
		public System.Int32 y;

		public void onChangeY(System.Int32 newY)
		{
			this.y = newY;
			if (this.netData.clientData != null) {
				this.netData.clientData.y.v = newY;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region piece

		[SyncVar(hook="onChangePiece")]
		public StoneHelper.Stones piece;

		public void onChangePiece(StoneHelper.Stones newPiece)
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

		private NetData<JanggiCustomSet> netData = new NetData<JanggiCustomSet>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeX(this.x);
				this.onChangeY(this.y);
				this.onChangePiece(this.piece);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.x);
				ret += GetDataSize (this.y);
				ret += GetDataSize (this.piece);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is JanggiCustomSet) {
				JanggiCustomSet janggiCustomSet = data as JanggiCustomSet;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, janggiCustomSet.makeSearchInforms ());
					this.x = janggiCustomSet.x.v;
					this.y = janggiCustomSet.y.v;
					this.piece = janggiCustomSet.piece.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (janggiCustomSet);
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
			if (data is JanggiCustomSet) {
				// JanggiCustomSet janggiCustomSet = data as JanggiCustomSet;
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
			if (wrapProperty.p is JanggiCustomSet) {
				switch ((JanggiCustomSet.Property)wrapProperty.n) {
				case JanggiCustomSet.Property.x:
					this.x = (System.Int32)wrapProperty.getValue ();
					break;
				case JanggiCustomSet.Property.y:
					this.y = (System.Int32)wrapProperty.getValue ();
					break;
				case JanggiCustomSet.Property.piece:
					this.piece = (StoneHelper.Stones)wrapProperty.getValue ();
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}