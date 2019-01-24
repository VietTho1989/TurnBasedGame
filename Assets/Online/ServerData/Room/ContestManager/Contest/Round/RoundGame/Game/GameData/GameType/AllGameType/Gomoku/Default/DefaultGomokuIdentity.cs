using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku
{
	public class DefaultGomokuIdentity : DataIdentity
	{

		#region SyncVar

		#region boardSize

		[SyncVar(hook="onChangeBoardSize")]
		public System.Int32 boardSize;

		public void onChangeBoardSize(System.Int32 newBoardSize)
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

		private NetData<DefaultGomoku> netData = new NetData<DefaultGomoku>();

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
				return ret;
			}
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is DefaultGomoku) {
				DefaultGomoku defaultGomoku = data as DefaultGomoku;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, defaultGomoku.makeSearchInforms ());
					this.boardSize = defaultGomoku.boardSize.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (defaultGomoku);
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
			if (data is DefaultGomoku) {
				// DefaultGomoku defaultGomoku = data as DefaultGomoku;
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
			if (wrapProperty.p is DefaultGomoku) {
				switch ((DefaultGomoku.Property)wrapProperty.n) {
				case DefaultGomoku.Property.boardSize:
					this.boardSize = (System.Int32)wrapProperty.getValue ();
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

		#region Change BoardSize

		public void requestChangeBoardSize(uint userId, int newBoardSize)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultGomokuChangeBoardSize (this.netId, userId, newBoardSize);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeBoardSize(uint userId, int newBoardSize){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeBoardSize (userId, newBoardSize);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}