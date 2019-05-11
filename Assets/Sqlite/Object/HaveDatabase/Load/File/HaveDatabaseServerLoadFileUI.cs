using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;

public class HaveDatabaseServerLoadFileUI : UIBehavior<HaveDatabaseServerLoadFileUI.UIData>
{

    #region UIData

    public class UIData : HaveDatabaseServerLoadUI.UIData.State
    {

        public VP<string> filePath;

        #region Constructor

        public enum Property
        {
            filePath
        }

        public UIData() : base()
        {
            this.filePath = new VP<string>(this, (byte)Property.filePath, "");
        }

        #endregion

        public override Type getType()
        {
            return Type.File;
        }

    }

    #endregion

    #region txt

    public Text lbMessage;
    private static readonly TxtLanguage txtMessage = new TxtLanguage("Loading File...");

    static HaveDatabaseServerLoadFileUI()
    {
        txtMessage.add(Language.Type.vi, "Đang Tải File...");
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
                FileInfo fileInfo = new FileInfo(this.data.filePath.v);
                // check directory
                bool haveDirectory = false;
                {
                    DirectoryInfo dir = fileInfo.Directory;
                    if (dir != null && dir.Exists)
                    {
                        haveDirectory = true;
                    }
                    else
                    {
                        Debug.LogError("Don't have directory");
                    }
                }
                // process
                if (haveDirectory)
                {
                    // make sqliteConnection
                    SQLiteConnection connection = null;
                    {
                        // create file if not exist
                        if (!fileInfo.Exists)
                        {
                            Mono.Data.Sqlite.SqliteConnection.CreateFile(fileInfo.FullName);
                            connection = new SQLiteConnection(fileInfo.FullName, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
                            connection.CreateTable<SqliteObject>();
                        }
                        else
                        {
                            connection = new SQLiteConnection(fileInfo.FullName, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
                        }
                    }
                    // Chuyen sang load data
                    if (connection != null)
                    {
                        HaveDatabaseServerLoadUI.UIData loadUIData = this.data.findDataInParent<HaveDatabaseServerLoadUI.UIData>();
                        if (loadUIData != null)
                        {
                            HaveDatabaseServerLoadDataUI.UIData loadDataUIData = new HaveDatabaseServerLoadDataUI.UIData();
                            {
                                loadDataUIData.uid = loadUIData.state.makeId();
                                loadDataUIData.connection.v = connection;
                            }
                            loadUIData.state.v = loadDataUIData;
                        }
                        else
                        {
                            Debug.LogError("loadUIData null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("connect null: " + this);
                        HaveDatabaseServerFailUI.UIData.changeToFail(this.data);
                    }
                }
                else
                {
                    Debug.LogError("Don't have directory: " + this);
                    HaveDatabaseServerFailUI.UIData.changeToFail(this.data);
                }
                // txt
                {
                    if (lbMessage != null)
                    {
                        lbMessage.text = txtMessage.get();
                    }
                    else
                    {
                        Debug.LogError("lbMessage null");
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
        return false;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
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
                case UIData.Property.filePath:
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

}