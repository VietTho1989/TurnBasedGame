using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class RoomBtnBackUI : UIBehavior<RoomBtnBackUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Room>> room;

        #region state

        public enum State
        {
            None,
            Request,
            Wait
        }

        public VP<State> state;

        #endregion

        public VP<bool> needConfirm;

        public VP<RoomBtnBackConfirmUI.UIData> confirm;

        #region Constructor

        public enum Property
        {
            room,
            state,
            needConfirm,
            confirm
        }

        public UIData() : base()
        {
            this.room = new VP<ReferenceData<Room>>(this, (byte)Property.room, new ReferenceData<Room>(null));
            this.state = new VP<State>(this, (byte)Property.state, State.None);
            // confirm
            {
                this.needConfirm = new VP<bool>(this, (byte)Property.needConfirm, true);
                this.confirm = new VP<RoomBtnBackConfirmUI.UIData>(this, (byte)Property.confirm, null);
            }
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
                // confirm
                if (!isProcess)
                {
                    RoomBtnBackConfirmUI.UIData confirm = this.confirm.v;
                    if (confirm != null)
                    {
                        isProcess = confirm.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("confirm null: " + this);
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        RoomBtnBackUI roomBtnBackUI = this.findCallBack<RoomBtnBackUI>();
                        if (roomBtnBackUI != null)
                        {
                            roomBtnBackUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("roomBtnBackUI null: " + this);
                        }
                        isProcess = true;
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    /*private static readonly TxtLanguage txtLeave = new TxtLanguage("Leave");
    private static readonly TxtLanguage txtCancelLeave = new TxtLanguage("Cancel Leave?");
    private static readonly TxtLanguage txtLeaving = new TxtLanguage("Leaving...");

    static RoomBtnBackUI()
    {
        txtLeave.add(Language.Type.vi, "Rời");
        txtCancelLeave.add(Language.Type.vi, "Huỷ rời");
        txtLeaving.add(Language.Type.vi, "Đang rời");
    }*/

    #endregion

    #region Refresh

    public Button btnBack;
    // public Text tvBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Room room = this.data.room.v.data;
                if (room != null)
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
                                        // Find roomUser
                                        RoomUser roomUser = room.users.getInList(Server.getProfileUserId(room));
                                        if (roomUser != null)
                                        {
                                            if (Server.IsServerOnline(room))
                                            {
                                                roomUser.requestLeaveRoom();
                                                this.data.state.v = UIData.State.Wait;
                                            }
                                            else
                                            {
                                                Debug.LogError("server not online: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("roomUser null: " + this);
                                        }
                                    }
                                }
                                break;
                            case UIData.State.Wait:
                                {
                                    if (Server.IsServerOnline(room))
                                    {
                                        startRoutine(ref this.wait, TaskWait());
                                    }
                                    else
                                    {
                                        Debug.LogError("server not online: " + this);
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
                        if (btnBack != null)
                        {
                            switch (this.data.state.v)
                            {
                                case UIData.State.None:
                                    {
                                        btnBack.interactable = true;
                                        //if (tvBack != null)
                                          //  tvBack.text = txtLeave.get();
                                    }
                                    break;
                                case UIData.State.Request:
                                    {
                                        btnBack.interactable = true;
                                        //if (tvBack != null)
                                          //  tvBack.text = txtCancelLeave.get();
                                    }
                                    break;
                                case UIData.State.Wait:
                                    {
                                        btnBack.interactable = false;
                                        //if (tvBack != null)
                                          //  tvBack.text = txtLeaving.get();
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("btnBack, tvBack null: " + this);
                        }
                    }
                    // confirm
                    {
                        if (this.data.state.v != UIData.State.None || !this.data.needConfirm.v)
                        {
                            this.data.confirm.v = null;
                        }
                    }
                }
                else
                {
                    Debug.LogError("room null: " + this);
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

    public RoomBtnBackConfirmUI confirmPrefab;

    private RoomCheckChangeAdminChange<Room> roomCheckAdminChange = new RoomCheckChangeAdminChange<Room>();
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
                uiData.room.allAddCallBack(this);
                uiData.confirm.allAddCallBack(this);
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
            // Room
            {
                if (data is Room)
                {
                    Room room = data as Room;
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
                    // CheckChange
                    {
                        roomCheckAdminChange.addCallBack(this);
                        roomCheckAdminChange.setData(room);
                    }
                    // Parent
                    {
                        DataUtils.addParentCallBack(room, this, ref this.server);
                    }
                    dirty = true;
                    return;
                }
                // CheckChange
                if (data is RoomCheckChangeAdminChange<Room>)
                {
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
            if (data is RoomBtnBackConfirmUI.UIData)
            {
                RoomBtnBackConfirmUI.UIData confirmUIData = data as RoomBtnBackConfirmUI.UIData;
                // UI
                {
                    // find
                    Transform container = this.transform;
                    {
                        if (this.data != null)
                        {
                            RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData>();
                            if (roomUIData != null)
                            {
                                RoomUI roomUI = roomUIData.findCallBack<RoomUI>();
                                if (roomUI != null)
                                {
                                    container = roomUI.confirmBtnBackContainer;
                                }
                                else
                                {
                                    Debug.LogError("roomUI null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("roomUIData null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("data null: " + this);
                        }
                    }
                    // Process
                    UIUtils.Instantiate(confirmUIData, confirmPrefab, container);
                }
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
                uiData.room.allAddCallBack(this);
                uiData.confirm.allRemoveCallBack(this);
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
            // Room
            {
                if (data is Room)
                {
                    Room room = data as Room;
                    // CheckChange
                    {
                        roomCheckAdminChange.removeCallBack(this);
                        roomCheckAdminChange.setData(null);
                    }
                    // Parent
                    {
                        DataUtils.removeParentCallBack(room, this, ref this.server);
                    }
                    return;
                }
                // CheckChange
                if (data is RoomCheckChangeAdminChange<Room>)
                {
                    return;
                }
                // Parent
                if (data is Server)
                {
                    return;
                }
            }
            if (data is RoomBtnBackConfirmUI.UIData)
            {
                RoomBtnBackConfirmUI.UIData confirmUIData = data as RoomBtnBackConfirmUI.UIData;
                // UI
                {
                    confirmUIData.removeCallBackAndDestroy(typeof(RoomBtnBackConfirmUI));
                }
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
                case UIData.Property.room:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.state:
                    dirty = true;
                    break;
                case UIData.Property.needConfirm:
                    dirty = true;
                    break;
                case UIData.Property.confirm:
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
            // Room
            {
                if (wrapProperty.p is Room)
                {
                    return;
                }
                // CheckChange
                if (wrapProperty.p is RoomCheckChangeAdminChange<Room>)
                {
                    dirty = true;
                    return;
                }
                // Parent
                if (wrapProperty.p is Server)
                {
                    Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                    return;
                }
            }
            if (wrapProperty.p is RoomBtnBackConfirmUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            switch (this.data.state.v)
            {
                case UIData.State.None:
                    {
                        if (this.data.needConfirm.v)
                        {
                            RoomBtnBackConfirmUI.UIData confirmUIData = this.data.confirm.newOrOld<RoomBtnBackConfirmUI.UIData>();
                            {

                            }
                            this.data.confirm.v = confirmUIData;
                        }
                        else
                        {
                            this.data.state.v = UIData.State.Request;
                        }
                    }
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