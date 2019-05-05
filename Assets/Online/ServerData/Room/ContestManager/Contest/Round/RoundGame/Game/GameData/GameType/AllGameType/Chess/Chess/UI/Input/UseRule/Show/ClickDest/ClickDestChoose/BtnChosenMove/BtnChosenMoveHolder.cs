using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System.Collections;
using System.Collections.Generic;

namespace Chess.UseRule
{
    public class BtnChosenMoveHolder : SriaHolderBehavior<BtnChosenMoveHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<ChessMove>> chessMove;

            public VP<OnClick> onClick;

            #region Constructor

            public enum Property
            {
                chessMove,
                onClick
            }

            public UIData() : base()
            {
                this.chessMove = new VP<ReferenceData<ChessMove>>(this, (byte)Property.chessMove, new ReferenceData<ChessMove>(null));
                this.onClick = new VP<OnClick>(this, (byte)Property.onClick, null);
            }

            #endregion

            public void updateView(BtnChosenMoveAdapter.UIData myParams)
            {
                // Find
                ChessMove chessMove = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.chessMoves.Count)
                    {
                        chessMove = myParams.chessMoves[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.chessMove.v = new ReferenceData<ChessMove>(chessMove);
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
            void onClickMove(ChessMove chessMove);
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickMove()
        {
            if (this.data != null)
            {
                ChessMove chessMove = this.data.chessMove.v.data;
                if (chessMove != null)
                {
                    if (this.data.onClick.v != null)
                    {
                        this.data.onClick.v.onClickMove(chessMove);
                    }
                }
                else
                {
                    Debug.LogError("chessMove null: " + this);
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
                    ChessMove chessMove = this.data.chessMove.v.data;
                    if (chessMove != null)
                    {
                        ChessMove.Move move = new ChessMove.Move(chessMove.move.v);
                        // imgPromotion
                        {
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
                                            Chess chess = useRuleInputUIData.chess.v.data;
                                            if (chess != null)
                                            {
                                                playerIndex = chess.getPlayerIndex();
                                            }
                                            else
                                            {
                                                Debug.LogError("chess null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("useRuleInputUIData null: " + this);
                                        }
                                    }
                                    // Process
                                    {
                                        Common.Piece piece = playerIndex == 0 ? Common.make_piece(Common.Color.WHITE, move.promotion)
                                            : Common.make_piece(Common.Color.BLACK, move.promotion);
                                        imgPromotion.sprite = ChessSpriteContainer.get().getSprite(piece);
                                    }
                                }
                                else
                                {
                                    imgPromotion.sprite = ChessSpriteContainer.get().getSprite(Common.Piece.NO_PIECE);
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
                                    case Common.MoveType.ENPASSANT:
                                        tvMoveType.text = "Enpassant";
                                        break;
                                    case Common.MoveType.CASTLING:
                                        tvMoveType.text = "Castling";
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
                                    Chess chess = useRuleInputUIData.chess.v.data;
                                    if (chess != null)
                                    {
                                        isChess960 = chess.chess960.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("chess null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("useRuleInputUIData null: " + this);
                                }
                            }
                            tvMove.text = Common.moveToString(chessMove.move.v, isChess960);
                        }
                        else
                        {
                            Debug.LogError("tvMove null: " + this);
                        }
                    }
                    else
                    {
                        // Debug.LogError("chessMove null: " + this);
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
                    uiData.chessMove.allAddCallBack(this);
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
                        useRuleInputUIData.chess.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                if (data is Chess)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                if (data is ChessMove)
                {
                    // ChessMove chessMove = data as ChessMove;
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
                    uiData.chessMove.allRemoveCallBack(this);
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
                        useRuleInputUIData.chess.allRemoveCallBack(this);
                    }
                    return;
                }
                if (data is Chess)
                {
                    return;
                }
            }
            // Child
            {
                if (data is ChessMove)
                {
                    // ChessMove chessMove = data as ChessMove;
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
                    case UIData.Property.chessMove:
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
                        case UseRuleInputUI.UIData.Property.chess:
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
                if (wrapProperty.p is Chess)
                {
                    switch ((Chess.Property)wrapProperty.n)
                    {
                        case Chess.Property.board:
                            break;
                        case Chess.Property.byTypeBB:
                            break;
                        case Chess.Property.byColorBB:
                            break;
                        case Chess.Property.pieceCount:
                            break;
                        case Chess.Property.pieceList:
                            break;
                        case Chess.Property.index:
                            break;
                        case Chess.Property.castlingRightsMask:
                            break;
                        case Chess.Property.castlingRookSquare:
                            break;
                        case Chess.Property.castlingPath:
                            break;
                        case Chess.Property.gamePly:
                            break;
                        case Chess.Property.sideToMove:
                            dirty = true;
                            break;
                        case Chess.Property.st:
                            break;
                        case Chess.Property.chess960:
                            dirty = true;
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
                if (wrapProperty.p is ChessMove)
                {
                    switch ((ChessMove.Property)wrapProperty.n)
                    {
                        case ChessMove.Property.move:
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