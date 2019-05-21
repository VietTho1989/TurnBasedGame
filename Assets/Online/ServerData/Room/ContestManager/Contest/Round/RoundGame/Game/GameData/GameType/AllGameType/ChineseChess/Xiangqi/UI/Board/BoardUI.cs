using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
    public class BoardUI : UIBehavior<BoardUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Xiangqi>> xiangqi;

            public VP<BoardIndexsUI.UIData> boardIndexs;

            public LP<PieceUI.UIData> pieces;

            #region Constructor

            public enum Property
            {
                xiangqi,
                boardIndexs,
                pieces
            }

            public UIData() : base()
            {
                this.xiangqi = new VP<ReferenceData<Xiangqi>>(this, (byte)Property.xiangqi, new ReferenceData<Xiangqi>(null));
                // boardIndexs
                {
                    this.boardIndexs = new VP<BoardIndexsUI.UIData>(this, (byte)Property.boardIndexs, new BoardIndexsUI.UIData());
                    this.boardIndexs.v.gameType.v = GameType.Type.Xiangqi;
                }
                this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Xiangqi ? 1 : 0;
        }

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Xiangqi xiangqi = this.data.xiangqi.v.data;
                    if (xiangqi != null)
                    {
                        // check load full
                        bool isLoadFull = true;
                        {
                            // chess
                            if (isLoadFull)
                            {
                                if (xiangqi.ucpcSquares.vs.Count == 0)
                                {
                                    Debug.LogError("board not load");
                                    isLoadFull = false;
                                }
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
                            // Normal board
                            bool blindFold = GameData.IsBlindFold(xiangqi);
                            {
                                // get olds
                                List<PieceUI.UIData> oldPieceUIs = new List<PieceUI.UIData>();
                                {
                                    oldPieceUIs.AddRange(this.data.pieces.vs);
                                }
                                // make pieceUI
                                {
                                    // find ucpcSquares
                                    List<byte> ucpcSquares = xiangqi.ucpcSquares.vs;
                                    {
                                        MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation(this.data);
                                        if (moveAnimation != null)
                                        {
                                            switch (moveAnimation.getType())
                                            {
                                                case GameMove.Type.XiangqiMove:
                                                    {
                                                        XiangqiMoveAnimation xiangqiMoveAnimation = moveAnimation as XiangqiMoveAnimation;
                                                        ucpcSquares = xiangqiMoveAnimation.ucpcSquares.vs;
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
                                    // Process
                                    {
                                        int[,] board = Common.getBoardArray(ucpcSquares);
                                        for (int y = 0; y < 10; y++)
                                            for (int x = 0; x < 9; x++)
                                            {
                                                // get piece
                                                int piece = board[x, y];
                                                if (piece != 0)
                                                {
                                                    int position = 9 * y + x;
                                                    // find pieceUI
                                                    bool needAdd = false;
                                                    PieceUI.UIData pieceUIData = null;
                                                    {
                                                        // find old
                                                        {
                                                            for (int i = 0; i < oldPieceUIs.Count; i++)
                                                            {
                                                                PieceUI.UIData check = oldPieceUIs[i];
                                                                if (check.position.v < 0)
                                                                {
                                                                    pieceUIData = check;
                                                                }
                                                                else if (check.position.v == position)
                                                                {
                                                                    pieceUIData = check;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        // make new
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
                                                            oldPieceUIs.Remove(pieceUIData);
                                                        }
                                                    }
                                                    // update property
                                                    {
                                                        pieceUIData.piece.v = piece;
                                                        pieceUIData.position.v = position;
                                                        pieceUIData.blindFold.v = blindFold;
                                                    }
                                                    // add
                                                    if (needAdd)
                                                    {
                                                        this.data.pieces.add(pieceUIData);
                                                    }
                                                }
                                            }
                                    }
                                }
                                // remove old pieceUI not used
                                foreach (PieceUI.UIData oldPieceUI in oldPieceUIs)
                                {
                                    this.data.pieces.remove(oldPieceUI);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("not load full");
                            dirty = true;
                        }
                    }
                    else
                    {
                        // Debug.LogError ("xiangqi null: " + this);
                    }
                    // siblingIndex
                    {
                        // background 0
                        // boardIndex last
                        UIRectTransform.SetSiblingIndex(this.data.boardIndexs.v, 1);
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
        private GameDataCheckChangeBlindFold<Xiangqi> gameDataCheckChangeBlindFold = new GameDataCheckChangeBlindFold<Xiangqi>();

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
                    uiData.xiangqi.allAddCallBack(this);
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
                // xiangqi
                {
                    if (data is Xiangqi)
                    {
                        Xiangqi xiangqi = data as Xiangqi;
                        // checkChange
                        {
                            gameDataCheckChangeBlindFold.addCallBack(this);
                            gameDataCheckChangeBlindFold.setData(xiangqi);
                        }
                        dirty = true;
                        return;
                    }
                    // checkChange
                    if (data is GameDataCheckChangeBlindFold<Xiangqi>)
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
                    uiData.xiangqi.allRemoveCallBack(this);
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
                // xiangqi
                {
                    if (data is Xiangqi)
                    {
                        // Xiangqi xiangqi = data as Xiangqi;
                        // checkChange
                        {
                            gameDataCheckChangeBlindFold.removeCallBack(this);
                            gameDataCheckChangeBlindFold.setData(null);
                        }
                        return;
                    }
                    // checkChange
                    if (data is GameDataCheckChangeBlindFold<Xiangqi>)
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
                    case UIData.Property.xiangqi:
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
            // Check Change
            if (wrapProperty.p is AnimationManagerCheckChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // xiangqi
                {
                    if (wrapProperty.p is Xiangqi)
                    {
                        switch ((Xiangqi.Property)wrapProperty.n)
                        {
                            case Xiangqi.Property.sdPlayer:
                                break;
                            case Xiangqi.Property.ucpcSquares:
                                dirty = true;
                                break;
                            case Xiangqi.Property.ucsqPieces:
                                break;
                            case Xiangqi.Property.zobr:
                                break;
                            case Xiangqi.Property.dwBitPiece:
                                break;
                            case Xiangqi.Property.wBitRanks:
                                break;
                            case Xiangqi.Property.wBitFiles:
                                break;
                            case Xiangqi.Property.vlWhite:
                                break;
                            case Xiangqi.Property.vlBlack:
                                break;
                            case Xiangqi.Property.nMoveNum:
                                break;
                            case Xiangqi.Property.nDistance:
                                break;
                            case Xiangqi.Property.rbsList:
                                break;
                            case Xiangqi.Property.ucRepHash:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // checkChange
                    if (wrapProperty.p is GameDataCheckChangeBlindFold<Xiangqi>)
                    {
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