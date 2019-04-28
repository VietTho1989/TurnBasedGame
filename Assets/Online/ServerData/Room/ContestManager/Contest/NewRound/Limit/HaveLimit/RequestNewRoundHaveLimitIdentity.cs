using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundHaveLimitIdentity : DataIdentity
	{

		#region SyncVar

		#region maxRound

		[SyncVar(hook="onChangeMaxRound")]
		public System.Int32 maxRound;

		public void onChangeMaxRound(System.Int32 newMaxRound)
		{
			this.maxRound = newMaxRound;
			if (this.netData.clientData != null) {
				this.netData.clientData.maxRound.v = newMaxRound;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region enoughScoreStop

		[SyncVar(hook="onChangeEnoughScoreStop")]
		public System.Boolean enoughScoreStop;

		public void onChangeEnoughScoreStop(System.Boolean newEnoughScoreStop)
		{
			this.enoughScoreStop = newEnoughScoreStop;
			if (this.netData.clientData != null) {
				this.netData.clientData.enoughScoreStop.v = newEnoughScoreStop;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<RequestNewRoundHaveLimit> netData = new NetData<RequestNewRoundHaveLimit>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMaxRound(this.maxRound);
				this.onChangeEnoughScoreStop(this.enoughScoreStop);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.maxRound);
				ret += GetDataSize (this.enoughScoreStop);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewRoundHaveLimit) {
				RequestNewRoundHaveLimit requestNewRoundHaveLimit = data as RequestNewRoundHaveLimit;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, requestNewRoundHaveLimit.makeSearchInforms ());
					this.maxRound = requestNewRoundHaveLimit.maxRound.v;
					this.enoughScoreStop = requestNewRoundHaveLimit.enoughScoreStop.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (requestNewRoundHaveLimit);
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
			if (data is RequestNewRoundHaveLimit) {
				// RequestNewRoundHaveLimit requestNewRoundHaveLimit = data as RequestNewRoundHaveLimit;
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
			if (wrapProperty.p is RequestNewRoundHaveLimit) {
				switch ((RequestNewRoundHaveLimit.Property)wrapProperty.n) {
				case RequestNewRoundHaveLimit.Property.maxRound:
					this.maxRound = (System.Int32)wrapProperty.getValue ();
					break;
				case RequestNewRoundHaveLimit.Property.enoughScoreStop:
					this.enoughScoreStop = (System.Boolean)wrapProperty.getValue ();
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

		#region maxRound

		public void requestChangeMaxRound(uint userId, int newMaxRound)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdRequestNewRoundHaveLimitChangeMaxRound (this.netId, userId, newMaxRound);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMaxRound(uint userId, int newMaxRound) {
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMaxRound (userId, newMaxRound);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region enoughScoreStop

		public void requestChangeEnoughScoreStop(uint userId, bool newEnoughScoreStop)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdRequestNewRoundHaveLimitChangeEnoughScoreStop (this.netId, userId, newEnoughScoreStop);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeEnoughScoreStop(uint userId, bool newEnoughScoreStop) {
			if (this.netData.serverData != null) {
				this.netData.serverData.changeEnoughScoreStop (userId, newEnoughScoreStop);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}