using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AccountUI : UIBehavior<AccountUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<EditData<Account>> editAccount;

		#region Type

		public VP<bool> isLogin;

		#endregion

		#region Avatar

		public VP<AccountAvatarUI.UIData> accountAvatar;

		#endregion

		#region Sub

		public abstract class Sub : Data
		{
			public abstract Account.Type getType();
		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			editAccount,
			isLogin,
			accountAvatar,
			sub
		}

		public UIData() : base()
		{
			this.editAccount = new VP<EditData<Account>>(this, (byte)Property.editAccount, new EditData<Account>());
			this.isLogin = new VP<bool>(this, (byte)Property.isLogin, true);
			this.accountAvatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.accountAvatar, new AccountAvatarUI.UIData());
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
		}

		#endregion

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				EditData<Account> editAccount = this.data.editAccount.v;
				if (editAccount != null) {
					// update
					editAccount.update ();
					// Make sub
					{
						Account show = editAccount.show.v.data;
						if (show != null) {
							switch (show.getType ()) {
							case Account.Type.NONE:
								{
									AccountNone accountNone = show as AccountNone;
									// UIData
									AccountNoneUI.UIData accountNoneUIData = this.data.sub.newOrOld<AccountNoneUI.UIData> ();
									{
										EditData<AccountNone> editAccountNone = accountNoneUIData.editAccountNone.v;
										if (editAccountNone != null) {
											// origin
											editAccountNone.origin.v = new ReferenceData<AccountNone> ((AccountNone)editAccount.origin.v.data);
											// show
											editAccountNone.show.v = new ReferenceData<AccountNone> (accountNone);
											// compare
											editAccountNone.compare.v = new ReferenceData<AccountNone> ((AccountNone)editAccount.compare.v.data);
											// compareOtherType
											editAccountNone.compareOtherType.v = new ReferenceData<Data>(editAccount.compareOtherType.v.data);
											// canEdit
											editAccountNone.canEdit.v = editAccount.canEdit.v;
											// editType
											editAccountNone.editType.v = editAccount.editType.v;
										} else {
											Debug.LogError ("editAccountNone null: " + this);
										}
									}
									this.data.sub.v = accountNoneUIData;
								}
								break;
							case Account.Type.Admin:
								{
									AccountAdmin accountAdmin = show as AccountAdmin;
									// UIData
									AccountAdminUI.UIData accountAdminUIData = this.data.sub.newOrOld<AccountAdminUI.UIData> ();
									{
										EditData<AccountAdmin> editAccountAdmin = accountAdminUIData.editAccountAdmin.v;
										if (editAccountAdmin != null) {
											// origin
											editAccountAdmin.origin.v = new ReferenceData<AccountAdmin> ((AccountAdmin)editAccount.origin.v.data);
											// show
											editAccountAdmin.show.v = new ReferenceData<AccountAdmin> (accountAdmin);
											// compare
											editAccountAdmin.compare.v = new ReferenceData<AccountAdmin> ((AccountAdmin)editAccount.compare.v.data);
											// compareOtherType
											editAccountAdmin.compareOtherType.v = new ReferenceData<Data>(editAccount.compareOtherType.v.data);
											// canEdit
											editAccountAdmin.canEdit.v = editAccount.canEdit.v;
											// editType
											editAccountAdmin.editType.v = editAccount.editType.v;
										} else {
											Debug.LogError ("editAccountAdmin null: " + this);
										}
									}
									this.data.sub.v = accountAdminUIData;
								}
								break;
							case Account.Type.DEVICE:
								{
									AccountDevice accountDevice = show as AccountDevice;
									// UIData
									AccountDeviceUI.UIData accountDeviceUIData = this.data.sub.newOrOld<AccountDeviceUI.UIData> ();
									{
										EditData<AccountDevice> editAccountDevice = accountDeviceUIData.editAccountDevice.v;
										if (editAccountDevice != null) {
											// origin
											editAccountDevice.origin.v = new ReferenceData<AccountDevice> ((AccountDevice)editAccount.origin.v.data);
											// show
											editAccountDevice.show.v = new ReferenceData<AccountDevice> (accountDevice);
											// compare
											editAccountDevice.compare.v = new ReferenceData<AccountDevice> ((AccountDevice)editAccount.compare.v.data);
											// compareOtherType
											editAccountDevice.compareOtherType.v = new ReferenceData<Data>(editAccount.compareOtherType.v.data);
											// canEdit
											editAccountDevice.canEdit.v = editAccount.canEdit.v;
											// editType
											editAccountDevice.editType.v = editAccount.editType.v;
										} else {
											Debug.LogError ("editAccountDevice null: " + this);
										}
									}
									this.data.sub.v = accountDeviceUIData;
									// Show Component
									{
										// avatarUrl
										{
											if (this.data.isLogin.v) {
												accountDeviceUIData.avatarUrl.v = null;
											} else {
												accountDeviceUIData.makeAvatarUrl ();
											}
										}
									}
								}
								break;
							case Account.Type.EMAIL:
								{
									AccountEmail accountEmail = show as AccountEmail;
									// UIData
									AccountEmailUI.UIData accountEmailUIData = this.data.sub.newOrOld<AccountEmailUI.UIData> ();
									{
										EditData<AccountEmail> editAccountEmail = accountEmailUIData.editAccountEmail.v;
										if (editAccountEmail != null) {
											// origin
											editAccountEmail.origin.v = new ReferenceData<AccountEmail> ((AccountEmail)editAccount.origin.v.data);
											// show
											editAccountEmail.show.v = new ReferenceData<AccountEmail> (accountEmail);
											// compare
											editAccountEmail.compare.v = new ReferenceData<AccountEmail> ((AccountEmail)editAccount.compare.v.data);
											// compareOtherType
											editAccountEmail.compareOtherType.v = new ReferenceData<Data>(editAccount.compareOtherType.v.data);
											// canEdit
											editAccountEmail.canEdit.v = editAccount.canEdit.v;
											// editType
											editAccountEmail.editType.v = editAccount.editType.v;
										} else {
											Debug.LogError ("editAccountEmail null: " + this);
										}
									}
									this.data.sub.v = accountEmailUIData;
									// type
									{
										if (this.data.isLogin.v) {
											if (accountEmailUIData.type.v == AccountEmailUI.UIData.Type.Show) {
												accountEmailUIData.type.v = AccountEmailUI.UIData.Type.Login;
											}
										} else {
											accountEmailUIData.type.v = AccountEmailUI.UIData.Type.Show;
										}
									}
								}
								break;
							case Account.Type.FACEBOOK:
								{
									AccountFacebook accountFacebook = show as AccountFacebook;
									// UIData
									AccountFacebookUI.UIData accountFacebookUIData = this.data.sub.newOrOld<AccountFacebookUI.UIData> ();
									{
										EditData<AccountFacebook> editAccountFacebook = accountFacebookUIData.editAccountFacebook.v;
										if (editAccountFacebook != null) {
											// origin
											editAccountFacebook.origin.v = new ReferenceData<AccountFacebook> ((AccountFacebook)editAccount.origin.v.data);
											// show
											editAccountFacebook.show.v = new ReferenceData<AccountFacebook> (accountFacebook);
											// compare
											editAccountFacebook.compare.v = new ReferenceData<AccountFacebook> ((AccountFacebook)editAccount.compare.v.data);
											// compareOtherType
											editAccountFacebook.compareOtherType.v = new ReferenceData<Data>(editAccount.compareOtherType.v.data);
											// canEdit
											editAccountFacebook.canEdit.v = editAccount.canEdit.v;
											// editType
											editAccountFacebook.editType.v = editAccount.editType.v;
										} else {
											Debug.LogError ("editAccountFacebook null: " + this);
										}
									}
									this.data.sub.v = accountFacebookUIData;
								}
								break;
							default:
								Debug.LogError ("unknown type: " + show.getType () + "; " + this);
								break;
							}
							// avatar
							{
								AccountAvatarUI.UIData accountAvatarUIData = this.data.accountAvatar.v;
								if (accountAvatarUIData != null) {
									accountAvatarUIData.account.v = new ReferenceData<Account> (show);
								} else {
									Debug.LogError ("accountAvatarUIData null: " + this);
								}
							}
						} else {
							Debug.LogError ("ai null: " + this);
						}
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

	public AccountAvatarUI accountAvatarPrefab;
	public Transform accountAvatarContainer;

	public AccountNoneUI accountNonePrefab;
	public AccountAdminUI accountAdminPrefab;
	public AccountDeviceUI accountDevicePrefab;
	public AccountEmailUI accountEmailPrefab;
	public AccountFacebookUI accountFacebookPrefab;

	public Transform subContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.editAccount.allAddCallBack (this);
				uiData.accountAvatar.allAddCallBack (this);
				uiData.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is EditData<Account>) {
				dirty = true;
				return;
			}
			if (data is AccountAvatarUI.UIData) {
				AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
				// UI
				{
					UIUtils.Instantiate (accountAvatarUIData, accountAvatarPrefab, accountAvatarContainer);
				}
				dirty = true;
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case Account.Type.NONE:
						{
							AccountNoneUI.UIData accountNoneUIData = sub as AccountNoneUI.UIData;
							UIUtils.Instantiate (accountNoneUIData, accountNonePrefab, subContainer);
						}
						break;
					case Account.Type.Admin:
						{
							AccountAdminUI.UIData accountAdminUIData = sub as AccountAdminUI.UIData;
							UIUtils.Instantiate (accountAdminUIData, accountAdminPrefab, subContainer);
						}
						break;
					case Account.Type.DEVICE:
						{
							AccountDeviceUI.UIData accountDeviceUIData = sub as AccountDeviceUI.UIData;
							UIUtils.Instantiate (accountDeviceUIData, accountDevicePrefab, subContainer);
						}
						break;
					case Account.Type.EMAIL:
						{
							AccountEmailUI.UIData accountEmailUIData = sub as AccountEmailUI.UIData;
							UIUtils.Instantiate (accountEmailUIData, accountEmailPrefab, subContainer);
						}
						break;
					case Account.Type.FACEBOOK:
						{
							AccountFacebookUI.UIData accountFacebookUIData = sub as AccountFacebookUI.UIData;
							UIUtils.Instantiate (accountFacebookUIData, accountFacebookPrefab, subContainer);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
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
			// Child
			{
				uiData.editAccount.allRemoveCallBack (this);
				uiData.accountAvatar.allRemoveCallBack (this);
				uiData.sub.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is EditData<Account>) {
				return;
			}
			if (data is AccountAvatarUI.UIData) {
				AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
				// UI
				{
					accountAvatarUIData.removeCallBackAndDestroy (typeof(AccountAvatarUI));
				}
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case Account.Type.NONE:
						{
							AccountNoneUI.UIData accountNoneUIData = sub as AccountNoneUI.UIData;
							accountNoneUIData.removeCallBackAndDestroy (typeof(AccountNoneUI));
						}
						break;
					case Account.Type.Admin:
						{
							AccountAdminUI.UIData accountAdminUIData = sub as AccountAdminUI.UIData;
							accountAdminUIData.removeCallBackAndDestroy (typeof(AccountAdminUI));
						}
						break;
					case Account.Type.DEVICE:
						{
							AccountDeviceUI.UIData accountDeviceUIData = sub as AccountDeviceUI.UIData;
							accountDeviceUIData.removeCallBackAndDestroy (typeof(AccountDeviceUI));
						}
						break;
					case Account.Type.EMAIL:
						{
							AccountEmailUI.UIData accountEmailUIData = sub as AccountEmailUI.UIData;
							accountEmailUIData.removeCallBackAndDestroy (typeof(AccountEmailUI));
						}
						break;
					case Account.Type.FACEBOOK:
						{
							AccountFacebookUI.UIData accountFacebookUIData = sub as AccountFacebookUI.UIData;
							accountFacebookUIData.removeCallBackAndDestroy (typeof(AccountFacebookUI));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
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
			case UIData.Property.editAccount:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.isLogin:
				dirty = true;
				break;
			case UIData.Property.accountAvatar:
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
		// Child
		{
			if (wrapProperty.p is EditData<Account>) {
				switch ((EditData<Account>.Property)wrapProperty.n) {
				case EditData<Account>.Property.origin:
					dirty = true;
					break;
				case EditData<Account>.Property.show:
					dirty = true;
					break;
				case EditData<Account>.Property.compare:
					dirty = true;
					break;
				case EditData<Account>.Property.compareOtherType:
					dirty = true;
					break;
				case EditData<Account>.Property.canEdit:
					dirty = true;
					break;
				case EditData<Account>.Property.editType:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is AccountAvatarUI.UIData) {
				return;
			}
			if (wrapProperty.p is UIData.Sub) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}