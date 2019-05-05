using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess.UseRule
{
    public class BtnChosenMoveHolder : SriaHolderBehavior<BtnChosenMoveHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<FairyChessMove>> fairyChessMove;

            public VP<OnClick> onClick;

            #region Constructor

            public enum Property
            {
                fairyChessMove,
                onClick
            }

            public UIData() : base()
            {
                this.fairyChessMove = new VP<ReferenceData<FairyChessMove>>(this, (byte)Property.fairyChessMove, new ReferenceData<FairyChessMove>(null));
                this.onClick = new VP<OnClick>(this, (byte)Property.onClick, null);
            }

            #endregion

            public void updateView(BtnChosenMoveAdapter.UIData myParams)
            {
                // Find
                FairyChessMove fairyChessMove = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.fairyChessMoves.Count)
                    {
                        fairyChessMove = myParams.fairyChessMoves[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.fairyChessMove.v = new ReferenceData<FairyChessMove>(fairyChessMove);
            }

            public void processEvent(Event e)
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
            void onClickMove(FairyChessMove fairyChessMove);
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickMove()
        {
            if (this.data != null)
            {
                FairyChessMove fairyChessMove = this.data.fairyChessMove.v.data;
                if (fairyChessMove != null)
                {
                    if (this.data.onClick.v != null)
                    {
                        this.data.onClick.v.onClickMove(fairyChessMove);
                    }
                }
                else
                {
                    Debug.LogError("fairyChessMove null: " + this);
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
                    FairyChessMove fairyChessMove = this.data.fairyChessMove.v.data;
                    if (fairyChessMove != null)
                    {
                        // imgPromotion
                        {
                            if (imgPromotion != null)
                            {
                                // Find VariantType
                                Common.VariantType variantType = Common.VariantType.asean;
                                Common.Color color = Common.Color.WHITE;
                                {
                                    UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                                    if (useRuleInputUIData != null)
                                    {
                                        FairyChess fairyChess = useRuleInputUIData.fairyChess.v.data;
                                        if (fairyChess != null)
                                        {
                                            variantType = (Common.VariantType)fairyChess.variantType.v;
                                            color = (Common.Color)fairyChess.sideToMove.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("fairyChess null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("inputUIData null: " + this);
                                    }
                                }
                                // Find PieceType
                                Common.PieceType pieceType = Common.PieceType.NO_PIECE_TYPE;
                                {
                                    switch (Common.type_of((Common.Move)fairyChessMove.move.v))
                                    {
                                        case Common.MoveType.PROMOTION:
                                            pieceType = Common.promotion_type((Common.Move)fairyChessMove.move.v);
                                            break;
                                        case Common.MoveType.DROP:
                                            pieceType = Common.dropped_piece_type((Common.Move)fairyChessMove.move.v);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                // Set Sprite
                                SpriteContainer.setImagePiece(imgPromotion, variantType, color, pieceType);
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
                                switch (Common.type_of((Common.Move)fairyChessMove.move.v))
                                {
                                    case Common.MoveType.NORMAL:
                                        tvMoveType.text = "Normal";
                                        break;
                                    case Common.MoveType.PROMOTION:
                                        tvMoveType.text = "Promotion";
                                        break;
                                    case Common.MoveType.ENPASSANT:
                                        tvMoveType.text = "Enpassant";
                                        break;
                                    case Common.MoveType.CASTLING:
                                        tvMoveType.text = "Castling";
                                        break;
                                    case Common.MoveType.DROP:
                                        tvMoveType.text = "Drop";
                                        break;
                                    default:
                                        tvMoveType.text = "";
                                        Debug.LogError("unknown move type: " + Common.type_of((Common.Move)fairyChessMove.move.v) + "; " + this);
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
                            // Find fairyChess
                            FairyChess fairyChess = null;
                            {
                                UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                                if (useRuleInputUIData != null)
                                {
                                    fairyChess = useRuleInputUIData.fairyChess.v.data;
                                }
                                else
                                {
                                    Debug.LogError("useRuleInputUIData null: " + this);
                                }
                            }
                            // Process
                            if (fairyChess != null)
                            {
                                tvMove.text = Core.unityGetStrMove(fairyChess, Core.CanCorrect, fairyChessMove.move.v);
                            }
                            else
                            {
                                Debug.LogError("fairyChess null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("tvMove null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("fairyChessMove null: " + this);
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
                    uiData.fairyChessMove.allAddCallBack(this);
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
                        useRuleInputUIData.fairyChess.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                if (data is FairyChess)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                if (data is FairyChessMove)
                {
                    // FairyChessMove fairyChessMove = data as FairyChessMove;
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
                    uiData.fairyChessMove.allRemoveCallBack(this);
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
                        useRuleInputUIData.fairyChess.allRemoveCallBack(this);
                    }
                    return;
                }
                if (data is FairyChess)
                {
                    return;
                }
            }
            // Child
            {
                if (data is FairyChessMove)
                {
                    // FairyChessMove fairyChessMove = data as FairyChessMove;
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
                    case UIData.Property.fairyChessMove:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.onClick:
                        break;
                    default:
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
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
                        case UseRuleInputUI.UIData.Property.fairyChess:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case UseRuleInputUI.UIData.Property.state:
                            break;
                        default:
                            Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is FairyChess)
                {
                    switch ((FairyChess.Property)wrapProperty.n)
                    {
                        case FairyChess.Property.board:
                            break;
                        case FairyChess.Property.unpromotedBoard:
                            break;
                        case FairyChess.Property.byTypeBB:
                            break;
                        case FairyChess.Property.byColorBB:
                            break;
                        case FairyChess.Property.pieceCount:
                            break;
                        case FairyChess.Property.pieceList:
                            break;
                        case FairyChess.Property.index:
                            break;
                        case FairyChess.Property.castlingRightsMask:
                            break;
                        case FairyChess.Property.castlingRookSquare:
                            break;
                        case FairyChess.Property.castlingPath:
                            break;
                        case FairyChess.Property.gamePly:
                            break;
                        case FairyChess.Property.sideToMove:
                            dirty = true;
                            break;
                        case FairyChess.Property.st:
                            break;
                        case FairyChess.Property.chess960:
                            dirty = true;
                            break;
                        case FairyChess.Property.pieceCountInHand:
                            break;
                        case FairyChess.Property.promotedPieces:
                            break;
                        default:
                            Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // Child
            {
                if (wrapProperty.p is FairyChessMove)
                {
                    switch ((FairyChessMove.Property)wrapProperty.n)
                    {
                        case FairyChessMove.Property.move:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                            break;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}