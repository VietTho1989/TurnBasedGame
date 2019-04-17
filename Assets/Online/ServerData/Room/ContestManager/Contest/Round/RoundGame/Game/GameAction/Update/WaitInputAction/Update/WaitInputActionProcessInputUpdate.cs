using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Check Legal Move de o luong chinh, co the gay anh huong
 * */
public class WaitInputActionProcessInputUpdate : UpdateBehavior<WaitInputAction>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            if (GlobalBehavior.CheckLegalCount <= GlobalBehavior.MaxCheckLegalCount)
            {
                dirty = false;
                if (this.data != null)
                {
                    if (Game.IsPlaying(this.data))
                    {
                        // Find legal inputData
                        InputData legalInputData = null;
                        {
                            // Find GameType
                            GameType gameType = null;
                            {
                                Game game = this.data.findDataInParent<Game>();
                                if (game != null)
                                {
                                    GameData gameData = game.gameData.v;
                                    if (gameData != null)
                                    {
                                        gameType = gameData.gameType.v;
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
                            // Process
                            if (gameType != null)
                            {
                                List<InputData> illegalInputDatas = new List<InputData>();
                                // Check legal
                                for (int i = 0; i < this.data.inputs.vs.Count; i++)
                                {
                                    InputData inputData = this.data.inputs.vs[i];
                                    // check legal
                                    bool isLegal = false;
                                    {
                                        // check correct user
                                        bool isCorrectUser = false;
                                        {
                                            // find correct userId
                                            uint correctUserId = 0;
                                            {
                                                if (this.data.sub.v != null)
                                                {
                                                    // HumanInput
                                                    if (this.data.sub.v is WaitHumanInput)
                                                    {
                                                        WaitHumanInput waitHumanInput = this.data.sub.v as WaitHumanInput;
                                                        correctUserId = waitHumanInput.userId.v;
                                                    }
                                                    // AIInput
                                                    else if (this.data.sub.v is WaitAIInput)
                                                    {
                                                        WaitAIInput waitAIInput = this.data.sub.v as WaitAIInput;
                                                        correctUserId = waitAIInput.userThink.v;
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("sub null: " + this);
                                                }
                                            }
                                            // Check
                                            if (inputData.userSend.v == correctUserId)
                                            {
                                                isCorrectUser = true;
                                            }
                                        }
                                        // Check legal
                                        if (isCorrectUser)
                                        {
                                            if (gameType.checkLegalMove(inputData))
                                            {
                                                GlobalBehavior.CheckLegalCount++;
                                                isLegal = true;
                                            }
                                            else
                                            {
                                                // Debug.LogError ("not legal move: " + inputData.gameMove.v + "; " + this);
                                                // rethink
                                                {
                                                    if (this.data.sub.v != null)
                                                    {
                                                        if (this.data.sub.v is WaitAIInput)
                                                        {
                                                            WaitAIInput waitAIInput = this.data.sub.v as WaitAIInput;
                                                            waitAIInput.rethink.v = waitAIInput.rethink.v + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("not correct user: " + this);
                                        }
                                    }
                                    if (isLegal)
                                    {
                                        legalInputData = inputData;
                                        break;
                                    }
                                    else
                                    {
                                        illegalInputDatas.Add(inputData);
                                    }
                                }
                                // remove illegal
                                {
                                    foreach (InputData illegalInputData in illegalInputDatas)
                                    {
                                        this.data.inputs.remove(illegalInputData);
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("gameType null: " + this);
                            }
                        }
                        // Process
                        if (legalInputData != null)
                        {
                            Game game = this.data.findDataInParent<Game>();
                            if (game != null)
                            {
                                // Change to processMoveAction
                                ProcessMoveAction processMoveAction = new ProcessMoveAction();
                                {
                                    processMoveAction.uid = game.gameAction.makeId();
                                    {
                                        processMoveAction.inputData.v = (InputData)DataUtils.cloneData(legalInputData);
                                        processMoveAction.inputData.v.serverTime.v = this.data.serverTime.v;
                                    }
                                    processMoveAction.state.v = ProcessMoveAction.State.Process;
                                }
                                game.gameAction.v = processMoveAction;
                            }
                            else
                            {
                                Debug.LogError("game null: " + this);
                            }
                        }
                        else
                        {
                            // Debug.LogError ("legalInputData null: " + this);
                        }
                    }
                    else
                    {
                        // Debug.LogError ("duel isn't playing: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
            else
            {
                Debug.LogError("check legal move too much: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    private GameIsPlayingChange<WaitInputAction> gameIsPlayingChange = new GameIsPlayingChange<WaitInputAction>();
    private Game game = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is WaitInputAction)
        {
            WaitInputAction waitInputAction = data as WaitInputAction;
            // CheckChange
            {
                gameIsPlayingChange.addCallBack(this);
                gameIsPlayingChange.setData(waitInputAction);
            }
            // Parent
            {
                DataUtils.addParentCallBack(waitInputAction, this, ref this.game);
            }
            // Child
            {
                waitInputAction.inputs.allAddCallBack(this);
                waitInputAction.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // CheckChange
        if (data is GameIsPlayingChange<WaitInputAction>)
        {
            dirty = true;
            return;
        }
        // Parent
        {
            if (data is Game)
            {
                Game game = data as Game;
                {
                    game.gameData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // GameData
            {
                if (data is GameData)
                {
                    GameData gameData = data as GameData;
                    {
                        gameData.gameType.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                if (data is GameType)
                {
                    dirty = true;
                    return;
                }
            }
        }
        // Child
        {
            if (data is InputData)
            {
                dirty = true;
                return;
            }
            if (data is WaitInputAction.Sub)
            {
                dirty = true;
                return;
            }
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
                gameIsPlayingChange.removeCallBack(this);
                gameIsPlayingChange.setData(null);
            }
            // Parent
            {
                DataUtils.removeParentCallBack(waitInputAction, this, ref this.game);
            }
            // Child
            {
                waitInputAction.inputs.allRemoveCallBack(this);
                waitInputAction.sub.allRemoveCallBack(this);
            }
            this.setDataNull(waitInputAction);
            return;
        }
        // CheckChange
        if (data is GameIsPlayingChange<WaitInputAction>)
        {
            return;
        }
        // Parent
        {
            if (data is Game)
            {
                Game game = data as Game;
                {
                    game.gameData.allRemoveCallBack(this);
                }
                return;
            }
            // GameData
            {
                if (data is GameData)
                {
                    GameData gameData = data as GameData;
                    {
                        gameData.gameType.allAddCallBack(this);
                    }
                    return;
                }
                if (data is GameType)
                {
                    return;
                }
            }
        }
        // Child
        {
            if (data is InputData)
            {
                return;
            }
            if (data is WaitInputAction.Sub)
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
        // CheckChange
        if (wrapProperty.p is GameIsPlayingChange<WaitInputAction>)
        {
            dirty = true;
            return;
        }
        // Parent
        {
            if (wrapProperty.p is Game)
            {
                switch ((Game.Property)wrapProperty.n)
                {
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
            // GameData
            {
                if (wrapProperty.p is GameData)
                {
                    switch ((GameData.Property)wrapProperty.n)
                    {
                        case GameData.Property.gameType:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case GameData.Property.useRule:
                            dirty = true;
                            break;
                        case GameData.Property.blindFold:
                            break;
                        case GameData.Property.requestChangeBlindFold:
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
                if (wrapProperty.p is GameType)
                {
                    // Debug.LogError ("why gameType have change: " + this);
                    dirty = true;
                    return;
                }
            }
        }
        // Child
        {
            if (wrapProperty.p is InputData)
            {
                switch ((InputData.Property)wrapProperty.n)
                {
                    case InputData.Property.gameMove:
                        dirty = true;
                        break;
                    case InputData.Property.userSend:
                        dirty = true;
                        break;
                    case InputData.Property.clientTime:
                        break;
                    default:
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is WaitInputAction.Sub)
            {
                // WaitHumanInput
                if (wrapProperty.p is WaitHumanInput)
                {
                    switch ((WaitHumanInput.Property)wrapProperty.n)
                    {
                        case WaitHumanInput.Property.userId:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // WaitAIInput
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
                            Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}