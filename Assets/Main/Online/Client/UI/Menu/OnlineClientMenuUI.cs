using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class OnlineClientMenuUI : UIBehavior<OnlineClientMenuUI.UIData>
{

    #region UIData

    public class UIData : OnlineClientUI.UIData.Sub
    {

        #region Constructor

        public enum Property
        {

        }

        public UIData() : base()
        {

        }

        #endregion

        public override Type getType()
        {
            return Type.Menu;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        OnlineClientMenuUI onlineClientMenuUI = this.findCallBack<OnlineClientMenuUI>();
                        if (onlineClientMenuUI != null)
                        {
                            onlineClientMenuUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("onlineClientMenuUI null");
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

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Client");

    #region ipAddress

    public Text lbIpAddress;
    private static readonly TxtLanguage txtIpAddress = new TxtLanguage("IP address");

    public Text tvIpAddressPlaceHolder;
    private static readonly TxtLanguage txtIpAddressPlaceHolder = new TxtLanguage("Enter ip address of server...");

    #endregion

    #region port

    public Text lbPort;
    private static readonly TxtLanguage txtPort = new TxtLanguage("Port");

    public Text tvPortPlaceHolder;
    private static readonly TxtLanguage txtPortPlaceHolder = new TxtLanguage("Enter port of server...");

    #endregion

    public Text tvMessage;
    private static readonly TxtLanguage txtMessage = new TxtLanguage("Server not very stable, so we will sometime have to clear server completely");

    public Text tvStart;
    private static readonly TxtLanguage txtStart = new TxtLanguage("Start");

    static OnlineClientMenuUI()
    {
        txtTitle.add(Language.Type.vi, "Mạng Khách");
        // ipAddress
        {
            txtIpAddress.add(Language.Type.vi, "Địa chỉ ip");
            txtIpAddressPlaceHolder.add(Language.Type.vi, "Điền địa chỉ ip của máy chủ...");
        }
        // port
        {
            txtPort.add(Language.Type.vi, "Cổng");
            txtPortPlaceHolder.add(Language.Type.vi, "Điền cổng của máy chủ...");
        }
        txtMessage.add(Language.Type.vi, "Server chưa thật sự ổn đinh, thỉnh thoảng chúng tôi sẽ xoá toàn bộ server");
        txtStart.add(Language.Type.vi, "Bắt Đầu");
    }

    #endregion

    #region Refresh

    public InputField edtIpAddress;
    public InputField edtPort;

    private bool firstInit = false;

    public Button btnBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // firstInit
                {
                    if (firstInit)
                    {
                        firstInit = false;
                        // address
                        if (edtIpAddress != null)
                        {
                            edtIpAddress.text = Config.serverAddress;
                        }
                        else
                        {
                            Debug.LogError("edtIpAddress null");
                        }
                        // port
                        if (edtPort != null)
                        {
                            edtPort.text = "" + Config.serverPort;
                        }
                        else
                        {
                            Debug.LogError("edtPort null");
                        }
                    }
                }
                // UI
                {
                    UIRectTransform.SetButtonTopLeftTransform(btnBack);
                    UIRectTransform.SetTitleTransform(lbTitle);
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get();
                        Setting.get().setTitleTextSize(lbTitle);
                    }
                    else
                    {
                        Debug.LogError("lbTitle null");
                    }
                    // ipAddress
                    {
                        if (lbIpAddress != null)
                        {
                            lbIpAddress.text = txtIpAddress.get();
                        }
                        else
                        {
                            Debug.LogError("lbIpAddress null");
                        }
                        if (tvIpAddressPlaceHolder != null)
                        {
                            tvIpAddressPlaceHolder.text = txtIpAddressPlaceHolder.get();
                        }
                        else
                        {
                            Debug.LogError("tvIpAddressPlaceHolder null");
                        }
                    }
                    // port
                    {
                        if (lbPort != null)
                        {
                            lbPort.text = txtPort.get();
                        }
                        else
                        {
                            Debug.LogError("lbPort null");
                        }
                        if (tvPortPlaceHolder != null)
                        {
                            tvPortPlaceHolder.text = txtPortPlaceHolder.get();
                        }
                        else
                        {
                            Debug.LogError("tvPortPlaceHolder null");
                        }
                    }
                    if (tvMessage != null)
                    {
                        tvMessage.text = txtMessage.get();
                    }
                    else
                    {
                        Debug.LogError("tvMessage null");
                    }
                    if (tvStart != null)
                    {
                        tvStart.text = txtStart.get();
                    }
                    else
                    {
                        Debug.LogError("tvStart null");
                    }
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
        return true;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            // Setting
            Setting.get().addCallBack(this);
            firstInit = true;
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().removeCallBack(this);
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if(data is Setting)
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
        if(wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Setting
        if(wrapProperty.p is Setting)
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            PlayOnlineUI.UIData playOnlineUIData = this.data.findDataInParent<PlayOnlineUI.UIData>();
            if (playOnlineUIData != null)
            {
                MenuOnlineUI.UIData menuOnlineUIData = new MenuOnlineUI.UIData();
                {
                    menuOnlineUIData.uid = playOnlineUIData.sub.makeId();
                }
                playOnlineUIData.sub.v = menuOnlineUIData;
            }
            else
            {
                Debug.LogError("playOnlineUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    public void onClickBtnStart()
    {
        if (this.data != null)
        {
            OnlineClientUI.UIData onlineClientUIData = this.data.findDataInParent<OnlineClientUI.UIData>();
            if (onlineClientUIData != null)
            {
                OnlineClientPlayUI.UIData onlineClientPlayUIData = new OnlineClientPlayUI.UIData();
                {
                    onlineClientPlayUIData.uid = onlineClientUIData.sub.makeId();
                    // address
                    {
                        string address = Config.serverAddress;
                        {
                            if (edtIpAddress != null)
                            {
                                address = edtIpAddress.text;
                            }
                            else
                            {
                                Debug.LogError("edtIpAddress null");
                            }
                        }
                        onlineClientPlayUIData.serverManager.v.server.v.data.serverConfig.v.address.v = address;
                    }
                    // port
                    {
                        int port = Config.serverPort;
                        {
                            if (edtPort != null)
                            {
                                string strPort = edtPort.text;
                                if (!int.TryParse(strPort, out port))
                                {
                                    Debug.LogError("strPort error: " + strPort);
                                    port = Config.serverPort;
                                }
                            }
                            else
                            {
                                Debug.LogError("edtPort null");
                            }
                        }
                        onlineClientPlayUIData.serverManager.v.server.v.data.serverConfig.v.port.v = port;
                    }
                }
                onlineClientUIData.sub.v = onlineClientPlayUIData;
            }
            else
            {
                Debug.LogError("onlineClientUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}