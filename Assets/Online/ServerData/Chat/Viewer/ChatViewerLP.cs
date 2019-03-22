using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatViewerLP : LP<ChatViewer>, ValueChangeCallBack
{

    #region Constructor

    public ChatViewerLP(Data parent, byte name) : base(parent, name)
    {
        parent.addCallBack(this);
    }

    #endregion

    #region dictionary

    private Dictionary<uint, ChatViewer> chatViewerDict = new Dictionary<uint, ChatViewer>();
    private HashSet<ChatViewer> notCorrectChatViewers = new HashSet<ChatViewer>();

    public ChatViewer getInList(uint userId)
    {
        ChatViewer ret = null;
        {
            // get in dict
            ChatViewer oldChatViewer = null;
            {
                if (!chatViewerDict.TryGetValue(userId, out oldChatViewer))
                {
                    Debug.LogError("Don't have chatViewer");
                }
            }
            // get in notCorrectChatViewers
            if (oldChatViewer != null && oldChatViewer.userId.v == userId)
            {
                // Debug.LogError("already found, not find in notCorrectChatViewers anymore");
                ret = oldChatViewer;
            }
            else
            {
                // add to notCorrectChatViewers
                if (oldChatViewer != null)
                {
                    notCorrectChatViewers.Add(oldChatViewer);
                    chatViewerDict.Remove(userId);
                }
                // find in not correctChatViewers
                {
                    // find
                    foreach (ChatViewer user in notCorrectChatViewers)
                    {
                        if (user.userId.v == userId)
                        {
                            ret = user;
                            break;
                        }
                    }
                    // add to dictionary
                    if (ret != null)
                    {
                        chatViewerDict[userId] = ret;
                        notCorrectChatViewers.Remove(ret);
                    }
                }
            }
        }
        return ret;
    }

    #endregion

    #region implement callBacks

    public void onAddCallBack<T>(T data) where T : Data
    {
        if(data == p)
        {
            return;
        }
        if (data is ChatViewer)
        {
            ChatViewer chatViewer = data as ChatViewer;
            // add
            {
                // find old
                ChatViewer oldChatViewer = null;
                {
                    if (chatViewerDict.TryGetValue(chatViewer.userId.v, out oldChatViewer))
                    {
                        Debug.LogError("already have oldChatViewer: " + oldChatViewer);
                    }
                }
                // process
                if (oldChatViewer == null)
                {
                    chatViewerDict[chatViewer.userId.v] = chatViewer;
                }
                else
                {
                    notCorrectChatViewers.Add(chatViewer);
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if(data == p)
        {
            return;
        }
        if (data is ChatViewer)
        {
            ChatViewer chatViewer = data as ChatViewer;
            // remove
            {
                // find old
                ChatViewer oldChatViewer = null;
                {
                    if (chatViewerDict.TryGetValue(chatViewer.userId.v, out oldChatViewer))
                    {

                    }
                }
                // process
                if (oldChatViewer == chatViewer)
                {
                    chatViewerDict.Remove(chatViewer.userId.v);
                    notCorrectChatViewers.Remove(chatViewer);
                }
                else
                {
                    Debug.LogError("Don't have old chatViewer");
                    notCorrectChatViewers.Remove(chatViewer);
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if(wrapProperty.p == p)
        {
            if (wrapProperty == this)
            {
                ValueChangeUtils.replaceCallBack(this, syncs);
            }
            return;
        }
        // Child
        if(wrapProperty.p is ChatViewer)
        {
            switch ((ChatViewer.Property)wrapProperty.n)
            {
                case ChatViewer.Property.userId:
                    {
                        ChatViewer chatViewer = wrapProperty.p as ChatViewer;
                        notCorrectChatViewers.Add(chatViewer);
                    }
                    break;
                case ChatViewer.Property.minViewId:
                    break;
                case ChatViewer.Property.subViews:
                    break;
                case ChatViewer.Property.connection:
                    break;
                case ChatViewer.Property.isActive:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
    }

    #endregion

}