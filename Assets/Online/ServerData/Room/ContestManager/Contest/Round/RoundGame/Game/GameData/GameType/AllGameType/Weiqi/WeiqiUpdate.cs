using UnityEngine;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace Weiqi
{
    /**
	 * Class nay lam ko the undoRedo duoc
	 * */
    public class WeiqiUpdate : UpdateBehavior<Weiqi>
    {

        #region UpdateData

        public class UpdateData : Data
        {
            public enum State
            {
                Get,
                Getting,
                Show
            }

            public VP<State> state;

            #region Constructor

            public enum Property
            {
                state
            }

            public UpdateData() : base()
            {
                this.state = new VP<State>(this, (byte)Property.state, State.Show);
            }

            #endregion

        }

        private UpdateData updateData = new UpdateData();

        void Awake()
        {
            // base.Awake ();
            this.updateData.addCallBack(this);
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
                    // Task
                    switch (updateData.state.v)
                    {
                        case UpdateData.State.Get:
                            {
                                destroyRoutine(updateScoreRoutine);
                                updateData.state.v = UpdateData.State.Getting;
                            }
                            break;
                        case UpdateData.State.Getting:
                            {
                                if (Routine.IsNull(updateScoreRoutine))
                                {
                                    updateScoreRoutine = CoroutineManager.StartCoroutine(TaskUpdateScore(), this.gameObject);
                                }
                                else
                                {
                                    // Debug.LogError ("Why routine != null");
                                }
                            }
                            break;
                        case UpdateData.State.Show:
                            {
                                destroyRoutine(updateScoreRoutine);
                                if (haveChange)
                                {
                                    haveChange = false;
                                    updateData.state.v = UpdateData.State.Get;
                                }
                            }
                            break;
                        default:
                            Debug.LogError("unknown state: " + updateData + "; " + this);
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

        #region Task UpdateScore

        private Routine updateScoreRoutine;

        private class Work
        {

            public bool isDone = false;

            public Weiqi data = null;

            public Weiqi newWeiqi = null;

            public void DoWork()
            {
                if (data != null)
                {
                    newWeiqi = Core.unityUpdateScore(this.data, Core.CanCorrect);
                }
                else
                {
                    Debug.LogError("data null");
                }
                isDone = true;
            }

        }

        public IEnumerator TaskUpdateScore()
        {
            if (this.data != null)
            {
                if (GameData.IsUseRule(this.data))
                {
                    Work w = new Work();
                    // Task
                    {
                        // data
                        w.data = this.data;
                        // start thread
                        {
                            ThreadStart threadDelegate = new ThreadStart(w.DoWork);
                            Thread newThread = new Thread(threadDelegate);
                            newThread.Start();
                        }
                        // Wait
                        while (!w.isDone)
                        {
                            yield return new Wait();
                        }
                    }
                    // Update
                    if (w.newWeiqi != null)
                    {
                        // wait until action WaitAction
                        do
                        {
                            bool canChange = false;
                            {
                                Game game = this.data.findDataInParent<Game>();
                                if (game != null)
                                {
                                    GameAction gameAction = game.gameAction.v;
                                    if (gameAction != null)
                                    {
                                        if (gameAction is WaitInputAction)
                                        {
                                            canChange = true;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameAction null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("game null: " + this);
                                }
                            }
                            // TODO Test
                            canChange = true;
                            if (canChange)
                            {
                                DataUtils.copyData(this.data, w.newWeiqi, Weiqi.UpdateScoreNames);
                                // Change state
                                updateData.state.v = UpdateData.State.Show;
                                break;
                            }
                            else
                            {
                                Debug.LogError("Cannot change: " + this);
                                yield return new Wait(0.1f);
                            }
                        } while (true);
                    }
                    else
                    {
                        Debug.LogError("newWeiqi null: " + this);
                        // Change state
                        updateData.state.v = UpdateData.State.Show;
                    }
                }
                else
                {
                    Debug.LogError("not use rule: chuyen sange state show: " + this);
                    updateData.state.v = UpdateData.State.Show;
                }
            }
            else
            {
                Debug.LogError("data null: chuyen sang state Show: " + this);
                updateData.state.v = UpdateData.State.Show;
            }
        }

        public override List<Routine> getRoutineList()
        {
            List<Routine> ret = new List<Routine>();
            {
                ret.Add(updateScoreRoutine);
            }
            return ret;
        }

        #endregion

        #region implement callBacks

        private bool haveChange = false;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UpdateData)
            {
                dirty = true;
                return;
            }
            if (data is Weiqi)
            {
                Weiqi weiqi = data as Weiqi;
                // Child
                {
                    weiqi.b.allAddCallBack(this);
                }
                haveChange = true;
                dirty = true;
                return;
            }
            // Board
            {
                if (data is Board)
                {
                    Board board = data as Board;
                    // Child
                    {
                        board.last_move.allAddCallBack(this);
                        board.last_move2.allAddCallBack(this);
                        board.last_move3.allAddCallBack(this);
                        board.last_move4.allAddCallBack(this);
                        board.gi.allAddCallBack(this);
                        board.symmetry.allAddCallBack(this);
                        board.last_ko.allAddCallBack(this);
                        board.ko.allAddCallBack(this);
                    }
                    haveChange = true;
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is WeiqiMove)
                    {
                        dirty = true;
                        haveChange = true;
                        return;
                    }
                    if (data is Group)
                    {
                        dirty = true;
                        haveChange = true;
                        return;
                    }
                    if (data is BoardSymmetry)
                    {
                        dirty = true;
                        haveChange = true;
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UpdateData)
            {
                return;
            }
            if (data is Weiqi)
            {
                Weiqi weiqi = data as Weiqi;
                // Child
                {
                    weiqi.b.allRemoveCallBack(this);
                }
                this.setDataNull(weiqi);
                return;
            }
            // Board
            {
                if (data is Board)
                {
                    Board board = data as Board;
                    // Child
                    {
                        board.last_move.allRemoveCallBack(this);
                        board.last_move2.allRemoveCallBack(this);
                        board.last_move3.allRemoveCallBack(this);
                        board.last_move4.allRemoveCallBack(this);
                        board.gi.allRemoveCallBack(this);
                        board.symmetry.allRemoveCallBack(this);
                        board.last_ko.allRemoveCallBack(this);
                        board.ko.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is WeiqiMove)
                    {
                        return;
                    }
                    if (data is Group)
                    {
                        return;
                    }
                    if (data is BoardSymmetry)
                    {
                        return;
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
            if (wrapProperty.p is Weiqi)
            {
                switch ((Weiqi.Property)wrapProperty.n)
                {
                    case Weiqi.Property.b:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            haveChange = true;
                            dirty = true;
                        }
                        break;
                    case Weiqi.Property.deadgroup:
                        break;
                    case Weiqi.Property.scoreOwnerMap:
                        break;
                    case Weiqi.Property.scoreOwnerMapSize:
                        break;
                    case Weiqi.Property.scoreBlack:
                        break;
                    case Weiqi.Property.scoreWhite:
                        break;
                    case Weiqi.Property.dame:
                        break;
                    case Weiqi.Property.score:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Board
            {
                if (wrapProperty.p is Board)
                {
                    switch ((Board.Property)wrapProperty.n)
                    {
                        case Board.Property.size:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.size2:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.bits2:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.captures:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.komi:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.handicap:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.rules:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;

                        case Board.Property.moves:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.last_move:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.last_move2:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.last_move3:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.last_move4:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.superko_violation:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;

                        case Board.Property.b:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.g:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.pp:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;

                        case Board.Property.pat3:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;

                        case Board.Property.gi:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                haveChange = true;
                                dirty = true;
                            }
                            break;

                        case Board.Property.c:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.clen:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;

                        case Board.Property.symmetry:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                haveChange = true;
                                dirty = true;
                            }
                            break;

                        case Board.Property.last_ko:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.last_ko_age:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;

                        case Board.Property.ko:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                haveChange = true;
                                dirty = true;
                            }
                            break;

                        case Board.Property.quicked:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;

                        case Board.Property.history_hash:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.hash:
                            {
                                haveChange = true;
                                dirty = true;
                            }
                            break;
                        case Board.Property.qhash:
                            {
                                haveChange = true;
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
                    if (wrapProperty.p is WeiqiMove)
                    {
                        switch ((WeiqiMove.Property)wrapProperty.n)
                        {
                            case WeiqiMove.Property.coord:
                                {
                                    haveChange = true;
                                    dirty = true;
                                }
                                break;
                            case WeiqiMove.Property.color:
                                {
                                    haveChange = true;
                                    dirty = true;
                                }
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    if (wrapProperty.p is Group)
                    {
                        switch ((Group.Property)wrapProperty.n)
                        {
                            case Group.Property.lib:
                                {
                                    haveChange = true;
                                    dirty = true;
                                }
                                break;
                            case Group.Property.libs:
                                {
                                    haveChange = true;
                                    dirty = true;
                                }
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    if (wrapProperty.p is BoardSymmetry)
                    {
                        switch ((BoardSymmetry.Property)wrapProperty.n)
                        {
                            case BoardSymmetry.Property.x1:
                                {
                                    haveChange = true;
                                    dirty = true;
                                }
                                break;
                            case BoardSymmetry.Property.x2:
                                {
                                    haveChange = true;
                                    dirty = true;
                                }
                                break;
                            case BoardSymmetry.Property.y1:
                                {
                                    haveChange = true;
                                    dirty = true;
                                }
                                break;
                            case BoardSymmetry.Property.y2:
                                {
                                    haveChange = true;
                                    dirty = true;
                                }
                                break;
                            case BoardSymmetry.Property.d:
                                {
                                    haveChange = true;
                                    dirty = true;
                                }
                                break;
                            case BoardSymmetry.Property.type:
                                {
                                    haveChange = true;
                                    dirty = true;
                                }
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

        #endregion

    }
}