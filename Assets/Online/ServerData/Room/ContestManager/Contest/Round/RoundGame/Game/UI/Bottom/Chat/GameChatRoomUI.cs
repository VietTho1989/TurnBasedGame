using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class GameChatRoomUI : UIBehavior<GameChatRoomUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<ChatRoom>> chatRoom;

        public VP<ChatRoomUI.UIData> chatRoomUIData;

        #region showAnimation

        public VP<ShowAnimationUI.UIData> showAnimation;

        public void OnHide()
        {
            GameChatRoomUI gameChatRoomUI = this.findCallBack<GameChatRoomUI>();
            if (gameChatRoomUI != null)
            {
                gameChatRoomUI.back();
            }
            else
            {
                Debug.LogError("gameChatRoomUI null");
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            chatRoom,
            chatRoomUIData,
            showAnimation
        }

        public UIData() : base()
        {
            this.chatRoom = new VP<ReferenceData<ChatRoom>>(this, (byte)Property.chatRoom, new ReferenceData<ChatRoom>(null));
            // chatRoomUIData
            {
                this.chatRoomUIData = new VP<ChatRoomUI.UIData>(this, (byte)Property.chatRoomUIData, new ChatRoomUI.UIData());
                this.chatRoomUIData.v.needHeader.v = false;
            }
            // showAnimation
            {
                this.showAnimation = new VP<ShowAnimationUI.UIData>(this, (byte)Property.showAnimation, new ShowAnimationUI.UIData());
                this.showAnimation.v.onHide.v = OnHide;
            }
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
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
                        Debug.LogError("chatRoomUIData null");
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        GameChatRoomUI gameChatRoomUI = this.findCallBack<GameChatRoomUI>();
                        if (gameChatRoomUI != null)
                        {
                            gameChatRoomUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("gameChatRoomUI null");
                        }
                        isProcess = true;
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        GameChatRoomUI gameChatRoomUI = this.findCallBack<GameChatRoomUI>();
                        if (gameChatRoomUI != null)
                        {
                            isProcess = gameChatRoomUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("gameChatRoomUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Game Messages");

    public Image bgNotAllowChat;
    public Text tvNotAllowChat;
    private static readonly TxtLanguage txtNotAllowChat = new TxtLanguage("Only player can chat");

    static GameChatRoomUI()
    {
        txtTitle.add(Language.Type.vi, "Thông Báo");
        txtNotAllowChat.add(Language.Type.vi, "Chỉ người chơi có thể chat");
    }

    #endregion

    #region Refresh

    public Button btnBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                ChatRoom chatRoom = this.data.chatRoom.v.data;
                if (chatRoom != null)
                {
                    // chatRoomUIData
                    {
                        ChatRoomUI.UIData chatRoomUIData = this.data.chatRoomUIData.v;
                        if (chatRoomUIData != null)
                        {
                            chatRoomUIData.chatRoom.v = new ReferenceData<ChatRoom>(chatRoom);
                        }
                        else
                        {
                            Debug.LogError("chatRoomUIData null");
                        }
                    }
                    // bgNotAllowChat
                    {
                        if (bgNotAllowChat != null)
                        {
                            if (!Room.isYouAdmin(chatRoom))
                            {
                                bool isYouPlayer = false;
                                {
                                    ContestManagerStatePlay contestManagerStatePlay = chatRoom.findDataInParent<ContestManagerStatePlay>();
                                    if (contestManagerStatePlay != null)
                                    {
                                        uint profileId = Server.getProfileUserId(chatRoom);
                                        foreach(MatchTeam matchTeam in contestManagerStatePlay.teams.vs)
                                        {
                                            foreach(TeamPlayer teamPlayer in matchTeam.players.vs)
                                            {
                                                if (teamPlayer.inform.v is Human)
                                                {
                                                    Human human = teamPlayer.inform.v as Human;
                                                    if (human.playerId.v == profileId)
                                                    {
                                                        isYouPlayer = true;
                                                        break;
                                                    }
                                                }
                                            }
                                            if (isYouPlayer)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("contestManagerStatePlay null");
                                    }
                                }
                                bgNotAllowChat.gameObject.SetActive(!isYouPlayer);
                            }
                            else
                            {
                                bgNotAllowChat.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            Debug.LogError("bgNotAllowChat null");
                        }
                    }
                    // UI Sibling Index
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.transform.SetSiblingIndex(0);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        UIRectTransform.SetSiblingIndex(this.data.chatRoomUIData.v, 1);
                        if (btnBack != null)
                        {
                            btnBack.transform.SetSiblingIndex(2);
                        }
                        else
                        {
                            Debug.LogError("btnBack null");
                        }
                        if (bgNotAllowChat != null)
                        {
                            bgNotAllowChat.transform.SetSiblingIndex(3);
                        }
                        else
                        {
                            Debug.LogError("bgNotAllowChat null");
                        }
                    }
                    // UI
                    {
                        float buttonSize = Setting.get().getButtonSize();
                        float deltaY = 0;
                        // header
                        {
                            UIRectTransform.SetButtonTopLeftTransform(btnBack);
                            UIRectTransform.SetTitleTransform(lbTitle);
                            deltaY += buttonSize;
                        }
                        // chatRoom
                        {
                            UIRectTransform rect = UIRectTransform.CreateFullRect(0, 0, buttonSize, 0);
                            UIRectTransform.Set(this.data.chatRoomUIData.v, rect);
                            deltaY += 180;
                        }
                        // set height
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        if (tvNotAllowChat != null)
                        {
                            tvNotAllowChat.text = txtNotAllowChat.get();
                        }
                        else
                        {
                            Debug.LogError("tvNotAllowChat null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("chatRoom null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public ChatRoomUI chatRoomPrefab;

    public ShowAnimationUI showAnimationUI;

    private Room room = null;
    private RoomCheckChangeAdminChange<Room> roomCheckChangeAdminChange = new RoomCheckChangeAdminChange<Room>();

    private ContestManagerStatePlay contestManagerStatePlay = null;
    private ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay> contestManagerStatePlayTeamCheckChange = new ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>();

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.chatRoom.allAddCallBack(this);
                uiData.chatRoomUIData.allAddCallBack(this);
                uiData.showAnimation.allAddCallBack(this);
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
            // chatRoom
            {
                if (data is ChatRoom)
                {
                    ChatRoom chatRoom = data as ChatRoom;
                    // Parent
                    {
                        DataUtils.addParentCallBack(chatRoom, this, ref this.room);
                        DataUtils.addParentCallBack(chatRoom, this, ref this.contestManagerStatePlay);
                    }
                    dirty = true;
                    return;
                }
                // Parent
                {
                    // room
                    {
                        if(data is Room)
                        {
                            Room room = data as Room;
                            // checkChange
                            {
                                roomCheckChangeAdminChange.addCallBack(this);
                                roomCheckChangeAdminChange.setData(room);
                            }
                            dirty = true;
                            return;
                        }
                        // checkChange
                        if(data is RoomCheckChangeAdminChange<Room>)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    // contestManagerStatePlay
                    {
                        if(data is ContestManagerStatePlay)
                        {
                            ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                            // checkChange
                            {
                                contestManagerStatePlayTeamCheckChange.addCallBack(this);
                                contestManagerStatePlayTeamCheckChange.setData(contestManagerStatePlay);
                            }
                            dirty = true;
                            return;
                        }
                        // checkChange
                        if(data is ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            if (data is ChatRoomUI.UIData)
            {
                ChatRoomUI.UIData chatRoomUIData = data as ChatRoomUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(chatRoomUIData, chatRoomPrefab, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is ShowAnimationUI.UIData)
            {
                ShowAnimationUI.UIData showAnimationUIData = data as ShowAnimationUI.UIData;
                // UI
                {
                    if (showAnimationUI != null)
                    {
                        showAnimationUI.setData(showAnimationUIData);
                    }
                    else
                    {
                        Debug.LogError("showAnimationUI null");
                    }
                }
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
                uiData.chatRoom.allRemoveCallBack(this);
                uiData.chatRoomUIData.allRemoveCallBack(this);
                uiData.showAnimation.allRemoveCallBack(this);
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
            // chatRoom
            {
                if (data is ChatRoom)
                {
                    ChatRoom chatRoom = data as ChatRoom;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(chatRoom, this, ref this.room);
                        DataUtils.removeParentCallBack(chatRoom, this, ref this.contestManagerStatePlay);
                    }
                    return;
                }
                // Parent
                {
                    // room
                    {
                        if (data is Room)
                        {
                            // Room room = data as Room;
                            // checkChange
                            {
                                roomCheckChangeAdminChange.removeCallBack(this);
                                roomCheckChangeAdminChange.setData(null);
                            }
                            return;
                        }
                        // checkChange
                        if (data is RoomCheckChangeAdminChange<Room>)
                        {
                            return;
                        }
                    }
                    // contestManagerStatePlay
                    {
                        if (data is ContestManagerStatePlay)
                        {
                            // ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                            // checkChange
                            {
                                contestManagerStatePlayTeamCheckChange.removeCallBack(this);
                                contestManagerStatePlayTeamCheckChange.setData(null);
                            }
                            return;
                        }
                        // checkChange
                        if (data is ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>)
                        {
                            return;
                        }
                    }
                }
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
            if (data is ShowAnimationUI.UIData)
            {
                ShowAnimationUI.UIData showAnimationUIData = data as ShowAnimationUI.UIData;
                // UI
                {
                    if (showAnimationUI != null)
                    {
                        showAnimationUI.setDataNull(showAnimationUIData);
                    }
                    else
                    {
                        Debug.LogError("showAnimationUI null");
                    }
                }
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
                case UIData.Property.chatRoom:
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
                case UIData.Property.showAnimation:
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
            // chatRoom
            {
                if (wrapProperty.p is ChatRoom)
                {
                    return;
                }
                // Parent
                {
                    // room
                    {
                        if (wrapProperty.p is Room)
                        {
                            return;
                        }
                        // checkChange
                        if (wrapProperty.p is RoomCheckChangeAdminChange<Room>)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    // contestManagerStatePlay
                    {
                        if (wrapProperty.p is ContestManagerStatePlay)
                        {
                            return;
                        }
                        // checkChange
                        if (wrapProperty.p is ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            if (wrapProperty.p is ChatRoomUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is ShowAnimationUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region back

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            if (showAnimationUI != null)
            {
                ShowAnimationUI.UIData showAnimationUIData = this.data.showAnimation.v;
                if (showAnimationUIData != null)
                {
                    showAnimationUIData.hide();
                }
                else
                {
                    Debug.LogError("showAnimationUIData null");
                }
            }
            else
            {
                Debug.LogError("showAnimationUI null");
                back();
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    private void back()
    {
        if (this.data != null)
        {
            GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
            if (gameUIData != null)
            {
                gameUIData.gameChatRoom.v = null;
            }
            else
            {
                Debug.LogError("gameUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    #endregion

}