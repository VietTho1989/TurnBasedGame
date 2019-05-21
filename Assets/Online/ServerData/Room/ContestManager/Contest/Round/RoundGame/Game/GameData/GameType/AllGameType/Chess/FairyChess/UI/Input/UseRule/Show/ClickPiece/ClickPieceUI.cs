using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace FairyChess.UseRule
{
    public class ClickPieceUI : UIBehavior<ClickPieceUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : ShowUI.UIData.Sub
        {

            public VP<int> keyX;

            public VP<int> keyY;

            #region Constructor

            public enum Property
            {
                keyX,
                keyY
            }

            public UIData() : base()
            {
                this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
                this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
            }

            #endregion

            public override Type getType()
            {
                return Type.ClickPiece;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    if (InputEvent.isEnter(e))
                    {
                        // enter
                        ClickPieceUI clickPieceUI = this.findCallBack<ClickPieceUI>();
                        if (clickPieceUI != null)
                        {
                            clickPieceUI.onEnterKey();
                        }
                        else
                        {
                            Debug.LogError("clickPieceUI null: " + this);
                        }
                        isProcess = true;
                    }
                    else if (InputEvent.isArrow(e))
                    {
                        if (this.keyX.v >= 0 && this.keyX.v < 8
                            && this.keyY.v >= 0 && this.keyY.v < 8)
                        {
                            // find new key position
                            int newKeyX = this.keyX.v;
                            int newKeyY = this.keyY.v;
                            {
                                switch (e.keyCode)
                                {
                                    case KeyCode.LeftArrow:
                                        newKeyX--;
                                        break;
                                    case KeyCode.RightArrow:
                                        newKeyX++;
                                        break;
                                    case KeyCode.UpArrow:
                                        newKeyY++;
                                        break;
                                    case KeyCode.DownArrow:
                                        newKeyY--;
                                        break;
                                    default:
                                        Debug.LogError("unknown keyCode: " + e.keyCode);
                                        break;
                                }
                            }
                            // set
                            if (newKeyX >= 0 && newKeyX < 8
                                && newKeyY >= 0 && newKeyY < 8)
                            {
                                this.keyX.v = newKeyX;
                                this.keyY.v = newKeyY;
                            }
                        }
                        else
                        {
                            // bring to lastMove
                            int lastKeyX = 4;
                            int lastKeyY = 4;
                            {
                                // find gameMove
                                GameMove gameMove = null;
                                {
                                    // Find gameData
                                    GameData gameData = null;
                                    {
                                        GameDataUI.UIData gameDataUIData = this.findDataInParent<GameDataUI.UIData>();
                                        if (gameDataUIData != null)
                                        {
                                            gameData = gameDataUIData.gameData.v.data;
                                        }
                                        else
                                        {
                                            Debug.LogError("gameDataUIData null: ");
                                        }
                                    }
                                    // Process
                                    if (gameData != null)
                                    {
                                        LastMove lastMove = gameData.lastMove.v;
                                        if (lastMove != null)
                                        {
                                            gameMove = lastMove.gameMove.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("lastMove null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        // Debug.LogError ("gameData null: " + data);
                                    }
                                }
                                // process
                                if (gameMove != null)
                                {
                                    switch (gameMove.getType())
                                    {
                                        case GameMove.Type.FairyChessMove:
                                            {
                                                FairyChessMove fairyChessMove = gameMove as FairyChessMove;
                                                int fromX = 0;
                                                int fromY = 0;
                                                int destX = 0;
                                                int destY = 0;
                                                FairyChessMove.GetClickPosition(fairyChessMove.move.v, out fromX, out fromY, out destX, out destY);
                                                lastKeyX = destX;
                                                lastKeyY = destY;
                                            }
                                            break;
                                        case GameMove.Type.FairyChessCustomSet:
                                            {
                                                NoneRule.FairyChessCustomSet fairyChessCustomSet = gameMove as NoneRule.FairyChessCustomSet;
                                                lastKeyX = fairyChessCustomSet.x.v;
                                                lastKeyY = fairyChessCustomSet.y.v;
                                            }
                                            break;
                                        case GameMove.Type.FairyChessCustomMove:
                                            {
                                                NoneRule.FairyChessCustomMove fairyChessCustomMove = gameMove as NoneRule.FairyChessCustomMove;
                                                lastKeyX = fairyChessCustomMove.destX.v;
                                                lastKeyY = fairyChessCustomMove.destY.v;
                                            }
                                            break;
                                        case GameMove.Type.None:
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + gameMove.getType() + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameMove null: " + this);
                                }
                            }
                            // set
                            this.keyX.v = lastKeyX;
                            this.keyY.v = lastKeyY;
                        }
                        isProcess = true;
                    }
                }
                return isProcess;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.FairyChess ? 1 : 0;
        }

        #region Refresh

        public GameObject keySelect;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // keySelect
                    {
                        if (keySelect != null)
                        {
                            if (this.data.keyX.v >= 0 && this.data.keyX.v < 8
                                && this.data.keyY.v >= 0 && this.data.keyY.v < 8)
                            {
                                keySelect.SetActive(true);
                                keySelect.transform.localPosition = Common.convertXYToLocalPosition(this.data.keyX.v, this.data.keyY.v);
                            }
                            else
                            {
                                keySelect.SetActive(false);
                            }
                        }
                        else
                        {
                            Debug.LogError("keySelect null: " + this);
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
            return false;
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
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
                // Child
                {

                }
                this.setDataNull(uiData);
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
                    case UIData.Property.keyX:
                        dirty = true;
                        break;
                    case UIData.Property.keyY:
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

        #region IPointerDownHandler

        private void clickPiece(int x, int y)
        {
            if (this.data != null)
            {
                FairyChess fairyChess = null;
                // Check isActive
                bool isActive = false;
                {
                    UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                    if (useRuleInputUIData != null)
                    {
                        fairyChess = useRuleInputUIData.fairyChess.v.data;
                        if (fairyChess != null)
                        {
                            if (Game.IsPlaying(fairyChess))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("fairyChess null: " + this);
                            return;
                        }
                    }
                    else
                    {
                        Debug.LogError("useRuleInputUIData null: " + this);
                    }
                }
                if (isActive)
                {
                    if (Common.isInsideBoard(x, y))
                    {
                        Common.Square square = Common.make_square((Common.File)x, (Common.Rank)y);
                        Common.Color color = Common.color_of(fairyChess.piece_on(square));
                        if (color != Common.Color.COLOR_NB)
                        {
                            bool isCorrectPiece = false;
                            // check click correct piece
                            {
                                switch (Common.color_of(fairyChess.piece_on(square)))
                                {
                                    case Common.Color.WHITE:
                                        {
                                            if (fairyChess.getPlayerIndex() == 0)
                                            {
                                                isCorrectPiece = true;
                                            }
                                        }
                                        break;
                                    case Common.Color.BLACK:
                                        {
                                            if (fairyChess.getPlayerIndex() == 1)
                                            {
                                                isCorrectPiece = true;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown piece type: " + fairyChess.piece_on(square) + "; " + this);
                                        break;
                                }
                            }
                            if (isCorrectPiece)
                            {
                                // chuyen sang clickDest
                                ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData>();
                                if (show != null)
                                {
                                    ClickDestUI.UIData clickDest = new ClickDestUI.UIData();
                                    {
                                        clickDest.uid = show.sub.makeId();
                                        clickDest.x.v = x;
                                        clickDest.y.v = y;
                                    }
                                    show.sub.v = clickDest;
                                }
                                else
                                {
                                    Debug.LogError("show null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("click wrong piece: " + this);
                            }
                        }
                        else
                        {
                            // drop piece?
                            bool haveDropPiece = false;
                            // Check haveDropPiece
                            {
                                ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                                if (showUIData != null)
                                {
                                    for (int i = 0; i < showUIData.legalMoves.vs.Count; i++)
                                    {
                                        FairyChessMove legalMove = showUIData.legalMoves.vs[i];
                                        if (Common.type_of((Common.Move)legalMove.move.v) == Common.MoveType.DROP)
                                        {
                                            if (Common.to_sq((Common.Move)legalMove.move.v) == square)
                                            {
                                                haveDropPiece = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            // process
                            if (haveDropPiece)
                            {
                                ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                                if (showUIData != null)
                                {
                                    DropPieceUI.UIData dropPieceUIData = new DropPieceUI.UIData();
                                    {
                                        dropPieceUIData.uid = showUIData.sub.makeId();
                                        dropPieceUIData.square.v = square;
                                    }
                                    showUIData.sub.v = dropPieceUIData;
                                }
                                else
                                {
                                    Debug.LogError("showUIData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("Don't have dropPiece: " + this);
                                Toast.showMessage("Don't have drop piece");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("click outside board: " + this);
                    }
                }
                else
                {
                    Debug.LogError("not active: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onEnterKey()
        {
            if (this.data != null)
            {
                this.clickPiece(this.data.keyX.v, this.data.keyY.v);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.LogError("OnPointerDown: " + eventData);
            Vector3 localPosition = transform.InverseTransformPoint(eventData.position);
            int x = 0;
            int y = 0;
            Common.convertLocalPositionToXY(localPosition, out x, out y);
            Debug.LogError("localPosition: " + localPosition + ", " + x + ", " + y);
            this.clickPiece(x, y);
        }

        #endregion

    }
}