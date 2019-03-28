using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

public class ChatRoomAdapter : SRIA<ChatRoomAdapter.UIData, ChatMessageHolder.UIData>
{

    #region UIData

    [Serializable]
    public class UIData : BaseParams
    {

        public VP<ReferenceData<ChatRoom>> chatRoom;

        public LP<ChatMessageHolder.UIData> holders;

        #region Constructor

        public enum Property
        {
            chatRoom,
            holders
        }

        public UIData() : base()
        {
            this.chatRoom = new VP<ReferenceData<ChatRoom>>(this, (byte)Property.chatRoom, new ReferenceData<ChatRoom>(null));
            this.holders = new LP<ChatMessageHolder.UIData>(this, (byte)Property.holders);
        }

        #endregion

        [NonSerialized]
        public List<ChatMessage> chatMessages = new List<ChatMessage>();

        public void reset()
        {
            this.chatMessages.Clear();
        }

    }

    #endregion

    #region Adapter

    public ChatMessageHolder holderPrefab;

    protected override ChatMessageHolder.UIData CreateViewsHolder(int itemIndex)
    {
        ChatMessageHolder.UIData uiData = new ChatMessageHolder.UIData();
        {
            // add
            {
                uiData.uid = this.data.holders.makeId();
                this.data.holders.add(uiData);
            }
            // MakeUI
            if (holderPrefab != null)
            {
                uiData.Init(holderPrefab.gameObject, itemIndex);
            }
            else
            {
                Debug.LogError("holderPrefab null: " + this);
            }
        }
        return uiData;
    }

    protected override void UpdateViewsHolder(ChatMessageHolder.UIData newOrRecycled)
    {
        newOrRecycled.updateView(_Params);
    }

    #endregion

    #region txt

    public Text tvNoMessages;
    public static readonly TxtLanguage txtNoMessages = new TxtLanguage();

    static ChatRoomAdapter()
    {
        txtNoMessages.add(Language.Type.vi, "Không có thông điệp nào cả");
    }

    #endregion

    #region Refresh

    public GameObject noMessages;

    public override void refresh()
    {
        if (dirty)
        {
            if (this.Initialized)
            {
                dirty = false;
                if (this.data != null)
                {
                    ChatRoom chatRoom = this.data.chatRoom.v.data;
                    if (chatRoom != null)
                    {
                        List<ChatMessage> chatMessages = new List<ChatMessage>();
                        // Add
                        {
                            chatMessages.AddRange(chatRoom.messages.vs);
                        }
                        // Make list
                        {
                            int min = Mathf.Min(chatMessages.Count, _Params.chatMessages.Count);
                            // Update
                            {
                                for (int i = 0; i < min; i++)
                                {
                                    if (chatMessages[i] != _Params.chatMessages[i])
                                    {
                                        // change param
                                        _Params.chatMessages[i] = chatMessages[i];
                                        // Update holder
                                        {
                                            foreach (ChatMessageHolder.UIData holder in this.data.holders.vs)
                                            {
                                                if (holder.ItemIndex == i)
                                                {
                                                    holder.chatMessage.v = new ReferenceData<ChatMessage>(chatMessages[i]);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            // Add or Remove
                            {
                                if (chatMessages.Count > min)
                                {
                                    // Add
                                    int insertCount = chatMessages.Count - min;
                                    List<ChatMessage> addItems = chatMessages.GetRange(min, insertCount);
                                    _Params.chatMessages.AddRange(addItems);
                                    InsertItems(min, insertCount, false, false);
                                }
                                else
                                {
                                    // Remove
                                    int deleteCount = _Params.chatMessages.Count - min;
                                    if (deleteCount > 0)
                                    {
                                        RemoveItems(min, deleteCount, false, false);
                                        _Params.chatMessages.RemoveRange(min, deleteCount);
                                    }
                                }
                            }
                        }
                        // NoMessages
                        {
                            if (noMessages != null)
                            {
                                bool haveAny = false;
                                {
                                    foreach (ChatMessageHolder.UIData holder in this.data.holders.vs)
                                    {
                                        if (holder.chatMessage.v.data != null)
                                        {
                                            ChatMessageHolder holderUI = holder.findCallBack<ChatMessageHolder>();
                                            if (holderUI != null)
                                            {
                                                if (holderUI.gameObject.activeSelf)
                                                {
                                                    haveAny = true;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("holderUI null: " + this);
                                            }
                                        }
                                    }
                                }
                                noMessages.SetActive(!haveAny);
                            }
                            else
                            {
                                Debug.LogError("noMessages null: " + this);
                            }
                        }
                    }
                    else
                    {
                        // Debug.Log ("chatRoom null: " + this);
                    }
                    // txt
                    {
                        if (tvNoMessages != null)
                        {
                            tvNoMessages.text = txtNoMessages.get("Don't have any messages");
                        }
                        else
                        {
                            Debug.LogError("tvNoMessages null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
            else
            {
                // Debug.LogError ("not initalized: " + this);
            }
        }
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.chatRoom.allAddCallBack(this);
            }
            // ScrollToBottom
            {
                ChatRoomAdapterAutoSscrollToBottom scrollToBottom = this.GetComponent<ChatRoomAdapterAutoSscrollToBottom>();
                if (scrollToBottom != null)
                {
                    scrollToBottom.setData(uiData);
                }
                else
                {
                    Debug.LogError("scrollToBottom null");
                }
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
        if (data is ChatRoom)
        {
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
            dirty = true;
            return;
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
                uiData.chatRoom.allRemoveCallBack(this);
            }
            // ScrollToBottom
            {
                ChatRoomAdapterAutoSscrollToBottom scrollToBottom = this.GetComponent<ChatRoomAdapterAutoSscrollToBottom>();
                if (scrollToBottom != null)
                {
                    if (scrollToBottom.data == uiData)
                    {
                        scrollToBottom.setData(null);
                    }
                    else
                    {
                        Debug.LogError("why different");
                    }
                }
                else
                {
                    Debug.LogError("scrollToBottom null");
                }
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
        if (data is ChatRoom)
        {
            return;
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
                case UIData.Property.holders:
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
        if (wrapProperty.p is ChatRoom)
        {
            switch ((ChatRoom.Property)wrapProperty.n)
            {
                case ChatRoom.Property.players:
                    break;
                case ChatRoom.Property.messages:
                    dirty = true;
                    break;
                case ChatRoom.Property.typing:
                    break;
                case ChatRoom.Property.isEnable:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + data + "; " + this);
    }

    #endregion

}