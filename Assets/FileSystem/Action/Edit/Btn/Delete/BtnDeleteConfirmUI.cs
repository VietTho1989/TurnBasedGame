using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
    public class BtnDeleteConfirmUI : UIBehavior<BtnDeleteConfirmUI.UIData>
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
                            BtnDeleteConfirmUI btnDeleteConfirmUI = this.findCallBack<BtnDeleteConfirmUI>();
                            if (btnDeleteConfirmUI != null)
                            {
                                btnDeleteConfirmUI.onClickBtnCancel();
                            }
                            else
                            {
                                Debug.LogError("btnDeleteConfirmUI null: " + this);
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Confirm Delete");

        public Text tvMessage;
        private static readonly TxtLanguage txtMessage = new TxtLanguage("Are you sure to delete files?");

        public Text tvConfirm;
        private static readonly TxtLanguage txtConfirm = new TxtLanguage("Confirm");

        public Text tvCancel;
        private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

        static BtnDeleteConfirmUI()
        {
            txtTitle.add(Language.Type.vi, "Xác Nhận Xoá");
            txtMessage.add(Language.Type.vi, "Bạn có chắc xoá file không?");
            txtConfirm.add(Language.Type.vi, "Xác Nhận");
            txtCancel.add(Language.Type.vi, "Huỷ Bỏ");
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
                    BtnDeleteUI.UIData btnDeleteUIData = this.data.findDataInParent<BtnDeleteUI.UIData>();
                    if (btnDeleteUIData != null)
                    {
                        // find needConfirm
                        bool needConfirm = false;
                        {
                            FileSystemBrowser fileSystemBrowser = btnDeleteUIData.fileSystemBrowser.v.data;
                            if (fileSystemBrowser != null)
                            {
                                if (fileSystemBrowser.action.v is ActionNone)
                                {
                                    ActionNone actionNone = fileSystemBrowser.action.v as ActionNone;
                                    if (actionNone.selectFiles.vs.Count > 0)
                                    {
                                        needConfirm = true;
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("fileSystemBrowser null: " + this);
                            }
                        }
                        // Process
                        if (!needConfirm)
                        {
                            btnDeleteUIData.btnDeleteConfirm.v = null;
                        }
                    }
                    else
                    {
                        Debug.LogError("btnDeleteUIData null: " + this);
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
                        if (tvMessage != null)
                        {
                            tvMessage.text = txtMessage.get();
                        }
                        else
                        {
                            Debug.LogError("tvMessage null: " + this);
                        }
                        if (tvConfirm != null)
                        {
                            tvConfirm.text = txtConfirm.get();
                        }
                        else
                        {
                            Debug.LogError("tvConfirm null: " + this);
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

        private BtnDeleteUI.UIData btnDeleteUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.btnDeleteUIData);
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
            // Parent
            {
                if (data is BtnDeleteUI.UIData)
                {
                    BtnDeleteUI.UIData btnDeleteUIData = data as BtnDeleteUI.UIData;
                    // Child
                    {
                        btnDeleteUIData.fileSystemBrowser.allAddCallBack(this);
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
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().removeCallBack(this);
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.btnDeleteUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Parent
            {
                if (data is BtnDeleteUI.UIData)
                {
                    BtnDeleteUI.UIData btnDeleteUIData = data as BtnDeleteUI.UIData;
                    // Child
                    {
                        btnDeleteUIData.fileSystemBrowser.allRemoveCallBack(this);
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
            // Parent
            {
                if (wrapProperty.p is BtnDeleteUI.UIData)
                {
                    switch ((BtnDeleteUI.UIData.Property)wrapProperty.n)
                    {
                        case BtnDeleteUI.UIData.Property.fileSystemBrowser:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case BtnDeleteUI.UIData.Property.btnDeleteConfirm:
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnCancel()
        {
            if (this.data != null)
            {
                BtnDeleteUI.UIData btnDeleteUIData = this.data.findDataInParent<BtnDeleteUI.UIData>();
                if (btnDeleteUIData != null)
                {
                    btnDeleteUIData.btnDeleteConfirm.v = null;
                }
                else
                {
                    Debug.LogError("btnDeleteUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onClickBtnConfirm()
        {
            if (this.data != null)
            {
                BtnDeleteUI.UIData btnDeleteUIData = this.data.findDataInParent<BtnDeleteUI.UIData>();
                if (btnDeleteUIData != null)
                {
                    // confirm
                    {
                        FileSystemBrowser fileSystemBrowser = btnDeleteUIData.fileSystemBrowser.v.data;
                        if (fileSystemBrowser != null)
                        {
                            Action action = fileSystemBrowser.action.v;
                            if (action != null)
                            {
                                if (action is ActionNone)
                                {
                                    ActionNone actionNone = action as ActionNone;
                                    if (actionNone.selectFiles.vs.Count > 0)
                                    {
                                        ActionEdit actionEdit = new ActionEdit();
                                        {
                                            actionEdit.uid = fileSystemBrowser.action.makeId();
                                            actionEdit.action.v = ActionEdit.Action.Delete;
                                            // state: ko can
                                            actionEdit.files.vs.AddRange(actionNone.selectFiles.vs);
                                            // destDir
                                            {
                                                // find
                                                DirectoryInfo destDir = null;
                                                {
                                                    if (fileSystemBrowser.show.v is SingleShow)
                                                    {
                                                        SingleShow singleShow = fileSystemBrowser.show.v as SingleShow;
                                                        // find showDirectory
                                                        ShowDirectory showDirectory = singleShow.showDirectory.v;
                                                        if (showDirectory != null)
                                                        {
                                                            destDir = showDirectory.directory.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("showDirectory null: " + this);
                                                        }
                                                    }
                                                }
                                                // set
                                                actionEdit.destDir.v = destDir;
                                            }
                                        }
                                        fileSystemBrowser.action.v = actionEdit;
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
                    btnDeleteUIData.btnDeleteConfirm.v = null;
                }
                else
                {
                    Debug.LogError("btnDeleteUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}