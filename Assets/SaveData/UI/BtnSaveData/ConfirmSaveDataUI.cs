using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class ConfirmSaveDataUI : UIBehavior<ConfirmSaveDataUI.UIData>
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
                        ConfirmSaveDataUI confirmSaveDataUI = this.findCallBack<ConfirmSaveDataUI>();
                        if (confirmSaveDataUI != null)
                        {
                            confirmSaveDataUI.onClickBtnCancel();
                        }
                        else
                        {
                            Debug.LogError("confirmSaveDataUI null: " + this);
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Confirm Replace");

    public Text tvConfirm;
    private static readonly TxtLanguage txtConfirm = new TxtLanguage("Confirm");

    public Text tvCancel;
    private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

    private static readonly TxtLanguage txtMessage = new TxtLanguage("Are you sure to replace file");

    static ConfirmSaveDataUI()
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

    public void onClickBtnCancel()
    {
        if (this.data != null)
        {
            BtnSaveDataUI.UIData btnSaveDataUIData = this.data.findDataInParent<BtnSaveDataUI.UIData>();
            if (btnSaveDataUIData != null)
            {
                btnSaveDataUIData.confirmSave.v = null;
            }
            else
            {
                Debug.LogError("btnSaveDataUIData null: " + this);
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
            BtnSaveDataUI.UIData btnSaveDataUIData = this.data.findDataInParent<BtnSaveDataUI.UIData>();
            if (btnSaveDataUIData != null)
            {
                // task
                SaveTask.TaskData saveData = btnSaveDataUIData.saveData.v;
                if (saveData != null)
                {
                    if (saveData.state.v == SaveTask.TaskData.State.None)
                    {
                        saveData.file = this.data.fileInfo.v;
                        // content
                        {
                            SaveUI.UIData saveUIData = this.data.findDataInParent<SaveUI.UIData>();
                            if (saveUIData != null)
                            {
                                SaveData newSaveData = new SaveData();
                                {
                                    newSaveData.data = DataUtils.cloneData(saveUIData.needSaveData.v.data);
                                }
                                saveData.save.content = newSaveData;
                            }
                            else
                            {
                                Debug.LogError("saveUIData null: " + this);
                            }
                        }
                        saveData.state.v = SaveTask.TaskData.State.Save;
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
                btnSaveDataUIData.confirmSave.v = null;
            }
            else
            {
                Debug.LogError("btnSaveDataUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}