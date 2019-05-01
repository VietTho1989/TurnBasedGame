using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeUseRuleUI : UIBehavior<RequestChangeUseRuleUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<RequestChangeUseRule>> requestChangeUseRule;

        #region Sub

        public abstract class Sub : Data
        {

            public abstract RequestChangeUseRule.State.Type getType();

            public abstract bool processEvent(Event e);

        }

        public VP<Sub> sub;

        #endregion

        #region showAnimation

        public VP<ShowAnimationUI.UIData> showAnimation;

        public void OnHide()
        {
            RequestChangeUseRuleUI requestChangeUseRuleUI = this.findCallBack<RequestChangeUseRuleUI>();
            if (requestChangeUseRuleUI != null)
            {
                requestChangeUseRuleUI.back();
            }
            else
            {
                Debug.LogError("requestChangeUseRuleUI null");
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            requestChangeUseRule,
            sub,
            showAnimation
        }

        public UIData() : base()
        {
            this.requestChangeUseRule = new VP<ReferenceData<RequestChangeUseRule>>(this, (byte)Property.requestChangeUseRule, new ReferenceData<RequestChangeUseRule>(null));
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
                        RequestChangeUseRuleUI requestChangeUseRuleUI = this.findCallBack<RequestChangeUseRuleUI>();
                        if (requestChangeUseRuleUI != null)
                        {
                            requestChangeUseRuleUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("requestChangeUseRuleUI null");
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Use Rule");

    public Text tvUseRule;
    private static readonly TxtLanguage txtUseRule = new TxtLanguage("use rule");

    static RequestChangeUseRuleUI()
    {
        txtTitle.add(Language.Type.vi, "Dùng Luật");
        txtUseRule.add(Language.Type.vi, "dùng luật");
    }

    #endregion

    #region Refresh

    public Toggle tgUseRule;

    public Button btnBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                RequestChangeUseRule requestChangeUseRule = this.data.requestChangeUseRule.v.data;
                if (requestChangeUseRule != null)
                {
                    // tgUseRule
                    {
                        if (tgUseRule != null)
                        {
                            bool useRule = true;
                            {
                                GameData gameData = requestChangeUseRule.findDataInParent<GameData>();
                                if (gameData != null)
                                {
                                    useRule = gameData.useRule.v;
                                }
                                else
                                {
                                    Debug.LogError("gameData null: " + this);
                                }
                            }
                            tgUseRule.isOn = useRule;
                        }
                        else
                        {
                            Debug.LogError("tgUseRule null: " + this);
                        }
                    }
                    // sub
                    {
                        RequestChangeUseRule.State state = requestChangeUseRule.state.v;
                        if (state != null)
                        {
                            switch (state.getType())
                            {
                                case RequestChangeUseRule.State.Type.None:
                                    {
                                        RequestChangeUseRuleStateNone none = state as RequestChangeUseRuleStateNone;
                                        // UIData
                                        {
                                            RequestChangeUseRuleStateNoneUI.UIData noneUIData = this.data.sub.newOrOld<RequestChangeUseRuleStateNoneUI.UIData>();
                                            {
                                                noneUIData.requestChangeUseRuleStateNone.v = new ReferenceData<RequestChangeUseRuleStateNone>(none);
                                            }
                                            this.data.sub.v = noneUIData;
                                        }
                                    }
                                    break;
                                case RequestChangeUseRule.State.Type.Ask:
                                    {
                                        RequestChangeUseRuleStateAsk ask = state as RequestChangeUseRuleStateAsk;
                                        // UIData
                                        {
                                            RequestChangeUseRuleStateAskUI.UIData askUIData = this.data.sub.newOrOld<RequestChangeUseRuleStateAskUI.UIData>();
                                            {
                                                askUIData.requestChangeUseRuleStateAsk.v = new ReferenceData<RequestChangeUseRuleStateAsk>(ask);
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
                            if (tgUseRule != null)
                            {
                                UIRectTransform.SetPosY((RectTransform)tgUseRule.transform, deltaY + 10);
                                deltaY += 40;
                            }
                            else
                            {
                                Debug.LogError("tgUseRule null");
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
                        if (tvUseRule != null)
                        {
                            tvUseRule.text = txtUseRule.get();
                        }
                        else
                        {
                            Debug.LogError("tvUseRule null: " + this);
                        }
                    }
                }
                else
                {
                    // Debug.LogError("requestChangeUseRule null: " + this);
                }
            }
            else
            {
                // Debug.LogError("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public RequestChangeUseRuleStateNoneUI nonePrefab;
    public RequestChangeUseRuleStateAskUI askPrefab;

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
                uiData.requestChangeUseRule.allAddCallBack(this);
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
            // requestChangeUseRule
            {
                if (data is RequestChangeUseRule)
                {
                    RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
                    // Parent
                    {
                        DataUtils.addParentCallBack(requestChangeUseRule, this, ref this.gameData);
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
                            case RequestChangeUseRule.State.Type.None:
                                {
                                    RequestChangeUseRuleStateNoneUI.UIData noneUIData = sub as RequestChangeUseRuleStateNoneUI.UIData;
                                    UIUtils.Instantiate(noneUIData, nonePrefab, this.transform);
                                }
                                break;
                            case RequestChangeUseRule.State.Type.Ask:
                                {
                                    RequestChangeUseRuleStateAskUI.UIData askUIData = sub as RequestChangeUseRuleStateAskUI.UIData;
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
                uiData.requestChangeUseRule.allRemoveCallBack(this);
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
            // requestChangeUseRule
            {
                if (data is RequestChangeUseRule)
                {
                    RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(requestChangeUseRule, this, ref this.gameData);
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
                            case RequestChangeUseRule.State.Type.None:
                                {
                                    RequestChangeUseRuleStateNoneUI.UIData noneUIData = sub as RequestChangeUseRuleStateNoneUI.UIData;
                                    noneUIData.removeCallBackAndDestroy(typeof(RequestChangeUseRuleStateNoneUI));
                                }
                                break;
                            case RequestChangeUseRule.State.Type.Ask:
                                {
                                    RequestChangeUseRuleStateAskUI.UIData askUIData = sub as RequestChangeUseRuleStateAskUI.UIData;
                                    askUIData.removeCallBackAndDestroy(typeof(RequestChangeUseRuleStateAskUI));
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
                case UIData.Property.requestChangeUseRule:
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
            // requestChangeUseRule
            {
                if (wrapProperty.p is RequestChangeUseRule)
                {
                    switch ((RequestChangeUseRule.Property)wrapProperty.n)
                    {
                        case RequestChangeUseRule.Property.state:
                            dirty = true;
                            break;
                        case RequestChangeUseRule.Property.whoCanAsks:
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
                            dirty = true;
                            break;
                        case GameData.Property.requestChangeUseRule:
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
                    gameDataUIData.requestChangeUseRule.v = null;
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