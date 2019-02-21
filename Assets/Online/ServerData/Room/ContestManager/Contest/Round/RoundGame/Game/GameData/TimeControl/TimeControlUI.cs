using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TimeControl.Normal;
using TimeControl.HourGlass;

namespace TimeControl
{
	public class TimeControlUI : UIBehavior<TimeControlUI.UIData>, HaveTransformData
	{

		#region UIData

		public class UIData : Data
		{

			public VP<EditData<TimeControl>> editTimeControl;

			#region isEnable

			public VP<RequestChangeBoolUI.UIData> isEnable;

			public void makeRequestChangeIsEnable (RequestChangeUpdate<bool>.UpdateData update, bool newIsEnable)
			{
				// Find
				TimeControl timeControl = null;
				{
					EditData<TimeControl> editTimeControl = this.editTimeControl.v;
					if (editTimeControl != null) {
						timeControl = editTimeControl.show.v.data;
					} else {
						Debug.LogError ("editTimeControl null: " + this);
					}
				}
				// Process
				if (timeControl != null) {
					timeControl.requestChangeIsEnable (Server.getProfileUserId(timeControl), newIsEnable);
				} else {
					Debug.LogError ("timeControl null: " + this);
				}
			}

			#endregion

			#region aiCanTimeOut

			public VP<RequestChangeBoolUI.UIData> aiCanTimeOut;

			public void makeRequestChangeAICanTimeOut (RequestChangeUpdate<bool>.UpdateData update, bool newAICanTimeOut)
			{
				// Find
				TimeControl timeControl = null;
				{
					EditData<TimeControl> editTimeControl = this.editTimeControl.v;
					if (editTimeControl != null) {
						timeControl = editTimeControl.show.v.data;
					} else {
						Debug.LogError ("editTimeControl null: " + this);
					}
				}
				// Process
				if (timeControl != null) {
					timeControl.requestChangeAICanTimeOut (Server.getProfileUserId(timeControl), newAICanTimeOut);
				} else {
					Debug.LogError ("timeControl null: " + this);
				}
			}

			#endregion

			#region use

			public VP<RequestChangeEnumUI.UIData> use;

			public void makeRequestChangeUse (RequestChangeUpdate<int>.UpdateData update, int newUse)
			{
				// Find
				TimeControl timeControl = null;
				{
					EditData<TimeControl> editTimeControl = this.editTimeControl.v;
					if (editTimeControl != null) {
						timeControl = editTimeControl.show.v.data;
					} else {
						Debug.LogError ("editTimeControl null: " + this);
					}
				}
				// Process
				if (timeControl != null) {
					timeControl.requestChangeUse (Server.getProfileUserId(timeControl), newUse);
				} else {
					Debug.LogError ("timeControl null: " + this);
				}
			}

			#endregion

			#region sub

			public VP<RequestChangeEnumUI.UIData> subType;

			public void makeRequestChangeSubType (RequestChangeUpdate<int>.UpdateData update, int newSubType)
			{
				// Find
				TimeControl timeControl = null;
				{
					EditData<TimeControl> editTimeControl = this.editTimeControl.v;
					if (editTimeControl != null) {
						timeControl = editTimeControl.show.v.data;
					} else {
						Debug.LogError ("editTimeControl null: " + this);
					}
				}
				// Process
				if (timeControl != null) {
					timeControl.requestChangeSubType (Server.getProfileUserId(timeControl), newSubType);
				} else {
					Debug.LogError ("timeControl null: " + this);
				}
			}

			public abstract class Sub : Data
			{
				
				public abstract TimeControl.Sub.Type getType ();


				public abstract bool processEvent(Event e);

			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				editTimeControl,
				isEnable,
				aiCanTimeOut,
				use,
				subType,
				sub
			}

			public UIData() : base()
			{
				this.editTimeControl = new VP<EditData<TimeControl>>(this, (byte)Property.editTimeControl, new EditData<TimeControl>());
				// isEnable
				{
					this.isEnable = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.isEnable, new RequestChangeBoolUI.UIData());
					// event
					this.isEnable.v.updateData.v.request.v = makeRequestChangeIsEnable;
				}
				// aiCanTimeOut
				{
					this.aiCanTimeOut = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.aiCanTimeOut, new RequestChangeBoolUI.UIData());
					// event
					this.aiCanTimeOut.v.updateData.v.request.v = makeRequestChangeAICanTimeOut;
				}
				// use
				{
					this.use = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.use, new RequestChangeEnumUI.UIData());
					// event
					this.use.v.updateData.v.request.v = makeRequestChangeUse;
					// options
					foreach (TimeControl.Use use in System.Enum.GetValues(typeof(TimeControl.Use))) {
						this.use.v.options.add(use.ToString());
					}
				}
				// subType
				{
					this.subType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.subType, new RequestChangeEnumUI.UIData());
					// event
					this.subType.v.updateData.v.request.v = makeRequestChangeSubType;
					// options
					foreach (TimeControl.Sub.Type subType in System.Enum.GetValues(typeof(TimeControl.Sub.Type))) {
						this.subType.v.options.add(subType.ToString());
					}
				}
				// sub
				this.sub = new VP<Sub>(this, (byte)Property.sub, null);
			}

			#endregion

			public bool processEvent(Event e)
			{
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

		public Text lbIsEnable;
		public static readonly TxtLanguage txtIsEnable = new TxtLanguage();

		public Text lbAICanTimeOut;
		public static readonly TxtLanguage txtAICanTimeOut = new TxtLanguage ();

		public Text lbUse;
		public static readonly TxtLanguage txtUse = new TxtLanguage();

		public Text lbSubType;
		public static readonly TxtLanguage txtSubType = new TxtLanguage();

		static TimeControlUI()
		{
            // txt
            {
                txtTitle.add(Language.Type.vi, "Điều Khiển Thời Gian");
                txtIsEnable.add(Language.Type.vi, "Kích hoạt");
                txtAICanTimeOut.add(Language.Type.vi, "AI có thể hết giờ");
                txtUse.add(Language.Type.vi, "Dùng");
                txtSubType.add(Language.Type.vi, "Loại");
            }
            // rect
            {
                isEnableRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2);
                aiCanTimeOutRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2);
                useRect.setPosY(UIConstants.HeaderHeight + 2 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2);
                subTypeRect.setPosY(UIConstants.HeaderHeight + 3 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2);
            }
        }

        #endregion

        #region TransformData

        public TransformData transformData = new TransformData();

        private void updateTransformData()
        {
            /*if (transform.hasChanged)
            {
                transform.hasChanged = false;
                this.transformData.update(this.transform);
            }*/
            this.transformData.update(this.transform);
        }

        public TransformData getTransformData()
        {
            return this.transformData;
        }

        #endregion

        private bool needReset = true;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<TimeControl> editTimeControl = this.data.editTimeControl.v;
					if (editTimeControl != null) {
						editTimeControl.update ();
						// get show
						TimeControl show = editTimeControl.show.v.data;
						TimeControl compare = editTimeControl.compare.v.data;
						// show
						if (show != null) {
							// different
							if (lbTitle != null) {
								bool isDifferent = false;
								{
									if (editTimeControl.compareOtherType.v.data != null) {
										if (editTimeControl.compareOtherType.v.data.GetType () != show.GetType ()) {
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
									// isEnable
									{
										RequestChangeBoolUI.UIData isEnable = this.data.isEnable.v;
										if (isEnable != null) {
											// update
											RequestChangeUpdate<bool>.UpdateData updateData = isEnable.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.isEnable.v;
												updateData.canRequestChange.v = editTimeControl.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													isEnable.showDifferent.v = true;
													isEnable.compare.v = compare.isEnable.v;
												} else {
													isEnable.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("isEnable null: " + this);
										}
									}
									// aiCanTimeOut
									{
										RequestChangeBoolUI.UIData aiCanTimeOut = this.data.aiCanTimeOut.v;
										if (aiCanTimeOut != null) {
											// update
											RequestChangeUpdate<bool>.UpdateData updateData = aiCanTimeOut.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.aiCanTimeOut.v;
												updateData.canRequestChange.v = editTimeControl.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													aiCanTimeOut.showDifferent.v = true;
													aiCanTimeOut.compare.v = compare.aiCanTimeOut.v;
												} else {
													aiCanTimeOut.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("aiCanTimeOut null: " + this);
										}
									}
									// use
									{
										RequestChangeEnumUI.UIData use = this.data.use.v;
										if (use != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = use.updateData.v;
											if (updateData != null) {
												updateData.origin.v = (int)show.use.v;
												updateData.canRequestChange.v = editTimeControl.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													use.showDifferent.v = true;
													use.compare.v = (int)compare.use.v;
												} else {
													use.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("use null: " + this);
										}
									}
									// subType
									{
										RequestChangeEnumUI.UIData subType = this.data.subType.v;
										if (subType != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = subType.updateData.v;
											if (updateData != null) {
												updateData.origin.v = (int)show.getSubType ();
												updateData.canRequestChange.v = editTimeControl.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													subType.showDifferent.v = true;
													subType.compare.v = (int)compare.getSubType ();
												} else {
													subType.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("subType null: " + this);
										}
									}
									// sub
									{
										TimeControl.Sub sub = show.sub.v;
										if (sub != null) {
											// find origin 
											TimeControl.Sub originSub = null;
											{
												TimeControl originTimeControl = editTimeControl.origin.v.data;
												if (originTimeControl != null) {
													originSub = originTimeControl.sub.v;
												} else {
													Debug.LogError ("origin null: " + this);
												}
											}
											// find compare
											TimeControl.Sub compareSub = null;
											{
												if (compare != null) {
													compareSub = compare.sub.v;
												} else {
													// Debug.LogError ("compare null: " + this);
												}
											}
											switch (sub.getType ()) {
											case TimeControl.Sub.Type.Normal:
												{
													TimeControlNormal timeControlNormal = sub as TimeControlNormal;
													// UIData
													TimeControlNormalUI.UIData timeControlNormalUIData = this.data.sub.newOrOld<TimeControlNormalUI.UIData> ();
													{
														EditData<TimeControlNormal> editTimeControlNormal = timeControlNormalUIData.editTimeControlNormal.v;
														if (editTimeControlNormal != null) {
															// origin
															editTimeControlNormal.origin.v = new ReferenceData<TimeControlNormal> ((TimeControlNormal)originSub);
															// show
															editTimeControlNormal.show.v = new ReferenceData<TimeControlNormal> (timeControlNormal);
															// compare
															editTimeControlNormal.compare.v = new ReferenceData<TimeControlNormal> ((TimeControlNormal)compareSub);
															// compareOtherType
															editTimeControlNormal.compareOtherType.v = new ReferenceData<Data>(compareSub);
															// canEdit
															editTimeControlNormal.canEdit.v = editTimeControl.canEdit.v;
															// editType
															editTimeControlNormal.editType.v = editTimeControl.editType.v;
														} else {
															Debug.LogError ("editTimeControlNormal null: " + this);
														}
													}
													this.data.sub.v = timeControlNormalUIData;
												}
												break;
											case TimeControl.Sub.Type.HourGlass:
												{
													TimeControlHourGlass timeControlHourGlass = sub as TimeControlHourGlass;
													// UIData
													TimeControlHourGlassUI.UIData timeControlHourGlassUIData = this.data.sub.newOrOld<TimeControlHourGlassUI.UIData> ();
													{
														EditData<TimeControlHourGlass> editTimeControlHourGlass = timeControlHourGlassUIData.editTimeControlHourGlass.v;
														if (editTimeControlHourGlass != null) {
															// origin
															editTimeControlHourGlass.origin.v = new ReferenceData<TimeControlHourGlass> ((TimeControlHourGlass)originSub);
															// show
															editTimeControlHourGlass.show.v = new ReferenceData<TimeControlHourGlass> (timeControlHourGlass);
															// compare
															editTimeControlHourGlass.compare.v = new ReferenceData<TimeControlHourGlass> ((TimeControlHourGlass)compareSub);
															// compareOtherType
															editTimeControlHourGlass.compareOtherType.v = new ReferenceData<Data>(compareSub);
															// canEdit
															editTimeControlHourGlass.canEdit.v = editTimeControl.canEdit.v;
															// editType
															editTimeControlHourGlass.editType.v = editTimeControl.editType.v;
														} else {
															Debug.LogError ("editTimeControlHourGlass null: " + this);
														}
													}
													this.data.sub.v = timeControlHourGlassUIData;
												}
												break;
											default:
												Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
												break;
											}
										} else {
											Debug.LogError ("sub null: " + this);
										}
									}
								}
								// reset?
								if (needReset) {
									needReset = false;
									// isEnable
									{
										RequestChangeBoolUI.UIData isEnable = this.data.isEnable.v;
										if (isEnable != null) {
											// update
											RequestChangeUpdate<bool>.UpdateData updateData = isEnable.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.isEnable.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("isEnable null: " + this);
										}
									}
									// aiCanTimeOut
									{
										RequestChangeBoolUI.UIData aiCanTimeOut = this.data.aiCanTimeOut.v;
										if (aiCanTimeOut != null) {
											// update
											RequestChangeUpdate<bool>.UpdateData updateData = aiCanTimeOut.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.aiCanTimeOut.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("aiCanTimeOut null: " + this);
										}
									}
									// use
									{
										RequestChangeEnumUI.UIData use = this.data.use.v;
										if (use != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = use.updateData.v;
											if (updateData != null) {
												updateData.current.v = (int)show.use.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("use null: " + this);
										}
									}
									// subType
									{
										RequestChangeEnumUI.UIData subType = this.data.subType.v;
										if (subType != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = subType.updateData.v;
											if (updateData != null) {
												updateData.current.v = (int)show.getSubType ();
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("subType null: " + this);
										}
									}
								}
							}
						} else {
							Debug.LogError ("show null: " + this);
						}
					} else {
						Debug.LogError ("editTimeControl null: " + this);
					}
                    // UISize
                    {
                        float subSize = UIRectTransform.GetHeight(this.data.sub.v);
                        UIRectTransform.SetHeight((RectTransform)this.transform, UIConstants.HeaderHeight + 4 * UIConstants.ItemHeight + subSize);
                    }
                    // txt
                    {
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Time Control");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbIsEnable != null) {
							lbIsEnable.text = txtIsEnable.get ("Enable");
						} else {
							Debug.LogError ("lbIsEnable null: " + this);
						}
						if (lbAICanTimeOut != null) {
							lbAICanTimeOut.text = txtAICanTimeOut.get ("AI can timeout");
						} else {
							Debug.LogError ("lbAICanTimeOut null: " + this);
						}
						if (lbUse != null) {
							lbUse.text = txtUse.get ("Use");
						} else {
							Debug.LogError ("lbUse null: " + this);
						}
						if (lbSubType != null) {
							lbSubType.text = txtSubType.get ("Type");
						} else {
							Debug.LogError ("lbSubType null: " + this);
						}
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
            updateTransformData();
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public RequestChangeBoolUI requestBoolPrefab;
		public RequestChangeEnumUI requestEnumPrefeb;

		public TimeControlNormalUI timeControlNormalPrefab;
		public TimeControlHourGlassUI timeControlHourGlassPrefab;

		private static readonly UIRectTransform isEnableRect = new UIRectTransform(UIConstants.RequestBoolRect);
		private static readonly UIRectTransform aiCanTimeOutRect = new UIRectTransform(UIConstants.RequestBoolRect);
		private static readonly UIRectTransform useRect = new UIRectTransform(UIConstants.RequestEnumRect);
		private static readonly UIRectTransform subTypeRect = new UIRectTransform(UIConstants.RequestEnumRect);

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.editTimeControl.allAddCallBack (this);
					uiData.isEnable.allAddCallBack (this);
					uiData.aiCanTimeOut.allAddCallBack (this);
					uiData.use.allAddCallBack (this);
					uiData.subType.allAddCallBack (this);
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
				// editTimeControl
				{
					if (data is EditData<TimeControl>) {
						EditData<TimeControl> editTimeControl = data as EditData<TimeControl>;
						// Child
						{
							editTimeControl.show.allAddCallBack (this);
							editTimeControl.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is TimeControl) {
							TimeControl timeControl = data as TimeControl;
							// Parent
							{
								DataUtils.addParentCallBack (timeControl, this, ref this.server);
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
				if (data is RequestChangeBoolUI.UIData) {
					RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.isEnable:
								UIUtils.Instantiate (requestChange, requestBoolPrefab, this.transform, isEnableRect);
								break;
							case UIData.Property.aiCanTimeOut:
								UIUtils.Instantiate (requestChange, requestBoolPrefab, this.transform, aiCanTimeOutRect);
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
				if (data is RequestChangeEnumUI.UIData) {
					RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.use:
								UIUtils.Instantiate (requestChange, requestEnumPrefeb, this.transform, useRect);
								break;
							case UIData.Property.subType:
								UIUtils.Instantiate (requestChange, requestEnumPrefeb, this.transform, subTypeRect);
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
                                case TimeControl.Sub.Type.Normal:
                                    {
                                        TimeControlNormalUI.UIData timeControlNormal = sub as TimeControlNormalUI.UIData;
                                        TimeControlNormalUI timeControlNormalUI = (TimeControlNormalUI)UIUtils.Instantiate(timeControlNormal, timeControlNormalPrefab, this.transform);
                                        if (timeControlNormalUI != null)
                                        {
                                            UIRectTransform.SetPosY((RectTransform)timeControlNormalUI.transform, UIConstants.HeaderHeight + 4 * UIConstants.ItemHeight);
                                            timeControlNormalUI.transformData.addCallBack(this);
                                        }
                                        else
                                        {
                                            Debug.LogError("timeControlNormalUI null");
                                        }
                                    }
                                    break;
                                case TimeControl.Sub.Type.HourGlass:
                                    {
                                        TimeControlHourGlassUI.UIData timeControlHourGlass = sub as TimeControlHourGlassUI.UIData;
                                        TimeControlHourGlassUI timeControlHourGlassUI = (TimeControlHourGlassUI)UIUtils.Instantiate(timeControlHourGlass, timeControlHourGlassPrefab, this.transform);
                                        if (timeControlHourGlassUI != null)
                                        {
                                            UIRectTransform.SetPosY((RectTransform)timeControlHourGlassUI.transform, UIConstants.HeaderHeight + 4 * UIConstants.ItemHeight);
                                            timeControlHourGlassUI.transformData.addCallBack(this);
                                        }
                                        else
                                        {
                                            Debug.LogError("timeControlNormalUI null");
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                    break;
                            }
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
					uiData.editTimeControl.allRemoveCallBack (this);
					uiData.isEnable.allRemoveCallBack (this);
					uiData.aiCanTimeOut.allRemoveCallBack (this);
					uiData.use.allRemoveCallBack (this);
					uiData.subType.allRemoveCallBack (this);
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
				// editTimeControl
				{
					if (data is EditData<TimeControl>) {
						EditData<TimeControl> editTimeControl = data as EditData<TimeControl>;
						// Child
						{
							editTimeControl.show.allRemoveCallBack (this);
							editTimeControl.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is TimeControl) {
							TimeControl timeControl = data as TimeControl;
							// Parent
							{
								DataUtils.removeParentCallBack (timeControl, this, ref this.server);
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
				if (data is RequestChangeBoolUI.UIData) {
					RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeBoolUI));
					}
					return;
				}
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
                        // UI
                        {
                            switch (sub.getType())
                            {
                                case TimeControl.Sub.Type.Normal:
                                    {
                                        TimeControlNormalUI.UIData timeControlNormal = sub as TimeControlNormalUI.UIData;
                                        // Child
                                        {
                                            TimeControlNormalUI timeControlNormalUI = timeControlNormal.findCallBack<TimeControlNormalUI>();
                                            if (timeControlNormalUI != null)
                                            {
                                                timeControlNormalUI.transformData.removeCallBack(this);
                                            }
                                            else
                                            {
                                                Debug.LogError("timeControlNormalUI null");
                                            }
                                        }
                                        timeControlNormal.removeCallBackAndDestroy(typeof(TimeControlNormalUI));
                                    }
                                    break;
                                case TimeControl.Sub.Type.HourGlass:
                                    {
                                        TimeControlHourGlassUI.UIData timeControlHourGlass = sub as TimeControlHourGlassUI.UIData;
                                        // Child
                                        {
                                            TimeControlHourGlassUI timeControlHourGlassUI = timeControlHourGlass.findCallBack<TimeControlHourGlassUI>();
                                            if (timeControlHourGlassUI != null)
                                            {
                                                timeControlHourGlassUI.transformData.removeCallBack(this);
                                            }
                                            else
                                            {
                                                Debug.LogError("timeControlHourGlassUI null");
                                            }
                                        }
                                        timeControlHourGlass.removeCallBackAndDestroy(typeof(TimeControlHourGlassUI));
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                    break;
                            }
                        }
                        return;
                    }
                    // Child
                    if (data is TransformData)
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
				case UIData.Property.editTimeControl:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.isEnable:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.aiCanTimeOut:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.use:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.subType:
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
				// editTimeControl
				{
					if (wrapProperty.p is EditData<TimeControl>) {
						switch ((EditData<TimeControl>.Property)wrapProperty.n) {
						case EditData<TimeControl>.Property.origin:
							dirty = true;
							break;
						case EditData<TimeControl>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<TimeControl>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<TimeControl>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<TimeControl>.Property.canEdit:
							dirty = true;
							break;
						case EditData<TimeControl>.Property.editType:
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
						if (wrapProperty.p is TimeControl) {
							switch ((TimeControl.Property)wrapProperty.n) {
							case TimeControl.Property.isEnable:
								dirty = true;
								break;
							case TimeControl.Property.aiCanTimeOut:
								dirty = true;
								break;
							case TimeControl.Property.timeOutPlayers:
								break;
							case TimeControl.Property.sub:
								dirty = true;
								break;
							case TimeControl.Property.use:
								dirty = true;
								break;
							case TimeControl.Property.timeReport:
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
				if (wrapProperty.p is RequestChangeBoolUI.UIData) {
					return;
				}
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
                            case TransformData.Property.position:
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