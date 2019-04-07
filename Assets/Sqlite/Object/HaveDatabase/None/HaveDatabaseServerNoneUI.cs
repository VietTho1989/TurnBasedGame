using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using FileSystem;

public class HaveDatabaseServerNoneUI : UIBehavior<HaveDatabaseServerNoneUI.UIData>
{

    #region UIData

    public class UIData : HaveDatabaseServerUI.UIData.Sub
    {

        public VP<ChooseDatabaseUI.UIData> chooseDatabaseUIData;

        #region Constructor

        public enum Property
        {
            chooseDatabaseUIData
        }

        public UIData() : base()
        {
            this.chooseDatabaseUIData = new VP<ChooseDatabaseUI.UIData>(this, (byte)Property.chooseDatabaseUIData, null);
        }

        #endregion

        public override Type getType()
        {
            return Type.None;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // chooseDatabaseUIData
                if (!isProcess)
                {
                    ChooseDatabaseUI.UIData chooseDatabaseUIData = this.chooseDatabaseUIData.v;
                    if (chooseDatabaseUIData != null)
                    {
                        isProcess = chooseDatabaseUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("chooseDatabaseUIData null: " + this);
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

    public Text tvChooseFile;
    private static readonly TxtLanguage txtChooseFile = new TxtLanguage("Choose");

    public Text tvLoad;
    private static readonly TxtLanguage txtLoad = new TxtLanguage("Load");

    static HaveDatabaseServerNoneUI()
    {
        txtChooseFile.add(Language.Type.vi, "Chọn");
        txtLoad.add(Language.Type.vi, "Tải");
    }

    #endregion

    #region Refresh

    public InputField edtFilePath;
    private bool firstInit = false;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // firstInit
                if (firstInit)
                {
                    if (edtFilePath != null)
                    {
                        // find server type
                        Server.Type serverType = Server.Type.Server;
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
                        // process
                        {
                            string databasePath = Application.persistentDataPath;
                            {
                                string databaseFolderPath = Path.Combine(Application.persistentDataPath, FileSystemBrowser.DatabaseFolder);
                                DirectoryInfo databaseFolderInfo = new DirectoryInfo(databaseFolderPath);
                                if (databaseFolderInfo.Exists)
                                {
                                    databasePath = databaseFolderPath;
                                }
                            }
                            switch (serverType)
                            {
                                case Server.Type.Server:
                                    edtFilePath.text = Path.Combine(databasePath, "Server.db");
                                    break;
                                case Server.Type.Client:
                                    edtFilePath.text = Path.Combine(databasePath, "Client.db");
                                    break;
                                case Server.Type.Host:
                                    edtFilePath.text = Path.Combine(databasePath, "Host.db");
                                    break;
                                case Server.Type.Offline:
                                    edtFilePath.text = Path.Combine(databasePath, "Offline.db");
                                    break;
                                default:
                                    Debug.LogError("unknown server type: " + serverType + "; " + this);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("edtFilePath null: " + this);
                    }
                }
                firstInit = false;
                // txt
                {
                    if (tvChooseFile != null)
                    {
                        tvChooseFile.text = txtChooseFile.get();
                    }
                    else
                    {
                        Debug.LogError("tvChooseFile null");
                    }
                    if (tvLoad != null)
                    {
                        tvLoad.text = txtLoad.get();
                    }
                    else
                    {
                        Debug.LogError("tvLoad null");
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

    public ChooseDatabaseUI chooseDatabasePrefab;
    public Transform chooseDatabaseContainer;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.chooseDatabaseUIData.allAddCallBack(this);
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
        if (data is ChooseDatabaseUI.UIData)
        {
            ChooseDatabaseUI.UIData chooseDatabaseUIData = data as ChooseDatabaseUI.UIData;
            // UI
            {
                UIUtils.Instantiate(chooseDatabaseUIData, chooseDatabasePrefab, chooseDatabaseContainer);
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
                uiData.chooseDatabaseUIData.allRemoveCallBack(this);
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
        if (data is ChooseDatabaseUI.UIData)
        {
            ChooseDatabaseUI.UIData chooseDatabaseUIData = data as ChooseDatabaseUI.UIData;
            // UI
            {
                chooseDatabaseUIData.removeCallBackAndDestroy(typeof(ChooseDatabaseUI));
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
                case UIData.Property.chooseDatabaseUIData:
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
        if (wrapProperty.p is ChooseDatabaseUI.UIData)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnChooseFile()
    {
        if (this.data != null)
        {
            ChooseDatabaseUI.UIData chooseDatabaseUIData = this.data.chooseDatabaseUIData.newOrOld<ChooseDatabaseUI.UIData>();
            {

            }
            this.data.chooseDatabaseUIData.v = chooseDatabaseUIData;
            // init value
            {
                // get fileInfo
                FileInfo fileInfo = null;
                {
                    if (edtFilePath != null)
                    {
                        string filePath = edtFilePath.text;
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            fileInfo = new FileInfo(filePath);
                        }
                        else
                        {
                            Debug.LogError("filePath null or empty: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("edtFilePath null: " + this);
                    }
                }
                // process
                {
                    // directory
                    {
                        if (fileInfo != null)
                        {
                            DirectoryInfo dir = fileInfo.Directory;
                            if (dir.Exists)
                            {
                                FileSystemBrowserUI.UIData fileSystemBrowserUIData = chooseDatabaseUIData.fileSystemBrowser.v;
                                if (fileSystemBrowserUIData != null)
                                {
                                    FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
                                    if (fileSystemBrowser != null)
                                    {
                                        fileSystemBrowser.changeCurrentDirectory(dir);
                                    }
                                    else
                                    {
                                        Debug.LogError("fileSystemBrowser null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("fileSystemBrowserUIData null: " + this);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("fileInfo null: " + this);
                        }
                    }
                    // fileName
                    {
                        string fileName = "";
                        {
                            if (fileInfo != null)
                            {
                                fileName = fileInfo.Name;
                            }
                            else
                            {
                                Debug.LogError("fileInfo null: " + this);
                            }
                        }
                        ChooseDatabaseUI chooseDatabaseUI = chooseDatabaseUIData.findCallBack<ChooseDatabaseUI>();
                        if (chooseDatabaseUI != null)
                        {
                            if (chooseDatabaseUI.edtName != null)
                            {
                                chooseDatabaseUI.edtName.text = fileName;
                            }
                            else
                            {
                                Debug.LogError("chooseDatabaseUI edtName null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("chooseDatabaseUI null: " + this);
                        }
                    }
                }
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public void onClickBtnLoad()
    {
        if (this.data != null)
        {
            if (edtFilePath != null)
            {
                string filePath = edtFilePath.text;
                if (!string.IsNullOrEmpty(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    DirectoryInfo dir = fileInfo.Directory;
                    if (dir != null && dir.Exists)
                    {
                        HaveDatabaseServerUI.UIData haveDatabaseServerUIData = this.data.findDataInParent<HaveDatabaseServerUI.UIData>();
                        if (haveDatabaseServerUIData != null)
                        {
                            HaveDatabaseServerLoadUI.UIData haveDatabaseServerLoadUIData = new HaveDatabaseServerLoadUI.UIData();
                            {
                                haveDatabaseServerLoadUIData.uid = haveDatabaseServerUIData.sub.makeId();
                                // state
                                {
                                    HaveDatabaseServerLoadFileUI.UIData loadFileUIData = new HaveDatabaseServerLoadFileUI.UIData();
                                    {
                                        loadFileUIData.filePath.v = filePath;
                                    }
                                    haveDatabaseServerLoadUIData.state.v = loadFileUIData;
                                }
                            }
                            haveDatabaseServerUIData.sub.v = haveDatabaseServerLoadUIData;
                        }
                        else
                        {
                            Debug.LogError("haveDatabaseServerUIData null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("dir null or not exist: " + this);
                    }
                }
                else
                {
                    Debug.LogError("filePath null: " + this);
                }
            }
            else
            {
                Debug.LogError("edtFilePath null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}