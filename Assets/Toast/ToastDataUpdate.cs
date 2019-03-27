using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToastDataUpdate : UpdateBehavior<ToastData>
{

    #region Update

    void Update()
    {
        // Debug.LogError ("ToastDataUpdate: " + this);
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                switch (this.data.state.v)
                {
                    case ToastData.State.Normal:
                        {
                            // Find current toast message
                            ToastMessage currentMessage = null;
                            {
                                if (this.data.messages.vs.Count > 0)
                                {
                                    currentMessage = this.data.messages.vs[0];
                                }
                            }
                            // Process
                            if (currentMessage != null)
                            {
                                currentMessage.time.v = currentMessage.time.v + Time.deltaTime;
                                if (currentMessage.time.v >= currentMessage.duration.v)
                                {
                                    // remove message
                                    this.data.messages.remove(currentMessage);
                                    // move to waitNext
                                    this.data.state.v = ToastData.State.WaitNext;
                                }
                            }
                        }
                        break;
                    case ToastData.State.WaitNext:
                        {
                            this.data.state.v = ToastData.State.Normal;
                        }
                        break;
                    default:
                        Debug.LogError("unknown state: " + this.data.state.v);
                        break;
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override void update()
    {

    }

    public override bool isShouldDisableUpdate()
    {
        return false;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is ToastData)
        {
            ToastData toastData = data as ToastData;
            {
                toastData.messages.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        if (data is ToastMessage)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is ToastData)
        {
            ToastData toastData = data as ToastData;
            {
                toastData.messages.allRemoveCallBack(this);
            }
            return;
        }
        if (data is ToastMessage)
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
        if (wrapProperty.p is ToastData)
        {
            switch ((ToastData.Property)wrapProperty.n)
            {
                case ToastData.Property.messages:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case ToastData.Property.maxIndex:
                    break;
                case ToastData.Property.state:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        if (wrapProperty.p is ToastMessage)
        {
            switch ((ToastMessage.Property)wrapProperty.n)
            {
                case ToastMessage.Property.toastIndex:
                    break;
                case ToastMessage.Property.message:
                    break;
                case ToastMessage.Property.time:
                    dirty = true;
                    break;
                case ToastMessage.Property.duration:
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