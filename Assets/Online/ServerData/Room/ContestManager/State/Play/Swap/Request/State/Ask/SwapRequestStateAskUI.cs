using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace GameManager.Match.Swap
{
    public class SwapRequestStateAskUI : UIBehavior<SwapRequestStateAskUI.UIData>
    {

        #region UIData

        public class UIData : HaveRequestSwapPlayerUI.UIData.StateUI
        {

            public VP<ReferenceData<SwapRequestStateAsk>> swapRequestStateAsk;

            public VP<WhoCanAskAdapter.UIData> whoCanAskAdapter;

            #region State

            public abstract class State : Data
            {

                public enum Type
                {
                    None,
                    Request,
                    Wait
                }

                public abstract Type getType();

            }

            public enum Action
            {
                Accept,
                Refuse
            }

            public class StateNone : State
            {

                #region Constructor

                public enum Property
                {

                }

                public StateNone() : base()
                {

                }

                #endregion

                public override Type getType()
                {
                    return Type.None;
                }

            }

            public class StateRequest : State
            {

                public VP<Action> action;

                #region Constructor

                public enum Property
                {
                    action
                }

                public StateRequest() : base()
                {
                    this.action = new VP<Action>(this, (byte)Property.action, Action.Accept);
                }

                #endregion

                public override Type getType()
                {
                    return Type.Request;
                }

            }

            public class StateWait : State
            {

                public VP<Action> action;

                #region Constructor

                public enum Property
                {
                    action
                }

                public StateWait() : base()
                {
                    this.action = new VP<Action>(this, (byte)Property.action, Action.Accept);
                }

                #endregion

                public override Type getType()
                {
                    return Type.Wait;
                }

            }

            public VP<State> state;

            #endregion

            #region Constructor

            public enum Property
            {
                swapRequestStateAsk,
                whoCanAskAdapter,
                state
            }

            public UIData() : base()
            {
                this.swapRequestStateAsk = new VP<ReferenceData<SwapRequestStateAsk>>(this, (byte)Property.swapRequestStateAsk, new ReferenceData<SwapRequestStateAsk>(null));
                this.whoCanAskAdapter = new VP<WhoCanAskAdapter.UIData>(this, (byte)Property.whoCanAskAdapter, new WhoCanAskAdapter.UIData());
                this.state = new VP<State>(this, (byte)Property.state, new StateNone());
            }

            #endregion

            public override SwapRequest.State.Type getType()
            {
                return SwapRequest.State.Type.Ask;
            }

            public void reset()
            {
                UIData.StateNone none = this.state.newOrOld<UIData.StateNone>();
                {

                }
                this.state.v = none;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage();

        public Text tvCannotAnswer;
        private static readonly TxtLanguage txtCannotAnswer = new TxtLanguage();

        private static readonly TxtLanguage txtAccept = new TxtLanguage();
        private static readonly TxtLanguage txtCancelAccept = new TxtLanguage();
        private static readonly TxtLanguage txtAccepting = new TxtLanguage();

        private static readonly TxtLanguage txtRefuse = new TxtLanguage();
        private static readonly TxtLanguage txtCancelRefuse = new TxtLanguage();
        private static readonly TxtLanguage txtRefusing = new TxtLanguage();

        private static readonly TxtLanguage txtRequestError = new TxtLanguage();

        static SwapRequestStateAskUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Trả Lời Yêu Cầu Thay Người");
                txtCannotAnswer.add(Language.Type.vi, "Không có quyền trả lời");
                // accept
                {
                    txtAccept.add(Language.Type.vi, "Chấp Nhận");
                    txtCancelAccept.add(Language.Type.vi, "Huỷ");
                    txtAccepting.add(Language.Type.vi, "Đang chấp nhận");
                }
                // refuse
                {
                    txtRefuse.add(Language.Type.vi, "Từ Chối");
                    txtCancelRefuse.add(Language.Type.vi, "Huỷ");
                    txtRefusing.add(Language.Type.vi, "Đang từ chối");
                }
                txtRequestError.add(Language.Type.vi, "Gửi trả lời lỗi");
            }
            // rect
            {
                // whoCanAskRect
                {
                    // anchoredPosition: (0.0, -30.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (0.0, -90.0); offsetMax: (0.0, -30.0); sizeDelta: (0.0, 60.0);
                    whoCanAskRect.anchoredPosition = new Vector3(0.0f, -30.0f, 0.0f);
                    whoCanAskRect.anchorMin = new Vector2(0.0f, 1.0f);
                    whoCanAskRect.anchorMax = new Vector2(1.0f, 1.0f);
                    whoCanAskRect.pivot = new Vector2(0.5f, 1.0f);
                    whoCanAskRect.offsetMin = new Vector2(0.0f, -90.0f);
                    whoCanAskRect.offsetMax = new Vector2(0.0f, -30.0f);
                    whoCanAskRect.sizeDelta = new Vector2(0.0f, 60.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Button btnAccept;
        public Text tvAccept;

        public Button btnRefuse;
        public Text tvRefuse;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    SwapRequestStateAsk swapRequestStateAsk = this.data.swapRequestStateAsk.v.data;
                    if (swapRequestStateAsk != null)
                    {
                        // whoCanAskAdapter
                        {
                            WhoCanAskAdapter.UIData whoCanAskAdapter = this.data.whoCanAskAdapter.v;
                            if (whoCanAskAdapter != null)
                            {
                                whoCanAskAdapter.swapRequestStateAsk.v = new ReferenceData<SwapRequestStateAsk>(swapRequestStateAsk);
                            }
                            else
                            {
                                Debug.LogError("whoCanAskAdapter null: " + this);
                            }
                        }
                        // find can ask
                        {
                            bool canAsk = false;
                            uint profileId = Server.getProfileUserId(swapRequestStateAsk);
                            {
                                foreach (Human human in swapRequestStateAsk.whoCanAsks.vs)
                                {
                                    if (human.playerId.v == profileId)
                                    {
                                        canAsk = true;
                                        break;
                                    }
                                }
                            }
                            // Process
                            if (canAsk)
                            {
                                // Task
                                {
                                    UIData.State state = this.data.state.v;
                                    if (state != null)
                                    {
                                        switch (state.getType())
                                        {
                                            case UIData.State.Type.None:
                                                {
                                                    destroyRoutine(wait);
                                                }
                                                break;
                                            case UIData.State.Type.Request:
                                                {
                                                    UIData.StateRequest stateRequest = state as UIData.StateRequest;
                                                    // request
                                                    if (Server.IsServerOnline(swapRequestStateAsk))
                                                    {
                                                        switch (stateRequest.action.v)
                                                        {
                                                            case UIData.Action.Accept:
                                                                {
                                                                    if (swapRequestStateAsk.accepts.vs.Contains(profileId))
                                                                    {
                                                                        UIData.StateNone none = this.data.state.newOrOld<UIData.StateNone>();
                                                                        {

                                                                        }
                                                                        this.data.state.v = none;
                                                                    }
                                                                    else
                                                                    {
                                                                        swapRequestStateAsk.requestAccept(profileId);
                                                                        // chuyen sang wait
                                                                        {
                                                                            UIData.StateWait stateWait = new UIData.StateWait();
                                                                            {
                                                                                stateWait.uid = this.data.state.makeId();
                                                                                stateWait.action.v = UIData.Action.Accept;
                                                                            }
                                                                            this.data.state.v = stateWait;
                                                                        }
                                                                    }
                                                                }
                                                                break;
                                                            case UIData.Action.Refuse:
                                                                {
                                                                    swapRequestStateAsk.requestRefuse(profileId);
                                                                    // chuyen sang wait
                                                                    {
                                                                        UIData.StateWait stateWait = new UIData.StateWait();
                                                                        {
                                                                            stateWait.uid = this.data.state.makeId();
                                                                            stateWait.action.v = UIData.Action.Refuse;
                                                                        }
                                                                        this.data.state.v = stateWait;
                                                                    }
                                                                }
                                                                break;
                                                            default:
                                                                Debug.LogError("unknown action: " + stateRequest.action.v + "; " + this);
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("server not online: " + this);
                                                    }
                                                }
                                                break;
                                            case UIData.State.Type.Wait:
                                                {
                                                    UIData.StateWait stateWait = state as UIData.StateWait;
                                                    // Process
                                                    if (Server.IsServerOnline(swapRequestStateAsk))
                                                    {
                                                        switch (stateWait.action.v)
                                                        {
                                                            case UIData.Action.Accept:
                                                                {
                                                                    if (swapRequestStateAsk.accepts.vs.Contains(profileId))
                                                                    {
                                                                        UIData.StateNone none = this.data.state.newOrOld<UIData.StateNone>();
                                                                        {

                                                                        }
                                                                        this.data.state.v = none;
                                                                    }
                                                                    else
                                                                    {
                                                                        startRoutine(ref this.wait, TaskWait());
                                                                    }
                                                                }
                                                                break;
                                                            case UIData.Action.Refuse:
                                                                {
                                                                    startRoutine(ref this.wait, TaskWait());
                                                                }
                                                                break;
                                                            default:
                                                                Debug.LogError("unknown type: " + stateWait.getType() + "; " + this);
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        UIData.StateNone none = this.data.state.newOrOld<UIData.StateNone>();
                                                        {

                                                        }
                                                        this.data.state.v = none;
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
                                // UI
                                {
                                    // UI
                                    {
                                        if (btnAccept != null)
                                        {
                                            btnAccept.gameObject.SetActive(true);
                                        }
                                        else
                                        {
                                            Debug.LogError("btnAccept null");
                                        }
                                        if (btnRefuse != null)
                                        {
                                            btnRefuse.gameObject.SetActive(true);
                                        }
                                        else
                                        {
                                            Debug.LogError("btnRefuse null");
                                        }
                                        if (tvCannotAnswer != null)
                                        {
                                            tvCannotAnswer.gameObject.SetActive(false);
                                        }
                                        else
                                        {
                                            Debug.LogError("tvCannotAnswer null");
                                        }
                                    }
                                    // btn
                                    {
                                        if (btnAccept != null && tvAccept != null && btnRefuse != null && tvRefuse != null)
                                        {
                                            UIData.State state = this.data.state.v;
                                            if (state != null)
                                            {
                                                switch (state.getType())
                                                {
                                                    case UIData.State.Type.None:
                                                        {
                                                            // btnAccept
                                                            {
                                                                btnAccept.interactable = !swapRequestStateAsk.accepts.vs.Contains(profileId);
                                                                tvAccept.text = txtAccept.get("Accept");
                                                            }
                                                            // btnRefuse
                                                            {
                                                                btnRefuse.interactable = true;
                                                                tvRefuse.text = txtRefuse.get("Refuse");
                                                            }
                                                        }
                                                        break;
                                                    case UIData.State.Type.Request:
                                                        {
                                                            UIData.StateRequest stateRequest = state as UIData.StateRequest;
                                                            switch (stateRequest.action.v)
                                                            {
                                                                case UIData.Action.Accept:
                                                                    {
                                                                        // btnAccept
                                                                        {
                                                                            btnAccept.interactable = true;
                                                                            tvAccept.text = txtCancelAccept.get("Cancel");// "Cancel Accept?";
                                                                        }
                                                                        // btnRefuse
                                                                        {
                                                                            btnRefuse.interactable = false;
                                                                            tvRefuse.text = txtRefuse.get("Refuse");
                                                                        }
                                                                    }
                                                                    break;
                                                                case UIData.Action.Refuse:
                                                                    {
                                                                        // btnAccept
                                                                        {
                                                                            btnAccept.interactable = false;
                                                                            tvAccept.text = txtAccept.get("Accept");
                                                                        }
                                                                        // btnRefuse
                                                                        {
                                                                            btnRefuse.interactable = true;
                                                                            tvRefuse.text = txtCancelRefuse.get("Cancel");// "Cancel Refuse?";
                                                                        }
                                                                    }
                                                                    break;
                                                                default:
                                                                    Debug.LogError("unknown action: " + stateRequest.action.v + "; " + this);
                                                                    break;
                                                            }
                                                        }
                                                        break;
                                                    case UIData.State.Type.Wait:
                                                        {
                                                            UIData.StateWait stateWait = state as UIData.StateWait;
                                                            switch (stateWait.action.v)
                                                            {
                                                                case UIData.Action.Accept:
                                                                    {
                                                                        // btnAccept
                                                                        {
                                                                            btnAccept.interactable = false;
                                                                            tvAccept.text = txtAccepting.get("Accepting");
                                                                        }
                                                                        // btnRefuse
                                                                        {
                                                                            btnRefuse.interactable = false;
                                                                            tvRefuse.text = txtRefuse.get("Refuse");
                                                                        }
                                                                    }
                                                                    break;
                                                                case UIData.Action.Refuse:
                                                                    {
                                                                        // btnAccept
                                                                        {
                                                                            btnAccept.interactable = false;
                                                                            tvAccept.text = txtAccept.get("Accept");
                                                                        }
                                                                        // btnRefuse
                                                                        { 
                                                                            btnRefuse.interactable = false;
                                                                            tvRefuse.text = txtRefusing.get("Refusing");
                                                                        }
                                                                    }
                                                                    break;
                                                                default:
                                                                    Debug.LogError("unkown action: " + stateWait.action.v + "; " + this);
                                                                    break;
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
                                        else
                                        {
                                            Debug.LogError("btnAccept, tvAccept, btnRefuse, tvRefuse null: " + this);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // Task
                                {
                                    {
                                        UIData.StateNone none = this.data.state.newOrOld<UIData.StateNone>();
                                        {

                                        }
                                        this.data.state.v = none;
                                    }
                                    destroyRoutine(wait);
                                }
                                // UI
                                {
                                    if (btnAccept != null)
                                    {
                                        btnAccept.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("btnAccept null");
                                    }
                                    if (btnRefuse != null)
                                    {
                                        btnRefuse.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("btnRefuse null");
                                    }
                                    if (tvCannotAnswer != null)
                                    {
                                        tvCannotAnswer.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        Debug.LogError("tvCannotAnswer null");
                                    }
                                }
                            }
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get("Answer Swap Request");
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                            if (tvCannotAnswer != null)
                            {
                                tvCannotAnswer.text = txtCannotAnswer.get("Don't have rights to answer");
                            }
                            else
                            {
                                Debug.LogError("tvCannotAnswer null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("swapRequestStateAsk null: " + this);
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

        #region Task wait

        private Routine wait;

        public IEnumerator TaskWait()
        {
            if (this.data != null)
            {
                yield return new Wait(Global.WaitSendTime);
                // Chuyen sang state none
                {
                    if (this.data != null)
                    {
                        UIData.StateNone none = this.data.state.newOrOld<UIData.StateNone>();
                        {

                        }
                        this.data.state.v = none;
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                Toast.showMessage(txtRequestError.get("Send answer error"));
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

        public WhoCanAskAdapter whoCanAskAdapterPrefab;
        private static readonly UIRectTransform whoCanAskRect = new UIRectTransform();

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
                    uiData.swapRequestStateAsk.allAddCallBack(this);
                    uiData.whoCanAskAdapter.allAddCallBack(this);
                    uiData.state.allAddCallBack(this);
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
                // swapRequestStateAsk
                {
                    if (data is SwapRequestStateAsk)
                    {
                        SwapRequestStateAsk swapRequestStateAsk = data as SwapRequestStateAsk;
                        // Parent
                        {
                            DataUtils.addParentCallBack(swapRequestStateAsk, this, ref this.server);
                        }
                        // Child
                        {
                            swapRequestStateAsk.whoCanAsks.allAddCallBack(this);
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
                    // Child
                    if (data is Human)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is WhoCanAskAdapter.UIData)
                {
                    WhoCanAskAdapter.UIData whoCanAskAdapter = data as WhoCanAskAdapter.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(whoCanAskAdapter, whoCanAskAdapterPrefab, this.transform, whoCanAskRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is UIData.State)
                {
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
                    uiData.swapRequestStateAsk.allRemoveCallBack(this);
                    uiData.whoCanAskAdapter.allRemoveCallBack(this);
                    uiData.state.allRemoveCallBack(this);
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
                // swapRequestStateAsk
                {
                    if (data is SwapRequestStateAsk)
                    {
                        SwapRequestStateAsk swapRequestStateAsk = data as SwapRequestStateAsk;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(swapRequestStateAsk, this, ref this.server);
                        }
                        // Child
                        {
                            swapRequestStateAsk.whoCanAsks.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Parent
                    if (data is Server)
                    {
                        return;
                    }
                    // Child
                    if (data is Human)
                    {
                        return;
                    }
                }
                if (data is WhoCanAskAdapter.UIData)
                {
                    WhoCanAskAdapter.UIData whoCanAskAdapter = data as WhoCanAskAdapter.UIData;
                    // UI
                    {
                        whoCanAskAdapter.removeCallBackAndDestroy(typeof(WhoCanAskAdapter));
                    }
                    return;
                }
                if (data is UIData.State)
                {
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
                    case UIData.Property.swapRequestStateAsk:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.whoCanAskAdapter:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.state:
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
                // swapRequestStateAsk
                {
                    if (wrapProperty.p is SwapRequestStateAsk)
                    {
                        switch ((SwapRequestStateAsk.Property)wrapProperty.n)
                        {
                            case SwapRequestStateAsk.Property.whoCanAsks:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case SwapRequestStateAsk.Property.accepts:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Parent
                    if (wrapProperty.p is Server)
                    {
                        Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                        return;
                    }
                    // Child
                    if (wrapProperty.p is Human)
                    {
                        Human.onUpdateSyncPlayerIdChange(wrapProperty, this);
                        return;
                    }
                }
                if (wrapProperty.p is WhoCanAskAdapter.UIData)
                {
                    return;
                }
                if (wrapProperty.p is UIData.State)
                {
                    UIData.State state = wrapProperty.p as UIData.State;
                    switch (state.getType())
                    {
                        case UIData.State.Type.None:
                            break;
                        case UIData.State.Type.Request:
                            {
                                switch ((UIData.StateRequest.Property)wrapProperty.n)
                                {
                                    case UIData.StateRequest.Property.action:
                                        dirty = true;
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                            }
                            break;
                        case UIData.State.Type.Wait:
                            {
                                switch ((UIData.StateWait.Property)wrapProperty.n)
                                {
                                    case UIData.StateWait.Property.action:
                                        dirty = true;
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                            }
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnAccept()
        {
            if (this.data != null)
            {
                UIData.State state = this.data.state.v;
                if (state != null)
                {
                    switch (state.getType())
                    {
                        case UIData.State.Type.None:
                            {
                                UIData.StateRequest stateRequest = new UIData.StateRequest();
                                {
                                    stateRequest.uid = this.data.state.makeId();
                                    stateRequest.action.v = UIData.Action.Accept;
                                }
                                this.data.state.v = stateRequest;
                            }
                            break;
                        case UIData.State.Type.Request:
                            {
                                UIData.StateRequest stateRequest = state as UIData.StateRequest;
                                switch (stateRequest.action.v)
                                {
                                    case UIData.Action.Accept:
                                        {
                                            // cancel
                                            {
                                                UIData.StateNone none = this.data.state.newOrOld<UIData.StateNone>();
                                                {

                                                }
                                                this.data.state.v = none;
                                            }
                                        }
                                        break;
                                    case UIData.Action.Refuse:
                                        {
                                            Debug.LogError("error, why can click: " + this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown action: " + stateRequest.action.v + "; " + this);
                                        break;
                                }
                            }
                            break;
                        case UIData.State.Type.Wait:
                            Debug.LogError("you are requesting: " + this);
                            break;
                        default:
                            Debug.LogError("unknown state: " + state.getType() + "; " + this);
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
                Debug.LogError("data null: " + this);
            }
        }

        public void onClickBtnRefuse()
        {
            if (this.data != null)
            {
                UIData.State state = this.data.state.v;
                if (state != null)
                {
                    switch (state.getType())
                    {
                        case UIData.State.Type.None:
                            {
                                UIData.StateRequest stateRequest = new UIData.StateRequest();
                                {
                                    stateRequest.uid = this.data.state.makeId();
                                    stateRequest.action.v = UIData.Action.Refuse;
                                }
                                this.data.state.v = stateRequest;
                            }
                            break;
                        case UIData.State.Type.Request:
                            {
                                UIData.StateRequest stateRequest = state as UIData.StateRequest;
                                switch (stateRequest.action.v)
                                {
                                    case UIData.Action.Accept:
                                        {
                                            Debug.LogError("error, why can click: " + this);
                                        }
                                        break;
                                    case UIData.Action.Refuse:
                                        {
                                            // cancel
                                            {
                                                UIData.StateNone none = this.data.state.newOrOld<UIData.StateNone>();
                                                {

                                                }
                                                this.data.state.v = none;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown action: " + stateRequest.action.v + "; " + this);
                                        break;
                                }
                            }
                            break;
                        case UIData.State.Type.Wait:
                            Debug.LogError("you are requesting: " + this);
                            break;
                        default:
                            Debug.LogError("unknown state: " + state.getType() + "; " + this);
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
                Debug.LogError("data null: " + this);
            }
        }

    }
}