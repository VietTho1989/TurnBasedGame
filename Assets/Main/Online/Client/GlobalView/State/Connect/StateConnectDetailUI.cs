using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

#pragma warning disable CS0618

public class StateConnectDetailUI : UIBehavior<StateConnectDetailUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Server.State.Connect>> connect;

        #region Constructor

        public enum Property
        {
            connect
        }

        public UIData() : base()
        {
            this.connect = new VP<ReferenceData<Server.State.Connect>>(this, (byte)Property.connect, new ReferenceData<Server.State.Connect>(null));
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        StateConnectDetailUI stateConnectDetailUI = this.findCallBack<StateConnectDetailUI>();
                        if (stateConnectDetailUI != null)
                        {
                            stateConnectDetailUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("stateConnectDetailUI null");
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        StateConnectDetailUI stateConnectDetailUI = this.findCallBack<StateConnectDetailUI>();
                        if (stateConnectDetailUI != null)
                        {
                            isProcess = stateConnectDetailUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("stateConnectDetailUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTilte = new TxtLanguage("Server Connected");

    private static readonly TxtLanguage txtAddress = new TxtLanguage("Address");
    private static readonly TxtLanguage txtPort = new TxtLanguage("Port");

    static StateConnectDetailUI()
    {
        txtTilte.add(Language.Type.vi, "Server Đã Kết Nối");
        txtAddress.add(Language.Type.vi, "Địa chỉ");
        txtPort.add(Language.Type.vi, "Cổng");
    }

    #endregion

    #region Refresh

    public Text tvAddress;
    public Text tvPort;
    public Text tvPing;

    public override void LateUpdate()
    {
        base.LateUpdate();
        // port
        if (tvPort != null)
        {
            int port = Config.DefaultLANPort;
            {
                ServerManager serverManager = (ServerManager)NetworkManager.singleton;
                if (serverManager != null)
                {
                    port = serverManager.networkPort;
                }
                else
                {
                    Debug.LogError("serverManager null");
                }
            }
            tvPort.text = txtPort.get() + ": " + port;
        }
        else
        {
            Debug.LogError("tvPort null");
        }
        // ping
        if (tvPing != null)
        {
            float rtt = 0;
            {
                Server.State.Connect connect = this.data.connect.v.data;
                if (connect != null)
                {
                    Server server = connect.findDataInParent<Server>();
                    if (server != null)
                    {
                        if (server.type.v == Server.Type.Client)
                        {
                            if (NetworkClient.allClients.Count > 0)
                            {
                                rtt = NetworkClient.allClients[0].GetRTT() / 1000.0f;
                                // Debug.LogError("find rtt: " + NetworkClient.allClients[0].GetRTT());
                            }
                            else
                            {
                                // Debug.LogError("why don't have client");
                            }
                        }
                    }
                    else
                    {
                        // Debug.LogError("server null");
                    }
                }
                else
                {
                    Debug.LogError("connect null");
                }
            }
            tvPing.text = "Ping: " + rtt + "s";
        }
        else
        {
            Debug.LogError("tvPing null");
        }
    }

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Server.State.Connect connect = this.data.connect.v.data;
                if (connect != null)
                {
                    // title
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTilte.get();
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                    // port, address
                    {
                        // find server config
                        ServerConfig serverConfig = null;
                        {
                            Server server = connect.findDataInParent<Server>();
                            if (server != null)
                            {
                                serverConfig = server.serverConfig.v;
                            }
                            else
                            {
                                Debug.LogError("server null");
                            }
                        }
                        // process
                        if (serverConfig != null)
                        {
                            if (tvAddress != null)
                            {
                                tvAddress.text = txtAddress.get() + ": " + serverConfig.address.v;
                            }
                            else
                            {
                                Debug.LogError("tvAddress null");
                            }
                            if (tvPort != null)
                            {
                                tvPort.text = txtPort.get() + ": " + serverConfig.port.v;
                            }
                            else
                            {
                                Debug.LogError("tvPort null");
                            }
                        }
                        else
                        {
                            Debug.LogError("serverConfig null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("connect null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return false;
    }

    #endregion

    #region Task

    private Routine timeRoutine;

    public override void Awake()
    {
        base.Awake();
        startRoutine(ref this.timeRoutine, TaskUpdateRTT());
    }

    public override List<Routine> getRoutineList()
    {
        List<Routine> ret = new List<Routine>();
        {
            ret.Add(timeRoutine);
        }
        return ret;
    }

    public IEnumerator TaskUpdateRTT()
    {
        while (true)
        {
            yield return new Wait(0.2f);
            // ping
            if (tvPing != null)
            {
                float rtt = 0;
                {
                    // TODO Can hoan thien
                    // NetworkTime.rtt
                }
                tvPing.text = "Ping: " + rtt + "s";
            }
            else
            {
                Debug.LogError("tvPing null");
            }
        }
    }

    #endregion

    #region implement callBacks

    private Server server = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.connect.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        {
            if(data is Server.State.Connect)
            {
                Server.State.Connect connect = data as Server.State.Connect;
                // Parent
                {
                    DataUtils.addParentCallBack(connect, this, ref this.server);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if(data is Server)
                {
                    Server server = data as Server;
                    // Child
                    {
                        server.serverConfig.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is ServerConfig)
                {
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
            // Setting
            Setting.get().removeCallBack(this);
            // Child
            {
                uiData.connect.allRemoveCallBack(this);
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
            if (data is Server.State.Connect)
            {
                Server.State.Connect connect = data as Server.State.Connect;
                // Parent
                {
                    DataUtils.removeParentCallBack(connect, this, ref this.server);
                }
                return;
            }
            // Parent
            {
                if (data is Server)
                {
                    Server server = data as Server;
                    // Child
                    {
                        server.serverConfig.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is ServerConfig)
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
        if (wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.connect:
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
            if (wrapProperty.p is Server.State.Connect)
            {
                return;
            }
            // Parent
            {
                if (wrapProperty.p is Server)
                {
                    switch ((Server.Property)wrapProperty.n)
                    {
                        case Server.Property.serverConfig:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Server.Property.instanceId:
                            break;
                        case Server.Property.startState:
                            break;
                        case Server.Property.type:
                            break;
                        case Server.Property.profile:
                            break;
                        case Server.Property.state:
                            break;
                        case Server.Property.users:
                            break;
                        case Server.Property.disconnectTime:
                            break;
                        case Server.Property.roomManager:
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
                // Child
                if (wrapProperty.p is ServerConfig)
                {
                    switch ((ServerConfig.Property)wrapProperty.n)
                    {
                        case ServerConfig.Property.address:
                            dirty = true;
                            break;
                        case ServerConfig.Property.port:
                            dirty = true;
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

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            StateConnectUI.UIData stateConnectUIData = this.data.findDataInParent<StateConnectUI.UIData>();
            if (stateConnectUIData != null)
            {
                stateConnectUIData.detail.v = null;
            }
            else
            {
                Debug.LogError("stateConnectUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}