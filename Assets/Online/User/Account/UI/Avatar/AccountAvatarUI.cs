using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AccountAvatarUI : UIBehavior<AccountAvatarUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<Account>> account;

		#region Constructor

		public enum Property
		{
			account
		}

		public UIData() : base()
		{
			this.account = new VP<ReferenceData<Account>>(this, (byte)Property.account, new ReferenceData<Account>(null));
		}

		#endregion

	}

	#endregion

	#region Refresh

	public Sprite defaultNone;
	public Sprite defaultAdmin;
	public Sprite defaultDevice;
	public Sprite defaultEmail;
	public Sprite defaultFacebook;

	public Sprite loadingSprite;

	public UrlImage ivAvatar;

	#region ivType

	public Sprite noneType;
	public Sprite adminType;
	public Sprite deviceType;
	public Sprite emailType;
	public Sprite facebookType;

	public UrlImage ivType;

	#endregion

	#region connect state

	public UrlImage ivConnectState;

	public Sprite stateOnline;
	public Sprite stateOffline;
	public Sprite stateDisconnect;

	#endregion

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Account account = this.data.account.v.data;
				if (account != null) {
					// ivAvatar
					if (ivAvatar != null) {
						switch (account.getType ()) {
						case Account.Type.NONE:
							ivAvatar.setUrl (account.getAvatarUrl(), loadingSprite, defaultNone);
							break;
						case Account.Type.Admin:
							ivAvatar.setUrl (account.getAvatarUrl(), loadingSprite, defaultAdmin);
							break;
						case Account.Type.DEVICE:
							ivAvatar.setUrl (account.getAvatarUrl(), loadingSprite, defaultDevice);
							break;
						case Account.Type.EMAIL:
							ivAvatar.setUrl (account.getAvatarUrl(), loadingSprite, defaultEmail);
							break;
						case Account.Type.FACEBOOK:
							ivAvatar.setUrl (account.getAvatarUrl(), loadingSprite, defaultFacebook);
							break;
						default:
							Debug.LogError ("unknown type: " + account.getType () + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("ivAvatar null: " + this);
					}
					// ivType
					if (ivType != null) {
						switch (account.getType ()) {
						case Account.Type.NONE:
							ivType.image.sprite = noneType;
							break;
						case Account.Type.Admin:
							ivType.image.sprite = adminType;
							break;
						case Account.Type.DEVICE:
							ivType.image.sprite = deviceType;
							break;
						case Account.Type.EMAIL:
							ivType.image.sprite = emailType;
							break;
						case Account.Type.FACEBOOK:
							ivType.image.sprite = facebookType;
							break;
						default:
							Debug.LogError ("unknown type: " + account.getType () + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("ivType null: " + this);
					}
					// ivConnectState
					if (ivConnectState != null) {
						UserState.State state = UserState.State.Online;
						// Find
						{
							Human human = account.findDataInParent<Human> ();
							if (human != null) {
								if (human.state.v != null) {
									state = human.state.v.state.v;
								} else {
									Debug.LogError ("state null: " + this);
								}
							} else {
								Debug.LogError ("human null: " + this);
							}
						}
						// Process
						switch (state) {
						case UserState.State.Online:
							ivConnectState.setUrl ("", null, stateOnline);
							break;
						case UserState.State.Disconnect:
							ivConnectState.setUrl ("", null, stateDisconnect);
							break;
						case UserState.State.Offline:
							ivConnectState.setUrl ("", null, stateOffline);
							break;
						default:
							Debug.LogError ("unknown state: " + state + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("ivConnectState null: " + this);
					}
				} else {
					// Debug.LogError ("account null: " + this);
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

	private Human human = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.account.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is Account) {
				Account account = data as Account;
				// Parent
				{
					DataUtils.addParentCallBack (account, this, ref this.human);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is Human) {
					Human human = data as Human;
					// Child
					{
						human.state.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is UserState) {
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
			// Child
			{
				uiData.account.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is Account) {
				Account account = data as Account;
				// Parent
				{
					DataUtils.addParentCallBack (account, this, ref this.human);
				}
				return;
			}
			// Parent
			if (data is Human) {
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
			case UIData.Property.account:
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
			if (wrapProperty.p is Account) {
				Account.OnUpdateSyncAccount (wrapProperty, this);
				return;
			}
			// Parent
			{
				if (wrapProperty.p is Human) {
					switch ((Human.Property)wrapProperty.n) {
					case Human.Property.playerId:
						break;
					case Human.Property.account:
						break;
					case Human.Property.state:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case Human.Property.email:
						break;
					case Human.Property.phoneNumber:
						break;
					case Human.Property.status:
						break;
					case Human.Property.birthday:
						break;
					case Human.Property.sex:
						break;
					case Human.Property.connection:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is UserState) {
					switch ((UserState.Property)wrapProperty.n) {
					case UserState.Property.state:
						dirty = true;
						break;
					case UserState.Property.hide:
						dirty = true;
						break;
					case UserState.Property.time:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
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