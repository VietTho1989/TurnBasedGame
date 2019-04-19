using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
{
    public class BoardUI : UIBehavior<BoardUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<FairyChess>> fairyChess;

            public VP<BoardIndexsUI.UIData> boardIndexs;

            public LP<PieceUI.UIData> pieces;

            public LP<HandPieceUI.UIData> whiteHand;

            public LP<HandPieceUI.UIData> blackHand;

            #region Constructor

            public enum Property
            {
                fairyChess,
                boardIndexs,
                pieces,
                whiteHand,
                blackHand
            }

            public UIData() : base()
            {
                this.fairyChess = new VP<ReferenceData<FairyChess>>(this, (byte)Property.fairyChess, new ReferenceData<FairyChess>(null));
                // boardIndexs
                {
                    this.boardIndexs = new VP<BoardIndexsUI.UIData>(this, (byte)Property.boardIndexs, new BoardIndexsUI.UIData());
                    this.boardIndexs.v.gameType.v = GameType.Type.FairyChess;
                }
                this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
                this.whiteHand = new LP<HandPieceUI.UIData>(this, (byte)Property.whiteHand);
                this.blackHand = new LP<HandPieceUI.UIData>(this, (byte)Property.blackHand);
            }

            #endregion
        }

        #endregion

        #region refresh

        public RectTransform whiteHand;
        public RectTransform blackHand;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    FairyChess fairyChess = this.data.fairyChess.v.data;
                    if (fairyChess != null)
                    {
                        // check load full
                        bool isLoadFull = true;
                        {
                            // chess
                            if (isLoadFull)
                            {
                                if (fairyChess.board.vs.Count == 0)
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
                            // Find board
                            List<int> board = fairyChess.board.vs;
                            Common.Piece dropPiece = Common.Piece.NO_PIECE;
                            int dropPosition = -1;
                            List<int> pieceCountInHand = fairyChess.pieceCountInHand.vs;
                            {
                                MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation(this.data);
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.FairyChessMove:
                                            {
                                                FairyChessMoveAnimation fairyChessMoveAnimation = moveAnimation as FairyChessMoveAnimation;
                                                board = fairyChessMoveAnimation.board.vs;
                                                // drop
                                                {
                                                    FairyChessMove.Move move = new FairyChessMove.Move(fairyChessMoveAnimation.move.v);
                                                    if (move.type == Common.MoveType.DROP)
                                                    {
                                                        dropPosition = (int)move.dest;
                                                        dropPiece = fairyChessMoveAnimation.promoteOrDropPiece.v;
                                                        // Debug.LogError ("dropPiece: " + dropPiece + "; " + dropPosition);
                                                    }
                                                }
                                                pieceCountInHand = fairyChessMoveAnimation.pieceCountInHand.vs;
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
                            // Normal board
                            bool blindFold = GameData.IsBlindFold(fairyChess);
                            {
                                // get olds
                                List<PieceUI.UIData> oldPieceUIs = new List<PieceUI.UIData>();
                                {
                                    oldPieceUIs.AddRange(this.data.pieces.vs);
                                }
                                // Make pieceUI
                                {
                                    for (int index = 0; index < board.Count; index++)
                                    {
                                        int pieceIndex = board[index];
                                        if (pieceIndex >= 0 && pieceIndex <= (int)Common.Piece.PIECE_NB)
                                        {
                                            Common.Piece piece = (Common.Piece)pieceIndex;
                                            Common.PieceType pieceType = Common.type_of(piece);
                                            if ((pieceType != Common.PieceType.NO_PIECE_TYPE
                                                && pieceType != Common.PieceType.ALL_PIECES
                                                && pieceType != Common.PieceType.PIECE_TYPE_NB) || (index == dropPosition))
                                            {
                                                bool needAdd = false;
                                                // Find pieceUI
                                                PieceUI.UIData pieceUIData = null;
                                                {
                                                    // Find old
                                                    foreach (PieceUI.UIData check in oldPieceUIs)
                                                    {
                                                        if (check.position.v == index)
                                                        {
                                                            pieceUIData = check;
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
                                                        oldPieceUIs.Remove(pieceUIData);
                                                    }
                                                }
                                                // Update Property
                                                {
                                                    pieceUIData.variantType.v = (Common.VariantType)fairyChess.variantType.v;
                                                    // piece
                                                    if (index != dropPosition)
                                                    {
                                                        pieceUIData.piece.v = piece;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("makeDropPiece: " + dropPiece);
                                                        pieceUIData.piece.v = dropPiece;
                                                    }
                                                    pieceUIData.position.v = index;
                                                    pieceUIData.blindFold.v = blindFold;
                                                }
                                                // add
                                                if (needAdd)
                                                {
                                                    this.data.pieces.add(pieceUIData);
                                                }
                                            }
                                            else
                                            {
                                                // Debug.Log ("pieceIndex wrong: " + piece + "; " + this);
                                            }
                                        }
                                    }
                                }
                                // Remove oldPieceUIs not reuse
                                foreach (PieceUI.UIData oldPieceUI in oldPieceUIs)
                                {
                                    this.data.pieces.remove(oldPieceUI);
                                }
                            }
                            // Hand
                            {
                                // Get old
                                List<HandPieceUI.UIData> oldWhiteHands = new List<HandPieceUI.UIData>();
                                List<HandPieceUI.UIData> oldBlackHands = new List<HandPieceUI.UIData>();
                                {
                                    oldWhiteHands.AddRange(this.data.whiteHand.vs);
                                    oldBlackHands.AddRange(this.data.blackHand.vs);
                                }
                                // Update
                                {
                                    // int32_t pieceCountInHand[COLOR_NB][PIECE_TYPE_NB]
                                    for (int handIndex = 0; handIndex < pieceCountInHand.Count; handIndex++)
                                    {
                                        if (pieceCountInHand[handIndex] > 0)
                                        {
                                            Common.Color color = (handIndex / (int)Common.PieceType.PIECE_TYPE_NB) == 0 ? Common.Color.WHITE : Common.Color.BLACK;
                                            int pieceType = handIndex % (int)Common.PieceType.PIECE_TYPE_NB;
                                            if (pieceType > 0 && pieceType < (int)Common.PieceType.PIECE_TYPE_NB)
                                            {
                                                // Find handPieceUIData
                                                HandPieceUI.UIData handPieceUIData = null;
                                                {
                                                    // Find old
                                                    {
                                                        List<HandPieceUI.UIData> olds = (color == Common.Color.WHITE ? oldWhiteHands : oldBlackHands);
                                                        if (olds.Count > 0)
                                                        {
                                                            handPieceUIData = olds[0];
                                                            olds.Remove(handPieceUIData);
                                                        }
                                                    }
                                                    // Make new
                                                    if (handPieceUIData == null)
                                                    {
                                                        LP<HandPieceUI.UIData> lp = (color == Common.Color.WHITE ? this.data.whiteHand : this.data.blackHand);
                                                        handPieceUIData = new HandPieceUI.UIData();
                                                        {
                                                            handPieceUIData.uid = lp.makeId();
                                                        }
                                                        lp.add(handPieceUIData);
                                                    }
                                                }
                                                // Update Property
                                                {
                                                    // variantType
                                                    handPieceUIData.variantType.v = (Common.VariantType)fairyChess.variantType.v;
                                                    // piece
                                                    handPieceUIData.piece.v = Common.make_piece(color, (Common.PieceType)pieceType);
                                                    // count
                                                    handPieceUIData.count.v = pieceCountInHand[handIndex];
                                                }
                                                // Debug.LogError ("pieceCountInHand: " + pieceCountInHand [handIndex]);
                                            }
                                            else
                                            {
                                                // Debug.LogError ("unknown pieceType: " + pieceType);
                                            }
                                        }
                                    }
                                }
                                // Remove old
                                {
                                    foreach (HandPieceUI.UIData oldWhiteHand in oldWhiteHands)
                                    {
                                        this.data.whiteHand.remove(oldWhiteHand);
                                    }
                                    foreach (HandPieceUI.UIData oldBlackHand in oldBlackHands)
                                    {
                                        this.data.blackHand.remove(oldBlackHand);
                                    }
                                }
                                // show hand or not
                                {
                                    if (handContainer != null)
                                    {
                                        if (this.data.whiteHand.vs.Count == 0 && this.data.blackHand.vs.Count == 0)
                                        {
                                            handContainer.SetActive(false);
                                        }
                                        else
                                        {
                                            handContainer.SetActive(true);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("handContainer null: " + this);
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
                        // hand
                        {
                            if(whiteHand!=null && blackHand != null)
                            {
                                // find distance
                                float distance = 500;
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
                                            distance = 550;
                                            break;
                                        default:
                                            Debug.LogError("unknown boardIndex: " + Setting.get().boardIndex.v);
                                            break;
                                    }
                                }
                                // process
                                {
                                    // white: -distance
                                    {
                                        UIRectTransform rect = new UIRectTransform();
                                        {
                                            // anchoredPosition: (0.0, -500.0); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                                            // offsetMin: (-400.0, -570.0); offsetMax: (400.0, -430.0); sizeDelta: (800.0, 140.0);
                                            rect.anchoredPosition = new Vector3(0.0f, -distance, 0.0f);
                                            rect.anchorMin = new Vector2(0.5f, 0.5f);
                                            rect.anchorMax = new Vector2(0.5f, 0.5f);
                                            rect.pivot = new Vector2(0.5f, 0.5f);
                                            rect.offsetMin = new Vector2(-400.0f, -distance - 70.0f);
                                            rect.offsetMax = new Vector2(400.0f, -distance + 70.0f);
                                            rect.sizeDelta = new Vector2(800.0f, 140.0f);
                                        }
                                        rect.set(whiteHand);
                                    }
                                    // black: +distance
                                    {
                                        UIRectTransform rect = new UIRectTransform();
                                        {
                                            rect.anchoredPosition = new Vector3(0.0f, distance, 0.0f);
                                            rect.anchorMin = new Vector2(0.5f, 0.5f);
                                            rect.anchorMax = new Vector2(0.5f, 0.5f);
                                            rect.pivot = new Vector2(0.5f, 0.5f);
                                            rect.offsetMin = new Vector2(-400.0f, distance - 70.0f);
                                            rect.offsetMax = new Vector2(400.0f, distance + 70.0f);
                                            rect.sizeDelta = new Vector2(800.0f, 140.0f);
                                        }
                                        rect.set(blackHand);
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("whiteHand, blackHand null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("fairyChess null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("why data null: " + this);
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

        public HandPieceUI handPiecePrefab;
        public Transform whiteHandContainer;
        public Transform blackHandContainer;
        public GameObject handContainer;

        private GameDataCheckChangeBlindFold<FairyChess> gameDataCheckChangeBlindFold = new GameDataCheckChangeBlindFold<FairyChess>();

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
                    uiData.fairyChess.allAddCallBack(this);
                    uiData.boardIndexs.allAddCallBack(this);
                    uiData.pieces.allAddCallBack(this);
                    uiData.whiteHand.allAddCallBack(this);
                    uiData.blackHand.allAddCallBack(this);
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
                // fairyChess
                {
                    if (data is FairyChess)
                    {
                        FairyChess fairyChess = data as FairyChess;
                        // checkChange
                        {
                            gameDataCheckChangeBlindFold.addCallBack(this);
                            gameDataCheckChangeBlindFold.setData(fairyChess);
                        }
                        dirty = true;
                        return;
                    }
                    // checkChange
                    if (data is GameDataCheckChangeBlindFold<FairyChess>)
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
                // Hand
                if (data is HandPieceUI.UIData)
                {
                    HandPieceUI.UIData handPieceUIData = data as HandPieceUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = handPieceUIData.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.whiteHand:
                                    UIUtils.Instantiate(handPieceUIData, handPiecePrefab, whiteHandContainer);
                                    break;
                                case UIData.Property.blackHand:
                                    UIUtils.Instantiate(handPieceUIData, handPiecePrefab, blackHandContainer);
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("wrapProperty null: " + this);
                        }
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
                    uiData.fairyChess.allRemoveCallBack(this);
                    uiData.boardIndexs.allRemoveCallBack(this);
                    uiData.pieces.allRemoveCallBack(this);
                    uiData.whiteHand.allRemoveCallBack(this);
                    uiData.blackHand.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
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
                return;
            }
            // Child
            {
                // fairyChess
                {
                    if (data is FairyChess)
                    {
                        // FairyChess fairyChess = data as FairyChess;
                        // checkChange
                        {
                            gameDataCheckChangeBlindFold.removeCallBack(this);
                            gameDataCheckChangeBlindFold.setData(null);
                        }
                        return;
                    }
                    // checkChange
                    if (data is GameDataCheckChangeBlindFold<FairyChess>)
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
                // Hand
                if (data is HandPieceUI.UIData)
                {
                    HandPieceUI.UIData handPieceUIData = data as HandPieceUI.UIData;
                    // UI
                    {
                        handPieceUIData.removeCallBackAndDestroy(typeof(HandPieceUI));
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
                    case UIData.Property.fairyChess:
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
                    case UIData.Property.whiteHand:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.blackHand:
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
                // fairyChess
                {
                    if (wrapProperty.p is FairyChess)
                    {
                        switch ((FairyChess.Property)wrapProperty.n)
                        {
                            case FairyChess.Property.board:
                                dirty = true;
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
                                break;
                            case FairyChess.Property.variantType:
                                dirty = true;
                                break;
                            case FairyChess.Property.st:
                                break;
                            case FairyChess.Property.chess960:
                                break;
                            case FairyChess.Property.pieceCountInHand:
                                dirty = true;
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
                    // checkChange
                    if (wrapProperty.p is GameDataCheckChangeBlindFold<FairyChess>)
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
                // Hand
                if (wrapProperty.p is HandPieceUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}