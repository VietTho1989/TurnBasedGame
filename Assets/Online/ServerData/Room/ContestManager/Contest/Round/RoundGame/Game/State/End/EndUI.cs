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

        #region Refresh

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
                    // anchoredPosition: (0.0, -50.0); anchorMin: (0.5, 1.0); anchorMax: (0.5, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (-60.0, -80.0); offsetMax: (60.0, -50.0); sizeDelta: (120.0, 30.0);
                    btnRequestNewRect.anchoredPosition = new Vector3(0.0f, -50.0f);
                    btnRequestNewRect.anchorMin = new Vector2(0.5f, 1.0f);
                    btnRequestNewRect.anchorMax = new Vector2(0.5f, 1.0f);
                    btnRequestNewRect.pivot = new Vector2(0.5f, 1.0f);
                    btnRequestNewRect.offsetMin = new Vector2(-60.0f, -80.0f);
                    btnRequestNewRect.offsetMax = new Vector2(60.0f, -50.0f);
                    btnRequestNewRect.sizeDelta = new Vector2(120.0f, 30.0f);
                }
                // normal
                {
                    // anchoredPosition: (0.0, 30.0); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                    // offsetMin: (-100.0, 5.0); offsetMax: (100.0, 55.0); sizeDelta: (200.0, 50.0);
                    normalContentRect.anchoredPosition = new Vector3(0.0f, 30.0f, 0.0f);
                    normalContentRect.anchorMin = new Vector2(0.5f, 0.5f);
                    normalContentRect.anchorMax = new Vector2(0.5f, 0.5f);
                    normalContentRect.pivot = new Vector2(0.5f, 0.5f);
                    normalContentRect.offsetMin = new Vector2(-100.0f, 5.0f);
                    normalContentRect.offsetMax = new Vector2(100.0f, 55.0f);
                    normalContentRect.sizeDelta = new Vector2(200.0f, 50.0f);
                }
                // expandRect
                {
                    // anchoredPosition: (0.0, 30.0); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                    // offsetMin: (-100.0, -15.0); offsetMax: (100.0, 75.0); sizeDelta: (200.0, 90.0);
                    expandContentRect.anchoredPosition = new Vector3(0.0f, 30.0f, 0.0f);
                    expandContentRect.anchorMin = new Vector2(0.5f, 0.5f);
                    expandContentRect.anchorMax = new Vector2(0.5f, 0.5f);
                    expandContentRect.pivot = new Vector2(0.5f, 0.5f);
                    expandContentRect.offsetMin = new Vector2(-100.0f, -15.0f);
                    expandContentRect.offsetMax = new Vector2(100.0f, 75.0f);
                    expandContentRect.sizeDelta = new Vector2(200.0f, 90.0f);
                }
            }
        }

        #endregion

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
                    }
                    else
                    {
                        Debug.LogError("end null: " + this);
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
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