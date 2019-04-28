using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
	public class RequestLastYourTurnIdentity : DataIdentity
	{

		#region SyncVar

		#region operation

		[SyncVar(hook="onChangeOperation")]
		public UndoRedoRequest.Operation operation;

		public void onChangeOperation(UndoRedoRequest.Operation newOperation)
		{
			this.operation = newOperation;
			if (this.netData.clientData != null) {
				this.netData.clientData.operation.v = newOperation;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region userId

		[SyncVar(hook="onChangeUserId")]
		public System.UInt32 userId;

		public void onChangeUserId(System.UInt32 newUserId)
		{
			this.userId = newUserId;
			if (this.netData.clientData != null) {
				this.netData.clientData.userId.v = newUserId;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<RequestLastYourTurn> netData = new NetData<RequestLastYourTurn>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeOperation(this.operation);
				this.onChangeUserId(this.userId);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.operation);
				ret += GetDataSize (this.userId);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestLastYourTurn) {
				RequestLastYourTurn requestLastYourTurn = data as RequestLastYourTurn;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, requestLastYourTurn.makeSearchInforms ());
					this.operation = requestLastYourTurn.operation.v;
					this.userId = requestLastYourTurn.userId.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (requestLastYourTurn);
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
			if (data is RequestLastYourTurn) {
				// RequestLastYourTurn requestLastYourTurn = data as RequestLastYourTurn;
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
			if (wrapProperty.p is RequestLastYourTurn) {
				switch ((RequestLastYourTurn.Property)wrapProperty.n) {
				case RequestLastYourTurn.Property.operation:
					this.operation = (UndoRedoRequest.Operation)wrapProperty.getValue ();
					break;
				case RequestLastYourTurn.Property.userId:
					this.userId = (System.UInt32)wrapProperty.getValue ();
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

	}
}