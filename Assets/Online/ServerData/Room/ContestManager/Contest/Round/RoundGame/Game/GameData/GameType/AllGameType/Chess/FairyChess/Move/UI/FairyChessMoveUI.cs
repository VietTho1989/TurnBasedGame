using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
{
    public class FairyChessMoveUI : UIBehavior<FairyChessMoveUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<FairyChessMove>> fairyChessMove;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                fairyChessMove,
                isHint
            }

            public UIData() : base()
            {
                this.fairyChessMove = new VP<ReferenceData<FairyChessMove>>(this, (byte)Property.fairyChessMove, new ReferenceData<FairyChessMove>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.FairyChessMove;
            }
        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.FairyChess ? 1 : 0;
        }

        #region Refresh

        private const float DeltaX = 4f;
        private const float DeltaY = 4f;

        private static Color NormalColor = Color.blue;
        private static Color PromotionColor = Color.red;
        private static Color DropColor = Color.green;

        private static Color hintNormalColor = new Color(0, 0, 1, 0.5f);
        private static Color hintPromotionColor = new Color(1, 0, 0, 0.5f);
        private static Color hintDropColor = new Color(0, 1, 0, 0.5f);

        public UILineRenderer lineRenderer;

        public Image imgHint;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    FairyChessMove fairyChessMove = this.data.fairyChessMove.v.data;
                    if (fairyChessMove != null)
                    {
                        // UI
                        {
                            if (lineRenderer != null)
                            {
                                lineRenderer.enabled = true;
                                Piece.Position from = new Piece.Position(0, 0);
                                Piece.Position dest = new Piece.Position(0, 0);
                                // find position
                                {
                                    Common.Square fromSquare = Common.from_sq((Common.Move)fairyChessMove.move.v);
                                    Common.Square destSquare = Common.to_sq((Common.Move)fairyChessMove.move.v);
                                    switch (Common.type_of((Common.Move)fairyChessMove.move.v))
                                    {
                                        case Common.MoveType.DROP:
                                            {
                                                // Color
                                                lineRenderer.color = this.data.isHint.v ? hintDropColor : DropColor;
                                                // from
                                                {
                                                    from.X = (int)destSquare % 8;
                                                    from.Y = (int)destSquare / 8;
                                                }
                                                // dest
                                                {
                                                    dest.X = (int)destSquare % 8;
                                                    dest.Y = (int)destSquare / 8;
                                                }
                                            }
                                            break;
                                        case Common.MoveType.PROMOTION:
                                            {
                                                // Color
                                                lineRenderer.color = this.data.isHint.v ? hintPromotionColor : PromotionColor;
                                                // from
                                                {
                                                    from.X = (int)fromSquare % 8;
                                                    from.Y = (int)fromSquare / 8;
                                                }
                                                // dest
                                                {
                                                    dest.X = (int)destSquare % 8;
                                                    dest.Y = (int)destSquare / 8;
                                                }
                                            }
                                            break;
                                        default:
                                            {
                                                // Color
                                                lineRenderer.color = this.data.isHint.v ? hintNormalColor : NormalColor;
                                                // from
                                                {
                                                    from.X = (int)fromSquare % 8;
                                                    from.Y = (int)fromSquare / 8;
                                                }
                                                // dest
                                                {
                                                    dest.X = (int)destSquare % 8;
                                                    dest.Y = (int)destSquare / 8;
                                                }
                                            }
                                            break;
                                    }
                                }
                                // process
                                // Debug.LogError("from, dest: "+from+"; "+dest+"; "+this);
                                if (Common.isInsideBoard(from.X, from.Y) && Common.isInsideBoard(dest.X, dest.Y))
                                {
                                    if (from.X != dest.X || from.Y != dest.Y)
                                    {
                                        // Make point array
                                        Vector2[] points;
                                        {
                                            List<Vector2> temp = new List<Vector2>();
                                            // From
                                            {
                                                Vector2 fro = new Vector2(from.X + 0.5f - DeltaX,
                                                    from.Y + 0.5f - DeltaY);
                                                temp.Add(fro);
                                            }
                                            // Middle: for horse move
                                            {
                                                // Check is horse move
                                                bool isHorseMove = false;
                                                {
                                                    if ((Mathf.Abs(from.X - dest.X) == 2 && Mathf.Abs(from.Y - dest.Y) == 1)
                                                        || (Mathf.Abs(from.X - dest.X) == 1 && Mathf.Abs(from.Y - dest.Y) == 2))
                                                    {
                                                        isHorseMove = true;
                                                    }
                                                }
                                                // Make point
                                                if (isHorseMove)
                                                {
                                                    Vector2 middle = Vector2.zero;
                                                    //
                                                    if (from.X + 2 == dest.X)
                                                    {
                                                        middle = new Vector2(from.X + 0.5f + 1, from.Y + 0.5f);
                                                    }
                                                    //
                                                    else if (from.X - 2 == dest.X)
                                                    {
                                                        middle = new Vector2(from.X + 0.5f - 1, from.Y + 0.5f);
                                                    }
                                                    //
                                                    else if (from.Y + 2 == dest.Y)
                                                    {
                                                        middle = new Vector2(from.X + 0.5f, from.Y + 1 + 0.5f);
                                                    }
                                                    //
                                                    else if (from.Y - 2 == dest.Y)
                                                    {
                                                        middle = new Vector2(from.X + 0.5f, from.Y - 1 + 0.5f);
                                                    }
                                                    temp.Add(new Vector2(middle.x - DeltaX, middle.y - DeltaY));
                                                }
                                                else
                                                {
                                                    // Debug.Log ("not horse move");
                                                }
                                            }
                                            // Des
                                            {
                                                Vector2 des = new Vector2(dest.X + 0.5f - DeltaX, dest.Y + 0.5f - DeltaY);
                                                temp.Add(des);
                                            }
                                            // Set
                                            {
                                                points = new Vector2[temp.Count];
                                                for (int i = 0; i < temp.Count; i++)
                                                {
                                                    points[i] = temp[i];
                                                }
                                            }
                                        }
                                        lineRenderer.Points = points;
                                    }
                                    else
                                    {
                                        // position the same, so this is drop
                                        Debug.LogError("why position the same: " + from + "; " + dest + "; " + this);
                                        Vector2[] points = new Vector2[5];
                                        {
                                            points[0] = new Vector2(dest.X + 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY + 0.5f);
                                            points[1] = new Vector2(dest.X - 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY + 0.5f);
                                            points[2] = new Vector2(dest.X - 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY - 0.5f);
                                            points[3] = new Vector2(dest.X + 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY - 0.5f);
                                            points[4] = new Vector2(dest.X + 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY + 0.5f);
                                        }
                                        lineRenderer.Points = points;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("why position not inside board: " + from + "; " + dest + "; " + this);
                                    lineRenderer.Points = new Vector2[] { };
                                }
                            }
                            else
                            {
                                Debug.LogError("lineRenderer null: " + this);
                            }
                        }
                        // Image
                        if (imgHint != null)
                        {
                            imgHint.enabled = true;
                            // sprite
                            {
                                // find color and variantType
                                Common.Color color = Common.Color.WHITE;
                                Common.VariantType variantType = Common.VariantType.asean;
                                {
                                    FairyChessGameDataUI.UIData fairyChessGameDataUIData = this.data.findDataInParent<FairyChessGameDataUI.UIData>();
                                    if (fairyChessGameDataUIData != null)
                                    {
                                        GameData gameData = fairyChessGameDataUIData.gameData.v.data;
                                        if (gameData != null)
                                        {
                                            if (gameData.gameType.v != null && gameData.gameType.v is FairyChess)
                                            {
                                                FairyChess fairyChess = gameData.gameType.v as FairyChess;
                                                color = fairyChess.getPlayerIndex() == 0 ? Common.Color.WHITE : Common.Color.BLACK;
                                                variantType = (Common.VariantType)fairyChess.variantType.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("chess null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("gameData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRuleInputUIData null: " + this);
                                    }
                                }
                                // find variantType
                                Common.PieceType pieceType = Common.PieceType.NO_PIECE_TYPE;
                                {
                                    if (this.data.isHint.v)
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
                                                pieceType = Common.PieceType.NO_PIECE_TYPE;
                                                break;
                                        }
                                    }
                                }
                                // set sprite
                                SpriteContainer.setImagePiece(imgHint, variantType, color, pieceType);
                            }
                            // position
                            {
                                Common.Square destSquare = Common.to_sq((Common.Move)fairyChessMove.move.v);
                                int destX = (int)destSquare % 8;
                                int destY = (int)destSquare / 8;
                                imgHint.transform.localPosition = new Vector3(destX - DeltaX + 0.5f, destY - DeltaY + 0.5f, 0);
                            }
                            // scale
                            {
                                int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                            }
                        }
                        else
                        {
                            Debug.LogError("imgHint null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("fairyChessMove null: " + this);
                        // lineRenderer
                        if (lineRenderer != null)
                        {
                            lineRenderer.enabled = false;
                        }
                        else
                        {
                            Debug.LogError("lineRenderer null: " + this);
                        }
                        // imgHint
                        if (imgHint != null)
                        {
                            imgHint.enabled = false;
                        }
                        else
                        {
                            Debug.LogError("imgHint null: " + this);
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

        private FairyChessGameDataUI.UIData fairyChessGameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.fairyChessGameDataUIData);
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
                if (data is FairyChessGameDataUI.UIData)
                {
                    FairyChessGameDataUI.UIData fairyChessGameDataUIData = data as FairyChessGameDataUI.UIData;
                    // Child
                    {
                        fairyChessGameDataUIData.gameData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // GameData
                {
                    if (data is GameData)
                    {
                        GameData gameData = data as GameData;
                        // Child
                        {
                            gameData.gameType.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    if (data is GameType)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            if (data is FairyChessMove)
            {
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.fairyChessGameDataUIData);
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
                if (data is FairyChessGameDataUI.UIData)
                {
                    FairyChessGameDataUI.UIData fairyChessGameDataUIData = data as FairyChessGameDataUI.UIData;
                    // Child
                    {
                        fairyChessGameDataUIData.gameData.allRemoveCallBack(this);
                    }
                    return;
                }
                // GameData
                {
                    if (data is GameData)
                    {
                        GameData gameData = data as GameData;
                        // Child
                        {
                            gameData.gameType.allRemoveCallBack(this);
                        }
                        return;
                    }
                    if (data is GameType)
                    {
                        return;
                    }
                }
            }
            // Child
            if (data is FairyChessMove)
            {
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
                    case UIData.Property.fairyChessMove:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.isHint:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                if (wrapProperty.p is FairyChessGameDataUI.UIData)
                {
                    switch ((FairyChessGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case FairyChessGameDataUI.UIData.Property.gameData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case FairyChessGameDataUI.UIData.Property.isOnAnimation:
                            break;
                        case FairyChessGameDataUI.UIData.Property.board:
                            break;
                        case FairyChessGameDataUI.UIData.Property.lastMove:
                            break;
                        case FairyChessGameDataUI.UIData.Property.showHint:
                            break;
                        case FairyChessGameDataUI.UIData.Property.inputUI:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is GameData)
                {
                    switch ((GameData.Property)wrapProperty.n)
                    {
                        case GameData.Property.gameType:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case GameData.Property.useRule:
                            break;
                        case GameData.Property.turn:
                            break;
                        case GameData.Property.timeControl:
                            break;
                        case GameData.Property.lastMove:
                            break;
                        case GameData.Property.state:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is GameType)
                {
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
                            case FairyChess.Property.variantType:
                                break;
                            case FairyChess.Property.st:
                                break;
                            case FairyChess.Property.chess960:
                                break;
                            case FairyChess.Property.pieceCountInHand:
                                break;
                            case FairyChess.Property.promotedPieces:
                                break;
                            case FairyChess.Property.isCustom:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    return;
                }
            }
            // Child
            if (wrapProperty.p is FairyChessMove)
            {
                switch ((FairyChessMove.Property)wrapProperty.n)
                {
                    case FairyChessMove.Property.move:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}