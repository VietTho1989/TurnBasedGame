using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerUI : UIBehavior<GamePlayerUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<GamePlayer>> gamePlayer;

        public VP<InformAvatarUI.UIData> avatar;

        public VP<GamePlayerTimeUI.UIData> time;

        public VP<GamePlayerStateBtnUI.UIData> btnState;

        public VP<GameState.ResultUI.UIData> result;

        #region Constructor

        public enum Property
        {
            gamePlayer,
            avatar,
            time,
            btnState,
            result
        }

        public UIData() : base()
        {
            this.gamePlayer = new VP<ReferenceData<GamePlayer>>(this, (byte)Property.gamePlayer, new ReferenceData<GamePlayer>(null));
            this.avatar = new VP<InformAvatarUI.UIData>(this, (byte)Property.avatar, new InformAvatarUI.UIData());
            this.time = new VP<GamePlayerTimeUI.UIData>(this, (byte)Property.time, new GamePlayerTimeUI.UIData());
            this.btnState = new VP<GamePlayerStateBtnUI.UIData>(this, (byte)Property.btnState, new GamePlayerStateBtnUI.UIData());
            this.result = new VP<GameState.ResultUI.UIData>(this, (byte)Property.result, new GameState.ResultUI.UIData());
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // btnState
                if (!isProcess)
                {
                    GamePlayerStateBtnUI.UIData btnState = this.btnState.v;
                    if (btnState != null)
                    {
                        isProcess = btnState.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("btnState null");
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt, rect

    static GamePlayerUI()
    {
        //rect
        {
            // avatarRect
            {
                // anchoredPosition: (4.0, -4.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 1.0);
                // offsetMin: (4.0, -34.0); offsetMax: (34.0, -4.0); sizeDelta: (30.0, 30.0);
                avatarRect.anchoredPosition = new Vector3(4.0f, -4.0f, 0.0f);
                avatarRect.anchorMin = new Vector2(0.0f, 1.0f);
                avatarRect.anchorMax = new Vector2(0.0f, 1.0f);
                avatarRect.pivot = new Vector2(0.0f, 1.0f);
                avatarRect.offsetMin = new Vector2(4.0f, -34.0f);
                avatarRect.offsetMax = new Vector2(34.0f, -4.0f);
                avatarRect.sizeDelta = new Vector2(30.0f, 30.0f);
            }
            // gamePlayerTimeUIRect
            {
                // anchoredPosition: (38.0, -20.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.0, 1.0);
                // offsetMin: (38.0, -36.0); offsetMax: (-8.0, -20.0); sizeDelta: (-46.0, 16.0);
                gamePlayerTimeUIRect.anchoredPosition = new Vector3(38.0f, -20.0f);
                gamePlayerTimeUIRect.anchorMin = new Vector2(0.0f, 1.0f);
                gamePlayerTimeUIRect.anchorMax = new Vector2(1.0f, 1.0f);
                gamePlayerTimeUIRect.pivot = new Vector2(0.0f, 1.0f);
                gamePlayerTimeUIRect.offsetMin = new Vector2(38.0f, -36.0f);
                gamePlayerTimeUIRect.offsetMax = new Vector2(-4.0f, -20.0f);
                gamePlayerTimeUIRect.sizeDelta = new Vector2(-42.0f, 16.0f);
            }
            // resultRect
            {
                // anchoredPosition: (38.0, -36.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.0, 1.0);
                // offsetMin: (38.0, -52.0); offsetMax: (-4.0, -36.0); sizeDelta: (-42.0, 16.0);
                resultRect.anchoredPosition = new Vector3(38.0f, -36.0f, 0.0f);
                resultRect.anchorMin = new Vector2(0.0f, 1.0f);
                resultRect.anchorMax = new Vector2(1.0f, 1.0f);
                resultRect.pivot = new Vector2(0.0f, 1.0f);
                resultRect.offsetMin = new Vector2(38.0f, -52.0f);
                resultRect.offsetMax = new Vector2(-4.0f, -36.0f);
                resultRect.sizeDelta = new Vector2(-42.0f, 16.0f);
            }
            // gamePlayerStateBtnRect
            {
                // anchoredPosition: (9.0, -34.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 1.0);
                // offsetMin: (9.0, -54.0); offsetMax: (29.0, -34.0); sizeDelta: (20.0, 20.0);
                gamePlayerStateBtnRect.anchoredPosition = new Vector3(9.0f, -34.0f, 0.0f);
                gamePlayerStateBtnRect.anchorMin = new Vector2(0.0f, 1.0f);
                gamePlayerStateBtnRect.anchorMax = new Vector2(0.0f, 1.0f);
                gamePlayerStateBtnRect.pivot = new Vector2(0.0f, 1.0f);
                gamePlayerStateBtnRect.offsetMin = new Vector2(9.0f, -54.0f);
                gamePlayerStateBtnRect.offsetMax = new Vector2(29.0f, -34.0f);
                gamePlayerStateBtnRect.sizeDelta = new Vector2(20.0f, 20.0f);
            }
        }
    }

    #endregion

    #region Update

    public Text tvName;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                GamePlayer gamePlayer = this.data.gamePlayer.v.data;
                if (gamePlayer != null)
                {
                    // avatar
                    {
                        InformAvatarUI.UIData avatar = this.data.avatar.v;
                        if (avatar != null)
                        {
                            avatar.inform.v = new ReferenceData<GamePlayer.Inform>(gamePlayer.inform.v);
                        }
                        else
                        {
                            Debug.LogError("avatar null: " + this);
                        }
                    }
                    // tvName
                    {
                        if (tvName != null)
                        {
                            tvName.text = gamePlayer.inform.v.getPlayerName();
                        }
                        else
                        {
                            Debug.LogError("tvName null: " + this);
                        }
                    }
                    // result
                    {
                        GameState.ResultUI.UIData resultUIData = this.data.result.v;
                        if (resultUIData != null)
                        {
                            // Find result
                            GameState.Result result = null;
                            {
                                Game game = gamePlayer.findDataInParent<Game>();
                                if (game != null)
                                {
                                    if (game.state.v is GameState.End)
                                    {
                                        GameState.End end = game.state.v as GameState.End;
                                        result = end.findResult(gamePlayer.playerIndex.v);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("game null: " + this);
                                }
                            }
                            // Set
                            resultUIData.result.v = new ReferenceData<GameState.Result>(result);
                        }
                        else
                        {
                            Debug.LogError("resultUIData null: " + this);
                        }
                    }
                    // time
                    {
                        GamePlayerTimeUI.UIData gamePlayerTimeUIData = this.data.time.v;
                        if (gamePlayerTimeUIData != null)
                        {
                            gamePlayerTimeUIData.gamePlayer.v = new ReferenceData<GamePlayer>(gamePlayer);
                        }
                    }
                    // btnState
                    {
                        GamePlayerStateBtnUI.UIData btnStateUIData = this.data.btnState.v;
                        if (btnStateUIData != null)
                        {
                            btnStateUIData.state.v = new ReferenceData<GamePlayer.State>(gamePlayer.state.v);
                        }
                        else
                        {
                            Debug.LogError("btnStateUIData null: " + this);
                        }
                    }
                    // position
                    {
                        // find
                        int playerView = 0;
                        RectTransform boardTransform = null;
                        {
                            GameDataUI.UIData gameDataUIData = this.data.findDataInParent<GameDataUI.UIData>();
                            if (gameDataUIData != null)
                            {
                                GameDataBoardUI.UIData gameDataBoardUIData = gameDataUIData.board.v;
                                if (gameDataBoardUIData != null)
                                {
                                    // playerView
                                    {
                                        Perspective perspective = gameDataBoardUIData.perspective.v;
                                        if (perspective != null)
                                        {
                                            playerView = perspective.playerView.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("perspective null");
                                        }
                                    }
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
                            float left = boardTransform.rect.xMin;
                            float right = boardTransform.rect.xMax;
                            float top = boardTransform.rect.yMin;
                            float bottom = boardTransform.rect.yMax;
                            {
                                UIRectTransform.GetMargin(boardTransform, out left, out right, out top, out bottom);
                            }
                            // Debug.LogError("boardTransform: " + left + ", " + right + ", " + top + ", " + bottom);
                            // process
                            RectTransform gamePlayerTransform = (RectTransform)this.transform;
                            if (gamePlayerTransform != null)
                            {
                                // get gamePlayer dimension
                                float gamePlayerWidth = gamePlayerTransform.rect.width;
                                float gamePlayerHeight = gamePlayerTransform.rect.height;
                                // get gamePlayerList dimension
                                float gamePlayerListWidth = 0;
                                float gamePlayerListHeight = 0;
                                {
                                    GamePlayerListUI.UIData gamePlayerListUIData = this.data.findDataInParent<GamePlayerListUI.UIData>();
                                    if (gamePlayerListUIData != null)
                                    {
                                        GamePlayerListUI gamePlayerListUI = gamePlayerListUIData.findCallBack<GamePlayerListUI>();
                                        if (gamePlayerListUI != null)
                                        {
                                            RectTransform gamePlayerListTransform = (RectTransform)gamePlayerListUI.transform;
                                            if (gamePlayerListTransform != null)
                                            {
                                                gamePlayerListWidth = gamePlayerListTransform.rect.width;
                                                gamePlayerListHeight = gamePlayerListTransform.rect.height;
                                            }
                                            else
                                            {
                                                Debug.LogError("gamePlayerListTransform null");
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("gamePlayerListUI null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gamePlayerListUIData null");
                                    }
                                }
                                // portrait view
                                if (gamePlayerListWidth <= gamePlayerListHeight)
                                {
                                    float x = -gamePlayerListWidth / 2 + gamePlayerWidth / 2 + GameDataBoardUI.Margin;
                                    switch (gamePlayer.playerIndex.v)
                                    {
                                        case 0:
                                            {
                                                if (playerView == 0)
                                                {
                                                    gamePlayerTransform.anchoredPosition = new Vector2(x, top - gamePlayerHeight / 2 - GameDataBoardUI.Margin);
                                                }
                                                else
                                                {
                                                    gamePlayerTransform.anchoredPosition = new Vector2(x, bottom + gamePlayerHeight / 2 + GameDataBoardUI.Margin);
                                                }
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (playerView != 0)
                                                {
                                                    gamePlayerTransform.anchoredPosition = new Vector2(x, top - gamePlayerHeight / 2 - GameDataBoardUI.Margin);
                                                }
                                                else
                                                {
                                                    gamePlayerTransform.anchoredPosition = new Vector2(x, bottom + gamePlayerHeight / 2 + GameDataBoardUI.Margin);
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown playerIndex: " + gamePlayer.playerIndex.v);
                                            break;
                                    }
                                }
                                // landscape view
                                else
                                {
                                    float x = left - gamePlayerWidth / 2 - GameDataBoardUI.Margin;
                                    switch (gamePlayer.playerIndex.v)
                                    {
                                        case 0:
                                            {
                                                if (playerView == 0)
                                                {
                                                    gamePlayerTransform.anchoredPosition = new Vector2(x, top + gamePlayerHeight / 2);
                                                }
                                                else
                                                {
                                                    gamePlayerTransform.anchoredPosition = new Vector2(x, bottom - gamePlayerHeight / 2);
                                                }
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (playerView != 0)
                                                {
                                                    gamePlayerTransform.anchoredPosition = new Vector2(x, top + gamePlayerHeight / 2);
                                                }
                                                else
                                                {
                                                    gamePlayerTransform.anchoredPosition = new Vector2(x, bottom - gamePlayerHeight / 2);
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown playerIndex: " + gamePlayer.playerIndex.v);
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("gamePlayerTransform null");
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
                    Debug.LogError("gamePlayer null");
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

    public InformAvatarUI avatarPrefab;
    private static readonly UIRectTransform avatarRect = new UIRectTransform();

    public GamePlayerTimeUI gamePlayerTimeUIPrefab;
    private static readonly UIRectTransform gamePlayerTimeUIRect = new UIRectTransform();

    public GamePlayerStateBtnUI gamePlayerStateBtnPrefab;
    private static readonly UIRectTransform gamePlayerStateBtnRect = new UIRectTransform();

    private GameState.CheckEndResultChange<GamePlayer> checkEndResultChange = new GameState.CheckEndResultChange<GamePlayer>();
    public GameState.ResultUI resultPrefab;
    private static readonly UIRectTransform resultRect = new UIRectTransform();

    private GameDataUI.UIData gameDataUIData = null;
    private GamePlayerListUI.UIData gamePlayerListUIData = null;

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
                DataUtils.addParentCallBack(uiData, this, ref this.gamePlayerListUIData);
            }
            // Child
            {
                uiData.gamePlayer.allAddCallBack(this);
                uiData.avatar.allAddCallBack(this);
                uiData.time.allAddCallBack(this);
                uiData.btnState.allAddCallBack(this);
                uiData.result.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Global
        if(data is Global)
        {
            dirty = true;
            return;
        }
        // Parent
        {
            // gameDataUIData
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
                    if (data is GameDataBoardUI.UIData)
                    {
                        GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
                        // Chil
                        {
                            gameDataBoardUIData.perspective.allAddCallBack(this);
                            TransformData.AddCallBack(gameDataBoardUIData, this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Perspective)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // gamePlayerListUIData
            if (data is GamePlayerListUI.UIData)
            {
                GamePlayerListUI.UIData gamePlayerListUIData = data as GamePlayerListUI.UIData;
                // Child
                {
                    TransformData.AddCallBack(gamePlayerListUIData, this);
                }
                dirty = true;
                return;
            }
            // child
            if (data is TransformData)
            {
                dirty = true;
                return;
            }
        }
        // Child
        {
            // GamePlayer
            {
                if (data is GamePlayer)
                {
                    GamePlayer gamePlayer = data as GamePlayer;
                    // CheckChange
                    {
                        checkEndResultChange.addCallBack(this);
                        checkEndResultChange.setData(gamePlayer);
                    }
                    // child
                    {
                        gamePlayer.inform.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // CheckChange
                if (data is GameState.CheckEndResultChange<GamePlayer>)
                {
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is GamePlayer.Inform)
                    {
                        GamePlayer.Inform inform = data as GamePlayer.Inform;
                        // Child
                        {
                            if (inform is Human)
                            {
                                Human human = inform as Human;
                                human.account.allAddCallBack(this);
                            }
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Account)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            if (data is InformAvatarUI.UIData)
            {
                InformAvatarUI.UIData informAvatarUIData = data as InformAvatarUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(informAvatarUIData, avatarPrefab, this.transform, avatarRect);
                }
                dirty = true;
                return;
            }
            if (data is GamePlayerTimeUI.UIData)
            {
                GamePlayerTimeUI.UIData time = data as GamePlayerTimeUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(time, gamePlayerTimeUIPrefab, this.transform, gamePlayerTimeUIRect);
                }
                dirty = true;
                return;
            }
            if (data is GamePlayerStateBtnUI.UIData)
            {
                GamePlayerStateBtnUI.UIData btnStateUIData = data as GamePlayerStateBtnUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnStateUIData, gamePlayerStateBtnPrefab, this.transform, gamePlayerStateBtnRect);
                }
                dirty = true;
                return;
            }
            if (data is GameState.ResultUI.UIData)
            {
                GameState.ResultUI.UIData resultUIData = data as GameState.ResultUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(resultUIData, resultPrefab, this.transform, resultRect);
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
            // Global
            Global.get().removeCallBack(this);
            // Parent
            {
                DataUtils.removeParentCallBack(uiData, this, ref this.gameDataUIData);
                DataUtils.removeParentCallBack(uiData, this, ref this.gamePlayerListUIData);
            }
            // Child
            {
                uiData.gamePlayer.allRemoveCallBack(this);
                uiData.avatar.allRemoveCallBack(this);
                uiData.time.allRemoveCallBack(this);
                uiData.btnState.allRemoveCallBack(this);
                uiData.result.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Global
        if(data is Global)
        {
            return;
        }
        // Parent
        {
            // gameDataUIData
            {
                if (data is GameDataUI.UIData)
                {
                    GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                    // Child
                    {
                        gameDataUIData.board.allRemoveCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is GameDataBoardUI.UIData)
                    {
                        GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
                        // Chil
                        {
                            gameDataBoardUIData.perspective.allRemoveCallBack(this);
                            TransformData.RemoveCallBack(gameDataBoardUIData, this);
                        }
                        return;
                    }
                    // Child
                    if (data is Perspective)
                    {
                        return;
                    }
                }
            }
            // gamePlayerListUIData
            if (data is GamePlayerListUI.UIData)
            {
                return;
            }
            // Child
            if (data is TransformData)
            {
                return;
            }
        }
        // Child
        {
            // GamePlayer
            {
                if (data is GamePlayer)
                {
                    GamePlayer gamePlayer = data as GamePlayer;
                    // CheckChange
                    {
                        checkEndResultChange.removeCallBack(this);
                        checkEndResultChange.setData(null);
                    }
                    // child
                    {
                        gamePlayer.inform.allRemoveCallBack(this);
                    }
                    return;
                }
                // CheckChange
                if (data is GameState.CheckEndResultChange<GamePlayer>)
                {
                    return;
                }
                // Child
                {
                    if (data is GamePlayer.Inform)
                    {
                        GamePlayer.Inform inform = data as GamePlayer.Inform;
                        // Child
                        {
                            if (inform is Human)
                            {
                                Human human = inform as Human;
                                human.account.allRemoveCallBack(this);
                            }
                        }
                        return;
                    }
                    // Child
                    if (data is Account)
                    {
                        return;
                    }
                }
            }
            if (data is InformAvatarUI.UIData)
            {
                InformAvatarUI.UIData informAvatarUIData = data as InformAvatarUI.UIData;
                // UI
                {
                    informAvatarUIData.removeCallBackAndDestroy(typeof(InformAvatarUI));
                }
                return;
            }
            if (data is GamePlayerTimeUI.UIData)
            {
                GamePlayerTimeUI.UIData time = data as GamePlayerTimeUI.UIData;
                // UI
                {
                    time.removeCallBackAndDestroy(typeof(GamePlayerTimeUI));
                }
                return;
            }
            if (data is GamePlayerStateBtnUI.UIData)
            {
                GamePlayerStateBtnUI.UIData btnStateUIData = data as GamePlayerStateBtnUI.UIData;
                // UI
                {
                    btnStateUIData.removeCallBackAndDestroy(typeof(GamePlayerStateBtnUI));
                }
                return;
            }
            if (data is GameState.ResultUI.UIData)
            {
                GameState.ResultUI.UIData resultUIData = data as GameState.ResultUI.UIData;
                // UI
                {
                    resultUIData.removeCallBackAndDestroy(typeof(GameState.ResultUI));
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
                case UIData.Property.gamePlayer:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.avatar:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.time:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnState:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.result:
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
        if(wrapProperty.p is Global)
        {
            switch ((Global.Property)wrapProperty.n)
            {
                case Global.Property.networkReachability:
                    break;
                case Global.Property.deviceOrientation:
                    dirty = true;
                    break;
                case Global.Property.screenOrientation:
                    dirty = true;
                    break;
                case Global.Property.width:
                    dirty = true;
                    break;
                case Global.Property.height:
                    dirty = true;
                    break;
                case Global.Property.screenWidth:
                    dirty = true;
                    break;
                case Global.Property.screenHeight:
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
            // gameDataUIData
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
                            case GameDataBoardUI.UIData.Property.perspective:
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
                        if (wrapProperty.p is Perspective)
                        {
                            switch ((Perspective.Property)wrapProperty.n)
                            {
                                case Perspective.Property.playerView:
                                    dirty = true;
                                    break;
                                case Perspective.Property.sub:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
            }
            // gamePlayerListUIData
            if (wrapProperty.p is GamePlayerListUI.UIData)
            {
                return;
            }
            // Child
            if (wrapProperty.p is TransformData)
            {
                dirty = true;
                return;
            }
        }
        // Child
        {
            // GamePlayer
            {
                if (wrapProperty.p is GamePlayer)
                {
                    switch ((GamePlayer.Property)wrapProperty.n)
                    {
                        case GamePlayer.Property.playerIndex:
                            dirty = true;
                            break;
                        case GamePlayer.Property.inform:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case GamePlayer.Property.state:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // CheckChange
                if (wrapProperty.p is GameState.CheckEndResultChange<GamePlayer>)
                {
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is GamePlayer.Inform)
                    {
                        if (wrapProperty.p is Human)
                        {
                            switch ((Human.Property)wrapProperty.n)
                            {
                                case Human.Property.playerId:
                                    break;
                                case Human.Property.account:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case Human.Property.state:
                                    break;
                                case Human.Property.email:
                                    break;
                                case Human.Property.phoneNumber:
                                    break;
                                case Human.Property.status:
                                    break;
                                case Human.Property.birthday:
                                    break;
                                case Human.Property.sex:
                                    break;
                                case Human.Property.connection:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is Account)
                    {
                        Account.OnUpdateSyncAccount(wrapProperty, this);
                        return;
                    }
                }
            }
            if (wrapProperty.p is InformAvatarUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is GamePlayerTimeUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is GamePlayerStateBtnUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is GameState.ResultUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}