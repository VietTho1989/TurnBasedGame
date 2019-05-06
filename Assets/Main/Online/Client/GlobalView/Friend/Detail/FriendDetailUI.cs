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

        public VP<HumanUI.UIData> humanUIData;

        public VP<ChatRoomUI.UIData> chatRoom;

        #region Constructor

        public enum Property
        {
            friend,
            humanUIData,
            chatRoom
        }

        public UIData() : base()
        {
            this.friend = new VP<ReferenceData<Friend>>(this, (byte)Property.friend, new ReferenceData<Friend>(null));
            // humanUIData
            {
                this.humanUIData = new VP<HumanUI.UIData>(this, (byte)Property.humanUIData, new HumanUI.UIData());
                this.humanUIData.v.editHuman.v.canEdit.v = false;
                this.humanUIData.v.showType.v = UIRectTransform.ShowType.HeadLess;
                this.humanUIData.v.ban.v = null;
            }
            // chatRoom
            {
                this.chatRoom = new VP<ChatRoomUI.UIData>(this, (byte)Property.chatRoom, new ChatRoomUI.UIData());
                this.chatRoom.v.needHeader.v = false;
            }
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // chatRoom
                if (!isProcess)
                {
                    ChatRoomUI.UIData chatRoomUIData = this.chatRoom.v;
                    if (chatRoomUIData != null)
                    {
                        isProcess = chatRoomUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("chatRoomUIData null: " + this);
                    }
                }
                // btnBack
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        FriendDetailUI friendDetailUI = this.findCallBack<FriendDetailUI>();
                        if (friendDetailUI != null)
                        {
                            friendDetailUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("friendDetalUI null: " + this);
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        FriendDetailUI friendDetailUI = this.findCallBack<FriendDetailUI>();
                        if (friendDetailUI != null)
                        {
                            isProcess = friendDetailUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("friendDetailUI null: " + this);
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Friend Detail");

    static FriendDetailUI()
    {
        txtTitle.add(Language.Type.vi, "Thông Tin Chi Tiết Bạn Bè");
    }

    #endregion

    #region Refresh

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Friend friend = this.data.friend.v.data;
                if (friend != null)
                {
                    // ChatRoom
                    {
                        ChatRoomUI.UIData chatRoomUIData = this.data.chatRoom.v;
                        if (chatRoomUIData != null)
                        {
                            chatRoomUIData.chatRoom.v = new ReferenceData<ChatRoom>(friend.chatRoom.v);
                        }
                        else
                        {
                            Debug.LogError("chatRoomUIData null: " + this);
                        }
                    }
                    // human
                    {
                        HumanUI.UIData humanUIData = this.data.humanUIData.v;
                        if (humanUIData != null)
                        {
                            // find human
                            Human human = null;
                            {
                                uint profileId = Server.getProfileUserId(friend);
                                if (friend.user1Id.v != profileId)
                                {
                                    human = friend.user1.v;
                                }
                                else
                                {
                                    human = friend.user2.v;
                                }
                            }
                            // set
                            humanUIData.editHuman.v.origin.v = new ReferenceData<Human>(human);
                        }
                        else
                        {
                            Debug.LogError("humanUIData null");
                        }
                    }
                    // title
                    {
                        if (lbTitle != null)
                        {
                            string friendName = friend.getName(Server.getProfileUserId(friend));
                            lbTitle.text = friendName;
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                    // txt
                    {

                    }
                }
                else
                {
                    Debug.LogError("friend null: " + this);
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

    public ChatRoomUI chatRoomPrefab;
    private static readonly UIRectTransform chatRoomRect = UIRectTransform.CreateFullRect(0, 0, UIConstants.HeaderHeight + 150.0f, 0);

    public HumanUI humanPrefab;
    public Transform humanContainer;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.friend.allAddCallBack(this);
                uiData.humanUIData.allAddCallBack(this);
                uiData.chatRoom.allAddCallBack(this);
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
            // friend
            {
                if (data is Friend)
                {
                    Friend friend = data as Friend;
                    // Child
                    {
                        friend.user1.allAddCallBack(this);
                        friend.user2.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Human)
                    {
                        Human human = data as Human;
                        // Child
                        {
                            human.account.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Account)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            if(data is HumanUI.UIData)
            {
                HumanUI.UIData humanUIData = data as HumanUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(humanUIData, humanPrefab, humanContainer);
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
                uiData.friend.allRemoveCallBack(this);
                uiData.humanUIData.allRemoveCallBack(this);
                uiData.chatRoom.allRemoveCallBack(this);
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
            // friend
            {
                if (data is Friend)
                {
                    Friend friend = data as Friend;
                    // Child
                    {
                        friend.user1.allRemoveCallBack(this);
                        friend.user2.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Human)
                    {
                        Human human = data as Human;
                        // Child
                        {
                            human.account.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Account)
                    {
                        return;
                    }
                }
            }
            if (data is HumanUI.UIData)
            {
                HumanUI.UIData humanUIData = data as HumanUI.UIData;
                // UI
                {
                    humanUIData.removeCallBackAndDestroy(typeof(HumanUI));
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
                case UIData.Property.friend:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.humanUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.chatRoom:
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
                case Setting.Property.contentTextSize:
                    dirty = true;
                    break;
                case Setting.Property.titleTextSize:
                    dirty = true;
                    break;
                case Setting.Property.labelTextSize:
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
            // friend
            {
                if (wrapProperty.p is Friend)
                {
                    switch ((Friend.Property)wrapProperty.n)
                    {
                        case Friend.Property.state:
                            break;
                        case Friend.Property.user1:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Friend.Property.user2:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Friend.Property.time:
                            break;
                        case Friend.Property.chatRoom:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if(wrapProperty.p is Human)
                    {
                        switch ((Human.Property)wrapProperty.n)
                        {
                            case Human.Property.playerId:
                                break;
                            case Human.Property.account:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
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
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if(wrapProperty.p is Account)
                    {
                        Account.OnUpdateSyncAccount(wrapProperty, this);
                        dirty = true;
                    }
                }
            }
            if(wrapProperty.p is HumanUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is ChatRoomUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            GlobalFriendsUI.UIData globalFriendsUIData = this.data.findDataInParent<GlobalFriendsUI.UIData>();
            if (globalFriendsUIData != null)
            {
                globalFriendsUIData.friendDetail.v = null;
            }
            else
            {
                Debug.LogError("globalFriendsUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}