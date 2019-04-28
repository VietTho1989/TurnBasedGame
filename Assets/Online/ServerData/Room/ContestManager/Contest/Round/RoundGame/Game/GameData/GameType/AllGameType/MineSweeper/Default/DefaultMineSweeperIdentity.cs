using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class DefaultMineSweeperIdentity : DataIdentity
	{

		#region SyncVar

		#region N

		[SyncVar(hook="onChangeN")]
		public System.Int32 N;

		public void onChangeN(System.Int32 newN)
		{
			this.N = newN;
			if (this.netData.clientData != null) {
				this.netData.clientData.N.v = newN;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region M

		[SyncVar(hook="onChangeM")]
		public System.Int32 M;

		public void onChangeM(System.Int32 newM)
		{
			this.M = newM;
			if (this.netData.clientData != null) {
				this.netData.clientData.M.v = newM;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region minK

		[SyncVar(hook="onChangeMinK")]
		public System.Single minK;

		public void onChangeMinK(System.Single newMinK)
		{
			this.minK = newMinK;
			if (this.netData.clientData != null) {
				this.netData.clientData.minK.v = newMinK;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region maxK

		[SyncVar(hook="onChangeMaxK")]
		public System.Single maxK;

		public void onChangeMaxK(System.Single newMaxK)
		{
			this.maxK = newMaxK;
			if (this.netData.clientData != null) {
				this.netData.clientData.maxK.v = newMaxK;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region allowWatchBomb

		[SyncVar(hook="onChangeAllowWatchBomb")]
		public bool allowWatchBomb;

		public void onChangeAllowWatchBomb(bool newAllowWatchBomb)
		{
			this.allowWatchBomb = newAllowWatchBomb;
			if (this.netData.clientData != null) {
				this.netData.clientData.allowWatchBomb.v = newAllowWatchBomb;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<DefaultMineSweeper> netData = new NetData<DefaultMineSweeper>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeN(this.N);
				this.onChangeM(this.M);
				this.onChangeMinK(this.minK);
				this.onChangeMaxK(this.maxK);
				this.onChangeAllowWatchBomb (this.allowWatchBomb);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.N);
				ret += GetDataSize (this.M);
				ret += GetDataSize (this.minK);
				ret += GetDataSize (this.maxK);
				ret += GetDataSize (this.allowWatchBomb);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is DefaultMineSweeper) {
				DefaultMineSweeper defaultMineSweeper = data as DefaultMineSweeper;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, defaultMineSweeper.makeSearchInforms ());
					this.N = defaultMineSweeper.N.v;
					this.M = defaultMineSweeper.M.v;
					this.minK = defaultMineSweeper.minK.v;
					this.maxK = defaultMineSweeper.maxK.v;
					this.allowWatchBomb = defaultMineSweeper.allowWatchBomb.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (defaultMineSweeper);
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
			if (data is DefaultMineSweeper) {
				// DefaultMineSweeper defaultMineSweeper = data as DefaultMineSweeper;
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
			if (wrapProperty.p is DefaultMineSweeper) {
				switch ((DefaultMineSweeper.Property)wrapProperty.n) {
				case DefaultMineSweeper.Property.N:
					this.N = (System.Int32)wrapProperty.getValue ();
					break;
				case DefaultMineSweeper.Property.M:
					this.M = (System.Int32)wrapProperty.getValue ();
					break;
				case DefaultMineSweeper.Property.minK:
					this.minK = (System.Single)wrapProperty.getValue ();
					break;
				case DefaultMineSweeper.Property.maxK:
					this.maxK = (System.Single)wrapProperty.getValue ();
					break;
				case DefaultMineSweeper.Property.allowWatchBomb:
					this.allowWatchBomb = (bool)wrapProperty.getValue ();
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

		#region N

		public void requestChangeN(uint userId, int newN)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultMineSweeperChangeN (this.netId, userId, newN);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeN(uint userId, int newN)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeN (userId, newN);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region M

		public void requestChangeM(uint userId, int newM)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultMineSweeperChangeM (this.netId, userId, newM);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeM(uint userId, int newM)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeM (userId, newM);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region minK

		public void requestChangeMinK(uint userId, float newMinK)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultMineSweeperChangeMinK (this.netId, userId, newMinK);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMinK(uint userId, float newMinK)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMinK (userId, newMinK);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region maxK

		public void requestChangeMaxK(uint userId, float newMaxK)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultMineSweeperChangeMaxK (this.netId, userId, newMaxK);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMaxK(uint userId, float newMaxK)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMaxK (userId, newMaxK);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region allowWatchBomb

		public void requestChangeAllowWatchBomb(uint userId, bool newAllowWatchBomb)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultMineSweeperChangeAllowWatchBomb (this.netId, userId, newAllowWatchBomb);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeAllowWatchBomb(uint userId, bool newAllowWatchBomb)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeAllowWatchBomb (userId, newAllowWatchBomb);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}