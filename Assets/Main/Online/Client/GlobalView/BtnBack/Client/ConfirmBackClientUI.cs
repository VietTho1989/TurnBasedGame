using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ConfirmBackClientUI : UIBehavior<ConfirmBackClientUI.UIData>
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
                        ConfirmBackClientUI confirmBackClientUI = this.findCallBack<ConfirmBackClientUI>();
                        if (confirmBackClientUI != null)
                        {
                            confirmBackClientUI.onClickBtnCancel();
                        }
                        else
                        {
                            Debug.LogError("confirmBackClientUI null: " + this);
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Confirm Logout");

    public Text tvMessage;
    private static readonly TxtLanguage txtMessage = new TxtLanguage("Are you sure to logout?");

    public Text tvConfirm;
    private static readonly TxtLanguage txtConfirm = new TxtLanguage("Confirm");

    public Text tvCancel;
    private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

    static ConfirmBackClientUI()
    {
        txtTitle.add(Language.Type.vi, "Xác Nhận Đăng Xuất");
        txtMessage.add(Language.Type.vi, "Bạn có chắc đăng xuất không?");
        txtConfirm.add(Language.Type.vi, "Xác nhận");
        txtCancel.add(Language.Type.vi, "Huỷ bỏ");
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
                if (lbTitle != null)
                {
                    lbTitle.text = txtTitle.get();
                }
                else
                {
                    Debug.LogError("lbTitle null");
                }
                if (tvMessage != null)
                {
                    tvMessage.text = txtMessage.get();
                }
                else
                {
                    Debug.LogError("tvMessage null");
                }
                if (tvConfirm != null)
                {
                    tvConfirm.text = txtConfirm.get();
                }
                else
                {
                    Debug.LogError("tvConfirm null");
                }
                if (tvCancel != null)
                {
                    tvCancel.text = txtCancel.get();
                }
                else
                {
                    Debug.LogError("tvCancel null");
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
        // Child
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
            {
                Setting.get().removeCallBack(this);
            }
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
    }

    #endregion

    public void onClickBtnConfirm()
    {
        if (this.data != null)
        {
            AfterLoginMainBtnBackClientUI.UIData backClientUIData = this.data.findDataInParent<AfterLoginMainBtnBackClientUI.UIData>();
            if (backClientUIData != null)
            {
                backClientUIData.back();
            }
            else
            {
                Debug.LogError("backClientUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public void onClickBtnCancel()
    {
        if (this.data != null)
        {
            AfterLoginMainBtnBackClientUI.UIData backClientUIData = this.data.findDataInParent<AfterLoginMainBtnBackClientUI.UIData>();
            if (backClientUIData != null)
            {
                backClientUIData.confirmUI.v = null;
            }
            else
            {
                Debug.LogError("backClientUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}