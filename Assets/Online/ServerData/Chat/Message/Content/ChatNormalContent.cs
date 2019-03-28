using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatNormalContent : ChatMessage.Content
{

    public const uint MAX_LENGTH = 100;
    public const uint MAX_EDIT = 5;

    #region Owner

    public VP<uint> owner;

    public bool isMine()
    {
        if (Server.getProfileUserId(this) == this.owner.v)
        {
            return true;
        }
        return false;
    }

    #endregion

    #region Content

    public VP<string> message;

    public LP<ChatNormalContentEdit> edits;

    public override string getMessage()
    {
        string ret = this.message.v;
        {
            if (this.edits.vs.Count > 0)
            {
                ChatNormalContentEdit chatNormalContentEdit = this.edits.vs[this.edits.vs.Count - 1];
                ret = chatNormalContentEdit.message.v;
            }
        }
        return ret;
    }

    #endregion

    #region edit

    public bool isCanEdit(uint userId, string newMessage)
    {
        if (string.IsNullOrEmpty(newMessage))
        {
            return false;
        }
        // Can edit anymore
        {
            // find
            uint editMax = MAX_EDIT;
            {
                ChatRoom chatRoom = this.findDataInParent<ChatRoom>();
                if (chatRoom != null)
                {
                    editMax = chatRoom.editMax.v;
                }
                else
                {
                    Debug.LogError("chatRoom null");
                }
            }
            // process
            if (this.edits.vs.Count >= editMax)
            {
                return false;
            }
        }
        // different message
        {
            if (this.getMessage() == newMessage)
            {
                Debug.LogError("the same messages");
                return false;
            }
        }
        // correct user
        if (this.owner.v == userId)
        {
            Debug.Log("not correct userId: " + userId);
        }
        else
        {
            return false;
        }
        // return
        return true;
    }

    public void requestEdit(uint userId, string newMessage)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.edit(userId, newMessage);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is ChatNormalContentIdentity)
                    {
                        ChatNormalContentIdentity chatNormalContentIdentity = dataIdentity as ChatNormalContentIdentity;
                        chatNormalContentIdentity.requestEdit(userId, newMessage);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void edit(uint userId, string newMessage)
    {
        if (isCanEdit(userId, newMessage))
        {
            ChatNormalContentEdit edit = new ChatNormalContentEdit();
            {
                edit.time.v = Global.getRealTimeInMiliSeconds();
                edit.message.v = newMessage;
            }
            this.edits.add(edit);
        }
        else
        {
            Debug.LogError("cannot edit: " + this + ", " + userId + ", " + newMessage);
        }
    }

    #endregion

    #region Constructor

    public enum Property
    {
        owner,
        message,
        edits
    }

    public ChatNormalContent() : base()
    {
        this.owner = new VP<uint>(this, (byte)Property.owner, 0);
        this.message = new VP<string>(this, (byte)Property.message, "");
        this.edits = new LP<ChatNormalContentEdit>(this, (byte)Property.edits);
    }

    #endregion

    public override Type getType()
    {
        return ChatMessage.Content.Type.Normal;
    }

}