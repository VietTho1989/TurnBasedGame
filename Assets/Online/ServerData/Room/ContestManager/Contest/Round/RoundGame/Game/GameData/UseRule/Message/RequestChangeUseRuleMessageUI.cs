using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeUseRuleMessageUI : UIBehavior<RequestChangeUseRuleMessageUI.UIData>
{

    #region UIData

    public class UIData : ChatMessageHolder.UIData.Sub
    {

        public VP<ReferenceData<RequestChangeUseRuleMessage>> requestChangeUseRuleMessage;

        public VP<AccountAvatarUI.UIData> avatar;

        #region Constructor

        public enum Property
        {
            requestChangeUseRuleMessage,
            avatar
        }

        public UIData() : base()
        {
            this.requestChangeUseRuleMessage = new VP<ReferenceData<RequestChangeUseRuleMessage>>(this, (byte)Property.requestChangeUseRuleMessage, new ReferenceData<RequestChangeUseRuleMessage>(null));
            this.avatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.avatar, new AccountAvatarUI.UIData());
        }

        #endregion

        public override ChatMessage.Content.Type getType()
        {
            return ChatMessage.Content.Type.RequestChangeUseRule;
        }

    }

    #endregion

    #region txt, rect

    static RequestChangeUseRuleMessageUI()
    {
        // avatarRect
        {
            // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 0.5); anchorMax: (0.0, 0.5); pivot: (0.0, 0.5);
            // offsetMin: (0.0, -18.0); offsetMax: (36.0, 18.0); sizeDelta: (36.0, 36.0);
            avatarRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
            avatarRect.anchorMin = new Vector2(0.0f, 0.5f);
            avatarRect.anchorMax = new Vector2(0.0f, 0.5f);
            avatarRect.pivot = new Vector2(0.0f, 0.5f);
            avatarRect.offsetMin = new Vector2(0.0f, -15.0f);
            avatarRect.offsetMax = new Vector2(30.0f, 15.0f);
            avatarRect.sizeDelta = new Vector2(30.0f, 30.0f);
        }
    }

    #endregion

    #region Refresh

    public Text tvContent;
    public Text tvTime;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                RequestChangeUseRuleMessage requestChangeUseRuleMessage = this.data.requestChangeUseRuleMessage.v.data;
                if (requestChangeUseRuleMessage != null)
                {
                    ChatMessage chatMessage = requestChangeUseRuleMessage.findDataInParent<ChatMessage>();
                    if (chatMessage != null)
                    {
                        // Find human
                        {
                            // check old
                            if (human != null)
                            {
                                // isCorrect
                                bool isCorrect = false;
                                {
                                    if (human.findDataInParent<ChatRoom>() == requestChangeUseRuleMessage.findDataInParent<ChatRoom>())
                                    {
                                        if (human.playerId.v == requestChangeUseRuleMessage.userId.v)
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
                                    human.removeCallBack(this);
                                    human = null;
                                }
                            }
                            // find new
                            if (human == null)
                            {
                                human = ChatRoom.findHuman(requestChangeUseRuleMessage, requestChangeUseRuleMessage.userId.v);
                                if (human != null)
                                {
                                    human.addCallBack(this);
                                }
                                else
                                {
                                    Debug.LogError("don't find humanOwner: " + human);
                                }
                            }
                        }
                        // Avatar
                        {
                            AccountAvatarUI.UIData accountAvatarUIData = this.data.avatar.v;
                            if (accountAvatarUIData != null)
                            {
                                Account account = null;
                                {
                                    if (this.human != null)
                                    {
                                        account = this.human.account.v;
                                    }
                                }
                                accountAvatarUIData.account.v = new ReferenceData<Account>(account);
                            }
                            else
                            {
                                Debug.LogError("accountAvatarUIData null: " + this);
                            }
                        }
                        // time
                        {
                            if (tvTime != null)
                            {
                                tvTime.text = chatMessage.TimestampAsDateTime.ToString("HH:mm");
                            }
                            else
                            {
                                Debug.LogError("tvTime null");
                            }
                        }
                        // content
                        {
                            if (tvContent != null)
                            {
                                // Find user name
                                string userName = "";
                                {
                                    if (this.human != null)
                                    {
                                        userName = this.human.getPlayerName();
                                    }
                                    else
                                    {
                                        Debug.LogError("human null: " + this);
                                    }
                                }
                                // set
                                tvContent.text = requestChangeUseRuleMessage.getMessage(userName);
                            }
                            else
                            {
                                Debug.LogError("tvContent null");
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
                    Debug.LogError("chatRoomUserStateContent null: " + this);
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

    public override void OnDestroy()
    {
        base.OnDestroy();
        if (this.human != null)
        {
            this.human.removeCallBack(this);
            this.human = null;
        }
        else
        {
            // Debug.LogError ("human null: " + this);
        }
    }

    #endregion

    #region implement callBacks

    private ChatMessage chatMessage = null;

    public AccountAvatarUI avatarPrefab;
    private static readonly UIRectTransform avatarRect = new UIRectTransform();

    private Human human = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.requestChangeUseRuleMessage.allAddCallBack(this);
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
            // RequestChangeUseRuleMessage
            {
                if (data is RequestChangeUseRuleMessage)
                {
                    RequestChangeUseRuleMessage requestChangeUseRuleMessage = data as RequestChangeUseRuleMessage;
                    // Parent
                    {
                        DataUtils.addParentCallBack(requestChangeUseRuleMessage, this, ref this.chatMessage);
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
                        // child
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
                uiData.requestChangeUseRuleMessage.allRemoveCallBack(this);
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
            // RequestChangeUseRuleMessage
            {
                if (data is RequestChangeUseRuleMessage)
                {
                    RequestChangeUseRuleMessage requestChangeUseRuleMessage = data as RequestChangeUseRuleMessage;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(requestChangeUseRuleMessage, this, ref this.chatMessage);
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
                        // child
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
                case UIData.Property.requestChangeUseRuleMessage:
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
            // RequestChangeUseRuleMessage
            {
                if (wrapProperty.p is RequestChangeUseRuleMessage)
                {
                    switch ((RequestChangeUseRuleMessage.Property)wrapProperty.n)
                    {
                        case RequestChangeUseRuleMessage.Property.userId:
                            dirty = true;
                            break;
                        case RequestChangeUseRuleMessage.Property.action:
                            dirty = true;
                            break;
                        case RequestChangeUseRuleMessage.Property.newUseRule:
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
                        // child
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

}