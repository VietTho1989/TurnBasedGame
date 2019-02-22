using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestDrawStateAcceptUpdate : UpdateBehavior<RequestDrawStateAccept>
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
                            this.data.accepts.clear();
                            this.data.refuses.clear();
                        }
                        else
                        {
                            // check all accept
                            bool isAllAccept = true;
                            {
                                foreach (uint userId in whoCanAsks)
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
                                // chuyen sang none
                                RequestDrawStateNone none = new RequestDrawStateNone();
                                {
                                    none.uid = requestDraw.state.makeId();
                                }
                                requestDraw.state.v = none;
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
        if (data is RequestDrawStateAccept)
        {
            RequestDrawStateAccept accept = data as RequestDrawStateAccept;
            // Parent
            {
                DataUtils.addParentCallBack(accept, this, ref this.requestDraw);
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
            if (data is Human)
            {
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is RequestDrawStateAccept)
        {
            RequestDrawStateAccept accept = data as RequestDrawStateAccept;
            // Parent
            {
                DataUtils.removeParentCallBack(accept, this, ref this.requestDraw);
            }
            this.setDataNull(accept);
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
        if (wrapProperty.p is RequestDrawStateAccept)
        {
            switch ((RequestDrawStateAccept.Property)wrapProperty.n)
            {
                case RequestDrawStateAccept.Property.accepts:
                    dirty = true;
                    break;
                case RequestDrawStateAccept.Property.refuses:
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