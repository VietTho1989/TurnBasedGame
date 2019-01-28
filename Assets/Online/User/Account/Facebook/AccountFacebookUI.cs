﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AccountFacebookUI : UIBehavior<AccountFacebookUI.UIData>
{

	#region UIData

	public class UIData : AccountUI.UIData.Sub
	{

		public VP<EditData<AccountFacebook>> editAccountFacebook;

		public VP<RequestChangeStringUI.UIData> userId;

		public VP<RequestChangeStringUI.UIData> firstName;

		public VP<RequestChangeStringUI.UIData> lastName;

		#region Constructor

		public enum Property
		{
			editAccountFacebook,
			userId,
			firstName,
			lastName
		}

		public UIData() : base()
		{
			this.editAccountFacebook = new VP<EditData<AccountFacebook>>(this, (byte)Property.editAccountFacebook, new EditData<AccountFacebook>());
			this.userId = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.userId, new RequestChangeStringUI.UIData());
			this.firstName = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.firstName, new RequestChangeStringUI.UIData());
			this.lastName = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.lastName, new RequestChangeStringUI.UIData());
		}

		#endregion

		public override Account.Type getType ()
		{
			return Account.Type.FACEBOOK;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public Text lbTitle;
	public static readonly TxtLanguage txtTitle = new TxtLanguage();

	public Text lbUserId;
	public static readonly TxtLanguage txtUserId = new TxtLanguage ();

	public Text lbFirstName;
	public static readonly TxtLanguage txtFirstName = new TxtLanguage();

	public Text lbLastName;
	public static readonly TxtLanguage txtLastName = new TxtLanguage();

	static AccountFacebookUI()
	{
		txtTitle.add (Language.Type.vi, "Tài Khoản Facebook");
		txtUserId.add (Language.Type.vi, "Id người dùng");
		txtFirstName.add (Language.Type.vi, "Tên riêng");
		txtLastName.add (Language.Type.vi, "Họ");
	}

	#endregion

	private bool needReset = true;
	public GameObject differentIndicator;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				EditData<AccountFacebook> editAccountFacebook = this.data.editAccountFacebook.v;
				if (editAccountFacebook != null) {
					editAccountFacebook.update ();
					// get show
					AccountFacebook show = editAccountFacebook.show.v.data;
					AccountFacebook compare = editAccountFacebook.compare.v.data;
					if (show != null) {
						// differentIndicator
						if (differentIndicator != null) {
							bool isDifferent = false;
							{
								if (editAccountFacebook.compareOtherType.v.data != null) {
									if (editAccountFacebook.compareOtherType.v.data.GetType () != show.GetType ()) {
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
								// userId
								{
									RequestChangeStringUI.UIData userId = this.data.userId.v;
									if (userId != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = userId.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.userId.v;
											updateData.canRequestChange.v = false;// editAccountFacebook.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												userId.showDifferent.v = true;
												userId.compare.v = compare.userId.v;
											} else {
												userId.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("userId null: " + this);
									}
									// Container
									if (userIdContainer != null) {
										userIdContainer.parent.gameObject.SetActive (userId != null);
									} else {
										Debug.LogError ("userIdContainer null: " + this);
									}
								}
								// firstName
								{
									RequestChangeStringUI.UIData firstName = this.data.firstName.v;
									if (firstName != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = firstName.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.firstName.v;
											updateData.canRequestChange.v = false;// editAccountFacebook.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												firstName.showDifferent.v = true;
												firstName.compare.v = compare.firstName.v;
											} else {
												firstName.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("firstName null: " + this);
									}
									// Container
									if (firstNameContainer != null) {
										firstNameContainer.parent.gameObject.SetActive (firstName != null);
									} else {
										Debug.LogError ("firstNameContainer null: " + this);
									}
								}
								// lastName
								{
									RequestChangeStringUI.UIData lastName = this.data.lastName.v;
									if (lastName != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = lastName.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.lastName.v;
											updateData.canRequestChange.v = false;// editAccountFacebook.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												lastName.showDifferent.v = true;
												lastName.compare.v = compare.lastName.v;
											} else {
												lastName.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("lastName null: " + this);
									}
									// Container
									if (lastNameContainer != null) {
										lastNameContainer.parent.gameObject.SetActive (lastName != null);
									} else {
										Debug.LogError ("lastNameContainer null: " + this);
									}
								}
							}
							// reset?
							if (needReset) {
								needReset = false;
								// userId
								{
									RequestChangeStringUI.UIData userId = this.data.userId.v;
									if (userId != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = userId.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.userId.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("userId null: " + this);
									}
								}
								// firstName
								{
									RequestChangeStringUI.UIData firstName = this.data.firstName.v;
									if (firstName != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = firstName.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.firstName.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("firstName null: " + this);
									}
								}
								// lastName
								{
									RequestChangeStringUI.UIData lastName = this.data.lastName.v;
									if (lastName != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = lastName.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.lastName.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("lastName null: " + this);
									}
								}
							}
						}
					} else {
						Debug.LogError ("show null: " + this);
					}
				} else {
					Debug.LogError ("editAccountFacebook null: " + this);
				}
				// txt
				{
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("Account Facebook");
					} else {
						Debug.LogError ("lbTitle null: " + this);
					}
					if (lbUserId != null) {
						lbUserId.text = txtUserId.get ("UserId");
					} else {
						Debug.LogError ("lbUserId null: " + this);
					}
					if (lbFirstName != null) {
						lbFirstName.text = txtFirstName.get ("First Name");
					} else {
						Debug.LogError ("lbFirstName null: " + this);
					}
					if (lbLastName != null) {
						lbLastName.text = txtLastName.get ("Last Name");
					} else {
						Debug.LogError ("lbLastName null: " + this);
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

	public RequestChangeStringUI requestStringPrefab;

	public Transform userIdContainer;
	public Transform firstNameContainer;
	public Transform lastNameContainer;

	private Server server = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.editAccountFacebook.allAddCallBack (this);
				uiData.userId.allAddCallBack (this);
				uiData.firstName.allAddCallBack (this);
				uiData.lastName.allAddCallBack (this);
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
			// editAccountFacebook
			{
				if (data is EditData<AccountFacebook>) {
					EditData<AccountFacebook> editAccountFacebook = data as EditData<AccountFacebook>;
					// Child
					{
						editAccountFacebook.show.allAddCallBack (this);
						editAccountFacebook.compare.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is AccountFacebook) {
						AccountFacebook accountFacebook = data as AccountFacebook;
						// Parent
						{
							DataUtils.addParentCallBack (accountFacebook, this, ref this.server);
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
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.userId:
							UIUtils.Instantiate (requestChange, requestStringPrefab, userIdContainer);
							break;
						case UIData.Property.firstName:
							UIUtils.Instantiate (requestChange, requestStringPrefab, firstNameContainer);
							break;
						case UIData.Property.lastName:
							UIUtils.Instantiate (requestChange, requestStringPrefab, lastNameContainer);
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
				uiData.editAccountFacebook.allRemoveCallBack (this);
				uiData.userId.allRemoveCallBack (this);
				uiData.firstName.allRemoveCallBack (this);
				uiData.lastName.allRemoveCallBack (this);
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
			// editAccountFacebook
			{
				if (data is EditData<AccountFacebook>) {
					EditData<AccountFacebook> editAccountFacebook = data as EditData<AccountFacebook>;
					// Child
					{
						editAccountFacebook.show.allRemoveCallBack (this);
						editAccountFacebook.compare.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is AccountFacebook) {
						AccountFacebook accountFacebook = data as AccountFacebook;
						// Parent
						{
							DataUtils.removeParentCallBack (accountFacebook, this, ref this.server);
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
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeStringUI));
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if(WrapProperty.checkError(wrapProperty)){
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.editAccountFacebook:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.userId:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.firstName:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.lastName:
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
			// editAccountFacebook
			{
				if (wrapProperty.p is EditData<AccountFacebook>) {
					switch ((EditData<AccountFacebook>.Property)wrapProperty.n) {
					case EditData<AccountFacebook>.Property.origin:
						dirty = true;
						break;
					case EditData<AccountFacebook>.Property.show:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case EditData<AccountFacebook>.Property.compare:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case EditData<AccountFacebook>.Property.compareOtherType:
						dirty = true;
						break;
					case EditData<AccountFacebook>.Property.canEdit:
						dirty = true;
						break;
					case EditData<AccountFacebook>.Property.editType:
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
					if (wrapProperty.p is AccountFacebook) {
						switch ((AccountFacebook.Property)wrapProperty.n) {
						case AccountFacebook.Property.userId:
							dirty = true;
							break;
						case AccountFacebook.Property.firstName:
							dirty = true;
							break;
						case AccountFacebook.Property.lastName:
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
			if (wrapProperty.p is RequestChangeStringUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
	}

	#endregion

}