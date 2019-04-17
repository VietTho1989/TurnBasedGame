using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;

/**
 * MakeSub co cho sai, chua biet tai sao: khi doi tu computer sang human
 * */
public class WaitInputMakeSubUpdate : UpdateBehavior<WaitInputAction>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                bool needAI = false;
                // Check use AI
                {
                    // Find current GamePlayer
                    GamePlayer currentGamePlayer = null;
                    {
                        // find curentPlayerIdex
                        int currentPlayerIndex = 0;
                        {
                            Game game = this.data.findDataInParent<Game>();
                            if (game != null)
                            {
                                GameData gameData = game.gameData.v;
                                if (gameData != null)
                                {
                                    Turn turn = gameData.turn.v;
                                    if (turn != null)
                                    {
                                        currentPlayerIndex = turn.playerIndex.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("turn null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("game null: " + this);
                            }
                        }
                        // get current GamePlayer
                        {
                            Game game = this.data.findDataInParent<Game>();
                            if (game != null)
                            {
                                currentGamePlayer = game.findGamePlayer(currentPlayerIndex);
                            }
                            else
                            {
                                Debug.LogError("game null: " + this);
                            }
                        }
                    }
                    // Check current gamePlayer is computer
                    if (currentGamePlayer != null)
                    {
                        if (currentGamePlayer.inform.v is Computer)
                        {
                            needAI = true;
                        }
                        else
                        {
                            // Debug.Log ("not computer, don't need ai");
                        }
                    }
                    else
                    {
                        Debug.LogError("Cannot find current gamePlayer");
                    }
                }
                // Process
                if (needAI)
                {
                    // find waitAIInput
                    WaitAIInput waitAIInput = this.data.sub.newOrOld<WaitAIInput>();
                    {
                        // userThink
                        {
                            uint userThink = 0;
                            {
                                RoomUser admin = Room.findAdmin(this.data);
                                if (admin != null)
                                {
                                    Human human = admin.inform.v;
                                    if (human != null)
                                    {
                                        userThink = human.playerId.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("human null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("admin null: " + this);
                                }
                            }
                            waitAIInput.userThink.v = userThink;
                        }
                    }
                    this.data.sub.v = waitAIInput;
                }
                else
                {
                    // find waitHumanInput
                    WaitHumanInput waitHumanInput = this.data.sub.newOrOld<WaitHumanInput>();
                    {
                        // userId
                        {
                            uint userId = 0;
                            // find userId
                            {
                                // Find current GamePlayer
                                GamePlayer currentGamePlayer = null;
                                {
                                    // find curentPlayerIdex
                                    int currentPlayerIndex = 0;
                                    {
                                        Game game = this.data.findDataInParent<Game>();
                                        if (game != null)
                                        {
                                            GameData gameData = game.gameData.v;
                                            if (gameData != null)
                                            {
                                                Turn turn = gameData.turn.v;
                                                if (turn != null)
                                                {
                                                    currentPlayerIndex = turn.playerIndex.v;
                                                }
                                                else
                                                {
                                                    Debug.LogError("turn null: " + this);
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("gameData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("game null: " + this);
                                        }
                                    }
                                    // get current GamePlayer
                                    {
                                        Game game = this.data.findDataInParent<Game>();
                                        if (game != null)
                                        {
                                            currentGamePlayer = game.findGamePlayer(currentPlayerIndex);
                                        }
                                        else
                                        {
                                            Debug.LogError("game null: " + this);
                                        }
                                    }
                                }
                                // Check current gamePlayer is computer
                                if (currentGamePlayer != null)
                                {
                                    if (currentGamePlayer.inform.v is Human)
                                    {
                                        Human human = currentGamePlayer.inform.v as Human;
                                        userId = human.playerId.v;
                                    }
                                    else
                                    {
                                        Debug.Log("why not human: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("Cannot find current gamePlayer: " + this);
                                }
                            }
                            // Process
                            waitHumanInput.userId.v = userId;
                        }
                    }
                    this.data.sub.v = waitHumanInput;
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
        return false;
    }

    #endregion

    #region implement callBacks

    private GameCheckPlayerChange<WaitInputAction> gameCheckPlayerChange = new GameCheckPlayerChange<WaitInputAction>();
    private RoomCheckChangeAdminChange<WaitInputAction> roomCheckAdminChange = new RoomCheckChangeAdminChange<WaitInputAction>();

    private Game game = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is WaitInputAction)
        {
            WaitInputAction waitInputAction = data as WaitInputAction;
            // CheckChange
            {
                // Check Player Change
                {
                    gameCheckPlayerChange.addCallBack(this);
                    gameCheckPlayerChange.setData(waitInputAction);
                }
                // Check Admin Change
                {
                    roomCheckAdminChange.addCallBack(this);
                    roomCheckAdminChange.setData(waitInputAction);
                }
            }
            // Parent
            {
                DataUtils.addParentCallBack(waitInputAction, this, ref this.game);
            }
            // Child
            {
                waitInputAction.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // CheckChange
        {
            // Check Player Change
            if (data is GameCheckPlayerChange<WaitInputAction>)
            {
                dirty = true;
                return;
            }
            // Check Admin Change
            if (data is RoomCheckChangeAdminChange<WaitInputAction>)
            {
                dirty = true;
                return;
            }
        }
        // Parent
        {
            if (data is Game)
            {
                Game game = data as Game;
                // Child
                {
                    game.gameData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is GameData)
                {
                    GameData gameData = data as GameData;
                    // Child
                    {
                        gameData.turn.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Turn)
                {
                    dirty = true;
                    return;
                }
            }
        }
        // Child
        if (data is WaitInputAction.Sub)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is WaitInputAction)
        {
            WaitInputAction waitInputAction = data as WaitInputAction;
            // CheckChange
            {
                // Check Player Change
                {
                    gameCheckPlayerChange.removeCallBack(this);
                    gameCheckPlayerChange.setData(null);
                }
                // Check Admin Change
                {
                    roomCheckAdminChange.removeCallBack(this);
                    roomCheckAdminChange.setData(null);
                }
            }
            // Parent
            {
                DataUtils.removeParentCallBack(waitInputAction, this, ref this.game);
            }
            // Child
            {
                waitInputAction.sub.allRemoveCallBack(this);
            }
            this.setDataNull(waitInputAction);
            return;
        }
        // CheckChange
        {
            // Check Player Change
            if (data is GameCheckPlayerChange<WaitInputAction>)
            {
                return;
            }
            // Check Admin Change
            if (data is RoomCheckChangeAdminChange<WaitInputAction>)
            {
                return;
            }
        }
        // Parent
        {
            if (data is Game)
            {
                Game game = data as Game;
                // Child
                {
                    game.gameData.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            {
                if (data is GameData)
                {
                    GameData gameData = data as GameData;
                    // Child
                    {
                        gameData.turn.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Turn)
                {
                    return;
                }
            }
        }
        // Child
        if (data is WaitInputAction.Sub)
        {
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
        if (wrapProperty.p is WaitInputAction)
        {
            switch ((WaitInputAction.Property)wrapProperty.n)
            {
                case WaitInputAction.Property.serverTime:
                    break;
                case WaitInputAction.Property.clientTime:
                    break;
                case WaitInputAction.Property.sub:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case WaitInputAction.Property.inputs:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // CheckChange
        {
            // Check Player Change
            if (wrapProperty.p is GameCheckPlayerChange<WaitInputAction>)
            {
                dirty = true;
                return;
            }
            // Check Admin Change
            if (wrapProperty.p is RoomCheckChangeAdminChange<WaitInputAction>)
            {
                dirty = true;
                return;
            }
        }
        // Parent
        {
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
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
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
                            break;
                        case GameData.Property.blindFold:
                            break;
                        case GameData.Property.requestChangeBlindFold:
                            break;
                        case GameData.Property.turn:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
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
                // Child
                if (wrapProperty.p is Turn)
                {
                    switch ((Turn.Property)wrapProperty.n)
                    {
                        case Turn.Property.turn:
                            break;
                        case Turn.Property.playerIndex:
                            dirty = true;
                            break;
                        case Turn.Property.gameTurn:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
        }
        // Child
        if (wrapProperty.p is WaitInputAction.Sub)
        {
            if (wrapProperty.p is WaitHumanInput)
            {
                return;
            }
            if (wrapProperty.p is WaitAIInput)
            {
                switch ((WaitAIInput.Property)wrapProperty.n)
                {
                    case WaitAIInput.Property.userThink:
                        dirty = true;
                        break;
                    case WaitAIInput.Property.reThink:
                        break;
                    case WaitAIInput.Property.sub:
                        break;
                    case WaitAIInput.Property.isGettingSolvedMove:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}