using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace GameState
{
    public class StartNormalUpdate : UpdateBehavior<StartNormal>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    if (this.data.time.v > this.data.duration.v)
                    {
                        Game game = this.data.findDataInParent<Game>();
                        if (game != null)
                        {
                            Play play = new Play();
                            {
                                play.uid = game.state.makeId();
                                // sub: de default normal
                            }
                            game.state.v = play;
                        }
                        else
                        {
                            Debug.LogError("game null: " + this);
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
            return false;
        }

        #endregion

        #region Task

        private Routine timeRoutine;

        void Awake()
        {
            if (Routine.IsNull(timeRoutine))
            {
                timeRoutine = CoroutineManager.StartCoroutine(updateTime(), this.gameObject);
            }
            else
            {
                Debug.LogError("Why routine != null");
            }
        }

        public override List<Routine> getRoutineList()
        {
            List<Routine> ret = new List<Routine>();
            {
                ret.Add(timeRoutine);
            }
            return ret;
        }

        public IEnumerator updateTime()
        {
            while (true)
            {
                yield return new Wait(1f);
                if (this.data != null)
                {
                    this.data.time.v = this.data.time.v + 1f;
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is StartNormal)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is StartNormal)
            {
                StartNormal startNormal = data as StartNormal;
                {

                }
                this.setDataNull(startNormal);
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
            if (wrapProperty.p is StartNormal)
            {
                switch ((StartNormal.Property)wrapProperty.n)
                {
                    case StartNormal.Property.time:
                        dirty = true;
                        break;
                    case StartNormal.Property.duration:
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
}