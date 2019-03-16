using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayOnlineUI : UIBehavior<PlayOnlineUI.UIData>
{

    #region UIData

    public class UIData : MainUI.UIData.Sub
    {

        #region Sub

        public abstract class Sub : Data
        {

            public enum Type
            {
                Menu,
                Client,
                Server
            }

            public abstract Type getType();

            public abstract bool processEvent(Event e);

        }

        public VP<PlayOnlineUI.UIData.Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            sub
        }

        public UIData() : base()
        {
            sub = new VP<Sub>(this, (byte)Property.sub, new MenuOnlineUI.UIData());
        }

        #endregion

        public override MainUI.UIData.Sub.Type getType()
        {
            return MainUI.UIData.Sub.Type.Online;
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

            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public MenuOnlineUI menuOnlineUIPrefab = null;
    public OnlineClientUI onlineClientUIPrefab = null;
    public ServerOnlineUI serverUIPrefab = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        if (data is UIData.Sub)
        {
            UIData.Sub sub = data as UIData.Sub;
            // UI
            {
                switch (sub.getType())
                {
                    case PlayOnlineUI.UIData.Sub.Type.Menu:
                        {
                            MenuOnlineUI.UIData menuOnlineUIData = sub as MenuOnlineUI.UIData;
                            UIUtils.Instantiate(menuOnlineUIData, menuOnlineUIPrefab, this.transform);
                        }
                        break;
                    case PlayOnlineUI.UIData.Sub.Type.Client:
                        {
                            OnlineClientUI.UIData onlineClientUIData = sub as OnlineClientUI.UIData;
                            UIUtils.Instantiate(onlineClientUIData, onlineClientUIPrefab, this.transform);
                        }
                        break;
                    case PlayOnlineUI.UIData.Sub.Type.Server:
                        {
                            ServerOnlineUI.UIData serverOnlineUIData = sub as ServerOnlineUI.UIData;
                            UIUtils.Instantiate(serverOnlineUIData, serverUIPrefab, this.transform);
                        }
                        break;
                    default:
                        Debug.LogError("unknown sub: " + sub.getType() + "; " + this);
                        break;
                }
            }
            dirty = true;
            return;
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
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        if (data is UIData.Sub)
        {
            UIData.Sub sub = data as UIData.Sub;
            // UI
            {
                switch (sub.getType())
                {
                    case PlayOnlineUI.UIData.Sub.Type.Menu:
                        {
                            MenuOnlineUI.UIData menuOnlineUIData = sub as MenuOnlineUI.UIData;
                            menuOnlineUIData.removeCallBackAndDestroy(typeof(MenuOnlineUI));
                        }
                        break;
                    case PlayOnlineUI.UIData.Sub.Type.Client:
                        {
                            OnlineClientUI.UIData onlineClientUIData = sub as OnlineClientUI.UIData;
                            onlineClientUIData.removeCallBackAndDestroy(typeof(OnlineClientUI));
                        }
                        break;
                    case PlayOnlineUI.UIData.Sub.Type.Server:
                        {
                            ServerOnlineUI.UIData serverOnlineUIData = sub as ServerOnlineUI.UIData;
                            serverOnlineUIData.removeCallBackAndDestroy(typeof(ServerOnlineUI));
                        }
                        break;
                    default:
                        Debug.LogError("unknown sub: " + sub.getType() + "; " + this);
                        break;
                }
            }
            return;
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
        if (wrapProperty.p is UIData.Sub)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}