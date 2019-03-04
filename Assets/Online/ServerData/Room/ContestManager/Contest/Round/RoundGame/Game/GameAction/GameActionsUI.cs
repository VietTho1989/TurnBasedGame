using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameActionsUI : UIBehavior<GameActionsUI.UIData>
{
    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<GameAction>> gameAction;

        #region Sub

        public abstract class Sub : Data
        {
            public abstract GameAction.Type getType();
        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            gameAction,
            sub
        }

        public UIData() : base()
        {
            this.gameAction = new VP<ReferenceData<GameAction>>(this, (byte)Property.gameAction, new ReferenceData<GameAction>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
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
                GameAction gameAction = this.data.gameAction.v.data;
                if (gameAction != null)
                {
                    // sub
                    {
                        switch (gameAction.getType())
                        {
                            case GameAction.Type.ProcessMove:
                                {
                                    ProcessMoveAction processMoveAction = gameAction as ProcessMoveAction;
                                    // UIData
                                    ProcessMoveActionUI.UIData processMoveActionUIData = this.data.sub.newOrOld<ProcessMoveActionUI.UIData>();
                                    {
                                        processMoveActionUIData.processMoveAction.v = new ReferenceData<ProcessMoveAction>(processMoveAction);
                                    }
                                    this.data.sub.v = processMoveActionUIData;
                                }
                                break;
                            case GameAction.Type.StartTurn:
                                {
                                    StartTurnAction startTurnAction = gameAction as StartTurnAction;
                                    // UIData
                                    StartTurnActionUI.UIData startTurnActionUIData = this.data.sub.newOrOld<StartTurnActionUI.UIData>();
                                    {
                                        startTurnActionUIData.startTurnAction.v = new ReferenceData<StartTurnAction>(startTurnAction);
                                    }
                                    this.data.sub.v = startTurnActionUIData;
                                }
                                break;
                            case GameAction.Type.Non:
                                {
                                    NonAction nonAction = gameAction as NonAction;
                                    // UIData
                                    NonActionUI.UIData nonActionUIData = this.data.sub.newOrOld<NonActionUI.UIData>();
                                    {
                                        nonActionUIData.nonAction.v = new ReferenceData<NonAction>(nonAction);
                                    }
                                    this.data.sub.v = nonActionUIData;
                                }
                                break;
                            case GameAction.Type.UndoRedo:
                                {
                                    UndoRedoAction undoRedoAction = gameAction as UndoRedoAction;
                                    // UIData
                                    UndoRedoActionUI.UIData undoRedoActionUIData = this.data.sub.newOrOld<UndoRedoActionUI.UIData>();
                                    {
                                        undoRedoActionUIData.undoRedoAction.v = new ReferenceData<UndoRedoAction>(undoRedoAction);
                                    }
                                    this.data.sub.v = undoRedoActionUIData;
                                }
                                break;
                            case GameAction.Type.WaitInput:
                                {
                                    WaitInputAction waitInputAction = gameAction as WaitInputAction;
                                    // UIData
                                    WaitInputActionUI.UIData waitInputActionUIData = this.data.sub.newOrOld<WaitInputActionUI.UIData>();
                                    {
                                        waitInputActionUIData.waitInputAction.v = new ReferenceData<WaitInputAction>(waitInputAction);
                                    }
                                    this.data.sub.v = waitInputActionUIData;
                                }
                                break;
                            default:
                                Debug.LogError("Unknown gameAction Type: " + gameAction.getType());
                                break;
                        }
                    }
                    // position
                    {
                        // find
                        RectTransform boardTransform = null;
                        float boardLeft = 0;
                        float boardRight = 0;
                        float boardTop = 0;
                        float boardBottom = 0;
                        {
                            GameDataUI.UIData gameDataUIData = this.data.findDataInParent<GameDataUI.UIData>();
                            if (gameDataUIData != null)
                            {
                                GameDataBoardUI.UIData gameDataBoardUIData = gameDataUIData.board.v;
                                if (gameDataBoardUIData != null)
                                {
                                    // boardTransform
                                    {
                                        GameDataBoardUI gameDataBoardUI = gameDataBoardUIData.findCallBack<GameDataBoardUI>();
                                        if (gameDataBoardUI != null)
                                        {
                                            boardTransform = (RectTransform)gameDataBoardUI.transform;
                                        }
                                        else
                                        {
                                            Debug.LogError("gameDataBoardUI null");
                                        }
                                    }
                                    // margin
                                    {
                                        boardLeft = gameDataBoardUIData.left.v;
                                        boardRight = gameDataBoardUIData.right.v;
                                        boardTop = gameDataBoardUIData.top.v;
                                        boardBottom = gameDataBoardUIData.bottom.v;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameDataBoardUIData null");
                                }
                            }
                            else
                            {
                                Debug.LogError("gameDataUIData null");
                            }
                        }
                        // process
                        if (boardTransform != null)
                        {
                            // find
                            float left = boardTransform.rect.xMin - boardLeft;
                            float right = boardTransform.rect.xMax + boardRight;
                            float top = boardTransform.rect.yMin + boardTop;
                            float bottom = boardTransform.rect.yMax - boardBottom;
                            {
                                UIRectTransform.GetMargin(boardTransform, out left, out right, out top, out bottom);
                            }
                            // process
                            RectTransform gameActionsTransform = (RectTransform)this.transform;
                            if (gameActionsTransform != null)
                            {
                                // get gameActions dimension
                                float gameActionsWidth = gameActionsTransform.rect.width;
                                float gameActionsHeight = gameActionsTransform.rect.height;
                                // get gameDataUI dimension
                                float gameDataWidth = 0;
                                float gameDataHeight = 0;
                                {
                                    GameDataUI.UIData gameDataUIData = this.data.findDataInParent<GameDataUI.UIData>();
                                    if (gameDataUIData != null)
                                    {
                                        GameDataUI gameDataUI = gameDataUIData.findCallBack<GameDataUI>();
                                        if (gameDataUI != null)
                                        {
                                            RectTransform gameDataUITransform = (RectTransform)gameDataUI.transform;
                                            if (gameDataUITransform != null)
                                            {
                                                gameDataWidth = gameDataUITransform.rect.width;
                                                gameDataHeight = gameDataUITransform.rect.height;
                                            }
                                            else
                                            {
                                                Debug.LogError("gameDataUITransform null");
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("gameDataUI null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameDataUIData null");
                                    }
                                }
                                // portrait view
                                if (gameDataWidth <= gameDataHeight)
                                {
                                    float x = gameDataWidth / 2 - gameActionsWidth / 2 - GameDataBoardUI.Margin;
                                    gameActionsTransform.anchoredPosition = new Vector2(x, bottom + gameActionsHeight / 2 + GameDataBoardUI.Margin);
                                }
                                // landscape view
                                else
                                {
                                    float x = right + gameActionsWidth / 2 + GameDataBoardUI.Margin;
                                    gameActionsTransform.anchoredPosition = new Vector2(x, bottom - gameActionsHeight / 2);
                                }
                            }
                            else
                            {
                                Debug.LogError("gameActionsTransform null");
                            }
                        }
                        else
                        {
                            Debug.LogError("boardTransform null");
                        }
                    }
                }
                else
                {
                    // Debug.LogError ("gameAction null: " + this);
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

    public ProcessMoveActionUI processMoveActionPrefab;
    public StartTurnActionUI startTurnActionPrefab;
    public NonActionUI nonActionPrefab;
    public UndoRedoActionUI undoRedoActionPrefab;
    public WaitInputActionUI waitInputActionPrefab;

    private GameDataUI.UIData gameDataUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Global
            Global.get().addCallBack(this);
            // Parent
            {
                DataUtils.addParentCallBack(uiData, this, ref this.gameDataUIData);
            }
            // Child
            {
                uiData.gameAction.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Global
        if (data is Global)
        {
            dirty = true;
            return;
        }
        // Parent
        {
            if (data is GameDataUI.UIData)
            {
                GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                // Child
                {
                    gameDataUIData.board.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if(data is GameDataBoardUI.UIData)
                {
                    GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
                    // Child
                    {
                        TransformData.AddCallBack(gameDataBoardUIData, this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is TransformData)
                {
                    dirty = true;
                    return;
                }
            }
        }
        // Child
        {
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                {
                    switch (sub.getType())
                    {
                        case GameAction.Type.ProcessMove:
                            {
                                ProcessMoveActionUI.UIData subUIData = sub as ProcessMoveActionUI.UIData;
                                UIUtils.Instantiate(subUIData, processMoveActionPrefab, this.transform);
                            }
                            break;
                        case GameAction.Type.StartTurn:
                            {
                                StartTurnActionUI.UIData subUIData = sub as StartTurnActionUI.UIData;
                                UIUtils.Instantiate(subUIData, startTurnActionPrefab, this.transform);
                            }
                            break;
                        case GameAction.Type.Non:
                            {
                                NonActionUI.UIData subUIData = sub as NonActionUI.UIData;
                                UIUtils.Instantiate(subUIData, nonActionPrefab, this.transform);
                            }
                            break;
                        case GameAction.Type.UndoRedo:
                            {
                                UndoRedoActionUI.UIData subUIData = sub as UndoRedoActionUI.UIData;
                                UIUtils.Instantiate(subUIData, undoRedoActionPrefab, this.transform);
                            }
                            break;
                        case GameAction.Type.WaitInput:
                            {
                                WaitInputActionUI.UIData subUIData = sub as WaitInputActionUI.UIData;
                                UIUtils.Instantiate(subUIData, waitInputActionPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("Unknown gameAction Type: " + sub.getType());
                            break;
                    }
                }
                return;
            }
            if (data is GameAction)
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
            // Global
            Global.get().removeCallBack(this);
            // Parent
            {
                DataUtils.removeParentCallBack(uiData, this, ref this.gameDataUIData);
            }
            // Child
            {
                uiData.gameAction.allRemoveCallBack(this);
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Global
        if (data is Global)
        {
            return;
        }
        // Parent
        {
            if (data is GameDataUI.UIData)
            {
                GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                // Child
                {
                    gameDataUIData.board.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            {
                if (data is GameDataBoardUI.UIData)
                {
                    GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(gameDataBoardUIData, this);
                    }
                    return;
                }
                // Child
                if (data is TransformData)
                {
                    return;
                }
            }
        }
        // Child
        {
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                {
                    switch (sub.getType())
                    {
                        case GameAction.Type.ProcessMove:
                            {
                                ProcessMoveActionUI.UIData subUIData = sub as ProcessMoveActionUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(ProcessMoveActionUI));
                            }
                            break;
                        case GameAction.Type.StartTurn:
                            {
                                StartTurnActionUI.UIData subUIData = sub as StartTurnActionUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(StartTurnActionUI));
                            }
                            break;
                        case GameAction.Type.Non:
                            {
                                NonActionUI.UIData subUIData = sub as NonActionUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(NonActionUI));
                            }
                            break;
                        case GameAction.Type.UndoRedo:
                            {
                                UndoRedoActionUI.UIData subUIData = sub as UndoRedoActionUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(UndoRedoActionUI));
                            }
                            break;
                        case GameAction.Type.WaitInput:
                            {
                                WaitInputActionUI.UIData subUIData = sub as WaitInputActionUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(WaitInputActionUI));
                            }
                            break;
                        default:
                            Debug.LogError("Unknown gameAction Type: " + sub.getType());
                            break;
                    }
                }
                return;
            }
            if (data is GameAction)
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
                case UIData.Property.gameAction:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.sub:
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
        // Global
        if (wrapProperty.p is Global)
        {
            Global.OnValueTransformChange(wrapProperty, this);
            return;
        }
        // Parent
        {
            if (wrapProperty.p is GameDataUI.UIData)
            {
                switch ((GameDataUI.UIData.Property)wrapProperty.n)
                {
                    case GameDataUI.UIData.Property.gameData:
                        break;
                    case GameDataUI.UIData.Property.board:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case GameDataUI.UIData.Property.allowLastMove:
                        break;
                    case GameDataUI.UIData.Property.hintUI:
                        break;
                    case GameDataUI.UIData.Property.allowInput:
                        break;
                    case GameDataUI.UIData.Property.requestChangeUseRule:
                        break;
                    case GameDataUI.UIData.Property.perspectiveUIData:
                        break;
                    case GameDataUI.UIData.Property.gamePlayerList:
                        break;
                    case GameDataUI.UIData.Property.gameActionsUI:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is GameDataBoardUI.UIData)
                {
                    switch ((GameDataBoardUI.UIData.Property)wrapProperty.n)
                    {
                        case GameDataBoardUI.UIData.Property.gameData:
                            break;
                        case GameDataBoardUI.UIData.Property.animationManager:
                            break;
                        case GameDataBoardUI.UIData.Property.sub:
                            break;
                        case GameDataBoardUI.UIData.Property.heightWidth:
                            break;
                        case GameDataBoardUI.UIData.Property.left:
                            dirty = true;
                            break;
                        case GameDataBoardUI.UIData.Property.right:
                            dirty = true;
                            break;
                        case GameDataBoardUI.UIData.Property.top:
                            dirty = true;
                            break;
                        case GameDataBoardUI.UIData.Property.bottom:
                            dirty = true;
                            break;
                        case GameDataBoardUI.UIData.Property.perspective:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is TransformData)
                {
                    dirty = true;
                    return;
                }
            }
        }
        // Child
        {
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
            if (wrapProperty.p is GameAction)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}