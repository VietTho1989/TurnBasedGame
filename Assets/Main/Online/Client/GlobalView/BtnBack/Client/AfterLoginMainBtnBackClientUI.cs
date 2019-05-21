using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AfterLoginMainBtnBackClientUI : UIBehavior<AfterLoginMainBtnBackClientUI.UIData>
{

    #region UIData

    public class UIData : AfterLoginMainBtnBackUI.UIData.Sub
    {

        public VP<ReferenceData<Server>> server;

        public VP<bool> needConfirm;

        public VP<ConfirmBackClientUI.UIData> confirmUI;

        #region State

        public enum State
        {
            None,
            LogOut,
            Wait
        }

        public VP<State> state;

        #endregion

        #region Constructor

        public enum Property
        {
            server,
            needConfirm,
            confirmUI,
            state
        }

        public UIData() : base()
        {
            this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
            this.needConfirm = new VP<bool>(this, (byte)Property.needConfirm, true);
            this.confirmUI = new VP<ConfirmBackClientUI.UIData>(this, (byte)Property.confirmUI, null);
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public override Server.Type getType()
        {
            return Server.Type.Client;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // confirmUI
                if (!isProcess)
                {
                    ConfirmBackClientUI.UIData confirmUI = this.confirmUI.v;
                    if (confirmUI != null)
                    {
                        isProcess = confirmUI.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("confirmUI null: " + this);
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        AfterLoginMainBtnBackClientUI backClientUI = this.findCallBack<AfterLoginMainBtnBackClientUI>();
                        if (backClientUI != null)
                        {
                            backClientUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("backClientUI null: " + this);
                        }
                        isProcess = true;
                    }
                }
            }
            return isProcess;
        }

        public void reset()
        {

        }

        public void back()
        {
            if (this.state.v == State.None)
            {
                this.state.v = State.LogOut;
            }
            else
            {
                Debug.LogError("state error: " + this.state.v + "; " + this);
            }
        }

    }

    #endregion

    public override int getStartAllocate()
    {
        return 1;
    }

    #region txt

    private static readonly TxtLanguage txtLogOut = new TxtLanguage("Logout");
    private static readonly TxtLanguage txtLoggingOut = new TxtLanguage("Logging out");

    static AfterLoginMainBtnBackClientUI()
    {
        txtLogOut.add(Language.Type.vi, "Đăng xuất");
        txtLoggingOut.add(Language.Type.vi, "Đang đăng xuất");
    }

    #endregion

    #region Refresh

    public Button btnLogOut;
    public Text tvState;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // btnBack
                {
                    if (btnLogOut != null)
                    {
                        switch (this.data.state.v)
                        {
                            case UIData.State.None:
                                btnLogOut.interactable = true;
                                break;
                            case UIData.State.LogOut:
                            case UIData.State.Wait:
                                btnLogOut.interactable = false;
                                break;
                            default:
                                Debug.LogError("unknown type: " + this.data.state.v);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("btnBack null: " + this);
                    }
                }
                if (tvState != null)
                {
                    switch (this.data.state.v)
                    {
                        case UIData.State.None:
                            tvState.text = txtLogOut.get();
                            break;
                        case UIData.State.LogOut:
                        case UIData.State.Wait:
                            tvState.text = txtLoggingOut.get();
                            break;
                        default:
                            Debug.LogError("unknown type: " + this.data.state.v);
                            break;
                    }
                }
                else
                {
                    Debug.LogError("tvState null: " + this);
                }
                // ConfirmUI
                {
                    if (!this.data.needConfirm.v || this.data.state.v != UIData.State.None)
                    {
                        this.data.confirmUI.v = null;
                    }
                }
                // Server
                {
                    Server server = this.data.server.v.data;
                    if (server != null)
                    {
                        switch (this.data.state.v)
                        {
                            case UIData.State.None:
                                break;
                            case UIData.State.LogOut:
                                {
                                    Server.State.Connect connect = server.state.v as Server.State.Connect;
                                    if (connect != null)
                                    {
                                        if (connect.state.v == Server.State.Connect.State.Normal)
                                        {
                                            connect.state.v = Server.State.Connect.State.Logout;
                                            this.data.state.v = UIData.State.Wait;
                                        }
                                        else
                                        {
                                            Debug.LogError("other connect state: " + connect.state.v + "; " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("connect null: " + this);
                                        // Chuyen sang offline
                                        Server.State.Offline offline = new Server.State.Offline();
                                        {
                                            offline.uid = server.state.makeId();
                                        }
                                        server.state.v = offline;
                                    }
                                }
                                break;
                            case UIData.State.Wait:
                                {
                                    if (server.state.v != null && server.state.v.getType() == Server.State.Type.Disconnect)
                                    {
                                        Debug.LogError("server disconnect, offline immediately: " + this);
                                        Server.State.Offline offline = new Server.State.Offline();
                                        {
                                            offline.uid = server.state.makeId();
                                        }
                                        server.state.v = offline;
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("Unknown state: " + this.data.state.v + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("server null: " + this);
                        this.data.state.v = UIData.State.None;
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
        return true;
    }

    #endregion

    #region implement callBacks

    public ConfirmBackClientUI confirmBackPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.server.allAddCallBack(this);
                uiData.confirmUI.allAddCallBack(this);
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
            if (data is Server)
            {
                // reset
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
                dirty = true;
                return;
            }
            if (data is ConfirmBackClientUI.UIData)
            {
                ConfirmBackClientUI.UIData confirmBackUIData = data as ConfirmBackClientUI.UIData;
                // UI
                {
                    Transform confirmBackContainer = null;
                    {
                        AfterLoginUI.UIData afterLoginUIData = confirmBackUIData.findDataInParent<AfterLoginUI.UIData>();
                        if (afterLoginUIData != null)
                        {
                            AfterLoginUI afterLoginUI = afterLoginUIData.findCallBack<AfterLoginUI>();
                            if (afterLoginUI != null)
                            {
                                confirmBackContainer = afterLoginUI.confirmBackContainer;
                            }
                            else
                            {
                                Debug.LogError("afterLoginUI null");
                            }
                        }
                        else
                        {
                            Debug.LogError("afterLoginUIData null");
                        }
                    }
                    UIUtils.Instantiate(confirmBackUIData, confirmBackPrefab, confirmBackContainer);
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
                uiData.server.allRemoveCallBack(this);
                uiData.confirmUI.allRemoveCallBack(this);
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
            if (data is Server)
            {
                return;
            }
            if (data is ConfirmBackClientUI.UIData)
            {
                ConfirmBackClientUI.UIData confirmBackUIData = data as ConfirmBackClientUI.UIData;
                // UI
                {
                    confirmBackUIData.removeCallBackAndDestroy(typeof(ConfirmBackClientUI));
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
                case UIData.Property.server:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.needConfirm:
                    dirty = true;
                    break;
                case UIData.Property.confirmUI:
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
            if (wrapProperty.p is Server)
            {
                switch ((Server.Property)wrapProperty.n)
                {
                    case Server.Property.serverConfig:
                        break;
                    case Server.Property.startState:
                        break;
                    case Server.Property.type:
                        break;
                    case Server.Property.profile:
                        break;
                    case Server.Property.state:
                        dirty = true;
                        break;
                    case Server.Property.users:
                        dirty = true;
                        break;
                    case Server.Property.globalChat:
                        break;
                    case Server.Property.friendWorld:
                        break;
                    case Server.Property.guilds:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is ConfirmBackClientUI.UIData)
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
            if (this.data.state.v == UIData.State.None)
            {
                if (!this.data.needConfirm.v)
                {
                    this.data.back();
                }
                else
                {
                    ConfirmBackClientUI.UIData confirmBackClientUIData = this.data.confirmUI.newOrOld<ConfirmBackClientUI.UIData>();
                    {

                    }
                    this.data.confirmUI.v = confirmBackClientUIData;
                }
            }
            else
            {
                Debug.LogError("wrong state: " + this.data.state.v + "; " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}