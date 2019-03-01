using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.HourGlass
{
    public class GamePlayerTimeHourGlassUI : UIBehavior<GamePlayerTimeHourGlassUI.UIData>, HaveTransformData
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
                return TimeControl.Sub.Type.HourGlass;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        static GamePlayerTimeHourGlassUI()
        {
            txtTitle.add(Language.Type.vi, "Đồng Hồ Cát");
        }

        #endregion

        #region TransformData

        public TransformData transformData = new TransformData();

        private void updateTransformData()
        {
            this.transformData.update(this.transform);
        }

        public TransformData getTransformData()
        {
            return this.transformData;
        }

        #endregion

        #region Refresh

        public Text tvServerTime;
        public Text tvClientTime;
        public Text tvReportTime;

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
                        TimeControlHourGlass timeControlHourGlass = null;
                        WaitInputAction waitInputAction = null;
                        {
                            Game game = gamePlayer.findDataInParent<Game>();
                            if (game != null)
                            {
                                // gameAction
                                if (game.gameAction.v != null && game.gameAction.v is WaitInputAction)
                                {
                                    waitInputAction = game.gameAction.v as WaitInputAction;
                                    // Debug.LogError ("waitInputAction time: " + waitInputAction.serverTime.v + "; " + waitInputAction.clientTime.v);
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
                                            if (timeControl.sub.v != null && timeControl.sub.v is TimeControlHourGlass)
                                            {
                                                timeControlHourGlass = timeControl.sub.v as TimeControlHourGlass;
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
                        if (timeControl != null && timeControlHourGlass != null)
                        {
                            PlayerTime playerTime = timeControlHourGlass.getPlayerTime(gamePlayer.playerIndex.v);
                            // tvServerTime
                            if (tvServerTime != null)
                            {
                                if (playerTime != null)
                                {
                                    float time = 0;
                                    {
                                        if (waitInputAction != null)
                                        {
                                            if (playerIndex == gamePlayer.playerIndex.v)
                                            {
                                                time = waitInputAction.serverTime.v;
                                            }
                                            else
                                            {
                                                time = -waitInputAction.serverTime.v;
                                            }
                                        }
                                    }
                                    // set
                                    tvServerTime.text = time + "/" + (playerTime.serverTime.v - time) + "/" + playerTime.serverTime.v;
                                }
                                else
                                {
                                    Debug.LogError("playerTime null: " + this);
                                    tvServerTime.text = "?";
                                }
                            }
                            else
                            {
                                Debug.LogError("tvServerTime null: " + this);
                            }
                            // tvClientTime
                            if (tvClientTime != null)
                            {
                                if (playerTime != null)
                                {
                                    float time = 0;
                                    {
                                        if (waitInputAction != null)
                                        {
                                            if (playerIndex == gamePlayer.playerIndex.v)
                                            {
                                                time = waitInputAction.clientTime.v;
                                            }
                                            else
                                            {
                                                time = -waitInputAction.clientTime.v;
                                            }
                                        }
                                    }
                                    // set
                                    tvClientTime.text = time + "/" + (playerTime.clientTime.v - time) + "/" + playerTime.clientTime.v + "/" + playerTime.lagCompensation.v;
                                }
                                else
                                {
                                    Debug.LogError("playerTime null: " + this);
                                    tvClientTime.text = "?";
                                }
                            }
                            else
                            {
                                Debug.LogError("tvClientTime null: " + this);
                            }
                            // tvReportTime
                            if (tvReportTime != null)
                            {
                                if (gamePlayer.playerIndex.v == playerIndex)
                                {
                                    // Find timeReportClient
                                    TimeReportClient timeReportClient = null;
                                    {
                                        if (timeControl.timeReport.v != null && timeControl.timeReport.v is TimeReportClient)
                                        {
                                            timeReportClient = timeControl.timeReport.v as TimeReportClient;
                                        }
                                    }
                                    // Process
                                    if (timeReportClient != null)
                                    {
                                        tvReportTime.text = timeReportClient.reportTime.v + "/" + timeReportClient.delta.v;
                                    }
                                    else
                                    {
                                        // Debug.LogError ("timeReportClient null: " + this);
                                        tvReportTime.text = "0/0";
                                    }
                                }
                                else
                                {
                                    tvReportTime.text = "0/0";
                                }
                            }
                            else
                            {
                                Debug.LogError("tvReportTime null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("timeControl, timeControlHourGlass null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("gamePlayer null: " + this);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Hourglass");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
            updateTransformData();
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
                                        // Sub
                                        {
                                            if (data is TimeControl.Sub)
                                            {
                                                TimeControl.Sub sub = data as TimeControl.Sub;
                                                // Inherit
                                                {
                                                    if (sub is TimeControlHourGlass)
                                                    {
                                                        TimeControlHourGlass timeControlHourGlass = sub as TimeControlHourGlass;
                                                        // Child
                                                        {
                                                            timeControlHourGlass.playerTimes.allAddCallBack(this);
                                                        }
                                                    }
                                                }
                                                dirty = true;
                                                return;
                                            }
                                            // PlayerTime
                                            if (data is PlayerTime)
                                            {
                                                dirty = true;
                                                return;
                                            }
                                        }
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
                Debug.LogError("Don't process: " + data + "; " + this);
            }
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
                                        // Sub
                                        {
                                            if (data is TimeControl.Sub)
                                            {
                                                TimeControl.Sub sub = data as TimeControl.Sub;
                                                // Inherit
                                                {
                                                    if (sub is TimeControlHourGlass)
                                                    {
                                                        TimeControlHourGlass timeControlHourGlass = sub as TimeControlHourGlass;
                                                        // Child
                                                        {
                                                            timeControlHourGlass.playerTimes.allRemoveCallBack(this);
                                                        }
                                                    }
                                                }
                                                return;
                                            }
                                            // PlayerTime
                                            if (data is PlayerTime)
                                            {
                                                return;
                                            }
                                        }
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
                Debug.LogError("Don't process: " + data + "; " + this);
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
                                return;
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
                                        // Sub
                                        {
                                            if (wrapProperty.p is TimeControl.Sub)
                                            {
                                                if (wrapProperty.p is TimeControlHourGlass)
                                                {
                                                    switch ((TimeControlHourGlass.Property)wrapProperty.n)
                                                    {
                                                        case TimeControlHourGlass.Property.initTime:
                                                            break;
                                                        case TimeControlHourGlass.Property.lagCompensation:
                                                            break;
                                                        case TimeControlHourGlass.Property.playerTimes:
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
                                            // PlayerTime
                                            if (wrapProperty.p is PlayerTime)
                                            {
                                                switch ((PlayerTime.Property)wrapProperty.n)
                                                {
                                                    case PlayerTime.Property.playerIndex:
                                                        dirty = true;
                                                        break;
                                                    case PlayerTime.Property.serverTime:
                                                        dirty = true;
                                                        break;
                                                    case PlayerTime.Property.clientTime:
                                                        dirty = true;
                                                        break;
                                                    case PlayerTime.Property.lagCompensation:
                                                        dirty = true;
                                                        break;
                                                    default:
                                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                        break;
                                                }
                                                return;
                                            }
                                        }
                                        if (wrapProperty.p is TimeReport)
                                        {
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
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Debug.LogError("Don't process: " + data + "; " + this);
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}