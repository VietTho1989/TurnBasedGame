using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught.UseRule
{
    public class BtnChosenMoveHolder : SriaHolderBehavior<BtnChosenMoveHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<EnglishDraughtMove>> englishDraughtMove;

            public VP<OnClick> onClick;

            #region Constructor

            public enum Property
            {
                englishDraughtMove,
                onClick
            }

            public UIData() : base()
            {
                this.englishDraughtMove = new VP<ReferenceData<EnglishDraughtMove>>(this, (byte)Property.englishDraughtMove, new ReferenceData<EnglishDraughtMove>(null));
                this.onClick = new VP<OnClick>(this, (byte)Property.onClick, null);
            }

            #endregion

            public void updateView(BtnChosenMoveAdapter.UIData myParams)
            {
                // Find
                EnglishDraughtMove englishDraughtMove = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.englishDraughtMoves.Count)
                    {
                        englishDraughtMove = myParams.englishDraughtMoves[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.englishDraughtMove.v = new ReferenceData<EnglishDraughtMove>(englishDraughtMove);
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
                            BtnChosenMoveHolder btnChosenMoveHolder = this.findCallBack<BtnChosenMoveHolder>();
                            if (btnChosenMoveHolder != null)
                            {
                                isProcess = btnChosenMoveHolder.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("btnChosenMoveHolder null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        public interface OnClick
        {
            void onClickMove(EnglishDraughtMove englishDraughtMove);
        }

        #endregion

        #region Refresh

        public Image imgPiece;

        public Text tvMove;

        public override void refresh()
        {
            base.refresh();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EnglishDraughtMove englishDraughtMove = this.data.englishDraughtMove.v.data;
                    if (englishDraughtMove != null)
                    {
                        // imgPiece
                        {
                            if (imgPiece != null)
                            {
                                // find piece
                                byte piece = 0;
                                {
                                    EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = this.data.findDataInParent<EnglishDraughtGameDataUI.UIData>();
                                    if (englishDraughtGameDataUIData != null)
                                    {
                                        GameData gameData = englishDraughtGameDataUIData.gameData.v.data;
                                        if (gameData != null)
                                        {
                                            if (gameData.gameType.v != null && gameData.gameType.v is EnglishDraught)
                                            {
                                                EnglishDraught englishDraught = gameData.gameType.v as EnglishDraught;
                                                piece = EnglishDraught.getPiece(englishDraught.Sqs.vs, englishDraughtMove.from());
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("gameData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("englishDraughtGameDataUIData null: " + this);
                                    }
                                }
                                // set
                                {
                                    imgPiece.sprite = EnglishDraughtSpriteContainer.get().getSprite(piece);
                                }
                            }
                            else
                            {
                                Debug.LogError("imgPromotion null: " + this);
                            }
                        }
                        // tvMove
                        if (tvMove != null)
                        {
                            tvMove.text = Common.printMove(englishDraughtMove);
                        }
                        else
                        {
                            Debug.LogError("tvMove null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("englishDraughtMove null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        #endregion

        #region implement callBacks

        private UseRuleInputUI.UIData useRuleInputUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.useRuleInputUIData);
                }
                // Child
                {
                    uiData.englishDraughtMove.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is UseRuleInputUI.UIData)
                {
                    UseRuleInputUI.UIData useRuleInputUIData = data as UseRuleInputUI.UIData;
                    // Child
                    {
                        useRuleInputUIData.englishDraught.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // EnglishDraught
                {
                    if (data is EnglishDraught)
                    {
                        EnglishDraught englishDraught = data as EnglishDraught;
                        // Child
                        {
                            englishDraught.C.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is SCheckerBoard)
                    {
                        dirty = true;
                    }
                }
            }
            // Child
            {
                if (data is EnglishDraughtMove)
                {
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.useRuleInputUIData);
                }
                // Child
                {
                    uiData.englishDraughtMove.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is UseRuleInputUI.UIData)
                {
                    UseRuleInputUI.UIData useRuleInputUIData = data as UseRuleInputUI.UIData;
                    // Child
                    {
                        useRuleInputUIData.englishDraught.allRemoveCallBack(this);
                    }
                    return;
                }
                // EnglishDraught
                {
                    if (data is EnglishDraught)
                    {
                        EnglishDraught englishDraught = data as EnglishDraught;
                        // Child
                        {
                            englishDraught.C.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is SCheckerBoard)
                    {
                        return;
                    }
                }
            }
            // Child
            {
                if (data is EnglishDraughtMove)
                {
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
                    case UIData.Property.englishDraughtMove:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.onClick:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                if (wrapProperty.p is UseRuleInputUI.UIData)
                {
                    switch ((UseRuleInputUI.UIData.Property)wrapProperty.n)
                    {
                        case UseRuleInputUI.UIData.Property.englishDraught:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case UseRuleInputUI.UIData.Property.state:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // EnglishDraught
                {
                    if (wrapProperty.p is EnglishDraught)
                    {
                        switch ((EnglishDraught.Property)wrapProperty.n)
                        {
                            case EnglishDraught.Property.Sqs:
                                dirty = true;
                                break;
                            case EnglishDraught.Property.C:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EnglishDraught.Property.nPSq:
                                dirty = true;
                                break;
                            case EnglishDraught.Property.eval:
                                dirty = true;
                                break;
                            case EnglishDraught.Property.nWhite:
                                dirty = true;
                                break;
                            case EnglishDraught.Property.nBlack:
                                dirty = true;
                                break;
                            case EnglishDraught.Property.SideToMove:
                                dirty = true;
                                break;
                            case EnglishDraught.Property.extra:
                                dirty = true;
                                break;
                            case EnglishDraught.Property.HashKey:
                                dirty = true;
                                break;
                            case EnglishDraught.Property.ply:
                                dirty = true;
                                break;
                            case EnglishDraught.Property.RepNum:
                                dirty = true;
                                break;
                            case EnglishDraught.Property.maxPly:
                                dirty = true;
                                break;
                            case EnglishDraught.Property.turn:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is SCheckerBoard)
                    {
                        switch ((SCheckerBoard.Property)wrapProperty.n)
                        {
                            case SCheckerBoard.Property.WP:
                                dirty = true;
                                break;
                            case SCheckerBoard.Property.BP:
                                dirty = true;
                                break;
                            case SCheckerBoard.Property.K:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            // Child
            {
                if (wrapProperty.p is EnglishDraughtMove)
                {
                    switch ((EnglishDraughtMove.Property)wrapProperty.n)
                    {
                        case EnglishDraughtMove.Property.SrcDst:
                            dirty = true;
                            break;
                        case EnglishDraughtMove.Property.cPath:
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

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {
                UIUtils.SetButtonOnClick(btnMove, onClickMove);
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
                        case KeyCode.M:
                            {
                                if (btnMove != null && btnMove.gameObject.activeInHierarchy && btnMove.interactable)
                                {
                                    this.onClickMove();
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

        public Button btnMove;

        [UnityEngine.Scripting.Preserve]
        public void onClickMove()
        {
            if (this.data != null)
            {
                EnglishDraughtMove englishDraughtMove = this.data.englishDraughtMove.v.data;
                if (englishDraughtMove != null)
                {
                    if (this.data.onClick.v != null)
                    {
                        this.data.onClick.v.onClickMove(englishDraughtMove);
                    }
                    else
                    {
                        Debug.LogError("onClick null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("englishDraughtMove null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}