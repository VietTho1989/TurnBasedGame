using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class RoomUserBtnKickUI : UIBehavior<RoomUserBtnKickUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<RoomUser>> roomUser;

        #region State

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
            roomUser,
            state
        }

        public UIData() : base()
        {
            this.roomUser = new VP<ReferenceData<RoomUser>>(this, (byte)Property.roomUser, new ReferenceData<RoomUser>(null));
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
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        RoomUserBtnKickUI roomUserBtnKickUI = this.findCallBack<RoomUserBtnKickUI>();
                        if (roomUserBtnKickUI != null)
                        {
                            isProcess = roomUserBtnKickUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("roomUserBtnKickUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtKick = new TxtLanguage("Kick");
    private static readonly TxtLanguage txtCancelKick = new TxtLanguage("Cancel Kick?");
    private static readonly TxtLanguage txtKicking = new TxtLanguage("Kicking");
    private static readonly TxtLanguage txtCannotKick = new TxtLanguage("You cannot kick");

    static RoomUserBtnKickUI()
    {
        txtKick.add(Language.Type.vi, "Kick");
        txtCancelKick.add(Language.Type.vi, "Huỷ kick?");
        txtKicking.add(Language.Type.vi, "Đang kick");
        txtCannotKick.add(Language.Type.vi, "Không thể bị kick");
    }

    #endregion

    #region Refresh

    public Button btnKick;
    public Text tvKick;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                RoomUser roomUser = this.data.roomUser.v.data;
                if (roomUser != null)
                {
                    uint profileId = Server.getProfileUserId(roomUser);
                    if (roomUser.isCanKick(profileId))
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
                                        if (Server.IsServerOnline(roomUser))
                                        {
                                            roomUser.requestKick(profileId);
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
                                        if (Server.IsServerOnline(roomUser))
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
                        // UI
                        {
                            if (btnKick != null && tvKick != null)
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            btnKick.interactable = true;
                                            tvKick.text = txtKick.get();
                                        }
                                        break;
                                    case UIData.State.Request:
                                        {
                                            btnKick.interactable = true;
                                            tvKick.text = txtCancelKick.get();
                                        }
                                        break;
                                    case UIData.State.Wait:
                                        {
                                            btnKick.interactable = false;
                                            tvKick.text = txtKicking.get();
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("btnKick, tvKick null: " + this);
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
                            if (btnKick != null && tvKick != null)
                            {
                                btnKick.interactable = false;
                                tvKick.text = txtCannotKick.get();
                            }
                            else
                            {
                                Debug.LogError("btnKick, tvKick null: " + this);
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("roomUser null: " + this);
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
            // Chuyen sang state none
            {
                if (this.data != null)
                {
                    this.data.state.v = UIData.State.None;
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
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

    private RoomCheckChangeAdminChange<RoomUser> roomCheckAdminChange = new RoomCheckChangeAdminChange<RoomUser>();
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
                uiData.roomUser.allAddCallBack(this);
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
            if (data is RoomUser)
            {
                RoomUser roomUser = data as RoomUser;
                // CheckChange
                {
                    roomCheckAdminChange.addCallBack(this);
                    roomCheckAdminChange.setData(roomUser);
                }
                // Parent
                {
                    DataUtils.addParentCallBack(roomUser, this, ref this.server);
                }
                // Child
                {
                    roomUser.inform.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // CheckChange
            if (data is RoomCheckChangeAdminChange<RoomUser>)
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
            // Setting
            Setting.get().removeCallBack(this);
            // Child
            {
                uiData.roomUser.allRemoveCallBack(this);
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
            if (data is RoomUser)
            {
                RoomUser roomUser = data as RoomUser;
                // CheckChange
                {
                    roomCheckAdminChange.removeCallBack(this);
                    roomCheckAdminChange.setData(null);
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(roomUser, this, ref this.server);
                }
                // Child
                {
                    roomUser.inform.allRemoveCallBack(this);
                }
                return;
            }
            // CheckChange
            if (data is RoomCheckChangeAdminChange<RoomUser>)
            {
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
                case UIData.Property.roomUser:
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
            if (wrapProperty.p is RoomUser)
            {
                switch ((RoomUser.Property)wrapProperty.n)
                {
                    case RoomUser.Property.role:
                        dirty = true;
                        break;
                    case RoomUser.Property.inform:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case RoomUser.Property.state:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            if (wrapProperty.p is RoomCheckChangeAdminChange<RoomUser>)
            {
                dirty = true;
                return;
            }
            // Parent
            if (wrapProperty.p is Server)
            {
                dirty = true;
                return;
            }
            // Child
            if (wrapProperty.p is Human)
            {
                switch ((Human.Property)wrapProperty.n)
                {
                    case Human.Property.playerId:
                        dirty = true;
                        break;
                    case Human.Property.account:
                        break;
                    case Human.Property.state:
                        break;
                    case Human.Property.email:
                        break;
                    case Human.Property.phoneNumber:
                        break;
                    case Human.Property.status:
                        break;
                    case Human.Property.birthday:
                        break;
                    case Human.Property.sex:
                        break;
                    case Human.Property.connection:
                        break;
                    case Human.Property.ban:
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

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnKick()
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