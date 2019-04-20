using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
    public class BoardUI : UIBehavior<BoardUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Weiqi>> weiqi;

            public VP<BoardIndexsUI.UIData> boardIndexs;

            public VP<BoardBackgroundUI.UIData> background;

            #region Mode

            public enum Mode
            {
                Normal,
                Score
            }

            public VP<Mode> mode;

            #endregion

            public VP<int> boardSize;

            public LP<PieceUI.UIData> pieces;

            #region UIData

            public enum Property
            {
                weiqi,
                boardIndexs,
                background,
                mode,
                boardSize,
                pieces
            }

            public UIData() : base()
            {
                this.weiqi = new VP<ReferenceData<Weiqi>>(this, (byte)Property.weiqi, new ReferenceData<Weiqi>(null));
                // boardIndexs
                {
                    this.boardIndexs = new VP<BoardIndexsUI.UIData>(this, (byte)Property.boardIndexs, new BoardIndexsUI.UIData());
                    this.boardIndexs.v.gameType.v = GameType.Type.Weiqi;
                }
                this.background = new VP<BoardBackgroundUI.UIData>(this, (byte)Property.background, new BoardBackgroundUI.UIData());
                this.mode = new VP<Mode>(this, (byte)Property.mode, Mode.Normal);
                this.boardSize = new VP<int>(this, (byte)Property.boardSize, 0);
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
                    // Find weqi
                    Weiqi weiqi = this.data.weiqi.v.data;
                    if (weiqi != null)
                    {
                        bool blindFold = GameData.IsBlindFold(weiqi);
                        // check load full
                        bool isLoadFull = true;
                        {
                            // weiqi
                            if (isLoadFull)
                            {
                                Board board = weiqi.b.v;
                                if (board != null)
                                {
                                    if (board.b.vs.Count == 0)
                                    {
                                        isLoadFull = false;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("board null");
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
                            List<int> b = weiqi.b.v.b.vs;
                            MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation(this.data);
                            {
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.WeiqiMove:
                                            {
                                                WeiqiMoveAnimation weiqiMoveAnimation = moveAnimation as WeiqiMoveAnimation;
                                                b = weiqiMoveAnimation.b.vs;
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
                                // boardSize
                                {
                                    this.data.boardSize.v = weiqi.b.v.size.v;
                                    if (this.data.background.v != null)
                                    {
                                        this.data.background.v.size.v = this.data.boardSize.v - 2;
                                    }
                                }
                                // pieces
                                {
                                    // check use rule
                                    bool useRule = GameData.IsUseRule(this.data.weiqi.v.data);
                                    // Find old list
                                    List<PieceUI.UIData> oldPieces = new List<PieceUI.UIData>();
                                    {
                                        oldPieces.AddRange(this.data.pieces.vs);
                                    }
                                    // Update board
                                    {
                                        int boardSize = this.data.boardSize.v;
                                        // Dead
                                        List<int> deadCoords = new List<int>();
                                        {
                                            if (useRule)
                                            {
                                                if (this.data.mode.v == UIData.Mode.Score)
                                                {
                                                    for (int i = 0; i < weiqi.deadgroup.v.moves.v; i++)
                                                    {
                                                        int group = weiqi.deadgroup.v.getMove(i);
                                                        // while
                                                        {
                                                            // them count vao de phong lap vo tan
                                                            int count = 0;
                                                            // iteriate
                                                            int c = group;
                                                            int c2 = c;
                                                            if (Common.groupnext_at(weiqi.b.v, c2, out c2))
                                                            {
                                                                do
                                                                {
                                                                    count++;
                                                                    // add
                                                                    deadCoords.Add(c);
                                                                    // next
                                                                    c = c2;
                                                                    if (!Common.groupnext_at(weiqi.b.v, c2, out c2))
                                                                    {
                                                                        Debug.LogError("group error: " + this);
                                                                        break;
                                                                    }
                                                                } while (c != 0 && count < 361);
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("group error: " + this);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                // Debug.LogError ("not use rule: so, cannot dead: " + this);
                                            }
                                        }
                                        for (int y = boardSize - 2; y >= 1; y--)
                                        {
                                            for (int x = 1; x < boardSize - 1; x++)
                                            {
                                                int coord = x + boardSize * y;
                                                // get information
                                                Common.stone stone = Board.GetBoardStone(b, coord);
                                                {
                                                    if (moveAnimation != null)
                                                    {
                                                        switch (moveAnimation.getType())
                                                        {
                                                            case GameMove.Type.WeiqiMove:
                                                                {
                                                                    WeiqiMoveAnimation weiqiMoveAnimation = moveAnimation as WeiqiMoveAnimation;
                                                                    if (weiqiMoveAnimation.coord.v == coord)
                                                                    {
                                                                        stone = (Common.stone)weiqiMoveAnimation.color.v;
                                                                    }
                                                                }
                                                                break;
                                                            default:
                                                                Debug.LogError("Unknown type: " + moveAnimation + "; " + this);
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        // Debug.LogError ("moveAnimation null: " + this);
                                                    }
                                                }
                                                int owner = (this.data.mode.v == UIData.Mode.Score) ? weiqi.getOwner(coord) : 0;
                                                int lastMoveIndex = weiqi.getLastMoveIndex(coord);
                                                bool isDead = deadCoords.Contains(coord);
                                                // make piece
                                                if (owner != 0 || stone == Common.stone.S_BLACK || stone == Common.stone.S_WHITE || lastMoveIndex != 0 || isDead)
                                                {
                                                    // Find piece
                                                    PieceUI.UIData pieceUI = null;
                                                    bool needAdd = false;
                                                    {
                                                        // find old
                                                        foreach (PieceUI.UIData oldPiece in oldPieces)
                                                        {
                                                            if (oldPiece.coord.v == coord)
                                                            {
                                                                pieceUI = oldPiece;
                                                                break;
                                                            }
                                                        }
                                                        // make new
                                                        if (pieceUI == null)
                                                        {
                                                            pieceUI = new PieceUI.UIData();
                                                            {
                                                                pieceUI.uid = this.data.pieces.makeId();
                                                            }
                                                            needAdd = true;
                                                        }
                                                        else
                                                        {
                                                            oldPieces.Remove(pieceUI);
                                                        }
                                                    }
                                                    // Update
                                                    {
                                                        pieceUI.coord.v = coord;
                                                        pieceUI.stone.v = stone;
                                                        pieceUI.isDead.v = isDead;
                                                        pieceUI.owner.v = owner;
                                                        pieceUI.lastMove.v = lastMoveIndex;
                                                        pieceUI.blindFold.v = blindFold;
                                                    }
                                                    // add
                                                    if (needAdd)
                                                    {
                                                        this.data.pieces.add(pieceUI);
                                                    }
                                                }
                                                else
                                                {
                                                    // Debug.Log("Don't need show piece");
                                                }
                                            }
                                        }
                                    }
                                    // remove unused piece
                                    foreach (PieceUI.UIData oldPiece in oldPieces)
                                    {
                                        this.data.pieces.remove(oldPiece);
                                    }
                                }
                            }
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
                        // Debug.LogError ("weiqi null: " + this);
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

        public BoardBackgroundUI backgroundPrefab;
        public PieceUI piecePrefab;

        private GameDataCheckChangeRule<Weiqi> checkUseRule = new GameDataCheckChangeRule<Weiqi>();
        private AnimationManagerCheckChange<UIData> animationManagerCheckChange = new AnimationManagerCheckChange<UIData>();

        private GameDataCheckChangeBlindFold<Weiqi> gameDataCheckChangeBlindFold = new GameDataCheckChangeBlindFold<Weiqi>();

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
                    UpdateUtils.makeUpdate<PieceUIAnimationSetDirtyUpdate, UIData>(uiData, this.transform);
                }
                // Child
                {
                    uiData.weiqi.allAddCallBack(this);
                    uiData.boardIndexs.allAddCallBack(this);
                    uiData.background.allAddCallBack(this);
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
                // Weiqi
                {
                    if (data is Weiqi)
                    {
                        Weiqi weiqi = data as Weiqi;
                        // reset
                        {
                            if (this.data != null)
                            {
                                this.data.mode.v = UIData.Mode.Normal;
                            }
                            else
                            {
                                Debug.LogError("error, data null: " + this);
                            }
                        }
                        // CheckChange
                        {
                            // useRule
                            {
                                checkUseRule.addCallBack(this);
                                checkUseRule.setData(weiqi);
                            }
                            // blindFold
                            {
                                gameDataCheckChangeBlindFold.addCallBack(this);
                                gameDataCheckChangeBlindFold.setData(weiqi);
                            }
                        }
                        // child
                        {
                            weiqi.b.allAddCallBack(this);
                            weiqi.deadgroup.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    {
                        if (data is GameDataCheckChangeRule<Weiqi>)
                        {
                            dirty = true;
                            return;
                        }
                        if (data is GameDataCheckChangeBlindFold<Weiqi>)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    // Child
                    {
                        if (data is Board)
                        {
                            Board board = data as Board;
                            // Child
                            {
                                board.last_move.allAddCallBack(this);
                                board.last_move2.allAddCallBack(this);
                                board.last_move3.allAddCallBack(this);
                                board.last_move4.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        if (data is WeiqiMove)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    if (data is MoveQueue)
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
                if (data is BoardBackgroundUI.UIData)
                {
                    BoardBackgroundUI.UIData subUIData = data as BoardBackgroundUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(subUIData, backgroundPrefab, this.transform);
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
                    uiData.removeCallBackAndDestroy(typeof(PieceUIAnimationSetDirtyUpdate));
                }
                // Child
                {
                    uiData.weiqi.allRemoveCallBack(this);
                    uiData.boardIndexs.allRemoveCallBack(this);
                    uiData.background.allRemoveCallBack(this);
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
                // Weiqi
                {
                    if (data is Weiqi)
                    {
                        Weiqi weiqi = data as Weiqi;
                        // CheckChange
                        {
                            // useRule
                            {
                                checkUseRule.removeCallBack(this);
                                checkUseRule.setData(null);
                            }
                            // blindFold
                            {
                                gameDataCheckChangeBlindFold.removeCallBack(this);
                                gameDataCheckChangeBlindFold.setData(null);
                            }
                        }
                        // Child
                        {
                            weiqi.b.allRemoveCallBack(this);
                            weiqi.deadgroup.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // CheckChange
                    {
                        if (data is GameDataCheckChangeRule<Weiqi>)
                        {
                            return;
                        }
                        if (data is GameDataCheckChangeBlindFold<Weiqi>)
                        {
                            return;
                        }
                    }
                    // Child
                    {
                        // Board
                        {

                            if (data is Board)
                            {
                                Board board = data as Board;
                                // Child
                                {
                                    board.last_move.allRemoveCallBack(this);
                                    board.last_move2.allRemoveCallBack(this);
                                    board.last_move3.allRemoveCallBack(this);
                                    board.last_move4.allRemoveCallBack(this);
                                }
                                return;
                            }
                            if (data is WeiqiMove)
                            {
                                return;
                            }
                        }
                        // MoveQueue
                        if (data is MoveQueue)
                        {
                            return;
                        }
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
                if (data is BoardBackgroundUI.UIData)
                {
                    BoardBackgroundUI.UIData boardBackgroundUIData = data as BoardBackgroundUI.UIData;
                    // UI
                    {
                        boardBackgroundUIData.removeCallBackAndDestroy(typeof(BoardBackgroundUI));
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
                    case UIData.Property.weiqi:
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
                    case UIData.Property.background:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.boardSize:
                        dirty = true;
                        break;
                    case UIData.Property.pieces:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            // dirty = true;
                        }
                        break;
                    case UIData.Property.mode:
                        dirty = true;
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
                // Weiqi
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
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case Weiqi.Property.scoreOwnerMap:
                                dirty = true;
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
                    // checkChange
                    {
                        if (wrapProperty.p is GameDataCheckChangeRule<Weiqi>)
                        {
                            dirty = true;
                            return;
                        }
                        if (wrapProperty.p is GameDataCheckChangeBlindFold<Weiqi>)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    // Board
                    {
                        if (wrapProperty.p is Board)
                        {
                            switch ((Board.Property)wrapProperty.n)
                            {
                                case Board.Property.size:
                                    dirty = true;
                                    break;
                                case Board.Property.size2:
                                    dirty = true;
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
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case Board.Property.last_move2:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case Board.Property.last_move3:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case Board.Property.last_move4:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
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
                        if (wrapProperty.p is WeiqiMove)
                        {
                            switch ((WeiqiMove.Property)wrapProperty.n)
                            {
                                case WeiqiMove.Property.coord:
                                    dirty = true;
                                    break;
                                case WeiqiMove.Property.color:
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                    if (wrapProperty.p is MoveQueue)
                    {
                        switch ((MoveQueue.Property)wrapProperty.n)
                        {
                            case MoveQueue.Property.moves:
                                dirty = true;
                                break;
                            case MoveQueue.Property.move:
                                dirty = true;
                                break;
                            case MoveQueue.Property.tag:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                if (wrapProperty.p is BoardIndexsUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is BoardBackgroundUI.UIData)
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