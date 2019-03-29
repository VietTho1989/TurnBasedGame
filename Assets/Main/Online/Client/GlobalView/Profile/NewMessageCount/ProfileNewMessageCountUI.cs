using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ProfileNewMessageCountUI : UIBehavior<ProfileNewMessageCountUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Server>> server;

        #region Constructor

        public enum Property
        {
            server
        }

        public UIData() : base()
        {
            this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
        }

        #endregion

    }

    #endregion

    #region Refresh

    public Text tvNewCount;
    public Image bg;

    private User profileUser = null;
    private ChatViewer chatViewer = null;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Server server = this.data.server.v.data;
                if (server != null)
                {
                    uint profileId = server.profileId.v;
                    // find count
                    uint newCount = 0;
                    {
                        // find profileUser
                        {
                            // check old
                            if (profileUser != null)
                            {
                                // isCorrect
                                bool isCorrect = false;
                                {
                                    if (profileUser.findDataInParent<Server>() == server)
                                    {
                                        if (profileUser.human.v.playerId.v == profileId)
                                        {
                                            isCorrect = true;
                                        }
                                    }
                                }
                                // process
                                if (isCorrect)
                                {
                                    // oldProfileUser correct
                                }
                                else
                                {
                                    profileUser.removeCallBack(this);
                                    profileUser = null;
                                }
                            }
                            // find new
                            if (profileUser == null)
                            {
                                profileUser = server.users.getInList(profileId);
                                if (profileUser != null)
                                {
                                    profileUser.addCallBack(this);
                                }
                                else
                                {
                                    Debug.LogError("don't find profileUser: " + profileId);
                                }
                            }
                        }
                        // find newCount
                        if (profileUser != null)
                        {
                            ChatRoom chatRoom = profileUser.chatRoom.v;
                            if (chatRoom != null)
                            {
                                // find chatViewer
                                ChatViewer chatViewer = null;
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
                                            Debug.LogError("don't find chatViewer: " + profileId);
                                        }
                                    }
                                }
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
                            else
                            {
                                Debug.LogError("chatRoom nul");
                            }
                        }
                        else
                        {
                            Debug.LogError("profileUser null");
                        }
                    }
                    // set
                    if (tvNewCount != null && bg != null)
                    {
                        if (newCount <= 0)
                        {
                            tvNewCount.text = "";
                            bg.enabled = false;
                        }
                        else if (newCount <= 50)
                        {
                            tvNewCount.text = "" + newCount;
                            bg.enabled = true;
                        }
                        else
                        {
                            tvNewCount.text = "50+";
                            bg.enabled = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("tvNewCount, bg null");
                    }
                }
                else
                {
                    Debug.LogError("server null");
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
        if (this.profileUser != null)
        {
            this.profileUser.removeCallBack(this);
            this.profileUser = null;
        }
        else
        {
            // Debug.LogError ("profileUser null: " + this);
        }
        if (this.chatViewer != null)
        {
            this.chatViewer.removeCallBack(this);
            this.chatViewer = null;
        }
        else
        {
            // Debug.LogError("chatViewer null");
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
                uiData.server.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if(data is Server)
            {
                dirty = true;
                return;
            }
            // Child
            {
                if(data is User)
                {
                    User user = data as User;
                    // Child
                    {
                        user.chatRoom.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is ChatRoom)
                    {
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
                uiData.server.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is Server)
            {
                return;
            }
            // Child
            {
                if(data is User)
                {
                    User user = data as User;
                    // Child
                    {
                        user.chatRoom.allRemoveCallBack(this);
                    }
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
                case UIData.Property.server:
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
            if (wrapProperty.p is Server)
            {
                switch ((Server.Property)wrapProperty.n)
                {
                    case Server.Property.serverConfig:
                        break;
                    case Server.Property.instanceId:
                        break;
                    case Server.Property.startState:
                        break;
                    case Server.Property.type:
                        break;
                    case Server.Property.profile:
                        break;
                    case Server.Property.state:
                        break;
                    case Server.Property.users:
                        dirty = true;
                        break;
                    case Server.Property.disconnectTime:
                        break;
                    case Server.Property.roomManager:
                        break;
                    case Server.Property.globalChat:
                        break;
                    case Server.Property.friendWorld:
                        break;
                    case Server.Property.guilds:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if(wrapProperty.p is User)
                {
                    switch ((User.Property)wrapProperty.n)
                    {
                        case User.Property.human:
                            break;
                        case User.Property.role:
                            break;
                        case User.Property.ipAddress:
                            break;
                        case User.Property.registerTime:
                            break;
                        case User.Property.chatRoom:
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
                            case ChatRoom.Property.editMax:
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
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}