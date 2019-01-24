using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class WaitAIInputIdentity : DataIdentity
{

	#region SyncVar

	#region userThink

	[SyncVar(hook="onChangeUserThink")]
	public System.UInt32 userThink;

	public void onChangeUserThink(System.UInt32 newUserThink)
	{
		this.userThink = newUserThink;
		if (this.netData.clientData != null) {
			this.netData.clientData.userThink.v = newUserThink;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region reThink

	[SyncVar(hook="onChangeRethink")]
	public System.UInt32 rethink;

	public void onChangeRethink(System.UInt32 newRethink)
	{
		this.rethink = newRethink;
		if (this.netData.clientData != null) {
			this.netData.clientData.rethink.v = newRethink;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region isGettingSolvedMove

	[SyncVar(hook="onChangeIsGettingSolvedMove")]
	public bool isGettingSolvedMove;

	public void onChangeIsGettingSolvedMove(bool newIsGettingSolvedMove)
	{
		this.isGettingSolvedMove = newIsGettingSolvedMove;
		if (this.netData.clientData != null) {
			this.netData.clientData.isGettingSolvedMove.v = newIsGettingSolvedMove;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<WaitAIInput> netData = new NetData<WaitAIInput>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void afterAddNewDataToClient ()
	{
		base.afterAddNewDataToClient ();
		UpdateUtils.makeUpdate<WaitAIInputUpdate, WaitAIInput> (this.netData.clientData, this.transform);
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeUserThink(this.userThink);
			this.onChangeRethink (this.rethink);
			this.onChangeIsGettingSolvedMove (this.isGettingSolvedMove);
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.userThink);
			ret += GetDataSize (this.rethink);
			ret += GetDataSize (this.isGettingSolvedMove);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is WaitAIInput) {
			WaitAIInput waitAIInput = data as WaitAIInput;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, waitAIInput.makeSearchInforms ());
				this.userThink = waitAIInput.userThink.v;
				this.rethink = waitAIInput.rethink.v;
				this.isGettingSolvedMove = waitAIInput.isGettingSolvedMove.v;
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (waitAIInput);
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
		if (data is WaitAIInput) {
			// WaitAIInput waitAIInput = data as WaitAIInput;
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
		if (wrapProperty.p is WaitAIInput) {
			switch ((WaitAIInput.Property)wrapProperty.n) {
			case WaitAIInput.Property.userThink:
				this.userThink = (System.UInt32)wrapProperty.getValue ();
				break;
			case WaitAIInput.Property.reThink:
				this.rethink = (System.UInt32)wrapProperty.getValue ();
				break;
			case WaitAIInput.Property.sub:
				break;
			case WaitAIInput.Property.isGettingSolvedMove:
				this.isGettingSolvedMove = (bool)wrapProperty.getValue ();
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