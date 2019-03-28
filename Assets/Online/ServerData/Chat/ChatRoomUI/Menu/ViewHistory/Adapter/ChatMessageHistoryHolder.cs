using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

public class ChatMessageHistoryHolder : SriaHolderBehavior<ChatMessageHistoryHolder.UIData>
{

    #region UIData

    public class UIData : BaseItemViewsHolder
    {

        public VP<ReferenceData<ChatNormalContentEdit>> chatNormalContentEdit;

        #region Constructor

        public enum Property
        {
            chatNormalContentEdit
        }

        public UIData() : base()
        {
            this.chatNormalContentEdit = new VP<ReferenceData<ChatNormalContentEdit>>(this, (byte)Property.chatNormalContentEdit, new ReferenceData<ChatNormalContentEdit>(null));
        }

        #endregion

        public void updateView(ChatMessageHistoryAdapter.UIData myParams)
        {
            // Find
            ChatNormalContentEdit chatNormalContentEdit = null;
            {
                if (ItemIndex >= 0 && ItemIndex < myParams.edits.Count)
                {
                    chatNormalContentEdit = myParams.edits[ItemIndex];
                }
                else
                {
                    Debug.LogError("ItemIdex error: " + ItemIndex + "; " + myParams.edits.Count + "; " + this);
                }
            }
            // Update
            this.chatNormalContentEdit.v = new ReferenceData<ChatNormalContentEdit>(chatNormalContentEdit);
        }
    }

    #endregion

    #region Refresh

    public Text tvMessage;
    public Text tvTime;

    public override void refresh()
    {
        base.refresh();
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                ChatNormalContentEdit chatNormalContentEdit = this.data.chatNormalContentEdit.v.data;
                if (chatNormalContentEdit != null)
                {
                    // message
                    if (tvMessage != null)
                    {
                        tvMessage.text = chatNormalContentEdit.message.v;
                    }
                    else
                    {
                        Debug.LogError("tvMessage null");
                    }
                    // time
                    if (tvTime != null)
                    {
                        tvTime.text = Global.getStrTime(chatNormalContentEdit.time.v);
                    }
                    else
                    {
                        Debug.LogError("tvTime null");
                    }
                }
                else
                {
                    Debug.LogError("chatNormalContentEdit null");
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

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.chatNormalContentEdit.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        if(data is ChatNormalContentEdit)
        {
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
            // Child
            {
                uiData.chatNormalContentEdit.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        if (data is ChatNormalContentEdit)
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
                case UIData.Property.chatNormalContentEdit:
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
        if (wrapProperty.p is ChatNormalContentEdit)
        {
            switch ((ChatNormalContentEdit.Property)wrapProperty.n)
            {
                case ChatNormalContentEdit.Property.time:
                    dirty = true;
                    break;
                case ChatNormalContentEdit.Property.message:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}