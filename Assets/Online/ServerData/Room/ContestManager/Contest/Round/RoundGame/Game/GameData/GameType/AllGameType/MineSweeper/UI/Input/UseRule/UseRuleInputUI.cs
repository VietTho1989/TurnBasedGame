using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace MineSweeper
{
    public class UseRuleInputUI : UIBehavior<UseRuleInputUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : InputUI.UIData.Sub
        {

            public VP<ReferenceData<MineSweeper>> mineSweeper;

            public VP<int> keyX;

            public VP<int> keyY;

            public VP<MineSweeperMove.MoveType> type;

            public VP<UseRuleInputDrTypeUI.UIData> drType;

            #region Constructor

            public enum Property
            {
                mineSweeper,
                keyX,
                keyY,
                type,
                drType
            }

            public UIData() : base()
            {
                this.mineSweeper = new VP<ReferenceData<MineSweeper>>(this, (byte)Property.mineSweeper, new ReferenceData<MineSweeper>(null));
                this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
                this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
                this.type = new VP<MineSweeperMove.MoveType>(this, (byte)Property.type, MineSweeperMove.MoveType.Normal);
                this.drType = new VP<UseRuleInputDrTypeUI.UIData>(this, (byte)Property.drType, new UseRuleInputDrTypeUI.UIData());
            }

            #endregion

            public override Type getType()
            {
                return Type.UseRule;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    if (InputEvent.isEnter(e))
                    {
                        // enter
                        UseRuleInputUI useRuleInputUI = this.findCallBack<UseRuleInputUI>();
                        if (useRuleInputUI != null)
                        {
                            useRuleInputUI.onEnterKey();
                        }
                        else
                        {
                            Debug.LogError("useRuleInputUI null: " + this);
                        }
                        isProcess = true;
                    }
                    else if (InputEvent.isArrow(e))
                    {
                        // find X, Y
                        int X = 10;
                        int Y = 10;
                        {
                            MineSweeper mineSweeper = this.mineSweeper.v.data;
                            if (mineSweeper != null)
                            {
                                X = mineSweeper.X.v;
                                Y = mineSweeper.Y.v;
                            }
                            else
                            {
                                Debug.LogError("mineSweeper null: " + this);
                            }
                        }
                        if (X >= MineSweeper.MIN_DIMENSION_SIZE && Y >= MineSweeper.MIN_DIMENSION_SIZE)
                        {
                            if (this.keyX.v >= 0 && this.keyX.v < X
                                && this.keyY.v >= 0 && this.keyY.v < Y)
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
                                if (newKeyX >= 0 && newKeyX < X
                                    && newKeyY >= 0 && newKeyY < Y)
                                {
                                    this.keyX.v = newKeyX;
                                    this.keyY.v = newKeyY;
                                }
                            }
                            else
                            {
                                // bring to lastMove
                                int lastKeyX = X / 2;
                                int lastKeyY = Y / 2;
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
                                            case GameMove.Type.MineSweeperMove:
                                                {
                                                    MineSweeperMove mineSweeperMove = gameMove as MineSweeperMove;
                                                    lastKeyX = mineSweeperMove.move.v / Y;
                                                    lastKeyY = mineSweeperMove.move.v % Y;
                                                }
                                                break;
                                            case GameMove.Type.MineSweeperCustomSet:
                                                {
                                                    NoneRule.MineSweeperCustomSet mineSweeperCustomSet = gameMove as NoneRule.MineSweeperCustomSet;
                                                    lastKeyX = mineSweeperCustomSet.square.v / Y;
                                                    lastKeyY = mineSweeperCustomSet.square.v % Y;
                                                }
                                                break;
                                            case GameMove.Type.MineSweeperCustomMove:
                                                {
                                                    NoneRule.MineSweeperCustomMove mineSweeperCustomMove = gameMove as NoneRule.MineSweeperCustomMove;
                                                    lastKeyX = mineSweeperCustomMove.dest.v / Y;
                                                    lastKeyY = mineSweeperCustomMove.dest.v % Y;
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
                            Debug.LogError("boardSize too small: " + X + ", " + Y + ", " + this);
                        }
                        isProcess = true;
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt, rect

        static UseRuleInputUI()
        {
            // rect
            {
                // drTypeRect
                {
                    // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 0.0);
                    // offsetMin: (0.0, 0.0); offsetMax: (100.0, 24.0); sizeDelta: (100.0, 24.0);
                    drTypeRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    drTypeRect.anchorMin = new Vector2(0.0f, 1.0f);
                    drTypeRect.anchorMax = new Vector2(0.0f, 1.0f);
                    drTypeRect.pivot = new Vector2(0.0f, 0.0f);
                    drTypeRect.offsetMin = new Vector2(0.0f, 4.0f);
                    drTypeRect.offsetMax = new Vector2(100.0f, 28.0f);
                    drTypeRect.sizeDelta = new Vector2(100.0f, 24.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public GameObject keySelect;

        private bool firstTime = false;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // firstTime
                    {
                        if (firstTime)
                        {
                            firstTime = false;
                            {
                                MineSweeperMove.MoveType lastType = MineSweeperMove.MoveType.Normal;
                                {
                                    // find gameMove
                                    GameMove gameMove = null;
                                    {
                                        // Find gameData
                                        GameData gameData = null;
                                        {
                                            GameDataUI.UIData gameDataUIData = this.data.findDataInParent<GameDataUI.UIData>();
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
                                            case GameMove.Type.MineSweeperMove:
                                                {
                                                    MineSweeperMove mineSweeperMove = gameMove as MineSweeperMove;
                                                    lastType = mineSweeperMove.type.v;
                                                }
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
                                this.data.type.v = lastType;
                            }
                        }
                    }
                    // keySelect
                    {
                        if (keySelect != null)
                        {
                            // find X, Y
                            int X = 10;
                            int Y = 10;
                            {
                                MineSweeper mineSweeper = this.data.mineSweeper.v.data;
                                if (mineSweeper != null)
                                {
                                    X = mineSweeper.X.v;
                                    Y = mineSweeper.Y.v;
                                }
                                else
                                {
                                    Debug.LogError("mineSweeper null: " + this);
                                }
                            }
                            if (X >= MineSweeper.MIN_DIMENSION_SIZE && Y >= MineSweeper.MIN_DIMENSION_SIZE)
                            {
                                if (this.data.keyX.v >= 0 && this.data.keyX.v < X
                                    && this.data.keyY.v >= 0 && this.data.keyY.v < Y)
                                {
                                    keySelect.SetActive(true);
                                    // find boardUIData
                                    BoardUI.UIData boardUIData = null;
                                    {
                                        MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = this.data.findDataInParent<MineSweeperGameDataUI.UIData>();
                                        if (mineSweeperGameDataUIData != null)
                                        {
                                            boardUIData = mineSweeperGameDataUIData.board.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("mineSweeperGameDataUIData null: " + this);
                                        }
                                    }
                                    // Process
                                    if (boardUIData != null)
                                    {
                                        keySelect.transform.localPosition = Common.converPosToLocalPosition(this.data.keyX.v, this.data.keyY.v, boardUIData);
                                    }
                                    else
                                    {
                                        Debug.LogError("boardUIData null: " + this);
                                    }
                                }
                                else
                                {
                                    keySelect.SetActive(false);
                                }
                            }
                            else
                            {
                                Debug.LogError("X, Y too small: " + X + ", " + Y + "; " + this);
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

        public UseRuleInputDrTypeUI drTypePrefab;
        private static readonly UIRectTransform drTypeRect = new UIRectTransform();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.mineSweeper.allAddCallBack(this);
                    uiData.drType.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is MineSweeper)
                {
                    firstTime = true;
                    dirty = true;
                    return;
                }
                if(data is UseRuleInputDrTypeUI.UIData)
                {
                    UseRuleInputDrTypeUI.UIData drTypeUIData = data as UseRuleInputDrTypeUI.UIData;
                    // UI
                    {
                        // find container
                        Transform container = null;
                        {
                            GameDataBoardUI.UIData gameDataBoardUIData = drTypeUIData.findDataInParent<GameDataBoardUI.UIData>();
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
                        UIUtils.Instantiate(drTypeUIData, drTypePrefab, container, drTypeRect);
                        UIRectTransform.SetSiblingIndex(drTypeUIData, 0);
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
                // Child
                {
                    uiData.mineSweeper.allRemoveCallBack(this);
                    uiData.drType.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                if (data is MineSweeper)
                {
                    return;
                }
                if (data is UseRuleInputDrTypeUI.UIData)
                {
                    UseRuleInputDrTypeUI.UIData drTypeUIData = data as UseRuleInputDrTypeUI.UIData;
                    // UI
                    {
                        drTypeUIData.removeCallBackAndDestroy(typeof(UseRuleInputDrTypeUI));
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
                    case UIData.Property.keyX:
                        dirty = true;
                        break;
                    case UIData.Property.keyY:
                        dirty = true;
                        break;
                    case UIData.Property.drType:
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
            {
                if (wrapProperty.p is MineSweeper)
                {
                    return;
                }
                if (wrapProperty.p is UseRuleInputDrTypeUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        private void clickMove(int move)
        {
            if (this.data != null)
            {
                MineSweeper mineSweeper = null;
                // Check isActive
                bool isActive = false;
                {
                    mineSweeper = this.data.mineSweeper.v.data;
                    if (mineSweeper != null)
                    {
                        if (Game.IsPlaying(mineSweeper))
                        {
                            isActive = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("mineSweeper null: " + this);
                        return;
                    }
                }
                if (isActive)
                {
                    if (move >= 0)
                    {
                        if (Core.unityIsLegalMove(mineSweeper, Core.CanCorrect, move))
                        {
                            // Send
                            ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                            if (clientInput != null)
                            {
                                MineSweeperMove mineSweeperMove = new MineSweeperMove();
                                {
                                    mineSweeperMove.move.v = move;
                                    mineSweeperMove.type.v = this.data.type.v;
                                }
                                clientInput.makeSend(mineSweeperMove);
                            }
                            else
                            {
                                Debug.LogError("clientInput null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("not legal move: " + move + "; " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("click outside board");
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
                int X = 10;
                int Y = 10;
                {
                    MineSweeper mineSweeper = this.data.mineSweeper.v.data;
                    if (mineSweeper != null)
                    {
                        X = mineSweeper.X.v;
                        Y = mineSweeper.Y.v;
                    }
                    else
                    {
                        Debug.LogError("mineSweeper null: " + this);
                    }
                }
                if (X >= MineSweeper.MIN_DIMENSION_SIZE && Y >= MineSweeper.MIN_DIMENSION_SIZE)
                {
                    if (this.data.keyX.v >= 0 && this.data.keyX.v < X
                       && this.data.keyY.v >= 0 && this.data.keyY.v < Y)
                    {
                        this.clickMove(this.data.keyX.v * Y + this.data.keyY.v);
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.LogError("OnPointerDown: " + eventData);
            if (this.data != null)
            {
                Vector2 localPosition = transform.InverseTransformPoint(eventData.position);
                int move = -1;
                {
                    // find boardUIData
                    BoardUI.UIData boardUIData = null;
                    {
                        MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = this.data.findDataInParent<MineSweeperGameDataUI.UIData>();
                        if (mineSweeperGameDataUIData != null)
                        {
                            boardUIData = mineSweeperGameDataUIData.board.v;
                        }
                        else
                        {
                            Debug.LogError("mineSweeperGameDataUIData null: " + this);
                        }
                    }
                    // Process
                    if (boardUIData != null)
                    {
                        move = Common.convertLocalPositionToPos(localPosition, boardUIData);
                    }
                    else
                    {
                        Debug.LogError("boardUIData null: " + this);
                    }
                }
                Debug.LogError("localPosition: " + localPosition + ", " + move);
                this.clickMove(move);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
    }

}