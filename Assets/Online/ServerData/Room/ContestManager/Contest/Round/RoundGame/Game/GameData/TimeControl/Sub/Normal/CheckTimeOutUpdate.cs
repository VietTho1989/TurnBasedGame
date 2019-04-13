using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
    public class CheckTimeOutUpdate : UpdateBehavior<TimeControlNormal>
    {

        #region update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // Get playerIndex
                    int playerIndex = 0;
                    {
                        // Find Turn
                        Turn turn = null;
                        {
                            GameData gameData = this.data.findDataInParent<GameData>();
                            if (gameData != null)
                            {
                                turn = gameData.turn.v;
                            }
                            else
                            {
                                Debug.LogError("gameData null: " + this);
                            }
                        }
                        if (turn != null)
                        {
                            playerIndex = turn.playerIndex.v;
                        }
                        else
                        {
                            Debug.LogError("turn null: " + this);
                        }
                    }
                    // Check timeout
                    bool isTimeOut = false;
                    {
                        TimeControl timeControl = this.data.findDataInParent<TimeControl>();
                        if (timeControl != null)
                        {
                            // Find serverPerTime
                            float serverTurnTime = 0;
                            {
                                WaitInputAction waitInputAction = null;
                                {
                                    Game game = this.data.findDataInParent<Game>();
                                    if (game != null)
                                    {
                                        if (game.gameAction.v != null && game.gameAction.v is WaitInputAction)
                                        {
                                            waitInputAction = game.gameAction.v as WaitInputAction;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("game null: " + this);
                                    }
                                }
                                if (waitInputAction != null)
                                {
                                    serverTurnTime = waitInputAction.serverTime.v;
                                }
                                else
                                {
                                    // Debug.LogError ("waitInputAction null: " + this);
                                }
                            }
                            PlayerTotalTime playerTotalTime = this.data.getPlayerTotalTime(playerIndex);
                            TimeInfo playerTimeInfo = this.data.getTimeInfo(playerIndex);
                            if (playerTotalTime != null && playerTimeInfo != null)
                            {
                                switch (timeControl.use.v)
                                {
                                    case TimeControl.Use.ServerTime:
                                        {
                                            // Check is over time
                                            bool isOverTotalTime = false;
                                            {
                                                if (playerTimeInfo.totalTime.v.isOverTime(playerTotalTime.serverTime.v + serverTurnTime))
                                                {
                                                    isOverTotalTime = true;
                                                }
                                            }
                                            // Get TimePerTurnInfo
                                            TimePerTurnInfo timePerTurnInfo = isOverTotalTime ? playerTimeInfo.overTimePerTurn.v : playerTimeInfo.timePerTurn.v;
                                            if (timePerTurnInfo.isOverTime(serverTurnTime))
                                            {
                                                isTimeOut = true;
                                            }
                                        }
                                        break;
                                    case TimeControl.Use.ClientTime:
                                        {
                                            // Get Report Time
                                            float reportTime = 0;
                                            {
                                                // Find TimeReportClient
                                                TimeReportClient timeReportClient = null;
                                                {
                                                    if (timeControl.timeReport.v != null)
                                                    {
                                                        if (timeControl.timeReport.v is TimeReportClient)
                                                        {
                                                            timeReportClient = timeControl.timeReport.v as TimeReportClient;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("timeReport null: " + this);
                                                    }
                                                }
                                                // Process
                                                if (timeReportClient != null)
                                                {
                                                    reportTime = timeReportClient.reportTime.v;
                                                }
                                                else
                                                {
                                                    // Debug.LogError ("timeReportClient null: " + this);
                                                }
                                            }
                                            // get checkTime
                                            float checkTime = reportTime;
                                            {
                                                if (serverTurnTime >= reportTime + playerTimeInfo.lagCompensation.v)
                                                {
                                                    // wait report time too long
                                                    checkTime = serverTurnTime - playerTimeInfo.lagCompensation.v;
                                                }
                                                else
                                                {
                                                    checkTime = reportTime;
                                                }
                                            }
                                            // Check is over time
                                            bool isOverTotalTime = false;
                                            {
                                                if (playerTimeInfo.totalTime.v.isOverTime(playerTotalTime.clientTime.v + checkTime))
                                                {
                                                    isOverTotalTime = true;
                                                }
                                            }
                                            // Get TimePerTurnInfo
                                            TimePerTurnInfo timePerTurnInfo = isOverTotalTime ? playerTimeInfo.overTimePerTurn.v : playerTimeInfo.timePerTurn.v;
                                            {
                                                if (timePerTurnInfo.isOverTime(checkTime))
                                                {
                                                    isTimeOut = true;
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown use: " + timeControl.use.v);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("playerTotalTime, playerTimeInfo null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("timeControls null: " + this);
                        }
                    }
                    // Process
                    {
                        TimeControl timeControl = this.data.findDataInParent<TimeControl>();
                        if (timeControl != null)
                        {
                            if (isTimeOut)
                            {
                                // Check ai time out
                                bool isAITimeOut = false;
                                {
                                    if (!timeControl.aiCanTimeOut.v)
                                    {
                                        Game game = this.data.findDataInParent<Game>();
                                        if (game != null)
                                        {
                                            foreach (GamePlayer gamePlayer in game.gamePlayers.vs)
                                            {
                                                if (gamePlayer.playerIndex.v == playerIndex)
                                                {
                                                    if (gamePlayer.inform.v != null && gamePlayer.inform.v is Computer)
                                                    {
                                                        isAITimeOut = true;
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("duel null: " + this);
                                        }
                                    }
                                }
                                // Process
                                if (!isAITimeOut)
                                {
                                    // remove not correct
                                    for (int i = timeControl.timeOutPlayers.vs.Count - 1; i >= 0; i--)
                                    {
                                        if (timeControl.timeOutPlayers.vs[i] != playerIndex)
                                        {
                                            timeControl.timeOutPlayers.removeAt(i);
                                        }
                                    }
                                    // Add
                                    if (!timeControl.timeOutPlayers.vs.Contains(playerIndex))
                                    {
                                        timeControl.timeOutPlayers.add(playerIndex);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("isAITimeOut: not add");
                                    if (timeControl.timeOutPlayers.vs.Contains(playerIndex))
                                    {
                                        Debug.LogError("why already contain playerIndex: " + playerIndex);
                                        timeControl.timeOutPlayers.remove(playerIndex);
                                    }
                                }
                            }
                            else
                            {
                                timeControl.timeOutPlayers.clear();
                            }
                        }
                        else
                        {
                            Debug.LogError("timeControls null: " + this);
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

        private GameData gameData = null;

        private TimeControl timeControls = null;

        private Game game = null;

        private GameCheckPlayerChange<TimeControlNormal> gameCheckPlayerChange = new GameCheckPlayerChange<TimeControlNormal>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is TimeControlNormal)
            {
                TimeControlNormal timeControlNormal = data as TimeControlNormal;
                // CheckChange
                {
                    gameCheckPlayerChange.addCallBack(this);
                    gameCheckPlayerChange.setData(timeControlNormal);
                }
                // Parent
                {
                    DataUtils.addParentCallBack(timeControlNormal, this, ref this.gameData);
                    DataUtils.addParentCallBack(timeControlNormal, this, ref this.timeControls);
                    DataUtils.addParentCallBack(timeControlNormal, this, ref this.game);
                }
                // Child
                {
                    timeControlNormal.generalInfo.allAddCallBack(this);
                    timeControlNormal.playerTimeInfos.allAddCallBack(this);
                    timeControlNormal.playerTotalTimes.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // CheckChange
            if (data is GameCheckPlayerChange<TimeControlNormal>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                // GameData
                {
                    if (data is GameData)
                    {
                        GameData gameData = data as GameData;
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
                // TimeControls
                {
                    if (data is TimeControl)
                    {
                        TimeControl timeControls = data as TimeControl;
                        // Child
                        {
                            timeControls.timeReport.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is TimeReport)
                    {
                        dirty = true;
                        return;
                    }
                }
                // Game
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
                // TimeInfo
                {
                    if (data is TimeInfo)
                    {
                        TimeInfo timeInfo = data as TimeInfo;
                        // Child
                        {
                            timeInfo.timePerTurn.allAddCallBack(this);
                            timeInfo.totalTime.allAddCallBack(this);
                            timeInfo.overTimePerTurn.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is TimePerTurnInfo)
                        {
                            dirty = true;
                            return;
                        }
                        if (data is TotalTimeInfo)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
                if (data is PlayerTimeInfo)
                {
                    PlayerTimeInfo playerTimeInfo = data as PlayerTimeInfo;
                    // Child
                    {
                        playerTimeInfo.timeInfo.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                if (data is PlayerTotalTime)
                {
                    // PlayerTotalTime playerTotalTime = data as PlayerTotalTime;
                    {

                    }
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is TimeControlNormal)
            {
                TimeControlNormal timeControlNormal = data as TimeControlNormal;
                // CheckChange
                {
                    gameCheckPlayerChange.removeCallBack(this);
                    gameCheckPlayerChange.setData(null);
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(timeControlNormal, this, ref this.gameData);
                    DataUtils.removeParentCallBack(timeControlNormal, this, ref this.timeControls);
                    DataUtils.removeParentCallBack(timeControlNormal, this, ref this.game);
                }
                // Child
                {
                    timeControlNormal.generalInfo.allRemoveCallBack(this);
                    timeControlNormal.playerTimeInfos.allRemoveCallBack(this);
                    timeControlNormal.playerTotalTimes.allRemoveCallBack(this);
                }
                this.setDataNull(timeControlNormal);
                return;
            }
            // CheckChange
            if (data is GameCheckPlayerChange<TimeControlNormal>)
            {
                return;
            }
            // Parent
            {
                // GameData
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
                    if (data is Turn)
                    {
                        return;
                    }
                }
                // TimeControls
                {
                    if (data is TimeControl)
                    {
                        TimeControl timeControls = data as TimeControl;
                        // Child
                        {
                            timeControls.timeReport.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is TimeReport)
                    {
                        return;
                    }
                }
                // Game
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
                // TimeInfo
                {
                    if (data is TimeInfo)
                    {
                        TimeInfo timeInfo = data as TimeInfo;
                        // Child
                        {
                            timeInfo.timePerTurn.allRemoveCallBack(this);
                            timeInfo.totalTime.allRemoveCallBack(this);
                            timeInfo.overTimePerTurn.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is TimePerTurnInfo)
                        {
                            return;
                        }
                        if (data is TotalTimeInfo)
                        {
                            return;
                        }
                    }
                }
                if (data is PlayerTimeInfo)
                {
                    PlayerTimeInfo playerTimeInfo = data as PlayerTimeInfo;
                    // Child
                    {
                        playerTimeInfo.timeInfo.allRemoveCallBack(this);
                    }
                    return;
                }
                if (data is PlayerTotalTime)
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
            if (wrapProperty.p is TimeControlNormal)
            {
                switch ((TimeControlNormal.Property)wrapProperty.n)
                {
                    case TimeControlNormal.Property.generalInfo:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case TimeControlNormal.Property.playerTimeInfos:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case TimeControlNormal.Property.playerTotalTimes:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    default:
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            if (wrapProperty.p is GameCheckPlayerChange<TimeControlNormal>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                // GameData
                {
                    if (wrapProperty.p is GameData)
                    {
                        switch ((GameData.Property)wrapProperty.n)
                        {
                            case GameData.Property.gameType:
                                break;
                            case GameData.Property.useRule:
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
                                Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    if (wrapProperty.p is Turn)
                    {
                        switch ((Turn.Property)wrapProperty.n)
                        {
                            case Turn.Property.turn:
                                dirty = true;
                                break;
                            case Turn.Property.playerIndex:
                                dirty = true;
                                break;
                            case Turn.Property.gameTurn:
                                break;
                            default:
                                Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                // TimeControls
                {
                    if (wrapProperty.p is TimeControl)
                    {
                        switch ((TimeControl.Property)wrapProperty.n)
                        {
                            case TimeControl.Property.isEnable:
                                break;
                            case TimeControl.Property.aiCanTimeOut:
                                dirty = true;
                                break;
                            case TimeControl.Property.timeOutPlayers:
                                break;
                            case TimeControl.Property.sub:
                                break;
                            case TimeControl.Property.use:
                                dirty = true;
                                break;
                            case TimeControl.Property.timeReport:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            default:
                                Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    if (wrapProperty.p is TimeReport)
                    {
                        if (wrapProperty.p is TimeReportNone)
                        {
                            switch ((TimeReportNone.Property)wrapProperty.n)
                            {
                                default:
                                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        if (wrapProperty.p is TimeReportClient)
                        {
                            switch ((TimeReportClient.Property)wrapProperty.n)
                            {
                                case TimeReportClient.Property.userId:
                                    break;
                                case TimeReportClient.Property.delta:
                                    break;
                                case TimeReportClient.Property.reportTime:
                                    dirty = true;
                                    break;
                                case TimeReportClient.Property.clientState:
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
                // Game
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
                            default:
                                Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    if (wrapProperty.p is GameAction)
                    {
                        if (wrapProperty.p is WaitInputAction)
                        {
                            switch ((WaitInputAction.Property)wrapProperty.n)
                            {
                                case WaitInputAction.Property.serverTime:
                                    dirty = true;
                                    break;
                                case WaitInputAction.Property.clientTime:
                                    break;
                                case WaitInputAction.Property.sub:
                                    break;
                                case WaitInputAction.Property.inputs:
                                    break;
                                case WaitInputAction.Property.clientInput:
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
            }
            // Child
            {
                // TimeInfo
                {
                    if (wrapProperty.p is TimeInfo)
                    {
                        switch ((TimeInfo.Property)wrapProperty.n)
                        {
                            case TimeInfo.Property.timePerTurn:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case TimeInfo.Property.totalTime:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case TimeInfo.Property.overTimePerTurn:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case TimeInfo.Property.lagCompensation:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is TimePerTurnInfo)
                        {
                            if (wrapProperty.p is TimePerTurnInfo.Limit)
                            {
                                switch ((TimePerTurnInfo.Limit.Property)wrapProperty.n)
                                {
                                    case TimePerTurnInfo.Limit.Property.perTurn:
                                        dirty = true;
                                        break;
                                    default:
                                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                                        break;
                                }
                                return;
                            }
                            if (wrapProperty.p is TimePerTurnInfo.NoLimit)
                            {
                                return;
                            }
                            return;
                        }
                        if (wrapProperty.p is TotalTimeInfo)
                        {
                            if (wrapProperty.p is TotalTimeInfo.Limit)
                            {
                                switch ((TotalTimeInfo.Limit.Property)wrapProperty.n)
                                {
                                    case TotalTimeInfo.Limit.Property.totalTime:
                                        dirty = true;
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                                return;
                            }
                            if (wrapProperty.p is TotalTimeInfo.NoLimit)
                            {
                                return;
                            }
                            return;
                        }
                    }
                }
                if (wrapProperty.p is PlayerTimeInfo)
                {
                    switch ((PlayerTimeInfo.Property)wrapProperty.n)
                    {
                        case PlayerTimeInfo.Property.playerIndex:
                            dirty = true;
                            break;
                        case PlayerTimeInfo.Property.timeInfo:
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
                if (wrapProperty.p is PlayerTotalTime)
                {
                    switch ((PlayerTotalTime.Property)wrapProperty.n)
                    {
                        case PlayerTotalTime.Property.playerIndex:
                            dirty = true;
                            break;
                        case PlayerTotalTime.Property.serverTime:
                            dirty = true;
                            break;
                        case PlayerTotalTime.Property.clientTime:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}