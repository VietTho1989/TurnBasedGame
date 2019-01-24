using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UserChatUI : UIBehavior<UserChatUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<User>> user;

		public VP<ChatRoomUI.UIData> chatRoom;

		#region Constructor

		public enum Property
		{
			user,
			chatRoom
		}

		public UIData() : base()
		{
			this.user = new VP<ReferenceData<User>>(this, (byte)Property.user, new ReferenceData<User>(null));
			this.chatRoom = new VP<ChatRoomUI.UIData>(this, (byte)Property.chatRoom, new ChatRoomUI.UIData());
		}

		#endregion

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// chatRoom
				if (!isProcess) {
					ChatRoomUI.UIData chatRoomUIData = this.chatRoom.v;
					if (chatRoomUIData != null) {
						isProcess = chatRoomUIData.processEvent (e);
					} else {
						Debug.LogError ("chatRoomUIData null: " + this);
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

	static UserChatUI()
	{
		txtTitle.add (Language.Type.vi, "Tán gẫu");
		txtBack.add (Language.Type.vi, "Quay Lại");
	}

	#endregion

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				User user = this.data.user.v.data;
				if (user != null) {
					// ChatRoom
					{
						ChatRoomUI.UIData chatRoomUIData = this.data.chatRoom.v;
						if (chatRoomUIData != null) {
							chatRoomUIData.chatRoom.v = new ReferenceData<ChatRoom> (user.chatRoom.v);
						} else {
							Debug.LogError ("chatRoomUIData null: " + this);
						}
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Chat");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (tvBack != null) {
							tvBack.text = txtBack.get ("Back");
						} else {
							Debug.LogError ("tvBack null: " + this);
						}
					}
				} else {
					Debug.LogError ("user null: " + this);
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

	public ChatRoomUI chatRoomPrefab;
	public Transform chatRoomContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.user.allAddCallBack (this);
				uiData.chatRoom.allAddCallBack (this);
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
			if (data is User) {
				dirty = true;
				return;
			}
			if (data is ChatRoomUI.UIData) {
				ChatRoomUI.UIData chatRoomUIData = data as ChatRoomUI.UIData;
				// UI
				{
					UIUtils.Instantiate (chatRoomUIData, chatRoomPrefab, chatRoomContainer);
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
				uiData.user.allRemoveCallBack (this);
				uiData.chatRoom.allRemoveCallBack (this);
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
			if (data is User) {
				return;
			}
			if (data is ChatRoomUI.UIData) {
				ChatRoomUI.UIData chatRoomUIData = data as ChatRoomUI.UIData;
				// UI
				{
					chatRoomUIData.removeCallBackAndDestroy (typeof(ChatRoomUI));
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
			case UIData.Property.user:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.chatRoom:
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
			if (wrapProperty.p is User) {
				switch ((User.Property)wrapProperty.n) {
				case User.Property.human:
					break;
				case User.Property.role:
					break;
				case User.Property.ipAddress:
					break;
				case User.Property.registerTime:
					break;
				case User.Property.chatRoom:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is ChatRoomUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnBack()
	{
		if (this.data != null) {
			UserUI.UIData userUIData = this.data.findDataInParent<UserUI.UIData> ();
			if (userUIData != null) {
				userUIData.userChat.v = null;
			} else {
				Debug.LogError ("userUIData null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}