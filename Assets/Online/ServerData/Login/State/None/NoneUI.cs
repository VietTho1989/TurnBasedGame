using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
    public class NoneUI : UIHaveTransformDataBehavior<NoneUI.UIData>
    {

        #region UIData

        public class UIData : LoginStateUI.UIData.Sub
        {

            public VP<ReferenceData<None>> none;

            #region Sub

            public abstract class Sub : Data
            {
                public abstract None.State.Type getType();
            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                none,
                sub
            }

            public UIData() : base()
            {
                this.none = new VP<ReferenceData<None>>(this, (byte)Property.none, new ReferenceData<None>(null));
                this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            }

            #endregion

            public override Login.State.Type getType()
            {
                return Login.State.Type.None;
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
                            NoneUI noneUI = this.findCallBack<NoneUI>();
                            if (noneUI != null)
                            {
                                isProcess = noneUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("noneUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text tvLogin;
        private static readonly TxtLanguage txtLogin = new TxtLanguage("Login");
        private static readonly TxtLanguage txtRegister = new TxtLanguage("Register");

        private static readonly TxtLanguage txtEmailNotCorrect = new TxtLanguage("Email not correct");
        private static readonly TxtLanguage txtRetypePasswordNotCorrect = new TxtLanguage("Retype password not correct");

        static NoneUI()
        {
            txtLogin.add(Language.Type.vi, "Đăng Nhập");
            txtRegister.add(Language.Type.vi, "Đăng Ký");

            txtEmailNotCorrect.add(Language.Type.vi, "Email không đúng");
            txtRetypePasswordNotCorrect.add(Language.Type.vi, "Mật khẩu viết lại không đúng");
        }

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    None none = this.data.none.v.data;
                    if (none != null)
                    {
                        None.State state = none.state.v;
                        if (state != null)
                        {
                            switch (state.getType())
                            {
                                case None.State.Type.Normal:
                                    {
                                        StateNormal stateNormal = state as StateNormal;
                                        // UIData
                                        StateNormalUI.UIData stateNormalUIData = this.data.sub.newOrOld<StateNormalUI.UIData>();
                                        {
                                            stateNormalUIData.stateNormal.v = new ReferenceData<StateNormal>(stateNormal);
                                        }
                                        this.data.sub.v = stateNormalUIData;
                                    }
                                    break;
                                case None.State.Type.Fail:
                                    {
                                        StateFail stateFail = state as StateFail;
                                        // UIData
                                        StateFailUI.UIData stateFailUIData = this.data.sub.newOrOld<StateFailUI.UIData>();
                                        {
                                            stateFailUIData.stateFail.v = new ReferenceData<StateFail>(stateFail);
                                        }
                                        this.data.sub.v = stateFailUIData;
                                    }
                                    break;
                                case None.State.Type.Success:
                                    {
                                        StateSuccess stateSuccess = state as StateSuccess;
                                        // UIData
                                        StateSuccessUI.UIData stateSuccessUIData = this.data.sub.newOrOld<StateSuccessUI.UIData>();
                                        {
                                            stateSuccessUIData.stateSuccess.v = new ReferenceData<StateSuccess>(stateSuccess);
                                        }
                                        this.data.sub.v = stateSuccessUIData;
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("state null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("none null: " + this);
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // btnLogin
                        {
                            deltaY += 50;
                        }
                        // sub
                        deltaY += UIRectTransform.SetPosY(this.data.sub.v, deltaY);
                        // set height
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (tvLogin != null)
                        {
                            // find
                            bool isRegister = false;
                            {
                                LoginUI.UIData loginUIData = this.data.findDataInParent<LoginUI.UIData>();
                                if (loginUIData != null)
                                {
                                    AccountUI.UIData accountUIData = loginUIData.accountUIData.v;
                                    if (accountUIData != null)
                                    {
                                        AccountUI.UIData.Sub sub = accountUIData.sub.v;
                                        if (sub != null)
                                        {
                                            if(sub is AccountEmailUI.UIData)
                                            {
                                                AccountEmailUI.UIData accountEmailUIData = sub as AccountEmailUI.UIData;
                                                if(accountEmailUIData.type.v == AccountEmailUI.UIData.Type.Register)
                                                {
                                                    isRegister = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("sub null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("accountUIData null");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("loginUIData null");
                                }
                            }
                            // process
                            if (!isRegister)
                            {
                                tvLogin.text = txtLogin.get();
                            }
                            else
                            {
                                tvLogin.text = txtRegister.get();
                            }
                        }
                        else
                        {
                            Debug.LogError("tvLogin null: " + this);
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

        public StateNormalUI stateNormalPrefab;
        public StateFailUI stateFailPrefab;
        public StateSuccessUI stateSuccessPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.none.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
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
                if (data is None)
                {
                    dirty = true;
                    return;
                }
                // sub
                {
                    if (data is UIData.Sub)
                    {
                        UIData.Sub sub = data as UIData.Sub;
                        // UI
                        {
                            switch (sub.getType())
                            {
                                case None.State.Type.Normal:
                                    {
                                        StateNormalUI.UIData stateNormalUIData = sub as StateNormalUI.UIData;
                                        UIUtils.Instantiate(stateNormalUIData, stateNormalPrefab, this.transform);
                                    }
                                    break;
                                case None.State.Type.Fail:
                                    {
                                        StateFailUI.UIData stateFailUIData = sub as StateFailUI.UIData;
                                        UIUtils.Instantiate(stateFailUIData, stateFailPrefab, this.transform);
                                    }
                                    break;
                                case None.State.Type.Success:
                                    {
                                        StateSuccessUI.UIData stateSuccessUIData = sub as StateSuccessUI.UIData;
                                        UIUtils.Instantiate(stateSuccessUIData, stateSuccessPrefab, this.transform);
                                    }
                                    break;
                                default:
                                    Debug.LogError("Unknown type: " + sub.getType() + "; " + this);
                                    break;
                            }
                        }
                        // Child
                        {
                            TransformData.AddCallBack(sub, this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is TransformData)
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
                    uiData.none.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
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
                if (data is None)
                {
                    return;
                }
                // sub
                {
                    if (data is UIData.Sub)
                    {
                        UIData.Sub sub = data as UIData.Sub;
                        // Child
                        {
                            TransformData.RemoveCallBack(sub, this);
                        }
                        // UI
                        {
                            switch (sub.getType())
                            {
                                case None.State.Type.Normal:
                                    {
                                        StateNormalUI.UIData stateNormalUIData = sub as StateNormalUI.UIData;
                                        stateNormalUIData.removeCallBackAndDestroy(typeof(StateNormalUI));
                                    }
                                    break;
                                case None.State.Type.Fail:
                                    {
                                        StateFailUI.UIData stateFailUIData = sub as StateFailUI.UIData;
                                        stateFailUIData.removeCallBackAndDestroy(typeof(StateFailUI));
                                    }
                                    break;
                                case None.State.Type.Success:
                                    {
                                        StateSuccessUI.UIData stateSuccessUIData = sub as StateSuccessUI.UIData;
                                        stateSuccessUIData.removeCallBackAndDestroy(typeof(StateSuccessUI));

                                    }
                                    break;
                                default:
                                    Debug.LogError("Unknown type: " + sub.getType() + "; " + this);
                                    break;
                            }
                        }
                        return;
                    }
                    // sub
                    if (data is TransformData)
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
                    case UIData.Property.none:
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
                if (wrapProperty.p is None)
                {
                    switch ((None.Property)wrapProperty.n)
                    {
                        case None.Property.state:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // sub
                {
                    if (wrapProperty.p is UIData.Sub)
                    {
                        return;
                    }
                    // Child
                    if (wrapProperty.p is TransformData)
                    {
                        switch ((TransformData.Property)wrapProperty.n)
                        {
                            case TransformData.Property.anchoredPosition:
                                break;
                            case TransformData.Property.anchorMin:
                                break;
                            case TransformData.Property.anchorMax:
                                break;
                            case TransformData.Property.pivot:
                                break;
                            case TransformData.Property.offsetMin:
                                break;
                            case TransformData.Property.offsetMax:
                                break;
                            case TransformData.Property.sizeDelta:
                                break;
                            case TransformData.Property.rotation:
                                break;
                            case TransformData.Property.scale:
                                break;
                            case TransformData.Property.size:
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnLogin()
        {
            if (this.data != null)
            {
                None none = this.data.none.v.data;
                if (none != null)
                {
                    Login login = none.findDataInParent<Login>();
                    if (login != null)
                    {
                        // find correct or not
                        bool isCorrect = true;
                        {
                            if (login.account.v.getType() == Account.Type.EMAIL)
                            {
                                AccountEmail accountEmail = login.account.v as AccountEmail;
                                if (accountEmail.isRegister)
                                {
                                    // validate email
                                    if (isCorrect)
                                    {
                                        if (!GameUtils.Utils.validateEmail(accountEmail.email.v))
                                        {
                                            Toast.showMessage(txtEmailNotCorrect.get());
                                            isCorrect = false;
                                        }
                                    }
                                    // retype password as password
                                    if (isCorrect)
                                    {
                                        LoginUI.UIData loginUIData = this.data.findDataInParent<LoginUI.UIData>();
                                        if (loginUIData != null)
                                        {
                                            AccountUI.UIData accountUIData = loginUIData.accountUIData.v;
                                            if (accountUIData != null)
                                            {
                                                AccountUI.UIData.Sub sub = accountUIData.sub.v;
                                                if (sub != null)
                                                {
                                                    if (sub.getType() == Account.Type.EMAIL)
                                                    {
                                                        AccountEmailUI.UIData accountEmailUIData = sub as AccountEmailUI.UIData;
                                                        // find
                                                        string password = accountEmail.password.v;
                                                        string retypePassword = "";
                                                        {
                                                            RequestChangeStringUI.UIData requestRetypePassword = accountEmailUIData.retypePassword.v;
                                                            if (requestRetypePassword != null)
                                                            {
                                                                RequestChangeUpdate<string>.UpdateData updateData = requestRetypePassword.updateData.v;
                                                                if (updateData != null)
                                                                {
                                                                    retypePassword = updateData.current.v;
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("updateData null");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("requestRetypePassword null");
                                                            }
                                                        }
                                                        // compare
                                                        Debug.LogError("password: " + password + ", " + retypePassword);
                                                        if (password != retypePassword)
                                                        {
                                                            Toast.showMessage(txtRetypePasswordNotCorrect.get());
                                                            isCorrect = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("sub null");
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("sub null");
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("accountUIData null");
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("loginUIData null");
                                        }
                                    }
                                }
                            }
                        }
                        // Chuyen sang log state
                        if (isCorrect)
                        {
                            LoginState.Log log = new LoginState.Log();
                            {
                                log.uid = login.state.makeId();
                            }
                            login.state.v = log;
                        }
                        else
                        {
                            Debug.LogError("account not correct");
                        }
                    }
                    else
                    {
                        Debug.LogError("login null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("none null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}