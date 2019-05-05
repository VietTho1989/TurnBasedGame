using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Hint
{
    public class EditHintAIUI : UIBehavior<EditHintAIUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<AIUI.UIData> aiUIData;

            public VP<EditType> editType;

            #region Constructor

            public enum Property
            {
                aiUIData,
                editType
            }

            public UIData() : base()
            {
                // aiUIData
                {
                    this.aiUIData = new VP<AIUI.UIData>(this, (byte)Property.aiUIData, new AIUI.UIData());
                    this.aiUIData.v.subShowType.v = UIRectTransform.ShowType.HeadLess;
                }
                this.editType = new VP<EditType>(this, (byte)Property.editType, EditType.Later);
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
                            EditHintAIUI editHintAIUI = this.findCallBack<EditHintAIUI>();
                            if (editHintAIUI != null)
                            {
                                editHintAIUI.onClickBtnBack();
                            }
                            else
                            {
                                Debug.LogError("editHintAIUI null: " + this);
                            }
                            isProcess = true;
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            EditHintAIUI editHintAIUI = this.findCallBack<EditHintAIUI>();
                            if (editHintAIUI != null)
                            {
                                isProcess = editHintAIUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("editHintAIUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region Refresh

        public Dropdown drEditType;

        public override void Awake()
        {
            base.Awake();
            if (drEditType != null)
            {
                drEditType.onValueChanged.AddListener(delegate (int newValue)
                {
                    if (drEditType.gameObject.activeInHierarchy)
                    {
                        if (this.data != null)
                        {
                            this.data.editType.v = (Data.EditType)newValue;
                        }
                        else
                        {
                            Debug.LogError("data null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("drEditType not active: " + this);
                    }
                });
            }
            else
            {
                Debug.LogError("drValue null: " + this);
            }
        }

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Edit Hint AI");

        public Text tvApply;
        private static readonly TxtLanguage txtApply = new TxtLanguage("Apply");
        private static readonly TxtLanguage txtNotDifferentApply = new TxtLanguage("Not different, cannot apply");

        public Text tvReset;
        private static readonly TxtLanguage txtReset = new TxtLanguage("Reset");
        private static readonly TxtLanguage txtNotDifferentReset = new TxtLanguage("Not diffrent, cannot reset");

        static EditHintAIUI()
        {
            txtTitle.add(Language.Type.vi, "Chỉnh Sửa Gợi Ý Của AI");

            txtApply.add(Language.Type.vi, "Áp Dụng");
            txtNotDifferentApply.add(Language.Type.vi, "Không khác, không thể áp dụng");

            txtReset.add(Language.Type.vi, "Đặt Lại");
            txtNotDifferentReset.add(Language.Type.vi, "Không khác, không thể đặt lại");
        }

        #endregion

        public Button btnApply;
        public Button btnReset;

        public RectTransform aiScrollView;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // drEditType
                    if (drEditType != null)
                    {
                        // options
                        Data.RefreshStrEditType(drEditType);
                        // set value
                        drEditType.value = (int)this.data.editType.v;
                    }
                    else
                    {
                        Debug.LogError("drEditType null: " + this);
                    }
                    // aiUIData
                    {
                        EditData<Computer.AI> editComputerAI = null;
                        {
                            AIUI.UIData aiUIData = this.data.aiUIData.v;
                            if (aiUIData != null)
                            {
                                editComputerAI = aiUIData.editAI.v;
                            }
                            else
                            {
                                Debug.LogError("aiUIData null: " + this);
                            }
                        }
                        if (editComputerAI != null)
                        {
                            editComputerAI.editType.v = this.data.editType.v;
                        }
                        else
                        {
                            Debug.LogError("editComputerAI null: " + this);
                        }
                    }
                    // btns, aiScrollView
                    {
                        if (btnApply != null && btnReset != null && aiScrollView != null)
                        {
                            switch (this.data.editType.v)
                            {
                                case Data.EditType.Immediate:
                                    {
                                        btnApply.gameObject.SetActive(false);
                                        btnReset.gameObject.SetActive(false);
                                        UIRectTransform.SetHeight(aiScrollView, 300);
                                    }
                                    break;
                                case Data.EditType.Later:
                                    {
                                        btnApply.gameObject.SetActive(true);
                                        btnReset.gameObject.SetActive(true);
                                        UIRectTransform.SetHeight(aiScrollView, 250);
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown editType: " + this.data.editType.v);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("btns, aiScrollView null: " + this);
                        }
                    }
                    // btnUpdate, btnReset interactable
                    {
                        if (btnApply != null && tvApply != null && btnReset != null && tvReset != null)
                        {
                            // Find
                            bool isDifferent = true;
                            {
                                // Find
                                EditData<Computer.AI> editComputerAI = null;
                                {
                                    AIUI.UIData aiUIData = this.data.aiUIData.v;
                                    if (aiUIData != null)
                                    {
                                        editComputerAI = aiUIData.editAI.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("aiUIData null: " + this);
                                    }
                                }
                                // Process
                                if (editComputerAI != null)
                                {
                                    if (editComputerAI.origin.v.data != null && editComputerAI.show.v.data != null && editComputerAI.origin.v.data != editComputerAI.show.v.data)
                                    {
                                        isDifferent = DataUtils.IsDifferent(editComputerAI.show.v.data, editComputerAI.origin.v.data);
                                    }
                                    else
                                    {
                                        // Debug.LogError ("not different between origin and show, so cannot update: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("editComputerAI null: " + this);
                                }
                            }
                            // Process
                            if (isDifferent)
                            {
                                // apply
                                {
                                    btnApply.interactable = true;
                                    tvApply.text = txtApply.get();
                                }
                                // reset
                                {
                                    btnReset.interactable = true;
                                    tvReset.text = txtReset.get();
                                }
                            }
                            else
                            {
                                // apply
                                {
                                    btnApply.interactable = false;
                                    tvApply.text = txtNotDifferentApply.get();
                                }
                                // reset
                                {
                                    btnReset.interactable = false;
                                    tvReset.text = txtNotDifferentReset.get();
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("btnUpdate, btnReset null: " + this);
                        }
                    }
                    // Compare
                    {
                        EditData<Computer.AI> editComputerAI = null;
                        {
                            AIUI.UIData aiUIData = this.data.aiUIData.v;
                            if (aiUIData != null)
                            {
                                editComputerAI = aiUIData.editAI.v;
                            }
                            else
                            {
                                Debug.LogError("aiUIData null: " + this);
                            }
                        }
                        if (editComputerAI != null)
                        {
                            if (this.data.editType.v == Data.EditType.Later)
                            {
                                editComputerAI.compare.v = new ReferenceData<Computer.AI>(editComputerAI.origin.v.data);
                            }
                            else
                            {
                                editComputerAI.compare.v = new ReferenceData<Computer.AI>(null);
                            }
                        }
                        else
                        {
                            Debug.LogError("editComputerAI null: " + this);
                        }
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

        public Transform aiContainer;
        public AIUI aiUIPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.aiUIData.allAddCallBack(this);
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
                if (data is AIUI.UIData)
                {
                    AIUI.UIData aiUIData = data as AIUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(aiUIData, aiUIPrefab, aiContainer);
                    }
                    // Child
                    {
                        aiUIData.editAI.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is EditData<Computer.AI>)
                    {
                        EditData<Computer.AI> editComputerAI = data as EditData<Computer.AI>;
                        // Child
                        {
                            editComputerAI.show.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        Debug.LogError("addCallBackAllChildren: " + data + "; " + this);
                        data.addCallBackAllChildren(this);
                        dirty = true;
                        return;
                    }
                }
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
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
                    uiData.aiUIData.allRemoveCallBack(this);
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
                if (data is AIUI.UIData)
                {
                    AIUI.UIData aiUIData = data as AIUI.UIData;
                    // UI
                    {
                        aiUIData.removeCallBackAndDestroy(typeof(AIUI));
                    }
                    // Child
                    {
                        aiUIData.editAI.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is EditData<Computer.AI>)
                    {
                        EditData<Computer.AI> editComputerAI = data as EditData<Computer.AI>;
                        // Child
                        {
                            editComputerAI.show.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        data.removeCallBackAllChildren(this);
                        dirty = true;
                        return;
                    }
                }
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
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
                    case UIData.Property.aiUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.editType:
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
                    case Setting.Property.contentTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
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
                if (wrapProperty.p is AIUI.UIData)
                {
                    switch ((AIUI.UIData.Property)wrapProperty.n)
                    {
                        case AIUI.UIData.Property.editAI:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case AIUI.UIData.Property.sub:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is EditData<Computer.AI>)
                    {
                        switch ((EditData<Computer.AI>.Property)wrapProperty.n)
                        {
                            case EditData<Computer.AI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<Computer.AI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<Computer.AI>.Property.compare:
                                dirty = true;
                                break;
                            case EditData<Computer.AI>.Property.canEdit:
                                break;
                            case EditData<Computer.AI>.Property.editType:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (Generic.IsAddCallBackInterface<T>())
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                        }
                        Debug.LogError("have change in ai: " + this);
                        dirty = true;
                        return;
                    }
                }
            }
            // Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                HintUI.UIData hintUIData = this.data.findDataInParent<HintUI.UIData>();
                if (hintUIData != null)
                {
                    hintUIData.editHintAIUIData.v = null;
                }
                else
                {
                    Debug.LogError("hintUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnApply()
        {
            if (this.data != null)
            {
                // Find
                EditData<Computer.AI> editComputerAI = null;
                {
                    AIUI.UIData aiUIData = this.data.aiUIData.v;
                    if (aiUIData != null)
                    {
                        editComputerAI = aiUIData.editAI.v;
                    }
                    else
                    {
                        Debug.LogError("aiUIData null: " + this);
                    }
                }
                // Process
                if (editComputerAI != null)
                {
                    if (editComputerAI.origin.v.data != null && editComputerAI.show.v.data != null && editComputerAI.origin.v.data != editComputerAI.show.v.data)
                    {
                        DataUtils.copyData(editComputerAI.origin.v.data, editComputerAI.show.v.data);
                    }
                    else
                    {
                        Debug.LogError("not different between origin and show, so cannot update: " + this);
                    }
                }
                else
                {
                    Debug.LogError("editComputerAI null: " + this);
                }
                dirty = true;
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnReset()
        {
            if (this.data != null)
            {
                // Find
                EditData<Computer.AI> editComputerAI = null;
                {
                    AIUI.UIData aiUIData = this.data.aiUIData.v;
                    if (aiUIData != null)
                    {
                        editComputerAI = aiUIData.editAI.v;
                    }
                    else
                    {
                        Debug.LogError("aiUIData null: " + this);
                    }
                }
                // Process
                if (editComputerAI != null)
                {
                    editComputerAI.show.v = new ReferenceData<Computer.AI>(null);
                }
                else
                {
                    Debug.LogError("editComputerAI null: " + this);
                }
                dirty = true;
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}