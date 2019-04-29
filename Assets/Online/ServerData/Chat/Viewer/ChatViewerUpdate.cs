using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class ChatViewerUpdate : UpdateBehavior<ChatViewer>
{

    #region Update

    private Human serverHuman = null;

    public override void OnDestroy()
    {
        base.OnDestroy();
        if (this.serverHuman != null)
        {
            this.serverHuman.removeCallBack(this);
            this.serverHuman = null;
        }
    }

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // find connection
                NetworkConnection connection = null;
                {
                    // check correct serverHuman
                    {
                        if (this.serverHuman != null)
                        {
                            if (this.serverHuman.playerId.v != this.data.userId.v)
                            {
                                this.serverHuman.removeCallBack(this);
                                this.serverHuman = null;
                            }
                        }
                    }
                    // find server human
                    {
                        if (this.serverHuman == null)
                        {
                            Server server = this.data.findDataInParent<Server>();
                            if (server != null)
                            {
                                User serverUser = server.users.getInList(this.data.userId.v);
                                if (serverUser != null)
                                {
                                    this.serverHuman = serverUser.human.v;
                                    this.serverHuman.addCallBack(this);
                                }
                                else
                                {
                                    Debug.LogError("serverHuman null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("server null: " + this);
                            }
                        }
                    }
                    // copy
                    if (this.serverHuman != null)
                    {
                        connection = this.serverHuman.connection.v;
                    }
                    else
                    {
                        Debug.LogError("server human null: " + this);
                    }
                }
                // process
                if (connection != null)
                {
                    this.data.connection.v = connection;
                    // subViews
                    uint newMinId = this.data.minViewId.v;
                    {
                        for (int i = this.data.subViews.vs.Count - 1; i >= 0; i--)
                        {
                            ChatSubView chatSubView = this.data.subViews.vs[i];
                            if (chatSubView.max.v >= newMinId)
                            {
                                newMinId = chatSubView.min.v;
                                this.data.subViews.removeAt(i);
                            }
                        }
                    }
                    this.data.minViewId.v = newMinId;
                }
                else
                {
                    // remove viewer
                    /*ChatRoom chatRoom = this.data.findDataInParent<ChatRoom>();
                    if (chatRoom != null)
                    {
                        chatRoom.chatViewers.remove(this.data);
                    }
                    else
                    {
                        Debug.LogError("chatRoom null: " + this);
                    }*/
                    this.data.isActive.v = false;
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
        if (data is ChatViewer)
        {
            ChatViewer chatViewer = data as ChatViewer;
            // Child
            {
                chatViewer.subViews.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Parent
        if (data is Human)
        {
            dirty = true;
            return;
        }
        // Child
        if (data is ChatSubView)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is ChatViewer)
        {
            ChatViewer chatViewer = data as ChatViewer;
            // Child
            {
                chatViewer.subViews.allRemoveCallBack(this);
            }
            this.setDataNull(chatViewer);
            return;
        }
        // Parent
        if (data is Human)
        {
            return;
        }
        // Child
        if (data is ChatSubView)
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
        if (wrapProperty.p is ChatViewer)
        {
            switch ((ChatViewer.Property)wrapProperty.n)
            {
                case ChatViewer.Property.userId:
                    dirty = true;
                    break;
                case ChatViewer.Property.minViewId:
                    dirty = true;
                    break;
                case ChatViewer.Property.subViews:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case ChatViewer.Property.connection:
                    dirty = true;
                    break;
                case ChatViewer.Property.isActive:
                    dirty = true;
                    break;
                case ChatViewer.Property.alreadyViewMaxId:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Parent
        if (wrapProperty.p is Human)
        {
            switch ((Human.Property)wrapProperty.n)
            {
                case Human.Property.playerId:
                    dirty = true;
                    break;
                case Human.Property.account:
                    break;
                case Human.Property.state:
                    break;
                case Human.Property.email:
                    break;
                case Human.Property.phoneNumber:
                    break;
                case Human.Property.status:
                    break;
                case Human.Property.birthday:
                    break;
                case Human.Property.sex:
                    break;
                case Human.Property.connection:
                    dirty = true;
                    break;
                case Human.Property.ban:
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
                    dirty = true;
                    break;
                case ChatSubView.Property.max:
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