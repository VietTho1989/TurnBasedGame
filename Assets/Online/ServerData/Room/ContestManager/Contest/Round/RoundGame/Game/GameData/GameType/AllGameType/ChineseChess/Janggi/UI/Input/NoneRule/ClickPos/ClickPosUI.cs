using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Janggi.NoneRule
{
    public class ClickPosUI : UIBehavior<ClickPosUI.UIData>
    {

        #region UIData

        public class UIData : NoneRuleInputUI.UIData.Sub
        {

            public VP<int> x;

            public VP<int> y;

            #region Constructor

            public enum Property
            {
                x,
                y
            }

            public UIData() : base()
            {
                this.x = new VP<int>(this, (byte)Property.x, 0);
                this.y = new VP<int>(this, (byte)Property.y, 0);
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

        public Button btnSetPiece;
        public Text tvSetPiece;

        public Button btnMove;
        public Text tvMove;

        public Button btnEndTurn;
        public Text tvEndTurn;

        public Button btnClear;
        public Text tvClear;

        #endregion

        #region Refresh

        public GameObject ivSelect;
        public Transform contentContainer;

        public Button btnBack;

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
                            // position
                            ivSelect.transform.localPosition = Common.convertXYToLocalPosition(this.data.x.v, this.data.y.v);
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
                                    Janggi janggi = noneRuleInputUIData.janggi.v.data;
                                    if (janggi != null)
                                    {
                                        if (this.data.x.v >= 0 && this.data.x.v < 9 && this.data.y.v >= 0 && this.data.y.v < 10)
                                        {
                                            int index = this.data.y.v * Board.Width + this.data.x.v;
                                            if (index >= 0 && index < janggi.stones.vs.Count)
                                            {
                                                uint stone = janggi.stones.vs[index];
                                                if (stone != (uint)StoneHelper.Stones.Empty)
                                                {
                                                    isClickPiece = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("outside board: " + this.data.x.v + ", " + this.data.y.v);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("chess null: " + this);
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
                        {
                            UIRectTransform.SetButtonTopLeftTransform(btnBack);
                            UIRectTransform.SetTitleTransform(lbTitle);
                            deltaY += Setting.get().getButtonSize() + 10;
                        }
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
                            lbTitle.text = ClickPosTxt.txtClickPosTitle.get();
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        if (tvSetPiece != null)
                        {
                            tvSetPiece.text = ClickPosTxt.txtClickPosSetPiece.get();
                        }
                        else
                        {
                            Debug.LogError("tvSetPiece null");
                        }
                        if (tvMove != null)
                        {
                            tvMove.text = ClickPosTxt.txtClickPosMove.get();
                        }
                        else
                        {
                            Debug.LogError("tvMove null");
                        }
                        if (tvEndTurn != null)
                        {
                            tvEndTurn.text = ClickPosTxt.txtClickPosEndTurn.get();
                        }
                        else
                        {
                            Debug.LogError("tvEndTurn null");
                        }
                        if (tvClear != null)
                        {
                            tvClear.text = ClickPosTxt.txtClickPosClear.get();
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
                        noneRuleInputUIData.janggi.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Janggi)
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
                        noneRuleInputUIData.janggi.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Janggi)
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
                    case UIData.Property.x:
                        dirty = true;
                        break;
                    case UIData.Property.y:
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
                        case NoneRuleInputUI.UIData.Property.janggi:
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
                if (wrapProperty.p is Janggi)
                {
                    switch ((Janggi.Property)wrapProperty.n)
                    {
                        case Janggi.Property.stones:
                            dirty = true;
                            break;
                        case Janggi.Property.targets:
                            break;
                        case Janggi.Property.blocks:
                            break;
                        case Janggi.Property.positions:
                            break;
                        case Janggi.Property.isMyTurn:
                            break;
                        case Janggi.Property.Point:
                            break;
                        case Janggi.Property.isMyFirst:
                            break;
                        case Janggi.Property.isCustom:
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

        [UnityEngine.Scripting.Preserve]
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

        [UnityEngine.Scripting.Preserve]
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
                        setPieceUIData.x.v = this.data.x.v;
                        setPieceUIData.y.v = this.data.y.v;
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

        [UnityEngine.Scripting.Preserve]
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
                        clickMoveUIData.x.v = this.data.x.v;
                        clickMoveUIData.y.v = this.data.y.v;
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

        [UnityEngine.Scripting.Preserve]
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

        [UnityEngine.Scripting.Preserve]
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