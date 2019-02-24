using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

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
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTilte = new TxtLanguage();

    private static readonly TxtLanguage txtAddress = new TxtLanguage();
    private static readonly TxtLanguage txtPort = new TxtLanguage();

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
                            lbTitle.text = txtTilte.get("Server Connected");
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
                                tvAddress.text = txtAddress.get("Address") + ": " + serverConfig.address.v;
                            }
                            else
                            {
                                Debug.LogError("tvAddress null");
                            }
                            if (tvPort != null)
                            {
                                tvPort.text = txtPort.get("Port") + ": " + serverConfig.port.v;
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
                    // ping
                    if (tvPing != null)
                    {
                        tvPing.text = "Ping: " + NetworkTime.rtt + "s";
                    }
                    else
                    {
                        Debug.LogError("tvPing null");
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

    void Awake()
    {
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
                tvPing.text = "Ping: " + NetworkTime.rtt + "s";
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