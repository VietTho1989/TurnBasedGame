using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HumanUI : UIBehavior<HumanUI.UIData>, HaveTransformData
{

	#region UIData

	public class UIData : InformUI
	{

		public VP<EditData<Human>> editHuman;

		// playerId
		public VP<RequestChangeIntUI.UIData> playerId;

		// account
		public VP<AccountUI.UIData> account;

		#region email

		public VP<RequestChangeStringUI.UIData> email;

		public void makeRequestChangeEmail (RequestChangeUpdate<string>.UpdateData update, string newEmail)
		{
			// Find
			Human human = null;
			{
				EditData<Human> editHuman = this.editHuman.v;
				if (editHuman != null) {
					human = editHuman.show.v.data;
				} else {
					Debug.LogError ("editHuman null: " + this);
				}
			}
			// Process
			if (human != null) {
				human.requestChangeEmail (Server.getProfileUserId(human), newEmail);
			} else {
				Debug.LogError ("human null: " + this);
			}
		}

		#endregion

		#region phoneNumber

		public VP<RequestChangeStringUI.UIData> phoneNumber;

		public void makeRequestChangePhoneNumber (RequestChangeUpdate<string>.UpdateData update, string newPhoneNumber)
		{
			// Find
			Human human = null;
			{
				EditData<Human> editHuman = this.editHuman.v;
				if (editHuman != null) {
					human = editHuman.show.v.data;
				} else {
					Debug.LogError ("editHuman null: " + this);
				}
			}
			// Process
			if (human != null) {
				human.requestChangePhoneNumber (Server.getProfileUserId(human), newPhoneNumber);
			} else {
				Debug.LogError ("human null: " + this);
			}
		}

		#endregion

		#region status

		public VP<RequestChangeStringUI.UIData> status;

		public void makeRequestChangeStatus (RequestChangeUpdate<string>.UpdateData update, string newStatus)
		{
			// Find
			Human human = null;
			{
				EditData<Human> editHuman = this.editHuman.v;
				if (editHuman != null) {
					human = editHuman.show.v.data;
				} else {
					Debug.LogError ("editHuman null: " + this);
				}
			}
			// Process
			if (human != null) {
				human.requestChangeStatus (Server.getProfileUserId(human), newStatus);
			} else {
				Debug.LogError ("human null: " + this);
			}
		}

		#endregion

		#region birthday

		public VP<RequestChangeLongUI.UIData> birthday;

		public void makeRequestChangeBirthday (RequestChangeUpdate<long>.UpdateData update, long newBirthday)
		{
			// Find
			Human human = null;
			{
				EditData<Human> editHuman = this.editHuman.v;
				if (editHuman != null) {
					human = editHuman.show.v.data;
				} else {
					Debug.LogError ("editHuman null: " + this);
				}
			}
			// Process
			if (human != null) {
				human.requestChangeBirthday (Server.getProfileUserId(human), newBirthday);
			} else {
				Debug.LogError ("human null: " + this);
			}
		}

		#endregion

		#region sex

		public VP<RequestChangeEnumUI.UIData> sex;

		public void makeRequestChangeSex (RequestChangeUpdate<int>.UpdateData update, int newSex)
		{
			// Find
			Human human = null;
			{
				EditData<Human> editHuman = this.editHuman.v;
				if (editHuman != null) {
					human = editHuman.show.v.data;
				} else {
					Debug.LogError ("editHuman null: " + this);
				}
			}
			// Process
			if (human != null) {
				human.requestChangeSex (Server.getProfileUserId (human), (User.SEX)newSex);
			} else {
				Debug.LogError ("human null: " + this);
			}
		}

		#endregion

		// ban
		public VP<BanUI.UIData> ban;

		#region Constructor

		public enum Property
		{
			editHuman,
			playerId,
			account,
			email,
			phoneNumber,
			status,
			birthday,
			sex,
			ban
		}

		public UIData() : base()
		{
			this.editHuman = new VP<EditData<Human>>(this, (byte)Property.editHuman, new EditData<Human>());
			//playerId
			{
				this.playerId = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.playerId, new RequestChangeIntUI.UIData());
				this.playerId.v.updateData.v.canRequestChange.v = false;
			}
			this.account = new VP<AccountUI.UIData>(this, (byte)Property.account, new AccountUI.UIData());
			// email
			{
				this.email = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.email, new RequestChangeStringUI.UIData());
				this.email.v.updateData.v.request.v = makeRequestChangeEmail;
			}
			// phoneNumber
			{
				this.phoneNumber = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.phoneNumber, new RequestChangeStringUI.UIData());
				this.phoneNumber.v.updateData.v.request.v = makeRequestChangePhoneNumber;
			}
			// status
			{
				this.status = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.status, new RequestChangeStringUI.UIData());
				this.status.v.updateData.v.request.v = makeRequestChangeStatus;
			}
			// birthday
			{
				this.birthday = new VP<RequestChangeLongUI.UIData>(this, (byte)Property.birthday, new RequestChangeLongUI.UIData());
				this.birthday.v.updateData.v.request.v = makeRequestChangeBirthday;
			}
			// sex
			{
				this.sex = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.sex, new RequestChangeEnumUI.UIData());
				foreach (User.SEX sex in System.Enum.GetValues(typeof(User.SEX))) {
					this.sex.v.options.add(sex.ToString());
				}
				this.sex.v.updateData.v.request.v = makeRequestChangeSex;
			}
			// ban
			this.ban = new VP<BanUI.UIData>(this, (byte)Property.ban, new BanUI.UIData());
		}

		#endregion

		public override GamePlayer.Inform.Type getType ()
		{
			return GamePlayer.Inform.Type.Human;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public Text lbTitle;
	public static readonly TxtLanguage txtTitle = new TxtLanguage();

	public Text lbPlayerId;
	public static readonly TxtLanguage txtPlayerId = new TxtLanguage();

	public Text lbEmail;
	public static readonly TxtLanguage txtEmail = new TxtLanguage();

	public Text lbPhoneNumber;
	public static readonly TxtLanguage txtPhoneNumber = new TxtLanguage();

	public Text lbStatus;
	public static readonly TxtLanguage txtStatus = new TxtLanguage();

	public Text lbBirthday;
	public static readonly TxtLanguage txtBirthday = new TxtLanguage ();

	public Text lbSex;
	public static readonly TxtLanguage txtSex = new TxtLanguage();

	public Text lbBan;
	public static readonly TxtLanguage txtBan = new TxtLanguage();

	static HumanUI()
	{
        // txt
        {
            txtTitle.add(Language.Type.vi, "Con người");
            txtPlayerId.add(Language.Type.vi, "Id người chơi");
            txtEmail.add(Language.Type.vi, "Email");
            txtPhoneNumber.add(Language.Type.vi, "Số điện thoại");
            txtStatus.add(Language.Type.vi, "Status");
            txtBirthday.add(Language.Type.vi, "Sinh nhật");
            txtSex.add(Language.Type.vi, "Giới tính");
            txtBan.add(Language.Type.vi, "Trạng thái ban");
        }
        // rect
        {

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

    private bool needReset = true;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				EditData<Human> editHuman = this.data.editHuman.v;
				if (editHuman != null) {
					editHuman.update ();
					// get show
					Human show = editHuman.show.v.data;
					Human compare = editHuman.compare.v.data;
					if (show != null) {
						// different
						if (lbTitle != null) {
							bool isDifferent = false;
							{
								if (editHuman.compareOtherType.v.data != null) {
									if (editHuman.compareOtherType.v.data.GetType () != show.GetType ()) {
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
							// playerId
							{
								RequestChangeIntUI.UIData playerId = this.data.playerId.v;
								if (playerId != null) {
									// update
									RequestChangeUpdate<int>.UpdateData updateData = playerId.updateData.v;
									if (updateData != null) {
										updateData.origin.v = (int)show.playerId.v;
										updateData.canRequestChange.v = false;// editHuman.canEdit.v;
										updateData.serverState.v = serverState;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
									// compare
									{
										if (compare != null) {
											playerId.showDifferent.v = true;
											playerId.compare.v = (int)compare.playerId.v;
										} else {
											playerId.showDifferent.v = false;
										}
									}
								} else {
									Debug.LogError ("playerId null: " + this);
								}
							}
							// account
							{
								AccountUI.UIData accountUIData = this.data.account.v;
								if (accountUIData != null) {
									EditData<Account> editAccount = accountUIData.editAccount.v;
									if (editAccount != null) {
										// origin
										{
											Account originAccount = null;
											{
												Human originHuman = editHuman.origin.v.data;
												if (originHuman != null) {
													originAccount = originHuman.account.v;
												} else {
													Debug.LogError ("originHuman null: " + this);
												}
											}
											editAccount.origin.v = new ReferenceData<Account> (originAccount);
										}
										// show
										{
											Account showAccount = null;
											{
												Human showHuman = editHuman.show.v.data;
												if (showHuman != null) {
													showAccount = showHuman.account.v;
												} else {
													Debug.LogError ("showAccount null: " + this);
												}
											}
											editAccount.show.v = new ReferenceData<Account> (showAccount);
										}
										// compare
										{
											Account compareAccount = null;
											{
												Human compareHuman = editHuman.compare.v.data;
												if (compareHuman != null) {
													compareAccount = compareHuman.account.v;
												} else {
													Debug.LogError ("compareAccount null: " + this);
												}
											}
											editAccount.compare.v = new ReferenceData<Account> (compareAccount);
										}
										// compare other type
										{
											Account compareOtherTypeAccount = null;
											{
												Human compareOtherTypeHuman = (Human)editHuman.compareOtherType.v.data;
												if (compareOtherTypeHuman != null) {
													compareOtherTypeAccount = compareOtherTypeHuman.account.v;
												}
											}
											editAccount.compareOtherType.v = new ReferenceData<Data> (compareOtherTypeAccount);
										}
										// canEdit
										editAccount.canEdit.v = editHuman.canEdit.v;
										// editType
										editAccount.editType.v = editHuman.editType.v;
									} else {
										Debug.LogError ("editHuman null: " + this);
									}
								} else {
									Debug.LogError ("accountUIData null: " + this);
								}
							}
							// email
							{
								RequestChangeStringUI.UIData email = this.data.email.v;
								if (email != null) {
									// update
									RequestChangeUpdate<string>.UpdateData updateData = email.updateData.v;
									if (updateData != null) {
										updateData.origin.v = show.email.v;
										updateData.canRequestChange.v = editHuman.canEdit.v;
										updateData.serverState.v = serverState;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
									// compare
									{
										if (compare != null) {
											email.showDifferent.v = true;
											email.compare.v = compare.email.v;
										} else {
											email.showDifferent.v = false;
										}
									}
								} else {
									Debug.LogError ("email null: " + this);
								}
							}
							// phoneNumber
							{
								RequestChangeStringUI.UIData phoneNumber = this.data.phoneNumber.v;
								if (phoneNumber != null) {
									// update
									RequestChangeUpdate<string>.UpdateData updateData = phoneNumber.updateData.v;
									if (updateData != null) {
										updateData.origin.v = show.phoneNumber.v;
										updateData.canRequestChange.v = editHuman.canEdit.v;
										updateData.serverState.v = serverState;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
									// compare
									{
										if (compare != null) {
											phoneNumber.showDifferent.v = true;
											phoneNumber.compare.v = compare.phoneNumber.v;
										} else {
											phoneNumber.showDifferent.v = false;
										}
									}
								} else {
									Debug.LogError ("phoneNumber null: " + this);
								}
							}
							// status
							{
								RequestChangeStringUI.UIData status = this.data.status.v;
								if (status != null) {
									// update
									RequestChangeUpdate<string>.UpdateData updateData = status.updateData.v;
									if (updateData != null) {
										updateData.origin.v = show.status.v;
										updateData.canRequestChange.v = editHuman.canEdit.v;
										updateData.serverState.v = serverState;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
									// compare
									{
										if (compare != null) {
											status.showDifferent.v = true;
											status.compare.v = compare.status.v;
										} else {
											status.showDifferent.v = false;
										}
									}
								} else {
									Debug.LogError ("status null: " + this);
								}
							}
							// birthday
							{
								RequestChangeLongUI.UIData birthday = this.data.birthday.v;
								if (birthday != null) {
									// update
									RequestChangeUpdate<long>.UpdateData updateData = birthday.updateData.v;
									if (updateData != null) {
										updateData.origin.v = show.birthday.v;
										updateData.canRequestChange.v = editHuman.canEdit.v;
										updateData.serverState.v = serverState;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
									// compare
									{
										if (compare != null) {
											birthday.showDifferent.v = true;
											birthday.compare.v = compare.birthday.v;
										} else {
											birthday.showDifferent.v = false;
										}
									}
								} else {
									Debug.LogError ("birthday null: " + this);
								}
							}
							// sex
							{
								RequestChangeEnumUI.UIData sex = this.data.sex.v;
								if (sex != null) {
									// update
									RequestChangeUpdate<int>.UpdateData updateData = sex.updateData.v;
									if (updateData != null) {
										updateData.origin.v = (int)show.sex.v;
										updateData.canRequestChange.v = editHuman.canEdit.v;
										updateData.serverState.v = serverState;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
									// compare
									{
										if (compare != null) {
											sex.showDifferent.v = true;
											sex.compare.v = (int)compare.sex.v;
										} else {
											sex.showDifferent.v = false;
										}
									}
								} else {
									Debug.LogError ("sex null: " + this);
								}
							}
							// ban
							{
								BanUI.UIData banUIData = this.data.ban.v;
								if (banUIData != null) {
									banUIData.ban.v = new ReferenceData<Ban> (show.ban.v);
								} else {
									Debug.LogError ("banUIData null: " + this);
								}
							}
						}
						// reset
						if (needReset) {
							needReset = false;
							// playerId
							{
								RequestChangeIntUI.UIData playerId = this.data.playerId.v;
								if (playerId != null) {
									// update
									RequestChangeUpdate<int>.UpdateData updateData = playerId.updateData.v;
									if (updateData != null) {
										updateData.current.v = (int)show.playerId.v;
										updateData.changeState.v = Data.ChangeState.None;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("playerId null: " + this);
								}
							}
							// account
							{
								
							}
							// email
							{
								RequestChangeStringUI.UIData email = this.data.email.v;
								if (email != null) {
									// update
									RequestChangeUpdate<string>.UpdateData updateData = email.updateData.v;
									if (updateData != null) {
										updateData.current.v = show.email.v;
										updateData.changeState.v = Data.ChangeState.None;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("email null: " + this);
								}
							}
							// phoneNumber
							{
								RequestChangeStringUI.UIData phoneNumber = this.data.phoneNumber.v;
								if (phoneNumber != null) {
									// update
									RequestChangeUpdate<string>.UpdateData updateData = phoneNumber.updateData.v;
									if (updateData != null) {
										updateData.current.v = show.phoneNumber.v;
										updateData.changeState.v = Data.ChangeState.None;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("phoneNumber null: " + this);
								}
							}
							// status
							{
								RequestChangeStringUI.UIData status = this.data.status.v;
								if (status != null) {
									// update
									RequestChangeUpdate<string>.UpdateData updateData = status.updateData.v;
									if (updateData != null) {
										updateData.current.v = show.status.v;
										updateData.changeState.v = Data.ChangeState.None;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("status null: " + this);
								}
							}
							// birthday
							{
								RequestChangeLongUI.UIData birthday = this.data.birthday.v;
								if (birthday != null) {
									// update
									RequestChangeUpdate<long>.UpdateData updateData = birthday.updateData.v;
									if (updateData != null) {
										updateData.current.v = show.birthday.v;
										updateData.changeState.v = Data.ChangeState.None;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("birthday null: " + this);
								}
							}
							// sex
							{
								RequestChangeEnumUI.UIData sex = this.data.sex.v;
								if (sex != null) {
									// update
									RequestChangeUpdate<int>.UpdateData updateData = sex.updateData.v;
									if (updateData != null) {
										updateData.current.v = (int)show.sex.v;
										updateData.changeState.v = Data.ChangeState.None;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("sex null: " + this);
								}
							}
							// ban
							{

							}
						}
					} else {
						Debug.LogError ("show null: " + this);
					}
				} else {
					Debug.LogError ("editHuman null: " + this);
				}
                // UI Size
                {
                    float deltaY = UIConstants.HeaderHeight;
                    // playerId
                    {
                        if (this.data.playerId.v != null)
                        {
                            if (lbPlayerId != null)
                            {
                                lbPlayerId.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbPlayerId.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbPlayerId null");
                            }
                            UIRectTransform.SetPosY(this.data.playerId.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbPlayerId != null)
                            {
                                lbPlayerId.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbPlayerId null");
                            }
                        }
                    }
                    // account
                    deltaY += UIRectTransform.SetPosY(this.data.account.v, deltaY);
                    // email
                    {
                        if (this.data.email.v != null)
                        {
                            if (lbEmail != null)
                            {
                                lbEmail.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbEmail.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbEmail null");
                            }
                            UIRectTransform.SetPosY(this.data.email.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbEmail != null)
                            {
                                lbEmail.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbEmail null");
                            }
                        }
                    }
                    // phoneNumber
                    {
                        if (this.data.phoneNumber.v != null)
                        {
                            if (lbPhoneNumber != null)
                            {
                                lbPhoneNumber.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbPhoneNumber.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbPhoneNumber null");
                            }
                            UIRectTransform.SetPosY(this.data.phoneNumber.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbPhoneNumber != null)
                            {
                                lbPhoneNumber.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbPhoneNumber null");
                            }
                        }
                    }
                    // status
                    {
                        if (this.data.status.v != null)
                        {
                            if (lbStatus != null)
                            {
                                lbStatus.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbStatus.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbStatus null");
                            }
                            UIRectTransform.SetPosY(this.data.status.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbStatus != null)
                            {
                                lbStatus.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbStatus null");
                            }
                        }
                    }
                    // birthday
                    {
                        if (this.data.birthday.v != null)
                        {
                            if (lbBirthday != null)
                            {
                                lbBirthday.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbBirthday.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbBirthday null");
                            }
                            UIRectTransform.SetPosY(this.data.birthday.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbBirthday != null)
                            {
                                lbBirthday.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbBirthday null");
                            }
                        }
                    }
                    // sex
                    {
                        if (this.data.sex.v != null)
                        {
                            if (lbSex != null)
                            {
                                lbSex.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbSex.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbSex null");
                            }
                            UIRectTransform.SetPosY(this.data.sex.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbSex != null)
                            {
                                lbSex.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbSex null");
                            }
                        }
                    }
                    // ban
                    {
                        if (this.data.ban.v != null)
                        {
                            if (lbBan != null)
                            {
                                lbBan.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbBan.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbBan null");
                            }
                        }
                        else
                        {
                            if (lbBan != null)
                            {
                                lbBan.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbBan null");
                            }
                        }
                        deltaY += UIRectTransform.SetPosY(this.data.ban.v, deltaY);
                    }
                    // set
                    UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                }
                // txt
                {
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("Human");
					} else {
						Debug.LogError ("lbTitle null: " + this);
					}
					if (lbPlayerId != null) {
						lbPlayerId.text = txtPlayerId.get ("PlayerId");
					} else {
						Debug.LogError ("lbPlayerId null: " + this);
					}
					if (lbEmail != null) {
						lbEmail.text = txtEmail.get ("Email");
					} else {
						Debug.LogError ("lbEmail null: " + this);
					}
					if (lbPhoneNumber != null) {
						lbPhoneNumber.text = txtPhoneNumber.get ("Phone Number");
					} else {
						Debug.LogError ("lbPhoneNumber null: " + this);
					}
					if (lbStatus != null) {
						lbStatus.text = txtStatus.get ("Status");
					} else {
						Debug.LogError ("lbStatus null: " + this);
					}
					if (lbBirthday != null) {
						lbBirthday.text = txtBirthday.get ("Birthday");
					} else {
						Debug.LogError ("lbBirthday null: " + this);
					}
					if (lbSex != null) {
						lbSex.text = txtSex.get ("Sex");
					} else {
						Debug.LogError ("lbSex null: " + this);
					}
					if (lbBan != null) {
						lbBan.text = txtBan.get ("Ban");
					} else {
						Debug.LogError ("lbBan null: " + this);
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

	public RequestChangeIntUI requestIntPrefab;
	public AccountUI accountPrefab;
	public RequestChangeStringUI requestStringPrefab;
	public RequestChangeLongUI requestLongPrefab;
	public RequestChangeEnumUI requestEnumPrefab;
	public BanUI banPrefab;

	private static readonly UIRectTransform playerIdRect = new UIRectTransform(UIConstants.RequestRect);
	// public Transform accountContainer;
	private static readonly UIRectTransform emailRect = new UIRectTransform(UIConstants.RequestEnumRect);
	private static readonly UIRectTransform phoneNumberRect = new UIRectTransform(UIConstants.RequestEnumRect);
	private static readonly UIRectTransform statusRect = new UIRectTransform(UIConstants.RequestEnumRect);
	private static readonly UIRectTransform birthdayRect = new UIRectTransform(UIConstants.RequestRect);
	private static readonly UIRectTransform sexRect = new UIRectTransform(UIConstants.RequestEnumRect);
	// public Transform banContainer;

	private Server server = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.editHuman.allAddCallBack (this);
				uiData.playerId.allAddCallBack (this);
				uiData.account.allAddCallBack (this);
				uiData.email.allAddCallBack (this);
				uiData.phoneNumber.allAddCallBack (this);
				uiData.status.allAddCallBack (this);
				uiData.birthday.allAddCallBack (this);
				uiData.sex.allAddCallBack (this);
				uiData.ban.allAddCallBack (this);
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
			// editHuman
			{
				if (data is EditData<Human>) {
					EditData<Human> editHuman = data as EditData<Human>;
					// Child
					{
						editHuman.show.allAddCallBack (this);
						editHuman.compare.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is Human) {
						Human human = data as Human;
						// Parent
						{
							DataUtils.addParentCallBack (human, this, ref this.server);
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
			// playerId
			if (data is RequestChangeIntUI.UIData) {
				RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.playerId:
							UIUtils.Instantiate (requestChange, requestIntPrefab, this.transform, playerIdRect);
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
			// email, phoneNumber, status
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.email:
							UIUtils.Instantiate (requestChange, requestStringPrefab, this.transform, emailRect);
							break;
						case UIData.Property.phoneNumber:
							UIUtils.Instantiate (requestChange, requestStringPrefab, this.transform, phoneNumberRect);
							break;
						case UIData.Property.status:
							UIUtils.Instantiate (requestChange, requestStringPrefab, this.transform, statusRect);
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
			// birthday
			if (data is RequestChangeLongUI.UIData) {
				RequestChangeLongUI.UIData requestChange = data as RequestChangeLongUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.birthday:
							UIUtils.Instantiate (requestChange, requestLongPrefab, this.transform, birthdayRect);
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
			// sex
			if (data is RequestChangeEnumUI.UIData) {
				RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.sex:
							UIUtils.Instantiate (requestChange, requestEnumPrefab, this.transform, sexRect);
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
			// account
			if (data is AccountUI.UIData) {
				AccountUI.UIData accountUIData = data as AccountUI.UIData;
				// UI
				{
					UIUtils.Instantiate (accountUIData, accountPrefab, this.transform);
				}
                // Child
                {
                    TransformData.AddCallBack(accountUIData, this);
                }
                dirty = true;
				return;
			}
			// ban
			if (data is BanUI.UIData) {
				BanUI.UIData banUIData = data as BanUI.UIData;
				// UI
				{
					UIUtils.Instantiate (banUIData, banPrefab, this.transform);
				}
                // Child
                {
                    TransformData.AddCallBack(banUIData, this);
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
				uiData.editHuman.allRemoveCallBack (this);
				uiData.playerId.allRemoveCallBack (this);
				uiData.account.allRemoveCallBack (this);
				uiData.email.allRemoveCallBack (this);
				uiData.phoneNumber.allRemoveCallBack (this);
				uiData.status.allRemoveCallBack (this);
				uiData.birthday.allRemoveCallBack (this);
				uiData.sex.allRemoveCallBack (this);
				uiData.ban.allRemoveCallBack (this);
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
			// editHuman
			{
				if (data is EditData<Human>) {
					EditData<Human> editHuman = data as EditData<Human>;
					// Child
					{
						editHuman.show.allRemoveCallBack (this);
						editHuman.compare.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is Human) {
						Human human = data as Human;
						// Parent
						{
							DataUtils.removeParentCallBack (human, this, ref this.server);
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
			// playerId
			if (data is RequestChangeIntUI.UIData) {
				RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeIntUI));
				}
				return;
			}
			// email, phoneNumber, status
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeStringUI));
				}
				return;
			}
			// birthday
			if (data is RequestChangeLongUI.UIData) {
				RequestChangeLongUI.UIData requestChange = data as RequestChangeLongUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeLongUI));
				}
				return;
			}
			// sex
			if (data is RequestChangeEnumUI.UIData) {
				RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeEnumUI));
				}
				return;
			}
			// account
			if (data is AccountUI.UIData) {
				AccountUI.UIData accountUIData = data as AccountUI.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(accountUIData, this);
                }
                // UI
                {
					accountUIData.removeCallBackAndDestroy (typeof(AccountUI));
				}
				return;
			}
			// ban
			if (data is BanUI.UIData) {
				BanUI.UIData banUIData = data as BanUI.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(banUIData, this);
                }
                // UI
                {
					banUIData.removeCallBackAndDestroy (typeof(BanUI));
				}
				return;
			}
            // Child
            if(data is TransformData)
            {
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
			case UIData.Property.editHuman:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.playerId:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.account:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.email:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.phoneNumber:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.status:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.birthday:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.sex:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.ban:
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
			// editHuman
			{
				if (wrapProperty.p is EditData<Human>) {
					switch ((EditData<Human>.Property)wrapProperty.n) {
					case EditData<Human>.Property.origin:
						dirty = true;
						break;
					case EditData<Human>.Property.show:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case EditData<Human>.Property.compare:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case EditData<Human>.Property.compareOtherType:
						dirty = true;
						break;
					case EditData<Human>.Property.canEdit:
						dirty = true;
						break;
					case EditData<Human>.Property.editType:
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
					if (wrapProperty.p is Human) {
						switch ((Human.Property)wrapProperty.n) {
						case Human.Property.playerId:
							dirty = true;
							break;
						case Human.Property.account:
							dirty = true;
							break;
						case Human.Property.state:
							dirty = true;
							break;
						case Human.Property.email:
							dirty = true;
							break;
						case Human.Property.phoneNumber:
							dirty = true;
							break;
						case Human.Property.status:
							dirty = true;
							break;
						case Human.Property.birthday:
							dirty = true;
							break;
						case Human.Property.sex:
							dirty = true;
							break;
						case Human.Property.connection:
							break;
						case Human.Property.ban:
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
			// playerId
			if (wrapProperty.p is RequestChangeIntUI.UIData) {
				return;
			}
			// email, phoneNumber, status
			if (wrapProperty.p is RequestChangeStringUI.UIData) {
				return;
			}
			// birthday
			if (wrapProperty.p is RequestChangeLongUI.UIData) {
				return;
			}
			// sex
			if (wrapProperty.p is RequestChangeEnumUI.UIData) {
				return;
			}
			// account
			if (wrapProperty.p is AccountUI.UIData) {
				return;
			}
			// ban
			if (wrapProperty.p is BanUI.UIData) {
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
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}