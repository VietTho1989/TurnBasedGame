using UnityEngine;
using System;
using System.Threading;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace Record
{
    public class SaveRecordTask : UpdateBehavior<SaveRecordTask.TaskData>
    {

        #region TaskData

        public class TaskData : Data
        {

            public DataRecord dataRecord = null;

            public FileInfo file = null;

            #region State

            public enum State
            {
                None,
                Save,
                Success,
                Fail
            }

            public VP<State> state;

            #endregion

            #region Constructor

            public enum Property
            {
                state
            }

            public TaskData() : base()
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
                    switch (this.data.state.v)
                    {
                        case TaskData.State.None:
                            {
                                destroyRoutine(saveRoutine);
                            }
                            break;
                        case TaskData.State.Save:
                            {
                                startRoutine(ref this.saveRoutine, TaskSave());
                            }
                            break;
                        case TaskData.State.Success:
                            {
                                destroyRoutine(saveRoutine);
                            }
                            break;
                        case TaskData.State.Fail:
                            {
                                destroyRoutine(saveRoutine);
                            }
                            break;
                        default:
                            Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
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
            return true;
        }

        #endregion

        #region Routine Save

        private Routine saveRoutine;

        public override List<Routine> getRoutineList()
        {
            List<Routine> ret = new List<Routine>();
            {
                ret.Add(saveRoutine);
            }
            return ret;
        }

        private class Work
        {

            public TaskData data = null;

            public bool isDone = false;
            public bool success = false;

            public void DoWork()
            {
                // Save and compress
                if (this.data != null)
                {
                    if (this.data.dataRecord != null)
                    {
                        byte[] byteArray;
                        using (MemoryStream memStream = new MemoryStream())
                        {
                            using (BinaryWriter writer = new BinaryWriter(memStream))
                            {
                                this.data.dataRecord.makeBinary(writer);
                                // write to byteArray
                                byteArray = memStream.ToArray();
                                Debug.LogError("makeBinary: " + byteArray.Length);
                            }
                        }
                        // Compress
                        {
                            byte[] outByte = null;
                            if (lbz2.bz2CompressBuffer(byteArray, ref outByte, 9, true))
                            {
                                Debug.LogError("compress success: " + byteArray.Length + ", " + outByte.Length);
                                File.WriteAllBytes(this.data.file.FullName, outByte);
                                success = true;
                            }
                            else
                            {
                                Debug.LogError("compress fail");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("save null: " + this.data.dataRecord);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
                isDone = true;
            }

        }

        public IEnumerator TaskSave()
        {
            if (this.data != null)
            {
                Work w = new Work();
                // Task
                {
                    w.data = this.data;
                    w.isDone = false;
                    w.success = false;
                    // startThread
                    ThreadStart threadDelegate = new ThreadStart(w.DoWork);
                    new Thread(threadDelegate).Start();
                    // Wait
                    while (!w.isDone)
                    {
                        yield return new Wait(1f);
                    }
                }
                // Process
                if (w.success)
                {
                    Debug.LogError("save success");
                    Toast.showMessage("save success");
                    this.data.state.v = TaskData.State.Success;
                }
                else
                {
                    Debug.LogError("save fail");
                    Toast.showMessage("save fail");
                    this.data.state.v = TaskData.State.Fail;
                }
            }
            else
            {
                Debug.LogError("inputData null");
            }
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is TaskData)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is TaskData)
            {
                TaskData taskData = data as TaskData;
                // Child
                {

                }
                this.setDataNull(taskData);
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
            if (wrapProperty.p is TaskData)
            {
                switch ((TaskData.Property)wrapProperty.n)
                {
                    case TaskData.Property.state:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}