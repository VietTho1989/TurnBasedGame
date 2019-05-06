using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class JoinLimitRoomContainerUI : UIBehavior<JoinLimitRoomContainerUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<LimitRoomContainer>> limitRoomContainer;

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
            limitRoomContainer,
            state
        }

        public UIData() : base()
        {
            this.limitRoomContainer = new VP<ReferenceData<LimitRoomContainer>>(this, (byte)Property.limitRoomContainer, new ReferenceData<LimitRoomContainer>(null));
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
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        JoinLimitRoomContainerUI joinLimitRoomContainerUI = this.findCallBack<JoinLimitRoomContainerUI>();
                        if (joinLimitRoomContainerUI != null)
                        {
                            joinLimitRoomContainerUI.onClickBtnCancel();
                        }
                        else
                        {
                            Debug.LogError("joinLimitRoomContainerUI null");
                        }
                        isProcess = true;
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        JoinLimitRoomContainerUI joinLimitRoomContainerUI = this.findCallBack<JoinLimitRoomContainerUI>();
                        if (joinLimitRoomContainerUI != null)
                        {
                            isProcess = joinLimitRoomContainerUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("joinLimitRoomContainerUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region Refresh

    public Text tvIndex;
    public Text tvGameType;
    public Text tvUserCount;

    public Button btnJoin;
    public Text tvJoin;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                LimitRoomContainer limitRoomContainer = this.data.limitRoomContainer.v.data;
                if (limitRoomContainer != null)
                {
                    // tvIndex
                    {
                        if (tvIndex != null)
                        {
                            int index = 0;
                            {
                                AllLimitRoomContainers allLimitRoomContainers = limitRoomContainer.findDataInParent<AllLimitRoomContainers>();
                                if (allLimitRoomContainers != null)
                                {
                                    index = allLimitRoomContainers.limitRoomContainers.vs.IndexOf(limitRoomContainer);
                                }
                                else
                                {
                                    Debug.LogError("limitRoomContainer null");
                                }
                            }
                            tvIndex.text = "" + index;
                        }
                        else
                        {
                            Debug.LogError("tvIndex null");
                        }
                    }
                    // tvGameType
                    {
                        if (tvGameType != null)
                        {
                            if (limitRoomContainer.gameTypes.vs.Count == 0)
                            {
                                tvGameType.text = "None";
                            }
                            else if (limitRoomContainer.gameTypes.vs.Count == 1)
                            {
                                GameType.Type gameType = limitRoomContainer.gameTypes.vs[0];
                                tvGameType.text = "" + gameType;
                            }
                            else if (limitRoomContainer.gameTypes.vs.Count > 1)
                            {
                                tvGameType.text = "Mix";
                            }
                        }
                        else
                        {
                            Debug.LogError("tvGameType null");
                        }
                    }
                    // tvUserCount
                    {
                        if (tvUserCount != null)
                        {
                            tvUserCount.text = limitRoomContainer.userCount.v + "/" + limitRoomContainer.maxUserCount.v;
                        }
                        else
                        {
                            Debug.LogError("tvUserCount null");
                        }
                    }
                    // join
                    {
                        uint profileId = Server.getProfileUserId(limitRoomContainer);
                        if (limitRoomContainer.isCanJoin(profileId))
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
                                            if (Server.IsServerOnline(limitRoomContainer))
                                            {
                                                limitRoomContainer.requestJoin(profileId);
                                                this.data.state.v = UIData.State.Wait;
                                            }
                                            else
                                            {
                                                Debug.LogError("server not online");
                                            }
                                        }
                                        break;
                                    case UIData.State.Wait:
                                        {
                                            if (Server.IsServerOnline(limitRoomContainer))
                                            {
                                                startRoutine(ref this.wait, TaskWait());
                                            }
                                            else
                                            {
                                                destroyRoutine(wait);
                                                this.data.state.v = UIData.State.None;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v);
                                        break;
                                }
                            }
                            // UI
                            {
                                if (btnJoin != null && tvJoin != null)
                                {
                                    switch (this.data.state.v)
                                    {
                                        case UIData.State.None:
                                            {
                                                btnJoin.interactable = true;
                                                tvJoin.text = "Join";
                                            }
                                            break;
                                        case UIData.State.Request:
                                            {
                                                btnJoin.interactable = true;
                                                tvJoin.text = "Cancel Join?";
                                            }
                                            break;
                                        case UIData.State.Wait:
                                            {
                                                btnJoin.interactable = false;
                                                tvJoin.text = "Joining...";
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown state: " + this.data.state.v);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("btnJoin, tvJoin null");
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
                                if (btnJoin != null && tvJoin != null)
                                {
                                    btnJoin.interactable = false;
                                    tvJoin.text = "Cannot Join";
                                }
                                else
                                {
                                    Debug.LogError("btnJoin, tvJoin null");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("limitRoomContainer null");
                }
            }
            else
            {
                Debug.LogError("data null");
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

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.limitRoomContainer.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is LimitRoomContainer)
            {
                LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
                // reset
                {
                    if (this.data != null)
                    {
                        this.data.reset();
                    }
                    else
                    {
                        Debug.LogError("data null");
                    }
                }
                // Parent
                {
                    DataUtils.addParentCallBack(limitRoomContainer, this, ref this.server);
                }
                // Child
                {
                    limitRoomContainer.users.allAddCallBack(this);
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
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.limitRoomContainer.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is LimitRoomContainer)
            {
                LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
                // Parent
                {
                    DataUtils.removeParentCallBack(limitRoomContainer, this, ref this.server);
                }
                // Child
                {
                    limitRoomContainer.users.allRemoveCallBack(this);
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
                case UIData.Property.limitRoomContainer:
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
        // Child
        {
            if (wrapProperty.p is LimitRoomContainer)
            {
                switch ((LimitRoomContainer.Property)wrapProperty.n)
                {
                    case LimitRoomContainer.Property.maxUserCount:
                        dirty = true;
                        break;
                    case LimitRoomContainer.Property.userCount:
                        dirty = true;
                        break;
                    case LimitRoomContainer.Property.users:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case LimitRoomContainer.Property.gameTypes:
                        dirty = true;
                        break;
                    case LimitRoomContainer.Property.rooms:
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnJoin, onClickBtnJoin);
        }
    }

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.J:
                        {
                            if (btnJoin != null && btnJoin.gameObject.activeInHierarchy && btnJoin.interactable)
                            {
                                this.onClickBtnJoin();
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
    public void onClickBtnJoin()
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
                    break;
                default:
                    Debug.LogError("unknown state: " + this.data.state.v);
                    break;
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnCancel()
    {
        if (this.data != null)
        {
            LimitRoomContainerListUI.UIData limitRoomContainerListUIData = this.data.findDataInParent<LimitRoomContainerListUI.UIData>();
            if (limitRoomContainerListUIData != null)
            {
                limitRoomContainerListUIData.joinLimitRoomContainerUIData.v = null;
            }
            else
            {
                Debug.LogError("limitRoomContainerListUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}