using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class SingleContestContentUpdate : UpdateBehavior<SingleContestContent>
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
			if (data is SingleContestContent) {
				SingleContestContent singleContestContent = data as SingleContestContent;
				// Update
				{
					UpdateUtils.makeUpdate<SingleContestMakePlayerUpdate, SingleContestContent> (singleContestContent, this.transform);
					UpdateUtils.makeUpdate<SingleContestContentCheckEndUpdate, SingleContestContent> (singleContestContent, this.transform);
				}
				// Child
				{
					singleContestContent.contest.allAddCallBack (this);
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
			if (data is SingleContestContent) {
				SingleContestContent singleContestContent = data as SingleContestContent;
				// Update
				{
					singleContestContent.removeCallBackAndDestroy (typeof(SingleContestMakePlayerUpdate));
					singleContestContent.removeCallBackAndDestroy (typeof(SingleContestContentCheckEndUpdate));
				}
				// Child
				{
					singleContestContent.contest.allRemoveCallBack (this);
				}
				this.setDataNull (singleContestContent);
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
			if (wrapProperty.p is SingleContestContent) {
				switch ((SingleContestContent.Property)wrapProperty.n) {
				case SingleContestContent.Property.contest:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
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