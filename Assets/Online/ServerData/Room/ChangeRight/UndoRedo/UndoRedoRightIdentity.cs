using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Rights
{
	public class UndoRedoRightIdentity : DataIdentity
	{

		#region SyncVar

		#region needAccept

		[SyncVar(hook="onChangeNeedAccept")]
		public System.Boolean needAccept;

		public void onChangeNeedAccept(System.Boolean newNeedAccept)
		{
			this.needAccept = newNeedAccept;
			if (this.netData.clientData != null) {
				this.netData.clientData.needAccept.v = newNeedAccept;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region needAdmin

		[SyncVar(hook="onChangeNeedAdmin")]
		public System.Boolean needAdmin;

		public void onChangeNeedAdmin(System.Boolean newNeedAdmin)
		{
			this.needAdmin = newNeedAdmin;
			if (this.netData.clientData != null) {
				this.netData.clientData.needAdmin.v = newNeedAdmin;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<UndoRedoRight> netData = new NetData<UndoRedoRight>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeNeedAccept(this.needAccept);
				this.onChangeNeedAdmin(this.needAdmin);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.needAccept);
				ret += GetDataSize (this.needAdmin);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is UndoRedoRight) {
				UndoRedoRight undoRedoRight = data as UndoRedoRight;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, undoRedoRight.makeSearchInforms ());
					this.needAccept = undoRedoRight.needAccept.v;
					this.needAdmin = undoRedoRight.needAdmin.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (undoRedoRight);
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
			if (data is UndoRedoRight) {
				// UndoRedoRight undoRedoRight = data as UndoRedoRight;
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
			if (wrapProperty.p is UndoRedoRight) {
				switch ((UndoRedoRight.Property)wrapProperty.n) {
				case UndoRedoRight.Property.needAccept:
					this.needAccept = (System.Boolean)wrapProperty.getValue ();
					break;
				case UndoRedoRight.Property.needAdmin:
					this.needAdmin = (System.Boolean)wrapProperty.getValue ();
					break;
				case UndoRedoRight.Property.limit:
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

		#region needAccept

		public void requestChangeNeedAccept(uint userId, bool newNeedAccept)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdUndoRedoRightChangeNeedAccept (this.netId, userId, newNeedAccept);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeNeedAccept(uint userId, bool newNeedAccept){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeNeedAccept (userId, newNeedAccept);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region needAdmin

		public void requestChangeNeedAdmin(uint userId, bool newNeedAdmin)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdUndoRedoRightChangeNeedAdmin (this.netId, userId, newNeedAdmin);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeNeedAdmin(uint userId, bool newNeedAdmin){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeNeedAdmin (userId, newNeedAdmin);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region limitType

		public void requestChangeLimitType(uint userId, int newLimitType)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdUndoRedoRightChangeLimitType (this.netId, userId, newLimitType);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeLimitType(uint userId, int newLimitType){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeLimitType (userId, newLimitType);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}