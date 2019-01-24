using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestIdentity : DataIdentity
	{

		#region SyncVar

		#region playerPerTeam

		[SyncVar(hook="onChangePlayerPerTeam")]
		public System.Int32 playerPerTeam;

		public void onChangePlayerPerTeam(System.Int32 newPlayerPerTeam)
		{
			this.playerPerTeam = newPlayerPerTeam;
			if (this.netData.clientData != null) {
				this.netData.clientData.playerPerTeam.v = newPlayerPerTeam;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region rounds

		[SyncVar]
		public int rounds;

		#endregion

		#endregion

		#region NetData

		private NetData<Contest> netData = new NetData<Contest>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangePlayerPerTeam(this.playerPerTeam);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.playerPerTeam);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is Contest) {
				Contest contest = data as Contest;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, contest.makeSearchInforms ());
					this.playerPerTeam = contest.playerPerTeam.v;
					this.rounds = contest.rounds.vs.Count;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (contest);
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
			if (data is Contest) {
				// Contest contest = data as Contest;
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
			if (wrapProperty.p is Contest) {
				switch ((Contest.Property)wrapProperty.n) {
				case Contest.Property.state:
					break;
				case Contest.Property.playerPerTeam:
					this.playerPerTeam = (System.Int32)wrapProperty.getValue ();
					break;
				case Contest.Property.teams:
					break;
				case Contest.Property.roundFactory:
					break;
				case Contest.Property.rounds:
					{
						Contest contest = wrapProperty.p as Contest;
						this.rounds = contest.rounds.vs.Count;
					}
					break;
				case Contest.Property.requestNewRound:
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