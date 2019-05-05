using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Hint
{
    public class HintUI : UIBehavior<HintUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<GameData>> gameData;

            #region show

            public enum Visibility
            {
                Show,
                Hide
            }

            public VP<Visibility> visibility;

            #endregion

            public VP<bool> autoHint;

            #region State

            public abstract class State : Data
            {
                public enum Type
                {
                    Not,
                    Normal,
                    Get,
                    Getting,
                    Show
                }

                public abstract Type getType();
            }

            public VP<State> state;

            #endregion

            public VP<Computer.AI> ai;

            public VP<EditHintAIUI.UIData> editHintAIUIData;

            #region showAnimation

            public VP<ShowAnimationUI.UIData> showAnimation;

            public void OnHide()
            {
                this.visibility.v = Visibility.Hide;
            }

            #endregion

            #region Constructor

            public enum Property
            {
                gameData,
                visibility,
                autoHint,
                state,
                ai,
                editHintAIUIData,
                showAnimation
            }

            public UIData() : base()
            {
                this.gameData = new VP<ReferenceData<GameData>>(this, (byte)Property.gameData, new ReferenceData<GameData>(null));
                this.visibility = new VP<Visibility>(this, (byte)Property.visibility, Visibility.Hide);
                this.autoHint = new VP<bool>(this, (byte)Property.autoHint, false);
                this.state = new VP<State>(this, (byte)Property.state, new NotUI.UIData());
                this.ai = new VP<Computer.AI>(this, (byte)Property.ai, null);
                this.editHintAIUIData = new VP<EditHintAIUI.UIData>(this, (byte)Property.editHintAIUIData, null);
                // showAnimation
                {
                    this.showAnimation = new VP<ShowAnimationUI.UIData>(this, (byte)Property.showAnimation, new ShowAnimationUI.UIData());
                    this.showAnimation.v.onHide.v = OnHide;
                }
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // editHintAIUIData
                    if (!isProcess)
                    {
                        EditHintAIUI.UIData editHintAIUIData = this.editHintAIUIData.v;
                        if (editHintAIUIData != null)
                        {
                            isProcess = editHintAIUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("editHintAIUIData null: " + this);
                        }
                    }
                    // back
                    if (!isProcess)
                    {
                        if (this.visibility.v == Visibility.Show)
                        {
                            if (InputEvent.isBackEvent(e))
                            {
                                HintUI hintUI = this.findCallBack<HintUI>();
                                if (hintUI != null)
                                {
                                    hintUI.onClickBtnBack();
                                    isProcess = true;
                                }
                                else
                                {
                                    Debug.LogError("hintUI null");
                                }
                            }
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            HintUI hintUI = this.findCallBack<HintUI>();
                            if (hintUI != null)
                            {
                                isProcess = hintUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("hintUI null: " + this);
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Hint");

        public Text tvAuto;
        private static readonly TxtLanguage txtAuto = new TxtLanguage("Auto");

        public Text tvEditAI;
        private static readonly TxtLanguage txtEditAI = new TxtLanguage("Edit AI");

        static HintUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Gợi Ý");
                txtAuto.add(Language.Type.vi, "Tự Động");
                txtEditAI.add(Language.Type.vi, "Chỉnh AI");
            }
            // rect
            {
                // stateRect
                {
                    // anchoredPosition: (0.0, -40.0); anchorMin: (0.5, 1.0); anchorMax: (0.5, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (-60.0, -70.0); offsetMax: (60.0, -40.0); sizeDelta: (120.0, 30.0);
                    stateRect.anchoredPosition = new Vector3(0.0f, -40.0f, 0.0f);
                    stateRect.anchorMin = new Vector2(0.5f, 1.0f);
                    stateRect.anchorMax = new Vector2(0.5f, 1.0f);
                    stateRect.pivot = new Vector2(0.5f, 1.0f);
                    stateRect.offsetMin = new Vector2(-60.0f, -70.0f);
                    stateRect.offsetMax = new Vector2(60.0f, -40.0f);
                    stateRect.sizeDelta = new Vector2(120.0f, 30.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Button btnBack;

        public Button btnShowHint;

        public Toggle tgAutoHint;

        public Button btnEditHint;

        public RectTransform contentContainer;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // visibility
                    {
                        // contentContainer
                        if (contentContainer != null)
                        {
                            contentContainer.gameObject.SetActive(this.data.visibility.v == UIData.Visibility.Show);
                        }
                        else
                        {
                            Debug.LogError("contentContainer null");
                        }
                        // editAI
                        if (this.data.visibility.v == UIData.Visibility.Hide)
                        {
                            this.data.editHintAIUIData.v = null;
                        }
                    }
                    // tgAutoHint
                    if (tgAutoHint != null)
                    {
                        tgAutoHint.isOn = this.data.autoHint.v;
                    }
                    else
                    {
                        Debug.LogError("tgAutoHint null: " + this);
                    }
                    // editHintUIData
                    {
                        EditHintAIUI.UIData editHintAIUIData = this.data.editHintAIUIData.v;
                        if (editHintAIUIData != null)
                        {
                            AIUI.UIData aiUIData = editHintAIUIData.aiUIData.v;
                            if (aiUIData != null)
                            {
                                EditData<Computer.AI> editAI = aiUIData.editAI.v;
                                if (editAI != null)
                                {
                                    // origin
                                    editAI.origin.v = new ReferenceData<Computer.AI>(this.data.ai.v);
                                    // show
                                    // canEdit
                                    editAI.canEdit.v = true;
                                    // editType
                                }
                                else
                                {
                                    Debug.LogError("editAI null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("aiUIData null: " + this);
                            }
                        }
                        else
                        {
                            // Debug.LogError ("editHintAIUIData null: " + this);
                        }
                    }
                    // UI
                    {
                        float buttonSize = Setting.get().getButtonSize();
                        float deltaY = 0;
                        // header
                        {
                            UIRectTransform.SetTitleTransform(lbTitle);
                            UIRectTransform.SetButtonTopLeftTransform(btnBack);
                            deltaY += buttonSize;
                        }
                        // btnShowHint
                        {
                            if (btnShowHint != null)
                            {
                                UIRectTransform.SetPosY((RectTransform)btnShowHint.transform, deltaY + 10);
                            }
                            else
                            {
                                Debug.LogError("btnShowHint null");
                            }
                            UIRectTransform.SetPosY(this.data.state.v, deltaY + 10);
                            deltaY += 40;
                        }
                        // tgAuto
                        {
                            if (tgAutoHint != null)
                            {
                                UIRectTransform.SetPosY((RectTransform)tgAutoHint.transform, deltaY + 10);
                            }
                            else
                            {
                                Debug.LogError("tgAutoHint null");
                            }
                            deltaY += 40;
                        }
                        // btnEditHint
                        {
                            if (btnEditHint != null)
                            {
                                UIRectTransform.SetPosY((RectTransform)btnEditHint.transform, deltaY + 10);
                            }
                            else
                            {
                                Debug.LogError("btnEditHint null");
                            }
                            deltaY += 50;
                        }
                        // set height
                        if (contentContainer != null)
                        {
                            UIRectTransform.SetHeight(contentContainer, deltaY);
                        }
                        else
                        {
                            Debug.LogError("contentContainer null");
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
                            Debug.LogError("lbTitle null");
                        }
                        if (tvAuto != null)
                        {
                            tvAuto.text = txtAuto.get();
                        }
                        else
                        {
                            Debug.LogError("tvAuto null");
                        }
                        if (tvEditAI != null)
                        {
                            tvEditAI.text = txtEditAI.get();
                        }
                        else
                        {
                            Debug.LogError("tvEditAI null");
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

        public NotUI notPrefab;
        public NormalUI normalPrefab;
        public GetUI getPrefab;
        public GettingUI gettingPrefab;
        public ShowUI showPrefab;
        private static readonly UIRectTransform stateRect = new UIRectTransform();

        public EditHintAIUI editHintAIPrefab;

        public ShowAnimationUI showAnimationUI;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Update
                {
                    UpdateUtils.makeUpdate<PreventAINullUpdate, HintUI.UIData>(uiData, this.transform);
                    UpdateUtils.makeUpdate<HintUpdate, HintUI.UIData>(uiData, this.transform);
                }
                // Child
                {
                    uiData.gameData.allAddCallBack(this);
                    uiData.state.allAddCallBack(this);
                    uiData.editHintAIUIData.allAddCallBack(this);
                    uiData.showAnimation.allAddCallBack(this);
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
                if (data is GameData)
                {
                    // GameData gameData = data as GameData;
                    // reset state
                    {
                        if (this.data != null)
                        {
                            NotUI.UIData notUIData = this.data.state.newOrOld<NotUI.UIData>();
                            {

                            }
                            this.data.state.v = notUIData;
                        }
                        else
                        {
                            Debug.LogError("data null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
                if (data is UIData.State)
                {
                    UIData.State state = data as UIData.State;
                    {
                        switch (state.getType())
                        {
                            case UIData.State.Type.Not:
                                {
                                    NotUI.UIData notUIData = state as NotUI.UIData;
                                    UIUtils.Instantiate(notUIData, notPrefab, contentContainer, stateRect);
                                }
                                break;
                            case UIData.State.Type.Normal:
                                {
                                    NormalUI.UIData normalUIData = state as NormalUI.UIData;
                                    UIUtils.Instantiate(normalUIData, normalPrefab, contentContainer, stateRect);
                                }
                                break;
                            case UIData.State.Type.Get:
                                {
                                    GetUI.UIData getUIData = state as GetUI.UIData;
                                    UIUtils.Instantiate(getUIData, getPrefab, contentContainer, stateRect);
                                }
                                break;
                            case UIData.State.Type.Getting:
                                {
                                    GettingUI.UIData gettingUIData = state as GettingUI.UIData;
                                    UIUtils.Instantiate(gettingUIData, gettingPrefab, contentContainer, stateRect);
                                }
                                break;
                            case UIData.State.Type.Show:
                                {
                                    ShowUI.UIData showUIData = state as ShowUI.UIData;
                                    UIUtils.Instantiate(showUIData, showPrefab, contentContainer, stateRect);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                break;
                        }
                    }
                    dirty = true;
                    return;
                }
                if (data is EditHintAIUI.UIData)
                {
                    EditHintAIUI.UIData editHintAIUIData = data as EditHintAIUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(editHintAIUIData, editHintAIPrefab, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if (data is ShowAnimationUI.UIData)
                {
                    ShowAnimationUI.UIData showAnimationUIData = data as ShowAnimationUI.UIData;
                    // UI
                    {
                        if (showAnimationUI != null)
                        {
                            showAnimationUI.setData(showAnimationUIData);
                        }
                        else
                        {
                            Debug.LogError("showAnimationUI null");
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
                // Update
                {
                    uiData.removeCallBackAndDestroy(typeof(PreventAINullUpdate));
                    uiData.removeCallBackAndDestroy(typeof(HintUpdate));
                }
                // Child
                {
                    uiData.gameData.allRemoveCallBack(this);
                    uiData.state.allRemoveCallBack(this);
                    uiData.editHintAIUIData.allRemoveCallBack(this);
                    uiData.showAnimation.allRemoveCallBack(this);
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
                if (data is GameData)
                {
                    // GameData gameData = data as GameData;
                    return;
                }
                if (data is UIData.State)
                {
                    UIData.State state = data as UIData.State;
                    {
                        switch (state.getType())
                        {
                            case UIData.State.Type.Not:
                                {
                                    NotUI.UIData notUIData = state as NotUI.UIData;
                                    notUIData.removeCallBackAndDestroy(typeof(NotUI));
                                }
                                break;
                            case UIData.State.Type.Normal:
                                {
                                    NormalUI.UIData normalUIData = state as NormalUI.UIData;
                                    normalUIData.removeCallBackAndDestroy(typeof(NormalUI));
                                }
                                break;
                            case UIData.State.Type.Get:
                                {
                                    GetUI.UIData getUIData = state as GetUI.UIData;
                                    getUIData.removeCallBackAndDestroy(typeof(GetUI));
                                }
                                break;
                            case UIData.State.Type.Getting:
                                {
                                    GettingUI.UIData gettingUIData = state as GettingUI.UIData;
                                    gettingUIData.removeCallBackAndDestroy(typeof(GettingUI));
                                }
                                break;
                            case UIData.State.Type.Show:
                                {
                                    ShowUI.UIData showUIData = state as ShowUI.UIData;
                                    showUIData.removeCallBackAndDestroy(typeof(ShowUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                if (data is EditHintAIUI.UIData)
                {
                    EditHintAIUI.UIData editHintAIUIData = data as EditHintAIUI.UIData;
                    // UI
                    {
                        editHintAIUIData.removeCallBackAndDestroy(typeof(EditHintAIUI));
                    }
                    return;
                }
                if (data is ShowAnimationUI.UIData)
                {
                    ShowAnimationUI.UIData showAnimationUIData = data as ShowAnimationUI.UIData;
                    // UI
                    {
                        if (showAnimationUI != null)
                        {
                            showAnimationUI.setDataNull(showAnimationUIData);
                        }
                        else
                        {
                            Debug.LogError("showAnimationUI null");
                        }
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
                    case UIData.Property.gameData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.visibility:
                        dirty = true;
                        break;
                    case UIData.Property.autoHint:
                        dirty = true;
                        break;
                    case UIData.Property.state:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.ai:
                        dirty = true;
                        break;
                    case UIData.Property.editHintAIUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showAnimation:
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
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is GameData)
                {
                    return;
                }
                if (wrapProperty.p is UIData.State)
                {
                    return;
                }
                if (wrapProperty.p is EditHintAIUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is ShowAnimationUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs);
        }

        #endregion

        #region back

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                if (showAnimationUI != null)
                {
                    ShowAnimationUI.UIData showAnimationUIData = this.data.showAnimation.v;
                    if (showAnimationUIData != null)
                    {
                        if ((showAnimationUIData.state.v is ShowAnimationUI.Normal))
                        {
                            ShowAnimationUI.Hide hide = new ShowAnimationUI.Hide();
                            {
                                hide.uid = showAnimationUIData.state.makeId();
                            }
                            showAnimationUIData.state.v = hide;
                        }
                        else
                        {
                            Debug.LogError("state error: " + showAnimationUIData.state.v);
                        }
                    }
                    else
                    {
                        Debug.LogError("showAnimationUIData null");
                    }
                }
                else
                {
                    Debug.LogError("showAnimationUI null");
                    back();
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

        public void back()
        {
            if (this.data != null)
            {
                this.data.visibility.v = UIData.Visibility.Hide;
            }
            else
            {
                Debug.LogError("data null");
            }
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnHint()
        {
            if (this.data != null)
            {
                if (this.data.state.v != null)
                {
                    if (this.data.state.v is NormalUI.UIData)
                    {
                        GetUI.UIData getUIData = this.data.state.newOrOld<GetUI.UIData>();
                        {

                        }
                        this.data.state.v = getUIData;
                    }
                    else if (this.data.state.v is ShowUI.UIData)
                    {
                        NormalUI.UIData normalUIData = this.data.state.newOrOld<NormalUI.UIData>();
                        {

                        }
                        this.data.state.v = normalUIData;
                    }
                    else
                    {
                        NormalUI.UIData normalUIData = this.data.state.newOrOld<NormalUI.UIData>();
                        {

                        }
                        this.data.state.v = normalUIData;
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnAI()
        {
            if (this.data != null)
            {
                EditHintAIUI.UIData editHintAIUIData = this.data.editHintAIUIData.newOrOld<EditHintAIUI.UIData>();
                {
                    AIUI.UIData aiUIData = editHintAIUIData.aiUIData.v;
                    if (aiUIData != null)
                    {
                        EditData<Computer.AI> editAI = aiUIData.editAI.v;
                        if (editAI != null)
                        {
                            editAI.origin.v = new ReferenceData<Computer.AI>(this.data.ai.v);
                            editAI.canEdit.v = true;
                            editAI.editType.v = Data.EditType.Immediate;
                        }
                        else
                        {
                            Debug.LogError("editAI null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("aiUIData null: " + this);
                    }
                }
                this.data.editHintAIUIData.v = editHintAIUIData;
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onToggleAutoChange(bool newAuto)
        {
            Debug.LogError("onToggleAutoChange: " + newAuto + "; " + this);
            if (this.data != null)
            {
                if (tgAutoHint != null)
                {
                    this.data.autoHint.v = tgAutoHint.isOn;
                }
                else
                {
                    Debug.LogError("tgAutoHint null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}