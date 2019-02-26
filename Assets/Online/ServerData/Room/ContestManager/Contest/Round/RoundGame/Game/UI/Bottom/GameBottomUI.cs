using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using GameManager.Match;
using GameManager.Match.Swap;

public class GameBottomUI : UIBehavior<GameBottomUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Game>> game;

        public VP<BtnUndoRedoUI.UIData> btnUndoRedo;

        public VP<BtnRequestDrawUI.UIData> btnRequestDraw;

        public VP<BtnHintUI.UIData> btnHint;

        public VP<BtnGameChatUI.UIData> btnGameChat;

        public VP<BtnPauseUI.UIData> btnPause;

        public VP<BtnShowSwapUI.UIData> btnShowSwap;

        public VP<BtnUseRuleUI.UIData> btnUseRule;

        public VP<BtnHistoryUI.UIData> btnHistory;

        #region Constructor

        public enum Property
        {
            game,
            btnUndoRedo,
            btnRequestDraw,
            btnHint,
            btnGameChat,
            btnPause,
            btnShowSwap,
            btnUseRule,
            btnHistory
        }

        public UIData() : base()
        {
            this.game = new VP<ReferenceData<Game>>(this, (byte)Property.game, new ReferenceData<Game>(null));
            this.btnUndoRedo = new VP<BtnUndoRedoUI.UIData>(this, (byte)Property.btnUndoRedo, new BtnUndoRedoUI.UIData());
            this.btnRequestDraw = new VP<BtnRequestDrawUI.UIData>(this, (byte)Property.btnRequestDraw, new BtnRequestDrawUI.UIData());
            this.btnHint = new VP<BtnHintUI.UIData>(this, (byte)Property.btnHint, new BtnHintUI.UIData());
            this.btnGameChat = new VP<BtnGameChatUI.UIData>(this, (byte)Property.btnGameChat, new BtnGameChatUI.UIData());
            this.btnPause = new VP<BtnPauseUI.UIData>(this, (byte)Property.btnPause, new BtnPauseUI.UIData());
            this.btnShowSwap = new VP<BtnShowSwapUI.UIData>(this, (byte)Property.btnShowSwap, new BtnShowSwapUI.UIData());
            this.btnUseRule = new VP<BtnUseRuleUI.UIData>(this, (byte)Property.btnUseRule, new BtnUseRuleUI.UIData());
            this.btnHistory = new VP<BtnHistoryUI.UIData>(this, (byte)Property.btnHistory, new BtnHistoryUI.UIData());
        }

        #endregion

    }

    #endregion

    #region txt

    static GameBottomUI()
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
                Game game = this.data.game.v.data;
                if (game != null)
                {
                    // btnUndoRedo
                    {
                        BtnUndoRedoUI.UIData btnUndoRedo = this.data.btnUndoRedo.v;
                        if (btnUndoRedo != null)
                        {
                            btnUndoRedo.undoRedoRequest.v = new ReferenceData<UndoRedoRequest>(game.undoRedoRequest.v);
                        }
                        else
                        {
                            Debug.LogError("btnUndoRedo null");
                        }
                    }
                    // btnRequestDraw
                    {
                        BtnRequestDrawUI.UIData btnRequestDraw = this.data.btnRequestDraw.v;
                        if (btnRequestDraw != null)
                        {
                            btnRequestDraw.requestDraw.v = new ReferenceData<RequestDraw>(game.requestDraw.v);
                        }
                        else
                        {
                            Debug.LogError("btnRequestDraw null");
                        }
                    }
                    // btnHint
                    {
                        BtnHintUI.UIData btnHint = this.data.btnHint.v;
                        if (btnHint != null)
                        {
                            btnHint.gameData.v = new ReferenceData<GameData>(game.gameData.v);
                        }
                        else
                        {
                            Debug.LogError("btnHint null");
                        }
                    }
                    // btnGameChat
                    {
                        BtnGameChatUI.UIData btnGameChat = this.data.btnGameChat.v;
                        if (btnGameChat != null)
                        {
                            btnGameChat.chatRoom.v = new ReferenceData<ChatRoom>(game.chatRoom.v);
                        }
                        else
                        {
                            Debug.LogError("btnGameChat null");
                        }
                    }
                    // btnPause
                    {
                        BtnPauseUI.UIData btnPause = this.data.btnPause.v;
                        if (btnPause != null)
                        {
                            // find play
                            GameState.Play play = null;
                            {
                                if(game.state.v is GameState.Play)
                                {
                                    play = game.state.v as GameState.Play;
                                }
                            }
                            btnPause.play.v = new ReferenceData<GameState.Play>(play);
                        }
                        else
                        {
                            Debug.LogError("btnPause null");
                        }
                    }
                    // btnShowSwap
                    {
                        BtnShowSwapUI.UIData btnShowSwap = this.data.btnShowSwap.v;
                        if (btnShowSwap != null)
                        {
                            // find Swap
                            Swap swap = null;
                            {
                                ContestManagerStatePlay contestManagerStatePlay = game.findDataInParent<ContestManagerStatePlay>();
                                if (contestManagerStatePlay != null)
                                {
                                    swap = contestManagerStatePlay.swap.v;
                                }
                                else
                                {
                                    Debug.LogError("contestManagerStatePlay null");
                                }
                            }
                            // set
                            btnShowSwap.swap.v = new ReferenceData<Swap>(swap);
                        }
                        else
                        {
                            Debug.LogError("btnShowSwap null");
                        }
                    }
                    // btnUseRule
                    {
                        BtnUseRuleUI.UIData btnUseRule = this.data.btnUseRule.v;
                        if (btnUseRule != null)
                        {
                            btnUseRule.requestChangeUseRule.v = new ReferenceData<RequestChangeUseRule>(game.gameData.v.requestChangeUseRule.v);
                        }
                        else
                        {
                            Debug.LogError("btnUseRule null");
                        }
                    }
                    // btnHistory
                    {
                        BtnHistoryUI.UIData btnHistory = this.data.btnHistory.v;
                        if (btnHistory != null)
                        {
                            btnHistory.history.v = new ReferenceData<History>(game.history.v);
                        }
                        else
                        {
                            Debug.LogError("btnHistory null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("game null");
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

    private static UIRectTransform CreateBtnRect(int index)
    {
        UIRectTransform uiRectTransform = new UIRectTransform();
        {
            float width = 80.0f;
            uiRectTransform.anchoredPosition = new Vector3(width * index, 0.0f, 0.0f);
            uiRectTransform.anchorMin = new Vector2(0.0f, 0.0f);
            uiRectTransform.anchorMax = new Vector2(0.0f, 1.0f);
            uiRectTransform.pivot = new Vector2(0.0f, 0.5f);
            uiRectTransform.offsetMin = new Vector2(width * index, 0.0f);
            uiRectTransform.offsetMax = new Vector2(width * index + width, 0.0f);
            uiRectTransform.sizeDelta = new Vector2(width, 0.0f);
        }
        return uiRectTransform;
    }

    public BtnUndoRedoUI btnUndoRedoPrefab;
    public BtnRequestDrawUI btnRequestDrawPrefab;
    public BtnHintUI btnHintPrefab;
    public BtnGameChatUI btnGameChatPrefab;
    public BtnPauseUI btnPausePrefab;
    public BtnShowSwapUI btnShowSwapPrefab;
    public BtnUseRuleUI btnUseRulePrefab;
    public BtnHistoryUI btnHistoryPrefab;

    public Transform contentContainer;

    private ContestManagerStatePlay contestManagerStatePlay = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.game.allAddCallBack(this);
                uiData.btnUndoRedo.allAddCallBack(this);
                uiData.btnRequestDraw.allAddCallBack(this);
                uiData.btnHint.allAddCallBack(this);
                uiData.btnGameChat.allAddCallBack(this);
                uiData.btnPause.allAddCallBack(this);
                uiData.btnShowSwap.allAddCallBack(this);
                uiData.btnUseRule.allAddCallBack(this);
                uiData.btnHistory.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            // game
            {
                if (data is Game)
                {
                    Game game = data as Game;
                    // Parent
                    {
                        DataUtils.addParentCallBack(game, this, ref this.contestManagerStatePlay);
                    }
                    // Child
                    {
                        game.gameData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Parent
                if(data is ContestManagerStatePlay)
                {
                    dirty = true;
                    return;
                }
                // Child
                if (data is GameData)
                {
                    dirty = true;
                    return;
                }
            }
            if (data is BtnUndoRedoUI.UIData)
            {
                BtnUndoRedoUI.UIData btnUndoRedoUIData = data as BtnUndoRedoUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnUndoRedoUIData, btnUndoRedoPrefab, contentContainer, CreateBtnRect(0));
                }
                dirty = true;
                return;
            }
            if(data is BtnRequestDrawUI.UIData)
            {
                BtnRequestDrawUI.UIData btnRequestDrawUIData = data as BtnRequestDrawUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnRequestDrawUIData, btnRequestDrawPrefab, contentContainer, CreateBtnRect(1));
                }
                dirty = true;
                return;
            }
            if(data is BtnHintUI.UIData)
            {
                BtnHintUI.UIData btnHintUIData = data as BtnHintUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnHintUIData, btnHintPrefab, contentContainer, CreateBtnRect(2));
                }
                dirty = true;
                return;
            }
            if(data is BtnGameChatUI.UIData)
            {
                BtnGameChatUI.UIData btnGameChatUIData = data as BtnGameChatUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnGameChatUIData, btnGameChatPrefab, contentContainer, CreateBtnRect(3));
                }
                dirty = true;
                return;
            }
            if(data is BtnPauseUI.UIData)
            {
                BtnPauseUI.UIData btnPauseUIData = data as BtnPauseUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnPauseUIData, btnPausePrefab, contentContainer, CreateBtnRect(4));
                }
                dirty = true;
                return;
            }
            if(data is BtnShowSwapUI.UIData)
            {
                BtnShowSwapUI.UIData btnShowSwapUIData = data as BtnShowSwapUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnShowSwapUIData, btnShowSwapPrefab, contentContainer, CreateBtnRect(5));
                }
                dirty = true;
                return;
            }
            if (data is BtnUseRuleUI.UIData)
            {
                BtnUseRuleUI.UIData btnUseRuleUIData = data as BtnUseRuleUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnUseRuleUIData, btnUseRulePrefab, contentContainer, CreateBtnRect(6));
                }
                dirty = true;
                return;
            }
            if(data is BtnHistoryUI.UIData)
            {
                BtnHistoryUI.UIData btnHistoryUIData = data as BtnHistoryUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnHistoryUIData, btnHistoryPrefab, contentContainer, CreateBtnRect(7));
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
                uiData.btnUndoRedo.allRemoveCallBack(this);
                uiData.btnRequestDraw.allRemoveCallBack(this);
                uiData.btnHint.allRemoveCallBack(this);
                uiData.btnGameChat.allRemoveCallBack(this);
                uiData.btnPause.allRemoveCallBack(this);
                uiData.btnShowSwap.allRemoveCallBack(this);
                uiData.btnUseRule.allRemoveCallBack(this);
                uiData.btnHistory.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            // game
            {
                if (data is Game)
                {
                    Game game = data as Game;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(game, this, ref this.contestManagerStatePlay);
                    }
                    // Child
                    {
                        game.gameData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Parent
                if(data is ContestManagerStatePlay)
                {
                    return;
                }
                // Child
                if (data is GameData)
                {
                    return;
                }
            }
            if (data is BtnUndoRedoUI.UIData)
            {
                BtnUndoRedoUI.UIData btnUndoRedoUIData = data as BtnUndoRedoUI.UIData;
                // UI
                {
                    btnUndoRedoUIData.removeCallBackAndDestroy(typeof(BtnUndoRedoUI));
                }
                return;
            }
            if(data is BtnRequestDrawUI.UIData)
            {
                BtnRequestDrawUI.UIData btnRequestDrawUIData = data as BtnRequestDrawUI.UIData;
                // UI
                {
                    btnRequestDrawUIData.removeCallBackAndDestroy(typeof(BtnRequestDrawUI));
                }
                return;
            }
            if (data is BtnHintUI.UIData)
            {
                BtnHintUI.UIData btnHintUIData = data as BtnHintUI.UIData;
                // UI
                {
                    btnHintUIData.removeCallBackAndDestroy(typeof(BtnHintUI));
                }
                return;
            }
            if (data is BtnGameChatUI.UIData)
            {
                BtnGameChatUI.UIData btnGameChatUIData = data as BtnGameChatUI.UIData;
                // UI
                {
                    btnGameChatUIData.removeCallBackAndDestroy(typeof(BtnGameChatUI));
                }
                return;
            }
            if(data is BtnPauseUI.UIData)
            {
                BtnPauseUI.UIData btnPauseUIData = data as BtnPauseUI.UIData;
                // UI
                {
                    btnPauseUIData.removeCallBackAndDestroy(typeof(BtnPauseUI));
                }
                return;
            }
            if(data is BtnShowSwapUI.UIData)
            {
                BtnShowSwapUI.UIData btnShowSwapUIData = data as BtnShowSwapUI.UIData;
                // UI
                {
                    btnShowSwapUIData.removeCallBackAndDestroy(typeof(BtnShowSwapUI));
                }
                return;
            }
            if (data is BtnUseRuleUI.UIData)
            {
                BtnUseRuleUI.UIData btnUseRuleUIData = data as BtnUseRuleUI.UIData;
                // UI
                {
                    btnUseRuleUIData.removeCallBackAndDestroy(typeof(BtnUseRuleUI));
                }
                return;
            }
            if (data is BtnHistoryUI.UIData)
            {
                BtnHistoryUI.UIData btnHistoryUIData = data as BtnHistoryUI.UIData;
                // UI
                {
                    btnHistoryUIData.removeCallBackAndDestroy(typeof(BtnHistoryUI));
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if(WrapProperty.checkError(wrapProperty))
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
                case UIData.Property.btnUndoRedo:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnRequestDraw:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnHint:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnGameChat:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnPause:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnShowSwap:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnUseRule:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnHistory:
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
            // game
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
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Game.Property.history:
                            dirty = true;
                            break;
                        case Game.Property.gameAction:
                            break;
                        case Game.Property.undoRedoRequest:
                            dirty = true;
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
                // Parent
                if(wrapProperty.p is ContestManagerStatePlay)
                {
                    switch ((ContestManagerStatePlay.Property)wrapProperty.n)
                    {
                        case ContestManagerStatePlay.Property.state:
                            break;
                        case ContestManagerStatePlay.Property.isForceEnd:
                            break;

                        case ContestManagerStatePlay.Property.teams:
                            break;
                        case ContestManagerStatePlay.Property.swap:
                            dirty = true;
                            break;

                        case ContestManagerStatePlay.Property.content:
                            break;
                        case ContestManagerStatePlay.Property.contentTeamResult:
                            break;
                        case ContestManagerStatePlay.Property.gameTypeType:
                            break;

                        case ContestManagerStatePlay.Property.randomTeamIndex:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
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
            }
            if (wrapProperty.p is BtnUndoRedoUI.UIData)
            {
                return;
            }
            if(wrapProperty.p is BtnRequestDrawUI.UIData)
            {
                return;
            }
            if(wrapProperty.p is BtnHintUI.UIData)
            {
                return;
            }
            if(wrapProperty.p is BtnGameChatUI.UIData)
            {
                return;
            }
            if(wrapProperty.p is BtnPauseUI.UIData)
            {
                return;
            }
            if(wrapProperty.p is BtnShowSwapUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is BtnUseRuleUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}