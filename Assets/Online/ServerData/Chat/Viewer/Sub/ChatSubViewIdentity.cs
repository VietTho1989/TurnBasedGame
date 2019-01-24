using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class ChatSubViewIdentity : DataIdentity
{

	#region SyncVar

	#region min

	[SyncVar(hook="onChangeMin")]
	public System.UInt32 min;

	public void onChangeMin(System.UInt32 newMin)
	{
		this.min = newMin;
		if (this.netData.clientData != null) {
			this.netData.clientData.min.v = newMin;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region max

	[SyncVar(hook="onChangeMax")]
	public System.UInt32 max;

	public void onChangeMax(System.UInt32 newMax)
	{
		this.max = newMax;
		if (this.netData.clientData != null) {
			this.netData.clientData.max.v = newMax;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<ChatSubView> netData = new NetData<ChatSubView>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeMin(this.min);
			this.onChangeMax(this.max);
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.min);
			ret += GetDataSize (this.max);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is ChatSubView) {
			ChatSubView chatSubView = data as ChatSubView;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, chatSubView.makeSearchInforms ());
				this.min = chatSubView.min.v;
				this.max = chatSubView.max.v;
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (chatSubView);
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
		if (data is ChatSubView) {
			// ChatSubView chatSubView = data as ChatSubView;
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
		if (wrapProperty.p is ChatSubView) {
			switch ((ChatSubView.Property)wrapProperty.n) {
			case ChatSubView.Property.min:
				this.min = (System.UInt32)wrapProperty.getValue ();
				break;
			case ChatSubView.Property.max:
				this.max = (System.UInt32)wrapProperty.getValue ();
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