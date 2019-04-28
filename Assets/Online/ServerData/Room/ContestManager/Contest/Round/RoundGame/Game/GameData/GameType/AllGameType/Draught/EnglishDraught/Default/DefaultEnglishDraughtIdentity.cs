using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught
{
	public class DefaultEnglishDraughtIdentity : DataIdentity
	{

		#region SyncVar

		#region threeMoveRandom

		[SyncVar(hook="onChangeThreeMoveRandom")]
		public bool threeMoveRandom;

		public void onChangeThreeMoveRandom(bool newThreeMoveRandom)
		{
			this.threeMoveRandom = newThreeMoveRandom;
			if (this.netData.clientData != null) {
				this.netData.clientData.threeMoveRandom.v = newThreeMoveRandom;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region maxPly

		[SyncVar(hook="onChangeMaxPly")]
		public System.Int32 maxPly;

		public void onChangeMaxPly(System.Int32 newMaxPly)
		{
			this.maxPly = newMaxPly;
			if (this.netData.clientData != null) {
				this.netData.clientData.maxPly.v = newMaxPly;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<DefaultEnglishDraught> netData = new NetData<DefaultEnglishDraught>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeThreeMoveRandom (this.threeMoveRandom);
				this.onChangeMaxPly(this.maxPly);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.threeMoveRandom);
				ret += GetDataSize (this.maxPly);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is DefaultEnglishDraught) {
				DefaultEnglishDraught defaultEnglishDraught = data as DefaultEnglishDraught;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, defaultEnglishDraught.makeSearchInforms ());
					this.threeMoveRandom = defaultEnglishDraught.threeMoveRandom.v;
					this.maxPly = defaultEnglishDraught.maxPly.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (defaultEnglishDraught);
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
			if (data is DefaultEnglishDraught) {
				// DefaultEnglishDraught defaultEnglishDraught = data as DefaultEnglishDraught;
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
			if (wrapProperty.p is DefaultEnglishDraught) {
				switch ((DefaultEnglishDraught.Property)wrapProperty.n) {
				case DefaultEnglishDraught.Property.threeMoveRandom:
					this.threeMoveRandom = (bool)wrapProperty.getValue ();
					break;
				case DefaultEnglishDraught.Property.maxPly:
					this.maxPly = (System.Int32)wrapProperty.getValue ();
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

		#region Change MaxPly

		public void requestChangeMaxPly(uint userId, int newMaxPly)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultEnglishDraughtChangeMaxPly (this.netId, userId, newMaxPly);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMaxPly(uint userId, int newMaxPly)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMaxPly (userId, newMaxPly);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region Change ThreeMoveRandom

		public void requestChangeThreeMoveRandom(uint userId, bool newThreeMoveRandom)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultEnglishDraughtChangeThreeMoveRandom (this.netId, userId, newThreeMoveRandom);
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

	}
}