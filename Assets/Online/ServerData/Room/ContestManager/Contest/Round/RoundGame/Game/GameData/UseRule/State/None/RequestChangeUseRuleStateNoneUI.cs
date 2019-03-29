using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class RequestChangeUseRuleStateNoneUI : UIHaveTransformDataBehavior<RequestChangeUseRuleStateNoneUI.UIData>
{

    #region UIData

    public class UIData : RequestChangeUseRuleUI.UIData.Sub
    {

        public VP<ReferenceData<RequestChangeUseRuleStateNone>> requestChangeUseRuleStateNone;

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
            requestChangeUseRuleStateNone,
            state
        }

        public UIData() : base()
        {
            this.requestChangeUseRuleStateNone = new VP<ReferenceData<RequestChangeUseRuleStateNone>>(this, (byte)Property.requestChangeUseRuleStateNone, new ReferenceData<RequestChangeUseRuleStateNone>(null));
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public override RequestChangeUseRule.State.Type getType()
        {
            return RequestChangeUseRule.State.Type.None;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {

            }
            return isProcess;
        }

        public void reset()
        {
            this.state.v = State.None;
        }

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtRequest = new TxtLanguage();
    private static readonly TxtLanguage txtCancelRequest = new TxtLanguage();
    private static readonly TxtLanguage txtRequesting = new TxtLanguage();
    private static readonly TxtLanguage txtCannotRequest = new TxtLanguage();

    private static readonly TxtLanguage txtRequestError = new TxtLanguage();

    static RequestChangeUseRuleStateNoneUI()
    {
        txtRequest.add(Language.Type.vi, "Yêu Cầu");
        txtCancelRequest.add(Language.Type.vi, "Huỷ yêu cầu?");
        txtRequesting.add(Language.Type.vi, "Đang yêu cầu");
        txtCannotRequest.add(Language.Type.vi, "Không thể yêu cầu");

        txtRequestError.add(Language.Type.vi, "Gửi yêu cầu đổi luật lỗi");
    }

    #endregion

    #region Refresh

    public Button btnRequest;
    public Text tvRequest;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                RequestChangeUseRuleStateNone requestChangeUseRuleStateNone = this.data.requestChangeUseRuleStateNone.v.data;
                if (requestChangeUseRuleStateNone != null)
                {
                    uint profileId = Server.getProfileUserId(requestChangeUseRuleStateNone);
                    if (requestChangeUseRuleStateNone.isCanChange(profileId))
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
                                            if (Server.IsServerOnline(requestChangeUseRuleStateNone))
                                            {
                                                requestChangeUseRuleStateNone.requestChange(profileId);
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
                                        if (Server.IsServerOnline(requestChangeUseRuleStateNone))
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
                            if (btnRequest != null && tvRequest != null)
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            btnRequest.interactable = true;
                                            tvRequest.text = txtRequest.get("Request");
                                        }
                                        break;
                                    case UIData.State.Request:
                                        {
                                            btnRequest.interactable = true;
                                            tvRequest.text = txtCancelRequest.get("Cancel Request?");
                                        }
                                        break;
                                    case UIData.State.Wait:
                                        {
                                            btnRequest.interactable = false;
                                            tvRequest.text = txtRequesting.get("Requesting...");
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
                            if (btnRequest != null && tvRequest != null)
                            {
                                btnRequest.interactable = false;
                                tvRequest.text = txtCannotRequest.get("Cannot Request");
                            }
                            else
                            {
                                Debug.LogError("btnRequest null, tvRequest null: " + this);
                            }
                        }
                    }
                }
                else
                {
                    // Debug.LogError("requestChangeUseRuleStateNone null: " + this);
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
            Toast.showMessage(txtRequestError.get("send request to change rule error"));
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
                uiData.requestChangeUseRuleStateNone.allAddCallBack(this);
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
            if (data is RequestChangeUseRuleStateNone)
            {
                RequestChangeUseRuleStateNone requestChangeUseRuleStateNone = data as RequestChangeUseRuleStateNone;
                // reset
                {
                    if (this.data != null)
                    {
                        this.data.reset();
                    }
                }
                // Parent
                {
                    DataUtils.addParentCallBack(requestChangeUseRuleStateNone, this, ref this.requestChangeUseRule);
                    DataUtils.addParentCallBack(requestChangeUseRuleStateNone, this, ref this.server);
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
                uiData.requestChangeUseRuleStateNone.allRemoveCallBack(this);
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
            if (data is RequestChangeUseRuleStateNone)
            {
                RequestChangeUseRuleStateNone requestChangeUseRuleStateNone = data as RequestChangeUseRuleStateNone;
                // Parent
                {
                    DataUtils.removeParentCallBack(requestChangeUseRuleStateNone, this, ref this.requestChangeUseRule);
                    DataUtils.removeParentCallBack(requestChangeUseRuleStateNone, this, ref this.server);
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
                case UIData.Property.requestChangeUseRuleStateNone:
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
            if (wrapProperty.p is RequestChangeUseRuleStateNone)
            {
                switch ((RequestChangeUseRuleStateNone.Property)wrapProperty.n)
                {
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

    public void onClickBtnRequest()
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
                    Debug.LogError("you are requesting: " + this);
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