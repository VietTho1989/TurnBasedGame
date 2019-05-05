using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LanClientMenuUI : UIBehavior<LanClientMenuUI.UIData>
{

    #region UIData

    public class UIData : LanClientUI.UIData.Sub
    {

        public VP<DiscoveredServers> discoveredServers;

        #region State

        public enum State
        {
            Start,
            Scanning
        }

        public VP<State> state;

        #endregion

        #region Constructor

        public enum Property
        {
            discoveredServers,
            state
        }

        public UIData() : base()
        {
            this.discoveredServers = new VP<DiscoveredServers>(this, (byte)Property.discoveredServers, null);
            this.state = new VP<State>(this, (byte)Property.state, State.Start);
        }

        #endregion

        public override LanClientUI.UIData.Sub.Type getType()
        {
            return LanClientUI.UIData.Sub.Type.Menu;
        }

        #region Join

        [UnityEngine.Scripting.Preserve]
        public void onClickJoin(DiscoveredServer discoveredServer)
        {
            // Debug.LogError ("onClickJoin: " + discoveredServer);
            if (discoveredServer != null)
            {
                if (discoveredServer.version.v == Global.VersionCode)
                {
                    LanClientUI.UIData lanClientUIData = this.findDataInParent<LanClientUI.UIData>();
                    if (lanClientUIData != null)
                    {
                        LanClientPlayUI.UIData newUIData = new LanClientPlayUI.UIData();
                        {
                            Server server = newUIData.serverManager.v.server.v.data;
                            if (server != null)
                            {
                                server.serverConfig.v.address.v = discoveredServer.ipAddress.v;
                                server.serverConfig.v.port.v = discoveredServer.port.v;
                            }
                            else
                            {
                                Debug.LogError("server null");
                            }
                        }
                        lanClientUIData.sub.v = newUIData;
                    }
                    else
                    {
                        Debug.LogError("Cannot find lanClientUIData");
                    }
                }
                else
                {
                    Debug.LogError("not correct version code: " + discoveredServer);
                }
            }
            else
            {
                Debug.LogError("discoveredServer null");
            }
        }

        #endregion

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        LanClientMenuUI lanClientMenuUI = this.findCallBack<LanClientMenuUI>();
                        if (lanClientMenuUI != null)
                        {
                            lanClientMenuUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("lanClientMenuUI null: " + this);
                        }
                        isProcess = true;
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        LanClientMenuUI lanClientMenuUI = this.findCallBack<LanClientMenuUI>();
                        if (lanClientMenuUI != null)
                        {
                            isProcess = lanClientMenuUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("lanClientMenuUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

        public override MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            return MainUI.UIData.AllowShowBanner.ForceShow;
        }

    }

    #endregion

    #region txt

    public Text tvState;
    private static readonly TxtLanguage txtStart = new TxtLanguage("Starting...");
    private static readonly TxtLanguage txtScan = new TxtLanguage("Scanning...");

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Choose LAN server");

    public Text tvNoLan;
    private static readonly TxtLanguage txtNoLan = new TxtLanguage("Don't have any LAN servers");

    static LanClientMenuUI()
    {
        // txt
        {
            txtStart.add(Language.Type.vi, "Đang bắt đầu");
            txtScan.add(Language.Type.vi, "Đang quét");
            txtTitle.add(Language.Type.vi, "Chọn Mạng LAN");
            txtNoLan.add(Language.Type.vi, "Không có server LAN nào cả");
        }
    }

    #endregion

    #region Refresh

    private float time = 0;
    private bool alreadyInit = false;

    public Button btnBack;
    public RectTransform discoveryServerListContainer;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // tvState
                if (tvState != null)
                {
                    switch (this.data.state.v)
                    {
                        case UIData.State.Start:
                            tvState.text = txtStart.get();
                            break;
                        case UIData.State.Scanning:
                            tvState.text = txtScan.get();
                            break;
                        default:
                            Debug.LogError("unknown state: " + this.data.state.v);
                            break;
                    }
                }
                else
                {
                    Debug.LogError("tvState null: " + this);
                }
                // lbTitle
                if (lbTitle != null)
                {
                    lbTitle.text = txtTitle.get();
                    Setting.get().setTitleTextSize(lbTitle);
                }
                else
                {
                    Debug.LogError("lbTitle null: " + this);
                }
                // tvNoLan
                if (tvNoLan != null)
                {
                    tvNoLan.text = txtNoLan.get();
                    bool haveAnyLan = false;
                    {
                        DiscoveredServers discoveredServers = this.data.discoveredServers.v;
                        if (discoveredServers != null)
                        {
                            haveAnyLan = discoveredServers.servers.vs.Count > 0;
                        }
                        else
                        {
                            Debug.LogError("disceveredServers null");
                        }
                    }
                    tvNoLan.gameObject.SetActive(!haveAnyLan);
                }
                else
                {
                    Debug.LogError("tvNoLan null");
                }
                // UI
                {
                    UIRectTransform.SetButtonTopLeftTransform(btnBack);
                    UIRectTransform.SetTitleTransform(lbTitle);
                    // discoveryServerListContainer
                    {
                        UIRectTransform rect = UIRectTransform.CreateFullRect(0, 0, Setting.get().getButtonSize(), 0);
                        rect.set(discoveryServerListContainer);
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
        if (!alreadyInit)
        {
            time += Time.fixedDeltaTime;
            if (time >= 1f)
            {
                alreadyInit = true;
                onClickBtnJoin();
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return false;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // DiscoveredServerListUI
            {
                DiscoveredServerListUI discoveredServerListUI = this.GetComponentInChildren<DiscoveredServerListUI>();
                if (discoveredServerListUI != null)
                {
                    // set data
                    {
                        ClientNetworkDiscovery clientNetworkDiscovery = this.GetComponentInChildren<ClientNetworkDiscovery>();
                        if (clientNetworkDiscovery != null)
                        {
                            discoveredServerListUI.setData(clientNetworkDiscovery.discoveredServers);
                        }
                        else
                        {
                            Debug.LogError("clientNetworkDiscovery null: " + this);
                        }
                    }
                }
                uiData.discoveredServers.v = discoveredServerListUI.data;
            }
            // Child
            {
                uiData.discoveredServers.allAddCallBack(this);
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
        if(data is DiscoveredServers)
        {
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
            // Setting
            Setting.get().removeCallBack(this);
            // DiscoveredServerListUI
            {
                DiscoveredServerListUI discoveredServerListUI = this.GetComponentInChildren<DiscoveredServerListUI>();
                if (discoveredServerListUI != null)
                {
                    // set data
                    {
                        ClientNetworkDiscovery clientNetworkDiscovery = this.GetComponentInChildren<ClientNetworkDiscovery>();
                        if (clientNetworkDiscovery != null)
                        {
                            discoveredServerListUI.setData(null);
                            clientNetworkDiscovery.StopBroadcast();
                        }
                        else
                        {
                            Debug.LogError("clientNetworkDiscovery null: " + this);
                        }
                    }
                }
            }
            // Child
            {
                uiData.discoveredServers.allRemoveCallBack(this);
            }
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Child
        if(data is DiscoveredServers)
        {
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
                case UIData.Property.discoveredServers:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.state:
                    dirty = true;
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
                case Setting.Property.contentTextSize:
                    dirty = true;
                    break;
                case Setting.Property.titleTextSize:
                    dirty = true;
                    break;
                case Setting.Property.labelTextSize:
                    dirty = true;
                    break;
                case Setting.Property.buttonSize:
                    dirty = true;
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
        if(wrapProperty.p is DiscoveredServers)
        {
            switch ((DiscoveredServers.Property)wrapProperty.n)
            {
                case DiscoveredServers.Property.servers:
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

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnJoin()
    {
        // Debug.LogError ("onClickBtnJoin");
        ClientNetworkDiscovery clientNetworkDiscovery = FindObjectOfType<ClientNetworkDiscovery>();
        if (clientNetworkDiscovery != null)
        {
            clientNetworkDiscovery.StartJoining();

            // change state
            if (this.data != null)
            {
                this.data.state.v = UIData.State.Scanning;
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
        else
        {
            // Debug.LogError ("clientNetworkDiscovery null");
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        // Debug.LogError ("onClickBtnBack");
        if (this.data != null)
        {
            LanUI.UIData lanUIData = this.data.findDataInParent<LanUI.UIData>();
            if (lanUIData != null)
            {
                if (lanUIData.sub.v.getType() != LanUI.UIData.Sub.Type.Menu)
                {
                    lanUIData.sub.v = new LanMenuUI.UIData();
                }
                else
                {
                    Debug.LogError("Why already menu");
                }
            }
            else
            {
                Debug.LogError("lanUIData null");
            }
        }
        else
        {
            Debug.LogError("uiData null");
        }
    }

}