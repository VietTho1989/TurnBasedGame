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
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public static readonly TxtLanguage txtView = new TxtLanguage();
    public static readonly TxtLanguage txtCannotView = new TxtLanguage();

    static GameHistoryUI()
    {
        // txt
        {
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
                                tvView.text = txtView.get("View History");
                            }
                            else
                            {
                                btnView.interactable = false;
                                tvView.text = txtCannotView.get("Not Load History");
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
    public Transform contentContainer;
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