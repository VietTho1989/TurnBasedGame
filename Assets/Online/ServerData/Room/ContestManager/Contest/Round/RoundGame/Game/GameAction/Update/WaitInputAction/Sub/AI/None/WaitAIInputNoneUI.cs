using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaitAIInputNoneUI : UIBehavior<WaitAIInputNoneUI.UIData>
{

    #region UIData

    public class UIData : WaitAIInputUI.UIData.Sub
    {

        public VP<ReferenceData<WaitAIInputNone>> waitAIInputNone;

        #region Constructor

        public enum Property
        {
            waitAIInputNone
        }

        public UIData() : base()
        {
            this.waitAIInputNone = new VP<ReferenceData<WaitAIInputNone>>(this, (byte)Property.waitAIInputNone, new ReferenceData<WaitAIInputNone>(null));
        }

        #endregion

        public override WaitAIInput.Sub.Type getType()
        {
            return WaitAIInput.Sub.Type.None;
        }

    }

    #endregion

    #region txt

    public Text tvMessage;
    public static readonly TxtLanguage txtMessage = new TxtLanguage("Wait AI Input: None");

    static WaitAIInputNoneUI()
    {
        txtMessage.add(Language.Type.vi, "Đợi đầu vào AI: không");
    }

    #endregion

    #region Refresh

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // txt
                {
                    if (tvMessage != null)
                    {
                        tvMessage.text = txtMessage.get();
                    }
                    else
                    {
                        Debug.LogError("tvMessage null: " + this);
                    }
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
                uiData.waitAIInputNone.allAddCallBack(this);
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
        if (data is WaitAIInputNone)
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
                uiData.waitAIInputNone.allRemoveCallBack(this);
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
        if (data is WaitAIInputNone)
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
                case UIData.Property.waitAIInputNone:
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
        if (wrapProperty.p is WaitAIInputNone)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}