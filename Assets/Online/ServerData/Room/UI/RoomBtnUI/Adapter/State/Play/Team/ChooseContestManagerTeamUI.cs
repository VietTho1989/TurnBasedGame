using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ChooseContestManagerTeamUI : UIBehavior<ChooseContestManagerTeamUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<MatchTeam>> matchTeam;

			#region Constructor

			public enum Property
			{
				matchTeam
			}

			public UIData() : base()
			{
				this.matchTeam = new VP<ReferenceData<MatchTeam>>(this, (byte)Property.matchTeam, new ReferenceData<MatchTeam>(null));
			}

			#endregion

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtIndex = new TxtLanguage();
		public static readonly TxtLanguage txtScore = new TxtLanguage();

		static ChooseContestManagerTeamUI()
		{
			txtIndex.add (Language.Type.vi, "Chỉ số");
			txtScore.add (Language.Type.vi, "Điểm ");
		}

		#endregion

		public Text tvIndex;
		public Text tvScore;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					MatchTeam matchTeam = this.data.matchTeam.v.data;
					if (matchTeam != null) {
						// tvIndex
						{
							if (tvIndex != null) {
								tvIndex.text = txtIndex.get ("Index") + ": " + matchTeam.teamIndex.v;
							} else {
								Debug.LogError ("tvIndex null: " + this);
							}
						}
						// tvScore
						{
							if (tvScore != null) {
								float score = 0;
								{
									ContestManagerStatePlay contestManagerStatePlay = matchTeam.findDataInParent<ContestManagerStatePlay> ();
									if (contestManagerStatePlay != null) {
										ContentTeamResult contentTeamResult = contestManagerStatePlay.contentTeamResult.v;
										if (contentTeamResult != null) {
											score = contentTeamResult.getResult (matchTeam.teamIndex.v);
										} else {
											Debug.LogError ("contentTeamResult null: " + this);
										}
									} else {
										Debug.LogError ("contestManagerStatePlay null: " + this);
									}
								}
								tvScore.text = txtScore.get ("Score") + ": " + score;
							} else {
								Debug.LogError ("tvScore null: " + this);
							}
						}
					} else {
						Debug.LogError ("matchTeam null: " + this);
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
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.matchTeam.allAddCallBack (this);
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
				if (data is MatchTeam) {
					MatchTeam matchTeam = data as MatchTeam;
					// Parent
					{
						DataUtils.addParentCallBack (matchTeam, this, ref this.contestManagerStatePlay);
					}
					dirty = true;
					return;
				}
				// Parent
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
					uiData.matchTeam.allRemoveCallBack (this);
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
				if (data is MatchTeam) {
					MatchTeam matchTeam = data as MatchTeam;
					// Parent
					{
						DataUtils.removeParentCallBack (matchTeam, this, ref this.contestManagerStatePlay);
					}
					return;
				}
				// Parent
				{
					if (data is ContestManagerStatePlay) {
						ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
						// Child
						{
							contestManagerStatePlay.contentTeamResult.allRemoveCallBack (this);
						}
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
				case UIData.Property.matchTeam:
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
				if (wrapProperty.p is MatchTeam) {
					switch ((MatchTeam.Property)wrapProperty.n) {
					case MatchTeam.Property.teamIndex:
						dirty = true;
						break;
					case MatchTeam.Property.state:
						break;
					case MatchTeam.Property.players:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Parent
				{
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
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
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
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}