using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class UserDisconnectUpdate : UpdateBehavior<User>
{

    #region update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // find user state
                UserState.State state = UserState.State.Online;
                {
                    Human human = this.data.human.v;
                    if (human != null)
                    {
                        UserState userState = human.state.v;
                        if (userState != null)
                        {
                            state = userState.state.v;
                        }
                        else
                        {
                            Debug.LogError("userState null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("human null: " + this);
                    }
                }
                // Process
                switch (state)
                {
                    case UserState.State.Online:
                    case UserState.State.Offline:
                        destroyRoutine(wait);
                        break;
                    case UserState.State.Disconnect:
                        {
                            if (Routine.IsNull(wait))
                            {
                                wait = CoroutineManager.StartCoroutine(TaskWait(), this.gameObject);
                            }
                            else
                            {
                                Debug.LogError("Why routine != null: " + this);
                            }
                        }
                        break;
                    default:
                        Debug.LogError("unknown state: " + state + "; " + this);
                        break;
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
        return false;
    }

    #endregion

    #region Task wait

    private Routine wait;

    public IEnumerator TaskWait()
    {
        if (this.data != null)
        {
            // Find time
            float time = Server.DefaultDisconnectTime;
            {
                Server server = this.data.findDataInParent<Server>();
                if (server != null)
                {
                    time = server.disconnectTime.v;
                }
                else
                {
                    Debug.LogError("server null: " + this);
                }
            }
            yield return new Wait(time);
            // Change state
            if (this.data != null)
            {
                Human human = this.data.human.v;
                if (human != null)
                {
                    UserState userState = human.state.v;
                    if (userState != null)
                    {
                        if (userState.state.v == UserState.State.Disconnect)
                        {
                            userState.state.v = UserState.State.Offline;
                        }
                        else
                        {
                            Debug.LogError("error, why userState not disconnect: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("userState null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("human null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
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

    public override void onAddCallBack<T>(T data)
    {
        if (data is User)
        {
            User user = data as User;
            // Child
            {
                user.human.allAddCallBack(this);
            }
            dirty = true;
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
                dirty = true;
                return;
            }
            // Child
            if (data is UserState)
            {
                dirty = true;
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
            this.setDataNull(user);
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
                        dirty = true;
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
                            dirty = true;
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
            if (wrapProperty.p is UserState)
            {
                switch ((UserState.Property)wrapProperty.n)
                {
                    case UserState.Property.state:
                        dirty = true;
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

}