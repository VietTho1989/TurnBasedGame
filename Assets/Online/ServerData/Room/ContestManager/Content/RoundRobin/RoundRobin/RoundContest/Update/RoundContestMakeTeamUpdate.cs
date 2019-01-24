using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundContestMakeTeamUpdate : UpdateBehavior<RoundContest>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Contest contest = this.data.contest.v;
					if (contest != null) {
						ContestManagerStatePlay contestManagerStatePlay = this.data.findDataInParent<ContestManagerStatePlay> ();
						if (contestManagerStatePlay != null) {
							foreach (MatchTeam team in contest.teams.vs) {
								// find contestManagerStatePlayTeam
								MatchTeam contestManagerStatePlayTeam = null;
								{
									if (team.teamIndex.v >= 0 && team.teamIndex.v < this.data.teamIndexs.vs.Count) {
										int contestManagerStatePlayTeamIndex = this.data.teamIndexs.vs [team.teamIndex.v];
										contestManagerStatePlayTeam = contestManagerStatePlay.findTeam (contestManagerStatePlayTeamIndex);
									}
								}
								// Copy
								{
									if (contestManagerStatePlayTeam != null) {
										team.copy (contestManagerStatePlayTeam);
									} else {
										Debug.LogError ("contestManagerStatePlayTeam null: " + this);
									}
								}
							}
						} else {
							Debug.LogError ("contestManagerStatePlay null: " + this);
						}
					} else {
						Debug.LogError ("contest null: " + this);
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

		private ContestManagerStatePlayTeamCheckChange<RoundContest> contestManagerStatePlayTeamCheckChange = new ContestManagerStatePlayTeamCheckChange<RoundContest> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RoundContest) {
				RoundContest roundContest = data as RoundContest;
				// CheckChange
				{
					contestManagerStatePlayTeamCheckChange.addCallBack (this);
					contestManagerStatePlayTeamCheckChange.setData (roundContest);
				}
				// Child
				{
					roundContest.contest.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is ContestManagerStatePlayTeamCheckChange<RoundContest>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Contest) {
					Contest contest = data as Contest;
					// Child
					{
						contest.teams.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is MatchTeam) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RoundContest) {
				RoundContest roundContest = data as RoundContest;
				// CheckChange
				{
					contestManagerStatePlayTeamCheckChange.removeCallBack (this);
					contestManagerStatePlayTeamCheckChange.setData (null);
				}
				// Child
				{
					roundContest.contest.allRemoveCallBack (this);
				}
				this.setDataNull (roundContest);
				return;
			}
			// CheckChange
			if (data is ContestManagerStatePlayTeamCheckChange<RoundContest>) {
				return;
			}
			// Child
			{
				if (data is Contest) {
					Contest contest = data as Contest;
					// Child
					{
						contest.teams.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is MatchTeam) {
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
			if (wrapProperty.p is RoundContest) {
				switch ((RoundContest.Property)wrapProperty.n) {
				case RoundContest.Property.index:
					break;
				case RoundContest.Property.teamIndexs:
					dirty = true;
					break;
				case RoundContest.Property.contest:
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
			if (wrapProperty.p is ContestManagerStatePlayTeamCheckChange<RoundContest>) {
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
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
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
				// Child
				if (wrapProperty.p is MatchTeam) {
					switch ((MatchTeam.Property)wrapProperty.n) {
					case MatchTeam.Property.teamIndex:
						dirty = true;
						break;
					case MatchTeam.Property.state:
						break;
					case MatchTeam.Property.players:
						dirty = true;
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