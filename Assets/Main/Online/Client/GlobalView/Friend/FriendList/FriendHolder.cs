using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

public class FriendHolder : SriaHolderBehavior<FriendHolder.UIData>
{

	#region UIData

	public class UIData : BaseItemViewsHolder
	{
		
		public VP<ReferenceData<Friend>> friend;

		#region StateUI

		public VP<FriendStateUI.UIData> friendStateUIData;

		#endregion

		public VP<AccountAvatarUI.UIData> accountAvatar;

		public VP<RequestChangeStringUI.UIData> name;

		public VP<RequestChangeStringUI.UIData> status;

		public VP<RequestChangeStringUI.UIData> birthday;

		public VP<RequestChangeEnumUI.UIData> sex;

		public VP<NewChatMessageNumberUI.UIData> newChatMessageNumber;

		#region Constructor

		public enum Property
		{
			friend,
			friendStateUIData,
			accountAvatar,
			name,
			status,
			birthday,
			sex,
			newChatMessageNumber
		}

		public UIData() : base()
		{
			this.friend = new VP<ReferenceData<Friend>>(this, (byte)Property.friend, new ReferenceData<Friend>(null));
			this.accountAvatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.accountAvatar, new AccountAvatarUI.UIData());
			this.friendStateUIData = new VP<FriendStateUI.UIData>(this, (byte)Property.friendStateUIData, new FriendStateUI.UIData());
			// name
			{
				this.name = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.name, new RequestChangeStringUI.UIData());
				this.name.v.updateData.v.canRequestChange.v = false;
			}
			// status
			{
				this.status = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.status, new RequestChangeStringUI.UIData());
				this.status.v.updateData.v.canRequestChange.v = false;
			}
			// birthday
			{
				this.birthday = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.birthday, new RequestChangeStringUI.UIData());
				this.birthday.v.updateData.v.canRequestChange.v = false;
			}
			// sex
			{
				this.sex = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.sex, new RequestChangeEnumUI.UIData());
				this.sex.v.updateData.v.canRequestChange.v = false;
				// options
				foreach(User.SEX type in System.Enum.GetValues(typeof(User.SEX))){
					this.sex.v.options.add(type.ToString());
				}
			}
			this.newChatMessageNumber = new VP<NewChatMessageNumberUI.UIData>(this, (byte)Property.newChatMessageNumber, new NewChatMessageNumberUI.UIData());
		}

		#endregion

		public void updateView(FriendAdapter.UIData myParams)
		{
			// Find
			Friend friend = null;
			{
				if (ItemIndex >= 0 && ItemIndex < myParams.friends.Count) {
					friend = myParams.friends [ItemIndex];
				} else {
					Debug.LogError ("ItemIdex error: " + this);
				}
			}
			// Update
			this.friend.v = new ReferenceData<Friend> (friend);
		}
	}

	#endregion

	#region Refresh

	#region txt

	public Text tvViewDetail;
	public static readonly TxtLanguage txtViewDetail = new TxtLanguage ();

	static FriendHolder()
	{
		txtViewDetail.add (Language.Type.vi, "Xem chi tiết");
	}

	#endregion

	public override void refresh ()
	{
		base.refresh ();
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Friend friend = this.data.friend.v.data;
				if (friend != null) {
					// stateUIData
					{
						FriendStateUI.UIData stateUIData = this.data.friendStateUIData.v;
						if (stateUIData != null) {
							stateUIData.friend.v = new ReferenceData<Friend> (friend);
						} else {
							Debug.LogError ("stateUIData null: " + this);
						}
					}
					// Human
					{
						// Find
						Human human = null;
						{
							uint profileId = Server.getProfileUserId (friend);
							if (friend.user1.v.playerId.v != profileId) {
								human = friend.user1.v;
							}
							if (friend.user2.v.playerId.v != profileId) {
								human = friend.user2.v;
							}
						}
						// Process
						if (human != null) {
							// accountAvatar
							{
								AccountAvatarUI.UIData accountAvatarUIData = this.data.accountAvatar.v;
								if (accountAvatarUIData != null) {
									accountAvatarUIData.account.v = new ReferenceData<Account> (human.account.v);
								} else {
									Debug.LogError ("accountAvatarUIData null: " + this);
								}
							}
							// name
							{
								RequestChangeStringUI.UIData name = this.data.name.v;
								if (name != null) {
									RequestChangeStringUpdate.UpdateData updateData = name.updateData.v;
									if (updateData != null) {
										updateData.origin.v = "Name: " + human.account.v.getName ();
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("name null: " + this);
								}
							}
							// status
							{
								RequestChangeStringUI.UIData status = this.data.status.v;
								if (status != null) {
									RequestChangeStringUpdate.UpdateData updateData = status.updateData.v;
									if (updateData != null) {
										updateData.origin.v = "Status: " + human.status.v;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("status null: " + this);
								}
							}
							// birthday
							{
								RequestChangeStringUI.UIData birthday = this.data.birthday.v;
								if (birthday != null) {
									RequestChangeStringUpdate.UpdateData updateData = birthday.updateData.v;
									if (updateData != null) {
										updateData.origin.v = "Birthday: " + human.birthday.v;
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
									RequestChangeIntUpdate.UpdateData updateData = sex.updateData.v;
									if (updateData != null) {
										updateData.origin.v = (int)human.sex.v;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("sex null: " + this);
								}
							}
						} else {
							Debug.LogError ("human null: " + this);
						}
					}
					// newChatMessageNumber
					{
						NewChatMessageNumberUI.UIData newChatMessageNumber = this.data.newChatMessageNumber.v;
						if (newChatMessageNumber != null) {
							newChatMessageNumber.chatRoom.v = new ReferenceData<ChatRoom> (friend.chatRoom.v);
						} else {
							Debug.LogError ("newChatMessageNumber null: " + this);
						}
					}
				} else {
					Debug.LogError ("friend null: " + this);
				}
				// txt
				{
					if (tvViewDetail != null) {
						tvViewDetail.text = txtViewDetail.get ("View Detail");
					} else {
						Debug.LogError ("tvViewDetail null: " + this);
					}
				}
			} else {
				// Debug.LogError ("data null: " + this);
			}
		}
	}

	#endregion

	#region implement callBacks

	public FriendStateUI friendStatePrefab;

	public AccountAvatarUI accountAvatarPrefab;

	public RequestChangeStringUI requestStringPrefab;
	public RequestChangeEnumUI requestEnumPrefab;
	public NewChatMessageNumberUI newChatMessageNumberPrefab;

	public Transform friendStateContainer;
	public Transform accountAvatarContainer;
	public Transform nameContainer;
	public Transform statusContainer;
	public Transform birthdayContainer;
	public Transform sexContainer;
	public Transform newChatMessageNumberContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.friend.allAddCallBack (this);
				uiData.friendStateUIData.allAddCallBack (this);
				uiData.accountAvatar.allAddCallBack (this);
				uiData.name.allAddCallBack (this);
				uiData.status.allAddCallBack (this);
				uiData.birthday.allAddCallBack (this);
				uiData.sex.allAddCallBack (this);
				uiData.newChatMessageNumber.allAddCallBack (this);
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
			// Friend
			{
				if (data is Friend) {
					Friend friend = data as Friend;
					// Child
					{
						friend.user1.allAddCallBack (this);
						friend.user2.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
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
			}
			// friendStateUIData
			if (data is FriendStateUI.UIData) {
				FriendStateUI.UIData friendStateUIData = data as FriendStateUI.UIData;
				// UI
				{
					UIUtils.Instantiate (friendStateUIData, friendStatePrefab, friendStateContainer);
				}
				dirty = true;
				return;
			}
			// accountAvatar
			if (data is AccountAvatarUI.UIData) {
				AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
				// UI
				{
					UIUtils.Instantiate (accountAvatarUIData, accountAvatarPrefab, accountAvatarContainer);
				}
				dirty = true;
				return;
			}
			// name, status, birthday
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.name:
							UIUtils.Instantiate (requestChange, requestStringPrefab, nameContainer);
							break;
						case UIData.Property.status:
							UIUtils.Instantiate (requestChange, requestStringPrefab, statusContainer);
							break;
						case UIData.Property.birthday:
							UIUtils.Instantiate (requestChange, requestStringPrefab, birthdayContainer);
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
							UIUtils.Instantiate (requestChange, requestEnumPrefab, sexContainer);
							break;
						}
					} else {
						Debug.LogError ("wrapProperty null: " + this);
					}
				}
				dirty = true;
				return;
			}
			// newChatMessageNumber
			if (data is NewChatMessageNumberUI.UIData) {
				NewChatMessageNumberUI.UIData newChatMessageNumberUIData = data as NewChatMessageNumberUI.UIData;
				// UI
				{
					UIUtils.Instantiate (newChatMessageNumberUIData, newChatMessageNumberPrefab, newChatMessageNumberContainer);
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
				uiData.friend.allRemoveCallBack (this);
				uiData.friendStateUIData.allRemoveCallBack (this);
				uiData.accountAvatar.allRemoveCallBack (this);
				uiData.name.allRemoveCallBack (this);
				uiData.status.allRemoveCallBack (this);
				uiData.birthday.allRemoveCallBack (this);
				uiData.sex.allRemoveCallBack (this);
				uiData.newChatMessageNumber.allRemoveCallBack (this);
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
			// Friend
			{
				if (data is Friend) {
					Friend friend = data as Friend;
					// Child
					{
						friend.user1.allRemoveCallBack (this);
						friend.user2.allRemoveCallBack (this);
					}
					return;
				}
				// Child
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
			}
			// friendStateUIData
			if (data is FriendStateUI.UIData) {
				FriendStateUI.UIData friendStateUIData = data as FriendStateUI.UIData;
				// UI
				{
					friendStateUIData.removeCallBackAndDestroy (typeof(FriendStateUI));
				}
				return;
			}
			// accountAvatar
			if (data is AccountAvatarUI.UIData) {
				AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
				// UI
				{
					accountAvatarUIData.removeCallBackAndDestroy (typeof(AccountAvatarUI));
				}
				return;
			}
			// name, status, birthday
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeStringUI));
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
			// newChatMessageNumber
			if (data is NewChatMessageNumberUI.UIData) {
				NewChatMessageNumberUI.UIData newChatMessageNumberUIData = data as NewChatMessageNumberUI.UIData;
				// UI
				{
					newChatMessageNumberUIData.removeCallBackAndDestroy (typeof(NewChatMessageNumberUI));
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
			case UIData.Property.friend:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.friendStateUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.accountAvatar:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.name:
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
			case UIData.Property.newChatMessageNumber:
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
			// Friend
			{
				if (wrapProperty.p is Friend) {
					switch ((Friend.Property)wrapProperty.n) {
					case Friend.Property.state:
						dirty = true;
						break;
					case Friend.Property.user1:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case Friend.Property.user2:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case Friend.Property.time:
						dirty = true;
						break;
					case Friend.Property.chatRoom:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
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
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			// friendStateUIData
			if (wrapProperty.p is FriendStateUI.UIData) {
				return;
			}
			// accountAvatar
			if (wrapProperty.p is AccountAvatarUI.UIData) {
				return;
			}
			// name, status, birthday
			if (wrapProperty.p is RequestChangeStringUI.UIData) {
				return;
			}
			// sex
			if (wrapProperty.p is RequestChangeEnumUI.UIData) {
				return;
			}
			// newChatMessageNumber
			if (wrapProperty.p is NewChatMessageNumberUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnViewDetail()
	{
		if (this.data != null) {
			Friend friend = this.data.friend.v.data;
			if (friend != null) {
				GlobalFriendsUI.UIData globalFriendsUIData = this.data.findDataInParent<GlobalFriendsUI.UIData> ();
				if (globalFriendsUIData != null) {
					FriendDetailUI.UIData friendDetailUIData = globalFriendsUIData.friendDetail.newOrOld<FriendDetailUI.UIData> ();
					{
						friendDetailUIData.friend.v = new ReferenceData<Friend> (friend);
					}
					globalFriendsUIData.friendDetail.v = friendDetailUIData;
				} else {
					Debug.LogError ("globalFriendsUIData null: " + this);
				}
			} else {
				Debug.LogError ("friend null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}