using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameHistoryUI : UIBehavior<GameHistoryUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<History>> history;

        #region show

        public enum Visibility
        {
            Show,
            Hide
        }

        public VP<Visibility> visibility;

        #endregion

        public VP<ViewSaveDataUI.UIData> viewSaveDataUIData;

        public VP<BtnLoadHistoryUI.UIData> btnLoadHistoryUIData;

        #region showAnimation

        public VP<ShowAnimationUI.UIData> showAnimation;

        public void OnHide()
        {
            this.visibility.v = Visibility.Hide;
            // contentContainer
            {
                GameHistoryUI gameHistoryUI = this.findCallBack<GameHistoryUI>();
                if (gameHistoryUI != null)
                {
                    if (gameHistoryUI.contentContainer != null)
                    {
                        gameHistoryUI.contentContainer.gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.LogError("contentContainer null");
                    }
                }
                else
                {
                    Debug.LogError("gameHistoryUI null");
                }
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            history,
            visibility,
            viewSaveDataUIData,
            btnLoadHistoryUIData,
            showAnimation
        }

        public UIData() : base()
        {
            this.history = new VP<ReferenceData<History>>(this, (byte)Property.history, new ReferenceData<History>(null));
            this.visibility = new VP<Visibility>(this, (byte)Property.visibility, Visibility.Hide);
            this.viewSaveDataUIData = new VP<ViewSaveDataUI.UIData>(this, (byte)Property.viewSaveDataUIData, new ViewSaveDataUI.UIData());
            this.btnLoadHistoryUIData = new VP<BtnLoadHistoryUI.UIData>(this, (byte)Property.btnLoadHistoryUIData, new BtnLoadHistoryUI.UIData());
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
                // viewSaveDataUIData
                if (!isProcess)
                {
                    ViewSaveDataUI.UIData viewSaveDataUIData = this.viewSaveDataUIData.v;
                    if (viewSaveDataUIData != null)
                    {
                        isProcess = viewSaveDataUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("viewSaveDataUIData null: " + this);
                    }
                }
                // back
                if (!isProcess)
                {
                    if (this.visibility.v == Visibility.Show)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            GameHistoryUI gameHistoryUI = this.findCallBack<GameHistoryUI>();
                            if (gameHistoryUI != null)
                            {
                                gameHistoryUI.onClickBtnBack();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("gameHistoryUI null");
                            }
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        GameHistoryUI gameHistoryUI = this.findCallBack<GameHistoryUI>();
                        if (gameHistoryUI != null)
                        {
                            isProcess = gameHistoryUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("gameHistoryUI null: " + this);
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Game History");

    private static readonly TxtLanguage txtView = new TxtLanguage("View History");
    private static readonly TxtLanguage txtCannotView = new TxtLanguage("Not Load History");

    static GameHistoryUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Lịch Sử");
            txtView.add(Language.Type.vi, "Xem Lịch Sử");
            txtCannotView.add(Language.Type.vi, "Chưa tải lịch sử");
        }
        // rect
        {
            // btnLoadHistoryRect
            {
                // anchoredPosition: (0.0, -80.0); anchorMin: (0.5, 1.0); anchorMax: (0.5, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (-60.0, -110.0); offsetMax: (60.0, -80.0); sizeDelta: (120.0, 30.0);
                btnLoadHistoryRect.anchoredPosition = new Vector3(0.0f, -80.0f, 0.0f);
                btnLoadHistoryRect.anchorMin = new Vector2(0.5f, 1.0f);
                btnLoadHistoryRect.anchorMax = new Vector2(0.5f, 1.0f);
                btnLoadHistoryRect.pivot = new Vector2(0.5f, 1.0f);
                btnLoadHistoryRect.offsetMin = new Vector2(-60.0f, -110.0f);
                btnLoadHistoryRect.offsetMax = new Vector2(60.0f, -80.0f);
                btnLoadHistoryRect.sizeDelta = new Vector2(120.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    public Button btnBack;

    public Button btnView;
    public Text tvView;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                History history = this.data.history.v.data;
                if (history != null)
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
                    }
                    // btnView, tvView
                    {
                        if (btnView != null && tvView != null)
                        {
                            if (history.changes.vs.Count == history.changeCount.v)
                            {
                                btnView.interactable = true;
                                tvView.text = txtView.get();
                            }
                            else
                            {
                                btnView.interactable = false;
                                tvView.text = txtCannotView.get();
                            }
                        }
                        else
                        {
                            Debug.LogError("btnView null, tvView null: " + this);
                        }
                    }
                    // btnLoadHistoryUIData
                    {
                        BtnLoadHistoryUI.UIData btnLoadHistoryUIData = this.data.btnLoadHistoryUIData.v;
                        if (btnLoadHistoryUIData != null)
                        {
                            btnLoadHistoryUIData.history.v = new ReferenceData<History>(history);
                        }
                        else
                        {
                            Debug.LogError("btnLoadHistoryUIData null: " + this);
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
                        // btnView
                        {
                            if (btnView != null)
                            {
                                UIRectTransform.SetPosY((RectTransform)btnView.transform, deltaY + 10);
                            }
                            else
                            {
                                Debug.LogError("btnView null");
                            }
                            deltaY += 40;
                        }
                        // btnLoadHistory
                        {
                            UIRectTransform.SetPosY(this.data.btnLoadHistoryUIData.v, deltaY + 10);
                            deltaY += 40;
                        }
                        // bottomMargin
                        deltaY += 10;
                        // set height
                        {
                            if (contentContainer != null)
                            {
                                UIRectTransform.SetHeight(contentContainer, deltaY);
                            }
                            else
                            {
                                Debug.LogError("contentContainer null");
                            }
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
                    }
                }
                else
                {
                    // Debug.LogError ("history null: " + this);
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

    public ViewSaveDataUI viewSaveDataPrefab;
    private static readonly UIRectTransform viewSaveDataRect = UIRectTransform.CreateFullRect(30, 30, 30, 30);

    public BtnLoadHistoryUI btnLoadHistoryPrefab;
    public RectTransform contentContainer;
    private static readonly UIRectTransform btnLoadHistoryRect = new UIRectTransform();

    public ShowAnimationUI showAnimationUI;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.history.allAddCallBack(this);
                uiData.viewSaveDataUIData.allAddCallBack(this);
                uiData.btnLoadHistoryUIData.allAddCallBack(this);
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
            if (data is History)
            {
                dirty = true;
                return;
            }
            if (data is ViewSaveDataUI.UIData)
            {
                ViewSaveDataUI.UIData viewSaveDataUIData = data as ViewSaveDataUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(viewSaveDataUIData, viewSaveDataPrefab, this.transform, viewSaveDataRect);
                }
                dirty = true;
                return;
            }
            if (data is BtnLoadHistoryUI.UIData)
            {
                BtnLoadHistoryUI.UIData btnLoadHistoryUIData = data as BtnLoadHistoryUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnLoadHistoryUIData, btnLoadHistoryPrefab, contentContainer, btnLoadHistoryRect);
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
            // Child
            {
                uiData.history.allRemoveCallBack(this);
                uiData.viewSaveDataUIData.allRemoveCallBack(this);
                uiData.btnLoadHistoryUIData.allRemoveCallBack(this);
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
            if (data is History)
            {
                return;
            }
            if (data is ViewSaveDataUI.UIData)
            {
                ViewSaveDataUI.UIData viewSaveDataUIData = data as ViewSaveDataUI.UIData;
                // UI
                {
                    viewSaveDataUIData.removeCallBackAndDestroy(typeof(ViewSaveDataUI));
                }
                return;
            }
            if (data is BtnLoadHistoryUI.UIData)
            {
                BtnLoadHistoryUI.UIData btnLoadHistoryUIData = data as BtnLoadHistoryUI.UIData;
                // UI
                {
                    btnLoadHistoryUIData.removeCallBackAndDestroy(typeof(BtnLoadHistoryUI));
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
                case UIData.Property.history:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.viewSaveDataUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnLoadHistoryUIData:
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
                case UIData.Property.visibility:
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
            if (wrapProperty.p is History)
            {
                switch ((History.Property)wrapProperty.n)
                {
                    case History.Property.isActive:
                        break;
                    case History.Property.changes:
                        dirty = true;
                        break;
                    case History.Property.position:
                        break;
                    case History.Property.changeCount:
                        dirty = true;
                        break;
                    case History.Property.humanConnections:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is ViewSaveDataUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is BtnLoadHistoryUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is ShowAnimationUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
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
                    showAnimationUIData.hide();
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

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnView, onClickBtnView);
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
                    case KeyCode.V:
                        {
                            if (btnView != null && btnView.gameObject.activeInHierarchy && btnView.interactable)
                            {
                                this.onClickBtnView();
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

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnView()
    {
        if (this.data != null)
        {
            History history = this.data.history.v.data;
            if (history != null)
            {
                Game game = history.findDataInParent<Game>();
                if (game != null)
                {
                    ViewSaveDataUI.UIData viewSaveDataUIData = this.data.viewSaveDataUIData.newOrOld<ViewSaveDataUI.UIData>();
                    {
                        Save save = new Save();
                        {
                            SaveData saveData = new SaveData();
                            {
                                saveData.data = DataUtils.cloneData(game);
                            }
                            save.content = saveData;
                        }
                        viewSaveDataUIData.save.v = save;
                    }
                    this.data.viewSaveDataUIData.v = viewSaveDataUIData;
                }
                else
                {
                    Debug.LogError("game null: " + this);
                }
            }
            else
            {
                Debug.LogError("history null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}