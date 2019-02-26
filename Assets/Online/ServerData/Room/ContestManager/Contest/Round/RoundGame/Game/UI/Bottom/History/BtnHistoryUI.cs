using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BtnHistoryUI : UIBehavior<BtnHistoryUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<History>> history;

        #region Constructor

        public enum Property
        {
            history
        }

        public UIData() : base()
        {
            this.history = new VP<ReferenceData<History>>(this, (byte)Property.history, new ReferenceData<History>(null));
        }

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    public Text tvTurn;
    private static readonly TxtLanguage txtTurn = new TxtLanguage();

    static BtnHistoryUI()
    {
        txtTitle.add(Language.Type.vi, "Lịch Sử");
        txtTurn.add(Language.Type.vi, "lượt");
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
                History history = this.data.history.v.data;
                if (history != null)
                {
                    // title
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get("History");
                    }
                    else
                    {
                        Debug.LogError("lbTitle null");
                    }
                    // turn
                    if (tvTurn != null)
                    {
                        int turnNumber = 0;
                        {
                            Game game = history.findDataInParent<Game>();
                            if (game != null)
                            {
                                GameData gameData = game.gameData.v;
                                if (gameData != null)
                                {
                                    Turn turn = gameData.turn.v;
                                    if (turn != null)
                                    {
                                        turnNumber = turn.turn.v;
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
                                Debug.LogError("game null");
                            }
                        }
                        tvTurn.text = txtTurn.get("turn") + " " + turnNumber;
                    }
                    else
                    {
                        Debug.LogError("tvTurn null");
                    }
                }
                else
                {
                    Debug.LogError("history null");
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

    private Game game = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.history.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if(data is History)
            {
                History history = data as History;
                // Parent
                {
                    DataUtils.addParentCallBack(history, this, ref this.game);
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
                uiData.history.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is History)
            {
                History history = data as History;
                // Parent
                {
                    DataUtils.removeParentCallBack(history, this, ref this.game);
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
                case UIData.Property.history:
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
            if (wrapProperty.p is History)
            {
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
                                dirty = true;
                                break;
                            case Turn.Property.playerIndex:
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
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnHistory()
    {
        if (this.data != null)
        {
            History history = this.data.history.v.data;
            if (history != null)
            {
                GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
                if (gameUIData != null)
                {
                    // create
                    GameHistoryUI.UIData gameHistoryUIData = gameUIData.gameHistoryUIData.newOrOld<GameHistoryUI.UIData>();
                    {
                       
                    }
                    gameUIData.gameHistoryUIData.v = gameHistoryUIData;
                    // show
                    {
                        // find alreadyLoad
                        bool alreadyLoad = false;
                        {
                            if (history.changes.vs.Count == history.changeCount.v)
                            {
                                alreadyLoad = true;
                            }
                            else
                            {
                                Debug.LogError("not already load");
                            }
                        }
                        // process
                        if (alreadyLoad)
                        {
                            // show view save
                            GameHistoryUI gameHistoryUI = gameHistoryUIData.findCallBack<GameHistoryUI>();
                            if (gameHistoryUI != null)
                            {
                                gameHistoryUI.onClickBtnView();
                            }
                            else
                            {
                                Debug.LogError("gameHistoryUI null");
                            }
                        }
                        else
                        {
                            gameHistoryUIData.visibility.v = GameHistoryUI.UIData.Visibility.Show;
                        }
                    }
                }
                else
                {
                    Debug.LogError("gameUIData null");
                }
            }
            else
            {
                Debug.LogError("history null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}