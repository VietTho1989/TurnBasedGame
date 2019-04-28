using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
	public class DefaultWeiqiIdentity : DataIdentity
	{

		#region SyncVar

		#region size

		[SyncVar(hook="onChangeSize")]
		public System.Int32 size;

		public void onChangeSize(System.Int32 newSize)
		{
			this.size = newSize;
			if (this.netData.clientData != null) {
				this.netData.clientData.size.v = newSize;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region komi

		[SyncVar(hook="onChangeKomi")]
		public System.Single komi;

		public void onChangeKomi(System.Single newKomi)
		{
			this.komi = newKomi;
			if (this.netData.clientData != null) {
				this.netData.clientData.komi.v = newKomi;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region rule

		[SyncVar(hook="onChangeRule")]
		public System.Int32 rule;

		public void onChangeRule(System.Int32 newRule)
		{
			this.rule = newRule;
			if (this.netData.clientData != null) {
				this.netData.clientData.rule.v = newRule;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region handicap

		[SyncVar(hook="onChangeHandicap")]
		public System.Int32 handicap;

		public void onChangeHandicap(System.Int32 newHandicap)
		{
			this.handicap = newHandicap;
			if (this.netData.clientData != null) {
				this.netData.clientData.handicap.v = newHandicap;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<DefaultWeiqi> netData = new NetData<DefaultWeiqi>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeSize(this.size);
				this.onChangeKomi(this.komi);
				this.onChangeRule(this.rule);
				this.onChangeHandicap(this.handicap);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.size);
				ret += GetDataSize (this.komi);
				ret += GetDataSize (this.rule);
				ret += GetDataSize (this.handicap);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is DefaultWeiqi) {
				DefaultWeiqi defaultWeiqi = data as DefaultWeiqi;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, defaultWeiqi.makeSearchInforms ());
					this.size = defaultWeiqi.size.v;
					this.komi = defaultWeiqi.komi.v;
					this.rule = defaultWeiqi.rule.v;
					this.handicap = defaultWeiqi.handicap.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (defaultWeiqi);
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
			if (data is DefaultWeiqi) {
				// DefaultWeiqi defaultWeiqi = data as DefaultWeiqi;
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
			if (wrapProperty.p is DefaultWeiqi) {
				switch ((DefaultWeiqi.Property)wrapProperty.n) {
				case DefaultWeiqi.Property.size:
					this.size = (System.Int32)wrapProperty.getValue ();
					break;
				case DefaultWeiqi.Property.komi:
					this.komi = (System.Single)wrapProperty.getValue ();
					break;
				case DefaultWeiqi.Property.rule:
					this.rule = (System.Int32)wrapProperty.getValue ();
					break;
				case DefaultWeiqi.Property.handicap:
					this.handicap = (System.Int32)wrapProperty.getValue ();
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

		#region Change Size

		public void requestChangeSize(uint userId, int newSize)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultWeiqiChangeSize (this.netId, userId, newSize);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeSize(uint userId, int newSize)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeSize (userId, newSize);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region Change Komi

		public void requestChangeKomi(uint userId, float newKomi)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultWeiqiChangeKomi (this.netId, userId, newKomi);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeKomi(uint userId, float newKomi)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeKomi (userId, newKomi);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region Change Rule

		public void requestChangeRule(uint userId, int newRule)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultWeiqiChangeRule (this.netId, userId, newRule);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeRule(uint userId, int newRule)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeRule (userId, newRule);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region Change Handicap

		public void requestChangeHandicap(uint userId, int newHandicap)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultWeiqiChangeHandicap (this.netId, userId, newHandicap);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeHandicap(uint userId, int newHandicap)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeHandicap (userId, newHandicap);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}