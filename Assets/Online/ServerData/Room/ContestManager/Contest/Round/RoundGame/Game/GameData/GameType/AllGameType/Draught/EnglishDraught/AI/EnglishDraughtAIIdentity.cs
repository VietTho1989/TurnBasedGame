using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught
{
	public class EnglishDraughtAIIdentity : DataIdentity
	{

		#region SyncVar

		#region threeMoveRandom

		[SyncVar(hook="onChangeThreeMoveRandom")]
		public System.Boolean threeMoveRandom;

		public void onChangeThreeMoveRandom(System.Boolean newThreeMoveRandom)
		{
			this.threeMoveRandom = newThreeMoveRandom;
			if (this.netData.clientData != null) {
				this.netData.clientData.threeMoveRandom.v = newThreeMoveRandom;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region fMaxSeconds

		[SyncVar(hook="onChangeFMaxSeconds")]
		public System.Single fMaxSeconds;

		public void onChangeFMaxSeconds(System.Single newFMaxSeconds)
		{
			this.fMaxSeconds = newFMaxSeconds;
			if (this.netData.clientData != null) {
				this.netData.clientData.fMaxSeconds.v = newFMaxSeconds;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region g_MaxDepth

		[SyncVar(hook="onChangeG_MaxDepth")]
		public System.Int32 g_MaxDepth;

		public void onChangeG_MaxDepth(System.Int32 newG_MaxDepth)
		{
			this.g_MaxDepth = newG_MaxDepth;
			if (this.netData.clientData != null) {
				this.netData.clientData.g_MaxDepth.v = newG_MaxDepth;
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

		private NetData<EnglishDraughtAI> netData = new NetData<EnglishDraughtAI>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeThreeMoveRandom(this.threeMoveRandom);
				this.onChangeFMaxSeconds(this.fMaxSeconds);
				this.onChangeG_MaxDepth(this.g_MaxDepth);
				this.onChangePickBestMove(this.pickBestMove);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.threeMoveRandom);
				ret += GetDataSize (this.fMaxSeconds);
				ret += GetDataSize (this.g_MaxDepth);
				ret += GetDataSize (this.pickBestMove);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is EnglishDraughtAI) {
				EnglishDraughtAI englishDraughtAI = data as EnglishDraughtAI;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, englishDraughtAI.makeSearchInforms ());
					this.threeMoveRandom = englishDraughtAI.threeMoveRandom.v;
					this.fMaxSeconds = englishDraughtAI.fMaxSeconds.v;
					this.g_MaxDepth = englishDraughtAI.g_MaxDepth.v;
					this.pickBestMove = englishDraughtAI.pickBestMove.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (englishDraughtAI);
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
			if (data is EnglishDraughtAI) {
				// EnglishDraughtAI englishDraughtAI = data as EnglishDraughtAI;
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
			if (wrapProperty.p is EnglishDraughtAI) {
				switch ((EnglishDraughtAI.Property)wrapProperty.n) {
				case EnglishDraughtAI.Property.threeMoveRandom:
					this.threeMoveRandom = (System.Boolean)wrapProperty.getValue ();
					break;
				case EnglishDraughtAI.Property.fMaxSeconds:
					this.fMaxSeconds = (System.Single)wrapProperty.getValue ();
					break;
				case EnglishDraughtAI.Property.g_MaxDepth:
					this.g_MaxDepth = (System.Int32)wrapProperty.getValue ();
					break;
				case EnglishDraughtAI.Property.pickBestMove:
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

		#region threeMoveRandom

		public void requestChangeThreeMoveRandom(uint userId, bool newThreeMoveRandom)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdEnglishDraughtAIChangeThreeMoveRandom (this.netId, userId, newThreeMoveRandom);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeThreeMoveRandom(uint userId, bool newThreeMoveRandom)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeThreeMoveRandom (userId, newThreeMoveRandom);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region fMaxSeconds

		public void requestChangeFMaxSeconds(uint userId, float newFMaxSeconds)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdEnglishDraughtAIChangeFMaxSeconds (this.netId, userId, newFMaxSeconds);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeFMaxSeconds(uint userId, float newFMaxSeconds)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeFMaxSeconds (userId, newFMaxSeconds);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region g_MaxDepth

		public void requestChangeGMaxDepth(uint userId, int newGMaxDepth)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdEnglishDraughtAIChangeGMaxDepth (this.netId, userId, newGMaxDepth);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeGMaxDepth(uint userId, int newGMaxDepth)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeGMaxDepth (userId, newGMaxDepth);
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
				clientConnect.CmdEnglishDraughtAIChangePickBestMove (this.netId, userId, newPickBestMove);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changePickBestMove(uint userId, int newPickBestMove){
			if (this.netData.serverData != null) {
				this.netData.serverData.changePickBestMove (userId, newPickBestMove);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}