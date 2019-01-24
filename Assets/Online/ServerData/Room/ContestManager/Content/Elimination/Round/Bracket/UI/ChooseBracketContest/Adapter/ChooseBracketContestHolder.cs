using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class ChooseBracketContestHolder : SriaHolderBehavior<ChooseBracketContestHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<ReferenceData<BracketContest>> bracketContest;

			public LP<ChooseBracketContestTeamUI.UIData> teams;

			#region Constructor

			public enum Property
			{
				bracketContest,
				teams
			}

			public UIData() : base()
			{
				this.bracketContest = new VP<ReferenceData<BracketContest>>(this, (byte)Property.bracketContest, new ReferenceData<BracketContest>(null));
				this.teams = new LP<ChooseBracketContestTeamUI.UIData>(this, (byte)Property.teams);
			}

			#endregion

			public void updateView(ChooseBracketContestAdapter.UIData myParams)
			{
				// Find
				BracketContest bracketContest = null;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.bracketContests.Count) {
						bracketContest = myParams.bracketContests [ItemIndex];
					} else {
						Debug.LogError ("ItemIdex error: " + this);
					}
				}
				// Update
				this.bracketContest.v = new ReferenceData<BracketContest> (bracketContest);
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text tvShow;
		public static readonly TxtLanguage txtShow = new TxtLanguage();

		public static readonly TxtLanguage txtIndex = new TxtLanguage ();
		public static readonly TxtLanguage txtState = new TxtLanguage ();

		static ChooseBracketContestHolder()
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
					BracketContest bracketContest = this.data.bracketContest.v.data;
					if (bracketContest != null) {
						// tvIndex
						{
							if (tvIndex != null) {
								tvIndex.text = txtIndex.get ("Index") + ": " + bracketContest.index.v;
							} else {
								Debug.LogError ("tvIndex null: " + this);
							}
						}
						// teams
						{
							// get old
							List<ChooseBracketContestTeamUI.UIData> oldTeams = new List<ChooseBracketContestTeamUI.UIData>();
							{
								oldTeams.AddRange (this.data.teams.vs);
							}
							// Update
							{
								foreach (int teamIndex in bracketContest.teamIndexs.vs) {
									// find
									ChooseBracketContestTeamUI.UIData teamUIData = null;
									{
										// find old
										if (oldTeams.Count > 0) {
											teamUIData = oldTeams [0];
										}
										// make new
										if (teamUIData == null) {
											teamUIData = new ChooseBracketContestTeamUI.UIData ();
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
										teamUIData.bracketContest.v = new ReferenceData<BracketContest> (bracketContest);
										teamUIData.teamIndex.v = teamIndex;
									}
								}
							}
							// remove old
							foreach (ChooseBracketContestTeamUI.UIData oldTeam in oldTeams) {
								this.data.teams.remove (oldTeam);
							}
						}
						// tvState
						{
							if (tvState != null) {
								tvState.text = txtState.get ("") + "" + bracketContest.contest.v.state.v.getType ();
							} else {
								Debug.LogError ("tvStatate null: " + this);
							}
						}
					} else {
						Debug.LogError ("bracketContest null: " + this);
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

		public ChooseBracketContestTeamUI teamPrefab;
		public Transform teamContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.bracketContest.allAddCallBack (this);
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
				// bracketContest
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
					if (data is Contest) {
						dirty = true;
						return;
					}
				}
				if (data is ChooseBracketContestTeamUI.UIData) {
					ChooseBracketContestTeamUI.UIData teamUIData = data as ChooseBracketContestTeamUI.UIData;
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
					uiData.bracketContest.allRemoveCallBack (this);
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
				// bracketContest
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
					if (data is Contest) {
						return;
					}
				}
				if (data is ChooseBracketContestTeamUI.UIData) {
					ChooseBracketContestTeamUI.UIData teamUIData = data as ChooseBracketContestTeamUI.UIData;
					// UI
					{
						teamUIData.removeCallBackAndDestroy (typeof(ChooseBracketContestTeamUI));
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
				case UIData.Property.bracketContest:
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
				// bracketContest
				{
					if (wrapProperty.p is BracketContest) {
						switch ((BracketContest.Property)wrapProperty.n) {
						case BracketContest.Property.isActive:
							dirty = true;
							break;
						case BracketContest.Property.index:
							dirty = true;
							break;
						case BracketContest.Property.teamIndexs:
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
				if (wrapProperty.p is ChooseBracketContestTeamUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnShow()
		{
			if (this.data != null) {
				BracketContest bracketContest = this.data.bracketContest.v.data;
				if (bracketContest != null) {
					BracketUI.UIData bracketUIData = this.data.findDataInParent<BracketUI.UIData> ();
					if (bracketUIData != null) {
						BracketContestUI.UIData bracketContestUIData = bracketUIData.bracketContestUIData.v;
						if (bracketContestUIData != null) {
							bracketContestUIData.bracketContest.v = new ReferenceData<BracketContest> (bracketContest);
						} else {
							Debug.LogError ("bracketContestUIData null: " + this);
						}
					} else {
						Debug.LogError ("bracketRobinUIData null: " + this);
					}
				} else {
					Debug.LogError ("bracketContest null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}