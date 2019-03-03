using UnityEngine;
using UnityEngine.UI;
using Mirror;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class LoginStateUI : UIBehavior<LoginStateUI.UIData>, HaveTransformData
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Login>> login;

        #region Sub

        public abstract class Sub : Data
        {

            public abstract Login.State.Type getType();

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            login,
            sub
        }

        public UIData() : base()
        {
            this.login = new VP<ReferenceData<Login>>(this, (byte)Property.login, new ReferenceData<Login>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
        }

        #endregion
    }

    #endregion

    #region TransformData

    public TransformData transformData = new TransformData();

    private void updateTransformData()
    {
        this.transformData.update(this.transform);
    }

    public TransformData getTransformData()
    {
        return this.transformData;
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
                Login login = this.data.login.v.data;
                if (login != null)
                {
                    Login.State state = login.state.v;
                    if (state != null)
                    {
                        switch (state.getType())
                        {
                            case Login.State.Type.None:
                                {
                                    LoginState.None none = state as LoginState.None;
                                    // UIData
                                    LoginState.NoneUI.UIData noneUIData = this.data.sub.newOrOld<LoginState.NoneUI.UIData>();
                                    {
                                        noneUIData.none.v = new ReferenceData<LoginState.None>(none);
                                    }
                                    this.data.sub.v = noneUIData;
                                }
                                break;
                            case Login.State.Type.Log:
                                {
                                    LoginState.Log log = state as LoginState.Log;
                                    // UIData
                                    LoginState.LogUI.UIData logUIData = this.data.sub.newOrOld<LoginState.LogUI.UIData>();
                                    {
                                        logUIData.log.v = new ReferenceData<LoginState.Log>(log);
                                    }
                                    this.data.sub.v = logUIData;
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
                    Debug.LogError("login null: " + this);
                }
                // UI
                {
                    float deltaY = 0;
                    // state
                    deltaY += UIRectTransform.SetPosY(this.data.sub.v, deltaY);
                    // set height
                    UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
        updateTransformData();
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public LoginState.NoneUI nonePrefab;
    public LoginState.LogUI logPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Global
            Global.get().addCallBack(this);
            // Child
            {
                uiData.login.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Global
        if (data is Global)
        {
            dirty = true;
            return;
        }
        // Child
        {
            if (data is Login)
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
                            case Login.State.Type.None:
                                {
                                    LoginState.NoneUI.UIData noneUIData = sub as LoginState.NoneUI.UIData;
                                    UIUtils.Instantiate(noneUIData, nonePrefab, this.transform);
                                }
                                break;
                            case Login.State.Type.Log:
                                {
                                    LoginState.LogUI.UIData logUIData = sub as LoginState.LogUI.UIData;
                                    UIUtils.Instantiate(logUIData, logPrefab, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
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
            // Global
            Global.get().removeCallBack(this);
            // Child
            {
                uiData.login.allRemoveCallBack(this);
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Global
        if (data is Global)
        {
            return;
        }
        // Child
        {
            if (data is Login)
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
                            case Login.State.Type.None:
                                {
                                    LoginState.NoneUI.UIData noneUIData = sub as LoginState.NoneUI.UIData;
                                    noneUIData.removeCallBackAndDestroy(typeof(LoginState.NoneUI));
                                }
                                break;
                            case Login.State.Type.Log:
                                {
                                    LoginState.LogUI.UIData logUIData = sub as LoginState.LogUI.UIData;
                                    logUIData.removeCallBackAndDestroy(typeof(LoginState.LogUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                // Child
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
                case UIData.Property.login:
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
        // Global
        if (wrapProperty.p is Global)
        {
            Global.OnValueTransformChange(wrapProperty, this);
            return;
        }
        // Child
        {
            if (wrapProperty.p is Login)
            {
                switch ((Login.Property)wrapProperty.n)
                {
                    case Login.Property.state:
                        dirty = true;
                        break;
                    case Login.Property.account:
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}