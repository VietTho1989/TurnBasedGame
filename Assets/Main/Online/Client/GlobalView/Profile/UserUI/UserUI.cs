using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UserUI : UIBehavior<UserUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<EditData<User>> editUser;

		#region editType

		public VP<EditType> editType;

		public VP<RequestChangeEnumUI.UIData> requestEditType;

		public void makeRequestChangeEditType (RequestChangeUpdate<int>.UpdateData update, int newEditType)
		{
			this.editType.v = (EditType)newEditType;
		}

		#endregion

		// human
		public VP<HumanUI.UIData> human;

		#region role

		public VP<RequestChangeEnumUI.UIData> role;

		public void makeRequestChangeRole (RequestChangeUpdate<int>.UpdateData update, int newRole)
		{
			// Find
			User user = null;
			{
				EditData<User> editUser = this.editUser.v;
				if (editUser != null) {
					user = editUser.show.v.data;
				} else {
					Debug.LogError ("editUser null: " + this);
				}
			}
			// Process
			if (user != null) {
				user.requestChangeRole (Server.getProfileUserId (user), (User.Role)newRole);
			} else {
				Debug.LogError ("user null: " + this);
			}
		}

		#endregion

		// ipAddress
		public VP<RequestChangeStringUI.UIData> ipAddress;

		// registerTime
		public VP<RequestChangeLongUI.UIData> registerTime;

		public VP<BtnUpdateUser.UIData> btnUpdate;

		public VP<UserChatUI.UIData> userChat;

		#region Constructor

		public enum Property
		{
			editUser,
			editType,
			requestEditType,
			human,
			role,
			ipAddress,
			registerTime,
			btnUpdate,
			userChat
		}

		public UIData() : base()
		{
			this.editUser = new VP<EditData<User>>(this, (byte)Property.editUser, new EditData<User>());
			this.editType = new VP<EditType>(this, (byte)Property.editType, EditType.Later);
			// editType
			{
				this.requestEditType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.requestEditType, new RequestChangeEnumUI.UIData());
				foreach (EditType editType in System.Enum.GetValues(typeof(EditType))) {
					this.requestEditType.v.options.add(editType.ToString());
				}
				this.requestEditType.v.updateData.v.request.v = makeRequestChangeEditType;
			}
			this.human = new VP<HumanUI.UIData>(this, (byte)Property.human, new HumanUI.UIData());
			// role
			{
				this.role = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.role, new RequestChangeEnumUI.UIData());
				foreach (User.Role role in System.Enum.GetValues(typeof(User.Role))) {
					this.role.v.options.add(role.ToString());
				}
				this.role.v.updateData.v.request.v = makeRequestChangeRole;
			}
			// ipAddress
			{
				this.ipAddress = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.ipAddress, new RequestChangeStringUI.UIData());
				this.ipAddress.v.updateData.v.canRequestChange.v = false;
			}
			// registerTime
			{
				this.registerTime = new VP<RequestChangeLongUI.UIData>(this, (byte)Property.registerTime, new RequestChangeLongUI.UIData());
				this.registerTime.v.updateData.v.canRequestChange.v = false;
			}
			this.btnUpdate = new VP<BtnUpdateUser.UIData>(this, (byte)Property.btnUpdate, new BtnUpdateUser.UIData());
			this.userChat = new VP<UserChatUI.UIData>(this, (byte)Property.userChat, null);
		}

		#endregion

		public void reset()
		{
			if (this.btnUpdate.v != null) {
				this.btnUpdate.v.state.v = BtnUpdateUser.UIData.State.None;
			}
		}

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// userChat
				if (!isProcess) {
					UserChatUI.UIData userChatUIData = this.userChat.v;
					if (userChatUIData != null) {
						isProcess = userChatUIData.processEvent (e);
					} else {
						Debug.LogError ("userChatUIData null: " + this);
					}
				}
				// back
				if (!isProcess) {
					if (InputEvent.isBackEvent (e)) {
						UserUI userUI = this.findCallBack<UserUI> ();
						if (userUI != null) {
							userUI.onClickBtnBack ();
						} else {
							Debug.LogError ("userUI null: " + this);
						}
						isProcess = true;
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

	public Text tvBack;
	public static readonly TxtLanguage txtBack = new TxtLanguage();

	public Text lbEditType;
	public static readonly TxtLanguage txtEditType = new TxtLanguage ();

	public Text tvChat;
	public static readonly TxtLanguage txtChat = new TxtLanguage ();

	public Text lbRole;
	public static readonly TxtLanguage txtRole = new TxtLanguage ();

	public Text lbIpAddress;
	public static readonly TxtLanguage txtIpAddress = new TxtLanguage();

	public Text lbRegisterTime;
	public static readonly TxtLanguage txtRegisterTime = new TxtLanguage();

	public Text tvReset;
	public static readonly TxtLanguage txtReset = new TxtLanguage ();

	static UserUI()
	{
        // txt
        {
            txtTitle.add(Language.Type.vi, "Thông tin người dùng");
            txtBack.add(Language.Type.vi, "Quay Lại");
            txtEditType.add(Language.Type.vi, "Loại chỉnh sửa");
            txtChat.add(Language.Type.vi, "Tán gẫu");
            txtRole.add(Language.Type.vi, "Vai trò");
            txtIpAddress.add(Language.Type.vi, "Địa chỉ ip");
            txtRegisterTime.add(Language.Type.vi, "Thời điểm đăng ký");
            txtReset.add(Language.Type.vi, "Đặt lại");
        }
        // rect
        {
            // editType
            requestEditTypeRect.setPosY(UIConstants.HeaderHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
        }
    }

	#endregion

	private bool needReset = true;

	public GameObject bottom;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				EditData<User> editUser = this.data.editUser.v;
				if (editUser != null) {
					{
						// check is your user?
						bool isYourUser = false;
						{
							User originUser = editUser.origin.v.data;
							if (originUser != null) {
								Human human = originUser.human.v;
								if (human != null) {
									if (human.playerId.v == Server.getProfileUserId (originUser)) {
										isYourUser = true;
									}
								} else {
									Debug.LogError ("human null: " + this);
								}
							} else {
								Debug.LogError ("originUser null: " + this);
							}
						}
						// Process
						{
							if (isYourUser) {
								editUser.canEdit.v = true;
							} else {
								editUser.canEdit.v = false;
								editUser.editType.v = Data.EditType.Immediate;
							}
						}
					}
					// editType
					{
						if (editUser.canEdit.v) {
							editUser.editType.v = this.data.editType.v;
						} else {
							this.data.editType.v = Data.EditType.Immediate;
						}
					}
					// requestEditType
					{
						// request
						{
							RequestChangeEnumUI.UIData requestEditType = this.data.requestEditType.v;
							if (requestEditType != null) {
								RequestChangeUpdate<int>.UpdateData updateData = requestEditType.updateData.v;
								if (updateData != null) {
									updateData.canRequestChange.v = editUser.canEdit.v;
									updateData.origin.v = (int)this.data.editType.v;
								} else {
									Debug.LogError ("updateData null: " + this);
								}
							} else {
								Debug.LogError ("editType null: " + this);
							}
						}
					}
					// bottom
					{
						if (bottom != null) {
							if (editUser.canEdit.v && editUser.editType.v == Data.EditType.Later) {
								bottom.SetActive (true);
							} else {
								bottom.SetActive (false);
							}
						} else {
							Debug.LogError ("bottom null: " + this);
						}
					}
					editUser.update ();
					// get show
					User show = editUser.show.v.data;
					User compare = editUser.compare.v.data;
					if (show != null) {
						// different
						if (lbTitle != null) {
							bool isDifferent = false;
							{
								if (editUser.compareOtherType.v.data != null) {
									if (editUser.compareOtherType.v.data.GetType () != show.GetType ()) {
										isDifferent = true;
									}
								}
							}
                            lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
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
							// human
							{
								HumanUI.UIData humanUIData = this.data.human.v;
								if (humanUIData != null) {
									EditData<Human> editHuman = humanUIData.editHuman.v;
									if (editHuman != null) {
										// origin
										{
											Human originHuman = null;
											{
												User originUser = editUser.origin.v.data;
												if (originUser != null) {
													originHuman = originUser.human.v;
												} else {
													Debug.LogError ("originUser null: " + this);
												}
											}
											editHuman.origin.v = new ReferenceData<Human> (originHuman);
										}
										// show
										{
											Human showHuman = null;
											{
												User showUser = editUser.show.v.data;
												if (showUser != null) {
													showHuman = showUser.human.v;
												} else {
													Debug.LogError ("showUser null: " + this);
												}
											}
											editHuman.show.v = new ReferenceData<Human> (showHuman);
										}
										// compare
										{
											Human compareHuman = null;
											{
												User compareUser = editUser.compare.v.data;
												if (compareUser != null) {
													compareHuman = compareUser.human.v;
												} else {
													Debug.LogError ("compareUser null: " + this);
												}
											}
											editHuman.compare.v = new ReferenceData<Human> (compareHuman);
										}
										// compare other type
										{
											Human compareOtherTypeHuman = null;
											{
												User compareOtherTypeUser = (User)editUser.compareOtherType.v.data;
												if (compareOtherTypeUser != null) {
													compareOtherTypeHuman = compareOtherTypeUser.human.v;
												}
											}
											editHuman.compareOtherType.v = new ReferenceData<Data> (compareOtherTypeHuman);
										}
										// canEdit
										editHuman.canEdit.v = editUser.canEdit.v;
										// editType
										editHuman.editType.v = editUser.editType.v;
									} else {
										Debug.LogError ("editHuman null: " + this);
									}
								} else {
									Debug.LogError ("accountUIData null: " + this);
								}
							}
							// role
							{
								RequestChangeEnumUI.UIData role = this.data.role.v;
								if (role != null) {
									// update
									RequestChangeUpdate<int>.UpdateData updateData = role.updateData.v;
									if (updateData != null) {
										updateData.origin.v = (int)show.role.v;
										updateData.canRequestChange.v = show.isCanChangeRole (Server.getProfileUserId (editUser.origin.v.data));
										updateData.serverState.v = serverState;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
									// compare
									{
										if (compare != null) {
											role.showDifferent.v = true;
											role.compare.v = (int)compare.role.v;
										} else {
											role.showDifferent.v = false;
										}
									}
								} else {
									Debug.LogError ("role null: " + this);
								}
							}
							// ipAddress
							{
								RequestChangeStringUI.UIData ipAddress = this.data.ipAddress.v;
								if (ipAddress != null) {
									// update
									RequestChangeUpdate<string>.UpdateData updateData = ipAddress.updateData.v;
									if (updateData != null) {
										updateData.origin.v = show.ipAddress.v;
										updateData.canRequestChange.v = false;// editUser.canEdit.v;
										updateData.serverState.v = serverState;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
									// compare
									{
										if (compare != null) {
											ipAddress.showDifferent.v = true;
											ipAddress.compare.v = compare.ipAddress.v;
										} else {
											ipAddress.showDifferent.v = false;
										}
									}
								} else {
									Debug.LogError ("ipAddress null: " + this);
								}
							}
							// registerTime
							{
								RequestChangeLongUI.UIData registerTime = this.data.registerTime.v;
								if (registerTime != null) {
									// update
									RequestChangeUpdate<long>.UpdateData updateData = registerTime.updateData.v;
									if (updateData != null) {
										updateData.origin.v = show.registerTime.v;
										updateData.canRequestChange.v = false; // editUser.canEdit.v;
										updateData.serverState.v = serverState;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
									// compare
									{
										if (compare != null) {
											registerTime.showDifferent.v = true;
											registerTime.compare.v = compare.registerTime.v;
										} else {
											registerTime.showDifferent.v = false;
										}
									}
								} else {
									Debug.LogError ("registerTime null: " + this);
								}
							}
						}
						// reset
						if (needReset) {
							needReset = false;
							// role
							{
								RequestChangeEnumUI.UIData role = this.data.role.v;
								if (role != null) {
									// update
									RequestChangeUpdate<int>.UpdateData updateData = role.updateData.v;
									if (updateData != null) {
										updateData.current.v = (int)show.role.v;
										updateData.changeState.v = Data.ChangeState.None;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("role null: " + this);
								}
							}
							// ipAddress
							{
								RequestChangeStringUI.UIData ipAddress = this.data.ipAddress.v;
								if (ipAddress != null) {
									// update
									RequestChangeUpdate<string>.UpdateData updateData = ipAddress.updateData.v;
									if (updateData != null) {
										updateData.current.v = show.ipAddress.v;
										updateData.changeState.v = Data.ChangeState.None;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("ipAddress null: " + this);
								}
							}
							// registerTime
							{
								RequestChangeLongUI.UIData registerTime = this.data.registerTime.v;
								if (registerTime != null) {
									// update
									RequestChangeUpdate<long>.UpdateData updateData = registerTime.updateData.v;
									if (updateData != null) {
										updateData.current.v = show.registerTime.v;
										updateData.changeState.v = Data.ChangeState.None;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("registerTime null: " + this);
								}
							}
						}
					} else {
						Debug.LogError ("show null: " + this);
					}
					// userChat
					{
						UserChatUI.UIData userChatUIData = this.data.userChat.v;
						if (userChatUIData != null) {
							userChatUIData.user.v = new ReferenceData<User> (editUser.origin.v.data);
						} else {
							Debug.LogError ("userChatUIData null: " + this);
						}
					}
				} else {
					Debug.LogError ("editUser null: " + this);
				}
				// txt
				{
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("User Information");
					} else {
						Debug.LogError ("lbTitle null: " + this);
					}
					if (tvBack != null) {
						tvBack.text = txtBack.get ("Back");
					} else {
						Debug.LogError ("tvBack null: " + this);
					}
					if (lbEditType != null) {
						lbEditType.text = txtEditType.get ("Edit Type");
					} else {
						Debug.LogError ("lbEditType null: " + this);
					}
					if (tvChat != null) {
						tvChat.text = txtChat.get ("Chat");
					} else {
						Debug.LogError ("tvChat null: " + this);
					}
					if (lbRole != null) {
						lbRole.text = txtRole.get ("Role");
					} else {
						Debug.LogError ("lbRole null: " + this);
					}
					if (lbIpAddress != null) {
						lbIpAddress.text = txtIpAddress.get ("Ip Address");
					} else {
						Debug.LogError ("lbIpAddress null: " + this);
					}
					if (lbRegisterTime != null) {
						lbRegisterTime.text = txtRegisterTime.get ("Register Time");
					} else {
						Debug.LogError ("lbRegisterTime null: " + this);
					}
					if (tvReset != null) {
						tvReset.text = txtReset.get ("Reset");
					} else {
						Debug.LogError ("tvReset null: " + this);
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

	private static readonly UIRectTransform requestEditTypeRect = new UIRectTransform(UIConstants.RequestEnumRect);

	public HumanUI humanPrefab;
	public RequestChangeEnumUI requestEnumPrefab;
	public RequestChangeStringUI requestStringPrefab;
	public RequestChangeLongUI requestLongPrefab;

	public Transform humanContainer;
	public Transform roleContainer;
	public Transform ipAddressContainer;
	public Transform registerTimeContainer;

	public BtnUpdateUser btnUpdateUserPrefab;
	public Transform btnUpdateUserContainer;

	public UserChatUI userChatPrefab;

	private Server server = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.editUser.allAddCallBack (this);
				uiData.requestEditType.allAddCallBack (this);
				uiData.human.allAddCallBack (this);
				uiData.role.allAddCallBack (this);
				uiData.ipAddress.allAddCallBack (this);
				uiData.registerTime.allAddCallBack (this);
				uiData.btnUpdate.allAddCallBack (this);
				uiData.userChat.allAddCallBack (this);
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
			// editUser
			{
				if (data is EditData<User>) {
					EditData<User> editUser = data as EditData<User>;
					// Child
					{
						editUser.show.allAddCallBack (this);
						editUser.compare.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is User) {
						User user = data as User;
						// Parent
						{
							DataUtils.addParentCallBack (user, this, ref this.server);
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
			// human
			if (data is HumanUI.UIData) {
				HumanUI.UIData humanUIData = data as HumanUI.UIData;
				// UI
				{
					UIUtils.Instantiate (humanUIData, humanPrefab, humanContainer);
				}
				dirty = true;
				return;
			}
			// role
			if (data is RequestChangeEnumUI.UIData) {
				RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.requestEditType:
							UIUtils.Instantiate (requestChange, requestEnumPrefab, this.transform, requestEditTypeRect);
							break;
						case UIData.Property.role:
							UIUtils.Instantiate (requestChange, requestEnumPrefab, roleContainer);
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
			// ipAddress
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.ipAddress:
							UIUtils.Instantiate (requestChange, requestStringPrefab, ipAddressContainer);
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
			// registerTime
			if (data is RequestChangeLongUI.UIData) {
				RequestChangeLongUI.UIData requestChange = data as RequestChangeLongUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.registerTime:
							UIUtils.Instantiate (requestChange, requestLongPrefab, registerTimeContainer);
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
			if (data is BtnUpdateUser.UIData) {
				BtnUpdateUser.UIData btnUpdateUserUIData = data as BtnUpdateUser.UIData;
				// UI
				{
					UIUtils.Instantiate (btnUpdateUserUIData, btnUpdateUserPrefab, btnUpdateUserContainer);
				}
				dirty = true;
				return;
			}
			if (data is UserChatUI.UIData) {
				UserChatUI.UIData userChatUIData = data as UserChatUI.UIData;
				// UI
				{
					UIUtils.Instantiate (userChatUIData, userChatPrefab, this.transform, UIConstants.FullParent);
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
				uiData.editUser.allRemoveCallBack (this);
				uiData.requestEditType.allRemoveCallBack (this);
				uiData.human.allRemoveCallBack (this);
				uiData.role.allRemoveCallBack (this);
				uiData.ipAddress.allRemoveCallBack (this);
				uiData.registerTime.allRemoveCallBack (this);
				uiData.btnUpdate.allRemoveCallBack (this);
				uiData.userChat.allRemoveCallBack (this);
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
			// editUser
			{
				if (data is EditData<User>) {
					EditData<User> editUser = data as EditData<User>;
					// Child
					{
						editUser.show.allRemoveCallBack (this);
						editUser.compare.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is User) {
						User user = data as User;
						// Parent
						{
							DataUtils.removeParentCallBack (user, this, ref this.server);
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
			// human
			if (data is HumanUI.UIData) {
				HumanUI.UIData humanUIData = data as HumanUI.UIData;
				// UI
				{
					humanUIData.removeCallBackAndDestroy (typeof(HumanUI));
				}
				return;
			}
			// role
			if (data is RequestChangeEnumUI.UIData) {
				RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeEnumUI));
				}
				return;
			}
			// ipAddress
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeStringUI));
				}
				return;
			}
			// registerTime
			if (data is RequestChangeLongUI.UIData) {
				RequestChangeLongUI.UIData requestChange = data as RequestChangeLongUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeLongUI));
				}
				return;
			}
			if (data is BtnUpdateUser.UIData) {
				BtnUpdateUser.UIData btnUpdateUserUIData = data as BtnUpdateUser.UIData;
				// UI
				{
					btnUpdateUserUIData.removeCallBackAndDestroy (typeof(BtnUpdateUser));
				}
				return;
			}
			if (data is UserChatUI.UIData) {
				UserChatUI.UIData userChatUIData = data as UserChatUI.UIData;
				// UI
				{
					userChatUIData.removeCallBackAndDestroy (typeof(UserChatUI));
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
			case UIData.Property.editUser:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.editType:
				dirty = true;
				break;
			case UIData.Property.requestEditType:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.human:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.role:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.ipAddress:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.registerTime:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.btnUpdate:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.userChat:
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
			// editUser
			{
				if (wrapProperty.p is EditData<User>) {
					switch ((EditData<User>.Property)wrapProperty.n) {
					case EditData<User>.Property.origin:
						dirty = true;
						break;
					case EditData<User>.Property.show:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case EditData<User>.Property.compare:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case EditData<User>.Property.compareOtherType:
						dirty = true;
						break;
					case EditData<User>.Property.canEdit:
						dirty = true;
						break;
					case EditData<User>.Property.editType:
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
					if (wrapProperty.p is User) {
						switch ((User.Property)wrapProperty.n) {
						case User.Property.human:
							dirty = true;
							break;
						case User.Property.role:
							dirty = true;
							break;
						case User.Property.ipAddress:
							dirty = true;
							break;
						case User.Property.registerTime:
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
			// human
			if (wrapProperty.p is HumanUI.UIData) {
				return;
			}
			// role
			if (wrapProperty.p is RequestChangeEnumUI.UIData) {
				return;
			}
			// ipAddress
			if (wrapProperty.p is RequestChangeStringUI.UIData) {
				return;
			}
			// registerTime
			if (wrapProperty.p is RequestChangeLongUI.UIData) {
				return;
			}
			// btnUpdate
			if (wrapProperty.p is BtnUpdateUser.UIData) {
				return;
			}
			if (wrapProperty.p is UserChatUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnBack()
	{
		if (this.data != null) {
			GlobalProfileUI.UIData globalProfileUIData = this.data.findDataInParent<GlobalProfileUI.UIData> ();
			if (globalProfileUIData != null) {
				globalProfileUIData.userUI.v = null;
			} else {
				Debug.LogError ("globalProfileUIData null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public void onClickBtnReset()
	{
		if (this.data != null) {
			EditData<User> editUser = this.data.editUser.v;
			if (editUser != null) {
				editUser.show.v = new ReferenceData<User> (null);
			} else {
				Debug.LogError ("editUser null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public void onClickBtnChat()
	{
		if (this.data != null) {
			UserChatUI.UIData userChatUIData = this.data.userChat.newOrOld<UserChatUI.UIData> ();
			{

			}
			this.data.userChat.v = userChatUIData;
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}