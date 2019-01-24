using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobinCheckEndUpdate : UpdateBehavior<RoundRobin>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					bool allRoundGameEnd = true;
					// init teamResults list
					List<TeamResult> newTeamResults = new List<TeamResult> ();
					{
						ContestManagerStatePlay contestManagerStatePlay = this.data.findDataInParent<ContestManagerStatePlay> ();
						if (contestManagerStatePlay != null) {
							foreach (MatchTeam team in contestManagerStatePlay.teams.vs) {
								TeamResult teamResult = new TeamResult ();
								{
									teamResult.teamIndex.v = team.teamIndex.v;
								}
								newTeamResults.Add (teamResult);
							}
						} else {
							Debug.LogError ("contestManagerStatePlay null: " + this);
						}
					}
					// get score
					{
						foreach (RoundContest roundContest in this.data.roundContests.vs) {
							Contest contest = roundContest.contest.v;
							if (contest.state.v.getType () == ContestState.Type.End) {
								foreach (TeamResult newTeamResult in newTeamResults) {
									newTeamResult.score.v += roundContest.getResult (newTeamResult.teamIndex.v);
								}
							} else {
								allRoundGameEnd = false;
								break;
							}
						}
					}
					// Process
					{
						if (allRoundGameEnd) {
							// Find
							RoundRobinStateEnd roundRobinStateEnd = null;
							{
								// find old
								if (this.data.state.v is RoundRobinStateEnd) {
									roundRobinStateEnd = this.data.state.v as RoundRobinStateEnd;
								}
								// make new
								if (roundRobinStateEnd == null) {
									roundRobinStateEnd = new RoundRobinStateEnd ();
									{
										roundRobinStateEnd.uid = this.data.state.makeId ();
									}
									this.data.state.v = roundRobinStateEnd;
								}
							}
							// Update
							{
								// get old
								List<TeamResult> oldTeamResults = new List<TeamResult>();
								{
									oldTeamResults.AddRange (roundRobinStateEnd.teamResults.vs);
								}
								// Update
								{
									foreach (TeamResult newTeamResult in newTeamResults) {
										// Find 
										TeamResult teamResult = null;
										{
											// find old
											if (oldTeamResults.Count > 0) {
												teamResult = oldTeamResults [0];
											}
											// make new
											if (teamResult == null) {
												teamResult = new TeamResult ();
												{
													teamResult.uid = roundRobinStateEnd.teamResults.makeId ();
												}
												roundRobinStateEnd.teamResults.add (teamResult);
											} else {
												oldTeamResults.Remove (teamResult);
											}
										}
										// Update
										{
											teamResult.teamIndex.v = newTeamResult.teamIndex.v;
											teamResult.score.v = newTeamResult.score.v;
										}
									}
								}
								// remove old
								foreach (TeamResult oldTeamResult in oldTeamResults) {
									roundRobinStateEnd.teamResults.remove (oldTeamResult);
								}
							}
						} else {
							// chuyen sang play
							if (!(this.data.state.v is RoundRobinStatePlay)) {
								RoundRobinStatePlay roundRobinStatePlay = new RoundRobinStatePlay ();
								{
									roundRobinStatePlay.uid = this.data.state.makeId ();
								}
								this.data.state.v = roundRobinStatePlay;
							}
						}
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

		private ContestManagerStatePlay contestManagerStatePlay = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is RoundRobin) {
				RoundRobin roundRobin = data as RoundRobin;
				// Parent
				{
					DataUtils.addParentCallBack (roundRobin, this, ref this.contestManagerStatePlay);
				}
				// Child
				{
					roundRobin.roundContests.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is ContestManagerStatePlay) {
					ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
					// Child
					{
						contestManagerStatePlay.teams.allAddCallBack (this);
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
			// Child
			{
				if (data is RoundContest) {
					RoundContest roundContest = data as RoundContest;
					// Child
					{
						roundContest.contest.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is Contest) {
						Contest contest = data as Contest;
						// Child
						{
							contest.state.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is ContestState) {
							ContestState contestState = data as ContestState;
							// Child
							{
								switch (contestState.getType ()) {
								case ContestState.Type.Load:
									break;
								case ContestState.Type.Start:
									break;
								case ContestState.Type.Play:
									break;
								case ContestState.Type.End:
									{
										ContestStateEnd contestStateEnd = contestState as ContestStateEnd;
										contestStateEnd.teamResults.allAddCallBack (this);
									}
									break;
								default:
									Debug.LogError ("unknown type: " + contestState.getType () + "; " + this);
									break;
								}
							}
							dirty = true;
							return;
						}
						// Child
						if (data is TeamResult) {
							dirty = true;
							return;
						}
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RoundRobin) {
				RoundRobin roundRobin = data as RoundRobin;
				// Parent
				{
					DataUtils.removeParentCallBack (roundRobin, this, ref this.contestManagerStatePlay);
				}
				// Child
				{
					roundRobin.roundContests.allRemoveCallBack (this);
				}
				this.setDataNull (roundRobin);
				return;
			}
			// Parent
			{
				if (data is ContestManagerStatePlay) {
					ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
					// Child
					{
						contestManagerStatePlay.teams.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is MatchTeam) {
					return;
				}
			}
			// Child
			{
				if (data is RoundContest) {
					RoundContest roundContest = data as RoundContest;
					// Child
					{
						roundContest.contest.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is Contest) {
						Contest contest = data as Contest;
						// Child
						{
							contest.state.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is ContestState) {
							ContestState contestState = data as ContestState;
							// Child
							{
								switch (contestState.getType ()) {
								case ContestState.Type.Load:
									break;
								case ContestState.Type.Start:
									break;
								case ContestState.Type.Play:
									break;
								case ContestState.Type.End:
									{
										ContestStateEnd contestStateEnd = contestState as ContestStateEnd;
										contestStateEnd.teamResults.allRemoveCallBack (this);
									}
									break;
								default:
									Debug.LogError ("unknown type: " + contestState.getType () + "; " + this);
									break;
								}
							}
							return;
						}
						// Child
						if (data is TeamResult) {
							return;
						}
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RoundRobin) {
				switch ((RoundRobin.Property)wrapProperty.n) {
				case RoundRobin.Property.state:
					break;
				case RoundRobin.Property.index:
					break;
				case RoundRobin.Property.roundContests:
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
			// Parent
			{
				if (wrapProperty.p is ContestManagerStatePlay) {
					switch ((ContestManagerStatePlay.Property)wrapProperty.n) {
					case ContestManagerStatePlay.Property.state:
						break;
					case ContestManagerStatePlay.Property.isForceEnd:
						break;
					case ContestManagerStatePlay.Property.teams:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case ContestManagerStatePlay.Property.content:
						break;
					case ContestManagerStatePlay.Property.contentTeamResult:
						break;
					case ContestManagerStatePlay.Property.randomTeamIndex:
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
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			// Child
			{
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
				// Child
				{
					if (wrapProperty.p is Contest) {
						switch ((Contest.Property)wrapProperty.n) {
						case Contest.Property.state:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case Contest.Property.playerPerTeam:
							break;
						case Contest.Property.teams:
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
					{
						if (wrapProperty.p is ContestState) {
							ContestState contestState = wrapProperty.p as ContestState;
							// Child
							{
								switch (contestState.getType ()) {
								case ContestState.Type.Load:
									break;
								case ContestState.Type.Start:
									break;
								case ContestState.Type.Play:
									break;
								case ContestState.Type.End:
									{
										switch ((ContestStateEnd.Property)wrapProperty.n) {
										case ContestStateEnd.Property.teamResults:
											{
												ValueChangeUtils.replaceCallBack (this, syncs);
												dirty = true;
											}
											break;
										default:
											Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
											break;
										}
									}
									break;
								default:
									Debug.LogError ("unknown type: " + contestState.getType () + "; " + this);
									break;
								}
							}
							return;
						}
						// Child
						if (wrapProperty.p is TeamResult) {
							switch ((TeamResult.Property)wrapProperty.n) {
							case TeamResult.Property.teamIndex:
								dirty = true;
								break;
							case TeamResult.Property.score:
								dirty = true;
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
					}
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}