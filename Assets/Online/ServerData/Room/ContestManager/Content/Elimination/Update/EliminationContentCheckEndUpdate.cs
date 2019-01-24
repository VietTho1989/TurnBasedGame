using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationContentCheckEndUpdate : UpdateBehavior<EliminationContent>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// check is end
					bool isEnd = false;
					{
						foreach (EliminationRound eliminationRound in this.data.rounds.vs) {
							if (!eliminationRound.isActive.v) {
								isEnd = false;
								break;
							} else {
								if (eliminationRound.isLastRound ()) {
									isEnd = true;
									break;
								}
							}
						}
					}
					// Process
					{
						ContestManagerStatePlay contestManagerStatePlay = this.data.findDataInParent<ContestManagerStatePlay> ();
						if (contestManagerStatePlay != null) {
							ContentTeamResult contentTeamResult = contestManagerStatePlay.contentTeamResult.v;
							if (contentTeamResult != null) {
								contentTeamResult.isEnd.v = isEnd;
								// results
								{
									// find
									List<TeamResult> newTeamResults = new List<TeamResult> ();
									{
										foreach (EliminationRound eliminationRound in this.data.rounds.vs) {
											if (eliminationRound.isActive.v) {
												if (eliminationRound.state.v.getType () == EliminationRound.State.Type.End) {
													// get last bracket
													Bracket lastBracket = null;
													{
														for (int i = eliminationRound.brackets.vs.Count - 1; i >= 0; i--) {
															Bracket bracket = eliminationRound.brackets.vs [i];
															if (bracket.isActive.v) {
																lastBracket = bracket;
																break;
															}
														}
													}
													// add 
													if (lastBracket != null) {
														BracketStateEnd bracketStateEnd = lastBracket.state.v as BracketStateEnd;
														if (bracketStateEnd != null) {
															// add losers
															{
																foreach (int teamIndex in bracketStateEnd.loseTeamIndexs.vs) {
																	TeamResult teamResult = new TeamResult ();
																	{
																		teamResult.teamIndex.v = teamIndex;
																		{
																			int count = bracketStateEnd.loseTeamIndexs.vs.Count;
																			teamResult.score.v = newTeamResults.Count + ((count - 1) * count / 2) / count;
																		}
																	}
																	newTeamResults.Add (teamResult);
																}
															}
															// add winners
															if (eliminationRound.isLastRound ()) {
																foreach (int teamIndex in bracketStateEnd.winTeamIndexs.vs) {
																	TeamResult teamResult = new TeamResult ();
																	{
																		teamResult.teamIndex.v = teamIndex;
																		{
																			int count = bracketStateEnd.winTeamIndexs.vs.Count;
																			teamResult.score.v = newTeamResults.Count + ((count - 1) * count / 2) / count;
																		}
																	}
																	newTeamResults.Add (teamResult);
																}
															}
														} else {
															Debug.LogError ("bracketStateEnd null: " + this);
														}
													} else {
														Debug.LogError ("lastBracket null: " + this);
													}
												} else {
													break;
												}
											} else {
												break;
											}
										}
									}
									// update
									{
										// find old
										List<TeamResult> oldTeamResults = new List<TeamResult> ();
										{
											oldTeamResults.AddRange (contentTeamResult.teamResults.vs);
										}
										// Update
										{
											foreach (TeamResult newTeamResult in newTeamResults) {
												// find
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
															teamResult.uid = contentTeamResult.teamResults.makeId ();
														}
														contentTeamResult.teamResults.add (teamResult);
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
											contentTeamResult.teamResults.remove (oldTeamResult);
										}
									}
								}
							} else {
								Debug.LogError ("contentTeamResult null: " + this);
							}
						} else {
							Debug.LogError ("contestManagerStatePlay null: " + this);
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

		private EliminationRoundCheckChange<EliminationContent> eliminationRoundCheckChange = new EliminationRoundCheckChange<EliminationContent>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is EliminationContent) {
				EliminationContent eliminationContent = data as EliminationContent;
				// CheckChange
				{
					eliminationRoundCheckChange.addCallBack (this);
					eliminationRoundCheckChange.setData (eliminationContent);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is EliminationRoundCheckChange<EliminationContent>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is EliminationContent) {
				EliminationContent eliminationContent = data as EliminationContent;
				// CheckChange
				{
					eliminationRoundCheckChange.removeCallBack (this);
					eliminationRoundCheckChange.setData (null);
				}
				this.setDataNull (eliminationContent);
				return;
			}
			// CheckChange
			if (data is EliminationRoundCheckChange<EliminationContent>) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is EliminationContent) {
				switch ((EliminationContent.Property)wrapProperty.n) {
				case EliminationContent.Property.singleContestFactory:
					break;
				case EliminationContent.Property.initTeamCounts:
					break;
				case EliminationContent.Property.requestNewRound:
					break;
				case EliminationContent.Property.rounds:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is EliminationRoundCheckChange<EliminationContent>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}