using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class FriendStateBanUI : UIBehavior<FriendStateBanUI.UIData>
{

    #region UIData

    public class UIData : FriendStateUI.UIData.Sub
    {

        public VP<ReferenceData<FriendStateBan>> friendStateBan;

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
            friendStateBan,
            state
        }

        public UIData() : base()
        {
            this.friendStateBan = new VP<ReferenceData<FriendStateBan>>(this, (byte)Property.friendStateBan, new ReferenceData<FriendStateBan>(null));
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public override Friend.State.Type getType()
        {
            return Friend.State.Type.Ban;
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
                        FriendStateBanUI friendStateBanUI = this.findCallBack<FriendStateBanUI>();
                        if (friendStateBanUI != null)
                        {
                            isProcess = friendStateBanUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("friendStateBanUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text tvUnBan;
    private static readonly TxtLanguage txtUnBan = new TxtLanguage("Unban");
    private static readonly TxtLanguage txtUnBanning = new TxtLanguage("Unbanning");

    private static readonly TxtLanguage txtRequestError = new TxtLanguage("Request unban error");

    static FriendStateBanUI()
    {
        txtUnBan.add(Language.Type.vi, "Huỷ Cấm");
        txtUnBanning.add(Language.Type.vi, "Đang huỷ cấm");
        txtRequestError.add(Language.Type.vi, "Yêu cầu huỷ cấm lỗi");
    }

    #endregion

    #region Refresh

    public Button btnUnBan;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                FriendStateBan friendStateBan = this.data.friendStateBan.v.data;
                if (friendStateBan != null)
                {
                    // btnUnBan
                    {
                        if (btnUnBan != null)
                        {
                            if (friendStateBan.isCanUnBan(Server.getProfileUserId(friendStateBan)))
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        btnUnBan.interactable = true;
                                        break;
                                    case UIData.State.Request:
                                        btnUnBan.interactable = true;
                                        break;
                                    case UIData.State.Wait:
                                        btnUnBan.interactable = false;
                                        break;
                                    default:
                                        Debug.LogError("Unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                btnUnBan.interactable = false;
                                this.data.state.v = UIData.State.None;
                            }
                        }
                        else
                        {
                            Debug.LogError("btnUnBan null: " + this);
                        }
                    }
                    // tvUnBan
                    {
                        if (tvUnBan != null)
                        {
                            switch (this.data.state.v)
                            {
                                case UIData.State.None:
                                    tvUnBan.text = txtUnBan.get();
                                    break;
                                case UIData.State.Request:
                                    tvUnBan.text = txtUnBanning.get();
                                    break;
                                case UIData.State.Wait:
                                    tvUnBan.text = txtUnBanning.get();
                                    break;
                                default:
                                    Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("tvUnBan null: " + this);
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
                            case UIData.State.Request:
                                {
                                    destroyRoutine(wait);
                                    // request
                                    if (Server.IsServerOnline(friendStateBan))
                                    {
                                        friendStateBan.requestUnBan(Server.getProfileUserId(friendStateBan));
                                        this.data.state.v = UIData.State.Wait;
                                    }
                                    else
                                    {
                                        Debug.LogError("server not online: " + this);
                                    }
                                }
                                break;
                            case UIData.State.Wait:
                                {
                                    if (Server.IsServerOnline(friendStateBan))
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
                    Debug.LogError("friendStateAccept null: " + this);
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
            Debug.LogError("request unfriend error: " + this);
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
                uiData.friendStateBan.allAddCallBack(this);
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
            if (data is FriendStateBan)
            {
                FriendStateBan friendStateBan = data as FriendStateBan;
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
                    DataUtils.addParentCallBack(friendStateBan, this, ref this.server);
                    DataUtils.addParentCallBack(friendStateBan, this, ref this.friend);
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
                uiData.friendStateBan.allRemoveCallBack(this);
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
            if (data is FriendStateBan)
            {
                FriendStateBan friendStateBan = data as FriendStateBan;
                // Parent
                {
                    DataUtils.removeParentCallBack(friendStateBan, this, ref this.server);
                    DataUtils.removeParentCallBack(friendStateBan, this, ref this.friend);
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
                case UIData.Property.friendStateBan:
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
            if (wrapProperty.p is FriendStateBan)
            {
                switch ((FriendStateBan.Property)wrapProperty.n)
                {
                    case FriendStateBan.Property.userId:
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

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.U:
                        {
                            if (btnUnBan != null && btnUnBan.gameObject.activeInHierarchy && btnUnBan.interactable)
                            {
                                this.onClickBtnUnBan();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnUnBan()
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
                    Debug.LogError("You are requesting");
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