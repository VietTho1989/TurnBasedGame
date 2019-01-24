using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobinContentCheckEndUpdate : UpdateBehavior<RoundRobinContent>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ContestManagerStatePlay contestManagerStatePlay = this.data.findDataInParent<ContestManagerStatePlay> ();
					if (contestManagerStatePlay != null) {
						ContentTeamResult contentTeamResult = contestManagerStatePlay.contentTeamResult.v;
						if (contentTeamResult != null) {
							// find
							bool isEnd = true;
							List<TeamResult> newTeamResults = new List<TeamResult> ();
							{
								// init newTeamResults
								{
									foreach (MatchTeam matchTeam in contestManagerStatePlay.teams.vs) {
										TeamResult newTeamResult = new TeamResult ();
										{
											newTeamResult.teamIndex.v = matchTeam.teamIndex.v;
										}
										newTeamResults.Add (newTeamResult);
									}
								}
								// check all round end
								{
									foreach (RoundRobin roundRobin in this.data.roundRobins.vs) {
										if (roundRobin.state.v.getType () == RoundRobin.State.Type.End) {
											RoundRobinStateEnd roundRobinStateEnd = roundRobin.state.v as RoundRobinStateEnd;
											// add score for each newTeamResult
											foreach (TeamResult newTeamResult in newTeamResults) {
												newTeamResult.score.v += roundRobinStateEnd.getResult (newTeamResult.teamIndex.v);
											}
										} else {
											isEnd = false;
										}
									}
								}
								// check round count
								if (isEnd) {
									if (this.data.roundRobins.vs.Count < this.data.getMaxRound ()) {
										isEnd = false;
									}
								}
							}
							// Update
							{
								contentTeamResult.isEnd.v = isEnd;
								// TeamResult
								{
									// get old
									List<TeamResult> oldTeamResults = new List<TeamResult> ();
									{
										oldTeamResults.AddRange (contentTeamResult.teamResults.vs);
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
		private SingleContestFactoryCheckChange<SingleContestFactory> singleContestFactoryCheckChange = new SingleContestFactoryCheckChange<SingleContestFactory> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RoundRobinContent) {
				RoundRobinContent roundRobinContent = data as RoundRobinContent;
				// Parent
				{
					DataUtils.addParentCallBack (roundRobinContent, this, ref this.contestManagerStatePlay);
				}
				// Child
				{
					roundRobinContent.singleContestFactory.allAddCallBack (this);
					roundRobinContent.roundRobins.allAddCallBack (this);
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
				// singleContestFactory
				{
					if (data is SingleContestFactory) {
						SingleContestFactory singleContestFactory = data as SingleContestFactory;
						// CheckChange
						{
							singleContestFactoryCheckChange.addCallBack (this);
							singleContestFactoryCheckChange.setData (singleContestFactory);
						}
						dirty = true;
						return;
					}
					// CheckChange
					if (data is SingleContestFactoryCheckChange<SingleContestFactory>) {
						dirty = true;
						return;
					}
				}
				// roundRobin
				{
					if (data is RoundRobin) {
						RoundRobin roundRobin = data as RoundRobin;
						// Child
						{
							roundRobin.state.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is RoundRobin.State) {
							RoundRobin.State state = data as RoundRobin.State;
							// Child
							{
								switch (state.getType ()) {
								case RoundRobin.State.Type.Load:
									break;
								case RoundRobin.State.Type.Start:
									break;
								case RoundRobin.State.Type.Play:
									break;
								case RoundRobin.State.Type.End:
									{
										RoundRobinStateEnd roundRobinStateEnd = data as RoundRobinStateEnd;
										roundRobinStateEnd.teamResults.allAddCallBack (this);
									}
									break;
								default:
									Debug.LogError ("unknown type: " + state.getType () + "; " + this);
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
			if (data is RoundRobinContent) {
				RoundRobinContent roundRobinContent = data as RoundRobinContent;
				// Parent
				{
					DataUtils.removeParentCallBack (roundRobinContent, this, ref this.contestManagerStatePlay);
				}
				// Child
				{
					roundRobinContent.singleContestFactory.allAddCallBack (this);
					roundRobinContent.roundRobins.allAddCallBack (this);
				}
				this.setDataNull(roundRobinContent);
				return;
			}
			// Parent
			if (data is ContestManagerStatePlay) {
				return;
			}
			// Child
			{
				// singleContestFactory
				{
					if (data is SingleContestFactory) {
						// SingleContestFactory singleContestFactory = data as SingleContestFactory;
						// CheckChange
						{
							singleContestFactoryCheckChange.removeCallBack (this);
							singleContestFactoryCheckChange.setData (null);
						}
						return;
					}
					// CheckChange
					if (data is SingleContestFactoryCheckChange<SingleContestFactory>) {
						return;
					}
				}
				// roundRobin
				{
					if (data is RoundRobin) {
						RoundRobin roundRobin = data as RoundRobin;
						// Child
						{
							roundRobin.state.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is RoundRobin.State) {
							RoundRobin.State state = data as RoundRobin.State;
							// Child
							{
								switch (state.getType ()) {
								case RoundRobin.State.Type.Load:
									break;
								case RoundRobin.State.Type.Start:
									break;
								case RoundRobin.State.Type.Play:
									break;
								case RoundRobin.State.Type.End:
									{
										RoundRobinStateEnd roundRobinStateEnd = data as RoundRobinStateEnd;
										roundRobinStateEnd.teamResults.allRemoveCallBack (this);
									}
									break;
								default:
									Debug.LogError ("unknown type: " + state.getType () + "; " + this);
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
			if (wrapProperty.p is RoundRobinContent) {
				switch ((RoundRobinContent.Property)wrapProperty.n) {
				case RoundRobinContent.Property.singleContestFactory:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case RoundRobinContent.Property.roundRobins:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case RoundRobinContent.Property.requestNewRoundRobin:
					break;
				case RoundRobinContent.Property.needReturnRound:
					dirty = true;
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
					dirty = true;
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
			{
				// singleContestFactory
				{
					if (wrapProperty.p is SingleContestFactory) {
						return;
					}
					// CheckChange
					if (wrapProperty.p is SingleContestFactoryCheckChange<SingleContestFactory>) {
						dirty = true;
						return;
					}
				}
				// roundRobin
				{
					if (wrapProperty.p is RoundRobin) {
						switch ((RoundRobin.Property)wrapProperty.n) {
						case RoundRobin.Property.state:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case RoundRobin.Property.index:
							break;
						case RoundRobin.Property.roundContests:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					{
						if (wrapProperty.p is RoundRobin.State) {
							RoundRobin.State state = wrapProperty.p as RoundRobin.State;
							// Child
							{
								switch (state.getType ()) {
								case RoundRobin.State.Type.Load:
									break;
								case RoundRobin.State.Type.Start:
									break;
								case RoundRobin.State.Type.Play:
									break;
								case RoundRobin.State.Type.End:
									{
										switch ((RoundRobinStateEnd.Property)wrapProperty.n) {
										case RoundRobinStateEnd.Property.teamResults:
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
									Debug.LogError ("unknown type: " + state.getType () + "; " + this);
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