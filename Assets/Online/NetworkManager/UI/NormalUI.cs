using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class NormalUI : UIBehavior<NormalUI.UIData>
{

    #region UIData

    public class UIData : ManagerUI.UIData.Sub
    {

        public VP<ReferenceData<Server>> server;

        #region Sub

        public abstract class Sub : Data
        {

            public enum Type
            {
                Login,
                AfterLogin
            }

            public abstract Type getType();

            public abstract bool processEvent(Event e);

            public abstract MainUI.UIData.AllowShowBanner getAllowShowBanner();

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            server,
            sub
        }

        public UIData() : base()
        {
            this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
        }

        #endregion

        public override Type getType()
        {
            return Type.Normal;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
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

    #region Update

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
                    // Sub
                    switch (server.state.v.getType())
                    {
                        case Server.State.Type.Offline:
                            {
                                LoginUI.UIData loginUIData = this.data.sub.newOrOld<LoginUI.UIData>();
                                {
                                    loginUIData.server.v = new ReferenceData<Server>(server);
                                }
                                this.data.sub.v = loginUIData;
                            }
                            break;
                        case Server.State.Type.Connect:
                        case Server.State.Type.Disconnect:
                            {
                                AfterLoginUI.UIData afterLoginUIData = this.data.sub.newOrOld<AfterLoginUI.UIData>();
                                {
                                    afterLoginUIData.server.v = new ReferenceData<Server>(server);
                                }
                                this.data.sub.v = afterLoginUIData;
                            }
                            break;
                        default:
                            Debug.LogError("unknown state: " + server.state.v.getType() + "; " + this);
                            break;
                    }
                }
                else
                {
                    Debug.LogError("server null: " + this);
                }
            }
            else
            {
                // Debug.LogError ("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public LoginUI loginUIPrefab;
    public AfterLoginUI afterLoginPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.server.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is Server)
            {
                dirty = true;
                return;
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.Login:
                            {
                                LoginUI.UIData loginData = sub as LoginUI.UIData;
                                UIUtils.Instantiate(loginData, loginUIPrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.AfterLogin:
                            {
                                AfterLoginUI.UIData afterLoginUIData = sub as AfterLoginUI.UIData;
                                UIUtils.Instantiate(afterLoginUIData, afterLoginPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
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
            // Child
            {
                uiData.server.allRemoveCallBack(this);
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is Server)
            {
                return;
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.Login:
                            {
                                LoginUI.UIData loginData = sub as LoginUI.UIData;
                                loginData.removeCallBackAndDestroy(typeof(LoginUI));
                            }
                            break;
                        case UIData.Sub.Type.AfterLogin:
                            {
                                AfterLoginUI.UIData afterLoginUIData = sub as AfterLoginUI.UIData;
                                afterLoginUIData.removeCallBackAndDestroy(typeof(AfterLoginUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
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
                Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                return;
            }
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}