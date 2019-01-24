using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class SingleContestMakePlayerUpdate : UpdateBehavior<SingleContestContent>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ContestManagerStatePlay contestManagerStatePlay = this.data.findDataInParent<ContestManagerStatePlay> ();
					if (contestManagerStatePlay != null) {
						Contest contest = this.data.contest.v;
						if (contest != null) {
							foreach (MatchTeam team in contest.teams.vs) {
								MatchTeam playTeam = contestManagerStatePlay.findTeam (team.teamIndex.v);
								if (playTeam != null) {
									team.copy (playTeam);
								} else {
									Debug.LogError ("playTeam null: " + this);
								}
							}
						} else {
							Debug.LogError ("contest null: " + this);
						}
					} else {
						Debug.LogError ("contestManagerStatePlay null: " + this);
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

		private ContestManagerStatePlayTeamCheckChange<SingleContestContent> contestManagerStatePlayTeamCheckChange = new ContestManagerStatePlayTeamCheckChange<SingleContestContent> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is SingleContestContent) {
				SingleContestContent singleContestContent = data as SingleContestContent;
				// CheckChange
				{
					contestManagerStatePlayTeamCheckChange.addCallBack (this);
					contestManagerStatePlayTeamCheckChange.setData (singleContestContent);
				}
				// Child
				{
					singleContestContent.contest.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is ContestManagerStatePlayTeamCheckChange<SingleContestContent>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Contest) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is SingleContestContent) {
				SingleContestContent singleContestContent = data as SingleContestContent;
				// CheckChange
				{
					contestManagerStatePlayTeamCheckChange.removeCallBack (this);
					contestManagerStatePlayTeamCheckChange.setData (null);
				}
				// Child
				{
					singleContestContent.contest.allRemoveCallBack (this);
				}
				this.setDataNull (singleContestContent);
				return;
			}
			// CheckChange
			if (data is ContestManagerStatePlayTeamCheckChange<SingleContestContent>) {
				return;
			}
			// Child
			{
				if (data is Contest) {
					return;
				}
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
			// CheckChange
			if (wrapProperty.p is ContestManagerStatePlayTeamCheckChange<SingleContestContent>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (wrapProperty.p is Contest) {
					switch ((Contest.Property)wrapProperty.n) {
					case Contest.Property.state:
						break;
					case Contest.Property.playerPerTeam:
						break;
					case Contest.Property.teams:
						dirty = true;
						break;
					case Contest.Property.roundFactory:
						break;
					case Contest.Property.rounds:
						break;
					case Contest.Property.requestNewRound:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}