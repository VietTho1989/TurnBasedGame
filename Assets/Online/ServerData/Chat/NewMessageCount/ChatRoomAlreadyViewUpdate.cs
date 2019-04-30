using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class ChatRoomAlreadyViewUpdate : UpdateBehavior<ChatRoomAlreadyViewUpdate.UpdateData>
{

    #region updateData

    public class UpdateData : Data
    {

        public VP<uint> alreadyViewMaxId;

        #region state

        public enum State
        {
            None,
            Wait
        }

        public VP<State> state;

        #endregion

        #region Constructor

        public enum Property
        {
            alreadyViewMaxId,
            state
        }

        public UpdateData() : base()
        {
            this.alreadyViewMaxId = new VP<uint>(this, (byte)Property.alreadyViewMaxId, 0);
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public void reset()
        {
            this.alreadyViewMaxId.v = 0;
            this.state.v = State.None;
        }

    }

    #endregion

    #region update

    private ChatViewer chatViewer = null;

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                ChatRoomUI.UIData chatRoomUIData = this.data.findDataInParent<ChatRoomUI.UIData>();
                if (chatRoomUIData != null)
                {
                    ChatRoom chatRoom = chatRoomUIData.chatRoom.v.data;
                    if (chatRoom != null)
                    {
                        uint profileId = Server.getProfileUserId(chatRoom);
                        // find chatViewer
                        {
                            // check old
                            if (chatViewer != null)
                            {
                                // isCorrect
                                bool isCorrect = false;
                                {
                                    if (chatViewer.findDataInParent<ChatRoom>() == chatRoom)
                                    {
                                        if (chatViewer.userId.v == profileId)
                                        {
                                            isCorrect = true;
                                        }
                                    }
                                }
                                // process
                                if (isCorrect)
                                {
                                    // oldChatViewer correct
                                }
                                else
                                {
                                    chatViewer.removeCallBack(this);
                                    chatViewer = null;
                                }
                            }
                            // find new
                            if (chatViewer == null)
                            {
                                chatViewer = chatRoom.chatViewers.getInList(profileId);
                                if (chatViewer != null)
                                {
                                    chatViewer.addCallBack(this);
                                }
                                else
                                {
                                    Debug.LogError("don't find chatViewer: " + chatViewer);
                                }
                            }
                        }
                        // process
                        if (chatViewer != null)
                        {
                            // find alreadyViewMaxId
                            {
                                // find
                                uint currentViewMaxId = 0;
                                {
                                    ChatRoomAdapter.UIData chatRoomAdapterUIData = chatRoomUIData.chatRoomAdapter.v;
                                    if (chatRoomAdapterUIData != null)
                                    {
                                        foreach(ChatMessageHolder.UIData holder in chatRoomAdapterUIData.holders.vs)
                                        {
                                            ChatMessage chatMessage = holder.chatMessage.v.data;
                                            if (chatMessage != null)
                                            {
                                                if (chatMessage.uid > currentViewMaxId)
                                                {
                                                    currentViewMaxId = chatMessage.uid;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("chatMessage null");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("chatRoomAdapterUIData null");
                                    }
                                }
                                // set
                                if (this.data.alreadyViewMaxId.v < currentViewMaxId)
                                {
                                    this.data.alreadyViewMaxId.v = currentViewMaxId;
                                }
                            }
                            // Task
                            switch (this.data.state.v)
                            {
                                case UpdateData.State.None:
                                    {
                                        destroyRoutine(wait);
                                        // send
                                        if (this.data.alreadyViewMaxId.v <= chatRoom.maxId.v)
                                        {
                                            if (this.data.alreadyViewMaxId.v > chatViewer.alreadyViewMaxId.v)
                                            {
                                                // Debug.LogError("send new alreadyViewMaxId: " + this.data.alreadyViewMaxId.v);
                                                if (Server.IsServerOnline(chatRoom))
                                                {
                                                    chatViewer.requestSetAlreadyViewMaxId(profileId, this.data.alreadyViewMaxId.v);
                                                }
                                                else
                                                {
                                                    Debug.LogError("server not online");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("why alreadyViewMaxId too high: " + this.data.alreadyViewMaxId.v + ", " + chatRoom.maxId.v);
                                        }
                                    }
                                    break;
                                case UpdateData.State.Wait:
                                    {
                                        if (Server.IsServerOnline(chatRoom))
                                        {
                                            startRoutine(ref this.wait, TaskWait());
                                        }
                                        else
                                        {
                                            this.data.state.v = UpdateData.State.None;
                                            destroyRoutine(wait);
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown state: " + this.data.state.v);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("data null");
                            this.data.state.v = UpdateData.State.None;
                            destroyRoutine(wait);
                        }
                    }
                    else
                    {
                        Debug.LogError("chatRoom null");
                        this.data.state.v = UpdateData.State.None;
                        destroyRoutine(wait);
                    }
                }
                else
                {
                    Debug.LogError("chatRoomUIData null");
                    this.data.state.v = UpdateData.State.None;
                    destroyRoutine(wait);
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
        return false;
    }

    #endregion

    #region Task wait

    private Routine wait;

    public IEnumerator TaskWait()
    {
        if (this.data != null)
        {
            yield return new Wait(15f);
            this.data.state.v = UpdateData.State.None;
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public override List<Routine> getRoutineList()
    {
        List<Routine> ret = new List<Routine>();
        {
            ret.Add(wait);
        }
        return ret;
    }

    #endregion

    #region implement callBacks

    private ChatRoomUI.UIData chatRoomUIData = null;
    private Server server = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UpdateData)
        {
            UpdateData updateData = data as UpdateData;
            // Parent
            {
                DataUtils.addParentCallBack(updateData, this, ref this.chatRoomUIData);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if(data is ChatRoomUI.UIData)
            {
                ChatRoomUI.UIData chatRoomUIData = data as ChatRoomUI.UIData;
                // Child
                {
                    chatRoomUIData.chatRoom.allAddCallBack(this);
                    chatRoomUIData.chatRoomAdapter.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                // chatRoom
                {
                    if(data is ChatRoom)
                    {
                        ChatRoom chatRoom = data as ChatRoom;
                        // Parent
                        {
                            DataUtils.addParentCallBack(chatRoom, this, ref this.server);
                        }
                        dirty = true;
                        return;
                    }
                    // Parent
                    if(data is Server)
                    {
                        dirty = true;
                        return;
                    }
                    // Child
                    if(data is ChatViewer)
                    {
                        dirty = true;
                        return;
                    }
                }
                // chatRoomAdapter
                {
                    if(data is ChatRoomAdapter.UIData)
                    {
                        ChatRoomAdapter.UIData chatRoomAdapterUIData = data as ChatRoomAdapter.UIData;
                        // Child
                        {
                            chatRoomAdapterUIData.holders.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is ChatMessageHolder.UIData)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UpdateData)
        {
            UpdateData updateData = data as UpdateData;
            // Parent
            {
                DataUtils.removeParentCallBack(updateData, this, ref this.chatRoomUIData);
            }
            this.setDataNull(updateData);
            return;
        }
        // Child
        {
            if (data is ChatRoomUI.UIData)
            {
                ChatRoomUI.UIData chatRoomUIData = data as ChatRoomUI.UIData;
                // Child
                {
                    chatRoomUIData.chatRoom.allRemoveCallBack(this);
                    chatRoomUIData.chatRoomAdapter.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            {
                // chatRoom
                {
                    if (data is ChatRoom)
                    {
                        ChatRoom chatRoom = data as ChatRoom;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(chatRoom, this, ref this.server);
                        }
                        return;
                    }
                    // Parent
                    if (data is Server)
                    {
                        return;
                    }
                    // Child
                    if (data is ChatViewer)
                    {
                        return;
                    }
                }
                // chatRoomAdapter
                {
                    if (data is ChatRoomAdapter.UIData)
                    {
                        ChatRoomAdapter.UIData chatRoomAdapterUIData = data as ChatRoomAdapter.UIData;
                        // Child
                        {
                            chatRoomAdapterUIData.holders.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is ChatMessageHolder.UIData)
                    {
                        return;
                    }
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
        if (wrapProperty.p is UpdateData)
        {
            switch ((UpdateData.Property)wrapProperty.n)
            {
                case UpdateData.Property.alreadyViewMaxId:
                    dirty = true;
                    break;
                case UpdateData.Property.state:
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
            if (wrapProperty.p is ChatRoomUI.UIData)
            {
                switch ((ChatRoomUI.UIData.Property)wrapProperty.n)
                {
                    case ChatRoomUI.UIData.Property.chatRoom:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case ChatRoomUI.UIData.Property.needHeader:
                        break;
                    case ChatRoomUI.UIData.Property.topicUI:
                        break;
                    case ChatRoomUI.UIData.Property.chatRoomAdapter:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case ChatRoomUI.UIData.Property.typingUI:
                        break;
                    case ChatRoomUI.UIData.Property.chatMessageMenu:
                        break;
                    case ChatRoomUI.UIData.Property.canSendMessage:
                        break;
                    case ChatRoomUI.UIData.Property.btnLoadMore:
                        break;
                    case ChatRoomUI.UIData.Property.alreadyView:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                // chatRoom
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
                            case ChatRoom.Property.maxId:
                                dirty = true;
                                break;
                            case ChatRoom.Property.chatViewers:
                                dirty = true;
                                break;
                            case ChatRoom.Property.typing:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Parent
                    if (wrapProperty.p is Server)
                    {
                        Server.State.OnUpdateSyncStateChange(wrapProperty, this);
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
                                break;
                            case ChatViewer.Property.alreadyViewMaxId:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                // chatRoomAdapter
                {
                    if (wrapProperty.p is ChatRoomAdapter.UIData)
                    {
                        switch ((ChatRoomAdapter.UIData.Property)wrapProperty.n)
                        {
                            case ChatRoomAdapter.UIData.Property.chatRoom:
                                break;
                            case ChatRoomAdapter.UIData.Property.holders:
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
                    if (wrapProperty.p is ChatMessageHolder.UIData)
                    {
                        switch ((ChatMessageHolder.UIData.Property)wrapProperty.n)
                        {
                            case ChatMessageHolder.UIData.Property.chatMessage:
                                dirty = true;
                                break;
                            case ChatMessageHolder.UIData.Property.sub:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}