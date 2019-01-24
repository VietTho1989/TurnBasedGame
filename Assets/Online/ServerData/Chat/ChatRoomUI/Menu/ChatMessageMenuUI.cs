using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChatMessageMenuUI : UIBehavior<ChatMessageMenuUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<ChatMessage>> chatMessage;

		public VP<ChatMessageDeleteUI.UIData> btnDelete;

		public VP<ChatMessageEditUI.UIData> edit;

		#region Constructor

		public enum Property
		{
			chatMessage,
			btnDelete,
			edit
		}

		public UIData() : base()
		{
			this.chatMessage = new VP<ReferenceData<ChatMessage>>(this, (byte)Property.chatMessage, new ReferenceData<ChatMessage>(null));
			this.btnDelete = new VP<ChatMessageDeleteUI.UIData>(this, (byte)Property.btnDelete, new ChatMessageDeleteUI.UIData());
			this.edit = new VP<ChatMessageEditUI.UIData>(this, (byte)Property.edit, null);
		}

		#endregion

		public void reset()
		{
			this.edit.v = null;
		}

		public bool processEvent(Event e)
		{
			Debug.LogError ("processEvent: " + e + "; " + this);
			bool isProcess = false;
			{
				// edit
				if (!isProcess) {
					ChatMessageEditUI.UIData edit = this.edit.v;
					if (edit != null) {
						isProcess = edit.processEvent (e);
					} else {
						Debug.LogError ("edit null: " + this);
					}
				}
				// back
				if (!isProcess) {
					if (InputEvent.isBackEvent (e)) {
						ChatMessageMenuUI chatMessageMenuUI = this.findCallBack<ChatMessageMenuUI> ();
						if (chatMessageMenuUI != null) {
							chatMessageMenuUI.onClickBtnBack ();
						} else {
							Debug.LogError ("chatMessageMenuUI null: " + this);
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

	public Text tvBack;
	public static readonly TxtLanguage txtBack = new TxtLanguage();

	public Text tvEdit;
	public static readonly TxtLanguage txtEdit = new TxtLanguage();

	static ChatMessageMenuUI()
	{
		txtBack.add (Language.Type.vi, "Quay Lại");
		txtEdit.add (Language.Type.vi, "Chỉnh Sửa");
	}

	#endregion

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				ChatMessage chatMessage = this.data.chatMessage.v.data;
				if (chatMessage != null) {
					// isYourMessage
					{
						// find isYourMessage
						bool isYourMessage = false;
						{
							ChatMessage.Content content = chatMessage.content.v;
							if (content != null) {
								switch (content.getType ()) {
								case ChatMessage.Content.Type.Normal:
									{
										ChatNormalContent chatNormalContent = content as ChatNormalContent;
										if (chatNormalContent.isMine ()) {
											isYourMessage = true;
										}
									}
									break;
								case ChatMessage.Content.Type.UserAction:
									break;
								case ChatMessage.Content.Type.RoomUserState:
									break;
								case ChatMessage.Content.Type.FriendStateChange:
									break;
								case ChatMessage.Content.Type.GameMove:
									break;
								default:
									Debug.LogError ("unknown type: " + content.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("content null: " + this);
							}
						}
						// process
						if (isYourMessage) {
							// btnDelete
							{
								ChatMessageDeleteUI.UIData btnDelete = this.data.btnDelete.v;
								if (btnDelete != null) {
									btnDelete.chatMessage.v = new ReferenceData<ChatMessage> (chatMessage);
								} else {
									Debug.LogError ("btnDelete null: " + this);
								}
							}
						} else {
							this.onClickBtnBack ();
						}
					}
					// edit
					{
						ChatMessageEditUI.UIData edit = this.data.edit.v;
						if (edit != null) {
							edit.chatMessage.v = new ReferenceData<ChatMessage> (chatMessage);
						} else {
							Debug.LogError ("edit null: " + this);
						}
					}
				} else {
					Debug.LogError ("chatMessage null: " + this);
					this.onClickBtnBack ();
				}
				// txt
				{
					if (tvBack != null) {
						tvBack.text = txtBack.get ("Back");
					} else {
						Debug.LogError ("tvBack null: " + this);
					}
					if (tvEdit != null) {
						tvEdit.text = txtEdit.get ("Edit");
					} else {
						Debug.LogError ("tvEdit null: " + this);
					}
				}
			} else {
				Debug.LogError ("data null");
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public ChatMessageDeleteUI btnDeletePrefab;
	public Transform btnDeleteContainer;

	public ChatMessageEditUI editPrefab;
	public Transform editContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.chatMessage.allAddCallBack (this);
				uiData.btnDelete.allAddCallBack (this);
				uiData.edit.allAddCallBack (this);
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
			// chatMessage
			{
				if (data is ChatMessage) {
					ChatMessage chatMessage = data as ChatMessage;
					// reset
					{
						if (this.data != null) {
							this.data.reset ();
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
					// Child
					{
						chatMessage.content.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is ChatMessage.Content) {
					dirty = true;
					return;
				}
			}
			if (data is ChatMessageDeleteUI.UIData) {
				ChatMessageDeleteUI.UIData btnDelete = data as ChatMessageDeleteUI.UIData;
				// UI
				{
					UIUtils.Instantiate (btnDelete, btnDeletePrefab, btnDeleteContainer);
				}
				dirty = true;
				return;
			}
			if (data is ChatMessageEditUI.UIData) {
				ChatMessageEditUI.UIData edit = data as ChatMessageEditUI.UIData;
				// UI
				{
					UIUtils.Instantiate (edit, editPrefab, editContainer);
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
				uiData.chatMessage.allRemoveCallBack (this);
				uiData.btnDelete.allRemoveCallBack (this);
				uiData.edit.allRemoveCallBack (this);
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
			// chatMessage
			{
				if (data is ChatMessage) {
					ChatMessage chatMessage = data as ChatMessage;
					// Child
					{
						chatMessage.content.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is ChatMessage.Content) {
					return;
				}
			}
			if (data is ChatMessageDeleteUI.UIData) {
				ChatMessageDeleteUI.UIData btnDelete = data as ChatMessageDeleteUI.UIData;
				// UI
				{
					btnDelete.removeCallBackAndDestroy (typeof(ChatMessageDeleteUI));
				}
				return;
			}
			if (data is ChatMessageEditUI.UIData) {
				ChatMessageEditUI.UIData edit = data as ChatMessageEditUI.UIData;
				// UI
				{
					edit.removeCallBackAndDestroy (typeof(ChatMessageEditUI));
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
			case UIData.Property.chatMessage:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.btnDelete:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.edit:
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
			// chatMessage
			{
				if (wrapProperty.p is ChatMessage) {
					switch ((ChatMessage.Property)wrapProperty.n) {
					case ChatMessage.Property.state:
						break;
					case ChatMessage.Property.time:
						break;
					case ChatMessage.Property.content:
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
				if (wrapProperty.p is ChatMessage.Content) {
					ChatMessage.Content content = wrapProperty.p as ChatMessage.Content;
					switch (content.getType ()) {
					case ChatMessage.Content.Type.Normal:
						{
							switch ((ChatNormalContent.Property)wrapProperty.n) {
							case ChatNormalContent.Property.owner:
								dirty = true;
								break;
							case ChatNormalContent.Property.messages:
								break;
							case ChatNormalContent.Property.editMax:
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
						}
						break;
					case ChatMessage.Content.Type.UserAction:
						break;
					case ChatMessage.Content.Type.RoomUserState:
						break;
					case ChatMessage.Content.Type.FriendStateChange:
						break;
					case ChatMessage.Content.Type.GameMove:
						break;
					default:
						Debug.LogError ("unknown type: " + content.getType () + "; " + this);
						break;
					}
					return;
				}
			}
			if (wrapProperty.p is ChatMessageDeleteUI.UIData) {
				return;
			}
			if (wrapProperty.p is ChatMessageEditUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnBack()
	{
		if (this.data != null) {
			ChatRoomUI.UIData chatRoomUIData = this.data.findDataInParent<ChatRoomUI.UIData> ();
			if (chatRoomUIData != null) {
				chatRoomUIData.chatMessageMenu.v = null;
			} else {
				Debug.LogError ("chatRoomUIData null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public void onClickBtnEdit()
	{
		if (this.data != null) {
			ChatMessage chatMessage = this.data.chatMessage.v.data;
			if (chatMessage != null) {
				ChatMessageEditUI.UIData edit = this.data.edit.newOrOld<ChatMessageEditUI.UIData> ();
				{
					edit.chatMessage.v = new ReferenceData<ChatMessage> (chatMessage);
				}
				this.data.edit.v = edit;
			} else {
				Debug.LogError ("chatMessage null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}