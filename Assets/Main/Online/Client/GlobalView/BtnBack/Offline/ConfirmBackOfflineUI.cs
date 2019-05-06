using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ConfirmBackOfflineUI : UIBehavior<ConfirmBackOfflineUI.UIData>
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
                if (InputEvent.isBackEvent(e))
                {
                    ConfirmBackOfflineUI confirmBackOfflineUI = this.findCallBack<ConfirmBackOfflineUI>();
                    if (confirmBackOfflineUI != null)
                    {
                        confirmBackOfflineUI.onClickBtnCancel();
                    }
                    else
                    {
                        Debug.LogError("confirmBackOfflineUI null: " + this);
                    }
                    isProcess = true;
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        ConfirmBackOfflineUI confirmBackOfflineUI = this.findCallBack<ConfirmBackOfflineUI>();
                        if (confirmBackOfflineUI != null)
                        {
                            isProcess = confirmBackOfflineUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("confirmBackOfflineUI null: " + this);
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Confirm Back");

    public Text tvMessage;
    private static readonly TxtLanguage txtMessage = new TxtLanguage("Are you sure to back?");

    public Text tvConfirm;
    private static readonly TxtLanguage txtConfirm = new TxtLanguage("Confirm");

    public Text tvCancel;
    private static TxtLanguage txtCancel = new TxtLanguage("Cancel");

    static ConfirmBackOfflineUI()
    {
        txtTitle.add(Language.Type.vi, "Xác Nhận Thoát");
        txtMessage.add(Language.Type.vi, "Bạn có chắc chắn thoát không?");
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

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnConfirm, onClickBtnConfirm);
            UIUtils.SetButtonOnClick(btnCancel, onClickBtnCancel);
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
                    case KeyCode.F:
                        {
                            if (btnConfirm != null && btnConfirm.gameObject.activeInHierarchy && btnConfirm.interactable)
                            {
                                this.onClickBtnConfirm();
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

    public Button btnConfirm;

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnConfirm()
    {
        if (this.data != null)
        {
            AfterLoginMainBtnBackOfflineUI.UIData backOfflineUIData = this.data.findDataInParent<AfterLoginMainBtnBackOfflineUI.UIData>();
            if (backOfflineUIData != null)
            {
                backOfflineUIData.back();
            }
            else
            {
                Debug.LogError("backOfflineUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public Button btnCancel;

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnCancel()
    {
        if (this.data != null)
        {
            AfterLoginMainBtnBackOfflineUI.UIData backOfflineUIData = this.data.findDataInParent<AfterLoginMainBtnBackOfflineUI.UIData>();
            if (backOfflineUIData != null)
            {
                backOfflineUIData.confirmUI.v = null;
            }
            else
            {
                Debug.LogError("backOfflineUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}