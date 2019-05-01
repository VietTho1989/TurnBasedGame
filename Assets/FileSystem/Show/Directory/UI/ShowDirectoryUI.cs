using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
    public class ShowDirectoryUI : UIBehavior<ShowDirectoryUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<ShowDirectory>> showDirectory;

            public VP<FileAdapter.UIData> fileAdapter;

            public VP<BtnPathAdapter.UIData> btnPathAdapter;

            #region History

            public VP<BtnBackWardUI.UIData> btnBackWard;
            public VP<BtnForWardUI.UIData> btnForWard;

            #endregion

            public VP<BtnPasteUI.UIData> btnPaste;

            public VP<NewFolderUI.UIData> newFolder;

            public VP<BtnRenameFileUI.UIData> btnRenameFile;

            #region Constructor

            public enum Property
            {
                showDirectory,
                fileAdapter,
                btnPathAdapter,
                btnBackWard,
                btnForWard,
                btnPaste,
                newFolder,
                btnRenameFile
            }

            public UIData() : base()
            {
                this.showDirectory = new VP<ReferenceData<ShowDirectory>>(this, (byte)Property.showDirectory, new ReferenceData<ShowDirectory>(null));
                this.fileAdapter = new VP<FileAdapter.UIData>(this, (byte)Property.fileAdapter, new FileAdapter.UIData());
                this.btnPathAdapter = new VP<BtnPathAdapter.UIData>(this, (byte)Property.btnPathAdapter, new BtnPathAdapter.UIData());
                // history
                {
                    this.btnBackWard = new VP<BtnBackWardUI.UIData>(this, (byte)Property.btnBackWard, new BtnBackWardUI.UIData());
                    this.btnForWard = new VP<BtnForWardUI.UIData>(this, (byte)Property.btnForWard, new BtnForWardUI.UIData());
                }
                this.btnPaste = new VP<BtnPasteUI.UIData>(this, (byte)Property.btnPaste, new BtnPasteUI.UIData());
                this.newFolder = new VP<NewFolderUI.UIData>(this, (byte)Property.newFolder, null);
                this.btnRenameFile = new VP<BtnRenameFileUI.UIData>(this, (byte)Property.btnRenameFile, new BtnRenameFileUI.UIData());
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // btnRenameFile
                    if (!isProcess)
                    {
                        BtnRenameFileUI.UIData btnRenameFile = this.btnRenameFile.v;
                        if (btnRenameFile != null)
                        {
                            isProcess = btnRenameFile.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("btnRenameFile null: " + this);
                        }
                    }
                    // newFolder
                    if (!isProcess)
                    {
                        NewFolderUI.UIData newFolder = this.newFolder.v;
                        if (newFolder != null)
                        {
                            isProcess = newFolder.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("newFolder null: " + this);
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text tvShowExplorer;
        private static readonly TxtLanguage txtShowExplorer = new TxtLanguage("Show Explorer");

        public Text tvRefresh;
        private static readonly TxtLanguage txtRefresh = new TxtLanguage("Refresh");

        public Text tvNewFolder;
        private static readonly TxtLanguage txtNewFolder = new TxtLanguage("New Folder");

        public Text tvFail;
        private static readonly TxtLanguage txtFail = new TxtLanguage("The directory cannot be accessed");

        static ShowDirectoryUI()
        {
            // txt
            {
                txtShowExplorer.add(Language.Type.vi, "Hiện Explorer");
                txtRefresh.add(Language.Type.vi, "Làm Mới");
                txtNewFolder.add(Language.Type.vi, "Folder Mới");
                txtFail.add(Language.Type.vi, "Đường dẫn không thể truy nhập");
            }
            // rect
            {
                // btnPathAdapterRect
                {
                    // anchoredPosition: (-90.0, -30.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (0.0, -60.0); offsetMax: (-180.0, -30.0); sizeDelta: (-180.0, 30.0);
                    btnPathAdapterRect.anchoredPosition = new Vector3(-90.0f, -30.0f, 0.0f);
                    btnPathAdapterRect.anchorMin = new Vector2(0.0f, 1.0f);
                    btnPathAdapterRect.anchorMax = new Vector2(1.0f, 1.0f);
                    btnPathAdapterRect.pivot = new Vector2(0.5f, 1.0f);
                    btnPathAdapterRect.offsetMin = new Vector2(0.0f, -60.0f);
                    btnPathAdapterRect.offsetMax = new Vector2(-180.0f, -30.0f);
                    btnPathAdapterRect.sizeDelta = new Vector2(-180.0f, 30.0f);
                }
                // btnBackWardRect
                {
                    // anchoredPosition: (-150.0, -30.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                    // offsetMin: (-180.0, -60.0); offsetMax: (-150.0, -30.0); sizeDelta: (30.0, 30.0);
                    btnBackWardRect.anchoredPosition = new Vector3(-150.0f, -30.0f);
                    btnBackWardRect.anchorMin = new Vector2(1.0f, 1.0f);
                    btnBackWardRect.anchorMax = new Vector2(1.0f, 1.0f);
                    btnBackWardRect.pivot = new Vector2(1.0f, 1.0f);
                    btnBackWardRect.offsetMin = new Vector2(-180.0f, -60.0f);
                    btnBackWardRect.offsetMax = new Vector2(-150.0f, -30.0f);
                    btnBackWardRect.sizeDelta = new Vector2(30.0f, 30.0f);
                }
                // btnForWardRect
                {
                    // anchoredPosition: (-120.0, -30.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                    // offsetMin: (-150.0, -60.0); offsetMax: (-120.0, -30.0); sizeDelta: (30.0, 30.0);
                    btnForWardRect.anchoredPosition = new Vector3(-120.0f, -30.0f, 0.0f);
                    btnForWardRect.anchorMin = new Vector2(1.0f, 1.0f);
                    btnForWardRect.anchorMax = new Vector2(1.0f, 1.0f);
                    btnForWardRect.pivot = new Vector2(1.0f, 1.0f);
                    btnForWardRect.offsetMin = new Vector2(-150.0f, -60.0f);
                    btnForWardRect.offsetMax = new Vector2(-120.0f, -30.0f);
                    btnForWardRect.sizeDelta = new Vector2(30.0f, 30.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Transform headerScrollView;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ShowDirectory showDirectory = this.data.showDirectory.v.data;
                    if (showDirectory != null)
                    {
                        // fileAdapter
                        {
                            FileAdapter.UIData fileAdapter = this.data.fileAdapter.v;
                            if (fileAdapter != null)
                            {
                                fileAdapter.showDirectory.v = new ReferenceData<ShowDirectory>(showDirectory);
                            }
                            else
                            {
                                Debug.LogError("fileAdapter null: " + this);
                            }
                        }
                        // btnPathAdapter
                        {
                            BtnPathAdapter.UIData btnPathAdapter = this.data.btnPathAdapter.v;
                            if (btnPathAdapter != null)
                            {
                                btnPathAdapter.showDirectory.v = new ReferenceData<ShowDirectory>(showDirectory);
                            }
                            else
                            {
                                Debug.LogError("btnPathAdapter null: " + this);
                            }
                        }
                        // failIndicator
                        {
                            if (tvFail != null)
                            {
                                tvFail.gameObject.SetActive(showDirectory.state.v == ShowDirectory.State.Fail);
                            }
                            else
                            {
                                Debug.LogError("failIndicator null: " + this);
                            }
                        }
                        // history
                        {
                            // btnBackWard
                            {
                                BtnBackWardUI.UIData btnBackWardUIData = this.data.btnBackWard.v;
                                if (btnBackWardUIData != null)
                                {
                                    btnBackWardUIData.directoryHistory.v = new ReferenceData<DirectoryHistory>(showDirectory.directoryHistory.v);
                                }
                                else
                                {
                                    Debug.LogError("btnBackWardUIData null: " + this);
                                }
                            }
                            // btnForWard
                            {
                                BtnForWardUI.UIData btnForWardUIData = this.data.btnForWard.v;
                                if (btnForWardUIData != null)
                                {
                                    btnForWardUIData.directoryHistory.v = new ReferenceData<DirectoryHistory>(showDirectory.directoryHistory.v);
                                }
                                else
                                {
                                    Debug.LogError("btnForWardUIData null: " + this);
                                }
                            }
                        }
                        // btnPaste
                        {
                            BtnPasteUI.UIData btnPasteUIData = this.data.btnPaste.v;
                            if (btnPasteUIData != null)
                            {
                                btnPasteUIData.showDirectory.v = new ReferenceData<ShowDirectory>(showDirectory);
                            }
                            else
                            {
                                Debug.LogError("btnPasteUIData null: " + this);
                            }
                        }
                        // btnRenameFile
                        {
                            BtnRenameFileUI.UIData btnRenameFile = this.data.btnRenameFile.v;
                            if (btnRenameFile != null)
                            {
                                btnRenameFile.showDirectory.v = new ReferenceData<ShowDirectory>(showDirectory);
                            }
                            else
                            {
                                Debug.LogError("btnRenameFile null: " + this);
                            }
                        }
                        // siblingIndex
                        {
                            if (headerScrollView != null)
                            {
                                headerScrollView.SetSiblingIndex(0);
                            }
                            else
                            {
                                Debug.LogError("headerScrollView null");
                            }
                            UIRectTransform.SetSiblingIndex(this.data.fileAdapter.v, 1);
                            if (tvFail != null)
                            {
                                tvFail.transform.SetSiblingIndex(2);
                            }
                            else
                            {
                                Debug.LogError("tvFail null");
                            }
                            UIRectTransform.SetSiblingIndex(this.data.btnPathAdapter.v, 3);
                            UIRectTransform.SetSiblingIndex(this.data.btnBackWard.v, 4);
                            UIRectTransform.SetSiblingIndex(this.data.btnForWard.v, 5);
                            if (renameFileContainer != null)
                            {
                                renameFileContainer.SetSiblingIndex(6);
                            }
                            else
                            {
                                Debug.LogError("renameFileContainer null");
                            }
                            UIRectTransform.SetSiblingIndex(this.data.newFolder.v, 7);
                        }
                        // txt
                        {
                            if (tvShowExplorer != null)
                            {
                                tvShowExplorer.text = txtShowExplorer.get();
                            }
                            else
                            {
                                Debug.LogError("tvShowExplorer null: " + this);
                            }
                            if (tvRefresh != null)
                            {
                                tvRefresh.text = txtRefresh.get();
                            }
                            else
                            {
                                Debug.LogError("tvRefresh null: " + this);
                            }
                            if (tvNewFolder != null)
                            {
                                tvNewFolder.text = txtNewFolder.get();
                            }
                            else
                            {
                                Debug.LogError("tvNewFolder null: " + this);
                            }
                            if (tvFail != null)
                            {
                                tvFail.text = txtFail.get();
                            }
                            else
                            {
                                Debug.LogError("tvFail null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("showDirectory null: " + this);
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

        public FileAdapter fileAdapterPrefab;
        private static readonly UIRectTransform fileAdapterRect = UIRectTransform.CreateFullRect(0, 0, 30, 0);

        public BtnPathAdapter btnPathAdapterPrefab;
        private static readonly UIRectTransform btnPathAdapterRect = new UIRectTransform();

        public BtnBackWardUI btnBackWardPrefab;
        private static readonly UIRectTransform btnBackWardRect = new UIRectTransform();

        public BtnForWardUI btnForWardPrefab;
        private static readonly UIRectTransform btnForWardRect = new UIRectTransform();

        #region btn

        public Transform btnContainer;

        public BtnPasteUI btnPastePrefab;
        private static readonly UIRectTransform btnPasteRect = GameBottomUI.CreateBtnRect(2);

        public BtnRenameFileUI btnRenameFilePrefab;
        private static readonly UIRectTransform btnRenameFileRect = GameBottomUI.CreateBtnRect(4);
        public Transform renameFileContainer;

        #endregion

        public NewFolderUI newFolerPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.showDirectory.allAddCallBack(this);
                    uiData.fileAdapter.allAddCallBack(this);
                    uiData.btnPathAdapter.allAddCallBack(this);
                    // History
                    {
                        uiData.btnBackWard.allAddCallBack(this);
                        uiData.btnForWard.allAddCallBack(this);
                    }
                    uiData.btnPaste.allAddCallBack(this);
                    uiData.newFolder.allAddCallBack(this);
                    uiData.btnRenameFile.allAddCallBack(this);
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
                if (data is ShowDirectory)
                {
                    dirty = true;
                    return;
                }
                if (data is FileAdapter.UIData)
                {
                    FileAdapter.UIData fileAdapterUIData = data as FileAdapter.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(fileAdapterUIData, fileAdapterPrefab, this.transform, fileAdapterRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is BtnPathAdapter.UIData)
                {
                    BtnPathAdapter.UIData btnPathAdapterUIData = data as BtnPathAdapter.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnPathAdapterUIData, btnPathAdapterPrefab, this.transform, btnPathAdapterRect);
                    }
                    dirty = true;
                    return;
                }
                // History
                {
                    if (data is BtnBackWardUI.UIData)
                    {
                        BtnBackWardUI.UIData btnBackWardUIData = data as BtnBackWardUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(btnBackWardUIData, btnBackWardPrefab, this.transform, btnBackWardRect);
                        }
                        dirty = true;
                        return;
                    }
                    if (data is BtnForWardUI.UIData)
                    {
                        BtnForWardUI.UIData btnForWardUIData = data as BtnForWardUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(btnForWardUIData, btnForWardPrefab, this.transform, btnForWardRect);
                        }
                        dirty = true;
                        return;
                    }
                }
                if (data is BtnPasteUI.UIData)
                {
                    BtnPasteUI.UIData btnPasteUIData = data as BtnPasteUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnPasteUIData, btnPastePrefab, btnContainer, btnPasteRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is NewFolderUI.UIData)
                {
                    NewFolderUI.UIData newFolderUIData = data as NewFolderUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(newFolderUIData, newFolerPrefab, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if (data is BtnRenameFileUI.UIData)
                {
                    BtnRenameFileUI.UIData btnRenameFileUIData = data as BtnRenameFileUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnRenameFileUIData, btnRenameFilePrefab, btnContainer, btnRenameFileRect);
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
                    uiData.showDirectory.allRemoveCallBack(this);
                    uiData.fileAdapter.allRemoveCallBack(this);
                    uiData.btnPathAdapter.allRemoveCallBack(this);
                    // History
                    {
                        uiData.btnBackWard.allRemoveCallBack(this);
                        uiData.btnForWard.allRemoveCallBack(this);
                    }
                    uiData.btnPaste.allRemoveCallBack(this);
                    uiData.newFolder.allRemoveCallBack(this);
                    uiData.btnRenameFile.allRemoveCallBack(this);
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
                if (data is ShowDirectory)
                {
                    return;
                }
                if (data is FileAdapter.UIData)
                {
                    FileAdapter.UIData fileAdapterUIData = data as FileAdapter.UIData;
                    // UI
                    {
                        fileAdapterUIData.removeCallBackAndDestroy(typeof(FileAdapter));
                    }
                    return;
                }
                if (data is BtnPathAdapter.UIData)
                {
                    BtnPathAdapter.UIData btnPathAdapterUIData = data as BtnPathAdapter.UIData;
                    // UI
                    {
                        btnPathAdapterUIData.removeCallBackAndDestroy(typeof(BtnPathAdapter));
                    }
                    return;
                }
                // History
                {
                    if (data is BtnBackWardUI.UIData)
                    {
                        BtnBackWardUI.UIData btnBackWardUIData = data as BtnBackWardUI.UIData;
                        // UI
                        {
                            btnBackWardUIData.removeCallBackAndDestroy(typeof(BtnBackWardUI));
                        }
                        return;
                    }
                    if (data is BtnForWardUI.UIData)
                    {
                        BtnForWardUI.UIData btnForWardUIData = data as BtnForWardUI.UIData;
                        // UI
                        {
                            btnForWardUIData.removeCallBackAndDestroy(typeof(BtnForWardUI));
                        }
                        return;
                    }
                }
                if (data is BtnPasteUI.UIData)
                {
                    BtnPasteUI.UIData btnPasteUIData = data as BtnPasteUI.UIData;
                    // UI
                    {
                        btnPasteUIData.removeCallBackAndDestroy(typeof(BtnPasteUI));
                    }
                    return;
                }
                if (data is NewFolderUI.UIData)
                {
                    NewFolderUI.UIData newFolderUIData = data as NewFolderUI.UIData;
                    // UI
                    {
                        newFolderUIData.removeCallBackAndDestroy(typeof(NewFolderUI));
                    }
                    return;
                }
                if (data is BtnRenameFileUI.UIData)
                {
                    BtnRenameFileUI.UIData btnRenameFileUIData = data as BtnRenameFileUI.UIData;
                    // UI
                    {
                        btnRenameFileUIData.removeCallBackAndDestroy(typeof(BtnRenameFileUI));
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
                    case UIData.Property.showDirectory:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.fileAdapter:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnPathAdapter:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnBackWard:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnForWard:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnPaste:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.newFolder:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnRenameFile:
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
                if (wrapProperty.p is ShowDirectory)
                {
                    switch ((ShowDirectory.Property)wrapProperty.n)
                    {
                        case ShowDirectory.Property.state:
                            dirty = true;
                            break;
                        case ShowDirectory.Property.directory:
                            break;
                        case ShowDirectory.Property.directoryHistory:
                            break;
                        case ShowDirectory.Property.files:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is FileAdapter.UIData)
                {
                    return;
                }
                if (wrapProperty.p is BtnPathAdapter.UIData)
                {
                    return;
                }
                // History
                {
                    if (wrapProperty.p is BtnBackWardUI.UIData)
                    {
                        return;
                    }
                    if (wrapProperty.p is BtnForWardUI.UIData)
                    {
                        return;
                    }
                }
                if (wrapProperty.p is BtnPasteUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is NewFolderUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is BtnRenameFileUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnShowExplorer()
        {
            if (this.data != null)
            {
                // find dir
                DirectoryInfo dir = null;
                {
                    ShowDirectory showDirectory = this.data.showDirectory.v.data;
                    if (showDirectory != null)
                    {
                        dir = showDirectory.directory.v;
                    }
                    else
                    {
                        Debug.LogError("showDirectory null: " + this);
                    }
                }
                // Process
                if (dir != null)
                {
                    OpenInFileBrowser.Open(dir.FullName);
                }
                else
                {
                    Debug.LogError("dir null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnRefresh()
        {
            if (this.data != null)
            {
                ShowDirectory showDirectory = this.data.showDirectory.v.data;
                if (showDirectory != null)
                {
                    showDirectory.state.v = ShowDirectory.State.Load;
                }
                else
                {
                    Debug.LogError("showDirectory null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnNewFolder()
        {
            if (this.data != null)
            {
                NewFolderUI.UIData newFolderUIData = this.data.newFolder.newOrOld<NewFolderUI.UIData>();
                {

                }
                this.data.newFolder.v = newFolderUIData;
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}