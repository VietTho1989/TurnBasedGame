using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BtnRequestDrawUI : UIBehavior<BtnRequestDrawUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<RequestDraw>> requestDraw;

        #region Constructor

        public enum Property
        {
            requestDraw
        }

        public UIData() : base()
        {
            this.requestDraw = new VP<ReferenceData<RequestDraw>>(this, (byte)Property.requestDraw, new ReferenceData<RequestDraw>(null));
        }

        #endregion

        public bool process(Event e)
        {
            bool isProcess = false;
            {
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        BtnRequestDrawUI btnRequestDrawUI = this.findCallBack<BtnRequestDrawUI>();
                        if (btnRequestDrawUI != null)
                        {
                            isProcess = btnRequestDrawUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("btnRequestDrawUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Request Draw");

    static BtnRequestDrawUI()
    {
        txtTitle.add(Language.Type.vi, "Cầu Hoà");
    }

    #endregion

    #region Refresh

    public GameObject highlightIndicator;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                RequestDraw requestDraw = this.data.requestDraw.v.data;
                if (requestDraw != null)
                {
                    // highlight
                    if (highlightIndicator != null)
                    {
                        // find
                        bool isHighlight = false;
                        {
                            if (requestDraw.state.v.getType() != RequestDraw.State.Type.None)
                            {
                                isHighlight = true;
                            }
                        }
                        // set
                        highlightIndicator.SetActive(isHighlight);
                    }
                    else
                    {
                        Debug.LogError("highlightIndicator null");
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                }
                else
                {
                    // Debug.LogError("requestDraw null");
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

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.requestDraw.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        if (data is RequestDraw)
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
                uiData.requestDraw.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if(data is Setting)
        {
            return;
        }
        // Child
        if (data is RequestDraw)
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
                case UIData.Property.requestDraw:
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
        if(wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    dirty = true;
                    break;
                case Setting.Property.style:
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
        if (wrapProperty.p is RequestDraw)
        {
            switch ((RequestDraw.Property)wrapProperty.n)
            {
                case RequestDraw.Property.state:
                    dirty = true;
                    break;
                case RequestDraw.Property.whoCanAsks:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.Q:
                        {
                            if (btnRequest != null && btnRequest.gameObject.activeInHierarchy && btnRequest.interactable)
                            {
                                this.onClickBtnRequestDraw();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    public Button btnRequest;

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnRequestDraw()
    {
        if (this.data != null)
        {
            RequestDraw requestDraw = this.data.requestDraw.v.data;
            if (requestDraw != null)
            {
                GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
                if (gameUIData != null)
                {
                    RequestDrawUI.UIData requestDrawUIData = gameUIData.requestDraw.newOrOld<RequestDrawUI.UIData>();
                    {

                    }
                    gameUIData.requestDraw.v = requestDrawUIData;
                    // showAnimation
                    {
                        ShowAnimationUI.UIData showAnimationUIData = requestDrawUIData.showAnimation.v;
                        if (showAnimationUIData != null)
                        {
                            showAnimationUIData.show();
                        }
                        else
                        {
                            Debug.LogError("showAnimationUIData null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("gameUIData null");
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