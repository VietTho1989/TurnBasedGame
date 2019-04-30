using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace LoginState
{
    public class StepLoginUpdate : UpdateBehavior<StepLogin>
    {

        #region update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // connect?
                    {
                        // Find
                        bool isConnect = false;
                        {
                            Log log = this.data.findDataInParent<Log>();
                            if (log != null)
                            {
                                if (log.connectState.v != null && log.connectState.v.getType() == Log.ConnectState.Type.HaveConnect)
                                {
                                    isConnect = true;
                                }
                            }
                            else
                            {
                                Debug.LogError("log null: " + this);
                            }
                        }
                        // Process
                        if (isConnect)
                        {
                            if (this.data.state.v == StepLogin.State.Not)
                            {
                                this.data.state.v = StepLogin.State.Log;
                            }
                        }
                        else
                        {
                            this.data.state.v = StepLogin.State.Not;
                        }
                    }
                    // Task
                    {
                        switch (this.data.state.v)
                        {
                            case StepLogin.State.Not:
                                {
                                    destroyRoutine(wait);
                                }
                                break;
                            case StepLogin.State.Log:
                                {
                                    destroyRoutine(wait);
                                    // request
                                    {
                                        ClientConnectIdentity clientConnect = FindObjectOfType<ClientConnectIdentity>();
                                        if (clientConnect != null)
                                        {
                                            // Find AccountMessage
                                            Account account = null;
                                            {
                                                Login login = this.data.findDataInParent<Login>();
                                                if (login != null)
                                                {
                                                    account = login.account.v;
                                                }
                                                else
                                                {
                                                    Debug.LogError("login null: " + this);
                                                }
                                            }
                                            if (account != null)
                                            {
                                                AccountMessage accountMessage = account.makeAccountMessage();
                                                if (accountMessage != null)
                                                {
                                                    // request login or register email
                                                    {
                                                        // find
                                                        bool isRegisterEmail = false;
                                                        {
                                                            if(accountMessage is AccountEmailMessage)
                                                            {
                                                                AccountEmailMessage accountEmailMessage = accountMessage as AccountEmailMessage;
                                                                isRegisterEmail = accountEmailMessage.isRegister;
                                                            }
                                                        }
                                                        // process
                                                        if (!isRegisterEmail)
                                                        {
                                                            clientConnect.requestLogin(accountMessage, Account.getIdentites(), ChatViewer.GetChatViewerByteArray());
                                                        }
                                                        else
                                                        {
                                                            if(accountMessage is AccountEmailMessage)
                                                            {
                                                                AccountEmailMessage accountEmailMessage = accountMessage as AccountEmailMessage;
                                                                clientConnect.CmdRegisterEmailAccount(accountEmailMessage);
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("why not accountEmailMessage");
                                                            }
                                                        }
                                                    }
                                                    this.data.state.v = StepLogin.State.Wait;
                                                }
                                                else
                                                {
                                                    Debug.LogError("accountMeesage null: " + this);
                                                    // Chuyen ve login state none
                                                    Login login = account.findDataInParent<Login>();
                                                    if (login != null)
                                                    {
                                                        None none = new None();
                                                        {
                                                            none.uid = login.state.makeId();
                                                        }
                                                        login.state.v = none;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("login null: " + this);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("account null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("why cannot find userIdentity: " + this);
                                            this.data.state.v = StepLogin.State.Not;
                                        }
                                    }
                                }
                                break;
                            case StepLogin.State.Wait:
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
                                break;
                            default:
                                Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                break;
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
                yield return new Wait(120f);
                if (this.data != null)
                {
                    this.data.state.v = StepLogin.State.Not;
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
                Debug.LogError("resend: " + this);
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

        private Login login = null;
        private Log log = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is StepLogin)
            {
                StepLogin stepLogin = data as StepLogin;
                // Parent
                {
                    DataUtils.addParentCallBack(stepLogin, this, ref this.login);
                    DataUtils.addParentCallBack(stepLogin, this, ref this.log);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is Login)
                {
                    // Login login = data as Login;
                    {

                    }
                    dirty = true;
                    return;
                }
                if (data is Log)
                {
                    // Log log = data as Log;
                    {

                    }
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is StepLogin)
            {
                StepLogin stepLogin = data as StepLogin;
                // Parent
                {
                    DataUtils.removeParentCallBack(stepLogin, this, ref this.login);
                    DataUtils.removeParentCallBack(stepLogin, this, ref this.log);
                }
                this.setDataNull(stepLogin);
                return;
            }
            // Parent
            {
                if (data is Login)
                {
                    // Login login = data as Login;
                    {

                    }
                    return;
                }
                if (data is Log)
                {
                    // Log log = data as Log;
                    {

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
            if (wrapProperty.p is StepLogin)
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
                return;
            }
            // Parent
            {
                if (wrapProperty.p is Login)
                {
                    switch ((Login.Property)wrapProperty.n)
                    {
                        case Login.Property.state:
                            break;
                        case Login.Property.account:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is Log)
                {
                    switch ((Log.Property)wrapProperty.n)
                    {
                        case Log.Property.connectState:
                            dirty = true;
                            break;
                        case Log.Property.step:
                            break;
                        case Log.Property.time:
                            break;
                        case Log.Property.timeOut:
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

    }
}