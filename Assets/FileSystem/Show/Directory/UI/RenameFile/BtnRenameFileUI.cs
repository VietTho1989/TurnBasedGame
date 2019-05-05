using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
    public class BtnRenameFileUI : UIBehavior<BtnRenameFileUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<ShowDirectory>> showDirectory;

            public VP<RenameFileUI.UIData> renameFile;

            #region Constructor

            public enum Property
            {
                showDirectory,
                renameFile
            }

            public UIData() : base()
            {
                this.showDirectory = new VP<ReferenceData<ShowDirectory>>(this, (byte)Property.showDirectory, new ReferenceData<ShowDirectory>(null));
                this.renameFile = new VP<RenameFileUI.UIData>(this, (byte)Property.renameFile, null);
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // renameFile
                    if (!isProcess)
                    {
                        RenameFileUI.UIData renameFile = this.renameFile.v;
                        if (renameFile != null)
                        {
                            isProcess = renameFile.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("renameFile null: " + this);
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            BtnRenameFileUI btnRenameFileUI = this.findCallBack<BtnRenameFileUI>();
                            if (btnRenameFileUI != null)
                            {
                                isProcess = btnRenameFileUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("btnRenameFileUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtRename = new TxtLanguage("Rename");
        private static readonly TxtLanguage txtCannotRename = new TxtLanguage("Rename");

        static BtnRenameFileUI()
        {
            txtRename.add(Language.Type.vi, "Đổi Tên");
            txtCannotRename.add(Language.Type.vi, "Đổi Tên");
        }

        #endregion

        #region Refresh

        public Button btnRename;
        public Text tvRename;

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
                        if (btnRename != null && tvRename != null)
                        {
                            // find
                            bool canRename = false;
                            {
                                FileSystemBrowser fileSystemBrowser = showDirectory.findDataInParent<FileSystemBrowser>();
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
                                                canRename = true;
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
                            // process
                            if (canRename)
                            {
                                btnRename.interactable = true;
                                tvRename.text = txtRename.get();
                            }
                            else
                            {
                                btnRename.interactable = false;
                                tvRename.text = txtCannotRename.get();
                            }
                        }
                        else
                        {
                            Debug.LogError("btnRename, tvRename null: " + this);
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

        public RenameFileUI renameFilePrefab;

        private FileSystemBrowser fileSystemBrowser = null;

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
                    uiData.renameFile.allAddCallBack(this);
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
                // showDirectory
                {
                    if (data is ShowDirectory)
                    {
                        ShowDirectory showDirectory = data as ShowDirectory;
                        // Parent
                        {
                            DataUtils.addParentCallBack(showDirectory, this, ref this.fileSystemBrowser);
                        }
                        dirty = true;
                        return;
                    }
                    // Parent
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
                if (data is RenameFileUI.UIData)
                {
                    RenameFileUI.UIData renameFileUIData = data as RenameFileUI.UIData;
                    // UI
                    {
                        Transform renameFileContainer = null;
                        {
                            if (this.data != null)
                            {
                                ShowDirectoryUI.UIData showDirectoryUIData = this.data.findDataInParent<ShowDirectoryUI.UIData>();
                                if (showDirectoryUIData != null)
                                {
                                    ShowDirectoryUI showDirectoryUI = showDirectoryUIData.findCallBack<ShowDirectoryUI>();
                                    if (showDirectoryUI != null)
                                    {
                                        renameFileContainer = showDirectoryUI.renameFileContainer;
                                    }
                                    else
                                    {
                                        Debug.LogError("showDirectoryUI null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("showDirectoryUIData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("data null: " + this);
                            }
                        }
                        UIUtils.Instantiate(renameFileUIData, renameFilePrefab, renameFileContainer);
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
                    uiData.renameFile.allRemoveCallBack(this);
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
                // showDirectory
                {
                    if (data is ShowDirectory)
                    {
                        ShowDirectory showDirectory = data as ShowDirectory;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(showDirectory, this, ref this.fileSystemBrowser);
                        }
                        return;
                    }
                    // Parent
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
                if (data is RenameFileUI.UIData)
                {
                    RenameFileUI.UIData renameFileUIData = data as RenameFileUI.UIData;
                    // UI
                    {
                        renameFileUIData.removeCallBackAndDestroy(typeof(RenameFileUI));
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
                    case UIData.Property.renameFile:
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
                // showDirectory
                {
                    if (wrapProperty.p is ShowDirectory)
                    {
                        return;
                    }
                    // Parent
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
                                    {

                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + action.getType() + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
                if (wrapProperty.p is RenameFileUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnRenameFile()
        {
            if (this.data != null)
            {
                ShowDirectory showDirectory = this.data.showDirectory.v.data;
                if (showDirectory != null)
                {
                    // find select file
                    FileSystemInfo file = null;
                    {
                        FileSystemBrowser fileSystemBrowser = showDirectory.findDataInParent<FileSystemBrowser>();
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
                                        file = actionNone.selectFiles.vs[0];
                                    }
                                    else
                                    {
                                        Debug.LogError("Don't have 1 selected file: " + this);
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
                    // Process
                    if (file != null)
                    {
                        RenameFileUI.UIData renameFileUIData = this.data.renameFile.newOrOld<RenameFileUI.UIData>();
                        {
                            renameFileUIData.file.v = file;
                        }
                        this.data.renameFile.v = renameFileUIData;
                    }
                    else
                    {
                        this.data.renameFile.v = null;
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
}