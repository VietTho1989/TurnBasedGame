using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace FileSystem
{
    public class ActionEditFailUpdate : UpdateBehavior<ActionEditFail>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    if (this.data.time.v >= this.data.duration.v)
                    {
                        // change to actionNone
                        FileSystemBrowser fileSystemBrowser = this.data.findDataInParent<FileSystemBrowser>();
                        if (fileSystemBrowser != null)
                        {
                            ActionNone actionNone = new ActionNone();
                            {
                                actionNone.uid = fileSystemBrowser.action.makeId();
                                actionNone.selectFiles.vs.AddRange(this.data.successFiles.vs);
                            }
                            fileSystemBrowser.action.v = actionNone;
                        }
                        else
                        {
                            Debug.LogError("fileSystemBrowser null: " + this);
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

        private Routine timeCoroutine;

        void Awake()
        {
            if (Routine.IsNull(timeCoroutine))
            {
                timeCoroutine = CoroutineManager.StartCoroutine(updateTime(), this.gameObject);
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
                ret.Add(timeCoroutine);
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
                    this.data.time.v = this.data.time.v + 1;
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
            if (data is ActionEditFail)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is ActionEditFail)
            {
                ActionEditFail actionEditFail = data as ActionEditFail;
                // Child
                {

                }
                this.setDataNull(actionEditFail);
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
            if (wrapProperty.p is ActionEditFail)
            {
                switch ((ActionEditFail.Property)wrapProperty.n)
                {
                    case ActionEditFail.Property.failFile:
                        break;
                    case ActionEditFail.Property.time:
                        dirty = true;
                        break;
                    case ActionEditFail.Property.duration:
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