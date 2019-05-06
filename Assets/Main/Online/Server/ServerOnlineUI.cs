using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ServerOnlineUI : UIBehavior<ServerOnlineUI.UIData>
{

    #region UIData

    public class UIData : PlayOnlineUI.UIData.Sub, ServerManager.UIData.OnClick
    {

        public VP<SqliteServerUI.UIData> sqliteServerUIData;

        #region Constructor

        public enum Property
        {
            sqliteServerUIData
        }

        public UIData() : base()
        {
            // sqliteServerUIData
            {
                this.sqliteServerUIData = new VP<SqliteServerUI.UIData>(this, (byte)Property.sqliteServerUIData, new SqliteServerUI.UIData());
                this.sqliteServerUIData.v.serverType = Server.Type.Server;
            }
        }

        #endregion

        public override PlayOnlineUI.UIData.Sub.Type getType()
        {
            return PlayOnlineUI.UIData.Sub.Type.Server;
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
                Debug.LogError("playOnlineuIData null: " + this);
            }
        }

        #endregion

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // sqliteServerUIData
                if (!isProcess)
                {
                    SqliteServerUI.UIData sqliteServerUIData = this.sqliteServerUIData.v;
                    if (sqliteServerUIData != null)
                    {
                        isProcess = sqliteServerUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("sqliteServerUIData null: " + this);
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
                        ServerOnlineUI serverOnlineUI = this.findCallBack<ServerOnlineUI>();
                        if (serverOnlineUI != null)
                        {
                            isProcess = serverOnlineUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("serverOnlineUI null: " + this);
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
                SqliteServerUI.UIData sqliteServerUIData = this.sqliteServerUIData.v;
                if (sqliteServerUIData != null)
                {
                    ret = sqliteServerUIData.getAllowShowBanner();
                }
                else
                {
                    Debug.LogError("sqliteServerUIData null");
                }
            }
            return ret;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Server");

    static ServerOnlineUI()
    {
        txtTitle.add(Language.Type.vi, "Mạng Chủ");
    }

    #endregion

    #region Refresh

    public GameObject contentContainer;

    public Button btnBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // contentContainer
                {
                    if (contentContainer != null)
                    {
                        bool show = false;
                        {
                            SqliteServerUI.UIData sqliteServerUIData = this.data.sqliteServerUIData.v;
                            if (sqliteServerUIData != null)
                            {
                                show = sqliteServerUIData.isShowOther();
                            }
                            else
                            {
                                Debug.LogError("sqliteServerUIData null: " + this);
                            }
                        }
                        contentContainer.SetActive(show);
                    }
                    else
                    {
                        Debug.LogError("contentContainer null: " + this);
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
                        Debug.LogError("lbTitle null: " + this);
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

    public SqliteServerUI sqliteServerPrefab;
    public Transform sqliteServerContainer;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.sqliteServerUIData.allAddCallBack(this);
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
            if (data is SqliteServerUI.UIData)
            {
                SqliteServerUI.UIData sqliteServerUIData = data as SqliteServerUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(sqliteServerUIData, sqliteServerPrefab, sqliteServerContainer);
                }
                // Child
                {
                    sqliteServerUIData.sub.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is SqliteServerUI.UIData.Sub)
            {
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
                uiData.sqliteServerUIData.allRemoveCallBack(this);
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
            if (data is SqliteServerUI.UIData)
            {
                SqliteServerUI.UIData sqliteServerUIData = data as SqliteServerUI.UIData;
                // UI
                {
                    sqliteServerUIData.removeCallBackAndDestroy(typeof(SqliteServerUI));
                }
                // Child
                {
                    sqliteServerUIData.sub.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            if (data is SqliteServerUI.UIData.Sub)
            {
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
                case UIData.Property.sqliteServerUIData:
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
        {
            if (wrapProperty.p is SqliteServerUI.UIData)
            {
                switch ((SqliteServerUI.UIData.Property)wrapProperty.n)
                {
                    case SqliteServerUI.UIData.Property.sub:
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
            if (wrapProperty.p is SqliteServerUI.UIData.Sub)
            {
                SqliteServerUI.UIData.Sub sub = wrapProperty.p as SqliteServerUI.UIData.Sub;
                switch (sub.getType())
                {
                    case SqliteServerUI.UIData.Sub.Type.NoDatabase:
                        {
                            switch ((NoDatabaseServerUI.UIData.Property)wrapProperty.n)
                            {
                                case NoDatabaseServerUI.UIData.Property.sub:
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        break;
                    case SqliteServerUI.UIData.Sub.Type.HaveDatabase:
                        {
                            switch ((HaveDatabaseServerUI.UIData.Property)wrapProperty.n)
                            {
                                case HaveDatabaseServerUI.UIData.Property.sub:
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnBack, onClickBtnBack);
        }
    }

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.Backspace:
                    case KeyCode.Escape:
                        {
                            if (btnBack != null && btnBack.gameObject.activeInHierarchy && btnBack.interactable)
                            {
                                this.onClickBtnBack();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
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
            this.data.onClickReturn();
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}