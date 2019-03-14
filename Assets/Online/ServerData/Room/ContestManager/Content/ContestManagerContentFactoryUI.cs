using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match.RoundRobin;
using GameManager.Match.Elimination;

namespace GameManager.Match
{
	public class ContestManagerContentFactoryUI : UIHaveTransformDataBehavior<ContestManagerContentFactoryUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<EditData<ContestManagerStateLobby>> editContestManagerStateLobby;

			#region randomTeamIndex

			public VP<RequestChangeBoolUI.UIData> randomTeamIndex;

			public void makeRequestChangeRandomTeamIndex (RequestChangeUpdate<bool>.UpdateData update, bool newRandomTeamIndex)
			{
				// Find
				ContestManagerStateLobby contestManagerStateLobby = null;
				{
					EditData<ContestManagerStateLobby> editContestManagerStateLobby = this.editContestManagerStateLobby.v;
					if (editContestManagerStateLobby != null) {
						contestManagerStateLobby = editContestManagerStateLobby.show.v.data;
					} else {
						Debug.LogError ("editContestManagerStateLobby null: " + this);
					}
				}
				// Process
				if (contestManagerStateLobby != null) {
					contestManagerStateLobby.requestChangeRandomTeamIndex (Server.getProfileUserId (contestManagerStateLobby), newRandomTeamIndex);
				} else {
					Debug.LogError ("contestManagerStateLobby null: " + this);
				}
			}

			#endregion

			#region contentType

			public VP<RequestChangeEnumUI.UIData> contentType;

			public void makeRequestChangeContentType (RequestChangeUpdate<int>.UpdateData update, int newContentType)
			{
				// Find
				ContestManagerStateLobby contestManagerStateLobby = null;
				{
					EditData<ContestManagerStateLobby> editContestManagerStateLobby = this.editContestManagerStateLobby.v;
					if (editContestManagerStateLobby != null) {
						contestManagerStateLobby = editContestManagerStateLobby.show.v.data;
					} else {
						Debug.LogError ("editContestManagerStateLobby null: " + this);
					}
				}
				// Process
				if (contestManagerStateLobby != null) {
					contestManagerStateLobby.requestChangeContentFactoryType (Server.getProfileUserId (contestManagerStateLobby), newContentType);
				} else {
					Debug.LogError ("contestManagerStateLobby null: " + this);
				}
			}

			#endregion

			#region Sub

			public abstract class Sub : Data
			{

				public abstract ContestManagerContent.Type getType ();

				public abstract bool processEvent(Event e);

			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				editContestManagerStateLobby,
				randomTeamIndex,
				contentType,
				sub
			}

			public UIData() : base()
			{
				this.editContestManagerStateLobby = new VP<EditData<ContestManagerStateLobby>>(this, (byte)Property.editContestManagerStateLobby, new EditData<ContestManagerStateLobby>());
				// randomTeamIndex
				{
					this.randomTeamIndex = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.randomTeamIndex, new RequestChangeBoolUI.UIData());
					this.randomTeamIndex.v.updateData.v.request.v = makeRequestChangeRandomTeamIndex;
				}
				// contentType
				{
					this.contentType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.contentType, new RequestChangeEnumUI.UIData());
					// event
					this.contentType.v.updateData.v.request.v = makeRequestChangeContentType;
					{
						foreach (ContestManagerContent.Type type in System.Enum.GetValues(typeof(ContestManagerContent.Type))) {
							this.contentType.v.options.add(type.ToString());
						}
					}
				}
				this.sub = new VP<Sub>(this, (byte)Property.sub, null);
			}

			#endregion

			public bool processEvent(Event e)
			{
				Debug.LogError ("processEvent: " + e + "; " + this);
				bool isProcess = false;
				{
					// sub
					if (!isProcess) {
						Sub sub = this.sub.v;
						if (sub != null) {
							isProcess = sub.processEvent (e);
						} else {
							Debug.LogError ("sub null: " + this);
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

		public Text lbRandomTeamIndex;
		public static readonly TxtLanguage txtRandomTeamIndex = new TxtLanguage();

		public Text lbContentType;
		public static readonly TxtLanguage txtContentType = new TxtLanguage ();

		static ContestManagerContentFactoryUI()
		{
            // txt
            {
                txtTitle.add(Language.Type.vi, "Thiết Lập Giải Dấu");
                txtRandomTeamIndex.add(Language.Type.vi, "Ngẫu nhiên chỉ số team");
                txtContentType.add(Language.Type.vi, "Loại giải đấu");
            }
            // rect
            {
                randomTeamIndexRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                contentFactoryTypeRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
            }
        }

		#endregion

		private bool needReset = true;

        public Image bgSub;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<ContestManagerStateLobby> editContestManagerStateLobby = this.data.editContestManagerStateLobby.v;
					if (editContestManagerStateLobby != null) {
						editContestManagerStateLobby.update ();
						// get show
						ContestManagerStateLobby show = editContestManagerStateLobby.show.v.data;
						ContestManagerStateLobby compare = editContestManagerStateLobby.compare.v.data;
						if (show != null) {
							// different
							if (lbTitle != null) {
								bool isDifferent = false;
								{
									if (editContestManagerStateLobby.compareOtherType.v.data != null) {
										if (editContestManagerStateLobby.compareOtherType.v.data.GetType () != show.GetType ()) {
											isDifferent = true;
										}
									}
								}
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
							} else {
								Debug.LogError ("lbTitle null: " + this);
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
									// randomTeamIndex
									{
										RequestChangeBoolUI.UIData randomTeamIndex = this.data.randomTeamIndex.v;
										if (randomTeamIndex != null) {
											// update
											RequestChangeUpdate<bool>.UpdateData updateData = randomTeamIndex.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.randomTeamIndex.v;
												updateData.canRequestChange.v = editContestManagerStateLobby.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													randomTeamIndex.showDifferent.v = true;
													randomTeamIndex.compare.v = compare.randomTeamIndex.v;
												} else {
													randomTeamIndex.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("randomTeamIndex null: " + this);
										}
									}
									// contentType
									{
										RequestChangeEnumUI.UIData contentType = this.data.contentType.v;
										if (contentType != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = contentType.updateData.v;
											if (updateData != null) {
												updateData.origin.v = (int)show.getContentFactoryType();
												updateData.canRequestChange.v = editContestManagerStateLobby.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													contentType.showDifferent.v = true;
													contentType.compare.v = (int)compare.getContentFactoryType ();
												} else {
													contentType.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("contentType null: " + this);
										}
									}
									// sub
									{
										ContestManagerContentFactory contestManagerContentFactory = show.contentFactory.v;
										if (contestManagerContentFactory != null) {
											// find origin 
											ContestManagerContentFactory originContestManagerContentFactory = null;
											{
												ContestManagerStateLobby originContestManagerStateLobby = editContestManagerStateLobby.origin.v.data;
												if (originContestManagerStateLobby != null) {
													originContestManagerContentFactory = originContestManagerStateLobby.contentFactory.v;
												} else {
													Debug.LogError ("origin null: " + this);
												}
											}
											// find compare
											ContestManagerContentFactory compareContestManagerContentFactory = null;
											{
												if (compare != null) {
													compareContestManagerContentFactory = compare.contentFactory.v;
												} else {
													// Debug.LogError ("compare null: " + this);
												}
											}
											switch (contestManagerContentFactory.getType ()) {
											case ContestManagerContent.Type.Single:
												{
													SingleContestFactory singleContestFactory = contestManagerContentFactory as SingleContestFactory;
													// UIData
													SingleContestFactoryUI.UIData singleContestFactoryUIData = this.data.sub.newOrOld<SingleContestFactoryUI.UIData> ();
													{
														EditData<SingleContestFactory> editSingleContestContentFactory = singleContestFactoryUIData.editSingleContestFactory.v;
														if (editSingleContestContentFactory != null) {
															// origin
															editSingleContestContentFactory.origin.v = new ReferenceData<SingleContestFactory> ((SingleContestFactory)originContestManagerContentFactory);
															// show
															editSingleContestContentFactory.show.v = new ReferenceData<SingleContestFactory> (singleContestFactory);
															// compare
															editSingleContestContentFactory.compare.v = new ReferenceData<SingleContestFactory> ((SingleContestFactory)compareContestManagerContentFactory);
															// compareOtherType
															editSingleContestContentFactory.compareOtherType.v = new ReferenceData<Data> (compareContestManagerContentFactory);
															// canEdit
															editSingleContestContentFactory.canEdit.v = editContestManagerStateLobby.canEdit.v;
															// editType
															editSingleContestContentFactory.editType.v = editContestManagerStateLobby.editType.v;
														} else {
															Debug.LogError ("editSingleContestContentFactory null: " + this);
														}
													}
													this.data.sub.v = singleContestFactoryUIData;
												}
												break;
											case ContestManagerContent.Type.RoundRobin:
												{
													RoundRobinFactory roundRobinFactory = contestManagerContentFactory as RoundRobinFactory;
													// UIData
													RoundRobinFactoryUI.UIData roundRobinFactoryUIData = this.data.sub.newOrOld<RoundRobinFactoryUI.UIData> ();
													{
														EditData<RoundRobinFactory> editRoundRobinFactory = roundRobinFactoryUIData.editRoundRobinFactory.v;
														if (editRoundRobinFactory != null) {
															// origin
															editRoundRobinFactory.origin.v = new ReferenceData<RoundRobinFactory> ((RoundRobinFactory)originContestManagerContentFactory);
															// show
															editRoundRobinFactory.show.v = new ReferenceData<RoundRobinFactory> (roundRobinFactory);
															// compare
															editRoundRobinFactory.compare.v = new ReferenceData<RoundRobinFactory> ((RoundRobinFactory)compareContestManagerContentFactory);
															// compareOtherType
															editRoundRobinFactory.compareOtherType.v = new ReferenceData<Data> (compareContestManagerContentFactory);
															// canEdit
															editRoundRobinFactory.canEdit.v = editContestManagerStateLobby.canEdit.v;
															// editType
															editRoundRobinFactory.editType.v = editContestManagerStateLobby.editType.v;
														} else {
															Debug.LogError ("editRoundRobinFactory null: " + this);
														}
													}
													this.data.sub.v = roundRobinFactoryUIData;
												}
												break;
											case ContestManagerContent.Type.Elimination:
												{
													EliminationFactory eliminationFactory = contestManagerContentFactory as EliminationFactory;
													// UIData
													EliminationFactoryUI.UIData eliminationFactoryUIData = this.data.sub.newOrOld<EliminationFactoryUI.UIData> ();
													{
														EditData<EliminationFactory> editEliminationFactory = eliminationFactoryUIData.editEliminationFactory.v;
														if (editEliminationFactory != null) {
															// origin
															editEliminationFactory.origin.v = new ReferenceData<EliminationFactory> ((EliminationFactory)originContestManagerContentFactory);
															// show
															editEliminationFactory.show.v = new ReferenceData<EliminationFactory> (eliminationFactory);
															// compare
															editEliminationFactory.compare.v = new ReferenceData<EliminationFactory> ((EliminationFactory)compareContestManagerContentFactory);
															// compareOtherType
															editEliminationFactory.compareOtherType.v = new ReferenceData<Data> (compareContestManagerContentFactory);
															// canEdit
															editEliminationFactory.canEdit.v = editContestManagerStateLobby.canEdit.v;
															// editType
															editEliminationFactory.editType.v = editContestManagerStateLobby.editType.v;
														} else {
															Debug.LogError ("editEliminationFactory null: " + this);
														}
													}
													this.data.sub.v = eliminationFactoryUIData;
												}
												break;
											default:
												Debug.LogError ("unknown type: " + contestManagerContentFactory.getType () + "; " + this);
												break;
											}
										} else {
											Debug.LogError ("show null: " + this);
										}
									}
								}
								// reset
								if (needReset) {
									needReset = false;
									// randomTeamIndex
									{
										RequestChangeBoolUI.UIData randomTeamIndex = this.data.randomTeamIndex.v;
										if (randomTeamIndex != null) {
											// update
											RequestChangeUpdate<bool>.UpdateData updateData = randomTeamIndex.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.randomTeamIndex.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("randomTeamIndex null: " + this);
										}
									}
									// contentType
									{
										RequestChangeEnumUI.UIData contentType = this.data.contentType.v;
										if (contentType != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = contentType.updateData.v;
											if (updateData != null) {
												updateData.current.v = (int)show.getContentFactoryType();
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("useRule null: " + this);
										}
									}
								}
							}
						} else {
							Debug.LogError ("show null: " + this);
						}
					} else {
						Debug.LogError ("editContestManagerStateLobby null: " + this);
					}
                    // UISize
                    {
                        float deltaY = UIConstants.HeaderHeight;
                        // randomTeamIndex
                        {
                            deltaY += UIConstants.ItemHeight;
                        }
                        // sub
                        {
                            float bgY = deltaY;
                            float bgHeight = 0;
                            // drSubType
                            {
                                deltaY += UIConstants.ItemHeight;
                                bgHeight += UIConstants.ItemHeight;
                            }
                            // sub
                            {
                                float subHeight = UIRectTransform.SetPosY(this.data.sub.v, deltaY);
                                bgHeight += subHeight;
                                deltaY += subHeight;
                            }
                            // bg
                            if (bgSub != null)
                            {
                                UIRectTransform.SetPosY(bgSub.rectTransform, bgY);
                                UIRectTransform.SetHeight(bgSub.rectTransform, bgHeight);
                            }
                            else
                            {
                                Debug.LogError("bgSub null");
                            }
                        }
                        // set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Tournament Factory");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbRandomTeamIndex != null) {
							lbRandomTeamIndex.text = txtRandomTeamIndex.get ("Random Team Index");
						} else {
							Debug.LogError ("lbRandomTeamIndex null: " + this);
						}
						if (lbContentType != null) {
							lbContentType.text = txtContentType.get ("Tournament Type");
						} else {
							Debug.LogError ("lbContentType null: " + this);
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

		public RequestChangeBoolUI requestBoolPrefab;
		public RequestChangeEnumUI requestEnumPrefab;

        private static readonly UIRectTransform randomTeamIndexRect = new UIRectTransform(UIConstants.RequestBoolRect);
		private static readonly UIRectTransform contentFactoryTypeRect = new UIRectTransform(UIConstants.RequestEnumRect);

		public SingleContestFactoryUI singleContestFactoryPrefab;
		public RoundRobinFactoryUI roundRobinFactoryPrefab;
		public EliminationFactoryUI eliminationFactoryPrefab;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.editContestManagerStateLobby.allAddCallBack (this);
					uiData.randomTeamIndex.allAddCallBack (this);
					uiData.contentType.allAddCallBack (this);
					uiData.sub.allAddCallBack (this);
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
				// editContestManagerStateLobby
				{
					if (data is EditData<ContestManagerStateLobby>) {
						EditData<ContestManagerStateLobby> editContestManagerStateLobby = data as EditData<ContestManagerStateLobby>;
						// Child
						{
							editContestManagerStateLobby.show.allAddCallBack (this);
							editContestManagerStateLobby.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is ContestManagerStateLobby) {
							ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
							// Parent
							{
								DataUtils.addParentCallBack (contestManagerStateLobby, this, ref this.server);
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
				// randomTeamIndex
				if (data is RequestChangeBoolUI.UIData) {
					RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.randomTeamIndex:
								UIUtils.Instantiate (requestChange, requestBoolPrefab, this.transform, randomTeamIndexRect);
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
				// contentType
				if (data is RequestChangeEnumUI.UIData) {
					RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.contentType:
								UIUtils.Instantiate (requestChange, requestEnumPrefab, this.transform, contentFactoryTypeRect);
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
                // sub
                {
                    if (data is UIData.Sub)
                    {
                        UIData.Sub sub = data as UIData.Sub;
                        // UI
                        {
                            switch (sub.getType())
                            {
                                case ContestManagerContent.Type.Single:
                                    {
                                        SingleContestFactoryUI.UIData singleContestFactoryUIData = sub as SingleContestFactoryUI.UIData;
                                        UIUtils.Instantiate(singleContestFactoryUIData, singleContestFactoryPrefab, this.transform);
                                    }
                                    break;
                                case ContestManagerContent.Type.RoundRobin:
                                    {
                                        RoundRobinFactoryUI.UIData roundRobinFactoryUIData = sub as RoundRobinFactoryUI.UIData;
                                        UIUtils.Instantiate(roundRobinFactoryUIData, roundRobinFactoryPrefab, this.transform);
                                    }
                                    break;
                                case ContestManagerContent.Type.Elimination:
                                    {
                                        EliminationFactoryUI.UIData eliminationFactoryUIData = sub as EliminationFactoryUI.UIData;
                                        UIUtils.Instantiate(eliminationFactoryUIData, eliminationFactoryPrefab, this.transform);
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                    break;
                            }
                        }
                        // Child
                        {
                            TransformData.AddCallBack(sub, this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if(data is TransformData)
                    {
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
					uiData.editContestManagerStateLobby.allRemoveCallBack (this);
					uiData.randomTeamIndex.allRemoveCallBack (this);
					uiData.contentType.allRemoveCallBack (this);
					uiData.sub.allRemoveCallBack (this);
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
				// editContestManagerStateLobby
				{
					if (data is EditData<ContestManagerStateLobby>) {
						EditData<ContestManagerStateLobby> editContestManagerStateLobby = data as EditData<ContestManagerStateLobby>;
						// Child
						{
							editContestManagerStateLobby.show.allRemoveCallBack (this);
							editContestManagerStateLobby.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is ContestManagerStateLobby) {
							ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
							// Parent
							{
								DataUtils.removeParentCallBack (contestManagerStateLobby, this, ref this.server);
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
				// randomTeamIndex
				if (data is RequestChangeBoolUI.UIData) {
					RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeBoolUI));
					}
					return;
				}
				// contentType
				if (data is RequestChangeEnumUI.UIData) {
					RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeEnumUI));
					}
					return;
				}
                // sub
                {
                    if (data is UIData.Sub)
                    {
                        UIData.Sub sub = data as UIData.Sub;
                        // Child
                        {
                            TransformData.RemoveCallBack(sub, this);
                        }
                        // UI
                        {
                            switch (sub.getType())
                            {
                                case ContestManagerContent.Type.Single:
                                    {
                                        SingleContestFactoryUI.UIData singleContestFactoryUIData = sub as SingleContestFactoryUI.UIData;
                                        singleContestFactoryUIData.removeCallBackAndDestroy(typeof(SingleContestFactoryUI));
                                    }
                                    break;
                                case ContestManagerContent.Type.RoundRobin:
                                    {
                                        RoundRobinFactoryUI.UIData roundRobinFactoryUIData = sub as RoundRobinFactoryUI.UIData;
                                        roundRobinFactoryUIData.removeCallBackAndDestroy(typeof(RoundRobinFactoryUI));
                                    }
                                    break;
                                case ContestManagerContent.Type.Elimination:
                                    {
                                        EliminationFactoryUI.UIData eliminationFactoryUIData = sub as EliminationFactoryUI.UIData;
                                        eliminationFactoryUIData.removeCallBackAndDestroy(typeof(EliminationFactoryUI));
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                    break;
                            }
                        }
                        return;
                    }
                    if(data is TransformData)
                    {
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
				case UIData.Property.editContestManagerStateLobby:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.randomTeamIndex:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.contentType:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.sub:
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
				// editContestManagerStateLobby
				{
					if (wrapProperty.p is EditData<ContestManagerStateLobby>) {
						switch ((EditData<ContestManagerStateLobby>.Property)wrapProperty.n) {
						case EditData<ContestManagerStateLobby>.Property.origin:
							dirty = true;
							break;
						case EditData<ContestManagerStateLobby>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<ContestManagerStateLobby>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<ContestManagerStateLobby>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<ContestManagerStateLobby>.Property.canEdit:
							dirty = true;
							break;
						case EditData<ContestManagerStateLobby>.Property.editType:
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
						if (wrapProperty.p is ContestManagerStateLobby) {
							switch ((ContestManagerStateLobby.Property)wrapProperty.n) {
							case ContestManagerStateLobby.Property.state:
								break;
							case ContestManagerStateLobby.Property.teams:
								break;
							case ContestManagerStateLobby.Property.gameType:
								break;
							case ContestManagerStateLobby.Property.randomTeamIndex:
								dirty = true;
								break;
							case ContestManagerStateLobby.Property.contentFactory:
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
				// randomTeamIndex
				if (wrapProperty.p is RequestChangeBoolUI.UIData) {
					return;
				}
				// contentType
				if (wrapProperty.p is RequestChangeEnumUI.UIData) {
					return;
				}
                // sub
                {
                    if (wrapProperty.p is UIData.Sub)
                    {
                        return;
                    }
                    // Child
                    if(wrapProperty.p is TransformData)
                    {
                        switch ((TransformData.Property)wrapProperty.n)
                        {
                            case TransformData.Property.anchoredPosition:
                                break;
                            case TransformData.Property.anchorMin:
                                break;
                            case TransformData.Property.anchorMax:
                                break;
                            case TransformData.Property.pivot:
                                break;
                            case TransformData.Property.offsetMin:
                                break;
                            case TransformData.Property.offsetMax:
                                break;
                            case TransformData.Property.sizeDelta:
                                break;
                            case TransformData.Property.rotation:
                                break;
                            case TransformData.Property.scale:
                                break;
                            case TransformData.Property.size:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}