﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class BtnLoadHistoryUI : UIBehavior<BtnLoadHistoryUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<History>> history;

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
            history,
            state
        }

        public UIData() : base()
        {
            this.history = new VP<ReferenceData<History>>(this, (byte)Property.history, new ReferenceData<History>(null));
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
                        BtnLoadHistoryUI btnLoadHistoryUI = this.findCallBack<BtnLoadHistoryUI>();
                        if (btnLoadHistoryUI != null)
                        {
                            isProcess = btnLoadHistoryUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("btnLoadHistoryUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtLoad = new TxtLanguage("Load");
    private static readonly TxtLanguage txtCancelLoad = new TxtLanguage("Cancel load?");
    private static readonly TxtLanguage txtLoading = new TxtLanguage("Loading");

    private static readonly TxtLanguage txtUnload = new TxtLanguage("Unload");
    private static readonly TxtLanguage txtCancelUnload = new TxtLanguage("Cancel Unload?");
    private static readonly TxtLanguage txtUnloading = new TxtLanguage("Unloading");

    private static readonly TxtLanguage txtCannotLoad = new TxtLanguage("Can't Load");

    private static readonly TxtLanguage txtRequestError = new TxtLanguage("Load history error");

    static BtnLoadHistoryUI()
    {
        txtLoad.add(Language.Type.vi, "Tải");
        txtCancelLoad.add(Language.Type.vi, "Huỷ tải?");
        txtLoading.add(Language.Type.vi, "Đang tải...");

        txtUnload.add(Language.Type.vi, "Dỡ");
        txtCancelUnload.add(Language.Type.vi, "Huỷ dỡ?");
        txtUnloading.add(Language.Type.vi, "Đang dỡ");

        txtCannotLoad.add(Language.Type.vi, "Không được tải");

        txtRequestError.add(Language.Type.vi, "Tải lịch sử lỗi");
    }

    #endregion

    #region Refresh

    public Button btnLoad;
    public Text tvLoad;

    private bool needReset = false;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                History history = this.data.history.v.data;
                if (history != null)
                {
                    // reset
                    {
                        if (needReset)
                        {
                            needReset = false;
                            this.data.state.v = UIData.State.None;
                        }
                    }
                    uint profileId = Server.getProfileUserId(history);
                    // check is client
                    bool isClient = false;
                    {
                        Server server = history.findDataInParent<Server>();
                        if (server != null)
                        {
                            if (server.type.v == Server.Type.Client)
                            {
                                isClient = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("server null: " + this);
                        }
                    }
                    // find allowLoadHistory
                    bool allowLoadHistory = false;
                    {
                        Room room = history.findDataInParent<Room>();
                        if (room != null)
                        {
                            allowLoadHistory = room.allowLoadHistory.v;
                        }
                        else
                        {
                            Debug.LogError("room null: " + this);
                        }
                    }
                    // Process
                    if (isClient && allowLoadHistory)
                    {
                        // valueChangeCallBacks
                        {
                            history.humanConnections.allAddCallBack(this);
                        }
                        // check already load
                        bool alreadyLoad = false;
                        {
                            HumanConnection humanConnection = history.humanConnections.getInList(profileId);
                            if (humanConnection != null)
                            {
                                alreadyLoad = true;
                            }
                            else
                            {
                                Debug.LogError("humanConnection null: " + this);
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
                                        if (Server.IsServerOnline(history))
                                        {
                                            if (!alreadyLoad)
                                            {
                                                history.requestAddHumanConnection(profileId);
                                            }
                                            else
                                            {
                                                history.requestRemoveHumanConnection(profileId);
                                            }
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
                                        if (Server.IsServerOnline(history))
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
                                    Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                    break;
                            }
                        }
                        // UI
                        {
                            if (btnLoad != null && tvLoad != null)
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            if (!alreadyLoad)
                                            {
                                                btnLoad.interactable = true;
                                                tvLoad.text = txtLoad.get();
                                            }
                                            else
                                            {
                                                btnLoad.interactable = true;
                                                tvLoad.text = txtUnload.get();
                                            }
                                        }
                                        break;
                                    case UIData.State.Request:
                                        {
                                            if (!alreadyLoad)
                                            {
                                                btnLoad.interactable = true;
                                                tvLoad.text = txtCancelLoad.get();
                                            }
                                            else
                                            {
                                                btnLoad.interactable = true;
                                                tvLoad.text = txtCancelUnload.get();
                                            }
                                        }
                                        break;
                                    case UIData.State.Wait:
                                        {
                                            if (!alreadyLoad)
                                            {
                                                btnLoad.interactable = false;
                                                tvLoad.text = txtLoading.get();
                                            }
                                            else
                                            {
                                                btnLoad.interactable = false;
                                                tvLoad.text = txtUnloading.get();
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("btnLoad, tvLoad null: " + this);
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
                            if (btnLoad != null && tvLoad != null)
                            {
                                btnLoad.interactable = false;
                                tvLoad.text = txtCannotLoad.get();
                            }
                            else
                            {
                                Debug.LogError("btnLoad, tvLoad null");
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("history null: " + this);
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
            this.data.state.v = UIData.State.None;
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
    private Room room = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.history.allAddCallBack(this);
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
            if (data is History)
            {
                History history = data as History;
                // Parent
                {
                    DataUtils.addParentCallBack(history, this, ref this.server);
                    DataUtils.addParentCallBack(history, this, ref this.room);
                }
                // Child
                {

                }
                dirty = true;
                needReset = true;
                return;
            }
            // Parent
            {
                if (data is Server)
                {
                    dirty = true;
                    return;
                }
                if (data is Room)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            if (data is HumanConnection)
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
                uiData.history.allRemoveCallBack(this);
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
            if (data is History)
            {
                History history = data as History;
                // Parent
                {
                    DataUtils.removeParentCallBack(history, this, ref this.server);
                    DataUtils.removeParentCallBack(history, this, ref this.room);
                }
                // Child
                {
                    history.humanConnections.allRemoveCallBack(this);
                }
                return;
            }
            // Parent
            {
                if (data is Server)
                {
                    return;
                }
                if (data is Room)
                {
                    return;
                }
            }
            // Child
            if (data is HumanConnection)
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
                case UIData.Property.history:
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
            if (wrapProperty.p is History)
            {
                switch ((History.Property)wrapProperty.n)
                {
                    case History.Property.isActive:
                        break;
                    case History.Property.changes:
                        break;
                    case History.Property.position:
                        break;
                    case History.Property.changeCount:
                        break;
                    case History.Property.humanConnections:
                        {
                            dirty = true;
                            needReset = true;
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
                if (wrapProperty.p is Server)
                {
                    Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                    return;
                }
                if (wrapProperty.p is Room)
                {
                    switch ((Room.Property)wrapProperty.n)
                    {
                        case Room.Property.roomInform:
                            break;
                        case Room.Property.changeRights:
                            break;
                        case Room.Property.name:
                            break;
                        case Room.Property.password:
                            break;
                        case Room.Property.users:
                            break;
                        case Room.Property.state:
                            break;
                        case Room.Property.requestNewContestManager:
                            break;
                        case Room.Property.contestManagers:
                            break;
                        case Room.Property.timeCreated:
                            break;
                        case Room.Property.chatRoom:
                            break;
                        case Room.Property.allowHint:
                            break;
                        case Room.Property.allowLoadHistory:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // Child
            if (wrapProperty.p is HumanConnection)
            {
                switch ((HumanConnection.Property)wrapProperty.n)
                {
                    case HumanConnection.Property.playerId:
                        {
                            dirty = true;
                            needReset = true;
                        }
                        break;
                    case HumanConnection.Property.connection:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
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
            UIUtils.SetButtonOnClick(btnLoad, onClickBtnLoad);
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
                    case KeyCode.L:
                        {
                            if (btnLoad != null && btnLoad.gameObject.activeInHierarchy && btnLoad.interactable)
                            {
                                this.onClickBtnLoad();
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
    public void onClickBtnLoad()
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
                    Debug.LogError("You are requesting: " + this);
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