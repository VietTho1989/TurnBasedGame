using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
    public class NewFolderUI : UIBehavior<NewFolderUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            #region Constructor

            public enum Property
            {

            }

            public UIData() : base()
            {

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
                            NewFolderUI newFolderUI = this.findCallBack<NewFolderUI>();
                            if (newFolderUI != null)
                            {
                                newFolderUI.onClickBtnCancel();
                            }
                            else
                            {
                                Debug.LogError("newFolderUI null: " + this);
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

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("New Folder");

        public Text lbName;
        private static readonly TxtLanguage txtName = new TxtLanguage("Name");

        public Text tvPlaceHolder;
        private static readonly TxtLanguage txtPlaceHolder = new TxtLanguage("Enter folder name...");

        public Text tvOK;
        private static readonly TxtLanguage txtOK = new TxtLanguage("OK");

        public Text tvCancel;
        private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

        static NewFolderUI()
        {
            txtTitle.add(Language.Type.vi, "Folder Mới");
            txtName.add(Language.Type.vi, "Tên");
            txtPlaceHolder.add(Language.Type.vi, "Gõ tên folder...");
            txtOK.add(Language.Type.vi, "Đồng Ý");
            txtCancel.add(Language.Type.vi, "Huỷ Bỏ");
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
                        if (lbName != null)
                        {
                            lbName.text = txtName.get();
                            Setting.get().setLabelTextSize(lbName);
                        }
                        else
                        {
                            Debug.LogError("lbName null: " + this);
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
                        if (tvOK != null)
                        {
                            tvOK.text = txtOK.get();
                        }
                        else
                        {
                            Debug.LogError("tvOK null: " + this);
                        }
                        if (tvCancel != null)
                        {
                            tvCancel.text = txtCancel.get();
                        }
                        else
                        {
                            Debug.LogError("tvCancel null: " + this);
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                // Setting
                {
                    Setting.get().addCallBack(this);
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

                }
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
                    case Setting.Property.contentTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnCancel()
        {
            if (this.data != null)
            {
                ShowDirectoryUI.UIData showDirectoryUIData = this.data.findDataInParent<ShowDirectoryUI.UIData>();
                if (showDirectoryUIData != null)
                {
                    showDirectoryUIData.newFolder.v = null;
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

        public void onClickBtnOk()
        {
            if (edtName != null)
            {
                if (this.data != null)
                {
                    string folderName = edtName.text;
                    // check fileName correct
                    bool isCorrect = true;
                    {
                        if (!string.IsNullOrEmpty(folderName))
                        {
                            foreach (char ch in Path.GetInvalidFileNameChars())
                            {
                                if (folderName.Contains("" + ch))
                                {
                                    isCorrect = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            isCorrect = false;
                        }
                    }
                    // process
                    if (isCorrect)
                    {
                        // get current directory
                        DirectoryInfo dir = null;
                        {
                            ShowDirectoryUI.UIData showDirectoryUIData = this.data.findDataInParent<ShowDirectoryUI.UIData>();
                            if (showDirectoryUIData != null)
                            {
                                ShowDirectory showDirectory = showDirectoryUIData.showDirectory.v.data;
                                if (showDirectory != null)
                                {
                                    dir = showDirectory.directory.v;
                                }
                                else
                                {
                                    Debug.LogError("showDirectory null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("showDirectoryUIData null: " + this);
                            }
                        }
                        // process
                        if (dir != null && dir.Exists)
                        {
                            string path = Path.Combine(dir.FullName, folderName);
                            try
                            {
                                DirectoryInfo newFolder = Directory.CreateDirectory(path);
                                Toast.showMessage("create file success");
                                // show folder
                                {
                                    FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.findDataInParent<FileSystemBrowserUI.UIData>();
                                    if (fileSystemBrowserUIData != null)
                                    {
                                        FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
                                        if (fileSystemBrowser != null)
                                        {
                                            fileSystemBrowser.selectFile(newFolder, false, true);
                                            fileSystemBrowser.refresh();
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
                                // close
                                {
                                    ShowDirectoryUI.UIData showDirectoryUIData = this.data.findDataInParent<ShowDirectoryUI.UIData>();
                                    if (showDirectoryUIData != null)
                                    {
                                        showDirectoryUIData.newFolder.v = null;
                                    }
                                    else
                                    {
                                        Debug.LogError("showDirectoryUIData null: " + this);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Debug.LogError(e);
                                Toast.showMessage("create file error");
                            }
                        }
                        else
                        {
                            Debug.LogError("dir null: " + this);
                        }
                    }
                    else
                    {
                        Toast.showMessage("File name not correct");
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
            else
            {
                Debug.LogError("edtName null: " + this);
            }
        }

    }
}