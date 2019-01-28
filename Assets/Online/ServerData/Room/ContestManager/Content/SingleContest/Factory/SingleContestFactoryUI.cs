﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class SingleContestFactoryUI : UIBehavior<SingleContestFactoryUI.UIData>
	{

		#region UIData

		public class UIData : ContestManagerContentFactoryUI.UIData.Sub
		{

			public VP<EditData<SingleContestFactory>> editSingleContestFactory;

			#region playerPerTeam

			public VP<RequestChangeIntUI.UIData> playerPerTeam;

			public void makeRequestChangePlayerPerTeam (RequestChangeUpdate<int>.UpdateData update, int newPlayerPerTeam)
			{
				// Find
				SingleContestFactory singleContestFactory = null;
				{
					EditData<SingleContestFactory> editSingleContestFactory = this.editSingleContestFactory.v;
					if (editSingleContestFactory != null) {
						singleContestFactory = editSingleContestFactory.show.v.data;
					} else {
						Debug.LogError ("editSingleContestFactory null: " + this);
					}
				}
				// Process
				if (singleContestFactory != null) {
					singleContestFactory.requestChangePlayerPerTeam (Server.getProfileUserId (singleContestFactory), newPlayerPerTeam);
				} else {
					Debug.LogError ("singleContestFactory null: " + this);
				}
			}

			#endregion

			#region roundFactory

			public VP<RequestChangeEnumUI.UIData> roundFactoryType;

			public void makeRequestChangeRoundFactoryType (RequestChangeUpdate<int>.UpdateData update, int newRoundFactoryType)
			{
				// Find
				SingleContestFactory singleContestFactory = null;
				{
					EditData<SingleContestFactory> editSingleContestFactory = this.editSingleContestFactory.v;
					if (editSingleContestFactory != null) {
						singleContestFactory = editSingleContestFactory.show.v.data;
					} else {
						Debug.LogError ("editSingleContestFactory null: " + this);
					}
				}
				// Process
				if (singleContestFactory != null) {
					singleContestFactory.requestChangeRoundFactoryType (Server.getProfileUserId (singleContestFactory), newRoundFactoryType);
				} else {
					Debug.LogError ("singleContestFactory null: " + this);
				}
			}

			public abstract class RoundFactoryUI : Data
			{

				public abstract RoundFactory.Type getType();

				public abstract bool processEvent(Event e);

			}

			public VP<RoundFactoryUI> roundFactoryUI;

			#endregion

			#region limit

			public VP<RequestChangeEnumUI.UIData> newRoundLimitType;

			public void makeRequestChangeNewRoundLimitType (RequestChangeUpdate<int>.UpdateData update, int newRoundLimitType)
			{
				// Find
				SingleContestFactory singleContestFactory = null;
				{
					EditData<SingleContestFactory> editSingleContestFactory = this.editSingleContestFactory.v;
					if (editSingleContestFactory != null) {
						singleContestFactory = editSingleContestFactory.show.v.data;
					} else {
						Debug.LogError ("editSingleContestFactory null: " + this);
					}
				}
				// Process
				if (singleContestFactory != null) {
					singleContestFactory.requestChangeNewRoundLimitType (Server.getProfileUserId (singleContestFactory), newRoundLimitType);
				} else {
					Debug.LogError ("singleContestFactory null: " + this);
				}
			}

			public abstract class NewRoundLimitUI : Data
			{

				public abstract RequestNewRound.Limit.Type getType();

				public abstract bool processEvent(Event e);

			}

			public VP<NewRoundLimitUI> newRoundLimitUI;

			#endregion

			#region calculateScore

			public VP<RequestChangeEnumUI.UIData> calculateScoreType;

			public void makeRequestChangeCalculateScoreType (RequestChangeUpdate<int>.UpdateData update, int newCalculateScoreType)
			{
				// Find
				SingleContestFactory singleContestFactory = null;
				{
					EditData<SingleContestFactory> editSingleContestFactory = this.editSingleContestFactory.v;
					if (editSingleContestFactory != null) {
						singleContestFactory = editSingleContestFactory.show.v.data;
					} else {
						Debug.LogError ("editSingleContestFactory null: " + this);
					}
				}
				// Process
				if (singleContestFactory != null) {
					singleContestFactory.requestChangeCalculateScoreType (Server.getProfileUserId (singleContestFactory), newCalculateScoreType);
				} else {
					Debug.LogError ("singleContestFactory null: " + this);
				}
			}

			public VP<CalculateScore.UIData> calculateScoreUI;

			#endregion

			#region Constructor

			public enum Property
			{
				editSingleContestFactory,
				playerPerTeam,

				roundFactoryType,
				roundFactoryUI,

				newRoundLimitType,
				newRoundLimitUI,

				calculateScoreType,
				calculateScoreUI
			}

			public UIData() : base()
			{
				this.editSingleContestFactory = new VP<EditData<SingleContestFactory>>(this, (byte)Property.editSingleContestFactory, new EditData<SingleContestFactory>());
				// playerPerTeam
				{
					this.playerPerTeam = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.playerPerTeam, new RequestChangeIntUI.UIData());
					// have limit
					{
						IntLimit.Have have = new IntLimit.Have();
						{
							have.uid = this.playerPerTeam.v.limit.makeId();
							have.min.v = 1;
							have.max.v = 20;
						}
						this.playerPerTeam.v.limit.v = have;
					}
					// event
					this.playerPerTeam.v.updateData.v.request.v = makeRequestChangePlayerPerTeam;
				}
				// roundFactoryType
				{
					this.roundFactoryType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.roundFactoryType, new RequestChangeEnumUI.UIData());
					// event
					this.roundFactoryType.v.updateData.v.request.v = makeRequestChangeRoundFactoryType;
					{
						foreach (RoundFactory.Type type in System.Enum.GetValues(typeof(RoundFactory.Type))) {
							this.roundFactoryType.v.options.add(type.ToString());
						}
					}
				}
				this.roundFactoryUI = new VP<RoundFactoryUI>(this, (byte)Property.roundFactoryUI, null);
				// newRoundLimitType
				{
					this.newRoundLimitType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.newRoundLimitType, new RequestChangeEnumUI.UIData());
					// event
					this.newRoundLimitType.v.updateData.v.request.v = makeRequestChangeNewRoundLimitType;
					{
						foreach (RequestNewRound.Limit.Type type in System.Enum.GetValues(typeof(RequestNewRound.Limit.Type))) {
							this.newRoundLimitType.v.options.add(type.ToString());
						}
					}
				}
				this.newRoundLimitUI = new VP<NewRoundLimitUI>(this, (byte)Property.newRoundLimitUI, null);
				// calculateScoreType
				{
					this.calculateScoreType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.calculateScoreType, new RequestChangeEnumUI.UIData());
					// event
					this.calculateScoreType.v.updateData.v.request.v = makeRequestChangeCalculateScoreType;
					{
						foreach (CalculateScore.Type type in System.Enum.GetValues(typeof(CalculateScore.Type))) {
							this.calculateScoreType.v.options.add(type.ToString());
						}
					}
				}
				this.calculateScoreUI = new VP<CalculateScore.UIData>(this, (byte)Property.calculateScoreUI, null);
			}

			#endregion

			public override ContestManagerContent.Type getType ()
			{
				return ContestManagerContent.Type.Single;
			}

			public override bool processEvent (Event e)
			{
				Debug.LogError ("processEvent: " + e + "; " + this);
				bool isProcess = false;
				{
					// newRoundLimitUI
					if (!isProcess) {
						NewRoundLimitUI newRoundLimitUIData = this.newRoundLimitUI.v;
						if (newRoundLimitUIData != null) {
							isProcess = newRoundLimitUIData.processEvent (e);
						} else {
							Debug.LogError ("newRoundLimitUIData null: " + this);
						}
					}
					// roundFactoryUI
					if (!isProcess) {
						RoundFactoryUI roundFactoryUI = this.roundFactoryUI.v;
						if (roundFactoryUI != null) {
							isProcess = roundFactoryUI.processEvent (e);
						} else {
							Debug.LogError ("roundFactoryUI null: " + this);
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage ();

		public Text lbPlayerPerTeam;
		public static readonly TxtLanguage txtPlayerPerTeam = new TxtLanguage();

		public Text lbRoundFactoryType;
		public static readonly TxtLanguage txtRoundFactoryType = new TxtLanguage();

		public Text lbNewRoundLimitType;
		public static readonly TxtLanguage txtNewRoundLimitType = new TxtLanguage();

		public Text lbCalculateScoreType;
		public static readonly TxtLanguage txtCalculateScoreType = new TxtLanguage();

		static SingleContestFactoryUI()
		{
			txtTitle.add (Language.Type.vi, "Tạo Trận Đấu");
			txtPlayerPerTeam.add (Language.Type.vi, "Số người chơi mỗi đội");
			txtRoundFactoryType.add (Language.Type.vi, "Loại tạo vòng đấu");
			txtNewRoundLimitType.add (Language.Type.vi, "Loại giới hạn số vòng");
			txtCalculateScoreType.add (Language.Type.vi, "Loại tính điểm");
		}

		#endregion

		private bool needReset = true;
		public GameObject differentIndicator;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<SingleContestFactory> editSingleContestFactory = this.data.editSingleContestFactory.v;
					if (editSingleContestFactory != null) {
						editSingleContestFactory.update ();
						// get show
						SingleContestFactory show = editSingleContestFactory.show.v.data;
						SingleContestFactory compare = editSingleContestFactory.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editSingleContestFactory.compareOtherType.v.data != null) {
										if (editSingleContestFactory.compareOtherType.v.data.GetType () != show.GetType ()) {
											isDifferent = true;
										}
									}
								}
								differentIndicator.SetActive (isDifferent);
							} else {
								Debug.LogError ("differentIndicator null: " + this);
							}
							// request
							{
								// get server state
								Server.State.Type serverState = Server.State.Type.Connect;
								{
									Server server = show.findDataInParent<Server> ();
									if (server != null) {
										if (server.state.v != null) {
											serverState = server.state.v.getType ();
										} else {
											Debug.LogError ("server state null: " + this);
										}
									} else {
										Debug.LogError ("server null: " + this);
									}
								}
								// set origin
								{
									// playerPerTeam
									{
										RequestChangeIntUI.UIData playerPerTeam = this.data.playerPerTeam.v;
										if (playerPerTeam != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = playerPerTeam.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.playerPerTeam.v;
												updateData.canRequestChange.v = editSingleContestFactory.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													playerPerTeam.showDifferent.v = true;
													playerPerTeam.compare.v = compare.playerPerTeam.v;
												} else {
													playerPerTeam.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("useRule null: " + this);
										}
									}
									// roundFactoryType
									{
										RequestChangeEnumUI.UIData roundFactoryType = this.data.roundFactoryType.v;
										if (roundFactoryType != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = roundFactoryType.updateData.v;
											if (updateData != null) {
												updateData.origin.v = (int)show.getRoundFactoryType();
												updateData.canRequestChange.v = editSingleContestFactory.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													roundFactoryType.showDifferent.v = true;
													roundFactoryType.compare.v = (int)compare.getRoundFactoryType ();
												} else {
													roundFactoryType.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("roundFactoryType null: " + this);
										}
									}
									// roundFactoryUI
									{
										RoundFactory roundFactory = show.roundFactory.v;
										if (roundFactory != null) {
											// find origin 
											RoundFactory originRoundFactory = null;
											{
												SingleContestFactory originSingleContestFactory = editSingleContestFactory.origin.v.data;
												if (originSingleContestFactory != null) {
													originRoundFactory = originSingleContestFactory.roundFactory.v;
												} else {
													Debug.LogError ("origin null: " + this);
												}
											}
											// find compare
											RoundFactory compareRoundFactory = null;
											{
												if (compare != null) {
													compareRoundFactory = compare.roundFactory.v;
												} else {
													Debug.LogError ("compare null: " + this);
												}
											}
											switch (roundFactory.getType ()) {
											case RoundFactory.Type.Normal:
												{
													NormalRoundFactory normalRoundFactory = roundFactory as NormalRoundFactory;
													// UIData
													NormalRoundFactoryUI.UIData normalRoundFactoryUIData = this.data.roundFactoryUI.newOrOld<NormalRoundFactoryUI.UIData> ();
													{
														EditData<NormalRoundFactory> editNormalRoundFactory = normalRoundFactoryUIData.editNormalRoundFactory.v;
														if (editNormalRoundFactory != null) {
															// origin
															editNormalRoundFactory.origin.v = new ReferenceData<NormalRoundFactory> ((NormalRoundFactory)originRoundFactory);
															// show
															editNormalRoundFactory.show.v = new ReferenceData<NormalRoundFactory> (normalRoundFactory);
															// compare
															editNormalRoundFactory.compare.v = new ReferenceData<NormalRoundFactory> ((NormalRoundFactory)compareRoundFactory);
															// compareOtherType
															editNormalRoundFactory.compareOtherType.v = new ReferenceData<Data> (compareRoundFactory);
															// canEdit
															editNormalRoundFactory.canEdit.v = editSingleContestFactory.canEdit.v;
															// editType
															editNormalRoundFactory.editType.v = editSingleContestFactory.editType.v;
														} else {
															Debug.LogError ("editNormalRoundFactory null: " + this);
														}
													}
													this.data.roundFactoryUI.v = normalRoundFactoryUIData;
												}
												break;
											default:
												Debug.LogError ("unknown type: " + roundFactory.getType () + "; " + this);
												break;
											}
										} else {
											Debug.LogError ("show null: " + this);
										}
									}
									// newRoundLimitType
									{
										RequestChangeEnumUI.UIData newRoundLimitType = this.data.newRoundLimitType.v;
										if (newRoundLimitType != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = newRoundLimitType.updateData.v;
											if (updateData != null) {
												updateData.origin.v = (int)show.getNewRoundLimitType ();
												updateData.canRequestChange.v = editSingleContestFactory.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													newRoundLimitType.showDifferent.v = true;
													newRoundLimitType.compare.v = (int)compare.getNewRoundLimitType ();
												} else {
													newRoundLimitType.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("newRoundLimitType null: " + this);
										}
									}
									// newRoundLimitUI
									{
										RequestNewRound.Limit newRoundLimit = show.newRoundLimit.v;
										if (newRoundLimit != null) {
											// find origin 
											RequestNewRound.Limit originNewRoundLimit = null;
											{
												SingleContestFactory originSingleContestFactory = editSingleContestFactory.origin.v.data;
												if (originSingleContestFactory != null) {
													originNewRoundLimit = originSingleContestFactory.newRoundLimit.v;
												} else {
													Debug.LogError ("origin null: " + this);
												}
											}
											// find compare
											RequestNewRound.Limit compareNewRoundLimit = null;
											{
												if (compare != null) {
													compareNewRoundLimit = compare.newRoundLimit.v;
												} else {
													// Debug.LogError ("compare null: " + this);
												}
											}
											switch (newRoundLimit.getType ()) {
											case RequestNewRound.Limit.Type.NoLimit:
												{
													RequestNewRoundNoLimit newRoundNoLimit = newRoundLimit as RequestNewRoundNoLimit;
													// UIData
													RequestNewRoundNoLimitUI.UIData newRoundNoLimitUIData = this.data.newRoundLimitUI.newOrOld<RequestNewRoundNoLimitUI.UIData> ();
													{
														EditData<RequestNewRoundNoLimit> editNoLimit = newRoundNoLimitUIData.editNoLimit.v;
														if (editNoLimit != null) {
															// origin
															editNoLimit.origin.v = new ReferenceData<RequestNewRoundNoLimit> ((RequestNewRoundNoLimit)originNewRoundLimit);
															// show
															editNoLimit.show.v = new ReferenceData<RequestNewRoundNoLimit> (newRoundNoLimit);
															// compare
															editNoLimit.compare.v = new ReferenceData<RequestNewRoundNoLimit> ((RequestNewRoundNoLimit)compareNewRoundLimit);
															// compareOtherType
															editNoLimit.compareOtherType.v = new ReferenceData<Data> (compareNewRoundLimit);
															// canEdit
															editNoLimit.canEdit.v = editSingleContestFactory.canEdit.v;
															// editType
															editNoLimit.editType.v = editSingleContestFactory.editType.v;
														} else {
															Debug.LogError ("editNoLimit null: " + this);
														}
													}
													this.data.newRoundLimitUI.v = newRoundNoLimitUIData;
												}
												break;
											case RequestNewRound.Limit.Type.HaveLimit:
												{
													RequestNewRoundHaveLimit newRoundHaveLimit = newRoundLimit as RequestNewRoundHaveLimit;
													// UIData
													RequestNewRoundHaveLimitUI.UIData newRoundHaveLimitUIData = this.data.newRoundLimitUI.newOrOld<RequestNewRoundHaveLimitUI.UIData> ();
													{
														EditData<RequestNewRoundHaveLimit> editHaveLimit = newRoundHaveLimitUIData.editHaveLimit.v;
														if (editHaveLimit != null) {
															// origin
															editHaveLimit.origin.v = new ReferenceData<RequestNewRoundHaveLimit> ((RequestNewRoundHaveLimit)originNewRoundLimit);
															// show
															editHaveLimit.show.v = new ReferenceData<RequestNewRoundHaveLimit> (newRoundHaveLimit);
															// compare
															editHaveLimit.compare.v = new ReferenceData<RequestNewRoundHaveLimit> ((RequestNewRoundHaveLimit)compareNewRoundLimit);
															// compareOtherType
															editHaveLimit.compareOtherType.v = new ReferenceData<Data> (compareNewRoundLimit);
															// canEdit
															editHaveLimit.canEdit.v = editSingleContestFactory.canEdit.v;
															// editType
															editHaveLimit.editType.v = editSingleContestFactory.editType.v;
														} else {
															Debug.LogError ("editHaveLimit null: " + this);
														}
													}
													this.data.newRoundLimitUI.v = newRoundHaveLimitUIData;
												}
												break;
											default:
												Debug.LogError ("unknown type: " + newRoundLimit.getType () + "; " + this);
												break;
											}
										} else {
											Debug.LogError ("show null: " + this);
										}
									}
									// calculateScoreType
									{
										RequestChangeEnumUI.UIData calculateScoreType = this.data.calculateScoreType.v;
										if (calculateScoreType != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = calculateScoreType.updateData.v;
											if (updateData != null) {
												updateData.origin.v = (int)show.getCalculateScoreType ();
												updateData.canRequestChange.v = editSingleContestFactory.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													calculateScoreType.showDifferent.v = true;
													calculateScoreType.compare.v = (int)compare.getCalculateScoreType ();
												} else {
													calculateScoreType.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("calculateScoreType null: " + this);
										}
									}
									// calculateScoreUI
									{
										CalculateScore calculateScore = show.calculateScore.v;
										if (calculateScore != null) {
											// find origin 
											CalculateScore originCalculateScore = null;
											{
												SingleContestFactory originSingleContestFactory = editSingleContestFactory.origin.v.data;
												if (originSingleContestFactory != null) {
													originCalculateScore = originSingleContestFactory.calculateScore.v;
												} else {
													Debug.LogError ("origin null: " + this);
												}
											}
											// find compare
											CalculateScore compareCalculateScore = null;
											{
												if (compare != null) {
													compareCalculateScore = compare.calculateScore.v;
												} else {
													// Debug.LogError ("compare null: " + this);
												}
											}
											switch (calculateScore.getType ()) {
											case CalculateScore.Type.Sum:
												{
													CalculateScoreSum calculateScoreSum = calculateScore as CalculateScoreSum;
													// UIData
													CalculateScoreSumUI.UIData calculateScoreSumUIData = this.data.calculateScoreUI.newOrOld<CalculateScoreSumUI.UIData> ();
													{
														EditData<CalculateScoreSum> editCalculateScoreSum = calculateScoreSumUIData.editCalculateScoreSum.v;
														if (editCalculateScoreSum != null) {
															// origin
															editCalculateScoreSum.origin.v = new ReferenceData<CalculateScoreSum> ((CalculateScoreSum)originCalculateScore);
															// show
															editCalculateScoreSum.show.v = new ReferenceData<CalculateScoreSum> (calculateScoreSum);
															// compare
															editCalculateScoreSum.compare.v = new ReferenceData<CalculateScoreSum> ((CalculateScoreSum)compareCalculateScore);
															// compareOtherType
															editCalculateScoreSum.compareOtherType.v = new ReferenceData<Data> (compareCalculateScore);
															// canEdit
															editCalculateScoreSum.canEdit.v = editSingleContestFactory.canEdit.v;
															// editType
															editCalculateScoreSum.editType.v = editSingleContestFactory.editType.v;
														} else {
															Debug.LogError ("editCalculateScoreSum null: " + this);
														}
													}
													this.data.calculateScoreUI.v = calculateScoreSumUIData;
												}
												break;
											case CalculateScore.Type.WinLoseDraw:
												{
													CalculateScoreWinLoseDraw calculateScoreWinLoseDraw = calculateScore as CalculateScoreWinLoseDraw;
													// UIData
													CalculateScoreWinLoseDrawUI.UIData calculateScoreWinLoseDrawUIData = this.data.calculateScoreUI.newOrOld<CalculateScoreWinLoseDrawUI.UIData> ();
													{
														EditData<CalculateScoreWinLoseDraw> editCalculateScoreWinLoseDraw = calculateScoreWinLoseDrawUIData.editCalculateScoreWinLoseDraw.v;
														if (editCalculateScoreWinLoseDraw != null) {
															// origin
															editCalculateScoreWinLoseDraw.origin.v = new ReferenceData<CalculateScoreWinLoseDraw> ((CalculateScoreWinLoseDraw)originCalculateScore);
															// show
															editCalculateScoreWinLoseDraw.show.v = new ReferenceData<CalculateScoreWinLoseDraw> (calculateScoreWinLoseDraw);
															// compare
															editCalculateScoreWinLoseDraw.compare.v = new ReferenceData<CalculateScoreWinLoseDraw> ((CalculateScoreWinLoseDraw)compareCalculateScore);
															// compareOtherType
															editCalculateScoreWinLoseDraw.compareOtherType.v = new ReferenceData<Data> (compareCalculateScore);
															// canEdit
															editCalculateScoreWinLoseDraw.canEdit.v = editSingleContestFactory.canEdit.v;
															// editType
															editCalculateScoreWinLoseDraw.editType.v = editSingleContestFactory.editType.v;
														} else {
															Debug.LogError ("editCalculateScoreWinLoseDraw null: " + this);
														}
													}
													this.data.calculateScoreUI.v = calculateScoreWinLoseDrawUIData;
												}
												break;
											default:
												Debug.LogError ("unknown type: " + calculateScore.getType () + "; " + this);
												break;
											}
										} else {
											Debug.LogError ("show null: " + this);
										}
									}
								}
							}
							// reset
							if (needReset) {
								needReset = false;
								// playerPerTeam
								{
									RequestChangeIntUI.UIData playerPerTeam = this.data.playerPerTeam.v;
									if (playerPerTeam != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = playerPerTeam.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.playerPerTeam.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("useRule null: " + this);
									}
								}
								// roundFactoryType
								{
									RequestChangeEnumUI.UIData roundFactoryType = this.data.roundFactoryType.v;
									if (roundFactoryType != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = roundFactoryType.updateData.v;
										if (updateData != null) {
											updateData.current.v = (int)show.getRoundFactoryType();
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("useRule null: " + this);
									}
								}
								// newRoundLimitType
								{
									RequestChangeEnumUI.UIData newRoundLimitType = this.data.newRoundLimitType.v;
									if (newRoundLimitType != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = newRoundLimitType.updateData.v;
										if (updateData != null) {
											updateData.current.v = (int)show.getNewRoundLimitType ();
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("newRoundLimitType null: " + this);
									}
								}
								// calculateScoreType
								{
									RequestChangeEnumUI.UIData calculateScoreType = this.data.calculateScoreType.v;
									if (calculateScoreType != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = calculateScoreType.updateData.v;
										if (updateData != null) {
											updateData.current.v = (int)show.getCalculateScoreType ();
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("calculateScoreType null: " + this);
									}
								}
							}
						} else {
							Debug.LogError ("show null: " + this);
						}
					} else {
						Debug.LogError ("editSingleContestFactory null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Match Factory");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbPlayerPerTeam != null) {
							lbPlayerPerTeam.text = txtPlayerPerTeam.get ("Player per team");
						} else {
							Debug.LogError ("lbPlayerPerTeam null: " + this);
						}
						if (lbRoundFactoryType != null) {
							lbRoundFactoryType.text = txtRoundFactoryType.get ("Round factory type");
						} else {
							Debug.LogError ("lbRoundFactoryType null: " + this);
						}
						if (lbNewRoundLimitType != null) {
							lbNewRoundLimitType.text = txtNewRoundLimitType.get ("New round limit type");
						} else {
							Debug.LogError ("lbNewRoundLimitType null: " + this);
						}
						if (lbCalculateScoreType != null) {
							lbCalculateScoreType.text = txtCalculateScoreType.get ("Calculate score type");
						} else {
							Debug.LogError ("lbCalculateScoreType null: " + this);
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

		public RequestChangeIntUI requestIntPrefab;
		public RequestChangeEnumUI requestEnumPrefab;

		public NormalRoundFactoryUI normalRoundFactoryPrefab;

		public RequestNewRoundNoLimitUI requestNewRoundNoLimitPrefab;
		public RequestNewRoundHaveLimitUI requestNewRoundHaveLimitPrefab;

		public CalculateScoreSumUI calculateScoreSumPrefab;
		public CalculateScoreWinLoseDrawUI calculateScoreWinLoseDrawPrefab;

		public Transform playerPerTeamContainer;

		public Transform roundFactoryTypeContainer;
		public Transform roundFactoryUIContainer;

		public Transform newRoundLimitTypeContainer;
		public Transform newRoundLimitUIContainer;

		public Transform calculateScoreTypeContainer;
		public Transform calculateScoreUIContainer;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.editSingleContestFactory.allAddCallBack (this);
					uiData.playerPerTeam.allAddCallBack (this);
					// roundFactory
					{
						uiData.roundFactoryType.allAddCallBack (this);
						uiData.roundFactoryUI.allAddCallBack (this);
					}
					// requestNewRoundLimit
					{
						uiData.newRoundLimitType.allAddCallBack (this);
						uiData.newRoundLimitUI.allAddCallBack (this);
					}
					// calculateScore
					{
						uiData.calculateScoreType.allAddCallBack (this);
						uiData.calculateScoreUI.allAddCallBack (this);
					}
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
				// editSingleContestFactory
				{
					if (data is EditData<SingleContestFactory>) {
						EditData<SingleContestFactory> editSingleContestFactory = data as EditData<SingleContestFactory>;
						// Child
						{
							editSingleContestFactory.show.allAddCallBack (this);
							editSingleContestFactory.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is SingleContestFactory) {
							SingleContestFactory singleContestFactory = data as SingleContestFactory;
							// Parent
							{
								DataUtils.addParentCallBack (singleContestFactory, this, ref this.server);
							}
							needReset = true;
							dirty = true;
							return;
						}
						// Parent
						{
							if (data is Server) {
								dirty = true;
								return;
							}
						}
					}
				}
				// playerPerTeam
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.playerPerTeam:
								UIUtils.Instantiate (requestChange, requestIntPrefab, playerPerTeamContainer);
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("wrapProperty null: " + this);
						}
					}
					dirty = true;
					return;
				}
				// roundFactoryType, newRoundLimitType, calculateScoreType
				if (data is RequestChangeEnumUI.UIData) {
					RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.roundFactoryType:
								UIUtils.Instantiate (requestChange, requestEnumPrefab, roundFactoryTypeContainer);
								break;
							case UIData.Property.newRoundLimitType:
								UIUtils.Instantiate (requestChange, requestEnumPrefab, newRoundLimitTypeContainer);
								break;
							case UIData.Property.calculateScoreType:
								UIUtils.Instantiate (requestChange, requestEnumPrefab, calculateScoreTypeContainer);
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("wrapProperty null: " + this);
						}
					}
					dirty = true;
					return;
				}
				// roundFactoryUI
				if (data is UIData.RoundFactoryUI) {
					UIData.RoundFactoryUI roundFactoryUI = data as UIData.RoundFactoryUI;
					{
						switch (roundFactoryUI.getType ()) {
						case RoundFactory.Type.Normal:
							{
								NormalRoundFactoryUI.UIData normalRoundFactoryUIData = roundFactoryUI as NormalRoundFactoryUI.UIData;
								UIUtils.Instantiate (normalRoundFactoryUIData, normalRoundFactoryPrefab, roundFactoryUIContainer);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + roundFactoryUI.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				// newRoundLimitUI
				if (data is UIData.NewRoundLimitUI) {
					UIData.NewRoundLimitUI newRoundLimitUI = data as UIData.NewRoundLimitUI;
					// UI
					{
						switch (newRoundLimitUI.getType ()) {
						case RequestNewRound.Limit.Type.NoLimit:
							{
								RequestNewRoundNoLimitUI.UIData noLimitUIData = newRoundLimitUI as RequestNewRoundNoLimitUI.UIData;
								UIUtils.Instantiate (noLimitUIData, requestNewRoundNoLimitPrefab, newRoundLimitUIContainer);
							}
							break;
						case RequestNewRound.Limit.Type.HaveLimit:
							{
								RequestNewRoundHaveLimitUI.UIData haveLimitUIData = newRoundLimitUI as RequestNewRoundHaveLimitUI.UIData;
								UIUtils.Instantiate (haveLimitUIData, requestNewRoundHaveLimitPrefab, newRoundLimitUIContainer);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + newRoundLimitUI.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				// calculateScoreUI
				if (data is CalculateScore.UIData) {
					CalculateScore.UIData calculateScoreUIData = data as CalculateScore.UIData;
					// UI
					{
						switch (calculateScoreUIData.getType ()) {
						case CalculateScore.Type.Sum:
							{
								CalculateScoreSumUI.UIData calculateScoreSumUIData = calculateScoreUIData as CalculateScoreSumUI.UIData;
								UIUtils.Instantiate (calculateScoreSumUIData, calculateScoreSumPrefab, calculateScoreUIContainer);
							}
							break;
						case CalculateScore.Type.WinLoseDraw:
							{
								CalculateScoreWinLoseDrawUI.UIData calculateScoreWinLoseDrawUIData = calculateScoreUIData as CalculateScoreWinLoseDrawUI.UIData;
								UIUtils.Instantiate (calculateScoreWinLoseDrawUIData, calculateScoreWinLoseDrawPrefab, calculateScoreUIContainer);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + calculateScoreUIData.getType () + "; " + this);
							break;
						}
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
					uiData.editSingleContestFactory.allRemoveCallBack (this);
					uiData.playerPerTeam.allRemoveCallBack (this);
					// roundFactory
					{
						uiData.roundFactoryType.allRemoveCallBack (this);
						uiData.roundFactoryUI.allRemoveCallBack (this);
					}
					// requestNewRoundLimit
					{
						uiData.newRoundLimitType.allRemoveCallBack (this);
						uiData.newRoundLimitUI.allRemoveCallBack (this);
					}
					// calculateScore
					{
						uiData.calculateScoreType.allRemoveCallBack (this);
						uiData.calculateScoreUI.allRemoveCallBack (this);
					}
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
				// editSingleContestFactory
				{
					if (data is EditData<SingleContestFactory>) {
						EditData<SingleContestFactory> editSingleContestFactory = data as EditData<SingleContestFactory>;
						// Child
						{
							editSingleContestFactory.show.allRemoveCallBack (this);
							editSingleContestFactory.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is SingleContestFactory) {
							SingleContestFactory singleContestFactory = data as SingleContestFactory;
							// Parent
							{
								DataUtils.removeParentCallBack (singleContestFactory, this, ref this.server);
							}
							return;
						}
						// Parent
						{
							if (data is Server) {
								return;
							}
						}
					}
				}
				// playerPerTeam
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeIntUI));
					}
					return;
				}
				// roundFactoryType, newRoundLimitType, calculateScoreType
				if (data is RequestChangeEnumUI.UIData) {
					RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeEnumUI));
					}
					return;
				}
				// roundFactoryUI
				if (data is UIData.RoundFactoryUI) {
					UIData.RoundFactoryUI roundFactoryUI = data as UIData.RoundFactoryUI;
					{
						switch (roundFactoryUI.getType ()) {
						case RoundFactory.Type.Normal:
							{
								NormalRoundFactoryUI.UIData normalRoundFactoryUIData = roundFactoryUI as NormalRoundFactoryUI.UIData;
								normalRoundFactoryUIData.removeCallBackAndDestroy (typeof(NormalRoundFactoryUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + roundFactoryUI.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				// newRoundLimitUI
				if (data is UIData.NewRoundLimitUI) {
					UIData.NewRoundLimitUI newRoundLimitUI = data as UIData.NewRoundLimitUI;
					// UI
					{
						switch (newRoundLimitUI.getType ()) {
						case RequestNewRound.Limit.Type.NoLimit:
							{
								RequestNewRoundNoLimitUI.UIData noLimitUIData = newRoundLimitUI as RequestNewRoundNoLimitUI.UIData;
								noLimitUIData.removeCallBackAndDestroy (typeof(RequestNewRoundNoLimitUI));
							}
							break;
						case RequestNewRound.Limit.Type.HaveLimit:
							{
								RequestNewRoundHaveLimitUI.UIData haveLimitUIData = newRoundLimitUI as RequestNewRoundHaveLimitUI.UIData;
								haveLimitUIData.removeCallBackAndDestroy (typeof(RequestNewRoundHaveLimitUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + newRoundLimitUI.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				// calculateScoreUI
				if (data is CalculateScore.UIData) {
					CalculateScore.UIData calculateScoreUIData = data as CalculateScore.UIData;
					// UI
					{
						switch (calculateScoreUIData.getType ()) {
						case CalculateScore.Type.Sum:
							{
								CalculateScoreSumUI.UIData calculateScoreSumUIData = calculateScoreUIData as CalculateScoreSumUI.UIData;
								calculateScoreSumUIData.removeCallBackAndDestroy (typeof(CalculateScoreSumUI));
							}
							break;
						case CalculateScore.Type.WinLoseDraw:
							{
								CalculateScoreWinLoseDrawUI.UIData calculateScoreWinLoseDrawUIData = calculateScoreUIData as CalculateScoreWinLoseDrawUI.UIData;
								calculateScoreWinLoseDrawUIData.removeCallBackAndDestroy (typeof(CalculateScoreWinLoseDrawUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + calculateScoreUIData.getType () + "; " + this);
							break;
						}
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
				case UIData.Property.editSingleContestFactory:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.playerPerTeam:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.roundFactoryType:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.roundFactoryUI:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.newRoundLimitType:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.newRoundLimitUI:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.calculateScoreType:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.calculateScoreUI:
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
				// editSingleContestFactory
				{
					if (wrapProperty.p is EditData<SingleContestFactory>) {
						switch ((EditData<SingleContestFactory>.Property)wrapProperty.n) {
						case EditData<SingleContestFactory>.Property.origin:
							dirty = true;
							break;
						case EditData<SingleContestFactory>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<SingleContestFactory>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<SingleContestFactory>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<SingleContestFactory>.Property.canEdit:
							dirty = true;
							break;
						case EditData<SingleContestFactory>.Property.editType:
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					{
						if (wrapProperty.p is SingleContestFactory) {
							switch ((SingleContestFactory.Property)wrapProperty.n) {
							case SingleContestFactory.Property.playerPerTeam:
								dirty = true;
								break;
							case SingleContestFactory.Property.roundFactory:
								dirty = true;
								break;
							case SingleContestFactory.Property.newRoundLimit:
								dirty = true;
								break;
							case SingleContestFactory.Property.calculateScore:
								dirty = true;
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Parent
						{
							if (wrapProperty.p is Server) {
								Server.State.OnUpdateSyncStateChange (wrapProperty, this);
								return;
							}
						}
					}
				}
				// playerPerTeam
				if (wrapProperty.p is RequestChangeIntUI.UIData) {
					return;
				}
				// roundFactoryType, newRoundLimit, calculateScoreType
				if (wrapProperty.p is RequestChangeEnumUI.UIData) {
					return;
				}
				// roundFactoryUI
				if (wrapProperty.p is UIData.RoundFactoryUI) {
					return;
				}
				// newRoundLimitUI
				if (wrapProperty.p is UIData.NewRoundLimitUI) {
					return;
				}
				// calculateScoreUI
				if (wrapProperty.p is CalculateScore.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}