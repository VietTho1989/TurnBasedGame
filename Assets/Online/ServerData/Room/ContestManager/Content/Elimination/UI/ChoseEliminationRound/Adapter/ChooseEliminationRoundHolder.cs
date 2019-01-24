using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class ChooseEliminationRoundHolder : SriaHolderBehavior<ChooseEliminationRoundHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<ReferenceData<EliminationRound>> eliminationRound;

			public LP<ChooseEliminationRoundBracketUI.UIData> brackets;

			#region Constructor

			public enum Property
			{
				eliminationRound,
				brackets
			}

			public UIData() : base()
			{
				this.eliminationRound = new VP<ReferenceData<EliminationRound>>(this, (byte)Property.eliminationRound, new ReferenceData<EliminationRound>(null));
				this.brackets = new LP<ChooseEliminationRoundBracketUI.UIData>(this, (byte)Property.brackets);
			}

			#endregion

			public void updateView(ChooseEliminationRoundAdapter.UIData myParams)
			{
				// Find
				EliminationRound eliminationRound = null;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.eliminationRounds.Count) {
						eliminationRound = myParams.eliminationRounds [ItemIndex];
					} else {
						Debug.LogError ("ItemIdex error: " + this);
					}
				}
				// Update
				this.eliminationRound.v = new ReferenceData<EliminationRound> (eliminationRound);
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text tvShow;
		public static readonly TxtLanguage txtShow = new TxtLanguage();

		public static readonly TxtLanguage txtIndex = new TxtLanguage ();
		public static readonly TxtLanguage txtState = new TxtLanguage ();

		static ChooseEliminationRoundHolder()
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
					EliminationRound eliminationRound = this.data.eliminationRound.v.data;
					if (eliminationRound != null) {
						// tvIndex
						{
							if (tvIndex != null) {
								tvIndex.text = txtIndex.get ("Index") + ": " + eliminationRound.index.v;
							} else {
								Debug.LogError ("tvIndex null: " + this);
							}
						}
						// brackets
						{
							// get old
							List<ChooseEliminationRoundBracketUI.UIData> oldBrackets = new List<ChooseEliminationRoundBracketUI.UIData>();
							{
								oldBrackets.AddRange (this.data.brackets.vs);
							}
							// Update
							{
								// get active list
								List<Bracket> brackets = new List<Bracket>();
								{
									foreach (Bracket bracket in eliminationRound.brackets.vs) {
										if (bracket.isActive.v) {
											brackets.Add (bracket);
										}
									}
								}
								// Update
								foreach (Bracket bracket in brackets) {
									// find
									ChooseEliminationRoundBracketUI.UIData bracketUIData = null;
									{
										// find old
										if (oldBrackets.Count > 0) {
											bracketUIData = oldBrackets [0];
										}
										// make new
										if (bracketUIData == null) {
											bracketUIData = new ChooseEliminationRoundBracketUI.UIData ();
											{
												bracketUIData.uid = this.data.brackets.makeId ();
											}
											this.data.brackets.add (bracketUIData);
										} else {
											oldBrackets.Remove (bracketUIData);
										}
									}
									// update
									{
										bracketUIData.bracket.v = new ReferenceData<Bracket> (bracket);
									}
								}
							}
							// remove old
							foreach (ChooseEliminationRoundBracketUI.UIData oldBracket in oldBrackets) {
								this.data.brackets.remove (oldBracket);
							}
						}
						// tvState
						{
							if (tvState != null) {
								tvState.text = txtState.get ("") + "" + eliminationRound.state.v.getType ();
							} else {
								Debug.LogError ("tvStatate null: " + this);
							}
						}
					} else {
						Debug.LogError ("eliminationRound null: " + this);
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

		public ChooseEliminationRoundBracketUI bracketPrefab;
		public Transform bracketContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.eliminationRound.allAddCallBack (this);
					uiData.brackets.allAddCallBack (this);
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
				// eliminationRound
				{
					if (data is EliminationRound) {
						EliminationRound eliminationRound = data as EliminationRound;
						// Child
						{
							eliminationRound.brackets.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is Bracket) {
						dirty = true;
						return;
					}
				}
				if (data is ChooseEliminationRoundBracketUI.UIData) {
					ChooseEliminationRoundBracketUI.UIData bracketUIData = data as ChooseEliminationRoundBracketUI.UIData;
					// UI
					{
						UIUtils.Instantiate (bracketUIData, bracketPrefab, bracketContainer);
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
					uiData.eliminationRound.allRemoveCallBack (this);
					uiData.brackets.allRemoveCallBack (this);
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
				// eliminationRound
				{
					if (data is EliminationRound) {
						EliminationRound eliminationRound = data as EliminationRound;
						// Child
						{
							eliminationRound.brackets.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is Bracket) {
						return;
					}
				}
				if (data is ChooseEliminationRoundBracketUI.UIData) {
					ChooseEliminationRoundBracketUI.UIData bracketUIData = data as ChooseEliminationRoundBracketUI.UIData;
					// UI
					{
						bracketUIData.removeCallBackAndDestroy (typeof(ChooseEliminationRoundBracketUI));
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
				case UIData.Property.eliminationRound:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.brackets:
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
				// eliminationRound
				{
					if (wrapProperty.p is EliminationRound) {
						switch ((EliminationRound.Property)wrapProperty.n) {
						case EliminationRound.Property.isActive:
							break;
						case EliminationRound.Property.state:
							dirty = true;
							break;
						case EliminationRound.Property.index:
							break;
						case EliminationRound.Property.brackets:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
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
					if (wrapProperty.p is Bracket) {
						switch ((Bracket.Property)wrapProperty.n) {
						case Bracket.Property.isActive:
							dirty = true;
							break;
						case Bracket.Property.state:
							break;
						case Bracket.Property.index:
							break;
						case Bracket.Property.bracketContests:
							break;
						case Bracket.Property.byeTeamIndexs:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					}
				}
				if (wrapProperty.p is ChooseEliminationRoundBracketUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnShow()
		{
			if (this.data != null) {
				EliminationRound eliminationRound = this.data.eliminationRound.v.data;
				if (eliminationRound != null) {
					EliminationContentUI.UIData eliminationContentUIData = this.data.findDataInParent<EliminationContentUI.UIData> ();
					if (eliminationContentUIData != null) {
						EliminationRoundUI.UIData eliminationRoundUIData = eliminationContentUIData.eliminationRoundUIData.v;
						if (eliminationRoundUIData != null) {
							eliminationRoundUIData.eliminationRound.v = new ReferenceData<EliminationRound> (eliminationRound);
						} else {
							Debug.LogError ("eliminationRoundUIData null: " + this);
						}
					} else {
						Debug.LogError ("eliminationContentUIData null: " + this);
					}
				} else {
					Debug.LogError ("eliminationRound null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}