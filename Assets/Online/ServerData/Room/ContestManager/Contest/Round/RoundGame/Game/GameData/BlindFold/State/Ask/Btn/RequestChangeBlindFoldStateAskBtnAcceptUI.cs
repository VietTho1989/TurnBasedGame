using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class RequestChangeBlindFoldStateAskBtnAcceptUI : UIBehavior<RequestChangeBlindFoldStateAskBtnAcceptUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<RequestChangeBlindFoldStateAsk>> requestChangeBlindFoldStateAsk;

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
            requestChangeBlindFoldStateAsk,
            state
        }

        public UIData() : base()
        {
            this.requestChangeBlindFoldStateAsk = new VP<ReferenceData<RequestChangeBlindFoldStateAsk>>(this, (byte)Property.requestChangeBlindFoldStateAsk, new ReferenceData<RequestChangeBlindFoldStateAsk>(null));
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

    private static readonly TxtLanguage txtAccept = new TxtLanguage("Accept");
    private static readonly TxtLanguage txtCancelAccept = new TxtLanguage("Cancel Accept?");
    private static readonly TxtLanguage txtAccepting = new TxtLanguage("Accepting...");
    private static readonly TxtLanguage txtCannotAccept = new TxtLanguage("Cannot Accept");

    static RequestChangeBlindFoldStateAskBtnAcceptUI()
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
                RequestChangeBlindFoldStateAsk requestChangeBlindFoldStateAsk = this.data.requestChangeBlindFoldStateAsk.v.data;
                if (requestChangeBlindFoldStateAsk != null)
                {
                    // reset
                    {
                        if (needReset)
                        {
                            this.data.state.v = UIData.State.None;
                            needReset = false;
                        }
                    }
                    uint profileId = Server.getProfileUserId(requestChangeBlindFoldStateAsk);
                    // find can accept
                    bool canAccept = false;
                    {
                        if (requestChangeBlindFoldStateAsk.isCanAnswer(profileId))
                        {
                            if (!requestChangeBlindFoldStateAsk.accepts.vs.Contains(profileId))
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
                                            if (Server.IsServerOnline(requestChangeBlindFoldStateAsk))
                                            {
                                                requestChangeBlindFoldStateAsk.requestAccept(profileId);
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
                                        if (Server.IsServerOnline(requestChangeBlindFoldStateAsk))
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
                    Debug.LogError("requestChangeBlindFoldStateAsk null: " + this);
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

    private RequestChangeBlindFold requestChangeBlindFold = null;
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
                uiData.requestChangeBlindFoldStateAsk.allAddCallBack(this);
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
            if (data is RequestChangeBlindFoldStateAsk)
            {
                RequestChangeBlindFoldStateAsk requestChangeBlindFoldStateAsk = data as RequestChangeBlindFoldStateAsk;
                // Parent
                {
                    DataUtils.addParentCallBack(requestChangeBlindFoldStateAsk, this, ref this.requestChangeBlindFold);
                    DataUtils.addParentCallBack(requestChangeBlindFoldStateAsk, this, ref this.server);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                // requestChangeBlindFold
                {
                    if (data is RequestChangeBlindFold)
                    {
                        RequestChangeBlindFold requestChangeBlindFold = data as RequestChangeBlindFold;
                        // Child
                        {
                            requestChangeBlindFold.whoCanAsks.allAddCallBack(this);
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
                uiData.requestChangeBlindFoldStateAsk.allRemoveCallBack(this);
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
            if (data is RequestChangeBlindFoldStateAsk)
            {
                RequestChangeBlindFoldStateAsk requestChangeBlindFoldStateAsk = data as RequestChangeBlindFoldStateAsk;
                // Parent
                {
                    DataUtils.removeParentCallBack(requestChangeBlindFoldStateAsk, this, ref this.requestChangeBlindFold);
                    DataUtils.removeParentCallBack(requestChangeBlindFoldStateAsk, this, ref this.server);
                }
                return;
            }
            // Parent
            {
                // requestChangeBlindFold
                {
                    if (data is RequestChangeBlindFold)
                    {
                        RequestChangeBlindFold requestChangeBlindFold = data as RequestChangeBlindFold;
                        // Child
                        {
                            requestChangeBlindFold.whoCanAsks.allRemoveCallBack(this);
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
                case UIData.Property.requestChangeBlindFoldStateAsk:
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
            if (wrapProperty.p is RequestChangeBlindFoldStateAsk)
            {
                switch ((RequestChangeBlindFoldStateAsk.Property)wrapProperty.n)
                {
                    case RequestChangeBlindFoldStateAsk.Property.accepts:
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
                // requestChangeBlindFold
                {
                    if (wrapProperty.p is RequestChangeBlindFold)
                    {
                        switch ((RequestChangeBlindFold.Property)wrapProperty.n)
                        {
                            case RequestChangeBlindFold.Property.state:
                                break;
                            case RequestChangeBlindFold.Property.whoCanAsks:
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