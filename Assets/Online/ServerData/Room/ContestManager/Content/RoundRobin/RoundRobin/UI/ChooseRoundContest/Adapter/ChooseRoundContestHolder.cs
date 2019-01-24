using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class ChooseRoundContestHolder : SriaHolderBehavior<ChooseRoundContestHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<ReferenceData<RoundContest>> roundContest;

			public LP<ChooseRoundContestTeamUI.UIData> teams;

			#region Constructor

			public enum Property
			{
				roundContest,
				teams
			}

			public UIData() : base()
			{
				this.roundContest = new VP<ReferenceData<RoundContest>>(this, (byte)Property.roundContest, new ReferenceData<RoundContest>(null));
				this.teams = new LP<ChooseRoundContestTeamUI.UIData>(this, (byte)Property.teams);
			}

			#endregion

			public void updateView(ChooseRoundContestAdapter.UIData myParams)
			{
				// Find
				RoundContest roundContest = null;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.roundContests.Count) {
						roundContest = myParams.roundContests [ItemIndex];
					} else {
						Debug.LogError ("ItemIdex error: " + this);
					}
				}
				// Update
				this.roundContest.v = new ReferenceData<RoundContest> (roundContest);
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text tvShow;
		public static readonly TxtLanguage txtShow = new TxtLanguage();

		public static readonly TxtLanguage txtIndex = new TxtLanguage();
		public static readonly TxtLanguage txtState = new TxtLanguage();

		static ChooseRoundContestHolder()
		{
			txtShow.add (Language.Type.vi, "Hiện");
			txtIndex.add (Language.Type.vi, "Chỉ số");
			txtState.add (Language.Type.vi, "");
		}

		#endregion

		public Text tvIndex;
		public Text tvState;

		public override void refresh ()
		{
			base.refresh ();
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RoundContest roundContest = this.data.roundContest.v.data;
					if (roundContest != null) {
						// tvIndex
						{
							if (tvIndex != null) {
								tvIndex.text = txtIndex.get ("Index") + ": " + roundContest.index.v;
							} else {
								Debug.LogError ("tvIndex null: " + this);
							}
						}
						// teams
						{
							// get old
							List<ChooseRoundContestTeamUI.UIData> oldTeams = new List<ChooseRoundContestTeamUI.UIData>();
							{
								oldTeams.AddRange (this.data.teams.vs);
							}
							// Update
							{
								foreach (int teamIndex in roundContest.teamIndexs.vs) {
									// find
									ChooseRoundContestTeamUI.UIData teamUIData = null;
									{
										// find old
										if (oldTeams.Count > 0) {
											teamUIData = oldTeams [0];
										}
										// make new
										if (teamUIData == null) {
											teamUIData = new ChooseRoundContestTeamUI.UIData ();
											{
												teamUIData.uid = this.data.teams.makeId ();
											}
											this.data.teams.add (teamUIData);
										} else {
											oldTeams.Remove (teamUIData);
										}
									}
									// update
									{
										teamUIData.roundContest.v = new ReferenceData<RoundContest> (roundContest);
										teamUIData.teamIndex.v = teamIndex;
									}
								}
							}
							// remove old
							foreach (ChooseRoundContestTeamUI.UIData oldTeam in oldTeams) {
								this.data.teams.remove (oldTeam);
							}
						}
						// tvState
						{
							if (tvState != null) {
								tvState.text = txtState.get ("") + "" + roundContest.contest.v.state.v.getType ();
							} else {
								Debug.LogError ("tvStatate null: " + this);
							}
						}
					} else {
						Debug.LogError ("roundContest null: " + this);
					}
					// txt
					{
						if (tvShow != null) {
							tvShow.text = txtShow.get ("Show");
						} else {
							Debug.LogError ("tvShow null: " + this);
						}
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		#endregion

		#region implement callBacks

		public ChooseRoundContestTeamUI teamPrefab;
		public Transform teamContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.roundContest.allAddCallBack (this);
					uiData.teams.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Setting
			if (data is Setting) {
				dirty = true;
				return;
			}
			// Child
			{
				// roundContest
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
					if (data is Contest) {
						dirty = true;
						return;
					}
				}
				if (data is ChooseRoundContestTeamUI.UIData) {
					ChooseRoundContestTeamUI.UIData teamUIData = data as ChooseRoundContestTeamUI.UIData;
					// UI
					{
						UIUtils.Instantiate (teamUIData, teamPrefab, teamContainer);
					}
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().removeCallBack(this);
				// Child
				{
					uiData.roundContest.allRemoveCallBack (this);
					uiData.teams.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			{
				// roundContest
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
					if (data is Contest) {
						return;
					}
				}
				if (data is ChooseRoundContestTeamUI.UIData) {
					ChooseRoundContestTeamUI.UIData teamUIData = data as ChooseRoundContestTeamUI.UIData;
					// UI
					{
						teamUIData.removeCallBackAndDestroy (typeof(ChooseRoundContestTeamUI));
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
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.roundContest:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.teams:
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
			// Setting
			if (wrapProperty.p is Setting) {
				switch ((Setting.Property)wrapProperty.n) {
				case Setting.Property.language:
					dirty = true;
					break;
				case Setting.Property.showLastMove:
					break;
				case Setting.Property.viewUrlImage:
					break;
				case Setting.Property.animationSetting:
					break;
				case Setting.Property.maxThinkCount:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				// roundContest
				{
					if (wrapProperty.p is RoundContest) {
						switch ((RoundContest.Property)wrapProperty.n) {
						case RoundContest.Property.index:
							dirty = true;
							break;
						case RoundContest.Property.teamIndexs:
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
					if (wrapProperty.p is Contest) {
						switch ((Contest.Property)wrapProperty.n) {
						case Contest.Property.state:
							dirty = true;
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
					}
				}
				if (wrapProperty.p is ChooseRoundContestTeamUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnShow()
		{
			if (this.data != null) {
				RoundContest roundContest = this.data.roundContest.v.data;
				if (roundContest != null) {
					RoundRobinUI.UIData roundRobinUIData = this.data.findDataInParent<RoundRobinUI.UIData> ();
					if (roundRobinUIData != null) {
						RoundContestUI.UIData roundContestUIData = roundRobinUIData.roundContestUIData.v;
						if (roundContestUIData != null) {
							roundContestUIData.roundContest.v = new ReferenceData<RoundContest> (roundContest);
						} else {
							Debug.LogError ("roundContestUIData null: " + this);
						}
					} else {
						Debug.LogError ("roundRobinUIData null: " + this);
					}
				} else {
					Debug.LogError ("roundContest null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}