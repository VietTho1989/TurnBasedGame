using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match.RoundRobin;
using GameManager.Match.Elimination;

namespace GameManager.Match
{
	public class ContestManagerContentUpdate : UpdateBehavior<ContestManagerContent>
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
			if (data is ContestManagerContent) {
				ContestManagerContent contestManagerContent = data as ContestManagerContent;
				// Update
				{
					switch (contestManagerContent.getType ()) {
					case ContestManagerContent.Type.Single:
						{
							SingleContestContent singleContestContent = contestManagerContent as SingleContestContent;
							UpdateUtils.makeUpdate<SingleContestContentUpdate, SingleContestContent> (singleContestContent, this.transform);
						}
						break;
					case ContestManagerContent.Type.RoundRobin:
						{
							RoundRobinContent roundRobinContent = contestManagerContent as RoundRobinContent;
							UpdateUtils.makeUpdate<RoundRobinContentUpdate, RoundRobinContent> (roundRobinContent, this.transform);
						}
						break;
					case ContestManagerContent.Type.Elimination:
						{
							EliminationContent eliminationContent = contestManagerContent as EliminationContent;
							UpdateUtils.makeUpdate<EliminationContentUpdate, EliminationContent> (eliminationContent, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + contestManagerContent.getType () + "; " + this);
						break;
					}
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is ContestManagerContent) {
				ContestManagerContent contestManagerContent = data as ContestManagerContent;
				// Update
				{
					switch (contestManagerContent.getType ()) {
					case ContestManagerContent.Type.Single:
						{
							SingleContestContent singleContestContent = contestManagerContent as SingleContestContent;
							singleContestContent.removeCallBackAndDestroy (typeof(SingleContestContentUpdate));
						}
						break;
					case ContestManagerContent.Type.RoundRobin:
						{
							RoundRobinContent roundRobinContent = contestManagerContent as RoundRobinContent;
							roundRobinContent.removeCallBackAndDestroy (typeof(RoundRobinContentUpdate));
						}
						break;
					case ContestManagerContent.Type.Elimination:
						{
							EliminationContent eliminationContent = contestManagerContent as EliminationContent;
							eliminationContent.removeCallBackAndDestroy (typeof(EliminationContentUpdate));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + contestManagerContent.getType () + "; " + this);
						break;
					}
				}
				this.setDataNull (contestManagerContent);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is ContestManagerContent) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}