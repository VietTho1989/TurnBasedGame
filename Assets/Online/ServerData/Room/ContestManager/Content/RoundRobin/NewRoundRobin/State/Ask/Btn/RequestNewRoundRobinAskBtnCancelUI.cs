using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace GameManager.Match.RoundRobin
{
    public class RequestNewRoundRobinAskBtnCancelUI : UIBehavior<RequestNewRoundRobinAskBtnCancelUI.UIData>
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
                return Type.Cancel;
            }

            public void reset()
            {
                this.state.v = State.None;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");
        private static readonly TxtLanguage txtCancelCancel = new TxtLanguage("Cancel cancel?");
        private static readonly TxtLanguage txtCancelling = new TxtLanguage("Cancelling");

        private static readonly TxtLanguage txtRequestError = new TxtLanguage("Send request to cancel error");

        static RequestNewRoundRobinAskBtnCancelUI()
        {
            txtCancel.add(Language.Type.vi, "Huỷ Bỏ");
            txtCancelCancel.add(Language.Type.vi, "Huỷ huỷ bỏ?");
            txtCancelling.add(Language.Type.vi, "Đang huỷ bỏ");

            txtRequestError.add(Language.Type.vi, "Gửi yêu cầu huỷ bỏ lỗi");
        }

        #endregion

        #region Refresh

        public Button btnCancel;
        public Text tvCancel;

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
                                                    requestNewRoundRobinStateAsk.requestCancel(Server.getProfileUserId(requestNewRoundRobinStateAsk));
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
                        if (btnCancel != null && tvCancel != null)
                        {
                            switch (this.data.state.v)
                            {
                                case UIData.State.None:
                                    {
                                        btnCancel.interactable = true;
                                        tvCancel.text = txtCancel.get();
                                    }
                                    break;
                                case UIData.State.Request:
                                    {
                                        btnCancel.interactable = true;
                                        tvCancel.text = txtCancelCancel.get();
                                    }
                                    break;
                                case UIData.State.Wait:
                                    {
                                        btnCancel.interactable = false;
                                        tvCancel.text = txtCancelling.get();
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("btnCancel, tvCancel null: " + this);
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
            if(data is Setting)
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
            if(data is Setting)
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
            if(wrapProperty.p is Setting)
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

        public void onClickBtnCancel()
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