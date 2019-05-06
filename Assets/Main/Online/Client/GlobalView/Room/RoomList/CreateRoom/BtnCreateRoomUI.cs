using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class BtnCreateRoomUI : UIBehavior<BtnCreateRoomUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

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
            state
        }

        public UIData() : base()
        {
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
                        BtnCreateRoomUI btnCreateRoomUI = this.findCallBack<BtnCreateRoomUI>();
                        if (btnCreateRoomUI != null)
                        {
                            isProcess = btnCreateRoomUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("btnCreateRoomUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtCreate = new TxtLanguage("Create");
    private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel Create");
    private static readonly TxtLanguage txtCreating = new TxtLanguage("Creating...");

    private static readonly TxtLanguage txtRequestError = new TxtLanguage("Send request to create room error");

    static BtnCreateRoomUI()
    {
        txtCreate.add(Language.Type.vi, "Tạo Phòng");
        txtCancel.add(Language.Type.vi, "Huỷ tạo phòng");
        txtCreating.add(Language.Type.vi, "Đang tạo phòng");

        txtRequestError.add(Language.Type.vi, "Gửi yêu cầu tạo phòng lỗi");
    }

    #endregion

    #region Refresh

    public Button btnCreate;
    public Text tvCreate;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // Task
                {
                    bool isOnline = true;
                    {
                        ManagerUI.UIData managerUIData = this.data.findDataInParent<ManagerUI.UIData>();
                        if (managerUIData != null)
                        {
                            Server server = managerUIData.server.v.data;
                            if (server != null)
                            {
                                isOnline = Server.IsServerOnline(server);
                            }
                            else
                            {
                                Debug.LogError("server null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("managerUIData null: " + this);
                        }
                    }
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
                                if (isOnline)
                                {
                                    CreateRoomUI.UIData createRoomUIData = this.data.findDataInParent<CreateRoomUI.UIData>();
                                    if (createRoomUIData != null)
                                    {
                                        CreateRoomUI createRoomUI = createRoomUIData.findCallBack<CreateRoomUI>();
                                        if (createRoomUI != null)
                                        {
                                            createRoomUI.onClickBtnCreate();
                                        }
                                        else
                                        {
                                            Debug.LogError("createRoomUI null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("createRoomUI null: " + this);
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
                                if (isOnline)
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
                            Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                            break;
                    }
                }
                // UI
                {
                    if (btnCreate != null && tvCreate != null)
                    {
                        switch (this.data.state.v)
                        {
                            case UIData.State.None:
                                {
                                    btnCreate.interactable = true;
                                    tvCreate.text = txtCreate.get();
                                }
                                break;
                            case UIData.State.Request:
                                {
                                    btnCreate.interactable = true;
                                    tvCreate.text = txtCancel.get();
                                }
                                break;
                            case UIData.State.Wait:
                                {
                                    btnCreate.interactable = false;
                                    tvCreate.text = txtCreating.get();
                                }
                                break;
                            default:
                                Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("btnCreate, tvCreate null: " + this);
                    }
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

    private ManagerUI.UIData managerUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Parent
            {
                DataUtils.addParentCallBack(uiData, this, ref this.managerUIData);
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
        // Parent
        {
            if (data is ManagerUI.UIData)
            {
                ManagerUI.UIData managerUIData = data as ManagerUI.UIData;
                // Child
                {
                    managerUIData.server.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is Server)
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
            // Parent
            {
                DataUtils.removeParentCallBack(uiData, this, ref this.managerUIData);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Parent
        {
            if (data is ManagerUI.UIData)
            {
                ManagerUI.UIData managerUIData = data as ManagerUI.UIData;
                // Child
                {
                    managerUIData.server.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            if (data is Server)
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
        // Parent
        {
            if (wrapProperty.p is ManagerUI.UIData)
            {
                switch ((ManagerUI.UIData.Property)wrapProperty.n)
                {
                    case ManagerUI.UIData.Property.server:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case ManagerUI.UIData.Property.sub:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            if (wrapProperty.p is Server)
            {
                Server.State.OnUpdateSyncStateChange(wrapProperty, this);
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
                    case KeyCode.C:
                        {
                            if (btnCreate != null && btnCreate.gameObject.activeInHierarchy && btnCreate.interactable)
                            {
                                this.onClickBtnCreateRoom();
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
    public void onClickBtnCreateRoom()
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
                    Debug.LogError("You are creating room...");
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