using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

using Hint;

public class GameDataUI : UIHaveTransformDataBehavior<GameDataUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<GameData>> gameData;

        public VP<GameDataBoardUI.UIData> board;

        public VP<Com.MyBool> allowLastMove;

        public VP<HintUI.UIData> hintUI;

        public VP<bool> allowInput;

        public VP<RequestChangeUseRuleUI.UIData> requestChangeUseRule;

        public VP<RequestChangeBlindFoldUI.UIData> requestChangeBlindFold;

        public VP<PerspectiveUI.UIData> perspectiveUIData;

        public VP<GamePlayerListUI.UIData> gamePlayerList;

        public VP<InformGameMessageUI.UIData> informGameMessage;

        public VP<GameActionsUI.UIData> gameActionsUI;

        #region UI

        public enum Type
        {
            Game,
            ViewSave
        }

        public VP<Type> type;

        /** bottomHeight for gameBottomUI*/
        public VP<float> bottomHeight;

        public VP<float> rightWidth;

        #endregion

        #region Constructor

        public enum Property
        {
            gameData,
            board,
            allowLastMove,
            hintUI,
            allowInput,
            requestChangeUseRule,
            requestChangeBlindFold,
            perspectiveUIData,
            gamePlayerList,
            informGameMessage,
            gameActionsUI,

            type,
            bottomHeight,
            rightWidth
        }

        public UIData() : base()
        {
            this.gameData = new VP<ReferenceData<GameData>>(this, (byte)Property.gameData, new ReferenceData<GameData>(null));
            this.board = new VP<GameDataBoardUI.UIData>(this, (byte)Property.board, new GameDataBoardUI.UIData());
            this.allowLastMove = new VP<Com.MyBool>(this, (byte)Property.allowLastMove, Com.MyBool.None);
            this.hintUI = new VP<HintUI.UIData>(this, (byte)Property.hintUI, new HintUI.UIData());
            this.allowInput = new VP<bool>(this, (byte)Property.allowInput, false);
            this.requestChangeUseRule = new VP<RequestChangeUseRuleUI.UIData>(this, (byte)Property.requestChangeUseRule, null);
            this.requestChangeBlindFold = new VP<RequestChangeBlindFoldUI.UIData>(this, (byte)Property.requestChangeBlindFold, null);
            this.perspectiveUIData = new VP<PerspectiveUI.UIData>(this, (byte)Property.perspectiveUIData, null);
            this.gamePlayerList = new VP<GamePlayerListUI.UIData>(this, (byte)Property.gamePlayerList, new GamePlayerListUI.UIData());
            this.informGameMessage = new VP<InformGameMessageUI.UIData>(this, (byte)Property.informGameMessage, new InformGameMessageUI.UIData());
            this.gameActionsUI = new VP<GameActionsUI.UIData>(this, (byte)Property.gameActionsUI, new GameActionsUI.UIData());

            this.type = new VP<Type>(this, (byte)Property.type, Type.Game);
            this.bottomHeight = new VP<float>(this, (byte)Property.bottomHeight, 60);
            this.rightWidth = new VP<float>(this, (byte)Property.rightWidth, 0);
        }

        #endregion

        public static bool IsAllowInput(Data data)
        {
            bool gameDataUIDataAllowInput = false;
            {
                if (data != null)
                {
                    GameDataUI.UIData gameDataUIData = data.findDataInParent<GameDataUI.UIData>();
                    if (gameDataUIData != null)
                    {
                        gameDataUIDataAllowInput = gameDataUIData.allowInput.v;
                    }
                    else
                    {
                        // Debug.LogError ("gameDataUIData null: " + data);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + data);
                }
            }
            return gameDataUIDataAllowInput;
        }

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // hintUI
                if (!isProcess)
                {
                    HintUI.UIData hintUI = this.hintUI.v;
                    if (hintUI != null)
                    {
                        isProcess = hintUI.processEvent(e);
                    }
                    else
                    {
                        // Debug.LogError ("hintUI null: " + this);
                    }
                }
                // requestChangeUseRule
                if (!isProcess)
                {
                    RequestChangeUseRuleUI.UIData requestChangeUseRule = this.requestChangeUseRule.v;
                    if (requestChangeUseRule != null)
                    {
                        isProcess = requestChangeUseRule.processEvent(e);
                    }
                    else
                    {
                        // Debug.LogError ("requestChangeUseRule null: " + this);
                    }
                }
                // requestChangeBlindFold
                if (!isProcess)
                {
                    RequestChangeBlindFoldUI.UIData requestChangeBlindFold = this.requestChangeBlindFold.v;
                    if (requestChangeBlindFold != null)
                    {
                        isProcess = requestChangeBlindFold.processEvent(e);
                    }
                    else
                    {
                        // Debug.LogError ("requestChangeBlindFold null: " + this);
                    }
                }
                // perspectiveUIData
                if (!isProcess)
                {
                    PerspectiveUI.UIData perspectiveUIData = this.perspectiveUIData.v;
                    if (perspectiveUIData != null)
                    {
                        isProcess = perspectiveUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("perspectiveUIData null");
                    }
                }
                // gamePlayerList
                if (!isProcess)
                {
                    GamePlayerListUI.UIData gamePlayerList = this.gamePlayerList.v;
                    if (gamePlayerList != null)
                    {
                        isProcess = gamePlayerList.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("gamePlayerList null: " + this);
                    }
                }
                // board
                if (!isProcess)
                {
                    GameDataBoardUI.UIData board = this.board.v;
                    if (board != null)
                    {
                        isProcess = board.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("board null: " + this);
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt, rect

    static GameDataUI()
    {

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
                GameData gameData = this.data.gameData.v.data;
                if (gameData != null)
                {
                    // input
                    {
                        GameDataBoardUI.UIData board = this.data.board.v;
                        if (board != null)
                        {
                            board.gameData.v = new ReferenceData<GameData>(gameData);
                        }
                        else
                        {
                            Debug.LogError("board null");
                        }
                    }
                    // HintData
                    {
                        HintUI.UIData hintUI = this.data.hintUI.v;
                        if (hintUI != null)
                        {
                            hintUI.gameData.v = new ReferenceData<GameData>(gameData);
                        }
                        else
                        {
                            Debug.LogError("hintUI null");
                        }
                    }
                    // requestChangeUseRule
                    {
                        RequestChangeUseRuleUI.UIData requestChangeUseRuleUIData = this.data.requestChangeUseRule.v;
                        if (requestChangeUseRuleUIData != null)
                        {
                            requestChangeUseRuleUIData.requestChangeUseRule.v = new ReferenceData<RequestChangeUseRule>(gameData.requestChangeUseRule.v);
                        }
                        else
                        {
                            // Debug.LogError("requestChangeUseRuleUIData null");
                        }
                    }
                    // requestChangeBlindFold
                    {
                        RequestChangeBlindFoldUI.UIData requestChangeBlindFoldUIData = this.data.requestChangeBlindFold.v;
                        if (requestChangeBlindFoldUIData != null)
                        {
                            requestChangeBlindFoldUIData.requestChangeBlindFold.v = new ReferenceData<RequestChangeBlindFold>(gameData.requestChangeBlindFold.v);
                        }
                        else
                        {
                            // Debug.LogError("requestChangeBlindFoldUIData null");
                        }
                    }
                    // perspectiveUIData
                    {
                        PerspectiveUI.UIData perspectiveUIData = this.data.perspectiveUIData.v;
                        if (perspectiveUIData != null)
                        {
                            // find
                            Perspective perspective = null;
                            {
                                GameDataBoardUI.UIData gameDataBoardUIData = this.data.board.v;
                                if (gameDataBoardUIData != null)
                                {
                                    perspective = gameDataBoardUIData.perspective.v;
                                }
                                else
                                {
                                    Debug.LogError("gameDataBoardUIData null");
                                }
                            }
                            // set
                            perspectiveUIData.perspective.v = new ReferenceData<Perspective>(perspective);
                        }
                        else
                        {
                            // Debug.LogError("perspectiveUIData null");
                        }
                    }
                    // gamePlayerList
                    {
                        GamePlayerListUI.UIData gamePlayerListUIData = this.data.gamePlayerList.v;
                        if (gamePlayerListUIData != null)
                        {
                            Game game = gameData.findDataInParent<Game>();
                            gamePlayerListUIData.game.v = new ReferenceData<Game>(game);
                        }
                        else
                        {
                            Debug.LogError("gamePlayerList null: " + this);
                        }
                    }
                    // informGameMessage
                    {
                        InformGameMessageUI.UIData informGameMessageUIData = this.data.informGameMessage.v;
                        if (informGameMessageUIData != null)
                        {
                            // find chatRoom
                            ChatRoom chatRoom = null;
                            {
                                Game game = gameData.findDataInParent<Game>();
                                if (game != null)
                                {
                                    chatRoom = game.chatRoom.v;
                                }
                                else
                                {
                                    Debug.LogError("game null");
                                }
                            }
                            // set
                            informGameMessageUIData.chatRoom.v = new ReferenceData<ChatRoom>(chatRoom);
                        }
                        else
                        {
                            Debug.LogError("informGameMessageUIData null");
                        }
                    }
                    // GameAction
                    {
                        GameActionsUI.UIData gameActionsUIData = this.data.gameActionsUI.v;
                        if (gameActionsUIData != null)
                        {
                            // find
                            GameAction gameAction = null;
                            {
                                Game game = gameData.findDataInParent<Game>();
                                if (game != null)
                                {
                                    gameAction = game.gameAction.v;
                                }
                                else
                                {
                                    Debug.LogError("game null");
                                }
                            }
                            // set
                            gameActionsUIData.gameAction.v = new ReferenceData<GameAction>(gameAction);
                        }
                        else
                        {
                            Debug.LogError("gameActionsUI null: " + this);
                        }
                    }
                    // UI
                    {
                        UIRectTransform.SetSiblingIndex(this.data.informGameMessage.v, 0);
                        UIRectTransform.SetSiblingIndex(this.data.board.v, 1);
                        UIRectTransform.SetSiblingIndex(this.data.gamePlayerList.v, 2);
                        UIRectTransform.SetSiblingIndex(this.data.gameActionsUI.v, 3);
                        UIRectTransform.SetSiblingIndex(this.data.perspectiveUIData.v, 4);
                        UIRectTransform.SetSiblingIndex(this.data.hintUI.v, 5);
                        UIRectTransform.SetSiblingIndex(this.data.requestChangeUseRule.v, 6);
                        UIRectTransform.SetSiblingIndex(this.data.requestChangeBlindFold.v, 7);
                    }
                    // UI Size
                    {
                        switch (this.data.type.v)
                        {
                            case UIData.Type.Game:
                                {
                                    this.data.bottomHeight.v = 60;
                                    this.data.rightWidth.v = 0;
                                }
                                break;
                            case UIData.Type.ViewSave:
                                {
                                    this.data.bottomHeight.v = 0;
                                    this.data.rightWidth.v = 0;
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + this.data.type.v);
                                break;
                        }
                    }
                }
                else
                {
                    // Debug.LogError("gameData null");
                }
            }
            else
            {
                // Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public GameDataBoardUI boardPrefab;

    public HintUI hintPrefab;
    private readonly UIRectTransform hintRect = UIConstants.FullParent;

    public PerspectiveUI perspectivePrefab;

    public RequestChangeUseRuleUI requestChangeUseRulePrefab;
    public RequestChangeBlindFoldUI requestChangeBlindFoldPrefab;

    public GamePlayerListUI gamePlayerListPrefab;
    public InformGameMessageUI informGameMessagePrefab;
    public GameActionsUI gameActionsPrefab;

    public GameDataBoardTransformUpdate boardTransformUpdate;

    private Game game = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.gameData.allAddCallBack(this);
                uiData.board.allAddCallBack(this);
                uiData.hintUI.allAddCallBack(this);
                uiData.requestChangeUseRule.allAddCallBack(this);
                uiData.requestChangeBlindFold.allAddCallBack(this);
                uiData.perspectiveUIData.allAddCallBack(this);
                uiData.gamePlayerList.allAddCallBack(this);
                uiData.informGameMessage.allAddCallBack(this);
                uiData.gameActionsUI.allAddCallBack(this);
            }
            // Update
            {
                UpdateUtils.makeUpdate<GameDataUIAllowInputUpdate, UIData>(uiData, this.transform);
                if (boardTransformUpdate != null)
                {
                    boardTransformUpdate.setData(uiData);
                }
                else
                {
                    Debug.LogError("boardTransformUpdate null");
                }
            }
            dirty = true;
            return;
        }
        // Child
        {
            // gameData
            {
                if (data is GameData)
                {
                    GameData gameData = data as GameData;
                    // Parent
                    {
                        DataUtils.addParentCallBack(gameData, this, ref this.game);
                    }
                    dirty = true;
                    return;
                }
                // Parent
                if (data is Game)
                {
                    dirty = true;
                    return;
                }
            }
            if (data is GameDataBoardUI.UIData)
            {
                GameDataBoardUI.UIData boardData = data as GameDataBoardUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(boardData, boardPrefab, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is HintUI.UIData)
            {
                HintUI.UIData hintData = data as HintUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(hintData, hintPrefab, this.transform, hintRect);
                }
                dirty = true;
                return;
            }
            if (data is RequestChangeUseRuleUI.UIData)
            {
                RequestChangeUseRuleUI.UIData requestChangeUseRuleUIData = data as RequestChangeUseRuleUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(requestChangeUseRuleUIData, requestChangeUseRulePrefab, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is RequestChangeBlindFoldUI.UIData)
            {
                RequestChangeBlindFoldUI.UIData requestChangeBlindFoldUIData = data as RequestChangeBlindFoldUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(requestChangeBlindFoldUIData, requestChangeBlindFoldPrefab, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is PerspectiveUI.UIData)
            {
                PerspectiveUI.UIData perspectiveUIData = data as PerspectiveUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(perspectiveUIData, perspectivePrefab, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is GamePlayerListUI.UIData)
            {
                GamePlayerListUI.UIData gamePlayerListUIData = data as GamePlayerListUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(gamePlayerListUIData, gamePlayerListPrefab, this.transform, UIConstants.FullParent);
                }
                dirty = true;
                return;
            }
            if(data is InformGameMessageUI.UIData)
            {
                InformGameMessageUI.UIData informGameMessageUIData = data as InformGameMessageUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(informGameMessageUIData, informGameMessagePrefab, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is GameActionsUI.UIData)
            {
                GameActionsUI.UIData gameActionsUIData = data as GameActionsUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(gameActionsUIData, gameActionsPrefab, this.transform);
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
                uiData.gameData.allRemoveCallBack(this);
                uiData.board.allRemoveCallBack(this);
                uiData.hintUI.allRemoveCallBack(this);
                uiData.requestChangeUseRule.allRemoveCallBack(this);
                uiData.requestChangeBlindFold.allRemoveCallBack(this);
                uiData.perspectiveUIData.allRemoveCallBack(this);
                uiData.gamePlayerList.allRemoveCallBack(this);
                uiData.informGameMessage.allRemoveCallBack(this);
                uiData.gameActionsUI.allRemoveCallBack(this);
            }
            // Update
            {
                uiData.removeCallBackAndDestroy(typeof(GameDataUIAllowInputUpdate));
                if (boardTransformUpdate != null)
                {
                    boardTransformUpdate.setDataNull(uiData);
                }
                else
                {
                    Debug.LogError("boardTransformUpdate null");
                }
            }
            this.setDataNull(uiData);
            return;
        }
        // Parent
        if (data is Game)
        {
            return;
        }
        // Child
        {
            // gameData
            {
                if (data is GameData)
                {
                    GameData gameData = data as GameData;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(gameData, this, ref this.game);
                    }
                    return;
                }
                // Parent
                if (data is Game)
                {
                    return;
                }
            }
            if (data is GameDataBoardUI.UIData)
            {
                GameDataBoardUI.UIData boardData = data as GameDataBoardUI.UIData;
                // UI
                {
                    boardData.removeCallBackAndDestroy(typeof(GameDataBoardUI));
                }
                return;
            }
            if (data is HintUI.UIData)
            {
                HintUI.UIData hintData = data as HintUI.UIData;
                // UI
                {
                    hintData.removeCallBackAndDestroy(typeof(HintUI));
                }
                return;
            }
            if (data is RequestChangeUseRuleUI.UIData)
            {
                RequestChangeUseRuleUI.UIData requestChangeUseRuleUIData = data as RequestChangeUseRuleUI.UIData;
                // UI
                {
                    requestChangeUseRuleUIData.removeCallBackAndDestroy(typeof(RequestChangeUseRuleUI));
                }
                return;
            }
            if (data is RequestChangeBlindFoldUI.UIData)
            {
                RequestChangeBlindFoldUI.UIData requestChangeBlindFoldUIData = data as RequestChangeBlindFoldUI.UIData;
                // UI
                {
                    requestChangeBlindFoldUIData.removeCallBackAndDestroy(typeof(RequestChangeBlindFoldUI));
                }
                return;
            }
            if (data is PerspectiveUI.UIData)
            {
                PerspectiveUI.UIData perspectiveUIData = data as PerspectiveUI.UIData;
                // UI
                {
                    perspectiveUIData.removeCallBackAndDestroy(typeof(PerspectiveUI));
                }
                return;
            }
            if (data is GamePlayerListUI.UIData)
            {
                GamePlayerListUI.UIData gamePlayerListUIData = data as GamePlayerListUI.UIData;
                // UI
                {
                    gamePlayerListUIData.removeCallBackAndDestroy(typeof(GamePlayerListUI));
                }
                return;
            }
            if(data is InformGameMessageUI.UIData)
            {
                InformGameMessageUI.UIData informGameMessageUIData = data as InformGameMessageUI.UIData;
                // UI
                {
                    informGameMessageUIData.removeCallBackAndDestroy(typeof(InformGameMessageUI));
                }
                return;
            }
            if (data is GameActionsUI.UIData)
            {
                GameActionsUI.UIData subUIData = data as GameActionsUI.UIData;
                // UI
                {
                    subUIData.removeCallBackAndDestroy(typeof(GameActionsUI));
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
                case UIData.Property.gameData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.board:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.allowLastMove:
                    break;
                case UIData.Property.hintUI:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.allowInput:
                    break;
                case UIData.Property.requestChangeUseRule:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.requestChangeBlindFold:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.perspectiveUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.gamePlayerList:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.informGameMessage:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.gameActionsUI:
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
            // gameData
            {
                if (wrapProperty.p is GameData)
                {
                    switch ((GameData.Property)wrapProperty.n)
                    {
                        case GameData.Property.gameType:
                            break;
                        case GameData.Property.useRule:
                            break;
                        case GameData.Property.requestChangeUseRule:
                            dirty = true;
                            break;
                        case GameData.Property.blindFold:
                            break;
                        case GameData.Property.requestChangeBlindFold:
                            dirty = true;
                            break;
                        case GameData.Property.turn:
                            dirty = true;
                            break;
                        case GameData.Property.timeControl:
                            break;
                        case GameData.Property.lastMove:
                            break;
                        case GameData.Property.state:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Parent
                if (wrapProperty.p is Game)
                {
                    switch ((Game.Property)wrapProperty.n)
                    {
                        case Game.Property.gamePlayers:
                            break;
                        case Game.Property.requestDraw:
                            break;
                        case Game.Property.state:
                            break;
                        case Game.Property.gameData:
                            break;
                        case Game.Property.history:
                            break;
                        case Game.Property.gameAction:
                            dirty = true;
                            break;
                        case Game.Property.undoRedoRequest:
                            break;
                        case Game.Property.chatRoom:
                            dirty = true;
                            break;
                        case Game.Property.animationData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
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
                        break;
                    case GameDataBoardUI.UIData.Property.right:
                        break;
                    case GameDataBoardUI.UIData.Property.top:
                        break;
                    case GameDataBoardUI.UIData.Property.bottom:
                        break;

                    case GameDataBoardUI.UIData.Property.perspective:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is HintUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is RequestChangeUseRuleUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is RequestChangeBlindFoldUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is PerspectiveUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is GamePlayerListUI.UIData)
            {
                return;
            }
            if(wrapProperty.p is InformGameMessageUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is GameActionsUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}