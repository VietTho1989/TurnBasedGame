using UnityEngine;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class WaitAIInputSearchUpdate : UpdateBehavior<WaitAIInputSearch>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // haveChange in gameType: research
                {
                    if (haveChange)
                    {
                        haveChange = false;
                        this.data.state.v = WaitAIInputSearch.State.Search;
                    }
                }
                // Task
                switch (this.data.state.v)
                {
                    case WaitAIInputSearch.State.Search:
                        {
                            destroyRoutine(findAIRoutine);
                            destroyNewThread();
                            this.data.state.v = WaitAIInputSearch.State.Searching;
                        }
                        break;
                    case WaitAIInputSearch.State.Searching:
                        {
                            startRoutine(ref this.findAIRoutine, TaskFindAIMove());
                        }
                        break;
                    default:
                        Debug.LogError("unknown state: " + this.data.state.v);
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

    #region Routine Search AI Move

    class Work
    {

        public WaitAIInputSearch data = null;

        public GameMove aiMove = new NonMove();

        public bool isDone = false;

        public void DoWork()
        {
            if (this.data != null)
            {
                // find gameData
                GameData gameData = null;
                {
                    Game game = this.data.findDataInParent<Game>();
                    if (game != null)
                    {
                        gameData = game.gameData.v;
                    }
                    else
                    {
                        Debug.LogError("Why game null");
                    }
                }
                // process
                if (gameData != null)
                {
                    // Get ai
                    Computer.AI ai = null;
                    {
                        // find playerIndex
                        int playerIndex = 0;
                        {
                            GameType gameType = gameData.gameType.v;
                            if (gameType != null)
                            {
                                playerIndex = gameType.getPlayerIndex();
                            }
                            else
                            {
                                System.Console.WriteLine("gameType null: " + playerIndex);
                            }
                            System.Console.WriteLine("waitAIInputSearch: " + playerIndex);
                        }
                        // get ai
                        {
                            Game game = this.data.findDataInParent<Game>();
                            if (game != null)
                            {
                                GamePlayer currentPlayer = game.findGamePlayer(playerIndex);
                                if (currentPlayer != null)
                                {
                                    ai = currentPlayer.getAI();
                                }
                                else
                                {
                                    // Debug.LogError ("Why currentPlayer null");
                                }
                            }
                            else
                            {
                                // Debug.LogError ("duel null");
                            }
                        }
                    }
                    aiMove = gameData.gameType.v.getAIMove(ai, false);
                }
                else
                {
                    // Debug.LogError ("Why gameData, ai null");
                }
            }
            else
            {
                // Debug.LogError ("data null: " + this);
            }
            // Finish
            isDone = true;
        }
    }

    private Routine findAIRoutine;

    #region thread

    private Thread newThread = null;

    private void destroyNewThread()
    {
        /*if (newThread != null) {
			if (newThread.IsAlive) {
				Debug.LogError ("delete new thread");
				newThread.Abort ();
				newThread = null;
				AIController.startEnd ();
			}
		}*/
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        destroyNewThread();
    }

    #endregion

    public IEnumerator TaskFindAIMove()
    {
        // TODO Co nen cho cai nay ko nhi?
        yield return new Wait(0.5f);
        Work w = new Work();
        {
            w.data = this.data;
            w.isDone = false;
            // startThread
            {
                // ThreadPool.QueueUserWorkItem(w => w.DoWork());

                ThreadStart threadDelegate = new ThreadStart(w.DoWork);
                // remove old thread
                destroyNewThread();
                // find stackSize
                int stackSize = Global.ThreadSize;
                {
                    // find gameType
                    GameType gameType = null;
                    {
                        // find gameData
                        GameData gameData = null;
                        {
                            Game game = this.data.findDataInParent<Game>();
                            if (game != null)
                            {
                                gameData = game.gameData.v;
                            }
                            else
                            {
                                Debug.LogError("Why game null");
                            }
                        }
                        // process
                        if (gameData != null)
                        {
                            gameType = gameData.gameType.v;
                        }
                        else
                        {
                            Debug.LogError("gameData null");
                        }
                    }
                    // process
                    if (gameType != null)
                    {
                        stackSize = gameType.getStackSize();
                    }
                    else
                    {
                        Debug.LogError("gameType null");
                    }
                }
                // make new thread
                newThread = (stackSize > 0) ? new Thread(threadDelegate, stackSize) : new Thread(threadDelegate);
                newThread.Start();
            }
        }
        // Wait
        while (!w.isDone)
        {
            yield return new Wait(1f);
        }
        // check is playing
        {
            while (!Game.IsPlaying(this.data))
            {
                // game is paused, not send
                yield return new Wait(1f);
            }
        }
        if (w.aiMove.getType() == GameMove.Type.None)
        {
            Debug.LogWarning("why cannot find a game move: " + this);
        }
        // Send
        if (this.data != null)
        {
            // Find ClientInput
            ClientInput clientInput = null;
            {
                WaitInputAction waitInputAction = this.data.findDataInParent<WaitInputAction>();
                if (waitInputAction != null)
                {
                    clientInput = waitInputAction.clientInput.v;
                }
                else
                {
                    Debug.LogError("waitInputAction null: " + this);
                }
            }
            // Process
            if (clientInput != null)
            {
                clientInput.makeSend(w.aiMove);
            }
            else
            {
                Debug.LogError("clientInput null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    #endregion

    #region implement callBacks

    private bool haveChange = false;

    private WaitAIInput waitAIInput = null;
    private Game game = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is WaitAIInputSearch)
        {
            WaitAIInputSearch search = data as WaitAIInputSearch;
            // Parent
            {
                DataUtils.addParentCallBack(search, this, ref this.waitAIInput);
                DataUtils.addParentCallBack(search, this, ref this.game);
            }
            dirty = true;
            return;
        }
        // Parent
        {
            if (data is WaitAIInput)
            {
                dirty = true;
                return;
            }
            // Game
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
                    // GameType
                    {
                        if (data is GameType)
                        {
                            GameType gameType = data as GameType;
                            {
                                gameType.addCallBackAllChildren(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        {
                            if (Generic.IsAddCallBackInterface<T>())
                            {
                                data.addCallBackAllChildren(this);
                            }
                            dirty = true;
                            return;
                        }
                    }
                }
            }
        }
        // Debug.LogError ("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is WaitAIInputSearch)
        {
            WaitAIInputSearch search = data as WaitAIInputSearch;
            // Parent
            {
                DataUtils.removeParentCallBack(search, this, ref this.waitAIInput);
                DataUtils.removeParentCallBack(search, this, ref this.game);
            }
            this.setDataNull(search);
            return;
        }
        // Parent
        {
            if (data is WaitAIInput)
            {
                return;
            }
            // Game
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
                            gameData.gameType.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // GameType
                    {
                        if (data is GameType)
                        {
                            GameType gameType = data as GameType;
                            {
                                gameType.removeCallBackAllChildren(this);
                            }
                            return;
                        }
                        // Child
                        {
                            if (Generic.IsAddCallBackInterface<T>())
                            {
                                data.removeCallBackAllChildren(this);
                            }
                            return;
                        }
                    }
                }
            }
        }
        // Debug.LogError ("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is WaitAIInputSearch)
        {
            switch ((WaitAIInputSearch.Property)wrapProperty.n)
            {
                case WaitAIInputSearch.Property.state:
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
            if (wrapProperty.p is WaitAIInput)
            {
                switch ((WaitAIInput.Property)wrapProperty.n)
                {
                    case WaitAIInput.Property.userThink:
                        break;
                    case WaitAIInput.Property.reThink:
                        {
                            haveChange = true;
                            dirty = true;
                        }
                        break;
                    case WaitAIInput.Property.sub:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
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
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                                haveChange = true;
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
                                    haveChange = true;
                                }
                                break;
                            case GameData.Property.useRule:
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
                    // GameType
                    {
                        if (wrapProperty.p is GameType)
                        {
                            if (Generic.IsAddCallBackInterface<T>())
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                            }
                            dirty = true;
                            haveChange = true;
                            return;
                        }
                        // Child
                        {
                            if (Generic.IsAddCallBackInterface<T>())
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                            }
                            dirty = true;
                            haveChange = true;
                            return;
                        }
                    }
                }
            }
        }
        // Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}