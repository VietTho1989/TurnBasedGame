using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class GlobalViewUI : UIBehavior<GlobalViewUI.UIData>
{

    #region UIData 

    public class UIData : AfterLoginUI.UIData.Sub
    {

        public VP<ReferenceData<Server>> server;

        #region Show

        public enum Show
        {
            rooms,
            chats,
            friends,
            profile
        }

        public VP<Show> show;

        #endregion

        public VP<GlobalRoomsUI.UIData> rooms;

        #region chat

        public VP<GlobalChatUI.UIData> chats;

        public VP<ChatRoomNewMessageCountUI.UIData> chatRoomNewMessageCountUIData;

        #endregion

        #region friends

        public VP<GlobalFriendsUI.UIData> friends;

        public VP<FriendListNewMessageCountUI.UIData> friendListNewMessageCountUIData;

        #endregion

        #region profile

        public VP<GlobalProfileUI.UIData> profile;

        public VP<ProfileNewMessageCountUI.UIData> profileNewMessageCountUIData;

        #endregion

        #region Constructor

        public enum Property
        {
            server,
            show,
            rooms,

            chats,
            chatRoomNewMessageUIData,

            friends,
            friendListNewMessageCountUIData,

            profile,
            profileNewMessageCountUIData
        }

        public UIData() : base()
        {
            this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
            this.show = new VP<Show>(this, (byte)Property.show, Show.rooms);
            this.rooms = new VP<GlobalRoomsUI.UIData>(this, (byte)Property.rooms, null);
            // chats
            {
                this.chats = new VP<GlobalChatUI.UIData>(this, (byte)Property.chats, null);
                this.chatRoomNewMessageCountUIData = new VP<ChatRoomNewMessageCountUI.UIData>(this, (byte)Property.chatRoomNewMessageUIData, new ChatRoomNewMessageCountUI.UIData());
            }
            // friends
            {
                this.friends = new VP<GlobalFriendsUI.UIData>(this, (byte)Property.friends, null);
                this.friendListNewMessageCountUIData = new VP<FriendListNewMessageCountUI.UIData>(this, (byte)Property.friendListNewMessageCountUIData, new FriendListNewMessageCountUI.UIData());
            }
            // profile
            {
                this.profile = new VP<GlobalProfileUI.UIData>(this, (byte)Property.profile, null);
                this.profileNewMessageCountUIData = new VP<ProfileNewMessageCountUI.UIData>(this, (byte)Property.profileNewMessageCountUIData, new ProfileNewMessageCountUI.UIData());
            }
        }

        #endregion

        public override Type getType()
        {
            return Type.View;
        }

        public void reset()
        {
            this.show.v = Show.rooms;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // show
                if (!isProcess)
                {
                    switch (this.show.v)
                    {
                        case Show.rooms:
                            {
                                GlobalRoomsUI.UIData rooms = this.rooms.v;
                                if (rooms != null)
                                {
                                    isProcess = rooms.processEvent(e);
                                }
                                else
                                {
                                    Debug.LogError("rooms null: " + this);
                                }
                            }
                            break;
                        case Show.chats:
                            {
                                GlobalChatUI.UIData chats = this.chats.v;
                                if (chats != null)
                                {
                                    isProcess = chats.processEvent(e);
                                }
                                else
                                {
                                    Debug.LogError("chats null: " + this);
                                }
                            }
                            break;
                        case Show.friends:
                            {
                                GlobalFriendsUI.UIData friends = this.friends.v;
                                if (friends != null)
                                {
                                    isProcess = friends.processEvent(e);
                                }
                                else
                                {
                                    Debug.LogError("friends null: " + this);
                                }
                            }
                            break;
                        case Show.profile:
                            {
                                GlobalProfileUI.UIData profile = this.profile.v;
                                if (profile != null)
                                {
                                    isProcess = profile.processEvent(e);
                                }
                                else
                                {
                                    Debug.LogError("profile null: " + this);
                                }
                            }
                            break;
                        default:
                            Debug.LogError("unknown show: " + this.show.v + "; " + this);
                            break;
                    }
                }
            }
            return isProcess;
        }

        public override MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            MainUI.UIData.AllowShowBanner ret = MainUI.UIData.AllowShowBanner.ForceShow;
            {
                switch (this.show.v)
                {
                    case Show.rooms:
                        {
                            GlobalRoomsUI.UIData rooms = this.rooms.v;
                            if (rooms != null)
                            {
                                ret = rooms.getAllowShowBanner();
                            }
                            else
                            {
                                Debug.LogError("rooms null");
                            }
                        }
                        break;
                    case Show.chats:
                        break;
                    case Show.friends:
                        break;
                    case Show.profile:
                        break;
                    default:
                        Debug.LogError("unknown show: " + this.show.v);
                        break;
                }
            }
            return ret;
        }

    }

    #endregion

    #region txt, rect

    static GlobalViewUI()
    {
        // rect
        {
            // chatRoomNewMessageCountRect
            {
                // anchoredPosition: (105.0, 0.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 1.0);
                // offsetMin: (105.0, -15.0); offsetMax: (120.0, 0.0); sizeDelta: (15.0, 15.0);
                chatRoomNewMessageCountRect.anchoredPosition = new Vector3(105.0f, 0.0f, 0.0f);
                chatRoomNewMessageCountRect.anchorMin = new Vector2(0.0f, 1.0f);
                chatRoomNewMessageCountRect.anchorMax = new Vector2(0.0f, 1.0f);
                chatRoomNewMessageCountRect.pivot = new Vector2(0.0f, 1.0f);
                chatRoomNewMessageCountRect.offsetMin = new Vector2(105.0f, -15.0f);
                chatRoomNewMessageCountRect.offsetMax = new Vector2(120.0f, 0.0f);
                chatRoomNewMessageCountRect.sizeDelta = new Vector2(15.0f, 15.0f);
            }
            // friendListNewMessageCountRect
            {
                friendListNewMessageCountRect.anchoredPosition = new Vector3(135.0f, 0.0f, 0.0f);
                friendListNewMessageCountRect.anchorMin = new Vector2(0.0f, 1.0f);
                friendListNewMessageCountRect.anchorMax = new Vector2(0.0f, 1.0f);
                friendListNewMessageCountRect.pivot = new Vector2(0.0f, 1.0f);
                friendListNewMessageCountRect.offsetMin = new Vector2(135.0f, -15.0f);
                friendListNewMessageCountRect.offsetMax = new Vector2(150.0f, 0.0f);
                friendListNewMessageCountRect.sizeDelta = new Vector2(15.0f, 15.0f);
            }
            // profileNewMessageCountRect
            {
                profileNewMessageCountRect.anchoredPosition = new Vector3(165.0f, 0.0f, 0.0f);
                profileNewMessageCountRect.anchorMin = new Vector2(0.0f, 1.0f);
                profileNewMessageCountRect.anchorMax = new Vector2(0.0f, 1.0f);
                profileNewMessageCountRect.pivot = new Vector2(0.0f, 1.0f);
                profileNewMessageCountRect.offsetMin = new Vector2(165.0f, -15.0f);
                profileNewMessageCountRect.offsetMax = new Vector2(180.0f, 0.0f);
                profileNewMessageCountRect.sizeDelta = new Vector2(15.0f, 15.0f);
            }
        }
    }

    #endregion

    #region Refresh

    public Button btnRooms;
    public Button btnChats;
    public Button btnFriends;
    public Button btnProfile;

    public RectTransform btnBackground;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Server server = this.data.server.v.data;
                if (server != null)
                {
                    // set child ui
                    {
                        switch (this.data.show.v)
                        {
                            case UIData.Show.rooms:
                                {
                                    GlobalRoomsUI.UIData globalRoomsUIData = this.data.rooms.newOrOld<GlobalRoomsUI.UIData>();
                                    {

                                    }
                                    this.data.rooms.v = globalRoomsUIData;
                                }
                                break;
                            case UIData.Show.chats:
                                {
                                    GlobalChatUI.UIData globalChatUIData = this.data.chats.newOrOld<GlobalChatUI.UIData>();
                                    {

                                    }
                                    this.data.chats.v = globalChatUIData;
                                }
                                break;
                            case UIData.Show.friends:
                                {
                                    GlobalFriendsUI.UIData globalFriendsUIData = this.data.friends.newOrOld<GlobalFriendsUI.UIData>();
                                    {

                                    }
                                    this.data.friends.v = globalFriendsUIData;
                                }
                                break;
                            case UIData.Show.profile:
                                {
                                    GlobalProfileUI.UIData profileUIData = this.data.profile.newOrOld<GlobalProfileUI.UIData>();
                                    {

                                    }
                                    this.data.profile.v = profileUIData;
                                }
                                break;
                            default:
                                Debug.LogError("unknown show: " + this.data.show.v + "; " + this);
                                break;
                        }
                    }
                    // Update Child UI
                    {
                        // rooms
                        {
                            GlobalRoomsUI.UIData rooms = this.data.rooms.v;
                            if (rooms != null)
                            {
                                rooms.server.v = new ReferenceData<Server>(server);
                            }
                            else
                            {
                                Debug.LogError("rooms null: " + this);
                            }
                        }
                        // chats
                        {
                            GlobalChatUI.UIData chats = this.data.chats.v;
                            if (chats != null)
                            {
                                chats.server.v = new ReferenceData<Server>(server);
                            }
                            else
                            {
                                Debug.LogError("chats null: " + this);
                            }
                        }
                        // friends
                        {
                            GlobalFriendsUI.UIData friends = this.data.friends.v;
                            if (friends != null)
                            {
                                friends.server.v = new ReferenceData<Server>(server);
                            }
                            else
                            {
                                Debug.LogError("friends null: " + this);
                            }
                        }
                        // profile
                        {
                            GlobalProfileUI.UIData profile = this.data.profile.v;
                            if (profile != null)
                            {
                                profile.server.v = new ReferenceData<Server>(server);
                            }
                            else
                            {
                                Debug.LogError("profile null: " + this);
                            }
                        }
                    }
                    // show
                    {
                        if (btnRooms != null && btnChats != null && btnFriends != null && btnProfile != null)
                        {
                            // get UI
                            GlobalRoomsUI globalRoomsUI = null;
                            {
                                GlobalRoomsUI.UIData globalRoomsUIData = this.data.rooms.v;
                                if (globalRoomsUIData != null)
                                {
                                    globalRoomsUI = globalRoomsUIData.findCallBack<GlobalRoomsUI>();
                                }
                                else
                                {
                                    Debug.LogError("globalRoomsUIData null");
                                }
                            }
                            GlobalChatUI globalChatUI = null;
                            {
                                GlobalChatUI.UIData globalChatUIData = this.data.chats.v;
                                if (globalChatUIData != null)
                                {
                                    globalChatUI = globalChatUIData.findCallBack<GlobalChatUI>();
                                }
                                else
                                {
                                    Debug.LogError("globalChatUIData null");
                                }
                            }
                            GlobalFriendsUI globalFriendsUI = null;
                            {
                                GlobalFriendsUI.UIData globalFriendsUIData = this.data.friends.v;
                                if (globalFriendsUIData != null)
                                {
                                    globalFriendsUI = globalFriendsUIData.findCallBack<GlobalFriendsUI>();
                                }
                                else
                                {
                                    Debug.LogError("globalFriendsUIData null");
                                }
                            }
                            GlobalProfileUI globalProfileUI = null;
                            {
                                GlobalProfileUI.UIData globalProfileUIData = this.data.profile.v;
                                if (globalProfileUIData != null)
                                {
                                    globalProfileUI = globalProfileUIData.findCallBack<GlobalProfileUI>();
                                }
                                else
                                {
                                    Debug.LogError("globalProfileUIData null");
                                }
                            }
                            // show
                            switch (this.data.show.v)
                            {
                                case UIData.Show.rooms:
                                    {
                                        // container
                                        {
                                            if (globalRoomsUI != null)
                                            {
                                                globalRoomsUI.gameObject.SetActive(true);
                                            }
                                            if (globalChatUI != null)
                                            {
                                                globalChatUI.gameObject.SetActive(false);
                                            }
                                            if (globalFriendsUI != null)
                                            {
                                                globalFriendsUI.gameObject.SetActive(false);
                                            }
                                            if (globalProfileUI != null)
                                            {
                                                globalProfileUI.gameObject.SetActive(false);
                                            }
                                        }
                                        // btns
                                        {
                                            btnRooms.interactable = false;
                                            btnChats.interactable = true;
                                            btnFriends.interactable = true;
                                            btnProfile.interactable = true;
                                        }
                                    }
                                    break;
                                case UIData.Show.chats:
                                    {
                                        // container
                                        {
                                            if (globalRoomsUI != null)
                                            {
                                                globalRoomsUI.gameObject.SetActive(false);
                                            }
                                            if (globalChatUI != null)
                                            {
                                                globalChatUI.gameObject.SetActive(true);
                                            }
                                            if (globalFriendsUI != null)
                                            {
                                                globalFriendsUI.gameObject.SetActive(false);
                                            }
                                            if (globalProfileUI != null)
                                            {
                                                globalProfileUI.gameObject.SetActive(false);
                                            }
                                        }
                                        // btns
                                        {
                                            btnRooms.interactable = true;
                                            btnChats.interactable = false;
                                            btnFriends.interactable = true;
                                            btnProfile.interactable = true;
                                        }
                                    }
                                    break;
                                case UIData.Show.friends:
                                    {
                                        // container
                                        {
                                            if (globalRoomsUI != null)
                                            {
                                                globalRoomsUI.gameObject.SetActive(false);
                                            }
                                            if (globalChatUI != null)
                                            {
                                                globalChatUI.gameObject.SetActive(false);
                                            }
                                            if (globalFriendsUI != null)
                                            {
                                                globalFriendsUI.gameObject.SetActive(true);
                                            }
                                            if (globalProfileUI != null)
                                            {
                                                globalProfileUI.gameObject.SetActive(false);
                                            }
                                        }
                                        // btns
                                        {
                                            btnRooms.interactable = true;
                                            btnChats.interactable = true;
                                            btnFriends.interactable = false;
                                            btnProfile.interactable = true;
                                        }
                                    }
                                    break;
                                case UIData.Show.profile:
                                    {
                                        // container
                                        {
                                            if (globalRoomsUI != null)
                                            {
                                                globalRoomsUI.gameObject.SetActive(false);
                                            }
                                            if (globalChatUI != null)
                                            {
                                                globalChatUI.gameObject.SetActive(false);
                                            }
                                            if (globalFriendsUI != null)
                                            {
                                                globalFriendsUI.gameObject.SetActive(false);
                                            }
                                            if (globalProfileUI != null)
                                            {
                                                globalProfileUI.gameObject.SetActive(true);
                                            }
                                        }
                                        // btns
                                        {
                                            btnRooms.interactable = true;
                                            btnChats.interactable = true;
                                            btnFriends.interactable = true;
                                            btnProfile.interactable = false;
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown show: " + this.data.show.v + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("btn null: " + this);
                        }
                    }
                    // chatRoomNewMessageUIData
                    {
                        ChatRoomNewMessageCountUI.UIData chatRoomNewMessageCountUIData = this.data.chatRoomNewMessageCountUIData.v;
                        if (chatRoomNewMessageCountUIData != null)
                        {
                            // find chatRoom
                            ChatRoom chatRoom = null;
                            {
                                // find in globalChatUIData
                                GlobalChatUI.UIData globalChatUIData = this.data.chats.v;
                                if (globalChatUIData != null)
                                {
                                    ChatRoomUI.UIData chatRoomUIData = globalChatUIData.chatRoomUIData.v;
                                    if (chatRoomUIData != null)
                                    {
                                        chatRoom = chatRoomUIData.chatRoom.v.data;
                                    }
                                    else
                                    {
                                        Debug.LogError("chatRoomUIData null");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("globalChatUIData null");
                                }
                                // find in server
                                if (chatRoom == null)
                                {
                                    GlobalChat globalChat = server.globalChat.v;
                                    if (globalChat != null)
                                    {
                                        chatRoom = globalChat.general.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("globalChat null");
                                    }
                                }
                            }
                            // set
                            chatRoomNewMessageCountUIData.chatRoom.v = new ReferenceData<ChatRoom>(chatRoom);
                        }
                        else
                        {
                            Debug.LogError("newChatMessageNumberUIData null");
                        }
                    }
                    // friendListNewMessageCountUIData
                    {
                        FriendListNewMessageCountUI.UIData friendListNewMessageCountUIData = this.data.friendListNewMessageCountUIData.v;
                        if (friendListNewMessageCountUIData != null)
                        {
                            // find
                            FriendWorld friendWorld = server.friendWorld.v;
                            // set
                            friendListNewMessageCountUIData.friendWorld.v = new ReferenceData<FriendWorld>(friendWorld);
                        }
                        else
                        {
                            Debug.LogError("friendListNewMessageCountUIData null");
                        }
                    }
                    // profileNewMesssageCountUIData
                    {
                        ProfileNewMessageCountUI.UIData profileNewMessageCountUIData = this.data.profileNewMessageCountUIData.v;
                        if (profileNewMessageCountUIData != null)
                        {
                            profileNewMessageCountUIData.server.v = new ReferenceData<Server>(server);
                        }
                        else
                        {
                            Debug.LogError("profileNewCountCountUIData null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("server null");
                }
                // UI
                {
                    float buttonSize = Setting.get().getButtonSize();
                    UIRectTransform.SetButtonTopLeftTransform(btnRooms, 2 * buttonSize);
                    UIRectTransform.SetButtonTopLeftTransform(btnChats, 3 * buttonSize);
                    UIRectTransform.SetButtonTopLeftTransform(btnFriends, 4 * buttonSize);
                    UIRectTransform.SetButtonTopLeftTransform(btnProfile, 5 * buttonSize);
                    // newMessage
                    {
                        // chatRoomNewMessageUIData
                        {
                            // set rect
                            {
                                chatRoomNewMessageCountRect.anchoredPosition.x = 4 * buttonSize - 15;
                                chatRoomNewMessageCountRect.offsetMin.x = 4 * buttonSize - 15;
                                chatRoomNewMessageCountRect.offsetMax.x = 4 * buttonSize;
                            }
                            UIRectTransform.Set(this.data.chatRoomNewMessageCountUIData.v, chatRoomNewMessageCountRect);
                        }
                        // friendListNewMessageCountUIData
                        {
                            // set rect
                            {
                                friendListNewMessageCountRect.anchoredPosition.x = 5 * buttonSize - 15;
                                friendListNewMessageCountRect.offsetMin.x = 5 * buttonSize - 15;
                                friendListNewMessageCountRect.offsetMax.x = 5 * buttonSize;
                            }
                            UIRectTransform.Set(this.data.friendListNewMessageCountUIData.v, friendListNewMessageCountRect);
                        }
                        // profileNewMessageCountUIData
                        {
                            // set rect
                            {
                                profileNewMessageCountRect.anchoredPosition.x = 6 * buttonSize - 15;
                                profileNewMessageCountRect.offsetMin.x = 6 * buttonSize - 15;
                                profileNewMessageCountRect.offsetMax.x = 6 * buttonSize;
                            }
                            UIRectTransform.Set(this.data.profileNewMessageCountUIData.v, profileNewMessageCountRect);
                        }
                    }
                    // btnBackground
                    {
                        UIRectTransform rect = new UIRectTransform();
                        {
                            // anchoredPosition: (60.0, 0.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 1.0);
                            // offsetMin: (60.0, -30.0); offsetMax: (180.0, 0.0); sizeDelta: (120.0, 30.0);
                            rect.anchoredPosition = new Vector3(2 * buttonSize, 0.0f, 0.0f);
                            rect.anchorMin = new Vector2(0.0f, 1.0f);
                            rect.anchorMax = new Vector2(0.0f, 1.0f);
                            rect.pivot = new Vector2(0.0f, 1.0f);
                            rect.offsetMin = new Vector2(2 * buttonSize, -buttonSize);
                            rect.offsetMax = new Vector2(6 * buttonSize, 0.0f);
                            rect.sizeDelta = new Vector2(4 * buttonSize, buttonSize);
                        }
                        rect.set(btnBackground);
                    }
                    // content
                    {
                        // make
                        UIRectTransform contentRect = UIRectTransform.CreateFullRect(0, 0, buttonSize, 0);
                        // set
                        {
                            UIRectTransform.Set(this.data.rooms.v, contentRect);
                            UIRectTransform.Set(this.data.chats.v, contentRect);
                            UIRectTransform.Set(this.data.friends.v, contentRect);
                            UIRectTransform.Set(this.data.profile.v, contentRect);
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public GlobalRoomsUI roomsPrefab;
    public GlobalChatUI chatsPrefab;
    public GlobalFriendsUI friendsPrefab;
    public GlobalProfileUI profilePrefab;

    public ChatRoomNewMessageCountUI chatRoomNewMessageCountPrefab;
    private static readonly UIRectTransform chatRoomNewMessageCountRect = new UIRectTransform();

    public FriendListNewMessageCountUI friendListNewMessageCountPrefab;
    private static readonly UIRectTransform friendListNewMessageCountRect = new UIRectTransform();

    public ProfileNewMessageCountUI profileNewMessageCountPrefab;
    private static readonly UIRectTransform profileNewMessageCountRect = new UIRectTransform();

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.server.allAddCallBack(this);
                uiData.rooms.allAddCallBack(this);
                // chats
                {
                    uiData.chats.allAddCallBack(this);
                    uiData.chatRoomNewMessageCountUIData.allAddCallBack(this);
                }
                // friends
                {
                    uiData.friends.allAddCallBack(this);
                    uiData.friendListNewMessageCountUIData.allAddCallBack(this);
                }
                // profile
                {
                    uiData.profile.allAddCallBack(this);
                    uiData.profileNewMessageCountUIData.allAddCallBack(this);
                }
            }
            dirty = true;
            return;
        }
        // Setting
        if (data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        {
            // server
            {
                if (data is Server)
                {
                    Server server = data as Server;
                    // Reset
                    {
                        if (this.data != null)
                        {
                            this.data.reset();
                        }
                        else
                        {
                            Debug.LogError("data null: " + this);
                        }
                    }
                    // Child
                    {
                        server.globalChat.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is GlobalChat)
                {
                    dirty = true;
                    return;
                }
            }
            if (data is GlobalRoomsUI.UIData)
            {
                GlobalRoomsUI.UIData rooms = data as GlobalRoomsUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(rooms, roomsPrefab, this.transform);
                }
                dirty = true;
                return;
            }
            // chat
            {
                // globalChatUIData
                {
                    if (data is GlobalChatUI.UIData)
                    {
                        GlobalChatUI.UIData chats = data as GlobalChatUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(chats, chatsPrefab, this.transform);
                        }
                        // Child
                        {
                            chats.chatRoomUIData.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is ChatRoomUI.UIData)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is ChatRoomNewMessageCountUI.UIData)
                {
                    ChatRoomNewMessageCountUI.UIData chatRoomNewMessageCountUIData = data as ChatRoomNewMessageCountUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chatRoomNewMessageCountUIData, chatRoomNewMessageCountPrefab, this.transform, chatRoomNewMessageCountRect);
                    }
                    dirty = true;
                    return;
                }
            }
            // friends
            {
                if (data is GlobalFriendsUI.UIData)
                {
                    GlobalFriendsUI.UIData friends = data as GlobalFriendsUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(friends, friendsPrefab, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if(data is FriendListNewMessageCountUI.UIData)
                {
                    FriendListNewMessageCountUI.UIData friendListNewMessageCountUIData = data as FriendListNewMessageCountUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(friendListNewMessageCountUIData, friendListNewMessageCountPrefab, this.transform, friendListNewMessageCountRect);
                    }
                    dirty = true;
                    return;
                }
            }
            // profile
            {
                if (data is GlobalProfileUI.UIData)
                {
                    GlobalProfileUI.UIData profile = data as GlobalProfileUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(profile, profilePrefab, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if(data is ProfileNewMessageCountUI.UIData)
                {
                    ProfileNewMessageCountUI.UIData profileNewMessageCountUIData = data as ProfileNewMessageCountUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(profileNewMessageCountUIData, profileNewMessageCountPrefab, this.transform, profileNewMessageCountRect);
                    }
                    dirty = true;
                    return;
                }
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
                uiData.server.allRemoveCallBack(this);
                uiData.rooms.allRemoveCallBack(this);
                // chats
                {
                    uiData.chats.allRemoveCallBack(this);
                    uiData.chatRoomNewMessageCountUIData.allRemoveCallBack(this);
                }
                // friends
                {
                    uiData.friends.allRemoveCallBack(this);
                    uiData.friendListNewMessageCountUIData.allRemoveCallBack(this);
                }
                // profile
                {
                    uiData.profile.allRemoveCallBack(this);
                    uiData.profileNewMessageCountUIData.allRemoveCallBack(this);
                }
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Child
        {
            // server
            {
                if (data is Server)
                {
                    Server server = data as Server;
                    // Child
                    {
                        server.globalChat.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is GlobalChat)
                {
                    return;
                }
            }
            if (data is GlobalRoomsUI.UIData)
            {
                GlobalRoomsUI.UIData rooms = data as GlobalRoomsUI.UIData;
                // UI
                {
                    rooms.removeCallBackAndDestroy(typeof(GlobalRoomsUI));
                }
                return;
            }
            // chats
            {
                // globalChatUIData
                {
                    if (data is GlobalChatUI.UIData)
                    {
                        GlobalChatUI.UIData chats = data as GlobalChatUI.UIData;
                        // UI
                        {
                            chats.removeCallBackAndDestroy(typeof(GlobalChatUI));
                        }
                        // child
                        {
                            chats.chatRoomUIData.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is ChatRoomUI.UIData)
                    {
                        return;
                    }
                }
                if (data is ChatRoomNewMessageCountUI.UIData)
                {
                    ChatRoomNewMessageCountUI.UIData chatRoomNewMessageCountUIData = data as ChatRoomNewMessageCountUI.UIData;
                    // UI
                    {
                        chatRoomNewMessageCountUIData.removeCallBackAndDestroy(typeof(ChatRoomNewMessageCountUI));
                    }
                    return;
                }
            }
            // friends
            {
                if (data is GlobalFriendsUI.UIData)
                {
                    GlobalFriendsUI.UIData friends = data as GlobalFriendsUI.UIData;
                    // UI
                    {
                        friends.removeCallBackAndDestroy(typeof(GlobalFriendsUI));
                    }
                    return;
                }
                if(data is FriendListNewMessageCountUI.UIData)
                {
                    FriendListNewMessageCountUI.UIData friendListNewMessageCountUIData = data as FriendListNewMessageCountUI.UIData;
                    // UI
                    {
                        friendListNewMessageCountUIData.removeCallBackAndDestroy(typeof(FriendListNewMessageCountUI));
                    }
                    return;
                }
            }
            // profile
            {
                if (data is GlobalProfileUI.UIData)
                {
                    GlobalProfileUI.UIData profile = data as GlobalProfileUI.UIData;
                    // UI
                    {
                        profile.removeCallBackAndDestroy(typeof(GlobalProfileUI));
                    }
                    return;
                }
                if (data is ProfileNewMessageCountUI.UIData)
                {
                    ProfileNewMessageCountUI.UIData profileNewMessageCountUIData = data as ProfileNewMessageCountUI.UIData;
                    // UI
                    {
                        profileNewMessageCountUIData.removeCallBackAndDestroy(typeof(ProfileNewMessageCountUI));
                    }
                    return;
                }
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
                case UIData.Property.server:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.show:
                    dirty = true;
                    break;
                case UIData.Property.rooms:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.chats:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.chatRoomNewMessageUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.friends:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.friendListNewMessageCountUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.profile:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.profileNewMessageCountUIData:
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
        if (wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
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
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            // server
            {
                if (wrapProperty.p is Server)
                {
                    switch ((Server.Property)wrapProperty.n)
                    {
                        case Server.Property.serverConfig:
                            break;
                        case Server.Property.instanceId:
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
                        case Server.Property.disconnectTime:
                            break;
                        case Server.Property.roomManager:
                            break;
                        case Server.Property.globalChat:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Server.Property.friendWorld:
                            dirty = true;
                            break;
                        case Server.Property.guilds:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is GlobalChat)
                {
                    switch ((GlobalChat.Property)wrapProperty.n)
                    {
                        case GlobalChat.Property.general:
                            dirty = true;
                            break;
                        case GlobalChat.Property.shortQuestion:
                            dirty = true;
                            break;
                        case GlobalChat.Property.suggestion:
                            dirty = true;
                            break;
                        case GlobalChat.Property.bugReport:
                            dirty = true;
                            break;
                        case GlobalChat.Property.offTopic:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            if (wrapProperty.p is GlobalRoomsUI.UIData)
            {
                return;
            }
            // chats
            {
                // globalChatUIData
                {
                    if (wrapProperty.p is GlobalChatUI.UIData)
                    {
                        switch ((GlobalChatUI.UIData.Property)wrapProperty.n)
                        {
                            case GlobalChatUI.UIData.Property.server:
                                break;
                            case GlobalChatUI.UIData.Property.chatRoomUIData:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case GlobalChatUI.UIData.Property.btnChooseChatUIDatas:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is ChatRoomUI.UIData)
                    {
                        switch ((ChatRoomUI.UIData.Property)wrapProperty.n)
                        {
                            case ChatRoomUI.UIData.Property.chatRoom:
                                dirty = true;
                                break;
                            case ChatRoomUI.UIData.Property.needHeader:
                                break;
                            case ChatRoomUI.UIData.Property.topicUI:
                                break;
                            case ChatRoomUI.UIData.Property.chatRoomAdapter:
                                break;
                            case ChatRoomUI.UIData.Property.typingUI:
                                break;
                            case ChatRoomUI.UIData.Property.chatMessageMenu:
                                break;
                            case ChatRoomUI.UIData.Property.canSendMessage:
                                break;
                            case ChatRoomUI.UIData.Property.btnLoadMore:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                if (wrapProperty.p is ChatRoomNewMessageCountUI.UIData)
                {
                    return;
                }
            }
            // friends
            {
                if (wrapProperty.p is GlobalFriendsUI.UIData)
                {
                    return;
                }
                if(wrapProperty.p is FriendListNewMessageCountUI.UIData)
                {
                    return;
                }
            }
            // profile
            {
                if (wrapProperty.p is GlobalProfileUI.UIData)
                {
                    return;
                }
                if(wrapProperty.p is ProfileNewMessageCountUI.UIData)
                {
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region btns

    public void onClickBtnRooms()
    {
        if (this.data != null)
        {
            this.data.show.v = UIData.Show.rooms;
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public void onClickBtnChats()
    {
        if (this.data != null)
        {
            this.data.show.v = UIData.Show.chats;
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public void onClickBtnFriends()
    {
        if (this.data != null)
        {
            this.data.show.v = UIData.Show.friends;
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public void onClickBtnProfile()
    {
        if (this.data != null)
        {
            this.data.show.v = UIData.Show.profile;
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    #endregion

}