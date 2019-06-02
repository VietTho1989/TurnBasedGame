using UnityEngine;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace Rubiks
{
    /**
     * solve problem in different thread
     * */
    public class RubiksUpdate : UpdateBehavior<Rubiks>
    {

        #region UpdateData

        public class UpdateData : Data
        {

            #region State

            public enum State
            {
                None,
                Solve,
                Finish
            }

            public VP<State> state;

            #endregion

            #region Constructor

            public enum Property
            {
                state
            }

            public UpdateData() : base()
            {
                this.state = new VP<State>(this, (byte)Property.state, State.None);
            }

            #endregion

        }

        #endregion

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // check lastMoveId
                    {
                        if (this.data.lastMoveId.v != this.lastMoveId)
                        {
                            // needReset = true;
                        }
                    }
                    // reset
                    if (needReset)
                    {
                        this.cube = null;
                        updateData.state.v = UpdateData.State.None;
                        lastMoveId = 0;
                        needReset = false;
                    }
                    // Task
                    {
                        switch (updateData.state.v)
                        {
                            case UpdateData.State.None:
                                {
                                    destroyRoutine(solveRoutine);
                                }
                                break;
                            case UpdateData.State.Solve:
                                {
                                    startRoutine(ref solveRoutine, TaskSolve());
                                }
                                break;
                            case UpdateData.State.Finish:
                                {
                                    destroyRoutine(solveRoutine);
                                }
                                break;
                            default:
                                Debug.LogError("unknown state: " + updateData.state.v);
                                break;
                        }
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
            return false;
        }

        public UpdateData updateData = new UpdateData();

        void Awake()
        {
            updateData.addCallBack(this);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            updateData.removeCallBack(this);
        }

        #endregion

        #region Task get ai move

        public int lastMoveId = 0;
        public Cubenxn cube = null;

        public Routine solveRoutine;

        private class Work
        {

            public bool isDone = false;

            public Cubenxn data;

            public void DoWork()
            {
                if (data != null)
                {
                    data.solveCube(data);
                }
                else
                {
                    Debug.LogError("data null");
                }
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

        public IEnumerator TaskSolve()
        {
            if (this.data != null)
            {
                Work w = new Work();
                // Task
                {
                    // lastMoveId
                    {
                        while (lastMoveId != 0)
                        {
                            lastMoveId = Common.random.Next();
                        }
                        updateData.state.v = UpdateData.State.Solve;
                    }
                    // data
                    this.cube = Rubiks.convertToCube(this.data);
                    w.data = this.cube;
                    // start thread
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), w);
                    }
                    // Wait
                    while (!w.isDone)
                    {
                        yield return new Wait();
                    }
                    updateData.state.v = UpdateData.State.Finish;
                }
            }
            else
            {
                Debug.LogError("data null: chuyen sang state Show: " + this);
                updateData.state.v = UpdateData.State.None;
            }
        }

        public override List<Routine> getRoutineList()
        {
            List<Routine> ret = new List<Routine>();
            {
                ret.Add(solveRoutine);
            }
            return ret;
        }

        #endregion

        #region implement callBacks

        public bool needReset = false;

        public override void onAddCallBack<T>(T data)
        {
            if(data is UpdateData)
            {
                dirty = true;
                return;
            }
            if(data is Rubiks)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UpdateData)
            {
                return;
            }
            if (data is Rubiks)
            {
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
            if (wrapProperty.p is UpdateData)
            {
                switch ((UpdateData.Property)wrapProperty.n)
                {
                    case UpdateData.Property.state:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is Rubiks)
            {
                switch ((Rubiks.Property)wrapProperty.n)
                {
                    case Rubiks.Property.faces:
                        break;
                    case Rubiks.Property.dimension:
                        break;
                    case Rubiks.Property.lastMoveId:
                        break;
                    case Rubiks.Property.lastMoveIndex:
                        break;
                    case Rubiks.Property.canFinish:
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
}