using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestManagerStateLobbyUI : UIBehavior<ContestManagerStateLobbyUI.UIData>
	{

		#region UIData

		public class UIData : ContestManagerUI.UIData.Sub
		{

			public VP<ReferenceData<ContestManagerStateLobby>> contestManagerStateLobby;

			public VP<RoomSettingUI.UIData> roomSetting; 

			public VP<RoomUserAdapter.UIData> roomUserAdapter;

			public VP<ChatRoomUI.UIData> chatRoomUIData;

			public VP<ContestManagerContentFactoryUI.UIData> contentFactory;

			public VP<LobbyBtnStart.UIData> btnStart;

			#region team

			public VP<LobbyTeamAdapter.UIData> teamAdapter;

			public VP<EditLobbyPlayerUI.UIData> editLobbyPlayer;

			#endregion

			#region Constructor

			public enum Property
			{
				contestManagerStateLobby,
				roomSetting,
				roomUserAdapter,
				chatRoomUIData,
				contentFactory,
				btnStart,
				teamAdapter,
				editLobbyPlayer
			}

			public UIData() : base()
			{
				this.contestManagerStateLobby = new VP<ReferenceData<ContestManagerStateLobby>>(this, (byte)Property.contestManagerStateLobby, new ReferenceData<ContestManagerStateLobby>(null));
				this.roomSetting = new VP<RoomSettingUI.UIData>(this, (byte)Property.roomSetting, new RoomSettingUI.UIData());
				this.roomUserAdapter = new VP<RoomUserAdapter.UIData>(this, (byte)Property.roomUserAdapter, new RoomUserAdapter.UIData());
				this.chatRoomUIData = new VP<ChatRoomUI.UIData>(this, (byte)Property.chatRoomUIData, new ChatRoomUI.UIData());
				this.contentFactory = new VP<ContestManagerContentFactoryUI.UIData>(this, (byte)Property.contentFactory, new ContestManagerContentFactoryUI.UIData());
				this.btnStart = new VP<LobbyBtnStart.UIData>(this, (byte)Property.btnStart, new LobbyBtnStart.UIData());
				// team
				{
					this.teamAdapter = new VP<LobbyTeamAdapter.UIData>(this, (byte)Property.teamAdapter, new LobbyTeamAdapter.UIData());
					this.editLobbyPlayer = new VP<EditLobbyPlayerUI.UIData>(this, (byte)Property.editLobbyPlayer, null);
				}
			}

			#endregion

			public override ContestManager.State.Type getType ()
			{
				return ContestManager.State.Type.Lobby;
			}

			public void reset()
			{
				this.editLobbyPlayer.v = null;
			}

			public override bool processEvent (Event e)
			{
				Debug.LogError ("processEvent: " + e + "; " + this);
				bool isProcess = false;
				{
					// editLobbyPlayer
					if (!isProcess) {
						EditLobbyPlayerUI.UIData editLobbyPlayerUIData = this.editLobbyPlayer.v;
						if (editLobbyPlayerUIData != null) {
							isProcess = editLobbyPlayerUIData.processEvent (e);
						} else {
							Debug.LogError ("editLobbyPlayerUIData null: " + this);
						}
					}
					// roomSetting
					if (!isProcess) {
						RoomSettingUI.UIData roomSettingUIData = this.roomSetting.v;
						if (roomSettingUIData != null) {
							isProcess = roomSettingUIData.processEvent (e);
						} else {
							Debug.LogError ("roomSettingUIData null: " + this);
						}
					}
					// roomUserAdapter
					{
						// ko can
					}
					// chatRoomUIData
					if (!isProcess) {
						ChatRoomUI.UIData chatRoomUIData = this.chatRoomUIData.v;
						if (chatRoomUIData != null) {
							isProcess = chatRoomUIData.processEvent (e);
						} else {
							Debug.LogError ("chatRoomUIData null: " + this);
						}
					}
					// contentFactory
					if (!isProcess) {
						ContestManagerContentFactoryUI.UIData contestFactoryUIData = this.contentFactory.v;
						if (contestFactoryUIData != null) {
							isProcess = contestFactoryUIData.processEvent (e);
						} else {
							Debug.LogError ("contestFactoryUIData null: " + this);
						}
					}
					// btnStart
					{
						// ko can
					}
					// teamAdapter
					{
						// ko can
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		private bool firstSet = false;
		public ScrollRect contestManagerContentFactoryScrollRect;
		public ScrollRect roomSettingScrollRect;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ContestManagerStateLobby lobby = this.data.contestManagerStateLobby.v.data;
					if (lobby != null) {
						// roomSetting
						{
							RoomSettingUI.UIData roomSettingUIData = this.data.roomSetting.v;
							if (roomSettingUIData != null) {
								// room
								{
									Room room = lobby.findDataInParent<Room> ();
									roomSettingUIData.editRoom.v.origin.v = new ReferenceData<Room> (room);
								}
								// canEdit?
								{
									bool canEdit = false;
									{
										uint profileId = Server.getProfileUserId (lobby);
										if (Room.IsCanEditSetting (lobby, profileId)) {
											canEdit = true;
										}
									}
									roomSettingUIData.editRoom.v.canEdit.v = canEdit;
								}
							} else {
								Debug.LogError ("roomSettingUIData null: " + this);
							}
						}
						// roomUserAdapter
						{
							RoomUserAdapter.UIData roomUserAdapterUIData = this.data.roomUserAdapter.v;
							if (roomUserAdapterUIData != null) {
								// Find room
								Room room = null;
								{
									room = lobby.findDataInParent<Room> ();
								}
								// Set
								roomUserAdapterUIData.room.v = new ReferenceData<Room>(room);
							} else {
								Debug.LogError ("roomUserAdapterUIData null: " + this);
							}
						}
						// chatRoomUIData
						{
							ChatRoomUI.UIData chatRoomUIData = this.data.chatRoomUIData.v;
							if (chatRoomUIData != null) {
								// Find ChatRoom
								ChatRoom chatRoom = null;
								{
									Room room = lobby.findDataInParent<Room> ();
									if (room != null) {
										chatRoom = room.chatRoom.v;
									} else {
										Debug.LogError ("room null: " + this);
									}
								}
								// Set
								chatRoomUIData.chatRoom.v = new ReferenceData<ChatRoom>(chatRoom);
							} else {
								Debug.LogError ("chatRoomUIData null: " + this);
							}
						}
						// contentFactory
						{
							ContestManagerContentFactoryUI.UIData contentFactoryUIData = this.data.contentFactory.v;
							if (contentFactoryUIData != null) {
								contentFactoryUIData.editContestManagerStateLobby.v.origin.v = new ReferenceData<ContestManagerStateLobby> (lobby);
								// canEdit?
								{
									bool canEdit = false;
									{
										uint profileId = Server.getProfileUserId (lobby);
										if (lobby.isCanChange (profileId)) {
											canEdit = true;
										}
									}
									contentFactoryUIData.editContestManagerStateLobby.v.canEdit.v = canEdit;
								}
							} else {
								Debug.LogError ("contentFactoryUIData null: " + this);
							}
						}
						// teamAdapter
						{
							LobbyTeamAdapter.UIData teamAdapter = this.data.teamAdapter.v;
							if (teamAdapter != null) {
								teamAdapter.contestManagerStateLobby.v = new ReferenceData<ContestManagerStateLobby> (lobby);
							} else {
								Debug.LogError ("teamAdapter null: " + this);
							}
						}
						// firstSet
						{
							if (firstSet) {
								firstSet = false;
								// contestManagerContentFactoryScrollRect
								if (contestManagerContentFactoryScrollRect != null) {
									contestManagerContentFactoryScrollRect.verticalNormalizedPosition = 1;
								} else {
									Debug.LogError ("contestManagerContentFactoryScrollRect null");
								}
								// roomSettingScrollRect
								if (roomSettingScrollRect != null) {
									roomSettingScrollRect.verticalNormalizedPosition = 1;
								} else {
									Debug.LogError ("roomSettingScrollRect null");
								}
							}
						}
					} else {
						Debug.LogError ("lobby null: " + this);
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

		public RoomSettingUI roomSettingPrefab;
		public Transform roomSettingContainer;

		public RoomUserAdapter roomUserAdapterPrefab;
		public Transform roomUserAdapterContainer;

		public ChatRoomUI chatRoomPrefab;
		public Transform chatRoomContainer;

		public ContestManagerContentFactoryUI contestManagerContentFactoryPrefab;
		public Transform contestManagerContentFactoryContainer;

		public LobbyBtnStart btnStartPrefab;
		public Transform btnStartContainer;

		public LobbyTeamAdapter teamAdapterPrefab;
		public Transform teamAdapterContainer;

		public EditLobbyPlayerUI editLobbyPlayerPrefab;
		public Transform editLobbyPlayerContainer;

		public Transform editPostureGameDataUIContainer;

		private RoomCheckChangeAdminChange<ContestManagerStateLobby> roomCheckAdminChange = new RoomCheckChangeAdminChange<ContestManagerStateLobby>();
		private Room room = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.contestManagerStateLobby.allAddCallBack (this);
					uiData.roomSetting.allAddCallBack (this);
					uiData.roomUserAdapter.allAddCallBack (this);
					uiData.chatRoomUIData.allAddCallBack (this);
					uiData.contentFactory.allAddCallBack (this);
					uiData.btnStart.allAddCallBack (this);
					uiData.teamAdapter.allAddCallBack (this);
					uiData.editLobbyPlayer.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				// contestManagerStateLobby
				{
					if (data is ContestManagerStateLobby) {
						ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
						// Reset
						{
							firstSet = true;
							if (this.data != null) {
								this.data.reset ();
							} else {
								Debug.LogError ("data null: " + this);
							}
						}
						// CheckChange
						{
							roomCheckAdminChange.addCallBack (this);
							roomCheckAdminChange.setData (contestManagerStateLobby);
						}
						// Parent
						{
							DataUtils.addParentCallBack (contestManagerStateLobby, this, ref this.room);
						}
						dirty = true;
						return;
					}
					// CheckChange
					if (data is RoomCheckChangeAdminChange<ContestManagerStateLobby>) {
						dirty = true;
						return;
					}
					// Parent
					if (data is Room) {
						dirty = true;
						return;
					}
				}
				if (data is RoomSettingUI.UIData) {
					RoomSettingUI.UIData roomSettingUIData = data as RoomSettingUI.UIData;
					// UI
					{
						UIUtils.Instantiate (roomSettingUIData, roomSettingPrefab, roomSettingContainer);
					}
					dirty = true;
					return;
				}
				if (data is RoomUserAdapter.UIData) {
					RoomUserAdapter.UIData roomUserAdapterUIData = data as RoomUserAdapter.UIData;
					// UI
					{
						UIUtils.Instantiate (roomUserAdapterUIData, roomUserAdapterPrefab, roomUserAdapterContainer);
					}
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
				if (data is ContestManagerContentFactoryUI.UIData) {
					ContestManagerContentFactoryUI.UIData contestManagerContentFactoryUIData = data as ContestManagerContentFactoryUI.UIData;
					// UI
					{
						UIUtils.Instantiate (contestManagerContentFactoryUIData, contestManagerContentFactoryPrefab, contestManagerContentFactoryContainer);
					}
					dirty = true;
					return;
				}
				if (data is LobbyBtnStart.UIData) {
					LobbyBtnStart.UIData btnStartUIData = data as LobbyBtnStart.UIData;
					// UI
					{
						UIUtils.Instantiate (btnStartUIData, btnStartPrefab, btnStartContainer);
					}
					dirty = true;
					return;
				}
				if (data is LobbyTeamAdapter.UIData) {
					LobbyTeamAdapter.UIData teamAdapter = data as LobbyTeamAdapter.UIData;
					// UI
					{
						UIUtils.Instantiate (teamAdapter, teamAdapterPrefab, teamAdapterContainer);
					}
					dirty = true;
					return;
				}
				if (data is EditLobbyPlayerUI.UIData) {
					EditLobbyPlayerUI.UIData editLobbyPlayerUIData = data as EditLobbyPlayerUI.UIData;
					// UI
					{
						UIUtils.Instantiate (editLobbyPlayerUIData, editLobbyPlayerPrefab, editLobbyPlayerContainer);
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
					uiData.contestManagerStateLobby.allRemoveCallBack (this);
					uiData.roomSetting.allRemoveCallBack (this);
					uiData.roomUserAdapter.allRemoveCallBack (this);
					uiData.chatRoomUIData.allRemoveCallBack (this);
					uiData.contentFactory.allRemoveCallBack (this);
					uiData.btnStart.allRemoveCallBack (this);
					uiData.teamAdapter.allRemoveCallBack (this);
					uiData.editLobbyPlayer.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				// contestManagerStateLobby
				{
					if (data is ContestManagerStateLobby) {
						ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
						// CheckChange
						{
							roomCheckAdminChange.removeCallBack (this);
							roomCheckAdminChange.setData (null);
						}
						// Parent
						{
							DataUtils.removeParentCallBack (contestManagerStateLobby, this, ref this.room);
						}
						return;
					}
					// CheckChange
					if (data is RoomCheckChangeAdminChange<ContestManagerStateLobby>) {
						return;
					}
					// Parent
					if (data is Room) {
						return;
					}
				}
				if (data is RoomSettingUI.UIData) {
					RoomSettingUI.UIData roomSettingUIData = data as RoomSettingUI.UIData;
					// UI
					{
						roomSettingUIData.removeCallBackAndDestroy (typeof(RoomSettingUI));
					}
					return;
				}
				if (data is RoomUserAdapter.UIData) {
					RoomUserAdapter.UIData roomUserAdapterUIData = data as RoomUserAdapter.UIData;
					// UI
					{
						roomUserAdapterUIData.removeCallBackAndDestroy (typeof(RoomUserAdapter));
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
				if (data is ContestManagerContentFactoryUI.UIData) {
					ContestManagerContentFactoryUI.UIData contestManagerContentFactoryUIData = data as ContestManagerContentFactoryUI.UIData;
					// UI
					{
						contestManagerContentFactoryUIData.removeCallBackAndDestroy (typeof(ContestManagerContentFactoryUI));
					}
					return;
				}
				if (data is LobbyBtnStart.UIData) {
					LobbyBtnStart.UIData btnStartUIData = data as LobbyBtnStart.UIData;
					// UI
					{
						btnStartUIData.removeCallBackAndDestroy (typeof(LobbyBtnStart));
					}
					return;
				}
				if (data is LobbyTeamAdapter.UIData) {
					LobbyTeamAdapter.UIData teamAdapter = data as LobbyTeamAdapter.UIData;
					// UI
					{
						teamAdapter.removeCallBackAndDestroy (typeof(LobbyTeamAdapter));
					}
					return;
				}
				if (data is EditLobbyPlayerUI.UIData) {
					EditLobbyPlayerUI.UIData editLobbyPlayerUIData = data as EditLobbyPlayerUI.UIData;
					// UI
					{
						editLobbyPlayerUIData.removeCallBackAndDestroy (typeof(EditLobbyPlayerUI));
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
				case UIData.Property.contestManagerStateLobby:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.roomSetting:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.roomUserAdapter:
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
				case UIData.Property.contentFactory:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.btnStart:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.teamAdapter:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.editLobbyPlayer:
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
				// contestManagerStateLobby
				{
					if (wrapProperty.p is ContestManagerStateLobby) {
						switch ((ContestManagerStateLobby.Property)wrapProperty.n) {
						case ContestManagerStateLobby.Property.state:
							dirty = true;
							break;
						case ContestManagerStateLobby.Property.teams:
							break;
						case ContestManagerStateLobby.Property.gameType:
							break;
						case ContestManagerStateLobby.Property.randomTeamIndex:
							break;
						case ContestManagerStateLobby.Property.contentFactory:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// CheckChange
					if (wrapProperty.p is RoomCheckChangeAdminChange<ContestManagerStateLobby>) {
						dirty = true;
						return;
					}
					// Parent
					if (wrapProperty.p is Room) {
						switch ((Room.Property)wrapProperty.n) {
						case Room.Property.changeRights:
							break;
						case Room.Property.name:
							break;
						case Room.Property.password:
							break;
						case Room.Property.users:
							break;
						case Room.Property.state:
							break;
						case Room.Property.contestManagers:
							break;
						case Room.Property.timeCreated:
							break;
						case Room.Property.chatRoom:
							dirty = true;
							break;
						case Room.Property.allowHint:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
				if (wrapProperty.p is RoomSettingUI.UIData) {
					return;
				}
				if (wrapProperty.p is RoomUserAdapter.UIData) {
					return;
				}
				if (wrapProperty.p is ChatRoomUI.UIData) {
					return;
				}
				if (wrapProperty.p is ContestManagerContentFactoryUI.UIData) {
					return;
				}
				if (wrapProperty.p is LobbyBtnStart.UIData) {
					return;
				}
				if (wrapProperty.p is LobbyTeamAdapter.UIData) {
					return;
				}
				if (wrapProperty.p is EditLobbyPlayerUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}