using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestUpdate : UpdateBehavior<Contest>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ContestState contestState = this.data.state.v;
					if (contestState != null) {
						switch (contestState.getType ()) {
						case ContestState.Type.Load:
						case ContestState.Type.Start:
							{
								// round
								foreach (Round round in this.data.rounds.vs) {
									round.removeCallBackAndDestroy (typeof(RoundUpdate));
								}
								// request new round
								{
									RequestNewRound requestNewRound = this.data.requestNewRound.v;
									if (requestNewRound != null) {
										requestNewRound.removeCallBackAndDestroy (typeof(RequestNewRoundUpdate));
									} else {
										Debug.LogError ("requestNewRound null: " + this);
									}
								}
								// Check contest end
								this.data.removeCallBackAndDestroy (typeof(CheckContestEndUpdate));
								// make new round
								this.data.removeCallBackAndDestroy (typeof(MakeNewRoundUpdate));
							}
							break;
						case ContestState.Type.Play:
						case ContestState.Type.End:
							{
								// round
								foreach (Round round in this.data.rounds.vs) {
									UpdateUtils.makeUpdate<RoundUpdate, Round> (round, this.transform);
								}
								// request new round
								{
									RequestNewRound requestNewRound = this.data.requestNewRound.v;
									if (requestNewRound != null) {
										UpdateUtils.makeUpdate<RequestNewRoundUpdate, RequestNewRound> (requestNewRound, this.transform);
									} else {
										Debug.LogError ("requestNewRound null: " + this);
									}
								}
								// Check contest end
								UpdateUtils.makeUpdate<CheckContestEndUpdate, Contest>(this.data, this.transform);
								// make new round
								UpdateUtils.makeUpdate<MakeNewRoundUpdate, Contest>(this.data, this.transform);
							}
							break;
						default:
							Debug.LogError ("Unknown type: " + contestState.getType () + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("contestState null: " + this);
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
			if (data is Contest) {
				Contest contest = data as Contest;
				// Update
				{
					UpdateUtils.makeUpdate<MakeTeamCountCorrectUpdate, Contest> (contest, this.transform);
				}
				// Child
				{
					contest.state.allAddCallBack (this);
					// playerPerTeam
					contest.teams.allAddCallBack (this);
					// roundFactory
					contest.rounds.allAddCallBack (this);
					contest.requestNewRound.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is ContestState) {
					ContestState contestState = data as ContestState;
					// Update
					{
						switch (contestState.getType ()) {
						case ContestState.Type.Load:
							{
								ContestStateLoad contestStateLoad = contestState as ContestStateLoad;
								UpdateUtils.makeUpdate<ContestStateLoadUpdate, ContestStateLoad> (contestStateLoad, this.transform);
							}
							break;
						case ContestState.Type.Start:
							{
								ContestStateStart contestStateStart = contestState as ContestStateStart;
								UpdateUtils.makeUpdate<ContestStateStartUpdate, ContestStateStart> (contestStateStart, this.transform);
							}
							break;
						case ContestState.Type.Play:
							{
								ContestStatePlay contestStatePlay = contestState as ContestStatePlay;
								UpdateUtils.makeUpdate<ContestStatePlayUpdate, ContestStatePlay> (contestStatePlay, this.transform);
							}
							break;
						case ContestState.Type.End:
							{
								ContestStateEnd contestStateEnd = contestState as ContestStateEnd;
								UpdateUtils.makeUpdate<ContestStateEndUpdate, ContestStateEnd> (contestStateEnd, this.transform);
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
				if (data is MatchTeam) {
					MatchTeam matchTeam = data as MatchTeam;
					// Update
					{
						UpdateUtils.makeUpdate<MatchTeamUpdate, MatchTeam> (matchTeam, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is Round) {
					dirty = true;
					return;
				}
				if (data is RequestNewRound) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Contest) {
				Contest contest = data as Contest;
				// Update
				{
					contest.removeCallBackAndDestroy (typeof(MakeTeamCountCorrectUpdate));
					contest.removeCallBackAndDestroy (typeof(CheckContestEndUpdate));
					contest.removeCallBackAndDestroy (typeof(MakeNewRoundUpdate));
				}
				// Child
				{
					contest.state.allRemoveCallBack (this);
					// playerPerTeam
					contest.teams.allRemoveCallBack (this);
					// roundFactory
					contest.rounds.allRemoveCallBack (this);
					contest.requestNewRound.allRemoveCallBack (this);
				}
				this.setDataNull (contest);
				return;
			}
			// Child
			{
				if (data is ContestState) {
					ContestState contestState = data as ContestState;
					// Update
					{
						switch (contestState.getType ()) {
						case ContestState.Type.Load:
							{
								ContestStateLoad contestStateLoad = contestState as ContestStateLoad;
								contestStateLoad.removeCallBackAndDestroy (typeof(ContestStateLoadUpdate));
							}
							break;
						case ContestState.Type.Start:
							{
								ContestStateStart contestStateStart = contestState as ContestStateStart;
								contestStateStart.removeCallBackAndDestroy (typeof(ContestStateStartUpdate));
							}
							break;
						case ContestState.Type.Play:
							{
								ContestStatePlay contestStatePlay = contestState as ContestStatePlay;
								contestStatePlay.removeCallBackAndDestroy (typeof(ContestStatePlayUpdate));
							}
							break;
						case ContestState.Type.End:
							{
								ContestStateEnd contestStateEnd = contestState as ContestStateEnd;
								contestStateEnd.removeCallBackAndDestroy (typeof(ContestStateEndUpdate));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + contestState.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is MatchTeam) {
					MatchTeam matchTeam = data as MatchTeam;
					// Update
					{
						matchTeam.removeCallBackAndDestroy (typeof(MatchTeamUpdate));
					}
					return;
				}
				if (data is Round) {
					Round round = data as Round;
					// Update
					{
						round.removeCallBackAndDestroy (typeof(RoundUpdate));
					}
					return;
				}
				if (data is RequestNewRound) {
					RequestNewRound requestNewRound = data as RequestNewRound;
					// Update
					{
						requestNewRound.removeCallBackAndDestroy (typeof(RequestNewRoundUpdate));
					}
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
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Contest.Property.roundFactory:
					break;
				case Contest.Property.rounds:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Contest.Property.requestNewRound:
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
				if (wrapProperty.p is ContestState) {
					return;
				}
				if (wrapProperty.p is MatchTeam) {
					return;
				}
				if (wrapProperty.p is Round) {
					return;
				}
				if (wrapProperty.p is RequestNewRound) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}