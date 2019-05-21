using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
    public class UseRuleInputNoneUI : UIBehavior<UseRuleInputNoneUI.UIData>
    {

        #region UIData

        public class UIData : UseRuleInputUI.UIData.Sub
        {

            public VP<UseRuleInputNoneBtnResetUI.UIData> btnReset;

            #region Constructor

            public enum Property
            {
                btnReset
            }

            public UIData() : base()
            {
                this.btnReset = new VP<UseRuleInputNoneBtnResetUI.UIData>(this, (byte)Property.btnReset, new UseRuleInputNoneBtnResetUI.UIData());
            }

            #endregion

            public override Type getType()
            {
                return Type.None;
            }

            public override void onClickCard(Card card)
            {
                if (card != null)
                {
                    UseRuleInputUI.UIData useRuleInputUIData = this.findDataInParent<UseRuleInputUI.UIData>();
                    if (useRuleInputUIData != null)
                    {
                        UseRuleInputCardUI.UIData useRuleInputCardUIData = new UseRuleInputCardUI.UIData();
                        {
                            useRuleInputCardUIData.uid = useRuleInputUIData.sub.makeId();
                            useRuleInputCardUIData.card.v = new ReferenceData<Card>(card);
                        }
                        useRuleInputUIData.sub.v = useRuleInputCardUIData;
                    }
                    else
                    {
                        Debug.LogError("useRuleInputUIData null");
                    }
                }
                else
                {
                    Debug.LogError("card null");
                }
            }

            public override void onClickPile(Pile pile)
            {

            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            UseRuleInputNoneUI useRuleInputNoneUI = this.findCallBack<UseRuleInputNoneUI>();
                            if (useRuleInputNoneUI != null)
                            {
                                isProcess = useRuleInputNoneUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("useRuleInputNoneUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Solitaire ? 1 : 0;
        }

        #region txt, rect

        static UseRuleInputNoneUI()
        {
            // rect
            {
                // btnResetRect
                {
                    // anchoredPosition: (0.0, 8.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 0.0);
                    // offsetMin: (-80.0, 8.0); offsetMax: (0.0, 30.0); sizeDelta: (80.0, 22.0);
                    btnResetRect.anchoredPosition = new Vector3(0.0f, 8.0f, 0.0f);
                    btnResetRect.anchorMin = new Vector2(1.0f, 1.0f);
                    btnResetRect.anchorMax = new Vector2(1.0f, 1.0f);
                    btnResetRect.pivot = new Vector2(1.0f, 0.0f);
                    btnResetRect.offsetMin = new Vector2(-80.0f, 8.0f);
                    btnResetRect.offsetMax = new Vector2(0.0f, 30.0f);
                    btnResetRect.sizeDelta = new Vector2(80.0f, 22.0f);
                }
            }
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

                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return false;
        }

        #endregion

        #region implement callBacks

        public UseRuleInputNoneBtnResetUI btnResetPrefab;
        private static readonly UIRectTransform btnResetRect = new UIRectTransform();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.btnReset.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if(data is UseRuleInputNoneBtnResetUI.UIData)
            {
                UseRuleInputNoneBtnResetUI.UIData btnResetUIData = data as UseRuleInputNoneBtnResetUI.UIData;
                // UI
                {
                    // find container
                    Transform btnResetContainer = null;
                    {
                        GameDataBoardUI.UIData gameDataBoardUIData = btnResetUIData.findDataInParent<GameDataBoardUI.UIData>();
                        if (gameDataBoardUIData != null)
                        {
                            GameDataBoardUI gameDataBoardUI = gameDataBoardUIData.findCallBack<GameDataBoardUI>();
                            if (gameDataBoardUI != null)
                            {
                                btnResetContainer = gameDataBoardUI.transform;
                            }
                            else
                            {
                                Debug.LogError("gameDataBoardUI null");
                            }
                        }
                        else
                        {
                            Debug.LogError("gameDataBoardUIData null");
                        }
                    }
                    // set
                    UIUtils.Instantiate(btnResetUIData, btnResetPrefab, btnResetContainer, btnResetRect);
                    UIRectTransform.SetSiblingIndex(btnResetUIData, 0);
                }
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
                // Child
                {
                    uiData.btnReset.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is UseRuleInputNoneBtnResetUI.UIData)
            {
                UseRuleInputNoneBtnResetUI.UIData btnResetUIData = data as UseRuleInputNoneBtnResetUI.UIData;
                // UI
                {
                    btnResetUIData.removeCallBackAndDestroy(typeof(UseRuleInputNoneBtnResetUI));
                }
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
                    case UIData.Property.btnReset:
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
            if(wrapProperty.p is UseRuleInputNoneBtnResetUI.UIData)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {
                UIUtils.SetButtonOnClick(btnReset, onClickBtnReset);
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
                        case KeyCode.R:
                            {
                                if (btnReset != null && btnReset.gameObject.activeInHierarchy && btnReset.interactable)
                                {
                                    this.onClickBtnReset();
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

        public Button btnReset;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnReset()
        {
            if (this.data != null)
            {
                Solitaire solitaire = null;
                // Check isActive
                bool isActive = false;
                {
                    UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                    if (useRuleInputUIData != null)
                    {
                        solitaire = useRuleInputUIData.solitaire.v.data;
                        if (solitaire != null)
                        {
                            if (Game.IsPlaying(solitaire))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("solitaire null: " + this);
                            return;
                        }
                    }
                    else
                    {
                        Debug.LogError("useRuleInputUIData null: " + this);
                    }
                }
                if (isActive)
                {
                    ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                    if (clientInput != null)
                    {
                        SolitaireReset solitaireReset = new SolitaireReset();
                        {

                        }
                        clientInput.makeSend(solitaireReset);
                    }
                    else
                    {
                        Debug.LogError("clientInput null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("not active: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}