using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeUseRuleIdentity : DataIdentity
{

	#region SyncVar

	#endregion

	#region NetData

	private NetData<RequestChangeUseRule> netData = new NetData<RequestChangeUseRule>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
		} else {
			Debug.Log ("clientData null");
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
		if (data is RequestChangeUseRule) {
			RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, requestChangeUseRule.makeSearchInforms ());
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (requestChangeUseRule);
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
		if (data is RequestChangeUseRule) {
			// RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
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
		if (wrapProperty.p is RequestChangeUseRule) {
			switch ((RequestChangeUseRule.Property)wrapProperty.n) {
			case RequestChangeUseRule.Property.state:
				break;
			case RequestChangeUseRule.Property.whoCanAsks:
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