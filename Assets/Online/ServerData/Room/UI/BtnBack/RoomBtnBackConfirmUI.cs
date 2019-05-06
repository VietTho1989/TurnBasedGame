using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RoomBtnBackConfirmUI : UIBehavior<RoomBtnBackConfirmUI.UIData>
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
                        RoomBtnBackConfirmUI roomBtnBackConfirmUI = this.findCallBack<RoomBtnBackConfirmUI>();
                        if (roomBtnBackConfirmUI != null)
                        {
                            roomBtnBackConfirmUI.onClickBtnCancel();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("roomBtnBackConfirmUI null: " + this);
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        RoomBtnBackConfirmUI roomBtnBackConfirmUI = this.findCallBack<RoomBtnBackConfirmUI>();
                        if (roomBtnBackConfirmUI != null)
                        {
                            isProcess = roomBtnBackConfirmUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("roomBtnBackConfirmUI null: " + this);
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

    public Text lbMessage;
    private static readonly TxtLanguage txtMessage = new TxtLanguage("Are you sure to leave the room?");

    public Text tvOK;
    private static readonly TxtLanguage txtOK = new TxtLanguage("OK");

    public Text tvCancel;
    private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

    static RoomBtnBackConfirmUI()
    {
        txtTitle.add(Language.Type.vi, "Xác nhận thoát");
        txtMessage.add(Language.Type.vi, "Bạn có chắc chắn thoát khỏi phòng?");
        txtOK.add(Language.Type.vi, "Đồng Ý");
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
                        lbTitle.text = txtTitle.get();
                    }
                    else
                    {
                        Debug.LogError("lbTitle null: " + this);
                    }
                    if (lbMessage != null)
                    {
                        lbMessage.text = txtMessage.get();
                    }
                    else
                    {
                        Debug.LogError("lbMessage null: " + this);
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
                // Debug.LogError("data null: " + this);
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
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnOK, onClickBtnOk);
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
                    case KeyCode.O:
                        {
                            if (btnOK != null && btnOK.gameObject.activeInHierarchy && btnOK.interactable)
                            {
                                this.onClickBtnOk();
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

    public Button btnOK;

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnOk()
    {
        if (this.data != null)
        {
            RoomBtnBackUI.UIData roomBtnBackUIData = this.data.findDataInParent<RoomBtnBackUI.UIData>();
            if (roomBtnBackUIData != null)
            {
                if (roomBtnBackUIData.state.v == RoomBtnBackUI.UIData.State.None)
                {
                    roomBtnBackUIData.state.v = RoomBtnBackUI.UIData.State.Request;
                    roomBtnBackUIData.confirm.v = null;
                }
                else
                {
                    Debug.LogError("you are requesting: " + this);
                }
            }
            else
            {
                Debug.LogError("roomBtnBackUIData null: " + this);
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
            RoomBtnBackUI.UIData roomBtnBackUIData = this.data.findDataInParent<RoomBtnBackUI.UIData>();
            if (roomBtnBackUIData != null)
            {
                roomBtnBackUIData.confirm.v = null;
            }
            else
            {
                Debug.LogError("roomBtnBackUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}