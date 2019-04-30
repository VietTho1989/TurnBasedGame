using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class FriendStateNoneUI : UIBehavior<FriendStateNoneUI.UIData>
{

    #region UIData

    public class UIData : FriendStateUI.UIData.Sub
    {

        public VP<ReferenceData<FriendStateNone>> friendStateNone;

        #region State

        public enum State
        {
            None,
            RequestMakeFriend,
            RequestBan,
            WaitMakeFriend,
            WaitMakeBan
        }

        public VP<State> state;

        #endregion

        #region Constructor

        public enum Property
        {
            friendStateNone,
            state
        }

        public UIData() : base()
        {
            this.friendStateNone = new VP<ReferenceData<FriendStateNone>>(this, (byte)Property.friendStateNone, new ReferenceData<FriendStateNone>(null));
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public override Friend.State.Type getType()
        {
            return Friend.State.Type.None;
        }

        public void reset()
        {
            this.state.v = State.None;
        }

    }

    #endregion

    #region txt

    public Text tvMakeFriend;
    private static readonly TxtLanguage txtMakeFriend = new TxtLanguage("Make Friend");
    private static readonly TxtLanguage txtMakingFriend = new TxtLanguage("Making Friend");

    public Text tvBan;
    private static readonly TxtLanguage txtBan = new TxtLanguage("Ban");
    private static readonly TxtLanguage txtBanning = new TxtLanguage("Banning");

    static FriendStateNoneUI()
    {
        txtMakeFriend.add(Language.Type.vi, "Kết Bạn");
        txtMakingFriend.add(Language.Type.vi, "Đang kết bạn");
        txtBan.add(Language.Type.vi, "Cấm");
        txtBanning.add(Language.Type.vi, "Đang cấm");
    }

    #endregion

    #region Refresh

    public Button btnMakeFriend;
    public Button btnBan;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                FriendStateNone friendStateNone = this.data.friendStateNone.v.data;
                if (friendStateNone != null)
                {
                    // btnMakeFriend, btnBan
                    {
                        if (btnMakeFriend != null && btnBan != null)
                        {
                            if (friendStateNone.isCanRequest(Server.getProfileUserId(friendStateNone)))
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            btnMakeFriend.interactable = true;
                                            btnBan.interactable = true;
                                        }
                                        break;
                                    case UIData.State.RequestMakeFriend:
                                        {
                                            btnMakeFriend.interactable = true;
                                            btnBan.interactable = false;
                                        }
                                        break;
                                    case UIData.State.RequestBan:
                                        {
                                            btnMakeFriend.interactable = false;
                                            btnBan.interactable = true;
                                        }
                                        break;
                                    case UIData.State.WaitMakeFriend:
                                    case UIData.State.WaitMakeBan:
                                        {
                                            btnMakeFriend.interactable = false;
                                            btnBan.interactable = false;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                btnMakeFriend.interactable = false;
                                btnBan.interactable = false;
                            }
                        }
                        else
                        {
                            Debug.LogError("btnMakeFriend, btnBan null: " + this);
                        }
                    }
                    // requestingIndicator
                    {
                        if (tvMakeFriend != null && tvBan != null)
                        {
                            switch (this.data.state.v)
                            {
                                case UIData.State.None:
                                    {
                                        tvMakeFriend.text = txtMakeFriend.get();
                                        tvBan.text = txtBan.get();
                                    }
                                    break;
                                case UIData.State.RequestMakeFriend:
                                    {
                                        tvMakeFriend.text = txtMakingFriend.get();
                                        tvBan.text = txtBan.get();
                                    }
                                    break;
                                case UIData.State.WaitMakeFriend:
                                    {
                                        tvMakeFriend.text = txtMakingFriend.get();
                                        tvBan.text = txtBan.get();
                                    }
                                    break;
                                case UIData.State.RequestBan:
                                    {
                                        tvMakeFriend.text = txtMakeFriend.get();
                                        tvBan.text = txtBanning.get();
                                    }
                                    break;
                                case UIData.State.WaitMakeBan:
                                    {
                                        tvMakeFriend.text = txtMakeFriend.get();
                                        tvBan.text = txtBanning.get();
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("tvMakeFriend, tvBan null: " + this);
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
                            case UIData.State.RequestMakeFriend:
                                {
                                    destroyRoutine(wait);
                                    // request
                                    if (Server.IsServerOnline(friendStateNone))
                                    {
                                        friendStateNone.requestMakeFriend(Server.getProfileUserId(friendStateNone));
                                        this.data.state.v = UIData.State.WaitMakeFriend;
                                    }
                                    else
                                    {
                                        Debug.LogError("server not online: " + this);
                                    }
                                }
                                break;
                            case UIData.State.RequestBan:
                                {
                                    destroyRoutine(wait);
                                    // request
                                    if (Server.IsServerOnline(friendStateNone))
                                    {
                                        friendStateNone.requestBan(Server.getProfileUserId(friendStateNone));
                                        this.data.state.v = UIData.State.WaitMakeBan;
                                    }
                                    else
                                    {
                                        Debug.LogError("server not online: " + this);
                                    }
                                }
                                break;
                            case UIData.State.WaitMakeFriend:
                            case UIData.State.WaitMakeBan:
                                {
                                    if (Server.IsServerOnline(friendStateNone))
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
                    Debug.LogError("friendStateNone null:  " + this);
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
                uiData.friendStateNone.allAddCallBack(this);
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
            if (data is FriendStateNone)
            {
                FriendStateNone friendStateNone = data as FriendStateNone;
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
                    DataUtils.addParentCallBack(friendStateNone, this, ref this.server);
                    DataUtils.addParentCallBack(friendStateNone, this, ref this.friend);
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
                uiData.friendStateNone.allRemoveCallBack(this);
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
            if (data is FriendStateNone)
            {
                FriendStateNone friendStateNone = data as FriendStateNone;
                // Parent
                {
                    DataUtils.removeParentCallBack(friendStateNone, this, ref this.server);
                    DataUtils.removeParentCallBack(friendStateNone, this, ref this.friend);
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
                case UIData.Property.friendStateNone:
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
            if (wrapProperty.p is FriendStateNone)
            {
                switch ((FriendStateNone.Property)wrapProperty.n)
                {
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

    public void onClickBtnMakeFriend()
    {
        if (this.data != null)
        {
            switch (this.data.state.v)
            {
                case UIData.State.None:
                    this.data.state.v = UIData.State.RequestMakeFriend;
                    break;
                case UIData.State.RequestMakeFriend:
                    this.data.state.v = UIData.State.None;
                    break;
                case UIData.State.WaitMakeFriend:
                    break;
                case UIData.State.RequestBan:
                    break;
                case UIData.State.WaitMakeBan:
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

    public void onClickBtnBan()
    {
        if (this.data != null)
        {
            switch (this.data.state.v)
            {
                case UIData.State.None:
                    this.data.state.v = UIData.State.RequestBan;
                    break;
                case UIData.State.RequestMakeFriend:
                    break;
                case UIData.State.WaitMakeFriend:
                    break;
                case UIData.State.RequestBan:
                    this.data.state.v = UIData.State.None;
                    break;
                case UIData.State.WaitMakeBan:
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