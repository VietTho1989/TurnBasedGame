using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Gomoku.NoneRule
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
                                Gomoku gomoku = noneRuleInputUIData.gomoku.v.data;
                                if (gomoku != null)
                                {
                                    boardSize = gomoku.boardSize.v;
                                }
                                else
                                {
                                    Debug.LogError("gomoku null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("noneRuleInputUIData null: " + this);
                            }
                        }
                        // process
                        if (boardSize > 0)
                        {
                            if (this.keyX.v >= 0 && this.keyX.v < boardSize
                                && this.keyY.v >= 0 && this.keyY.v < boardSize)
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
                                if (newKeyX >= 0 && newKeyX < boardSize
                                    && newKeyY >= 0 && newKeyY < boardSize)
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
                                            case GameMove.Type.GomokuMove:
                                                {
                                                    GomokuMove gomokuMove = gameMove as GomokuMove;
                                                    lastKeyX = gomokuMove.move.v % boardSize;
                                                    lastKeyY = gomokuMove.move.v / boardSize;
                                                }
                                                break;
                                            case GameMove.Type.GomokuCustomSet:
                                                {
                                                    NoneRule.GomokuCustomSet gomokuCustomSet = gameMove as NoneRule.GomokuCustomSet;
                                                    lastKeyX = gomokuCustomSet.square.v % boardSize;
                                                    lastKeyY = gomokuCustomSet.square.v / boardSize;
                                                }
                                                break;
                                            case GameMove.Type.GomokuCustomMove:
                                                {
                                                    NoneRule.GomokuCustomMove gomokuCustomMove = gameMove as NoneRule.GomokuCustomMove;
                                                    lastKeyX = gomokuCustomMove.dest.v % boardSize;
                                                    lastKeyY = gomokuCustomMove.dest.v / boardSize;
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
                            Debug.LogError("boardSize < 0: " + boardSize);
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
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Gomoku ? 1 : 0;
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
                    // find boardSize
                    int boardSize = 19;
                    {
                        NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                        if (noneRuleInputUIData != null)
                        {
                            Gomoku gomoku = noneRuleInputUIData.gomoku.v.data;
                            if (gomoku != null)
                            {
                                boardSize = gomoku.boardSize.v;
                            }
                            else
                            {
                                Debug.LogError("gomoku null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("noneRuleInputUIData null: " + this);
                        }
                    }
                    // keySelect
                    {
                        if (keySelect != null)
                        {
                            if (boardSize > 0)
                            {
                                if (this.data.keyX.v >= 0 && this.data.keyX.v < boardSize
                                    && this.data.keyY.v >= 0 && this.data.keyY.v < boardSize)
                                {
                                    keySelect.SetActive(true);
                                    keySelect.transform.localPosition = Common.convertSquareToLocalPosition(boardSize, this.data.keyX.v + boardSize * this.data.keyY.v);
                                }
                                else
                                {
                                    keySelect.SetActive(false);
                                }
                            }
                            else
                            {
                                Debug.LogError("boardSize < 0: " + boardSize + "; " + this);
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

        private NoneRuleInputUI.UIData noneRuleInputUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.noneRuleInputUIData);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is NoneRuleInputUI.UIData)
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
                    // Child
                    {
                        noneRuleInputUIData.gomoku.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Gomoku)
                {
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.noneRuleInputUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is NoneRuleInputUI.UIData)
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
                    // Child
                    {
                        noneRuleInputUIData.gomoku.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Gomoku)
                {
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
            // Parent
            {
                if (wrapProperty.p is NoneRuleInputUI.UIData)
                {
                    switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n)
                    {
                        case NoneRuleInputUI.UIData.Property.gomoku:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case NoneRuleInputUI.UIData.Property.sub:
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
                // Child
                if (wrapProperty.p is Gomoku)
                {
                    switch ((Gomoku.Property)wrapProperty.n)
                    {
                        case Gomoku.Property.boardSize:
                            dirty = true;
                            break;
                        case Gomoku.Property.gs:
                            break;
                        case Gomoku.Property.player:
                            break;
                        case Gomoku.Property.winningPlayer:
                            break;
                        case Gomoku.Property.lastMove:
                            break;
                        case Gomoku.Property.winSize:
                            break;
                        case Gomoku.Property.winCoord:
                            break;
                        case Gomoku.Property.isCustom:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        #region IPointerDownHandler

        private void clickNone(int square)
        {
            if (this.data != null)
            {
                Gomoku gomoku = null;
                // Check isActive
                bool isActive = false;
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                    if (noneRuleInputUIData != null)
                    {
                        gomoku = noneRuleInputUIData.gomoku.v.data;
                        if (gomoku != null)
                        {
                            if (Game.IsPlaying(gomoku))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("gomoku null: " + this);
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
                    if (square >= 0 && square < gomoku.boardSize.v * gomoku.boardSize.v)
                    {
                        NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                        if (noneRuleInputUIData != null)
                        {
                            ClickPosUI.UIData clickPosUIData = new ClickPosUI.UIData();
                            {
                                clickPosUIData.uid = noneRuleInputUIData.sub.makeId();
                                clickPosUIData.square.v = square;
                            }
                            noneRuleInputUIData.sub.v = clickPosUIData;
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
                // find boardSize
                int boardSize = 19;
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                    if (noneRuleInputUIData != null)
                    {
                        Gomoku gomoku = noneRuleInputUIData.gomoku.v.data;
                        if (gomoku != null)
                        {
                            boardSize = gomoku.boardSize.v;
                        }
                        else
                        {
                            Debug.LogError("gomoku null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("noneRuleInputUIData null: " + this);
                    }
                }
                // Process
                if (boardSize > 0)
                {
                    if (this.data.keyX.v >= 0 && this.data.keyX.v < boardSize
                        && this.data.keyY.v >= 0 && this.data.keyY.v < boardSize)
                    {
                        this.clickNone(this.data.keyX.v + boardSize * this.data.keyY.v);
                    }
                    else
                    {
                        Debug.LogError("outSize board: " + boardSize + ", " + this.data.keyX.v + ", " + this.data.keyY.v);
                    }
                }
                else
                {
                    Debug.LogError("boardSize < 0: " + boardSize + "; " + this);
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
                NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                if (noneRuleInputUIData != null)
                {
                    Gomoku gomoku = noneRuleInputUIData.gomoku.v.data;
                    if (gomoku != null)
                    {
                        // get x, y
                        Vector3 localPosition = transform.InverseTransformPoint(eventData.position);
                        int square = Common.convertLocalPositionToSquare(gomoku, localPosition);
                        Debug.LogError("localPosition: " + localPosition + ", " + square);
                        this.clickNone(square);
                    }
                    else
                    {
                        Debug.LogError("gomoku null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("noneRuleInputUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        #endregion

    }
}