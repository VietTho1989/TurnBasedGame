using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class ClientConnectStateUpdate : UpdateBehavior<Server.State.Connect>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                switch (this.data.state.v)
                {
                    case Server.State.Connect.State.Normal:
                        break;
                    case Server.State.Connect.State.Logout:
                        {
                            User profileUser = Server.GetProfileUser(this.data);
                            if (profileUser != null)
                            {
                                profileUser.requestLogOut(profileUser.human.v.playerId.v);
                                this.data.state.v = Server.State.Connect.State.LoggingOut;
                            }
                            else
                            {
                                Debug.LogError("profileUser null: " + this);
                            }
                        }
                        break;
                    case Server.State.Connect.State.LoggingOut:
                        {
                            StartCoroutine(WaitForLogout());
                        }
                        break;
                    default:
                        Debug.LogError("unknown connect state: " + this.data.state.v);
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

    public IEnumerator WaitForLogout()
    {
        yield return new WaitForSeconds(15);
        if (this.data != null && this.data.state.v == Server.State.Connect.State.LoggingOut)
        {
            ServerManager clientManager = (ServerManager)NetworkManager.singleton;
            if (clientManager != null)
            {
                clientManager.logOut();
            }
            else
            {
                Debug.LogError("logOut: clientManager null");
            }
        }
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is Server.State.Connect)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is Server.State.Connect)
        {
            Server.State.Connect connect = data as Server.State.Connect;
            // Child
            {

            }
            this.setDataNull(connect);
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
        if (wrapProperty.p is Server.State.Connect)
        {
            switch ((Server.State.Connect.Property)wrapProperty.n)
            {
                case Server.State.Connect.Property.state:
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