using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FriendStateChangeContentUI : UIBehavior<FriendStateChangeContentUI.UIData>
{

	#region UIData

	public class UIData : ChatMessageHolder.UIData.Sub
	{
		public VP<ReferenceData<FriendStateChangeContent>> friendStateChangeContent;

		public VP<AccountAvatarUI.UIData> avatar;

		public VP<RequestChangeStringUI.UIData> content;

		public VP<RequestChangeStringUI.UIData> time;

		#region Constructor

		public enum Property
		{
			friendStateChangeContent,
			avatar,
			content,
			time
		}

		public UIData() : base()
		{
			this.friendStateChangeContent = new VP<ReferenceData<FriendStateChangeContent>>(this, (byte)Property.friendStateChangeContent, new ReferenceData<FriendStateChangeContent>(null));
			this.avatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.avatar, new AccountAvatarUI.UIData());
			// content
			{
				this.content = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.content, new RequestChangeStringUI.UIData());
				this.content.v.updateData.v.canRequestChange.v = false;
			}
			// time
			{
				this.time = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.time, new RequestChangeStringUI.UIData());
				this.time.v.updateData.v.canRequestChange.v = false;
			}
		}

		#endregion

		public override ChatMessage.Content.Type getType ()
		{
			return ChatMessage.Content.Type.FriendStateChange;
		}

	}

	#endregion

	#region Refresh

	private Human human = null;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				FriendStateChangeContent friendStateChangeContent = this.data.friendStateChangeContent.v.data;
				if (friendStateChangeContent != null) {
					ChatMessage chatMessage = friendStateChangeContent.findDataInParent<ChatMessage> ();
					if (chatMessage != null) {
						// Find human
						{
							Human human = ChatRoom.findHuman (friendStateChangeContent, friendStateChangeContent.userId.v);
							if (this.human != human) {
								// remove old
								if (this.human != null) {
									this.human.removeCallBack (this);
								}
								// set new
								this.human = human;
								if (this.human != null) {
									this.human.addCallBack (this);
								}
							}
						}
						// Avatar
						{
							AccountAvatarUI.UIData accountAvatarUIData = this.data.avatar.v;
							if (accountAvatarUIData != null) {
								Account account = null;
								{
									if (this.human != null) {
										account = this.human.account.v;
									}
								}
								accountAvatarUIData.account.v = new ReferenceData<Account> (account);
							} else {
								Debug.LogError ("accountAvatarUIData null: " + this);
							}
						}
						// time
						{
							RequestChangeStringUI.UIData time = this.data.time.v;
							if (time != null) {
								RequestChangeStringUpdate.UpdateData updateData = time.updateData.v;
								if (updateData != null) {
									updateData.origin.v = chatMessage.TimestampAsDateTime.ToString ("HH:mm");
								} else {
									Debug.LogError ("updateData null: " + this);
								}
							} else {
								Debug.LogError ("time null: " + this);
							}
						}
						// content
						{
							RequestChangeStringUI.UIData content = this.data.content.v;
							if (content != null) {
								RequestChangeStringUpdate.UpdateData updateData = content.updateData.v;
								if (updateData != null) {
									// Find user name
									string userName = "";
									{
										if (this.human != null) {
											userName = this.human.getPlayerName ();
										} else {
											Debug.LogError ("human null: " + this);
										}
									}
									// state
									switch (friendStateChangeContent.action.v) {
									case FriendStateChangeContent.Action.Request:
										updateData.origin.v = "<color=grey>" + userName + "</color> request to make friend";
										break;
									case FriendStateChangeContent.Action.Accept:
										updateData.origin.v = "<color=grey>" + userName + "</color> accept friend request";
										break;
									case FriendStateChangeContent.Action.Refuse:
										updateData.origin.v = "<color=grey>" + userName + "</color> refuse friend request";
										break;
									case FriendStateChangeContent.Action.Cancel:
										updateData.origin.v = "<color=grey>" + userName + "</color> cancel friend request";
										break;
									case FriendStateChangeContent.Action.UnFriend:
										updateData.origin.v = "<color=grey>" + userName + "</color> unFriend";
										break;
									case FriendStateChangeContent.Action.Ban:
										updateData.origin.v = "<color=grey>" + userName + "</color> ban";
										break;
									case FriendStateChangeContent.Action.UnBan:
										updateData.origin.v = "<color=grey>" + userName + "</color> unBan";
										break;
									default:
										Debug.LogError ("unknown action: " + friendStateChangeContent.action.v + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("updateData null: " + this);
								}
							} else {
								Debug.LogError ("content null: " + this);
							}
						}
					} else {
						Debug.LogError ("chatMessage null: " + this);
					}
				} else {
					Debug.LogError ("friendStateChangeContent null: " + this);
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

	public override void OnDestroy ()
	{
		base.OnDestroy ();
		if (this.human != null) {
			this.human.removeCallBack (this);
			this.human = null;
		} else {
			Debug.LogError ("human null: " + this);
		}
	}

	#endregion

	#region implement callBacks

	private ChatMessage chatMessage = null;

	public AccountAvatarUI avatarPrefab;
	public RequestChangeStringUI requestStringPrefab;

	public Transform avatarContainer;
	public Transform contentContainer;
	public Transform timeContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.friendStateChangeContent.allAddCallBack (this);
				uiData.avatar.allAddCallBack (this);
				uiData.content.allAddCallBack (this);
				uiData.time.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// FriendStateChangeContent
			{
				if (data is FriendStateChangeContent) {
					FriendStateChangeContent friendStateChangeContent = data as FriendStateChangeContent;
					// Parent
					{
						DataUtils.addParentCallBack (friendStateChangeContent, this, ref this.chatMessage);
					}
					dirty = true;
					return;
				}
				// Parent
				{
					if (data is ChatMessage) {
						dirty = true;
						return;
					}
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
						// child
						if (data is Account) {
							dirty = true;
							return;
						}
					}
				}
			}
			if (data is AccountAvatarUI.UIData) {
				AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
				// UI
				{
					UIUtils.Instantiate (accountAvatarUIData, avatarPrefab, avatarContainer);
				}
				dirty = true;
				return;
			}
			// content, time
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.content:
							UIUtils.Instantiate (requestChange, requestStringPrefab, contentContainer);
							break;
						case UIData.Property.time:
							UIUtils.Instantiate (requestChange, requestStringPrefab, timeContainer);
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
			// Child
			{
				uiData.friendStateChangeContent.allRemoveCallBack (this);
				uiData.avatar.allRemoveCallBack (this);
				uiData.content.allRemoveCallBack (this);
				uiData.time.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			// FriendStateChangeContent
			{
				if (data is FriendStateChangeContent) {
					FriendStateChangeContent friendStateChangeContent = data as FriendStateChangeContent;
					// Parent
					{
						DataUtils.removeParentCallBack (friendStateChangeContent, this, ref this.chatMessage);
					}
					return;
				}
				// Parent
				{
					if (data is ChatMessage) {
						return;
					}
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
						// child
						if (data is Account) {
							return;
						}
					}
				}
			}
			if (data is AccountAvatarUI.UIData) {
				AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
				// UI
				{
					accountAvatarUIData.removeCallBackAndDestroy (typeof(AccountAvatarUI));
				}
				return;
			}
			// content, time
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
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.friendStateChangeContent:
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
			case UIData.Property.content:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.time:
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
			// FriendStateChangeContent
			{
				if (wrapProperty.p is FriendStateChangeContent) {
					switch ((FriendStateChangeContent.Property)wrapProperty.n) {
					case FriendStateChangeContent.Property.userId:
						dirty = true;
						break;
					case FriendStateChangeContent.Property.action:
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
					if (wrapProperty.p is ChatMessage) {
						switch ((ChatMessage.Property)wrapProperty.n) {
						case ChatMessage.Property.state:
							dirty = true;
							break;
						case ChatMessage.Property.time:
							dirty = true;
							break;
						case ChatMessage.Property.content:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
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
							case Human.Property.ban:
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// child
						if (wrapProperty.p is Account) {
							Account.OnUpdateSyncAccount (wrapProperty, this);
							return;
						}
					}
				}
			}
			if (wrapProperty.p is AccountAvatarUI.UIData) {
				return;
			}
			// content, time
			if (wrapProperty.p is RequestChangeStringUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't prococess: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}