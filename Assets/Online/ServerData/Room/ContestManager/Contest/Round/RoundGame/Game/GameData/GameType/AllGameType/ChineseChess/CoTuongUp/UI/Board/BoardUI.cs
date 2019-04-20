using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rule;

namespace CoTuongUp
{
    public class BoardUI : UIBehavior<BoardUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<CoTuongUp>> coTuongUp;

            public VP<BoardIndexsUI.UIData> boardIndexs;

            public VP<bool> isWatcher;

            public LP<PieceUI.UIData> pieces;

            public LP<CaptureUI.UIData> captures;

            #region Constructor

            public enum Property
            {
                coTuongUp,
                boardIndexs,
                isWatcher,
                pieces,
                captures
            }

            public UIData() : base()
            {
                this.coTuongUp = new VP<ReferenceData<CoTuongUp>>(this, (byte)Property.coTuongUp, new ReferenceData<CoTuongUp>(null));
                // boardIndexs
                {
                    this.boardIndexs = new VP<BoardIndexsUI.UIData>(this, (byte)Property.boardIndexs, new BoardIndexsUI.UIData());
                    this.boardIndexs.v.gameType.v = GameType.Type.CO_TUONG_UP;
                }
                this.isWatcher = new VP<bool>(this, (byte)Property.isWatcher, false);
                this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
                this.captures = new LP<CaptureUI.UIData>(this, (byte)Property.captures);
            }

            #endregion

        }

        #endregion

        #region Refresh

        public RectTransform redHand;
        public RectTransform blackHand;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    CoTuongUp coTuongUp = this.data.coTuongUp.v.data;
                    if (coTuongUp != null)
                    {
                        // check load full
                        bool isLoadFull = true;
                        {
                            // coTuongUp
                            if (isLoadFull)
                            {
                                isLoadFull = coTuongUp.isLoadFull();
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
                            // check canView
                            {
                                bool canView = false;
                                {
                                    if (coTuongUp.allowWatcherViewHidden.v)
                                    {
                                        bool isYouViewer = true;
                                        {
                                            Game game = coTuongUp.findDataInParent<Game>();
                                            if (game != null)
                                            {
                                                for (int i = 0; i < game.gamePlayers.vs.Count; i++)
                                                {
                                                    GamePlayer gamePlayer = game.gamePlayers.vs[i];
                                                    if (gamePlayer.inform.v is Human)
                                                    {
                                                        Human human = gamePlayer.inform.v as Human;
                                                        if (human.playerId.v == Server.getProfileUserId(game))
                                                        {
                                                            isYouViewer = false;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("duel null: " + this);
                                                isYouViewer = false;
                                            }
                                        }
                                        if (isYouViewer)
                                        {
                                            canView = true;
                                        }
                                    }
                                }
                                this.data.isWatcher.v = canView;
                            }
                            // Update pieces, captures
                            {
                                // Find current node
                                Node currentNode = null;
                                {
                                    MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation(this.data);
                                    if (moveAnimation != null)
                                    {
                                        switch (moveAnimation.getType())
                                        {
                                            case GameMove.Type.CoTuongUpMove:
                                                {
                                                    CoTuongUpMoveAnimation coTuongUpMoveAnimation = moveAnimation as CoTuongUpMoveAnimation;
                                                    currentNode = coTuongUpMoveAnimation.node.v;
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + moveAnimation.getType() + "; " + this);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        if (coTuongUp.nodes.vs.Count > 0)
                                        {
                                            currentNode = coTuongUp.nodes.vs[coTuongUp.nodes.vs.Count - 1];
                                        }
                                    }
                                }
                                if (currentNode != null)
                                {
                                    // Normal board
                                    bool blindFold = GameData.IsBlindFold(coTuongUp);
                                    {
                                        // get olds
                                        List<PieceUI.UIData> oldPieceUIs = new List<PieceUI.UIData>();
                                        {
                                            oldPieceUIs.AddRange(this.data.pieces.vs);
                                        }
                                        // Make pieceUI
                                        {
                                            Board board = Rule.getBoard(currentNode);
                                            for (byte x = 0; x < board.board.GetLength(0); x++)
                                                for (byte y = 0; y < board.board.GetLength(1); y++)
                                                {
                                                    if (board.board[x, y] != 0)
                                                    {
                                                        byte coord = Common.makeCoord(x, y);
                                                        // Find pieceUIData
                                                        bool needAdd = false;
                                                        PieceUI.UIData pieceUIData = null;
                                                        {
                                                            // find old
                                                            foreach (PieceUI.UIData check in oldPieceUIs)
                                                            {
                                                                if (check.coord.v == coord)
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
                                                        // Update Property
                                                        {
                                                            pieceUIData.coord.v = coord;
                                                            pieceUIData.piece.v = board.board[x, y];
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
                                        // Remove oldPieceUIs not reuse
                                        foreach (PieceUI.UIData pieceUIData in oldPieceUIs)
                                        {
                                            this.data.pieces.remove(pieceUIData);
                                        }
                                    }
                                    // Captures
                                    {
                                        // get old list
                                        List<CaptureUI.UIData> oldCaptureUIs = new List<CaptureUI.UIData>();
                                        {
                                            oldCaptureUIs.AddRange(this.data.captures.vs);
                                        }
                                        // Update
                                        {
                                            for (int i = 0; i < currentNode.captures.vs.Count; i++)
                                            {
                                                byte capture = currentNode.captures.vs[i];
                                                // Debug.LogError ("make captureUIData: " + capture + "; " + this);
                                                // Find captureUIData
                                                CaptureUI.UIData captureUIData = null;
                                                {
                                                    // Find old
                                                    {
                                                        if (oldCaptureUIs.Count > 0)
                                                        {
                                                            captureUIData = oldCaptureUIs[0];
                                                            oldCaptureUIs.RemoveAt(0);
                                                        }
                                                    }
                                                    // Make new
                                                    if (captureUIData == null)
                                                    {
                                                        captureUIData = new CaptureUI.UIData();
                                                        {
                                                            captureUIData.uid = this.data.captures.makeId();
                                                        }
                                                        this.data.captures.add(captureUIData);
                                                    }
                                                }
                                                // Update Property
                                                {
                                                    captureUIData.piece.v = capture;
                                                }
                                            }
                                        }
                                        // Remove old
                                        foreach (CaptureUI.UIData captureUIData in oldCaptureUIs)
                                        {
                                            this.data.captures.remove(captureUIData);
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("currentNode null: " + this);
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
                            UIRectTransform.SetSiblingIndex(this.data.boardIndexs.v, 1);
                        }
                    }
                    else
                    {
                        Debug.LogError("coTuongUp null: " + this);
                    }
                    // hand
                    {
                        if(redHand!=null && blackHand != null)
                        {
                            // find
                            float distance = 600;
                            {
                                switch (Setting.get().boardIndex.v)
                                {
                                    case Setting.BoardIndex.None:
                                        // nhu default
                                        break;
                                    case Setting.BoardIndex.InBoard:
                                        // nhu default
                                        break;
                                    case Setting.BoardIndex.OutBoard:
                                        distance = 650;
                                        break;
                                    default:
                                        Debug.LogError("unknown boardIndex: " + Setting.get().boardIndex.v);
                                        break;
                                }
                            }
                            // red
                            {
                                UIRectTransform rect = new UIRectTransform();
                                {
                                    // anchoredPosition: (0.0, -600.0); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                                    // offsetMin: (-450.0, -650.0); offsetMax: (450.0, -550.0); sizeDelta: (900.0, 100.0);
                                    rect.anchoredPosition = new Vector3(0.0f, -distance);
                                    rect.anchorMin = new Vector2(0.5f, 0.5f);
                                    rect.anchorMax = new Vector2(0.5f, 0.5f);
                                    rect.pivot = new Vector2(0.5f, 0.5f);
                                    rect.offsetMin = new Vector2(-450.0f, -distance - 50.0f);
                                    rect.offsetMax = new Vector2(450.0f, -distance + 50.0f);
                                    rect.sizeDelta = new Vector2(900.0f, 100.0f);
                                }
                                rect.set(redHand);
                            }
                            // black
                            {
                                UIRectTransform rect = new UIRectTransform();
                                {
                                    rect.anchoredPosition = new Vector3(0.0f, distance);
                                    rect.anchorMin = new Vector2(0.5f, 0.5f);
                                    rect.anchorMax = new Vector2(0.5f, 0.5f);
                                    rect.pivot = new Vector2(0.5f, 0.5f);
                                    rect.offsetMin = new Vector2(-450.0f, distance + 50.0f);
                                    rect.offsetMax = new Vector2(450.0f, distance - 50.0f);
                                    rect.sizeDelta = new Vector2(900.0f, 100.0f);
                                }
                                rect.set(blackHand);
                            }
                        }
                        else
                        {
                            Debug.LogError("redHand, blackHand null");
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

        public PieceUI piecePrefab;

        public CaptureUI capturePrefab;
        public Transform redCaptureContainer;
        public Transform blackCaptureContainer;

        private GameCheckPlayerChange<CoTuongUp> gameCheckPlayerChange = new GameCheckPlayerChange<CoTuongUp>();
        private AnimationManagerCheckChange<UIData> animationManagerCheckChange = new AnimationManagerCheckChange<UIData>();
        private GameDataCheckChangeBlindFold<CoTuongUp> gameDataCheckChangeBlindFold = new GameDataCheckChangeBlindFold<CoTuongUp>();

        public BoardIndexsUI boardIndexsPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
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
                    uiData.coTuongUp.allAddCallBack(this);
                    uiData.boardIndexs.allAddCallBack(this);
                    uiData.pieces.allAddCallBack(this);
                    uiData.captures.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if(data is Setting)
            {
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
                // CoTuongUp
                {
                    if (data is CoTuongUp)
                    {
                        CoTuongUp coTuongUp = data as CoTuongUp;
                        // CheckChange
                        {
                            // playerChange
                            {
                                gameCheckPlayerChange.addCallBack(this);
                                gameCheckPlayerChange.setData(coTuongUp);
                            }
                            // blindFold
                            {
                                gameDataCheckChangeBlindFold.addCallBack(this);
                                gameDataCheckChangeBlindFold.setData(coTuongUp);
                            }
                        }
                        // Child
                        {
                            coTuongUp.nodes.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    {
                        if (data is GameCheckPlayerChange<CoTuongUp>)
                        {
                            dirty = true;
                            return;
                        }
                        if (data is GameDataCheckChangeBlindFold<CoTuongUp>)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    // Child
                    if (data is Node)
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
                if (data is CaptureUI.UIData)
                {
                    CaptureUI.UIData captureUIData = data as CaptureUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(captureUIData, capturePrefab, redCaptureContainer);
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
                // Setting
                Setting.get().removeCallBack(this);
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
                    uiData.coTuongUp.allRemoveCallBack(this);
                    uiData.boardIndexs.allRemoveCallBack(this);
                    uiData.pieces.allRemoveCallBack(this);
                    uiData.captures.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if(data is Setting)
            {
                return;
            }
            // checkChange
            if (data is AnimationManagerCheckChange<UIData>)
            {
                return;
            }
            // Child
            {
                // CoTuongUp
                {
                    if (data is CoTuongUp)
                    {
                        CoTuongUp coTuongUp = data as CoTuongUp;
                        // CheckChange
                        {
                            // playerChange
                            {
                                gameCheckPlayerChange.removeCallBack(this);
                                gameCheckPlayerChange.setData(null);
                            }
                            // blindFold
                            {
                                gameDataCheckChangeBlindFold.removeCallBack(this);
                                gameDataCheckChangeBlindFold.setData(null);
                            }
                        }
                        // Child
                        {
                            coTuongUp.nodes.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // checkChange
                    {
                        if (data is GameCheckPlayerChange<CoTuongUp>)
                        {
                            return;
                        }
                        if (data is GameDataCheckChangeBlindFold<CoTuongUp>)
                        {
                            return;
                        }
                    }
                    if (data is Node)
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
                if (data is CaptureUI.UIData)
                {
                    CaptureUI.UIData captureUIData = data as CaptureUI.UIData;
                    // UI
                    {
                        captureUIData.removeCallBackAndDestroy(typeof(CaptureUI));
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
                    case UIData.Property.coTuongUp:
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
                    case UIData.Property.isWatcher:
                        break;
                    case UIData.Property.pieces:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            // dirty = true;
                        }
                        break;
                    case UIData.Property.captures:
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
            if(wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        break;
                    case Setting.Property.style:
                        break;
                    case Setting.Property.contentTextSize:
                        break;
                    case Setting.Property.titleTextSize:
                        break;
                    case Setting.Property.labelTextSize:
                        break;
                    case Setting.Property.buttonSize:
                        break;
                    case Setting.Property.itemSize:
                        break;
                    case Setting.Property.confirmQuit:
                        break;
                    case Setting.Property.boardIndex:
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
                    case Setting.Property.defaultChosenGame:
                        break;
                    case Setting.Property.defaultRoomName:
                        break;
                    case Setting.Property.defaultChatRoomStyle:
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
                // CoTuongUp
                {
                    if (wrapProperty.p is CoTuongUp)
                    {
                        switch ((CoTuongUp.Property)wrapProperty.n)
                        {
                            case CoTuongUp.Property.allowOnlyFlip:
                                break;
                            case CoTuongUp.Property.turn:
                                break;
                            case CoTuongUp.Property.side:
                                break;
                            case CoTuongUp.Property.nodes:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case CoTuongUp.Property.plyDraw:
                                break;
                            case CoTuongUp.Property.isCustom:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // checkChange
                    {
                        if (wrapProperty.p is GameCheckPlayerChange<CoTuongUp>)
                        {
                            dirty = true;
                            return;
                        }
                        if (wrapProperty.p is GameDataCheckChangeBlindFold<CoTuongUp>)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    if (wrapProperty.p is Node)
                    {
                        switch ((Node.Property)wrapProperty.n)
                        {
                            case Node.Property.ply:
                                break;
                            case Node.Property.pieces:
                                dirty = true;
                                break;
                            case Node.Property.captures:
                                dirty = true;
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
                if (wrapProperty.p is PieceUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is CaptureUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}