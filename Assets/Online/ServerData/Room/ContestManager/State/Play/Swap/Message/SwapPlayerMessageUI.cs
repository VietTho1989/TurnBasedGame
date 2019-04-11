using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class SwapPlayerMessageUI : UIBehavior<SwapPlayerMessageUI.UIData>
    {

        #region UIData

        public class UIData : ChatMessageHolder.UIData.Sub
        {

            public VP<ReferenceData<SwapPlayerMessage>> swapPlayerMessage;

            public VP<AccountAvatarUI.UIData> avatar;

            #region Constructor

            public enum Property
            {
                swapPlayerMessage,
                avatar
            }

            public UIData() : base()
            {
                this.swapPlayerMessage = new VP<ReferenceData<SwapPlayerMessage>>(this, (byte)Property.swapPlayerMessage, new ReferenceData<SwapPlayerMessage>(null));
                this.avatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.avatar, new AccountAvatarUI.UIData());
            }

            #endregion

            public override ChatMessage.Content.Type getType()
            {
                return ChatMessage.Content.Type.SwapPlayer;
            }

        }

        #endregion

        #region txt, rect

        static SwapPlayerMessageUI()
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
                    SwapPlayerMessage swapPlayerMessage = this.data.swapPlayerMessage.v.data;
                    if (swapPlayerMessage != null)
                    {
                        ChatMessage chatMessage = swapPlayerMessage.findDataInParent<ChatMessage>();
                        if (chatMessage != null)
                        {
                            // Find human
                            Human oldHuman = null;
                            {
                                // check old
                                if (human != null)
                                {
                                    // isCorrect
                                    bool isCorrect = false;
                                    {
                                        if (human.findDataInParent<ChatRoom>() == swapPlayerMessage.findDataInParent<ChatRoom>())
                                        {
                                            if (human.playerId.v == swapPlayerMessage.userId.v)
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
                                        oldHuman = human;// human.removeCallBack(this);
                                        human = null;
                                    }
                                }
                                // find new
                                if (human == null)
                                {
                                    human = ChatRoom.findHuman(swapPlayerMessage, swapPlayerMessage.userId.v);
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
                            // Find swap human
                            Human oldSwapHuman = null;
                            {
                                if (swapPlayerMessage.type.v == GamePlayer.Inform.Type.Human)
                                {
                                    // check old
                                    if (swapHuman != null)
                                    {
                                        // isCorrect
                                        bool isCorrect = false;
                                        {
                                            if (swapHuman.findDataInParent<ChatRoom>() == swapPlayerMessage.findDataInParent<ChatRoom>())
                                            {
                                                if (swapHuman.playerId.v == swapPlayerMessage.humanId.v)
                                                {
                                                    isCorrect = true;
                                                }
                                            }
                                        }
                                        // process
                                        if (isCorrect)
                                        {
                                            // oldSwapHuman correct
                                        }
                                        else
                                        {
                                            oldSwapHuman = swapHuman;// swapHuman.removeCallBack(this);
                                            swapHuman = null;
                                        }
                                    }
                                    // find new
                                    if (swapHuman == null)
                                    {
                                        swapHuman = ChatRoom.findHuman(swapPlayerMessage, swapPlayerMessage.humanId.v);
                                        if (swapHuman != null)
                                        {
                                            swapHuman.addCallBack(this);
                                        }
                                        else
                                        {
                                            Debug.LogError("don't find swapHuman: " + swapHuman);
                                        }
                                    }
                                }
                                else
                                {
                                    oldSwapHuman = swapHuman;
                                    swapHuman = null;
                                }
                            }
                            // remove old
                            {
                                // oldHuman
                                if (oldHuman != null)
                                {
                                    if(oldHuman!=human && oldHuman != swapHuman)
                                    {
                                        oldHuman.removeCallBack(this);
                                    }
                                }
                                // oldSwapHuman
                                if (oldSwapHuman != null)
                                {
                                    if(oldSwapHuman!=human && oldSwapHuman != swapHuman)
                                    {
                                        oldSwapHuman.removeCallBack(this);
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
                                    // find user name
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
                                    // find swapHumanName
                                    string swapHumanName = "";
                                    {
                                        if (this.swapHuman != null)
                                        {
                                            swapHumanName = this.swapHuman.getPlayerName();
                                        }
                                        else
                                        {
                                            Debug.LogError("swapHuman null");
                                        }
                                    }
                                    // set
                                    tvContent.text = swapPlayerMessage.getMessage(userName, swapHumanName);
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
            // human
            if (this.human != null)
            {
                this.human.removeCallBack(this);
                this.human = null;
            }
            else
            {
                // Debug.LogError ("human null");
            }
            // swapHuman
            if (this.swapHuman != null)
            {
                this.swapHuman.removeCallBack(this);
                this.swapHuman = null;
            }
            else
            {
                Debug.LogError("swap human null");
            }
        }

        #endregion

        #region implement callBacks

        private ChatMessage chatMessage = null;

        public AccountAvatarUI avatarPrefab;
        private static readonly UIRectTransform avatarRect = new UIRectTransform();

        private Human human = null;
        private Human swapHuman = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.swapPlayerMessage.allAddCallBack(this);
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
                // SwapPlayerMessage
                {
                    if (data is SwapPlayerMessage)
                    {
                        SwapPlayerMessage swapPlayerMessage = data as SwapPlayerMessage;
                        // Parent
                        {
                            DataUtils.addParentCallBack(swapPlayerMessage, this, ref this.chatMessage);
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
                    uiData.swapPlayerMessage.allRemoveCallBack(this);
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
                // SwapPlayerMessage
                {
                    if (data is SwapPlayerMessage)
                    {
                        SwapPlayerMessage swapPlayerMessage = data as SwapPlayerMessage;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(swapPlayerMessage, this, ref this.chatMessage);
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
                    case UIData.Property.swapPlayerMessage:
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
                // SwapPlayerMessage
                {
                    if (wrapProperty.p is SwapPlayerMessage)
                    {
                        switch ((SwapPlayerMessage.Property)wrapProperty.n)
                        {
                            case SwapPlayerMessage.Property.userId:
                                dirty = true;
                                break;
                            case SwapPlayerMessage.Property.action:
                                dirty = true;
                                break;
                            case SwapPlayerMessage.Property.teamIndex:
                                dirty = true;
                                break;
                            case SwapPlayerMessage.Property.playerIndex:
                                dirty = true;
                                break;
                            case SwapPlayerMessage.Property.type:
                                dirty = true;
                                break;
                            case SwapPlayerMessage.Property.humanId:
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
}