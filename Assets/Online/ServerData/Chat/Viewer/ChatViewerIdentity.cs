using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class ChatViewerIdentity : DataIdentity
{

	#region SyncVar

	#region userId

	[SyncVar(hook="onChangeUserId")]
	public System.UInt32 userId;

	public void onChangeUserId(System.UInt32 newUserId)
	{
		this.userId = newUserId;
		if (this.netData.clientData != null) {
			this.netData.clientData.userId.v = newUserId;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region minViewId

	[SyncVar(hook="onChangeMinViewId")]
	public System.UInt32 minViewId;

	public void onChangeMinViewId(System.UInt32 newMinViewId)
	{
		this.minViewId = newMinViewId;
		if (this.netData.clientData != null) {
			this.netData.clientData.minViewId.v = newMinViewId;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#endregion

	#region NetData

	public NetData<ChatViewer> netData = new NetData<ChatViewer>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeUserId(this.userId);
			this.onChangeMinViewId(this.minViewId);
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.userId);
			ret += GetDataSize (this.minViewId);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is ChatViewer) {
			ChatViewer chatViewer = data as ChatViewer;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, chatViewer.makeSearchInforms ());
				this.userId = chatViewer.userId.v;
				this.minViewId = chatViewer.minViewId.v;
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new ChatViewerObserver (observer);
					observer.setCheckChangeData (chatViewer);
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
		if (data is ChatViewer) {
			// ChatViewer chatViewer = data as ChatViewer;
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
		if (wrapProperty.p is ChatViewer) {
			switch ((ChatViewer.Property)wrapProperty.n) {
			case ChatViewer.Property.userId:
				this.userId = (System.UInt32)wrapProperty.getValue ();
				break;
			case ChatViewer.Property.minViewId:
				this.minViewId = (System.UInt32)wrapProperty.getValue ();
				break;
			case ChatViewer.Property.subViews:
				break;
			case ChatViewer.Property.connection:
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