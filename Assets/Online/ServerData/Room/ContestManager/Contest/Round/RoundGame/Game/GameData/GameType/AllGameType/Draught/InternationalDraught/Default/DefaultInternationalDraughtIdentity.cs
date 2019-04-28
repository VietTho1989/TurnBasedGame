using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
	public class DefaultInternationalDraughtIdentity : DataIdentity
	{

		#region SyncVar

		#region variant

		[SyncVar(hook="onChangeVariant")]
		public System.Int32 variant;

		public void onChangeVariant(System.Int32 newVariant)
		{
			this.variant = newVariant;
			if (this.netData.clientData != null) {
				this.netData.clientData.variant.v = newVariant;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<DefaultInternationalDraught> netData = new NetData<DefaultInternationalDraught>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeVariant(this.variant);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.variant);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is DefaultInternationalDraught) {
				DefaultInternationalDraught defaultInternationalDraught = data as DefaultInternationalDraught;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, defaultInternationalDraught.makeSearchInforms ());
					this.variant = defaultInternationalDraught.variant.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (defaultInternationalDraught);
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
			if (data is DefaultInternationalDraught) {
				// DefaultInternationalDraught defaultInternationalDraught = data as DefaultInternationalDraught;
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
			if (wrapProperty.p is DefaultInternationalDraught) {
				switch ((DefaultInternationalDraught.Property)wrapProperty.n) {
				case DefaultInternationalDraught.Property.variant:
					this.variant = (System.Int32)wrapProperty.getValue ();
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

		#region Change Variant

		public void requestChangeVariant(uint userId, int newVariant)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdDefaultInternationalDraughtChangeVariant (this.netId, userId, newVariant);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeVariant(uint userId, int newVariant)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeVariant (userId, newVariant);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}