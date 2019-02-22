using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawUpdate : UpdateBehavior<RequestDraw>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
                HashSet<uint> whoCanAsks = this.data.getWhoCanAsk();
                // update human
                {
                    // get old
                    List<Human> oldHumans = new List<Human>();
                    {
                        oldHumans.AddRange(this.data.whoCanAsks.vs);
                    }
                    // Update
                    {
                        foreach (uint userId in whoCanAsks)
                        {
                            // find Human
                            Human human = null;
                            {
                                // find old
                                if (oldHumans.Count > 0)
                                {
                                    human = oldHumans[0];
                                }
                                // make new
                                if (human == null)
                                {
                                    human = new Human();
                                    {
                                        human.uid = this.data.whoCanAsks.makeId();
                                    }
                                    this.data.whoCanAsks.add(human);
                                }
                                else
                                {
                                    oldHumans.Remove(human);
                                }
                            }
                            // Update
                            {
                                human.playerId.v = userId;
                            }
                        }
                    }
                    // Remove old
                    foreach (Human oldHuman in oldHumans)
                    {
                        this.data.whoCanAsks.remove(oldHuman);
                    }
                }
            } else {
				Debug.LogError ("requestDraw null");
			}
		}	
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

    #endregion

    #region implement callBacks

    private RoomCheckChangeAdminChange<RequestDraw> roomCheckChangeAdminChange = new RoomCheckChangeAdminChange<RequestDraw>();
    private GameCheckPlayerChange<RequestDraw> gameCheckPlayerChange = new GameCheckPlayerChange<RequestDraw>();

	public override void onAddCallBack<T> (T data)
	{
		if (data is RequestDraw) {
			RequestDraw requestDraw = data as RequestDraw;
			// CheckChange
			{
                // admin
                {
                    roomCheckChangeAdminChange.addCallBack(this);
                    roomCheckChangeAdminChange.setData(requestDraw);
                }
                // players
                {
                    gameCheckPlayerChange.addCallBack(this);
                    gameCheckPlayerChange.setData(requestDraw);
                }
            }
			// Child
			{
				requestDraw.state.allAddCallBack (this);
                requestDraw.whoCanAsks.allAddCallBack(this);
			}
			dirty = true;
			return;
		}
        // CheckChange
        {
            if(data is RoomCheckChangeAdminChange<RequestDraw>)
            {
                dirty = true;
                return;
            }
            if(data is GameCheckPlayerChange<RequestDraw>)
            {
                dirty = true;
                return;
            }
        }
        // Child
        {
            if (data is RequestDraw.State)
            {
                RequestDraw.State state = data as RequestDraw.State;
                // Update
                {
                    switch (state.getType())
                    {
                        case RequestDraw.State.Type.None:
                            {
                                RequestDrawStateNone none = state as RequestDrawStateNone;
                                UpdateUtils.makeUpdate<RequestDrawStateNoneUpdate, RequestDrawStateNone>(none, this.transform);
                            }
                            break;
                        case RequestDraw.State.Type.Ask:
                            {
                                RequestDrawStateAsk ask = state as RequestDrawStateAsk;
                                UpdateUtils.makeUpdate<RequestDrawStateAskUpdate, RequestDrawStateAsk>(ask, this.transform);
                            }
                            break;
                        case RequestDraw.State.Type.Accept:
                            {
                                RequestDrawStateAccept accept = state as RequestDrawStateAccept;
                                UpdateUtils.makeUpdate<RequestDrawStateAcceptUpdate, RequestDrawStateAccept>(accept, this.transform);
                            }
                            break;
                        case RequestDraw.State.Type.Cancel:
                            {
                                RequestDrawStateCancel cancel = state as RequestDrawStateCancel;
                                UpdateUtils.makeUpdate<RequestDrawStateCancelUpdate, RequestDrawStateCancel>(cancel, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + state.getType());
                            break;
                    }
                }
                dirty = true;
                return;
            }
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
        }
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
        if (data is RequestDraw)
        {
            RequestDraw requestDraw = data as RequestDraw;
            // CheckChange
            {
                // admin
                {
                    roomCheckChangeAdminChange.removeCallBack(this);
                    roomCheckChangeAdminChange.setData(null);
                }
                // players
                {
                    gameCheckPlayerChange.removeCallBack(this);
                    gameCheckPlayerChange.setData(null);
                }
            }
            // Child
            {
                requestDraw.state.allRemoveCallBack(this);
                requestDraw.whoCanAsks.allRemoveCallBack(this);
            }
            this.setDataNull(requestDraw);
            return;
        }
        // CheckChange
        {
            if (data is RoomCheckChangeAdminChange<RequestDraw>)
            {
                return;
            }
            if (data is GameCheckPlayerChange<RequestDraw>)
            {
                return;
            }
        }
        // Child
        {
            if (data is RequestDraw.State)
            {
                RequestDraw.State state = data as RequestDraw.State;
                // Update
                {
                    switch (state.getType())
                    {
                        case RequestDraw.State.Type.None:
                            {
                                RequestDrawStateNone none = state as RequestDrawStateNone;
                                none.removeCallBackAndDestroy(typeof(RequestDrawStateNoneUpdate));
                            }
                            break;
                        case RequestDraw.State.Type.Ask:
                            {
                                RequestDrawStateAsk ask = state as RequestDrawStateAsk;
                                ask.removeCallBackAndDestroy(typeof(RequestDrawStateAskUpdate));
                            }
                            break;
                        case RequestDraw.State.Type.Accept:
                            {
                                RequestDrawStateAccept accept = state as RequestDrawStateAccept;
                                accept.removeCallBackAndDestroy(typeof(RequestDrawStateAcceptUpdate));
                            }
                            break;
                        case RequestDraw.State.Type.Cancel:
                            {
                                RequestDrawStateCancel cancel = state as RequestDrawStateCancel;
                                cancel.removeCallBackAndDestroy(typeof(RequestDrawStateCancelUpdate));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + state.getType());
                            break;
                    }
                }
                return;
            }
            if (data is Human)
            {
                Human human = data as Human;
                // Update
                {
                    human.removeCallBackAndDestroy(typeof(HumanUpdate));
                }
                return;
            }
        }
        Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
        if (wrapProperty.p is RequestDraw)
        {
            switch ((RequestDraw.Property)wrapProperty.n)
            {
                case RequestDraw.Property.state:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
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
        // CheckChange
        {
            if (wrapProperty.p is RoomCheckChangeAdminChange<RequestDraw>)
            {
                dirty = true;
                return;
            }
            if (wrapProperty.p is GameCheckPlayerChange<RequestDraw>)
            {
                dirty = true;
                return;
            }
        }
        // Child
        {
            if (wrapProperty.p is RequestDraw.State)
            {
                return;
            }
            if (wrapProperty.p is Human)
            {
                return;
            }
        }
        Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}