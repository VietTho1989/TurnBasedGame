using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationRoundMakeBracketUpdate : UpdateBehavior<EliminationRound>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EliminationContent eliminationContent = this.data.findDataInParent<EliminationContent> ();
					if (eliminationContent != null) {
						// active or not
						bool isActive = true;
						{
							if (this.data.index.v == 0) {
								isActive = true;
							} else {
								// check last round
								EliminationRound lastEliminationRound = null;
								{
									int index = this.data.index.v - 1;
									if (index >= 0 && index < eliminationContent.rounds.vs.Count) {
										lastEliminationRound = eliminationContent.rounds.vs [index];
										if (lastEliminationRound.index.v != index) {
											Debug.LogError ("impossible: why wrong index: " + this);
											foreach (EliminationRound round in eliminationContent.rounds.vs) {
												if (round.index.v == index) {
													lastEliminationRound = round;
													break;
												}
											}
										}
									}
								}
								if (lastEliminationRound != null) {
									if (!lastEliminationRound.isActive.v || lastEliminationRound.isLastRound ()) {
										isActive = false;
									} else {
										if (lastEliminationRound.state.v.getType () == EliminationRound.State.Type.End) {
											isActive = true;
										} else {
											isActive = false;
										}
									}
								} else {
									Debug.LogError ("lastEliminationRound null: " + this);
								}
							}
							this.data.isActive.v = isActive;
						}
						// make brackets
						if (this.data.isActive.v) {
							// make list of teamIndexs each brackets
							List<List<int>> teamIndexsList = new List<List<int>>();
							{
								if (this.data.index.v == 0) {
									ContestManagerStatePlay contestManagerStatePlay = this.data.findDataInParent<ContestManagerStatePlay> ();
									if (contestManagerStatePlay != null) {
										// get teamIndexList
										List<int> teamIndexList = new List<int> ();
										{
											foreach (MatchTeam matchTeam in contestManagerStatePlay.teams.vs) {
												teamIndexList.Add (matchTeam.teamIndex.v);
											}
										}
										// make bracket
										foreach (uint initTeamCount in eliminationContent.initTeamCounts.vs) {
											if (initTeamCount == 0) {
												teamIndexsList.Add (new List<int> ());
											} else {
												if (teamIndexList.Count >= initTeamCount) {
													teamIndexsList.Add (teamIndexList.GetRange (0, (int)initTeamCount));
													teamIndexList.RemoveRange (0, (int)initTeamCount);
												} else {
													Debug.LogError ("Don't have enough team left");
												}
											}
										}
									} else {
										Debug.LogError ("contestManagerStatePlay null: " + this);
									}
								} else {
									// find last round
									EliminationRound lastRound = null;
									{
										int lastRoundIndex = this.data.index.v - 1;
										if (lastRoundIndex >= 0 && lastRoundIndex < eliminationContent.rounds.vs.Count) {
											lastRound = eliminationContent.rounds.vs [lastRoundIndex];
										}
									}
									// Process
									if (lastRound != null) {
										for (int bracketIndex = 0; bracketIndex < lastRound.brackets.vs.Count; bracketIndex++) {
											Bracket bracket = lastRound.brackets.vs [bracketIndex];
											if (bracket.isActive.v) {
												BracketStateEnd bracketStateEnd = bracket.state.v as BracketStateEnd;
												if (bracketStateEnd != null) {
													// make list for bracket
													List<int> teamIndexs = new List<int> ();
													{
														// get loser from upper brackets
														List<int> fromUppers = new List<int>();
														{
															if (bracketIndex > 0) {
																Bracket upperBracket = lastRound.brackets.vs [bracketIndex - 1];
																BracketStateEnd upperBracketStateEnd = upperBracket.state.v as BracketStateEnd;
																if (upperBracketStateEnd != null) {
																	fromUppers.AddRange (upperBracketStateEnd.loseTeamIndexs.vs);
																} else {
																	Debug.LogError ("upperBracketStateEnd null: " + this);
																}
															}
														}
														// get from same brackets
														List<int> fromSames = new List<int>();
														{
															fromSames.AddRange (bracketStateEnd.winTeamIndexs.vs);
														}
														// add to teamIndexs
														for (int i = 0; i < Mathf.Max (fromUppers.Count, fromSames.Count); i++) {
															// add loser from upper bracket
															if (i < fromUppers.Count) {
																teamIndexs.Add (fromUppers [i]);
															}
															// add from the same brackets
															if (i < fromSames.Count) {
																teamIndexs.Add (fromSames [i]);
															}
														}
													}
													teamIndexsList.Add (teamIndexs);
												} else {
													Debug.LogError ("bracketStateEnd null: " + this);
												}
											} else {
												Debug.LogError ("bracket not active: " + this);
											}
										}
									} else {
										Debug.LogError ("lastRound null: " + this);
									}
								}
							}
							// combine brackets
							{
								if (teamIndexsList.Count >= 2) {
									// check all bracket have 1 team?
									bool isAllTeamIndexsCountEqualOne = true;
									{
										foreach (List<int> teamIndexs in teamIndexsList) {
											if (teamIndexs.Count >= 2) {
												isAllTeamIndexsCountEqualOne = false;
												break;
											}
										}
									}
									// Combine two lowest bracket
									if (isAllTeamIndexsCountEqualOne) {
										Debug.LogError ("allTeamIndexsCountEqualOne");
										teamIndexsList [teamIndexsList.Count - 2].AddRange (teamIndexsList [teamIndexsList.Count - 1]);
										teamIndexsList.RemoveAt (teamIndexsList.Count - 1);
									}
								}
							}
							// make bracket
							{
								// get information to make contest
								int teamCountPerContest = 2;
								{
									SingleContestFactory singleContestFactory = eliminationContent.singleContestFactory.v;
									if (singleContestFactory != null) {
										int playerPerTeam = 1;
										GameType.Type gameTypeType = GameType.Type.CHESS;
										singleContestFactory.getTeamCountAndPlayerPerTeamGameType (out teamCountPerContest, out playerPerTeam, out gameTypeType);
									} else {
										Debug.LogError ("singleContestFactory null: " + this);
									}
								}
								// make contest for copy
								Contest modelContest = ((SingleContestContent)eliminationContent.singleContestFactory.v.makeContent ()).contest.v;
								// get old
								List<Bracket> oldBrackets = new List<Bracket>();
								{
									oldBrackets.AddRange (this.data.brackets.vs);
								}
								// Update
								{
									for(int i=0; i<teamIndexsList.Count; i++) {
										List<int> bracketTeamIndexs = teamIndexsList [i];
										// find bracket
										Bracket bracket = null;
										{
											// find old
											if (oldBrackets.Count > 0) {
												bracket = oldBrackets [0];
											}
											// make new
											if (bracket == null) {
												bracket = new Bracket ();
												{
													bracket.uid = this.data.brackets.makeId ();
												}
												this.data.brackets.add (bracket);
											} else {
												oldBrackets.Remove (bracket);
											}
										}
										// Update
										{
											bracket.isActive.v = true;
											bracket.index.v = i;
											// make bracketContests
											{
												// get old bracketContest
												List<BracketContest> oldBracketContests = new List<BracketContest>();
												{
													oldBracketContests.AddRange (bracket.bracketContests.vs);
												}
												// Update
												{
													int bracketContestIndex = 0;
													while (bracketTeamIndexs.Count > 0) {
														if (bracketTeamIndexs.Count >= teamCountPerContest) {
															// find bracketContest
															BracketContest bracketContest = null;
															{
																// find old
																if (oldBracketContests.Count > 0) {
																	bracketContest = oldBracketContests [0];
																}
																// make new
																if (bracketContest == null) {
																	bracketContest = new BracketContest ();
																	{
																		bracketContest.uid = bracket.bracketContests.makeId ();
																		// contest
																		{
																			Contest newContest = DataUtils.cloneData (modelContest) as Contest;
																			{
																				newContest.uid = bracketContest.contest.makeId ();
																			}
																			bracketContest.contest.v = newContest;
																		}
																	}
																	bracket.bracketContests.add (bracketContest);
																} else {
																	oldBracketContests.Remove (bracketContest);
																}
															}
															// Update
															{
																bracketContest.isActive.v = true;
																bracketContest.index.v = bracketContestIndex;
																// teamIndexs
																{
																	List<int> contestTeamIndexs = bracketTeamIndexs.GetRange (0, teamCountPerContest);
																	IdentityUtils.refresh (bracketContest.teamIndexs, contestTeamIndexs);
																	bracketTeamIndexs.RemoveRange (0, teamCountPerContest);
																}
															}
														} else {
															IdentityUtils.refresh (bracket.byeTeamIndexs, bracketTeamIndexs);
															bracketTeamIndexs.Clear ();
															break;
														}
														bracketContestIndex++;
													}
												}
												// Remove old
												foreach (BracketContest oldBracketContest in oldBracketContests) {
													oldBracketContest.isActive.v = false;
												}
											}
										}
									}
								}
								// Remove old
								foreach (Bracket oldBracket in oldBrackets) {
									oldBracket.isActive.v = false;
								}
							}
						} else {
							Debug.LogError ("eliminationRound not active: " + this);
						}
					} else {
						Debug.LogError ("eliminationContent null: " + this);
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

		private EliminationRoundCheckChange<EliminationRound> eliminationRoundCheckChange = new EliminationRoundCheckChange<EliminationRound> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is EliminationRound) {
				EliminationRound eliminationRound = data as EliminationRound;
				// CheckChange
				{
					eliminationRoundCheckChange.addCallBack (this);
					eliminationRoundCheckChange.setData (eliminationRound);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is EliminationRoundCheckChange<EliminationRound>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is EliminationRound) {
				EliminationRound eliminationRound = data as EliminationRound;
				// CheckChange
				{
					eliminationRoundCheckChange.removeCallBack (this);
					eliminationRoundCheckChange.setData (null);
				}
				this.setDataNull (eliminationRound);
				return;
			}
			// CheckChange
			if (data is EliminationRoundCheckChange<EliminationRound>) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is EliminationRound) {
				return;
			}
			// CheckChange
			if (wrapProperty.p is EliminationRoundCheckChange<EliminationRound>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}