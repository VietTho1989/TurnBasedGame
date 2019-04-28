using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
	public class PlayerTotalTimeIdentity : DataIdentity
	{

		#region SyncVar

		#region playerIndex

		[SyncVar(hook="onChangePlayerIndex")]
		public System.Int32 playerIndex;

		public void onChangePlayerIndex(System.Int32 newPlayerIndex)
		{
			this.playerIndex = newPlayerIndex;
			if (this.netData.clientData != null) {
				this.netData.clientData.playerIndex.v = newPlayerIndex;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region serverTime

		[SyncVar(hook="onChangeServerTime")]
		public System.Single serverTime;

		public void onChangeServerTime(System.Single newServerTime)
		{
			this.serverTime = newServerTime;
			if (this.netData.clientData != null) {
				this.netData.clientData.serverTime.v = newServerTime;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region clientTime

		[SyncVar(hook="onChangeClientTime")]
		public System.Single clientTime;

		public void onChangeClientTime(System.Single newClientTime)
		{
			this.clientTime = newClientTime;
			if (this.netData.clientData != null) {
				this.netData.clientData.clientTime.v = newClientTime;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<PlayerTotalTime> netData = new NetData<PlayerTotalTime>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangePlayerIndex(this.playerIndex);
				this.onChangeServerTime(this.serverTime);
				this.onChangeClientTime(this.clientTime);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.playerIndex);
				ret += GetDataSize (this.serverTime);
				ret += GetDataSize (this.clientTime);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is PlayerTotalTime) {
				PlayerTotalTime playerTotalTime = data as PlayerTotalTime;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, playerTotalTime.makeSearchInforms ());
					this.playerIndex = playerTotalTime.playerIndex.v;
					this.serverTime = playerTotalTime.serverTime.v;
					this.clientTime = playerTotalTime.clientTime.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (playerTotalTime);
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
			if (data is PlayerTotalTime) {
				// PlayerTotalTime playerTotalTime = data as PlayerTotalTime;
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
			if (wrapProperty.p is PlayerTotalTime) {
				switch ((PlayerTotalTime.Property)wrapProperty.n) {
				case PlayerTotalTime.Property.playerIndex:
					this.playerIndex = (System.Int32)wrapProperty.getValue ();
					break;
				case PlayerTotalTime.Property.serverTime:
					this.serverTime = (System.Single)wrapProperty.getValue ();
					break;
				case PlayerTotalTime.Property.clientTime:
					this.clientTime = (System.Single)wrapProperty.getValue ();
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