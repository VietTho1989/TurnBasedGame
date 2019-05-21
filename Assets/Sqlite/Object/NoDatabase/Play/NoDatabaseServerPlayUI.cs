using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class NoDatabaseServerPlayUI : UIBehavior<NoDatabaseServerPlayUI.UIData>
{

    #region UIData

    public class UIData : NoDatabaseServerUI.UIData.Sub
    {

        public VP<ServerManager.UIData> serverManager;

        #region Constructor

        public enum Property
        {
            serverManager
        }

        public UIData() : base()
        {
            this.serverManager = new VP<ServerManager.UIData>(this, (byte)Property.serverManager, null);
        }

        #endregion

        public override Type getType()
        {
            return Type.Play;
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

    public override int getStartAllocate()
    {
        return 1;
    }

    #region Refresh

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {

            }
            else
            {
                // Debug.LogError("data null: " + this);
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
    public HostNetworkDiscovery hostNetworkDiscoveryPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.serverManager.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if (data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
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
                        ServerManager serverManager = Instantiate<ServerManager>(serverManagerPrefab, this.transform, false);
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
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().removeCallBack(this);
            // Child
            {
                uiData.serverManager.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Child
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
                case UIData.Property.serverManager:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Setting
        if (wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    dirty = true;
                    break;
                case Setting.Property.style:
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
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
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}