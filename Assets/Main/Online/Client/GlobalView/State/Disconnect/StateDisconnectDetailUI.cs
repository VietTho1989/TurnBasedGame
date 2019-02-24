using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class StateDisconnectDetailUI : UIBehavior<StateDisconnectDetailUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Server.State.Disconnect>> disconnect;

        public VP<LoginStateUI.UIData> loginState;

        #region Constructor

        public enum Property
        {
            disconnect,
            loginState
        }

        public UIData() : base()
        {
            this.disconnect = new VP<ReferenceData<Server.State.Disconnect>>(this, (byte)Property.disconnect, new ReferenceData<Server.State.Disconnect>(null));
            this.loginState = new VP<LoginStateUI.UIData>(this, (byte)Property.loginState, new LoginStateUI.UIData());
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        StateDisconnectDetailUI stateDisconnectDetailUI = this.findCallBack<StateDisconnectDetailUI>();
                        if (stateDisconnectDetailUI != null)
                        {
                            stateDisconnectDetailUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("stateDisconnectDetailUI null");
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    public Text tvMessage;
    public static readonly TxtLanguage txtMessage = new TxtLanguage();

    static StateDisconnectDetailUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Mất Kết Nối");
            txtMessage.add(Language.Type.vi, "Server đã mất kết nối được");
        }
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
                Server.State.Disconnect disconnect = this.data.disconnect.v.data;
                if (disconnect != null)
                {
                    // title
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Server Disconnected");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                    // message
                    {
                        if (tvMessage != null)
                        {
                            tvMessage.text = txtMessage.get("Server has disconnected in") + " " + disconnect.time.v;
                        }
                        else
                        {
                            Debug.LogError("tvMessage null");
                        }
                    }
                    // login
                    {
                        LoginStateUI.UIData loginStateUIData = this.data.loginState.v;
                        if (loginStateUIData != null)
                        {
                            loginStateUIData.login.v = new ReferenceData<Login>(disconnect.login.v);
                        }
                        else
                        {
                            Debug.LogError("loginUIData null: " + this);
                        }
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        deltaY += UIConstants.HeaderHeight;
                        // tvMessage
                        deltaY += 30;
                        // loginStateUIData
                        deltaY += UIRectTransform.SetPosY(this.data.loginState.v, deltaY);
                        deltaY += 10;
                        // set height
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                }
                else
                {
                    Debug.LogError("disconnect null: " + this);
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

    public LoginStateUI loginStatePrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.disconnect.allAddCallBack(this);
                uiData.loginState.allAddCallBack(this);
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
            if (data is Server.State.Disconnect)
            {
                dirty = true;
                return;
            }
            // loginStateUIData
            {
                if (data is LoginStateUI.UIData)
                {
                    LoginStateUI.UIData loginStateUIData = data as LoginStateUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(loginStateUIData, loginStatePrefab, this.transform);
                    }
                    // Child
                    {
                        TransformData.AddCallBack(loginStateUIData, this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is TransformData)
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
                uiData.disconnect.allRemoveCallBack(this);
                uiData.loginState.allRemoveCallBack(this);
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
            if (data is Server.State.Disconnect)
            {
                return;
            }
            // loginStateUIData
            {
                if (data is LoginStateUI.UIData)
                {
                    LoginStateUI.UIData loginStateUIData = data as LoginStateUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(loginStateUIData, this);
                    }
                    // UI
                    {
                        loginStateUIData.removeCallBackAndDestroy(typeof(LoginStateUI));
                    }
                    return;
                }
                // Child
                if(data is TransformData)
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
                case UIData.Property.disconnect:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.loginState:
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
            if (wrapProperty.p is Server.State.Disconnect)
            {
                switch ((Server.State.Disconnect.Property)wrapProperty.n)
                {
                    case Server.State.Disconnect.Property.time:
                        dirty = true;
                        break;
                    case Server.State.Disconnect.Property.login:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // loginStateUIData
            {
                if (wrapProperty.p is LoginStateUI.UIData)
                {
                    return;
                }
                // Child
                if(wrapProperty.p is TransformData)
                {
                    switch ((TransformData.Property)wrapProperty.n)
                    {
                        case TransformData.Property.position:
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            StateDisconnectUI.UIData stateDisconnectUIData = this.data.findDataInParent<StateDisconnectUI.UIData>();
            if (stateDisconnectUIData != null)
            {
                stateDisconnectUIData.detail.v = null;
            }
            else
            {
                Debug.LogError("stateDisconnectUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}