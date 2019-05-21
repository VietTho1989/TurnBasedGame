using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Weiqi.NoneRule
{
    public class ClickNoneUI : UIBehavior<ClickNoneUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : NoneRuleInputUI.UIData.Sub
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
                return Type.ClickNone;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    if (InputEvent.isEnter(e))
                    {
                        // enter
                        ClickNoneUI clickNoneUI = this.findCallBack<ClickNoneUI>();
                        if (clickNoneUI != null)
                        {
                            clickNoneUI.onEnterKey();
                        }
                        else
                        {
                            Debug.LogError("clickNoneUI null: " + this);
                        }
                        isProcess = true;
                    }
                    else if (InputEvent.isArrow(e))
                    {
                        // find boardSize
                        int boardSize = 19;
                        {
                            NoneRuleInputUI.UIData noneRuleInputUIData = this.findDataInParent<NoneRuleInputUI.UIData>();
                            if (noneRuleInputUIData != null)
                            {
                                Weiqi weiqi = noneRuleInputUIData.weiqi.v.data;
                                if (weiqi != null)
                                {
                                    boardSize = weiqi.b.v.size.v;
                                }
                                else
                                {
                                    Debug.LogError("weiqi null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("noneRuleInputUIData null: " + this);
                            }
                        }
                        // process
                        if (boardSize >= Weiqi.MinBoardSize)
                        {
                            if (this.keyX.v >= 1 && this.keyX.v < boardSize - 1
                                && this.keyY.v >= 1 && this.keyY.v < boardSize - 1)
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
                                if (newKeyX >= 1 && newKeyX < boardSize - 1
                                    && newKeyY >= 1 && newKeyY < boardSize - 1)
                                {
                                    this.keyX.v = newKeyX;
                                    this.keyY.v = newKeyY;
                                }
                            }
                            else
                            {
                                // bring to lastMove
                                int lastKeyX = boardSize / 2;
                                int lastKeyY = boardSize / 2;
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
                                            case GameMove.Type.WeiqiMove:
                                                {
                                                    WeiqiMove weiqiMove = gameMove as WeiqiMove;
                                                    if (weiqiMove.coord.v > 0)
                                                    {
                                                        lastKeyX = weiqiMove.coord.v % boardSize;
                                                        lastKeyY = weiqiMove.coord.v / boardSize;
                                                    }
                                                }
                                                break;
                                            case GameMove.Type.WeiqiCustomSet:
                                                {
                                                    NoneRule.WeiqiCustomSet weiqiCustomSet = gameMove as NoneRule.WeiqiCustomSet;
                                                    if (weiqiCustomSet.coord.v > 0)
                                                    {
                                                        lastKeyX = weiqiCustomSet.coord.v % boardSize;
                                                        lastKeyY = weiqiCustomSet.coord.v / boardSize;
                                                    }
                                                }
                                                break;
                                            case GameMove.Type.WeiqiCustomMove:
                                                {
                                                    NoneRule.WeiqiCustomMove weiqiCustomMove = gameMove as NoneRule.WeiqiCustomMove;
                                                    if (weiqiCustomMove.dest.v > 0)
                                                    {
                                                        lastKeyX = weiqiCustomMove.dest.v % boardSize;
                                                        lastKeyY = weiqiCustomMove.dest.v / boardSize;
                                                    }
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
                        }
                        else
                        {
                            Debug.LogError("boardSize too small: " + this);
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
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Weiqi ? 1 : 0;
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
                    // Find Weiqi
                    Weiqi weiqi = null;
                    {
                        WeiqiGameDataUI.UIData weiqiGameDataUIData = this.data.findDataInParent<WeiqiGameDataUI.UIData>();
                        if (weiqiGameDataUIData != null)
                        {
                            GameData gameData = weiqiGameDataUIData.gameData.v.data;
                            if (gameData != null)
                            {
                                if (gameData.gameType.v != null && gameData.gameType.v is Weiqi)
                                {
                                    weiqi = gameData.gameType.v as Weiqi;
                                }
                                else
                                {
                                    Debug.LogError("weiqi null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("gameData null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("weiqiGameDataUIData null: " + this);
                        }
                    }
                    // get board size
                    int boardSize = weiqi != null ? weiqi.b.v.size.v : 21;
                    {
                        if (boardSize < 5)
                        {
                            Debug.LogError("why boardSize small: " + boardSize + "; " + this);
                            boardSize = 5;
                        }
                    }
                    // keySelect
                    {
                        if (keySelect != null)
                        {
                            if (this.data.keyX.v >= 1 && this.data.keyX.v < boardSize - 1
                                && this.data.keyY.v >= 1 && this.data.keyY.v < boardSize - 1)
                            {
                                keySelect.SetActive(true);
                                keySelect.transform.localPosition = Common.convertCoordToLocalPosition(boardSize, this.data.keyX.v + boardSize * this.data.keyY.v);
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

        private void clickNone(int coord)
        {
            if (this.data != null)
            {
                Weiqi weiqi = null;
                // Check isActive
                bool isActive = false;
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                    if (noneRuleInputUIData != null)
                    {
                        weiqi = noneRuleInputUIData.weiqi.v.data;
                        if (weiqi != null)
                        {
                            if (Game.IsPlaying(weiqi))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("xiangqi null: " + this);
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
                    if (coord >= 0 && coord < Common.BOARD_MAX_COORDS)
                    {
                        NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                        if (noneRuleInputUIData != null)
                        {
                            ClickPosUI.UIData clickPieceUIData = new ClickPosUI.UIData();
                            {
                                clickPieceUIData.uid = noneRuleInputUIData.sub.makeId();
                                clickPieceUIData.coord.v = coord;
                            }
                            noneRuleInputUIData.sub.v = clickPieceUIData;
                        }
                        else
                        {
                            Debug.LogError("noneRuleInputUIData null: " + this);
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
                // get board size
                int boardSize = 19;
                {
                    // get board size
                    NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                    if (noneRuleInputUIData != null)
                    {
                        Weiqi weiqi = noneRuleInputUIData.weiqi.v.data;
                        if (weiqi != null)
                        {
                            boardSize = weiqi.b.v.size.v;
                        }
                        else
                        {
                            Debug.LogError("weiqi null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("noneRuleInputUIData null: " + this);
                    }
                    // correct board size
                    if (boardSize < 5)
                    {
                        Debug.LogError("why board size so small: " + this);
                        boardSize = 5;
                    }
                }
                // make move
                if (this.data.keyX.v >= 1 && this.data.keyX.v < boardSize - 1
                    && this.data.keyY.v >= 1 && this.data.keyY.v < boardSize - 1)
                {
                    this.clickNone(this.data.keyX.v + boardSize * this.data.keyY.v);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // Debug.LogError ("OnPointerDown: " + eventData);
            if (this.data != null)
            {
                // get boardSize
                int boardSize = 19;
                {
                    // get board size
                    NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                    if (noneRuleInputUIData != null)
                    {
                        Weiqi weiqi = noneRuleInputUIData.weiqi.v.data;
                        if (weiqi != null)
                        {
                            boardSize = weiqi.b.v.size.v;
                        }
                        else
                        {
                            Debug.LogError("weiqi null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("noneRuleInputUIData null: " + this);
                    }
                    // correct board size
                    if (boardSize < 5)
                    {
                        Debug.LogError("why board size so small: " + this);
                        boardSize = 5;
                    }
                }
                // get coord
                int coord = 0;
                {
                    Vector3 localPosition = transform.InverseTransformPoint(eventData.position);
                    int x = Mathf.RoundToInt(localPosition.x + boardSize / 2.0f - 0.5f);
                    int y = Mathf.RoundToInt(localPosition.y + boardSize / 2.0f - 0.5f);
                    coord = x + boardSize * y;
                    // Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y + "; " + move);
                }
                this.clickNone(coord);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        #endregion

    }
}