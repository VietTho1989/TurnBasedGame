using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

[Serializable]
public abstract class Data : AddCallBackInterface
{

    public override string ToString()
    {
        return GetType().FullName + "-" + uid;
    }

    #region Id

    public const uint UNKNOWN_ID = System.UInt32.MaxValue;

    public uint uid = 0;

    #endregion

    #region Parent

    /// <summary>
    /// parent
    /// </summary>
    public WrapProperty p;

    public Data getDataParent()
    {
        if (p == null)
        {
            return null;
        }
        else
        {
            return p.p;
        }
    }

    public byte propertyName
    {
        get
        {
            if (p == null)
            {
                return 0;
            }
            else
            {
                return p.n;
            }
        }
    }

    public bool isCorrectType<T>()
    {
        if (this.GetType() == typeof(T) || typeof(T).IsAssignableFrom(this.GetType()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public T findDataInParent<T>()
    {
        // isYou?
        if (this.isCorrectType<T>())
        {
            // Debug.Log ("this is you");
            return (T)(object)this;
        }
        // Check parent
        if (this.p != null)
        {
            if (this.p.p != null)
            {
                T ret = this.p.p.findDataInParent<T>();
                return ret;
            }
            else
            {
                return default(T);
            }
        }
        else
        {
            return default(T);
        }
    }

    public void getParentList(List<Data> parentList)
    {
        if (this.p != null)
        {
            if (this.p.p != null)
            {
                parentList.Add(this.p.p);
                this.p.p.getParentList(parentList);
                return;
            }
            else
            {
                Debug.LogError("parent wrapProperty parent null: " + this);
            }
        }
        else
        {
            Debug.LogError("parent wrapProperty null: " + this);
            return;
        }
    }

    #endregion

    /// <summary>
    /// List of wrapproperty data have
    /// </summary>
    public List<WrapProperty> pts = new List<WrapProperty>();

    public string getListWrapPropertyString()
    {
        string temp = "";
        {
            for (int i = 0; i < pts.Count; i++)
            {
                WrapProperty wrapProperty = pts[i];
                temp += "{" + wrapProperty + "}";
            }
        }
        return temp;
    }

    public void addCallBackAllChildren(ValueChangeCallBack valueChangeCallBack)
    {
        for (int i = 0; i < this.pts.Count; i++)
        {
            WrapProperty property = this.pts[i];
            if (Generic.IsAddCallBackInterface(property.getValueType()))
            {
                property.allAddCallBack(valueChangeCallBack);
            }
        }
    }

    public void removeCallBackAllChildren(ValueChangeCallBack valueChangeCallBack)
    {
        for (int i = 0; i < this.pts.Count; i++)
        {
            WrapProperty property = this.pts[i];
            if (Generic.IsAddCallBackInterface(property.getValueType()))
            {
                property.allRemoveCallBack(valueChangeCallBack);
            }
        }
    }

    /*******************************************************************************************
	 * ****************** CallBack when value change **************************
	 * *****************************************************************************************/

    [System.NonSerialized]
    public List<ValueChangeCallBack> callBacks = new List<ValueChangeCallBack>();

    public void addCallBack(ValueChangeCallBack callBack)
    {
        if (callBack == null)
        {
            Debug.LogError("callBack null: " + this);
            return;
        }
        // Add
        if (!callBacks.Contains(callBack))
        {
            callBacks.Add(callBack);
            callBack.onAddCallBack(this);
        }
        else
        {
            // TODO Tam bo Debug.LogError ("Cannot add this callBack: " + this + ", " + callBack);
        }
    }

    public void removeCallBack(ValueChangeCallBack callBack, bool isHide = false)
    {
        if (callBacks.Remove(callBack))
        {
            // Debug.Log ("Remove callback success: " + callBack + ", " + this);
            callBack.onRemoveCallBack(this, isHide);
        }
        else
        {
            // Debug.LogError ("strange, cannot find callBack: " + this + ", " + callBack);
        }
    }

    #region Remove and Destroy

    public static bool IsSubclassOfRawGeneric(System.Type generic, System.Type toCheck)
    {
        while (toCheck != null && toCheck != typeof(object))
        {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur)
            {
                return true;
            }
            toCheck = toCheck.BaseType;
        }
        return false;
    }

    public int removeCallBackAndDestroy(System.Type type)
    {
        int ret = 0;
        // Search
        for (int i = callBacks.Count - 1; i >= 0; i--)
        {
            ValueChangeCallBack callBack = callBacks[i];
            // Check correct type
            bool correctType = false;
            {
                System.Type callBackType = callBack.GetType();
                if (callBackType == type || callBackType.IsSubclassOf(type))
                {
                    correctType = true;
                }
                if (!correctType)
                {
                    if (Data.IsSubclassOfRawGeneric(type, callBackType))
                    {
                        // Debug.LogError ("removeCallBackAndDestroy: correctType: " + type + "; " + callBackType);
                        correctType = true;
                    }
                }
            }
            // Process
            if (correctType)
            {
                this.removeCallBack(callBack);
                if (callBack is TrashMan.DespawnInterface)
                {
                    TrashMan.DespawnInterface despawnInterface = callBack as TrashMan.DespawnInterface;
                    TrashMan.normalDespawn(despawnInterface);
                }
                else if (callBack is Component)
                {
                    Component component = callBack as Component;
                    if (component != null)
                    {
                        GameObject.Destroy(component.gameObject);
                    }
                    else
                    {
                        Debug.LogError("why component null, cannot destroy: " + this);
                    }
                }
                else
                {
                    Debug.LogError("Why isn't Component: " + this + "; " + type);
                }
                ret++;
            }
        }
        // Return
        return ret;
    }

    public int removeCallBackAndRemoveComponent(System.Type type)
    {
        int ret = 0;
        // Search
        for (int i = callBacks.Count - 1; i >= 0; i--)
        {
            ValueChangeCallBack callBack = callBacks[i];
            // Check correct type
            bool correctType = false;
            {
                System.Type callBackType = callBack.GetType();
                if (callBackType == type || callBackType.IsSubclassOf(type))
                {
                    correctType = true;
                }
                if (!correctType)
                {
                    if (Data.IsSubclassOfRawGeneric(type, callBackType))
                    {
                        // Debug.LogError ("removeCallBackAndDestroy: correctType: " + type + "; " + callBackType);
                        correctType = true;
                    }
                }
            }
            // Process
            if (correctType)
            {
                this.removeCallBack(callBack);
                if (callBack is Component)
                {
                    Component component = callBack as Component;
                    GameObject.Destroy(component);
                }
                else
                {
                    Debug.LogError("Why isn't Component: " + this + "; " + type);
                }
                ret++;
            }
        }
        // Return
        return ret;
    }

    #endregion

    public T findCallBack<T>()
    {
        for (int i = callBacks.Count - 1; i >= 0; i--)
        {
            ValueChangeCallBack callBack = callBacks[i];
            if (callBack.GetType() == typeof(T) || callBack.GetType().IsSubclassOf(typeof(T))
                || typeof(T).IsAssignableFrom(callBack.GetType()))
            {
                T ret = (T)(object)callBack;
                return ret;
            }
        }
        return default(T);
    }

    public T findCallBack<T>(System.Type type)
    {
        for (int i = callBacks.Count - 1; i >= 0; i--)
        {
            ValueChangeCallBack callBack = callBacks[i];
            if (callBack.GetType() == type || callBack.GetType().IsSubclassOf(type))
            {
                T ret = (T)(object)callBack;
                return ret;
            }
        }
        return default(T);
    }

    #region Transform

    public GameObject uiGameObject = null;

    public static Transform FindTransform(Data data)
    {
        Transform ret = null;
        {
            if (data != null)
            {
                if (data.uiGameObject != null)
                {
                    ret = data.uiGameObject.transform;
                }
                else
                {
                    Debug.LogError("uiGameObject null");
                }
                /*for (int i = data.callBacks.Count - 1; i >= 0; i--)
                {
                    ValueChangeCallBack callBack = data.callBacks[i];
                    if (typeof(HaveTransformInterface).IsAssignableFrom(callBack.GetType()))
                    {
                        HaveTransformInterface haveTransformInterface = (HaveTransformInterface)callBack;
                        // TODO Test
                        {
                            if(data is Chess.NoneRule.ChoosePieceAdapter.UIData)
                            {
                                Debug.LogError("test: " + data + ", " + haveTransformInterface);
                            }
                        }
                        if (haveTransformInterface.getData() == data)
                        {
                            ret = haveTransformInterface.getTransform();
                            break;
                        }
                    }
                }*/
            }
            else
            {
                Debug.LogError("data null");
            }
        }
        if (ret == null)
        {
            Debug.LogError("find transform null: " + data);
        }
        return ret;
    }

    #endregion

    public HaveTransformData haveTransformData = null;

    public HaveTransformData findTransformData()
    {
        HaveTransformData ret = null;
        {
            ret = this.haveTransformData;
            /*for (int i = this.callBacks.Count - 1; i >= 0; i--)
            {
                ValueChangeCallBack callBack = this.callBacks[i];
                if (typeof(HaveTransformData).IsAssignableFrom(callBack.GetType()))
                {
                    HaveTransformData haveTransformData = (HaveTransformData)callBack;
                    if (haveTransformData.getDataHaveTransformData() == this)
                    {
                        ret = haveTransformData;
                        break;
                    }
                }
            }*/
        }
        return ret;
    }

    #region get information

    #region serch information

    /// <summary>
    /// Search inform.
    /// </summary>
    public struct SI
    {
        public uint i;
        public byte n;

        public SI(uint dataId, byte property)
        {
            this.i = dataId;
            this.n = property;
        }

        public override string ToString()
        {
            return "(" + i + ", " + n + ")";
        }

        public static bool isParent(List<SI> checkParent, List<SI> checkChildren)
        {
            if (checkParent.Count > checkChildren.Count)
            {
                // Debug.Log ("parent have more search than children");
                return false;
            }
            for (int i = checkParent.Count - 1; i >= 0; i--)
            {
                if (checkParent[i].i != checkChildren[i].i || checkParent[i].n != checkChildren[i].n)
                {
                    return false;
                }
            }
            return true;
        }

        public static string serialize(List<Data.SI> informs)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            {
                for (int i = 0; i < informs.Count; i++)
                {
                    Data.SI inform = informs[i];
                    builder.AppendFormat("{0},{1};", inform.i, inform.n);
                }
            }
            return builder.ToString();
        }

        public static List<Data.SI> deserialize(string jsInform)
        {
            List<Data.SI> ret = new List<SI>();
            {
                string[] strInforms = jsInform.Split(';');
                for (int informIdex = 0; informIdex < strInforms.Length; informIdex++)
                {
                    string strInform = strInforms[informIdex];
                    string[] strData = strInform.Split(',');
                    if (strData.Length == 2)
                    {
                        Data.SI searchInform = new Data.SI();
                        {
                            System.UInt32.TryParse(strData[0], out searchInform.i);
                            System.Byte.TryParse(strData[1], out searchInform.n);
                        }
                        ret.Add(searchInform);
                    }
                    else
                    {
                        // Debug.LogError ("Why data search inform not correct: " + strData);
                    }
                }
            }
            return ret;
        }

    }

    #region SIConvert

    public class SIConvert<T> : ConvertDelegate<string, T>
    {
        public override string convert(T value)
        {
            if (value is List<Data.SI>)
            {
                return StringSerializationAPI.Serialize(typeof(List<Data.SI>), (List<Data.SI>)(object)value);
            }
            else
            {
                Debug.LogError("convert error: " + value);
                return "";
            }
        }
    }

    #endregion

    public List<uint> makeUIntSearchInforms()
    {
        List<uint> ret = new List<uint>();
        {
            List<Data.SI> informs = this.makeSearchInforms();
            for (int i = 0; i < informs.Count; i++)
            {
                Data.SI si = informs[i];
                // Add
                {
                    ret.Add(si.i);
                    ret.Add(si.n);
                }
            }
        }
        return ret;
    }

    public List<Data.SI> makeSearchInforms()
    {
        return this.makeSearchInforms(null);
    }

    public List<Data.SI> makeSearchInforms(Data endParentData)
    {
        List<Data.SI> ret = new List<Data.SI>();
        ret.Add(new Data.SI(this.uid, this.propertyName));
        // Check parent
        if (p != null)
        {
            if (this != endParentData)
            {
                List<Data.SI> parentIdList = p.p.makeSearchInforms(endParentData);
                for (int i = 0; i < parentIdList.Count; i++)
                {
                    ret.Add(parentIdList[i]);
                }
            }
        }
        else
        {
            // Debug.Log ("You don't have parent");
        }
        return ret;
    }

    #endregion

    /**
	 * the last searchInform contain property name and idList of data
	 * */
    public WrapProperty findPropertyForData(List<Data.SI> idList)
    {
        if (idList.Count > 0)
        {
            // find parent data
            Data parentData = null;
            {
                List<Data.SI> parentIdList = new List<Data.SI>();
                {
                    for (int i = 1; i < idList.Count; i++)
                    {
                        parentIdList.Add(idList[i]);
                    }
                }
                parentData = this.findData(parentIdList);
            }
            // find property
            if (parentData != null)
            {
                Data.SI dataInfor = idList[0];
                return parentData.findProperty(dataInfor.n);
            }
            else
            {
                // Debug.Log ("cannot find parent data: " + this + ", " + Utils.getListString (idList) + "; " + Utils.getListString (this.makeSearchInforms ()));
            }
        }
        else
        {
            // Debug.LogError ("why idList count = 0;");
        }
        return null;
    }

    #region Find Data

    public Data findData(List<Data.SI> idList)
    {
        // Debug.LogError ("findData: " + this + ", " + this.propertyName + ", " + this.uid);
        if (idList.Count >= 1)
        {
            Data.SI searchInfo = idList[idList.Count - 1];
            if (searchInfo.i == uid && (this.p == null || searchInfo.n == this.propertyName))
            {
                //Debug.Log ("foundData: " + this + ", " + this.propertyName + ", " + this.uniqueId);
                if (idList.Count == 1)
                {
                    return this;
                }
                else
                {
                    // find deeper in child
                    List<Data.SI> childIdList = new List<Data.SI>();
                    for (int i = 0; i < idList.Count - 1; i++)
                    {
                        childIdList.Add(idList[i]);
                    }
                    // search
                    Data find = null;
                    {
                        // Find WrapProperty
                        Data.SI childInfo = childIdList[childIdList.Count - 1];
                        WrapProperty wrapProperty = this.findProperty(childInfo.n);
                        if (wrapProperty != null && wrapProperty.getValueType().IsSubclassOf(typeof(Data)))
                        {
                            Data child = null;
                            // Find child
                            {
                                int valueCount = wrapProperty.getValueCount();
                                for (int i = valueCount - 1; i >= 0; i--)
                                {
                                    Data checkChild = (Data)wrapProperty.getValue(i);
                                    if (checkChild != null)
                                    {
                                        if (checkChild.uid == childInfo.i)
                                        {
                                            child = checkChild;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("checkChild null");
                                    }
                                }
                            }
                            // Search in child
                            if (child != null)
                            {
                                find = child.findData(childIdList);
                            }
                            else
                            {
                                // Debug.LogError ("Cannot find child");
                            }
                        }
                        else
                        {
                            // Debug.LogError ("wrapProperty null");
                        }
                    }
                    // Debug.Log ("search: " + this + ", find: " + find);
                    return find;
                }
            }
            else
            {
                // Debug.LogError ("Cannot find data: " + searchInfo + ", " + this.uid + ", " + this.p + ", " + this);
                return null;
            }
        }
        else
        {
            // Debug.Log ("Cannot find data: " + idList + ", " + this);
            return null;
        }
        // return findData (idList, null);
    }

    #endregion

    public WrapProperty findProperty(byte propertyName)
    {
        WrapProperty property = null;
        for (int i = 0; i < pts.Count; i++)
        {
            WrapProperty check = pts[i];
            if (check.n == propertyName)
            {
                property = check;
                break;
            }
        }
        return property;
    }

    #endregion

    // TODO co le can thuc hien copy class

    public struct NeedRequest
    {
        public bool canRequest;
        public bool needIdentity;

        /*public NeedRequest()
		{
			this.canRequest = true;
			this.needIdentity = false;
		}*/
    }

    public NeedRequest isNeedRequestServerByNetworkIdentity()
    {
        NeedRequest needRequest = new NeedRequest();
        // Check
        Server server = this.findDataInParent<Server>();
        if (server != null)
        {
            switch (server.state.v.getType())
            {
                case Server.State.Type.Offline:
                    needRequest.canRequest = true;
                    needRequest.needIdentity = false;
                    break;
                case Server.State.Type.Connect:
                    {
                        switch (server.type.v)
                        {
                            case Server.Type.Server:
                                {
                                    needRequest.canRequest = true;
                                    needRequest.needIdentity = false;
                                }
                                break;
                            case Server.Type.Host:
                                {
                                    needRequest.canRequest = true;
                                    needRequest.needIdentity = false;
                                }
                                break;
                            case Server.Type.Client:
                                {
                                    needRequest.canRequest = true;
                                    needRequest.needIdentity = true;
                                }
                                break;
                            case Server.Type.Offline:
                                {
                                    needRequest.canRequest = true;
                                    needRequest.needIdentity = false;
                                }
                                break;
                            default:
                                // Debug.LogError ("unknown server type: " + server.type.property);
                                break;
                        }
                    }
                    break;
                case Server.State.Type.Disconnect:
                    {
                        // Debug.LogError ("Server is disconnected");
                        needRequest.canRequest = false;
                        needRequest.needIdentity = false;
                    }
                    break;
                default:
                    {
                        // Debug.LogError ("unknown server state: " + server.state.property.getType());
                        needRequest.canRequest = false;
                        needRequest.needIdentity = false;
                    }
                    break;
            }
        }
        else
        {
            // Debug.LogError ("server null");
            needRequest.canRequest = true;
            needRequest.needIdentity = false;
        }
        // return
        return needRequest;
    }

    #region Edit

    public enum EditType
    {
        Immediate,
        Later
    }

    public static readonly TxtLanguage txtImmediately = new TxtLanguage("Immediately");
    public static readonly TxtLanguage txtLater = new TxtLanguage("Later");

    public static void RefreshStrEditType(RequestChangeEnumUI.UIData requestEditType)
    {
        if (requestEditType != null)
        {
            List<string> options = new List<string>();
            {
                options.Add(txtImmediately.get());
                options.Add(txtLater.get());
            }
            requestEditType.options.copyList(options);
        }
        else
        {
            Debug.LogError("requestEditType null");
        }
    }

    public static void RefreshStrEditType(Dropdown drEditType)
    {
        if (drEditType != null)
        {
            string[] options = new string[] { Data.txtImmediately.get(), Data.txtLater.get() };
            // remove 
            {
                if (drEditType.options.Count > options.Length)
                {
                    drEditType.options.RemoveRange(options.Length, drEditType.options.Count - options.Length);
                }
            }
            for (int i = 0; i < options.Length; i++)
            {
                if (i < drEditType.options.Count)
                {
                    // Update
                    drEditType.options[i].text = options[i];
                }
                else
                {
                    // Add new
                    Dropdown.OptionData optionData = new Dropdown.OptionData();
                    {
                        optionData.text = options[i];
                    }
                    drEditType.options.Add(optionData);
                }
            }
        }
        else
        {
            Debug.LogError("drEditType null");
        }
    }

    static Data()
    {
        txtImmediately.add(Language.Type.vi, "Ngay lập tức");
        txtLater.add(Language.Type.vi, "Sau này");
    }

    public enum ChangeState
    {
        None,
        Request,
        Requesting
    }

    #endregion

    #region makeBinary for save

    public virtual void makeBinary(BinaryWriter writer)
    {
        // write class name
        {
            writer.Write(this.GetType().FullName);
        }
        // write uid
        writer.Write(this.uid);
        // properties
        foreach (WrapProperty wrapProperty in this.pts)
        {
            wrapProperty.makeBinary(writer);
        }
    }

    public static byte[] MakeBinary(Data data)
    {
        byte[] byteArray = null;
        {
            if (data != null)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(memStream))
                    {
                        data.makeBinary(writer);
                        byteArray = memStream.ToArray();
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + data);
            }
        }
        return byteArray;
    }

    public static Data parseBinary(BinaryReader reader)
    {
        Data outData = null;
        {
            try
            {
                // class name
                {
                    string className = reader.ReadString();
                    if (className != "null")
                    {
                        outData = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(className) as Data;
                    }
                    else
                    {
                        Debug.LogError("className null: " + reader);
                    }
                }
                if (outData != null)
                {
                    // uid
                    outData.uid = reader.ReadUInt32();
                    // properties
                    outData.parse(reader);
                }
                else
                {
                    Debug.LogError("outData null: " + outData);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("data utils parse: " + e);
            }
        }
        return outData;
    }

    public virtual void parse(BinaryReader reader)
    {
        foreach (WrapProperty wrapProperty in this.pts)
        {
            wrapProperty.parse(reader);
        }
    }

    public WrapProperty findProperty(WrapChange change)
    {
        Data parent = this.findData(change.pi.v);
        if (parent != null)
        {
            WrapProperty wrapProperty = parent.findProperty(change.vn.v);
            return wrapProperty;
        }
        else
        {
            Debug.LogError("Cannot find data");
            return null;
        }
    }

    #endregion

    #region make binary for sqlite

    public virtual void makeSqliteBinary(BinaryWriter writer)
    {
        // write class name
        {
            writer.Write(this.GetType().FullName);
        }
        // write uid
        writer.Write(this.uid);
        // properties
        foreach (WrapProperty wrapProperty in this.pts)
        {
            wrapProperty.makeSqliteBinary(writer);
        }
    }

    public static byte[] MakeSqliteBinary(Data data)
    {
        byte[] byteArray = null;
        {
            if (data != null)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(memStream))
                    {
                        data.makeSqliteBinary(writer);
                        byteArray = memStream.ToArray();
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + data);
            }
        }
        return byteArray;
    }

    public static Data parseSqliteBinary(BinaryReader reader)
    {
        Data outData = null;
        {
            try
            {
                // class name
                {
                    string className = reader.ReadString();
                    if (className != "null")
                    {
                        outData = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(className) as Data;
                    }
                    else
                    {
                        Debug.LogError("className null: " + reader);
                    }
                }
                if (outData != null)
                {
                    // uid
                    outData.uid = reader.ReadUInt32();
                    // properties
                    outData.parseSqlite(reader);
                }
                else
                {
                    Debug.LogError("outData null: " + outData);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("data utils parse: " + e);
            }
        }
        return outData;
    }

    public virtual void parseSqlite(BinaryReader reader)
    {
        foreach (WrapProperty wrapProperty in this.pts)
        {
            wrapProperty.parseSqlite(reader);
        }
    }

    #endregion

    #region root

    public bool isRoot = false;

    public bool isHaveRoot()
    {
        if (this.p != null)
        {
            if (this.p.p != null)
            {
                return this.p.p.isHaveRoot();
            }
            else
            {
                return this.isRoot;
            }
        }
        else
        {
            return this.isRoot;
        }
    }

    #endregion

}