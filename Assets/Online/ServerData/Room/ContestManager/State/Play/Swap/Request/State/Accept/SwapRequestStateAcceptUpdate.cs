using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace GameManager.Match.Swap
{
    public class SwapRequestStateAcceptUpdate : UpdateBehavior<SwapRequestStateAccept>
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
                        // remove
                        Swap swap = this.data.findDataInParent<Swap>();
                        if (swap != null)
                        {
                            SwapRequest swapRequest = this.data.findDataInParent<SwapRequest>();
                            if (swapRequest != null)
                            {
                                swap.swapRequests.remove(swapRequest);
                            }
                            else
                            {
                                Debug.LogError("swapRequest null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("swap null: " + this);
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

        private Routine time;

        void Awake()
        {
            startRoutine(ref this.time, TaskUpdateTime());
        }

        public IEnumerator TaskUpdateTime()
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

        public override List<Routine> getRoutineList()
        {
            List<Routine> ret = new List<Routine>();
            {
                ret.Add(time);
            }
            return ret;
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is SwapRequestStateAccept)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is SwapRequestStateAccept)
            {
                SwapRequestStateAccept swapRequestStateAccept = data as SwapRequestStateAccept;
                // Child
                {

                }
                this.setDataNull(swapRequestStateAccept);
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
            if (wrapProperty.p is SwapRequestStateAccept)
            {
                switch ((SwapRequestStateAccept.Property)wrapProperty.n)
                {
                    case SwapRequestStateAccept.Property.time:
                        dirty = true;
                        break;
                    case SwapRequestStateAccept.Property.duration:
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