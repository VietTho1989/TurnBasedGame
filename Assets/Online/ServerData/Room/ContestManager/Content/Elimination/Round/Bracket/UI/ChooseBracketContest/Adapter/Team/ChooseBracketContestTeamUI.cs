﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class ChooseBracketContestTeamUI : UIBehavior<ChooseBracketContestTeamUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<BracketContest>> bracketContest;

			public VP<int> teamIndex;

			#region Constructor

			public enum Property
			{
				bracketContest,
				teamIndex
			}

			public UIData() : base()
			{
				this.bracketContest = new VP<ReferenceData<BracketContest>>(this, (byte)Property.bracketContest, new ReferenceData<BracketContest>(null));
				this.teamIndex = new VP<int>(this, (byte)Property.teamIndex, 0);
			}

			#endregion

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtTeamIndex = new TxtLanguage ();
		public static readonly TxtLanguage txtTeamScore = new TxtLanguage ();

		static ChooseBracketContestTeamUI()
		{
			txtTeamIndex.add (Language.Type.vi, "Chỉ Số Đội");
			txtTeamScore.add (Language.Type.vi, "Điểm Đội");
		}

		#endregion

		public Text tvTeamIndex;
		public Text tvTeamScore;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					BracketContest bracketContest = this.data.bracketContest.v.data;
					if (bracketContest != null) {
						// tvTeamIndex
						{
							if (tvTeamIndex != null) {
								tvTeamIndex.text = txtTeamIndex.get ("TeamIndex") + ": " + this.data.teamIndex.v;
							} else {
								Debug.LogError ("tvTeamIndex null: " + this);
							}
						}
						// tvTeamScore
						{
							if (tvTeamScore != null) {
								float score = bracketContest.getResult (this.data.teamIndex.v);
								tvTeamScore.text = txtTeamScore.get ("TeamScore") + ": " + score;
							} else {
								Debug.LogError ("tvTeamScore null: " + this);
							}
						}
					} else {
						// Debug.LogError ("bracketContest null: " + this);
					}
				} else {
					// Debug.LogError ("data null: " + this);
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
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get ().addCallBack (this);
				// Child
				{
					uiData.bracketContest.allAddCallBack (this);
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
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().removeCallBack(this);
				// Child
				{
					uiData.bracketContest.allRemoveCallBack (this);
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
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.bracketContest:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.teamIndex:
					dirty = true;
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
				if (wrapProperty.p is BracketContest) {
					switch ((BracketContest.Property)wrapProperty.n) {
					case BracketContest.Property.isActive:
						break;
					case BracketContest.Property.index:
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