using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace MineSweeper.NoneRule
{
    public class ClickPosUI : UIBehavior<ClickPosUI.UIData>
    {

        #region UIData

        public class UIData : NoneRuleInputUI.UIData.Sub
        {

            public VP<int> square;

            #region Constructor

            public enum Property
            {
                square
            }

            public UIData() : base()
            {
                this.square = new VP<int>(this, (byte)Property.square, 0);
            }

            #endregion

            public override Type getType()
            {
                return Type.ClickPos;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // back
                    if (!isProcess)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            ClickPosUI clickPosUI = this.findCallBack<ClickPosUI>();
                            if (clickPosUI != null)
                            {
                                clickPosUI.onClickBtnBack();
                            }
                            else
                            {
                                Debug.LogError("clickPosUI null: " + this);
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

        public Text lbTitle;

        public Text tvSetPiece;
        public Text tvMove;
        public Text tvEndTurn;
        public Text tvClear;

        #endregion

        #region Refresh

        public GameObject ivSelect;
        public Transform contentContainer;

        public Button btnSetPiece;
        public Button btnMove;
        public Button btnEndTurn;
        public Button btnClear;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // imgSelect
                    {
                        if (ivSelect != null)
                        {
                            // show
                            {
                                Common.show(ivSelect, this.data.square.v, this.data);
                            }
                            // Scale
                            {
                                int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                ivSelect.transform.localScale = (playerView == 0 ? new Vector3(1f, 1f, 1f) : new Vector3(1f, -1f, 1f));
                            }
                        }
                        else
                        {
                            Debug.LogError("imgSelect null: " + this);
                        }
                    }
                    // btnMove
                    {
                        if (btnMove != null)
                        {
                            bool isClickPiece = false;
                            {
                                NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                                if (noneRuleInputUIData != null)
                                {
                                    MineSweeper mineSweeper = noneRuleInputUIData.mineSweeper.v.data;
                                    if (mineSweeper != null)
                                    {
                                        if (mineSweeper.getPiece(this.data.square.v) != -1)
                                        {
                                            isClickPiece = true;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("mineSweeper null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("noneRuleInputuIData null: " + this);
                                }
                            }
                            btnMove.gameObject.SetActive(isClickPiece);
                        }
                        else
                        {
                            Debug.LogError("btnMove null: " + this);
                        }
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        deltaY += 30 + 10;
                        // btnSetPiece
                        {
                            if (btnSetPiece != null && btnSetPiece.gameObject.activeSelf)
                            {
                                UIRectTransform.SetPosY((RectTransform)btnSetPiece.transform, deltaY);
                                deltaY += 40;
                            }
                            else
                            {
                                Debug.LogError("btnSetPiece null");
                            }
                        }
                        // btnMove
                        {
                            if (btnMove != null && btnMove.gameObject.activeSelf)
                            {
                                UIRectTransform.SetPosY((RectTransform)btnMove.transform, deltaY);
                                deltaY += 40;
                            }
                            else
                            {
                                Debug.LogError("btnMove null");
                            }
                        }
                        // btnEndTurn
                        {
                            if (btnEndTurn != null && btnEndTurn.gameObject.activeSelf)
                            {
                                UIRectTransform.SetPosY((RectTransform)btnEndTurn.transform, deltaY);
                                deltaY += 40;
                            }
                            else
                            {
                                Debug.LogError("btnEndTurn null");
                            }
                        }
                        // btnClear
                        {
                            if (btnClear != null && btnClear.gameObject.activeSelf)
                            {
                                UIRectTransform.SetPosY((RectTransform)btnClear.transform, deltaY);
                                deltaY += 40;
                            }
                            else
                            {
                                Debug.LogError("btnClear null");
                            }
                        }
                        // set
                        if (contentContainer != null)
                        {
                            UIRectTransform.SetHeight((RectTransform)contentContainer, deltaY);
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
                            lbTitle.text = ClickPosTxt.txtClickPosTitle.get(ClickPosTxt.DefaultClickPosTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        if (tvSetPiece != null)
                        {
                            tvSetPiece.text = ClickPosTxt.txtClickPosSetPiece.get(ClickPosTxt.DefaultClickPosSetPiece);
                        }
                        else
                        {
                            Debug.LogError("tvSetPiece null");
                        }
                        if (tvMove != null)
                        {
                            tvMove.text = ClickPosTxt.txtClickPosMove.get(ClickPosTxt.DefaultClickPosMove);
                        }
                        else
                        {
                            Debug.LogError("tvMove null");
                        }
                        if (tvEndTurn != null)
                        {
                            tvEndTurn.text = ClickPosTxt.txtClickPosEndTurn.get(ClickPosTxt.DefaultClickPosEndTurn);
                        }
                        else
                        {
                            Debug.LogError("tvEndTurn null");
                        }
                        if (tvClear != null)
                        {
                            tvClear.text = ClickPosTxt.txtClickPosClear.get(ClickPosTxt.DefaultClickPosClear);
                        }
                        else
                        {
                            Debug.LogError("tvClear null");
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
            return false;
        }

        #endregion

        #region implement callBacks

        private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

        private MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // CheckChange
                {
                    perspectiveChange.addCallBack(this);
                    perspectiveChange.setData(uiData);
                }
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.mineSweeperGameDataUIData);
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
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is MineSweeperGameDataUI.UIData)
                {
                    MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = data as MineSweeperGameDataUI.UIData;
                    // Child
                    {
                        mineSweeperGameDataUIData.board.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is BoardUI.UIData)
                    {
                        BoardUI.UIData boardUIData = data as BoardUI.UIData;
                        // Child
                        {
                            boardUIData.mineSweeper.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is MineSweeper)
                    {
                        dirty = true;
                        return;
                    }
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
                // CheckChange
                {
                    perspectiveChange.removeCallBack(this);
                    perspectiveChange.setData(null);
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.mineSweeperGameDataUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                return;
            }
            // Parent
            {
                if (data is MineSweeperGameDataUI.UIData)
                {
                    MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = data as MineSweeperGameDataUI.UIData;
                    // Child
                    {
                        mineSweeperGameDataUIData.board.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is BoardUI.UIData)
                    {
                        BoardUI.UIData boardUIData = data as BoardUI.UIData;
                        // Child
                        {
                            boardUIData.mineSweeper.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is MineSweeper)
                    {
                        return;
                    }
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
                    case UIData.Property.square:
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
            // CheckChange
            if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (wrapProperty.p is MineSweeperGameDataUI.UIData)
                {
                    switch ((MineSweeperGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case MineSweeperGameDataUI.UIData.Property.gameData:
                            break;
                        case MineSweeperGameDataUI.UIData.Property.transformOrganizer:
                            break;
                        case MineSweeperGameDataUI.UIData.Property.isOnAnimation:
                            break;
                        case MineSweeperGameDataUI.UIData.Property.board:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case MineSweeperGameDataUI.UIData.Property.lastMove:
                            break;
                        case MineSweeperGameDataUI.UIData.Property.showHint:
                            break;
                        case MineSweeperGameDataUI.UIData.Property.inputUI:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is BoardUI.UIData)
                    {
                        switch ((BoardUI.UIData.Property)wrapProperty.n)
                        {
                            case BoardUI.UIData.Property.mineSweeper:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case BoardUI.UIData.Property.background:
                                break;
                            case BoardUI.UIData.Property.boundary:
                                break;
                            case BoardUI.UIData.Property.scrollView:
                                break;
                            case BoardUI.UIData.Property.pieces:
                                break;
                            case BoardUI.UIData.Property.booom:
                                break;
                            case BoardUI.UIData.Property.allowWatchBomb:
                                break;
                            case BoardUI.UIData.Property.maxWidth:
                                dirty = true;
                                break;
                            case BoardUI.UIData.Property.maxHeight:
                                dirty = true;
                                break;
                            case BoardUI.UIData.Property.x:
                                dirty = true;
                                break;
                            case BoardUI.UIData.Property.y:
                                dirty = true;
                                break;
                            case BoardUI.UIData.Property.width:
                                dirty = true;
                                break;
                            case BoardUI.UIData.Property.height:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is MineSweeper)
                    {
                        switch ((MineSweeper.Property)wrapProperty.n)
                        {
                            case MineSweeper.Property.Y:
                                break;
                            case MineSweeper.Property.X:
                                break;
                            case MineSweeper.Property.K:
                                break;
                            case MineSweeper.Property.bombs:
                                dirty = true;
                                break;
                            case MineSweeper.Property.booom:
                                break;
                            case MineSweeper.Property.flags:
                                break;
                            case MineSweeper.Property.board:
                                dirty = true;
                                break;
                            case MineSweeper.Property.minesFound:
                                break;
                            case MineSweeper.Property.init:
                                break;
                            case MineSweeper.Property.neb:
                                break;
                            case MineSweeper.Property.allowWatchBoomb:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                if (noneRuleInputUIData != null)
                {
                    ClickNoneUI.UIData clickNoneUIData = noneRuleInputUIData.sub.newOrOld<ClickNoneUI.UIData>();
                    {

                    }
                    noneRuleInputUIData.sub.v = clickNoneUIData;
                }
                else
                {
                    Debug.LogError("noneRuleInputUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onClickBtnSetPiece()
        {
            if (this.data != null)
            {
                NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                if (noneRuleInputUIData != null)
                {
                    SetPieceUI.UIData setPieceUIData = new SetPieceUI.UIData();
                    {
                        setPieceUIData.uid = noneRuleInputUIData.sub.makeId();
                        setPieceUIData.square.v = this.data.square.v;
                    }
                    noneRuleInputUIData.sub.v = setPieceUIData;
                }
                else
                {
                    Debug.LogError("noneRuleInputUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onClickBtnMove()
        {
            if (this.data != null)
            {
                NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                if (noneRuleInputUIData != null)
                {
                    ClickMoveUI.UIData clickMoveUIData = new ClickMoveUI.UIData();
                    {
                        clickMoveUIData.uid = noneRuleInputUIData.sub.makeId();
                        clickMoveUIData.square.v = this.data.square.v;
                    }
                    noneRuleInputUIData.sub.v = clickMoveUIData;
                }
                else
                {
                    Debug.LogError("noneRuleInputUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onClickBtnEnd()
        {
            if (this.data != null)
            {
                ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                if (clientInput != null)
                {
                    EndTurn endTurn = new EndTurn();
                    {

                    }
                    clientInput.makeSend(endTurn);
                }
                else
                {
                    Debug.LogError("clientInput null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onClickBtnClear()
        {
            if (this.data != null)
            {
                ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                if (clientInput != null)
                {
                    Clear clear = new Clear();
                    {

                    }
                    clientInput.makeSend(clear);
                }
                else
                {
                    Debug.LogError("clientInput null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}