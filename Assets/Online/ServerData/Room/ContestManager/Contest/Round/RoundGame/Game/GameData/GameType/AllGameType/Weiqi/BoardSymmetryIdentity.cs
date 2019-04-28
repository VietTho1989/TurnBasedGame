using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
	public class BoardSymmetryIdentity : DataIdentity
	{

		#region SyncVar

		#region x1

		[SyncVar(hook="onChangeX1")]
		public System.Int32 x1;

		public void onChangeX1(System.Int32 newX1)
		{
			this.x1 = newX1;
			if (this.netData.clientData != null) {
				this.netData.clientData.x1.v = newX1;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region x2

		[SyncVar(hook="onChangeX2")]
		public System.Int32 x2;

		public void onChangeX2(System.Int32 newX2)
		{
			this.x2 = newX2;
			if (this.netData.clientData != null) {
				this.netData.clientData.x2.v = newX2;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region y1

		[SyncVar(hook="onChangeY1")]
		public System.Int32 y1;

		public void onChangeY1(System.Int32 newY1)
		{
			this.y1 = newY1;
			if (this.netData.clientData != null) {
				this.netData.clientData.y1.v = newY1;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region y2

		[SyncVar(hook="onChangeY2")]
		public System.Int32 y2;

		public void onChangeY2(System.Int32 newY2)
		{
			this.y2 = newY2;
			if (this.netData.clientData != null) {
				this.netData.clientData.y2.v = newY2;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region d

		[SyncVar(hook="onChangeD")]
		public System.Int32 d;

		public void onChangeD(System.Int32 newD)
		{
			this.d = newD;
			if (this.netData.clientData != null) {
				this.netData.clientData.d.v = newD;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region type

		[SyncVar(hook="onChangeType")]
		public System.Int32 type;

		public void onChangeType(System.Int32 newType)
		{
			this.type = newType;
			if (this.netData.clientData != null) {
				this.netData.clientData.type.v = newType;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<BoardSymmetry> netData = new NetData<BoardSymmetry>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeX1(this.x1);
				this.onChangeX2(this.x2);
				this.onChangeY1(this.y1);
				this.onChangeY2(this.y2);
				this.onChangeD(this.d);
				this.onChangeType(this.type);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.x1);
				ret += GetDataSize (this.x2);
				ret += GetDataSize (this.y1);
				ret += GetDataSize (this.y2);
				ret += GetDataSize (this.d);
				ret += GetDataSize (this.type);
				return ret;
			}
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is BoardSymmetry) {
				BoardSymmetry boardSymmetry = data as BoardSymmetry;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, boardSymmetry.makeSearchInforms ());
					this.x1 = boardSymmetry.x1.v;
					this.x2 = boardSymmetry.x2.v;
					this.y1 = boardSymmetry.y1.v;
					this.y2 = boardSymmetry.y2.v;
					this.d = boardSymmetry.d.v;
					this.type = boardSymmetry.type.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (boardSymmetry);
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
			if (data is BoardSymmetry) {
				// BoardSymmetry boardSymmetry = data as BoardSymmetry;
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
			if (wrapProperty.p is BoardSymmetry) {
				switch ((BoardSymmetry.Property)wrapProperty.n) {
				case BoardSymmetry.Property.x1:
					this.x1 = (System.Int32)wrapProperty.getValue ();
					break;
				case BoardSymmetry.Property.x2:
					this.x2 = (System.Int32)wrapProperty.getValue ();
					break;
				case BoardSymmetry.Property.y1:
					this.y1 = (System.Int32)wrapProperty.getValue ();
					break;
				case BoardSymmetry.Property.y2:
					this.y2 = (System.Int32)wrapProperty.getValue ();
					break;
				case BoardSymmetry.Property.d:
					this.d = (System.Int32)wrapProperty.getValue ();
					break;
				case BoardSymmetry.Property.type:
					this.type = (System.Int32)wrapProperty.getValue ();
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