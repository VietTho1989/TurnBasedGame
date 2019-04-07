using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Posture
{
    public class EditPostureGameDataUI : UIBehavior<EditPostureGameDataUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<PostureGameDataFactory>> postureGameDataFactory;

            public VP<GameUI.UIData> gameUIData;

            public VP<BtnSetEditPostureGameData.UIData> btnSet;

            #region choosePosture

            public VP<ChoosePostureUI.UIData> choosePostureUIData;

            public VP<LoadPostureUI.UIData> loadPostureUIData;

            #endregion

            #region Constructor

            public enum Property
            {
                postureGameDataFactory,
                gameUIData,
                btnSet,
                choosePostureUIData,
                loadPostureUIData
            }

            public UIData() : base()
            {
                this.postureGameDataFactory = new VP<ReferenceData<PostureGameDataFactory>>(this, (byte)Property.postureGameDataFactory, new ReferenceData<PostureGameDataFactory>(null));
                {
                    this.gameUIData = new VP<GameUI.UIData>(this, (byte)Property.gameUIData, new GameUI.UIData());
                    this.gameUIData.v.saveUIData.v = null;
                    this.gameUIData.v.requestDraw.v = null;
                    this.gameUIData.v.gameHistoryUIData.v = null;
                    // gameDataUIData
                    {
                        GameDataUI.UIData gameDataUIData = this.gameUIData.v.gameDataUI.v;
                        if (gameDataUIData != null)
                        {
                            gameDataUIData.gamePlayerList.v = null;
                            gameDataUIData.gameActionsUI.v = null;
                            gameDataUIData.informGameMessage.v = null;
                        }
                        else
                        {
                            Debug.LogError("gameDataUIData null");
                        }
                    }
                }
                this.btnSet = new VP<BtnSetEditPostureGameData.UIData>(this, (byte)Property.btnSet, new BtnSetEditPostureGameData.UIData());
                this.choosePostureUIData = new VP<ChoosePostureUI.UIData>(this, (byte)Property.choosePostureUIData, null);
                this.loadPostureUIData = new VP<LoadPostureUI.UIData>(this, (byte)Property.loadPostureUIData, null);
            }

            #endregion

            public bool processEvent(Event e)
            {
                Debug.LogError("processEvent: " + e + "; " + this);
                bool isProcess = false;
                {
                    // loadPostureUIData
                    if (!isProcess)
                    {
                        LoadPostureUI.UIData loadPostureUIData = this.loadPostureUIData.v;
                        if (loadPostureUIData != null)
                        {
                            isProcess = loadPostureUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("loadPostureUIData null: " + this);
                        }
                    }
                    // choosePostureUIData
                    if (!isProcess)
                    {
                        ChoosePostureUI.UIData choosePostureUIData = this.choosePostureUIData.v;
                        if (choosePostureUIData != null)
                        {
                            isProcess = choosePostureUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("choosePostureUIData null: " + this);
                        }
                    }
                    // gameUIData
                    if (!isProcess)
                    {
                        GameUI.UIData gameUIData = this.gameUIData.v;
                        if (gameUIData != null)
                        {
                            isProcess = gameUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("gameUIData null: " + this);
                        }
                    }
                    // back
                    if (!isProcess)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            EditPostureGameDataUI editPostureGameDataUI = this.findCallBack<EditPostureGameDataUI>();
                            if (editPostureGameDataUI != null)
                            {
                                editPostureGameDataUI.onClickBtnBack();
                            }
                            else
                            {
                                Debug.LogError("editPostureGameDataUI null: " + this);
                            }
                            isProcess = true;
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region Refresh

        public void makeNewGame(GameData needSetGameData)
        {
            if (needSetGameData != null)
            {
                if (this.data != null)
                {
                    GameUI.UIData gameUIData = this.data.gameUIData.v;
                    if (gameUIData != null)
                    {
                        Game game = new Game();
                        {
                            // gamePlayers
                            // requestDraw
                            // state
                            {
                                GameState.Play play = game.state.newOrOld<GameState.Play>();
                                {

                                }
                                game.state.v = play;
                            }
                            // gameData
                            {
                                GameData newGameData = DataUtils.cloneData(needSetGameData) as GameData;
                                {
                                    newGameData.uid = game.gameData.makeId();
                                    // gameType,
                                    newGameData.useRule.v = false;
                                    // turn
                                    // timeControl
                                    {
                                        newGameData.timeControl.v.isEnable.v = false;
                                    }
                                    // lastMove
                                    // state
                                }
                                game.gameData.v = newGameData;
                            }
                            // history
                            // gameAction
                            // undoRedoRequest
                            // chatRoom
                            // animationData
                        }
                        gameUIData.game.v = new ReferenceData<Game>(game);
                    }
                    else
                    {
                        Debug.LogError("gameUIData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
            else
            {
                Debug.LogError("gameData null: " + this);
            }
        }

        public void makeNewGame(Game newGame)
        {
            if (newGame != null)
            {
                if (this.data != null)
                {
                    GameUI.UIData gameUIData = this.data.gameUIData.v;
                    if (gameUIData != null)
                    {
                        {
                            // gamePlayers
                            // requestDraw
                            // state
                            {
                                GameState.Play play = newGame.state.newOrOld<GameState.Play>();
                                {

                                }
                                newGame.state.v = play;
                            }
                            // gameData
                            {
                                GameData newGameData = newGame.gameData.v;
                                {
                                    newGameData.useRule.v = false;
                                    newGameData.timeControl.v.isEnable.v = false;
                                }
                            }
                            // history
                            // gameAction
                            // undoRedoRequest
                            // chatRoom
                            // animationData
                        }
                        gameUIData.game.v = new ReferenceData<Game>(newGame);
                    }
                    else
                    {
                        Debug.LogError("gameUIData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
            else
            {
                Debug.LogError("gameData null: " + this);
            }
        }

        #region txt, rect

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Edit Posture Game Data");

        public Text tvPosture;
        private static readonly TxtLanguage txtPosture = new TxtLanguage("Posture");

        public Text tvLoad;
        private static readonly TxtLanguage txtLoad = new TxtLanguage("Load");

        static EditPostureGameDataUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Chỉnh Sửa Dữ Liệu Cờ Thế");
                txtPosture.add(Language.Type.vi, "Thế Cờ");
                txtLoad.add(Language.Type.vi, "Tải");
            }
            // rect
            {
                // btnSetRect
                {
                    // anchoredPosition: (0.0, 0.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                    // offsetMin: (-120.0, -30.0); offsetMax: (0.0, 0.0); sizeDelta: (120.0, 30.0);
                    btnSetRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    btnSetRect.anchorMin = new Vector2(1.0f, 1.0f);
                    btnSetRect.anchorMax = new Vector2(1.0f, 1.0f);
                    btnSetRect.pivot = new Vector2(1.0f, 1.0f);
                    btnSetRect.offsetMin = new Vector2(-120.0f, -30.0f);
                    btnSetRect.offsetMax = new Vector2(0.0f, 0.0f);
                    btnSetRect.sizeDelta = new Vector2(120.0f, 30.0f);
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
                    PostureGameDataFactory postureGameDataFactory = this.data.postureGameDataFactory.v.data;
                    if (postureGameDataFactory != null)
                    {
                        // gameUIData
                        {
                            GameUI.UIData gameUIData = this.data.gameUIData.v;
                            if (gameUIData != null)
                            {
                                GameData gameData = postureGameDataFactory.gameData.v;
                                if (gameData != null)
                                {
                                    // find need make new game
                                    bool needMakeNewGame = true;
                                    {
                                        Game game = gameUIData.game.v.data;
                                        if (game != null)
                                        {
                                            if (game.gameData.v.gameType.v.getType() == gameData.gameType.v.getType())
                                            {
                                                needMakeNewGame = false;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("game null: " + this);
                                        }
                                    }
                                    // Process
                                    if (needMakeNewGame)
                                    {
                                        this.makeNewGame(gameData);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("gameUIData null: " + this);
                            }
                        }
                        // find gameType
                        GameType.Type gameTypeType = GameType.Type.CHESS;
                        {
                            GameUI.UIData gameUIData = this.data.gameUIData.v;
                            if (gameUIData != null)
                            {
                                Game game = gameUIData.game.v.data;
                                if (game != null)
                                {
                                    GameData gameData = game.gameData.v;
                                    if (gameData != null)
                                    {
                                        GameType gameType = gameData.gameType.v;
                                        if (gameType != null)
                                        {
                                            gameTypeType = gameType.getType();
                                        }
                                        else
                                        {
                                            Debug.LogError("gameType null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameUIData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("gameUIData null: " + this);
                            }
                        }
                        // choosePostureUIData
                        {
                            ChoosePostureUI.UIData choosePostureUIData = this.data.choosePostureUIData.v;
                            if (choosePostureUIData != null)
                            {
                                choosePostureUIData.gameType.v = gameTypeType;
                            }
                            else
                            {
                                Debug.LogError("choosePostureUIData null: " + this);
                            }
                        }
                        // loadPostureUIData
                        {
                            LoadPostureUI.UIData loadPostureUIData = this.data.loadPostureUIData.v;
                            if (loadPostureUIData != null)
                            {
                                loadPostureUIData.gameType.v = gameTypeType;
                            }
                            else
                            {
                                Debug.LogError("loadPostureUIData null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("postureGameDataFactory null: " + this);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (tvPosture != null)
                        {
                            tvPosture.text = txtPosture.get();
                        }
                        else
                        {
                            Debug.LogError("tvPosture null: " + this);
                        }
                        if (tvLoad != null)
                        {
                            tvLoad.text = txtLoad.get();
                        }
                        else
                        {
                            Debug.LogError("tvLoad null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public GameUI gameUIPrefab;
        private static readonly UIRectTransform gameUIRect = UIRectTransform.CreateFullRect(0, 0, 60, 0);

        public BtnSetEditPostureGameData btnSetPrefab;
        private static readonly UIRectTransform btnSetRect = new UIRectTransform();

        public ChoosePostureUI choosePosturePrefab;
        private static readonly UIRectTransform choosePostureRect = UIRectTransform.CreateCenterRect(400.0f, 400.0f);// UIConstants.FullParent;

        public LoadPostureUI loadPosturePrefab;
        private static readonly UIRectTransform loadPostureRect = UIRectTransform.CreateCenterRect(400.0f, 400.0f);// UIConstants.FullParent;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.postureGameDataFactory.allAddCallBack(this);
                    uiData.gameUIData.allAddCallBack(this);
                    uiData.btnSet.allAddCallBack(this);
                    uiData.choosePostureUIData.allAddCallBack(this);
                    uiData.loadPostureUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // postureGameDataFactory
                {
                    if (data is PostureGameDataFactory)
                    {
                        PostureGameDataFactory postureGameDataFactory = data as PostureGameDataFactory;
                        // Child
                        {
                            postureGameDataFactory.gameData.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                }
                // GameUIData
                {
                    if (data is GameUI.UIData)
                    {
                        GameUI.UIData gameUIData = data as GameUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(gameUIData, gameUIPrefab, this.transform, gameUIRect);
                        }
                        // Child
                        {
                            gameUIData.game.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Game)
                    {
                        Game game = data as Game;
                        // Update
                        {
                            UpdateUtils.makeUpdate<GameUpdate, Game>(game, this.transform);
                        }
                        // Child
                        {
                            game.gameData.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                }
                if (data is GameData)
                {
                    dirty = true;
                    return;
                }
                if (data is BtnSetEditPostureGameData.UIData)
                {
                    BtnSetEditPostureGameData.UIData btnSetUIData = data as BtnSetEditPostureGameData.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnSetUIData, btnSetPrefab, this.transform, btnSetRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is ChoosePostureUI.UIData)
                {
                    ChoosePostureUI.UIData choosePostureUIData = data as ChoosePostureUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(choosePostureUIData, choosePosturePrefab, this.transform, choosePostureRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is LoadPostureUI.UIData)
                {
                    LoadPostureUI.UIData loadPostureUIData = data as LoadPostureUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(loadPostureUIData, loadPosturePrefab, this.transform, loadPostureRect);
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
                // Child
                {
                    uiData.postureGameDataFactory.allRemoveCallBack(this);
                    uiData.gameUIData.allRemoveCallBack(this);
                    uiData.btnSet.allRemoveCallBack(this);
                    uiData.choosePostureUIData.allRemoveCallBack(this);
                    uiData.loadPostureUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Child
            {
                // postureGameDataFactory
                {
                    if (data is PostureGameDataFactory)
                    {
                        PostureGameDataFactory postureGameDataFactory = data as PostureGameDataFactory;
                        // Child
                        {
                            postureGameDataFactory.gameData.allRemoveCallBack(this);
                        }
                        return;
                    }
                }
                // GameUIData
                {
                    if (data is GameUI.UIData)
                    {
                        GameUI.UIData gameUIData = data as GameUI.UIData;
                        // UI
                        {
                            gameUIData.removeCallBackAndDestroy(typeof(GameUI));
                        }
                        // Child
                        {
                            gameUIData.game.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Game)
                    {
                        Game game = data as Game;
                        // Update
                        {
                            game.removeCallBackAndDestroy(typeof(GameUpdate));
                        }
                        // Child
                        {
                            game.gameData.allRemoveCallBack(this);
                        }
                        return;
                    }
                }
                if (data is GameData)
                {
                    return;
                }
                if (data is BtnSetEditPostureGameData.UIData)
                {
                    BtnSetEditPostureGameData.UIData btnSetUIData = data as BtnSetEditPostureGameData.UIData;
                    // UI
                    {
                        btnSetUIData.removeCallBackAndDestroy(typeof(BtnSetEditPostureGameData));
                    }
                    return;
                }
                if (data is ChoosePostureUI.UIData)
                {
                    ChoosePostureUI.UIData choosePostureUIData = data as ChoosePostureUI.UIData;
                    // UI
                    {
                        choosePostureUIData.removeCallBackAndDestroy(typeof(ChoosePostureUI));
                    }
                    return;
                }
                if (data is LoadPostureUI.UIData)
                {
                    LoadPostureUI.UIData loadPostureUIData = data as LoadPostureUI.UIData;
                    // UI
                    {
                        loadPostureUIData.removeCallBackAndDestroy(typeof(LoadPostureUI));
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
                    case UIData.Property.postureGameDataFactory:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.gameUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnSet:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.choosePostureUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.loadPostureUIData:
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
            if (wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
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
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                // postureGameDataFactory
                {
                    if (wrapProperty.p is PostureGameDataFactory)
                    {
                        switch ((PostureGameDataFactory.Property)wrapProperty.n)
                        {
                            case PostureGameDataFactory.Property.gameData:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case PostureGameDataFactory.Property.useRule:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                // GameUIData
                {
                    if (wrapProperty.p is GameUI.UIData)
                    {
                        switch ((GameUI.UIData.Property)wrapProperty.n)
                        {
                            case GameUI.UIData.Property.game:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case GameUI.UIData.Property.isReplay:
                                break;
                            case GameUI.UIData.Property.stateUI:
                                break;
                            case GameUI.UIData.Property.gameDataUI:
                                break;
                            case GameUI.UIData.Property.undoRedoRequestUIData:
                                break;
                            case GameUI.UIData.Property.gameChatRoom:
                                break;
                            case GameUI.UIData.Property.requestDraw:
                                break;
                            case GameUI.UIData.Property.saveUIData:
                                break;
                            case GameUI.UIData.Property.gameHistoryUIData:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
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
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case Game.Property.history:
                                break;
                            case Game.Property.gameAction:
                                break;
                            case Game.Property.undoRedoRequest:
                                break;
                            case Game.Property.chatRoom:
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
                if (wrapProperty.p is GameData)
                {
                    switch ((GameData.Property)wrapProperty.n)
                    {
                        case GameData.Property.gameType:
                            dirty = true;
                            break;
                        case GameData.Property.useRule:
                            break;
                        case GameData.Property.turn:
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
                if (wrapProperty.p is BtnSetEditPostureGameData.UIData)
                {
                    return;
                }
                if (wrapProperty.p is ChoosePostureUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is LoadPostureUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                PostureGameDataFactoryUI.UIData postureGameDataFactoryUIData = this.data.findDataInParent<PostureGameDataFactoryUI.UIData>();
                if (postureGameDataFactoryUIData != null)
                {
                    postureGameDataFactoryUIData.editPostureGameData.v = null;
                }
                else
                {
                    Debug.LogError("postureGameDataFactoryUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onClickBtnPosture()
        {
            if (this.data != null)
            {
                // container
                {
                    /*if (choosePostureContainer != null) {
						choosePostureContainer.gameObject.SetActive (true);
					} else {
						Debug.LogError ("choosePostureContainer null: " + this);
					}*/
                    UIRectTransform.SetActive(this.data.choosePostureUIData.v, true);
                }
                // uiData
                {
                    ChoosePostureUI.UIData choosePostureUIData = this.data.choosePostureUIData.newOrOld<ChoosePostureUI.UIData>();
                    {
                        // gameType
                        {
                            GameType.Type gameTypeType = GameType.Type.CHESS;
                            {
                                GameUI.UIData gameUIData = this.data.gameUIData.v;
                                if (gameUIData != null)
                                {
                                    Game game = gameUIData.game.v.data;
                                    if (game != null)
                                    {
                                        GameData gameData = game.gameData.v;
                                        if (gameData != null)
                                        {
                                            GameType gameType = gameData.gameType.v;
                                            if (gameType != null)
                                            {
                                                gameTypeType = gameType.getType();
                                            }
                                            else
                                            {
                                                Debug.LogError("gameType null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("gameData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameUIData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameUIData null: " + this);
                                }
                            }
                            choosePostureUIData.gameType.v = gameTypeType;
                        }
                    }
                    this.data.choosePostureUIData.v = choosePostureUIData;
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onClickBtnLoad()
        {
            if (this.data != null)
            {
                LoadPostureUI.UIData loadPostureUIData = this.data.loadPostureUIData.newOrOld<LoadPostureUI.UIData>();
                {
                    // gameType
                    {
                        GameType.Type gameTypeType = GameType.Type.CHESS;
                        {
                            GameUI.UIData gameUIData = this.data.gameUIData.v;
                            if (gameUIData != null)
                            {
                                Game game = gameUIData.game.v.data;
                                if (game != null)
                                {
                                    GameData gameData = game.gameData.v;
                                    if (gameData != null)
                                    {
                                        GameType gameType = gameData.gameType.v;
                                        if (gameType != null)
                                        {
                                            gameTypeType = gameType.getType();
                                        }
                                        else
                                        {
                                            Debug.LogError("gameType null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameUIData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("gameUIData null: " + this);
                            }
                        }
                        loadPostureUIData.gameType.v = gameTypeType;
                    }
                }
                this.data.loadPostureUIData.v = loadPostureUIData;
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}