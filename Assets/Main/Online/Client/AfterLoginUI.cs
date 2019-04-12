using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class AfterLoginUI : UIBehavior<AfterLoginUI.UIData>
{

    #region UIData

    public class UIData : NormalUI.UIData.Sub
    {

        public VP<ReferenceData<Server>> server;

        #region Sub

        public abstract class Sub : Data
        {

            public enum Type
            {
                View,
                Ban
            }

            public abstract Type getType();

            public abstract bool processEvent(Event e);

            public abstract MainUI.UIData.AllowShowBanner getAllowShowBanner();

        }

        public VP<Sub> sub;

        #endregion

        public VP<AfterLoginMainBtnBackUI.UIData> btnBack;

        public VP<GlobalStateUI.UIData> state;

        #region Constructor

        public enum Property
        {
            server,
            sub,
            btnBack,
            state,
        }

        public UIData() : base()
        {
            this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            this.btnBack = new VP<AfterLoginMainBtnBackUI.UIData>(this, (byte)Property.btnBack, new AfterLoginMainBtnBackUI.UIData());
            this.state = new VP<GlobalStateUI.UIData>(this, (byte)Property.state, new GlobalStateUI.UIData());
        }

        #endregion

        public override Type getType()
        {
            return Type.AfterLogin;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // global state
                if (!isProcess)
                {
                    GlobalStateUI.UIData state = this.state.v;
                    if (state != null)
                    {
                        isProcess = state.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("state null");
                    }
                }
                // sub
                if (!isProcess)
                {
                    Sub sub = this.sub.v;
                    if (sub != null)
                    {
                        isProcess = sub.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("sub null: " + this);
                    }
                }
                // btnBack
                if (!isProcess)
                {
                    AfterLoginMainBtnBackUI.UIData btnBack = this.btnBack.v;
                    if (btnBack != null)
                    {
                        isProcess = btnBack.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("btnBack null: " + this);
                    }
                }
            }
            return isProcess;
        }

        public override MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            MainUI.UIData.AllowShowBanner ret = MainUI.UIData.AllowShowBanner.ForceShow;
            {
                Sub sub = this.sub.v;
                if (sub != null)
                {
                    ret = sub.getAllowShowBanner();
                }
                else
                {
                    Debug.LogError("sub null");
                }
            }
            return ret;
        }

    }

    #endregion

    #region txt,rect

    static AfterLoginUI()
    {

    }

    #endregion

    #region Refresh

    private User profileUser = null;

    public Transform confirmBackContainer;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Server server = this.data.server.v.data;
                if (server != null)
                {
                    // sub
                    {
                        // Check you are banned or not
                        bool isBan = false;
                        {
                            if (server.type.v == Server.Type.Client)
                            {
                                User profileUser = server.getProfileUser();
                                // set callBacks
                                {
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
                                }
                                // Check
                                if (profileUser != null)
                                {
                                    Human human = profileUser.human.v;
                                    if (human != null)
                                    {
                                        if (human.ban.v != null && human.ban.v.getType() == Ban.Type.Ban)
                                        {
                                            isBan = true;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("human null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("profileUser null: " + this);
                                }
                            }
                        }
                        // Process
                        if (!isBan)
                        {
                            GlobalViewUI.UIData globalViewUIData = this.data.sub.newOrOld<GlobalViewUI.UIData>();
                            {
                                globalViewUIData.server.v = new ReferenceData<Server>(server);
                            }
                            this.data.sub.v = globalViewUIData;
                        }
                        else
                        {
                            GlobalBanUI.UIData globalBanUIData = this.data.sub.newOrOld<GlobalBanUI.UIData>();
                            {
                                globalBanUIData.server.v = new ReferenceData<Server>(server);
                            }
                            this.data.sub.v = globalBanUIData;
                        }
                    }
                    // btnBack
                    {
                        AfterLoginMainBtnBackUI.UIData btnBack = this.data.btnBack.v;
                        if (btnBack != null)
                        {
                            btnBack.server.v = new ReferenceData<Server>(server);
                        }
                        else
                        {
                            Debug.LogError("btnBack null: " + this);
                        }
                    }
                    // state
                    {
                        GlobalStateUI.UIData state = this.data.state.v;
                        if (state != null)
                        {
                            state.server.v = new ReferenceData<Server>(server);
                        }
                        else
                        {
                            Debug.LogError("state null: " + this);
                        }
                    }
                    // siblingIndex
                    {
                        // btnBack
                        UIRectTransform.SetSiblingIndex(this.data.btnBack.v, 0);
                        // state
                        UIRectTransform.SetSiblingIndex(this.data.state.v, 1);
                        // sub
                        UIRectTransform.SetSiblingIndex(this.data.sub.v, 2);
                        // confirmBack
                        if (confirmBackContainer != null)
                        {
                            confirmBackContainer.SetSiblingIndex(3);
                        }
                        else
                        {
                            Debug.LogError("confirmBackContainer null");
                        }
                    }
                    // UI
                    {
                        float buttonSize = Setting.get().getButtonSize();
                        UIRectTransform.SetButtonTopLeftTransform(this.data.btnBack.v);
                        UIRectTransform.SetButtonTopLeftTransform(this.data.state.v, buttonSize);
                    }
                }
                else
                {
                    Debug.LogError("server null: " + this);
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

    public override void OnDestroy()
    {
        base.OnDestroy();
        if (this.profileUser != null)
        {
            this.profileUser.removeCallBack(this);
            this.profileUser = null;
        }
    }

    #endregion

    #region implement callBacks

    public GlobalViewUI globalViewPrefab;
    public GlobalBanUI globalBanPrefab;

    public AfterLoginMainBtnBackUI btnBackPrefab;

    public GlobalStateUI statePrefab;

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
                uiData.sub.allAddCallBack(this);
                uiData.btnBack.allAddCallBack(this);
                uiData.state.allAddCallBack(this);
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
            // Server
            {
                if (data is Server)
                {
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is User)
                    {
                        User user = data as User;
                        // Child
                        {
                            user.human.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is Human)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // Sub
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.View:
                            {
                                GlobalViewUI.UIData globalViewUIData = sub as GlobalViewUI.UIData;
                                UIUtils.Instantiate(globalViewUIData, globalViewPrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.Ban:
                            {
                                GlobalBanUI.UIData globalBanUIData = sub as GlobalBanUI.UIData;
                                UIUtils.Instantiate(globalBanUIData, globalBanPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("Unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
                }
                dirty = true;
                return;
            }
            if (data is AfterLoginMainBtnBackUI.UIData)
            {
                AfterLoginMainBtnBackUI.UIData btnBack = data as AfterLoginMainBtnBackUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnBack, btnBackPrefab, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is GlobalStateUI.UIData)
            {
                GlobalStateUI.UIData state = data as GlobalStateUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(state, statePrefab, this.transform);
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
                uiData.sub.allRemoveCallBack(this);
                uiData.btnBack.allRemoveCallBack(this);
                uiData.state.allRemoveCallBack(this);
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
            // Server
            {
                if (data is Server)
                {
                    return;
                }
                // Child
                {
                    if (data is User)
                    {
                        User user = data as User;
                        // Child
                        {
                            user.human.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is Human)
                        {
                            return;
                        }
                    }
                }
            }
            // Sub
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.View:
                            {
                                GlobalViewUI.UIData globalViewUIData = sub as GlobalViewUI.UIData;
                                globalViewUIData.removeCallBackAndDestroy(typeof(GlobalViewUI));
                            }
                            break;
                        case UIData.Sub.Type.Ban:
                            {
                                GlobalBanUI.UIData globalBanUIData = sub as GlobalBanUI.UIData;
                                globalBanUIData.removeCallBackAndDestroy(typeof(GlobalBanUI));
                            }
                            break;
                        default:
                            Debug.LogError("Unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
                }
                return;
            }
            if (data is AfterLoginMainBtnBackUI.UIData)
            {
                AfterLoginMainBtnBackUI.UIData btnBack = data as AfterLoginMainBtnBackUI.UIData;
                // UI
                {
                    btnBack.removeCallBackAndDestroy(typeof(AfterLoginMainBtnBackUI));
                }
                return;
            }
            if (data is GlobalStateUI.UIData)
            {
                GlobalStateUI.UIData state = data as GlobalStateUI.UIData;
                // UI
                {
                    state.removeCallBackAndDestroy(typeof(GlobalStateUI));
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
                case UIData.Property.sub:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnBack:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.state:
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
        if(wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    break;
                case Setting.Property.style:
                    break;
                case Setting.Property.contentTextSize:
                    dirty = true;
                    break;
                case Setting.Property.titleTextSize:
                    dirty = true;
                    break;
                case Setting.Property.labelTextSize:
                    dirty = true;
                    break;
                case Setting.Property.buttonSize:
                    dirty = true;
                    break;
                case Setting.Property.confirmQuit:
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                case Setting.Property.defaultChosenGame:
                    break;
                case Setting.Property.defaultRoomName:
                    break;
                case Setting.Property.defaultChatRoomStyle:
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
                        dirty = true;
                        break;
                    case Server.Property.profile:
                        break;
                    case Server.Property.state:
                        break;
                    case Server.Property.users:
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
            // Child
            {
                if (wrapProperty.p is User)
                {
                    switch ((User.Property)wrapProperty.n)
                    {
                        case User.Property.human:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
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
                // Child
                {
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
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
            if (wrapProperty.p is AfterLoginMainBtnBackUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is GlobalStateUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}