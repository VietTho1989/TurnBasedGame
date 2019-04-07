using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaitHumanInputUI : UIBehavior<WaitHumanInputUI.UIData>
{

    #region UIData

    public class UIData : WaitInputActionUI.UIData.Sub
    {

        public VP<ReferenceData<WaitHumanInput>> waitHumanInput;

        #region Constructor

        public enum Property
        {
            waitHumanInput
        }

        public UIData() : base()
        {
            this.waitHumanInput = new VP<ReferenceData<WaitHumanInput>>(this, (byte)Property.waitHumanInput, new ReferenceData<WaitHumanInput>(null));
        }

        #endregion

        public override WaitInputAction.Sub.Type getType()
        {
            return WaitInputAction.Sub.Type.Human;
        }

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtYourTurn = new TxtLanguage("Your Turn");
    private static readonly TxtLanguage txtNotYourTurn = new TxtLanguage("Not Your Turn");

    static WaitHumanInputUI()
    {
        txtYourTurn.add(Language.Type.vi, "Lượt của bạn");
        txtNotYourTurn.add(Language.Type.vi, "Không phải lượt của bạn");
    }

    #endregion

    #region Refresh

    public Text tvHuman;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                WaitHumanInput waitHumanInput = this.data.waitHumanInput.v.data;
                if (waitHumanInput != null)
                {
                    // tvHuman
                    if (tvHuman != null)
                    {
                        if (Server.getProfileUserId(waitHumanInput) == waitHumanInput.userId.v)
                        {
                            tvHuman.text = txtYourTurn.get();
                        }
                        else
                        {
                            tvHuman.text = txtNotYourTurn.get();
                        }
                    }
                    else
                    {
                        Debug.LogError("tvHuman null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("waitHumanInput null: " + this);
                }
            }
            else
            {
                // Debug.LogError ("data null: " + this);
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
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.waitHumanInput.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if (data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        if (data is WaitHumanInput)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().removeCallBack(this);
            // Child
            {
                uiData.waitHumanInput.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Child
        if (data is WaitHumanInput)
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
        if (wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.waitHumanInput:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Setting
        if (wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    dirty = true;
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        if (wrapProperty.p is WaitHumanInput)
        {
            switch ((WaitHumanInput.Property)wrapProperty.n)
            {
                case WaitHumanInput.Property.userId:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}