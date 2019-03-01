using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameState;
using Record;
using Hint;

public class GameUI : UIBehavior<GameUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Game>> game;

        #region isReplay

        public VP<bool> isReplay;

        public static bool IsReplay(Data data)
        {
            if (data != null)
            {
                GameUI.UIData gameUIData = data.findDataInParent<GameUI.UIData>();
                if (gameUIData != null)
                {
                    return gameUIData.isReplay.v;
                }
                else
                {
                    Debug.LogError("gameUIData null: " + data);
                }
            }
            else
            {
                Debug.LogError("data null: " + data);
            }
            return false;
        }

        #endregion

        public VP<GameDataUI.UIData> gameDataUI;

        public VP<GameBottomUI.UIData> gameBottom;

        public VP<StateUI.UIData> stateUI;

        public VP<GamePlayerListUI.UIData> gamePlayerList;

        #region bottomShow

        public VP<UndoRedoRequestUI.UIData> undoRedoRequestUIData;

        public VP<RequestDrawUI.UIData> requestDraw;

        public VP<GameChatRoomUI.UIData> gameChatRoom;

        public VP<GameHistoryUI.UIData> gameHistoryUIData;

        #endregion

        public VP<GameActionsUI.UIData> gameActionsUI;

        #region save

        public VP<SaveUI.UIData> saveUIData;

        #endregion

        #region Constructor

        public enum Property
        {
            game,
            isReplay,
            gameDataUI,

            gameBottom,
            undoRedoRequestUIData,
            requestDraw,
            gameChatRoom,
            gameHistoryUIData,

            stateUI,
            gamePlayerList,
            gameActionsUI,
            saveUIData
        }

        public UIData() : base()
        {
            this.game = new VP<ReferenceData<Game>>(this, (byte)Property.game, new ReferenceData<Game>(null));
            this.isReplay = new VP<bool>(this, (byte)Property.isReplay, false);
            this.gameDataUI = new VP<GameDataUI.UIData>(this, (byte)Property.gameDataUI, new GameDataUI.UIData());

            // bottom
            {
                this.gameBottom = new VP<GameBottomUI.UIData>(this, (byte)Property.gameBottom, new GameBottomUI.UIData());
                this.undoRedoRequestUIData = new VP<UndoRedoRequestUI.UIData>(this, (byte)Property.undoRedoRequestUIData, null);
                this.requestDraw = new VP<RequestDrawUI.UIData>(this, (byte)Property.requestDraw, null);
                this.gameChatRoom = new VP<GameChatRoomUI.UIData>(this, (byte)Property.gameChatRoom, null);
                this.gameHistoryUIData = new VP<GameHistoryUI.UIData>(this, (byte)Property.gameHistoryUIData, null);
            }

            this.stateUI = new VP<StateUI.UIData>(this, (byte)Property.stateUI, new StateUI.UIData());
            this.gamePlayerList = new VP<GamePlayerListUI.UIData>(this, (byte)Property.gamePlayerList, new GamePlayerListUI.UIData());
            this.gameActionsUI = new VP<GameActionsUI.UIData>(this, (byte)Property.gameActionsUI, new GameActionsUI.UIData());
            this.saveUIData = new VP<SaveUI.UIData>(this, (byte)Property.saveUIData, null);
        }

        #endregion

        public void reset()
        {
            this.saveUIData.v = null;
        }

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // requestDraw
                if (!isProcess)
                {
                    RequestDrawUI.UIData requestDraw = this.requestDraw.v;
                    if (requestDraw != null)
                    {
                        isProcess = requestDraw.processEvent(e);
                    }
                    else
                    {
                        // Debug.LogError("requestDraw null");
                    }
                }
                // undoRedoRequest
                if (!isProcess)
                {
                    UndoRedoRequestUI.UIData undoRedoRequestUIData = this.undoRedoRequestUIData.v;
                    if (undoRedoRequestUIData != null)
                    {
                        isProcess = undoRedoRequestUIData.processEvent(e);
                    }
                    else
                    {
                        // Debug.LogError("undoRedoRequestUIData null");
                    }
                }
                // gameChatRoom
                if (!isProcess)
                {
                    GameChatRoomUI.UIData gameChatRoom = this.gameChatRoom.v;
                    if (gameChatRoom != null)
                    {
                        isProcess = gameChatRoom.processEvent(e);
                    }
                    else
                    {
                        // Debug.LogError("gameChatRoom null");
                    }
                }
                // gameHistoryUIData
                if (!isProcess)
                {
                    GameHistoryUI.UIData gameHistoryUIData = this.gameHistoryUIData.v;
                    if (gameHistoryUIData != null)
                    {
                        isProcess = gameHistoryUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("gameHistoryUIData: " + this);
                    }
                }
                // saveUIData
                if (!isProcess)
                {
                    SaveUI.UIData saveUIData = this.saveUIData.v;
                    if (saveUIData != null)
                    {
                        isProcess = saveUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("saveUIData null: " + this);
                    }
                }
                // bottom
                if (!isProcess)
                {
                    GameBottomUI.UIData gameBottom = this.gameBottom.v;
                    if (gameBottom != null)
                    {
                        isProcess = gameBottom.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("gameBottom null");
                    }
                }
                // gamePlayerListUI
                if (!isProcess)
                {
                    GamePlayerListUI.UIData gamePlayerList = this.gamePlayerList.v;
                    if (gamePlayerList != null)
                    {
                        isProcess = gamePlayerList.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("gamePlayerList null");
                    }
                }
                // gameUIData
                if (!isProcess)
                {
                    GameDataUI.UIData gameUIData = this.gameDataUI.v;
                    if (gameUIData != null)
                    {
                        isProcess = gameUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("gameUIData null: " + this);
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region Update

    #region txt, rect

    static GameUI()
    {
        // rect
        {
            // gameBottomRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (0.5, 0.0); anchorMax: (0.5, 0.0); pivot: (0.5, 0.0);
                // offsetMin: (-240.0, 0.0); offsetMax: (240.0, 60.0); sizeDelta: (480.0, 60.0);
                gameBottomRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                gameBottomRect.anchorMin = new Vector2(0.5f, 0.0f);
                gameBottomRect.anchorMax = new Vector2(0.5f, 0.0f);
                gameBottomRect.pivot = new Vector2(0.5f, 0.0f);
                gameBottomRect.offsetMin = new Vector2(-240.0f, 0.0f);
                gameBottomRect.offsetMax = new Vector2(240.0f, 60.0f);
                gameBottomRect.sizeDelta = new Vector2(480.0f, 60.0f);
            }
        }
    }

    #endregion

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Game game = this.data.game.v.data;
                if (game != null)
                {
                    // gameUIData
                    {
                        if (this.data.gameDataUI.v != null)
                        {
                            this.data.gameDataUI.v.gameData.v = new ReferenceData<GameData>(game.gameData.v);
                        }
                    }

                    // gameBottom
                    {
                        GameBottomUI.UIData gameBottomUIData = this.data.gameBottom.v;
                        if (gameBottomUIData != null)
                        {
                            gameBottomUIData.game.v = new ReferenceData<Game>(game);
                        }
                        else
                        {
                            Debug.LogError("gameBottomUIData null");
                        }
                    }
                    // requestDraw
                    {
                        RequestDrawUI.UIData requestDrawUIData = this.data.requestDraw.v;
                        if (requestDrawUIData != null)
                        {
                            requestDrawUIData.requestDraw.v = new ReferenceData<RequestDraw>(game.requestDraw.v);
                        }
                        else
                        {
                            Debug.LogError("requestDrawUIData null: " + this);
                        }
                    }
                    // UndoRedoRequest
                    {
                        UndoRedoRequestUI.UIData undoRedoRequestUIData = this.data.undoRedoRequestUIData.v;
                        if (undoRedoRequestUIData != null)
                        {
                            undoRedoRequestUIData.undoRedoRequest.v = new ReferenceData<UndoRedoRequest>(game.undoRedoRequest.v);
                        }
                    }

                    // stateUI
                    {
                        StateUI.UIData stateUIData = this.data.stateUI.v;
                        if (stateUIData != null)
                        {
                            stateUIData.state.v = new ReferenceData<State>(game.state.v);
                        }
                        else
                        {
                            Debug.LogError("stateUIData null: " + this);
                        }
                    }
                    // gamePlayerList
                    {
                        if (this.data.gamePlayerList.v != null)
                        {
                            this.data.gamePlayerList.v.game.v = new ReferenceData<Game>(game);
                        }
                        else
                        {
                            Debug.LogError("gamePlayerList null: " + this);
                        }
                    }
                    // GameAction
                    {
                        if (this.data.gameActionsUI.v != null)
                        {
                            this.data.gameActionsUI.v.gameAction.v = new ReferenceData<GameAction>(game.gameAction.v);
                        }
                        else
                        {
                            Debug.LogError("gameActionsUI null: " + this);
                        }
                    }
                    // gameChatRoom
                    {
                        GameChatRoomUI.UIData gameChatRoomUIData = this.data.gameChatRoom.v;
                        if (gameChatRoomUIData != null)
                        {
                            gameChatRoomUIData.chatRoom.v = new ReferenceData<ChatRoom>(game.chatRoom.v);
                        }
                        else
                        {
                            Debug.LogError("gameChatRoomUIData null: " + this);
                        }
                    }
                    // saveUIData
                    {
                        SaveUI.UIData saveUIData = this.data.saveUIData.v;
                        if (saveUIData != null)
                        {
                            saveUIData.needSaveData.v = new ReferenceData<Data>(game);
                        }
                        else
                        {
                            // Debug.LogError ("saveUIData null: " + this);
                        }
                    }
                    // gameHistoryUIData
                    {
                        GameHistoryUI.UIData gameHistoryUIData = this.data.gameHistoryUIData.v;
                        if (gameHistoryUIData != null)
                        {
                            gameHistoryUIData.history.v = new ReferenceData<History>(game.history.v);
                        }
                        else
                        {
                            Debug.LogError("gameHistoryUIData null: " + this);
                        }
                    }
                    // UI sibling index
                    {
                        UIRectTransform.SetSiblingIndex(this.data.gameBottom.v, 0);
                        UIRectTransform.SetSiblingIndex(this.data.gameDataUI.v, 1);
                        UIRectTransform.SetSiblingIndex(this.data.gamePlayerList.v, 2);
                        UIRectTransform.SetSiblingIndex(this.data.stateUI.v, 3);
                        UIRectTransform.SetSiblingIndex(this.data.gameActionsUI.v, 4);
                        UIRectTransform.SetSiblingIndex(this.data.gameChatRoom.v, 5);
                        UIRectTransform.SetSiblingIndex(this.data.undoRedoRequestUIData.v, 6);
                        UIRectTransform.SetSiblingIndex(this.data.requestDraw.v, 7);
                        UIRectTransform.SetSiblingIndex(this.data.gameHistoryUIData.v, 8);
                        UIRectTransform.SetSiblingIndex(this.data.saveUIData.v, 9);
                        if (dataRecordSaveContainer != null)
                        {
                            dataRecordSaveContainer.SetSiblingIndex(10);
                        }
                        else
                        {
                            Debug.LogError("dataRecordSaveContainer null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("game null: " + this);
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

    public GameDataUI gameDataUIPrefab;
    private static readonly UIRectTransform gameDataUIRect = UIRectTransform.CreateFullRect(0, 0, 0, 0);

    #region bottom

    public GameBottomUI gameBottomPrefab;
    private static readonly UIRectTransform gameBottomRect = new UIRectTransform();

    public UndoRedoRequestUI undoRedoRequestPrefab;
    public RequestDrawUI requestDrawPrefab;
    public GameChatRoomUI gameChatRoomPrefab;

    public GameHistoryUI gameHistoryUIPrefab;

    #endregion

    public StateUI stateUIPrefab;
    private static readonly UIRectTransform stateUIRect = UIConstants.FullParent;

    public GamePlayerListUI gamePlayerListPrefab;

    public GameActionsUI gameActionsPrefab;
    private static readonly UIRectTransform gameActionsRect = UIConstants.FullParent;

    public SaveUI saveUIPrefab;
    private static readonly UIRectTransform saveUIRect = UIRectTransform.CreateCenterRect(360.0f, 400.0f);

    public Transform dataRecordSaveContainer;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.game.allAddCallBack(this);
                uiData.stateUI.allAddCallBack(this);
                uiData.gameDataUI.allAddCallBack(this);
                // bottom
                {
                    uiData.gameBottom.allAddCallBack(this);
                    uiData.undoRedoRequestUIData.allAddCallBack(this);
                    uiData.requestDraw.allAddCallBack(this);
                    uiData.gameChatRoom.allAddCallBack(this);
                }
                uiData.gamePlayerList.allAddCallBack(this);
                uiData.gameActionsUI.allAddCallBack(this);
                uiData.saveUIData.allAddCallBack(this);
                uiData.gameHistoryUIData.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is Game)
            {
                // reset
                {
                    if (this.data != null)
                    {
                        this.data.reset();
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                dirty = true;
                return;
            }
            if (data is GameDataUI.UIData)
            {
                GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(gameDataUIData, gameDataUIPrefab, this.transform, gameDataUIRect);
                }
                dirty = true;
                return;
            }
            // bottom
            {
                if (data is GameBottomUI.UIData)
                {
                    GameBottomUI.UIData gameBottomUIData = data as GameBottomUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(gameBottomUIData, gameBottomPrefab, this.transform, gameBottomRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is UndoRedoRequestUI.UIData)
                {
                    UndoRedoRequestUI.UIData undoRedoRequestUIData = data as UndoRedoRequestUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(undoRedoRequestUIData, undoRedoRequestPrefab, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if (data is RequestDrawUI.UIData)
                {
                    RequestDrawUI.UIData requestDrawUIData = data as RequestDrawUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(requestDrawUIData, requestDrawPrefab, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if (data is GameChatRoomUI.UIData)
                {
                    GameChatRoomUI.UIData gameChatRoomUIData = data as GameChatRoomUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(gameChatRoomUIData, gameChatRoomPrefab, this.transform);
                    }
                    dirty = true;
                    return;
                }
            }
            if (data is GameActionsUI.UIData)
            {
                GameActionsUI.UIData gameActionsUIData = data as GameActionsUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(gameActionsUIData, gameActionsPrefab, this.transform, gameActionsRect);
                }
                dirty = true;
                return;
            }
            if (data is StateUI.UIData)
            {
                StateUI.UIData stateUIData = data as StateUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(stateUIData, stateUIPrefab, this.transform, stateUIRect);
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
            if (data is SaveUI.UIData)
            {
                SaveUI.UIData saveUIData = data as SaveUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(saveUIData, saveUIPrefab, this.transform, saveUIRect);
                }
                dirty = true;
                return;
            }
            if (data is GameHistoryUI.UIData)
            {
                GameHistoryUI.UIData gameHistoryUIData = data as GameHistoryUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(gameHistoryUIData, gameHistoryUIPrefab, this.transform);
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
                uiData.game.allRemoveCallBack(this);
                uiData.gameDataUI.allRemoveCallBack(this);
                // bottom
                {
                    uiData.gameBottom.allRemoveCallBack(this);
                    uiData.undoRedoRequestUIData.allRemoveCallBack(this);
                    uiData.requestDraw.allRemoveCallBack(this);
                    uiData.gameChatRoom.allRemoveCallBack(this);
                }
                uiData.stateUI.allRemoveCallBack(this);
                uiData.gamePlayerList.allRemoveCallBack(this);
                uiData.gameActionsUI.allRemoveCallBack(this);
                uiData.saveUIData.allRemoveCallBack(this);
                uiData.gameHistoryUIData.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is Game)
            {
                return;
            }
            if (data is GameDataUI.UIData)
            {
                GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                // UI
                {
                    gameDataUIData.removeCallBackAndDestroy(typeof(GameDataUI));
                }
                return;
            }
            // bottom
            {
                if (data is GameBottomUI.UIData)
                {
                    GameBottomUI.UIData gameBottomUIData = data as GameBottomUI.UIData;
                    // UI
                    {
                        gameBottomUIData.removeCallBackAndDestroy(typeof(GameBottomUI));
                    }
                    return;
                }
                if (data is UndoRedoRequestUI.UIData)
                {
                    UndoRedoRequestUI.UIData subUIData = data as UndoRedoRequestUI.UIData;
                    // UI
                    {
                        subUIData.removeCallBackAndDestroy(typeof(UndoRedoRequestUI));
                    }
                    return;
                }
                if (data is RequestDrawUI.UIData)
                {
                    RequestDrawUI.UIData requestDrawUIData = data as RequestDrawUI.UIData;
                    // UI
                    {
                        requestDrawUIData.removeCallBackAndDestroy(typeof(RequestDrawUI));
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
                if (data is GameChatRoomUI.UIData)
                {
                    GameChatRoomUI.UIData gameChatRoomUIData = data as GameChatRoomUI.UIData;
                    // UI
                    {
                        gameChatRoomUIData.removeCallBackAndDestroy(typeof(GameChatRoomUI));
                    }
                    return;
                }
            }
            if (data is StateUI.UIData)
            {
                StateUI.UIData stateUIData = data as StateUI.UIData;
                // UI
                {
                    stateUIData.removeCallBackAndDestroy(typeof(StateUI));
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
            if (data is GameActionsUI.UIData)
            {
                GameActionsUI.UIData subUIData = data as GameActionsUI.UIData;
                // UI
                {
                    subUIData.removeCallBackAndDestroy(typeof(GameActionsUI));
                }
                return;
            }
            if (data is SaveUI.UIData)
            {
                SaveUI.UIData saveUIData = data as SaveUI.UIData;
                // UI
                {
                    saveUIData.removeCallBackAndDestroy(typeof(SaveUI));
                }
                return;
            }
            if (data is GameHistoryUI.UIData)
            {
                GameHistoryUI.UIData gameHistoryUIData = data as GameHistoryUI.UIData;
                // UI
                {
                    gameHistoryUIData.removeCallBackAndDestroy(typeof(GameHistoryUI));
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
                case UIData.Property.game:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.gameDataUI:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;

                // bottom
                case UIData.Property.gameBottom:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.undoRedoRequestUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.requestDraw:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.gameChatRoom:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;

                case UIData.Property.stateUI:
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
                case UIData.Property.gameActionsUI:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.saveUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.gameHistoryUIData:
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
            if (wrapProperty.p is Game)
            {
                switch ((Game.Property)wrapProperty.n)
                {
                    case Game.Property.gamePlayers:
                        break;
                    case Game.Property.requestDraw:
                        dirty = true;
                        break;
                    case Game.Property.state:
                        dirty = true;
                        break;
                    case Game.Property.gameData:
                        dirty = true;
                        break;
                    case Game.Property.history:
                        dirty = true;
                        break;
                    case Game.Property.gameAction:
                        dirty = true;
                        break;
                    case Game.Property.undoRedoRequest:
                        dirty = true;
                        break;
                    case Game.Property.chatRoom:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is GameDataUI.UIData)
            {
                return;
            }
            // bottom
            {
                if (wrapProperty.p is GameBottomUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is UndoRedoRequestUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RequestDrawUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is GameChatRoomUI.UIData)
                {
                    return;
                }
            }
            if (wrapProperty.p is StateUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is GamePlayerListUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is GameActionsUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is SaveUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is GameHistoryUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}