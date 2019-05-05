using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class FriendStateRequestUI : UIBehavior<FriendStateRequestUI.UIData>
{

    #region UIData

    public class UIData : FriendStateUI.UIData.Sub
    {

        public VP<ReferenceData<FriendStateRequest>> friendStateRequest;

        #region State

        public enum State
        {
            None,
            RequestAccept,
            RequestRefuse,
            RequestCancel,
            WaitAccept,
            WaitRefuse,
            WaitCancel
        }

        public VP<State> state;

        #endregion

        #region Constructor

        public enum Property
        {
            friendStateRequest,
            state
        }

        public UIData() : base()
        {
            this.friendStateRequest = new VP<ReferenceData<FriendStateRequest>>(this, (byte)Property.friendStateRequest, new ReferenceData<FriendStateRequest>(null));
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public override Friend.State.Type getType()
        {
            return Friend.State.Type.Request;
        }

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
                        FriendStateRequestUI friendStateRequestUI = this.findCallBack<FriendStateRequestUI>();
                        if (friendStateRequestUI != null)
                        {
                            isProcess = friendStateRequestUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("friendStateRequestUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text tvAccept;
    private static readonly TxtLanguage txtAccept = new TxtLanguage("Accept");
    private static readonly TxtLanguage txtAccepting = new TxtLanguage("Accepting");

    public Text tvRefuse;
    private static readonly TxtLanguage txtRefuse = new TxtLanguage("Refuse");
    private static readonly TxtLanguage txtRefusing = new TxtLanguage("Refusing");

    public Text tvCancel;
    private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");
    private static readonly TxtLanguage txtCancelling = new TxtLanguage("Cancelling");

    private static readonly TxtLanguage txtRequestError = new TxtLanguage("Request error");

    static FriendStateRequestUI()
    {
        txtAccept.add(Language.Type.vi, "Chấp Nhận");
        txtAccepting.add(Language.Type.vi, "Đang chấp nhận");
        txtRefuse.add(Language.Type.vi, "Từ Chối");
        txtRefusing.add(Language.Type.vi, "Đang từ chối");
        txtCancel.add(Language.Type.vi, "Huỷ Bỏ");
        txtCancelling.add(Language.Type.vi, "Đang huỷ bỏ");

        txtRequestError.add(Language.Type.vi, "Yêu cầu thất bại");
    }

    #endregion

    #region Refresh

    public Button btnAccept;
    public Button btnRefuse;
    public Button btnCancel;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                FriendStateRequest friendStateRequest = this.data.friendStateRequest.v.data;
                if (friendStateRequest != null)
                {
                    // btnAccept, btnRefuse
                    {
                        if (btnAccept != null && btnRefuse != null)
                        {
                            if (friendStateRequest.isCanAnswer(Server.getProfileUserId(friendStateRequest)))
                            {
                                btnAccept.gameObject.SetActive(true);
                                btnRefuse.gameObject.SetActive(true);
                                // enable?
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            btnAccept.interactable = true;
                                            btnRefuse.interactable = true;
                                        }
                                        break;
                                    case UIData.State.RequestAccept:
                                        {
                                            btnAccept.interactable = true;
                                            btnRefuse.interactable = false;
                                        }
                                        break;
                                    case UIData.State.RequestRefuse:
                                        {
                                            btnAccept.interactable = false;
                                            btnRefuse.interactable = true;
                                        }
                                        break;
                                    case UIData.State.WaitAccept:
                                    case UIData.State.WaitRefuse:
                                    case UIData.State.RequestCancel:
                                    case UIData.State.WaitCancel:
                                        {
                                            btnAccept.interactable = false;
                                            btnRefuse.interactable = false;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                btnAccept.gameObject.SetActive(false);
                                btnRefuse.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            Debug.LogError("btnAccept, btnRefuse null: " + this);
                        }
                    }
                    // btnCancel
                    {
                        if (btnCancel != null)
                        {
                            if (friendStateRequest.isCanCancel(Server.getProfileUserId(friendStateRequest)))
                            {
                                btnCancel.gameObject.SetActive(true);
                                // enable?
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            btnCancel.interactable = true;
                                        }
                                        break;
                                    case UIData.State.RequestCancel:
                                        {
                                            btnCancel.interactable = true;
                                        }
                                        break;
                                    case UIData.State.RequestAccept:
                                    case UIData.State.RequestRefuse:
                                    case UIData.State.WaitAccept:
                                    case UIData.State.WaitRefuse:
                                    case UIData.State.WaitCancel:
                                        {
                                            btnCancel.interactable = false;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                btnCancel.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            Debug.LogError("btnCancel null: " + this);
                        }
                    }
                    // tv
                    {
                        if(tvAccept!=null && tvRefuse!=null && tvCancel != null)
                        {
                            switch (this.data.state.v)
                            {
                                case UIData.State.None:
                                    {
                                        tvAccept.text = txtAccept.get();
                                        tvRefuse.text = txtRefuse.get();
                                        tvCancel.text = txtCancel.get();
                                    }
                                    break;
                                case UIData.State.RequestAccept:
                                case UIData.State.WaitAccept:
                                    {
                                        tvAccept.text = txtAccepting.get();
                                        tvRefuse.text = txtRefuse.get();
                                        tvCancel.text = txtCancel.get();
                                    }
                                    break;
                                case UIData.State.RequestRefuse:
                                case UIData.State.WaitRefuse:
                                    {
                                        tvAccept.text = txtAccept.get();
                                        tvRefuse.text = txtRefusing.get();
                                        tvCancel.text = txtCancel.get();
                                    }
                                    break;
                                case UIData.State.RequestCancel:
                                case UIData.State.WaitCancel:
                                    {
                                        tvAccept.text = txtAccept.get();
                                        tvRefuse.text = txtRefuse.get();
                                        tvCancel.text = txtCancelling.get();
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown state: " + this.data.state.v);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("tv null");
                        }
                    }
                    // Task
                    {
                        switch (this.data.state.v)
                        {
                            case UIData.State.None:
                                {
                                    destroyRoutine(wait);
                                }
                                break;
                            case UIData.State.RequestAccept:
                                {
                                    destroyRoutine(wait);
                                    // request
                                    if (Server.IsServerOnline(friendStateRequest))
                                    {
                                        friendStateRequest.requestAccept(Server.getProfileUserId(friendStateRequest));
                                        this.data.state.v = UIData.State.WaitAccept;
                                    }
                                    else
                                    {
                                        Debug.LogError("server not online: " + this);
                                    }
                                }
                                break;
                            case UIData.State.RequestRefuse:
                                {
                                    destroyRoutine(wait);
                                    // request
                                    if (Server.IsServerOnline(friendStateRequest))
                                    {
                                        friendStateRequest.requestRefuse(Server.getProfileUserId(friendStateRequest));
                                        this.data.state.v = UIData.State.WaitRefuse;
                                    }
                                    else
                                    {
                                        Debug.LogError("server not online: " + this);
                                    }
                                }
                                break;
                            case UIData.State.RequestCancel:
                                {
                                    destroyRoutine(wait);
                                    // request
                                    if (Server.IsServerOnline(friendStateRequest))
                                    {
                                        friendStateRequest.requestCancel(Server.getProfileUserId(friendStateRequest));
                                        this.data.state.v = UIData.State.WaitCancel;
                                    }
                                    else
                                    {
                                        Debug.LogError("server not online: " + this);
                                    }
                                }
                                break;
                            case UIData.State.WaitAccept:
                            case UIData.State.WaitRefuse:
                            case UIData.State.WaitCancel:
                                {
                                    if (Server.IsServerOnline(friendStateRequest))
                                    {
                                        startRoutine(ref this.wait, TaskWait());
                                    }
                                    else
                                    {
                                        this.data.state.v = UIData.State.None;
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                break;
                        }
                    }
                }
                else
                {
                    Debug.LogError("friendStateRequest null: " + this);
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

    private Server server = null;
    private Friend friend = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.friendStateRequest.allAddCallBack(this);
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
        // Child
        {
            if (data is FriendStateRequest)
            {
                FriendStateRequest friendStateRequest = data as FriendStateRequest;
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
                    DataUtils.addParentCallBack(friendStateRequest, this, ref this.server);
                    DataUtils.addParentCallBack(friendStateRequest, this, ref this.friend);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                // Server
                if (data is Server)
                {
                    dirty = true;
                    return;
                }
                // Friend
                {
                    if (data is Friend)
                    {
                        Friend friend = data as Friend;
                        // Child
                        {
                            friend.user1.allAddCallBack(this);
                            friend.user2.allAddCallBack(this);
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
                uiData.friendStateRequest.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if(data is Setting)
        {
            return;
        }
        // Child
        {
            if (data is FriendStateRequest)
            {
                FriendStateRequest friendStateRequest = data as FriendStateRequest;
                // Parent
                {
                    DataUtils.removeParentCallBack(friendStateRequest, this, ref this.server);
                    DataUtils.removeParentCallBack(friendStateRequest, this, ref this.friend);
                }
                return;
            }
            // Parent
            {
                // Server
                if (data is Server)
                {
                    return;
                }
                // Friend
                {
                    if (data is Friend)
                    {
                        Friend friend = data as Friend;
                        // Child
                        {
                            friend.user1.allRemoveCallBack(this);
                            friend.user2.allRemoveCallBack(this);
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
                case UIData.Property.friendStateRequest:
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
        // Child
        {
            if (wrapProperty.p is FriendStateRequest)
            {
                switch ((FriendStateRequest.Property)wrapProperty.n)
                {
                    case FriendStateRequest.Property.accepts:
                        {
                            dirty = true;
                            if (this.data != null)
                            {
                                this.data.reset();
                            }
                        }
                        break;
                    case FriendStateRequest.Property.refuses:
                        {
                            dirty = true;
                            if (this.data != null)
                            {
                                this.data.reset();
                            }
                        }
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                // Server
                if (wrapProperty.p is Server)
                {
                    Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                    return;
                }
                // Friend
                {
                    if (wrapProperty.p is Friend)
                    {
                        switch ((Friend.Property)wrapProperty.n)
                        {
                            case Friend.Property.state:
                                break;
                            case Friend.Property.user1:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case Friend.Property.user2:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case Friend.Property.time:
                                break;
                            case Friend.Property.chatRoom:
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
                    this.data.state.v = UIData.State.RequestAccept;
                    break;
                case UIData.State.RequestAccept:
                    this.data.state.v = UIData.State.None;
                    break;
                case UIData.State.RequestRefuse:
                    break;
                case UIData.State.RequestCancel:
                    break;
                case UIData.State.WaitAccept:
                    break;
                case UIData.State.WaitRefuse:
                    break;
                case UIData.State.WaitCancel:
                    break;
                default:
                    Debug.LogError("unknown state: " + this.data.state.v);
                    break;
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnRefuse()
    {
        if (this.data != null)
        {
            switch (this.data.state.v)
            {
                case UIData.State.None:
                    this.data.state.v = UIData.State.RequestRefuse;
                    break;
                case UIData.State.RequestAccept:
                    break;
                case UIData.State.RequestRefuse:
                    this.data.state.v = UIData.State.None;
                    break;
                case UIData.State.RequestCancel:
                    break;
                case UIData.State.WaitAccept:
                    break;
                case UIData.State.WaitRefuse:
                    break;
                case UIData.State.WaitCancel:
                    break;
                default:
                    Debug.LogError("unknown state: " + this.data.state.v);
                    break;
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnCancel()
    {
        if (this.data != null)
        {
            switch (this.data.state.v)
            {
                case UIData.State.None:
                    this.data.state.v = UIData.State.RequestCancel;
                    break;
                case UIData.State.RequestAccept:
                    break;
                case UIData.State.RequestRefuse:
                    break;
                case UIData.State.RequestCancel:
                    this.data.state.v = UIData.State.None;
                    break;
                case UIData.State.WaitAccept:
                    break;
                case UIData.State.WaitRefuse:
                    break;
                case UIData.State.WaitCancel:
                    break;
                default:
                    Debug.LogError("unknown state: " + this.data.state.v);
                    break;
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}