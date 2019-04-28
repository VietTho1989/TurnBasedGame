using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireAIIdentity : DataIdentity
	{

		#region SyncVar

		#region multiThreaded

		[SyncVar(hook="onChangeMultiThreaded")]
		public System.Int32 multiThreaded;

		public void onChangeMultiThreaded(System.Int32 newMultiThreaded)
		{
			this.multiThreaded = newMultiThreaded;
			if (this.netData.clientData != null) {
				this.netData.clientData.multiThreaded.v = newMultiThreaded;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region maxClosedCount

		[SyncVar(hook="onChangeMaxClosedCount")]
		public System.Int32 maxClosedCount;

		public void onChangeMaxClosedCount(System.Int32 newMaxClosedCount)
		{
			this.maxClosedCount = newMaxClosedCount;
			if (this.netData.clientData != null) {
				this.netData.clientData.maxClosedCount.v = newMaxClosedCount;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region fastMode

		[SyncVar(hook="onChangeFastMode")]
		public System.Boolean fastMode;

		public void onChangeFastMode(System.Boolean newFastMode)
		{
			this.fastMode = newFastMode;
			if (this.netData.clientData != null) {
				this.netData.clientData.fastMode.v = newFastMode;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<SolitaireAI> netData = new NetData<SolitaireAI>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMultiThreaded(this.multiThreaded);
				this.onChangeMaxClosedCount(this.maxClosedCount);
				this.onChangeFastMode(this.fastMode);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.multiThreaded);
				ret += GetDataSize (this.maxClosedCount);
				ret += GetDataSize (this.fastMode);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is SolitaireAI) {
				SolitaireAI solitaireAI = data as SolitaireAI;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, solitaireAI.makeSearchInforms ());
					this.multiThreaded = solitaireAI.multiThreaded.v;
					this.maxClosedCount = solitaireAI.maxClosedCount.v;
					this.fastMode = solitaireAI.fastMode.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (solitaireAI);
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
			if (data is SolitaireAI) {
				// SolitaireAI solitaireAI = data as SolitaireAI;
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
			if (wrapProperty.p is SolitaireAI) {
				switch ((SolitaireAI.Property)wrapProperty.n) {
				case SolitaireAI.Property.multiThreaded:
					this.multiThreaded = (System.Int32)wrapProperty.getValue ();
					break;
				case SolitaireAI.Property.maxClosedCount:
					this.maxClosedCount = (System.Int32)wrapProperty.getValue ();
					break;
				case SolitaireAI.Property.fastMode:
					this.fastMode = (System.Boolean)wrapProperty.getValue ();
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

		#region multiThreaded

		public void requestChangeMultiThreaded(uint userId, int newMultiThreaded)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdSolitaireAIChangeMultiThreaded (this.netId, userId, newMultiThreaded);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMultiThreaded(uint userId, int newMultiThreaded)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMultiThreaded (userId, newMultiThreaded);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region maxClosedCount

		public void requestChangeMaxClosedCount(uint userId, int newMaxClosedCount)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdSolitaireAIChangeMaxClosedCount (this.netId, userId, newMaxClosedCount);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMaxClosedCount(uint userId, int newMaxClosedCount)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMaxClosedCount (userId, newMaxClosedCount);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region fastMode

		public void requestChangeFastMode(uint userId, bool newFastMode)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdSolitaireAIChangeFastMode (this.netId, userId, newFastMode);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeFastMode(uint userId, bool newFastMode)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeFastMode (userId, newFastMode);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}