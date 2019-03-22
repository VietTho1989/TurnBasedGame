using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatMessageUpdate : UpdateBehavior<ChatMessage>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is ChatMessage)
        {
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is ChatMessage)
        {
            ChatMessage chatMessage = data as ChatMessage;
            // set data null
            this.setDataNull(chatMessage);
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
        if(wrapProperty.p is ChatMessage)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}