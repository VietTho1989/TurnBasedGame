using UnityEngine;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class WaitAIInputSolvedUpdate : UpdateBehavior<WaitAIInputSolved>
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
                        this.data.state.v = WaitAIInputSolved.State.Search;
                    }
                }
                // Task
                switch (this.data.state.v)
                {
                    case WaitAIInputSolved.State.Search:
                        {
                            destroyRoutine(getSolvedRoutine);
                            this.data.state.v = WaitAIInputSolved.State.Searching;
                        }
                        break;
                    case WaitAIInputSolved.State.Searching:
                        {
                            startRoutine(ref this.getSolvedRoutine, TaskGetSolvedMove());
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

    #region rountine

    class Work
    {

        public WaitAIInputSolved data = null;

        public GameMove solvedMove = new NonMove();

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
                    solvedMove = gameData.gameType.v.getSolvedMove();
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
            System.Threading.Thread.Sleep(1000);
            isDone = true;
        }
    }

    static void DoWork(object work)
    {
        if (work is Work)
        {
            ((Work)work).DoWork();
        }
        else
        {
            Debug.LogError("why not work: " + work);
        }
    }

    private Routine getSolvedRoutine;

    public IEnumerator TaskGetSolvedMove()
    {
        Work w = new Work();
        {
            w.data = this.data;
            w.isDone = false;
            // startThread
            {
                /*ThreadStart threadDelegate = new ThreadStart(w.DoWork);
                Thread newThread = new Thread(threadDelegate);
                newThread.Start();*/
                ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), w);
            }
        }
        // Wait
        {
            while (!w.isDone)
            {
                yield return new Wait(1f);
            }
        }
        if (w.solvedMove != null)
        {
            if (w.solvedMove.getType() == GameMove.Type.None)
            {
                Debug.LogWarning("why cannot find a game move: " + this);
            }
            // Send
            if (this.data != null)
            {
                WaitInputAction waitInputAction = this.data.findDataInParent<WaitInputAction>();
                if (waitInputAction != null)
                {
                    uint userId = 0;
                    {
                        WaitAIInput waitAIInput = this.data.findDataInParent<WaitAIInput>();
                        if (waitAIInput != null)
                        {
                            userId = waitAIInput.userThink.v;
                        }
                        else
                        {
                            Debug.LogError("waitAIInput null: " + this);
                        }
                    }
                    waitInputAction.sendInput(userId, w.solvedMove, 1);
                }
                else
                {
                    Debug.LogError("waitInputAction null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
        else
        {
            Debug.LogError("error, don't have solved move");
        }
    }

    #endregion

    #region implement callBacks

    private bool haveChange = false;

    public override void onAddCallBack<T>(T data)
    {
        if (data is WaitAIInputSolved)
        {
            dirty = true;
            haveChange = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is WaitAIInputSolved)
        {
            WaitAIInputSolved waitAIInputSolved = data as WaitAIInputSolved;
            // Child
            {

            }
            this.setDataNull(waitAIInputSolved);
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
        if (wrapProperty.p is WaitAIInputSolved)
        {
            switch ((WaitAIInputSolved.Property)wrapProperty.n)
            {
                case WaitAIInputSolved.Property.state:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}