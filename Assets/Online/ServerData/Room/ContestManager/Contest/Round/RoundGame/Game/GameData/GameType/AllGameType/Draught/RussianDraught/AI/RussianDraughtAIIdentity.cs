using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
{
	public class RussianDraughtAIIdentity : DataIdentity
	{
		
		#region SyncVar

		#region timeLimit

		[SyncVar(hook="onChangeTimeLimit")]
		public System.Int32 timeLimit;

		public void onChangeTimeLimit(System.Int32 newTimeLimit)
		{
			this.timeLimit = newTimeLimit;
			if (this.netData.clientData != null) {
				this.netData.clientData.timeLimit.v = newTimeLimit;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region pickBestMove

		[SyncVar(hook="onChangePickBestMove")]
		public System.Int32 pickBestMove;

		public void onChangePickBestMove(System.Int32 newPickBestMove)
		{
			this.pickBestMove = newPickBestMove;
			if (this.netData.clientData != null) {
				this.netData.clientData.pickBestMove.v = newPickBestMove;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<RussianDraughtAI> netData = new NetData<RussianDraughtAI>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeTimeLimit(this.timeLimit);
				this.onChangePickBestMove(this.pickBestMove);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.timeLimit);
				ret += GetDataSize (this.pickBestMove);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is RussianDraughtAI) {
				RussianDraughtAI russianDraughtAI = data as RussianDraughtAI;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, russianDraughtAI.makeSearchInforms ());
					this.timeLimit = russianDraughtAI.timeLimit.v;
					this.pickBestMove = russianDraughtAI.pickBestMove.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (russianDraughtAI);
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
			if (data is RussianDraughtAI) {
				// RussianDraughtAI russianDraughtAI = data as RussianDraughtAI;
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
			if (wrapProperty.p is RussianDraughtAI) {
				switch ((RussianDraughtAI.Property)wrapProperty.n) {
				case RussianDraughtAI.Property.timeLimit:
					this.timeLimit = (System.Int32)wrapProperty.getValue ();
					break;
				case RussianDraughtAI.Property.pickBestMove:
					this.pickBestMove = (System.Int32)wrapProperty.getValue ();
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

		#region timeLimit

		public void requestChangeTimeLimit(uint userId, int newTimeLimit)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdRussianDraughtAIChangeTimeLimit (this.netId, userId, newTimeLimit);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeTimeLimit(uint userId, int newTimeLimit)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeTimeLimit (userId, newTimeLimit);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region pickBestMove

		public void requestChangePickBestMove(uint userId, int newPickBestMove)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdRussianDraughtAIChangePickBestMove (this.netId, userId, newPickBestMove);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changePickBestMove(uint userId, int newPickBestMove)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changePickBestMove (userId, newPickBestMove);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}