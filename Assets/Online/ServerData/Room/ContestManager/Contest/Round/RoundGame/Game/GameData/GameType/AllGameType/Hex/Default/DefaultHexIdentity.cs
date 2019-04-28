using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
	public class DefaultHexIdentity : DataIdentity
	{

		#region SyncVar

		#region boardSize

		[SyncVar(hook="onChangeBoardSize")]
		public System.UInt16 boardSize;

		public void onChangeBoardSize(System.UInt16 newBoardSize)
		{
			this.boardSize = newBoardSize;
			if (this.netData.clientData != null) {
				this.netData.clientData.boardSize.v = newBoardSize;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<DefaultHex> netData = new NetData<DefaultHex>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeBoardSize(this.boardSize);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.boardSize);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is DefaultHex) {
				DefaultHex defaultHex = data as DefaultHex;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, defaultHex.makeSearchInforms ());
					this.boardSize = defaultHex.boardSize.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (defaultHex);
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
			if (data is DefaultHex) {
				// DefaultHex defaultHex = data as DefaultHex;
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
			if (wrapProperty.p is DefaultHex) {
				switch ((DefaultHex.Property)wrapProperty.n) {
				case DefaultHex.Property.boardSize:
					this.boardSize = (System.UInt16)wrapProperty.getValue ();
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

		#region BoardSize

		public void requestChangeBoardSize(uint userId, System.UInt16 newBoardSize)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultHexChangeBoardSize (this.netId, userId, newBoardSize);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeBoardSize(uint userId, System.UInt16 newBoardSize)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeBoardSize (userId, newBoardSize);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}