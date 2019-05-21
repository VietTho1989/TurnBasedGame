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

            public VP<LobbyMiniSettingUI.UIData> miniSetting;

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
                miniSetting,
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
                this.miniSetting = new VP<LobbyMiniSettingUI.UIData>(this, (byte)Property.miniSetting, new LobbyMiniSettingUI.UIData());
                this.roomSetting = new VP<RoomSettingUI.UIData>(this, (byte)Property.roomSetting, null);
                // roomUserAdapter
                {
                    this.roomUserAdapter = new VP<RoomUserAdapter.UIData>(this, (byte)Property.roomUserAdapter, new RoomUserAdapter.UIData());
                    this.roomUserAdapter.v.type.v = RoomUserAdapter.UIData.Type.Lobby;
                }
                // chatRoom
                {
                    this.chatRoomUIData = new VP<ChatRoomUI.UIData>(this, (byte)Property.chatRoomUIData, new ChatRoomUI.UIData());
                    this.chatRoomUIData.v.needHeader.v = false;
                }
                this.contentFactory = new VP<ContestManagerContentFactoryUI.UIData>(this, (byte)Property.contentFactory, null);
                this.btnStart = new VP<LobbyBtnStart.UIData>(this, (byte)Property.btnStart, new LobbyBtnStart.UIData());
                // team
                {
                    this.teamAdapter = new VP<LobbyTeamAdapter.UIData>(this, (byte)Property.teamAdapter, new LobbyTeamAdapter.UIData());
                    this.editLobbyPlayer = new VP<EditLobbyPlayerUI.UIData>(this, (byte)Property.editLobbyPlayer, null);
                }
            }

            #endregion

            public override ContestManager.State.Type getType()
            {
                return ContestManager.State.Type.Lobby;
            }

            public void reset()
            {
                this.editLobbyPlayer.v = null;
            }

            public override bool processEvent(Event e)
            {
                // Debug.LogError("processEvent: " + e + "; " + this);
                bool isProcess = false;
                {
                    // editLobbyPlayer
                    if (!isProcess)
                    {
                        EditLobbyPlayerUI.UIData editLobbyPlayerUIData = this.editLobbyPlayer.v;
                        if (editLobbyPlayerUIData != null)
                        {
                            isProcess = editLobbyPlayerUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("editLobbyPlayerUIData null: " + this);
                        }
                    }
                    // miniSetting
                    if (!isProcess)
                    {
                        LobbyMiniSettingUI.UIData miniSetting = this.miniSetting.v;
                        if (miniSetting != null)
                        {
                            isProcess = miniSetting.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("miniSetting null");
                        }
                    }
                    // roomSetting
                    if (!isProcess)
                    {
                        RoomSettingUI.UIData roomSettingUIData = this.roomSetting.v;
                        if (roomSettingUIData != null)
                        {
                            isProcess = roomSettingUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("roomSettingUIData null: " + this);
                        }
                    }
                    // roomUserAdapter
                    {
                        // ko can
                    }
                    // chatRoomUIData
                    if (!isProcess)
                    {
                        ChatRoomUI.UIData chatRoomUIData = this.chatRoomUIData.v;
                        if (chatRoomUIData != null)
                        {
                            isProcess = chatRoomUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("chatRoomUIData null: " + this);
                        }
                    }
                    // contentFactory
                    if (!isProcess)
                    {
                        ContestManagerContentFactoryUI.UIData contestFactoryUIData = this.contentFactory.v;
                        if (contestFactoryUIData != null)
                        {
                            isProcess = contestFactoryUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("contestFactoryUIData null: " + this);
                        }
                    }
                    // btnStart
                    if(!isProcess)
                    {
                        LobbyBtnStart.UIData btnStart = this.btnStart.v;
                        if (btnStart != null)
                        {
                            isProcess = btnStart.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("btnStart null");
                        }
                    }
                    // teamAdapter
                    {
                        // ko can
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ContestManagerStateLobbyUI contestManagerStateLobbyUI = this.findCallBack<ContestManagerStateLobbyUI>();
                            if (contestManagerStateLobbyUI != null)
                            {
                                isProcess = contestManagerStateLobbyUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("contestManagerStateLobbyUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return 1;
        }

        #region txt, rect

        public Button btnCollapse;
        public Text tvCollapse;
        private static readonly TxtLanguage txtCollapse = new TxtLanguage("Collapse");

        static ContestManagerStateLobbyUI()
        {
            // txt
            {
                txtCollapse.add(Language.Type.vi, "Thu Nhỏ");
            }
            // roomUserAdapterRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (1.0, 0.0); anchorMax: (1.0, 0.5); pivot: (1.0, 0.0); 
                // offsetMin: (-160.0, 0.0); offsetMax: (0.0, 0.0); sizeDelta: (160.0, 0.0);
                roomUserAdapterRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                roomUserAdapterRect.anchorMin = new Vector2(1.0f, 0.0f);
                roomUserAdapterRect.anchorMax = new Vector2(1.0f, 0.5f);
                roomUserAdapterRect.pivot = new Vector2(1.0f, 0.0f);
                roomUserAdapterRect.offsetMin = new Vector2(-160.0f, 0.0f);
                roomUserAdapterRect.offsetMax = new Vector2(0.0f, 0.0f);
                roomUserAdapterRect.sizeDelta = new Vector2(160.0f, 0.0f);
            }
            // chatRoomRect
            {
                // anchoredPosition: (-80.0, 0.0); anchorMin: (0.0, 0.0); anchorMax: (1.0, 0.5); pivot: (0.5, 0.0);
                // offsetMin: (0.0, 0.0); offsetMax: (-160.0, 0.0); sizeDelta: (-160.0, 0.0);
                chatRoomRect.anchoredPosition = new Vector3(-80.0f, 0.0f, 0.0f);
                chatRoomRect.anchorMin = new Vector2(0.0f, 0.0f);
                chatRoomRect.anchorMax = new Vector2(1.0f, 0.5f);
                chatRoomRect.pivot = new Vector2(0.5f, 0f);
                chatRoomRect.offsetMin = new Vector2(0.0f, 0.0f);
                chatRoomRect.offsetMax = new Vector2(-160.0f, 0.0f);
                chatRoomRect.sizeDelta = new Vector2(-160.0f, 0.0f);
            }
            // btnStartRect
            {
                // anchoredPosition: (0.0, 30.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                // offsetMin: (-80.0, 0.0); offsetMax: (0.0, 30.0); sizeDelta: (80.0, 30.0);
                btnStartRect.anchoredPosition = new Vector3(0.0f, 30.0f, 0f);
                btnStartRect.anchorMin = new Vector2(1.0f, 1.0f);
                btnStartRect.anchorMax = new Vector2(1.0f, 1.0f);
                btnStartRect.pivot = new Vector2(1.0f, 1.0f);
                btnStartRect.offsetMin = new Vector2(-90.0f, 0.0f);
                btnStartRect.offsetMax = new Vector2(0.0f, 30.0f);
                btnStartRect.sizeDelta = new Vector2(90.0f, 30f);
            }
            // teamAdapterRect
            {
                // normal
                {
                    teamAdapterRect.anchoredPosition = new Vector3(0f, 0f, 0f);
                    teamAdapterRect.anchorMin = new Vector2(0.0f, 0.5f);
                    teamAdapterRect.anchorMax = new Vector2(0.5f, 1.0f);
                    teamAdapterRect.pivot = new Vector2(0.5f, 0.5f);
                    teamAdapterRect.offsetMin = new Vector2(0.0f, 0.0f);
                    teamAdapterRect.offsetMax = new Vector2(0.0f, 0.0f);
                    teamAdapterRect.sizeDelta = new Vector2(0.0f, 0.0f);
                }
                // large
                {
                    // anchoredPosition: (-15.0, 0.0); anchorMin: (0.0, 0.5); anchorMax: (1.0, 1.0);
                    // pivot: (0.5, 0.5); offsetMin: (0.0, 0.0); offsetMax: (-30.0, 0.0); sizeDelta: (-30.0, 0.0);
                    teamAdapterLargeRect.anchoredPosition = new Vector3(-15f, 0f, 0f);
                    teamAdapterLargeRect.anchorMin = new Vector2(0.0f, 0.5f);
                    teamAdapterLargeRect.anchorMax = new Vector2(1.0f, 1.0f);
                    teamAdapterLargeRect.pivot = new Vector2(0.5f, 0.5f);
                    teamAdapterLargeRect.offsetMin = new Vector2(0.0f, 0.0f);
                    teamAdapterLargeRect.offsetMax = new Vector2(-30.0f, 0.0f);
                    teamAdapterLargeRect.sizeDelta = new Vector2(-30.0f, 0.0f);
                }
            }
        }

        #endregion

        #region Refresh

        private bool firstSet = false;
        public ScrollRect miniSettingScrollView;
        public ScrollRect settingScrollView;

        public Image bgContestManagerContentFactory;
        public Image bgRoomSetting;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ContestManagerStateLobby lobby = this.data.contestManagerStateLobby.v.data;
                    if (lobby != null)
                    {
                        // miniSetting
                        {
                            LobbyMiniSettingUI.UIData miniSetting = this.data.miniSetting.v;
                            if (miniSetting != null)
                            {
                                miniSetting.contestManagerStateLobby.v = new ReferenceData<ContestManagerStateLobby>(lobby);
                            }
                            else
                            {
                                Debug.LogError("miniSetting null");
                            }
                        }
                        // roomSetting
                        {
                            RoomSettingUI.UIData roomSettingUIData = this.data.roomSetting.v;
                            if (roomSettingUIData != null)
                            {
                                // room
                                {
                                    Room room = lobby.findDataInParent<Room>();
                                    roomSettingUIData.editRoom.v.origin.v = new ReferenceData<Room>(room);
                                }
                                // roomState
                                {
                                    RoomStateUI.UIData roomStateUIData = roomSettingUIData.roomStateUIData.v;
                                    if (roomStateUIData != null)
                                    {
                                        // find roomState
                                        Room.State roomState = null;
                                        {
                                            Room room = lobby.findDataInParent<Room>();
                                            if (room != null)
                                            {
                                                roomState = room.state.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("room null");
                                            }
                                        }
                                        // set
                                        roomStateUIData.roomState.v = new ReferenceData<Room.State>(roomState);
                                    }
                                    else
                                    {
                                        Debug.LogError("roomStateUIData null");
                                    }
                                }
                                // canEdit?
                                {
                                    bool canEdit = false;
                                    {
                                        uint profileId = Server.getProfileUserId(lobby);
                                        if (Room.IsCanEditSetting(lobby, profileId))
                                        {
                                            canEdit = true;
                                        }
                                    }
                                    roomSettingUIData.editRoom.v.canEdit.v = canEdit;
                                }
                            }
                            else
                            {
                                // Debug.LogError("roomSettingUIData null: " + this);
                            }
                        }
                        // roomUserAdapter
                        {
                            RoomUserAdapter.UIData roomUserAdapterUIData = this.data.roomUserAdapter.v;
                            if (roomUserAdapterUIData != null)
                            {
                                // Find room
                                Room room = null;
                                {
                                    room = lobby.findDataInParent<Room>();
                                }
                                // Set
                                roomUserAdapterUIData.room.v = new ReferenceData<Room>(room);
                            }
                            else
                            {
                                Debug.LogError("roomUserAdapterUIData null: " + this);
                            }
                        }
                        // chatRoomUIData
                        {
                            ChatRoomUI.UIData chatRoomUIData = this.data.chatRoomUIData.v;
                            if (chatRoomUIData != null)
                            {
                                // Find ChatRoom
                                ChatRoom chatRoom = null;
                                {
                                    Room room = lobby.findDataInParent<Room>();
                                    if (room != null)
                                    {
                                        chatRoom = room.chatRoom.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("room null: " + this);
                                    }
                                }
                                // Set
                                chatRoomUIData.chatRoom.v = new ReferenceData<ChatRoom>(chatRoom);
                            }
                            else
                            {
                                Debug.LogError("chatRoomUIData null: " + this);
                            }
                        }
                        // contentFactory
                        {
                            ContestManagerContentFactoryUI.UIData contentFactoryUIData = this.data.contentFactory.v;
                            if (contentFactoryUIData != null)
                            {
                                contentFactoryUIData.editContestManagerStateLobby.v.origin.v = new ReferenceData<ContestManagerStateLobby>(lobby);
                                // canEdit?
                                {
                                    bool canEdit = false;
                                    {
                                        uint profileId = Server.getProfileUserId(lobby);
                                        if (lobby.isCanChange(profileId))
                                        {
                                            canEdit = true;
                                        }
                                    }
                                    contentFactoryUIData.editContestManagerStateLobby.v.canEdit.v = canEdit;
                                }
                            }
                            else
                            {
                                // Debug.LogError("contentFactoryUIData null: " + this);
                            }
                        }
                        // teamAdapter
                        {
                            LobbyTeamAdapter.UIData teamAdapter = this.data.teamAdapter.v;
                            if (teamAdapter != null)
                            {
                                teamAdapter.contestManagerStateLobby.v = new ReferenceData<ContestManagerStateLobby>(lobby);
                            }
                            else
                            {
                                Debug.LogError("teamAdapter null: " + this);
                            }
                        }
                        // firstSet
                        {
                            if (firstSet)
                            {
                                firstSet = false;
                                if (miniSettingScrollView != null)
                                {
                                    miniSettingScrollView.verticalNormalizedPosition = 1;
                                }
                                else
                                {
                                    Debug.LogError("miniSettingScrollView null");
                                }
                                if (settingScrollView != null)
                                {
                                    settingScrollView.verticalNormalizedPosition = 1;
                                }
                                else
                                {
                                    Debug.LogError("settingScrollRect null");
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("lobby null: " + this);
                    }
                    // siblingIndex
                    {
                        if (editLobbyPlayerContainer != null)
                        {
                            editLobbyPlayerContainer.SetAsLastSibling();
                        }
                        else
                        {
                            Debug.LogError("editLobbyPlayerContainer null");
                        }
                        if (editPostureGameDataUIContainer != null)
                        {
                            editPostureGameDataUIContainer.SetAsLastSibling();
                        }
                        else
                        {
                            Debug.LogError("editPostureGameDataUIContainer null");
                        }
                    }
                    // setting
                    {
                        if(this.data.contentFactory.v!=null || this.data.roomSetting.v != null)
                        {
                            // miniSetting
                            {
                                // miniSettingScrollView
                                if (miniSettingScrollView != null)
                                {
                                    miniSettingScrollView.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("miniSettingScrollView null");
                                }
                                this.data.miniSetting.v = null;
                            }
                            // UI Visibility
                            {
                                // settingScrollView
                                if (settingScrollView != null)
                                {
                                    settingScrollView.gameObject.SetActive(true);
                                }
                                else
                                {
                                    Debug.LogError("settingScrollView null");
                                }
                            }
                            // teamAdapterLobby
                            UIRectTransform.Set(this.data.teamAdapter.v, teamAdapterRect);
                            // siblingIndex
                            {
                                if (bgContestManagerContentFactory != null)
                                {
                                    bgContestManagerContentFactory.transform.SetSiblingIndex(0);
                                }
                                else
                                {
                                    Debug.LogError("bgContestManagerContentFactory null");
                                }
                                if (bgRoomSetting != null)
                                {
                                    bgRoomSetting.transform.SetSiblingIndex(1);
                                }
                                else
                                {
                                    Debug.LogError("bgRoomSetting null");
                                }
                                UIRectTransform.SetSiblingIndex(this.data.contentFactory.v, 2);
                                UIRectTransform.SetSiblingIndex(this.data.roomSetting.v, 3);
                            }
                            // size
                            {
                                float deltaY = 0;
                                float itemSize = Setting.get().getItemSize();
                                // contestManagerContentFactory
                                {
                                    float height = UIRectTransform.SetPosY(this.data.contentFactory.v, deltaY);
                                    // bg
                                    {
                                        if (bgContestManagerContentFactory != null)
                                        {
                                            UIRectTransform.SetPosY(bgContestManagerContentFactory.rectTransform, deltaY);
                                            UIRectTransform.SetHeight(bgContestManagerContentFactory.rectTransform, height);
                                        }
                                        else
                                        {
                                            Debug.LogError("bgContestManagerContentFactory null");
                                        }
                                    }
                                    deltaY += height;
                                }
                                // roomSetting
                                {
                                    float height = UIRectTransform.SetPosY(this.data.roomSetting.v, deltaY);
                                    // bg
                                    {
                                        if (bgRoomSetting != null)
                                        {
                                            UIRectTransform.SetPosY(bgRoomSetting.rectTransform, deltaY);
                                            UIRectTransform.SetHeight(bgRoomSetting.rectTransform, height);
                                        }
                                        else
                                        {
                                            Debug.LogError("bgRoomSetting null");
                                        }
                                    }
                                    deltaY += height;
                                }
                                // btnCollapse
                                {
                                    if (btnCollapse != null)
                                    {
                                        UIRectTransform.SetPosY((RectTransform)btnCollapse.transform, deltaY + (itemSize - 30) / 2.0f);
                                    }
                                    else
                                    {
                                        Debug.LogError("btnCollapse null");
                                    }
                                    deltaY += itemSize;
                                }
                                // settingContainer
                                if (settingContainer != null)
                                {
                                    UIRectTransform.SetHeight(settingContainer, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("settingContainer null");
                                }
                            }
                        }
                        else
                        {
                            // miniSetting
                            {
                                // miniSettingScrollView
                                if (miniSettingScrollView != null)
                                {
                                    miniSettingScrollView.gameObject.SetActive(true);
                                }
                                else
                                {
                                    Debug.LogError("miniSettingScrollView null");
                                }
                                // Data
                                {
                                    LobbyMiniSettingUI.UIData miniSetting = this.data.miniSetting.newOrOld<LobbyMiniSettingUI.UIData>();
                                    {
                                        miniSetting.contestManagerStateLobby.v = new ReferenceData<ContestManagerStateLobby>(lobby);
                                    }
                                    this.data.miniSetting.v = miniSetting;
                                }
                                // UI Size
                                {
                                    if (miniSettingContainer != null)
                                    {
                                        float deltaY = 0;
                                        // miniSetting
                                        deltaY += UIRectTransform.SetPosY(this.data.miniSetting.v, deltaY);
                                        // set height
                                        UIRectTransform.SetHeight(miniSettingContainer, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("settingContainer null");
                                    }
                                }
                            }
                            // settingScrollView
                            if (settingScrollView != null)
                            {
                                settingScrollView.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("settingScrollView null");
                            }
                            // teamAdapterLobby
                            {
                                // UpdateTeamAdapterLargeRect();
                                // UIRectTransform.Set(this.data.teamAdapter.v, teamAdapterLargeRect);
                                UIRectTransform.Set(this.data.teamAdapter.v, teamAdapterRect);
                            }
                        }
                    }
                    // btStart
                    {
                        UIRectTransform rect = new UIRectTransform();
                        {
                            float buttonSize = Setting.get().getButtonSize();
                            btnStartRect.anchoredPosition.y = buttonSize;
                            btnStartRect.offsetMin.x = -3 * buttonSize;
                            btnStartRect.offsetMax.y = buttonSize;
                            btnStartRect.sizeDelta = new Vector2(3 * buttonSize, buttonSize);
                        }
                        UIRectTransform.Set(this.data.btnStart.v, btnStartRect);
                    }
                    // txt
                    {
                        if (tvCollapse != null)
                        {
                            tvCollapse.text = txtCollapse.get();
                            Setting.get().setContentTextSize(tvCollapse);
                        }
                        else
                        {
                            Debug.LogError("tvCollapse null");
                        }
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public LobbyMiniSettingUI miniSettingPrefab;
        public RectTransform miniSettingContainer;

        public ContestManagerContentFactoryUI contestManagerContentFactoryPrefab;
        public RoomSettingUI roomSettingPrefab;
        public RectTransform settingContainer;

        public RoomUserAdapter roomUserAdapterPrefab;
        private static readonly UIRectTransform roomUserAdapterRect = new UIRectTransform();

        public ChatRoomUI chatRoomPrefab;
        private static readonly UIRectTransform chatRoomRect = new UIRectTransform();

        public LobbyBtnStart btnStartPrefab;
        private static readonly UIRectTransform btnStartRect = new UIRectTransform();

        public LobbyTeamAdapter teamAdapterPrefab;
        private static readonly UIRectTransform teamAdapterRect = new UIRectTransform();
        private static readonly UIRectTransform teamAdapterLargeRect = new UIRectTransform();

        private static void UpdateTeamAdapterLargeRect()
        {
            float buttonSize = Setting.get().getButtonSize();
            // rect
            {
                teamAdapterLargeRect.anchoredPosition.x = -buttonSize / 2;
                teamAdapterLargeRect.offsetMax.x = -buttonSize;
                teamAdapterLargeRect.sizeDelta.x = -buttonSize;
            }
        }

        public EditLobbyPlayerUI editLobbyPlayerPrefab;
        public Transform editLobbyPlayerContainer;

        public Transform editPostureGameDataUIContainer;

        private RoomCheckChangeAdminChange<ContestManagerStateLobby> roomCheckAdminChange = new RoomCheckChangeAdminChange<ContestManagerStateLobby>();
        private Room room = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.contestManagerStateLobby.allAddCallBack(this);
                    uiData.miniSetting.allAddCallBack(this);
                    uiData.roomSetting.allAddCallBack(this);
                    uiData.roomUserAdapter.allAddCallBack(this);
                    uiData.chatRoomUIData.allAddCallBack(this);
                    uiData.contentFactory.allAddCallBack(this);
                    uiData.btnStart.allAddCallBack(this);
                    uiData.teamAdapter.allAddCallBack(this);
                    uiData.editLobbyPlayer.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if(data is Setting)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // contestManagerStateLobby
                {
                    if (data is ContestManagerStateLobby)
                    {
                        ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
                        // Reset
                        {
                            firstSet = true;
                            if (this.data != null)
                            {
                                this.data.reset();
                            }
                            else
                            {
                                Debug.LogError("data null: " + this);
                            }
                        }
                        // CheckChange
                        {
                            roomCheckAdminChange.addCallBack(this);
                            roomCheckAdminChange.setData(contestManagerStateLobby);
                        }
                        // Parent
                        {
                            DataUtils.addParentCallBack(contestManagerStateLobby, this, ref this.room);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if (data is RoomCheckChangeAdminChange<ContestManagerStateLobby>)
                    {
                        dirty = true;
                        return;
                    }
                    // Parent
                    if (data is Room)
                    {
                        dirty = true;
                        return;
                    }
                }
                if(data is LobbyMiniSettingUI.UIData)
                {
                    LobbyMiniSettingUI.UIData miniSettingUIData = data as LobbyMiniSettingUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(miniSettingUIData, miniSettingPrefab, miniSettingContainer);
                    }
                    // TransformData
                    {
                        TransformData.AddCallBack(miniSettingUIData, this);
                    }
                    dirty = true;
                    return;
                }
                if (data is RoomSettingUI.UIData)
                {
                    RoomSettingUI.UIData roomSettingUIData = data as RoomSettingUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(roomSettingUIData, roomSettingPrefab, settingContainer);
                    }
                    // Child
                    {
                        TransformData.AddCallBack(roomSettingUIData, this);
                    }
                    dirty = true;
                    return;
                }
                if (data is RoomUserAdapter.UIData)
                {
                    RoomUserAdapter.UIData roomUserAdapterUIData = data as RoomUserAdapter.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(roomUserAdapterUIData, roomUserAdapterPrefab, this.transform, roomUserAdapterRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is ChatRoomUI.UIData)
                {
                    ChatRoomUI.UIData chatRoomUIData = data as ChatRoomUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chatRoomUIData, chatRoomPrefab, this.transform, chatRoomRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is ContestManagerContentFactoryUI.UIData)
                {
                    ContestManagerContentFactoryUI.UIData contestManagerContentFactoryUIData = data as ContestManagerContentFactoryUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(contestManagerContentFactoryUIData, contestManagerContentFactoryPrefab, settingContainer);
                    }
                    // Child
                    {
                        TransformData.AddCallBack(contestManagerContentFactoryUIData, this);
                    }
                    dirty = true;
                    return;
                }
                if (data is LobbyBtnStart.UIData)
                {
                    LobbyBtnStart.UIData btnStartUIData = data as LobbyBtnStart.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnStartUIData, btnStartPrefab, this.transform, btnStartRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is LobbyTeamAdapter.UIData)
                {
                    LobbyTeamAdapter.UIData teamAdapter = data as LobbyTeamAdapter.UIData;
                    // UI
                    {
                        UpdateTeamAdapterLargeRect();
                        UIUtils.Instantiate(teamAdapter, teamAdapterPrefab, this.transform, teamAdapterLargeRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is EditLobbyPlayerUI.UIData)
                {
                    EditLobbyPlayerUI.UIData editLobbyPlayerUIData = data as EditLobbyPlayerUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(editLobbyPlayerUIData, editLobbyPlayerPrefab, editLobbyPlayerContainer);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is TransformData)
                {
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().removeCallBack(this);
                // Child
                {
                    uiData.contestManagerStateLobby.allRemoveCallBack(this);
                    uiData.miniSetting.allRemoveCallBack(this);
                    uiData.roomSetting.allRemoveCallBack(this);
                    uiData.roomUserAdapter.allRemoveCallBack(this);
                    uiData.chatRoomUIData.allRemoveCallBack(this);
                    uiData.contentFactory.allRemoveCallBack(this);
                    uiData.btnStart.allRemoveCallBack(this);
                    uiData.teamAdapter.allRemoveCallBack(this);
                    uiData.editLobbyPlayer.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if(data is Setting)
            {
                return;
            }
            // Child
            {
                // contestManagerStateLobby
                {
                    if (data is ContestManagerStateLobby)
                    {
                        ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
                        // CheckChange
                        {
                            roomCheckAdminChange.removeCallBack(this);
                            roomCheckAdminChange.setData(null);
                        }
                        // Parent
                        {
                            DataUtils.removeParentCallBack(contestManagerStateLobby, this, ref this.room);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is RoomCheckChangeAdminChange<ContestManagerStateLobby>)
                    {
                        return;
                    }
                    // Parent
                    if (data is Room)
                    {
                        return;
                    }
                }
                if (data is LobbyMiniSettingUI.UIData)
                {
                    LobbyMiniSettingUI.UIData miniSettingUIData = data as LobbyMiniSettingUI.UIData;
                    // UI
                    {
                        miniSettingUIData.removeCallBackAndDestroy(typeof(LobbyMiniSettingUI));
                    }
                    // TransformData
                    {
                        TransformData.RemoveCallBack(miniSettingUIData, this);
                    }
                    return;
                }
                if (data is RoomSettingUI.UIData)
                {
                    RoomSettingUI.UIData roomSettingUIData = data as RoomSettingUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(roomSettingUIData, this);
                    }
                    // UI
                    {
                        roomSettingUIData.removeCallBackAndDestroy(typeof(RoomSettingUI));
                    }
                    return;
                }
                if (data is RoomUserAdapter.UIData)
                {
                    RoomUserAdapter.UIData roomUserAdapterUIData = data as RoomUserAdapter.UIData;
                    // UI
                    {
                        roomUserAdapterUIData.removeCallBackAndDestroy(typeof(RoomUserAdapter));
                    }
                    return;
                }
                if (data is ChatRoomUI.UIData)
                {
                    ChatRoomUI.UIData chatRoomUIData = data as ChatRoomUI.UIData;
                    // UI
                    {
                        chatRoomUIData.removeCallBackAndDestroy(typeof(ChatRoomUI));
                    }
                    return;
                }
                if (data is ContestManagerContentFactoryUI.UIData)
                {
                    ContestManagerContentFactoryUI.UIData contestManagerContentFactoryUIData = data as ContestManagerContentFactoryUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(contestManagerContentFactoryUIData, this);
                    }
                    // UI
                    {
                        contestManagerContentFactoryUIData.removeCallBackAndDestroy(typeof(ContestManagerContentFactoryUI));
                    }
                    return;
                }
                if (data is LobbyBtnStart.UIData)
                {
                    LobbyBtnStart.UIData btnStartUIData = data as LobbyBtnStart.UIData;
                    // UI
                    {
                        btnStartUIData.removeCallBackAndDestroy(typeof(LobbyBtnStart));
                    }
                    return;
                }
                if (data is LobbyTeamAdapter.UIData)
                {
                    LobbyTeamAdapter.UIData teamAdapter = data as LobbyTeamAdapter.UIData;
                    // UI
                    {
                        teamAdapter.removeCallBackAndDestroy(typeof(LobbyTeamAdapter));
                    }
                    return;
                }
                if (data is EditLobbyPlayerUI.UIData)
                {
                    EditLobbyPlayerUI.UIData editLobbyPlayerUIData = data as EditLobbyPlayerUI.UIData;
                    // UI
                    {
                        editLobbyPlayerUIData.removeCallBackAndDestroy(typeof(EditLobbyPlayerUI));
                    }
                    return;
                }
                // Child
                if(data is TransformData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is UIData)
            {
                switch ((UIData.Property)wrapProperty.n)
                {
                    case UIData.Property.contestManagerStateLobby:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.miniSetting:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.roomSetting:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.roomUserAdapter:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.chatRoomUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.contentFactory:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnStart:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.teamAdapter:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.editLobbyPlayer:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Setting
            if(wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.fastStart:
                        break;
                    case Setting.Property.timeStep:
                        break;
                    case Setting.Property.language:
                        dirty = true;
                        break;
                    case Setting.Property.style:
                        break;
                    case Setting.Property.contentTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.buttonSize:
                        dirty = true;
                        break;
                    case Setting.Property.confirmQuit:
                        break;
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    case Setting.Property.defaultChosenGame:
                        break;
                    case Setting.Property.defaultRoomName:
                        break;
                    case Setting.Property.defaultChatRoomStyle:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                // contestManagerStateLobby
                {
                    if (wrapProperty.p is ContestManagerStateLobby)
                    {
                        switch ((ContestManagerStateLobby.Property)wrapProperty.n)
                        {
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
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // CheckChange
                    if (wrapProperty.p is RoomCheckChangeAdminChange<ContestManagerStateLobby>)
                    {
                        dirty = true;
                        return;
                    }
                    // Parent
                    if (wrapProperty.p is Room)
                    {
                        switch ((Room.Property)wrapProperty.n)
                        {
                            case Room.Property.changeRights:
                                break;
                            case Room.Property.name:
                                break;
                            case Room.Property.password:
                                break;
                            case Room.Property.users:
                                break;
                            case Room.Property.state:
                                dirty = true;
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
                            case Room.Property.allowLoadHistory:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                if (wrapProperty.p is LobbyMiniSettingUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RoomSettingUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RoomUserAdapter.UIData)
                {
                    return;
                }
                if (wrapProperty.p is ChatRoomUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is ContestManagerContentFactoryUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is LobbyBtnStart.UIData)
                {
                    return;
                }
                if (wrapProperty.p is LobbyTeamAdapter.UIData)
                {
                    return;
                }
                if (wrapProperty.p is EditLobbyPlayerUI.UIData)
                {
                    return;
                }
                // Child
                if(wrapProperty.p is TransformData)
                {
                    switch ((TransformData.Property)wrapProperty.n)
                    {
                        case TransformData.Property.anchoredPosition:
                            break;
                        case TransformData.Property.anchorMin:
                            break;
                        case TransformData.Property.anchorMax:
                            break;
                        case TransformData.Property.pivot:
                            break;
                        case TransformData.Property.offsetMin:
                            break;
                        case TransformData.Property.offsetMax:
                            break;
                        case TransformData.Property.sizeDelta:
                            break;
                        case TransformData.Property.rotation:
                            break;
                        case TransformData.Property.scale:
                            break;
                        case TransformData.Property.size:
                            dirty = true;
                            break;
                        default:
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {

            }
        }

        public bool useShortKey(Event e)
        {
            bool isProcess = false;
            {
                if (e.isKey && e.type == EventType.KeyUp)
                {
                    switch (e.keyCode)
                    {
                        case KeyCode.S:
                            break;
                        default:
                            break;
                    }
                }
            }
            return isProcess;
        }

        public void onClickBtnCollapse()
        {
            if (this.data != null)
            {
                // contestManagerFactory
                this.data.contentFactory.v = null;
                // roomSetting
                this.data.roomSetting.v = null;
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}