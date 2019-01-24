using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundContestIdentity : DataIdentity
	{

		#region SyncVar

		#region index

		[SyncVar(hook="onChangeIndex")]
		public System.Int32 index;

		public void onChangeIndex(System.Int32 newIndex)
		{
			this.index = newIndex;
			if (this.netData.clientData != null) {
				this.netData.clientData.index.v = newIndex;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region teamIndexs

		public SyncListInt teamIndexs = new SyncListInt();

		private void OnTeamIndexsChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.teamIndexs, this.teamIndexs, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#endregion

		#region NetData

		private NetData<RoundContest> netData = new NetData<RoundContest>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.teamIndexs.Callback += OnTeamIndexsChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeIndex(this.index);
				IdentityUtils.refresh(this.netData.clientData.teamIndexs, this.teamIndexs);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.index);
				ret += GetDataSize (this.teamIndexs);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is RoundContest) {
				RoundContest roundContest = data as RoundContest;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, roundContest.makeSearchInforms ());
					this.index = roundContest.index.v;
					IdentityUtils.InitSync(this.teamIndexs, roundContest.teamIndexs.vs);
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (roundContest);
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
			if (data is RoundContest) {
				// RoundContest roundContest = data as RoundContest;
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
			if (wrapProperty.p is RoundContest) {
				switch ((RoundContest.Property)wrapProperty.n) {
				case RoundContest.Property.index:
					this.index = (System.Int32)wrapProperty.getValue ();
					break;
				case RoundContest.Property.teamIndexs:
					IdentityUtils.UpdateSyncList (this.teamIndexs, syncs, GlobalCast<T>.CastingInt32);
					break;
				case RoundContest.Property.contest:
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