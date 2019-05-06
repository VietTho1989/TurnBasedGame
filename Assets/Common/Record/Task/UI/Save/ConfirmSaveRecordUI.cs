using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
    public class ConfirmSaveRecordUI : UIBehavior<ConfirmSaveRecordUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<FileInfo> fileInfo;

            #region Constructor

            public enum Property
            {
                fileInfo
            }

            public UIData() : base()
            {
                this.fileInfo = new VP<FileInfo>(this, (byte)Property.fileInfo, null);
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
                            ConfirmSaveRecordUI confirmSaveRecordUI = this.findCallBack<ConfirmSaveRecordUI>();
                            if (confirmSaveRecordUI != null)
                            {
                                confirmSaveRecordUI.onClickBtnCancel();
                            }
                            else
                            {
                                Debug.LogError("confirmSaveRecordUI null: " + this);
                            }
                            isProcess = true;
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ConfirmSaveRecordUI confirmSaveRecordUI = this.findCallBack<ConfirmSaveRecordUI>();
                            if (confirmSaveRecordUI != null)
                            {
                                isProcess = confirmSaveRecordUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("confirmSaveRecordUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Confirm Replace");

        public Text tvConfirm;
        private static readonly TxtLanguage txtConfirm = new TxtLanguage("Confirm");

        public Text tvCancel;
        private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

        private static readonly TxtLanguage txtMessage = new TxtLanguage("Are you sure to replace file");

        static ConfirmSaveRecordUI()
        {
            txtTitle.add(Language.Type.vi, "Xác Nhận Thay Thế");
            txtConfirm.add(Language.Type.vi, "Xác Nhận");
            txtCancel.add(Language.Type.vi, "Huỷ Bỏ");
            txtMessage.add(Language.Type.vi, "Bạn có chắc thay thế file");
        }

        #endregion

        #region Refresh

        public Text lbMessage;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    FileInfo fileInfo = this.data.fileInfo.v;
                    if (fileInfo != null)
                    {
                        // lbMessage
                        if (lbMessage != null)
                        {
                            lbMessage.text = txtMessage.get() + " " + this.data.fileInfo.v.Name + "?";
                        }
                        else
                        {
                            Debug.LogError("lbMessage null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("fileInfo null: " + this);
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
                    case UIData.Property.fileInfo:
                        dirty = true;
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public bool useShortKey(Event e)
        {
            bool isProcess = false;
            {
                if (e.isKey && e.type == EventType.KeyUp)
                {
                    switch (e.keyCode)
                    {
                        case KeyCode.O:
                            {
                                if (btnOK != null && btnOK.gameObject.activeInHierarchy && btnOK.interactable)
                                {
                                    this.onClickBtnOK();
                                    isProcess = true;
                                }
                                else
                                {
                                    Debug.LogError("cannot click");
                                }
                            }
                            break;
                        case KeyCode.C:
                            {
                                if (btnCancel != null && btnCancel.gameObject.activeInHierarchy && btnCancel.interactable)
                                {
                                    this.onClickBtnCancel();
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

        public Button btnCancel;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnCancel()
        {
            if (this.data != null)
            {
                SaveRecordUI.UIData saveRecordUIData = this.data.findDataInParent<SaveRecordUI.UIData>();
                if (saveRecordUIData != null)
                {
                    saveRecordUIData.confirmSave.v = null;
                }
                else
                {
                    Debug.LogError("saveRecordUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public Button btnOK;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnOK()
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
                    SaveRecordUI.UIData saveRecordUIData = this.data.findDataInParent<SaveRecordUI.UIData>();
                    if (saveRecordUIData != null)
                    {
                        // task
                        SaveRecordTask.TaskData saveRecord = saveRecordUIData.saveTask.v;
                        if (saveRecord != null)
                        {
                            if (saveRecord.state.v == SaveRecordTask.TaskData.State.None)
                            {
                                saveRecord.file = this.data.fileInfo.v;
                                saveRecord.dataRecord = dataRecord;
                                saveRecord.state.v = SaveRecordTask.TaskData.State.Save;
                            }
                            else
                            {
                                Debug.LogError("why not state none: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("saveData null: " + this);
                        }
                        // close
                        saveRecordUIData.confirmSave.v = null;
                    }
                    else
                    {
                        Debug.LogError("saveRecordUIData null: " + this);
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