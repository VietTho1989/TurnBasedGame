using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

public class ChatMessageHistoryAdapter : SRIA<ChatMessageHistoryAdapter.UIData, ChatMessageHistoryHolder.UIData>
{

    #region UIData

    [Serializable]
    public class UIData : BaseParams
    {

        public VP<ReferenceData<ChatNormalContent>> chatNormalContent;

        public LP<ChatMessageHistoryHolder.UIData> holders;

        #region Constructor

        public enum Property
        {
            chatNormalContent,
            holders
        }

        public UIData() : base()
        {
            this.chatNormalContent = new VP<ReferenceData<ChatNormalContent>>(this, (byte)Property.chatNormalContent, new ReferenceData<ChatNormalContent>(null));
            this.holders = new LP<ChatMessageHistoryHolder.UIData>(this, (byte)Property.holders);
        }

        #endregion

        [NonSerialized]
        public List<ChatNormalContentEdit> edits = new List<ChatNormalContentEdit>();

        public void reset()
        {
            this.edits.Clear();
        }

    }

    #endregion

    #region Adapter

    public ChatMessageHistoryHolder holderPrefab;

    protected override ChatMessageHistoryHolder.UIData CreateViewsHolder(int itemIndex)
    {
        ChatMessageHistoryHolder.UIData uiData = new ChatMessageHistoryHolder.UIData();
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

    protected override void UpdateViewsHolder(ChatMessageHistoryHolder.UIData newOrRecycled)
    {
        newOrRecycled.updateView(_Params);
    }

    #endregion

    #region txt

    public Text tvNoEdits;
    public static readonly TxtLanguage txtNoEdits = new TxtLanguage();

    static ChatMessageHistoryAdapter()
    {
        txtNoEdits.add(Language.Type.vi, "Không có chỉnh sửa nào cả");
    }

    #endregion

    #region Refresh

    public GameObject noEdits;

    public ChatNormalContentEdit firstEdit = new ChatNormalContentEdit();

    public override void refresh()
    {
        if (dirty)
        {
            if (this.Initialized)
            {
                dirty = false;
                if (this.data != null)
                {
                    ChatNormalContent chatNormalContent = this.data.chatNormalContent.v.data;
                    if (chatNormalContent != null)
                    {
                        List<ChatNormalContentEdit> edits = new List<ChatNormalContentEdit>();
                        // Add
                        {
                            // first
                            {
                                // content
                                {
                                    firstEdit.message.v = chatNormalContent.message.v;
                                    // time
                                    {
                                        ChatMessage chatMessage = chatNormalContent.findDataInParent<ChatMessage>();
                                        if (chatMessage != null)
                                        {
                                            firstEdit.time.v = chatMessage.time.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("chatMessage null");
                                        }
                                    }
                                }
                                edits.Add(firstEdit);
                            }
                            // add other
                            edits.AddRange(chatNormalContent.edits.vs);
                        }
                        // Make list
                        {
                            int min = Mathf.Min(edits.Count, _Params.edits.Count);
                            // Update
                            {
                                for (int i = 0; i < min; i++)
                                {
                                    if (edits[i] != _Params.edits[i])
                                    {
                                        // change param
                                        _Params.edits[i] = edits[i];
                                        // Update holder
                                        {
                                            foreach (ChatMessageHistoryHolder.UIData holder in this.data.holders.vs)
                                            {
                                                if (holder.ItemIndex == i)
                                                {
                                                    holder.chatNormalContentEdit.v = new ReferenceData<ChatNormalContentEdit>(edits[i]);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            // Add or Remove
                            {
                                if (edits.Count > min)
                                {
                                    // Add
                                    int insertCount = edits.Count - min;
                                    List<ChatNormalContentEdit> addItems = edits.GetRange(min, insertCount);
                                    _Params.edits.AddRange(addItems);
                                    InsertItems(min, insertCount, false, false);
                                }
                                else
                                {
                                    // Remove
                                    int deleteCount = _Params.edits.Count - min;
                                    if (deleteCount > 0)
                                    {
                                        RemoveItems(min, deleteCount, false, false);
                                        _Params.edits.RemoveRange(min, deleteCount);
                                    }
                                }
                            }
                        }
                        // NoEdits
                        {
                            if (noEdits != null)
                            {
                                bool haveAny = false;
                                {
                                    foreach (ChatMessageHistoryHolder.UIData holder in this.data.holders.vs)
                                    {
                                        if (holder.chatNormalContentEdit.v.data != null)
                                        {
                                            ChatMessageHistoryHolder holderUI = holder.findCallBack<ChatMessageHistoryHolder>();
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
                                noEdits.SetActive(!haveAny);
                            }
                            else
                            {
                                Debug.LogError("noEdits null: " + this);
                            }
                        }
                    }
                    else
                    {
                        // Debug.Log ("chatNormalContent null: " + this);
                    }
                    // txt
                    {
                        if (tvNoEdits != null)
                        {
                            tvNoEdits.text = txtNoEdits.get("Don't have any edits");
                        }
                        else
                        {
                            Debug.LogError("tvNoEdits null: " + this);
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

    private ChatMessage chatMessage = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.chatNormalContent.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if(data is ChatNormalContent)
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
            if(data is ChatMessage)
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
            // Child
            {
                uiData.chatNormalContent.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
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
            if (data is ChatMessage)
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
                case UIData.Property.chatNormalContent:
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
        // Child
        {
            if (wrapProperty.p is ChatNormalContent)
            {
                switch ((ChatNormalContent.Property)wrapProperty.n)
                {
                    case ChatNormalContent.Property.owner:
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
                return;
            }
            // Parent
            if (wrapProperty.p is ChatMessage)
            {
                switch ((ChatMessage.Property)wrapProperty.n)
                {
                    case ChatMessage.Property.state:
                        break;
                    case ChatMessage.Property.time:
                        dirty = true;
                        break;
                    case ChatMessage.Property.content:
                        break;
                    default:
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}