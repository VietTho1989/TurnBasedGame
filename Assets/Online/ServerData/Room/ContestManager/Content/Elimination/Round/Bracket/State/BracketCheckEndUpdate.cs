using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class BracketCheckEndUpdate : UpdateBehavior<Bracket>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Find
					bool isEnd = true;
					bool isTeamPerContestEqualOne = true;
					{
						foreach (BracketContest bracketContest in this.data.bracketContests.vs) {
							if (bracketContest.isActive.v) {
								// isTeamPerContestEqualOne
								if (bracketContest.teamIndexs.vs.Count > 1) {
									isTeamPerContestEqualOne = false;
								}
								// check end
								{
									Contest contest = bracketContest.contest.v;
									if (contest.state.v.getType () != ContestState.Type.End) {
										isEnd = false;
									}
								}
							} else {
								Debug.LogError ("bracketContest not active: " + this);
							}
						}
					}
					// Process
					if (isEnd) {
						// Find
						BracketStateEnd end = null;
						{
							// find old
							if (this.data.state.v is BracketStateEnd) {
								end = this.data.state.v as BracketStateEnd;
							}
							// make new
							if (end == null) {
								end = new BracketStateEnd ();
								{
									end.uid = this.data.state.makeId ();
								}
								this.data.state.v = end;
							}
						}
						// Update
						{
							// Find
							List<int> winTeamIndexs = new List<int>();
							List<int> loseTeamIndexs = new List<int> ();
							{
								// get result from bracketContests
								{
									if (isTeamPerContestEqualOne) {
										// 1 team contest
										// get scores
										float maxScore = float.MinValue;
										List<TeamResult> teamResults = new List<TeamResult> ();
										{
											foreach (BracketContest bracketContest in this.data.bracketContests.vs) {
												foreach (int teamIndex in bracketContest.teamIndexs.vs) {
													float score = bracketContest.getResult (teamIndex);
													// maxScore
													if (score > maxScore) {
														maxScore = score;
													}
													// add
													TeamResult teamResult = new TeamResult();
													{
														teamResult.teamIndex.v = teamIndex;
														teamResult.score.v = score;
													}
													teamResults.Add (teamResult);
												}
											}
										}
										// add winTeamIndexs, loseTeamIndexs
										foreach (TeamResult teamResult in teamResults) {
											if (teamResult.score.v >= maxScore) {
												winTeamIndexs.Add (teamResult.teamIndex.v);
											} else {
												loseTeamIndexs.Add (teamResult.teamIndex.v);
											}
										}
									} else {
										// >2 team contest
										foreach (BracketContest bracketContest in this.data.bracketContests.vs) {
											// find largest score teamIndex
											float maxScore = float.MinValue;
											int winnerTeamIndex = int.MinValue;
											foreach (int teamIndex in bracketContest.teamIndexs.vs) {
												float teamScore = bracketContest.getResult (teamIndex);
												if (teamScore > maxScore) {
													maxScore = teamScore;
													winnerTeamIndex = teamIndex;
												}
											}
											// add to winnerTeamIndexs, loserTeamIndexs
											foreach (int teamIndex in bracketContest.teamIndexs.vs) {
												if (teamIndex == winnerTeamIndex) {
													winTeamIndexs.Add (teamIndex);
												} else {
													loseTeamIndexs.Add (teamIndex);
												}
											}
										}
									}
								}
								// add byes
								winTeamIndexs.AddRange(this.data.byeTeamIndexs.vs);
							}
							// Update
							{
								// winTeamIndexs
								{
									if (end.winTeamIndexs.vs.Count == 0) {
										end.winTeamIndexs.add (winTeamIndexs);
									} else {
										// remove excess
										if (end.winTeamIndexs.vs.Count > winTeamIndexs.Count) {
											end.winTeamIndexs.remove (winTeamIndexs.Count, end.winTeamIndexs.vs.Count - winTeamIndexs.Count);
										}
										// update already have
										for (int i = 0; i < end.winTeamIndexs.vs.Count; i++) {
											end.winTeamIndexs.set (i, winTeamIndexs [i]);
										}
										// add
										for (int i = end.winTeamIndexs.vs.Count; i < winTeamIndexs.Count; i++) {
											end.winTeamIndexs.add (winTeamIndexs [i]);
										}
									}
								}
								// loseTeamIndexs
								{
									if (end.loseTeamIndexs.vs.Count == 0) {
										end.loseTeamIndexs.add (loseTeamIndexs);
									} else {
										// remove excess
										if (end.loseTeamIndexs.vs.Count > loseTeamIndexs.Count) {
											end.loseTeamIndexs.remove (loseTeamIndexs.Count, end.loseTeamIndexs.vs.Count - loseTeamIndexs.Count);
										}
										// update already have
										for (int i = 0; i < end.loseTeamIndexs.vs.Count; i++) {
											end.loseTeamIndexs.set (i, loseTeamIndexs [i]);
										}
										// add
										for (int i = end.loseTeamIndexs.vs.Count; i < loseTeamIndexs.Count; i++) {
											end.loseTeamIndexs.add (loseTeamIndexs [i]);
										}
									}
								}
							}
						}
					} else {
						// Find
						BracketStatePlay play = null;
						{
							// find old
							if (this.data.state.v is BracketStatePlay) {
								play = this.data.state.v as BracketStatePlay;
							}
							// make new
							if (play == null) {
								play = new BracketStatePlay ();
								{
									play.uid = this.data.state.makeId ();
								}
								this.data.state.v = play;
							}
						}
						// Update
						{

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

		public override void onAddCallBack<T> (T data)
		{
			if (data is Bracket) {
				Bracket bracket = data as Bracket;
				// Child
				{
					bracket.bracketContests.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is BracketContest) {
					BracketContest bracketContest = data as BracketContest;
					// Child
					{
						bracketContest.contest.allAddCallBack (this);
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
			if (data is Bracket) {
				Bracket bracket = data as Bracket;
				// Child
				{
					bracket.bracketContests.allRemoveCallBack (this);
				}
				this.setDataNull (bracket);
				return;
			}
			// Child
			{
				if (data is BracketContest) {
					BracketContest bracketContest = data as BracketContest;
					// Child
					{
						bracketContest.contest.allRemoveCallBack (this);
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
			if (wrapProperty.p is Bracket) {
				switch ((Bracket.Property)wrapProperty.n) {
				case Bracket.Property.state:
					break;
				case Bracket.Property.index:
					break;
				case Bracket.Property.bracketContests:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Bracket.Property.byeTeamIndexs:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is BracketContest) {
					switch ((BracketContest.Property)wrapProperty.n) {
					case BracketContest.Property.isActive:
						dirty = true;
						break;
					case BracketContest.Property.index:
						break;
					case BracketContest.Property.teamIndexs:
						dirty = true;
						break;
					case BracketContest.Property.contest:
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
						case Contest.Property.calculateScore:
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