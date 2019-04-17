using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
    public class GamePlayerTimeNormalUI : UIHaveTransformDataBehavior<GamePlayerTimeNormalUI.UIData>
    {

        #region UIData

        public class UIData : GamePlayerTimeUI.UIData.Sub
        {

            public VP<ReferenceData<GamePlayer>> gamePlayer;

            #region Constructor

            public enum Property
            {
                gamePlayer
            }

            public UIData() : base()
            {
                this.gamePlayer = new VP<ReferenceData<GamePlayer>>(this, (byte)Property.gamePlayer, new ReferenceData<GamePlayer>(null));
            }

            #endregion

            public override TimeControl.Sub.Type getType()
            {
                return TimeControl.Sub.Type.Normal;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtTime = new TxtLanguage("Time");

        static GamePlayerTimeNormalUI()
        {
            txtTime.add(Language.Type.vi, "Thời gian");
        }

        #endregion

        #region Refresh

        public Text tvTime;

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
                        // Find
                        int playerIndex = 0;
                        TimeControl timeControl = null;
                        TimeControlNormal timeControlNormal = null;
                        WaitInputAction waitInputAction = null;
                        {
                            Game game = gamePlayer.findDataInParent<Game>();
                            if (game != null)
                            {
                                // gameAction
                                if (game.gameAction.v != null && game.gameAction.v is WaitInputAction)
                                {
                                    waitInputAction = game.gameAction.v as WaitInputAction;
                                }
                                // GameData
                                GameData gameData = game.gameData.v;
                                if (gameData != null)
                                {
                                    // Turn
                                    {
                                        Turn turn = gameData.turn.v;
                                        if (turn != null)
                                        {
                                            playerIndex = turn.playerIndex.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("turn null: " + this);
                                        }
                                    }
                                    // timeControl
                                    {
                                        timeControl = gameData.timeControl.v;
                                        if (timeControl != null)
                                        {
                                            if (timeControl.sub.v != null && timeControl.sub.v is TimeControlNormal)
                                            {
                                                timeControlNormal = timeControl.sub.v as TimeControlNormal;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("timeControl null: " + this);
                                        }
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
                        // Process
                        if (timeControlNormal != null && timeControl != null)
                        {
                            TimeInfo timeInfo = timeControlNormal.getTimeInfo(gamePlayer.playerIndex.v);
                            PlayerTotalTime totalTime = timeControlNormal.getPlayerTotalTime(gamePlayer.playerIndex.v);
                            if (timeInfo != null && totalTime != null)
                            {
                                // totalTimeLimit
                                float totalTimeLimit = float.MaxValue;
                                {
                                    switch (timeInfo.totalTime.v.getType())
                                    {
                                        case TotalTimeInfo.Type.Limit:
                                            {
                                                TotalTimeInfo.Limit limit = timeInfo.totalTime.v as TotalTimeInfo.Limit;
                                                totalTimeLimit = limit.totalTime.v;
                                            }
                                            break;
                                        case TotalTimeInfo.Type.NoLimit:
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + timeInfo.totalTime.v.getType() + "; " + this);
                                            break;
                                    }
                                }
                                // serverTotalTime
                                float serverTotalTime = 0;
                                {
                                    // totalTime
                                    serverTotalTime = +totalTime.serverTime.v;
                                    // waitInputAction
                                    if (waitInputAction != null)
                                    {
                                        if (gamePlayer.playerIndex.v == playerIndex)
                                        {
                                            serverTotalTime += waitInputAction.serverTime.v;
                                        }
                                    }
                                    else
                                    {
                                        // Debug.LogError ("waitInputAction null: " + this);
                                    }
                                }
                                // clientTotalTime
                                float clientTotalTime = 0;
                                {
                                    // totalTime
                                    clientTotalTime = +totalTime.clientTime.v;
                                    // waitInputAction
                                    if (waitInputAction != null)
                                    {
                                        if (gamePlayer.playerIndex.v == playerIndex)
                                        {
                                            clientTotalTime += waitInputAction.clientTime.v;
                                        }
                                    }
                                    else
                                    {
                                        // Debug.LogError ("waitInputAction null: " + this);
                                    }
                                }

                                // serverTurnTime
                                float serverTurnTime = 0;
                                {
                                    if (waitInputAction != null)
                                    {
                                        if (gamePlayer.playerIndex.v == playerIndex)
                                        {
                                            serverTurnTime = waitInputAction.serverTime.v;
                                        }
                                    }
                                }
                                // perTurnLimitServer
                                float perTurnLimitServer = float.MaxValue;
                                {
                                    TimePerTurnInfo timePerTurnInfo = timeInfo.totalTime.v.isOverTime(serverTurnTime + totalTime.serverTime.v) ? timeInfo.overTimePerTurn.v : timeInfo.timePerTurn.v;
                                    switch (timePerTurnInfo.getType())
                                    {
                                        case TimePerTurnInfo.Type.Limit:
                                            {
                                                TimePerTurnInfo.Limit limit = timePerTurnInfo as TimePerTurnInfo.Limit;
                                                perTurnLimitServer = limit.perTurn.v;
                                            }
                                            break;
                                        case TimePerTurnInfo.Type.NoLimit:
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + timePerTurnInfo.getType() + "; " + this);
                                            break;
                                    }
                                }
                                // clientTurnTime
                                float clientTurnTime = 0;
                                {
                                    if (waitInputAction != null)
                                    {
                                        if (gamePlayer.playerIndex.v == playerIndex)
                                        {
                                            clientTurnTime = waitInputAction.clientTime.v;
                                        }
                                    }
                                }
                                // perTurnLimitClient
                                float perTurnLimitClient = float.MaxValue;
                                {
                                    TimePerTurnInfo timePerTurnInfo = timeInfo.totalTime.v.isOverTime(clientTurnTime + totalTime.clientTime.v) ? timeInfo.overTimePerTurn.v : timeInfo.timePerTurn.v;
                                    switch (timePerTurnInfo.getType())
                                    {
                                        case TimePerTurnInfo.Type.Limit:
                                            {
                                                TimePerTurnInfo.Limit limit = timePerTurnInfo as TimePerTurnInfo.Limit;
                                                perTurnLimitClient = limit.perTurn.v;
                                            }
                                            break;
                                        case TimePerTurnInfo.Type.NoLimit:
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + timePerTurnInfo.getType() + "; " + this);
                                            break;
                                    }
                                }

                                // reportTime
                                float reportTime = 0;
                                {
                                    TimeReportClient timeReportClient = null;
                                    {
                                        if (timeControl.timeReport.v != null && timeControl.timeReport.v is TimeReportClient)
                                        {
                                            timeReportClient = timeControl.timeReport.v as TimeReportClient;
                                        }
                                    }
                                    if (timeReportClient != null)
                                    {
                                        // strReport = timeReportClient.reportTime.v + "|" + timeReportClient.delta.v;
                                        reportTime = timeReportClient.reportTime.v;
                                    }
                                    else
                                    {
                                        // Debug.LogError ("timeReportClient null: " + this);
                                    }
                                }

                                // print
                                if (tvTime != null)
                                {
                                    // turnTime
                                    string strTurnTime = "";
                                    {
                                        float turnTime = 0;
                                        float turnTimeLimit = 0;
                                        {
                                            switch (timeControl.use.v)
                                            {
                                                case TimeControl.Use.ServerTime:
                                                    {
                                                        turnTime = serverTurnTime;
                                                        turnTimeLimit = perTurnLimitServer;
                                                    }
                                                    break;
                                                case TimeControl.Use.ClientTime:
                                                    {
                                                        turnTime = clientTurnTime;
                                                        turnTimeLimit = perTurnLimitClient;
                                                    }
                                                    break;
                                                default:
                                                    {
                                                        Debug.LogError("unknown use: " + timeControl.use.v);
                                                        turnTime = clientTurnTime;
                                                        turnTimeLimit = perTurnLimitClient;
                                                    }
                                                    break;
                                            }
                                        }
                                        // find is near time out
                                        bool isNearTimeOut = false;
                                        {
                                            if (turnTimeLimit != float.MaxValue)
                                            {
                                                if (turnTimeLimit - turnTime <= Mathf.Min(turnTimeLimit / 4, 15))
                                                {
                                                    isNearTimeOut = true;
                                                }
                                            }
                                        }
                                        // set string
                                        if (!isNearTimeOut)
                                        {
                                            strTurnTime = turnTime + "/" + (turnTimeLimit == float.MaxValue ? "∞" : "" + turnTimeLimit);
                                        }
                                        else
                                        {
                                            strTurnTime = "<color=red>" + turnTime + "/" + (turnTimeLimit == float.MaxValue ? "∞" : "" + turnTimeLimit) + "</color> ";
                                        }
                                    }
                                    // totalTime
                                    string strTotalTime = "";
                                    {
                                        float playerTotalTime = 0;
                                        {
                                            switch (timeControl.use.v)
                                            {
                                                case TimeControl.Use.ServerTime:
                                                    {
                                                        playerTotalTime = serverTotalTime;
                                                    }
                                                    break;
                                                case TimeControl.Use.ClientTime:
                                                    {
                                                        playerTotalTime = clientTotalTime;
                                                    }
                                                    break;
                                                default:
                                                    {
                                                        Debug.LogError("unknown use: " + timeControl.use.v);
                                                        playerTotalTime = clientTotalTime;
                                                    }
                                                    break;
                                            }
                                        }
                                        // find is near time out
                                        bool isNearTimeOut = false;
                                        {
                                            if (totalTimeLimit != float.MaxValue)
                                            {
                                                if (totalTimeLimit - playerTotalTime <= Mathf.Min(totalTimeLimit / 4, 30))
                                                {
                                                    isNearTimeOut = true;
                                                }
                                            }
                                        }
                                        // set string
                                        if (!isNearTimeOut)
                                        {
                                            strTotalTime = playerTotalTime + "/" + (totalTimeLimit == float.MaxValue ? "∞" : "" + totalTimeLimit);
                                        }
                                        else
                                        {
                                            strTotalTime = "<color=red>" + playerTotalTime + "/" + (totalTimeLimit == float.MaxValue ? "∞" : "" + totalTimeLimit) + "</color> ";
                                        }
                                    }
                                    // set
                                    // tvTime.text = txtTime.get("Time") + ": " + strTurnTime + " | " + strTotalTime;
                                    tvTime.text = strTurnTime + " | " + strTotalTime;
                                }
                                else
                                {
                                    Debug.LogError("tvTime null");
                                }
                            }
                            else
                            {
                                Debug.LogError("timeInfo, totalTime null");
                            }
                        }
                        else
                        {
                            Debug.LogError("timeControlNormal null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("gamePlayer null: " + this);
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

        private Game game = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.gamePlayer.allAddCallBack(this);
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
                if (data is GamePlayer)
                {
                    GamePlayer gamePlayer = data as GamePlayer;
                    // Parent
                    {
                        DataUtils.addParentCallBack(gamePlayer, this, ref this.game);
                    }
                    dirty = true;
                    return;
                }
                // Parent
                {
                    if (data is Game)
                    {
                        Game game = data as Game;
                        // Child
                        {
                            game.gameAction.allAddCallBack(this);
                            game.gameData.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        // GameAction
                        if (data is GameAction)
                        {
                            dirty = true;
                            return;
                        }
                        // GameData
                        {
                            if (data is GameData)
                            {
                                GameData gameData = data as GameData;
                                // Child
                                {
                                    gameData.turn.allAddCallBack(this);
                                    gameData.timeControl.allAddCallBack(this);
                                }
                                dirty = true;
                                return;
                            }
                            // Child
                            {
                                if (data is Turn)
                                {
                                    dirty = true;
                                    return;
                                }
                                // TimeControl
                                {
                                    if (data is TimeControl)
                                    {
                                        TimeControl timeControl = data as TimeControl;
                                        // Child
                                        {
                                            timeControl.sub.allAddCallBack(this);
                                            timeControl.timeReport.allAddCallBack(this);
                                        }
                                        dirty = true;
                                        return;
                                    }
                                    // Child
                                    {
                                        // sub
                                        {
                                            if (data is TimeControl.Sub)
                                            {
                                                TimeControl.Sub sub = data as TimeControl.Sub;
                                                // Inherit
                                                {
                                                    if (sub is TimeControlNormal)
                                                    {
                                                        TimeControlNormal normal = sub as TimeControlNormal;
                                                        // Child
                                                        {
                                                            normal.generalInfo.allAddCallBack(this);
                                                            normal.playerTimeInfos.allAddCallBack(this);
                                                            normal.playerTotalTimes.allAddCallBack(this);
                                                        }
                                                    }
                                                }
                                                dirty = true;
                                                return;
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
                                                            // lagCompensation
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
                                                // PlayerTimeInfo
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
                                                // PlayerTotalTime
                                                if (data is PlayerTotalTime)
                                                {
                                                    dirty = true;
                                                    return;
                                                }
                                            }
                                        }
                                        // timeReport
                                        if (data is TimeReport)
                                        {
                                            dirty = true;
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
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
                    uiData.gamePlayer.allRemoveCallBack(this);
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
                if (data is GamePlayer)
                {
                    GamePlayer gamePlayer = data as GamePlayer;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(gamePlayer, this, ref this.game);
                    }
                    return;
                }
                // Parent
                {
                    if (data is Game)
                    {
                        Game game = data as Game;
                        // Child
                        {
                            game.gameAction.allRemoveCallBack(this);
                            game.gameData.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        // GameAction
                        if (data is GameAction)
                        {
                            return;
                        }
                        // GameData
                        {
                            if (data is GameData)
                            {
                                GameData gameData = data as GameData;
                                // Child
                                {
                                    gameData.turn.allRemoveCallBack(this);
                                    gameData.timeControl.allRemoveCallBack(this);
                                }
                                return;
                            }
                            // Child
                            {
                                if (data is Turn)
                                {
                                    return;
                                }
                                // TimeControl
                                {
                                    if (data is TimeControl)
                                    {
                                        TimeControl timeControl = data as TimeControl;
                                        // Child
                                        {
                                            timeControl.sub.allRemoveCallBack(this);
                                            timeControl.timeReport.allRemoveCallBack(this);
                                        }
                                        return;
                                    }
                                    // Child
                                    {
                                        // sub
                                        {
                                            if (data is TimeControl.Sub)
                                            {
                                                TimeControl.Sub sub = data as TimeControl.Sub;
                                                // Inherit
                                                {
                                                    if (sub is TimeControlNormal)
                                                    {
                                                        TimeControlNormal normal = sub as TimeControlNormal;
                                                        // Child
                                                        {
                                                            normal.generalInfo.allRemoveCallBack(this);
                                                            normal.playerTimeInfos.allRemoveCallBack(this);
                                                            normal.playerTotalTimes.allRemoveCallBack(this);
                                                        }
                                                    }
                                                }
                                                return;
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
                                                            // lagCompensation
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
                                                // PlayerTimeInfo
                                                if (data is PlayerTimeInfo)
                                                {
                                                    PlayerTimeInfo playerTimeInfo = data as PlayerTimeInfo;
                                                    // Child
                                                    {
                                                        playerTimeInfo.timeInfo.allRemoveCallBack(this);
                                                    }
                                                    return;
                                                }
                                                // PlayerTotalTime
                                                if (data is PlayerTotalTime)
                                                {
                                                    return;
                                                }
                                            }
                                        }
                                        // timeReport
                                        if (data is TimeReport)
                                        {
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
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
                    case Setting.Property.style:
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
                if (wrapProperty.p is GamePlayer)
                {
                    switch ((GamePlayer.Property)wrapProperty.n)
                    {
                        case GamePlayer.Property.playerIndex:
                            dirty = true;
                            break;
                        case GamePlayer.Property.inform:
                            break;
                        case GamePlayer.Property.state:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
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
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
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
                        // GameAction
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
                                        dirty = true;
                                        break;
                                    case WaitInputAction.Property.sub:
                                        break;
                                    case WaitInputAction.Property.inputs:
                                        break;
                                    case WaitInputAction.Property.clientInput:
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
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
                                        {
                                            ValueChangeUtils.replaceCallBack(this, syncs);
                                            dirty = true;
                                        }
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
                            {
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
                                // TimeControl
                                {
                                    if (wrapProperty.p is TimeControl)
                                    {
                                        switch ((TimeControl.Property)wrapProperty.n)
                                        {
                                            case TimeControl.Property.isEnable:
                                                break;
                                            case TimeControl.Property.aiCanTimeOut:
                                                break;
                                            case TimeControl.Property.timeOutPlayers:
                                                break;
                                            case TimeControl.Property.sub:
                                                {
                                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                                    dirty = true;
                                                }
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
                                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                break;
                                        }
                                        return;
                                    }
                                    // Child
                                    {
                                        // sub
                                        {
                                            if (wrapProperty.p is TimeControl.Sub)
                                            {
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
                                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                            break;
                                                    }
                                                    return;
                                                }
                                                return;
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
                                                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                                        break;
                                                                }
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
                                                // PlayerTimeInfo
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
                                                // PlayerTotalTime
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
                                        }
                                        // TimeReport
                                        if (wrapProperty.p is TimeReport)
                                        {
                                            if (wrapProperty.p is TimeReportNone)
                                            {
                                                return;
                                            }
                                            if (wrapProperty.p is TimeReportClient)
                                            {
                                                switch ((TimeReportClient.Property)wrapProperty.n)
                                                {
                                                    case TimeReportClient.Property.userId:
                                                        break;
                                                    case TimeReportClient.Property.delta:
                                                        dirty = true;
                                                        break;
                                                    case TimeReportClient.Property.reportTime:
                                                        dirty = true;
                                                        break;
                                                    case TimeReportClient.Property.clientState:
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
                            }
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        #endregion

    }
}