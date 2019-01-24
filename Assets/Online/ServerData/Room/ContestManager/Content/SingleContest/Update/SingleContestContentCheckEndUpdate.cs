using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class SingleContestContentCheckEndUpdate : UpdateBehavior<SingleContestContent>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ContestManagerStatePlay contestManagerStatePlay = this.data.findDataInParent<ContestManagerStatePlay> ();
					if (contestManagerStatePlay != null) {
						// get content teamresult
						ContentTeamResult contentTeamResult = contestManagerStatePlay.contentTeamResult.v;
						if (contentTeamResult != null) {
							// Update content teamResult
							Contest contest = this.data.contest.v;
							if (contest != null) {
								ContestState contestState = contest.state.v;
								if (contestState != null) {
									switch (contestState.getType ()) {
									case ContestState.Type.Load:
									case ContestState.Type.Start:
									case ContestState.Type.Play:
										{
											contentTeamResult.isEnd.v = false;
										}
										break;
									case ContestState.Type.End:
										{
											ContestStateEnd contestStateEnd = contestState as ContestStateEnd;
											// Update ContentTeamResult
											{
												contentTeamResult.isEnd.v = true;
												// teamResults
												{
													// get old
													List<TeamResult> oldTeamResults = new List<TeamResult> ();
													{
														oldTeamResults.AddRange (contentTeamResult.teamResults.vs);
													}
													// Update
													{
														foreach (TeamResult contestTeamResult in contestStateEnd.teamResults.vs) {
															// Find 
															TeamResult teamResult = null;
															{
																// get old
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
																teamResult.teamIndex.v = contestTeamResult.teamIndex.v;
																teamResult.score.v = contestTeamResult.score.v;
															}
														}
													}
													// Remove old
													foreach (TeamResult oldTeamResult in oldTeamResults) {
														contentTeamResult.teamResults.remove (oldTeamResult);
													}
												}
											}
										}
										break;
									default:
										Debug.LogError ("unknown type: " + contestState.getType () + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("contestState null: " + this);
								}
							} else {
								Debug.LogError ("contest null: " + this);
							}
						} else {
							Debug.LogError ("contentTeamResult null: " + this);
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

		private ContestManagerStatePlay contestManagerStatePlay = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is SingleContestContent) {
				SingleContestContent singleContestContent = data as SingleContestContent;
				// Parent
				{
					DataUtils.addParentCallBack (singleContestContent, this, ref this.contestManagerStatePlay);
				}
				// Child
				{
					singleContestContent.contest.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			if (data is ContestManagerStatePlay) {
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
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is SingleContestContent) {
				SingleContestContent singleContestContent = data as SingleContestContent;
				// Parent
				{
					DataUtils.removeParentCallBack (singleContestContent, this, ref this.contestManagerStatePlay);
				}
				// Child
				{
					singleContestContent.contest.allRemoveCallBack (this);
				}
				this.setDataNull (singleContestContent);
				return;
			}
			// Parent
			if (data is ContestManagerStatePlay) {
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
			// Parent
			if (wrapProperty.p is ContestManagerStatePlay) {
				switch ((ContestManagerStatePlay.Property)wrapProperty.n) {
				case ContestManagerStatePlay.Property.state:
					break;
				case ContestManagerStatePlay.Property.isForceEnd:
					break;
				case ContestManagerStatePlay.Property.teams:
					break;
				case ContestManagerStatePlay.Property.content:
					break;
				case ContestManagerStatePlay.Property.contentTeamResult:
					dirty = true;
					break;
				case ContestManagerStatePlay.Property.randomTeamIndex:
					break;
				case ContestManagerStatePlay.Property.gameTypeType:
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
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}