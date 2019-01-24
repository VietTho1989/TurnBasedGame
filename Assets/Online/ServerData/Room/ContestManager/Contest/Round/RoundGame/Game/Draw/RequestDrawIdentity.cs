using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawIdentity : DataIdentity
{
	#region SyncVar

	[SyncVar(hook="onChangeTime")]
	public long time;

	public void onChangeTime(long newTime)
	{
		this.time = newTime;
		if (this.netData.clientData != null) {
			this.netData.clientData.time.v = newTime;
		} else {
			// Debug.Log ("clientData null: " + this);
		}
	}

	#endregion

	#region NetData

	private NetData<RequestDraw> netData = new NetData<RequestDraw>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeTime (this.time);
		} else {
			// Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.time);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is RequestDraw) {
			RequestDraw requestDraw = data as RequestDraw;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, requestDraw.makeSearchInforms ());
				this.time = requestDraw.time.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (requestDraw);
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
		if (data is RequestDraw) {
			// RequestDraw requestDraw = data as RequestDraw;
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
		if (wrapProperty.p is RequestDraw) {
			switch ((RequestDraw.Property)wrapProperty.n) {
			case RequestDraw.Property.state:
				break;
			case RequestDraw.Property.time:
				this.time = (long)wrapProperty.getValue ();
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