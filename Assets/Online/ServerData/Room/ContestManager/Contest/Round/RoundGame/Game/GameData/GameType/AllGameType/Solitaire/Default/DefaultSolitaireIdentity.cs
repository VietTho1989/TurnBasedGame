using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class DefaultSolitaireIdentity : DataIdentity
	{

		#region SyncVar

		#region drawCount

		[SyncVar(hook="onChangeDrawCount")]
		public System.Int32 drawCount;

		public void onChangeDrawCount(System.Int32 newDrawCount)
		{
			this.drawCount = newDrawCount;
			if (this.netData.clientData != null) {
				this.netData.clientData.drawCount.v = newDrawCount;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<DefaultSolitaire> netData = new NetData<DefaultSolitaire>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeDrawCount(this.drawCount);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.drawCount);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is DefaultSolitaire) {
				DefaultSolitaire defaultSolitaire = data as DefaultSolitaire;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, defaultSolitaire.makeSearchInforms ());
					this.drawCount = defaultSolitaire.drawCount.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (defaultSolitaire);
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
			if (data is DefaultSolitaire) {
				// DefaultSolitaire defaultSolitaire = data as DefaultSolitaire;
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
			if (wrapProperty.p is DefaultSolitaire) {
				switch ((DefaultSolitaire.Property)wrapProperty.n) {
				case DefaultSolitaire.Property.drawCount:
					this.drawCount = (System.Int32)wrapProperty.getValue ();
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

		#region DrawCount

		public void requestChangeDrawCount(uint userId, int newDrawCount)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultSolitaireChangeDrawCount (this.netId, userId, newDrawCount);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeDrawCount(uint userId, int newDrawCount)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeDrawCount (userId, newDrawCount);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}