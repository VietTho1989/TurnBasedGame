using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class GlobalChatUI : UIBehavior<GlobalChatUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<Server>> server;

		public VP<ChatRoomUI.UIData> chatRoomUIData;

		public LP<BtnChooseChatUI.UIData> btnChooseChatUIDatas;

		#region Constructor

		public enum Property
		{
			server,
			chatRoomUIData,
			btnChooseChatUIDatas
		}

		public UIData() : base()
		{
			this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
			this.chatRoomUIData = new VP<ChatRoomUI.UIData>(this, (byte)Property.chatRoomUIData, new ChatRoomUI.UIData());
			this.btnChooseChatUIDatas = new LP<BtnChooseChatUI.UIData>(this, (byte)Property.btnChooseChatUIDatas);
		}

		#endregion

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// chatRoomUIData
				if (!isProcess) {
					ChatRoomUI.UIData chatRoomUIData = this.chatRoomUIData.v;
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

    static GlobalChatUI()
    {
        // chatRoomRect
        {
            // anchoredPosition: (80.0, 0.0); anchorMin: (0.0, 0.0); anchorMax: (1.0, 1.0); pivot: (0.5, 0.5); 
            // offsetMin: (160.0, 0.0); offsetMax: (0.0, 0.0); sizeDelta: (-160.0, 0.0);
            chatRoomRect.anchoredPosition = new Vector3(80.0f, 0.0f, 0.0f);
            chatRoomRect.anchorMin = new Vector2(0.0f, 0.0f);
            chatRoomRect.anchorMax = new Vector2(1.0f, 1.0f);
            chatRoomRect.pivot = new Vector2(0.5f, 0.5f);
            chatRoomRect.offsetMin = new Vector2(160.0f, 0.0f);
            chatRoomRect.offsetMax = new Vector2(0.0f, 0.0f);
            chatRoomRect.sizeDelta = new Vector2(-160.0f, 0.0f);
        }
    }

    #region Refresh

    public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Server server = this.data.server.v.data;
				if (server != null) {
					// get chatRoomList
					List<ChatRoom> chatRoomList = new List<ChatRoom>();
					{
						GlobalChat globalChat = server.globalChat.v;
						if (globalChat != null) {
							chatRoomList = globalChat.getEnableChatRooms ();
						} else {
							Debug.LogError ("globalChat null: " + this);
						}
					}
					// btnChooseChatUI
					{
						List<BtnChooseChatUI.UIData> olds = new List<BtnChooseChatUI.UIData> ();
						// Make old
						{
							olds.AddRange (this.data.btnChooseChatUIDatas.vs);
						}
						// Update
						{
							foreach (ChatRoom chatRoom in chatRoomList) {
								// find btn
								BtnChooseChatUI.UIData btnChooseChatUIData = null;
								{
									// find old
									if (olds.Count > 0) {
										btnChooseChatUIData = olds [0];
									}
									// Make new
									if (btnChooseChatUIData == null) {
										btnChooseChatUIData = new BtnChooseChatUI.UIData ();
										{
											btnChooseChatUIData.uid = this.data.btnChooseChatUIDatas.makeId ();
										}
										this.data.btnChooseChatUIDatas.add (btnChooseChatUIData);
									} else {
										olds.Remove (btnChooseChatUIData);
									}
								}
								// Update
								{
									btnChooseChatUIData.chatRoom.v = new ReferenceData<ChatRoom> (chatRoom);
								}
							}
						}
						// Remove old
						foreach (BtnChooseChatUI.UIData old in olds) {
							this.data.btnChooseChatUIDatas.remove (old);
						}
					}
					// ChatRoom
					{
						ChatRoomUI.UIData chatRoomUIData = this.data.chatRoomUIData.v;
						if (chatRoomUIData != null) {
							// Check need new
							bool needNew = true;
							{
								if (chatRoomUIData.chatRoom.v.data != null) {
									if (chatRoomList.Contains (chatRoomUIData.chatRoom.v.data)) {
										needNew = false;
									}
								}
							}
							// Process
							if (needNew) {
								// Find
								ChatRoom chatRoom = null;
								{
									if (chatRoomList.Count > 0) {
										chatRoom = chatRoomList [0];
									}
								}
								// Set
								chatRoomUIData.chatRoom.v = new ReferenceData<ChatRoom> (chatRoom);
							}
						} else {
							Debug.LogError ("chatRoomUIData null: " + this);
						}
					}
				} else {
					Debug.LogError ("server null: " + this);
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

	public BtnChooseChatUI btnChooseChatPrefab;
	public Transform btnChooseChatContainer;

	public ChatRoomUI chatRoomPrefab;
    private static readonly UIRectTransform chatRoomRect = new UIRectTransform();

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.server.allAddCallBack (this);
				uiData.btnChooseChatUIDatas.allAddCallBack (this);
				uiData.chatRoomUIData.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// Server
			{
				if (data is Server) {
					Server server = data as Server;
					// Child
					{
						server.globalChat.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is GlobalChat) {
						GlobalChat globalChat = data as GlobalChat;
						// Child
						{
							globalChat.general.allAddCallBack (this);
							globalChat.suggestion.allAddCallBack (this);
							globalChat.bugReport.allAddCallBack (this);
							globalChat.offTopic.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is ChatRoom) {
						dirty = true;
						return;
					}
				}
			}
			if (data is BtnChooseChatUI.UIData) {
				BtnChooseChatUI.UIData btnChooseChatUIData = data as BtnChooseChatUI.UIData;
				// UI
				{
					UIUtils.Instantiate (btnChooseChatUIData, btnChooseChatPrefab, btnChooseChatContainer);
				}
				dirty = true;
				return;
			}
			if (data is ChatRoomUI.UIData) {
				ChatRoomUI.UIData chatRoomUIData = data as ChatRoomUI.UIData;
				// UI
				{
					UIUtils.Instantiate (chatRoomUIData, chatRoomPrefab, this.transform, chatRoomRect);
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
				uiData.server.allRemoveCallBack (this);
				uiData.chatRoomUIData.allRemoveCallBack (this);
				uiData.btnChooseChatUIDatas.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			// Server
			{
				if (data is Server) {
					Server server = data as Server;
					// Child
					{
						server.globalChat.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is GlobalChat) {
						GlobalChat globalChat = data as GlobalChat;
						// Child
						{
							globalChat.general.allRemoveCallBack (this);
							globalChat.suggestion.allRemoveCallBack (this);
							globalChat.bugReport.allRemoveCallBack (this);
							globalChat.offTopic.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is ChatRoom) {
						return;
					}
				}
			}
			if (data is BtnChooseChatUI.UIData) {
				BtnChooseChatUI.UIData btnChooseChatUIData = data as BtnChooseChatUI.UIData;
				// UI
				{
					btnChooseChatUIData.removeCallBackAndDestroy (typeof(BtnChooseChatUI));
				}
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
			case UIData.Property.server:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.btnChooseChatUIDatas:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.chatRoomUIData:
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
			// Server
			{
				if (wrapProperty.p is Server) {
					switch ((Server.Property)wrapProperty.n) {
					case Server.Property.serverConfig:
						break;
					case Server.Property.startState:
						break;
					case Server.Property.type:
						break;
					case Server.Property.profile:
						break;
					case Server.Property.state:
						break;
					case Server.Property.users:
						break;
					case Server.Property.globalChat:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case Server.Property.friendWorld:
						break;
					case Server.Property.guilds:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is GlobalChat) {
						switch ((GlobalChat.Property)wrapProperty.n) {
						case GlobalChat.Property.general:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case GlobalChat.Property.suggestion:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case GlobalChat.Property.bugReport:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case GlobalChat.Property.offTopic:
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
					if (wrapProperty.p is ChatRoom) {
						switch ((ChatRoom.Property)wrapProperty.n) {
						case ChatRoom.Property.topic:
							break;
						case ChatRoom.Property.isEnable:
							dirty = true;
							break;
						case ChatRoom.Property.players:
							break;
						case ChatRoom.Property.messages:
							break;
						case ChatRoom.Property.typing:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
			}
			if (wrapProperty.p is BtnChooseChatUI.UIData) {
				return;
			}
			if (wrapProperty.p is ChatRoomUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}