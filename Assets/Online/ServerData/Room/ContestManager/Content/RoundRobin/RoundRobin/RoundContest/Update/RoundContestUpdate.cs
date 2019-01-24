using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundContestUpdate : UpdateBehavior<RoundContest>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {

				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is RoundContest) {
				RoundContest roundContest = data as RoundContest;
				// Update
				{
					UpdateUtils.makeUpdate<RoundContestMakeTeamUpdate, RoundContest> (roundContest, this.transform);
				}
				// Child
				{
					roundContest.contest.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Contest) {
				Contest contest = data as Contest;
				// Update
				{
					UpdateUtils.makeUpdate<ContestUpdate, Contest> (contest, this.transform);
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RoundContest) {
				RoundContest roundContest = data as RoundContest;
				// Update
				{
					roundContest.removeCallBackAndDestroy (typeof(RoundContestMakeTeamUpdate));
				}
				// Child
				{
					roundContest.contest.allRemoveCallBack (this);
				}
				this.setDataNull (roundContest);
				return;
			}
			// Child
			if (data is Contest) {
				Contest contest = data as Contest;
				// Update
				{
					contest.removeCallBackAndDestroy (typeof(ContestUpdate));
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
					break;
				case RoundContest.Property.teamIndexs:
					break;
				case RoundContest.Property.contest:
					{
						ValueChangeUtils.replaceCallBack(this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is Contest) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}