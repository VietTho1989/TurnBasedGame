using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Shogi.UseRule
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
                        if (this.keyX.v >= 0 && this.keyX.v < 9
                            && this.keyY.v >= 0 && this.keyY.v < 9)
                        {
                            // find new key position
                            int newKeyX = this.keyX.v;
                            int newKeyY = this.keyY.v;
                            {
                                switch (e.keyCode)
                                {
                                    case KeyCode.LeftArrow:
                                        newKeyX++;
                                        break;
                                    case KeyCode.RightArrow:
                                        newKeyX--;
                                        break;
                                    case KeyCode.UpArrow:
                                        newKeyY--;
                                        break;
                                    case KeyCode.DownArrow:
                                        newKeyY++;
                                        break;
                                    default:
                                        Debug.LogError("unknown keyCode: " + e.keyCode);
                                        break;
                                }
                            }
                            // set
                            if (newKeyX >= 0 && newKeyX < 9
                                && newKeyY >= 0 && newKeyY < 9)
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
                                        case GameMove.Type.ShogiMove:
                                            {
                                                ShogiMove shogiMove = gameMove as ShogiMove;
                                                Common.Square square = shogiMove.to();
                                                lastKeyX = (int)Common.makeFile(square);
                                                lastKeyY = (int)Common.makeRank(square);
                                            }
                                            break;
                                        case GameMove.Type.ShogiCustomSet:
                                            {
                                                NoneRule.ShogiCustomSet shogiCustomSet = gameMove as NoneRule.ShogiCustomSet;
                                                Common.Square square = shogiCustomSet.square.v;
                                                lastKeyX = (int)Common.makeFile(square);
                                                lastKeyY = (int)Common.makeRank(square);
                                            }
                                            break;
                                        case GameMove.Type.ShogiCustomMove:
                                            {
                                                NoneRule.ShogiCustomMove shogiCustomMove = gameMove as NoneRule.ShogiCustomMove;
                                                Common.Square square = shogiCustomMove.dest.v;
                                                lastKeyX = (int)Common.makeFile(square);
                                                lastKeyY = (int)Common.makeRank(square);
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
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.SHOGI ? 1 : 0;
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
                            if (this.data.keyX.v >= 0 && this.data.keyX.v < 9
                                && this.data.keyY.v >= 0 && this.data.keyY.v < 9)
                            {
                                keySelect.SetActive(true);
                                keySelect.transform.localPosition = Common.convertSquareToLocalPosition(Common.makeSquare((Common.File)this.data.keyX.v, (Common.Rank)this.data.keyY.v));
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

        private void clickPiece(int x, int y)
        {
            if (this.data != null)
            {
                Shogi shogi = null;
                // Check isActive
                bool isActive = false;
                {
                    UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                    if (useRuleInputUIData != null)
                    {
                        shogi = useRuleInputUIData.shogi.v.data;
                        if (shogi != null)
                        {
                            if (Game.IsPlaying(shogi))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("shogi null: " + this);
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
                    if (x >= 0 && x < 9 && y >= 0 && y < 9)
                    {
                        Common.Square square = Common.makeSquare((Common.File)x, (Common.Rank)y);
                        Common.Piece piece = shogi.getPiece(square);
                        if (Common.isRealPiece(piece))
                        {
                            bool isCorrectPiece = false;
                            {
                                switch (piece)
                                {
                                    case Common.Piece.BPawn:
                                    case Common.Piece.BLance:
                                    case Common.Piece.BKnight:
                                    case Common.Piece.BSilver:
                                    case Common.Piece.BBishop:
                                    case Common.Piece.BRook:
                                    case Common.Piece.BGold:
                                    case Common.Piece.BKing:
                                    case Common.Piece.BProPawn:
                                    case Common.Piece.BProLance:
                                    case Common.Piece.BProKnight:
                                    case Common.Piece.BProSilver:
                                    case Common.Piece.BHorse:
                                    case Common.Piece.BDragon:
                                        {
                                            if (shogi.getPlayerIndex() == 0)
                                            {
                                                isCorrectPiece = true;
                                            }
                                        }
                                        break;
                                    case Common.Piece.WPawn:
                                    case Common.Piece.WLance:
                                    case Common.Piece.WKnight:
                                    case Common.Piece.WSilver:
                                    case Common.Piece.WBishop:
                                    case Common.Piece.WRook:
                                    case Common.Piece.WGold:
                                    case Common.Piece.WKing:
                                    case Common.Piece.WProPawn:
                                    case Common.Piece.WProLance:
                                    case Common.Piece.WProKnight:
                                    case Common.Piece.WProSilver:
                                    case Common.Piece.WHorse:
                                    case Common.Piece.WDragon:
                                        {
                                            if (shogi.getPlayerIndex() == 1)
                                            {
                                                isCorrectPiece = true;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown piece: " + piece + "; " + this);
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
                                        clickDest.square.v = square;
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
                            bool haveDropPiece = false;
                            // Check haveDropPiece
                            {
                                ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                                if (showUIData != null)
                                {
                                    for (int i = 0; i < showUIData.legalMoves.vs.Count; i++)
                                    {
                                        ShogiMove legalMove = showUIData.legalMoves.vs[i];
                                        if (legalMove.isDrop())
                                        {
                                            if (legalMove.to() == square)
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

    }

}