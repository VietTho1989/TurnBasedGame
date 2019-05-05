using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ConfirmBackServerUI : UIBehavior<ConfirmBackServerUI.UIData>
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
                        ConfirmBackServerUI confirmBackServerUI = this.findCallBack<ConfirmBackServerUI>();
                        if (confirmBackServerUI != null)
                        {
                            confirmBackServerUI.onClickBtnCancel();
                        }
                        else
                        {
                            Debug.LogError("confirmBackServerUI null: " + this);
                        }
                        isProcess = true;
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        ConfirmBackServerUI confirmBackServerUI = this.findCallBack<ConfirmBackServerUI>();
                        if (confirmBackServerUI != null)
                        {
                            isProcess = confirmBackServerUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("confirmBackServerUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region Txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Confirm Back");

    public Text tvMessage;
    private static readonly TxtLanguage txtMessage = new TxtLanguage("Are you sure to back?");

    public Text tvConfirm;
    private static readonly TxtLanguage txtConfirm = new TxtLanguage("Confirm");

    public Text tvCancel;
    private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

    static ConfirmBackServerUI()
    {
        txtTitle.add(Language.Type.vi, "Xác Nhận Thoát");
        txtMessage.add(Language.Type.vi, "Bạn có chắc chắn thoát?");
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
            {
                Setting.get().removeCallBack(this);
            }
            // Child
            {

            }
            this.setDataNull(uiData);
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

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnConfirm()
    {
        if (this.data != null)
        {
            AfterLoginMainBtnBackServerUI.UIData backServerUIData = this.data.findDataInParent<AfterLoginMainBtnBackServerUI.UIData>();
            if (backServerUIData != null)
            {
                backServerUIData.back();
            }
            else
            {
                Debug.LogError("backServerUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnCancel()
    {
        if (this.data != null)
        {
            AfterLoginMainBtnBackServerUI.UIData backServerUIData = this.data.findDataInParent<AfterLoginMainBtnBackServerUI.UIData>();
            if (backServerUIData != null)
            {
                backServerUIData.confirmUI.v = null;
            }
            else
            {
                Debug.LogError("backServerUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}