using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ManagerUI : UIBehavior<ManagerUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Server>> server;

        #region Sub

        public abstract class Sub : Data
        {

            public enum Type
            {
                Load,
                Normal,
                Fail
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

        public MainUI.UIData.AllowShowBanner getAllowShowBanner()
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

    public override int getStartAllocate()
    {
        return 1;
    }

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
                    switch (server.startState.v)
                    {
                        case Server.StartState.Begin:
                        case Server.StartState.Start:
                        case Server.StartState.Starting:
                            {
                                LoadingUI.UIData loadingUIData = this.data.sub.newOrOld<LoadingUI.UIData>();
                                {
                                    loadingUIData.server.v = new ReferenceData<Server>(server);
                                }
                                this.data.sub.v = loadingUIData;
                            }
                            break;
                        case Server.StartState.Success:
                            {
                                NormalUI.UIData normalUIData = this.data.sub.newOrOld<NormalUI.UIData>();
                                {
                                    normalUIData.server.v = new ReferenceData<Server>(server);
                                }
                                this.data.sub.v = normalUIData;
                            }
                            break;
                        case Server.StartState.Fail:
                            {
                                StartFailUI.UIData startFailUIData = this.data.sub.newOrOld<StartFailUI.UIData>();
                                {
                                    startFailUIData.server.v = new ReferenceData<Server>(server);
                                }
                                this.data.sub.v = startFailUIData;
                            }
                            break;
                        default:
                            Debug.LogError("unknown startState: " + server.startState.v + "; " + this);
                            break;
                    }
                }
                else
                {
                    // Debug.LogError ("server null: " + this);
                }
            }
            else
            {
                // Debug.LogError ("server null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public LoadingUI loadPrefab;
    public NormalUI normalPrefab;
    public StartFailUI startFailPrefab;

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
                Server server = data as Server;
                // isRoot
                {
                    server.isRoot = true;
                }
                dirty = true;
                return;
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.Load:
                            {
                                LoadingUI.UIData subUIData = data as LoadingUI.UIData;
                                UIUtils.Instantiate(subUIData, loadPrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.Normal:
                            {
                                NormalUI.UIData subUIData = data as NormalUI.UIData;
                                UIUtils.Instantiate(subUIData, normalPrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.Fail:
                            {
                                StartFailUI.UIData subUIData = data as StartFailUI.UIData;
                                UIUtils.Instantiate(subUIData, startFailPrefab, this.transform);
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
                Server server = data as Server;
                // isRoot
                {
                    server.isRoot = false;
                }
                return;
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.Load:
                            {
                                LoadingUI.UIData subUIData = data as LoadingUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(LoadingUI));
                            }
                            break;
                        case UIData.Sub.Type.Normal:
                            {
                                NormalUI.UIData subUIData = data as NormalUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(NormalUI));
                            }
                            break;
                        case UIData.Sub.Type.Fail:
                            {
                                StartFailUI.UIData subUIData = data as StartFailUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(StartFailUI));
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
                    case Server.Property.instanceId:
                        break;
                    case Server.Property.gameTypes:
                        break;
                    case Server.Property.startState:
                        dirty = true;
                        break;
                    case Server.Property.type:
                        break;
                    case Server.Property.profile:
                        break;
                    case Server.Property.state:
                        break;
                    case Server.Property.users:
                        break;
                    case Server.Property.disconnectTime:
                        break;
                    case Server.Property.roomManager:
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