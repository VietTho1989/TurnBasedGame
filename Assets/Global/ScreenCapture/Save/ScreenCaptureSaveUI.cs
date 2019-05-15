using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using FileSystem;
using AdvancedCoroutines;

public class ScreenCaptureSaveUI : UIBehavior<ScreenCaptureSaveUI.UIData>
{

    #region UIData

    public class UIData : ScreenCaptureUI.UIData.Sub
    {

        public VP<Texture2D> texture;

        public VP<FileSystemBrowserUI.UIData> fileSystemBrowser;

        #region state

        public enum State
        {
            None,
            Saving,
            Success,
            Fail
        }

        public VP<State> state;

        #endregion

        public VP<ConfirmSaveScreenUI.UIData> confirmSave;

        #region Constructor

        public enum Property
        {
            texture,
            fileSystemBrowser,
            state,
            confirmSave
        }

        public UIData() : base()
        {
            this.texture = new VP<Texture2D>(this, (byte)Property.texture, null);
            {
                this.fileSystemBrowser = new VP<FileSystemBrowserUI.UIData>(this, (byte)Property.fileSystemBrowser, new FileSystemBrowserUI.UIData());
                this.fileSystemBrowser.v.fileSystemBrowser.v = new ReferenceData<FileSystemBrowser>(new FileSystemBrowser());
            }
            this.state = new VP<State>(this, (byte)Property.state, State.None);
            this.confirmSave = new VP<ConfirmSaveScreenUI.UIData>(this, (byte)Property.confirmSave, null);
        }

        #endregion

        #region implement base

        public override Type getType()
        {
            return Type.Save;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // confirmSave
                if (!isProcess)
                {
                    ConfirmSaveScreenUI.UIData confirmSave = this.confirmSave.v;
                    if (confirmSave != null)
                    {
                        isProcess = confirmSave.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("confirmSave null: " + this);
                    }
                }
                // fileSystemBrowser
                if (!isProcess)
                {
                    FileSystemBrowserUI.UIData fileSystemBrowser = this.fileSystemBrowser.v;
                    if (fileSystemBrowser != null)
                    {
                        isProcess = fileSystemBrowser.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("fileSystemBrowser null: " + this);
                    }
                }
            }
            return isProcess;
        }

        public void reset()
        {
            this.state.v = State.None;
        }

        #endregion

    }

    #endregion

    #region txt, rect

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Save Screen Capture");

    public Button btnSave;
    public Text tvSave;
    private static readonly TxtLanguage txtSaveNone = new TxtLanguage("Save");
    private static readonly TxtLanguage txtSaveSaving = new TxtLanguage("Saving");
    private static readonly TxtLanguage txtSaveSuccess = new TxtLanguage("Save success");
    private static readonly TxtLanguage txtSaveFail = new TxtLanguage("Save fail");

    public Text tvPlaceHolder;
    private static readonly TxtLanguage txtPlaceHolder = new TxtLanguage("Enter file name");

    static ScreenCaptureSaveUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Lưu Ảnh Chụp");
            // txtSave
            {
                txtSaveNone.add(Language.Type.vi, "Lưu");
                txtSaveSaving.add(Language.Type.vi, "Đang lưu");
                txtSaveSuccess.add(Language.Type.vi, "Lưu thành công");
                txtSaveFail.add(Language.Type.vi, "Lưu thất bại");
            }
            txtPlaceHolder.add(Language.Type.vi, "Điền tên file");
        }
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
                if (this.data.texture.v != null)
                {
                    // edtName when selected files change
                    if (edtName != null)
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
                    }
                    // btnSave, tvSave
                    if (btnSave != null && tvSave != null)
                    {
                        switch (this.data.state.v)
                        {
                            case UIData.State.None:
                                {
                                    // UI
                                    {
                                        btnSave.interactable = true;
                                        tvSave.text = txtSaveNone.get();
                                    }
                                    // Task
                                    {
                                        destroyRoutine(this.saveRoutine);
                                        destroyRoutine(this.waitRoutine);
                                    }
                                }
                                break;
                            case UIData.State.Saving:
                                {
                                    // UI
                                    {
                                        this.data.confirmSave.v = null;
                                        btnSave.interactable = false;
                                        tvSave.text = txtSaveSaving.get();
                                    }
                                    // Task
                                    {
                                        startRoutine(ref this.saveRoutine, TaskSave());
                                        destroyRoutine(this.waitRoutine);
                                    }
                                }
                                break;
                            case UIData.State.Success:
                                {
                                    // UI
                                    {
                                        this.data.confirmSave.v = null;
                                        {
                                            btnSave.interactable = false;
                                            tvSave.text = txtSaveSuccess.get();
                                        }
                                        // refresh
                                        {
                                            FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.fileSystemBrowser.v;
                                            if (fileSystemBrowserUIData != null)
                                            {
                                                FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
                                                if (fileSystemBrowser != null)
                                                {
                                                    fileSystemBrowser.refresh();
                                                    fileSystemBrowser.selectFile(getFileInfo(), false, false);
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
                                    // Task
                                    {
                                        destroyRoutine(saveRoutine);
                                        startRoutine(ref this.waitRoutine, TaskWait());
                                    }
                                }
                                break;
                            case UIData.State.Fail:
                                {
                                    // UI
                                    {
                                        this.data.confirmSave.v = null;
                                        btnSave.interactable = false;
                                        tvSave.text = txtSaveFail.get();
                                    }
                                    // Task
                                    {
                                        destroyRoutine(saveRoutine);
                                        startRoutine(ref this.waitRoutine, TaskWait());
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("btnSaveData, tvSaveData null: " + this);
                    }
                    // siblingIndex
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.transform.SetSiblingIndex(0);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        if (edtName != null)
                        {
                            edtName.transform.SetSiblingIndex(1);
                        }
                        else
                        {
                            Debug.LogError("edtName null");
                        }
                        if (btnBack != null)
                        {
                            btnBack.transform.SetSiblingIndex(2);
                        }
                        else
                        {
                            Debug.LogError("btnBack null");
                        }
                        if (btnSave != null)
                        {
                            btnSave.transform.SetSiblingIndex(3);
                        }
                        else
                        {
                            Debug.LogError("btnSave null");
                        }
                        UIRectTransform.SetSiblingIndex(this.data.fileSystemBrowser.v, 4);
                        UIRectTransform.SetSiblingIndex(this.data.confirmSave.v, 5);
                    }
                    // UI
                    {
                        float buttonSize = Setting.get().getButtonSize();
                        // header
                        {
                            UIRectTransform.SetTitleTransform(lbTitle);
                            UIRectTransform.SetButtonTopLeftTransform(btnBack);
                            // btnSaveRecord
                            {
                                if (btnSave != null)
                                {
                                    UIRectTransform rect = new UIRectTransform();
                                    {
                                        rect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                                        rect.anchorMin = new Vector2(1.0f, 1.0f);
                                        rect.anchorMax = new Vector2(1.0f, 1.0f);
                                        rect.pivot = new Vector2(1.0f, 1.0f);
                                        rect.offsetMin = new Vector2(-90.0f, -buttonSize);
                                        rect.offsetMax = new Vector2(0.0f, 0.0f);
                                        rect.sizeDelta = new Vector2(90.0f, buttonSize);
                                    }
                                    rect.set((RectTransform)btnSave.transform);
                                }
                                else
                                {
                                    Debug.LogError("btnSave null");
                                }
                            }
                        }
                        // edtName
                        if (edtName != null)
                        {
                            UIRectTransform.SetPosY((RectTransform)edtName.transform, buttonSize + 10);
                        }
                        else
                        {
                            Debug.LogError("edtName null");
                        }
                        // fileSystemBrowser
                        {
                            UIRectTransform.Set(this.data.fileSystemBrowser.v, CreateFileSystemBrowserRect());
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
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (tvPlaceHolder != null)
                        {
                            tvPlaceHolder.text = txtPlaceHolder.get();
                            Setting.get().setContentTextSize(tvPlaceHolder);
                        }
                        else
                        {
                            Debug.LogError("tvPlaceHolder null: " + this);
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
                            Debug.LogError("edtName null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("texture null");
                    MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData>();
                    if (mainUIData != null)
                    {
                        mainUIData.screenCaptureUIData.v = null;
                    }
                    else
                    {
                        Debug.LogError("mainUIData null");
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
        return false;
    }

    #endregion

    #region Routine Save

    private Routine saveRoutine;

    public override List<Routine> getRoutineList()
    {
        List<Routine> ret = new List<Routine>();
        {
            ret.Add(saveRoutine);
            ret.Add(waitRoutine);
        }
        return ret;
    }

    private class Work
    {

        public UIData data = null;
        public FileInfo file = null;

        public bool isDone = false;
        public bool success = false;

        public void DoWork()
        {
            // Save and compress
            if (this.data != null)
            {
                if (this.data.texture != null)
                {
                    if (file != null)
                    {
                        byte[] byteArray = this.data.texture.v.EncodeToPNG();
                        if (byteArray != null)
                        {
                            Debug.LogError("save png success: " + byteArray.Length);
                            File.WriteAllBytes(file.FullName, byteArray);
                            success = true;
                        }
                        else
                        {
                            Debug.LogError("byteArray null");
                        }
                    }
                    else
                    {
                        Debug.LogError("file null");
                    }
                }
                else
                {
                    Debug.LogError("texture null");
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
            isDone = true;
        }

    }

    static void DoWork(object work)
    {
        if (work is Work)
        {
            ((Work)work).DoWork();
        }
        else
        {
            Debug.LogError("why not work: " + work);
        }
    }

    public IEnumerator TaskSave()
    {
        if (this.data != null)
        {
            Work w = new Work();
            // Task
            {
                w.data = this.data;
                w.isDone = false;
                w.success = false;
                // file
                {
                    FileInfo file = null;
                    {
                        if (this.edtName != null)
                        {
                            string fileName = this.edtName.text;
                            if (!string.IsNullOrEmpty(fileName))
                            {
                                // find folder
                                DirectoryInfo dir = null;
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
                                                dir = currentDir;
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
                                // Process
                                if (dir != null)
                                {
                                    file = new FileInfo(Path.Combine(dir.FullName, fileName) + ".png");
                                }
                                else
                                {
                                    Debug.LogError("dir null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("fileName null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("edtName null: " + this);
                        }
                    }
                    w.file = file;
                }
                // startThread
                ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), w);
                // Wait
                while (!w.isDone)
                {
                    yield return new Wait(1f);
                }
            }
            // Process
            if (w.success)
            {
                Debug.LogError("save success");
                Toast.showMessage(txtSaveSuccess.get());
                this.data.state.v = UIData.State.Success;
            }
            else
            {
                Debug.LogError("save fail");
                Toast.showMessage(txtSaveFail.get());
                this.data.state.v = UIData.State.Fail;
            }
        }
        else
        {
            Debug.LogError("inputData null");
        }
    }

    #endregion

    #region Routine WaitTime

    private Routine waitRoutine;

    public IEnumerator TaskWait()
    {
        if (this.data != null)
        {
            yield return new Wait(1f);
            if (this.data != null)
            {
                switch (this.data.state.v)
                {
                    case UIData.State.None:
                        break;
                    case UIData.State.Saving:
                        break;
                    case UIData.State.Success:
                    case UIData.State.Fail:
                        this.data.state.v = UIData.State.None;
                        break;
                    default:
                        Debug.LogError("unknown state: " + this.data.state.v);
                        break;
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    #endregion

    #region implement callBacks

    public FileSystemBrowserUI fileSystemBrowserPrefab;

    private static UIRectTransform CreateFileSystemBrowserRect()
    {
        return UIRectTransform.CreateFullRect(0, 0, Setting.get().getButtonSize() + 50, 0);
    }

    private FileSystemBrowserUISelectFilesCheckChange<FileSystemBrowserUI.UIData> fileSystemBrowserUISelectFilesCheckChange = new FileSystemBrowserUISelectFilesCheckChange<FileSystemBrowserUI.UIData>();
    private bool selectedFilesChange = false;
    private FileSystemInfo lastSelectedFile = null;

    public ConfirmSaveScreenUI confirmSaveScreenPrefab;

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
                uiData.confirmSave.allAddCallBack(this);
            }
            // reset
            {
                if (this.data != null)
                {
                    this.data.reset();
                }
                else
                {
                    Debug.LogError("data null");
                }
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
            // fileSystemBrowserUIData
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
                        UIUtils.Instantiate(fileSystemBrowserUIData, fileSystemBrowserPrefab, this.transform, CreateFileSystemBrowserRect());
                    }
                    dirty = true;
                    return;
                }
                // checkChange
                if (data is FileSystemBrowserUISelectFilesCheckChange<FileSystemBrowserUI.UIData>)
                {
                    dirty = true;
                    return;
                }
            }
            if (data is ConfirmSaveScreenUI.UIData)
            {
                ConfirmSaveScreenUI.UIData confirmSaveScreenUIData = data as ConfirmSaveScreenUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(confirmSaveScreenUIData, confirmSaveScreenPrefab, this.transform);
                }
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
                uiData.confirmSave.allRemoveCallBack(this);
            }
            // reset
            {
                if (uiData.texture.v != null)
                {
                    Object.Destroy(uiData.texture.v);
                    uiData.texture.v = null;
                }
                else
                {
                    Debug.LogError("texture null");
                }
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
            // fileSystemBrowserUIData
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
            if (data is ConfirmSaveScreenUI.UIData)
            {
                ConfirmSaveScreenUI.UIData confirmSaveScreenUIData = data as ConfirmSaveScreenUI.UIData;
                // UI
                {
                    confirmSaveScreenUIData.removeCallBackAndDestroy(typeof(ConfirmSaveScreenUI));
                }
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
                case UIData.Property.texture:
                    {
                        dirty = true;
                        // reset
                        if (this.data != null)
                        {
                            this.data.reset();
                        }
                        else
                        {
                            Debug.LogError("data null");
                        }
                    }
                    break;
                case UIData.Property.fileSystemBrowser:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.state:
                    dirty = true;
                    break;
                case UIData.Property.confirmSave:
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
                case Setting.Property.screenCaptureSetting:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            // fileSystemBrowserUIData
            {
                if (wrapProperty.p is FileSystemBrowserUI.UIData)
                {
                    return;
                }
                // checkChange
                if (wrapProperty.p is FileSystemBrowserUISelectFilesCheckChange<FileSystemBrowserUI.UIData>)
                {
                    dirty = true;
                    return;
                }
            }
            if (wrapProperty.p is ConfirmSaveScreenUI.UIData)
            {
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
            UIUtils.SetButtonOnClick(btnSave, onClickBtnSave);
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
                    case KeyCode.S:
                        {
                            if (btnSave != null && btnSave.gameObject.activeInHierarchy && btnSave.interactable)
                            {
                                this.onClickBtnSave();
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
            MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData>();
            if (mainUIData != null)
            {
                mainUIData.screenCaptureUIData.v = null;
            }
            else
            {
                Debug.LogError("mainUIData null");
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    private FileInfo getFileInfo()
    {
        FileInfo file = null;
        {
            if (this.data != null)
            {
                if (this.edtName != null)
                {
                    string fileName = this.edtName.text;
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        // find folder
                        DirectoryInfo dir = null;
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
                                        dir = currentDir;
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
                        // Process
                        if (dir != null)
                        {
                            file = new FileInfo(Path.Combine(dir.FullName, fileName) + ".png");
                        }
                        else
                        {
                            Debug.LogError("dir null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("fileName null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("edtName null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
        return file;
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnSave()
    {
        if (this.data != null)
        {
            if (this.data.state.v == UIData.State.None)
            {
                // get file
                FileInfo file = getFileInfo();
                // process
                if (file != null)
                {
                    if (!file.Exists)
                    {
                        this.data.state.v = UIData.State.Saving;
                    }
                    else
                    {
                        ConfirmSaveScreenUI.UIData confirmSaveUIData = this.data.confirmSave.newOrOld<ConfirmSaveScreenUI.UIData>();
                        {
                            confirmSaveUIData.fileInfo.v = file;
                        }
                        this.data.confirmSave.v = confirmSaveUIData;
                    }
                }
                else
                {
                    Debug.LogError("file null: " + this);
                }
            }
            else
            {
                Debug.LogError("you are saving: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}