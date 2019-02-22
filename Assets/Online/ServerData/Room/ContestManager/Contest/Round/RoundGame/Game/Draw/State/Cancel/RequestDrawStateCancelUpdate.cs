using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawStateCancelUpdate : UpdateBehavior<RequestDrawStateCancel>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                RequestDraw requestDraw = this.data.findDataInParent<RequestDraw>();
                if (requestDraw != null)
                {
                    RequestDrawStateNone none = new RequestDrawStateNone();
                    {
                        none.uid = requestDraw.state.makeId();
                    }
                    requestDraw.state.v = none;
                }
                else
                {
                    Debug.LogError("requestDraw null");
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
        return true;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if(data is RequestDrawStateCancel)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if(data is RequestDrawStateCancel)
        {
            RequestDrawStateCancel requestDrawStateCancel = data as RequestDrawStateCancel;
            this.setDataNull(requestDrawStateCancel);
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
        if(wrapProperty.p is RequestDrawStateCancel)
        {
            switch ((RequestDrawStateCancel.Property)wrapProperty.n)
            {
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