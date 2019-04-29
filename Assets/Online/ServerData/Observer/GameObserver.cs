using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable CS0618

[RequireComponent(typeof(DataIdentity))]
public class GameObserver : NetworkBehaviour
{

    #region Get information

    public ServerManager ServerManager;
    public ServerManager serverManager
    {
        get
        {
            if (ServerManager == null)
            {
                ServerManager = ServerManager.instance;
            }
            return ServerManager;
        }

        set
        {
            ServerManager = value;
        }
    }

    public NetworkIdentity Identity;
    public NetworkIdentity identity
    {
        get
        {
            if (Identity == null)
            {
                Identity = GetComponent<NetworkIdentity>();
            }
            return Identity;
        }

        set
        {
            Identity = value;
        }
    }

    public DataIdentity DataIdentity;
    public DataIdentity dataIdentity
    {
        get
        {
            if (DataIdentity == null)
            {
                DataIdentity = GetComponent<DataIdentity>();
            }
            return DataIdentity;
        }

        set
        {
            DataIdentity = value;
        }
    }

    #endregion

    #region Update

    public bool dirty = false;

    #endregion

    #region Utils

    protected void refreshChildObserver(Data data)
    {
        if (data == null)
        {
            Debug.LogError("data null" + data);
            return;
        }
        for (int i = 0; i < data.pts.Count; i++)
        {
            WrapProperty property = data.pts[i];
            if (property.getValueType().IsSubclassOf(typeof(Data)))
            {
                for (int j = 0; j < property.getValueCount(); j++)
                {
                    Data child = (Data)property.getValue(j);
                    if (child != null)
                    {
                        // Find GameObject
                        DataIdentity childDataIdentity = child.findCallBack<DataIdentity>();
                        if (childDataIdentity != null)
                        {
                            // Find Observer
                            GameObserver childObserver = childDataIdentity.GetComponent<GameObserver>();
                            if (childObserver != null)
                            {
                                if (childObserver.checkChange != null)
                                {
                                    childObserver.checkChange.onChangeParentObservers(identity.observers);
                                }
                                else
                                {
                                    Debug.LogError("childObserver checkChange null: " + this);
                                }
                            }
                            else
                            {
                                // Debug.Log ("childObserver null: " + childDataIdentity + "; " + data);
                            }
                        }
                        else
                        {
                            // Debug.Log ("childDataIdentity null: " + data);
                        }
                    }
                    else
                    {
                        // Debug.Log ("child null: " + data);
                    }
                }
            }
            else
            {
                // Debug.Log ("not wrapProperty data: " + data);
            }
        }
    }

    #endregion

    #region save change in observer

    public List<NetworkConnection> allConnections = new List<NetworkConnection>();

    public bool needRefresh = true;

    private List<NetworkConnection> getAllConnection()
    {
        if (this.needRefresh)
        {
            this.needRefresh = false;
            if (this.checkChange != null)
            {
                this.checkChange.refreshObserverConnections();
            }
            else
            {
                Debug.LogError("checkChange null: " + this);
            }
        }
        return this.allConnections;
    }

    #endregion

    #region Global

    public static ObserverController Controller = new ObserverController();

    private List<NetworkConnection> notAddImmediatelyConnections = new List<NetworkConnection>();

    /*void Awake ()
	{
		updateObserver ();
	}*/

    /*void Start ()
	{
		updateObserver ();
	}*/

    /*void FixedUpdate()
	{
		updateObserver ();
	}*/

    void Update()
    {
        updateObserver();
    }

    private void updateObserver()
    {
        if (dirty)
        {
            if (!isRebuildingObserver)
            {
                if (Controller.checkAllow(dataIdentity.GetNetworkChannel()))
                {
                    dirty = false;
                    List<NetworkConnection> allConnections = getAllConnection();
                    // Check have remove connection
                    bool haveRemoveConnection = false;
                    {
                        if (identity.observers != null)
                        {
                            foreach (NetworkConnection connection in identity.observers)
                            {
                                if (!allConnections.Contains(connection))
                                {
                                    haveRemoveConnection = true;
                                    break;
                                }
                            }
                        }
                    }
                    // Check have add connection
                    bool haveAddConnection = false;
                    {
                        notAddImmediatelyConnections.Clear();
                        if (identity.observers != null)
                        {
                            for (int i = allConnections.Count - 1; i >= 0; i--)
                            {
                                NetworkConnection connection = allConnections[i];
                                if (!identity.observers.Contains(connection))
                                {
                                    if (Controller.checkAllowAdd(dataIdentity, connection))
                                    {
                                        haveAddConnection = true;
                                    }
                                    else
                                    {
                                        notAddImmediatelyConnections.Add(connection);
                                    }
                                }
                                else
                                {
                                    // Debug.Log ("alread contain connection: " + connection + "; " + this);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("identity observers null: " + this);
                        }
                        // will check again to rebuild
                        if (notAddImmediatelyConnections.Count > 0)
                        {
                            dirty = true;
                        }
                    }
                    // rebuild observer
                    if (haveRemoveConnection || haveAddConnection)
                    {
                        // rebuild
                        if (identity != null)
                        {
                            isRebuildingObserver = true;
                            identity.RebuildObservers(false);
                        }
                        else
                        {
                            Debug.LogError("identity null: " + this);
                        }
                    }
                    else
                    {
                        // Debug.LogError ("why don't rebuild observer: " + this);
                    }
                }
                else
                {
                    Debug.Log("not allow");
                }
            }
            else
            {
                Debug.LogError("you are rebuilding observer: " + this);
            }
        }
    }

    #endregion

    #region Network Proximity

    // called when a new player enters the game
    public override bool OnCheckObserver(NetworkConnection newObserver)
    {
        // Debug.Log ("OnCheckObserver: "+newObserver);
        return false;
    }

    private bool isRebuildingObserver = false;

    // Only client user can see this class
    public override bool OnRebuildObservers(HashSet<NetworkConnection> observers, bool initial)
    {
        List<NetworkConnection> needAddConnections = getAllConnection();
        if (!initial)
        {
            // remove all not connect anymore in currentConnections
            observers.RemoveWhere(c => !needAddConnections.Contains(c));
            // add new connection
            {
                for (int i = needAddConnections.Count - 1; i >= 0; i--)
                {
                    NetworkConnection connection = needAddConnections[i];
                    if (!notAddImmediatelyConnections.Contains(connection))
                    {
                        observers.Add(connection);
                    }
                    else
                    {
                        Debug.LogError("not add immediately: " + connection + "; " + this);
                    }
                }
            }
            // set current connections
            isRebuildingObserver = false;
        }
        else
        {
            // Debug.LogError ("intial: " + this);
            if (Controller.checkAllow(dataIdentity.GetNetworkChannel()))
            {
                for (int i = needAddConnections.Count - 1; i >= 0; i--)
                {
                    NetworkConnection connection = needAddConnections[i];
                    if (Controller.checkAllowAdd(dataIdentity, connection))
                    {
                        observers.Add(connection);
                    }
                    else
                    {
                        // Debug.LogError ("intial cannot add: " + connection + "; " + this);
                    }
                }
            }
        }
        // Finish or not?
        if (observers.Count != needAddConnections.Count)
        {
            dirty = true;
        }
        // Refresh child observer
        {
            if (dataIdentity != null)
            {
                Data data = dataIdentity.getNetData().getServerData();
                if (data != null)
                {
                    this.refreshChildObserver(data);
                }
                else
                {
                    Debug.LogError("data null");
                }
            }
            else
            {
                Debug.LogError("dataIdentity null");
            }
        }
        // return
        return true;
    }

    #endregion

    public List<NetworkConnection> getParentObserver()
    {
        if (dataIdentity != null)
        {
            if (dataIdentity.getNetData() != null)
            {
                Data serverData = dataIdentity.getNetData().getServerData();
                if (serverData != null)
                {
                    Data parentData = serverData.getDataParent();
                    if (parentData != null)
                    {
                        DataIdentity parentDataIdentity = parentData.findCallBack<DataIdentity>();
                        if (parentDataIdentity != null)
                        {
                            NetworkIdentity parentNetworkIdentity = parentDataIdentity.GetComponent<NetworkIdentity>();
                            if (parentNetworkIdentity != null)
                            {
                                List<NetworkConnection> ret = new List<NetworkConnection>();
                                if (parentNetworkIdentity.observers != null)
                                {
                                    ret.AddRange(parentNetworkIdentity.observers);
                                }
                                return ret;
                            }
                            else
                            {
                                Debug.LogError("parentNetworkIdentity null: " + this);
                            }
                        }
                        else
                        {
                            // Debug.LogError ("parentDataIdentity null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("parentData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("serverData null: " + this);
                }
            }
            else
            {
                Debug.LogError("netData null: " + this);
            }
        }
        else
        {
            Debug.LogError("dataIdentity null: " + this);
        }
        return null;
    }

    #region CheckChange

    public CheckChange checkChange = null;// new FollowParentObserver(this);

    public void setCheckChangeData(Data data)
    {
        if (checkChange != null)
        {
            checkChange.setData(data);
        }
        else
        {
            Debug.LogError("checkChange null: " + data);
        }
    }

    public abstract class CheckChange : ValueChangeCallBack
    {

        public GameObserver gameObserver;

        public CheckChange(GameObserver gameObserver)
        {
            this.gameObserver = gameObserver;
        }

        #region Type

        public enum Type
        {
            ClientConnect,
            Friend,
            EveryOne,
            EveryOneNotBan,
            FollowParent,
            OnlyRoomPlayer,
            RoomUser,
            HumanConnection,
            HistoryChange,

            ChatMessage,
            ChatViewer,

            LimitRoomContainer
        }

        public abstract Type getType();

        #endregion

        #region callBack

        public abstract void onAddCallBack<T>(T data) where T : Data;

        public abstract void onRemoveCallBack<T>(T data, bool isHide) where T : Data;

        public abstract void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs);

        #endregion

        #region delegate

        public abstract void setData(Data data);

        public abstract void onChangeParentObservers(System.Collections.ObjectModel.ReadOnlyCollection<NetworkConnection> parentObserver);

        public abstract void refreshObserverConnections();

        #endregion

    }

    #endregion

}