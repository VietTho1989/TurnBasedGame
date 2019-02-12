using UnityEngine;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
	public class TimePerTurnInfoLimitIdentity : DataIdentity
	{

		#region SyncVar

		#region perTurn

		[SyncVar(hook="onChangePerTurn")]
		public System.Single perTurn;

		public void onChangePerTurn(System.Single newPerTurn)
		{
			this.perTurn = newPerTurn;
			if (this.netData.clientData != null) {
				this.netData.clientData.perTurn.v = newPerTurn;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<TimePerTurnInfo.Limit> netData = new NetData<TimePerTurnInfo.Limit>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangePerTurn(this.perTurn);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.perTurn);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is TimePerTurnInfo.Limit) {
				TimePerTurnInfo.Limit limit = data as TimePerTurnInfo.Limit;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, limit.makeSearchInforms ());
					this.perTurn = limit.perTurn.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (limit);
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
			if (data is TimePerTurnInfo.Limit) {
				// Limit limit = data as Limit;
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
			if (wrapProperty.p is TimePerTurnInfo.Limit) {
				switch ((TimePerTurnInfo.Limit.Property)wrapProperty.n) {
				case TimePerTurnInfo.Limit.Property.perTurn:
					this.perTurn = (System.Single)wrapProperty.getValue ();
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

		#region Change PerTurn

		public void requestChangePerTurn(uint userId, float newPerTurn)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdTimePerTurnInfoLimitChangePerTurn (this.netId, userId, newPerTurn);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changePerTurn(uint userId, float newPerTurn)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changePerTurn (userId, newPerTurn);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}