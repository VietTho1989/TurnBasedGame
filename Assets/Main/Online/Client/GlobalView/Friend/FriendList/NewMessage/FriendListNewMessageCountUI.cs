using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FriendListNewMessageCountUI : UIBehavior<FriendListNewMessageCountUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<FriendWorld>> friendWorld;

        #region Constructor

        public enum Property
        {
            friendWorld
        }

        public UIData() : base()
        {
            this.friendWorld = new VP<ReferenceData<FriendWorld>>(this, (byte)Property.friendWorld, new ReferenceData<FriendWorld>(null));
        }

        #endregion

    }

    #endregion

    #region Refresh

    public Text tvNewCount;
    public Image bg;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                FriendWorld friendWorld = this.data.friendWorld.v.data;
                if (friendWorld != null)
                {
                    uint profileId = Server.getProfileUserId(friendWorld);
                    // find count
                    uint newCount = 0;
                    {
                        foreach (ChatRoom chatRoom in chatRooms)
                        {
                            // check correct
                            bool isCorrect = false;
                            {
                                Friend friend = chatRoom.findDataInParent<Friend>();
                                if (friend != null)
                                {
                                    if (friend.user1Id.v == profileId || friend.user2Id.v == profileId)
                                    {
                                        isCorrect = true;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("friend null");
                                }
                            }
                            // process
                            if (isCorrect)
                            {
                                uint count = 0;
                                {
                                    uint alreadyViewMaxId = 0;
                                    {
                                        // find chatViewer
                                        ChatViewer chatViewer = null;
                                        {
                                            foreach(ChatViewer check in chatRoom.chatViewers.vs)
                                            {
                                                if (check.userId.v == profileId)
                                                {
                                                    chatViewer = check;
                                                    break;
                                                }
                                            }
                                        }
                                        // process
                                        if (chatViewer != null)
                                        {
                                            alreadyViewMaxId = chatViewer.alreadyViewMaxId.v;
                                        }
                                    }
                                    count = chatRoom.maxId.v - alreadyViewMaxId;
                                }
                                newCount += count;
                            }
                            else
                            {
                                Debug.LogError("error, why not correct: " + chatRoom);
                            }
                        }
                    }
                    // set
                    if (tvNewCount != null && bg != null)
                    {
                        if (newCount <= 0)
                        {
                            tvNewCount.text = "";
                            bg.enabled = false;
                        }
                        else if (newCount <= 50)
                        {
                            tvNewCount.text = "" + newCount;
                            bg.enabled = true;
                        }
                        else
                        {
                            tvNewCount.text = "50+";
                            bg.enabled = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("tvNewCount, bg null");
                    }
                }
                else
                {
                    Debug.LogError("friendWorld null");
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

    private HashSet<ChatRoom> chatRooms = new HashSet<ChatRoom>();

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.friendWorld.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is FriendWorld)
            {
                FriendWorld friendWorld = data as FriendWorld;
                // Child
                {
                    uint profileId = Server.getProfileUserId(friendWorld);
                    foreach (Friend friend in friendWorld.friends.vs)
                    {
                        if (friend.user1Id.v == profileId || friend.user2Id.v == profileId)
                        {
                            friend.addCallBack(this);
                        }
                    }
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is Friend)
                {
                    Friend friend = data as Friend;
                    // Child
                    {
                        friend.chatRoom.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is ChatRoom)
                    {
                        ChatRoom chatRoom = data as ChatRoom;
                        // add
                        {
                            Debug.LogError("add chatRoom: " + chatRoom);
                            chatRooms.Add(chatRoom);
                        }
                        // Child
                        {
                            uint profileId = Server.getProfileUserId(chatRoom);
                            foreach (ChatViewer chatViewer in chatRoom.chatViewers.vs)
                            {
                                if (chatViewer.userId.v == profileId)
                                {
                                    chatViewer.addCallBack(this);
                                }
                            }
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is ChatViewer)
                    {
                        dirty = true;
                        return;
                    }
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
            // Child
            {
                uiData.friendWorld.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is FriendWorld)
            {
                FriendWorld friendWorld = data as FriendWorld;
                // Child
                {
                    friendWorld.friends.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            {
                if (data is Friend)
                {
                    Friend friend = data as Friend;
                    // Child
                    {
                        friend.chatRoom.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is ChatRoom)
                    {
                        ChatRoom chatRoom = data as ChatRoom;
                        // remove
                        {
                            Debug.LogError("remove chatRoom");
                            chatRooms.Remove(chatRoom);
                        }
                        // Child
                        {
                            chatRoom.chatViewers.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is ChatViewer)
                    {
                        return;
                    }
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
                case UIData.Property.friendWorld:
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
        // Child
        {
            if (wrapProperty.p is FriendWorld)
            {
                switch ((FriendWorld.Property)wrapProperty.n)
                {
                    case FriendWorld.Property.friends:
                        {
                            // find
                            List<T> addFriends = new List<T>();
                            List<T> removeFriends = new List<T>();
                            {
                                ValueChangeUtils.getAddAndRemoveValues(syncs, addFriends, removeFriends);
                            }
                            // process
                            {
                                uint profileId = Server.getProfileUserId(wrapProperty.p);
                                // add
                                foreach (T tFriend in addFriends)
                                {
                                    if (tFriend is Friend)
                                    {
                                        Friend friend = (Friend)(object)tFriend;
                                        if (friend.user1Id.v == profileId || friend.user2Id.v == profileId)
                                        {
                                            friend.addCallBack(this);
                                        }
                                    }
                                }
                                // remove
                                foreach (T friend in removeFriends)
                                {
                                    if (friend is Friend)
                                    {
                                        ((Friend)(object)friend).removeCallBack(this);
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is Friend)
                {
                    switch ((Friend.Property)wrapProperty.n)
                    {
                        case Friend.Property.state:
                            break;
                        case Friend.Property.user1Id:
                            dirty = true;
                            break;
                        case Friend.Property.user1:
                            break;
                        case Friend.Property.user2Id:
                            dirty = true;
                            break;
                        case Friend.Property.user2:
                            break;
                        case Friend.Property.time:
                            break;
                        case Friend.Property.chatRoom:
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
                // Child
                {
                    if (wrapProperty.p is ChatRoom)
                    {
                        switch ((ChatRoom.Property)wrapProperty.n)
                        {
                            case ChatRoom.Property.topic:
                                break;
                            case ChatRoom.Property.isEnable:
                                break;
                            case ChatRoom.Property.players:
                                break;
                            case ChatRoom.Property.messages:
                                break;
                            case ChatRoom.Property.maxId:
                                dirty = true;
                                break;
                            case ChatRoom.Property.chatViewers:
                                {
                                    // find
                                    List<T> addChatViewers = new List<T>();
                                    List<T> removeChatViewers = new List<T>();
                                    {
                                        ValueChangeUtils.getAddAndRemoveValues(syncs, addChatViewers, removeChatViewers);
                                    }
                                    // process
                                    {
                                        // add
                                        {
                                            uint profileId = Server.getProfileUserId(wrapProperty.p);
                                            foreach (T tChatViewer in addChatViewers)
                                            {
                                                if (tChatViewer is ChatViewer)
                                                {
                                                    ChatViewer addChatViewer = (ChatViewer)(object)tChatViewer;
                                                    if (addChatViewer.userId.v == profileId)
                                                    {
                                                        addChatViewer.addCallBack(this);
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("error, why not chatViewer: " + tChatViewer);
                                                }
                                            }
                                        }
                                        // remove
                                        {
                                            foreach (T tChatViewer in removeChatViewers)
                                            {
                                                if (tChatViewer is ChatViewer)
                                                {
                                                    ChatViewer removeChatViewer = (ChatViewer)(object)tChatViewer;
                                                    removeChatViewer.removeCallBack(this);
                                                }
                                                else
                                                {
                                                    Debug.LogError("error, why not chatViewer: " + tChatViewer);
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            case ChatRoom.Property.typing:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is ChatViewer)
                    {
                        switch ((ChatViewer.Property)wrapProperty.n)
                        {
                            case ChatViewer.Property.userId:
                                dirty = true;
                                break;
                            case ChatViewer.Property.minViewId:
                                break;
                            case ChatViewer.Property.subViews:
                                break;
                            case ChatViewer.Property.connection:
                                break;
                            case ChatViewer.Property.isActive:
                                break;
                            case ChatViewer.Property.alreadyViewMaxId:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}