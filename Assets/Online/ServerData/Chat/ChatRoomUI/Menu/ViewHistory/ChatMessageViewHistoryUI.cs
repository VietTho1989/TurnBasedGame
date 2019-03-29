using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChatMessageViewHistoryUI : UIBehavior<ChatMessageViewHistoryUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<ChatNormalContent>> chatNormalContent;

        public VP<AccountAvatarUI.UIData> avatar;

        public VP<ChatMessageHistoryAdapter.UIData> historyAdapter;

        #region Constructor

        public enum Property
        {
            chatNormalContent,
            avatar,
            historyAdapter
        }

        public UIData() : base()
        {
            this.chatNormalContent = new VP<ReferenceData<ChatNormalContent>>(this, (byte)Property.chatNormalContent, new ReferenceData<ChatNormalContent>(null));
            this.avatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.avatar, new AccountAvatarUI.UIData());
            this.historyAdapter = new VP<ChatMessageHistoryAdapter.UIData>(this, (byte)Property.historyAdapter, new ChatMessageHistoryAdapter.UIData());
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // back
                if (!isProcess)
                {
                    ChatMessageViewHistoryUI chatMessageViewHistoryUI = this.findCallBack<ChatMessageViewHistoryUI>();
                    if (chatMessageViewHistoryUI != null)
                    {
                        chatMessageViewHistoryUI.onClickBtnBack();
                        isProcess = true;
                    }
                    else
                    {
                        Debug.LogError("chatMessageViewHistoryUI null");
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt, rect

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    static ChatMessageViewHistoryUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Xem Lịch Sử Thông Điệp");
        }
        // rect
        {
            // avatar
            {
                // anchoredPosition: (10.0, -35.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 1.0);
                // offsetMin: (10.0, -65.0); offsetMax: (40.0, -35.0); sizeDelta: (30.0, 30.0);
                avatarRect.anchoredPosition = new Vector3(10.0f, -35.0f, 0.0f);
                avatarRect.anchorMin = new Vector2(0.0f, 1.0f);
                avatarRect.anchorMax = new Vector2(0.0f, 1.0f);
                avatarRect.pivot = new Vector2(0.0f, 1.0f);
                avatarRect.offsetMin = new Vector2(10.0f, -65.0f);
                avatarRect.offsetMax = new Vector2(40.0f, -35.0f);
                avatarRect.sizeDelta = new Vector2(30.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    private Human humanOwner = null;

    public Text tvPlayerName;

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
                    // historyAdapter
                    {
                        ChatMessageHistoryAdapter.UIData historyAdapter = this.data.historyAdapter.v;
                        if (historyAdapter != null)
                        {
                            historyAdapter.chatNormalContent.v = new ReferenceData<ChatNormalContent>(chatNormalContent);
                        }
                        else
                        {
                            Debug.LogError("historyAdapter null");
                        }
                    }
                    // find human owner
                    {
                        // check old
                        if (humanOwner != null)
                        {
                            // isCorrect
                            bool isCorrect = false;
                            {
                                if (humanOwner.findDataInParent<ChatRoom>() == chatNormalContent.findDataInParent<ChatRoom>())
                                {
                                    if (humanOwner.playerId.v == chatNormalContent.owner.v)
                                    {
                                        isCorrect = true;
                                    }
                                }
                            }
                            // process
                            if (isCorrect)
                            {
                                // oldHumanOwner correct
                            }
                            else
                            {
                                humanOwner.removeCallBack(this);
                                humanOwner = null;
                            }
                        }
                        // find new
                        if (humanOwner == null)
                        {
                            humanOwner = ChatRoom.findHuman(chatNormalContent, chatNormalContent.owner.v);
                            if (humanOwner != null)
                            {
                                humanOwner.addCallBack(this);
                            }
                            else
                            {
                                Debug.LogError("don't find humanOwner: " + humanOwner);
                            }
                        }
                    }
                    // tvPlayerName
                    {
                        if (tvPlayerName != null)
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
                            tvPlayerName.text = strName;
                        }
                        else
                        {
                            Debug.LogError("tvPlayerName null");
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
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("View Chat Message History");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("chatNormalContent null");
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

    public AccountAvatarUI avatarPrefab;
    private static readonly UIRectTransform avatarRect = new UIRectTransform();

    public ChatMessageHistoryAdapter chatMessageHistoryAdapterPrefab;
    private static readonly UIRectTransform chatMessageHistoryRect = UIRectTransform.CreateFullRect(0, 0, 70, 0);

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
                uiData.historyAdapter.allAddCallBack(this);
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
                    dirty = true;
                    return;
                }
                // Parent
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
            if(data is ChatMessageHistoryAdapter.UIData)
            {
                ChatMessageHistoryAdapter.UIData chatMessageHistoryAdapterUIData = data as ChatMessageHistoryAdapter.UIData;
                // UI
                {
                    UIUtils.Instantiate(chatMessageHistoryAdapterUIData, chatMessageHistoryAdapterPrefab, this.transform, chatMessageHistoryRect);
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
                uiData.historyAdapter.allRemoveCallBack(this);
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
                    return;
                }
                // Parent
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
            if (data is AccountAvatarUI.UIData)
            {
                AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
                // UI
                {
                    accountAvatarUIData.removeCallBackAndDestroy(typeof(AccountAvatarUI));
                }
                return;
            }
            if (data is ChatMessageHistoryAdapter.UIData)
            {
                ChatMessageHistoryAdapter.UIData chatMessageHistoryAdapterUIData = data as ChatMessageHistoryAdapter.UIData;
                // UI
                {
                    chatMessageHistoryAdapterUIData.removeCallBackAndDestroy(typeof(ChatMessageHistoryAdapter));
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
                case UIData.Property.historyAdapter:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("Don't process");
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
            // ChatNormalContent
            {
                if (wrapProperty.p is ChatNormalContent)
                {
                    switch ((ChatNormalContent.Property)wrapProperty.n)
                    {
                        case ChatNormalContent.Property.owner:
                            dirty = true;
                            break;
                        case ChatNormalContent.Property.message:
                            break;
                        case ChatNormalContent.Property.edits:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Parent
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
            if (wrapProperty.p is AccountAvatarUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is ChatMessageHistoryAdapter.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            ChatMessageMenuUI.UIData chatMessageMenuUIData = this.data.findDataInParent<ChatMessageMenuUI.UIData>();
            if (chatMessageMenuUIData != null)
            {
                chatMessageMenuUIData.viewHistory.v = null;
            }
            else
            {
                Debug.LogError("chatMessageMenuUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}