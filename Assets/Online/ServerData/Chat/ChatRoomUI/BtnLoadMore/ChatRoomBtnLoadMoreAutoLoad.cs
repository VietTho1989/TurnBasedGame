using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatRoomBtnLoadMoreAutoLoad : UpdateBehavior<ChatRoomBtnLoadMoreUI.UIData>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                if (this.data.state.v == ChatRoomBtnLoadMoreUI.UIData.State.None)
                {
                    ChatRoom chatRoom = this.data.chatRoom.v.data;
                    if (chatRoom != null)
                    {
                        uint profileId = Server.getProfileUserId(chatRoom);
                        ChatViewer chatViewer = chatRoom.findChatViewer(profileId);
                        if (chatViewer == null || !chatViewer.isActive.v)
                        {
                            this.data.state.v = ChatRoomBtnLoadMoreUI.UIData.State.Request;
                        }
                        else
                        {
                            Debug.LogError("already have chatViewer: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("chatRoom null: " + this);
                    }
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

    public override void onAddCallBack<T>(T data)
    {
        if (data is ChatRoomBtnLoadMoreUI.UIData)
        {
            ChatRoomBtnLoadMoreUI.UIData btnLoadMoreUIData = data as ChatRoomBtnLoadMoreUI.UIData;
            // Child
            {
                btnLoadMoreUIData.chatRoom.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is ChatRoom)
            {
                ChatRoom chatRoom = data as ChatRoom;
                // Child
                {
                    chatRoom.chatViewers.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is ChatViewer)
            {
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is ChatRoomBtnLoadMoreUI.UIData)
        {
            ChatRoomBtnLoadMoreUI.UIData btnLoadMoreUIData = data as ChatRoomBtnLoadMoreUI.UIData;
            // Child
            {
                btnLoadMoreUIData.chatRoom.allRemoveCallBack(this);
            }
            this.setDataNull(btnLoadMoreUIData);
            return;
        }
        // Child
        {
            if (data is ChatRoom)
            {
                ChatRoom chatRoom = data as ChatRoom;
                // Child
                {
                    chatRoom.chatViewers.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            if (data is ChatViewer)
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
        if (wrapProperty.p is ChatRoomBtnLoadMoreUI.UIData)
        {
            switch ((ChatRoomBtnLoadMoreUI.UIData.Property)wrapProperty.n)
            {
                case ChatRoomBtnLoadMoreUI.UIData.Property.chatRoom:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case ChatRoomBtnLoadMoreUI.UIData.Property.state:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is ChatRoom)
            {
                switch ((ChatRoom.Property)wrapProperty.n)
                {
                    case ChatRoom.Property.topic:
                        break;
                    case ChatRoom.Property.isEnable:
                        break;
                    case ChatRoom.Property.players:
                        break;
                    case ChatRoom.Property.messages:
                        break;
                    case ChatRoom.Property.chatViewers:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case ChatRoom.Property.typing:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            if (wrapProperty.p is ChatViewer)
            {
                switch ((ChatViewer.Property)wrapProperty.n)
                {
                    case ChatViewer.Property.userId:
                        dirty = true;
                        break;
                    case ChatViewer.Property.minViewId:
                        break;
                    case ChatViewer.Property.subViews:
                        break;
                    case ChatViewer.Property.connection:
                        break;
                    case ChatViewer.Property.isActive:
                        dirty = true;
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

}