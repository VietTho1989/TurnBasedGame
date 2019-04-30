using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class RequestChangeUseRuleStateAskBtnRefuseUI : UIBehavior<RequestChangeUseRuleStateAskBtnRefuseUI.UIData>
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

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtRefuse = new TxtLanguage("Refuse");
    private static readonly TxtLanguage txtCancelRefuse = new TxtLanguage("Cancel Refuse?");
    private static readonly TxtLanguage txtRefusing = new TxtLanguage("Refusing...");
    private static readonly TxtLanguage txtCannotRefuse = new TxtLanguage("Cannot Refuse");

    static RequestChangeUseRuleStateAskBtnRefuseUI()
    {
        txtRefuse.add(Language.Type.vi, "Từ Chối");
        txtCancelRefuse.add(Language.Type.vi, "Huỷ từ chối?");
        txtRefusing.add(Language.Type.vi, "Đang từ chối...");
        txtCannotRefuse.add(Language.Type.vi, "Không thể từ chối");
    }

    #endregion

    #region Refresh

    public Button btnRefuse;
    public Text tvRefuse;

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
                    uint profileId = Server.getProfileUserId(requestChangeUseRuleStateAsk);
                    // find can refuse
                    bool canRefuse = false;
                    {
                        if (requestChangeUseRuleStateAsk.isCanAnswer(profileId))
                        {
                            canRefuse = true;
                        }
                    }
                    // process
                    if (canRefuse)
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
                                                requestChangeUseRuleStateAsk.requestRefuse(profileId);
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
                            if (btnRefuse != null && tvRefuse != null)
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            btnRefuse.interactable = true;
                                            tvRefuse.text = txtRefuse.get();
                                        }
                                        break;
                                    case UIData.State.Request:
                                        {
                                            btnRefuse.interactable = true;
                                            tvRefuse.text = txtCancelRefuse.get();
                                        }
                                        break;
                                    case UIData.State.Wait:
                                        {
                                            btnRefuse.interactable = false;
                                            tvRefuse.text = txtRefusing.get();
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("btnRefuse, tvRefuse null: " + this);
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
                            if (btnRefuse != null && tvRefuse != null)
                            {
                                btnRefuse.interactable = false;
                                tvRefuse.text = txtCannotRefuse.get();
                            }
                            else
                            {
                                Debug.LogError("btnRefuse, tvRefuse null: " + this);
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

    public void onClickBtnRefuse()
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
                    Debug.LogError("You are refusing");
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