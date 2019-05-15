using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScreenCaptureSettingUI : UIHaveTransformDataBehavior<ScreenCaptureSettingUI.UIData>
{

    #region UIData

    public class UIData : Data, EditDataUI.UIData<ScreenCaptureSetting>
    {

        public VP<EditData<ScreenCaptureSetting>> editScreenCaptureSetting;

        #region waitDuration

        public VP<RequestChangeIntUI.UIData> waitDuration;

        public void makeRequestChangeWaitDuration(RequestChangeUpdate<int>.UpdateData update, int newWaitDuration)
        {
            // Find
            ScreenCaptureSetting screenCaptureSetting = null;
            {
                EditData<ScreenCaptureSetting> editScreenCaptureSetting = this.editScreenCaptureSetting.v;
                if (editScreenCaptureSetting != null)
                {
                    screenCaptureSetting = editScreenCaptureSetting.show.v.data;
                }
                else
                {
                    Debug.LogError("editScreenCaptureSetting null: " + this);
                }
            }
            // Process
            if (screenCaptureSetting != null)
            {
                screenCaptureSetting.waitDuration.v = newWaitDuration;
            }
            else
            {
                Debug.LogError("screenCaptureSetting null: " + this);
            }
        }

        #endregion

        #region autoCloseSetting

        public VP<RequestChangeBoolUI.UIData> autoCloseSetting;

        public void makeRequestChangeAutoCloseSetting(RequestChangeUpdate<bool>.UpdateData update, bool newAutoCloseSetting)
        {
            // Find
            ScreenCaptureSetting screenCaptureSetting = null;
            {
                EditData<ScreenCaptureSetting> editScreenCaptureSetting = this.editScreenCaptureSetting.v;
                if (editScreenCaptureSetting != null)
                {
                    screenCaptureSetting = editScreenCaptureSetting.show.v.data;
                }
                else
                {
                    Debug.LogError("editScreenCaptureSetting null: " + this);
                }
            }
            // Process
            if (screenCaptureSetting != null)
            {
                screenCaptureSetting.autoCloseSetting.v = newAutoCloseSetting;
            }
            else
            {
                Debug.LogError("screenCaptureSetting null: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            editScreenCaptureSetting,
            waitDuration,
            autoCloseSetting
        }

        public UIData() : base()
        {
            {
                this.editScreenCaptureSetting = new VP<EditData<ScreenCaptureSetting>>(this, (byte)Property.editScreenCaptureSetting, new EditData<ScreenCaptureSetting>());
                this.editScreenCaptureSetting.v.canEdit.v = true;
            }
            // waitDuration
            {
                this.waitDuration = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.waitDuration, new RequestChangeIntUI.UIData());
                // event
                this.waitDuration.v.updateData.v.request.v = makeRequestChangeWaitDuration;
            }
            // autoCloseSetting
            {
                this.autoCloseSetting = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.autoCloseSetting, new RequestChangeBoolUI.UIData());
                this.autoCloseSetting.v.updateData.v.request.v = makeRequestChangeAutoCloseSetting;
            }
        }

        #endregion

        #region implement base

        public EditData<ScreenCaptureSetting> getEditData()
        {
            return this.editScreenCaptureSetting.v;
        }

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        ScreenCaptureSettingUI screenCaptureSettingUI = this.findCallBack<ScreenCaptureSettingUI>();
                        if (screenCaptureSettingUI != null)
                        {
                            isProcess = screenCaptureSettingUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("screenCaptureSettingUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Screen Capture Setting");

    public Text lbCapture;
    public Button btnCapture;
    private static readonly TxtLanguage txtCapture = new TxtLanguage("Capture");

    public Text lbWaitDuration;
    private static readonly TxtLanguage txtWaitDuration = new TxtLanguage("Wait duration");

    public Text lbAutoCloseSetting;
    private static readonly TxtLanguage txtAutoCloseSetting = new TxtLanguage("Auto close setting");

    static ScreenCaptureSettingUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Thiết Lập Chụp Màn Hình");
            txtCapture.add(Language.Type.vi, "Chụp");
            txtWaitDuration.add(Language.Type.vi, "Thời gian đợi");
            txtAutoCloseSetting.add(Language.Type.vi, "Tự động đóng thiết lập");
        }
    }

    #endregion

    #region Refresh

    private bool needReset = true;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                EditData<ScreenCaptureSetting> editScreenCaptureSetting = this.data.editScreenCaptureSetting.v;
                if (editScreenCaptureSetting != null)
                {
                    editScreenCaptureSetting.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editScreenCaptureSetting);
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = Server.State.Type.Connect;
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.waitDuration.v, editScreenCaptureSetting, serverState, needReset, editData => editData.waitDuration.v);
                                RequestChange.RefreshUI(this.data.autoCloseSetting.v, editScreenCaptureSetting, serverState, needReset, editData => editData.autoCloseSetting.v);
                            }
                        }
                        needReset = false;
                    }
                }
                else
                {
                    Debug.LogError("editScreenCaptureSetting null: " + this);
                }
                // UI
                {
                    float deltaY = 0;
                    // header
                    UIUtils.SetHeaderPosition(lbTitle, UIRectTransform.ShowType.Normal, ref deltaY);
                    // capture
                    {
                        float itemHeight = Setting.get().getItemSize();
                        // lb
                        if (lbCapture != null)
                        {
                            UIRectTransform.SetPosY(lbCapture.rectTransform, deltaY);
                            UIRectTransform.SetHeight(lbCapture.rectTransform, itemHeight);
                        }
                        else
                        {
                            Debug.LogError("lbCapture null");
                        }
                        // btn
                        if (btnCapture != null)
                        {
                            UIRectTransform.SetPosY((RectTransform)btnCapture.transform, deltaY + (itemHeight - 40.0f) / 2);
                        }
                        else
                        {
                            Debug.LogError("btnCapture null");
                        }
                        deltaY += itemHeight;
                    }
                    // waitDuration
                    UIUtils.SetLabelContentPosition(lbWaitDuration, this.data.waitDuration.v, ref deltaY);
                    // autoCloseSetting
                    UIUtils.SetLabelContentPosition(lbAutoCloseSetting, this.data.autoCloseSetting.v, ref deltaY);
                    // set height
                    UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get();
                        Setting.get().setTitleTextSize(lbTitle);
                    }
                    else
                    {
                        Debug.LogError("lbTitle null: " + this);
                    }
                    if (lbCapture != null)
                    {
                        lbCapture.text = txtCapture.get();
                        Setting.get().setLabelTextSize(lbCapture);
                    }
                    else
                    {
                        Debug.LogError("lbCapture null: " + this);
                    }
                    if (lbWaitDuration != null)
                    {
                        lbWaitDuration.text = txtWaitDuration.get();
                        Setting.get().setLabelTextSize(lbWaitDuration);
                    }
                    else
                    {
                        Debug.LogError("lbWaitDuration null: " + this);
                    }
                    if (lbAutoCloseSetting != null)
                    {
                        lbAutoCloseSetting.text = txtAutoCloseSetting.get();
                        Setting.get().setLabelTextSize(lbAutoCloseSetting);
                    }
                    else
                    {
                        Debug.LogError("lbAutoCloseSetting null: " + this);
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

    public RequestChangeBoolUI requestBoolPrefab;
    public RequestChangeIntUI requestIntPrefab;

    // private Server server = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.editScreenCaptureSetting.allAddCallBack(this);
                uiData.waitDuration.allAddCallBack(this);
                uiData.autoCloseSetting.allAddCallBack(this);
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
            // editScreenCaptureSetting
            {
                if (data is EditData<ScreenCaptureSetting>)
                {
                    EditData<ScreenCaptureSetting> editScreenCaptureSetting = data as EditData<ScreenCaptureSetting>;
                    // Child
                    {
                        editScreenCaptureSetting.show.allAddCallBack(this);
                        editScreenCaptureSetting.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is ScreenCaptureSetting)
                    {
                        /*ScreenCaptureSetting screenCaptureSetting = data as ScreenCaptureSetting;
                        // Parent
                        {
                            DataUtils.addParentCallBack (screenCaptureSetting, this, ref this.server);
                        }*/
                        needReset = true;
                        dirty = true;
                        return;
                    }
                    // Parent
                    /*if (data is Server) {
                            dirty = true;
                            return;
                        }*/
                }
            }
            // waitDuration
            if (data is RequestChangeIntUI.UIData)
            {
                RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.waitDuration:
                                UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("wrapProperty null: " + this);
                    }
                }
                dirty = true;
                return;
            }
            // autoCloseSetting
            if (data is RequestChangeBoolUI.UIData)
            {
                RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.autoCloseSetting:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("wrapProperty null: " + this);
                    }
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
                uiData.editScreenCaptureSetting.allRemoveCallBack(this);
                uiData.waitDuration.allRemoveCallBack(this);
                uiData.autoCloseSetting.allRemoveCallBack(this);
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
            // editScreenCaptureSetting
            {
                if (data is EditData<ScreenCaptureSetting>)
                {
                    EditData<ScreenCaptureSetting> editScreenCaptureSetting = data as EditData<ScreenCaptureSetting>;
                    // Child
                    {
                        editScreenCaptureSetting.show.allRemoveCallBack(this);
                        editScreenCaptureSetting.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is ScreenCaptureSetting)
                    {
                        /*ScreenCaptureSetting screenCaptureSetting = data as ScreenCaptureSetting;
                        // Parent
                        {
                            DataUtils.removeParentCallBack (screenCaptureSetting, this, ref this.server);
                        }*/
                        return;
                    }
                    // Parent
                    /*if (data is Server) {
                            return;
                        }*/
                }
            }
            // waitDuration
            if (data is RequestChangeIntUI.UIData)
            {
                RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                }
                return;
            }
            // autoCloseSetting
            if (data is RequestChangeBoolUI.UIData)
            {
                RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
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
                case UIData.Property.editScreenCaptureSetting:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.waitDuration:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.autoCloseSetting:
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
                case Setting.Property.style:
                    break;
                case Setting.Property.contentTextSize:
                    dirty = true;
                    break;
                case Setting.Property.titleTextSize:
                    dirty = true;
                    break;
                case Setting.Property.labelTextSize:
                    dirty = true;
                    break;
                case Setting.Property.buttonSize:
                    dirty = true;
                    break;
                case Setting.Property.itemSize:
                    dirty = true;
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
                case Setting.Property.screenCaptureSetting:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            // editScreenCaptureSetting
            {
                if (wrapProperty.p is EditData<ScreenCaptureSetting>)
                {
                    switch ((EditData<ScreenCaptureSetting>.Property)wrapProperty.n)
                    {
                        case EditData<ScreenCaptureSetting>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<ScreenCaptureSetting>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<ScreenCaptureSetting>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<ScreenCaptureSetting>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<ScreenCaptureSetting>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<ScreenCaptureSetting>.Property.editType:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is ScreenCaptureSetting)
                    {
                        switch ((ScreenCaptureSetting.Property)wrapProperty.n)
                        {
                            case ScreenCaptureSetting.Property.waitDuration:
                                dirty = true;
                                break;
                            case ScreenCaptureSetting.Property.autoCloseSetting:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Parent
                    /*if (wrapProperty.p is Server) {
                            Server.State.OnUpdateSyncStateChange (wrapProperty, this);
                            return;
                        }*/
                }
            }
            // waitDuration
            if (wrapProperty.p is RequestChangeIntUI.UIData)
            {
                return;
            }
            // autoCloseSetting
            if (wrapProperty.p is RequestChangeBoolUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // onClick
        {
            UIUtils.SetButtonOnClick(btnCapture, onClickBtnCapture);
        }
    }

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (!isProcess)
            {
                if (e.isKey && e.type == EventType.KeyUp)
                {
                    switch (e.keyCode)
                    {
                        case KeyCode.C:
                            {
                                if(btnCapture!=null && btnCapture.gameObject.activeInHierarchy && btnCapture.interactable)
                                {
                                    this.onClickBtnCapture();
                                    isProcess = true;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        return isProcess;
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnCapture()
    {
        if (this.data != null)
        {
            MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData>();
            if (mainUIData != null)
            {
                if (mainUIData.screenCaptureUIData.v == null)
                {
                    // make screenCapture
                    {
                        ScreenCaptureUI.UIData screenCaptureUIData = new ScreenCaptureUI.UIData();
                        {
                            screenCaptureUIData.uid = mainUIData.screenCaptureUIData.makeId();
                            // sub
                            {
                                ScreenCaptureWaitUI.UIData screenCaptureWaitUIData = new ScreenCaptureWaitUI.UIData();
                                {
                                    screenCaptureWaitUIData.uid = screenCaptureUIData.sub.makeId();
                                    screenCaptureWaitUIData.time.v = Mathf.Max(Setting.get().screenCaptureSetting.v.waitDuration.v, 1);
                                }
                                screenCaptureUIData.sub.v = screenCaptureWaitUIData;
                            }
                        }
                        mainUIData.screenCaptureUIData.v = screenCaptureUIData;
                    }
                    // close setting
                    if (Setting.get().screenCaptureSetting.v.autoCloseSetting.v)
                    {
                        mainUIData.showSettingUIData.v = null;
                    }
                }
                else
                {
                    Debug.LogError("already screenCapture");
                }
            }
            else
            {
                Debug.LogError("mainUIData null");
            }
        }
        else
        {
            Debug.LogError("btnSetting null");
        }
    }

}