using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
    public class BoardUI : UIBehavior<BoardUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<NineMenMorris>> nineMenMorris;

            public VP<BoardIndexsUI.UIData> boardIndexs;

            public LP<PieceUI.UIData> pieces;

            #region phase

            public enum Phase
            {
                Position,
                Play,
                Fly
            }

            public VP<Phase> phase;

            public VP<BoardPhaseUI.UIData> phaseUIData;

            #endregion

            #region Constructor

            public enum Property
            {
                nineMenMorris,
                boardIndexs,
                pieces,
                phase,
                phaseUIData
            }

            public UIData() : base()
            {
                this.nineMenMorris = new VP<ReferenceData<NineMenMorris>>(this, (byte)Property.nineMenMorris, new ReferenceData<NineMenMorris>(null));
                // boardIndexs
                {
                    this.boardIndexs = new VP<BoardIndexsUI.UIData>(this, (byte)Property.boardIndexs, new BoardIndexsUI.UIData());
                    this.boardIndexs.v.gameType.v = GameType.Type.NineMenMorris;
                }
                this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
                this.phase = new VP<Phase>(this, (byte)Property.phase, Phase.Position);
                this.phaseUIData = new VP<BoardPhaseUI.UIData>(this, (byte)Property.phaseUIData, new BoardPhaseUI.UIData());
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.NineMenMorris ? 1 : 0;
        }

        #region txt, rect

        static BoardUI()
        {
            // rect
            {
                // boardPhaseRect
                {
                    // anchoredPosition: (0.0, 8.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 0.0);
                    // offsetMin: (0.0, 8.0); offsetMax: (0.0, 30.0); sizeDelta: (0.0, 22.0);
                    boardPhaseRect.anchoredPosition = new Vector3(0.0f, 8.0f, 0.0f);
                    boardPhaseRect.anchorMin = new Vector2(0.0f, 1.0f);
                    boardPhaseRect.anchorMax = new Vector2(1.0f, 1.0f);
                    boardPhaseRect.pivot = new Vector2(0.5f, 0.0f);
                    boardPhaseRect.offsetMin = new Vector2(0.0f, 8.0f);
                    boardPhaseRect.offsetMax = new Vector2(0.0f, 30.0f);
                    boardPhaseRect.sizeDelta = new Vector2(0.0f, 22.0f);
                }
            }
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
                    NineMenMorris nineMenMorris = this.data.nineMenMorris.v.data;
                    if (nineMenMorris != null)
                    {
                        // check load full
                        bool isLoadFull = true;
                        {
                            // nineMenMorris
                            if (isLoadFull)
                            {
                                isLoadFull = nineMenMorris.isLoadFull();
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
                            bool blindFold = GameData.IsBlindFold(nineMenMorris);
                            // get olds
                            List<PieceUI.UIData> oldPieceUIs = new List<PieceUI.UIData>();
                            {
                                oldPieceUIs.AddRange(this.data.pieces.vs);
                            }
                            // board
                            List<int> board = nineMenMorris.board.vs;
                            int placePos = -1;
                            Common.SpotStatus placePiece = Common.SpotStatus.SS_Empty;
                            int turn = nineMenMorris.turn.v;
                            {
                                MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation(this.data);
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.NineMenMorrisMove:
                                            {
                                                NineMenMorrisMoveAnimation nineMenMorrisMoveAnimation = moveAnimation as NineMenMorrisMoveAnimation;
                                                board = nineMenMorrisMoveAnimation.board.vs;
                                                if (nineMenMorrisMoveAnimation.positioningDuration.v > 0)
                                                {
                                                    placePos = nineMenMorrisMoveAnimation.moved.v;
                                                    placePiece = nineMenMorrisMoveAnimation.turn.v % 2 == 0 ? Common.SpotStatus.SS_White : Common.SpotStatus.SS_Black;
                                                    turn = nineMenMorrisMoveAnimation.turn.v;
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
                            // phase
                            {
                                BoardUI.UIData.Phase phase = UIData.Phase.Position;
                                {
                                    if (turn < 18)
                                    {
                                        phase = UIData.Phase.Position;
                                    }
                                    else
                                    {
                                        int blackCount = 0;
                                        int whiteCount = 0;
                                        {
                                            for (int i = 0; i < board.Count; i++)
                                            {
                                                switch ((Common.SpotStatus)board[i])
                                                {
                                                    case Common.SpotStatus.SS_Empty:
                                                        break;
                                                    case Common.SpotStatus.SS_Black:
                                                        blackCount++;
                                                        break;
                                                    case Common.SpotStatus.SS_White:
                                                        whiteCount++;
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown type: " + board[i]);
                                                        break;
                                                }
                                            }
                                        }
                                        if (blackCount <= 3 || whiteCount <= 3)
                                        {
                                            phase = UIData.Phase.Fly;
                                        }
                                        else
                                        {
                                            phase = UIData.Phase.Play;
                                        }
                                    }
                                }
                                this.data.phase.v = phase;
                            }
                            // update
                            {
                                for (int i = 0; i < Common.BOARD_SPOT; i++)
                                {
                                    // get piece
                                    Common.SpotStatus piece = Common.SpotStatus.SS_Empty;
                                    {
                                        if (i == placePos)
                                        {
                                            piece = placePiece;
                                        }
                                        else if (i >= 0 && i < board.Count)
                                        {
                                            piece = (Common.SpotStatus)board[i];
                                        }
                                    }
                                    if (piece != Common.SpotStatus.SS_Empty)
                                    {
                                        // find pieceUI
                                        PieceUI.UIData pieceUIData = null;
                                        bool needAdd = false;
                                        {
                                            // find old
                                            foreach (PieceUI.UIData check in oldPieceUIs)
                                            {
                                                if (check.position.v == i)
                                                {
                                                    pieceUIData = check;
                                                    break;
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
                                        // Update
                                        {
                                            pieceUIData.position.v = i;
                                            pieceUIData.piece.v = piece;
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
                            // remove old
                            foreach (PieceUI.UIData oldPieceUI in oldPieceUIs)
                            {
                                this.data.pieces.remove(oldPieceUI);
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
                        Debug.LogError("nineMenMorris null");
                    }
                }
                else
                {
                    Debug.LogError("data null");
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

        public BoardPhaseUI boardPhasePrefab;
        private static readonly UIRectTransform boardPhaseRect = new UIRectTransform();

        private GameDataCheckChangeBlindFold<NineMenMorris> gameDataCheckChangeBlindFold = new GameDataCheckChangeBlindFold<NineMenMorris>();

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
                    uiData.nineMenMorris.allAddCallBack(this);
                    uiData.boardIndexs.allAddCallBack(this);
                    uiData.pieces.allAddCallBack(this);
                    uiData.phaseUIData.allAddCallBack(this);
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
                // nineMenMorris
                {
                    if (data is NineMenMorris)
                    {
                        NineMenMorris nineMenMorris = data as NineMenMorris;
                        // checkChange
                        {
                            gameDataCheckChangeBlindFold.addCallBack(this);
                            gameDataCheckChangeBlindFold.setData(nineMenMorris);
                        }
                        dirty = true;
                        return;
                    }
                    // checkChange
                    if (data is GameDataCheckChangeBlindFold<NineMenMorris>)
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
                if (data is BoardPhaseUI.UIData)
                {
                    BoardPhaseUI.UIData boardPhaseUIData = data as BoardPhaseUI.UIData;
                    // UI
                    {
                        // container
                        Transform container = null;
                        {
                            GameDataBoardUI.UIData gameDataBoardUIData = boardPhaseUIData.findDataInParent<GameDataBoardUI.UIData>();
                            if (gameDataBoardUIData != null)
                            {
                                GameDataBoardUI gameDataBoardUI = gameDataBoardUIData.findCallBack<GameDataBoardUI>();
                                if (gameDataBoardUI != null)
                                {
                                    container = gameDataBoardUI.transform;
                                }
                                else
                                {
                                    Debug.LogError("gameDataBoardUI null");
                                }
                            }
                            else
                            {
                                Debug.LogError("gameDataBoardUIData null");
                            }
                        }
                        // set
                        UIUtils.Instantiate(boardPhaseUIData, boardPhasePrefab, container, boardPhaseRect);
                        UIRectTransform.SetSiblingIndex(boardPhaseUIData, 0);
                    }
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
                    uiData.nineMenMorris.allRemoveCallBack(this);
                    uiData.boardIndexs.allRemoveCallBack(this);
                    uiData.pieces.allRemoveCallBack(this);
                    uiData.phaseUIData.allRemoveCallBack(this);
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
                // nineMenMorris
                {
                    if (data is NineMenMorris)
                    {
                        // NineMenMorris nineMenMorris = data as NineMenMorris;
                        // checkChange
                        {
                            gameDataCheckChangeBlindFold.removeCallBack(this);
                            gameDataCheckChangeBlindFold.setData(null);
                        }
                        return;
                    }
                    // checkChange
                    if (data is GameDataCheckChangeBlindFold<NineMenMorris>)
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
                if (data is BoardPhaseUI.UIData)
                {
                    BoardPhaseUI.UIData boardPhaseUIData = data as BoardPhaseUI.UIData;
                    // UI
                    {
                        boardPhaseUIData.removeCallBackAndDestroy(typeof(BoardPhaseUI));
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
                    case UIData.Property.nineMenMorris:
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
                    case UIData.Property.phase:
                        break;
                    case UIData.Property.phaseUIData:
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
            // Check Change
            if (wrapProperty.p is AnimationManagerCheckChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // nineMenMorris
                {
                    if (wrapProperty.p is NineMenMorris)
                    {
                        switch ((NineMenMorris.Property)wrapProperty.n)
                        {
                            case NineMenMorris.Property.board:
                                dirty = true;
                                break;
                            case NineMenMorris.Property.moved:
                                break;
                            case NineMenMorris.Property.moved_to:
                                break;
                            case NineMenMorris.Property.action:
                                break;
                            case NineMenMorris.Property.mill:
                                break;
                            case NineMenMorris.Property.terminal:
                                break;
                            case NineMenMorris.Property.removed:
                                break;
                            case NineMenMorris.Property.utility:
                                break;
                            case NineMenMorris.Property.turn:
                                break;
                            case NineMenMorris.Property.isCustom:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // checkChange
                    if (wrapProperty.p is GameDataCheckChangeBlindFold<NineMenMorris>)
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
                if (wrapProperty.p is BoardPhaseUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}