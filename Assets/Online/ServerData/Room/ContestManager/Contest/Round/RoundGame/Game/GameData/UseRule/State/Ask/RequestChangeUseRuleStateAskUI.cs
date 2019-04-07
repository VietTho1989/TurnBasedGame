using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using RequestUseRule;

public class RequestChangeUseRuleStateAskUI : UIHaveTransformDataBehavior<RequestChangeUseRuleStateAskUI.UIData>
{

    #region UIData

    public class UIData : RequestChangeUseRuleUI.UIData.Sub
    {

        public VP<ReferenceData<RequestChangeUseRuleStateAsk>> requestChangeUseRuleStateAsk;

        public VP<WhoAskAdapter.UIData> whoAskAdapter;

        public VP<RequestChangeUseRuleStateAskBtnAcceptUI.UIData> btnAccept;

        public VP<RequestChangeUseRuleStateAskBtnRefuseUI.UIData> btnRefuse;

        #region Constructor

        public enum Property
        {
            requestChangeUseRuleStateAsk,
            whoAskAdapter,
            btnAccept,
            btnRefuse
        }

        public UIData() : base()
        {
            this.requestChangeUseRuleStateAsk = new VP<ReferenceData<RequestChangeUseRuleStateAsk>>(this, (byte)Property.requestChangeUseRuleStateAsk, new ReferenceData<RequestChangeUseRuleStateAsk>(null));
            this.whoAskAdapter = new VP<WhoAskAdapter.UIData>(this, (byte)Property.whoAskAdapter, new WhoAskAdapter.UIData());
            this.btnAccept = new VP<RequestChangeUseRuleStateAskBtnAcceptUI.UIData>(this, (byte)Property.btnAccept, new RequestChangeUseRuleStateAskBtnAcceptUI.UIData());
            this.btnRefuse = new VP<RequestChangeUseRuleStateAskBtnRefuseUI.UIData>(this, (byte)Property.btnRefuse, new RequestChangeUseRuleStateAskBtnRefuseUI.UIData());
        }

        #endregion

        public override RequestChangeUseRule.State.Type getType()
        {
            return RequestChangeUseRule.State.Type.Ask;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {

            }
            return isProcess;
        }

    }

    #endregion

    #region txt, rect

    public Text tvCannotAnswer;
    private static readonly TxtLanguage txtCannotAnswer = new TxtLanguage("Don't have rights to answer");

    static RequestChangeUseRuleStateAskUI()
    {
        // txt
        {
            txtCannotAnswer.add(Language.Type.vi, "Không có quyền trả lời");
        }
        // rect
        {
            // whoAskAdapterRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (0.0, -60.0); offsetMax: (0.0, 0.0); sizeDelta: (0.0, 60.0);
                whoAskAdapterRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                whoAskAdapterRect.anchorMin = new Vector2(0.0f, 1.0f);
                whoAskAdapterRect.anchorMax = new Vector2(1.0f, 1.0f);
                whoAskAdapterRect.pivot = new Vector2(0.5f, 1.0f);
                whoAskAdapterRect.offsetMin = new Vector2(0.0f, -60.0f);
                whoAskAdapterRect.offsetMax = new Vector2(0.0f, 0.0f);
                whoAskAdapterRect.sizeDelta = new Vector2(0.0f, 60.0f);
            }
            // btnAcceptRect
            {
                // anchoredPosition: (-60.0, -70.0); anchorMin: (0.5, 1.0); anchorMax: (0.5, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (-120.0, -100.0); offsetMax: (0.0, -70.0); sizeDelta: (120.0, 30.0);
                btnAcceptRect.anchoredPosition = new Vector3(-60.0f, -70.0f, 0.0f);
                btnAcceptRect.anchorMin = new Vector2(0.5f, 1.0f);
                btnAcceptRect.anchorMax = new Vector2(0.5f, 1.0f);
                btnAcceptRect.pivot = new Vector2(0.5f, 1.0f);
                btnAcceptRect.offsetMin = new Vector2(-120.0f, -100.0f);
                btnAcceptRect.offsetMax = new Vector2(0.0f, -70.0f);
                btnAcceptRect.sizeDelta = new Vector2(120.0f, 30.0f);
            }
            // btnRefuseRect
            {
                // anchoredPosition: (60.0, -70.0); anchorMin: (0.5, 1.0); anchorMax: (0.5, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (0.0, -100.0); offsetMax: (120.0, -70.0); sizeDelta: (120.0, 30.0);
                btnRefuseRect.anchoredPosition = new Vector3(60.0f, -70.0f, 0.0f);
                btnRefuseRect.anchorMin = new Vector2(0.5f, 1.0f);
                btnRefuseRect.anchorMax = new Vector2(0.5f, 1.0f);
                btnRefuseRect.pivot = new Vector2(0.5f, 1.0f);
                btnRefuseRect.offsetMin = new Vector2(0.0f, -100.0f);
                btnRefuseRect.offsetMax = new Vector2(120.0f, -70.0f);
                btnRefuseRect.sizeDelta = new Vector2(120.0f, 30.0f);
            }
        }
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
                RequestChangeUseRuleStateAsk requestChangeUseRuleStateAsk = this.data.requestChangeUseRuleStateAsk.v.data;
                if (requestChangeUseRuleStateAsk != null)
                {
                    // whoAskAdapter
                    {
                        WhoAskAdapter.UIData whoAskAdapter = this.data.whoAskAdapter.v;
                        if (whoAskAdapter != null)
                        {
                            whoAskAdapter.requestChangeUseRuleStateAsk.v = new ReferenceData<RequestChangeUseRuleStateAsk>(requestChangeUseRuleStateAsk);
                        }
                        else
                        {
                            Debug.LogError("whoAskAdapter null: " + this);
                        }
                    }
                    // btnAccept
                    {
                        RequestChangeUseRuleStateAskBtnAcceptUI.UIData btnAccept = this.data.btnAccept.v;
                        if (btnAccept != null)
                        {
                            btnAccept.requestChangeUseRuleStateAsk.v = new ReferenceData<RequestChangeUseRuleStateAsk>(requestChangeUseRuleStateAsk);
                        }
                        else
                        {
                            Debug.LogError("btnAccept null: " + this);
                        }
                    }
                    // btnRefuse
                    {
                        RequestChangeUseRuleStateAskBtnRefuseUI.UIData btnRefuse = this.data.btnRefuse.v;
                        if (btnRefuse != null)
                        {
                            btnRefuse.requestChangeUseRuleStateAsk.v = new ReferenceData<RequestChangeUseRuleStateAsk>(requestChangeUseRuleStateAsk);
                        }
                        else
                        {
                            Debug.LogError("btnAccept null: " + this);
                        }
                    }
                    // tvCannotAnswer
                    {
                        if (tvCannotAnswer != null)
                        {
                            tvCannotAnswer.text = txtCannotAnswer.get();
                        }
                        else
                        {
                            Debug.LogError("tvCannotAnswer null");
                        }
                    }
                    // canAnswer
                    {
                        // find
                        bool canAnswer = false;
                        {
                            uint profileId = Server.getProfileUserId(requestChangeUseRuleStateAsk);
                            RequestChangeUseRule requestChangeUseRule = requestChangeUseRuleStateAsk.findDataInParent<RequestChangeUseRule>();
                            if (requestChangeUseRule != null)
                            {
                                foreach (Human human in requestChangeUseRule.whoCanAsks.vs)
                                {
                                    if (human.playerId.v == profileId)
                                    {
                                        canAnswer = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("requestChangeUseRule null");
                            }
                        }
                        // process
                        if (canAnswer)
                        {
                            // tv
                            if (tvCannotAnswer != null)
                            {
                                tvCannotAnswer.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("tvCannotAnswer null");
                            }
                            // btn
                            {
                                UIRectTransform.SetActive(this.data.btnAccept.v, true);
                                UIRectTransform.SetActive(this.data.btnRefuse.v, true);
                            }
                        }
                        else
                        {
                            // tv
                            if (tvCannotAnswer != null)
                            {
                                tvCannotAnswer.gameObject.SetActive(true);
                            }
                            else
                            {
                                Debug.LogError("tvCannotAnswer null");
                            }
                            // btn
                            {
                                UIRectTransform.SetActive(this.data.btnAccept.v, false);
                                UIRectTransform.SetActive(this.data.btnRefuse.v, false);
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("requestChangeUseRuleStateAsk null: " + this);
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

    public WhoAskAdapter whoAskAdapterPrefab;
    private static readonly UIRectTransform whoAskAdapterRect = new UIRectTransform();

    public RequestChangeUseRuleStateAskBtnAcceptUI btnAcceptPrefab;
    private static readonly UIRectTransform btnAcceptRect = new UIRectTransform();

    public RequestChangeUseRuleStateAskBtnRefuseUI btnRefusePrefab;
    private static readonly UIRectTransform btnRefuseRect = new UIRectTransform();

    private RequestChangeUseRule requestChangeUseRule = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.requestChangeUseRuleStateAsk.allAddCallBack(this);
                uiData.whoAskAdapter.allAddCallBack(this);
                uiData.btnAccept.allAddCallBack(this);
                uiData.btnRefuse.allAddCallBack(this);
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
            // requestChangeUseRuleStateAsk
            {
                if (data is RequestChangeUseRuleStateAsk)
                {
                    RequestChangeUseRuleStateAsk requestChangeUseRuleStateAsk = data as RequestChangeUseRuleStateAsk;
                    // Parent
                    {
                        DataUtils.addParentCallBack(requestChangeUseRuleStateAsk, this, ref this.requestChangeUseRule);
                    }
                    dirty = true;
                    return;
                }
                // Parent
                {
                    if (data is RequestChangeUseRule)
                    {
                        RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
                        // Child
                        {
                            requestChangeUseRule.whoCanAsks.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Human)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            if (data is WhoAskAdapter.UIData)
            {
                WhoAskAdapter.UIData whoAskAdapter = data as WhoAskAdapter.UIData;
                // UI
                {
                    UIUtils.Instantiate(whoAskAdapter, whoAskAdapterPrefab, this.transform, whoAskAdapterRect);
                }
                dirty = true;
                return;
            }
            if (data is RequestChangeUseRuleStateAskBtnAcceptUI.UIData)
            {
                RequestChangeUseRuleStateAskBtnAcceptUI.UIData btnAccept = data as RequestChangeUseRuleStateAskBtnAcceptUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnAccept, btnAcceptPrefab, this.transform, btnAcceptRect);
                }
                dirty = true;
                return;
            }
            if (data is RequestChangeUseRuleStateAskBtnRefuseUI.UIData)
            {
                RequestChangeUseRuleStateAskBtnRefuseUI.UIData btnRefuse = data as RequestChangeUseRuleStateAskBtnRefuseUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnRefuse, btnRefusePrefab, this.transform, btnRefuseRect);
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
                uiData.requestChangeUseRuleStateAsk.allRemoveCallBack(this);
                uiData.whoAskAdapter.allRemoveCallBack(this);
                uiData.btnAccept.allRemoveCallBack(this);
                uiData.btnRefuse.allRemoveCallBack(this);
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
            // requestChangeUseRuleStateAsk
            {
                if (data is RequestChangeUseRuleStateAsk)
                {
                    RequestChangeUseRuleStateAsk requestChangeUseRuleStateAsk = data as RequestChangeUseRuleStateAsk;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(requestChangeUseRuleStateAsk, this, ref this.requestChangeUseRule);
                    }
                    return;
                }
                // Parent
                {
                    if (data is RequestChangeUseRule)
                    {
                        RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
                        // Child
                        {
                            requestChangeUseRule.whoCanAsks.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Human)
                    {
                        return;
                    }
                }
            }
            if (data is WhoAskAdapter.UIData)
            {
                WhoAskAdapter.UIData whoAskAdapter = data as WhoAskAdapter.UIData;
                // UI
                {
                    whoAskAdapter.removeCallBackAndDestroy(typeof(WhoAskAdapter));
                }
                return;
            }
            if (data is RequestChangeUseRuleStateAskBtnAcceptUI.UIData)
            {
                RequestChangeUseRuleStateAskBtnAcceptUI.UIData btnAccept = data as RequestChangeUseRuleStateAskBtnAcceptUI.UIData;
                // UI
                {
                    btnAccept.removeCallBackAndDestroy(typeof(RequestChangeUseRuleStateAskBtnAcceptUI));
                }
                return;
            }
            if (data is RequestChangeUseRuleStateAskBtnRefuseUI.UIData)
            {
                RequestChangeUseRuleStateAskBtnRefuseUI.UIData btnRefuse = data as RequestChangeUseRuleStateAskBtnRefuseUI.UIData;
                // UI
                {
                    btnRefuse.removeCallBackAndDestroy(typeof(RequestChangeUseRuleStateAskBtnRefuseUI));
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
                case UIData.Property.requestChangeUseRuleStateAsk:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.whoAskAdapter:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnAccept:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnRefuse:
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
            // requestChangeUseRuleStateAsk
            {
                if (wrapProperty.p is RequestChangeUseRuleStateAsk)
                {
                    switch ((RequestChangeUseRuleStateAsk.Property)wrapProperty.n)
                    {
                        case RequestChangeUseRuleStateAsk.Property.accepts:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Parent
                {
                    if (wrapProperty.p is RequestChangeUseRule)
                    {
                        switch ((RequestChangeUseRule.Property)wrapProperty.n)
                        {
                            case RequestChangeUseRule.Property.state:
                                break;
                            case RequestChangeUseRule.Property.whoCanAsks:
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
                    if (wrapProperty.p is Human)
                    {
                        Human.onUpdateSyncPlayerIdChange(wrapProperty, this);
                        return;
                    }
                }
            }
            if (wrapProperty.p is WhoAskAdapter.UIData)
            {
                return;
            }
            if (wrapProperty.p is RequestChangeUseRuleStateAskBtnAcceptUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is RequestChangeUseRuleStateAskBtnRefuseUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}