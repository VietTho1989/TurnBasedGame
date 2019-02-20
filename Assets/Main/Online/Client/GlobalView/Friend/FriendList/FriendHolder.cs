using UnityEngine;
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

        public VP<NewChatMessageNumberUI.UIData> newChatMessageNumber;

        #region Constructor

        public enum Property
        {
            friend,
            friendStateUIData,
            accountAvatar,
            newChatMessageNumber
        }

        public UIData() : base()
        {
            this.friend = new VP<ReferenceData<Friend>>(this, (byte)Property.friend, new ReferenceData<Friend>(null));
            this.accountAvatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.accountAvatar, new AccountAvatarUI.UIData());
            this.friendStateUIData = new VP<FriendStateUI.UIData>(this, (byte)Property.friendStateUIData, new FriendStateUI.UIData());
            this.newChatMessageNumber = new VP<NewChatMessageNumberUI.UIData>(this, (byte)Property.newChatMessageNumber, new NewChatMessageNumberUI.UIData());
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
    }

    #endregion

    #region Refresh

    #region txt

    public Text tvViewDetail;
    public static readonly TxtLanguage txtViewDetail = new TxtLanguage();

    public Text tvName;

    public Text tvId;

    public Text tvStatus;
    private static readonly TxtLanguage txtStatus = new TxtLanguage();
    public Text tvStatusPlaceHolder;
    private static readonly TxtLanguage txtNoStatus = new TxtLanguage();

    public Text tvSex;

    static FriendHolder()
    {
        // txt
        {
            txtViewDetail.add(Language.Type.vi, "Xem chi tiết");
            // status
            {
                txtStatus.add(Language.Type.vi, "Status:");
                txtNoStatus.add(Language.Type.vi, "Không status");
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
                // anchoredPosition: (7.0, -32.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                // offsetMin: (-23.0, -62.0); offsetMax: (7.0, -32.0); sizeDelta: (30.0, 30.0);
                newChatMessageNumberRect.anchoredPosition = new Vector3(7.0f, -32.0f, 0.0f);
                newChatMessageNumberRect.anchorMin = new Vector2(1.0f, 1.0f);
                newChatMessageNumberRect.anchorMax = new Vector2(1.0f, 1.0f);
                newChatMessageNumberRect.pivot = new Vector2(1.0f, 1.0f);
                newChatMessageNumberRect.offsetMin = new Vector2(-23.0f, -62.0f);
                newChatMessageNumberRect.offsetMax = new Vector2(7.0f, -32.0f);
                newChatMessageNumberRect.sizeDelta = new Vector2(30.0f, 30.0f);
            }
        }
    }

    #endregion

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
                                    tvStatus.text = txtStatus.get("Status: ") + human.status.v;
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
                                tvStatusPlaceHolder.text = txtNoStatus.get("No status");
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
                    // newChatMessageNumber
                    {
                        NewChatMessageNumberUI.UIData newChatMessageNumber = this.data.newChatMessageNumber.v;
                        if (newChatMessageNumber != null)
                        {
                            newChatMessageNumber.chatRoom.v = new ReferenceData<ChatRoom>(friend.chatRoom.v);
                        }
                        else
                        {
                            Debug.LogError("newChatMessageNumber null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("friend null: " + this);
                }
                // txt
                {
                    if (tvViewDetail != null)
                    {
                        tvViewDetail.text = txtViewDetail.get("View Detail");
                    }
                    else
                    {
                        Debug.LogError("tvViewDetail null: " + this);
                    }
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

    public NewChatMessageNumberUI newChatMessageNumberPrefab;
    private static readonly UIRectTransform newChatMessageNumberRect = new UIRectTransform();

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
                uiData.newChatMessageNumber.allAddCallBack(this);
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
            if (data is NewChatMessageNumberUI.UIData)
            {
                NewChatMessageNumberUI.UIData newChatMessageNumberUIData = data as NewChatMessageNumberUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(newChatMessageNumberUIData, newChatMessageNumberPrefab, this.transform, newChatMessageNumberRect);
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
                uiData.newChatMessageNumber.allRemoveCallBack(this);
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
            if (data is NewChatMessageNumberUI.UIData)
            {
                NewChatMessageNumberUI.UIData newChatMessageNumberUIData = data as NewChatMessageNumberUI.UIData;
                // UI
                {
                    newChatMessageNumberUIData.removeCallBackAndDestroy(typeof(NewChatMessageNumberUI));
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
                case UIData.Property.newChatMessageNumber:
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
            // newChatMessageNumber
            if (wrapProperty.p is NewChatMessageNumberUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

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