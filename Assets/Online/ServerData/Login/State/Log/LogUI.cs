using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace LoginState
{
    public class LogUI : UIHaveTransformDataBehavior<LogUI.UIData>
    {

        #region UIData

        public class UIData : LoginStateUI.UIData.Sub
        {

            public VP<ReferenceData<Log>> log;

            #region Constructor

            public enum Property
            {
                log
            }

            public UIData() : base()
            {
                this.log = new VP<ReferenceData<Log>>(this, (byte)Property.log, new ReferenceData<Log>(null));
            }

            #endregion

            public override Login.State.Type getType()
            {
                return Login.State.Type.Log;
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
                            LogUI logUI = this.findCallBack<LogUI>();
                            if (logUI != null)
                            {
                                isProcess = logUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("logUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text tvCancel;
        private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

        private static readonly TxtLanguage txtTime = new TxtLanguage("Time");

        private static readonly TxtLanguage txtConnect = new TxtLanguage("Connecting to server...");
        private static readonly TxtLanguage txtGetDevice = new TxtLanguage("Getting device information...");
        private static readonly TxtLanguage txtGetEmail = new TxtLanguage("Getting email information...");
        private static readonly TxtLanguage txtGetFacebook = new TxtLanguage("Getting facebook information...");
        private static readonly TxtLanguage txtLogin = new TxtLanguage("Login server...");
        private static readonly TxtLanguage txtLoggingIn = new TxtLanguage("Logging in server...");

        static LogUI()
        {
            txtCancel.add(Language.Type.vi, "Huỷ bỏ");
            txtTime.add(Language.Type.vi, "Thời gian");
            txtConnect.add(Language.Type.vi, "Đang kết nối server...");
            txtGetDevice.add(Language.Type.vi, "Đang lấy thông tin thiết bị...");
            txtGetEmail.add(Language.Type.vi, "Đang lấy thông tin email...");
            txtGetFacebook.add(Language.Type.vi, "Đang lấy thông tin facebook...");
            txtLogin.add(Language.Type.vi, "Đăng nhập");
            txtLoggingIn.add(Language.Type.vi, "Đang đăng nhập...");
        }

        #endregion

        #region Refresh

        public Text tvTime;
        public Text tvProgress;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Log log = this.data.log.v.data;
                    if (log != null)
                    {
                        // tvCancel
                        if (tvCancel != null)
                        {
                            tvCancel.text = txtCancel.get();
                        }
                        else
                        {
                            Debug.LogError("tvCancel null: " + this);
                        }
                        // tvTime
                        if (tvTime != null)
                        {
                            tvTime.text = txtTime.get() + ": " + log.time.v + "/" + log.timeOut.v;
                        }
                        else
                        {
                            Debug.LogError("tvTime null: " + this);
                        }
                        // tvProgress
                        if (tvProgress != null)
                        {
                            Log.Step step = log.step.v;
                            if (step != null)
                            {
                                switch (step.getType())
                                {
                                    case Log.Step.Type.Start:
                                        tvProgress.text = txtConnect.get();
                                        break;
                                    case Log.Step.Type.GetData:
                                        {
                                            StepGetData stepGetData = step as StepGetData;
                                            StepGetData.Sub sub = stepGetData.sub.v;
                                            if (sub != null)
                                            {
                                                switch (sub.getType())
                                                {
                                                    case Account.Type.DEVICE:
                                                        tvProgress.text = txtGetDevice.get();
                                                        break;
                                                    case Account.Type.EMAIL:
                                                        tvProgress.text = txtGetEmail.get();
                                                        break;
                                                    case Account.Type.FACEBOOK:
                                                        tvProgress.text = txtGetFacebook.get();
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("sub null: " + this);
                                            }
                                        }
                                        break;
                                    case Log.Step.Type.Login:
                                        {
                                            StepLogin stepLogin = step as StepLogin;
                                            switch (stepLogin.state.v)
                                            {
                                                case StepLogin.State.Not:
                                                    tvProgress.text = txtConnect.get();
                                                    break;
                                                case StepLogin.State.Log:
                                                    tvProgress.text = txtLogin.get();
                                                    break;
                                                case StepLogin.State.Wait:
                                                    tvProgress.text = txtLoggingIn.get();
                                                    break;
                                                default:
                                                    Debug.LogError("unknown state: " + stepLogin.state.v + "; " + this);
                                                    break;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + step.getType() + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("step null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("tvProgress null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("log null: " + this);
                    }
                }
                else
                {
                    Debug.Log("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.log.allAddCallBack(this);
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
                if (data is Log)
                {
                    Log log = data as Log;
                    // Child
                    {
                        log.step.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Log.Step)
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
                    uiData.log.allAddCallBack(this);
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
                if (data is Log)
                {
                    Log log = data as Log;
                    // Child
                    {
                        log.step.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Log.Step)
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
                    case UIData.Property.log:
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
                if (wrapProperty.p is Log)
                {
                    switch ((Log.Property)wrapProperty.n)
                    {
                        case Log.Property.connectState:
                            break;
                        case Log.Property.step:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Log.Property.time:
                            dirty = true;
                            break;
                        case Log.Property.timeOut:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is Log.Step)
                {
                    Log.Step step = wrapProperty.p as Log.Step;
                    switch (step.getType())
                    {
                        case Log.Step.Type.Start:
                            break;
                        case Log.Step.Type.GetData:
                            {
                                switch ((StepGetData.Property)wrapProperty.n)
                                {
                                    case StepGetData.Property.sub:
                                        dirty = true;
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                            }
                            break;
                        case Log.Step.Type.Login:
                            {
                                switch ((StepLogin.Property)wrapProperty.n)
                                {
                                    case StepLogin.Property.state:
                                        dirty = true;
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + step.getType() + "; " + this);
                            break;
                    }
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
                                if (btnCancel != null && btnCancel.gameObject.activeInHierarchy && btnCancel.interactable)
                                {
                                    this.onClickBtnCancel();
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

        public Button btnCancel;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnCancel()
        {
            // Debug.Log ("onClickBtnCancel");
            try
            {
                NetworkManager.Shutdown();
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
            if (this.data != null)
            {
                Log log = this.data.log.v.data;
                if (log != null)
                {
                    // offline thi tro ve none
                    {
                        Server.State.Offline offline = log.findDataInParent<Server.State.Offline>();
                        if (offline != null)
                        {
                            Login login = log.findDataInParent<Login>();
                            if (login != null)
                            {
                                None none = new None();
                                {
                                    none.uid = login.state.makeId();
                                    {
                                        StateNormal stateNormal = new StateNormal();
                                        {
                                            stateNormal.uid = none.state.makeId();
                                        }
                                        none.state.v = stateNormal;
                                    }
                                }
                                login.state.v = none;
                            }
                            else
                            {
                                Debug.LogError("login null: " + this);
                            }
                            return;
                        }
                        else
                        {
                            Debug.Log("not offline: " + this);
                        }
                    }
                    // disconnect thi chuyen sange offline
                    {
                        Server.State.Disconnect disconnect = log.findDataInParent<Server.State.Disconnect>();
                        if (disconnect != null)
                        {
                            Server server = disconnect.findDataInParent<Server>();
                            if (server != null)
                            {
                                Server.State.Offline offline = new Server.State.Offline();
                                {
                                    offline.uid = server.state.makeId();
                                }
                                server.state.v = offline;
                            }
                            else
                            {
                                Debug.LogError("server null: " + this);
                            }
                            return;
                        }
                        else
                        {
                            Debug.LogError("disconnect null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("log null: " + this);
                }
            }
        }
    }

}