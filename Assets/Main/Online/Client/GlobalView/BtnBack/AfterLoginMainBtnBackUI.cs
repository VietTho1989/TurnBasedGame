using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterLoginMainBtnBackUI : UIBehavior<AfterLoginMainBtnBackUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Server>> server;

        #region Sub

        public abstract class Sub : Data
        {

            public abstract Server.Type getType();

            public abstract bool processEvent(Event e);

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

        public bool processEvent(Event e)
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
                Server server = this.data.server.v.data;
                if (server != null)
                {
                    switch (server.type.v)
                    {
                        case Server.Type.Server:
                            {
                                AfterLoginMainBtnBackServerUI.UIData backServerUIData = this.data.sub.newOrOld<AfterLoginMainBtnBackServerUI.UIData>();
                                {
                                    backServerUIData.server.v = new ReferenceData<Server>(server);
                                }
                                this.data.sub.v = backServerUIData;
                            }
                            break;
                        case Server.Type.Client:
                            {
                                AfterLoginMainBtnBackClientUI.UIData backClientUIData = this.data.sub.newOrOld<AfterLoginMainBtnBackClientUI.UIData>();
                                {
                                    backClientUIData.server.v = new ReferenceData<Server>(server);
                                }
                                this.data.sub.v = backClientUIData;
                            }
                            break;
                        case Server.Type.Host:
                            {
                                AfterLoginMainBtnBackHostUI.UIData backHostUIData = this.data.sub.newOrOld<AfterLoginMainBtnBackHostUI.UIData>();
                                {
                                    backHostUIData.server.v = new ReferenceData<Server>(server);
                                }
                                this.data.sub.v = backHostUIData;
                            }
                            break;
                        case Server.Type.Offline:
                            {
                                AfterLoginMainBtnBackOfflineUI.UIData backOfflineUIData = this.data.sub.newOrOld<AfterLoginMainBtnBackOfflineUI.UIData>();
                                {
                                    backOfflineUIData.server.v = new ReferenceData<Server>(server);
                                }
                                this.data.sub.v = backOfflineUIData;
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + server.type.v + "; " + this);
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

    public AfterLoginMainBtnBackServerUI backServerPrefab;
    public AfterLoginMainBtnBackClientUI backClientPrefab;
    public AfterLoginMainBtnBackHostUI backHostPrefab;
    public AfterLoginMainBtnBackOfflineUI backOfflinePrefab;

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
                // Child
                {
                    switch (sub.getType())
                    {
                        case Server.Type.Server:
                            {
                                AfterLoginMainBtnBackServerUI.UIData backServerUIData = sub as AfterLoginMainBtnBackServerUI.UIData;
                                UIUtils.Instantiate(backServerUIData, backServerPrefab, this.transform, UIConstants.FullParent);
                            }
                            break;
                        case Server.Type.Client:
                            {
                                AfterLoginMainBtnBackClientUI.UIData backClientUIData = sub as AfterLoginMainBtnBackClientUI.UIData;
                                UIUtils.Instantiate(backClientUIData, backClientPrefab, this.transform, UIConstants.FullParent);
                            }
                            break;
                        case Server.Type.Host:
                            {
                                AfterLoginMainBtnBackHostUI.UIData backHostUIData = sub as AfterLoginMainBtnBackHostUI.UIData;
                                UIUtils.Instantiate(backHostUIData, backHostPrefab, this.transform, UIConstants.FullParent);
                            }
                            break;
                        case Server.Type.Offline:
                            {
                                AfterLoginMainBtnBackOfflineUI.UIData backOfflineUIData = sub as AfterLoginMainBtnBackOfflineUI.UIData;
                                UIUtils.Instantiate(backOfflineUIData, backOfflinePrefab, this.transform, UIConstants.FullParent);
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
                // Child
                {
                    switch (sub.getType())
                    {
                        case Server.Type.Server:
                            {
                                AfterLoginMainBtnBackServerUI.UIData backServerUIData = sub as AfterLoginMainBtnBackServerUI.UIData;
                                backServerUIData.removeCallBackAndDestroy(typeof(AfterLoginMainBtnBackServerUI));
                            }
                            break;
                        case Server.Type.Client:
                            {
                                AfterLoginMainBtnBackClientUI.UIData backClientUIData = sub as AfterLoginMainBtnBackClientUI.UIData;
                                backClientUIData.removeCallBackAndDestroy(typeof(AfterLoginMainBtnBackClientUI));
                            }
                            break;
                        case Server.Type.Host:
                            {
                                AfterLoginMainBtnBackHostUI.UIData backHostUIData = sub as AfterLoginMainBtnBackHostUI.UIData;
                                backHostUIData.removeCallBackAndDestroy(typeof(AfterLoginMainBtnBackHostUI));
                            }
                            break;
                        case Server.Type.Offline:
                            {
                                AfterLoginMainBtnBackOfflineUI.UIData backOfflineUIData = sub as AfterLoginMainBtnBackOfflineUI.UIData;
                                backOfflineUIData.removeCallBackAndDestroy(typeof(AfterLoginMainBtnBackOfflineUI));
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
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}