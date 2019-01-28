﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChatNormalContentUI : UIBehavior<ChatNormalContentUI.UIData>
{

	#region UIData

	public class UIData : ChatMessageHolder.UIData.Sub
	{

		public VP<ReferenceData<ChatNormalContent>> chatNormalContent;

		public VP<AccountAvatarUI.UIData> avatar;

		#region Constructor

		public enum Property
		{
			chatNormalContent,
			avatar
		}

		public UIData() : base()
		{
			this.chatNormalContent = new VP<ReferenceData<ChatNormalContent>>(this, (byte)Property.chatNormalContent, new ReferenceData<ChatNormalContent>(null));
			// avatar
			this.avatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.avatar, new AccountAvatarUI.UIData());
		}

		#endregion

		public override ChatMessage.Content.Type getType ()
		{
			return ChatMessage.Content.Type.Normal;
		}

	}

	#endregion
	
	#region Refresh

	public Text tvMessage;

	public Button btnMenu;

	private Human humanOwner = null;

	public Text tvName;
	public Text tvTime;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				ChatNormalContent chatNormalContent = this.data.chatNormalContent.v.data;
				if (chatNormalContent != null) {
					ChatMessage chatMessage = chatNormalContent.findDataInParent<ChatMessage> ();
					if (chatMessage != null) {
						// find human owner
						{
							
							Human humanOwner = ChatRoom.findHuman (chatNormalContent, chatNormalContent.owner.v);
							if (this.humanOwner != humanOwner) {
								// remove old
								if (this.humanOwner != null) {
									this.humanOwner.removeCallBack (this);
								}
								// set new
								this.humanOwner = humanOwner;
								if (this.humanOwner != null) {
									this.humanOwner.addCallBack (this);
								}
							}
						}
						// Name
						{
							if (tvName != null) {
								string strName = "";
								{
									if (humanOwner != null) {
										strName = humanOwner.getPlayerName ();
									} else {
										Debug.LogError ("human null");
									}
								}
								tvName.text = strName;
							} else {
								Debug.LogError ("tvName null");
							}
						}
						// Message
						{
							if (tvMessage != null) {
								switch (chatMessage.state.v) {
								case ChatMessage.State.Normal:
									{
										string message = "";
										{
											if (chatNormalContent.messages.vs.Count > 0) {
												ChatNormalContent.Message contentMessage = chatNormalContent.messages.vs [chatNormalContent.messages.vs.Count - 1];
												message = contentMessage.message;
											}
										}
										tvMessage.text = message;
									}
									break;
								case ChatMessage.State.Delete:
									{
										// TODO co the cho in nghieng nua
										tvMessage.text = "<color=grey>this message has been deleted</color>";
									}
									break;
								case ChatMessage.State.TrueDelete:
									{
										tvMessage.text = "<color=red>this message has been removed</color>";
									}
									break;
								default:
									Debug.LogError ("unknown state: " + chatMessage.state.v + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("tvMessage null: " + this);
							}
						}
						// Time
						{
							if (tvTime != null) {
								tvTime.text = chatMessage.TimestampAsDateTime.ToString ("HH:mm");
							} else {
								Debug.LogError ("tvTime null");
							}
						}
						// Avatar
						{
							AccountAvatarUI.UIData accountAvatarUIData = this.data.avatar.v;
							if (accountAvatarUIData != null) {
								Account account = null;
								{
									if (this.humanOwner != null) {
										account = this.humanOwner.account.v;
									}
								}
								accountAvatarUIData.account.v = new ReferenceData<Account> (account);
							} else {
								Debug.LogError ("accountAvatarUIData null: " + this);
							}
						}
						// btnMenu
						{
							if (btnMenu != null) {
								if (Server.getProfileUserId(chatNormalContent)==chatNormalContent.owner.v) {
									btnMenu.gameObject.SetActive (true);
								} else {
									btnMenu.gameObject.SetActive (false);
								}
							} else {
								Debug.LogError ("btnMenu null: " + this);
							}
						}
						// Color
						{
							Image image = this.GetComponent<Image> ();
							if (image != null) {
								int index = 0;
								{
									ChatMessageHolder.UIData holder = this.data.findDataInParent<ChatMessageHolder.UIData> ();
									if (holder != null) {
										index = holder.ItemIndex;
									} else {
										Debug.LogError ("holder null: " + this);
									}
								}
								switch (index % 2) {
								case 0:
									image.color = new Color (.75f, 1f, 1f, 0.5f);
									break;
								case 1:
									image.color = new Color (.75f, 1f, 1f, 1);
									break;
								}
							} else {
								Debug.LogError ("image null: " + this);
							}
						}
					} else {
						Debug.LogError ("chatMessage null: " + this);
					}
				} else {
					// Debug.LogError ("chatNormalContent null: " + this);
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

	public override void OnDestroy ()
	{
		base.OnDestroy ();
		if (this.humanOwner != null) {
			this.humanOwner.removeCallBack (this);
			this.humanOwner = null;
		} else {
			// Debug.LogError ("human owner null: " + this);
		}
	}
		
	#endregion

	#region implement callBacks

	private ChatMessage chatMessage = null;

	public AccountAvatarUI avatarPrefab;

	public Transform avatarContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.chatNormalContent.allAddCallBack (this);
				uiData.avatar.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// ChatNormalContent
			{
				if (data is ChatNormalContent) {
					ChatNormalContent chatNormalContent = data as ChatNormalContent;
					// Parent
					{
						DataUtils.addParentCallBack (chatNormalContent, this, ref this.chatMessage);
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
						// Child
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
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.chatNormalContent.allRemoveCallBack(this);
				uiData.avatar.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			// ChatNormalContent
			{
				if (data is ChatNormalContent) {
					ChatNormalContent chatNormalContent = data as ChatNormalContent;
					// Parent
					{
						DataUtils.removeParentCallBack (chatNormalContent, this, ref this.chatMessage);
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
						// Child
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
			case UIData.Property.chatNormalContent:
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
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			// ChatNormalContent
			{
				if (wrapProperty.p is ChatNormalContent) {
					switch ((ChatNormalContent.Property)wrapProperty.n) {
					case ChatNormalContent.Property.owner:
						dirty = true;
						break;
					case ChatNormalContent.Property.messages:
						dirty = true;
						break;
					case ChatNormalContent.Property.editMax:
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
						// Child
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
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnMenu()
	{
		if (this.data != null) {
			ChatNormalContent chatNormalContent = this.data.chatNormalContent.v.data;
			if (chatNormalContent != null) {
				if (chatNormalContent.isMine ()) {
					ChatMessage chatMessage = chatNormalContent.findDataInParent<ChatMessage> ();
					if (chatMessage != null) {
						ChatRoomUI.UIData chatRoomUIData = this.data.findDataInParent<ChatRoomUI.UIData> ();
						if (chatRoomUIData != null) {
							ChatMessageMenuUI.UIData chatMessageMenuUIData = chatRoomUIData.chatMessageMenu.newOrOld<ChatMessageMenuUI.UIData> ();
							{
								chatMessageMenuUIData.chatMessage.v = new ReferenceData<ChatMessage> (chatMessage);
							}
							chatRoomUIData.chatMessageMenu.v = chatMessageMenuUIData;
						} else {
							Debug.LogError ("chatRoomUIData null: " + this);
						}
					} else {
						Debug.LogError ("chatMessage null: " + this);
					}
				} else {
					Debug.LogError ("not your message: " + this);
				}
			} else {
				Debug.LogError ("chatNormalContent null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}