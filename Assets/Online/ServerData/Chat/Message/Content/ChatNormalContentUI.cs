using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/**
 * TODO Co the can xac dinh co phai chatMessage cua minh ko
 * */
public class ChatNormalContentUI : UIBehavior<ChatNormalContentUI.UIData>
{

    #region UIData

    public class UIData : ChatMessageHolder.UIData.Sub
    {

        public VP<ReferenceData<ChatNormalContent>> chatNormalContent;

        public VP<AccountAvatarUI.UIData> avatar;

        #region Constructor

        public enum Property
        {
            chatNormalContent,
            avatar
        }

        public UIData() : base()
        {
            this.chatNormalContent = new VP<ReferenceData<ChatNormalContent>>(this, (byte)Property.chatNormalContent, new ReferenceData<ChatNormalContent>(null));
            // avatar
            this.avatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.avatar, new AccountAvatarUI.UIData());
        }

        #endregion

        public override ChatMessage.Content.Type getType()
        {
            return ChatMessage.Content.Type.Normal;
        }

    }

    #endregion

    #region txt, rect

    private static readonly TxtLanguage txtDelete = new TxtLanguage();
    private static readonly TxtLanguage txtTrueDelete = new TxtLanguage();

    static ChatNormalContentUI()
    {
        // txt
        {
            txtDelete.add(Language.Type.vi, "tin nhắn đã bị xoá");
            txtTrueDelete.add(Language.Type.vi, "tin nhắn đã bị loại bỏ");
        }
        // avatarRect
        {
            // anchoredPosition: (0.0, -5.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 1.0);
            // offsetMin: (0.0, -41.0); offsetMax: (36.0, -5.0); sizeDelta: (36.0, 36.0);
            avatarRect.anchoredPosition = new Vector3(0.0f, -4.0f, 0.0f);
            avatarRect.anchorMin = new Vector2(0.0f, 1.0f);
            avatarRect.anchorMax = new Vector2(0.0f, 1.0f);
            avatarRect.pivot = new Vector2(0.0f, 1.0f);
            avatarRect.offsetMin = new Vector2(0.0f, -34.0f);
            avatarRect.offsetMax = new Vector2(30.0f, -4.0f);
            avatarRect.sizeDelta = new Vector2(30.0f, 30.0f);
        }
    }

    #endregion

    #region Refresh

    public Text tvMessage;

    public Button btnMenu;

    private Human humanOwner = null;

    public Text tvNameTime;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                ChatNormalContent chatNormalContent = this.data.chatNormalContent.v.data;
                if (chatNormalContent != null)
                {
                    ChatMessage chatMessage = chatNormalContent.findDataInParent<ChatMessage>();
                    if (chatMessage != null)
                    {
                        // find human owner
                        {

                            Human humanOwner = ChatRoom.findHuman(chatNormalContent, chatNormalContent.owner.v);
                            if (this.humanOwner != humanOwner)
                            {
                                // remove old
                                if (this.humanOwner != null)
                                {
                                    this.humanOwner.removeCallBack(this);
                                }
                                // set new
                                this.humanOwner = humanOwner;
                                if (this.humanOwner != null)
                                {
                                    this.humanOwner.addCallBack(this);
                                }
                            }
                        }
                        // NameTime
                        {
                            if (tvNameTime != null)
                            {
                                string strName = "";
                                {
                                    if (humanOwner != null)
                                    {
                                        strName = humanOwner.getPlayerName();
                                    }
                                    else
                                    {
                                        Debug.LogError("human null");
                                    }
                                }
                                string strTime = "";
                                {
                                    strTime = chatMessage.TimestampAsDateTime.ToString("HH:mm");
                                }
                                tvNameTime.text = strName + ", " + strTime;
                            }
                            else
                            {
                                Debug.LogError("tvNameTime null");
                            }
                        }
                        // Message
                        {
                            if (tvMessage != null)
                            {
                                switch (chatMessage.state.v)
                                {
                                    case ChatMessage.State.Normal:
                                        {
                                            string message = "";
                                            {
                                                if (chatNormalContent.messages.vs.Count > 0)
                                                {
                                                    ChatNormalContent.Message contentMessage = chatNormalContent.messages.vs[chatNormalContent.messages.vs.Count - 1];
                                                    message = contentMessage.message;
                                                }
                                            }
                                            tvMessage.text = message;
                                        }
                                        break;
                                    case ChatMessage.State.Delete:
                                        {
                                            tvMessage.text = "<color=grey>" + txtDelete.get("this message has been deleted") + "</color>";
                                        }
                                        break;
                                    case ChatMessage.State.TrueDelete:
                                        {
                                            tvMessage.text = "<color=red>" + txtTrueDelete.get("this message has been removed") + "</color>";
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + chatMessage.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("tvMessage null: " + this);
                            }
                        }
                        // Avatar
                        {
                            AccountAvatarUI.UIData accountAvatarUIData = this.data.avatar.v;
                            if (accountAvatarUIData != null)
                            {
                                Account account = null;
                                {
                                    if (this.humanOwner != null)
                                    {
                                        account = this.humanOwner.account.v;
                                    }
                                }
                                accountAvatarUIData.account.v = new ReferenceData<Account>(account);
                            }
                            else
                            {
                                Debug.LogError("accountAvatarUIData null: " + this);
                            }
                        }
                        // btnMenu
                        {
                            if (btnMenu != null)
                            {
                                if (Server.getProfileUserId(chatNormalContent) == chatNormalContent.owner.v)
                                {
                                    btnMenu.interactable = true;
                                }
                                else
                                {
                                    btnMenu.interactable = false;
                                }
                            }
                            else
                            {
                                Debug.LogError("btnMenu null: " + this);
                            }
                        }
                        // Color
                        {
                            Image image = this.GetComponent<Image>();
                            if (image != null)
                            {
                                int index = 0;
                                {
                                    ChatMessageHolder.UIData holder = this.data.findDataInParent<ChatMessageHolder.UIData>();
                                    if (holder != null)
                                    {
                                        index = holder.ItemIndex;
                                    }
                                    else
                                    {
                                        Debug.LogError("holder null: " + this);
                                    }
                                }
                                switch (index % 2)
                                {
                                    case 0:
                                        image.color = new Color(1f, 1f, 1f, 1f);
                                        break;
                                    case 1:
                                        image.color = new Color(1f, 1f, 1f, 1);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("image null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("chatMessage null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("chatNormalContent null: " + this);
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

    public override void OnDestroy()
    {
        base.OnDestroy();
        if (this.humanOwner != null)
        {
            this.humanOwner.removeCallBack(this);
            this.humanOwner = null;
        }
        else
        {
            // Debug.LogError ("human owner null: " + this);
        }
    }

    #endregion

    #region implement callBacks

    private ChatMessage chatMessage = null;

    public AccountAvatarUI avatarPrefab;
    private static readonly UIRectTransform avatarRect = new UIRectTransform();

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.chatNormalContent.allAddCallBack(this);
                uiData.avatar.allAddCallBack(this);
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
            // ChatNormalContent
            {
                if (data is ChatNormalContent)
                {
                    ChatNormalContent chatNormalContent = data as ChatNormalContent;
                    // Parent
                    {
                        DataUtils.addParentCallBack(chatNormalContent, this, ref this.chatMessage);
                    }
                    dirty = true;
                    return;
                }
                // Parent
                {
                    if (data is ChatMessage)
                    {
                        dirty = true;
                        return;
                    }
                    // Human
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
            }
            if (data is AccountAvatarUI.UIData)
            {
                AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(accountAvatarUIData, avatarPrefab, this.transform, avatarRect);
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
                uiData.chatNormalContent.allRemoveCallBack(this);
                uiData.avatar.allRemoveCallBack(this);
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
            // ChatNormalContent
            {
                if (data is ChatNormalContent)
                {
                    ChatNormalContent chatNormalContent = data as ChatNormalContent;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(chatNormalContent, this, ref this.chatMessage);
                    }
                    return;
                }
                // Parent
                {
                    if (data is ChatMessage)
                    {
                        return;
                    }
                    // Human
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
            }
            if (data is AccountAvatarUI.UIData)
            {
                AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
                // UI
                {
                    accountAvatarUIData.removeCallBackAndDestroy(typeof(AccountAvatarUI));
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
                case UIData.Property.chatNormalContent:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.avatar:
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
            // ChatNormalContent
            {
                if (wrapProperty.p is ChatNormalContent)
                {
                    switch ((ChatNormalContent.Property)wrapProperty.n)
                    {
                        case ChatNormalContent.Property.owner:
                            dirty = true;
                            break;
                        case ChatNormalContent.Property.messages:
                            dirty = true;
                            break;
                        case ChatNormalContent.Property.editMax:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Parent
                {
                    if (wrapProperty.p is ChatMessage)
                    {
                        switch ((ChatMessage.Property)wrapProperty.n)
                        {
                            case ChatMessage.Property.state:
                                dirty = true;
                                break;
                            case ChatMessage.Property.time:
                                dirty = true;
                                break;
                            case ChatMessage.Property.content:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Human
                    {
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
                        if (wrapProperty.p is Account)
                        {
                            Account.OnUpdateSyncAccount(wrapProperty, this);
                            return;
                        }
                    }
                }
            }
            if (wrapProperty.p is AccountAvatarUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnMenu()
    {
        if (this.data != null)
        {
            ChatNormalContent chatNormalContent = this.data.chatNormalContent.v.data;
            if (chatNormalContent != null)
            {
                if (chatNormalContent.isMine())
                {
                    ChatMessage chatMessage = chatNormalContent.findDataInParent<ChatMessage>();
                    if (chatMessage != null)
                    {
                        ChatRoomUI.UIData chatRoomUIData = this.data.findDataInParent<ChatRoomUI.UIData>();
                        if (chatRoomUIData != null)
                        {
                            ChatMessageMenuUI.UIData chatMessageMenuUIData = chatRoomUIData.chatMessageMenu.newOrOld<ChatMessageMenuUI.UIData>();
                            {
                                chatMessageMenuUIData.chatMessage.v = new ReferenceData<ChatMessage>(chatMessage);
                            }
                            chatRoomUIData.chatMessageMenu.v = chatMessageMenuUIData;
                        }
                        else
                        {
                            Debug.LogError("chatRoomUIData null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("chatMessage null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("not your message: " + this);
                }
            }
            else
            {
                Debug.LogError("chatNormalContent null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}