using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
    public class BtnCutUI : UIBehavior<BtnCutUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<FileSystemBrowser>> fileSystemBrowser;

            #region Constructor

            public enum Property
            {
                fileSystemBrowser
            }

            public UIData() : base()
            {
                this.fileSystemBrowser = new VP<ReferenceData<FileSystemBrowser>>(this, (byte)Property.fileSystemBrowser, new ReferenceData<FileSystemBrowser>(null));
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            BtnCutUI btnCutUI = this.findCallBack<BtnCutUI>();
                            if (btnCutUI != null)
                            {
                                isProcess = btnCutUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("btnCutUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtCannotCutNotSelect = new TxtLanguage("Cut");
        private static readonly TxtLanguage txtCut = new TxtLanguage("Cut");
        private static readonly TxtLanguage txtAlreadySelectCutCancel = new TxtLanguage("Cancel select cut");
        private static readonly TxtLanguage txtCutting = new TxtLanguage("Cutting");

        private static readonly TxtLanguage txtCuttingFile = new TxtLanguage("Cutting");
        private static readonly TxtLanguage txtCancel = new TxtLanguage("cancel");
        private static readonly TxtLanguage txtCuttingCancel = new TxtLanguage("Cancel cutting");

        private static readonly TxtLanguage txtCutSuccess = new TxtLanguage("Cut success");

        private static readonly TxtLanguage txtCutFile = new TxtLanguage("Cut");
        private static readonly TxtLanguage txtFail = new TxtLanguage("fail");
        private static readonly TxtLanguage txtCutFail = new TxtLanguage("Cut fail");

        private static readonly TxtLanguage txtCannotCutDoingOtherAction = new TxtLanguage("Cannot cut");

        static BtnCutUI()
        {
            txtCannotCutNotSelect.add(Language.Type.vi, "Cắt");
            txtCut.add(Language.Type.vi, "Cắt");
            txtAlreadySelectCutCancel.add(Language.Type.vi, "Huỷ chọn cắt");
            txtCutting.add(Language.Type.vi, "Đang cắt");

            txtCuttingFile.add(Language.Type.vi, "Đang cắt");
            txtCancel.add(Language.Type.vi, "huỷ");
            txtCuttingCancel.add(Language.Type.vi, "Huỷ cắt");

            txtCutSuccess.add(Language.Type.vi, "Cắt thành công");

            txtCutFile.add(Language.Type.vi, "Cắt");
            txtFail.add(Language.Type.vi, "thất bại");
            txtCutFail.add(Language.Type.vi, "Cắt thất bại");

            txtCannotCutDoingOtherAction.add(Language.Type.vi, "Không thể cắt");
        }

        #endregion

        #region Refresh

        public Button btnCut;
        public Text tvCut;

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
                        if (btnCut != null && tvCut != null)
                        {
                            Action action = fileSystemBrowser.action.v;
                            if (action != null)
                            {
                                switch (action.getType())
                                {
                                    case Action.Type.None:
                                        {
                                            ActionNone actionNone = action as ActionNone;
                                            if (actionNone.selectFiles.vs.Count == 0)
                                            {
                                                btnCut.interactable = false;
                                                tvCut.text = txtCannotCutNotSelect.get();
                                            }
                                            else
                                            {
                                                switch (actionNone.state.v)
                                                {
                                                    case ActionNone.State.None:
                                                        {
                                                            btnCut.interactable = true;
                                                            tvCut.text = txtCut.get();
                                                        }
                                                        break;
                                                    case ActionNone.State.Cut:
                                                        {
                                                            btnCut.interactable = true;
                                                            tvCut.text = txtAlreadySelectCutCancel.get();
                                                        }
                                                        break;
                                                    case ActionNone.State.Copy:
                                                        {
                                                            btnCut.interactable = true;
                                                            tvCut.text = txtCut.get();
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown state: " + actionNone.state.v + "; " + this);
                                                        break;
                                                }
                                            }
                                        }
                                        break;
                                    case Action.Type.Edit:
                                        {
                                            ActionEdit actionEdit = action as ActionEdit;
                                            if (actionEdit.action.v == ActionEdit.Action.Cut)
                                            {
                                                ActionEdit.State state = actionEdit.state.v;
                                                if (state != null)
                                                {
                                                    switch (state.getType())
                                                    {
                                                        case ActionEdit.State.Type.Start:
                                                            {
                                                                btnCut.interactable = false;
                                                                tvCut.text = txtCutting.get();
                                                            }
                                                            break;
                                                        case ActionEdit.State.Type.Process:
                                                            {
                                                                ActionEditProcess actionEditProcess = state as ActionEditProcess;
                                                                // set
                                                                {
                                                                    btnCut.interactable = true;
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
                                                                            tvCut.text = txtCuttingFile.get() + " " + file.Name + " (" + percent + "), " + txtCancel.get() + "?";
                                                                        }
                                                                        else
                                                                        {
                                                                            tvCut.text = txtCuttingCancel.get();
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case ActionEdit.State.Type.Success:
                                                            {
                                                                btnCut.interactable = false;
                                                                tvCut.text = txtCutSuccess.get();
                                                            }
                                                            break;
                                                        case ActionEdit.State.Type.Fail:
                                                            {
                                                                ActionEditFail actionEditFail = state as ActionEditFail;
                                                                // Set
                                                                {
                                                                    btnCut.interactable = false;
                                                                    // txt
                                                                    {
                                                                        // find fail file
                                                                        FileSystemInfo failFile = actionEditFail.failFile.v;
                                                                        // Process
                                                                        if (failFile != null)
                                                                        {
                                                                            tvCut.text = txtCutFile.get() + " " + failFile.Name + " " + txtFail.get();
                                                                        }
                                                                        else
                                                                        {
                                                                            Debug.LogError("failFile null: " + this);
                                                                            tvCut.text = txtCutFail.get();
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
                                                btnCut.interactable = false;
                                                tvCut.text = txtCannotCutDoingOtherAction.get();
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
                            Debug.LogError("btnCut, tvCut null: " + this);
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
            if (data is Setting)
            {
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
                                                dirty = true;
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
                                            dirty = true;
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
                                            dirty = true;
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
                                            dirty = true;
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {
                UIUtils.SetButtonOnClick(btnCut, onClickBtnCut);
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
                                if (btnCut != null && btnCut.gameObject.activeInHierarchy && btnCut.interactable)
                                {
                                    this.onClickBtnCut();
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
        public void onClickBtnCut()
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
                                    if (actionNone.selectFiles.vs.Count == 0)
                                    {
                                        // Don't select any file
                                    }
                                    else
                                    {
                                        switch (actionNone.state.v)
                                        {
                                            case ActionNone.State.None:
                                                {
                                                    actionNone.state.v = ActionNone.State.Cut;
                                                }
                                                break;
                                            case ActionNone.State.Cut:
                                                {
                                                    actionNone.state.v = ActionNone.State.None;
                                                }
                                                break;
                                            case ActionNone.State.Copy:
                                                {
                                                    actionNone.state.v = ActionNone.State.Cut;
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown state: " + actionNone.state.v + "; " + this);
                                                break;
                                        }
                                    }
                                }
                                break;
                            case Action.Type.Edit:
                                {
                                    ActionEdit actionEdit = action as ActionEdit;
                                    if (actionEdit.action.v == ActionEdit.Action.Cut)
                                    {
                                        ActionEdit.State state = actionEdit.state.v;
                                        if (state != null)
                                        {
                                            switch (state.getType())
                                            {
                                                case ActionEdit.State.Type.Start:
                                                    {

                                                    }
                                                    break;
                                                case ActionEdit.State.Type.Process:
                                                    {
                                                        ActionEditProcess actionEditProcess = state as ActionEditProcess;
                                                        // cancel
                                                        {
                                                            ActionEditProcessUpdate actionEditProcessUpdate = actionEditProcess.findCallBack<ActionEditProcessUpdate>();
                                                            if (actionEditProcessUpdate != null)
                                                            {
                                                                actionEditProcessUpdate.stop = true;
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("actionEditProcessUpdate null");
                                                            }
                                                        }
                                                    }
                                                    break;
                                                case ActionEdit.State.Type.Success:
                                                    {

                                                    }
                                                    break;
                                                case ActionEdit.State.Type.Fail:
                                                    {

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