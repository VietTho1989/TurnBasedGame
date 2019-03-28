using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class ChatMessageObserver : GameObserver.CheckChange
{

    public ChatMessageObserver(GameObserver gameObserver) : base(gameObserver)
    {

    }

    #region setData

    public ChatMessage data = null;

    public override void setData(Data newData)
    {
        // set
        if (this.data != newData)
        {
            // remove old
            if (this.data != null)
            {
                this.data.removeCallBack(this);
            }
            // set new 
            {
                this.data = newData as ChatMessage;
                if (this.data != null)
                {
                    this.data.addCallBack(this);
                }
            }
        }
        else
        {
            // Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
        }
    }


    public override Type getType()
    {
        return Type.ChatMessage;
    }

    #endregion

    #region implement callBacks

    private ChatRoom chatRoom = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is ChatMessage)
        {
            ChatMessage chatMessage = data as ChatMessage;
            // Parent
            {
                DataUtils.addParentCallBack(chatMessage, this, ref this.chatRoom);
            }
            return;
        }
        // Parent
        {
            if (data is ChatRoom)
            {
                ChatRoom chatRoom = data as ChatRoom;
                // Child
                {
                    chatRoom.chatViewers.allAddCallBack(this);
                }
                return;
            }
            // Child
            {
                if (data is ChatViewer)
                {
                    ChatViewer chatViewer = data as ChatViewer;
                    // Child
                    {
                        chatViewer.subViews.allAddCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is ChatSubView)
                {
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is ChatMessage)
        {
            ChatMessage chatMessage = data as ChatMessage;
            // Parent
            {
                DataUtils.removeParentCallBack(chatMessage, this, ref this.chatRoom);
            }
            this.data = null;
            return;
        }
        // Parent
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
            {
                if (data is ChatViewer)
                {
                    ChatViewer chatViewer = data as ChatViewer;
                    // Child
                    {
                        chatViewer.subViews.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is ChatSubView)
                {
                    return;
                }
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
        if (wrapProperty.p is ChatMessage)
        {
            switch ((ChatMessage.Property)wrapProperty.n)
            {
                case ChatMessage.Property.state:
                    {
                        gameObserver.dirty = true;
                        gameObserver.needRefresh = true;
                    }
                    break;
                case ChatMessage.Property.time:
                    break;
                case ChatMessage.Property.content:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Parent
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
                            gameObserver.dirty = true;
                            gameObserver.needRefresh = true;
                        }
                        break;
                    case ChatRoom.Property.typing:
                        break;
                    case ChatRoom.Property.maxId:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is ChatViewer)
                {
                    switch ((ChatViewer.Property)wrapProperty.n)
                    {
                        case ChatViewer.Property.userId:
                            {
                                gameObserver.dirty = true;
                                gameObserver.needRefresh = true;
                            }
                            break;
                        case ChatViewer.Property.minViewId:
                            {
                                gameObserver.dirty = true;
                                gameObserver.needRefresh = true;
                            }
                            break;
                        case ChatViewer.Property.subViews:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                gameObserver.dirty = true;
                                gameObserver.needRefresh = true;
                            }
                            break;
                        case ChatViewer.Property.connection:
                            {
                                gameObserver.dirty = true;
                                gameObserver.needRefresh = true;
                            }
                            break;
                        case ChatViewer.Property.isActive:
                            {
                                gameObserver.dirty = true;
                                gameObserver.needRefresh = true;
                            }
                            break;
                        case ChatViewer.Property.alreadyViewMaxId:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is ChatSubView)
                {
                    switch ((ChatSubView.Property)wrapProperty.n)
                    {
                        case ChatSubView.Property.min:
                            {
                                gameObserver.dirty = true;
                                gameObserver.needRefresh = true;
                            }
                            break;
                        case ChatSubView.Property.max:
                            {
                                gameObserver.dirty = true;
                                gameObserver.needRefresh = true;
                            }
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void refreshObserverConnections()
    {
        gameObserver.allConnections.Clear();
        if (this.data != null)
        {
            if (this.data.state.v != ChatMessage.State.TrueDelete)
            {
                List<NetworkConnection> parentConnections = gameObserver.getParentObserver();
                // find in chat viewer
                ChatRoom chatRoom = this.data.findDataInParent<ChatRoom>();
                if (chatRoom != null)
                {
                    foreach (ChatViewer chatViewer in chatRoom.chatViewers.vs)
                    {
                        if (chatViewer.connection.v != null)
                        {
                            // check can view
                            bool canView = false;
                            {
                                if (chatViewer.isActive.v)
                                {
                                    if (this.data.uid >= chatViewer.minViewId.v)
                                    {
                                        // check min
                                        canView = true;
                                    }
                                    else
                                    {
                                        // check sub
                                        foreach (ChatSubView chatSubView in chatViewer.subViews.vs)
                                        {
                                            if (this.data.uid >= chatSubView.min.v && this.data.uid <= chatSubView.max.v)
                                            {
                                                canView = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // Debug.LogError("chatViewer not active");
                                }
                            }
                            // process
                            if (canView)
                            {
                                if (parentConnections.Contains(chatViewer.connection.v))
                                {
                                    gameObserver.allConnections.Add(chatViewer.connection.v);
                                }
                                else
                                {
                                    Debug.LogError("why parentConnections not contain: " + chatViewer);
                                }
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("chatRoom null: " + this);
                }
            }
            else
            {
                Debug.LogError("true delete, not show: " + this.data);
            }
        }
        else
        {
            Debug.LogError("chatMessage null: " + this);
        }
        // Debug.LogError ("refreshObserverConnections: humConnectionObserver: " + gameObserver.allConnections.Count);
    }

    public override void onChangeParentObservers(Dictionary<int, NetworkConnection>.ValueCollection parentObserver)
    {
        gameObserver.dirty = true;
        gameObserver.needRefresh = true;
    }

}