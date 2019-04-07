using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using FileSystem;

namespace Record
{
    public class SaveRecordUI : UIBehavior<SaveRecordUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<FileSystemBrowserUI.UIData> fileSystemBrowser;

            public VP<SaveRecordTask.TaskData> saveTask;

            public VP<ConfirmSaveRecordUI.UIData> confirmSave;

            #region Constructor

            public enum Property
            {
                fileSystemBrowser,
                saveTask,
                confirmSave
            }

            public UIData() : base()
            {
                {
                    this.fileSystemBrowser = new VP<FileSystemBrowserUI.UIData>(this, (byte)Property.fileSystemBrowser, new FileSystemBrowserUI.UIData());
                    this.fileSystemBrowser.v.fileSystemBrowser.v = new ReferenceData<FileSystemBrowser>(new FileSystemBrowser());
                }
                this.saveTask = new VP<SaveRecordTask.TaskData>(this, (byte)Property.saveTask, new SaveRecordTask.TaskData());
                this.confirmSave = new VP<ConfirmSaveRecordUI.UIData>(this, (byte)Property.confirmSave, null);
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // confirmSave
                    if (!isProcess)
                    {
                        ConfirmSaveRecordUI.UIData confirmSave = this.confirmSave.v;
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
                    // back
                    if (!isProcess)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            SaveRecordUI saveRecordUI = this.findCallBack<SaveRecordUI>();
                            if (saveRecordUI != null)
                            {
                                saveRecordUI.onClickBtnBack();
                            }
                            else
                            {
                                Debug.LogError("saveRecordUI null: " + this);
                            }
                            isProcess = true;
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtSave = new TxtLanguage("Save");
        private static readonly TxtLanguage txtSaving = new TxtLanguage("Saving...");

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Save Record");

        public Text tvPlaceHolder;
        private static readonly TxtLanguage txtPlaceHolder = new TxtLanguage("Enter file name");

        static SaveRecordUI()
        {
            txtSave.add(Language.Type.vi, "Lưu");
            txtSaving.add(Language.Type.vi, "Đang lưu...");
            txtTitle.add(Language.Type.vi, "Lưu Trữ Bản Ghi");
            txtPlaceHolder.add(Language.Type.vi, "Điền tên file");
        }

        #endregion

        #region Refresh

        public InputField edtName;

        public Button btnSave;
        public Text tvSave;

        public Button btnBack;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // btnSave, tvSave
                    if (btnSave != null && tvSave != null)
                    {
                        SaveRecordTask.TaskData saveTask = this.data.saveTask.v;
                        if (saveTask != null)
                        {
                            switch (saveTask.state.v)
                            {
                                case SaveRecordTask.TaskData.State.None:
                                    {
                                        btnSave.interactable = true;
                                        tvSave.text = txtSave.get();
                                    }
                                    break;
                                case SaveRecordTask.TaskData.State.Save:
                                    {
                                        this.data.confirmSave.v = null;
                                        btnSave.interactable = false;
                                        tvSave.text = txtSaving.get();
                                    }
                                    break;
                                case SaveRecordTask.TaskData.State.Success:
                                    {
                                        this.data.confirmSave.v = null;
                                        saveTask.state.v = SaveRecordTask.TaskData.State.None;
                                        // refresh
                                        {
                                            SaveRecordUI.UIData saveRecordUIData = this.data.findDataInParent<SaveRecordUI.UIData>();
                                            if (saveRecordUIData != null)
                                            {
                                                FileSystemBrowserUI.UIData fileSystemBrowserUIData = saveRecordUIData.fileSystemBrowser.v;
                                                if (fileSystemBrowserUIData != null)
                                                {
                                                    FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
                                                    if (fileSystemBrowser != null)
                                                    {
                                                        fileSystemBrowser.refresh();
                                                        fileSystemBrowser.selectFile(saveTask.file, false, false);
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
                                                Debug.LogError("savevUIData null: " + this);
                                            }
                                        }
                                    }
                                    break;
                                case SaveRecordTask.TaskData.State.Fail:
                                    {
                                        this.data.confirmSave.v = null;
                                        saveTask.state.v = SaveRecordTask.TaskData.State.None;
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown state: " + saveTask.state.v + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("saveData null: " + this);
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
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (tvPlaceHolder != null)
                        {
                            tvPlaceHolder.text = txtPlaceHolder.get();
                        }
                        else
                        {
                            Debug.LogError("tvPlaceHolder null: " + this);
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
        private static readonly UIRectTransform fileSystemBrowserRect = UIRectTransform.CreateFullRect(0, 0, 80, 0);

        public ConfirmSaveRecordUI confirmSaveRecordPrefab;

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
                    uiData.saveTask.allAddCallBack(this);
                    uiData.confirmSave.allAddCallBack(this);
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
                if (data is FileSystemBrowserUI.UIData)
                {
                    FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(fileSystemBrowserUIData, fileSystemBrowserPrefab, this.transform, fileSystemBrowserRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is SaveRecordTask.TaskData)
                {
                    SaveRecordTask.TaskData saveRecordTask = data as SaveRecordTask.TaskData;
                    // Update
                    {
                        UpdateUtils.makeUpdate<SaveRecordTask, SaveRecordTask.TaskData>(saveRecordTask, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if (data is ConfirmSaveRecordUI.UIData)
                {
                    ConfirmSaveRecordUI.UIData confirmSaveRecordUIData = data as ConfirmSaveRecordUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(confirmSaveRecordUIData, confirmSaveRecordPrefab, this.transform);
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
                    uiData.saveTask.allRemoveCallBack(this);
                    uiData.confirmSave.allRemoveCallBack(this);
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
                if (data is FileSystemBrowserUI.UIData)
                {
                    FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
                    // UI
                    {
                        fileSystemBrowserUIData.removeCallBackAndDestroy(typeof(FileSystemBrowserUI));
                    }
                    return;
                }
                if (data is SaveRecordTask.TaskData)
                {
                    SaveRecordTask.TaskData saveRecordTask = data as SaveRecordTask.TaskData;
                    // Update
                    {
                        saveRecordTask.removeCallBackAndDestroy(typeof(SaveRecordTask));
                    }
                    return;
                }
                if (data is ConfirmSaveRecordUI.UIData)
                {
                    ConfirmSaveRecordUI.UIData confirmSaveRecordUIData = data as ConfirmSaveRecordUI.UIData;
                    // UI
                    {
                        confirmSaveRecordUIData.removeCallBackAndDestroy(typeof(ConfirmSaveRecordUI));
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
                    case UIData.Property.fileSystemBrowser:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.saveTask:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
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
                if (wrapProperty.p is FileSystemBrowserUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is SaveRecordTask.TaskData)
                {
                    switch ((SaveRecordTask.TaskData.Property)wrapProperty.n)
                    {
                        case SaveRecordTask.TaskData.Property.state:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is ConfirmSaveRecordUI.UIData)
                {
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
                DataRecordTaskUI.UIData dataRecordTaskUIData = this.data.findDataInParent<DataRecordTaskUI.UIData>();
                if (dataRecordTaskUIData != null)
                {
                    DataRecordTask dataRecordTask = dataRecordTaskUIData.dataRecordTask.v.data;
                    if (dataRecordTask != null)
                    {
                        dataRecordTask.state.v = DataRecordTask.State.None;
                        dataRecordTaskUIData.saveRecordUIData.v = null;
                    }
                    else
                    {
                        Debug.LogError("dataRecordTask null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("dataRecordTaskUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onClickBtnSaveRecord()
        {
            if (this.data != null)
            {
                // find dataRecord
                DataRecord dataRecord = null;
                {
                    DataRecordTaskUI.UIData dataRecordTaskUIData = this.data.findDataInParent<DataRecordTaskUI.UIData>();
                    if (dataRecordTaskUIData != null)
                    {
                        DataRecordTask dataRecordTask = dataRecordTaskUIData.dataRecordTask.v.data;
                        if (dataRecordTask != null)
                        {
                            dataRecord = dataRecordTask.record;
                        }
                        else
                        {
                            Debug.LogError("dataRecordTask null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("dataRecordTaskUIData null: " + this);
                    }
                }
                // Process
                if (dataRecord != null)
                {
                    SaveRecordTask.TaskData saveTask = this.data.saveTask.v;
                    if (saveTask != null)
                    {
                        if (saveTask.state.v == SaveRecordTask.TaskData.State.None)
                        {
                            // get file
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
                                            file = new FileInfo(Path.Combine(dir.FullName, fileName) + DataRecord.Extension);
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
                            // process
                            if (file != null)
                            {
                                if (!file.Exists)
                                {
                                    saveTask.file = file;
                                    saveTask.dataRecord = dataRecord;
                                    saveTask.state.v = SaveRecordTask.TaskData.State.Save;
                                }
                                else
                                {
                                    ConfirmSaveRecordUI.UIData confirmSaveUIData = this.data.confirmSave.newOrOld<ConfirmSaveRecordUI.UIData>();
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
                        Debug.LogError("saveData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("dataRecord null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}