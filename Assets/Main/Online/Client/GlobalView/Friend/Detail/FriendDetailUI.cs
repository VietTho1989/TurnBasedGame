using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FriendDetailUI : UIBehavior<FriendDetailUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<Friend>> friend;

		public VP<ChatRoomUI.UIData> chatRoom;

		#region Constructor

		public enum Property
		{
			friend,
			chatRoom
		}

		public UIData() : base()
		{
			this.friend = new VP<ReferenceData<Friend>>(this, (byte)Property.friend, new ReferenceData<Friend>(null));
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
				// btnBack
				if (!isProcess) {
					if (InputEvent.isBackEvent (e)) {
						FriendDetailUI friendDetailUI = this.findCallBack<FriendDetailUI> ();
						if (friendDetailUI != null) {
							friendDetailUI.onClickBtnBack ();
						} else {
							Debug.LogError ("friendDetalUI null: " + this);
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

	public Text lbTitle;
	public static readonly TxtLanguage txtTitle = new TxtLanguage ();

	public Text tvBack;
	public static readonly TxtLanguage txtBack = new TxtLanguage();

	static FriendDetailUI()
	{
		txtTitle.add (Language.Type.vi, "Thông tin chi tiết bạn bè");
		txtBack.add (Language.Type.vi, "Quay Lại");
	}

	#endregion

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Friend friend = this.data.friend.v.data;
				if (friend != null) {
					// ChatRoom
					{
						ChatRoomUI.UIData chatRoomUIData = this.data.chatRoom.v;
						if (chatRoomUIData != null) {
							chatRoomUIData.chatRoom.v = new ReferenceData<ChatRoom> (friend.chatRoom.v);
						} else {
							Debug.LogError ("chatRoomUIData null: " + this);
						}
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Friend Detail");
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
					Debug.LogError ("friend null: " + this);
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
				uiData.friend.allAddCallBack (this);
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
			if (data is Friend) {
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
				uiData.friend.allRemoveCallBack (this);
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
			if (data is Friend) {
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
			case UIData.Property.friend:
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
			if (wrapProperty.p is Friend) {
				switch ((Friend.Property)wrapProperty.n) {
				case Friend.Property.state:
					break;
				case Friend.Property.user1:
					break;
				case Friend.Property.user2:
					break;
				case Friend.Property.time:
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
			GlobalFriendsUI.UIData globalFriendsUIData = this.data.findDataInParent<GlobalFriendsUI.UIData> ();
			if (globalFriendsUIData != null) {
				globalFriendsUIData.friendDetail.v = null;
			} else {
				Debug.LogError ("globalFriendsUIData null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}