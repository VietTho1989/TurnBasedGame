using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class ChatViewerObserver : GameObserver.CheckChange
{

    public ChatViewerObserver(GameObserver gameObserver) : base(gameObserver)
    {

    }

    #region setData

    public ChatViewer data = null;

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
                this.data = newData as ChatViewer;
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
        return Type.ChatViewer;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is ChatViewer)
        {
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is ChatViewer)
        {
            this.data = null;
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
                    break;
                case ChatViewer.Property.minViewId:
                    break;
                case ChatViewer.Property.subViews:
                    break;
                case ChatViewer.Property.connection:
                    {
                        gameObserver.dirty = true;
                        gameObserver.needRefresh = true;
                    }
                    break;
                case ChatViewer.Property.isActive:
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

    public override void refreshObserverConnections()
    {
        gameObserver.allConnections.Clear();
        if (this.data != null)
        {
            List<NetworkConnection> parentConnections = gameObserver.getParentObserver();
            if (this.data.connection.v != null)
            {
                if (parentConnections.Contains(this.data.connection.v))
                {
                    gameObserver.allConnections.Add(this.data.connection.v);
                }
                else
                {
                    Debug.LogError("why parentConnections not contain: " + this.data);
                }
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