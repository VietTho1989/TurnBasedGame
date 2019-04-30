using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;

public class HaveDatabaseServerUpdateUI : UIBehavior<HaveDatabaseServerUpdateUI.UIData>
{

    #region UIData

    public class UIData : HaveDatabaseServerUI.UIData.Sub
    {

        public VP<SQLiteConnection> sqliteConnection;

        public VP<ServerManager.UIData> serverManager;

        public VP<HaveSqliteServerUpdateUI.UIData> sqliteUpdate;

        #region Constructor

        public enum Property
        {
            sqliteConnection,
            serverManager,
            sqliteUpdate
        }

        public UIData() : base()
        {
            this.sqliteConnection = new VP<SQLiteConnection>(this, (byte)Property.sqliteConnection, null);
            this.serverManager = new VP<ServerManager.UIData>(this, (byte)Property.serverManager, null);
            this.sqliteUpdate = new VP<HaveSqliteServerUpdateUI.UIData>(this, (byte)Property.sqliteUpdate, new HaveSqliteServerUpdateUI.UIData());
        }

        #endregion

        public override Type getType()
        {
            return Type.Update;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // serverManager
                if (!isProcess)
                {
                    ServerManager.UIData serverManager = this.serverManager.v;
                    if (serverManager != null)
                    {
                        isProcess = serverManager.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("severManager null: " + this);
                    }
                }
            }
            return isProcess;
        }

        public override MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            MainUI.UIData.AllowShowBanner ret = MainUI.UIData.AllowShowBanner.ForceShow;
            {
                ServerManager.UIData serverManager = this.serverManager.v;
                if (serverManager != null)
                {
                    ret = serverManager.getAllowShowBanner();
                }
                else
                {
                    Debug.LogError("serverManager null");
                }
            }
            return ret;
        }

    }

    #endregion

    #region Refresh

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // sqliteUpdate
                {
                    HaveSqliteServerUpdateUI.UIData sqliteUpdate = this.data.sqliteUpdate.v;
                    if (sqliteUpdate != null)
                    {
                        sqliteUpdate.connection.v = this.data.sqliteConnection.v;
                        // server
                        {
                            Server server = null;
                            {
                                ServerManager.UIData serverManager = this.data.serverManager.v;
                                if (serverManager != null)
                                {
                                    server = serverManager.server.v.data;
                                }
                                else
                                {
                                    Debug.LogError("serverManager null: " + this);
                                }
                            }
                            sqliteUpdate.server.v = new ReferenceData<Server>(server);
                        }
                    }
                    else
                    {
                        Debug.LogError("sqliteUpdate null: " + this);
                    }
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

    public ServerManager serverManagerPrefab;
    public Transform serverManagerContainer;

    public HaveSqliteServerUpdateUI sqliteUpdatePrefab;
    public Transform sqliteUpdateContainer;

    public HostNetworkDiscovery hostNetworkDiscoveryPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.sqliteUpdate.allAddCallBack(this);
                uiData.serverManager.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is HaveSqliteServerUpdateUI.UIData)
            {
                HaveSqliteServerUpdateUI.UIData sqliteUpdate = data as HaveSqliteServerUpdateUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(sqliteUpdate, sqliteUpdatePrefab, sqliteUpdateContainer);
                }
                dirty = true;
                return;
            }
            // serverManagerUIData
            {
                if (data is ServerManager.UIData)
                {
                    ServerManager.UIData serverManagerUIData = data as ServerManager.UIData;
                    // reset
#pragma warning disable CS0618 // Type or member is obsolete
                    NetworkServer.Reset();
#pragma warning restore CS0618 // Type or member is obsolete
                    // UI
                    {
                        if (serverManagerPrefab != null)
                        {
                            ServerManager serverManager = Instantiate<ServerManager>(serverManagerPrefab, serverManagerContainer, false);
                            // Set Address
                            {
                                Server server = serverManagerUIData.server.v.data;
                                if (server != null)
                                {
                                    serverManager.networkAddress = server.serverConfig.v.address.v;
                                    serverManager.networkPort = (ushort)server.serverConfig.v.port.v;
                                }
                                else
                                {
                                    Debug.LogError("server null: " + this);
                                }
                            }
                            serverManager.setData(serverManagerUIData);
                        }
                        else
                        {
                            Debug.LogError("serverPrefab null: " + this);
                        }
                    }
                    // Child
                    {
                        serverManagerUIData.server.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Server)
                {
                    Server server = data as Server;
                    {
                        if (server.type.v == Server.Type.Host)
                        {
                            HostNetworkDiscovery old = server.findCallBack<HostNetworkDiscovery>();
                            if (old == null)
                            {
                                if (hostNetworkDiscoveryPrefab != null)
                                {
                                    HostNetworkDiscovery hostNetworkDiscovery = TrashMan.normalSpawn(hostNetworkDiscoveryPrefab, this.transform);
                                    hostNetworkDiscovery.setData(server);
                                }
                                else
                                {
                                    Debug.LogError("hostNetworkDiscoveryPrefab null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("already have: " + this);
                            }
                        }
                    }
                    dirty = true;
                    return;
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
                uiData.sqliteUpdate.allRemoveCallBack(this);
                uiData.serverManager.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is HaveSqliteServerUpdateUI.UIData)
            {
                HaveSqliteServerUpdateUI.UIData sqliteUpdate = data as HaveSqliteServerUpdateUI.UIData;
                // UI
                {
                    sqliteUpdate.removeCallBackAndDestroy(typeof(HaveSqliteServerUpdateUI));
                }
                return;
            }
            // serverManagerUIData
            {
                if (data is ServerManager.UIData)
                {
                    ServerManager.UIData serverManagerUIData = data as ServerManager.UIData;
                    // UI
                    {
                        serverManagerUIData.removeCallBackAndDestroy(typeof(ServerManager));
                    }
                    // Child
                    {
                        serverManagerUIData.server.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Server)
                {
                    Server server = data as Server;
                    // UI
                    {
                        server.removeCallBackAndDestroy(typeof(HostNetworkDiscovery));
                    }
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
        if (wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.sqliteConnection:
                    dirty = true;
                    break;
                case UIData.Property.serverManager:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.sqliteUpdate:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("Don't process: " + data + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is HaveSqliteServerUpdateUI.UIData)
            {
                return;
            }
            // serverManagerUIData
            {
                if (wrapProperty.p is ServerManager.UIData)
                {
                    switch ((ServerManager.UIData.Property)wrapProperty.n)
                    {
                        case ServerManager.UIData.Property.server:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ServerManager.UIData.Property.managerUI:
                            break;
                        default:
                            Debug.LogError("Don't process: " + data + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is Server)
                {
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}