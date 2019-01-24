using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundNoLimitIdentity : DataIdentity
	{

		#region SyncVar

		#region isStopMakeMoreRound

		[SyncVar(hook="onChangeIsStopMakeMoreRound")]
		public System.Boolean isStopMakeMoreRound;

		public void onChangeIsStopMakeMoreRound(System.Boolean newIsStopMakeMoreRound)
		{
			this.isStopMakeMoreRound = newIsStopMakeMoreRound;
			if (this.netData.clientData != null) {
				this.netData.clientData.isStopMakeMoreRound.v = newIsStopMakeMoreRound;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<RequestNewRoundNoLimit> netData = new NetData<RequestNewRoundNoLimit>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeIsStopMakeMoreRound(this.isStopMakeMoreRound);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.isStopMakeMoreRound);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewRoundNoLimit) {
				RequestNewRoundNoLimit requestNewRoundNoLimit = data as RequestNewRoundNoLimit;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, requestNewRoundNoLimit.makeSearchInforms ());
					this.isStopMakeMoreRound = requestNewRoundNoLimit.isStopMakeMoreRound.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (requestNewRoundNoLimit);
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
			if (data is RequestNewRoundNoLimit) {
				// RequestNewRoundNoLimit requestNewRoundNoLimit = data as RequestNewRoundNoLimit;
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
			if (wrapProperty.p is RequestNewRoundNoLimit) {
				switch ((RequestNewRoundNoLimit.Property)wrapProperty.n) {
				case RequestNewRoundNoLimit.Property.isStopMakeMoreRound:
					this.isStopMakeMoreRound = (System.Boolean)wrapProperty.getValue ();
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

		#region isStopMakeMoreRound

		public void requestChangeIsStopMakeMoreRound(uint userId, bool newIsStopMakeMoreRound)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdRequestNewRoundNoLimitChangeIsStopMakeMoreRound (this.netId, userId, newIsStopMakeMoreRound);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeIsStopMakeMoreRound(uint userId, bool newIsStopMakeMoreRound) {
			if (this.netData.serverData != null) {
				this.netData.serverData.changeIsStopMakeMoreRound (userId, newIsStopMakeMoreRound);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}