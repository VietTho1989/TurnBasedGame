using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
    public class GlobalDataRecordController : MonoBehaviour, ValueChangeCallBack
    {

        #region updateData

        public class UpdateData : Data
        {

            #region dataRecordTasks

            public LP<ReferenceData<DataRecordTask>> dataRecordTasks;

            public DataRecordTask find(Data needRecordData)
            {
                DataRecordTask ret = null;
                {
                    foreach(ReferenceData<DataRecordTask> referenceDataRecordTask in this.dataRecordTasks.vs)
                    {
                        DataRecordTask dataRecordTask = referenceDataRecordTask.data;
                        if (dataRecordTask != null)
                        {
                            if (dataRecordTask.needRecordData.v.data == needRecordData)
                            {
                                ret = dataRecordTask;
                                break;
                            }
                        }
                        else
                        {
                            Debug.LogError("dataRecordTask null");
                        }
                    }
                }
                return ret;
            }

            #endregion

            #region Constructor

            public enum Property
            {
                dataRecordTasks
            }

            public UpdateData() : base()
            {
                this.dataRecordTasks = new LP<ReferenceData<DataRecordTask>>(this, (byte)Property.dataRecordTasks);
            }

            #endregion

            #region singleton

            private static UpdateData instance;

            static UpdateData()
            {
                instance = new UpdateData();
            }

            public static UpdateData get()
            {
                return instance;
            }

            #endregion

        }

        #endregion

        #region LifeCycle

        void Awake()
        {
            UpdateData.get().addCallBack(this);
        }

        void OnDestroy()
        {
            UpdateData.get().removeCallBack(this);
        }

        void Update()
        {
            for (int i = UpdateData.get().dataRecordTasks.vs.Count - 1; i >= 0; i--)
            {
                DataRecordTask dataRecordTask = UpdateData.get().dataRecordTasks.vs[i].data;
                // find need keep
                bool needKeep = true;
                {
                    Data needRecordData = dataRecordTask.needRecordData.v.data;
                    if (needRecordData == null)
                    {
                        Debug.LogError("needRecordData null");
                        needKeep = false;
                    }
                    else
                    {
                        if (!needRecordData.isHaveRoot())
                        {
                            Debug.LogError("needRecordData don't have root: " + needRecordData);
                            needKeep = false;
                        }
                    }
                }
                // process
                if (!needKeep)
                {
                    UpdateData.get().dataRecordTasks.removeAt(i);
                }
            }
        }

        #endregion

        #region implement callBacks

        public void onAddCallBack<T>(T data) where T : Data
        {
            if(data is UpdateData)
            {
                UpdateData updateData = data as UpdateData;
                // Child
                {
                    updateData.dataRecordTasks.allAddCallBack(this);
                }
                return;
            }
            // Child
            if (data is DataRecordTask)
            {
                DataRecordTask dataRecordTask = data as DataRecordTask;
                // Update
                {
                    UpdateUtils.makeUpdate<DataRecordTaskUpdate, DataRecordTask>(dataRecordTask, this.transform);
                }
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
        {
            if (data is UpdateData)
            {
                UpdateData updateData = data as UpdateData;
                // Child
                {
                    updateData.dataRecordTasks.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            if (data is DataRecordTask)
            {
                DataRecordTask dataRecordTask = data as DataRecordTask;
                // Update
                {
                    dataRecordTask.removeCallBackAndDestroy(typeof(DataRecordTaskUpdate));
                }
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is UpdateData)
            {
                switch ((UpdateData.Property)wrapProperty.n)
                {
                    case UpdateData.Property.dataRecordTasks:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                        }
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            if (wrapProperty.p is DataRecordTask)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}