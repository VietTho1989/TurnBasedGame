﻿using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using FileSystem;
using Record;

public class LoadDataUI : UIBehavior<LoadDataUI.UIData>
{

    #region UIData

    public class UIData : MainUI.UIData.Sub
    {

        public VP<FileSystemBrowserUI.UIData> fileSystemBrowser;

        #region loadData

        public VP<LoadDataTask.TaskData> loadDataTask;

        public VP<ViewSaveDataUI.UIData> viewSaveDataUIData;

        #endregion

        #region loadRecord

        public VP<LoadRecordTask.TaskData> loadRecordTask;

        public VP<ViewRecordUI.UIData> viewRecordUIData;

        #endregion

        #region Constructor

        public enum Property
        {
            fileSystemBrowser,

            loadDataTask,
            viewSaveDataUIData,

            loadRecordTask,
            viewRecordUIData
        }

        public UIData() : base()
        {
            // fileSystemBrowser
            {
                this.fileSystemBrowser = new VP<FileSystemBrowserUI.UIData>(this, (byte)Property.fileSystemBrowser, new FileSystemBrowserUI.UIData());
                this.fileSystemBrowser.v.fileSystemBrowser.v = new ReferenceData<FileSystemBrowser>(new FileSystemBrowser());
            }
            // loadData
            {
                this.loadDataTask = new VP<LoadDataTask.TaskData>(this, (byte)Property.loadDataTask, new LoadDataTask.TaskData());
                this.viewSaveDataUIData = new VP<ViewSaveDataUI.UIData>(this, (byte)Property.viewSaveDataUIData, new ViewSaveDataUI.UIData());
            }
            // loadRecord
            {
                this.loadRecordTask = new VP<LoadRecordTask.TaskData>(this, (byte)Property.loadRecordTask, new LoadRecordTask.TaskData());
                this.viewRecordUIData = new VP<ViewRecordUI.UIData>(this, (byte)Property.viewRecordUIData, new ViewRecordUI.UIData());
            }
        }

        #endregion

        public override Type getType()
        {
            return Type.LoadData;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // viewSaveGameData
                if (!isProcess)
                {
                    ViewSaveDataUI.UIData viewSaveDataUIData = this.viewSaveDataUIData.v;
                    if (viewSaveDataUIData != null)
                    {
                        if (viewSaveDataUIData.save.v != null)
                        {
                            viewSaveDataUIData.processEvent(e);
                            isProcess = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("viewSaveDataUIData null: " + this);
                    }
                }
                // viewRecordUIData
                if (!isProcess)
                {
                    ViewRecordUI.UIData viewRecordUIData = this.viewRecordUIData.v;
                    if (viewRecordUIData != null)
                    {
                        if (viewRecordUIData.dataRecord.v != null)
                        {
                            isProcess = viewRecordUIData.processEvent(e);
                            isProcess = true;
                        }
                    }
                }
                // fileSystemBrowser
                if (!isProcess)
                {
                    // TODO Can hoan thien

                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        LoadDataUI loadDataUI = this.findCallBack<LoadDataUI>();
                        if (loadDataUI != null)
                        {
                            loadDataUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("loadDataUI null: " + this);
                        }
                        isProcess = true;
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        LoadDataUI loadDataUI = this.findCallBack<LoadDataUI>();
                        if (loadDataUI != null)
                        {
                            isProcess = loadDataUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("loadDataUI null: " + this);
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Load Data");

    private static readonly TxtLanguage txtLoad = new TxtLanguage("Load Game");
    private static readonly TxtLanguage txtCannotLoad = new TxtLanguage("Load Game");
    private static readonly TxtLanguage txtLoading = new TxtLanguage("Loading");
    private static readonly TxtLanguage txtLoadSuccess = new TxtLanguage("Load success");
    private static readonly TxtLanguage txtLoadFail = new TxtLanguage("Load fail");

    private static readonly TxtLanguage txtLoadRecord = new TxtLanguage("Load Record");
    private static readonly TxtLanguage txtCannotLoadRecord = new TxtLanguage("Load Record");
    private static readonly TxtLanguage txtLoadingRecord = new TxtLanguage("Loading");
    private static readonly TxtLanguage txtLoadRecordSuccess = new TxtLanguage("Load record success");
    private static readonly TxtLanguage txtLoadRecordFail = new TxtLanguage("Load fail");

    static LoadDataUI()
    {
        txtTitle.add(Language.Type.vi, "Tải Dữ Liệu");

        txtLoad.add(Language.Type.vi, "Tải");
        txtCannotLoad.add(Language.Type.vi, "Tải Game");
        txtLoading.add(Language.Type.vi, "Đang tải");
        txtLoadSuccess.add(Language.Type.vi, "Tải thành công");
        txtLoadFail.add(Language.Type.vi, "Tải thất bại");

        txtLoadRecord.add(Language.Type.vi, "Tải Record");
        txtCannotLoadRecord.add(Language.Type.vi, "Tải Record ");
        txtLoadingRecord.add(Language.Type.vi, "Đang tải");
        txtLoadRecordSuccess.add(Language.Type.vi, "Tải thành công");
        txtLoadRecordFail.add(Language.Type.vi, "Tải thất bại");
    }

    #endregion

    #region Refresh

    public Button btnBack;

    public Button btnLoad;
    public Text tvLoad;

    public Button btnRecord;
    public Text tvRecord;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // loadData
                {
                    // btnLoad, tvLoad
                    {
                        if (btnLoad != null && tvLoad != null)
                        {
                            LoadDataTask.TaskData loadDataTask = this.data.loadDataTask.v;
                            if (loadDataTask != null)
                            {
                                switch (loadDataTask.state.v)
                                {
                                    case LoadDataTask.TaskData.State.None:
                                        {
                                            // check have correct select file
                                            bool haveCorrectSelectFile = false;
                                            {
                                                FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.fileSystemBrowser.v;
                                                if (fileSystemBrowserUIData != null)
                                                {
                                                    FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
                                                    if (fileSystemBrowser != null)
                                                    {
                                                        Action action = fileSystemBrowser.action.v;
                                                        if (action != null)
                                                        {
                                                            if (action is ActionNone)
                                                            {
                                                                ActionNone actionNone = action as ActionNone;
                                                                if (actionNone.selectFiles.vs.Count == 1)
                                                                {
                                                                    FileSystemInfo fileSystemInfo = actionNone.selectFiles.vs[0];
                                                                    if (fileSystemInfo is FileInfo)
                                                                    {
                                                                        FileInfo fileInfo = fileSystemInfo as FileInfo;
                                                                        if (fileInfo.Extension == Save.SaveExtension || fileInfo.Extension == Save.FenExtension)
                                                                        {
                                                                            haveCorrectSelectFile = true;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("action null: " + this);
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
                                            {
                                                if (haveCorrectSelectFile)
                                                {
                                                    btnLoad.interactable = true;
                                                    tvLoad.text = txtLoad.get();
                                                }
                                                else
                                                {
                                                    btnLoad.interactable = false;
                                                    tvLoad.text = txtCannotLoad.get();
                                                }
                                            }
                                        }
                                        break;
                                    case LoadDataTask.TaskData.State.Load:
                                        {
                                            btnLoad.interactable = false;
                                            tvLoad.text = txtLoading.get();
                                        }
                                        break;
                                    case LoadDataTask.TaskData.State.Success:
                                        {
                                            btnLoad.interactable = false;
                                            tvLoad.text = txtLoadSuccess.get();
                                        }
                                        break;
                                    case LoadDataTask.TaskData.State.Fail:
                                        {
                                            btnLoad.interactable = false;
                                            tvLoad.text = txtLoadFail.get();
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + loadDataTask.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("loadDataTask null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("btnLoad, tvLoad null: " + this);
                        }
                    }
                    // UpdateTask
                    {
                        LoadDataTask.TaskData loadDataTask = this.data.loadDataTask.v;
                        if (loadDataTask != null)
                        {
                            switch (loadDataTask.state.v)
                            {
                                case LoadDataTask.TaskData.State.None:
                                    {

                                    }
                                    break;
                                case LoadDataTask.TaskData.State.Load:
                                    {

                                    }
                                    break;
                                case LoadDataTask.TaskData.State.Success:
                                    {
                                        // viewSaveDataUIData
                                        {
                                            ViewSaveDataUI.UIData viewSaveDataUIData = this.data.viewSaveDataUIData.v;
                                            if (viewSaveDataUIData != null)
                                            {
                                                viewSaveDataUIData.save.v = loadDataTask.save;
                                            }
                                            else
                                            {
                                                Debug.LogError("viewSaveDataUIData null: " + this);
                                            }
                                        }
                                        loadDataTask.state.v = LoadDataTask.TaskData.State.None;
                                    }
                                    break;
                                case LoadDataTask.TaskData.State.Fail:
                                    {
                                        loadDataTask.state.v = LoadDataTask.TaskData.State.None;
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown state: " + loadDataTask.state.v + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("loadDataTask null: " + this);
                        }
                    }
                }
                // loadRecord
                {
                    // btnRecord, tvRecord
                    {
                        if (btnRecord != null && tvRecord != null)
                        {
                            LoadRecordTask.TaskData loadRecordTask = this.data.loadRecordTask.v;
                            if (loadRecordTask != null)
                            {
                                switch (loadRecordTask.state.v)
                                {
                                    case LoadRecordTask.TaskData.State.None:
                                        {
                                            // check have correct select file
                                            bool haveCorrectSelectFile = false;
                                            {
                                                FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.fileSystemBrowser.v;
                                                if (fileSystemBrowserUIData != null)
                                                {
                                                    FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
                                                    if (fileSystemBrowser != null)
                                                    {
                                                        Action action = fileSystemBrowser.action.v;
                                                        if (action != null)
                                                        {
                                                            if (action is ActionNone)
                                                            {
                                                                ActionNone actionNone = action as ActionNone;
                                                                if (actionNone.selectFiles.vs.Count == 1)
                                                                {
                                                                    FileSystemInfo fileSystemInfo = actionNone.selectFiles.vs[0];
                                                                    if (fileSystemInfo is FileInfo)
                                                                    {
                                                                        FileInfo fileInfo = fileSystemInfo as FileInfo;
                                                                        if (fileInfo.Extension == DataRecord.Extension)
                                                                        {
                                                                            haveCorrectSelectFile = true;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("action null: " + this);
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
                                            {
                                                if (haveCorrectSelectFile)
                                                {
                                                    btnRecord.interactable = true;
                                                    tvRecord.text = txtLoadRecord.get();
                                                }
                                                else
                                                {
                                                    btnRecord.interactable = false;
                                                    tvRecord.text = txtCannotLoadRecord.get();
                                                }
                                            }
                                        }
                                        break;
                                    case LoadRecordTask.TaskData.State.Load:
                                        {
                                            btnRecord.interactable = false;
                                            tvRecord.text = txtLoadingRecord.get();
                                        }
                                        break;
                                    case LoadRecordTask.TaskData.State.Success:
                                        {
                                            btnRecord.interactable = false;
                                            tvRecord.text = txtLoadRecordSuccess.get();
                                        }
                                        break;
                                    case LoadRecordTask.TaskData.State.Fail:
                                        {
                                            btnRecord.interactable = false;
                                            tvRecord.text = txtLoadRecordFail.get();
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + loadRecordTask.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("loadDataTask null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("btnRecord, tvRecord null: " + this);
                        }
                    }
                    // UpdateTask
                    {
                        LoadRecordTask.TaskData loadRecordTask = this.data.loadRecordTask.v;
                        if (loadRecordTask != null)
                        {
                            switch (loadRecordTask.state.v)
                            {
                                case LoadRecordTask.TaskData.State.None:
                                    {

                                    }
                                    break;
                                case LoadRecordTask.TaskData.State.Load:
                                    {

                                    }
                                    break;
                                case LoadRecordTask.TaskData.State.Success:
                                    {
                                        // viewRecordUIData
                                        {
                                            ViewRecordUI.UIData viewRecordUIData = this.data.viewRecordUIData.v;
                                            if (viewRecordUIData != null)
                                            {
                                                viewRecordUIData.dataRecord.v = loadRecordTask.dataRecord;
                                            }
                                            else
                                            {
                                                Debug.LogError("viewRecordUIData null: " + this);
                                            }
                                        }
                                        Toast.showMessage(txtLoadRecordSuccess.get());
                                        loadRecordTask.state.v = LoadRecordTask.TaskData.State.None;
                                    }
                                    break;
                                case LoadRecordTask.TaskData.State.Fail:
                                    {
                                        loadRecordTask.state.v = LoadRecordTask.TaskData.State.None;
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown state: " + loadRecordTask.state.v + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("loadDataTask null: " + this);
                        }
                    }
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
                    if (btnBack != null)
                    {
                        btnBack.transform.SetSiblingIndex(1);
                    }
                    else
                    {
                        Debug.LogError("btnBack null");
                    }
                    if (btnLoad != null)
                    {
                        btnLoad.transform.SetSiblingIndex(2);
                    }
                    else
                    {
                        Debug.LogError("btnLoad null");
                    }
                    if (btnRecord != null)
                    {
                        btnRecord.transform.SetSiblingIndex(3);
                    }
                    else
                    {
                        Debug.LogError("btnRecord null");
                    }
                    UIRectTransform.SetSiblingIndex(this.data.fileSystemBrowser.v, 4);
                    UIRectTransform.SetSiblingIndex(this.data.viewSaveDataUIData.v, 5);
                    UIRectTransform.SetSiblingIndex(this.data.viewRecordUIData.v, 6);
                }
                // UI
                {
                    float buttonSize = Setting.get().getButtonSize();
                    // header
                    {
                        UIRectTransform.SetTitleTransform(lbTitle);
                        UIRectTransform.SetButtonTopLeftTransform(btnBack);
                        // btnLoad
                        {
                            // btnLoad
                            {
                                if (btnLoad != null)
                                {
                                    UIRectTransform rect = new UIRectTransform();
                                    {
                                        // anchoredPosition: (0.0, 0.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                                        // offsetMin: (-90.0, -30.0); offsetMax: (0.0, 0.0); sizeDelta: (90.0, 30.0);
                                        rect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                                        rect.anchorMin = new Vector2(1.0f, 1.0f);
                                        rect.anchorMax = new Vector2(1.0f, 1.0f);
                                        rect.pivot = new Vector2(1.0f, 1.0f);
                                        rect.offsetMin = new Vector2(-90.0f, -buttonSize);
                                        rect.offsetMax = new Vector2(0.0f, 0.0f);
                                        rect.sizeDelta = new Vector2(90.0f, buttonSize);
                                    }
                                    rect.set((RectTransform)btnLoad.transform);
                                }
                                else
                                {
                                    Debug.LogError("btnLoad null");
                                }
                            }
                            // btnRecord
                            {
                                if (btnRecord != null)
                                {
                                    UIRectTransform rect = new UIRectTransform();
                                    {
                                        // anchoredPosition: (-90.0, 0.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                                        // offsetMin: (-180.0, -30.0); offsetMax: (-90.0, 0.0); sizeDelta: (90.0, 30.0);
                                        rect.anchoredPosition = new Vector3(-90.0f, 0.0f, 0.0f);
                                        rect.anchorMin = new Vector2(1.0f, 1.0f);
                                        rect.anchorMax = new Vector2(1.0f, 1.0f);
                                        rect.pivot = new Vector2(1.0f, 1.0f);
                                        rect.offsetMin = new Vector2(-180.0f, -buttonSize);
                                        rect.offsetMax = new Vector2(-90.0f, 0.0f);
                                        rect.sizeDelta = new Vector2(90.0f, buttonSize);
                                    }
                                    rect.set((RectTransform)btnRecord.transform);
                                }
                                else
                                {
                                    Debug.LogError("btnRecord null");
                                }
                            }
                        }
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

    private static UIRectTransform CreateFileSystemBrowserRect()
    {
        return UIRectTransform.CreateFullRect(0, 0, Setting.get().getButtonSize(), 0);
    }

    public ViewSaveDataUI viewSaveDataPrefab;

    public ViewRecordUI viewRecordPrefab;

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
                // loadData
                {
                    uiData.loadDataTask.allAddCallBack(this);
                    uiData.viewSaveDataUIData.allAddCallBack(this);
                }
                // loadRecord
                {
                    uiData.loadRecordTask.allAddCallBack(this);
                    uiData.viewRecordUIData.allAddCallBack(this);
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
                    // UI
                    {
                        UIUtils.Instantiate(fileSystemBrowserUIData, fileSystemBrowserPrefab, this.transform, CreateFileSystemBrowserRect());
                    }
                    // Child
                    {
                        fileSystemBrowserUIData.fileSystemBrowser.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is FileSystemBrowser)
                    {
                        FileSystemBrowser fileSystemBrowser = data as FileSystemBrowser;
                        // Child
                        {
                            fileSystemBrowser.action.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Action)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // loadData
            {
                if (data is LoadDataTask.TaskData)
                {
                    LoadDataTask.TaskData loadDataTask = data as LoadDataTask.TaskData;
                    // Update
                    {
                        UpdateUtils.makeUpdate<LoadDataTask, LoadDataTask.TaskData>(loadDataTask, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if (data is ViewSaveDataUI.UIData)
                {
                    ViewSaveDataUI.UIData viewSaveDataUIData = data as ViewSaveDataUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(viewSaveDataUIData, viewSaveDataPrefab, this.transform, UIConstants.FullParent);
                    }
                    dirty = true;
                    return;
                }
            }
            // loadRecord
            {
                if (data is LoadRecordTask.TaskData)
                {
                    LoadRecordTask.TaskData loadRecordTask = data as LoadRecordTask.TaskData;
                    // Update
                    {
                        UpdateUtils.makeUpdate<LoadRecordTask, LoadRecordTask.TaskData>(loadRecordTask, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if (data is ViewRecordUI.UIData)
                {
                    ViewRecordUI.UIData viewRecordUIData = data as ViewRecordUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(viewRecordUIData, viewRecordPrefab, this.transform, UIConstants.FullParent);
                    }
                    dirty = true;
                    return;
                }
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
                // loadData
                {
                    uiData.loadDataTask.allRemoveCallBack(this);
                    uiData.viewSaveDataUIData.allRemoveCallBack(this);
                }
                // loadRecord
                {
                    uiData.loadRecordTask.allRemoveCallBack(this);
                    uiData.viewRecordUIData.allRemoveCallBack(this);
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
                    // UI
                    {
                        fileSystemBrowserUIData.removeCallBackAndDestroy(typeof(FileSystemBrowserUI));
                    }
                    // Child
                    {
                        fileSystemBrowserUIData.fileSystemBrowser.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is FileSystemBrowser)
                    {
                        FileSystemBrowser fileSystemBrowser = data as FileSystemBrowser;
                        // Child
                        {
                            fileSystemBrowser.action.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Action)
                    {
                        return;
                    }
                }
            }
            // loadData
            {
                if (data is LoadDataTask.TaskData)
                {
                    LoadDataTask.TaskData loadDataTask = data as LoadDataTask.TaskData;
                    // Update
                    {
                        loadDataTask.removeCallBackAndDestroy(typeof(LoadDataTask));
                    }
                    return;
                }
                if (data is ViewSaveDataUI.UIData)
                {
                    ViewSaveDataUI.UIData viewSaveDataUIData = data as ViewSaveDataUI.UIData;
                    // UI
                    {
                        viewSaveDataUIData.removeCallBackAndDestroy(typeof(ViewSaveDataUI));
                    }
                    return;
                }
            }
            // loadRecord
            {
                if (data is LoadRecordTask.TaskData)
                {
                    LoadRecordTask.TaskData loadRecordTask = data as LoadRecordTask.TaskData;
                    // Update
                    {
                        loadRecordTask.removeCallBackAndDestroy(typeof(LoadRecordTask));
                    }
                    return;
                }
                if (data is ViewRecordUI.UIData)
                {
                    ViewRecordUI.UIData viewRecordUIData = data as ViewRecordUI.UIData;
                    // UI
                    {
                        viewRecordUIData.removeCallBackAndDestroy(typeof(ViewRecordUI));
                    }
                    return;
                }
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
                case UIData.Property.loadDataTask:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.viewSaveDataUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.loadRecordTask:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.viewRecordUIData:
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
                case Setting.Property.confirmQuit:
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
            // fileSystemBrowserUIData
            {
                if (wrapProperty.p is FileSystemBrowserUI.UIData)
                {
                    switch ((FileSystemBrowserUI.UIData.Property)wrapProperty.n)
                    {
                        case FileSystemBrowserUI.UIData.Property.fileSystemBrowser:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case FileSystemBrowserUI.UIData.Property.showUIData:
                            break;
                        case FileSystemBrowserUI.UIData.Property.btnDelete:
                            break;
                        case FileSystemBrowserUI.UIData.Property.btnCopy:
                            break;
                        case FileSystemBrowserUI.UIData.Property.btnCut:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is FileSystemBrowser)
                    {
                        switch ((FileSystemBrowser.Property)wrapProperty.n)
                        {
                            case FileSystemBrowser.Property.action:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case FileSystemBrowser.Property.show:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is Action)
                    {
                        Action action = wrapProperty.p as Action;
                        switch (action.getType())
                        {
                            case Action.Type.None:
                                {
                                    switch ((ActionNone.Property)wrapProperty.n)
                                    {
                                        case ActionNone.Property.state:
                                            break;
                                        case ActionNone.Property.selectFiles:
                                            dirty = true;
                                            break;
                                        default:
                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                            break;
                                    }
                                }
                                break;
                            case Action.Type.Edit:
                                break;
                            default:
                                Debug.LogError("unknown type: " + action.getType() + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            // loadData
            {
                if (wrapProperty.p is LoadDataTask.TaskData)
                {
                    switch ((LoadDataTask.TaskData.Property)wrapProperty.n)
                    {
                        case LoadDataTask.TaskData.Property.state:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is ViewSaveDataUI.UIData)
                {
                    return;
                }
            }
            // loadRecord
            {
                if (wrapProperty.p is LoadRecordTask.TaskData)
                {
                    switch ((LoadRecordTask.TaskData.Property)wrapProperty.n)
                    {
                        case LoadRecordTask.TaskData.Property.state:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is ViewRecordUI.UIData)
                {
                    return;
                }
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
            UIUtils.SetButtonOnClick(btnLoad, onClickBtnLoad);
            UIUtils.SetButtonOnClick(btnRecord, onClickBtnRecord);
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
                    case KeyCode.L:
                        {
                            if (btnLoad != null && btnLoad.gameObject.activeInHierarchy && btnLoad.interactable)
                            {
                                this.onClickBtnLoad();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    case KeyCode.R:
                        {
                            if (btnRecord != null && btnRecord.gameObject.activeInHierarchy && btnRecord.interactable)
                            {
                                this.onClickBtnRecord();
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
                HomeUI.UIData homeUIData = mainUIData.sub.newOrOld<HomeUI.UIData>();
                {

                }
                mainUIData.sub.v = homeUIData;
            }
            else
            {
                Debug.LogError("mainUI null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnLoad()
    {
        if (this.data != null)
        {
            LoadDataTask.TaskData loadDataTask = this.data.loadDataTask.v;
            if (loadDataTask != null)
            {
                switch (loadDataTask.state.v)
                {
                    case LoadDataTask.TaskData.State.None:
                        {
                            // find fileInfo
                            FileInfo saveFileInfo = null;
                            {
                                FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.fileSystemBrowser.v;
                                if (fileSystemBrowserUIData != null)
                                {
                                    FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
                                    if (fileSystemBrowser != null)
                                    {
                                        Action action = fileSystemBrowser.action.v;
                                        if (action != null)
                                        {
                                            if (action is ActionNone)
                                            {
                                                ActionNone actionNone = action as ActionNone;
                                                if (actionNone.selectFiles.vs.Count == 1)
                                                {
                                                    FileSystemInfo fileSystemInfo = actionNone.selectFiles.vs[0];
                                                    if (fileSystemInfo is FileInfo)
                                                    {
                                                        FileInfo fileInfo = fileSystemInfo as FileInfo;
                                                        if (fileInfo.Extension == Save.SaveExtension || fileInfo.Extension == Save.FenExtension)
                                                        {
                                                            saveFileInfo = fileInfo;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("action null: " + this);
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
                            if (saveFileInfo != null)
                            {
                                loadDataTask.save = null;
                                loadDataTask.file = saveFileInfo;
                                loadDataTask.state.v = LoadDataTask.TaskData.State.Load;
                            }
                            else
                            {
                                Debug.LogError("saveFileInfo null: " + this);
                            }
                        }
                        break;
                    case LoadDataTask.TaskData.State.Load:
                        break;
                    case LoadDataTask.TaskData.State.Success:
                        break;
                    case LoadDataTask.TaskData.State.Fail:
                        break;
                    default:
                        Debug.LogError("unknown state: " + loadDataTask.state.v + "; " + this);
                        break;
                }
            }
            else
            {
                Debug.LogError("loadDataTask null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnRecord()
    {
        if (this.data != null)
        {
            LoadRecordTask.TaskData loadRecordTask = this.data.loadRecordTask.v;
            if (loadRecordTask != null)
            {
                switch (loadRecordTask.state.v)
                {
                    case LoadRecordTask.TaskData.State.None:
                        {
                            // find fileInfo
                            FileInfo recordFileInfo = null;
                            {
                                FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.fileSystemBrowser.v;
                                if (fileSystemBrowserUIData != null)
                                {
                                    FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
                                    if (fileSystemBrowser != null)
                                    {
                                        Action action = fileSystemBrowser.action.v;
                                        if (action != null)
                                        {
                                            if (action is ActionNone)
                                            {
                                                ActionNone actionNone = action as ActionNone;
                                                if (actionNone.selectFiles.vs.Count == 1)
                                                {
                                                    FileSystemInfo fileSystemInfo = actionNone.selectFiles.vs[0];
                                                    if (fileSystemInfo is FileInfo)
                                                    {
                                                        FileInfo fileInfo = fileSystemInfo as FileInfo;
                                                        if (fileInfo.Extension == DataRecord.Extension)
                                                        {
                                                            recordFileInfo = fileInfo;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("action null: " + this);
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
                            if (recordFileInfo != null)
                            {
                                loadRecordTask.dataRecord = null;
                                loadRecordTask.file = recordFileInfo;
                                loadRecordTask.state.v = LoadRecordTask.TaskData.State.Load;
                            }
                            else
                            {
                                Debug.LogError("recordFileInfo null: " + this);
                            }
                        }
                        break;
                    case LoadRecordTask.TaskData.State.Load:
                        break;
                    case LoadRecordTask.TaskData.State.Success:
                        break;
                    case LoadRecordTask.TaskData.State.Fail:
                        break;
                    default:
                        Debug.LogError("unknown state: " + loadRecordTask.state.v + "; " + this);
                        break;
                }
            }
            else
            {
                Debug.LogError("loadDataTask null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}