using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class BanNormalUI : UIBehavior<BanNormalUI.UIData>
{

    #region UIData

    public class UIData : BanUI.UIData.Sub
    {

        public VP<ReferenceData<BanNormal>> banNormal;

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
            banNormal,
            state
        }

        public UIData() : base()
        {
            this.banNormal = new VP<ReferenceData<BanNormal>>(this, (byte)Property.banNormal, new ReferenceData<BanNormal>(null));
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public override Ban.Type getType()
        {
            return Ban.Type.Normal;
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
                        BanNormalUI banNormalUI = this.findCallBack<BanNormalUI>();
                        if (banNormalUI != null)
                        {
                            isProcess = banNormalUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("banNormalUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text tvBan;
    private static readonly TxtLanguage txtBan = new TxtLanguage("Ban");
    private static readonly TxtLanguage txtCannotBan = new TxtLanguage("Cannot Ban");
    private static readonly TxtLanguage txtCancelBan = new TxtLanguage("Cancel");
    private static readonly TxtLanguage txtBanning = new TxtLanguage("Banning");

    private static readonly TxtLanguage txtRequestError = new TxtLanguage("Send request ban error");

    static BanNormalUI()
    {
        txtBan.add(Language.Type.vi, "Cấm");
        txtCannotBan.add(Language.Type.vi, "Không thể cấm");
        txtCancelBan.add(Language.Type.vi, "Huỷ");
        txtBanning.add(Language.Type.vi, "Đang cấm");
        txtRequestError.add(Language.Type.vi, "Gửi yêu cầu cấm lỗi");
    }

    #endregion

    #region Refresh

    private User profileUser = null;
    private User toBanUser = null;

    public Button btnBan;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                BanNormal banNormal = this.data.banNormal.v.data;
                if (banNormal != null)
                {
                    // Check to add callBack
                    {
                        // profileUser
                        {
                            User profileUser = Server.GetProfileUser(banNormal);
                            if (this.profileUser != profileUser)
                            {
                                // remove old
                                if (this.profileUser != null)
                                {
                                    this.profileUser.removeCallBack(this);
                                }
                                // set new
                                this.profileUser = profileUser;
                                if (this.profileUser != null)
                                {
                                    this.profileUser.addCallBack(this);
                                }
                            }
                            else
                            {
                                // Debug.LogError("the same: " + this);
                            }
                        }
                        // toBanUser
                        {
                            User toBanUser = banNormal.findDataInParent<User>();
                            if (this.toBanUser != toBanUser)
                            {
                                // remove old
                                if (this.toBanUser != null)
                                {
                                    this.toBanUser.removeCallBack(this);
                                }
                                // set new
                                this.toBanUser = toBanUser;
                                if (this.toBanUser != null)
                                {
                                    this.toBanUser.addCallBack(this);
                                }
                            }
                            else
                            {
                                // Debug.LogError("the same: " + this);
                            }
                        }
                    }
                    // Check can ban
                    bool canBan = banNormal.isCanBanOrUnBan(Server.getProfileUserId(banNormal));
                    // Task
                    {
                        if (canBan)
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
                                            if (Server.IsServerOnline(banNormal))
                                            {
                                                banNormal.requestBan(Server.getProfileUserId(banNormal));
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
                                            if (Server.IsServerOnline(banNormal))
                                            {
                                                if (Routine.IsNull(wait))
                                                {
                                                    wait = CoroutineManager.StartCoroutine(TaskWait(), this.gameObject);
                                                }
                                                else
                                                {
                                                    Debug.LogError("Why routine != null: " + this);
                                                }
                                            }
                                            else
                                            {
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
                                if (btnBan != null && tvBan != null)
                                {
                                    switch (this.data.state.v)
                                    {
                                        case UIData.State.None:
                                            {
                                                btnBan.interactable = true;
                                                tvBan.text = txtBan.get();
                                            }
                                            break;
                                        case UIData.State.Request:
                                            {
                                                btnBan.interactable = true;
                                                tvBan.text = txtCancelBan.get();
                                            }
                                            break;
                                        case UIData.State.Wait:
                                            {
                                                btnBan.interactable = false;
                                                tvBan.text = txtBanning.get();
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown state: " + this.data.state.v);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("btnBan, tvBan null");
                                }
                            }
                        }
                        else
                        {
                            // Task
                            {
                                destroyRoutine(wait);
                                this.data.state.v = UIData.State.None;
                            }
                            // UI
                            {
                                if (btnBan != null && tvBan != null)
                                {
                                    btnBan.interactable = false;
                                    tvBan.text = txtCannotBan.get();
                                }
                                else
                                {
                                    Debug.LogError("btnBan, tvBan null");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("banNormal null: " + this);
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

    public override void OnDestroy()
    {
        base.OnDestroy();
        if (this.profileUser != null)
        {
            this.profileUser.removeCallBack(this);
            this.profileUser = null;
        }
        else
        {
            Debug.LogError("profileUser null: " + this);
        }
        if (this.toBanUser != null)
        {
            this.toBanUser.removeCallBack(this);
            this.toBanUser = null;
        }
        else
        {
            Debug.LogError("toBanUser null: " + this);
        }
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

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.banNormal.allAddCallBack(this);
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
            // BanNormal
            {
                if (data is BanNormal)
                {
                    BanNormal banNormal = data as BanNormal;
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
                        DataUtils.addParentCallBack(banNormal, this, ref this.server);
                    }
                    dirty = true;
                    return;
                }
                // Parent
                {
                    if (data is Server)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is User)
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
            // Child
            {
                uiData.banNormal.allRemoveCallBack(this);
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
            // BanNormal
            {
                if (data is BanNormal)
                {
                    BanNormal banNormal = data as BanNormal;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(banNormal, this, ref this.server);
                    }
                    return;
                }
                // Parent
                {
                    if (data is Server)
                    {
                        return;
                    }
                }
                if (data is User)
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
                case UIData.Property.banNormal:
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
            // BanNormal
            {
                if (wrapProperty.p is BanNormal)
                {
                    switch ((BanNormal.Property)wrapProperty.n)
                    {
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
                }
                if (wrapProperty.p is User)
                {
                    switch ((User.Property)wrapProperty.n)
                    {
                        case User.Property.human:
                            dirty = true;
                            break;
                        case User.Property.role:
                            dirty = true;
                            break;
                        case User.Property.ipAddress:
                            break;
                        case User.Property.registerTime:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBan()
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