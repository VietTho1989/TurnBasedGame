using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawStateCancelUI : UIBehavior<RequestDrawStateCancelUI.UIData>, HaveTransformData
{

    #region UIData

    public class UIData : RequestDrawUI.UIData.Sub
    {

        public VP<ReferenceData<RequestDrawStateCancel>> requestDrawStateCancel;

        public override RequestDraw.State.Type getType()
        {
            return RequestDraw.State.Type.Cancel;
        }

        #region Constructor

        public enum Property
        {
            requestDrawStateCancel
        }

        public UIData() : base()
        {
            this.requestDrawStateCancel = new VP<ReferenceData<RequestDrawStateCancel>>(this, (byte)Property.requestDrawStateCancel, new ReferenceData<RequestDrawStateCancel>(null));
        }

        #endregion

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {

            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    public static readonly TxtLanguage txtTitle = new TxtLanguage();

    static RequestDrawStateCancelUI()
    {
        txtTitle.add(Language.Type.vi, "Yêu cầu hoà bị huỷ");
    }

    #endregion

    #region TransformData

    public TransformData transformData = new TransformData();

    private void updateTransformData()
    {
        this.transformData.update(this.transform);
    }

    public TransformData getTransformData()
    {
        return this.transformData;
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
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get("Request draw is cancelled");
                    }
                    else
                    {
                        Debug.LogError("lbTitle null: " + this);
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
        updateTransformData();
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
            // Global
            Global.get().addCallBack(this);
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.requestDrawStateCancel.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Global
        if (data is Global)
        {
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
        if (data is RequestDrawStateCancel)
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
            // Global
            Global.get().removeCallBack(this);
            // Setting
            Setting.get().removeCallBack(this);
            // Child
            {
                uiData.requestDrawStateCancel.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Global
        if (data is Global)
        {
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Child
        if (data is RequestDrawStateCancel)
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
                case UIData.Property.requestDrawStateCancel:
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
        // Global
        if (wrapProperty.p is Global)
        {
            Global.OnValueTransformChange(wrapProperty, this);
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
        if (wrapProperty.p is RequestDrawStateCancel)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}