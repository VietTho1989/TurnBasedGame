using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class StartTurnActionIdentity : DataIdentity
{

	#region SyncVar

	[SyncVar(hook="onChangeState")]
	public StartTurnAction.State state;

	public void onChangeState(StartTurnAction.State newState)
	{
		this.state = newState;
		if (this.netData.clientData != null) {
			this.netData.clientData.state.v = newState;
		} else {
			// Debug.Log ("clientData null");
		}
	}

	#endregion

	#region NetData

	private NetData<StartTurnAction> netData = new NetData<StartTurnAction>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeState(this.state);
		} else {
			// Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += 4;// GetDataSize (this.state);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is StartTurnAction) {
			StartTurnAction startTurnAction = data as StartTurnAction;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, startTurnAction.makeSearchInforms ());
				this.state = startTurnAction.state.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (startTurnAction);
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
		if (data is StartTurnAction) {
			// StartTurnAction startTurnAction = data as StartTurnAction;
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
		if (wrapProperty.p is StartTurnAction) {
			switch ((StartTurnAction.Property)wrapProperty.n) {
			case StartTurnAction.Property.state:
				this.state = (StartTurnAction.State)(object)wrapProperty.getValue ();
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}