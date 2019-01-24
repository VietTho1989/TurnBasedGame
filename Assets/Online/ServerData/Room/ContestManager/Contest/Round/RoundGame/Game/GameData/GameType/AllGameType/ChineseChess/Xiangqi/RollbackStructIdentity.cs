using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
	public class RollbackStructIdentity : DataIdentity
	{

		#region SyncVar

		#region vlWhite

		[SyncVar(hook="onChangeVlWhite")]
		public System.Int32 vlWhite;

		public void onChangeVlWhite(System.Int32 newVlWhite)
		{
			this.vlWhite = newVlWhite;
			if (this.netData.clientData != null) {
				this.netData.clientData.vlWhite.v = newVlWhite;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region vlBlack

		[SyncVar(hook="onChangeVlBlack")]
		public System.Int32 vlBlack;

		public void onChangeVlBlack(System.Int32 newVlBlack)
		{
			this.vlBlack = newVlBlack;
			if (this.netData.clientData != null) {
				this.netData.clientData.vlBlack.v = newVlBlack;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region mvs

		[SyncVar(hook="onChangeMvs")]
		public System.UInt32 mvs;

		public void onChangeMvs(System.UInt32 newMvs)
		{
			this.mvs = newMvs;
			if (this.netData.clientData != null) {
				this.netData.clientData.mvs.v = newMvs;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<RollbackStruct> netData = new NetData<RollbackStruct>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeVlWhite(this.vlWhite);
				this.onChangeVlBlack(this.vlBlack);
				this.onChangeMvs(this.mvs);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.vlWhite);
				ret += GetDataSize (this.vlBlack);
				ret += GetDataSize (this.mvs);
				return ret;
			}
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is RollbackStruct) {
				RollbackStruct rollbackStruct = data as RollbackStruct;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, rollbackStruct.makeSearchInforms ());
					this.vlWhite = rollbackStruct.vlWhite.v;
					this.vlBlack = rollbackStruct.vlBlack.v;
					this.mvs = rollbackStruct.mvs.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (rollbackStruct);
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
			if (data is RollbackStruct) {
				// RollbackStruct rollbackStruct = data as RollbackStruct;
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
			if (wrapProperty.p is RollbackStruct) {
				switch ((RollbackStruct.Property)wrapProperty.n) {
				case RollbackStruct.Property.zobr:
					break;
				case RollbackStruct.Property.vlWhite:
					this.vlWhite = (System.Int32)wrapProperty.getValue ();
					break;
				case RollbackStruct.Property.vlBlack:
					this.vlBlack = (System.Int32)wrapProperty.getValue ();
					break;
				case RollbackStruct.Property.mvs:
					this.mvs = (System.UInt32)wrapProperty.getValue ();
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