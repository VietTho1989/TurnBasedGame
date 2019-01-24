using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobinContentIdentity : DataIdentity
	{

		#region SyncVar

		#region roundRobins

		[SyncVar]
		public int roundRobins;

		#endregion

		#region needReturnRound

		[SyncVar(hook="onChangeNeedReturnRound")]
		public System.Boolean needReturnRound;

		public void onChangeNeedReturnRound(System.Boolean newNeedReturnRound)
		{
			this.needReturnRound = newNeedReturnRound;
			if (this.netData.clientData != null) {
				this.netData.clientData.needReturnRound.v = newNeedReturnRound;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<RoundRobinContent> netData = new NetData<RoundRobinContent>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeNeedReturnRound(this.needReturnRound);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.needReturnRound);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is RoundRobinContent) {
				RoundRobinContent roundRobinContent = data as RoundRobinContent;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, roundRobinContent.makeSearchInforms ());
					this.roundRobins = roundRobinContent.roundRobins.vs.Count;
					this.needReturnRound = roundRobinContent.needReturnRound.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.checkChange.setData (roundRobinContent);
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
			if (data is RoundRobinContent) {
				// RoundRobinContent roundRobinContent = data as RoundRobinContent;
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
			if (wrapProperty.p is RoundRobinContent) {
				switch ((RoundRobinContent.Property)wrapProperty.n) {
				case RoundRobinContent.Property.singleContestFactory:
					break;
				case RoundRobinContent.Property.roundRobins:
					{
						RoundRobinContent roundRobinContent = wrapProperty.p as RoundRobinContent;
						this.roundRobins = roundRobinContent.roundRobins.vs.Count;
					}
					break;
				case RoundRobinContent.Property.requestNewRoundRobin:
					break;
				case RoundRobinContent.Property.needReturnRound:
					this.needReturnRound = (System.Boolean)wrapProperty.getValue ();
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