using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace UndoRedo
{
	public class AskUI : UIBehavior<AskUI.UIData>, HaveTransformData
	{

		#region UIData

		public class UIData : UndoRedoRequestUI.UIData.Sub
		{

			public VP<ReferenceData<Ask>> ask;

			public VP<WhoCanAskAdapter.UIData> whoCanAskAdapter;

			#region state

			public enum State
			{
				None,
				RequestAccept,
				WaitAccept,
				RequestCancel,
				WaitCancel
			}

			public VP<State> state;

			#endregion

			#region Constructor

			public enum Property
			{
				ask,
				whoCanAskAdapter,
				state
			}

			public UIData() : base()
			{
				this.ask = new VP<ReferenceData<Ask>>(this, (byte)Property.ask, new ReferenceData<Ask>(null));
                this.whoCanAskAdapter = new VP<WhoCanAskAdapter.UIData>(this, (byte)Property.whoCanAskAdapter, new WhoCanAskAdapter.UIData());
				this.state = new VP<State>(this, (byte)Property.state, State.None);
			}

			#endregion

			public override UndoRedoRequest.State.Type getType ()
			{
				return UndoRedoRequest.State.Type.Ask;
			}

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {

                }
                return isProcess;
            }

            public void reset()
			{
				this.state.v = State.None;
			}

		}

        #endregion

        #region txt

        public static readonly TxtLanguage txtLastTurn = new TxtLanguage();
        public static readonly TxtLanguage txtLastYourTurn = new TxtLanguage();

        public static readonly TxtLanguage txtAlreadyAccept = new TxtLanguage();
        public static readonly TxtLanguage txtAccept = new TxtLanguage();
        public static readonly TxtLanguage txtAlreadyCancel = new TxtLanguage();
        public static readonly TxtLanguage txtCancel = new TxtLanguage();

        public static readonly TxtLanguage txtCannotAccept = new TxtLanguage();
        public static readonly TxtLanguage txtCannotCancel = new TxtLanguage();

        public static readonly TxtLanguage txtCancelAccept = new TxtLanguage();
        public static readonly TxtLanguage txtCancelCancel = new TxtLanguage();

        public static readonly TxtLanguage txtAccepting = new TxtLanguage();
        public static readonly TxtLanguage txtCancelling = new TxtLanguage();

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        static AskUI()
        {
            // txt
            {
                txtLastTurn.add(Language.Type.vi, "Lượt trước");
                txtLastYourTurn.add(Language.Type.vi, "Lượt trước của bạn");

                txtAlreadyAccept.add(Language.Type.vi, "Đã chấp nhận");
                txtAccept.add(Language.Type.vi, "Chấp Nhận");
                txtAlreadyCancel.add(Language.Type.vi, "Đã huỷ bỏ");
                txtCancel.add(Language.Type.vi, "Huỷ Bỏ");

                txtCannotAccept.add(Language.Type.vi, "Không thể chấp nhận");
                txtCannotCancel.add(Language.Type.vi, "Không thể huỷ bỏ");

                txtCancelAccept.add(Language.Type.vi, "Huỷ chấp nhận?");
                txtCancelCancel.add(Language.Type.vi, "Huỷ huỷ bỏ");

                txtAccepting.add(Language.Type.vi, "Đang chấp nhận...");
                txtCancelling.add(Language.Type.vi, "Đang huỷ bỏ...");

                txtTitle.add(Language.Type.vi, "Trả Lời Yêu Cầu Undo/Redo");
            }
            // rect
            {
                // whoCanAskAdapterRect
                {
                    // anchoredPosition: (0.0, -60.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (0.0, -120.0); offsetMax: (0.0, -60.0); sizeDelta: (0.0, 60.0);
                    whoCanAskAdapterRect.anchoredPosition = new Vector3(0.0f, -60.0f, 0.0f);
                    whoCanAskAdapterRect.anchorMin = new Vector2(0.0f, 1.0f);
                    whoCanAskAdapterRect.anchorMax = new Vector2(1.0f, 1.0f);
                    whoCanAskAdapterRect.offsetMin = new Vector2(0.0f, -120.0f);
                    whoCanAskAdapterRect.offsetMax = new Vector2(0.0f, -60.0f);
                    whoCanAskAdapterRect.sizeDelta = new Vector2(0.0f, 60.0f);
                }
            }
        }

        #endregion

        #region TransformData

        public TransformData transformData = new TransformData();

        private void updateTransformData()
        {
            this.transformData.update(this.transform);
        }

        public TransformData getTransformData()
        {
            return this.transformData;
        }

        #endregion

        #region Refresh

		public Button btnAccept;
		public Text tvAccept;

		public Button btnCancel;
		public Text tvCancel;

        public Text tvCannotAnswer;

		public Text tvRequestInform;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Ask ask = this.data.ask.v.data;
					if (ask != null) {
						// request Inform
						{
							if (tvRequestInform != null) {
								RequestInform requestInform = ask.requestInform.v;
								if (requestInform != null) {
									switch (requestInform.getType ()) {
									case RequestInform.Type.LastTurn:
										{
											RequestLastTurn requestLastTurn = requestInform as RequestLastTurn;
											tvRequestInform.text = txtLastTurn.get ("Last Turn") + " " + requestLastTurn.operation.v;
										}
										break;
									case RequestInform.Type.LastYourTurn:
										{
											RequestLastYourTurn requestLastYourTurn = requestInform as RequestLastYourTurn;
											tvRequestInform.text = txtLastYourTurn.get ("Last Your Turn") + ": " + requestLastYourTurn.operation.v;
										}
										break;
									default:
										Debug.LogError ("unknown type: " + requestInform.getType () + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("requestInform null: " + this);
								}
							} else {
								Debug.LogError ("tvRequestInform null: " + this);
							}
						}
                        // whoCanAskAdapter
                        {
                            WhoCanAskAdapter.UIData whoCanAskAdapter = this.data.whoCanAskAdapter.v;
                            if (whoCanAskAdapter != null)
                            {
                                whoCanAskAdapter.ask.v = new ReferenceData<Ask>(ask);
                            }
                            else
                            {
                                Debug.LogError("whoCanAskAdapter null");
                            }
                        }
						// btnAccept, btnCancel
						{
							if (UndoRedoRequest.getWhoCanAnswer (ask).Contains (Server.getProfileUserId (ask))) {
                                // answerContainer
                                {
                                    if(btnAccept!=null && btnCancel != null && tvCannotAnswer!=null)
                                    {
                                        btnAccept.gameObject.SetActive(true);
                                        btnCancel.gameObject.SetActive(true);
                                        tvCannotAnswer.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("btnAccept, btnCancel, tvCannotAnswer null");
                                    }
                                }
								// Task
								{
									switch (this.data.state.v) {
									case UIData.State.None:
										{
											destroyRoutine (wait);
										}
										break;
									case UIData.State.RequestAccept:
										{
											destroyRoutine (wait);
											// request
											if (Server.IsServerOnline (ask)) {
												ask.requestAnswer (Server.getProfileUserId (ask), Ask.Answer.Accept);
												this.data.state.v = UIData.State.WaitAccept;
											} else {
												Debug.LogError ("server not online: " + this);
											}
										}
										break;
									case UIData.State.WaitAccept:
										{
											if (Server.IsServerOnline (ask)) {
												startRoutine (ref wait, TaskWait ());
											} else {
												this.data.state.v = UIData.State.None;
											}
										}
										break;
									case UIData.State.RequestCancel:
										{
											destroyRoutine (wait);
											// request
											if (Server.IsServerOnline (ask)) {
												ask.requestAnswer (Server.getProfileUserId (ask), Ask.Answer.Cancel);
												this.data.state.v = UIData.State.WaitAccept;
											} else {
												Debug.LogError ("server not online: " + this);
											}
										}
										break;
									case UIData.State.WaitCancel:
										{
											if (Server.IsServerOnline (ask)) {
												startRoutine (ref wait, TaskWait ());
											} else {
												this.data.state.v = UIData.State.None;
											}
										}
										break;
									default:
										Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
										break;
									}
								}
								// UI
								{
									if (btnAccept != null && tvAccept != null && btnCancel != null && tvCancel != null) {
										uint profileId = Server.getProfileUserId (ask);
										switch (this.data.state.v) {
										case UIData.State.None:
											{
												// btnAccept
												{
													if (ask.accepts.vs.Contains (profileId)) {
														btnAccept.interactable = false;
														tvAccept.text = txtAlreadyAccept.get ("Already Accept");
													} else {
														btnAccept.interactable = true;
														tvAccept.text = txtAccept.get("Accept");
													}
												}
												// btnCancel
												{
													if (ask.cancels.vs.Contains (profileId)) {
														btnCancel.interactable = false;
														tvCancel.text = txtAlreadyCancel.get ("Already Cancel");
													} else {
														btnCancel.interactable = true;
														tvCancel.text = txtCancel.get ("Cancel");
													}
												}
											}
											break;
										case UIData.State.RequestAccept:
											{
												// btnAccept
												{
													btnAccept.interactable = true;
													tvAccept.text = txtCancelAccept.get ("Cancel request accept?");
												}
												// btnCancel
												{
													btnCancel.interactable = false;
													tvCancel.text = txtCannotCancel.get ("Cannot cancel");
												}
											}
											break;
										case UIData.State.WaitAccept:
											{
												// btnAccept
												{
													btnAccept.interactable = false;
													tvAccept.text = txtAccepting.get ("Requesting accept");
												}
												// btnCancel
												{
													btnCancel.interactable = false;
													tvCancel.text = txtCannotCancel.get ("Cannot cancel");
												}
											}
											break;
										case UIData.State.RequestCancel:
											{
												// btnAccept
												{
													btnAccept.interactable = false;
													tvAccept.text = txtCannotAccept.get ("Cannot accept");
												}
												// btnCancel
												{
													btnCancel.interactable = true;
													tvCancel.text = txtCancelCancel.get ("Cancel request cancel?");
												}
											}
											break;
										case UIData.State.WaitCancel:
											{
												// btnAccept
												{
													btnAccept.interactable = false;
													tvAccept.text = txtCannotAccept.get("Cannot accept");
												}
												// btnCancel
												{
													btnCancel.interactable = false;
													tvCancel.text = txtCancelling.get ("Requesting cancel");
												}
											}
											break;
										default:
											Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
											break;
										}
									} else {
										Debug.LogError ("btnAccept, tvAccept, btnCancel, tvCancel null: " + this);
									}
								}
							} else {
                                // answerContainer
                                {
                                    if (btnAccept != null && btnCancel != null && tvCannotAnswer!=null)
                                    {
                                        btnAccept.gameObject.SetActive(false);
                                        btnCancel.gameObject.SetActive(false);
                                        tvCannotAnswer.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        Debug.LogError("btnAccept, btnCancel null");
                                    }
                                }
								destroyRoutine (wait);
								this.data.state.v = UIData.State.None;
							}
						}
					} else {
						Debug.LogError ("ask null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Answer Undo/Redo Request");
						} else {
							Debug.LogError ("lbTitle null: " + this);
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

		#region Task wait

		private Routine wait;

		public IEnumerator TaskWait()
		{
			if (this.data != null) {
				yield return new Wait (Global.WaitSendTime);
				this.data.state.v = UIData.State.None;
				Debug.LogError ("request error: " + this);
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public override List<Routine> getRoutineList ()
		{
			List<Routine> ret = new List<Routine> ();
			{
				ret.Add (wait);
			}
			return ret;
		}

        #endregion

        #region implement callBacks

        public WhoCanAskAdapter whoCanAskAdapterPrefab;
        private static readonly UIRectTransform whoCanAskAdapterRect = new UIRectTransform();

		private Server server = null;

		private CheckWhoCanAskChange<Ask> checkWhoCanAnswer = new CheckWhoCanAskChange<Ask>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.ask.allAddCallBack (this);
					uiData.whoCanAskAdapter.allAddCallBack (this);
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
				// Ask
				{
					if (data is Ask) {
						Ask ask = data as Ask;
						// CheckChange
						{
							checkWhoCanAnswer.addCallBack (this);
							checkWhoCanAnswer.setData (ask);
						}
						// Parent
						{
							DataUtils.addParentCallBack (ask, this, ref this.server);
						}
						// Child
						{
							ask.requestInform.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// CheckChange
					if (data is CheckWhoCanAskChange<Ask>) {
						dirty = true;
						return;
					}
					// Parent
					if (data is Server) {
						dirty = true;
						return;
					}
					// Child
					if (data is RequestInform) {
						dirty = true;
						return;
					}
				}
				// whoCanAskAdapter
				if (data is WhoCanAskAdapter.UIData) {
					WhoCanAskAdapter.UIData whoCanAskAdapterUIData = data as WhoCanAskAdapter.UIData;
					// UI
					{
						UIUtils.Instantiate (whoCanAskAdapterUIData, whoCanAskAdapterPrefab, this.transform, whoCanAskAdapterRect);
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
					uiData.ask.allRemoveCallBack (this);
					uiData.whoCanAskAdapter.allRemoveCallBack (this);
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
				// Ask
				{
					if (data is Ask) {
						Ask ask = data as Ask;
						// CheckChange
						{
							checkWhoCanAnswer.removeCallBack (this);
							checkWhoCanAnswer.setData (null);
						}
						// Parent
						{
							DataUtils.removeParentCallBack (ask, this, ref this.server);
						}
						// Child
						{
							ask.requestInform.allRemoveCallBack (this);
						}
						return;
					}
					// CheckChange
					if (data is CheckWhoCanAskChange<Ask>) {
						return;
					}
					// Parent
					if (data is Server) {
						return;
					}
					// Child
					if (data is RequestInform) {
						return;
					}
				}
				// whoCanAskAdapter
				if (data is WhoCanAskAdapter.UIData) {
					WhoCanAskAdapter.UIData whoCanAskAdapterUIData = data as WhoCanAskAdapter.UIData;
					// UI
					{
						whoCanAskAdapterUIData.removeCallBackAndDestroy (typeof(WhoCanAskAdapter));
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
				case UIData.Property.ask:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.whoCanAskAdapter:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.state:
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
					Debug.LogError ("Don't proess: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				// Ask
				{
					if (wrapProperty.p is Ask) {
						switch ((Ask.Property)wrapProperty.n) {
						case Ask.Property.requestInform:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case Ask.Property.whoCanAsks:
							dirty = true;
							break;
						case Ask.Property.accepts:
							dirty = true;
							break;
						case Ask.Property.cancels:
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// CheckChange
					if (wrapProperty.p is CheckWhoCanAskChange<Ask>) {
						dirty = true;
						return;
					}
					// Parent
					if (wrapProperty.p is Server) {
						Server.State.OnUpdateSyncStateChange (wrapProperty, this);
						return;
					}
					// Child
					if (wrapProperty.p is RequestInform) {
						dirty = true;
						return;
					}
				}
				// whoCanAskAdapter
				if (wrapProperty.p is WhoCanAskAdapter.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnAccept()
		{
			if (this.data != null) {
				if (!GameUI.UIData.IsReplay (this.data)) {
					switch (this.data.state.v) {
					case UIData.State.None:
						this.data.state.v = UIData.State.RequestAccept;
						break;
					case UIData.State.RequestAccept:
						this.data.state.v = UIData.State.None;
						break;
					case UIData.State.WaitAccept:
						break;
					case UIData.State.RequestCancel:
						break;
					case UIData.State.WaitCancel:
						break;
					default:
						Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
						break;
					}
				} else {
					Debug.LogError ("this is replay, cannot change: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onClickBtnCancel()
		{
			if (this.data != null) {
				if (!GameUI.UIData.IsReplay (this.data)) {
					switch (this.data.state.v) {
					case UIData.State.None:
						this.data.state.v = UIData.State.RequestCancel;
						break;
					case UIData.State.RequestAccept:
						break;
					case UIData.State.WaitAccept:
						break;
					case UIData.State.RequestCancel:
						this.data.state.v = UIData.State.None;
						break;
					case UIData.State.WaitCancel:
						break;
					default:
						Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
						break;
					}
				} else {
					Debug.LogError ("this is replay, cannot change: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}