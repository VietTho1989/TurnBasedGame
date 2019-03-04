using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StartTurnActionUI : UIBehavior<StartTurnActionUI.UIData>
{

    #region UIData

    public class UIData : GameActionsUI.UIData.Sub
    {

        public VP<ReferenceData<StartTurnAction>> startTurnAction;

        public override GameAction.Type getType()
        {
            return GameAction.Type.StartTurn;
        }

        #region Constructor

        public enum Property
        {
            startTurnAction
        }

        public UIData() : base()
        {
            this.startTurnAction = new VP<ReferenceData<StartTurnAction>>(this, (byte)Property.startTurnAction, new ReferenceData<StartTurnAction>(null));
        }

        #endregion

    }

    #endregion

    #region Refresh

    #region txt

    public static TxtLanguage txtNewTurn = new TxtLanguage();
    public static TxtLanguage txtPlayer = new TxtLanguage();
    public static TxtLanguage txtTurn = new TxtLanguage();

    static StartTurnActionUI()
    {
        txtNewTurn.add(Language.Type.vi, "Lượt Mới");
        txtPlayer.add(Language.Type.vi, "Người chơi");
        txtTurn.add(Language.Type.vi, "lượt");
    }

    #endregion

    public Text tvTurn;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                StartTurnAction startTurnAction = this.data.startTurnAction.v.data;
                if (startTurnAction != null)
                {
                    if (tvTurn != null)
                    {
                        int turnIndex = 0;
                        {
                            Game game = startTurnAction.findDataInParent<Game>();
                            if (game != null)
                            {
                                GameData gameData = game.gameData.v;
                                if (gameData != null)
                                {
                                    Turn turn = gameData.turn.v;
                                    if (turn != null)
                                    {
                                        turnIndex = turn.turn.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("turn null");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameData null");
                                }
                            }
                            else
                            {
                                // Debug.LogError("game null");
                            }
                        }
                        tvTurn.text = txtNewTurn.get("New Turn") + ": " + turnIndex;
                        /*switch (startTurnAction.state.v)
                        {
                            case StartTurnAction.State.Start:
                                tvTurn.text = txtNewTurn.get("New Turn");
                                break;
                            case StartTurnAction.State.Process:
                                tvTurn.text = txtNewTurn.get("New Turn");
                                break;
                            case StartTurnAction.State.End:
                                {
                                    Game game = startTurnAction.findDataInParent<Game>();
                                    if (game != null)
                                    {
                                        Turn turn = game.gameData.v.turn.v;
                                        tvTurn.text = txtPlayer.get("Player") + " " + turn + " " + txtTurn.get("turn");
                                    }
                                    else
                                    {
                                        // Debug.LogError ("game null: " + this);
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown state: " + startTurnAction.state.v + "; " + this);
                                break;
                        }*/
                    }
                    else
                    {
                        Debug.LogError("tvTurn null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("startTurnAction null: " + this);
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
                uiData.startTurnAction.allAddCallBack(this);
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
            if (data is StartTurnAction)
            {
                StartTurnAction startTurnAction = data as StartTurnAction;
                // Parent
                {
                    DataUtils.addParentCallBack(startTurnAction, this, ref this.game);
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
                uiData.startTurnAction.allRemoveCallBack(this);
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
            if (data is StartTurnAction)
            {
                StartTurnAction startTurnAction = data as StartTurnAction;
                // Parent
                {
                    DataUtils.removeParentCallBack(startTurnAction, this, ref this.game);
                }
                return;
            }
            // Game
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
                case UIData.Property.startTurnAction:
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
            if (wrapProperty.p is StartTurnAction)
            {
                switch ((StartTurnAction.Property)wrapProperty.n)
                {
                    case StartTurnAction.Property.state:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
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
                            break;
                        case Game.Property.undoRedoRequest:
                            break;
                        default:
                            Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
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
                    // Child
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
                            default:
                                Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}