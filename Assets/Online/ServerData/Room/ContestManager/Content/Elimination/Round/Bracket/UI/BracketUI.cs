using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class BracketUI : UIBehavior<BracketUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<Bracket>> bracket;

			public VP<BracketContestUI.UIData> bracketContestUIData;

			public VP<ChooseBracketContestUI.UIData> chooseBracketContestUIData;

			#region Constructor

			public enum Property
			{
				bracket,
				bracketContestUIData,
				chooseBracketContestUIData
			}

			public UIData() : base()
			{
				this.bracket = new VP<ReferenceData<Bracket>>(this, (byte)Property.bracket, new ReferenceData<Bracket>(null));
				this.bracketContestUIData = new VP<BracketContestUI.UIData>(this, (byte)Property.bracketContestUIData, new BracketContestUI.UIData());
				this.chooseBracketContestUIData = new VP<ChooseBracketContestUI.UIData>(this, (byte)Property.chooseBracketContestUIData, null);
			}

			#endregion

			public void reset()
			{
				this.chooseBracketContestUIData.v = null;
			}

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{
					// chooseBracketContestUIData
					if (!isProcess) {
						ChooseBracketContestUI.UIData chooseBracketContestUIData = this.chooseBracketContestUIData.v;
						if (chooseBracketContestUIData != null) {
							isProcess = chooseBracketContestUIData.processEvent (e);
						} else {
							Debug.LogError ("chooseBracketContestUIData null: " + this);
						}
					}
					// bracketContestUIData
					if (!isProcess) {
						BracketContestUI.UIData bracketContestUIData = this.bracketContestUIData.v;
						if (bracketContestUIData != null) {
							isProcess = bracketContestUIData.processEvent (e);
						} else {
							Debug.LogError ("bracketContestUIData null: " + this);
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text tvNoBracketContest;
		public static readonly TxtLanguage txtNoBracketContest = new TxtLanguage ();

		static BracketUI()
		{
			txtNoBracketContest.add (Language.Type.vi, "Không có  trận đấu nào");
		}

		#endregion

		public GameObject noBracketContest;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Bracket bracket = this.data.bracket.v.data;
					if (bracket != null) {
						// bracketContestUIData
						{
							// check isLoadFull
							bool isLoadFull = true;
							{
								// dataIdentity
								if (isLoadFull) {
									DataIdentity dataIdentity = null;
									if (DataIdentity.clientMap.TryGetValue (bracket, out dataIdentity)) {
										if (dataIdentity is BracketIdentity) {
											BracketIdentity bracketIdentity = dataIdentity as  BracketIdentity;
											if (bracketIdentity.bracketContests != bracket.bracketContests.vs.Count) {
												Debug.LogError ("bracket bracketContest count error");
												isLoadFull = false;
											}
										} else {
											Debug.LogError ("why not bracketIdentity");
										}
									}
								}
							}
							// process
							if (isLoadFull) {
								BracketContestUI.UIData bracketContestUIData = this.data.bracketContestUIData.v;
								if (bracketContestUIData != null) {
									// find
									bool alreadySet = false;
									{
										BracketContest bracketContest = bracketContestUIData.bracketContest.v.data;
										if (bracketContest != null) {
											if (bracketContest.isActive.v) {
												if (bracket.bracketContests.vs.Contains (bracketContest)) {
													alreadySet = true;
												}
											}
										} else {
											Debug.LogError ("bracketContest null: " + this);
										}
									}
									// set
									if (!alreadySet) {
										// get active list
										List<BracketContest> bracketContests = new List<BracketContest> ();
										{
											foreach (BracketContest bracketContest in bracket.bracketContests.vs) {
												if (bracketContest.isActive.v) {
													bracketContests.Add (bracketContest);
												}
											}
										}
										// Process
										if (bracketContests.Count > 0) {
											// find
											BracketContest chosenBracketContest = bracketContests [0];
											{
												uint profileId = Server.getProfileUserId (bracket);
												foreach (BracketContest bracketContest in bracketContests) {
													// find have you
													bool haveYouInside = false;
													{
														Contest contest = bracketContest.contest.v;
														if (contest != null) {
															foreach (MatchTeam matchTeam in contest.teams.vs) {
																foreach (TeamPlayer teamPlayer in matchTeam.players.vs) {
																	if (teamPlayer.inform.v is Human) {
																		Human human = teamPlayer.inform.v as Human;
																		if (human.playerId.v == profileId) {
																			haveYouInside = true;
																			break;
																		}
																	}
																}
															}
														} else {
															Debug.LogError ("contest null: " + this);
														}
													}
													// process
													if (haveYouInside) {
														chosenBracketContest = bracketContest;
														break;
													}
												}
											}
											// set
											bracketContestUIData.bracketContest.v = new ReferenceData<BracketContest> (chosenBracketContest);
										} else {
											Debug.LogError ("why don't have bracketContests: " + this);
										}
									}
								} else {
									Debug.LogError ("bracketContestUIData null: " + this);
								}
							} else {
								Debug.LogError ("not load full");
								dirty = true;
							}
						}
						// chooseBracketContestUIData
						{
							ChooseBracketContestUI.UIData chooseBracketContestUIData = this.data.chooseBracketContestUIData.v;
							if (chooseBracketContestUIData != null) {
								chooseBracketContestUIData.bracket.v = new ReferenceData<Bracket> (bracket);
							} else {
								// Debug.LogError ("chooseBracketContestUIData null: " + this);
							}
						}
						// noBracketContest
						{
							if (noBracketContest != null) {
								// find
								bool haveBracketContest = false;
								{
									foreach (BracketContest bracketContest in bracket.bracketContests.vs) {
										if (bracketContest.isActive.v) {
											haveBracketContest = true;
											break;
										}
									}
								}
								// process
								noBracketContest.SetActive(!haveBracketContest);
							} else {
								Debug.LogError ("noBracketContest: " + this);
							}
						}
					} else {
						Debug.LogError ("bracket null: " + this);
					}
					// txt
					{
						if (tvNoBracketContest != null) {
							tvNoBracketContest.text = txtNoBracketContest.get ("Don't have any bracket matchs");
						} else {
							Debug.LogError ("tvNoBracketContest null: " + this);
						}
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

		public BracketContestUI bracketContestPrefab;
		public Transform bracketContestContainer;

		public ChooseBracketContestUI chooseBracketContestPrefab;
		public Transform chooseBracketContestContainer;

		private RoomUI.UIData roomUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.roomUIData);
				}
				// Child
				{
					uiData.bracket.allAddCallBack (this);
					uiData.bracketContestUIData.allAddCallBack (this);
					uiData.chooseBracketContestUIData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Setting
			if (data is Setting) {
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is RoomUI.UIData) {
					RoomUI.UIData roomUIData = data as RoomUI.UIData;
					// Add BtnBracketUI
					{
						RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
						if (roomBtnUIData != null) {
							BtnBracketUI.UIData btnBracketUIData = new BtnBracketUI.UIData ();
							{
								btnBracketUIData.uid = roomBtnUIData.subs.makeId ();
								btnBracketUIData.bracketUIData.v = new ReferenceData<UIData> (this.data);
							}
							roomBtnUIData.subs.add (btnBracketUIData);
						} else {
							Debug.LogError ("roomBtnUIData null: " + this);
						}
					}
					dirty = true;
					return;
				}
			}
			// Child
			{
				if (data is Bracket) {
					// reset
					{
						if (this.data != null) {
							this.data.reset ();
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
					dirty = true;
					return;
				}
				if (data is BracketContestUI.UIData) {
					BracketContestUI.UIData bracketContestUIData = data as BracketContestUI.UIData;
					// UI
					{
						UIUtils.Instantiate (bracketContestUIData, bracketContestPrefab, bracketContestContainer);
					}
					dirty = true;
					return;
				}
				if (data is ChooseBracketContestUI.UIData) {
					ChooseBracketContestUI.UIData chooseBracketContestUIData = data as ChooseBracketContestUI.UIData;
					// UI
					{
						UIUtils.Instantiate (chooseBracketContestUIData, chooseBracketContestPrefab, chooseBracketContestContainer);
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
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.roomUIData);
				}
				// Child
				{
					uiData.bracket.allRemoveCallBack (this);
					uiData.bracketContestUIData.allRemoveCallBack (this);
					uiData.chooseBracketContestUIData.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Parent
			{
				if (data is RoomUI.UIData) {
					RoomUI.UIData roomUIData = data as RoomUI.UIData;
					// Remove BtnBracketUI
					{
						RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
						if (roomBtnUIData != null) {
							foreach (RoomBtnUI.UIData.Sub sub in roomBtnUIData.subs.vs) {
								if (sub is BtnBracketUI.UIData) {
									BtnBracketUI.UIData btnBracketUIData = sub as BtnBracketUI.UIData;
									if (btnBracketUIData.bracketUIData.v.data == this.data) {
										roomBtnUIData.subs.remove (sub);
										break;
									}
								}
							}
						} else {
							Debug.LogError ("roomBtnUIData null: " + this);
						}
					}
					return;
				}
			}
			// Child
			{
				if (data is Bracket) {
					return;
				}
				if (data is BracketContestUI.UIData) {
					BracketContestUI.UIData bracketContestUIData = data as BracketContestUI.UIData;
					// UI
					{
						bracketContestUIData.removeCallBackAndDestroy (typeof(BracketContestUI));
					}
					return;
				}
				if (data is ChooseBracketContestUI.UIData) {
					ChooseBracketContestUI.UIData chooseBracketContestUIData = data as ChooseBracketContestUI.UIData;
					// UI
					{
						chooseBracketContestUIData.removeCallBackAndDestroy (typeof(ChooseBracketContestUI));
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
				case UIData.Property.bracket:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.bracketContestUIData:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.chooseBracketContestUIData:
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
			// Parent
			if (wrapProperty.p is RoomUI.UIData) {
				return;
			}
			// Child
			{
				if (wrapProperty.p is Bracket) {
					switch ((Bracket.Property)wrapProperty.n) {
					case Bracket.Property.isActive:
						break;
					case Bracket.Property.state:
						break;
					case Bracket.Property.index:
						break;
					case Bracket.Property.bracketContests:
						dirty = true;
						break;
					case Bracket.Property.byeTeamIndexs:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is BracketContestUI.UIData) {
					switch ((BracketContestUI.UIData.Property)wrapProperty.n) {
					case BracketContestUI.UIData.Property.bracketContest:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is ChooseBracketContestUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}