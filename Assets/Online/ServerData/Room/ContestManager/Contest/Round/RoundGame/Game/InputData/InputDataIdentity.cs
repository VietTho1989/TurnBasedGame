using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class InputDataIdentity : DataIdentity
{
	#region SyncVar

	#region UserSend

	[SyncVar(hook="onChangeUserSend")]
	public System.UInt32 userSend;

	public void onChangeUserSend(System.UInt32 newUserSend)
	{
		this.userSend = newUserSend;
		if (this.netData.clientData != null) {
			this.netData.clientData.userSend.v = newUserSend;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#region serverTime

	[SyncVar(hook="onChangeServerTime")]
	public float serverTime;

	public void onChangeServerTime(float newServerTime)
	{
		this.serverTime = newServerTime;
		if (this.netData.clientData != null) {
			this.netData.clientData.serverTime.v = newServerTime;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#region clientTime

	[SyncVar(hook="onChangeClientTime")]
	public float clientTime;

	public void onChangeClientTime(float newClientTime)
	{
		this.clientTime = newClientTime;
		if (this.netData.clientData != null) {
			this.netData.clientData.clientTime.v = newClientTime;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<InputData> netData = new NetData<InputData>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeUserSend (this.userSend);
			this.onChangeServerTime (this.serverTime);
			this.onChangeClientTime (this.clientTime);
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.userSend);
			ret += GetDataSize (this.serverTime);
			ret += GetDataSize (this.clientTime);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is InputData) {
			InputData inputData = data as InputData;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, inputData.makeSearchInforms ());
				this.userSend = inputData.userSend.v;
				this.serverTime = inputData.serverTime.v;
				this.clientTime = inputData.clientTime.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (inputData);
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
		if (data is InputData) {
			// InputData inputData = data as InputData;
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
		if (wrapProperty.p is InputData) {
			switch ((InputData.Property)wrapProperty.n) {
			case InputData.Property.gameMove:
				break;
			case InputData.Property.userSend:
				this.userSend = (uint)wrapProperty.getValue ();
				break;
			case InputData.Property.serverTime:
				this.serverTime = (float)wrapProperty.getValue ();
				break;
			case InputData.Property.clientTime:
				this.clientTime = (float)wrapProperty.getValue ();
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}
		
	#endregion
}