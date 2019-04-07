using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChatMessageMenuUI : UIBehavior<ChatMessageMenuUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<ChatMessage>> chatMessage;

        public VP<ChatMessageDeleteUI.UIData> btnDelete;

        public VP<ChatMessageEditUI.UIData> edit;

        public VP<ChatMessageViewHistoryUI.UIData> viewHistory;

        #region Constructor

        public enum Property
        {
            chatMessage,
            btnDelete,
            edit,
            viewHistory
        }

        public UIData() : base()
        {
            this.chatMessage = new VP<ReferenceData<ChatMessage>>(this, (byte)Property.chatMessage, new ReferenceData<ChatMessage>(null));
            this.btnDelete = new VP<ChatMessageDeleteUI.UIData>(this, (byte)Property.btnDelete, new ChatMessageDeleteUI.UIData());
            this.edit = new VP<ChatMessageEditUI.UIData>(this, (byte)Property.edit, null);
            this.viewHistory = new VP<ChatMessageViewHistoryUI.UIData>(this, (byte)Property.viewHistory, null);
        }

        #endregion

        public void reset()
        {
            this.edit.v = null;
        }

        public bool processEvent(Event e)
        {
            Debug.LogError("processEvent: " + e + "; " + this);
            bool isProcess = false;
            {
                // edit
                if (!isProcess)
                {
                    ChatMessageEditUI.UIData edit = this.edit.v;
                    if (edit != null)
                    {
                        isProcess = edit.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("edit null: " + this);
                    }
                }
                // viewHistory
                if (!isProcess)
                {
                    ChatMessageViewHistoryUI.UIData viewHistory = this.viewHistory.v;
                    if (viewHistory != null)
                    {
                        isProcess = viewHistory.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("viewHistory null");
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        ChatMessageMenuUI chatMessageMenuUI = this.findCallBack<ChatMessageMenuUI>();
                        if (chatMessageMenuUI != null)
                        {
                            chatMessageMenuUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("chatMessageMenuUI null: " + this);
                        }
                        isProcess = true;
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Chat Message Menu");

    public Button btnEdit;
    public Text tvEdit;
    private static readonly TxtLanguage txtEdit = new TxtLanguage("Edit");

    public Button btnCopyToClipboard;
    public Text tvCopyToClipboard;
    private static readonly TxtLanguage txtCopyToClipboard = new TxtLanguage("Copy To Clipboard");

    public Button btnViewHistory;
    public Text tvViewHistory;
    private static readonly TxtLanguage txtViewHistory = new TxtLanguage("View History");

    static ChatMessageMenuUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Menu Thông Điệp");
            txtEdit.add(Language.Type.vi, "Chỉnh Sửa");
            txtCopyToClipboard.add(Language.Type.vi, "Chép Vào Clipboard");
            txtViewHistory.add(Language.Type.vi, "Xem Lịch Sử");
        }
        // rect
        {
            // btnDeleteRect
            {
                // anchoredPosition: (0.0, -40.0); anchorMin: (0.5, 1.0); anchorMax: (0.5, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (-80.0, -70.0); offsetMax: (80.0, -40.0); sizeDelta: (160.0, 30.0);
                btnDeleteRect.anchoredPosition = new Vector3(0.0f, -40.0f, 0.0f);
                btnDeleteRect.anchorMin = new Vector2(0.5f, 1.0f);
                btnDeleteRect.anchorMax = new Vector2(0.5f, 1.0f);
                btnDeleteRect.pivot = new Vector2(0.5f, 1.0f);
                btnDeleteRect.offsetMin = new Vector2(-80.0f, -70.0f);
                btnDeleteRect.offsetMax = new Vector2(80.0f, -40.0f);
                btnDeleteRect.sizeDelta = new Vector2(160.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    public RectTransform contentContainer;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                ChatMessage chatMessage = this.data.chatMessage.v.data;
                if (chatMessage != null)
                {
                    // isYourMessage
                    bool isYourMessage = false;
                    bool isHaveHistory = false;
                    {
                        // find isYourMessage
                        {
                            ChatMessage.Content content = chatMessage.content.v;
                            if (content != null)
                            {
                                switch (content.getType())
                                {
                                    case ChatMessage.Content.Type.Normal:
                                        {
                                            ChatNormalContent chatNormalContent = content as ChatNormalContent;
                                            if (chatNormalContent.isMine())
                                            {
                                                isYourMessage = true;
                                                isHaveHistory = (chatNormalContent.edits.vs.Count > 0) && (chatMessage.state.v == ChatMessage.State.Normal);
                                            }
                                        }
                                        break;
                                    case ChatMessage.Content.Type.UserAction:
                                        break;
                                    case ChatMessage.Content.Type.RoomUserState:
                                        break;
                                    case ChatMessage.Content.Type.FriendStateChange:
                                        break;
                                    case ChatMessage.Content.Type.GameMove:
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + content.getType() + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("content null: " + this);
                            }
                        }
                        // process
                        if (isYourMessage)
                        {
                            // btnDelete
                            {
                                ChatMessageDeleteUI.UIData btnDelete = this.data.btnDelete.v;
                                if (btnDelete != null)
                                {
                                    btnDelete.chatMessage.v = new ReferenceData<ChatMessage>(chatMessage);
                                }
                                else
                                {
                                    Debug.LogError("btnDelete null: " + this);
                                }
                            }
                        }
                    }
                    // btn
                    {
                        // btnEdit
                        if (btnEdit != null)
                        {
                            btnEdit.gameObject.SetActive(isYourMessage);
                        }
                        else
                        {
                            Debug.LogError("btnEdit null");
                        }
                        // btnViewHistory
                        if (btnViewHistory != null)
                        {
                            btnViewHistory.gameObject.SetActive(isHaveHistory);
                        }
                        else
                        {
                            Debug.LogError("btnViewHistory null");
                        }
                    }
                    // edit
                    {
                        ChatMessageEditUI.UIData edit = this.data.edit.v;
                        if (edit != null)
                        {
                            edit.chatMessage.v = new ReferenceData<ChatMessage>(chatMessage);
                        }
                        else
                        {
                            // Debug.LogError("edit null: " + this);
                        }
                    }
                    // viewHistory
                    {
                        ChatMessageViewHistoryUI.UIData viewHistory = this.data.viewHistory.v;
                        if (viewHistory != null)
                        {
                            // find
                            ChatNormalContent chatNormalContent = null;
                            {
                                if(chatMessage.content.v is ChatNormalContent)
                                {
                                    chatNormalContent = chatMessage.content.v as ChatNormalContent;
                                }
                                else
                                {
                                    Debug.LogError("why not chatNormalContent: " + chatMessage.content.v);
                                }
                            }
                            // set
                            viewHistory.chatNormalContent.v = new ReferenceData<ChatNormalContent>(chatNormalContent);
                        }
                        else
                        {
                            Debug.LogError("viewHistory null");
                        }
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        deltaY += 30 + 10;
                        // btnDelete
                        {
                            if (this.data.btnDelete.v != null)
                            {
                                UIRectTransform.SetPosY(this.data.btnDelete.v, deltaY);
                                deltaY += 40;
                            }
                            else
                            {
                                // Debug.LogError("btnDelete null");
                            }
                        }
                        // btnEdit
                        {
                            if (btnEdit != null && btnEdit.gameObject.activeSelf)
                            {
                                UIRectTransform.SetPosY((RectTransform)btnEdit.transform, deltaY);
                                deltaY += 40;
                            }
                            else
                            {
                                Debug.LogError("btnEdit null");
                            }
                        }
                        // btnCopyToClipboard
                        {
                            if (btnCopyToClipboard != null && btnCopyToClipboard.gameObject.activeSelf)
                            {
                                UIRectTransform.SetPosY((RectTransform)btnCopyToClipboard.transform, deltaY);
                                deltaY += 40;
                            }
                            else
                            {
                                Debug.LogError("btnCopyToClipboard null");
                            }
                        }
                        // btnViewHistory
                        {
                            if (btnViewHistory != null && btnViewHistory.gameObject.activeSelf)
                            {
                                UIRectTransform.SetPosY((RectTransform)btnViewHistory.transform, deltaY);
                                deltaY += 40;
                            }
                            else
                            {
                                Debug.LogError("btnViewHistory null");
                            }
                        }
                        // set
                        if (contentContainer != null)
                        {
                            UIRectTransform.SetHeight(contentContainer, deltaY);
                        }
                        else
                        {
                            Debug.LogError("contentContainer null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("chatMessage null: " + this);
                    this.onClickBtnBack();
                }
                // contentContainer
                {
                    if (contentContainer != null)
                    {
                        // find
                        bool isShow = true;
                        {
                            // edit
                            if (isShow)
                            {
                                if (this.data.edit.v != null)
                                {
                                    isShow = false;
                                }
                            }
                            // history
                            if (isShow)
                            {
                                if (this.data.viewHistory.v != null)
                                {
                                    isShow = false;
                                }
                            }
                        }
                        contentContainer.gameObject.SetActive(isShow);
                    }
                    else
                    {
                        Debug.LogError("contentContainer null");
                    }
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get();
                    }
                    else
                    {
                        Debug.LogError("lbTitle null");
                    }
                    if (tvEdit != null)
                    {
                        tvEdit.text = txtEdit.get();
                    }
                    else
                    {
                        Debug.LogError("tvEdit null: " + this);
                    }
                    if (tvCopyToClipboard != null)
                    {
                        tvCopyToClipboard.text = txtCopyToClipboard.get();
                    }
                    else
                    {
                        Debug.LogError("tvCopyToClipboard null");
                    }
                    if (tvViewHistory != null)
                    {
                        tvViewHistory.text = txtViewHistory.get();
                    }
                    else
                    {
                        Debug.LogError("tvViewHistory null");
                    }
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

    public ChatMessageDeleteUI btnDeletePrefab;
    private static readonly UIRectTransform btnDeleteRect = new UIRectTransform();

    public ChatMessageEditUI editPrefab;
    private static readonly UIRectTransform editRect = UIRectTransform.CreateCenterRect(300, 120);

    public ChatMessageViewHistoryUI viewHistoryPrefab;
    private static readonly UIRectTransform viewHistoryRect = UIRectTransform.CreateCenterRect(300, 300);

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.chatMessage.allAddCallBack(this);
                uiData.btnDelete.allAddCallBack(this);
                uiData.edit.allAddCallBack(this);
                uiData.viewHistory.allAddCallBack(this);
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
            // chatMessage
            {
                if (data is ChatMessage)
                {
                    ChatMessage chatMessage = data as ChatMessage;
                    // reset
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
                        chatMessage.content.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is ChatMessage.Content)
                {
                    dirty = true;
                    return;
                }
            }
            if (data is ChatMessageDeleteUI.UIData)
            {
                ChatMessageDeleteUI.UIData btnDelete = data as ChatMessageDeleteUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnDelete, btnDeletePrefab, contentContainer, btnDeleteRect);
                }
                dirty = true;
                return;
            }
            if (data is ChatMessageEditUI.UIData)
            {
                ChatMessageEditUI.UIData edit = data as ChatMessageEditUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(edit, editPrefab, this.transform, editRect);
                }
                dirty = true;
                return;
            }
            if(data is ChatMessageViewHistoryUI.UIData)
            {
                ChatMessageViewHistoryUI.UIData viewHistory = data as ChatMessageViewHistoryUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(viewHistory, viewHistoryPrefab, this.transform, viewHistoryRect);
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
                uiData.chatMessage.allRemoveCallBack(this);
                uiData.btnDelete.allRemoveCallBack(this);
                uiData.edit.allRemoveCallBack(this);
                uiData.viewHistory.allRemoveCallBack(this);
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
            // chatMessage
            {
                if (data is ChatMessage)
                {
                    ChatMessage chatMessage = data as ChatMessage;
                    // Child
                    {
                        chatMessage.content.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is ChatMessage.Content)
                {
                    return;
                }
            }
            if (data is ChatMessageDeleteUI.UIData)
            {
                ChatMessageDeleteUI.UIData btnDelete = data as ChatMessageDeleteUI.UIData;
                // UI
                {
                    btnDelete.removeCallBackAndDestroy(typeof(ChatMessageDeleteUI));
                }
                return;
            }
            if (data is ChatMessageEditUI.UIData)
            {
                ChatMessageEditUI.UIData edit = data as ChatMessageEditUI.UIData;
                // UI
                {
                    edit.removeCallBackAndDestroy(typeof(ChatMessageEditUI));
                }
                return;
            }
            if (data is ChatMessageViewHistoryUI.UIData)
            {
                ChatMessageViewHistoryUI.UIData viewHistory = data as ChatMessageViewHistoryUI.UIData;
                // UI
                {
                    viewHistory.removeCallBackAndDestroy(typeof(ChatMessageViewHistoryUI));
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
                case UIData.Property.chatMessage:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnDelete:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.edit:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.viewHistory:
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
            // chatMessage
            {
                if (wrapProperty.p is ChatMessage)
                {
                    switch ((ChatMessage.Property)wrapProperty.n)
                    {
                        case ChatMessage.Property.state:
                            break;
                        case ChatMessage.Property.time:
                            break;
                        case ChatMessage.Property.content:
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
                if (wrapProperty.p is ChatMessage.Content)
                {
                    ChatMessage.Content content = wrapProperty.p as ChatMessage.Content;
                    switch (content.getType())
                    {
                        case ChatMessage.Content.Type.Normal:
                            {
                                switch ((ChatNormalContent.Property)wrapProperty.n)
                                {
                                    case ChatNormalContent.Property.owner:
                                        dirty = true;
                                        break;
                                    case ChatNormalContent.Property.message:
                                        dirty = true;
                                        break;
                                    case ChatNormalContent.Property.edits:
                                        dirty = true;
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                            }
                            break;
                        case ChatMessage.Content.Type.UserAction:
                            break;
                        case ChatMessage.Content.Type.RoomUserState:
                            break;
                        case ChatMessage.Content.Type.FriendStateChange:
                            break;
                        case ChatMessage.Content.Type.GameMove:
                            break;
                        default:
                            Debug.LogError("unknown type: " + content.getType() + "; " + this);
                            break;
                    }
                    return;
                }
            }
            if (wrapProperty.p is ChatMessageDeleteUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is ChatMessageEditUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is ChatMessageViewHistoryUI.UIData)
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
            ChatRoomUI.UIData chatRoomUIData = this.data.findDataInParent<ChatRoomUI.UIData>();
            if (chatRoomUIData != null)
            {
                chatRoomUIData.chatMessageMenu.v = null;
            }
            else
            {
                Debug.LogError("chatRoomUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public void onClickBtnEdit()
    {
        if (this.data != null)
        {
            ChatMessage chatMessage = this.data.chatMessage.v.data;
            if (chatMessage != null)
            {
                ChatMessageEditUI.UIData edit = this.data.edit.newOrOld<ChatMessageEditUI.UIData>();
                {
                    edit.chatMessage.v = new ReferenceData<ChatMessage>(chatMessage);
                }
                this.data.edit.v = edit;
            }
            else
            {
                Debug.LogError("chatMessage null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public void onClickCopyToClipboard()
    {
        if (this.data != null)
        {
            ChatMessage chatMessage = this.data.chatMessage.v.data;
            if (chatMessage != null)
            {
                // find message
                string message = "";
                {
                    ChatMessage.Content content = chatMessage.content.v;
                    if (content != null)
                    {
                        message = content.getMessage();
                    }
                    else
                    {
                        Debug.LogError("content null: " + this);
                    }
                }
                // process
                if (!string.IsNullOrEmpty(message))
                {
                    UniClipboard.SetText(message);
                    Toast.showMessage("Copy message to clipboard: " + message);
                }
                else
                {
                    Debug.LogError("message null");
                }
            }
            else
            {
                Debug.LogError("chatMessage null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    public void onClickBtnViewHistory()
    {
        if (this.data != null)
        {
            // find chatNormalContent
            ChatNormalContent chatNormalContent = null;
            {
                ChatMessage chatMessage = this.data.chatMessage.v.data;
                if (chatMessage != null)
                {
                    if(chatMessage.content.v is ChatNormalContent)
                    {
                        chatNormalContent = chatMessage.content.v as ChatNormalContent;
                    }
                }
                else
                {
                    Debug.LogError("chatMessage null");
                }
            }
            // process
            if (chatNormalContent != null)
            {
                ChatMessageViewHistoryUI.UIData chatMessageViewHistoryUIData = this.data.viewHistory.newOrOld<ChatMessageViewHistoryUI.UIData>();
                {
                    chatMessageViewHistoryUIData.chatNormalContent.v = new ReferenceData<ChatNormalContent>(chatNormalContent);
                }
                this.data.viewHistory.v = chatMessageViewHistoryUIData;
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