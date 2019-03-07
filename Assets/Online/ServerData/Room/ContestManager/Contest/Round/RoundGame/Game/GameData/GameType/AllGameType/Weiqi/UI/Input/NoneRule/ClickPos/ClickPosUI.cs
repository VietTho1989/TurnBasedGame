using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Weiqi.NoneRule
{
    public class ClickPosUI : UIBehavior<ClickPosUI.UIData>
    {

        #region UIData

        public class UIData : NoneRuleInputUI.UIData.Sub
        {

            public VP<int> coord;

            #region Constructor

            public enum Property
            {
                coord
            }

            public UIData() : base()
            {
                this.coord = new VP<int>(this, (byte)Property.coord, 0);
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
                    // find boardSize
                    int boardSize = 21;
                    {
                        NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                        if (noneRuleInputUIData != null)
                        {
                            Weiqi weiqi = noneRuleInputUIData.weiqi.v.data;
                            if (weiqi != null)
                            {
                                Board board = weiqi.b.v;
                                if (board != null)
                                {
                                    boardSize = board.size.v;
                                }
                                else
                                {
                                    Debug.LogError("board null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("weiqi null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("noneRuleInputUIData null: " + this);
                        }
                    }
                    // imgSelect
                    {
                        if (ivSelect != null)
                        {
                            // position
                            ivSelect.transform.localPosition = Common.convertCoordToLocalPosition(boardSize, this.data.coord.v);
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
                    // Scale
                    {
                        if (contentContainer != null)
                        {
                            int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                            // contentContainer.localScale = (playerView == 0 ? new Vector3 (scale, scale, 1f) : new Vector3 (scale, -scale, 1f));
                            // UIUtils.SetGlobalScale(contentContainer.transform, new Vector3(1, 1, 1));
                        }
                        else
                        {
                            Debug.LogError("contentContainer null: " + this);
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
                                    Weiqi weiqi = noneRuleInputUIData.weiqi.v.data;
                                    if (weiqi != null)
                                    {
                                        Common.stone piece = weiqi.getPieceByCoord(this.data.coord.v);
                                        if (piece == Common.stone.S_BLACK || piece == Common.stone.S_WHITE)
                                        {
                                            isClickPiece = true;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("weiqi null: " + this);
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
        private NoneRuleInputUI.UIData noneRuleInputUIData = null;

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
                    DataUtils.addParentCallBack(uiData, this, ref this.noneRuleInputUIData);
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
                if (data is NoneRuleInputUI.UIData)
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
                    // Child
                    {
                        noneRuleInputUIData.weiqi.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Weiqi)
                    {
                        Weiqi weiqi = data as Weiqi;
                        // Child
                        {
                            weiqi.b.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Board)
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.noneRuleInputUIData);
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
                if (data is NoneRuleInputUI.UIData)
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
                    // Child
                    {
                        noneRuleInputUIData.weiqi.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Weiqi)
                    {
                        Weiqi weiqi = data as Weiqi;
                        // Child
                        {
                            weiqi.b.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Board)
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
                    case UIData.Property.coord:
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
                if (wrapProperty.p is NoneRuleInputUI.UIData)
                {
                    switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n)
                    {
                        case NoneRuleInputUI.UIData.Property.weiqi:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case NoneRuleInputUI.UIData.Property.sub:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is Weiqi)
                    {
                        switch ((Weiqi.Property)wrapProperty.n)
                        {
                            case Weiqi.Property.b:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case Weiqi.Property.deadgroup:
                                break;
                            case Weiqi.Property.scoreOwnerMap:
                                break;
                            case Weiqi.Property.scoreOwnerMapSize:
                                break;
                            case Weiqi.Property.scoreBlack:
                                break;
                            case Weiqi.Property.scoreWhite:
                                break;
                            case Weiqi.Property.dame:
                                break;
                            case Weiqi.Property.score:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is Board)
                    {
                        switch ((Board.Property)wrapProperty.n)
                        {
                            case Board.Property.size:
                                dirty = true;
                                break;
                            case Board.Property.size2:
                                break;
                            case Board.Property.bits2:
                                break;
                            case Board.Property.captures:
                                break;
                            case Board.Property.komi:
                                break;
                            case Board.Property.handicap:
                                break;
                            case Board.Property.rules:
                                break;
                            case Board.Property.moves:
                                break;
                            case Board.Property.last_move:
                                break;
                            case Board.Property.last_move2:
                                break;
                            case Board.Property.last_move3:
                                break;
                            case Board.Property.last_move4:
                                break;
                            case Board.Property.superko_violation:
                                break;
                            case Board.Property.b:
                                dirty = true;
                                break;
                            case Board.Property.g:
                                break;
                            case Board.Property.pp:
                                break;
                            case Board.Property.pat3:
                                break;
                            case Board.Property.gi:
                                break;
                            case Board.Property.c:
                                break;
                            case Board.Property.clen:
                                break;
                            case Board.Property.symmetry:
                                break;
                            case Board.Property.last_ko:
                                break;
                            case Board.Property.last_ko_age:
                                break;
                            case Board.Property.ko:
                                break;
                            case Board.Property.quicked:
                                break;
                            case Board.Property.history_hash:
                                break;
                            case Board.Property.hash:
                                break;
                            case Board.Property.qhash:
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
                        setPieceUIData.coord.v = this.data.coord.v;
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
                        clickMoveUIData.coord.v = this.data.coord.v;
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