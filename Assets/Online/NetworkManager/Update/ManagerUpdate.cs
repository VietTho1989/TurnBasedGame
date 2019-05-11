using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class ManagerUpdate : UpdateBehavior<Server>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // StartServer
                {
                    switch (this.data.startState.v)
                    {
                        case Server.StartState.Begin:
                            {
                                if (this.data.type.v == Server.Type.Offline)
                                {
                                    this.data.startState.v = Server.StartState.Success;
                                }
                                else
                                {
                                    this.data.startState.v = Server.StartState.Start;
                                }
                            }
                            break;
                        case Server.StartState.Start:
                            {
                                switch (this.data.type.v)
                                {
                                    case Server.Type.Server:
                                        {
                                            ServerManager serverManager = (ServerManager)NetworkManager.singleton;
                                            if (serverManager != null)
                                            {
                                                if (serverManager.StartServer())
                                                {
                                                    this.data.startState.v = Server.StartState.Success;
                                                }
                                                else
                                                {
                                                    Debug.LogError("start server fail: " + this);
                                                    this.data.startState.v = Server.StartState.Fail;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("Server manager null: " + this);
                                            }
                                        }
                                        break;
                                    case Server.Type.Host:
                                        {
                                            ServerManager serverManager = (ServerManager)NetworkManager.singleton;
                                            if (serverManager != null)
                                            {
                                                // Start
                                                if (serverManager.StartHost() != null)
                                                {
                                                    this.data.startState.v = Server.StartState.Success;
                                                }
                                                else
                                                {
                                                    Debug.LogError("start host fail: " + this);
                                                    this.data.startState.v = Server.StartState.Fail;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("Server manager null: " + this);
                                            }
                                        }
                                        break;
                                    case Server.Type.Client:
                                        {
                                            ServerManager clientManager = (ServerManager)NetworkManager.singleton;
                                            if (clientManager != null)
                                            {
                                                if (clientManager.myStartClient() != null)
                                                {
                                                    this.data.startState.v = Server.StartState.Success;
                                                }
                                                else
                                                {
                                                    Debug.LogError("Why cannot start client: " + this);
                                                    this.data.startState.v = Server.StartState.Fail;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("clientManager null: " + this);
                                            }
                                        }
                                        break;
                                    case Server.Type.Offline:
                                        {
                                            Debug.LogError("why offline here: " + this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown server type: " + this.data.type.v);
                                        break;
                                }
                            }
                            break;
                        case Server.StartState.Starting:
                            break;
                        case Server.StartState.Success:
                            break;
                        case Server.StartState.Fail:
                            break;
                        default:
                            Debug.LogError("unknown startState: " + this.data.startState.v + "; " + this);
                            break;
                    }
                }

                // Profile
                {
                    bool needCreateProfile = false;
                    {
                        if (this.data.startState.v == Server.StartState.Success)
                        {
                            if (this.data.type.v == Server.Type.Host || this.data.type.v == Server.Type.Server
                                || this.data.type.v == Server.Type.Offline)
                            {
                                needCreateProfile = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("startState not success: " + this.data.startState.v);
                        }
                    }
                    // Tao profile cho admin
                    if (needCreateProfile)
                    {
                        // Debug.LogError ("needCretateProfile: " + this);
                        // Find admin
                        User admin = null;
                        {
                            // find old admin
                            for (int i = 0; i < this.data.users.vs.Count; i++)
                            {
                                User checkAdmin = this.data.users.vs[i];
                                if (checkAdmin.role.v == User.Role.Admin)
                                {
                                    admin = checkAdmin;
                                    break;
                                }
                            }
                            // make new
                            if (admin == null)
                            {
                                admin = new User();
                                {
                                    // uid
                                    if (this.data.users.vs.Count == 0 && this.data.users.i == 0)
                                    {
                                        admin.uid = 0;
                                    }
                                    else
                                    {
                                        admin.uid = this.data.users.makeId();
                                    }
                                    admin.human.v.playerId.v = admin.uid;
                                }
                                this.data.users.add(admin);

                                // TODO Test add users
                                /*{
                                    for (int i = 0; i < 5000; i++)
                                    {
                                        User testUser = new User();
                                        {
                                            testUser.uid = this.data.users.makeId();
                                            testUser.human.v.playerId.v = (uint)(i + 1);
                                            // account
                                            {
                                                AccountDevice account = new AccountDevice();
                                                {
                                                    account.imei.v = "Device " + i;
                                                }
                                                testUser.human.v.account.v = account;
                                            }
                                        }
                                        this.data.users.add(testUser);
                                    }
                                }*/
                            }
                        }
                        // Update Property
                        {
                            {
                                AccountAdmin accountAdmin = new AccountAdmin();
                                {
                                    accountAdmin.uid = admin.human.v.account.makeId();
                                    accountAdmin.customName.v = "Admin";
                                }
                                admin.human.v.account.v = accountAdmin;
                            }
                            admin.role.v = User.Role.Admin;
                            // state
                            {
                                admin.human.v.state.v.state.v = UserState.State.Online;
                                // hide,
                                // time,
                                // timeZone
                            }
                            // password,
                            // email,
                            // phoneNumber,
                            // status,
                            // birthday,
                            // sex,
                            // avatarUrl,
                            // token,
                            // imei,
                            // registerTime,
                            // registerTimeZone,
                            // friends,
                            // ban,
                            // connection
                        }
                        this.data.profileId.v = admin.human.v.playerId.v;
                    }
                    else
                    {
                        // remove old admin
                        for (int i = this.data.users.vs.Count - 1; i >= 0; i--)
                        {
                            User checkAdmin = this.data.users.vs[i];
                            if (checkAdmin.role.v == User.Role.Admin)
                            {
                                this.data.users.remove(checkAdmin);
                            }
                        }
                    }
                }
                // Normal Update
                {
                    bool needNormalUpdate = false;
                    {
                        if (this.data.startState.v == Server.StartState.Success)
                        {
                            needNormalUpdate = true;
                        }
                        else
                        {
                            Debug.LogError("Don't need normalUpdate: " + this);
                        }
                    }
                    if (needNormalUpdate)
                    {
                        UpdateUtils.makeUpdate<NormalUpdate, Server>(this.data, this.transform);
                    }
                    else
                    {
                        this.data.removeCallBackAndDestroy(typeof(NormalUpdate));
                    }
                }
            }
            else
            {
                Debug.LogError("server null");
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
        if (data is Server)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is Server)
        {
            Server server = data as Server;
            // child callBacks
            {
                server.removeCallBackAndDestroy(typeof(NormalUpdate));
            }
            // set data null
            this.setDataNull(server);
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
        if (wrapProperty.p is Server)
        {
            switch ((Server.Property)wrapProperty.n)
            {
                case Server.Property.serverConfig:
                    break;
                case Server.Property.instanceId:
                    break;
                case Server.Property.gameTypes:
                    break;
                case Server.Property.startState:
                    dirty = true;
                    break;
                case Server.Property.type:
                    dirty = true;
                    break;
                case Server.Property.profile:
                    break;
                case Server.Property.state:
                    break;
                case Server.Property.users:
                    break;
                case Server.Property.disconnectTime:
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}