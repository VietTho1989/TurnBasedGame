using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BtnChooseChatUI : UIBehavior<BtnChooseChatUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<ChatRoom>> chatRoom;

        #region Constructor

        public enum Property
        {
            chatRoom
        }

        public UIData() : base()
        {
            this.chatRoom = new VP<ReferenceData<ChatRoom>>(this, (byte)Property.chatRoom, new ReferenceData<ChatRoom>(null));
        }

        #endregion

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtGeneral = new TxtLanguage("General");
    private static readonly TxtLanguage txtShortQuestion = new TxtLanguage("Short Question");
    private static readonly TxtLanguage txtBug = new TxtLanguage("Bug");
    private static readonly TxtLanguage txtSuggestion = new TxtLanguage("Suggestion");
    private static readonly TxtLanguage txtOff = new TxtLanguage("Off");
    private static readonly TxtLanguage txtFriend = new TxtLanguage("Friend");
    private static readonly TxtLanguage txtGuild = new TxtLanguage("Guild");
    private static readonly TxtLanguage txtRoom = new TxtLanguage("Room");

    static BtnChooseChatUI()
    {
        txtGeneral.add(Language.Type.vi, "Chung");
        txtShortQuestion.add(Language.Type.vi, "Câu hỏi ngắn");
        txtBug.add(Language.Type.vi, "Báo Lỗi");
        txtSuggestion.add(Language.Type.vi, "Yêu cầu");
        txtOff.add(Language.Type.vi, "Ngoại truyện");
        txtFriend.add(Language.Type.vi, "Bạn bè");
        txtGuild.add(Language.Type.vi, "Bang hội");
        txtRoom.add(Language.Type.vi, "Phòng");
    }

    #endregion

    #region Refresh

    public Button btnTopic;
    public Text txtTopic;

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
                    // btnTopic
                    if (btnTopic != null)
                    {
                        bool isAlreadyShow = false;
                        {
                            GlobalChatUI.UIData globalChatUIData = this.data.findDataInParent<GlobalChatUI.UIData>();
                            if (globalChatUIData != null)
                            {
                                ChatRoomUI.UIData chatRoomUIData = globalChatUIData.chatRoomUIData.v;
                                if (chatRoomUIData != null)
                                {
                                    if (chatRoom == chatRoomUIData.chatRoom.v.data)
                                    {
                                        isAlreadyShow = true;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("chatRoomUIData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("globalChatUIData null: " + this);
                            }
                        }
                        btnTopic.interactable = !isAlreadyShow;
                    }
                    else
                    {
                        Debug.LogError("btnTopic null: " + this);
                    }
                    // txtTopic
                    if (txtTopic != null)
                    {
                        Topic topic = chatRoom.topic.v;
                        if (topic != null)
                        {
                            switch (topic.getType())
                            {
                                case Topic.Type.General:
                                    txtTopic.text = txtGeneral.get();
                                    break;
                                case Topic.Type.ShortQuestion:
                                    txtTopic.text = txtShortQuestion.get();
                                    break;
                                case Topic.Type.Bug:
                                    txtTopic.text = txtBug.get();
                                    break;
                                case Topic.Type.Suggestion:
                                    txtTopic.text = txtSuggestion.get();
                                    break;
                                case Topic.Type.Off:
                                    txtTopic.text = txtOff.get();
                                    break;
                                case Topic.Type.Friend:
                                    txtTopic.text = txtFriend.get();
                                    break;
                                case Topic.Type.Guild:
                                    txtTopic.text = txtGuild.get();
                                    break;
                                case Topic.Type.Room:
                                    txtTopic.text = txtRoom.get();
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + topic.getType() + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("topic null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("txtTopic null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("chatRoom null: " + this);
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

    private GlobalChatUI.UIData globalChatUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Parent
            {
                DataUtils.addParentCallBack(uiData, this, ref this.globalChatUIData);
            }
            // Child
            {
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
        // Parent
        {
            if (data is GlobalChatUI.UIData)
            {
                GlobalChatUI.UIData globalChatUIData = data as GlobalChatUI.UIData;
                // Child
                {
                    globalChatUIData.chatRoomUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is ChatRoomUI.UIData)
            {
                dirty = true;
                return;
            }
        }
        // Child
        {
            if (data is ChatRoom)
            {
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
            // Parent
            {
                DataUtils.removeParentCallBack(uiData, this, ref this.globalChatUIData);
            }
            // Child
            {
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
        // Parent
        {
            if (data is GlobalChatUI.UIData)
            {
                GlobalChatUI.UIData globalChatUIData = data as GlobalChatUI.UIData;
                // Child
                {
                    globalChatUIData.chatRoomUIData.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            if (data is ChatRoomUI.UIData)
            {
                return;
            }
        }
        // Child
        {
            if (data is ChatRoom)
            {
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
        // Parent
        {
            if (wrapProperty.p is GlobalChatUI.UIData)
            {
                switch ((GlobalChatUI.UIData.Property)wrapProperty.n)
                {
                    case GlobalChatUI.UIData.Property.server:
                        break;
                    case GlobalChatUI.UIData.Property.chatRoomUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case GlobalChatUI.UIData.Property.btnChooseChatUIDatas:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            if (wrapProperty.p is ChatRoomUI.UIData)
            {
                switch ((ChatRoomUI.UIData.Property)wrapProperty.n)
                {
                    case ChatRoomUI.UIData.Property.chatRoom:
                        dirty = true;
                        break;
                    case ChatRoomUI.UIData.Property.topicUI:
                        break;
                    case ChatRoomUI.UIData.Property.chatRoomAdapter:
                        break;
                    case ChatRoomUI.UIData.Property.typingUI:
                        break;
                    case ChatRoomUI.UIData.Property.chatMessageMenu:
                        break;
                    case ChatRoomUI.UIData.Property.canSendMessage:
                        break;
                    case ChatRoomUI.UIData.Property.btnLoadMore:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        // Child
        {
            if (wrapProperty.p is ChatRoom)
            {
                switch ((ChatRoom.Property)wrapProperty.n)
                {
                    case ChatRoom.Property.topic:
                        dirty = true;
                        break;
                    case ChatRoom.Property.isEnable:
                        break;
                    case ChatRoom.Property.players:
                        break;
                    case ChatRoom.Property.messages:
                        break;
                    case ChatRoom.Property.editMax:
                        break;
                    case ChatRoom.Property.maxId:
                        break;
                    case ChatRoom.Property.chatViewers:
                        break;
                    case ChatRoom.Property.typing:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnTopic()
    {
        if (this.data != null)
        {
            ChatRoom chatRoom = this.data.chatRoom.v.data;
            if (chatRoom != null)
            {
                GlobalChatUI.UIData globalChatUIData = this.data.findDataInParent<GlobalChatUI.UIData>();
                if (globalChatUIData != null)
                {
                    ChatRoomUI.UIData chatRoomUIData = globalChatUIData.chatRoomUIData.newOrOld<ChatRoomUI.UIData>();
                    {
                        chatRoomUIData.chatRoom.v = new ReferenceData<ChatRoom>(chatRoom);
                    }
                    globalChatUIData.chatRoomUIData.v = chatRoomUIData;
                }
                else
                {
                    Debug.LogError("globalChatUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("chatRoom null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}