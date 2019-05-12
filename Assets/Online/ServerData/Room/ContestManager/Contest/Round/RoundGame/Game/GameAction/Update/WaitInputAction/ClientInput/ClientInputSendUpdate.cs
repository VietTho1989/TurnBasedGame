using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class ClientInputSendUpdate : UpdateBehavior<ClientInputSend>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // haveChange
                {
                    if (haveChange)
                    {
                        // Debug.LogError ("have change: resend: " + this);
                        haveChange = false;
                        this.data.state.v = ClientInputSend.State.Send;
                    }
                }
                // Send
                switch (this.data.state.v)
                {
                    case ClientInputSend.State.Send:
                        {
                            destroyRoutine(waitToResend);
                            // Send
                            if (Server.IsServerOnline(this.data))
                            {
                                WaitInputAction waitInputAction = this.data.findDataInParent<WaitInputAction>();
                                if (this.data.gameMove.v != null && this.data.gameMove.v.getType() != GameMove.Type.None)
                                {
                                    if (waitInputAction.inputs.vs.Count == 0)
                                    {
                                        // make inputData
                                        InputData inputData = new InputData();
                                        {
                                            inputData.clientTime.v = this.data.clientTimeSend.v;
                                            inputData.gameMove.v = (GameMove)DataUtils.cloneData(this.data.gameMove.v);
                                            inputData.userSend.v = Server.getProfileUserId(this.data);
                                        }
                                        // send
                                        waitInputAction.requestSendInput(inputData.userSend.v, inputData.gameMove.v, inputData.clientTime.v);
                                        // change state
                                        this.data.state.v = ClientInputSend.State.Sending;
                                    }
                                    else
                                    {
                                        // Debug.LogError ("already have input, not send: " + this);
                                    }
                                }
                                else
                                {
                                    // Debug.LogError ("why inputData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("server not online: " + this);
                            }
                        }
                        break;
                    case ClientInputSend.State.Sending:
                        {
                            if (Server.IsServerOnline(this.data))
                            {
                                startRoutine(ref this.waitToResend, TaskWaitToResend());
                            }
                            else
                            {
                                this.data.state.v = ClientInputSend.State.Send;
                            }
                        }
                        break;
                    default:
                        Debug.LogError("unknown state: " + this.data.state.v);
                        break;
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
                destroyRoutine(waitToResend);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return false;
    }

    #endregion

    #region Task wait to resend

    private Routine waitToResend;

    public IEnumerator TaskWaitToResend()
    {
        if (this.data != null)
        {
            yield return new Wait(5f);
            if (this.data != null)
            {
                this.data.state.v = ClientInputSend.State.Send;
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
            Debug.LogError("resend: " + this);
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public override List<Routine> getRoutineList()
    {
        List<Routine> ret = new List<Routine>();
        {
            ret.Add(waitToResend);
        }
        return ret;
    }

    #endregion

    #region implement callBacks

    private Server server = null;

    private bool haveChange = true;

    private WaitInputAction waitInputAction = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is ClientInputSend)
        {
            ClientInputSend send = data as ClientInputSend;
            // Parent
            {
                DataUtils.addParentCallBack(send, this, ref this.server);
                DataUtils.addParentCallBack(send, this, ref this.waitInputAction);
            }
            // Child
            {
                send.gameMove.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Parent
        {
            // Server
            if (data is Server)
            {
                dirty = true;
                return;
            }
            // WaitInputAction
            if (data is WaitInputAction)
            {
                dirty = true;
                return;
            }
        }
        // Child
        if (data is GameMove)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is ClientInputSend)
        {
            ClientInputSend send = data as ClientInputSend;
            // Parent
            {
                DataUtils.removeParentCallBack(send, this, ref this.server);
                DataUtils.removeParentCallBack(send, this, ref this.waitInputAction);
            }
            // Child
            {
                send.gameMove.allRemoveCallBack(this);
            }
            this.setDataNull(send);
            return;
        }
        // Parent
        {
            // Server
            if (data is Server)
            {
                return;
            }
            // WaitInputAction
            if (data is WaitInputAction)
            {
                return;
            }
        }
        // Child
        if (data is GameMove)
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
        if (wrapProperty.p is ClientInputSend)
        {
            switch ((ClientInputSend.Property)wrapProperty.n)
            {
                case ClientInputSend.Property.state:
                    dirty = true;
                    break;
                case ClientInputSend.Property.gameMove:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                        haveChange = true;
                    }
                    break;
                case ClientInputSend.Property.clientTimeSend:
                    {
                        dirty = true;
                        haveChange = true;
                    }
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Parent
        {
            if (wrapProperty.p is Server)
            {
                Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                return;
            }
            if (wrapProperty.p is WaitInputAction)
            {
                switch ((WaitInputAction.Property)wrapProperty.n)
                {
                    case WaitInputAction.Property.serverTime:
                        break;
                    case WaitInputAction.Property.clientTime:
                        break;
                    case WaitInputAction.Property.sub:
                        break;
                    case WaitInputAction.Property.inputs:
                        dirty = true;
                        break;
                    case WaitInputAction.Property.clientInput:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        // Child
        if (wrapProperty.p is GameMove)
        {
            dirty = true;
            haveChange = true;
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}