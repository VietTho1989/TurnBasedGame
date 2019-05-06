using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class OnlineClientPlayUI : UIBehavior<OnlineClientPlayUI.UIData>
{

    #region UIData

    public class UIData : OnlineClientUI.UIData.Sub, ServerManager.UIData.OnClick
    {

        public VP<ServerManager.UIData> serverManager;

        #region Constructor

        public enum Property
        {
            serverManager
        }

        public UIData() : base()
        {
            // server manager
            {
                ServerManager.UIData uiData = new ServerManager.UIData();
                {
                    Server server = new Server();
                    {
                        server.type.v = Server.Type.Client;
                        server.state.v = new Server.State.Offline();
                        server.startState.v = Server.StartState.Begin;
                        // config
                        {
                            server.serverConfig.v.address.v = Config.serverAddress;
                            server.serverConfig.v.port.v = Config.serverPort;
                        }
                    }
                    uiData.server.v = new ReferenceData<Server>(server);
                }
                this.serverManager = new VP<ServerManager.UIData>(this, (byte)Property.serverManager, uiData);
            }
        }

        #endregion

        public override Type getType()
        {
            return Type.Play;
        }

        #region implement ServerManager.UIData.OnClick

        [UnityEngine.Scripting.Preserve]
        public void onClickReturn()
        {
            PlayOnlineUI.UIData playOnlineUIData = this.findDataInParent<PlayOnlineUI.UIData>();
            if (playOnlineUIData != null)
            {
                MenuOnlineUI.UIData menuOnlineUIData = playOnlineUIData.sub.newOrOld<MenuOnlineUI.UIData>();
                {

                }
                playOnlineUIData.sub.v = menuOnlineUIData;
            }
            else
            {
                Debug.LogError("playOnlineUIData null: " + this);
            }
        }

        #endregion

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
                        Debug.LogError("serverManager null: " + this);
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        this.onClickReturn();
                        isProcess = true;
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        OnlineClientPlayUI onlineClientPlayUI = this.findCallBack<OnlineClientPlayUI>();
                        if (onlineClientPlayUI != null)
                        {
                            isProcess = onlineClientPlayUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("onlineClientPlayUI null: " + this);
                        }
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

            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public ServerManager serverPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.serverManager.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        if (data is ServerManager.UIData)
        {
            ServerManager.UIData subUIData = data as ServerManager.UIData;
            // reset
#pragma warning disable CS0618 // Type or member is obsolete
            NetworkServer.Reset();
#pragma warning restore CS0618 // Type or member is obsolete
            // UI
            {
                if (serverPrefab != null)
                {
                    ServerManager serverManager = Instantiate<ServerManager>(serverPrefab, this.transform, false);
                    // Set Address
                    {
                        Server server = subUIData.server.v.data;
                        if (server != null)
                        {
                            serverManager.networkAddress = server.serverConfig.v.address.v;
                            serverManager.networkPort = (ushort)server.serverConfig.v.port.v;
                        }
                        else
                        {
                            Debug.LogError("server null");
                        }
                    }
                    serverManager.setData(subUIData);
                }
                else
                {
                    Debug.LogError("serverPrefab null");
                }
            }
            dirty = true;
            return;
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
                uiData.serverManager.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        if (data is ServerManager.UIData)
        {
            ServerManager.UIData serverManagerUIData = data as ServerManager.UIData;
            // UI
            {
                serverManagerUIData.removeCallBackAndDestroy(typeof(ServerManager));
            }
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
        // Child
        if (wrapProperty.p is ServerManager.UIData)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

}