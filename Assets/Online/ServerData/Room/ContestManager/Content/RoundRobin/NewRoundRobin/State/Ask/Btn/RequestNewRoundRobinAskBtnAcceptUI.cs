using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace GameManager.Match.RoundRobin
{
    public class RequestNewRoundRobinAskBtnAcceptUI : UIBehavior<RequestNewRoundRobinAskBtnAcceptUI.UIData>
    {

        #region UIData

        public class UIData : RequestNewRoundRobinStateAskUI.UIData.Btn
        {

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
                state
            }

            public UIData() : base()
            {
                this.state = new VP<State>(this, (byte)Property.state, State.None);
            }

            #endregion

            public override Type getType()
            {
                return Type.Accept;
            }

            public void reset()
            {
                this.state.v = State.None;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtAccept = new TxtLanguage("Accept");
        private static readonly TxtLanguage txtCancelAccept = new TxtLanguage("Cancel accept?");
        private static readonly TxtLanguage txtAccepting = new TxtLanguage("Accepting");

        private static readonly TxtLanguage txtRequestError = new TxtLanguage("Send request to accept error");

        static RequestNewRoundRobinAskBtnAcceptUI()
        {
            txtAccept.add(Language.Type.vi, "Chấp Nhận");
            txtCancelAccept.add(Language.Type.vi, "Huỷ chấp nhận?");
            txtAccepting.add(Language.Type.vi, "Đang chấp nhận");

            txtRequestError.add(Language.Type.vi, "Gửi yêu cầu chấp nhận lỗi");
        }

        #endregion

        #region Refresh

        public Button btnAccept;
        public Text tvAccept;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
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
                                        RequestNewRoundRobinStateAskUI.UIData requestNewRoundRobinStateAskUIData = this.data.findDataInParent<RequestNewRoundRobinStateAskUI.UIData>();
                                        if (requestNewRoundRobinStateAskUIData != null)
                                        {
                                            RequestNewRoundRobinStateAsk requestNewRoundRobinStateAsk = requestNewRoundRobinStateAskUIData.requestNewRoundRobinStateAsk.v.data;
                                            if (requestNewRoundRobinStateAsk != null)
                                            {
                                                if (Server.IsServerOnline(requestNewRoundRobinStateAsk))
                                                {
                                                    requestNewRoundRobinStateAsk.requestAccept(Server.getProfileUserId(requestNewRoundRobinStateAsk));
                                                    this.data.state.v = UIData.State.Wait;
                                                }
                                                else
                                                {
                                                    Debug.LogError("server not online: " + this);
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("requestNewRoundRobinStateAsk null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("requestNewRoundRobinStateAskUIData null: " + this);
                                        }
                                    }
                                }
                                break;
                            case UIData.State.Wait:
                                {
                                    RequestNewRoundRobinStateAskUI.UIData requestNewRoundRobinStateAskUIData = this.data.findDataInParent<RequestNewRoundRobinStateAskUI.UIData>();
                                    if (requestNewRoundRobinStateAskUIData != null)
                                    {
                                        RequestNewRoundRobinStateAsk requestNewRoundRobinStateAsk = requestNewRoundRobinStateAskUIData.requestNewRoundRobinStateAsk.v.data;
                                        if (requestNewRoundRobinStateAsk != null)
                                        {
                                            if (Server.IsServerOnline(requestNewRoundRobinStateAsk))
                                            {
                                                startRoutine(ref this.wait, TaskWait());
                                            }
                                            else
                                            {
                                                Debug.LogError("server not online: " + this);
                                                destroyRoutine(wait);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("requestNewRoundRobinStateAsk null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("requestNewRoundRobinStateAskUIData null: " + this);
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
                    // Debug.LogError ("data null: " + this);
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
                if (this.data != null)
                {
                    this.data.state.v = UIData.State.None;
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
                Toast.showMessage(txtRequestError.get());
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

        private RequestNewRoundRobinStateAskUI.UIData requestNewRoundRobinStateAskUIData = null;
        private Server server = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.requestNewRoundRobinStateAskUIData);
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
            // Parent
            {
                if (data is RequestNewRoundRobinStateAskUI.UIData)
                {
                    RequestNewRoundRobinStateAskUI.UIData requestNewRoundRobinStateAskUIData = data as RequestNewRoundRobinStateAskUI.UIData;
                    // Child
                    {
                        requestNewRoundRobinStateAskUIData.requestNewRoundRobinStateAsk.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is RequestNewRoundRobinStateAsk)
                    {
                        RequestNewRoundRobinStateAsk requestNewRoundRobinStateAsk = data as RequestNewRoundRobinStateAsk;
                        // Reset
                        {
                            if (this.data != null)
                            {
                                this.data.reset();
                            }
                            else
                            {
                                Debug.LogError("data null: " + this);
                            }
                        }
                        // Parent
                        {
                            DataUtils.addParentCallBack(requestNewRoundRobinStateAsk, this, ref this.server);
                        }
                        dirty = true;
                        return;
                    }
                    // Parent
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.requestNewRoundRobinStateAskUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Parent
            {
                if (data is RequestNewRoundRobinStateAskUI.UIData)
                {
                    RequestNewRoundRobinStateAskUI.UIData requestNewRoundRobinStateAskUIData = data as RequestNewRoundRobinStateAskUI.UIData;
                    // Child
                    {
                        requestNewRoundRobinStateAskUIData.requestNewRoundRobinStateAsk.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is RequestNewRoundRobinStateAsk)
                    {
                        RequestNewRoundRobinStateAsk requestNewRoundRobinStateAsk = data as RequestNewRoundRobinStateAsk;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(requestNewRoundRobinStateAsk, this, ref this.server);
                        }
                        return;
                    }
                    // Parent
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
            // Parent
            {
                if (wrapProperty.p is RequestNewRoundRobinStateAskUI.UIData)
                {
                    switch ((RequestNewRoundRobinStateAskUI.UIData.Property)wrapProperty.n)
                    {
                        case RequestNewRoundRobinStateAskUI.UIData.Property.requestNewRoundRobinStateAsk:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case RequestNewRoundRobinStateAskUI.UIData.Property.btn:
                            break;
                        case RequestNewRoundRobinStateAskUI.UIData.Property.visibility:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is RequestNewRoundRobinStateAsk)
                    {
                        return;
                    }
                    // Parent
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
}