using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UndoRedo;

public class UndoRedoRequestUI : UIBehavior<UndoRedoRequestUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<UndoRedoRequest>> undoRedoRequest;

        #region Sub

        public abstract class Sub : Data
        {

            public abstract UndoRedoRequest.State.Type getType();

            public abstract bool processEvent(Event e);

        }

        public VP<Sub> sub;

        #endregion

        #region showAnimation

        public VP<ShowAnimationUI.UIData> showAnimation;

        public void OnHide()
        {
            UndoRedoRequestUI undoRedoRequestUI = this.findCallBack<UndoRedoRequestUI>();
            if (undoRedoRequestUI != null)
            {
                undoRedoRequestUI.back();
            }
            else
            {
                Debug.LogError("undoRedoRequestUI null");
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            undoRedoRequest,
            sub,
            showAnimation
        }

        public UIData() : base()
        {
            this.undoRedoRequest = new VP<ReferenceData<UndoRedoRequest>>(this, (byte)Property.undoRedoRequest, new ReferenceData<UndoRedoRequest>(null));
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
                        UndoRedoRequestUI undoRedoRequestUI = this.findCallBack<UndoRedoRequestUI>();
                        if (undoRedoRequestUI != null)
                        {
                            undoRedoRequestUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("undoRedoRequestUI null");
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        UndoRedoRequestUI undoRedoRequestUI = this.findCallBack<UndoRedoRequestUI>();
                        if (undoRedoRequestUI != null)
                        {
                            isProcess = undoRedoRequestUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("swapUI null: " + this);
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
                UndoRedoRequest undoRedoRequest = this.data.undoRedoRequest.v.data;
                if (undoRedoRequest != null)
                {
                    // state
                    UndoRedoRequest.State state = undoRedoRequest.state.v;
                    if (state != null)
                    {
                        switch (undoRedoRequest.state.v.getType())
                        {
                            case UndoRedoRequest.State.Type.None:
                                {
                                    None none = state as None;
                                    // UIData
                                    NoneUI.UIData noneUIData = this.data.sub.newOrOld<NoneUI.UIData>();
                                    {
                                        noneUIData.none.v = new ReferenceData<None>(none);
                                    }
                                    this.data.sub.v = noneUIData;
                                }
                                break;
                            case UndoRedoRequest.State.Type.Ask:
                                {
                                    Ask ask = state as Ask;
                                    // UIData
                                    AskUI.UIData askUIData = this.data.sub.newOrOld<AskUI.UIData>();
                                    {
                                        askUIData.ask.v = new ReferenceData<Ask>(ask);
                                    }
                                    this.data.sub.v = askUIData;
                                }
                                break;
                            default:
                                Debug.LogError("unknown state: " + undoRedoRequest.state.v + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("state null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("undoRedoRequest null: " + this);
                }
                // SiblingIndex
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

    public NoneUI nonePrefab;
    public AskUI askPrefab;

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
                uiData.undoRedoRequest.allAddCallBack(this);
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
            if (data is UndoRedoRequest)
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
                            case UndoRedoRequest.State.Type.None:
                                {
                                    NoneUI.UIData none = sub as NoneUI.UIData;
                                    UIUtils.Instantiate(none, nonePrefab, this.transform);
                                }
                                break;
                            case UndoRedoRequest.State.Type.Ask:
                                {
                                    AskUI.UIData ask = sub as AskUI.UIData;
                                    UIUtils.Instantiate(ask, askPrefab, this.transform);
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
                if (data is TransformData)
                {
                    dirty = true;
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
                uiData.undoRedoRequest.allRemoveCallBack(this);
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
            if (data is UndoRedoRequest)
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
                            case UndoRedoRequest.State.Type.None:
                                {
                                    NoneUI.UIData none = sub as NoneUI.UIData;
                                    none.removeCallBackAndDestroy(typeof(NoneUI));
                                }
                                break;
                            case UndoRedoRequest.State.Type.Ask:
                                {
                                    AskUI.UIData ask = sub as AskUI.UIData;
                                    ask.removeCallBackAndDestroy(typeof(AskUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                // Child
                if (data is TransformData)
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
                case UIData.Property.undoRedoRequest:
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
            if (wrapProperty.p is UndoRedoRequest)
            {
                switch ((UndoRedoRequest.Property)wrapProperty.n)
                {
                    case UndoRedoRequest.Property.state:
                        dirty = true;
                        break;
                    case UndoRedoRequest.Property.canUndo:
                        break;
                    case UndoRedoRequest.Property.canRedo:
                        break;
                    case UndoRedoRequest.Property.count:
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
                if (wrapProperty.p is TransformData)
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
                gameUIData.undoRedoRequestUIData.v = null;
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