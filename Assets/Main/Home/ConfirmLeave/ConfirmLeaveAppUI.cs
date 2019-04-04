using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ConfirmLeaveAppUI : UIBehavior<ConfirmLeaveAppUI.UIData>
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
                        ConfirmLeaveAppUI confirmLeaveAppUI = this.findCallBack<ConfirmLeaveAppUI>();
                        if (confirmLeaveAppUI != null)
                        {
                            confirmLeaveAppUI.onClickBtnCancel();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("confirmLeaveAppUI null");
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    public Text tvMessage;
    private static readonly TxtLanguage txtMessage = new TxtLanguage();

    public Text tvConfirm;
    private static readonly TxtLanguage txtConfirm = new TxtLanguage();

    public Text tvCancel;
    private static readonly TxtLanguage txtCancel = new TxtLanguage();

    static ConfirmLeaveAppUI()
    {
        txtTitle.add(Language.Type.vi, "Xác Nhận Thoát");
        txtMessage.add(Language.Type.vi, "Bạn có chắc chắn thoát không?");
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
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get("Confirm Quit");
                    }
                    else
                    {
                        Debug.LogError("lbTitle null");
                    }
                    if (tvMessage != null)
                    {
                        tvMessage.text = txtMessage.get("Are you sure to quit?");
                    }
                    else
                    {
                        Debug.LogError("tvMessage null");
                    }
                    if (tvConfirm != null)
                    {
                        tvConfirm.text = txtConfirm.get("Confirm");
                    }
                    else
                    {
                        Debug.LogError("tvConfirm null");
                    }
                    if (tvCancel != null)
                    {
                        tvCancel.text = txtCancel.get("Cancel");
                    }
                    else
                    {
                        Debug.LogError("tvCancel null");
                    }
                }
            }
            else
            {
                Debug.LogError("data null");
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
        if(data is UIData)
        {
            // Setting
            Setting.get().addCallBack(this);
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
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
                case Setting.Property.style:
                    break;
                case Setting.Property.confirmQuit:
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                case Setting.Property.defaultChosenGame:
                    break;
                case Setting.Property.defaultRoomName:
                    break;
                case Setting.Property.defaultChatRoomStyle:
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

    public void onClickBtnConfirm()
    {
        Application.Quit();
    }

    public void onClickBtnCancel()
    {
        if (this.data != null)
        {
            HomeUI.UIData homeUIData = this.data.findDataInParent<HomeUI.UIData>();
            if (homeUIData != null)
            {
                homeUIData.confirmLeave.v = null;
            }
            else
            {
                Debug.LogError("homeUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}