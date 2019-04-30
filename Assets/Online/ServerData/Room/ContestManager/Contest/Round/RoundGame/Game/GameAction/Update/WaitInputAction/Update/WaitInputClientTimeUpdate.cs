using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class WaitInputClientTimeUpdate : UpdateBehavior<WaitInputAction>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {

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

    private Routine clientTimeRoutine;

    void Awake()
    {
        startRoutine(ref this.clientTimeRoutine, updateClientTime());
    }

    public override List<Routine> getRoutineList()
    {
        List<Routine> ret = new List<Routine>();
        {
            ret.Add(clientTimeRoutine);
        }
        return ret;
    }

    public IEnumerator updateClientTime()
    {
        while (true)
        {
            yield return new Wait(1f);
            if (this.data != null)
            {
                if (Game.IsPlaying(this.data))
                {
                    // Check is sending client input
                    bool isSending = false;
                    {
                        WaitInputAction waitInputAction = this.data.findDataInParent<WaitInputAction>();
                        if (waitInputAction != null)
                        {
                            ClientInput clientInput = waitInputAction.clientInput.v;
                            if (clientInput != null)
                            {
                                if (clientInput.sub.v != null)
                                {
                                    if (clientInput.sub.v.getType() == ClientInput.Sub.Type.Send)
                                    {
                                        isSending = true;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("sub null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("clientInput null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("waitInputAction null: " + this);
                        }
                    }
                    // Process
                    if (!isSending)
                    {
                        this.data.clientTime.v = this.data.clientTime.v + 1;
                    }
                    else
                    {
                        // Debug.LogError ("you are sending clientInput: " + this);
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is WaitInputAction)
        {
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is WaitInputAction)
        {
            WaitInputAction waitInputAction = data as WaitInputAction;
            {

            }
            this.setDataNull(waitInputAction);
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
        if (wrapProperty.p is WaitInputAction)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}