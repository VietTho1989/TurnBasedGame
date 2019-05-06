﻿using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

public class FriendHolder : SriaHolderBehavior<FriendHolder.UIData>
{

    #region UIData

    public class UIData : BaseItemViewsHolder
    {

        public VP<ReferenceData<Friend>> friend;

        #region StateUI

        public VP<FriendStateUI.UIData> friendStateUIData;

        #endregion

        public VP<AccountAvatarUI.UIData> accountAvatar;

        public VP<ChatRoomNewMessageCountUI.UIData> chatRoomNewMessageCountUIData;

        #region Constructor

        public enum Property
        {
            friend,
            friendStateUIData,
            accountAvatar,
            chatRoomNewMessageCountUIData
        }

        public UIData() : base()
        {
            this.friend = new VP<ReferenceData<Friend>>(this, (byte)Property.friend, new ReferenceData<Friend>(null));
            this.accountAvatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.accountAvatar, new AccountAvatarUI.UIData());
            this.friendStateUIData = new VP<FriendStateUI.UIData>(this, (byte)Property.friendStateUIData, new FriendStateUI.UIData());
            this.chatRoomNewMessageCountUIData = new VP<ChatRoomNewMessageCountUI.UIData>(this, (byte)Property.chatRoomNewMessageCountUIData, new ChatRoomNewMessageCountUI.UIData());
        }

        #endregion

        public void updateView(FriendAdapter.UIData myParams)
        {
            // Find
            Friend friend = null;
            {
                if (ItemIndex >= 0 && ItemIndex < myParams.friends.Count)
                {
                    friend = myParams.friends[ItemIndex];
                }
                else
                {
                    Debug.LogError("ItemIdex error: " + this);
                }
            }
            // Update
            this.friend.v = new ReferenceData<Friend>(friend);
        }

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        FriendHolder friendHolder = this.findCallBack<FriendHolder>();
                        if (friendHolder != null)
                        {
                            isProcess = friendHolder.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("friendHolder null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text tvName;

    public Text tvId;

    public Text tvStatus;
    private static readonly TxtLanguage txtStatus = new TxtLanguage("Status");

    public Text tvStatusPlaceHolder;
    private static readonly TxtLanguage txtNoStatus = new TxtLanguage("No status");

    public Text tvSex;

    static FriendHolder()
    {
        // txt
        {
            // status
            {
                txtStatus.add(Language.Type.vi, "Tình trạng");
                txtNoStatus.add(Language.Type.vi, "Không tình trạng");
            }
        }
        // rect
        {
            // friendStateUIData
            {
                // anchoredPosition: (0.0, -124.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (0.0, -154.0); offsetMax: (0.0, -124.0); sizeDelta: (0.0, 30.0);
                friendStateRect.anchoredPosition = new Vector3(0.0f, -124.0f, 0.0f);
                friendStateRect.anchorMin = new Vector2(0.0f, 1.0f);
                friendStateRect.anchorMax = new Vector2(1.0f, 1.0f);
                friendStateRect.pivot = new Vector2(0.5f, 1.0f);
                friendStateRect.offsetMin = new Vector2(0.0f, -154.0f);
                friendStateRect.offsetMax = new Vector2(0.0f, -124.0f);
                friendStateRect.sizeDelta = new Vector2(0.0f, 30.0f);
            }
            // accountAvatar
            {
                // anchoredPosition: (16.0, -36.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 1.0);
                // offsetMin: (16.0, -86.0); offsetMax: (66.0, -36.0); sizeDelta: (50.0, 50.0);
                accountAvatarRect.anchoredPosition = new Vector3(16.0f, -36.0f, 0.0f);
                accountAvatarRect.anchorMin = new Vector2(0.0f, 1.0f);
                accountAvatarRect.anchorMax = new Vector2(0.0f, 1.0f);
                accountAvatarRect.pivot = new Vector2(0.0f, 1.0f);
                accountAvatarRect.offsetMin = new Vector2(16.0f, -86.0f);
                accountAvatarRect.offsetMax = new Vector2(66.0f, -36.0f);
                accountAvatarRect.sizeDelta = new Vector2(50.0f, 50.0f);
            }
            // newChatMessageNumber
            {
                // anchoredPosition: (-8.0, -47.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                // offsetMin: (-23.0, -62.0); offsetMax: (-8.0, -47.0); sizeDelta: (15.0, 15.0);
                chatRoomNewMessageCountRect.anchoredPosition = new Vector3(-8.0f, -47.0f, 0.0f);
                chatRoomNewMessageCountRect.anchorMin = new Vector2(1.0f, 1.0f);
                chatRoomNewMessageCountRect.anchorMax = new Vector2(1.0f, 1.0f);
                chatRoomNewMessageCountRect.pivot = new Vector2(1.0f, 1.0f);
                chatRoomNewMessageCountRect.offsetMin = new Vector2(-23.0f, -62.0f);
                chatRoomNewMessageCountRect.offsetMax = new Vector2(-8.0f, -47.0f);
                chatRoomNewMessageCountRect.sizeDelta = new Vector2(15.0f, 15.0f);
            }
        }
    }

    #endregion

    #region Refresh

    public override void refresh()
    {
        base.refresh();
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Friend friend = this.data.friend.v.data;
                if (friend != null)
                {
                    // stateUIData
                    {
                        FriendStateUI.UIData stateUIData = this.data.friendStateUIData.v;
                        if (stateUIData != null)
                        {
                            stateUIData.friend.v = new ReferenceData<Friend>(friend);
                        }
                        else
                        {
                            Debug.LogError("stateUIData null: " + this);
                        }
                    }
                    // Human
                    {
                        // Find
                        Human human = null;
                        {
                            uint profileId = Server.getProfileUserId(friend);
                            if (friend.user1.v.playerId.v != profileId)
                            {
                                human = friend.user1.v;
                            }
                            if (friend.user2.v.playerId.v != profileId)
                            {
                                human = friend.user2.v;
                            }
                        }
                        // Process
                        if (human != null)
                        {
                            // accountAvatar
                            {
                                AccountAvatarUI.UIData accountAvatarUIData = this.data.accountAvatar.v;
                                if (accountAvatarUIData != null)
                                {
                                    accountAvatarUIData.account.v = new ReferenceData<Account>(human.account.v);
                                }
                                else
                                {
                                    Debug.LogError("accountAvatarUIData null: " + this);
                                }
                            }
                            // name
                            if (tvName != null)
                            {
                                tvName.text = human.account.v.getName();
                            }
                            else
                            {
                                Debug.LogError("tvName null");
                            }
                            // id
                            if (tvId != null)
                            {
                                tvId.text = "Id: " + human.playerId.v;
                            }
                            else
                            {
                                Debug.LogError("tvId null");
                            }
                            // status
                            if (tvStatus != null)
                            {
                                if (!string.IsNullOrEmpty(human.status.v))
                                {
                                    tvStatus.text = txtStatus.get()+": " + human.status.v;
                                }
                                else
                                {
                                    tvStatus.text = "";
                                }
                            }
                            else
                            {
                                Debug.LogError("tvStatus null");
                            }
                            // status place holder
                            if (tvStatusPlaceHolder != null)
                            {
                                tvStatusPlaceHolder.text = txtNoStatus.get();
                            }
                            else
                            {
                                Debug.LogError("tvStatusPlaceHolder null");
                            }
                            // sex
                            if (tvSex != null)
                            {
                                tvSex.text = User.getStrSex(human.sex.v);
                            }
                            else
                            {
                                Debug.LogError("tvSex null");
                            }
                        }
                        else
                        {
                            Debug.LogError("human null: " + this);
                        }
                    }
                    // chatRoomNewMessageCount
                    {
                        ChatRoomNewMessageCountUI.UIData chatRoomNewMessageCountUIData = this.data.chatRoomNewMessageCountUIData.v;
                        if (chatRoomNewMessageCountUIData != null)
                        {
                            chatRoomNewMessageCountUIData.chatRoom.v = new ReferenceData<ChatRoom>(friend.chatRoom.v);
                        }
                        else
                        {
                            Debug.LogError("chatRoomNewMessageCountUIData null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("friend null: " + this);
                }
                // txt
                {

                }
            }
            else
            {
                // Debug.LogError ("data null: " + this);
            }
        }
    }

    #endregion

    #region implement callBacks

    public FriendStateUI friendStatePrefab;
    private static readonly UIRectTransform friendStateRect = new UIRectTransform();

    public AccountAvatarUI accountAvatarPrefab;
    private static readonly UIRectTransform accountAvatarRect = new UIRectTransform();

    public ChatRoomNewMessageCountUI chatRoomNewMessageCountPrefab;
    private static readonly UIRectTransform chatRoomNewMessageCountRect = new UIRectTransform();

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
                uiData.friendStateUIData.allAddCallBack(this);
                uiData.accountAvatar.allAddCallBack(this);
                uiData.chatRoomNewMessageCountUIData.allAddCallBack(this);
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
            // Friend
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
            // friendStateUIData
            if (data is FriendStateUI.UIData)
            {
                FriendStateUI.UIData friendStateUIData = data as FriendStateUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(friendStateUIData, friendStatePrefab, this.transform, friendStateRect);
                }
                dirty = true;
                return;
            }
            // accountAvatar
            if (data is AccountAvatarUI.UIData)
            {
                AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(accountAvatarUIData, accountAvatarPrefab, this.transform, accountAvatarRect);
                }
                dirty = true;
                return;
            }
            // newChatMessageNumber
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
                uiData.friendStateUIData.allRemoveCallBack(this);
                uiData.accountAvatar.allRemoveCallBack(this);
                uiData.chatRoomNewMessageCountUIData.allRemoveCallBack(this);
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
            // Friend
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
            // friendStateUIData
            if (data is FriendStateUI.UIData)
            {
                FriendStateUI.UIData friendStateUIData = data as FriendStateUI.UIData;
                // UI
                {
                    friendStateUIData.removeCallBackAndDestroy(typeof(FriendStateUI));
                }
                return;
            }
            // accountAvatar
            if (data is AccountAvatarUI.UIData)
            {
                AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
                // UI
                {
                    accountAvatarUIData.removeCallBackAndDestroy(typeof(AccountAvatarUI));
                }
                return;
            }
            // newChatMessageNumber
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
                case UIData.Property.friendStateUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.accountAvatar:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.chatRoomNewMessageCountUIData:
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
            // Friend
            {
                if (wrapProperty.p is Friend)
                {
                    switch ((Friend.Property)wrapProperty.n)
                    {
                        case Friend.Property.state:
                            dirty = true;
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
                            dirty = true;
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
                if (wrapProperty.p is Human)
                {
                    switch ((Human.Property)wrapProperty.n)
                    {
                        case Human.Property.playerId:
                            dirty = true;
                            break;
                        case Human.Property.account:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Human.Property.state:
                            dirty = true;
                            break;
                        case Human.Property.email:
                            dirty = true;
                            break;
                        case Human.Property.phoneNumber:
                            dirty = true;
                            break;
                        case Human.Property.status:
                            dirty = true;
                            break;
                        case Human.Property.birthday:
                            dirty = true;
                            break;
                        case Human.Property.sex:
                            dirty = true;
                            break;
                        case Human.Property.connection:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // friendStateUIData
            if (wrapProperty.p is FriendStateUI.UIData)
            {
                return;
            }
            // accountAvatar
            if (wrapProperty.p is AccountAvatarUI.UIData)
            {
                return;
            }
            // chatRoomNewMessageCount
            if (wrapProperty.p is ChatRoomNewMessageCountUI.UIData)
            {
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
            UIUtils.SetButtonOnClick(btnViewDetail, onClickBtnViewDetail);
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
                    case KeyCode.V:
                        {
                            if (btnViewDetail != null && btnViewDetail.gameObject.activeInHierarchy && btnViewDetail.interactable)
                            {
                                this.onClickBtnViewDetail();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    public Button btnViewDetail;

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnViewDetail()
    {
        if (this.data != null)
        {
            Friend friend = this.data.friend.v.data;
            if (friend != null)
            {
                GlobalFriendsUI.UIData globalFriendsUIData = this.data.findDataInParent<GlobalFriendsUI.UIData>();
                if (globalFriendsUIData != null)
                {
                    FriendDetailUI.UIData friendDetailUIData = globalFriendsUIData.friendDetail.newOrOld<FriendDetailUI.UIData>();
                    {
                        friendDetailUIData.friend.v = new ReferenceData<Friend>(friend);
                    }
                    globalFriendsUIData.friendDetail.v = friendDetailUIData;
                }
                else
                {
                    Debug.LogError("globalFriendsUIData null: " + this);
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