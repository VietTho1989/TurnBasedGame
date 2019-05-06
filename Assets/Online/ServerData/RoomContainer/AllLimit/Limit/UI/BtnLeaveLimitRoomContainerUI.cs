using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class BtnLeaveLimitRoomContainerUI : UIBehavior<BtnLeaveLimitRoomContainerUI.UIData>
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

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        BtnLeaveLimitRoomContainerUI btnLeaveLimitRoomContainerUI = this.findCallBack<BtnLeaveLimitRoomContainerUI>();
                        if (btnLeaveLimitRoomContainerUI != null)
                        {
                            isProcess = btnLeaveLimitRoomContainerUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("btnLeaveLimitRoomContainerUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region Refresh

    public Button btnLeave;
    public Text tvLeave;

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
                    uint profileId = Server.getProfileUserId(limitRoomContainer);
                    if (limitRoomContainer.isCanLeave(profileId))
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
                                            if (Server.IsServerOnline(limitRoomContainer))
                                            {
                                                limitRoomContainer.requestLeave(profileId);
                                                this.data.state.v = UIData.State.Wait;
                                            }
                                            else
                                            {
                                                Debug.LogError("server not online");
                                            }
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
                                            this.data.state.v = UIData.State.None;
                                            destroyRoutine(wait);
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
                            if (btnLeave != null && tvLeave != null)
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            btnLeave.interactable = true;
                                            tvLeave.text = "Leave";
                                        }
                                        break;
                                    case UIData.State.Request:
                                        {
                                            btnLeave.interactable = true;
                                            tvLeave.text = "Cancel Leave?";
                                        }
                                        break;
                                    case UIData.State.Wait:
                                        {
                                            btnLeave.interactable = false;
                                            tvLeave.text = "Leaving...";
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("btnLeave, tvLeave null");
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
                            if (btnLeave != null && tvLeave != null)
                            {
                                btnLeave.interactable = false;
                                tvLeave.text = "Cannot Leave";
                            }
                            else
                            {
                                Debug.LogError("btnLeave, tvLeave null");
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
                // Debug.LogError ("data null");
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
                        break;
                    case LimitRoomContainer.Property.userCount:
                        break;
                    case LimitRoomContainer.Property.users:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case LimitRoomContainer.Property.gameTypes:
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

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.L:
                        {
                            if (btnLeave != null && btnLeave.gameObject.activeInHierarchy && btnLeave.interactable)
                            {
                                this.onClickBtnLeave();
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
    public void onClickBtnLeave()
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
                    Debug.LogError("you are leaving...");
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

}