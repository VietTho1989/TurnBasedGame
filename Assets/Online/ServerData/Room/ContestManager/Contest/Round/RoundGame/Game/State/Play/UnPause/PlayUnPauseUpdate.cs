using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace GameState
{
    public class PlayUnPauseUpdate : UpdateBehavior<PlayUnPause>
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
                        // Chuyen sang normal
                        Play play = this.data.findDataInParent<Play>();
                        if (play != null)
                        {
                            PlayNormal playNormal = new PlayNormal();
                            {
                                playNormal.uid = play.sub.makeId();
                            }
                            play.sub.v = playNormal;
                        }
                        else
                        {
                            Debug.LogError("play null: " + this);
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

        #region implment callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is PlayUnPause)
            {
                PlayUnPause playUnPause = data as PlayUnPause;
                // Child
                {
                    playUnPause.human.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is Human)
            {
                Human human = data as Human;
                // Update
                {
                    UpdateUtils.makeUpdate<HumanUpdate, Human>(human, this.transform);
                }
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is PlayUnPause)
            {
                PlayUnPause playUnPause = data as PlayUnPause;
                // Child
                {
                    playUnPause.human.allRemoveCallBack(this);
                }
                this.setDataNull(playUnPause);
                return;
            }
            // Child
            if (data is Human)
            {
                Human human = data as Human;
                // Update
                {
                    human.removeCallBackAndDestroy(typeof(HumanUpdate));
                }
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
            if (wrapProperty.p is PlayUnPause)
            {
                switch ((PlayUnPause.Property)wrapProperty.n)
                {
                    case PlayUnPause.Property.human:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case PlayUnPause.Property.time:
                        dirty = true;
                        break;
                    case PlayUnPause.Property.duration:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            if (wrapProperty.p is Human)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}