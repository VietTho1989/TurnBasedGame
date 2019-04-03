using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OfflineUI : UIBehavior<OfflineUI.UIData>
{

    #region UIData

    public class UIData : MainUI.UIData.Sub, ServerManager.UIData.OnClick
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
                this.sqliteServerUIData.v.serverType = Server.Type.Offline;
            }
        }

        #endregion

        public override MainUI.UIData.Sub.Type getType()
        {
            return MainUI.UIData.Sub.Type.Offline;
        }

        #region implements ServerManager.UIData.OnClick

        public void onClickReturn()
        {
            MainUI.UIData mainUIData = this.findDataInParent<MainUI.UIData>();
            if (mainUIData != null)
            {
                HomeUI.UIData homeUIData = mainUIData.sub.newOrOld<HomeUI.UIData>();
                {

                }
                mainUIData.sub.v = homeUIData;
            }
            else
            {
                Debug.LogError("mainUIData null: " + this);
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
                        Debug.LogError("backEvent: " + this);
                        this.onClickReturn();
                        isProcess = true;
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

    #region Refresh

    public GameObject contentContainer;

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
            // Child
            {
                uiData.sqliteServerUIData.allAddCallBack(this);
            }
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
            // Child
            {
                uiData.sqliteServerUIData.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
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

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            this.data.onClickReturn();
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}