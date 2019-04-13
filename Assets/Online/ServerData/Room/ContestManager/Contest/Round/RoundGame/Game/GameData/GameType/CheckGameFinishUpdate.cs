using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckGameFinishUpdate : UpdateBehavior<GameType>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                if (GlobalBehavior.CheckFinishCount <= GlobalBehavior.MaxCheckFinishCount)
                {
                    GlobalBehavior.CheckFinishCount++;
                    // check finish
                    GameType.Result result = GameType.Result.makeDefault();
                    {
                        // check correct gameAction
                        bool isCorrectGameAction = true;
                        {
                            Game game = this.data.findDataInParent<Game>();
                            if (game != null)
                            {
                                GameAction gameAction = game.gameAction.v;
                                if (gameAction != null)
                                {
                                    if (gameAction is ProcessMoveAction)
                                    {
                                        ProcessMoveAction processMoveAction = gameAction as ProcessMoveAction;
                                        if (processMoveAction.state.v != ProcessMoveAction.State.End)
                                        {
                                            // Debug.LogError ("processMoveAction not end");
                                            isCorrectGameAction = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameAction null");
                                }
                            }
                            else
                            {
                                Debug.LogError("game null");
                            }
                        }
                        // process
                        if (isCorrectGameAction)
                        {
                            result = this.data.isGameFinish();
                        }
                        else
                        {
                            // Debug.LogError ("not correct gameAction");
                        }
                    }
                    // Process result
                    {
                        GameData gameData = this.data.findDataInParent<GameData>();
                        if (gameData != null)
                        {
                            if (result.isGameFinish)
                            {
                                // find state finish
                                GameDataStateFinish finish = null;
                                {
                                    if (gameData.state.v is GameDataStateFinish)
                                    {
                                        // find old
                                        finish = gameData.state.v as GameDataStateFinish;
                                    }
                                    else
                                    {
                                        // make new
                                        finish = new GameDataStateFinish();
                                        {
                                            finish.uid = gameData.state.makeId();
                                        }
                                        gameData.state.v = finish;
                                    }
                                }
                                // Update
                                {
                                    // get old
                                    List<PlayerResult> oldPlayerResults = new List<PlayerResult>();
                                    {
                                        oldPlayerResults.AddRange(finish.playerResults.vs);
                                    }
                                    // update
                                    {
                                        for (int i = 0; i < result.scores.Count; i++)
                                        {
                                            GameType.Score score = result.scores[i];
                                            // get playerResult
                                            PlayerResult playerResult = null;
                                            {
                                                // get old
                                                if (oldPlayerResults.Count > 0)
                                                {
                                                    playerResult = oldPlayerResults[0];
                                                }
                                                // make new
                                                if (playerResult == null)
                                                {
                                                    playerResult = new PlayerResult();
                                                    {
                                                        playerResult.uid = finish.playerResults.makeId();
                                                    }
                                                    finish.playerResults.add(playerResult);
                                                }
                                                else
                                                {
                                                    oldPlayerResults.Remove(playerResult);
                                                }
                                            }
                                            // Update Property
                                            {
                                                playerResult.playerIndex.v = score.playerIndex;
                                                playerResult.score.v = score.score;
                                            }
                                        }
                                    }
                                    // remove old
                                    foreach (PlayerResult playerResult in oldPlayerResults)
                                    {
                                        finish.playerResults.remove(playerResult);
                                    }
                                }
                            }
                            else
                            {
                                // Game not finished, make state normal
                                GameDataStateNormal normal = null;
                                {
                                    if (gameData.state.v is GameDataStateNormal)
                                    {
                                        // find old
                                        normal = gameData.state.v as GameDataStateNormal;
                                    }
                                    else
                                    {
                                        // make new
                                        normal = new GameDataStateNormal();
                                        {
                                            normal.uid = gameData.state.makeId();
                                        }
                                        gameData.state.v = normal;
                                    }
                                }
                                // Update Property
                                {

                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("gameData null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("check finish too much");
                    dirty = true;
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

    private GameData gameData = null;
    private Game game = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is GameType)
        {
            GameType gameType = data as GameType;
            // Parent
            {
                DataUtils.addParentCallBack(gameType, this, ref this.gameData);
                DataUtils.addParentCallBack(gameType, this, ref this.game);
            }
            // Child
            {
                gameType.addCallBackAllChildren(this);
            }
            dirty = true;
            return;
        }
        // Parent
        {
            if (data is GameData)
            {
                dirty = true;
                return;
            }
            // game
            {
                if (data is Game)
                {
                    Game game = data as Game;
                    // Child
                    {
                        game.gameAction.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is GameAction)
                {
                    dirty = true;
                    return;
                }
            }
        }
        // Child
        {
            data.addCallBackAllChildren(this);
            dirty = true;
            return;
        }
        // Debug.LogError ("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is GameType)
        {
            GameType gameType = data as GameType;
            // Parent
            {
                DataUtils.removeParentCallBack(gameType, this, ref this.gameData);
                DataUtils.removeParentCallBack(gameType, this, ref this.game);
            }
            // Child
            {
                gameType.removeCallBackAllChildren(this);
            }
            this.setDataNull(gameType);
            return;
        }
        // Parent
        {
            if (data is GameData)
            {
                return;
            }
            // game
            {
                if (data is Game)
                {
                    Game game = data as Game;
                    // Child
                    {
                        game.gameAction.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is GameAction)
                {
                    return;
                }
            }
        }
        // Child
        {
            data.removeCallBackAllChildren(this);
            return;
        }
        // Debug.LogError ("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is GameType)
        {
            if (Generic.IsAddCallBackInterface<T>())
            {
                ValueChangeUtils.replaceCallBack(this, syncs);
            }
            dirty = true;
            return;
        }
        // Parent
        {
            if (wrapProperty.p is GameData)
            {
                switch ((GameData.Property)wrapProperty.n)
                {
                    case GameData.Property.gameType:
                        break;
                    case GameData.Property.useRule:
                        dirty = true;
                        break;
                    case GameData.Property.requestChangeUseRule:
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
            // game
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
                            break;
                        case Game.Property.history:
                            break;
                        case Game.Property.gameAction:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
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
                // Child
                if (wrapProperty.p is GameAction)
                {
                    if (wrapProperty.p is ProcessMoveAction)
                    {
                        switch ((ProcessMoveAction.Property)wrapProperty.n)
                        {
                            case ProcessMoveAction.Property.state:
                                dirty = true;
                                break;
                            case ProcessMoveAction.Property.inputData:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    return;
                }
            }
        }
        // Child
        {
            if (Generic.IsAddCallBackInterface<T>())
            {
                ValueChangeUtils.replaceCallBack(this, syncs);
            }
            dirty = true;
            return;
        }
        // Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}