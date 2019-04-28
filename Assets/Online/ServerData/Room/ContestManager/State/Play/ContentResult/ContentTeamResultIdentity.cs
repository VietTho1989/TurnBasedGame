using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContentTeamResultIdentity : DataIdentity
	{


		#region SyncVar

		#region isEnd

		[SyncVar(hook="onChangeIsEnd")]
		public System.Boolean isEnd;

		public void onChangeIsEnd(System.Boolean newIsEnd)
		{
			this.isEnd = newIsEnd;
			if (this.netData.clientData != null) {
				this.netData.clientData.isEnd.v = newIsEnd;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<ContentTeamResult> netData = new NetData<ContentTeamResult>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeIsEnd(this.isEnd);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.isEnd);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is ContentTeamResult) {
				ContentTeamResult contentTeamResult = data as ContentTeamResult;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, contentTeamResult.makeSearchInforms ());
					this.isEnd = contentTeamResult.isEnd.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (contentTeamResult);
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
			if (data is ContentTeamResult) {
				// ContentTeamResult contentTeamResult = data as ContentTeamResult;
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
			if (wrapProperty.p is ContentTeamResult) {
				switch ((ContentTeamResult.Property)wrapProperty.n) {
				case ContentTeamResult.Property.isEnd:
					this.isEnd = (System.Boolean)wrapProperty.getValue ();
					break;
				case ContentTeamResult.Property.teamResults:
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
}