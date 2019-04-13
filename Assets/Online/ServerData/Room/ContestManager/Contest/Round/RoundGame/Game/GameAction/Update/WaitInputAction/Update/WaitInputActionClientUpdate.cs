using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaitInputActionClientUpdate : UpdateBehavior<WaitInputAction>
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
        return true;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is WaitInputAction)
        {
            WaitInputAction waitInputAction = data as WaitInputAction;
            // Update
            {
                UpdateUtils.makeUpdate<WaitInputClientTimeUpdate, WaitInputAction>(waitInputAction, this.transform);
            }
            // Child
            {
                waitInputAction.clientInput.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        if (data is ClientInput)
        {
            ClientInput clientInput = data as ClientInput;
            {
                UpdateUtils.makeUpdate<ClientInputUpdate, ClientInput>(clientInput, this.transform);
            }
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is WaitInputAction)
        {
            WaitInputAction waitInputAction = data as WaitInputAction;
            // Update
            {
                waitInputAction.removeCallBackAndDestroy(typeof(WaitInputClientTimeUpdate));
            }
            // Child
            {
                waitInputAction.clientInput.allRemoveCallBack(this);
            }
            this.setDataNull(waitInputAction);
            return;
        }
        // Child
        if (data is ClientInput)
        {
            ClientInput clientInput = data as ClientInput;
            {
                clientInput.removeCallBackAndDestroy(typeof(ClientInputUpdate));
            }
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
            switch ((WaitInputAction.Property)wrapProperty.n)
            {
                case WaitInputAction.Property.serverTime:
                    break;
                case WaitInputAction.Property.clientTime:
                    break;
                case WaitInputAction.Property.sub:
                    break;
                case WaitInputAction.Property.inputs:
                    break;
                case WaitInputAction.Property.clientInput:
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
        if (wrapProperty.p is ClientInput)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}