using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
    public class BoardUI : UIBehavior<BoardUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<MineSweeper>> mineSweeper;

            public VP<BoundaryUI.UIData> boundary;

            public VP<ScrollViewUI.UIData> scrollView;

            public LP<PieceUI.UIData> pieces;

            public VP<bool> booom;

            public VP<bool> allowWatchBomb;

            #region dimension

            public VP<int> maxWidth;

            public VP<int> maxHeight;

            /** left, top*/
            public VP<float> x;

            /** left, top*/
            public VP<float> y;

            public VP<int> width;

            public VP<int> height;

            #endregion

            #region Constructor

            public enum Property
            {
                mineSweeper,
                boundary,
                scrollView,

                pieces,
                booom,
                allowWatchBomb,

                maxWidth,
                maxHeight,
                x,
                y,
                width,
                height
            }

            public UIData() : base()
            {
                this.mineSweeper = new VP<ReferenceData<MineSweeper>>(this, (byte)Property.mineSweeper, new ReferenceData<MineSweeper>(null));
                this.boundary = new VP<BoundaryUI.UIData>(this, (byte)Property.boundary, new BoundaryUI.UIData());
                this.scrollView = new VP<ScrollViewUI.UIData>(this, (byte)Property.scrollView, new ScrollViewUI.UIData());

                this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
                this.booom = new VP<bool>(this, (byte)Property.booom, false);
                this.allowWatchBomb = new VP<bool>(this, (byte)Property.allowWatchBomb, true);

                this.maxWidth = new VP<int>(this, (byte)Property.maxWidth, 20);
                this.maxHeight = new VP<int>(this, (byte)Property.maxHeight, 20);
                this.x = new VP<float>(this, (byte)Property.x, 0);
                this.y = new VP<float>(this, (byte)Property.y, 0);
                this.width = new VP<int>(this, (byte)Property.width, 20);
                this.height = new VP<int>(this, (byte)Property.height, 20);
            }

            #endregion

            public void reset()
            {
                MineSweeper mineSweeper = this.mineSweeper.v.data;
                if (mineSweeper != null)
                {
                    // maxWidth
                    this.maxWidth.v = (mineSweeper.X.v % 2 == 0) ? 20 : 19;
                    // maxHeigth
                    this.maxHeight.v = (mineSweeper.Y.v % 2 == 0) ? 20 : 19;
                    // width
                    this.width.v = Mathf.Min(mineSweeper.X.v, this.maxWidth.v);
                    // heigth
                    this.height.v = Mathf.Min(mineSweeper.Y.v, this.maxHeight.v);
                    // x
                    this.x.v = (mineSweeper.X.v - this.width.v) / 2.0f;
                    // y
                    this.y.v = (mineSweeper.Y.v - this.height.v) / 2.0f;
                }
                else
                {
                    Debug.LogError("mineSweeper null: " + this);
                }
            }

        }

        #endregion

        #region Refresh

        private MoveAnimation lastMoveAnimation = null;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    MineSweeper mineSweeper = this.data.mineSweeper.v.data;
                    if (mineSweeper != null)
                    {
                        // check load full
                        bool isLoadFull = true;
                        {
                            // mineSweeper
                            if (isLoadFull)
                            {
                                isLoadFull = mineSweeper.isLoadFull();
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
                            // allowWatchBomb
                            {
                                bool allowWatchBomb = false;
                                {
                                    if (mineSweeper.allowWatchBoomb.v)
                                    {
                                        // check is watcher?
                                        bool isWatcher = true;
                                        {
                                            Game game = mineSweeper.findDataInParent<Game>();
                                            if (game != null)
                                            {
                                                uint profileId = Server.getProfileUserId(game);
                                                // check each gamePlayer
                                                foreach (GamePlayer gamePlayer in game.gamePlayers.vs)
                                                {
                                                    if (gamePlayer.inform.v is Human)
                                                    {
                                                        Human human = gamePlayer.inform.v as Human;
                                                        if (human.playerId.v == profileId)
                                                        {
                                                            isWatcher = false;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("game null: " + this);
                                            }
                                        }
                                        if (isWatcher)
                                        {
                                            allowWatchBomb = true;
                                        }
                                    }
                                }
                                this.data.allowWatchBomb.v = allowWatchBomb;
                            }
                            // board
                            int X = mineSweeper.X.v;
                            int Y = mineSweeper.Y.v;
                            List<sbyte> board = mineSweeper.board.vs;
                            List<sbyte> bombs = mineSweeper.bombs.vs;
                            List<sbyte> flags = mineSweeper.flags.vs;
                            bool booom = mineSweeper.booom.v;
                            int newMoveAnimation = -1;
                            // Get Inform
                            {
                                MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation(this.data);
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.MineSweeperMove:
                                            {
                                                MineSweeperMoveAnimation mineSweeperMoveAnimation = moveAnimation as MineSweeperMoveAnimation;
                                                // get inform
                                                {
                                                    X = mineSweeperMoveAnimation.X.v;
                                                    Y = mineSweeperMoveAnimation.Y.v;
                                                    board = mineSweeperMoveAnimation.board.vs;
                                                    bombs = mineSweeperMoveAnimation.bombs.vs;
                                                    flags = mineSweeperMoveAnimation.flags.vs;
                                                }
                                                // move view to lastMove
                                                {
                                                    if (lastMoveAnimation != moveAnimation)
                                                    {
                                                        lastMoveAnimation = moveAnimation;
                                                        newMoveAnimation = mineSweeperMoveAnimation.move.v;
                                                    }
                                                }
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
                            // booom
                            this.data.booom.v = booom;
                            // dimension
                            {
                                // maxWidth
                                this.data.maxWidth.v = (X % 2 == 0) ? 20 : 19;
                                // maxHeigth
                                this.data.maxHeight.v = (Y % 2 == 0) ? 20 : 19;
                                // width
                                this.data.width.v = Mathf.Min(X, this.data.maxWidth.v);
                                // heigth
                                this.data.height.v = Mathf.Min(Y, this.data.maxHeight.v);
                                // x, y
                                {
                                    float newX = this.data.x.v;
                                    float newY = this.data.y.v;
                                    // change view position due to animation
                                    {
                                        if (newMoveAnimation >= 0)
                                        {
                                            if (mineSweeper.Y.v > 0)
                                            {
                                                int moveX = newMoveAnimation / mineSweeper.Y.v;
                                                int moveY = newMoveAnimation % mineSweeper.Y.v;
                                                if (moveX >= this.data.x.v && moveX < this.data.x.v + this.data.width.v
                                                   && moveY >= this.data.y.v && moveY < this.data.y.v + this.data.height.v)
                                                {
                                                    // Da o trong tam nhin
                                                }
                                                else
                                                {
                                                    // Chua o trong tam nhin, phai chuyen
                                                    newX = moveX - this.data.width.v / 2;
                                                    newY = moveY - this.data.height.v / 2;
                                                    Debug.LogError("not in the view, so change: " + newX + "; " + newY + "; " + moveX + "; " + moveY);
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("why Y < 0: " + mineSweeper.Y.v + "; " + this);
                                            }
                                        }
                                    }
                                    // Set
                                    {
                                        // x
                                        this.data.x.v = Mathf.Clamp(newX, 0, X - this.data.width.v);
                                        // y
                                        this.data.y.v = Mathf.Clamp(newY, 0, Y - this.data.height.v);
                                    }
                                }
                            }
                            // Pieces
                            {
                                // get old
                                List<PieceUI.UIData> oldPieces = new List<PieceUI.UIData>();
                                {
                                    oldPieces.AddRange(this.data.pieces.vs);
                                }
                                // Find from, dest
                                int fromX = Mathf.Max(Mathf.FloorToInt(this.data.x.v), 0);
                                int destX = Mathf.Min(Mathf.CeilToInt(this.data.x.v + this.data.width.v), X);
                                int fromY = Mathf.Max(Mathf.FloorToInt(this.data.y.v), 0);
                                int destY = Mathf.Min(Mathf.CeilToInt(this.data.y.v + this.data.height.v), Y);
                                // Debug.LogError (string.Format ("fromX: {0}, destX: {1}, fromY: {2}, dest: {3}", fromX, destX, fromY, destY));
                                // Update
                                for (int y = fromY; y < destY; y++)
                                    for (int x = fromX; x < destX; x++)
                                    {
                                        int index = y * X + x;
                                        // get inform
                                        sbyte piece = -1;
                                        sbyte bomb = 0;
                                        sbyte flag = 0;
                                        {
                                            if (index >= 0 && index < board.Count)
                                            {
                                                piece = board[index];
                                            }
                                            if (index >= 0 && index < bombs.Count)
                                            {
                                                bomb = bombs[index];
                                            }
                                            if (index >= 0 && index < flags.Count)
                                            {
                                                flag = flags[index];
                                            }
                                        }
                                        // check needPiece
                                        bool needPiece = true;
                                        {
                                            // TODO Co le ko can, phai hien de co pieceUI
                                            /*if (piece == -1 && bomb == 0 && flag == 0)
                                            {
                                                needPiece = false;
                                            }*/
                                        }
                                        if (needPiece)
                                        {
                                            bool needAdd = false;
                                            // Find PieceUI
                                            PieceUI.UIData pieceUIData = null;
                                            {
                                                // Find old
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
                                                pieceUIData.piece.v = piece;
                                                pieceUIData.bomb.v = bomb;
                                                pieceUIData.flag.v = flag;
                                            }
                                            // Add
                                            if (needAdd)
                                            {
                                                this.data.pieces.add(pieceUIData);
                                            }
                                        }
                                        else
                                        {
                                            // Debug.LogError ("Don't need piece: " + index + "; " + this);
                                        }
                                    }
                                // Remove old
                                foreach (PieceUI.UIData oldPiece in oldPieces)
                                {
                                    this.data.pieces.remove(oldPiece);
                                }
                            }
                            // Debug.LogError (Core.unityGetStrPosition (mineSweeper, Core.CanCorrect));
                        }
                        else
                        {
                            Debug.LogError("not load full");
                            dirty = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("mineSweeper null: " + this);
                    }
                    // siblingIndex
                    {
                        if (pieceContainer != null)
                        {
                            pieceContainer.SetSiblingIndex(0);
                        }
                        else
                        {
                            Debug.LogError("pieceContainer null");
                        }
                        UIRectTransform.SetSiblingIndex(this.data.boundary.v, 1);
                        UIRectTransform.SetSiblingIndex(this.data.scrollView.v, 2);
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

        public BoundaryUI boundaryPrefab;

        public ScrollViewUI scrollViewPrefab;

        public PieceUI piecePrefab;
        public Transform pieceContainer;

        private AnimationManagerCheckChange<UIData> animationManagerCheckChange = new AnimationManagerCheckChange<UIData>();
        private GameCheckPlayerChange<MineSweeper> gameCheckPlayerChange = new GameCheckPlayerChange<MineSweeper>();

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
                    uiData.mineSweeper.allAddCallBack(this);
                    uiData.boundary.allAddCallBack(this);
                    uiData.scrollView.allAddCallBack(this);
                    uiData.pieces.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // checkChange
            {
                if (data is AnimationManagerCheckChange<UIData>)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                // MineSweeper
                {
                    if (data is MineSweeper)
                    {
                        MineSweeper mineSweeper = data as MineSweeper;
                        // reset
                        {
                            if (this.data != null)
                            {
                                this.data.reset();
                            }
                            else
                            {
                                Debug.LogError("data null: " + this);
                            }
                        }
                        // CheckChange
                        {
                            gameCheckPlayerChange.addCallBack(this);
                            gameCheckPlayerChange.setData(mineSweeper);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if (data is GameCheckPlayerChange<MineSweeper>)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is BoundaryUI.UIData)
                {
                    BoundaryUI.UIData boundaryUIData = data as BoundaryUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(boundaryUIData, boundaryPrefab, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if (data is ScrollViewUI.UIData)
                {
                    ScrollViewUI.UIData scrollViewUIData = data as ScrollViewUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(scrollViewUIData, scrollViewPrefab, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if (data is PieceUI.UIData)
                {
                    PieceUI.UIData pieceUIData = data as PieceUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(pieceUIData, piecePrefab, pieceContainer);
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
                    uiData.mineSweeper.allRemoveCallBack(this);
                    uiData.boundary.allRemoveCallBack(this);
                    uiData.scrollView.allRemoveCallBack(this);
                    uiData.pieces.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // checkChange
            {
                if (data is AnimationManagerCheckChange<UIData>)
                {
                    return;
                }
            }
            // Child
            {
                // MineSweeper
                {
                    if (data is MineSweeper)
                    {
                        // MineSweeper mineSweeper = data as MineSweeper;
                        // CheckChange
                        {
                            gameCheckPlayerChange.removeCallBack(this);
                            gameCheckPlayerChange.setData(null);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is GameCheckPlayerChange<MineSweeper>)
                    {
                        return;
                    }
                }
                if (data is BoundaryUI.UIData)
                {
                    BoundaryUI.UIData boundaryUIData = data as BoundaryUI.UIData;
                    // UI
                    {
                        boundaryUIData.removeCallBackAndDestroy(typeof(BoundaryUI));
                    }
                    return;
                }
                if (data is ScrollViewUI.UIData)
                {
                    ScrollViewUI.UIData scrollViewUIData = data as ScrollViewUI.UIData;
                    // UI
                    {
                        scrollViewUIData.removeCallBackAndDestroy(typeof(ScrollViewUI));
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
                    case UIData.Property.mineSweeper:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.boundary:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.scrollView:
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
                    case UIData.Property.maxWidth:
                        dirty = true;
                        break;
                    case UIData.Property.maxHeight:
                        dirty = true;
                        break;
                    case UIData.Property.x:
                        dirty = true;
                        break;
                    case UIData.Property.y:
                        dirty = true;
                        break;
                    case UIData.Property.width:
                        dirty = true;
                        break;
                    case UIData.Property.height:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // checkChange
            {
                if (wrapProperty.p is AnimationManagerCheckChange<UIData>)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                // MineSweeper
                {
                    if (wrapProperty.p is MineSweeper)
                    {
                        switch ((MineSweeper.Property)wrapProperty.n)
                        {
                            case MineSweeper.Property.Y:
                                dirty = true;
                                break;
                            case MineSweeper.Property.X:
                                dirty = true;
                                break;
                            case MineSweeper.Property.K:
                                dirty = true;
                                break;
                            case MineSweeper.Property.bombs:
                                dirty = true;
                                break;
                            case MineSweeper.Property.booom:
                                dirty = true;
                                break;
                            case MineSweeper.Property.flags:
                                dirty = true;
                                break;
                            case MineSweeper.Property.board:
                                dirty = true;
                                break;
                            case MineSweeper.Property.minesFound:
                                dirty = true;
                                break;
                            case MineSweeper.Property.init:
                                dirty = true;
                                break;
                            case MineSweeper.Property.neb:
                                dirty = true;
                                break;
                            case MineSweeper.Property.allowWatchBoomb:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // CheckChange
                    if (wrapProperty.p is GameCheckPlayerChange<MineSweeper>)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (wrapProperty.p is BoundaryUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is ScrollViewUI.UIData)
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