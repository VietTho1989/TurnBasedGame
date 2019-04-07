using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClientInputSendUI : UIBehavior<ClientInputSendUI.UIData>
{

    #region UIData

    public class UIData : ClientInputUI.UIData.Sub
    {

        public VP<ReferenceData<ClientInputSend>> clientInputSend;

        #region Constructor

        public enum Property
        {
            clientInputSend
        }

        public UIData() : base()
        {
            this.clientInputSend = new VP<ReferenceData<ClientInputSend>>(this, (byte)Property.clientInputSend, new ReferenceData<ClientInputSend>(null));
        }

        #endregion

        public override ClientInput.Sub.Type getType()
        {
            return ClientInput.Sub.Type.Send;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Sending move");

    public Text tvCancel;
    private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

    static ClientInputSendUI()
    {
        txtTitle.add(Language.Type.vi, "Đang gửi nước đi");
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
                // Debug.LogError ("data null: " + this);
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
                uiData.clientInputSend.allAddCallBack(this);
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
        if (data is ClientInputSend)
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
                uiData.clientInputSend.allRemoveCallBack(this);
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
        if (data is ClientInputSend)
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
                case UIData.Property.clientInputSend:
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
        if (wrapProperty.p is ClientInputSend)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnCancelSend()
    {
        Debug.LogError("onClickBtnSend: " + this);
        if (this.data != null)
        {
            ClientInputSend clientInputSend = this.data.clientInputSend.v.data;
            if (clientInputSend != null)
            {
                ClientInput clientInput = clientInputSend.findDataInParent<ClientInput>();
                if (clientInput != null)
                {
                    clientInput.cancelSend();
                }
                else
                {
                    Debug.LogError("clientInput null: " + this);
                }
            }
            else
            {
                Debug.LogError("clientInputSend null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}