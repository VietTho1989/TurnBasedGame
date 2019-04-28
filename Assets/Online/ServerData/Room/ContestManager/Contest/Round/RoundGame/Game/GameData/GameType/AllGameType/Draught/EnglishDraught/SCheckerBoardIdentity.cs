using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught
{
	public class SCheckerBoardIdentity : DataIdentity
	{

		#region SyncVar

		#region WP

		[SyncVar(hook="onChangeWP")]
		public System.UInt64 WP;

		public void onChangeWP(System.UInt64 newWP)
		{
			this.WP = newWP;
			if (this.netData.clientData != null) {
				this.netData.clientData.WP.v = newWP;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region BP

		[SyncVar(hook="onChangeBP")]
		public System.UInt64 BP;

		public void onChangeBP(System.UInt64 newBP)
		{
			this.BP = newBP;
			if (this.netData.clientData != null) {
				this.netData.clientData.BP.v = newBP;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region K

		[SyncVar(hook="onChangeK")]
		public System.UInt64 K;

		public void onChangeK(System.UInt64 newK)
		{
			this.K = newK;
			if (this.netData.clientData != null) {
				this.netData.clientData.K.v = newK;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<SCheckerBoard> netData = new NetData<SCheckerBoard>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeWP(this.WP);
				this.onChangeBP(this.BP);
				this.onChangeK(this.K);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.WP);
				ret += GetDataSize (this.BP);
				ret += GetDataSize (this.K);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is SCheckerBoard) {
				SCheckerBoard sCheckerBoard = data as SCheckerBoard;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, sCheckerBoard.makeSearchInforms ());
					this.WP = sCheckerBoard.WP.v;
					this.BP = sCheckerBoard.BP.v;
					this.K = sCheckerBoard.K.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (sCheckerBoard);
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
			if (data is SCheckerBoard) {
				// SCheckerBoard sCheckerBoard = data as SCheckerBoard;
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
			if (wrapProperty.p is SCheckerBoard) {
				switch ((SCheckerBoard.Property)wrapProperty.n) {
				case SCheckerBoard.Property.WP:
					this.WP = (System.UInt64)wrapProperty.getValue ();
					break;
				case SCheckerBoard.Property.BP:
					this.BP = (System.UInt64)wrapProperty.getValue ();
					break;
				case SCheckerBoard.Property.K:
					this.K = (System.UInt64)wrapProperty.getValue ();
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