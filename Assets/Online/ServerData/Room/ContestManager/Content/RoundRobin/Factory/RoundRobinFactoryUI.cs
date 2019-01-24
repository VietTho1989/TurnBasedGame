using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobinFactoryUI : UIBehavior<RoundRobinFactoryUI.UIData>
	{

		#region UIData

		public class UIData : ContestManagerContentFactoryUI.UIData.Sub
		{

			public VP<EditData<RoundRobinFactory>> editRoundRobinFactory;

			#region singleContestFactory

			public VP<SingleContestFactoryUI.UIData> singleContestFactory;

			#endregion

			#region teamCount

			public VP<RequestChangeIntUI.UIData> teamCount;

			public void makeRequestChangeTeamCount (RequestChangeUpdate<int>.UpdateData update, int newTeamCount)
			{
				// Find
				RoundRobinFactory roundRobinFactory = null;
				{
					EditData<RoundRobinFactory> editRoundRobinFactory = this.editRoundRobinFactory.v;
					if (editRoundRobinFactory != null) {
						roundRobinFactory = editRoundRobinFactory.show.v.data;
					} else {
						Debug.LogError ("editRoundRobinFactory null: " + this);
					}
				}
				// Process
				if (roundRobinFactory != null) {
					roundRobinFactory.requestChangeTeamCount (Server.getProfileUserId (roundRobinFactory), newTeamCount);
				} else {
					Debug.LogError ("roundRobinFactory null: " + this);
				}
			}

			#endregion

			#region needReturnRound

			public VP<RequestChangeBoolUI.UIData> needReturnRound;

			public void makeRequestChangeNeedReturnRound (RequestChangeUpdate<bool>.UpdateData update, bool newNeedReturnRound)
			{
				// Find
				RoundRobinFactory roundRobinFactory = null;
				{
					EditData<RoundRobinFactory> editRoundRobinFactory = this.editRoundRobinFactory.v;
					if (editRoundRobinFactory != null) {
						roundRobinFactory = editRoundRobinFactory.show.v.data;
					} else {
						Debug.LogError ("editRoundRobinFactory null: " + this);
					}
				}
				// Process
				if (roundRobinFactory != null) {
					roundRobinFactory.requestChangeNeedReturnRound (Server.getProfileUserId (roundRobinFactory), newNeedReturnRound);
				} else {
					Debug.LogError ("roundRobinFactory null: " + this);
				}
			}

			#endregion

			#region Constructor

			public enum Property
			{
				editRoundRobinFactory,
				singleContestFactory,
				teamCount,
				needReturnRound
			}

			public UIData() : base()
			{
				this.editRoundRobinFactory = new VP<EditData<RoundRobinFactory>>(this, (byte)Property.editRoundRobinFactory, new EditData<RoundRobinFactory>());
				this.singleContestFactory = new VP<SingleContestFactoryUI.UIData>(this, (byte)Property.singleContestFactory, new SingleContestFactoryUI.UIData());
				// teamCount
				{
					this.teamCount = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.teamCount, new RequestChangeIntUI.UIData());
					// have limit
					{
						IntLimit.Have have = new IntLimit.Have();
						{
							have.uid = this.teamCount.v.limit.makeId();
							have.min.v = 3;
							have.max.v = 30;
						}
						this.teamCount.v.limit.v = have;
					}
					// event
					this.teamCount.v.updateData.v.request.v = makeRequestChangeTeamCount;
				}
				// needReturnRound
				{
					this.needReturnRound = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.needReturnRound, new RequestChangeBoolUI.UIData());
					this.needReturnRound.v.updateData.v.request.v = makeRequestChangeNeedReturnRound;
				}
			}

			#endregion

			public override ContestManagerContent.Type getType ()
			{
				return ContestManagerContent.Type.RoundRobin;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// singleContestFactory
					if (!isProcess) {
						SingleContestFactoryUI.UIData singleContestFactoryUIData = this.singleContestFactory.v;
						if (singleContestFactoryUIData != null) {
							isProcess = singleContestFactoryUIData.processEvent (e);
						} else {
							Debug.LogError ("singleContestFactoryUIData null: " + this);
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
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text lbTeamCount;
		public static readonly TxtLanguage txtTeamCount = new TxtLanguage();

		public Text lbNeedReturnRound;
		public static readonly TxtLanguage txtNeedReturnRound = new TxtLanguage();

		static RoundRobinFactoryUI()
		{
			txtTitle.add (Language.Type.vi, "Tạo Giải Đấu Vòng Tròn");
			txtTeamCount.add (Language.Type.vi, "Số đội");
			txtNeedReturnRound.add (Language.Type.vi, "Cần vòng đấu lại");
		}

		#endregion

		private bool needReset = true;
		public GameObject differentIndicator;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<RoundRobinFactory> editRoundRobinFactory = this.data.editRoundRobinFactory.v;
					if (editRoundRobinFactory != null) {
						editRoundRobinFactory.update ();
						// get show
						RoundRobinFactory show = editRoundRobinFactory.show.v.data;
						RoundRobinFactory compare = editRoundRobinFactory.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editRoundRobinFactory.compareOtherType.v.data != null) {
										if (editRoundRobinFactory.compareOtherType.v.data.GetType () != show.GetType ()) {
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
									// singleContestFactory
									{
										SingleContestFactoryUI.UIData singleContestFactory = this.data.singleContestFactory.v;
										if (singleContestFactory != null) {
											EditData<SingleContestFactory> editSingleContestFactory = singleContestFactory.editSingleContestFactory.v;
											if (editSingleContestFactory != null) {
												// origin
												{
													SingleContestFactory originSingleContestFactory = null;
													{
														RoundRobinFactory originRoundRobinFactory = editRoundRobinFactory.origin.v.data;
														if (originRoundRobinFactory != null) {
															originSingleContestFactory = originRoundRobinFactory.singleContestFactory.v;
														} else {
															Debug.LogError ("originSingleContestFactory null: " + this);
														}
													}
													editSingleContestFactory.origin.v = new ReferenceData<SingleContestFactory> (originSingleContestFactory);
												}
												// show
												{
													SingleContestFactory showSingleContestFactory = null;
													{
														RoundRobinFactory showRoundRobinFactory = editRoundRobinFactory.show.v.data;
														if (showRoundRobinFactory != null) {
															showSingleContestFactory = showRoundRobinFactory.singleContestFactory.v;
														} else {
															Debug.LogError ("showRoundRobinFactory null: " + this);
														}
													}
													editSingleContestFactory.show.v = new ReferenceData<SingleContestFactory> (showSingleContestFactory);
												}
												// compare
												{
													SingleContestFactory compareSingleContestFactory = null;
													{
														RoundRobinFactory compareRoundRobinFactory = editRoundRobinFactory.compare.v.data;
														if (compareRoundRobinFactory != null) {
															compareSingleContestFactory = compareRoundRobinFactory.singleContestFactory.v;
														} else {
															Debug.LogError ("compareRoundRobinFactory null: " + this);
														}
													}
													editSingleContestFactory.compare.v = new ReferenceData<SingleContestFactory> (compareSingleContestFactory);
												}
												// compare other type
												{
													SingleContestFactory compareOtherTypeSingleContestFactory = null;
													{
														RoundRobinFactory compareOtherTypeRoundRobinFactory = (RoundRobinFactory)editRoundRobinFactory.compareOtherType.v.data;
														if (compareOtherTypeRoundRobinFactory != null) {
															compareOtherTypeSingleContestFactory = compareOtherTypeRoundRobinFactory.singleContestFactory.v;
														}
													}
													editSingleContestFactory.compareOtherType.v = new ReferenceData<Data> (compareOtherTypeSingleContestFactory);
												}
												// canEdit
												editSingleContestFactory.canEdit.v = editRoundRobinFactory.canEdit.v;
												// editType
												editSingleContestFactory.editType.v = editRoundRobinFactory.editType.v;
											} else {
												Debug.LogError ("editSingleContestFactory null: " + this);
											}
										} else {
											Debug.LogError ("singleContestFactory null: " + this);
										}
									}
									// teamCount
									{
										RequestChangeIntUI.UIData teamCount = this.data.teamCount.v;
										if (teamCount != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = teamCount.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.teamCount.v;
												updateData.canRequestChange.v = editRoundRobinFactory.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													teamCount.showDifferent.v = true;
													teamCount.compare.v = compare.teamCount.v;
												} else {
													teamCount.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("teamCount null: " + this);
										}
									}
									// needReturnRound
									{
										RequestChangeBoolUI.UIData needReturnRound = this.data.needReturnRound.v;
										if (needReturnRound != null) {
											// update
											RequestChangeUpdate<bool>.UpdateData updateData = needReturnRound.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.needReturnRound.v;
												updateData.canRequestChange.v = editRoundRobinFactory.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													needReturnRound.showDifferent.v = true;
													needReturnRound.compare.v = compare.needReturnRound.v;
												} else {
													needReturnRound.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("needReturnRound null: " + this);
										}
									}
								}
								// reset
								if (needReset) {
									needReset = false;
									// teamCount
									{
										RequestChangeIntUI.UIData teamCount = this.data.teamCount.v;
										if (teamCount != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = teamCount.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.teamCount.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("teamCount null: " + this);
										}
									}
									// needReturnRound
									{
										RequestChangeBoolUI.UIData needReturnRound = this.data.needReturnRound.v;
										if (needReturnRound != null) {
											// update
											RequestChangeUpdate<bool>.UpdateData updateData = needReturnRound.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.needReturnRound.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("needReturnRound null: " + this);
										}
									}
								}
							}
						} else {
							Debug.LogError ("show null: " + this);
						}
					} else {
						Debug.LogError ("editRoundRobinFactory null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("RoundRobin Factory");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbTeamCount != null) {
							lbTeamCount.text = txtTeamCount.get ("Team count");
						} else {
							Debug.LogError ("lbTeamCount null: " + this);
						}
						if (lbNeedReturnRound != null) {
							lbNeedReturnRound.text = txtNeedReturnRound.get ("Need return round");
						} else {
							Debug.LogError ("lbNeedReturnRound null: " + this);
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

		public SingleContestFactoryUI singleContestFactoryPrefab;
		public RequestChangeIntUI requestIntPrefab;
		public RequestChangeBoolUI requestBoolPrefab;

		public Transform singleContestFactoryContainer;
		public Transform teamCountContainer;
		public Transform needReturnRoundContainer;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.editRoundRobinFactory.allAddCallBack (this);
					uiData.singleContestFactory.allAddCallBack (this);
					uiData.teamCount.allAddCallBack (this);
					uiData.needReturnRound.allAddCallBack (this);
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
				// editRoundRobinFactory
				{
					if (data is EditData<RoundRobinFactory>) {
						EditData<RoundRobinFactory> editRoundRobinFactory = data as EditData<RoundRobinFactory>;
						// Child
						{
							editRoundRobinFactory.show.allAddCallBack (this);
							editRoundRobinFactory.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is RoundRobinFactory) {
							RoundRobinFactory roundRobinFactory = data as RoundRobinFactory;
							// Parent
							{
								DataUtils.addParentCallBack (roundRobinFactory, this, ref this.server);
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
				// teamCount
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.teamCount:
								UIUtils.Instantiate (requestChange, requestIntPrefab, teamCountContainer);
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
				// needReturnRound
				if (data is RequestChangeBoolUI.UIData) {
					RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.needReturnRound:
								UIUtils.Instantiate (requestChange, requestBoolPrefab, needReturnRoundContainer);
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
				if (data is SingleContestFactoryUI.UIData) {
					SingleContestFactoryUI.UIData singleContestFactoryUIData = data as SingleContestFactoryUI.UIData;
					// UI
					{
						UIUtils.Instantiate (singleContestFactoryUIData, singleContestFactoryPrefab, singleContestFactoryContainer);
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
					uiData.editRoundRobinFactory.allRemoveCallBack (this);
					uiData.singleContestFactory.allRemoveCallBack (this);
					uiData.teamCount.allRemoveCallBack (this);
					uiData.needReturnRound.allRemoveCallBack (this);
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
				// editRoundRobinFactory
				{
					if (data is EditData<RoundRobinFactory>) {
						EditData<RoundRobinFactory> editRoundRobinFactory = data as EditData<RoundRobinFactory>;
						// Child
						{
							editRoundRobinFactory.show.allRemoveCallBack (this);
							editRoundRobinFactory.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is RoundRobinFactory) {
							RoundRobinFactory roundRobinFactory = data as RoundRobinFactory;
							// Parent
							{
								DataUtils.removeParentCallBack (roundRobinFactory, this, ref this.server);
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
				// teamCount
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeIntUI));
					}
					return;
				}
				// needReturnRound
				if (data is RequestChangeBoolUI.UIData) {
					RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeBoolUI));
					}
					return;
				}
				if (data is SingleContestFactoryUI.UIData) {
					SingleContestFactoryUI.UIData singleContestFactoryUIData = data as SingleContestFactoryUI.UIData;
					// UI
					{
						singleContestFactoryUIData.removeCallBackAndDestroy (typeof(SingleContestFactoryUI));
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
				case UIData.Property.editRoundRobinFactory:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.singleContestFactory:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.teamCount:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.needReturnRound:
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
				// editRoundRobinFactory
				{
					if (wrapProperty.p is EditData<RoundRobinFactory>) {
						switch ((EditData<RoundRobinFactory>.Property)wrapProperty.n) {
						case EditData<RoundRobinFactory>.Property.origin:
							dirty = true;
							break;
						case EditData<RoundRobinFactory>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<RoundRobinFactory>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<RoundRobinFactory>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<RoundRobinFactory>.Property.canEdit:
							dirty = true;
							break;
						case EditData<RoundRobinFactory>.Property.editType:
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
						if (wrapProperty.p is RoundRobinFactory) {
							switch ((RoundRobinFactory.Property)wrapProperty.n) {
							case RoundRobinFactory.Property.singleContestFactory:
								dirty = true;
								break;
							case RoundRobinFactory.Property.teamCount:
								dirty = true;
								break;
							case RoundRobinFactory.Property.needReturnRound:
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
				// teamCount
				if (wrapProperty.p is RequestChangeIntUI.UIData) {
					return;
				}
				// needReturnRound
				if (wrapProperty.p is RequestChangeBoolUI.UIData) {
					return;
				}
				if (wrapProperty.p is SingleContestFactoryUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}