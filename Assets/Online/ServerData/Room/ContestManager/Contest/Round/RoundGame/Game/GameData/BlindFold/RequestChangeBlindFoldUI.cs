using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeBlindFoldUI : UIBehavior<RequestChangeBlindFoldUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<RequestChangeBlindFold>> requestChangeBlindFold;

        #region Sub

        public abstract class Sub : Data
        {

            public abstract RequestChangeBlindFold.State.Type getType();

            public abstract bool processEvent(Event e);

        }

        public VP<Sub> sub;

        #endregion

        #region showAnimation

        public VP<ShowAnimationUI.UIData> showAnimation;

        public void OnHide()
        {
            RequestChangeBlindFoldUI requestChangeBlindfoldUI = this.findCallBack<RequestChangeBlindFoldUI>();
            if (requestChangeBlindfoldUI != null)
            {
                requestChangeBlindfoldUI.back();
            }
            else
            {
                Debug.LogError("requestChangeBlindfoldUI null");
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            requestChangeBlindFold,
            sub,
            showAnimation
        }

        public UIData() : base()
        {
            this.requestChangeBlindFold = new VP<ReferenceData<RequestChangeBlindFold>>(this, (byte)Property.requestChangeBlindFold, new ReferenceData<RequestChangeBlindFold>(null));
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
                        RequestChangeBlindFoldUI requestChangeBlindFoldUI = this.findCallBack<RequestChangeBlindFoldUI>();
                        if (requestChangeBlindFoldUI != null)
                        {
                            requestChangeBlindFoldUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("requestChangeBlindFoldUI null");
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        RequestChangeBlindFoldUI requestChangeBlindFoldUI = this.findCallBack<RequestChangeBlindFoldUI>();
                        if (requestChangeBlindFoldUI != null)
                        {
                            isProcess = requestChangeBlindFoldUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("requestChangeBlindFoldUI null: " + this);
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Blindfold");

    public Text tvBlindFold;
    private static readonly TxtLanguage txtBlindFold = new TxtLanguage("blindfold");

    static RequestChangeBlindFoldUI()
    {
        txtTitle.add(Language.Type.vi, "Cờ Mù");
        txtBlindFold.add(Language.Type.vi, "cờ mù");
    }

    #endregion

    #region Refresh

    public Toggle tgBlindFold;

    public Button btnBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                RequestChangeBlindFold requestChangeBlindFold = this.data.requestChangeBlindFold.v.data;
                if (requestChangeBlindFold != null)
                {
                    // tgBlindFold
                    {
                        if (tgBlindFold != null)
                        {
                            bool blindFold = true;
                            {
                                GameData gameData = requestChangeBlindFold.findDataInParent<GameData>();
                                if (gameData != null)
                                {
                                    blindFold = gameData.blindFold.v;
                                }
                                else
                                {
                                    Debug.LogError("gameData null: " + this);
                                }
                            }
                            tgBlindFold.isOn = blindFold;
                        }
                        else
                        {
                            Debug.LogError("tgBlindFold null: " + this);
                        }
                    }
                    // sub
                    {
                        RequestChangeBlindFold.State state = requestChangeBlindFold.state.v;
                        if (state != null)
                        {
                            switch (state.getType())
                            {
                                case RequestChangeBlindFold.State.Type.None:
                                    {
                                        RequestChangeBlindFoldStateNone none = state as RequestChangeBlindFoldStateNone;
                                        // UIData
                                        {
                                            RequestChangeBlindFoldStateNoneUI.UIData noneUIData = this.data.sub.newOrOld<RequestChangeBlindFoldStateNoneUI.UIData>();
                                            {
                                                noneUIData.requestChangeBlindFoldStateNone.v = new ReferenceData<RequestChangeBlindFoldStateNone>(none);
                                            }
                                            this.data.sub.v = noneUIData;
                                        }
                                    }
                                    break;
                                case RequestChangeBlindFold.State.Type.Ask:
                                    {
                                        RequestChangeBlindFoldStateAsk ask = state as RequestChangeBlindFoldStateAsk;
                                        // UIData
                                        {
                                            RequestChangeBlindFoldStateAskUI.UIData askUIData = this.data.sub.newOrOld<RequestChangeBlindFoldStateAskUI.UIData>();
                                            {
                                                askUIData.requestChangeBlindFoldStateAsk.v = new ReferenceData<RequestChangeBlindFoldStateAsk>(ask);
                                            }
                                            this.data.sub.v = askUIData;
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("state null: " + this);
                        }
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
                    // UI
                    {
                        float buttonSize = Setting.get().getButtonSize();
                        float deltaY = 0;
                        // header
                        {
                            UIRectTransform.SetTitleTransform(lbTitle);
                            UIRectTransform.SetButtonTopLeftTransform(btnBack);
                            deltaY += buttonSize;
                        }
                        // sub
                        deltaY += UIRectTransform.SetPosY(this.data.sub.v, deltaY);
                        // bottom
                        {
                            if (tgBlindFold != null)
                            {
                                UIRectTransform.SetPosY((RectTransform)tgBlindFold.transform, deltaY + 10);
                                deltaY += 40;
                            }
                            else
                            {
                                Debug.LogError("tgBlindFold null");
                            }
                        }
                        // set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (tvBlindFold != null)
                        {
                            tvBlindFold.text = txtBlindFold.get();
                        }
                        else
                        {
                            Debug.LogError("tvBlindFold null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("requestChangeBlindFold null: " + this);
                }
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

    public RequestChangeBlindFoldStateNoneUI nonePrefab;
    public RequestChangeBlindFoldStateAskUI askPrefab;

    public ShowAnimationUI showAnimationUI;

    private GameData gameData = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.requestChangeBlindFold.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
                uiData.showAnimation.allAddCallBack(this);
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
        {
            // requestChangeBlindfold
            {
                if (data is RequestChangeBlindFold)
                {
                    RequestChangeBlindFold requestChangeBlindfold = data as RequestChangeBlindFold;
                    // Parent
                    {
                        DataUtils.addParentCallBack(requestChangeBlindfold, this, ref this.gameData);
                    }
                    dirty = true;
                    return;
                }
                // Parent
                if (data is GameData)
                {
                    dirty = true;
                    return;
                }
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
                            case RequestChangeBlindFold.State.Type.None:
                                {
                                    RequestChangeBlindFoldStateNoneUI.UIData noneUIData = sub as RequestChangeBlindFoldStateNoneUI.UIData;
                                    UIUtils.Instantiate(noneUIData, nonePrefab, this.transform);
                                }
                                break;
                            case RequestChangeBlindFold.State.Type.Ask:
                                {
                                    RequestChangeBlindFoldStateAskUI.UIData askUIData = sub as RequestChangeBlindFoldStateAskUI.UIData;
                                    UIUtils.Instantiate(askUIData, askPrefab, this.transform);
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
                uiData.requestChangeBlindFold.allRemoveCallBack(this);
                uiData.sub.allRemoveCallBack(this);
                uiData.showAnimation.allRemoveCallBack(this);
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
        {
            // requestChangeBlindFold
            {
                if (data is RequestChangeBlindFold)
                {
                    RequestChangeBlindFold requestChangeBlindFold = data as RequestChangeBlindFold;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(requestChangeBlindFold, this, ref this.gameData);
                    }
                    return;
                }
                // Parent
                if (data is GameData)
                {
                    return;
                }
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
                            case RequestChangeBlindFold.State.Type.None:
                                {
                                    RequestChangeBlindFoldStateNoneUI.UIData noneUIData = sub as RequestChangeBlindFoldStateNoneUI.UIData;
                                    noneUIData.removeCallBackAndDestroy(typeof(RequestChangeBlindFoldStateNoneUI));
                                }
                                break;
                            case RequestChangeBlindFold.State.Type.Ask:
                                {
                                    RequestChangeBlindFoldStateAskUI.UIData askUIData = sub as RequestChangeBlindFoldStateAskUI.UIData;
                                    askUIData.removeCallBackAndDestroy(typeof(RequestChangeBlindFoldStateAskUI));
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
                case UIData.Property.requestChangeBlindFold:
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
        if (wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    dirty = true;
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
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            // requestChangeBlindFold
            {
                if (wrapProperty.p is RequestChangeBlindFold)
                {
                    switch ((RequestChangeBlindFold.Property)wrapProperty.n)
                    {
                        case RequestChangeBlindFold.Property.state:
                            dirty = true;
                            break;
                        case RequestChangeBlindFold.Property.whoCanAsks:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Parent
                if (wrapProperty.p is GameData)
                {
                    switch ((GameData.Property)wrapProperty.n)
                    {
                        case GameData.Property.gameType:
                            break;
                        case GameData.Property.useRule:
                            break;
                        case GameData.Property.requestChangeUseRule:
                            break;
                        case GameData.Property.blindFold:
                            dirty = true;
                            break;
                        case GameData.Property.requestChangeBlindFold:
                            break;
                        case GameData.Property.turn:
                            break;
                        case GameData.Property.timeControl:
                            break;
                        case GameData.Property.lastMove:
                            break;
                        case GameData.Property.state:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // sub
            {
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
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

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {

        }
    }

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
                GameDataUI.UIData gameDataUIData = gameUIData.gameDataUI.v;
                if (gameDataUIData != null)
                {
                    gameDataUIData.requestChangeBlindFold.v = null;
                }
                else
                {
                    Debug.LogError("gameDataUIData null");
                }
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