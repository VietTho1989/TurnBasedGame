using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class UndoRedoRequestIdentity : DataIdentity
{

	#region NetData

	private NetData<UndoRedoRequest> netData = new NetData<UndoRedoRequest>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void addSyncListCallBack ()
	{
		base.addSyncListCallBack ();
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {

		} else {
			// Debug.Log ("clientData null: " + this);
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{

		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is UndoRedoRequest) {
			UndoRedoRequest undoRedoRequest = data as UndoRedoRequest;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, undoRedoRequest.makeSearchInforms ());
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (undoRedoRequest);
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
		if (data is UndoRedoRequest) {
			// UndoRedoRequest undoRedoRequest = data as UndoRedoRequest;
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
		if (wrapProperty.p is UndoRedoRequest) {
			switch ((UndoRedoRequest.Property)wrapProperty.n) {
			case UndoRedoRequest.Property.state:
				break;
			default:
				Debug.LogError ("unknown property: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}