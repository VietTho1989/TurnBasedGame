using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationContentIdentity : DataIdentity
	{

		#region SyncVar

		#region initTeamCounts

		public SyncListUInt initTeamCounts = new SyncListUInt();

		private void OnInitTeamCountsChanged(SyncListUInt.Operation op, int index)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.initTeamCounts, this.initTeamCounts, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region rounds

		[SyncVar]
		public int rounds;

		#endregion

		#endregion

		#region NetData

		private NetData<EliminationContent> netData = new NetData<EliminationContent>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.initTeamCounts.Callback += OnInitTeamCountsChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				IdentityUtils.refresh(this.netData.clientData.initTeamCounts, this.initTeamCounts);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.initTeamCounts);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is EliminationContent) {
				EliminationContent eliminationContent = data as EliminationContent;
				// Set new parent
				this.addTransformToParent ();
				// Set property
				{
					this.serialize (this.searchInfor, eliminationContent.makeSearchInforms ());
					IdentityUtils.InitSync (this.initTeamCounts, eliminationContent.initTeamCounts.vs);
					this.rounds = eliminationContent.rounds.vs.Count;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (eliminationContent);
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
			if (data is EliminationContent) {
				// EliminationContent eliminationContent = data as EliminationContent;
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
			if (wrapProperty.p is EliminationContent) {
				switch ((EliminationContent.Property)wrapProperty.n) {
				case EliminationContent.Property.singleContestFactory:
					break;
				case EliminationContent.Property.initTeamCounts:
					IdentityUtils.UpdateSyncList (this.initTeamCounts, syncs, GlobalCast<T>.CastingUInt32);
					break;
				case EliminationContent.Property.requestNewRound:
					break;
				case EliminationContent.Property.rounds:
					{
						EliminationContent eliminationContent = wrapProperty.p as EliminationContent;
						this.rounds = eliminationContent.rounds.vs.Count;
					}
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