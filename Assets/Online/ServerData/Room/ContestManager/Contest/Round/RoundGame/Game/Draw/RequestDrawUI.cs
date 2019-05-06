using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawUI : UIBehavior<RequestDrawUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<RequestDraw>> requestDraw;

        #region Sub

        public abstract class Sub : Data
        {

            public abstract RequestDraw.State.Type getType();

            public abstract bool processEvent(Event e);

        }

        public VP<Sub> sub;

        #endregion

        #region showAnimation

        public VP<ShowAnimationUI.UIData> showAnimation;

        public void OnHide()
        {
            RequestDrawUI requestDrawUI = this.findCallBack<RequestDrawUI>();
            if (requestDrawUI != null)
            {
                requestDrawUI.back();
            }
            else
            {
                Debug.LogError("requestDrawUI null");
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            requestDraw,
            sub,
            showAnimation
        }

        public UIData() : base()
        {
            this.requestDraw = new VP<ReferenceData<RequestDraw>>(this, (byte)Property.requestDraw, new ReferenceData<RequestDraw>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            // showAnimation
            {
                this.showAnimation = new VP<ShowAnimationUI.UIData>(this, (byte)Property.showAnimation, new ShowAnimationUI.UIData());
                this.showAnimation.v.onHide.v = OnHide;
            }
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // sub
                if (!isProcess)
                {
                    Sub sub = this.sub.v;
                    if (sub != null)
                    {
                        isProcess = sub.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("sub null");
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        RequestDrawUI requestDrawUI = this.findCallBack<RequestDrawUI>();
                        if (requestDrawUI != null)
                        {
                            requestDrawUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("requestDrawUI null");
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        RequestDrawUI requestDrawUI = this.findCallBack<RequestDrawUI>();
                        if (requestDrawUI != null)
                        {
                            isProcess = requestDrawUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("requestDrawUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region Refresh

    public Button btnBack;

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
                    // stateUI
                    {
                        RequestDraw.State state = requestDraw.state.v;
                        if (state != null)
                        {
                            switch (state.getType())
                            {
                                case RequestDraw.State.Type.None:
                                    {
                                        RequestDrawStateNone stateNone = state as RequestDrawStateNone;
                                        // UIData
                                        RequestDrawStateNoneUI.UIData stateNoneUIData = this.data.sub.newOrOld<RequestDrawStateNoneUI.UIData>();
                                        {
                                            stateNoneUIData.requestDrawStateNone.v = new ReferenceData<RequestDrawStateNone>(stateNone);
                                        }
                                        this.data.sub.v = stateNoneUIData;
                                    }
                                    break;
                                case RequestDraw.State.Type.Ask:
                                    {
                                        RequestDrawStateAsk stateAsk = state as RequestDrawStateAsk;
                                        // UIData
                                        RequestDrawStateAskUI.UIData stateAskUIData = this.data.sub.newOrOld<RequestDrawStateAskUI.UIData>();
                                        {
                                            stateAskUIData.requestDrawStateAsk.v = new ReferenceData<RequestDrawStateAsk>(stateAsk);
                                        }
                                        this.data.sub.v = stateAskUIData;
                                    }
                                    break;
                                case RequestDraw.State.Type.Accept:
                                    {
                                        RequestDrawStateAccept stateAccept = state as RequestDrawStateAccept;
                                        // UIData
                                        RequestDrawStateAcceptUI.UIData stateAcceptUIData = this.data.sub.newOrOld<RequestDrawStateAcceptUI.UIData>();
                                        {
                                            stateAcceptUIData.requestDrawStateAccept.v = new ReferenceData<RequestDrawStateAccept>(stateAccept);
                                        }
                                        this.data.sub.v = stateAcceptUIData;
                                    }
                                    break;
                                case RequestDraw.State.Type.Cancel:
                                    {
                                        RequestDrawStateCancel stateCancel = state as RequestDrawStateCancel;
                                        // UIData
                                        RequestDrawStateCancelUI.UIData stateCancelUIData = this.data.sub.newOrOld<RequestDrawStateCancelUI.UIData>();
                                        {
                                            stateCancelUIData.requestDrawStateCancel.v = new ReferenceData<RequestDrawStateCancel>(stateCancel);
                                        }
                                        this.data.sub.v = stateCancelUIData;
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + state.getType());
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("state null: " + this);
                        }
                    }
                }
                else
                {
                    // Debug.LogError ("requestDraw null: " + this);
                }
                // siblingIndex
                {
                    UIRectTransform.SetSiblingIndex(this.data.sub.v, 0);
                    if (btnBack != null)
                    {
                        btnBack.transform.SetSiblingIndex(1);
                    }
                    else
                    {
                        Debug.LogError("btnBack null");
                    }
                }
                // btnBack
                {
                    UIRectTransform.SetButtonTopLeftTransform(btnBack);
                }
                // UI
                {
                    float deltaY = 0;
                    // sub
                    deltaY += UIRectTransform.SetPosY(this.data.sub.v, deltaY);
                    // set
                    UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
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

    public RequestDrawStateNoneUI nonePrefab;
    public RequestDrawStateAskUI askPrefab;
    public RequestDrawStateAcceptUI acceptPrefab;
    public RequestDrawStateCancelUI cancelPrefab;

    public ShowAnimationUI showAnimationUI;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.requestDraw.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
                uiData.showAnimation.allAddCallBack(this);
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
        {
            if (data is RequestDraw)
            {
                dirty = true;
                return;
            }
            // sub
            {
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case RequestDraw.State.Type.None:
                                {
                                    RequestDrawStateNoneUI.UIData noneUIData = sub as RequestDrawStateNoneUI.UIData;
                                    UIUtils.Instantiate(noneUIData, nonePrefab, this.transform);
                                }
                                break;
                            case RequestDraw.State.Type.Ask:
                                {
                                    RequestDrawStateAskUI.UIData askUIData = sub as RequestDrawStateAskUI.UIData;
                                    UIUtils.Instantiate(askUIData, askPrefab, this.transform);
                                }
                                break;
                            case RequestDraw.State.Type.Accept:
                                {
                                    RequestDrawStateAcceptUI.UIData acceptUIData = sub as RequestDrawStateAcceptUI.UIData;
                                    UIUtils.Instantiate(acceptUIData, acceptPrefab, this.transform);
                                }
                                break;
                            case RequestDraw.State.Type.Cancel:
                                {
                                    RequestDrawStateCancelUI.UIData cancelUIData = sub as RequestDrawStateCancelUI.UIData;
                                    UIUtils.Instantiate(cancelUIData, cancelPrefab, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
                    }
                    // Child
                    {
                        TransformData.AddCallBack(sub, this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is TransformData)
                {
                    dirty = true;
                    return;
                }
            }
            if(data is ShowAnimationUI.UIData)
            {
                ShowAnimationUI.UIData showAnimationUIData = data as ShowAnimationUI.UIData;
                // UI
                {
                    if (showAnimationUI != null)
                    {
                        showAnimationUI.setData(showAnimationUIData);
                    }
                    else
                    {
                        Debug.LogError("showAnimationUI null");
                    }
                }
                dirty = true;
                return;
            }
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
                uiData.sub.allRemoveCallBack(this);
                uiData.showAnimation.allRemoveCallBack(this);
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
        {
            if (data is RequestDraw)
            {
                return;
            }
            // sub
            {
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // Child
                    {
                        TransformData.RemoveCallBack(sub, this);
                    }
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case RequestDraw.State.Type.None:
                                {
                                    RequestDrawStateNoneUI.UIData noneUIData = sub as RequestDrawStateNoneUI.UIData;
                                    noneUIData.removeCallBackAndDestroy(typeof(RequestDrawStateNoneUI));
                                }
                                break;
                            case RequestDraw.State.Type.Ask:
                                {
                                    RequestDrawStateAskUI.UIData askUIData = sub as RequestDrawStateAskUI.UIData;
                                    askUIData.removeCallBackAndDestroy(typeof(RequestDrawStateAskUI));
                                }
                                break;
                            case RequestDraw.State.Type.Accept:
                                {
                                    RequestDrawStateAcceptUI.UIData acceptUIData = sub as RequestDrawStateAcceptUI.UIData;
                                    acceptUIData.removeCallBackAndDestroy(typeof(RequestDrawStateAcceptUI));
                                }
                                break;
                            case RequestDraw.State.Type.Cancel:
                                {
                                    RequestDrawStateCancelUI.UIData cancelUIData = sub as RequestDrawStateCancelUI.UIData;
                                    cancelUIData.removeCallBackAndDestroy(typeof(RequestDrawStateCancelUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType());
                                break;
                        }
                    }
                    return;
                }
                // Child
                if(data is TransformData)
                {
                    return;
                }
            }
            if (data is ShowAnimationUI.UIData)
            {
                ShowAnimationUI.UIData showAnimationUIData = data as ShowAnimationUI.UIData;
                // UI
                {
                    if (showAnimationUI != null)
                    {
                        showAnimationUI.setDataNull(showAnimationUIData);
                    }
                    else
                    {
                        Debug.LogError("showAnimationUI null");
                    }
                }
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
                case UIData.Property.sub:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.showAnimation:
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
                    break;
                case Setting.Property.style:
                    break;
                case Setting.Property.contentTextSize:
                    dirty = true;
                    break;
                case Setting.Property.titleTextSize:
                    dirty = true;
                    break;
                case Setting.Property.labelTextSize:
                    dirty = true;
                    break;
                case Setting.Property.buttonSize:
                    dirty = true;
                    break;
                case Setting.Property.confirmQuit:
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                case Setting.Property.defaultChosenGame:
                    break;
                case Setting.Property.defaultRoomName:
                    break;
                case Setting.Property.defaultChatRoomStyle:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is RequestDraw)
            {
                switch ((RequestDraw.Property)wrapProperty.n)
                {
                    case RequestDraw.Property.state:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // sub
            {
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
                // Child
                if(wrapProperty.p is TransformData)
                {
                    switch ((TransformData.Property)wrapProperty.n)
                    {
                        case TransformData.Property.anchoredPosition:
                            break;
                        case TransformData.Property.anchorMin:
                            break;
                        case TransformData.Property.anchorMax:
                            break;
                        case TransformData.Property.pivot:
                            break;
                        case TransformData.Property.offsetMin:
                            break;
                        case TransformData.Property.offsetMax:
                            break;
                        case TransformData.Property.sizeDelta:
                            break;
                        case TransformData.Property.rotation:
                            break;
                        case TransformData.Property.scale:
                            break;
                        case TransformData.Property.size:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            if (wrapProperty.p is ShowAnimationUI.UIData)
            {
                return;
            }
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
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            if (showAnimationUI != null)
            {
                ShowAnimationUI.UIData showAnimationUIData = this.data.showAnimation.v;
                if (showAnimationUIData != null)
                {
                    showAnimationUIData.hide();
                }
                else
                {
                    Debug.LogError("showAnimationUIData null");
                }
            }
            else
            {
                Debug.LogError("showAnimationUI null");
                back();
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    public void back()
    {
        if (this.data != null)
        {
            GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
            if (gameUIData != null)
            {
                gameUIData.requestDraw.v = null;
            }
            else
            {
                Debug.LogError("gameUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}