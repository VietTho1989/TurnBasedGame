using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
    public class BtnDeleteUI : UIBehavior<BtnDeleteUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<FileSystemBrowser>> fileSystemBrowser;

            public VP<BtnDeleteConfirmUI.UIData> btnDeleteConfirm;

            #region Constructor

            public enum Property
            {
                fileSystemBrowser,
                btnDeleteConfirm
            }

            public UIData() : base()
            {
                this.fileSystemBrowser = new VP<ReferenceData<FileSystemBrowser>>(this, (byte)Property.fileSystemBrowser, new ReferenceData<FileSystemBrowser>(null));
                this.btnDeleteConfirm = new VP<BtnDeleteConfirmUI.UIData>(this, (byte)Property.btnDeleteConfirm, null);
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // btnDeleteConfirm
                    if (!isProcess)
                    {
                        BtnDeleteConfirmUI.UIData btnDeleteConfirm = this.btnDeleteConfirm.v;
                        if (btnDeleteConfirm != null)
                        {
                            isProcess = btnDeleteConfirm.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("btnDeleteConfirm null: " + this);
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtDelete = new TxtLanguage("Delete");
        private static readonly TxtLanguage txtCannotDeleteNotSelect = new TxtLanguage("Delete");
        private static readonly TxtLanguage txtDeleting = new TxtLanguage("Deleting");

        private static readonly TxtLanguage txtDeletingFile = new TxtLanguage("Deleting");
        private static readonly TxtLanguage txtCancel = new TxtLanguage("cancel");
        private static readonly TxtLanguage txtDeletingCancel = new TxtLanguage("Deleting, cancel?");

        private static readonly TxtLanguage txtDeleteSuccess = new TxtLanguage("Delete success");

        private static readonly TxtLanguage txtDeleteFile = new TxtLanguage("Delete");
        private static readonly TxtLanguage txtFail = new TxtLanguage("fail");
        private static readonly TxtLanguage txtDeleteFail = new TxtLanguage("Delete fail");

        private static readonly TxtLanguage txtCannotDeleteDoingOtherAction = new TxtLanguage("Can't delete");

        static BtnDeleteUI()
        {
            txtDelete.add(Language.Type.vi, "Xoá");
            txtCannotDeleteNotSelect.add(Language.Type.vi, "Xoá");
            txtDeleting.add(Language.Type.vi, "Đang xoá");

            txtDeletingFile.add(Language.Type.vi, "Đang xoá");
            txtCancel.add(Language.Type.vi, "huỷ");
            txtDeletingCancel.add(Language.Type.vi, "Đang xoá, huỷ?");

            txtDeleteSuccess.add(Language.Type.vi, "Xoá thành công");

            txtDeleteFile.add(Language.Type.vi, "Xoá");
            txtFail.add(Language.Type.vi, "thất bại");
            txtDeleteFail.add(Language.Type.vi, "Xoá thất bại");

            txtCannotDeleteDoingOtherAction.add(Language.Type.vi, "Không thể xoá");
        }

        #endregion

        #region Refresh

        public Button btnDelete;
        public Text tvDelete;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    FileSystemBrowser fileSystemBrowser = this.data.fileSystemBrowser.v.data;
                    if (fileSystemBrowser != null)
                    {
                        if (btnDelete != null && tvDelete != null)
                        {
                            Action action = fileSystemBrowser.action.v;
                            if (action != null)
                            {
                                switch (action.getType())
                                {
                                    case Action.Type.None:
                                        {
                                            ActionNone actionNone = action as ActionNone;
                                            if (actionNone.selectFiles.vs.Count > 0)
                                            {
                                                btnDelete.interactable = true;
                                                tvDelete.text = txtDelete.get();
                                            }
                                            else
                                            {
                                                btnDelete.interactable = false;
                                                tvDelete.text = txtCannotDeleteNotSelect.get();
                                            }
                                        }
                                        break;
                                    case Action.Type.Edit:
                                        {
                                            ActionEdit actionEdit = action as ActionEdit;
                                            if (actionEdit.action.v == ActionEdit.Action.Delete)
                                            {
                                                ActionEdit.State state = actionEdit.state.v;
                                                if (state != null)
                                                {
                                                    switch (state.getType())
                                                    {
                                                        case ActionEdit.State.Type.Start:
                                                            {
                                                                btnDelete.interactable = false;
                                                                tvDelete.text = txtDeleting.get();
                                                            }
                                                            break;
                                                        case ActionEdit.State.Type.Process:
                                                            {
                                                                ActionEditProcess actionEditProcess = state as ActionEditProcess;
                                                                // set
                                                                {
                                                                    btnDelete.interactable = true;
                                                                    // txt
                                                                    {
                                                                        FileSystemInfo file = null;
                                                                        {
                                                                            if (actionEditProcess.files.vs.Count > 0)
                                                                            {
                                                                                file = actionEditProcess.files.vs[0];
                                                                            }
                                                                            else
                                                                            {
                                                                                Debug.LogError("Why don't have any file: " + this);
                                                                            }
                                                                        }
                                                                        if (file != null)
                                                                        {
                                                                            float percent = 0;
                                                                            {
                                                                                if (actionEdit.files.vs.Count > 0)
                                                                                {
                                                                                    percent = actionEditProcess.files.vs.Count / actionEdit.files.vs.Count;
                                                                                }
                                                                                else
                                                                                {
                                                                                    Debug.LogError("why actionEdit don't have any files: " + this);
                                                                                }
                                                                            }
                                                                            tvDelete.text = txtDeletingFile.get() + " " + file.Name + " (" + percent + "), " + txtCancel.get() + "?";
                                                                        }
                                                                        else
                                                                        {
                                                                            tvDelete.text = txtDeletingCancel.get();
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case ActionEdit.State.Type.Success:
                                                            {
                                                                btnDelete.interactable = false;
                                                                tvDelete.text = txtDeleteSuccess.get();
                                                            }
                                                            break;
                                                        case ActionEdit.State.Type.Fail:
                                                            {
                                                                ActionEditFail actionEditFail = state as ActionEditFail;
                                                                // Set
                                                                {
                                                                    btnDelete.interactable = false;
                                                                    // txt
                                                                    {
                                                                        // find fail file
                                                                        FileSystemInfo failFile = actionEditFail.failFile.v;
                                                                        // Process
                                                                        if (failFile != null)
                                                                        {
                                                                            tvDelete.text = txtDeleteFile.get() + " " + failFile.Name + " " + txtFail.get();
                                                                        }
                                                                        else
                                                                        {
                                                                            Debug.LogError("failFile null: " + this);
                                                                            tvDelete.text = txtDeleteFail.get();
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        default:
                                                            Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("staate null: " + this);
                                                }
                                            }
                                            else
                                            {
                                                btnDelete.interactable = false;
                                                tvDelete.text = txtCannotDeleteDoingOtherAction.get();
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + action.getType() + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("action null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("btnDelete, tvDelete null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("fileSystemBrowser null: " + this);
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

        public BtnDeleteConfirmUI btnDeleteConfirmPrefab;

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
                    uiData.btnDeleteConfirm.allAddCallBack(this);
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
                // FileSystemBrowser
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
                    {
                        if (data is Action)
                        {
                            Action action = data as Action;
                            // Child
                            {
                                switch (action.getType())
                                {
                                    case Action.Type.None:
                                        break;
                                    case Action.Type.Edit:
                                        {
                                            ActionEdit actionEdit = action as ActionEdit;
                                            actionEdit.state.allAddCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + action.getType() + "; " + this);
                                        break;
                                }
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is ActionEdit.State)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
                if (data is BtnDeleteConfirmUI.UIData)
                {
                    BtnDeleteConfirmUI.UIData btnDeleteConfirmUIData = data as BtnDeleteConfirmUI.UIData;
                    // UI
                    {
                        // find container
                        Transform btnDeleteConfirmContainer = null;
                        {
                            if (this.data != null)
                            {
                                FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.findDataInParent<FileSystemBrowserUI.UIData>();
                                if (fileSystemBrowserUIData != null)
                                {
                                    FileSystemBrowserUI fileSystemBrowserUI = fileSystemBrowserUIData.findCallBack<FileSystemBrowserUI>();
                                    if (fileSystemBrowserUI != null)
                                    {
                                        btnDeleteConfirmContainer = fileSystemBrowserUI.btnDeleteConfirmContainer;
                                    }
                                    else
                                    {
                                        Debug.LogError("fileSystemBrowserUI null: " + this);
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
                        UIUtils.Instantiate(btnDeleteConfirmUIData, btnDeleteConfirmPrefab, btnDeleteConfirmContainer);
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
                // fileSystemBrowser
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
                    {
                        if (data is Action)
                        {
                            Action action = data as Action;
                            // Child
                            {
                                switch (action.getType())
                                {
                                    case Action.Type.None:
                                        break;
                                    case Action.Type.Edit:
                                        {
                                            ActionEdit actionEdit = action as ActionEdit;
                                            actionEdit.state.allRemoveCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + action.getType() + "; " + this);
                                        break;
                                }
                            }
                            return;
                        }
                        // Child
                        if (data is ActionEdit.State)
                        {
                            return;
                        }
                    }
                }
                if (data is BtnDeleteConfirmUI.UIData)
                {
                    BtnDeleteConfirmUI.UIData btnDeleteConfirmUIData = data as BtnDeleteConfirmUI.UIData;
                    // UI
                    {
                        btnDeleteConfirmUIData.removeCallBackAndDestroy(typeof(BtnDeleteConfirmUI));
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
                    case UIData.Property.btnDeleteConfirm:
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
                // fileSystemBrowser
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
                    {
                        if (wrapProperty.p is Action)
                        {
                            Action action = wrapProperty.p as Action;
                            // Child
                            {
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
                                            switch ((ActionEdit.Property)wrapProperty.n)
                                            {
                                                case ActionEdit.Property.action:
                                                    dirty = true;
                                                    break;
                                                case ActionEdit.Property.state:
                                                    {
                                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                                        dirty = true;
                                                    }
                                                    break;
                                                case ActionEdit.Property.files:
                                                    dirty = true;
                                                    break;
                                                case ActionEdit.Property.destDir:
                                                    break;
                                                default:
                                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                    break;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + action.getType() + "; " + this);
                                        break;
                                }
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is ActionEdit.State)
                        {
                            ActionEdit.State state = wrapProperty.p as ActionEdit.State;
                            switch (state.getType())
                            {
                                case ActionEdit.State.Type.Start:
                                    {
                                        switch ((ActionEditStart.Property)wrapProperty.n)
                                        {
                                            default:
                                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                break;
                                        }
                                    }
                                    break;
                                case ActionEdit.State.Type.Process:
                                    {
                                        switch ((ActionEditProcess.Property)wrapProperty.n)
                                        {
                                            case ActionEditProcess.Property.state:
                                                dirty = true;
                                                break;
                                            case ActionEditProcess.Property.files:
                                                dirty = true;
                                                break;
                                            case ActionEditProcess.Property.successFiles:
                                                break;
                                            default:
                                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                break;
                                        }
                                    }
                                    break;
                                case ActionEdit.State.Type.Success:
                                    {
                                        switch ((ActionEditSuccess.Property)wrapProperty.n)
                                        {
                                            case ActionEditSuccess.Property.time:
                                                dirty = true;
                                                break;
                                            case ActionEditSuccess.Property.duration:
                                                dirty = true;
                                                break;
                                            case ActionEditSuccess.Property.successFiles:
                                                break;
                                            default:
                                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                break;
                                        }
                                    }
                                    break;
                                case ActionEdit.State.Type.Fail:
                                    {
                                        switch ((ActionEditFail.Property)wrapProperty.n)
                                        {
                                            case ActionEditFail.Property.failFile:
                                                dirty = true;
                                                break;
                                            case ActionEditFail.Property.successFiles:
                                                break;
                                            case ActionEditFail.Property.time:
                                                dirty = true;
                                                break;
                                            case ActionEditFail.Property.duration:
                                                dirty = true;
                                                break;
                                            default:
                                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                break;
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
                if (wrapProperty.p is BtnDeleteConfirmUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnDelete()
        {
            if (this.data != null)
            {
                FileSystemBrowser fileSystemBrowser = this.data.fileSystemBrowser.v.data;
                if (fileSystemBrowser != null)
                {
                    Action action = fileSystemBrowser.action.v;
                    if (action != null)
                    {
                        switch (action.getType())
                        {
                            case Action.Type.None:
                                {
                                    ActionNone actionNone = action as ActionNone;
                                    if (actionNone.selectFiles.vs.Count > 0)
                                    {
                                        BtnDeleteConfirmUI.UIData btnDeleteConfirmUIData = this.data.btnDeleteConfirm.newOrOld<BtnDeleteConfirmUI.UIData>();
                                        {

                                        }
                                        this.data.btnDeleteConfirm.v = btnDeleteConfirmUIData;
                                    }
                                    else
                                    {
                                        Debug.LogError("Don't select any files");
                                    }
                                }
                                break;
                            case Action.Type.Edit:
                                {
                                    ActionEdit actionEdit = action as ActionEdit;
                                    if (actionEdit.action.v == ActionEdit.Action.Delete)
                                    {
                                        ActionEdit.State state = actionEdit.state.v;
                                        if (state != null)
                                        {
                                            switch (state.getType())
                                            {
                                                case ActionEdit.State.Type.Start:
                                                    {
                                                        // TODO Co lam gi khong nhi?
                                                    }
                                                    break;
                                                case ActionEdit.State.Type.Process:
                                                    {
                                                        ActionEditProcess actionEditProcess = state as ActionEditProcess;
                                                        // stop
                                                        {
                                                            ActionEditProcessUpdate actionEditProcessUpdate = actionEditProcess.findCallBack<ActionEditProcessUpdate>();
                                                            if (actionEditProcessUpdate != null)
                                                            {
                                                                actionEditProcessUpdate.stop = true;
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("actionEditProcessUpdate null: " + this);
                                                            }
                                                        }
                                                    }
                                                    break;
                                                case ActionEdit.State.Type.Success:
                                                    break;
                                                case ActionEdit.State.Type.Fail:
                                                    break;
                                                default:
                                                    Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("staate null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        // other action
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + action.getType() + "; " + this);
                                break;
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
                Debug.LogError("data null: " + this);
            }
        }

    }
}