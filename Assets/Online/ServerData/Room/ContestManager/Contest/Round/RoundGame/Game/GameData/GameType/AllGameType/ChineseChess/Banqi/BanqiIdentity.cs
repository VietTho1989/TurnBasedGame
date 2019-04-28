using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class BanqiIdentity : DataIdentity
	{

		#region SyncVar

		#region color

		[SyncVar(hook="onChangeColor")]
		public Token.Ecolor color;

		public void onChangeColor(Token.Ecolor newColor)
		{
			this.color = newColor;
			if (this.netData.clientData != null) {
				this.netData.clientData.color.v = newColor;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region state

		[SyncVar(hook="onChangeState")]
		public System.String state;

		public void onChangeState(System.String newState)
		{
			this.state = newState;
			if (this.netData.clientData != null) {
				this.netData.clientData.state.v = newState;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region isCustom

		[SyncVar(hook="onChangeIsCustom")]
		public System.Boolean isCustom;

		public void onChangeIsCustom(System.Boolean newIsCustom)
		{
			this.isCustom = newIsCustom;
			if (this.netData.clientData != null) {
				this.netData.clientData.isCustom.v = newIsCustom;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<Banqi> netData = new NetData<Banqi>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeColor(this.color);
				this.onChangeState(this.state);
				this.onChangeIsCustom(this.isCustom);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.color);
				ret += GetDataSize (this.state);
				ret += GetDataSize (this.isCustom);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is Banqi) {
				Banqi banqi = data as Banqi;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, banqi.makeSearchInforms ());
					this.color = banqi.color.v;
					this.state = banqi.state.v;
					this.isCustom = banqi.isCustom.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (banqi);
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
			if (data is Banqi) {
				// Banqi banqi = data as Banqi;
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
			if (wrapProperty.p is Banqi) {
				switch ((Banqi.Property)wrapProperty.n) {
				case Banqi.Property.color:
					this.color = (Token.Ecolor)wrapProperty.getValue ();
					break;
				case Banqi.Property.state:
					this.state = (System.String)wrapProperty.getValue ();
					break;
				case Banqi.Property.isCustom:
					this.isCustom = (System.Boolean)wrapProperty.getValue ();
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