using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NormalUpdate : UpdateBehavior<Server>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // ServerUpdate
                {
                    // Check needServerUpdate
                    bool needServerUpdate = false;
                    {
                        switch (this.data.type.v)
                        {
                            case Server.Type.Server:
                            case Server.Type.Host:
                            case Server.Type.Offline:
                                needServerUpdate = true;
                                break;
                            case Server.Type.Client:
                                break;
                            default:
                                Debug.LogError("unknown server type: " + this.data.type.v + "; " + this);
                                break;
                        }
                    }
                    // Process
                    if (needServerUpdate)
                    {
                        UpdateUtils.makeUpdate<ServerUpdate, Server>(this.data, this.transform);
                    }
                    else
                    {
                        this.data.removeCallBackAndDestroy(typeof(ServerUpdate));
                    }
                }
                // ClientUpdate
                {
                    // Check need clientUpdate
                    bool needClientUpdate = false;
                    {
                        if (this.data.type.v == Server.Type.Client)
                        {
                            needClientUpdate = true;
                        }
                    }
                    // Process
                    if (needClientUpdate)
                    {
                        UpdateUtils.makeUpdate<ClientUpdate, Server>(this.data, this.transform);
                    }
                    else
                    {
                        this.data.removeCallBackAndDestroy(typeof(ClientUpdate));
                    }
                }
                // CreateDataIdentity
                {
                    // Check need 
                    bool need = false;
                    {
                        switch (this.data.type.v)
                        {
                            case Server.Type.Server:
                            case Server.Type.Host:
                                need = true;
                                break;
                            case Server.Type.Offline:
                                break;
                            case Server.Type.Client:
                                break;
                            default:
                                Debug.LogError("unknown server type: " + this.data.type.v + "; " + this);
                                break;
                        }
                    }
                    // Process
                    if (need)
                    {
                        UpdateUtils.makeUpdate<CreateDataIdentityUpdate, Server>(this.data, this.transform);
                    }
                    else
                    {
                        this.data.removeCallBackAndDestroy(typeof(CreateDataIdentityUpdate));
                    }
                }
            }
            else
            {
                Debug.LogError("server null: " + this);
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
            // Update
            {
                server.removeCallBackAndDestroy(typeof(ServerUpdate));
                server.removeCallBackAndDestroy(typeof(ClientUpdate));
                server.removeCallBackAndDestroy(typeof(CreateDataIdentityUpdate));
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