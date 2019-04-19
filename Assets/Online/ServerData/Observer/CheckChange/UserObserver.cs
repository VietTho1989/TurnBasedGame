using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class UserObserver : GameObserver.CheckChange
{

    public UserObserver(GameObserver gameObserver) : base(gameObserver)
    {

    }

    #region setData

    private User data = null;

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
                this.data = newData as User;
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
        return Type.ClientConnect;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is User)
        {
            User user = data as User;
            // Child
            {
                user.human.allAddCallBack(this);
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
                    human.state.allAddCallBack(this);
                }
                return;
            }
            // Child
            if (data is UserState)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is User)
        {
            User user = data as User;
            // Child
            {
                user.human.allRemoveCallBack(this);
            }
            this.data = null;
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region Global

    public override void refreshObserverConnections()
    {
        gameObserver.allConnections.Clear();
        if (this.data != null)
        {
            Human human = this.data.human.v;
            if (human != null)
            {
                if (human.state.v != null && human.state.v.state.v == UserState.State.Online)
                {
                    if (human.connection.v != null)
                    {
                        gameObserver.allConnections.Add(human.connection.v);
                    }
                    else
                    {
                        // Debug.LogError ("connection null: " + this);
                    }
                }
            }
            else
            {
                Debug.LogError("human null: " + this);
            }
        }
        else
        {
            Debug.LogError("room null: " + this);
        }
    }

    public override void onChangeParentObservers(Dictionary<int, NetworkConnection>.ValueCollection parentObserver)
    {
        gameObserver.dirty = true;
        gameObserver.needRefresh = true;
    }

    #endregion

}