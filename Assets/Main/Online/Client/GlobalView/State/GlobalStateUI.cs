using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalStateUI : UIBehavior<GlobalStateUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Server>> server;

        #region sub

        public abstract class Sub : Data
        {

            public abstract Server.State.Type getType();

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
                        Debug.LogError("sub null");
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    public override int getStartAllocate()
    {
        return 1;
    }

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
                    Server.State state = server.state.v;
                    if (state != null)
                    {
                        switch (state.getType())
                        {
                            case Server.State.Type.Offline:
                                {
                                    Server.State.Offline offline = state as Server.State.Offline;
                                    // Find
                                    StateOfflineUI.UIData stateOfflineUIData = this.data.sub.newOrOld<StateOfflineUI.UIData>();
                                    {
                                        stateOfflineUIData.offline.v = new ReferenceData<Server.State.Offline>(offline);
                                    }
                                    this.data.sub.v = stateOfflineUIData;
                                }
                                break;
                            case Server.State.Type.Connect:
                                {
                                    Server.State.Connect connect = state as Server.State.Connect;
                                    // Find
                                    StateConnectUI.UIData stateConnectUIData = this.data.sub.newOrOld<StateConnectUI.UIData>();
                                    {
                                        stateConnectUIData.connect.v = new ReferenceData<Server.State.Connect>(connect);
                                    }
                                    this.data.sub.v = stateConnectUIData;
                                }
                                break;
                            case Server.State.Type.Disconnect:
                                {
                                    Server.State.Disconnect disconnect = state as Server.State.Disconnect;
                                    // Find
                                    StateDisconnectUI.UIData stateDisconnectUIData = this.data.sub.newOrOld<StateDisconnectUI.UIData>();
                                    {
                                        stateDisconnectUIData.disconnect.v = new ReferenceData<Server.State.Disconnect>(disconnect);
                                    }
                                    this.data.sub.v = stateDisconnectUIData;
                                }
                                break;
                            default:
                                Debug.LogError("unknown state type: " + state.getType() + "; " + this);
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
                    // Debug.LogError("server null: " + this);
                }
            }
            else
            {
                // Debug.LogError("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public StateOfflineUI stateOfflinePrefab;
    public StateConnectUI stateConnectPrefab;
    public StateDisconnectUI stateDisconnectPrefab;

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
                        case Server.State.Type.Offline:
                            {
                                StateOfflineUI.UIData stateOfflineUIData = sub as StateOfflineUI.UIData;
                                UIUtils.Instantiate(stateOfflineUIData, stateOfflinePrefab, this.transform);
                            }
                            break;
                        case Server.State.Type.Connect:
                            {
                                StateConnectUI.UIData stateConnectUIData = sub as StateConnectUI.UIData;
                                UIUtils.Instantiate(stateConnectUIData, stateConnectPrefab, this.transform);
                            }
                            break;
                        case Server.State.Type.Disconnect:
                            {
                                StateDisconnectUI.UIData stateDisconnectUIData = sub as StateDisconnectUI.UIData;
                                UIUtils.Instantiate(stateDisconnectUIData, stateDisconnectPrefab, this.transform);
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
                        case Server.State.Type.Offline:
                            {
                                StateOfflineUI.UIData stateOfflineUIData = sub as StateOfflineUI.UIData;
                                stateOfflineUIData.removeCallBackAndDestroy(typeof(StateOfflineUI));
                            }
                            break;
                        case Server.State.Type.Connect:
                            {
                                StateConnectUI.UIData stateConnectUIData = sub as StateConnectUI.UIData;
                                stateConnectUIData.removeCallBackAndDestroy(typeof(StateConnectUI));
                            }
                            break;
                        case Server.State.Type.Disconnect:
                            {
                                StateDisconnectUI.UIData stateDisconnectUIData = sub as StateDisconnectUI.UIData;
                                stateDisconnectUIData.removeCallBackAndDestroy(typeof(StateDisconnectUI));
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
                        break;
                    case Server.Property.profile:
                        break;
                    case Server.Property.state:
                        dirty = true;
                        break;
                    case Server.Property.users:
                        break;
                    case Server.Property.disconnectTime:
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