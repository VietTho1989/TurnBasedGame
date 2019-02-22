using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShowSettingUI : UIBehavior<ShowSettingUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<SettingUI.UIData> settingUIData;

        #region editType

        public VP<RequestChangeEnumUI.UIData> requestEditType;

        public void makeRequestChangeEditType(RequestChangeUpdate<int>.UpdateData update, int newEditType)
        {
            EditData<Setting> editSetting = this.settingUIData.v.editSetting.v;
            if (editSetting != null)
            {
                editSetting.editType.v = (EditType)newEditType;
            }
            else
            {
                Debug.LogError("editSetting null");
            }
        }

        #endregion

            #region Constructor

        public enum Property
        {
            settingUIData,
            requestEditType
        }

        public UIData() : base()
        {
            // settingUIData
            {
                this.settingUIData = new VP<SettingUI.UIData>(this, (byte)Property.settingUIData, new SettingUI.UIData());
                this.settingUIData.v.showType.v = UIRectTransform.ShowType.HeadLess;
            }
            // editType
            {
                this.requestEditType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.requestEditType, new RequestChangeEnumUI.UIData());
                foreach (EditType editType in System.Enum.GetValues(typeof(EditType)))
                {
                    this.requestEditType.v.options.add(editType.ToString());
                }
                this.requestEditType.v.updateData.v.request.v = makeRequestChangeEditType;
            }
        }

        #endregion

        public bool processEvent(Event e)
        {
            Debug.LogError("processEvent: " + e);
            bool isProcess = false;
            {
                // child
                if (!isProcess)
                {
                    // TODO Can hoan thien
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        ShowSettingUI showSettingUI = this.findCallBack<ShowSettingUI>();
                        if (showSettingUI != null)
                        {
                            showSettingUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("showSettingUI null: " + this);
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

    public Text tvSetting;
    public static readonly TxtLanguage txtSetting = new TxtLanguage();

    public Text tvBack;
    public static readonly TxtLanguage txtBack = new TxtLanguage();

    public static readonly TxtLanguage txtImmediate = new TxtLanguage();
    public static readonly TxtLanguage txtLater = new TxtLanguage();

    public static readonly TxtLanguage txtApply = new TxtLanguage();
    public static readonly TxtLanguage txtCannotApply = new TxtLanguage();
    public static readonly TxtLanguage txtReset = new TxtLanguage();
    public static readonly TxtLanguage txtCannotReset = new TxtLanguage();

    static ShowSettingUI()
    {
        // txt
        {
            txtSetting.add(Language.Type.vi, "Thiết Lập");
            txtBack.add(Language.Type.vi, "Quay Lại");
            txtImmediate.add(Language.Type.vi, "Ngay Lập Tức");
            txtLater.add(Language.Type.vi, "Sau này");
            txtApply.add(Language.Type.vi, "Áp Dụng");
            txtCannotApply.add(Language.Type.vi, "Không thể áp dụng");
            txtReset.add(Language.Type.vi, "Đặt lại");
            txtCannotReset.add(Language.Type.vi, "Không cần đặt lại");
        }
        // rect
        {
            // requestEditTypeRect
            {
                // anchoredPosition: (-160.0, 0.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0); 
                // offsetMin: (-320.0, -30.0); offsetMax: (-160.0, 0.0); sizeDelta: (160.0, 30.0);
                requestEditTypeRect.anchoredPosition = new Vector3(0.0f, 0f, 0f);
                requestEditTypeRect.anchorMin = new Vector2(1.0f, 1.0f);
                requestEditTypeRect.anchorMax = new Vector2(1.0f, 1.0f);
                requestEditTypeRect.pivot = new Vector2(1.0f, 1.0f);
                requestEditTypeRect.offsetMin = new Vector2(-80.0f, 0.0f);
                requestEditTypeRect.offsetMax = new Vector2(0.0f, 0.0f);
                requestEditTypeRect.sizeDelta = new Vector2(80.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    public Button btnApply;
    public Text tvApply;

    public Button btnReset;
    public Text tvReset;

    public RectTransform settingUIScrollView;
    private static readonly UIRectTransform scrollRectImmediately = UIRectTransform.CreateFullRect(0, 0, UIConstants.HeaderHeight, 0);
    private static readonly UIRectTransform scrollRectLater = UIRectTransform.CreateFullRect(0, 0, UIConstants.HeaderHeight, UIConstants.ItemHeight);

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // settingUIData
                {
                    SettingUI.UIData settingUIData = this.data.settingUIData.v;
                    if (settingUIData != null)
                    {
                        EditData<Setting> editSetting = settingUIData.editSetting.v;
                        if (editSetting != null)
                        {
                            editSetting.origin.v = new ReferenceData<Setting>(Setting.get());
                            editSetting.canEdit.v = true;
                        }
                        else
                        {
                            Debug.LogError("editSetting null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("settingUIData null: " + this);
                    }
                }
                // btn
                {
                    EditData<Setting> editSetting = this.data.settingUIData.v.editSetting.v;
                    if (editSetting != null)
                    {
                        // editType
                        {
                            RequestChangeEnumUI.UIData requestEditType = this.data.requestEditType.v;
                            if (requestEditType != null)
                            {
                                // options
                                {
                                    List<string> options = new List<string>();
                                    {
                                        options.Add(txtImmediate.get("Immediately"));
                                        options.Add(txtLater.get("Later"));
                                    }
                                    requestEditType.options.copyList(options);
                                }
                                // origin
                                RequestChangeUpdate<int>.UpdateData updateData = requestEditType.updateData.v;
                                if (updateData != null)
                                {
                                    updateData.canRequestChange.v = true;
                                    updateData.origin.v = (int)editSetting.editType.v;
                                }
                                else
                                {
                                    Debug.LogError("updateData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("requestEditType null");
                            }
                        }
                        // scrollRect
                        {
                            if (settingUIScrollView != null)
                            {
                                switch (editSetting.editType.v)
                                {
                                    case Data.EditType.Immediate:
                                        {
                                            scrollRectImmediately.set(settingUIScrollView);
                                        }
                                        break;
                                    case Data.EditType.Later:
                                        {
                                            scrollRectLater.set(settingUIScrollView);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown editType: " + editSetting.editType.v);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("settingUIScrollView null");
                            }
                        }
                        // btn
                        if (btnApply != null && tvApply != null && btnReset != null && tvReset != null)
                        {
                            switch (editSetting.editType.v)
                            {
                                case EditData<Setting>.EditType.Immediate:
                                    {
                                        editSetting.compare.v = new ReferenceData<Setting>(null);
                                        btnApply.gameObject.SetActive(false);
                                        btnReset.gameObject.SetActive(false);
                                    }
                                    break;
                                case EditData<Setting>.EditType.Later:
                                    {
                                        // compare
                                        {
                                            editSetting.compare.v = new ReferenceData<Setting>(editSetting.origin.v.data);
                                        }
                                        btnApply.gameObject.SetActive(true);
                                        btnReset.gameObject.SetActive(true);
                                        // check is different
                                        bool isDifferent = false;
                                        {
                                            Setting origin = editSetting.origin.v.data;
                                            Setting show = editSetting.show.v.data;
                                            if (origin != null && show != null)
                                            {
                                                if (origin != show)
                                                {
                                                    if (DataUtils.IsDifferent(origin, show))
                                                    {
                                                        isDifferent = true;
                                                    }
                                                    // Debug.LogError ("find different: " + isDifferent);
                                                }
                                                else
                                                {
                                                    Debug.LogError("the same: " + this);
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("origin, show null: " + this);
                                            }
                                        }
                                        // process
                                        if (isDifferent)
                                        {
                                            // apply
                                            {
                                                btnApply.interactable = true;
                                                tvApply.text = txtApply.get("Apply");
                                            }
                                            // reset
                                            {
                                                btnReset.interactable = true;
                                                tvReset.text = txtReset.get("Reset");
                                            }
                                        }
                                        else
                                        {
                                            // apply
                                            {
                                                btnApply.interactable = false;
                                                tvApply.text = txtCannotApply.get("cannot apply");
                                            }
                                            // reset
                                            {
                                                btnReset.interactable = false;
                                                tvReset.text = txtCannotReset.get("Don't need reset");
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown editType: " + editSetting.editType.v + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("btn null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("editSetting null");
                    }
                }
                // txt
                {
                    if (tvSetting != null)
                    {
                        tvSetting.text = txtSetting.get("Setting");
                    }
                    else
                    {
                        Debug.LogError("tvSetting null: " + this);
                    }
                    if (tvBack != null)
                    {
                        tvBack.text = txtBack.get("Back");
                    }
                    else
                    {
                        // Debug.LogError ("tvBack null: " + this);
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

    public SettingUI settingUIPrefab;
    public Transform settingUIContainer;

    public RequestChangeEnumUI requestEnumPrefab;
    private static readonly UIRectTransform requestEditTypeRect = new UIRectTransform();

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.settingUIData.allAddCallBack(this);
                uiData.requestEditType.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            // requestEditType
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.requestEditType:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, requestEditTypeRect);
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
            // settingUIData
            {
                if (data is SettingUI.UIData)
                {
                    SettingUI.UIData settingUIData = data as SettingUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(settingUIData, settingUIPrefab, settingUIContainer);
                    }
                    // Child
                    {
                        settingUIData.editSetting.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is EditData<Setting>)
                    {
                        EditData<Setting> editSetting = data as EditData<Setting>;
                        // Child
                        {
                            editSetting.show.allAddCallBack(this);
                            editSetting.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is Setting)
                        {
                            Setting setting = data as Setting;
                            // Child
                            {
                                setting.addCallBackAllChildren(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        {
                            data.addCallBackAllChildren(this);
                            dirty = true;
                            return;
                        }
                    }
                }
            }
        }
        // Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.settingUIData.allRemoveCallBack(this);
                uiData.requestEditType.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            // requestEditType
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                }
                return;
            }
            // settingUIData
            {
                if (data is SettingUI.UIData)
                {
                    SettingUI.UIData settingUIData = data as SettingUI.UIData;
                    // UI
                    {
                        settingUIData.removeCallBackAndDestroy(typeof(SettingUI));
                    }
                    // Child
                    {
                        settingUIData.editSetting.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is EditData<Setting>)
                    {
                        EditData<Setting> editSetting = data as EditData<Setting>;
                        // Child
                        {
                            editSetting.show.allRemoveCallBack(this);
                            editSetting.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is Setting)
                        {
                            Setting setting = data as Setting;
                            // Child
                            {
                                setting.removeCallBackAllChildren(this);
                            }
                            return;
                        }
                        // Child
                        {
                            data.removeCallBackAllChildren(this);
                            return;
                        }
                    }
                }
            }
        }
        // Debug.LogError("Don't process: " + data + "; " + this);
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
                case UIData.Property.settingUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.requestEditType:
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
        // Child
        {
            // requestEditType
            if (wrapProperty.p is RequestChangeEnumUI.UIData)
            {
                return;
            }
            // settingUIData
            {
                if (wrapProperty.p is SettingUI.UIData)
                {
                    switch ((SettingUI.UIData.Property)wrapProperty.n)
                    {
                        case SettingUI.UIData.Property.editSetting:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case SettingUI.UIData.Property.showType:
                            break;
                        case SettingUI.UIData.Property.language:
                            break;
                        case SettingUI.UIData.Property.style:
                            break;
                        case SettingUI.UIData.Property.showLastMove:
                            break;
                        case SettingUI.UIData.Property.viewUrlImage:
                            break;
                        case SettingUI.UIData.Property.animationSetting:
                            break;
                        case SettingUI.UIData.Property.maxThinkCount:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is EditData<Setting>)
                    {
                        switch ((EditData<Setting>.Property)wrapProperty.n)
                        {
                            case EditData<Setting>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<Setting>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<Setting>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<Setting>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<Setting>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<Setting>.Property.editType:
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
                        if (wrapProperty.p is Setting)
                        {
                            if (Generic.IsAddCallBackInterface<T>())
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        {
                            if (Generic.IsAddCallBackInterface<T>())
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                            }
                            dirty = true;
                            return;
                        }
                    }
                }
            }
        }
        // Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData>();
            if (mainUIData != null)
            {
                mainUIData.showSettingUIData.v = null;
            }
            else
            {
                Debug.LogError("mainUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public void onClickBtnApply()
    {
        if (this.data != null)
        {
            // find editSetting
            EditData<Setting> editSetting = null;
            {
                SettingUI.UIData settingUIData = this.data.settingUIData.v;
                if (settingUIData != null)
                {
                    editSetting = settingUIData.editSetting.v;
                }
                else
                {
                    Debug.LogError("settingUIData null: " + this);
                }
            }
            // Process
            if (editSetting != null)
            {
                Setting origin = editSetting.origin.v.data;
                Setting show = editSetting.show.v.data;
                if (origin != null && show != null)
                {
                    if (origin != show)
                    {
                        DataUtils.copyData(origin, show);
                    }
                    else
                    {
                        Debug.LogError("the same: " + this);
                    }
                }
                else
                {
                    Debug.LogError("origin, show null: " + this);
                }
            }
            else
            {
                Debug.LogError("editSetting null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public void onClickBtnReset()
    {
        if (this.data != null)
        {
            // find editSetting
            EditData<Setting> editSetting = null;
            {
                SettingUI.UIData settingUIData = this.data.settingUIData.v;
                if (settingUIData != null)
                {
                    editSetting = settingUIData.editSetting.v;
                }
                else
                {
                    Debug.LogError("settingUIData null: " + this);
                }
            }
            // Process
            if (editSetting != null)
            {
                Setting origin = editSetting.origin.v.data;
                Setting show = editSetting.show.v.data;
                if (origin != null && show != null)
                {
                    if (origin != show)
                    {
                        editSetting.show.v = new ReferenceData<Setting>(null);
                    }
                    else
                    {
                        Debug.LogError("the same: " + this);
                    }
                }
                else
                {
                    Debug.LogError("origin, show null: " + this);
                }
            }
            else
            {
                Debug.LogError("editSetting null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}