using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaitInputActionUpdate : GameActionsUpdate.Sub<WaitInputAction>
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
                UpdateUtils.makeUpdate<WaitInputMakeSubUpdate, WaitInputAction>(waitInputAction, this.transform);
                UpdateUtils.makeUpdate<WaitInputServerTimeUpdate, WaitInputAction>(waitInputAction, this.transform);
                UpdateUtils.makeUpdate<WaitInputActionClientUpdate, WaitInputAction>(waitInputAction, this.transform);
                UpdateUtils.makeUpdate<WaitInputActionProcessInputUpdate, WaitInputAction>(waitInputAction, this.transform);
            }
            // Child
            {
                waitInputAction.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        if (data is WaitInputAction.Sub)
        {
            WaitInputAction.Sub sub = data as WaitInputAction.Sub;
            {
                switch (sub.getType())
                {
                    case WaitInputAction.Sub.Type.Human:
                        break;
                    case WaitInputAction.Sub.Type.AI:
                        {
                            WaitAIInput waitAIInput = sub as WaitAIInput;
                            UpdateUtils.makeUpdate<WaitAIInputUpdate, WaitAIInput>(waitAIInput, this.transform);
                        }
                        break;
                    default:
                        Debug.LogError("unknown sub type: " + sub.getType() + "; " + this);
                        break;
                }
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
                waitInputAction.removeCallBackAndDestroy(typeof(WaitInputMakeSubUpdate));
                waitInputAction.removeCallBackAndDestroy(typeof(WaitInputServerTimeUpdate));
                waitInputAction.removeCallBackAndDestroy(typeof(WaitInputActionClientUpdate));
                waitInputAction.removeCallBackAndDestroy(typeof(WaitInputActionProcessInputUpdate));
            }
            // Child
            {
                waitInputAction.sub.allRemoveCallBack(this);
            }
            this.setDataNull(waitInputAction);
            return;
        }
        if (data is WaitInputAction.Sub)
        {
            WaitInputAction.Sub sub = data as WaitInputAction.Sub;
            {
                switch (sub.getType())
                {
                    case WaitInputAction.Sub.Type.Human:
                        break;
                    case WaitInputAction.Sub.Type.AI:
                        {
                            WaitAIInput waitAIInput = sub as WaitAIInput;
                            waitAIInput.removeCallBackAndDestroy(typeof(WaitAIInputUpdate));
                        }
                        break;
                    default:
                        Debug.LogError("unknown sub type: " + sub.getType() + "; " + this);
                        break;
                }
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
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case WaitInputAction.Property.inputs:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        if (wrapProperty.p is WaitInputAction.Sub)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}