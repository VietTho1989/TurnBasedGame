using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
	public class NoneIdentity : DataIdentity
	{

		#region SyncVar

		#endregion

		#region NetData

		private NetData<None> netData = new NetData<None>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is None) {
				None none = data as None;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, none.makeSearchInforms ());
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (none);
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
			if (data is None) {
				// None none = data as None;
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
			if (wrapProperty.p is None) {
				switch ((None.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		#region ask last turn

		public void requestAskLastTurn(uint userId, UndoRedoRequest.Operation operation)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdUndoRedoNoneAskLastTurn (this.netId, userId, operation);
			} else {
				Debug.LogError ("Cannot find userIdentity: " + this);
			}
		}

		public void askLastTurn (uint userId, UndoRedoRequest.Operation operation)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.askLastTurn (userId, operation);
			} else {
				Debug.LogError ("serverData null");
			}
		}

		#endregion

		#region ask last your turn

		public void requestAskLastYourTurn(uint userId, UndoRedoRequest.Operation operation)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdUndoRedoNoneAskLastYourTurn (this.netId, userId, operation);
			} else {
				Debug.LogError ("Cannot find userIdentity: " + this);
			}
		}

		public void askLastYourTurn (uint userId, UndoRedoRequest.Operation operation)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.askLastYourTurn (userId, operation);
			} else {
				Debug.LogError ("serverData null");
			}
		}

		#endregion

	}
}