using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class TeamResultIdentity : DataIdentity
	{

		#region SyncVar

		#region teamIndex

		[SyncVar(hook="onChangeTeamIndex")]
		public System.Int32 teamIndex;

		public void onChangeTeamIndex(System.Int32 newTeamIndex)
		{
			this.teamIndex = newTeamIndex;
			if (this.netData.clientData != null) {
				this.netData.clientData.teamIndex.v = newTeamIndex;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region score

		[SyncVar(hook="onChangeScore")]
		public System.Single score;

		public void onChangeScore(System.Single newScore)
		{
			this.score = newScore;
			if (this.netData.clientData != null) {
				this.netData.clientData.score.v = newScore;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<TeamResult> netData = new NetData<TeamResult>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeTeamIndex(this.teamIndex);
				this.onChangeScore(this.score);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.teamIndex);
				ret += GetDataSize (this.score);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is TeamResult) {
				TeamResult teamResult = data as TeamResult;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, teamResult.makeSearchInforms ());
					this.teamIndex = teamResult.teamIndex.v;
					this.score = teamResult.score.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (teamResult);
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
			if (data is TeamResult) {
				// TeamResult teamResult = data as TeamResult;
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
			if (wrapProperty.p is TeamResult) {
				switch ((TeamResult.Property)wrapProperty.n) {
				case TeamResult.Property.teamIndex:
					this.teamIndex = (System.Int32)wrapProperty.getValue ();
					break;
				case TeamResult.Property.score:
					this.score = (System.Single)wrapProperty.getValue ();
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