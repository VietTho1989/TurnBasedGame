using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChatRoomNewMessageCountUI : UIBehavior<ChatRoomNewMessageCountUI.UIData>
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

    #region Refresh

    public Image bg;
    public Text tvNewCount;

    private ChatViewer chatViewer = null;

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
                    uint profileId = Server.getProfileUserId(chatRoom);
                    // find chatViewer
                    {
                        // check old
                        if (chatViewer != null)
                        {
                            // isCorrect
                            bool isCorrect = false;
                            {
                                if (chatViewer.getDataParent() == chatRoom)
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
                    // find count
                    uint newCount = 0;
                    {
                        // find alreadyViewMaxId
                        uint alreadyViewMaxId = 0;
                        {
                            if (chatViewer != null)
                            {
                                alreadyViewMaxId = chatViewer.alreadyViewMaxId.v;
                            }
                            else
                            {
                                Debug.LogError("chatViewer null");
                            }
                        }
                        // process
                        if (chatRoom.maxId.v >= alreadyViewMaxId)
                        {
                            newCount = chatRoom.maxId.v - alreadyViewMaxId;
                        }
                        else
                        {
                            Debug.LogError("error, why maxId < alreadyViewMaxId");
                        }
                    }
                    // set
                    if (tvNewCount != null && bg!=null)
                    {
                        if (newCount <= 0)
                        {
                            tvNewCount.text = "";
                            bg.enabled = false;
                        }
                        else if (newCount > 50)
                        {
                            tvNewCount.text = "50+";
                            bg.enabled = true;
                        }
                        else
                        {
                            tvNewCount.text = "" + newCount;
                            bg.enabled = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("tvNewCount null");
                    }
                }
                else
                {
                    Debug.LogError("chatRoom null");
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

    public override void OnDestroy()
    {
        base.OnDestroy();
        if (this.chatViewer != null)
        {
            this.chatViewer.removeCallBack(this);
            this.chatViewer = null;
        }
        else
        {
            // Debug.LogError ("human owner null: " + this);
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
                uiData.chatRoom.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if(data is ChatRoom)
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
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.chatRoom.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is ChatRoom)
            {
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
            // Child
            if (wrapProperty.p is ChatViewer)
            {
                switch ((ChatViewer.Property)wrapProperty.n)
                {
                    case ChatViewer.Property.userId:
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}