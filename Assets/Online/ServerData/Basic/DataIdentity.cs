using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[RequireComponent(typeof(RefreshDataIdentity))]
[RequireComponent(typeof(GameObserver))]
[RequireComponent(typeof(NetworkIdentity))]
public abstract class DataIdentity : NetworkBehaviour, ValueChangeCallBack
{

    public int GetNetworkChannel()
    {
        // TODO Can hoan thien
        return 1;
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
    }

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

    #region NetData

    public abstract NetDataDelegate getNetData();

    #endregion

    #region Server

    public void setNewServerData(Data newServerData)
    {
        if (this.getNetData().getServerData() != null)
        {
            this.getNetData().getServerData().removeCallBack(this);
        }
        // Set new
        {
            this.getNetData().setServerData(newServerData);
            if (this.getNetData().getServerData() != null)
            {
                this.getNetData().getServerData().addCallBack(this);
            }
        }
        this.name = this.getNetData().getObjectName();
    }

    public abstract void refreshClientData();

    #endregion

    #region getDataSize

    private bool haveChangeDataSize = true;
    private int dataSize = 1;

    public int getDataSize()
    {
        if (!haveChangeDataSize)
        {
            return dataSize;
        }
        else
        {
            haveChangeDataSize = false;
            dataSize = refreshDataSize() + 4 * this.searchInfor.Count;
            return dataSize;
        }
    }

    public abstract int refreshDataSize();

    #endregion

    #region Client maybeAddData

    public virtual void maybeAddNewDataToClient()
    {
        if (this.getNetData().getClientData() == null)
        {
            if (searchInfor.Count != 0)
            {
                if (serverManager != null)
                {
                    if (serverManager.data != null)
                    {
                        Server server = serverManager.data.server.v.data;
                        if (server != null)
                        {
                            if (server.type.v == Server.Type.Client)
                            {
                                // Find wrapProperty
                                List<Data.SI> search = DataIdentity.deserialize(searchInfor);
                                WrapProperty searchProperty = server.findPropertyForData(search);
                                if (searchProperty != null)
                                {
                                    notFindNeedWait = false;
                                    this.beforeAddNewDataToClient();
                                    // Make new
                                    {
                                        this.getNetData().initClientData();
                                        {
                                            // Add to parent
                                            this.addClientTransformToParent(searchProperty.p);
                                            // ClientMap
                                            DataIdentity.addToClientMap(this.getNetData().getClientData(), this);
                                            // Id
                                            this.getNetData().getClientData().uid = search[0].i;
                                            // SyncList
                                            this.addSyncListCallBack();
                                            // Set Property
                                            refreshClientData();
                                        }
                                        searchProperty.addValue(this.getNetData().getClientData(), true);
                                    }
                                    // set name
                                    this.name = this.getNetData().getObjectName();
                                    // after add
                                    this.afterAddNewDataToClient();
                                }
                                else
                                {
                                    // Debug.LogError ("tham hoa, sao ko thay duel nhi");
                                    notFindNeedWait = true;
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("server null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("serverManager null");
                }
            }
            else
            {
                Debug.LogError("searchInfo count = 0: " + this);
            }
        }
    }

    public virtual void addSyncListCallBack()
    {
        this.searchInfor.Callback += OnSearchInfoChange;
    }

    public virtual void beforeAddNewDataToClient()
    {

    }

    public virtual void afterAddNewDataToClient()
    {
        // Debug.LogError ("afterAddNewDataToClient");
    }

    public virtual bool checkCanAddNewDataToClientWhenStart()
    {
        return true;
    }

    public override void OnStartClient()
    {
        if (serverManager != null)
        {
            if (checkCanAddNewDataToClientWhenStart())
            {
                maybeAddNewDataToClient();
            }
            else
            {
                Debug.LogError("OnStartClient: cannot add: " + this);
            }
        }
        else
        {
            // Debug.Log ("Network is not client");
        }
    }

    private bool NotFindNeedWait = false;
    protected bool notFindNeedWait
    {
        get
        {
            return NotFindNeedWait;
        }

        set
        {
            NotFindNeedWait = value;
            if (this)
            {
                if (NotFindNeedWait || NotFindTransformParent)
                {
                    this.enabled = true;
                }
                else
                {
                    this.enabled = false;
                }
            }
        }
    }

    private bool NotFindTransformParent = false;
    private bool notFindTransformParent
    {
        get
        {
            return NotFindTransformParent;
        }

        set
        {
            NotFindTransformParent = value;
            if (this)
            {
                if (NotFindNeedWait || NotFindTransformParent)
                {
                    this.enabled = true;
                }
                else
                {
                    this.enabled = false;
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (notFindNeedWait)
        {
            // Debug.Log ("notFindNeedWait: " + this);
            maybeAddNewDataToClient();
        }
        // addTransformToParent
        if (notFindTransformParent)
        {
            this.addTransformToParent();
        }
        this.enabled = false;
    }

    void OnDestroy()
    {
        if (isClient)
        {
            if (serverManager != null)
            {
                if (serverManager.data != null)
                {
                    Server server = serverManager.data.server.v.data;
                    if (server != null)
                    {
                        if (server.type.v == Server.Type.Client)
                        {
                            Data clientData = getNetData().getClientData();
                            if (clientData != null)
                            {
                                WrapProperty property = clientData.p;
                                if (property != null)
                                {
                                    switch (property.getType())
                                    {
                                        case WrapProperty.Type.List:
                                            {
                                                // Debug.Log ("remove listProperty: " + property);
                                                property.removeValue(clientData);
                                            }
                                            break;
                                        case WrapProperty.Type.Value:
                                            {
                                                // Debug.Log ("not save to remove ValueProperty: " + property);
                                            }
                                            break;
                                        default:
                                            // Debug.LogError ("unknown type: " + property.getType ());
                                            break;
                                    }
                                }
                                else
                                {
                                    // Debug.Log ("property null: " + clientData);
                                }
                                // ClientMap
                                DataIdentity.removeFromClientMap(clientData);
                            }
                            else
                            {
                                // Debug.LogError ("clientData null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("server null");
                    }
                }
                else
                {
                    // Debug.LogError ("data null");
                }
            }
            else
            {
                Debug.LogError("serverManager null");
            }
        }
        else
        {
            // Debug.LogError ("not client");
        }
    }

    #endregion

    #region SyncVar

    #region searchInfor

    public SyncListUInt searchInfor = new SyncListUInt();

    private void OnSearchInfoChange(SyncListUInt.Operation op, int index)
    {
        Debug.LogError("why change searchInfo: " + searchInfor.Count + "; " + this);
        // Remove old
        {
            Data oldClientData = this.getNetData().getClientData();
            if (oldClientData != null)
            {
                Debug.LogError("oldClientData not null: " + this);
                WrapProperty wrapProperty = oldClientData.p;
                if (wrapProperty != null)
                {
                    wrapProperty.removeValue(oldClientData);
                }
                else
                {
                    Debug.LogError("wrapProperty null: " + this);
                }
            }
        }
        notFindNeedWait = true;
    }

    public void Awake()
    {
        this.searchInfor.Callback += OnSearchInfoChange;
    }

    #endregion

    #region refresh

    [SyncVar(hook = "onChangeRefresh")]
    public bool refresh = true;

    public void onChangeRefresh(bool newRefresh)
    {
        this.refresh = newRefresh;
        Debug.LogError("Why onChangeRefresh: " + newRefresh + ", " + this);
    }

    #endregion

    #endregion

    #region Utils

    protected void addTransformToParent()
    {
        Data data = this.getNetData().getServerData();
        if (data != null)
        {
            if (data.getDataParent() != null)
            {
                DataIdentity identity = data.getDataParent().findCallBack<DataIdentity>();
                if (identity != null)
                {
                    notFindTransformParent = false;
                    this.transform.SetParent(identity.transform, false);
                }
                else
                {
                    if (!(data is Server))
                    {
                        // Debug.LogError ("not find transform for data: " + data);
                        notFindTransformParent = true;
                    }
                    // Debug.LogError ("Why cannot find dataIdentity parent to add: " + this + ", " + data.getDataParent ());
                    // ServerManager serverManager = ServerManager.instance;
                    if (serverManager != null)
                    {
                        this.transform.SetParent(serverManager.gameObject.transform, false);
                    }
                    else
                    {
                        Debug.LogError("serverManager null: " + this);
                    }
                }
            }
            else
            {
                Debug.LogError("cannot find parent: " + this);
                // ServerManager serverManager = ServerManager.instance;
                if (serverManager != null)
                {
                    ServerManager.UIData serverManagerUIData = serverManager.data;
                    if (serverManagerUIData != null)
                    {
                        Server server = serverManagerUIData.server.v.data;
                        if (server != null)
                        {
                            CreateDataIdentityUpdate createDataIdentityCallBack = server.findCallBack<CreateDataIdentityUpdate>();
                            if (createDataIdentityCallBack != null)
                            {
                                createDataIdentityCallBack.removeDataIdentity(data);
                            }
                            else
                            {
                                Debug.LogError("createDataIdentityCallBack null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("server null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("serverManager data null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("serverManager null: " + this);
                }
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    private void setParentTransformServerManager()
    {
        if (serverManager != null)
        {
            this.transform.SetParent(serverManager.transform, true);
        }
        else
        {
            Debug.LogError("clientManager null: " + this);
        }
    }

    protected void addClientTransformToParent(Data dataParent)
    {
        // Debug.Log ("addClientTransformToParent: " + dataParent);
        if (dataParent != null)
        {
            DataIdentity parentIdentity = null;
            if (DataIdentity.clientMap.TryGetValue(dataParent, out parentIdentity))
            {
                if (parentIdentity != null)
                {
                    this.transform.SetParent(parentIdentity.transform, true);
                }
                else
                {
                    Debug.LogError("why dataIdentity already destroyed: " + this);
                    this.setParentTransformServerManager();
                }
            }
            else
            {
                this.setParentTransformServerManager();
            }
        }
        else
        {
            this.setParentTransformServerManager();
        }
    }

    #endregion

    #region ClientMap

    public static Dictionary<Data, DataIdentity> clientMap = new Dictionary<Data, DataIdentity>();

    public static void addToClientMap(Data data, DataIdentity identity)
    {
        if (data != null)
        {
            clientMap[data] = identity;
        }
        else
        {
            Debug.LogError("why data null");
        }
    }

    public static void removeFromClientMap(Data data)
    {
        clientMap.Remove(data);
    }

    #endregion

    #region implement callBacks

    public abstract void onAddCallBack<T>(T data) where T : Data;

    public abstract void onRemoveCallBack<T>(T data, bool isHide) where T : Data;

    public abstract void onUpdateSync<T>(WrapProperty wrapProperty, System.Collections.Generic.List<Sync<T>> syncs);

    #endregion

    #region UInt64

    [System.Serializable]
    public struct MyUInt64
    {
        public ulong value;

        public MyUInt64(ulong newValue)
        {
            this.value = newValue;
        }

        public override string ToString()
        {
            return "" + value;
        }

        #region ConvertDelegate

        public class Cast<K> : ConvertDelegate<MyUInt64, K>
        {
            public override MyUInt64 convert(K value)
            {
                if (value is ulong)
                {
                    return new MyUInt64((ulong)(object)value);
                }
                else
                {
                    Debug.LogError("convert ulong error");
                    return new MyUInt64();
                }
            }
        }

        #endregion

        #region ULongConvert

        public class ULongConvert : ConvertDelegate<ulong, MyUInt64>
        {
            public override ulong convert(MyUInt64 value)
            {
                return value.value;
            }
        }

        public static ULongConvert uLongConvert = new ULongConvert();

        #endregion

        #region MyUInt64Convert

        public class MyUInt64Convert : ConvertDelegate<MyUInt64, ulong>
        {
            public override MyUInt64 convert(ulong value)
            {
                MyUInt64 myUInt64 = new MyUInt64();
                {
                    myUInt64.value = value;
                }
                return myUInt64;
            }
        }

        public static MyUInt64Convert myUInt64Convert = new MyUInt64Convert();

        #endregion
    }

    public class SyncListUInt64 : SyncListStruct<MyUInt64>
    {

    }

    #endregion

    #region Int64

    [System.Serializable]
    public struct MyInt64
    {
        public long value;

        public MyInt64(long newValue)
        {
            this.value = newValue;
        }

        public override string ToString()
        {
            return "" + value;
        }

        #region ConvertDelegate

        public class Cast<K> : ConvertDelegate<MyInt64, K>
        {
            public override MyInt64 convert(K value)
            {
                if (value is long)
                {
                    return new MyInt64((long)(object)value);
                }
                else
                {
                    Debug.LogError("convert long error");
                    return new MyInt64();
                }
            }
        }

        #endregion

        #region ULongConvert

        public class LongConvert : ConvertDelegate<long, MyInt64>
        {
            public override long convert(MyInt64 value)
            {
                return value.value;
            }
        }

        public static LongConvert longConvert = new LongConvert();

        #endregion

        #region MyInt64Convert

        public class MyInt64Convert : ConvertDelegate<MyInt64, long>
        {
            public override MyInt64 convert(long value)
            {
                MyInt64 myInt64 = new MyInt64();
                {
                    myInt64.value = value;
                }
                return myInt64;
            }
        }

        public static MyInt64Convert myInt64Convert = new MyInt64Convert();

        #endregion
    }

    public class SyncListInt64 : SyncListStruct<MyInt64>
    {

    }

    #endregion

    /////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// byte ////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////// 

    #region Byte

    [System.Serializable]
    public struct MyByte
    {
        public byte value;

        public MyByte(byte newValue)
        {
            this.value = newValue;
        }

        public override string ToString()
        {
            return "" + value;
        }

        #region ConvertDelegate

        public class Cast<K> : ConvertDelegate<MyByte, K>
        {
            public override MyByte convert(K value)
            {
                if (value is byte)
                {
                    return new MyByte((byte)(object)value);
                }
                else
                {
                    Debug.LogError("convert ulong error");
                    return new MyByte();
                }
            }
        }

        #endregion

        #region byteConvert

        public class ByteConvert : ConvertDelegate<byte, MyByte>
        {
            public override byte convert(MyByte value)
            {
                return value.value;
            }
        }

        public static ByteConvert byteConvert = new ByteConvert();

        #endregion

        #region MyByteConvert

        public class MyByteConvert : ConvertDelegate<MyByte, byte>
        {
            public override MyByte convert(byte value)
            {
                MyByte myByte = new MyByte();
                {
                    myByte.value = value;
                }
                return myByte;
            }
        }

        public static MyByteConvert myByteConvert = new MyByteConvert();

        #endregion

    }

    public class SyncListByte : SyncListStruct<MyByte>
    {
        public byte[] getByteArray()
        {
            byte[] ret = new byte[this.Count];
            {
                for (int i = 0; i < this.Count; i++)
                {
                    ret[i] = this[i].value;
                }
            }
            return ret;
        }
    }

    #endregion

    /////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// sbyte ////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////

    #region SByte

    [System.Serializable]
    public struct MySByte
    {
        public sbyte value;

        public MySByte(sbyte newValue)
        {
            this.value = newValue;
        }

        public override string ToString()
        {
            return "" + value;
        }

        #region ConvertDelegate

        public class Cast<K> : ConvertDelegate<MySByte, K>
        {
            public override MySByte convert(K value)
            {
                if (value is sbyte)
                {
                    return new MySByte((sbyte)(object)value);
                }
                else
                {
                    Debug.LogError("convert ulong error");
                    return new MySByte();
                }
            }
        }

        #endregion

        #region byteConvert

        public class SByteConvert : ConvertDelegate<sbyte, MySByte>
        {
            public override sbyte convert(MySByte value)
            {
                return value.value;
            }
        }

        public static SByteConvert sbyteConvert = new SByteConvert();

        #endregion

        #region MySByteConvert

        public class MySByteConvert : ConvertDelegate<MySByte, sbyte>
        {

            public override MySByte convert(sbyte value)
            {
                MySByte mySByte = new MySByte();
                {
                    mySByte.value = value;
                }
                return mySByte;
            }
        }

        public static MySByteConvert mySByteConvert = new MySByteConvert();

        #endregion

    }

    public class SyncListSByte : SyncListStruct<MySByte>
    {

    }

    #endregion

    /////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// ushort ////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////

    #region ushort

    [System.Serializable]
    public struct MyUShort
    {
        public ushort value;

        public MyUShort(ushort newValue)
        {
            this.value = newValue;
        }

        public override string ToString()
        {
            return "" + value;
        }

        #region ConvertDelegate

        public class Cast<K> : ConvertDelegate<MyUShort, K>
        {
            public override MyUShort convert(K value)
            {
                if (value is ushort)
                {
                    return new MyUShort((ushort)(object)value);
                }
                else
                {
                    Debug.LogError("convert ushort error");
                    return new MyUShort();
                }
            }
        }

        #endregion

        #region byteConvert

        public class UShortConvert : ConvertDelegate<ushort, MyUShort>
        {
            public override ushort convert(MyUShort value)
            {
                return value.value;
            }
        }

        public static UShortConvert ushortConvert = new UShortConvert();

        #endregion

        #region MySByteConvert

        public class MyUShortConvert : ConvertDelegate<MyUShort, ushort>
        {

            public override MyUShort convert(ushort value)
            {
                MyUShort myUShort = new MyUShort();
                {
                    myUShort.value = value;
                }
                return myUShort;
            }
        }

        public static MyUShortConvert myUShortConvert = new MyUShortConvert();

        #endregion

    }

    public class SyncListUShort : SyncListStruct<MyUShort>
    {

    }

    #endregion

    /////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// getDataSize ////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////

    #region getDataSize

    public static int GetDataSize(NetworkInstanceId value)
    {
        return 4;
    }

    public static int GetDataSize(uint value)
    {
        return 4;
    }

    public static int GetDataSize(ulong value)
    {
        return 8;
    }

    public static int GetDataSize(long value)
    {
        return 8;
    }

    /*public static int GetDataSize(NetworkInstanceId value)
	{
		return 4;
	}

	public static int GetDataSize(NetworkSceneId value)
	{
		return 4;
	}*/

    public static int GetDataSize(char value)
    {
        return 1;
    }

    public static int GetDataSize(byte value)
    {
        return 1;
    }

    public static int GetDataSize(sbyte value)
    {
        return 1;
    }

    public static int GetDataSize(short value)
    {
        return 2;
    }

    public static int GetDataSize(ushort value)
    {
        return 2;
    }

    public static int GetDataSize(float value)
    {
        return 4;
    }

    public static int GetDataSize(double value)
    {
        return 8;
    }

    public static int GetDataSize(string value)
    {
        if (value == null)
        {
            return 2;
        }
        else
        {
            return 2 + value.Length;
        }
    }

    public static int GetDataSize(bool value)
    {
        return 1;
    }

    public static int GetDataSize(Vector2 value)
    {
        return 2 * 4;
    }

    public static int GetDataSize(Vector3 value)
    {
        return 3 * 4;
    }

    public static int GetDataSize(Vector4 value)
    {
        return 4 * 4;
    }

    public static int GetDataSize(Color value)
    {
        return 4 * 4;
    }

    public static int GetDataSize(Color32 value)
    {
        return 4;
    }

    public static int GetDataSize(Quaternion value)
    {
        return 4 * 4;
    }

    public static int GetDataSize(Rect value)
    {
        return 4 * 4;
    }

    public static int GetDataSize(Plane value)
    {
        return 3 * 4 + 4;
    }

    public static int GetDataSize(Ray value)
    {
        return 3 * 4 + 3 * 4;
    }

    public static int GetDataSize(Matrix4x4 value)
    {
        return 16 * 4;
    }

    public static int GetDataSize(System.Guid value)
    {
        return 16;
    }

    public static int GetDataSize(NetworkIdentity value)
    {
        if ((UnityEngine.Object)value == (UnityEngine.Object)null)
        {
            return GetDataSize(0U);
        }
        else
        {
            return GetDataSize(value.netId);
        }
    }

    public static int GetDataSize(Transform value)
    {
        if ((UnityEngine.Object)value == (UnityEngine.Object)null || (UnityEngine.Object)value.gameObject == (UnityEngine.Object)null)
        {
            return GetDataSize(0U);
        }
        else
        {
            NetworkIdentity component = value.gameObject.GetComponent<NetworkIdentity>();
            if ((UnityEngine.Object)component != (UnityEngine.Object)null)
            {
                return GetDataSize(component.netId);
            }
            else
            {
                // if (LogFilter.logWarn)
                // 	Debug.LogWarning((object) ("NetworkWriter " + (object) value + " has no NetworkIdentity"));
                return GetDataSize(0U);
            }
        }
    }

    public static int GetDataSize(SyncListByte items)
    {
        return 2 + items.Count * 1;
    }

    public static int GetDataSize(SyncListSByte items)
    {
        return 2 + items.Count * 1;
    }

    public static int GetDataSize(SyncListUShort items)
    {
        return 2 + items.Count * 2;
    }

    public static int GetDataSize(SyncListBool items)
    {
        return 2 + items.Count * 1;
    }

    public static int GetDataSize(SyncListFloat items)
    {
        return 2 + items.Count * 4;
    }

    public static int GetDataSize(SyncListInt items)
    {
        return 2 + items.Count * 4;
    }

    public static int GetDataSize(SyncListUInt items)
    {
        return 2 + items.Count * 4;
    }

    public static int GetDataSize(SyncListString items)
    {
        int ret = 0;
        {
            ret += GetDataSize((ushort)items.Count);
            foreach (string str in (SyncList<string>)items)
            {
                ret += str.Length;
            }
        }
        return ret;
    }

    public static int GetDataSize(SyncListUInt64 items)
    {
        return 2 + items.Count * 8;
    }

    public static int GetDataSize(SyncListInt64 items)
    {
        return 2 + items.Count * 8;
    }

    public static int GetDataSize(Shogi.Common.SyncListBitBoard items)
    {
        return 2 + items.Count * (8 + 8);
    }

    public static int GetDataSize(System.Enum myEnum)
    {
        return 4;
    }

    public static int GetDataSize(Janggi.Common.SyncListPos items)
    {
        return 2 + items.Count * 2;
    }

    #endregion

    #region SI

    public void serialize(SyncListUInt searchInfor, List<Data.SI> informs)
    {
        if (Debug.isDebugBuild)
        {
            Debug.unityLogger.logEnabled = false;
        }
        // LogFilter.currentLogLevel = LogFilter.Fatal;
        searchInfor.Clear();
        for (int i = 0; i < informs.Count; i++)
        {
            Data.SI si = informs[i];
            // Add
            {
                searchInfor.Add(si.i);
                searchInfor.Add(si.n);
            }
        }
        // LogFilter.currentLogLevel = LogFilter.Info;
        if (Debug.isDebugBuild)
        {
            Debug.unityLogger.logEnabled = true;
        }
    }

    public static List<Data.SI> deserialize(IList<uint> searchInfor)
    {
        List<Data.SI> ret = new List<Data.SI>();
        {
            for (int i = 0; i < searchInfor.Count; i = i + 2)
            {
                if (i + 1 < searchInfor.Count)
                {
                    Data.SI searchInform = new Data.SI();
                    {
                        searchInform.i = searchInfor[i];
                        searchInform.n = (byte)searchInfor[i + 1];
                    }
                    ret.Add(searchInform);
                }
                else
                {
                    Debug.LogError("jsInform count error");
                }
            }
        }
        return ret;
    }

    #endregion

}