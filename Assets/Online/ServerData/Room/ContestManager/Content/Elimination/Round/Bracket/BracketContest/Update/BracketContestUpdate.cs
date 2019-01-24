using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class BracketContestUpdate : UpdateBehavior<BracketContest>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (this.data.isActive.v) {
						// Contest
						{
							Contest contest = this.data.contest.v;
							if (contest != null) {
								UpdateUtils.makeUpdate<ContestUpdate, Contest> (contest, this.transform);
							} else {
								Debug.LogError ("contest null: " + this);
							}
						}
						// make team
						UpdateUtils.makeUpdate<BracketContestMakeTeamUpdate, BracketContest> (this.data, this.transform);
					} else {
						// Contest
						{
							Contest contest = this.data.contest.v;
							if (contest != null) {
								contest.removeCallBackAndDestroy (typeof(ContestUpdate));
							} else {
								Debug.LogError ("contest null: " + this);
							}
						}
						// make team
						this.data.removeCallBackAndDestroy(typeof(BracketContestMakeTeamUpdate));
					}
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
			if (data is BracketContest) {
				BracketContest bracketContest = data as BracketContest;
				// Update
				{
					
				}
				// Child
				{
					bracketContest.contest.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Contest) {
				// Contest contest = data as Contest;
				// Update
				{
					
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is BracketContest) {
				BracketContest bracketContest = data as BracketContest;
				// Update
				{
					bracketContest.removeCallBackAndDestroy (typeof(BracketContestMakeTeamUpdate));
				}
				// Child
				{
					bracketContest.contest.allRemoveCallBack (this);
				}
				this.setDataNull (bracketContest);
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
			if (wrapProperty.p is BracketContest) {
				switch ((BracketContest.Property)wrapProperty.n) {
				case BracketContest.Property.isActive:
					dirty = true;
					break;
				case BracketContest.Property.index:
					break;
				case BracketContest.Property.teamIndexs:
					break;
				case BracketContest.Property.contest:
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