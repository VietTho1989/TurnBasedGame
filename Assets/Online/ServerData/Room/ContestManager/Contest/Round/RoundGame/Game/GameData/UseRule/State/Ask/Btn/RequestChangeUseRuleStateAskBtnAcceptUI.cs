using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class RequestChangeUseRuleStateAskBtnAcceptUI : UIBehavior<RequestChangeUseRuleStateAskBtnAcceptUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<RequestChangeUseRuleStateAsk>> requestChangeUseRuleStateAsk;

        #region state

        public enum State
        {
            None,
            Request,
            Wait
        }

        public VP<State> state;

        #endregion

        #region Constructor

        public enum Property
        {
            requestChangeUseRuleStateAsk,
            state
        }

        public UIData() : base()
        {
            this.requestChangeUseRuleStateAsk = new VP<ReferenceData<RequestChangeUseRuleStateAsk>>(this, (byte)Property.requestChangeUseRuleStateAsk, new ReferenceData<RequestChangeUseRuleStateAsk>(null));
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public void reset()
        {
            this.state.v = State.None;
        }

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        RequestChangeUseRuleStateAskBtnAcceptUI requestChangeUseRuleStateAskBtnAcceptUI = this.findCallBack<RequestChangeUseRuleStateAskBtnAcceptUI>();
                        if (requestChangeUseRuleStateAskBtnAcceptUI != null)
                        {
                            isProcess = requestChangeUseRuleStateAskBtnAcceptUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("requestChangeBoolUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtAccept = new TxtLanguage("Accept");
    private static readonly TxtLanguage txtCancelAccept = new TxtLanguage("Cancel Accept?");
    private static readonly TxtLanguage txtAccepting = new TxtLanguage("Accepting...");
    private static readonly TxtLanguage txtCannotAccept = new TxtLanguage("Cannot Accept");

    static RequestChangeUseRuleStateAskBtnAcceptUI()
    {
        txtAccept.add(Language.Type.vi, "Chấp Nhận");
        txtCancelAccept.add(Language.Type.vi, "Huỷ chấp nhận?");
        txtAccepting.add(Language.Type.vi, "Đang chấp nhận...");
        txtCannotAccept.add(Language.Type.vi, "Không thể chấp nhận");
    }

    #endregion

    #region Refresh

    private bool needReset = false;

    public Button btnAccept;
    public Text tvAccept;

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
                    // reset
                    {
                        if (needReset)
                        {
                            this.data.state.v = UIData.State.None;
                            needReset = false;
                        }
                    }
                    uint profileId = Server.getProfileUserId(requestChangeUseRuleStateAsk);
                    // find can accept
                    bool canAccept = false;
                    {
                        if (requestChangeUseRuleStateAsk.isCanAnswer(profileId))
                        {
                            if (!requestChangeUseRuleStateAsk.accepts.vs.Contains(profileId))
                            {
                                canAccept = true;
                            }
                        }
                    }
                    // process
                    if (canAccept)
                    {
                        // Task
                        {
                            switch (this.data.state.v)
                            {
                                case UIData.State.None:
                                    {
                                        destroyRoutine(wait);
                                    }
                                    break;
                                case UIData.State.Request:
                                    {
                                        destroyRoutine(wait);
                                        // request
                                        {
                                            if (Server.IsServerOnline(requestChangeUseRuleStateAsk))
                                            {
                                                requestChangeUseRuleStateAsk.requestAccept(profileId);
                                                this.data.state.v = UIData.State.Wait;
                                            }
                                            else
                                            {
                                                Debug.LogError("server not online: " + this);
                                            }
                                        }
                                    }
                                    break;
                                case UIData.State.Wait:
                                    {
                                        if (Server.IsServerOnline(requestChangeUseRuleStateAsk))
                                        {
                                            startRoutine(ref this.wait, TaskWait());
                                        }
                                        else
                                        {
                                            Debug.LogError("server not online: " + this);
                                            this.data.state.v = UIData.State.None;
                                            destroyRoutine(wait);
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                    break;
                            }
                        }
                        // UI
                        {
                            if (btnAccept != null && tvAccept != null)
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            btnAccept.interactable = true;
                                            tvAccept.text = txtAccept.get();
                                        }
                                        break;
                                    case UIData.State.Request:
                                        {
                                            btnAccept.interactable = true;
                                            tvAccept.text = txtCancelAccept.get();
                                        }
                                        break;
                                    case UIData.State.Wait:
                                        {
                                            btnAccept.interactable = false;
                                            tvAccept.text = txtAccepting.get();
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("btnAccept, tvAccept null: " + this);
                            }
                        }
                    }
                    else
                    {
                        // Task
                        {
                            this.data.state.v = UIData.State.None;
                            destroyRoutine(wait);
                        }
                        // UI
                        {
                            if (btnAccept != null && tvAccept != null)
                            {
                                btnAccept.interactable = false;
                                tvAccept.text = txtCannotAccept.get();
                            }
                            else
                            {
                                Debug.LogError("btnAccept, tvAccept null: " + this);
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
        return false;
    }

    #endregion

    #region Task wait

    private Routine wait;

    public IEnumerator TaskWait()
    {
        if (this.data != null)
        {
            yield return new Wait(Global.WaitSendTime);
            this.data.state.v = UIData.State.None;
            Toast.showMessage("request error");
            Debug.LogError("request error: " + this);
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public override List<Routine> getRoutineList()
    {
        List<Routine> ret = new List<Routine>();
        {
            ret.Add(wait);
        }
        return ret;
    }

    #endregion

    #region implement callBacks

    private RequestChangeUseRule requestChangeUseRule = null;
    private Server server = null;

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
            if (data is RequestChangeUseRuleStateAsk)
            {
                RequestChangeUseRuleStateAsk requestChangeUseRuleStateAsk = data as RequestChangeUseRuleStateAsk;
                // Parent
                {
                    DataUtils.addParentCallBack(requestChangeUseRuleStateAsk, this, ref this.requestChangeUseRule);
                    DataUtils.addParentCallBack(requestChangeUseRuleStateAsk, this, ref this.server);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                // requestChangeUseRule
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
                if (data is Server)
                {
                    dirty = true;
                    return;
                }
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
            if (data is RequestChangeUseRuleStateAsk)
            {
                RequestChangeUseRuleStateAsk requestChangeUseRuleStateAsk = data as RequestChangeUseRuleStateAsk;
                // Parent
                {
                    DataUtils.removeParentCallBack(requestChangeUseRuleStateAsk, this, ref this.requestChangeUseRule);
                    DataUtils.removeParentCallBack(requestChangeUseRuleStateAsk, this, ref this.server);
                }
                return;
            }
            // Parent
            {
                // requestChangeUseRule
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
                if (data is Server)
                {
                    return;
                }
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
                case UIData.Property.state:
                    dirty = true;
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
        {
            if (wrapProperty.p is RequestChangeUseRuleStateAsk)
            {
                switch ((RequestChangeUseRuleStateAsk.Property)wrapProperty.n)
                {
                    case RequestChangeUseRuleStateAsk.Property.accepts:
                        dirty = true;
                        needReset = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                // requestChangeUseRule
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
                if (wrapProperty.p is Server)
                {
                    Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnAccept()
    {
        if (this.data != null)
        {
            switch (this.data.state.v)
            {
                case UIData.State.None:
                    this.data.state.v = UIData.State.Request;
                    break;
                case UIData.State.Request:
                    this.data.state.v = UIData.State.None;
                    break;
                case UIData.State.Wait:
                    Debug.LogError("You are accepting");
                    break;
                default:
                    Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                    break;
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}