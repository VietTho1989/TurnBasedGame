using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
    public class EndUI : UIBehavior<EndUI.UIData>
    {

        #region UIData

        public class UIData : StateUI.UIData.Sub
        {

            public VP<ReferenceData<End>> end;

            public VP<BtnRequestNewUI.UIData> btnRequestNew;

            #region Constructor

            public enum Property
            {
                end,
                btnRequestNew
            }

            public UIData() : base()
            {
                this.end = new VP<ReferenceData<End>>(this, (byte)Property.end, new ReferenceData<End>(null));
                this.btnRequestNew = new VP<BtnRequestNewUI.UIData>(this, (byte)Property.btnRequestNew, new BtnRequestNewUI.UIData());
            }

            #endregion

            public override State.Type getType()
            {
                return State.Type.End;
            }

        }

        #endregion

        #region txt

        public Text tvMessage;
        public static readonly TxtLanguage txtMessage = new TxtLanguage();

        static EndUI()
        {
            // txt
            txtMessage.add(Language.Type.vi, "Game Kết Thúc");
            // rect
            {
                // btnRequestNewRect
                {
                    // anchoredPosition: (0.0, -24.0); anchorMin: (0.5, 1.0); anchorMax: (0.5, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (-60.0, -52.0); offsetMax: (60.0, -24.0); sizeDelta: (120.0, 28.0);
                    btnRequestNewRect.anchoredPosition = new Vector3(0.0f, -24.0f);
                    btnRequestNewRect.anchorMin = new Vector2(0.5f, 1.0f);
                    btnRequestNewRect.anchorMax = new Vector2(0.5f, 1.0f);
                    btnRequestNewRect.pivot = new Vector2(0.5f, 1.0f);
                    btnRequestNewRect.offsetMin = new Vector2(-50.0f, -52.0f);
                    btnRequestNewRect.offsetMax = new Vector2(50.0f, -24.0f);
                    btnRequestNewRect.sizeDelta = new Vector2(100.0f, 28.0f);
                }
                // normal
                {
                    // anchoredPosition: (0.0, 30.0); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                    // offsetMin: (-80.0, 15.0); offsetMax: (80.0, 45.0); sizeDelta: (160.0, 30.0);
                    normalContentRect.anchoredPosition = new Vector3(0.0f, 30.0f, 0.0f);
                    normalContentRect.anchorMin = new Vector2(0.5f, 0.5f);
                    normalContentRect.anchorMax = new Vector2(0.5f, 0.5f);
                    normalContentRect.pivot = new Vector2(0.5f, 0.5f);
                    normalContentRect.offsetMin = new Vector2(-60.0f, 15.0f);
                    normalContentRect.offsetMax = new Vector2(60.0f, 39.0f);
                    normalContentRect.sizeDelta = new Vector2(120.0f, 24.0f);
                }
                // expandRect
                {
                    // anchoredPosition: (0.0, 30.0); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                    // offsetMin: (-80.0, 0.0); offsetMax: (80.0, 60.0); sizeDelta: (160.0, 60.0);
                    expandContentRect.anchoredPosition = new Vector3(0.0f, 30.0f, 0.0f);
                    expandContentRect.anchorMin = new Vector2(0.5f, 0.5f);
                    expandContentRect.anchorMax = new Vector2(0.5f, 0.5f);
                    expandContentRect.pivot = new Vector2(0.5f, 0.5f);
                    expandContentRect.offsetMin = new Vector2(-60.0f, 0.0f);
                    expandContentRect.offsetMax = new Vector2(60.0f, 60.0f);
                    expandContentRect.sizeDelta = new Vector2(120.0f, 60.0f);
                }
            }
        }

        #endregion

        #region Refresh

        private static readonly UIRectTransform normalContentRect = new UIRectTransform();
        private static readonly UIRectTransform expandContentRect = new UIRectTransform();
        public Transform contentContainer;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    End end = this.data.end.v.data;
                    if (end != null)
                    {
                        // contentContainer
                        {
                            if (contentContainer != null)
                            {
                                bool isOnAnimation = false;
                                {
                                    GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
                                    if (gameUIData != null)
                                    {
                                        GameDataUI.UIData gameDataUIData = gameUIData.gameDataUI.v;
                                        if (gameDataUIData != null)
                                        {
                                            GameDataBoardUI.UIData gameDataBoardUIData = gameDataUIData.board.v;
                                            if (gameDataBoardUIData != null)
                                            {
                                                isOnAnimation = GameDataBoardUI.UIData.isOnAnimation(gameDataBoardUIData);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("gameDataUIData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameUIData null: " + this);
                                    }
                                }
                                contentContainer.gameObject.SetActive(!isOnAnimation);
                                if (isOnAnimation)
                                {
                                    dirty = true;
                                }
                            }
                            else
                            {
                                Debug.LogError("contentContainer null: " + this);
                            }
                        }
                        // contentContainerRect
                        {
                            // find
                            bool haveSub = false;
                            {
                                BtnRequestNewUI.UIData btnRequestNewUIData = this.data.btnRequestNew.v;
                                if (btnRequestNewUIData != null)
                                {
                                    haveSub = (btnRequestNewUIData.sub.v != null);
                                }
                                else
                                {
                                    Debug.LogError("btnRequestNewUIData null");
                                }
                            }
                            // process
                            if (haveSub)
                            {
                                expandContentRect.set((RectTransform)contentContainer);
                            }
                            else
                            {
                                normalContentRect.set((RectTransform)contentContainer);
                            }
                        }
                        // txt
                        {
                            if (tvMessage != null)
                            {
                                tvMessage.text = txtMessage.get("Game End");
                            }
                            else
                            {
                                Debug.LogError("tvMessage null: " + this);
                            }
                        }
                        // position
                        {
                            // find
                            RectTransform boardTransform = null;
                            float boardLeft = 0;
                            float boardRight = 0;
                            float boardTop = 0;
                            float boardBottom = 0;
                            {
                                GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
                                if (gameUIData != null)
                                {
                                    GameDataUI.UIData gameDataUIData = gameUIData.gameDataUI.v;
                                    if (gameDataUIData != null)
                                    {
                                        GameDataBoardUI.UIData gameDataBoardUIData = gameDataUIData.board.v;
                                        if (gameDataBoardUIData != null)
                                        {
                                            // boardTransform
                                            {
                                                GameDataBoardUI gameDataBoardUI = gameDataBoardUIData.findCallBack<GameDataBoardUI>();
                                                if (gameDataBoardUI != null)
                                                {
                                                    boardTransform = (RectTransform)gameDataBoardUI.transform;
                                                }
                                                else
                                                {
                                                    Debug.LogError("gameDataBoardUI null");
                                                }
                                            }
                                            // margin
                                            {
                                                boardLeft = gameDataBoardUIData.left.v;
                                                boardRight = gameDataBoardUIData.right.v;
                                                boardTop = gameDataBoardUIData.top.v;
                                                boardBottom = gameDataBoardUIData.bottom.v;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("gameDataBoardUIData null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameDataUIData null");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameUIData null");
                                }
                            }
                            // process
                            if (boardTransform != null)
                            {
                                // find
                                float left = boardTransform.rect.xMin;
                                float right = boardTransform.rect.xMax;
                                float top = boardTransform.rect.yMin;
                                float bottom = boardTransform.rect.yMax;
                                {
                                    UIRectTransform.GetMargin(boardTransform, out left, out right, out top, out bottom);
                                    left -= boardLeft;
                                    right += boardRight;
                                    top -= boardTop;
                                    bottom += boardBottom;
                                }
                                // process
                                RectTransform endTransform = (RectTransform)contentContainer;
                                if (endTransform != null)
                                {
                                    // get gameActions dimension
                                    float endWidth = endTransform.rect.width;
                                    float endHeight = endTransform.rect.height;
                                    // get gameDataUI dimension
                                    float gameWidth = 0;
                                    float gameHeight = 0;
                                    {
                                        RectTransform gameDataUITransform = (RectTransform)this.transform;
                                        if (gameDataUITransform != null)
                                        {
                                            gameWidth = gameDataUITransform.rect.width;
                                            gameHeight = gameDataUITransform.rect.height;
                                        }
                                        else
                                        {
                                            Debug.LogError("gameDataUITransform null");
                                        }
                                    }
                                    // portrait view
                                    if (gameWidth <= gameHeight)
                                    {
                                        float x = 0;
                                        endTransform.anchoredPosition = new Vector2(x, bottom + 60 / 2 + GameDataBoardUI.Margin);
                                    }
                                    // landscape view
                                    else
                                    {
                                        float x = left - endWidth / 2 - GameDataBoardUI.Margin; ;
                                        endTransform.anchoredPosition = new Vector2(x, 30);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameActionsTransform null");
                                }
                            }
                            else
                            {
                                Debug.LogError("boardTransform null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("end null: " + this);
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

        public BtnRequestNewUI btnRequestNewPrefab;
        private static readonly UIRectTransform btnRequestNewRect = new UIRectTransform();

        private GameUI.UIData gameUIData = null;
        private GameDataBoardTransformCheckChange<GameDataUI.UIData> gameDataBoardTransformCheckChange = new GameDataBoardTransformCheckChange<GameDataUI.UIData>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.gameUIData);
                }
                // Child
                {
                    uiData.end.allAddCallBack(this);
                    uiData.btnRequestNew.allAddCallBack(this);
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
            // Parent
            {
                if(data is GameUI.UIData)
                {
                    GameUI.UIData gameUIData = data as GameUI.UIData;
                    // Child
                    {
                        gameUIData.gameDataUI.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if(data is GameDataUI.UIData)
                    {
                        GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                        // CheckChange
                        {
                            gameDataBoardTransformCheckChange.addCallBack(this);
                            gameDataBoardTransformCheckChange.setData(gameDataUIData);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if(data is GameDataBoardTransformCheckChange<GameDataUI.UIData>)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            {
                if (data is End)
                {
                    dirty = true;
                    return;
                }
                if(data is BtnRequestNewUI.UIData)
                {
                    BtnRequestNewUI.UIData btnRequestNewUIData = data as BtnRequestNewUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnRequestNewUIData, btnRequestNewPrefab, contentContainer, btnRequestNewRect);
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.gameUIData);
                }
                // Child
                {
                    uiData.end.allRemoveCallBack(this);
                    uiData.btnRequestNew.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Parent
            {
                if (data is GameUI.UIData)
                {
                    GameUI.UIData gameUIData = data as GameUI.UIData;
                    // Child
                    {
                        gameUIData.gameDataUI.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is GameDataUI.UIData)
                    {
                        GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                        // CheckChange
                        {
                            gameDataBoardTransformCheckChange.removeCallBack(this);
                            gameDataBoardTransformCheckChange.setData(null);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is GameDataBoardTransformCheckChange<GameDataUI.UIData>)
                    {
                        return;
                    }
                }
            }
            // Child
            {
                if (data is End)
                {
                    return;
                }
                if (data is BtnRequestNewUI.UIData)
                {
                    BtnRequestNewUI.UIData btnRequestNewUIData = data as BtnRequestNewUI.UIData;
                    // UI
                    {
                        btnRequestNewUIData.removeCallBackAndDestroy(typeof(BtnRequestNewUI));
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
                    case UIData.Property.end:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnRequestNew:
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
            // Parent
            {
                if (wrapProperty.p is GameUI.UIData)
                {
                    switch ((GameUI.UIData.Property)wrapProperty.n)
                    {
                        case GameUI.UIData.Property.game:
                            break;
                        case GameUI.UIData.Property.isReplay:
                            break;
                        case GameUI.UIData.Property.gameDataUI:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case GameUI.UIData.Property.gameBottom:
                            break;
                        case GameUI.UIData.Property.undoRedoRequestUIData:
                            break;
                        case GameUI.UIData.Property.requestDraw:
                            break;
                        case GameUI.UIData.Property.gameChatRoom:
                            break;
                        case GameUI.UIData.Property.gameHistoryUIData:
                            break;
                        case GameUI.UIData.Property.stateUI:
                            break;
                        case GameUI.UIData.Property.saveUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is GameDataUI.UIData)
                    {
                        return;
                    }
                    // CheckChange
                    if (wrapProperty.p is GameDataBoardTransformCheckChange<GameDataUI.UIData>)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            {
                if (wrapProperty.p is End)
                {
                    switch ((End.Property)wrapProperty.n)
                    {
                        case End.Property.results:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if(wrapProperty.p is BtnRequestNewUI.UIData)
                {
                    switch ((BtnRequestNewUI.UIData.Property)wrapProperty.n)
                    {
                        case BtnRequestNewUI.UIData.Property.sub:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}