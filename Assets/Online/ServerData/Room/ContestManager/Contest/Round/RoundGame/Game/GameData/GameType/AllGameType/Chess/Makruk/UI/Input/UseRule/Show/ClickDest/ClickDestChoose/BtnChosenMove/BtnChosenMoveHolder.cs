using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System.Collections;
using System.Collections.Generic;

namespace Makruk.UseRule
{
    public class BtnChosenMoveHolder : SriaHolderBehavior<BtnChosenMoveHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<MakrukMove>> makrukMove;

            public VP<OnClick> onClick;

            #region Constructor

            public enum Property
            {
                makrukMove,
                onClick
            }

            public UIData() : base()
            {
                this.makrukMove = new VP<ReferenceData<MakrukMove>>(this, (byte)Property.makrukMove, new ReferenceData<MakrukMove>(null));
                this.onClick = new VP<OnClick>(this, (byte)Property.onClick, null);
            }

            #endregion

            public void updateView(BtnChosenMoveAdapter.UIData myParams)
            {
                // Find
                MakrukMove makrukMove = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.makrukMoves.Count)
                    {
                        makrukMove = myParams.makrukMoves[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.makrukMove.v = new ReferenceData<MakrukMove>(makrukMove);
            }

        }

        public interface OnClick
        {
            void onClickMove(MakrukMove makrukMove);
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickMove()
        {
            if (this.data != null)
            {
                MakrukMove makrukMove = this.data.makrukMove.v.data;
                if (makrukMove != null)
                {
                    if (this.data.onClick.v != null)
                    {
                        this.data.onClick.v.onClickMove(makrukMove);
                    }
                }
                else
                {
                    Debug.LogError("makrukMove null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        #endregion

        #region Refresh

        public Image imgPromotion;

        public Text tvMoveType;
        public Text tvMove;

        public override void refresh()
        {
            base.refresh();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    MakrukMove makrukMove = this.data.makrukMove.v.data;
                    if (makrukMove != null)
                    {
                        MakrukMove.Move move = new MakrukMove.Move(makrukMove.move.v);
                        // imgPromotion
                        {
                            Setting.Style style = Setting.get().style.v;
                            if (imgPromotion != null)
                            {
                                if (move.type == Common.MoveType.PROMOTION)
                                {
                                    int playerIndex = 0;
                                    // Find playerIndex
                                    {
                                        UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                                        if (useRuleInputUIData != null)
                                        {
                                            Makruk makruk = useRuleInputUIData.makruk.v.data;
                                            if (makruk != null)
                                            {
                                                playerIndex = makruk.getPlayerIndex();
                                            }
                                            else
                                            {
                                                Debug.LogError("makruk null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("useRuleInputUIData null: " + this);
                                        }
                                    }
                                    // Process
                                    imgPromotion.sprite = MakrukSpriteContainer.get().getSprite(style,
                                        Common.make_piece(playerIndex == 0 ? Common.Color.WHITE : Common.Color.BLACK,
                                            move.promotion));
                                }
                                else
                                {
                                    imgPromotion.sprite = MakrukSpriteContainer.get().getSprite(style, Common.Piece.NO_PIECE);
                                }
                            }
                            else
                            {
                                Debug.LogError("imgPromotion null: " + this);
                            }
                        }
                        // tvMoveType
                        {
                            if (tvMoveType != null)
                            {
                                switch (move.type)
                                {
                                    case Common.MoveType.NORMAL:
                                        tvMoveType.text = "Normal";
                                        break;
                                    case Common.MoveType.PROMOTION:
                                        tvMoveType.text = "Promotion";
                                        break;
                                    default:
                                        tvMoveType.text = "";
                                        Debug.LogError("unknown move type: " + move.type + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("tvMoveType null: " + this);
                            }
                        }
                        // tvMove
                        if (tvMove != null)
                        {
                            bool isChess960 = false;
                            {
                                UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                                if (useRuleInputUIData != null)
                                {
                                    Makruk makruk = useRuleInputUIData.makruk.v.data;
                                    if (makruk != null)
                                    {
                                        isChess960 = makruk.chess960.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("makruk null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("useRuleInputUIData null: " + this);
                                }
                            }
                            tvMove.text = Common.moveToString(makrukMove.move.v, isChess960);
                        }
                        else
                        {
                            Debug.LogError("tvMove null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("makrukMove null: " + this);
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
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.useRuleInputUIData);
                }
                // Child
                {
                    uiData.makrukMove.allAddCallBack(this);
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
                if (data is UseRuleInputUI.UIData)
                {
                    UseRuleInputUI.UIData useRuleInputUIData = data as UseRuleInputUI.UIData;
                    // Child
                    {
                        useRuleInputUIData.makruk.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                if (data is Makruk)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                if (data is MakrukMove)
                {
                    // MakrukMove makrukMove = data as MakrukMove;
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.useRuleInputUIData);
                }
                // Child
                {
                    uiData.makrukMove.allRemoveCallBack(this);
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
                if (data is UseRuleInputUI.UIData)
                {
                    UseRuleInputUI.UIData useRuleInputUIData = data as UseRuleInputUI.UIData;
                    // Child
                    {
                        useRuleInputUIData.makruk.allRemoveCallBack(this);
                    }
                    return;
                }
                if (data is Makruk)
                {
                    return;
                }
            }
            // Child
            {
                if (data is MakrukMove)
                {
                    // MakrukMove makrukMove = data as MakrukMove;
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
                    case UIData.Property.makrukMove:
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
                        break;
                    case Setting.Property.style:
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
                if (wrapProperty.p is UseRuleInputUI.UIData)
                {
                    switch ((UseRuleInputUI.UIData.Property)wrapProperty.n)
                    {
                        case UseRuleInputUI.UIData.Property.makruk:
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
                if (wrapProperty.p is Makruk)
                {
                    switch ((Makruk.Property)wrapProperty.n)
                    {
                        case Makruk.Property.board:
                            break;
                        case Makruk.Property.byTypeBB:
                            break;
                        case Makruk.Property.byColorBB:
                            break;
                        case Makruk.Property.pieceCount:
                            break;
                        case Makruk.Property.pieceList:
                            break;
                        case Makruk.Property.index:
                            break;
                        case Makruk.Property.gamePly:
                            break;
                        case Makruk.Property.sideToMove:
                            dirty = true;
                            break;
                        case Makruk.Property.st:
                            break;
                        case Makruk.Property.chess960:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // Child
            if (wrapProperty.p is MakrukMove)
            {
                switch ((MakrukMove.Property)wrapProperty.n)
                {
                    case MakrukMove.Property.move:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}