using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using UnityImageLoader;

public class LimitRoomContainerUserHolder : SriaHolderBehavior<LimitRoomContainerUserHolder.UIData>
{

	#region UIData

	public class UIData : BaseItemViewsHolder
	{
		
		public VP<ReferenceData<Human>> human;

		public VP<AccountAvatarUI.UIData> avatar;

		#region Constructor

		public enum Property
		{
			human,
			avatar
		}

		public UIData() : base()
		{
			this.human = new VP<ReferenceData<Human>>(this, (byte)Property.human, new ReferenceData<Human>(null));
			this.avatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.avatar, new AccountAvatarUI.UIData());
		}

		#endregion

		public void updateView(LimitRoomContainerUserAdapter.UIData myParams)
		{
			// Find
			Human human = null;
			{
				if (ItemIndex >= 0 && ItemIndex < myParams.humans.Count) {
					human = myParams.humans [ItemIndex];
				} else {
					Debug.LogError ("ItemIdex error: " + this);
				}
			}
			// Update
			this.human.v = new ReferenceData<Human> (human);
		}

	}

	#endregion

	#region Refresh

	public Text tvId;
	public Text tvName;

	public override void refresh ()
	{
		base.refresh ();
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Human human = this.data.human.v.data;
				if (human != null) {
					// avatar
					{
						AccountAvatarUI.UIData accountAvatarUIData = this.data.avatar.v;
						if (accountAvatarUIData != null) {
							accountAvatarUIData.account.v = new ReferenceData<Account> (human.account.v);
						} else {
							Debug.LogError ("accountAvatarUIData null: " + this);
						}
					}
					// id
					{
						if (tvId != null) {
							tvId.text = "Id: " + human.playerId.v;
						} else {
							Debug.LogError ("tvId null");
						}
					}
					// name
					{
						if (tvName != null) {
							tvName.text = human.getPlayerName ();
						} else {
							Debug.LogError ("tvName null");
						}
					}
				} else {
					Debug.Log ("user null: " + this);
				}
			} else {
				Debug.Log ("data null: " + this);
			}
		}
	}

	#endregion

	#region implement Change

	public Transform avatarContainer;
	public AccountAvatarUI avatarPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.human.allAddCallBack (this);
				uiData.avatar.allAddCallBack (this);
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
			// Human
			{
				if (data is Human) {
					Human human = data as Human;
					// Child
					{
						human.account.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is Account) {
					dirty = true;
					return;
				}
			}
			// Avatar
			if (data is AccountAvatarUI.UIData) {
				AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
				// UI
				{
					UIUtils.Instantiate (accountAvatarUIData, avatarPrefab, avatarContainer);
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
				uiData.human.allRemoveCallBack (this);
				uiData.avatar.allRemoveCallBack (this);
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
			// Human
			{
				if (data is Human) {
					Human human = data as Human;
					// Child
					{
						human.account.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is Account) {
					return;
				}
			}
			// Avatar
			if (data is AccountAvatarUI.UIData) {
				AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
				// UI
				{
					accountAvatarUIData.removeCallBackAndDestroy (typeof(AccountAvatarUI));
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
			case UIData.Property.human:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.avatar:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
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
			// Human
			{
				if (wrapProperty.p is Human) {
					switch ((Human.Property)wrapProperty.n) {
					case Human.Property.playerId:
						dirty = true;
						break;
					case Human.Property.account:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case Human.Property.state:
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
				// Child
				if (wrapProperty.p is Account) {
					Account.OnUpdateSyncAccount (wrapProperty, this);
					return;
				}
			}
			// Avatar
			if (wrapProperty.p is AccountAvatarUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}