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

    #region txt, rect

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Choose Database");

    public Text tvChoose;
    private static readonly TxtLanguage txtChoose = new TxtLanguage("Choose");

    public Text tvNamePlaceHolder;
    private static readonly TxtLanguage txtNamePlaceHolder = new TxtLanguage("Enter database name...");

    static ChooseDatabaseUI()
    {
        txtTitle.add(Language.Type.vi, "Chọn Cơ Sở Dữ Liệu");
        txtChoose.add(Language.Type.vi, "Chọn");
        txtNamePlaceHolder.add(Language.Type.vi, "Điền tên cơ sở dữ liệu...");
    }

    #endregion

    #region Refresh

    public InputField edtName;

    public Button btnBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // edtName when selected files change
                if(edtName!=null)
                {
                    // find
                    FileSystemInfo newSelectedFile = null;
                    {
                        if (selectedFilesChange)
                        {
                            FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.fileSystemBrowser.v;
                            if (fileSystemBrowserUIData != null)
                            {
                                List<FileSystemInfo> selectedFiles = fileSystemBrowserUIData.getSelectedFiles();
                                // find
                                if (selectedFiles.Count > 0)
                                {
                                    FileSystemInfo selectedFile = selectedFiles[0];
                                    if (selectedFile != lastSelectedFile)
                                    {
                                        newSelectedFile = selectedFile;
                                    }
                                }
                                // set lastSelectedFiles
                                {
                                    if (selectedFiles.Count == 0)
                                    {
                                        lastSelectedFile = null;
                                    }
                                    else
                                    {
                                        lastSelectedFile = selectedFiles[0];
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("fileSystemBrowserUIData null");
                            }
                        }
                    }
                    // process
                    if (newSelectedFile != null)
                    {
                        edtName.text = newSelectedFile.Name;
                    }
                    else
                    {
                        // Debug.LogError("newSelectedFile null");
                    }
                }
                else
                {
                    Debug.LogError("edtName null");
                }
                // UI
                {
                    float buttonSize = Setting.get().getButtonSize();
                    // header
                    {
                        UIRectTransform.SetTitleTransform(lbTitle);
                        UIRectTransform.SetButtonTopLeftTransform(btnBack);
                    }
                    // edtName
                    if (edtName != null)
                    {
                        UIRectTransform.SetPosY((RectTransform)edtName.transform, buttonSize + 20);
                    }
                    else
                    {
                        Debug.LogError("edtName null");
                    }
                    // btnChoose
                    if (btnChoose != null)
                    {
                        UIRectTransform rect = new UIRectTransform();
                        {
                            // anchoredPosition: (0.0, 0.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                            // offsetMin: (-90.0, -30.0); offsetMax: (0.0, 0.0); sizeDelta: (90.0, 30.0);
                            rect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                            rect.anchorMin = new Vector2(1.0f, 1.0f);
                            rect.anchorMax = new Vector2(1.0f, 1.0f);
                            rect.pivot = new Vector2(1.0f, 1.0f);
                            rect.offsetMin = new Vector2(-90.0f, -30.0f);
                            rect.offsetMax = new Vector2(0.0f, 0.0f);
                            rect.sizeDelta = new Vector2(90.0f, 30.0f);
                        }
                        rect.set((RectTransform)btnChoose.transform);
                    }
                    else
                    {
                        Debug.LogError("btnChoose null");
                    }
                    // fileSystemBrowser
                    {
                        UIRectTransform rect = CreateFileSystemBrowserContainer();
                        UIRectTransform.Set(this.data.fileSystemBrowser.v, rect);
                    }
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
                        Debug.LogError("lbTile null");
                    }
                    if (tvChoose != null)
                    {
                        tvChoose.text = txtChoose.get();
                        Setting.get().setContentTextSize(tvChoose);
                    }
                    else
                    {
                        Debug.LogError("tvChoose null");
                    }
                    if (tvNamePlaceHolder != null)
                    {
                        tvNamePlaceHolder.text = txtNamePlaceHolder.get();
                        Setting.get().setContentTextSize(tvNamePlaceHolder);
                    }
                    else
                    {
                        Debug.LogError("tvNamePlaceHolder null");
                    }
                    if (edtName != null)
                    {
                        if (edtName.textComponent != null)
                        {
                            Setting.get().setContentTextSize(edtName.textComponent);
                        }
                        else
                        {
                            Debug.LogError("textComponent null");
                        }
                    }
                    else
                    {
                        Debug.LogError("edtFen null");
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

    public FileSystemBrowserUI fileSystemBrowserPrefab;
    public static UIRectTransform CreateFileSystemBrowserContainer()
    {
        UIRectTransform rect = UIRectTransform.CreateFullRect(0, 0, Setting.get().getButtonSize() + 70, 0);
        return rect;
    }

    private FileSystemBrowserUISelectFilesCheckChange<FileSystemBrowserUI.UIData> fileSystemBrowserUISelectFilesCheckChange = new FileSystemBrowserUISelectFilesCheckChange<FileSystemBrowserUI.UIData>();
    private bool selectedFilesChange = false;
    private FileSystemInfo lastSelectedFile = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.fileSystemBrowser.allAddCallBack(this);
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
            if (data is FileSystemBrowserUI.UIData)
            {
                FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
                // checkChange
                {
                    fileSystemBrowserUISelectFilesCheckChange.addCallBack(this);
                    fileSystemBrowserUISelectFilesCheckChange.setData(fileSystemBrowserUIData);
                }
                // UI
                {
                    UIUtils.Instantiate(fileSystemBrowserUIData, fileSystemBrowserPrefab, this.transform, CreateFileSystemBrowserContainer());
                }
                dirty = true;
                return;
            }
            // checkChange
            if(data is FileSystemBrowserUISelectFilesCheckChange<FileSystemBrowserUI.UIData>)
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
                uiData.fileSystemBrowser.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if(data is Setting)
        {
            return;
        }
        // Child
        {
            if (data is FileSystemBrowserUI.UIData)
            {
                FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
                // checkChange
                {
                    fileSystemBrowserUISelectFilesCheckChange.removeCallBack(this);
                    fileSystemBrowserUISelectFilesCheckChange.setData(null);
                }
                // UI
                {
                    fileSystemBrowserUIData.removeCallBackAndDestroy(typeof(FileSystemBrowserUI));
                }
                return;
            }
            // checkChange
            if (data is FileSystemBrowserUISelectFilesCheckChange<FileSystemBrowserUI.UIData>)
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
        // Setting
        if(wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    dirty = true;
                    break;
                case Setting.Property.useShortKey:
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
                case Setting.Property.itemSize:
                    dirty = true;
                    break;
                case Setting.Property.confirmQuit:
                    break;
                case Setting.Property.boardIndex:
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                case Setting.Property.defaultChosenGame:
                    break;
                case Setting.Property.defaultRoomName:
                    break;
                case Setting.Property.defaultChatRoomStyle:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is FileSystemBrowserUI.UIData)
            {
                return;
            }
            // checkChange
            if (wrapProperty.p is FileSystemBrowserUISelectFilesCheckChange<FileSystemBrowserUI.UIData>)
            {
                selectedFilesChange = true;
                dirty = true;
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