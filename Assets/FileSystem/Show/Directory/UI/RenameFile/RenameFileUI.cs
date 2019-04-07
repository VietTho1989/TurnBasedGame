using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
    public class RenameFileUI : UIBehavior<RenameFileUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<FileSystemInfo> file;

            #region name

            public VP<RequestChangeStringUI.UIData> name;

            public void makeRequestChangeName(RequestChangeUpdate<string>.UpdateData update, string newName)
            {

            }

            #endregion

            #region Constructor

            public enum Property
            {
                file,
                name
            }

            public UIData() : base()
            {
                this.file = new VP<FileSystemInfo>(this, (byte)Property.file, null);
                // name
                {
                    this.name = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.name, new RequestChangeStringUI.UIData());
                    this.name.v.updateData.v.canRequestChange.v = true;
                    // this.name.v.updateData.v.request.v = makeRequestChangeName;
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
                            RenameFileUI renameFileUI = this.findCallBack<RenameFileUI>();
                            if (renameFileUI != null)
                            {
                                renameFileUI.onClickBtnCancel();
                            }
                            else
                            {
                                Debug.LogError("renameFileUI null: " + this);
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Rename File");

        public Text lbName;
        private static readonly TxtLanguage txtName = new TxtLanguage("New name");

        public Text tvOK;
        private static readonly TxtLanguage txtOK = new TxtLanguage("OK");

        public Text tvCancel;
        private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

        static RenameFileUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Đổi Tên File");
                txtName.add(Language.Type.vi, "Tên mới");
                txtOK.add(Language.Type.vi, "Đồng Ý");
                txtCancel.add(Language.Type.vi, "Huỷ Bỏ");
            }
            // rect
            {
                // nameRect
                {
                    // anchoredPosition: (40.0, -35.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (90.0, -65.0); offsetMax: (-10.0, -35.0); sizeDelta: (-100.0, 30.0);
                    nameRect.anchoredPosition = new Vector3(40.0f, -35.0f, 0.0f);
                    nameRect.anchorMin = new Vector2(0.0f, 1.0f);
                    nameRect.anchorMax = new Vector2(1.0f, 1.0f);
                    nameRect.pivot = new Vector2(0.5f, 1.0f);
                    nameRect.offsetMin = new Vector2(90.0f, -65.0f);
                    nameRect.offsetMax = new Vector2(-10.0f, -35.0f);
                    nameRect.sizeDelta = new Vector2(-100.0f, 30.0f);
                }
            }
        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    FileSystemInfo file = this.data.file.v;
                    if (file != null)
                    {
                        Server.State.Type serverState = Server.State.Type.Connect;
                        // origin
                        {
                            // name
                            {
                                RequestChangeStringUI.UIData name = this.data.name.v;
                                if (name != null)
                                {
                                    // update
                                    RequestChangeUpdate<string>.UpdateData updateData = name.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.origin.v = file.Name;
                                        updateData.canRequestChange.v = true;
                                        updateData.serverState.v = serverState;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                    // compare
                                    {
                                        name.showDifferent.v = true;
                                        name.compare.v = file.Name;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("filter null: " + this);
                                }
                            }
                        }
                        // ret
                        if (needReset)
                        {
                            needReset = false;
                            // name
                            {
                                RequestChangeStringUI.UIData name = this.data.name.v;
                                if (name != null)
                                {
                                    // update
                                    RequestChangeUpdate<string>.UpdateData updateData = name.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = file.Name;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("filter null: " + this);
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("file null: " + this);
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
                        if (lbName != null)
                        {
                            lbName.text = txtName.get();
                        }
                        else
                        {
                            Debug.LogError("lbName null: " + this);
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

        public RequestChangeStringUI requestStringPrefab;
        public Transform contentContainer;
        private static readonly UIRectTransform nameRect = new UIRectTransform();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.name.allAddCallBack(this);
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
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.name:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, contentContainer, nameRect);
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("wrapProperty null: " + this);
                    }
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
                    uiData.name.allRemoveCallBack(this);
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
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeStringUI));
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
                    case UIData.Property.file:
                        dirty = true;
                        break;
                    case UIData.Property.name:
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
            if (wrapProperty.p is RequestChangeStringUI.UIData)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnCancel()
        {
            if (this.data != null)
            {
                BtnRenameFileUI.UIData btnRenameFileUIData = this.data.findDataInParent<BtnRenameFileUI.UIData>();
                if (btnRenameFileUIData != null)
                {
                    btnRenameFileUIData.renameFile.v = null;
                }
                else
                {
                    Debug.LogError("btnRenameFileUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onClickBtnOK()
        {
            if (this.data != null)
            {
                FileSystemInfo file = this.data.file.v;
                if (file != null)
                {
                    string newName = "";
                    {
                        RequestChangeStringUI.UIData name = this.data.name.v;
                        if (name != null)
                        {
                            newName = name.updateData.v.current.v;
                        }
                        else
                        {
                            Debug.LogError("name null: " + this);
                        }
                    }
                    if (!string.IsNullOrEmpty(newName))
                    {
                        try
                        {
                            FileSystemInfo newFile = null;
                            // fileInfo
                            if (file is FileInfo)
                            {
                                FileInfo fileInfo = file as FileInfo;
                                // rename
                                {
                                    string sourcePath = fileInfo.FullName;
                                    string directory = Path.GetDirectoryName(sourcePath);
                                    string destinationPath = Path.Combine(directory, newName);
                                    File.Move(sourcePath, destinationPath);
                                    newFile = new FileInfo(destinationPath);
                                }
                            }
                            // directoryInfo
                            else if (file is DirectoryInfo)
                            {
                                DirectoryInfo directoryInfor = file as DirectoryInfo;
                                // rename
                                {
                                    DirectoryInfo parent = directoryInfor.Parent;
                                    if (parent != null)
                                    {
                                        string sourcePath = directoryInfor.FullName;
                                        string directory = parent.FullName;
                                        string destinationPath = Path.Combine(directory, newName);
                                        Directory.Move(sourcePath, destinationPath);
                                        newFile = new DirectoryInfo(destinationPath);
                                    }
                                    else
                                    {
                                        Debug.LogError("parent null: " + this);
                                    }
                                }
                            }
                            // rename file success
                            {
                                Toast.showMessage("rename file success");
                                // refresh
                                {
                                    FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.findDataInParent<FileSystemBrowserUI.UIData>();
                                    if (fileSystemBrowserUIData != null)
                                    {
                                        FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
                                        if (fileSystemBrowser != null)
                                        {
                                            fileSystemBrowser.refresh();
                                            fileSystemBrowser.selectFile(newFile, false, true);
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
                                    BtnRenameFileUI.UIData btnRenameFileUIData = this.data.findDataInParent<BtnRenameFileUI.UIData>();
                                    if (btnRenameFileUIData != null)
                                    {
                                        btnRenameFileUIData.renameFile.v = null;
                                    }
                                    else
                                    {
                                        Debug.LogError("btnRenameFileUIData null: " + this);
                                    }
                                }
                            }
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogError(e);
                            Toast.showMessage("Erorr, cannot rename file");
                        }
                    }
                    else
                    {
                        Toast.showMessage("Error, empty name");
                        Debug.LogError("newName null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("file null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}