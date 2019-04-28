using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
	public class HexAIIdentity : DataIdentity
	{

		#region SyncVar

		#region limitTime

		[SyncVar(hook="onChangeLimitTime")]
		public System.Int32 limitTime;

		public void onChangeLimitTime(System.Int32 newLimitTime)
		{
			this.limitTime = newLimitTime;
			if (this.netData.clientData != null) {
				this.netData.clientData.limitTime.v = newLimitTime;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region firstMoveCenter

		[SyncVar(hook="onChangeFirstMoveCenter")]
		public System.Boolean firstMoveCenter;

		public void onChangeFirstMoveCenter(System.Boolean newFirstMoveCenter)
		{
			this.firstMoveCenter = newFirstMoveCenter;
			if (this.netData.clientData != null) {
				this.netData.clientData.firstMoveCenter.v = newFirstMoveCenter;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<HexAI> netData = new NetData<HexAI>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeLimitTime(this.limitTime);
				this.onChangeFirstMoveCenter(this.firstMoveCenter);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.limitTime);
				ret += GetDataSize (this.firstMoveCenter);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is HexAI) {
				HexAI hexAI = data as HexAI;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, hexAI.makeSearchInforms ());
					this.limitTime = hexAI.limitTime.v;
					this.firstMoveCenter = hexAI.firstMoveCenter.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (hexAI);
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
			if (data is HexAI) {
				// HexAI hexAI = data as HexAI;
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
			if (wrapProperty.p is HexAI) {
				switch ((HexAI.Property)wrapProperty.n) {
				case HexAI.Property.limitTime:
					this.limitTime = (System.Int32)wrapProperty.getValue ();
					break;
				case HexAI.Property.firstMoveCenter:
					this.firstMoveCenter = (System.Boolean)wrapProperty.getValue ();
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

		#region LimitTime

		public void requestChangeLimitTime(uint userId, int newLimitTime)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdHexAIChangeLimitTime (this.netId, userId, newLimitTime);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeLimitTime(uint userId, int newLimitTime)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeLimitTime (userId, newLimitTime);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region FirstMoveCenter

		public void requestChangeFirstMoveCenter(uint userId, bool newFirstMoveCenter)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdHexAIChangeFirstMoveCenter (this.netId, userId, newFirstMoveCenter);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeFirstMoveCenter(uint userId, bool newFirstMoveCenter)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeFirstMoveCenter (userId, newFirstMoveCenter);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}