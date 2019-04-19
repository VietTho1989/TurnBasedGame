using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class EveryOneObserver : GameObserver.CheckChange
{

    public EveryOneObserver(GameObserver gameObserver) : base(gameObserver)
    {

    }

    #region setData

    private Server data = null;

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
                this.data = newData as Server;
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
        return Type.EveryOne;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is Server)
        {
            Server server = data as Server;
            // Child
            {
                server.users.allAddCallBack(this);
            }
            // dirty = true;
            // needRefresh = true;
            return;
        }
        // Child
        {
            if (data is User)
            {
                User user = data as User;
                // Child
                {
                    user.human.allAddCallBack(this);
                }
                // dirty = true;
                // needRefresh = true;
                return;
            }
            // Child
            {
                if (data is Human)
                {
                    Human human = data as Human;
                    // Child
                    {
                        human.state.allAddCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is UserState)
                {
                    // dirty = true;
                    // needRefresh = true;
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is Server)
        {
            Server server = data as Server;
            // Child
            {
                server.users.allRemoveCallBack(this);
            }
            // set data null
            this.data = null;
            return;
        }
        // Child
        {
            if (data is User)
            {
                User user = data as User;
                // Child
                {
                    user.human.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            {
                if (data is Human)
                {
                    Human human = data as Human;
                    // Child
                    {
                        human.state.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is UserState)
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
        if (wrapProperty.p is Server)
        {
            switch ((Server.Property)wrapProperty.n)
            {
                case Server.Property.startState:
                    break;
                case Server.Property.type:
                    break;
                case Server.Property.profile:
                    break;
                case Server.Property.state:
                    break;
                case Server.Property.users:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        gameObserver.dirty = true;
                        gameObserver.needRefresh = true;
                    }
                    break;
                case Server.Property.globalChat:
                    break;
                case Server.Property.friendWorld:
                    break;
                case Server.Property.guilds:
                    break;
                default:
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is User)
            {
                switch ((User.Property)wrapProperty.n)
                {
                    case User.Property.human:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            gameObserver.dirty = true;
                            gameObserver.needRefresh = true;
                        }
                        break;
                    case User.Property.role:
                        break;
                    case User.Property.ipAddress:
                        break;
                    case User.Property.registerTime:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is Human)
                {
                    switch ((Human.Property)wrapProperty.n)
                    {
                        case Human.Property.playerId:
                            break;
                        case Human.Property.account:
                            break;
                        case Human.Property.state:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                gameObserver.dirty = true;
                                gameObserver.needRefresh = true;
                            }
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
                // Child
                if (wrapProperty.p is UserState)
                {
                    switch ((UserState.Property)wrapProperty.n)
                    {
                        case UserState.Property.state:
                            {
                                gameObserver.dirty = true;
                                gameObserver.needRefresh = true;
                            }
                            break;
                        case UserState.Property.hide:
                            break;
                        case UserState.Property.time:
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

    #region Global

    public override void refreshObserverConnections()
    {
        gameObserver.allConnections.Clear();
        if (this.data != null)
        {
            for (int i = this.data.users.vs.Count - 1; i >= 0; i--)
            {
                User user = this.data.users.vs[i];
                if (user.human.v.connection.v != null)
                {
                    gameObserver.allConnections.Add(user.human.v.connection.v);
                }
                else
                {
                    // Debug.Log ("connect null: " + user + "; " + this);
                }
            }
            // Debug.LogError ("getAllObserverConnection: getAllObserverConnection: " + ret.Count + "; " + this + "; " + this.gameObject);
        }
        else
        {
            Debug.LogError("server null: " + this);
        }
    }

    public override void onChangeParentObservers(Dictionary<int, NetworkConnection>.ValueCollection parentObserver)
    {
        gameObserver.dirty = true;
        gameObserver.needRefresh = true;
    }

    #endregion

}