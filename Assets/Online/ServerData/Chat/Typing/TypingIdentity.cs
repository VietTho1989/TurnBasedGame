using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

[NetworkSettings(channel = DataIdentity.ChatChanel)]
public class TypingIdentity : DataIdentity
{

	#region SyncVar

	[SyncVar(hook="onChangeIsEnable")]
	public System.Boolean isEnable;

	public void onChangeIsEnable(System.Boolean newIsEnable)
	{
		this.isEnable = newIsEnable;
		if (this.netData.clientData != null) {
			this.netData.clientData.isEnable.v = newIsEnable;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	[SyncVar(hook="onChangeNextReceiveTime")]
	public System.Single nextReceiveTime;

	public void onChangeNextReceiveTime(System.Single newNextReceiveTime)
	{
		this.nextReceiveTime = newNextReceiveTime;
		if (this.netData.clientData != null) {
			this.netData.clientData.nextReceiveTime.v = newNextReceiveTime;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	[SyncVar(hook="onChangeStopDuration")]
	public System.Single stopDuration;

	public void onChangeStopDuration(System.Single newStopDuration)
	{
		this.stopDuration = newStopDuration;
		if (this.netData.clientData != null) {
			this.netData.clientData.stopDuration.v = newStopDuration;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#region NetData

	private NetData<Typing> netData = new NetData<Typing>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeIsEnable(this.isEnable);
			this.onChangeNextReceiveTime(this.nextReceiveTime);
			this.onChangeStopDuration(this.stopDuration);
		} else {
			// Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.isEnable);
			ret += GetDataSize (this.nextReceiveTime);
			ret += GetDataSize (this.stopDuration);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is Typing) {
			Typing typing = data as Typing;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, typing.makeSearchInforms ());
				this.isEnable = typing.isEnable.v;
				this.nextReceiveTime = typing.nextReceiveTime.v;
				this.stopDuration = typing.stopDuration.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (typing);
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
		if (data is Typing) {
			// Typing typing = data as Typing;
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
		if (wrapProperty.p is Typing) {
			switch ((Typing.Property)wrapProperty.n) {
			case Typing.Property.isEnable:
				this.isEnable = (bool)wrapProperty.getValue ();
				break;
			case Typing.Property.nextReceiveTime:
				this.nextReceiveTime = (float)wrapProperty.getValue ();
				break;
			case Typing.Property.stopDuration:
				this.stopDuration = (float)wrapProperty.getValue ();
				break;
			case Typing.Property.typingPlayers:
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

	#region Send Typing

	public void requestSendTyping(uint userId)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdTypingSendTyping (this.netId, userId);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void sendTyping(uint userId)
	{
		if (this.netData.serverData != null) {
			this.netData.serverData.sendTyping (userId);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

}