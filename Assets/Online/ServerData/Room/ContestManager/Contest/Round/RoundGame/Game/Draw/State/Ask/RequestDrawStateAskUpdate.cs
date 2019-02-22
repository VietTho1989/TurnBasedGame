using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestDrawStateAskUpdate : UpdateBehavior<RequestDrawStateAsk>
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
                    // get who can ask
                    HashSet<uint> whoCanAsks = requestDraw.getWhoCanAsk();
                    // process
                    if (whoCanAsks != null && whoCanAsks.Count > 0)
                    {
                        // remove who cannot asks
                        {
                            // accepts
                            for (int i = this.data.accepts.vs.Count - 1; i >= 0; i--)
                            {
                                if (!whoCanAsks.Contains(this.data.accepts.vs[i]))
                                {
                                    this.data.accepts.removeAt(i);
                                }
                            }
                            // refuses
                            for (int i = this.data.refuses.vs.Count - 1; i >= 0; i--)
                            {
                                if (!whoCanAsks.Contains(this.data.refuses.vs[i]))
                                {
                                    this.data.refuses.removeAt(i);
                                }
                            }
                        }
                        // answer
                        if (this.data.refuses.vs.Count > 0)
                        {
                            // chuyen sang cancel
                            RequestDrawStateCancel cancel = new RequestDrawStateCancel();
                            {
                                cancel.uid = requestDraw.state.makeId();
                            }
                            requestDraw.state.v = cancel;
                        }
                        else
                        {
                            // check all accept
                            bool isAllAccept = true;
                            {
                                foreach(uint userId in whoCanAsks)
                                {
                                    if (!this.data.accepts.vs.Contains(userId))
                                    {
                                        isAllAccept = false;
                                        break;
                                    }
                                }
                            }
                            // process
                            if (isAllAccept)
                            {
                                // chuyen sang accept
                                RequestDrawStateAccept accept = new RequestDrawStateAccept();
                                {
                                    accept.uid = requestDraw.state.makeId();
                                }
                                requestDraw.state.v = accept;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("Don't have who can ask");
                    }
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

    private RequestDraw requestDraw = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is RequestDrawStateAsk)
        {
            RequestDrawStateAsk ask = data as RequestDrawStateAsk;
            // Parent
            {
                DataUtils.addParentCallBack(ask, this, ref this.requestDraw);
            }
            dirty = true;
            return;
        }
        // Parent
        {
            if (data is RequestDraw)
            {
                RequestDraw requestDraw = data as RequestDraw;
                // Child
                {
                    requestDraw.whoCanAsks.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if(data is Human)
            {
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is RequestDrawStateAsk)
        {
            RequestDrawStateAsk ask = data as RequestDrawStateAsk;
            // Parent
            {
                DataUtils.removeParentCallBack(ask, this, ref this.requestDraw);
            }
            this.setDataNull(ask);
            return;
        }
        // Parent
        {
            if (data is RequestDraw)
            {
                RequestDraw requestDraw = data as RequestDraw;
                // Child
                {
                    requestDraw.whoCanAsks.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            if (data is Human)
            {
                return;
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
        if (wrapProperty.p is RequestDrawStateAsk)
        {
            switch ((RequestDrawStateAsk.Property)wrapProperty.n)
            {
                case RequestDrawStateAsk.Property.accepts:
                    dirty = true;
                    break;
                case RequestDrawStateAsk.Property.refuses:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Parent
        {
            if (wrapProperty.p is RequestDraw)
            {
                switch ((RequestDraw.Property)wrapProperty.n)
                {
                    case RequestDraw.Property.state:
                        break;
                    case RequestDraw.Property.whoCanAsks:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
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
            if (wrapProperty.p is Human)
            {
                Human.onUpdateSyncPlayerIdChange(wrapProperty, this);
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}