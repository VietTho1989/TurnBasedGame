using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AfterLoginMainBtnBackHostUI : UIBehavior<AfterLoginMainBtnBackHostUI.UIData>
{

    #region UIData

    public class UIData : AfterLoginMainBtnBackUI.UIData.Sub
    {

        public VP<ReferenceData<Server>> server;

        public VP<bool> needConfirm;

        public VP<ConfirmBackHostUI.UIData> confirmUI;

        #region Constructor

        public enum Property
        {
            server,
            needConfirm,
            confirmUI
        }

        public UIData() : base()
        {
            this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
            this.needConfirm = new VP<bool>(this, (byte)Property.needConfirm, true);
            this.confirmUI = new VP<ConfirmBackHostUI.UIData>(this, (byte)Property.confirmUI, null);
        }

        #endregion

        public override Server.Type getType()
        {
            return Server.Type.Host;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // confirmUI
                if (!isProcess)
                {
                    ConfirmBackHostUI.UIData confirmUI = this.confirmUI.v;
                    if (confirmUI != null)
                    {
                        isProcess = confirmUI.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("confirmUI null: " + this);
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        AfterLoginMainBtnBackHostUI backHostUI = this.findCallBack<AfterLoginMainBtnBackHostUI>();
                        if (backHostUI != null)
                        {
                            backHostUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("backHostUI null: " + this);
                        }
                        isProcess = true;
                    }
                }
            }
            return isProcess;
        }

        public void back()
        {
            LanUI.UIData lanUIData = this.findDataInParent<LanUI.UIData>();
            if (lanUIData != null)
            {
                LanMenuUI.UIData lanMenuUIData = lanUIData.sub.newOrOld<LanMenuUI.UIData>();
                {

                }
                lanUIData.sub.v = lanMenuUIData;
            }
            else
            {
                Debug.LogError("lanUIData null: " + this);
            }
        }

    }

    #endregion

    public override int getStartAllocate()
    {
        return 1;
    }

    #region txt

    public Text tvBack;
    private static readonly TxtLanguage txtBack = new TxtLanguage("Back");

    static AfterLoginMainBtnBackHostUI()
    {
        txtBack.add(Language.Type.vi, "Quay lại");
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
                // confirmUI
                {
                    if (!this.data.needConfirm.v)
                    {
                        this.data.confirmUI.v = null;
                    }
                }
                // txt
                {
                    if (tvBack != null)
                    {
                        tvBack.text = txtBack.get();
                    }
                    else
                    {
                        // Debug.LogError("tvBack null: " + this);
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

    public ConfirmBackHostUI confirmUIPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.server.allAddCallBack(this);
                uiData.confirmUI.allAddCallBack(this);
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
            if (data is Server)
            {
                dirty = true;
                // reset
                {
                    if (this.data != null)
                    {
                        this.data.confirmUI.v = null;
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                return;
            }
            if (data is ConfirmBackHostUI.UIData)
            {
                ConfirmBackHostUI.UIData confirmUIData = data as ConfirmBackHostUI.UIData;
                // UI
                {
                    Transform confirmBackContainer = null;
                    {
                        AfterLoginUI.UIData afterLoginUIData = confirmUIData.findDataInParent<AfterLoginUI.UIData>();
                        if (afterLoginUIData != null)
                        {
                            AfterLoginUI afterLoginUI = afterLoginUIData.findCallBack<AfterLoginUI>();
                            if (afterLoginUI != null)
                            {
                                confirmBackContainer = afterLoginUI.confirmBackContainer;
                            }
                            else
                            {
                                Debug.LogError("globalViewUI null");
                            }
                        }
                        else
                        {
                            Debug.LogError("globalViewUIData null");
                        }
                    }
                    UIUtils.Instantiate(confirmUIData, confirmUIPrefab, confirmBackContainer);
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
                uiData.server.allRemoveCallBack(this);
                uiData.confirmUI.allRemoveCallBack(this);
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
            if (data is Server)
            {
                return;
            }
            if (data is ConfirmBackHostUI.UIData)
            {
                ConfirmBackHostUI.UIData confirmUIData = data as ConfirmBackHostUI.UIData;
                // UI
                {
                    confirmUIData.removeCallBackAndDestroy(typeof(ConfirmBackHostUI));
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
                case UIData.Property.server:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.needConfirm:
                    dirty = true;
                    break;
                case UIData.Property.confirmUI:
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
            if (wrapProperty.p is Server)
            {
                return;
            }
            if (wrapProperty.p is ConfirmBackHostUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            if (!this.data.needConfirm.v)
            {
                this.data.back();
            }
            else
            {
                ConfirmBackHostUI.UIData confirmBackHostUIData = this.data.confirmUI.newOrOld<ConfirmBackHostUI.UIData>();
                {

                }
                this.data.confirmUI.v = confirmBackHostUIData;
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}