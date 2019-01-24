using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class LaserIdentity : DataIdentity
	{

		#region SyncVar

		#region _targetIndex

		[SyncVar(hook="onChange_targetIndex")]
		public System.Int32 _targetIndex;

		public void onChange_targetIndex(System.Int32 new_targetIndex)
		{
			this._targetIndex = new_targetIndex;
			if (this.netData.clientData != null) {
				this.netData.clientData._targetIndex.v = new_targetIndex;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region _targetSquare

		[SyncVar(hook="onChange_targetSquare")]
		public System.Byte _targetSquare;

		public void onChange_targetSquare(System.Byte new_targetSquare)
		{
			this._targetSquare = new_targetSquare;
			if (this.netData.clientData != null) {
				this.netData.clientData._targetSquare.v = new_targetSquare;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region _targetPiece

		[SyncVar(hook="onChange_targetPiece")]
		public System.Int32 _targetPiece;

		public void onChange_targetPiece(System.Int32 new_targetPiece)
		{
			this._targetPiece = new_targetPiece;
			if (this.netData.clientData != null) {
				this.netData.clientData._targetPiece.v = new_targetPiece;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<Laser> netData = new NetData<Laser>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChange_targetIndex(this._targetIndex);
				this.onChange_targetSquare(this._targetSquare);
				this.onChange_targetPiece(this._targetPiece);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this._targetIndex);
				ret += GetDataSize (this._targetSquare);
				ret += GetDataSize (this._targetPiece);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is Laser) {
				Laser laser = data as Laser;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, laser.makeSearchInforms ());
					this._targetIndex = laser._targetIndex.v;
					this._targetSquare = laser._targetSquare.v;
					this._targetPiece = laser._targetPiece.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (laser);
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
			if (data is Laser) {
				// Laser laser = data as Laser;
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
			if (wrapProperty.p is Laser) {
				switch ((Laser.Property)wrapProperty.n) {
				case Laser.Property._targetIndex:
					this._targetIndex = (System.Int32)wrapProperty.getValue ();
					break;
				case Laser.Property._targetSquare:
					this._targetSquare = (System.Byte)wrapProperty.getValue ();
					break;
				case Laser.Property._targetPiece:
					this._targetPiece = (System.Int32)wrapProperty.getValue ();
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