using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class DefaultKhetIdentity : DataIdentity
	{

		#region SyncVar

		#region startPos

		[SyncVar(hook="onChangeStartPos")]
		public DefaultKhet.StartPos startPos;

		public void onChangeStartPos(DefaultKhet.StartPos newStartPos)
		{
			this.startPos = newStartPos;
			if (this.netData.clientData != null) {
				this.netData.clientData.startPos.v = newStartPos;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<DefaultKhet> netData = new NetData<DefaultKhet>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeStartPos(this.startPos);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.startPos);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is DefaultKhet) {
				DefaultKhet defaultKhet = data as DefaultKhet;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, defaultKhet.makeSearchInforms ());
					this.startPos = defaultKhet.startPos.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (defaultKhet);
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
			if (data is DefaultKhet) {
				// DefaultKhet defaultKhet = data as DefaultKhet;
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
			if (wrapProperty.p is DefaultKhet) {
				switch ((DefaultKhet.Property)wrapProperty.n) {
				case DefaultKhet.Property.startPos:
					this.startPos = (DefaultKhet.StartPos)wrapProperty.getValue ();
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

		#region startPos

		public void requestChangeStartPos(uint userId, DefaultKhet.StartPos newStartPos)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultKhetChangeStartPos (this.netId, userId, newStartPos);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeStartPos(uint userId, DefaultKhet.StartPos newStartPos)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeStartPos (userId, newStartPos);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}