using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeBlindFoldStateAskUpdate : UpdateBehavior<RequestChangeBlindFoldStateAsk>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // get who canAsk
                HashSet<uint> whoCanAsks = new HashSet<uint>();
                {
                    RequestChangeBlindFold requestChangeBlindFold = this.data.findDataInParent<RequestChangeBlindFold>();
                    if (requestChangeBlindFold != null)
                    {
                        foreach (Human human in requestChangeBlindFold.whoCanAsks.vs)
                        {
                            whoCanAsks.Add(human.playerId.v);
                        }
                    }
                    else
                    {
                        Debug.LogError("requestChangeBlindFold null: " + this);
                    }
                }
                // process
                if (whoCanAsks.Count > 0)
                {
                    // remove who cannot ask
                    for (int i = this.data.accepts.vs.Count - 1; i >= 0; i--)
                    {
                        if (!whoCanAsks.Contains(this.data.accepts.vs[i]))
                        {
                            Debug.LogError("not contains: " + this.data.accepts.vs[i]);
                            this.data.accepts.removeAt(i);
                        }
                    }
                    if (this.data.accepts.vs.Count > 0)
                    {
                        // check all accept
                        bool allAccept = true;
                        {
                            foreach (uint userId in whoCanAsks)
                            {
                                if (!this.data.accepts.vs.Contains(userId))
                                {
                                    allAccept = false;
                                    break;
                                }
                            }
                        }
                        // process
                        if (allAccept)
                        {
                            // change blindfold
                            {
                                GameData gameData = this.data.findDataInParent<GameData>();
                                if (gameData != null)
                                {
                                    gameData.blindFold.v = !gameData.blindFold.v;
                                }
                                else
                                {
                                    Debug.LogError("gameData null: " + this);
                                }
                            }
                            // change state
                            {
                                RequestChangeBlindFold requestChangeBlindFold = this.data.findDataInParent<RequestChangeBlindFold>();
                                if (requestChangeBlindFold != null)
                                {
                                    RequestChangeBlindFoldStateNone none = new RequestChangeBlindFoldStateNone();
                                    {
                                        none.uid = requestChangeBlindFold.state.makeId();
                                    }
                                    requestChangeBlindFold.state.v = none;
                                }
                                else
                                {
                                    Debug.LogError("requestChangeBlindFold null: " + this);
                                }
                            }
                        }
                    }
                    else
                    {
                        // nobody accept
                        RequestChangeBlindFold requestChangeBlindFold = this.data.findDataInParent<RequestChangeBlindFold>();
                        if (requestChangeBlindFold != null)
                        {
                            RequestChangeBlindFoldStateNone none = new RequestChangeBlindFoldStateNone();
                            {
                                none.uid = requestChangeBlindFold.state.makeId();
                            }
                            requestChangeBlindFold.state.v = none;
                        }
                        else
                        {
                            Debug.LogError("requestChangeBlindFold null: " + this);
                        }
                    }
                }
                else
                {
                    // nobody can ask
                    RequestChangeBlindFold requestChangeBlindFold = this.data.findDataInParent<RequestChangeBlindFold>();
                    if (requestChangeBlindFold != null)
                    {
                        RequestChangeBlindFoldStateNone none = new RequestChangeBlindFoldStateNone();
                        {
                            none.uid = requestChangeBlindFold.state.makeId();
                        }
                        requestChangeBlindFold.state.v = none;
                    }
                    else
                    {
                        Debug.LogError("requestChangeBlindFold null: " + this);
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
        return true;
    }

    #endregion

    #region implement callBacks

    private RequestChangeBlindFold requestChangeBlindFold = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is RequestChangeBlindFoldStateAsk)
        {
            RequestChangeBlindFoldStateAsk ask = data as RequestChangeBlindFoldStateAsk;
            // Parent
            {
                DataUtils.addParentCallBack(ask, this, ref this.requestChangeBlindFold);
            }
            dirty = true;
            return;
        }
        // Parent
        {
            if (data is RequestChangeBlindFold)
            {
                RequestChangeBlindFold requestChangeBlindFold = data as RequestChangeBlindFold;
                // Child
                {
                    requestChangeBlindFold.whoCanAsks.allAddCallBack(this);
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
        if (data is RequestChangeBlindFoldStateAsk)
        {
            RequestChangeBlindFoldStateAsk ask = data as RequestChangeBlindFoldStateAsk;
            // Parent
            {
                DataUtils.removeParentCallBack(ask, this, ref this.requestChangeBlindFold);
            }
            this.setDataNull(ask);
            return;
        }
        // Parent
        {
            if (data is RequestChangeBlindFold)
            {
                RequestChangeBlindFold requestChangeBlindFold = data as RequestChangeBlindFold;
                // Child
                {
                    requestChangeBlindFold.whoCanAsks.allRemoveCallBack(this);
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
        if (wrapProperty.p is RequestChangeBlindFoldStateAsk)
        {
            switch ((RequestChangeBlindFoldStateAsk.Property)wrapProperty.n)
            {
                case RequestChangeBlindFoldStateAsk.Property.accepts:
                    dirty = true;
                    break;
                default:
                    break;
            }
            return;
        }
        // Parent
        {
            if (wrapProperty.p is RequestChangeBlindFold)
            {
                switch ((RequestChangeBlindFold.Property)wrapProperty.n)
                {
                    case RequestChangeBlindFold.Property.state:
                        break;
                    case RequestChangeBlindFold.Property.whoCanAsks:
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