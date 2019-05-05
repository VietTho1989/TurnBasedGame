using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuOnlineUI : UIBehavior<MenuOnlineUI.UIData>
{

    #region UIData

    public class UIData : PlayOnlineUI.UIData.Sub
    {

        #region Constructor

        public enum Property
        {

        }

        public UIData() : base()
        {

        }

        #endregion


        public override PlayOnlineUI.UIData.Sub.Type getType()
        {
            return PlayOnlineUI.UIData.Sub.Type.Menu;
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
                        MenuOnlineUI menuOnlineUI = this.findCallBack<MenuOnlineUI>();
                        if (menuOnlineUI != null)
                        {
                            menuOnlineUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("menuOnlineUI null: " + this);
                        }
                        isProcess = true;
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        MenuOnlineUI menuOnlineUI = this.findCallBack<MenuOnlineUI>();
                        if (menuOnlineUI != null)
                        {
                            isProcess = menuOnlineUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("menuOnlineUI null: " + this);
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
    public static readonly TxtLanguage txtTitle = new TxtLanguage("Play Online");

    public Text tvServer;
    public static readonly TxtLanguage txtServer = new TxtLanguage("Server");

    public Text tvClient;
    public static readonly TxtLanguage txtClient = new TxtLanguage("Client");

    static MenuOnlineUI()
    {
        txtTitle.add(Language.Type.vi, "Chơi Online");
        txtServer.add(Language.Type.vi, "Máy Chủ");
        txtClient.add(Language.Type.vi, "Máy Khách");
    }

    #endregion

    #region Refresh

    public Button btnBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
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
                        Debug.LogError("lbTitle null: " + this);
                    }
                    if (tvServer != null)
                    {
                        tvServer.text = txtServer.get();
                    }
                    else
                    {
                        Debug.LogError("tvServer null: " + this);
                    }
                    if (tvClient != null)
                    {
                        tvClient.text = txtClient.get();
                    }
                    else
                    {
                        Debug.LogError("tvClient null: " + this);
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

    public override void onAddCallBack<T>(T data)
    {
        if (data is MenuOnlineUI.UIData)
        {
            // Setting
            Setting.get().addCallBack(this);
            dirty = true;
            return;
        }
        // Setting
        if (data is Setting)
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
            // Child
            {

            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
    }

    #endregion

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnServer()
    {
        if (this.data != null)
        {
            PlayOnlineUI.UIData playOnlineUIData = this.data.findDataInParent<PlayOnlineUI.UIData>();
            if (playOnlineUIData != null)
            {
                ServerOnlineUI.UIData serverOnlineUIData = new ServerOnlineUI.UIData();
                {
                    serverOnlineUIData.uid = playOnlineUIData.sub.makeId();
                }
                playOnlineUIData.sub.v = serverOnlineUIData;
            }
            else
            {
                Debug.LogError("playOnlineUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnClient()
    {
        if (this.data != null)
        {
            PlayOnlineUI.UIData playOnlineUIData = this.data.findDataInParent<PlayOnlineUI.UIData>();
            if (playOnlineUIData != null)
            {
                OnlineClientUI.UIData onlineClientUIData = new OnlineClientUI.UIData();
                {
                    onlineClientUIData.uid = playOnlineUIData.sub.makeId();
                }
                playOnlineUIData.sub.v = onlineClientUIData;
            }
            else
            {
                Debug.LogError("playOnlineUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData>();
            if (mainUIData != null)
            {
                HomeUI.UIData homeUIData = new HomeUI.UIData();
                {
                    homeUIData.uid = mainUIData.sub.makeId();
                }
                mainUIData.sub.v = homeUIData;
            }
            else
            {
                Debug.LogError("mainUIData null");
            }
        }
        else
        {
            Debug.LogError("uiData null");
        }
    }

}