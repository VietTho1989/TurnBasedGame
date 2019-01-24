using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestManagerStatePlaySetStateUpdate : UpdateBehavior<ContestManagerStatePlay>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// force end?
					if (!this.data.isForceEnd.v) {
						// check content team result
						ContentTeamResult contentTeamResult = this.data.contentTeamResult.v;
						if (contentTeamResult != null) {
							if (contentTeamResult.isEnd.v) {
								// Find end
								ContestManagerStatePlayEnd end = null;
								{
									// find old
									if (this.data.state.v is ContestManagerStatePlayEnd) {
										end = this.data.state.v as ContestManagerStatePlayEnd;
									}
									// make new
									if(end==null) {
										end = new ContestManagerStatePlayEnd ();
										{
											end.uid = this.data.state.makeId ();
										}
										this.data.state.v = end;
									}
								}
								// Update
								{
									// get old
									List<TeamResult> oldTeamResults = new List<TeamResult> ();
									{
										oldTeamResults.AddRange (end.teamResults.vs);
									}
									// Update
									{
										foreach (TeamResult contentResult in contentTeamResult.teamResults.vs) {
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
														teamResult.uid = end.teamResults.makeId ();
													}
													end.teamResults.add (teamResult);
												} else {
													oldTeamResults.Remove (teamResult);
												}
											}
											// Update
											{
												teamResult.teamIndex.v = contentResult.teamIndex.v;
												teamResult.score.v = contentResult.score.v;
											}
										}
									}
									// Remove old
									foreach (TeamResult oldTeamResult in oldTeamResults) {
										end.teamResults.remove (oldTeamResult);
									}
								}
							} else {
								// not end, set state normal
								ContestManagerStatePlayNormal normal = null;
								{
									// Find old
									if (this.data.state.v is ContestManagerStatePlayNormal) {
										normal = this.data.state.v as ContestManagerStatePlayNormal;
									}
									// Make new
									if (normal == null) {
										normal = new ContestManagerStatePlayNormal ();
										{
											normal.uid = this.data.state.makeId ();
										}
										this.data.state.v = normal;
									}
								}
								// Update
								{

								}
							}
						} else {
							Debug.LogError ("contentTeamResult null: " + this);
						}
					} else {
						// find end
						ContestManagerStatePlayEnd end = null;
						{
							// find old
							if (this.data.state.v is ContestManagerStatePlayEnd) {
								end = this.data.state.v as ContestManagerStatePlayEnd;
							}
							// make new
							if(end==null) {
								end = new ContestManagerStatePlayEnd ();
								{
									end.uid = this.data.state.makeId ();
								}
								this.data.state.v = end;
							}
						}
						// Update
						{
							end.teamResults.clear ();
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
			if (data is ContestManagerStatePlay) {
				ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
				// Child
				{
					contestManagerStatePlay.contentTeamResult.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is ContentTeamResult) {
					ContentTeamResult contentTeamResult = data as ContentTeamResult;
					// Child
					{
						contentTeamResult.teamResults.allAddCallBack (this);
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
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is ContestManagerStatePlay) {
				ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
				// Child
				{
					contestManagerStatePlay.contentTeamResult.allRemoveCallBack (this);
				}
				this.setDataNull (contestManagerStatePlay);
				return;
			}
			// Child
			{
				if (data is ContentTeamResult) {
					ContentTeamResult contentTeamResult = data as ContentTeamResult;
					// Child
					{
						contentTeamResult.teamResults.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is TeamResult) {
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
			if (wrapProperty.p is ContestManagerStatePlay) {
				switch ((ContestManagerStatePlay.Property)wrapProperty.n) {
				case ContestManagerStatePlay.Property.state:
					break;
				case ContestManagerStatePlay.Property.isForceEnd:
					dirty = true;
					break;
				case ContestManagerStatePlay.Property.teams:
					break;
				case ContestManagerStatePlay.Property.content:
					break;
				case ContestManagerStatePlay.Property.contentTeamResult:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case ContestManagerStatePlay.Property.gameTypeType:
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
				if (wrapProperty.p is ContentTeamResult) {
					switch ((ContentTeamResult.Property)wrapProperty.n) {
					case ContentTeamResult.Property.isEnd:
						dirty = true;
						break;
					case ContentTeamResult.Property.teamResults:
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
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}