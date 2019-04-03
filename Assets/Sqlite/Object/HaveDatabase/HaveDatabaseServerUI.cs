using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class HaveDatabaseServerUI : UIBehavior<HaveDatabaseServerUI.UIData>
{

    #region UIData

    public class UIData : SqliteServerUI.UIData.Sub
    {

        #region Sub

        public abstract class Sub : Data
        {

            public enum Type
            {
                None,
                Load,
                Update,
                Fail
            }

            public abstract Type getType();

            public abstract bool processEvent(Event e);

            public abstract MainUI.UIData.AllowShowBanner getAllowShowBanner();

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            sub
        }

        public UIData() : base()
        {
            this.sub = new VP<Sub>(this, (byte)Property.sub, new HaveDatabaseServerNoneUI.UIData());
        }

        #endregion

        public override Type getType()
        {
            return Type.HaveDatabase;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // sub
                if (!isProcess)
                {
                    Sub sub = this.sub.v;
                    if (sub != null)
                    {
                        isProcess = sub.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("sub null: " + this);
                    }
                }
            }
            return isProcess;
        }

        public override MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            MainUI.UIData.AllowShowBanner ret = MainUI.UIData.AllowShowBanner.ForceShow;
            {
                Sub sub = this.sub.v;
                if (sub != null)
                {
                    ret = sub.getAllowShowBanner();
                }
                else
                {
                    Debug.LogError("sub null");
                }
            }
            return ret;
        }

    }

    #endregion

    #region txt

    public Text lbPort;
    private static readonly TxtLanguage txtPort = new TxtLanguage();

    public Text lbMaxClientUserCount;
    private static readonly TxtLanguage txtMaxClientUserCount = new TxtLanguage();

    static HaveDatabaseServerUI()
    {
        txtPort.add(Language.Type.vi, "Cổng");
        txtMaxClientUserCount.add(Language.Type.vi, "Số người dùng");
    }

    #endregion

    #region Refresh

    public GameObject portContainer;
    public InputField edtPort;

    public GameObject maxClientUserCountContainer;
    public InputField edtMaxClientUserCount;

    private bool firstInit = false;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                int showCount = 0;
                // firstInit
                if (firstInit)
                {
                    firstInit = false;
                    if (edtMaxClientUserCount != null)
                    {
                        Server.Type serverType = Server.Type.Offline;
                        {
                            SqliteServerUI.UIData sqliteServerUIData = this.data.findDataInParent<SqliteServerUI.UIData>();
                            if (sqliteServerUIData != null)
                            {
                                serverType = sqliteServerUIData.serverType;
                            }
                            else
                            {
                                Debug.LogError("sqliteServerUIData null: " + this);
                            }
                        }
                        switch (serverType)
                        {
                            case Server.Type.Server:
#pragma warning disable CS0618 // Type or member is obsolete
                                edtMaxClientUserCount.text = "" + LLAPITransport.DefaultServerMaxConnections;
#pragma warning restore CS0618 // Type or member is obsolete
                                break;
                            case Server.Type.Client:
                            case Server.Type.Host:
                            case Server.Type.Offline:
#pragma warning disable CS0618 // Type or member is obsolete
                                edtMaxClientUserCount.text = "" + LLAPITransport.DefaultMaxConnections;
#pragma warning restore CS0618 // Type or member is obsolete
                                break;
                            default:
                                Debug.LogError("unknown serverType: " + serverType);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("edtMaxClientUserCount null");
                    }
                }
                // port
                if (edtPort != null && portContainer != null)
                {
                    // get serverType
                    Server.Type serverType = Server.Type.Offline;
                    {
                        SqliteServerUI.UIData sqliteServerUIData = this.data.findDataInParent<SqliteServerUI.UIData>();
                        if (sqliteServerUIData != null)
                        {
                            serverType = sqliteServerUIData.serverType;
                        }
                        else
                        {
                            Debug.LogError("sqliteServerUIData null: " + this);
                        }
                    }
                    // set
                    switch (serverType)
                    {
                        case Server.Type.Host:
                            {
                                // setActive
                                {
                                    switch (this.data.sub.v.getType())
                                    {
                                        case UIData.Sub.Type.None:
                                            portContainer.SetActive(true);
                                            break;
                                        case UIData.Sub.Type.Load:
                                        case UIData.Sub.Type.Fail:
                                        case UIData.Sub.Type.Update:
                                            portContainer.SetActive(false);
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + this.data.sub.v.getType());
                                            break;
                                    }
                                }
                                // enable
                                {
                                    if (this.data.sub.v.getType() == UIData.Sub.Type.None)
                                    {
                                        edtPort.interactable = true;
                                    }
                                    else
                                    {
                                        edtPort.interactable = false;
                                    }
                                }
                            }
                            break;
                        case Server.Type.Offline:
                        case Server.Type.Server:
                        case Server.Type.Client:
                            {
                                portContainer.SetActive(false);
                            }
                            break;
                        default:
                            Debug.LogError("unknown server type: " + serverType + "; " + this);
                            break;
                    }
                    if (portContainer.activeSelf)
                    {
                        showCount++;
                    }
                }
                else
                {
                    Debug.LogError("edtPort null: " + this);
                }
                // maxClientUserCount
                if (edtMaxClientUserCount != null && maxClientUserCountContainer != null)
                {
                    // get serverType
                    Server.Type serverType = Server.Type.Offline;
                    {
                        SqliteServerUI.UIData sqliteServerUIData = this.data.findDataInParent<SqliteServerUI.UIData>();
                        if (sqliteServerUIData != null)
                        {
                            serverType = sqliteServerUIData.serverType;
                        }
                        else
                        {
                            Debug.LogError("sqliteServerUIData null: " + this);
                        }
                    }
                    // set
                    switch (serverType)
                    {
                        case Server.Type.Server:
                        case Server.Type.Host:
                            {
                                // setActive
                                {
                                    switch (this.data.sub.v.getType())
                                    {
                                        case UIData.Sub.Type.None:
                                            maxClientUserCountContainer.SetActive(true);
                                            break;
                                        case UIData.Sub.Type.Load:
                                        case UIData.Sub.Type.Fail:
                                        case UIData.Sub.Type.Update:
                                            maxClientUserCountContainer.SetActive(false);
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + this.data.sub.v.getType());
                                            break;
                                    }
                                }
                                // enable
                                {
                                    if (this.data.sub.v.getType() == UIData.Sub.Type.None)
                                    {
                                        edtMaxClientUserCount.interactable = true;
                                    }
                                    else
                                    {
                                        edtMaxClientUserCount.interactable = false;
                                    }
                                }
                            }
                            break;
                        case Server.Type.Offline:
                        case Server.Type.Client:
                            {
                                maxClientUserCountContainer.SetActive(false);
                            }
                            break;
                        default:
                            Debug.LogError("unknown server type: " + serverType + "; " + this);
                            break;
                    }
                    if (maxClientUserCountContainer.activeSelf)
                    {
                        showCount++;
                    }
                }
                else
                {
                    Debug.LogError("edtMaxClientUserCount null: " + this);
                }
                // drSub
                {
                    // find
                    Dropdown drSubType = null;
                    {
                        SqliteServerUI.UIData sqliteServerUIData = this.data.findDataInParent<SqliteServerUI.UIData>();
                        if (sqliteServerUIData != null)
                        {
                            SqliteServerUI sqliteServerUI = sqliteServerUIData.findCallBack<SqliteServerUI>();
                            if (sqliteServerUI != null)
                            {
                                drSubType = sqliteServerUI.drSubType;
                            }
                            else
                            {
                                Debug.LogError("sqliteServerUI null");
                            }
                        }
                        else
                        {
                            Debug.LogError("sqliteServerUIData null");
                        }
                    }
                    // process
                    if (drSubType != null)
                    {
                        switch (showCount)
                        {
                            case 0:
                                {
                                    UIRectTransform.SetCenterPosY((RectTransform)drSubType.transform, -50);
                                }
                                break;
                            case 1:
                                {
                                    UIRectTransform.SetCenterPosY((RectTransform)drSubType.transform, -100);
                                }
                                break;
                            case 2:
                            default:
                                {
                                    UIRectTransform.SetCenterPosY((RectTransform)drSubType.transform, -150);
                                }
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("drSubType null");
                    }
                }
                // set siblingIndex
                {
                    UIRectTransform.SetSiblingIndex(this.data.sub.v, 0);
                }
                // txt
                {
                    if (lbPort != null)
                    {
                        lbPort.text = txtPort.get("Port");
                    }
                    else
                    {
                        Debug.LogError("lbPort null");
                    }
                    if (lbMaxClientUserCount != null)
                    {
                        lbMaxClientUserCount.text = txtMaxClientUserCount.get("Max user count");
                    }
                    else
                    {
                        Debug.LogError("lbMaxClientUserCount null");
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

    public HaveDatabaseServerNoneUI nonePrefab;
    public HaveDatabaseServerLoadUI loadPrefab;
    public HaveDatabaseServerUpdateUI updatePrefab;
    public HaveDatabaseServerFailUI failPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.sub.allAddCallBack(this);
            }
            firstInit = true;
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
        if (data is UIData.Sub)
        {
            UIData.Sub sub = data as UIData.Sub;
            // UI
            {
                switch (sub.getType())
                {
                    case UIData.Sub.Type.None:
                        {
                            HaveDatabaseServerNoneUI.UIData noneUIData = sub as HaveDatabaseServerNoneUI.UIData;
                            UIUtils.Instantiate(noneUIData, nonePrefab, this.transform, UIConstants.FullParent);
                        }
                        break;
                    case UIData.Sub.Type.Load:
                        {
                            HaveDatabaseServerLoadUI.UIData loadUIData = sub as HaveDatabaseServerLoadUI.UIData;
                            UIUtils.Instantiate(loadUIData, loadPrefab, this.transform, UIConstants.FullParent);
                        }
                        break;
                    case UIData.Sub.Type.Update:
                        {
                            HaveDatabaseServerUpdateUI.UIData updateUIData = sub as HaveDatabaseServerUpdateUI.UIData;
                            UIUtils.Instantiate(updateUIData, updatePrefab, this.transform, UIConstants.FullParent);
                        }
                        break;
                    case UIData.Sub.Type.Fail:
                        {
                            HaveDatabaseServerFailUI.UIData failUIData = sub as HaveDatabaseServerFailUI.UIData;
                            UIUtils.Instantiate(failUIData, failPrefab, this.transform, UIConstants.FullParent);
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                        break;
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
            // Setting
            Setting.get().removeCallBack(this);
            // Child
            {
                uiData.sub.allRemoveCallBack(this);
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
        if (data is UIData.Sub)
        {
            UIData.Sub sub = data as UIData.Sub;
            // UI
            {
                switch (sub.getType())
                {
                    case UIData.Sub.Type.None:
                        {
                            HaveDatabaseServerNoneUI.UIData noneUIData = sub as HaveDatabaseServerNoneUI.UIData;
                            noneUIData.removeCallBackAndDestroy(typeof(HaveDatabaseServerNoneUI));
                        }
                        break;
                    case UIData.Sub.Type.Load:
                        {
                            HaveDatabaseServerLoadUI.UIData loadUIData = sub as HaveDatabaseServerLoadUI.UIData;
                            loadUIData.removeCallBackAndDestroy(typeof(HaveDatabaseServerLoadUI));
                        }
                        break;
                    case UIData.Sub.Type.Update:
                        {
                            HaveDatabaseServerUpdateUI.UIData updateUIData = sub as HaveDatabaseServerUpdateUI.UIData;
                            updateUIData.removeCallBackAndDestroy(typeof(HaveDatabaseServerUpdateUI));
                        }
                        break;
                    case UIData.Sub.Type.Fail:
                        {
                            HaveDatabaseServerFailUI.UIData failUIData = sub as HaveDatabaseServerFailUI.UIData;
                            failUIData.removeCallBackAndDestroy(typeof(HaveDatabaseServerFailUI));
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                        break;
                }
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
                case UIData.Property.sub:
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
        if (wrapProperty.p is UIData.Sub)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}