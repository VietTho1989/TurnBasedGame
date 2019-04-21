using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
    public class BoardUI : UIBehavior<BoardUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Hex>> hex;

            public VP<BoardIndexsUI.UIData> boardIndexs;

            public VP<System.UInt16> boardSize;

            public LP<PieceUI.UIData> pieces;

            #region Constructor

            public enum Property
            {
                hex,
                boardIndexs,
                boardSize,
                pieces
            }

            public UIData() : base()
            {
                this.hex = new VP<ReferenceData<Hex>>(this, (byte)Property.hex, new ReferenceData<Hex>(null));
                // boardIndexs
                {
                    this.boardIndexs = new VP<BoardIndexsUI.UIData>(this, (byte)Property.boardIndexs, new BoardIndexsUI.UIData());
                    this.boardIndexs.v.gameType.v = GameType.Type.Hex;
                }
                this.boardSize = new VP<ushort>(this, (byte)Property.boardSize, 11);
                this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
            }

            #endregion

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
                    Hex hex = this.data.hex.v.data;
                    if (hex != null)
                    {
                        // check load full
                        bool isLoadFull = true;
                        {
                            // hex
                            if (isLoadFull)
                            {
                                isLoadFull = hex.isLoadFull();
                            }
                            // animation
                            if (isLoadFull)
                            {
                                isLoadFull = AnimationManager.IsLoadFull(this.data);
                            }
                        }
                        // process
                        if (isLoadFull)
                        {
                            bool blindFold = GameData.IsBlindFold(hex);
                            // pieces
                            {
                                // get olds
                                List<PieceUI.UIData> oldPieces = new List<PieceUI.UIData>();
                                {
                                    oldPieces.AddRange(this.data.pieces.vs);
                                }
                                // find inform
                                System.UInt16 boardSize = hex.boardSize.v;
                                List<System.SByte> board = hex.board.vs;
                                // move inform
                                System.UInt16 moveX = System.UInt16.MaxValue;
                                System.UInt16 moveY = System.UInt16.MinValue;
                                Common.Color moveColor = Common.Color.Empty;
                                {
                                    MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation(this.data);
                                    if (moveAnimation != null)
                                    {
                                        switch (moveAnimation.getType())
                                        {
                                            case GameMove.Type.HexMove:
                                                {
                                                    HexMoveAnimation hexMoveAnimation = moveAnimation as HexMoveAnimation;
                                                    boardSize = hexMoveAnimation.boardSize.v;
                                                    board = hexMoveAnimation.board.vs;
                                                    // moveX, moveY
                                                    {
                                                        if (boardSize > 0)
                                                        {
                                                            moveX = (System.UInt16)(hexMoveAnimation.move.v % boardSize);
                                                            moveY = (System.UInt16)(hexMoveAnimation.move.v / boardSize);
                                                            moveColor = hexMoveAnimation.color.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("why board size too small: " + this);
                                                        }
                                                    }
                                                }
                                                break;
                                            case GameMove.Type.HexSwitch:
                                                {
                                                    HexSwitchAnimation hexSwitchAnimation = moveAnimation as HexSwitchAnimation;
                                                    boardSize = hexSwitchAnimation.boardSize.v;
                                                    board = hexSwitchAnimation.board.vs;
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + moveAnimation.getType() + "; " + this);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        // Debug.LogError ("moveAnimation null: " + this);
                                    }
                                }
                                // Update
                                {
                                    this.data.boardSize.v = boardSize;
                                    for (System.UInt16 y = 0; y < boardSize; y++)
                                    {
                                        for (System.UInt16 x = 0; x < boardSize; x++)
                                        {
                                            System.UInt16 index = (System.UInt16)(y * boardSize + x);
                                            // get color
                                            Common.Color color = Common.Color.Empty;
                                            {
                                                if (x == moveX && y == moveY)
                                                {
                                                    color = moveColor;
                                                }
                                                else
                                                {
                                                    if (index < board.Count)
                                                    {
                                                        color = (Common.Color)board[index];
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("outside board");
                                                    }
                                                }
                                            }
                                            // Make piece
                                            // if (color != Common.Color.Empty) 
                                            {
                                                bool needAdd = false;
                                                // find pieceUIData
                                                PieceUI.UIData pieceUIData = null;
                                                {
                                                    foreach (PieceUI.UIData oldPiece in oldPieces)
                                                    {
                                                        if (oldPiece.x.v == x && oldPiece.y.v == y)
                                                        {
                                                            pieceUIData = oldPiece;
                                                            break;
                                                        }
                                                    }
                                                    // Make new
                                                    if (pieceUIData == null)
                                                    {
                                                        pieceUIData = new PieceUI.UIData();
                                                        {
                                                            pieceUIData.uid = this.data.pieces.makeId();
                                                        }
                                                        needAdd = true;
                                                    }
                                                    else
                                                    {
                                                        oldPieces.Remove(pieceUIData);
                                                    }
                                                }
                                                // Update Property
                                                {
                                                    pieceUIData.x.v = x;
                                                    pieceUIData.y.v = y;
                                                    pieceUIData.color.v = color;
                                                    pieceUIData.blindFold.v = blindFold;
                                                }
                                                // Add
                                                if (needAdd)
                                                {
                                                    this.data.pieces.add(pieceUIData);
                                                }
                                            }
                                        }
                                    }
                                }
                                // remove old
                                foreach (PieceUI.UIData oldPiece in oldPieces)
                                {
                                    this.data.pieces.remove(oldPiece);
                                }
                            }
                            // Debug.LogError (Core.unityGetStrPosition (hex, Core.CanCorrect));
                        }
                        else
                        {
                            Debug.LogError("not load full");
                            dirty = true;
                        }
                        // siblingIndex
                        {
                            // background 0
                            // boardIndex last
                            UIRectTransform.SetSiblingIndexLast(this.data.boardIndexs.v);
                        }
                    }
                    else
                    {
                        Debug.LogError("hex null: " + this);
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

        public PieceUI piecePrefab;
        private AnimationManagerCheckChange<UIData> animationManagerCheckChange = new AnimationManagerCheckChange<UIData>();
        private GameDataCheckChangeBlindFold<Hex> gameDataCheckChangeBlindFold = new GameDataCheckChangeBlindFold<Hex>();

        public BoardIndexsUI boardIndexsPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // CheckChange
                {
                    animationManagerCheckChange.needTimeChange = false;
                    animationManagerCheckChange.addCallBack(this);
                    animationManagerCheckChange.setData(uiData);
                }
                // Update
                {
                    UpdateUtils.makeUpdate<AnimationSetDirtyUpdate, UIData>(uiData, this.transform);
                }
                // Child
                {
                    uiData.hex.allAddCallBack(this);
                    uiData.boardIndexs.allAddCallBack(this);
                    uiData.pieces.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // checkChange
            if (data is AnimationManagerCheckChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // hex
                {
                    if (data is Hex)
                    {
                        Hex hex = data as Hex;
                        // checkChange
                        {
                            gameDataCheckChangeBlindFold.addCallBack(this);
                            gameDataCheckChangeBlindFold.setData(hex);
                        }
                        dirty = true;
                        return;
                    }
                    // checkChange
                    if (data is GameDataCheckChangeBlindFold<Hex>)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is BoardIndexsUI.UIData)
                {
                    BoardIndexsUI.UIData boardIndexsUIData = data as BoardIndexsUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(boardIndexsUIData, boardIndexsPrefab, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if (data is PieceUI.UIData)
                {
                    PieceUI.UIData pieceUIData = data as PieceUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(pieceUIData, piecePrefab, this.transform);
                    }
                    // dirty = true;
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
                // CheckChange
                {
                    animationManagerCheckChange.removeCallBack(this);
                    animationManagerCheckChange.setData(null);
                }
                // Update
                {
                    uiData.removeCallBackAndDestroy(typeof(AnimationSetDirtyUpdate));
                }
                // Child
                {
                    uiData.hex.allRemoveCallBack(this);
                    uiData.boardIndexs.allRemoveCallBack(this);
                    uiData.pieces.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // checkChange
            if (data is AnimationManagerCheckChange<UIData>)
            {
                return;
            }
            // Child
            {
                // hex
                {
                    if (data is Hex)
                    {
                        // Hex hex = data as Hex;
                        // checkChange
                        {
                            gameDataCheckChangeBlindFold.removeCallBack(this);
                            gameDataCheckChangeBlindFold.setData(null);
                        }
                        return;
                    }
                    // checkChange
                    if (data is GameDataCheckChangeBlindFold<Hex>)
                    {
                        return;
                    }
                }
                if (data is BoardIndexsUI.UIData)
                {
                    BoardIndexsUI.UIData boardIndexsUIData = data as BoardIndexsUI.UIData;
                    // UI
                    {
                        boardIndexsUIData.removeCallBackAndDestroy(typeof(BoardIndexsUI));
                    }
                    return;
                }
                if (data is PieceUI.UIData)
                {
                    PieceUI.UIData pieceUIData = data as PieceUI.UIData;
                    // UI
                    {
                        pieceUIData.removeCallBackAndDestroy(typeof(PieceUI));
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
                    case UIData.Property.hex:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.boardIndexs:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.boardSize:
                        break;
                    case UIData.Property.pieces:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            // dirty = true;
                        }
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // checkChange
            if (wrapProperty.p is AnimationManagerCheckChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // hex
                {
                    if (wrapProperty.p is Hex)
                    {
                        switch ((Hex.Property)wrapProperty.n)
                        {
                            case Hex.Property.board:
                                dirty = true;
                                break;
                            case Hex.Property.boardSize:
                                dirty = true;
                                break;
                            case Hex.Property.isSwitch:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // checkChange
                    if (wrapProperty.p is GameDataCheckChangeBlindFold<Hex>)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (wrapProperty.p is BoardIndexsUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is PieceUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}