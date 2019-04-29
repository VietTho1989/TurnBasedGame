using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

[NetworkSettings(channel = DataIdentity.ChatChanel)]
public class TypingPlayerIdentity : DataIdentity
{

	#region SyncVar

	[SyncVar(hook="onChangePlayerId")]
	public System.UInt32 playerId;

	public void onChangePlayerId(System.UInt32 newPlayerId)
	{
		this.playerId = newPlayerId;
		if (this.netData.clientData != null) {
			this.netData.clientData.playerId.v = newPlayerId;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	[SyncVar(hook="onChangeState")]
	public TypingPlayer.State state;

	public void onChangeState(TypingPlayer.State newState)
	{
		this.state = newState;
		if (this.netData.clientData != null) {
			this.netData.clientData.state.v = newState;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#region NetData

	private NetData<TypingPlayer> netData = new NetData<TypingPlayer>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangePlayerId(this.playerId);
			this.onChangeState(this.state);
		} else {
			// Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.playerId);
			ret += 4;// GetDataSize (this.state);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is TypingPlayer) {
			TypingPlayer typingPlayer = data as TypingPlayer;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, typingPlayer.makeSearchInforms ());
				this.playerId = typingPlayer.playerId.v;
				this.state = typingPlayer.state.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (typingPlayer);
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
		if (data is TypingPlayer) {
			// TypingPlayer typingPlayer = data as TypingPlayer;
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
		if (wrapProperty.p is TypingPlayer) {
			switch ((TypingPlayer.Property)wrapProperty.n) {
			case TypingPlayer.Property.playerId:
				this.playerId = (System.UInt32)(object)wrapProperty.getValue();
				break;
			case TypingPlayer.Property.state:
				this.state = (TypingPlayer.State)wrapProperty.getValue ();
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