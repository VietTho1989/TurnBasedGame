using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class BtnEliminationContentUI : UIBehavior<BtnEliminationContentUI.UIData>
	{

		#region UIData

		public class UIData : RoomBtnUI.UIData.Sub
		{

			public VP<ReferenceData<EliminationContentUI.UIData>> eliminationContentUIData;

			#region Constructor

			public enum Property
			{
				eliminationContentUIData
			}

			public UIData() : base()
			{
				this.eliminationContentUIData = new VP<ReferenceData<EliminationContentUI.UIData>>(this, (byte)Property.eliminationContentUIData, new ReferenceData<EliminationContentUI.UIData>(null));
			}

			#endregion

			public override Type getType ()
			{
				return Type.EliminationContent;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtEliminationContent = new TxtLanguage();

		static BtnEliminationContentUI()
		{
			txtEliminationContent.add (Language.Type.vi, "Vòng loại trực ");
		}

		#endregion

		public Text tvEliminationContent;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EliminationContentUI.UIData eliminationContentUIData = this.data.eliminationContentUIData.v.data;
					if (eliminationContentUIData != null) {
						// tvEliminationContent
						{
							if (tvEliminationContent != null) {
								int eliminationRoundIndex = 0;
								int eliminationRoundCount = 0;
								{
									// eliminationRoundIndex
									{
										EliminationRoundUI.UIData eliminationRoundUIData = eliminationContentUIData.eliminationRoundUIData.v;
										if (eliminationRoundUIData != null) {
											EliminationRound eliminationRound = eliminationRoundUIData.eliminationRound.v.data;
											if (eliminationRound != null) {
												eliminationRoundIndex = eliminationRound.index.v;
											} else {
												Debug.LogError ("eliminationRound null: " + this);
											}
										} else {
											Debug.LogError ("eliminationRoundUIData null: " + this);
										}
									}
									// eliminationRoundCount
									{
										EliminationContent eliminationContent = eliminationContentUIData.eliminationContent.v.data;
										if (eliminationContent != null) {
											foreach (EliminationRound eliminationRound in eliminationContent.rounds.vs) {
												if (eliminationRound.isActive.v) {
													eliminationRoundCount++;
												}
											}
										} else {
											// Debug.LogError ("eliminationContent null: " + this);
										}
									}
								}
								tvEliminationContent.text = txtEliminationContent.get ("Elimination Round") + " " + eliminationRoundIndex + "/" + eliminationRoundCount;
							} else {
								Debug.LogError ("tvEliminationContent null: " + this);
							}
						}
					} else {
						Debug.LogError ("eliminationContentUIData null: " + this);
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
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.eliminationContentUIData.allAddCallBack (this);
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
				if (data is EliminationContentUI.UIData) {
					EliminationContentUI.UIData eliminationContentUIData = data as EliminationContentUI.UIData;
					// Child
					{
						eliminationContentUIData.eliminationContent.allAddCallBack (this);
						eliminationContentUIData.eliminationRoundUIData.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is EliminationContent) {
						EliminationContent eliminationContent = data as EliminationContent;
						// Child
						{
							eliminationContent.rounds.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// eliminationRoundUIData
					{
						if (data is EliminationRoundUI.UIData) {
							dirty = true;
							return;
						}
					}
					// Child
					if (data is EliminationRound) {
						dirty = true;
						return;
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
					uiData.eliminationContentUIData.allRemoveCallBack (this);
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
				if (data is EliminationContentUI.UIData) {
					EliminationContentUI.UIData eliminationContentUIData = data as EliminationContentUI.UIData;
					// Child
					{
						eliminationContentUIData.eliminationContent.allRemoveCallBack (this);
						eliminationContentUIData.eliminationRoundUIData.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is EliminationContent) {
						EliminationContent eliminationContent = data as EliminationContent;
						// Child
						{
							eliminationContent.rounds.allRemoveCallBack (this);
						}
						return;
					}
					// eliminationRoundUIData
					{
						if (data is EliminationRoundUI.UIData) {
							return;
						}
					}
					// Child
					if (data is EliminationRound) {
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
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.eliminationContentUIData:
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
				if (wrapProperty.p is EliminationContentUI.UIData) {
					switch ((EliminationContentUI.UIData.Property)wrapProperty.n) {
					case EliminationContentUI.UIData.Property.eliminationContent:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case EliminationContentUI.UIData.Property.eliminationRoundUIData:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case EliminationContentUI.UIData.Property.chooseEliminationRoundUIData:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is EliminationContent) {
						switch ((EliminationContent.Property)wrapProperty.n) {
						case EliminationContent.Property.singleContestFactory:
							break;
						case EliminationContent.Property.initTeamCounts:
							break;
						case EliminationContent.Property.requestNewRound:
							break;
						case EliminationContent.Property.rounds:
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
					// eliminationRoundUIData
					{
						if (wrapProperty.p is EliminationRoundUI.UIData) {
							switch ((EliminationRoundUI.UIData.Property)wrapProperty.n) {
							case EliminationRoundUI.UIData.Property.eliminationRound:
								dirty = true;
								break;
							case EliminationRoundUI.UIData.Property.bracketUIData:
								break;
							case EliminationRoundUI.UIData.Property.chooseBracketUIData:
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
					}
					// Child
					if (wrapProperty.p is EliminationRound) {
						switch ((EliminationRound.Property)wrapProperty.n) {
						case EliminationRound.Property.isActive:
							dirty = true;
							break;
						case EliminationRound.Property.state:
							break;
						case EliminationRound.Property.index:
							break;
						case EliminationRound.Property.brackets:
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

		public void onClickBtnEliminationContent()
		{
			if (this.data != null) {
				EliminationContentUI.UIData eliminationContentUIData = this.data.eliminationContentUIData.v.data;
				if (eliminationContentUIData != null) {
					ChooseEliminationRoundUI.UIData chooseEliminationRoundUIData = eliminationContentUIData.chooseEliminationRoundUIData.newOrOld<ChooseEliminationRoundUI.UIData> ();
					{

					}
					eliminationContentUIData.chooseEliminationRoundUIData.v = chooseEliminationRoundUIData;
				} else {
					Debug.LogError ("eliminationContentUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}