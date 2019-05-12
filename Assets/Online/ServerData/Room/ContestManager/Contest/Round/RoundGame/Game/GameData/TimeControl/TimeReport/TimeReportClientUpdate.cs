using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

/**
 * TODO Can khoi tao o dataIdentity nua
 * */
public class TimeReportClientUpdate : UpdateBehavior<TimeReportClient>
{

    #region update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                float clientTime = 0;
                // Set state
                {
                    if (Server.getProfileUserId(this.data) == this.data.userId.v)
                    {
                        if (this.data.delta.v > 0)
                        {
                            // Find WaitInputAction
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
                            // Process
                            if (waitInputAction != null)
                            {
                                clientTime = waitInputAction.clientTime.v;
                                // Enough time, so send
                                if (waitInputAction.clientTime.v >= this.data.reportTime.v + this.data.delta.v)
                                {
                                    // Send
                                    if (this.data.clientState.v == TimeReportClient.State.None)
                                    {
                                        this.data.clientState.v = TimeReportClient.State.Send;
                                    }
                                }
                                // not enough time, so not send
                                else
                                {
                                    this.data.clientState.v = TimeReportClient.State.None;
                                }
                            }
                            else
                            {
                                this.data.clientState.v = TimeReportClient.State.None;
                                // Debug.LogError ("waitInputAction null: " + this);
                            }
                        }
                        else
                        {
                            this.data.clientState.v = TimeReportClient.State.None;
                        }
                    }
                    else
                    {
                        this.data.clientState.v = TimeReportClient.State.None;
                    }
                }
                // Debug.LogError ("timeReportClinetUpdate: " + clientTime + "; " + this);
                // Tasks
                switch (this.data.clientState.v)
                {
                    case TimeReportClient.State.None:
                        {
                            destroyRoutine(waitToResend);
                        }
                        break;
                    case TimeReportClient.State.Send:
                        {
                            destroyRoutine(waitToResend);
                            if (Server.IsServerOnline(this.data))
                            {
                                // request send
                                Debug.LogError("send report clientTime: " + clientTime + "; " + this);
                                this.data.requestReportClientTime(Server.getProfileUserId(this.data), clientTime);
                                // change state
                                this.data.clientState.v = TimeReportClient.State.Sending;
                            }
                            else
                            {
                                Debug.LogError("server not online: " + this);
                            }
                        }
                        break;
                    case TimeReportClient.State.Sending:
                        {
                            if (Server.IsServerOnline(this.data))
                            {
                                startRoutine(ref waitToResend, TaskWaitToResend());
                            }
                            else
                            {
                                this.data.clientState.v = TimeReportClient.State.Send;
                            }
                        }
                        break;
                    default:
                        Debug.LogError("unknown clientState: " + this.data.clientState.v + "; " + this);
                        break;
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

    #region Task wait to resend

    private Routine waitToResend;

    public IEnumerator TaskWaitToResend()
    {
        if (this.data != null)
        {
            yield return new Wait(3f);
            this.data.clientState.v = TimeReportClient.State.Send;
            Debug.LogError("resend: " + this);
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public override List<Routine> getRoutineList()
    {
        List<Routine> ret = new List<Routine>();
        {
            ret.Add(waitToResend);
        }
        return ret;
    }

    #endregion

    #region implement callBacks

    private Game game = null;

    #region when change turn

    private GameData gameData = null;

    private void resetTimeReport()
    {
        bool isServer = false;
        {
            Server server = this.data.findDataInParent<Server>();
            if (server != null)
            {
                switch (server.type.v)
                {
                    case Server.Type.Server:
                        isServer = true;
                        break;
                    case Server.Type.Client:
                        isServer = false;
                        break;
                    case Server.Type.Host:
                        isServer = true;
                        break;
                    case Server.Type.Offline:
                        isServer = true;
                        break;
                    default:
                        Debug.LogError("unknown server type: " + server.type.v);
                        break;
                }
            }
            else
            {
                // Debug.LogError("server null");
            }
        }
        if (isServer)
        {
            this.data.reportTime.v = 0;
        }
    }

    #endregion

    private Server server = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is TimeReportClient)
        {
            TimeReportClient timeReportClient = data as TimeReportClient;
            // Parent
            {
                DataUtils.addParentCallBack(timeReportClient, this, ref this.game);
                DataUtils.addParentCallBack(timeReportClient, this, ref this.gameData);
                DataUtils.addParentCallBack(timeReportClient, this, ref this.server);
            }
            dirty = true;
            return;
        }
        // Parent
        {
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
                    // GameAction gameAction = data as GameAction;
                    dirty = true;
                    return;
                }
            }
            // gameData
            {
                if(data is GameData)
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
                if(data is Turn)
                {
                    dirty = true;
                    return;
                }
            }
            // Server
            if (data is Server)
            {
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is TimeReportClient)
        {
            TimeReportClient timeReportClient = data as TimeReportClient;
            // Parent
            {
                DataUtils.removeParentCallBack(timeReportClient, this, ref this.game);
                DataUtils.removeParentCallBack(timeReportClient, this, ref this.gameData);
                DataUtils.removeParentCallBack(timeReportClient, this, ref this.server);
            }
            this.setDataNull(timeReportClient);
            return;
        }
        // Parent
        {
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
            // gameData
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
            // Server
            if (data is Server)
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
        if (wrapProperty.p is TimeReportClient)
        {
            switch ((TimeReportClient.Property)wrapProperty.n)
            {
                case TimeReportClient.Property.userId:
                    dirty = true;
                    break;
                case TimeReportClient.Property.delta:
                    dirty = true;
                    break;
                case TimeReportClient.Property.reportTime:
                    dirty = true;
                    break;
                case TimeReportClient.Property.clientState:
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
            // Game
            {
                if (wrapProperty.p is Game)
                {
                    switch ((Game.Property)wrapProperty.n)
                    {
                        case Game.Property.gamePlayers:
                            break;
                        case Game.Property.state:
                            break;
                        case Game.Property.requestDraw:
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
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is GameAction)
                {
                    if (wrapProperty.p is WaitInputAction)
                    {
                        switch ((WaitInputAction.Property)wrapProperty.n)
                        {
                            case WaitInputAction.Property.serverTime:
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
            }
            // gameData
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
                                resetTimeReport();
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
                        case Turn.Property.playerIndex:
                        case Turn.Property.gameTurn:
                            {
                                dirty = true;
                                resetTimeReport();
                            }
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // Server
            if (wrapProperty.p is Server)
            {
                Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}