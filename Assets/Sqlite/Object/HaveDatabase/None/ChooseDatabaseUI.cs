using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using FileSystem;

public class ChooseDatabaseUI : UIBehavior<ChooseDatabaseUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<FileSystemBrowserUI.UIData> fileSystemBrowser;

        #region Constructor

        public enum Property
        {
            fileSystemBrowser
        }

        public UIData() : base()
        {
            // fileSystemBrowser
            {
                this.fileSystemBrowser = new VP<FileSystemBrowserUI.UIData>(this, (byte)Property.fileSystemBrowser, new FileSystemBrowserUI.UIData());
                this.fileSystemBrowser.v.fileSystemBrowser.v = new ReferenceData<FileSystemBrowser>(new FileSystemBrowser());
            }
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
                        ChooseDatabaseUI chooseDatabaseUI = this.findCallBack<ChooseDatabaseUI>();
                        if (chooseDatabaseUI != null)
                        {
                            chooseDatabaseUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("chooseDatabaseUI null: " + this);
                        }
                        isProcess = true;
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        ChooseDatabaseUI chooseDatabaseUI = this.findCallBack<ChooseDatabaseUI>();
                        if (chooseDatabaseUI != null)
                        {
                            isProcess = chooseDatabaseUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("chooseDatabaseUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region Refresh

    public InputField edtName;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {

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

    public FileSystemBrowserUI fileSystemBrowserPrefab;
    public Transform fileSystemBrowserContainer;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.fileSystemBrowser.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        if (data is FileSystemBrowserUI.UIData)
        {
            FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
            // UI
            {
                UIUtils.Instantiate(fileSystemBrowserUIData, fileSystemBrowserPrefab, fileSystemBrowserContainer);
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
            // Child
            {
                uiData.fileSystemBrowser.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        if (data is FileSystemBrowserUI.UIData)
        {
            FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
            // UI
            {
                fileSystemBrowserUIData.removeCallBackAndDestroy(typeof(FileSystemBrowserUI));
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
                case UIData.Property.fileSystemBrowser:
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
        if (wrapProperty.p is FileSystemBrowserUI.UIData)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnChoose, onClickBtnChoose);
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
                    case KeyCode.C:
                        {
                            if (btnChoose != null && btnChoose.gameObject.activeInHierarchy && btnChoose.interactable)
                            {
                                this.onClickBtnChoose();
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

    public Button btnChoose;

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnChoose()
    {
        if (this.data != null)
        {
            FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.fileSystemBrowser.v;
            if (fileSystemBrowserUIData != null)
            {
                FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
                if (fileSystemBrowser != null)
                {
                    DirectoryInfo currentDir = fileSystemBrowser.getCurrentDirectory();
                    if (currentDir != null && currentDir.Exists)
                    {
                        if (edtName != null)
                        {
                            string fileName = edtName.text;
                            if (!string.IsNullOrEmpty(fileName))
                            {
                                string newFilePath = Path.Combine(currentDir.FullName, fileName);
                                HaveDatabaseServerNoneUI.UIData haveDatabaseServerNoneUIData = this.data.findDataInParent<HaveDatabaseServerNoneUI.UIData>();
                                if (haveDatabaseServerNoneUIData != null)
                                {
                                    // set
                                    {
                                        HaveDatabaseServerNoneUI haveDatabaseServerNoneUI = haveDatabaseServerNoneUIData.findCallBack<HaveDatabaseServerNoneUI>();
                                        if (haveDatabaseServerNoneUI != null)
                                        {
                                            if (haveDatabaseServerNoneUI.edtFilePath != null)
                                            {
                                                haveDatabaseServerNoneUI.edtFilePath.text = newFilePath;
                                            }
                                            else
                                            {
                                                Debug.LogError("edtFilePath null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("haveDatabaseServerNoneUI null: " + this);
                                        }
                                    }
                                    // back
                                    {
                                        haveDatabaseServerNoneUIData.chooseDatabaseUIData.v = null;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("haveDatabaseServerNoneUIData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("fileName null or empty: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("edtName null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("current dir not exist");
                    }
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
            HaveDatabaseServerNoneUI.UIData haveDatabaseServerNoneUIData = this.data.findDataInParent<HaveDatabaseServerNoneUI.UIData>();
            if (haveDatabaseServerNoneUIData != null)
            {
                haveDatabaseServerNoneUIData.chooseDatabaseUIData.v = null;
            }
            else
            {
                Debug.LogError("haveDatabaseServerNoneUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}