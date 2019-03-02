using UnityEngine;
using System.Text;
using System.Collections;
using System.Reflection;

public class DataMakeIdentityUtils
{
    public static string UppercaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }

    public static string LowercaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        char[] a = s.ToCharArray();
        a[0] = char.ToLower(a[0]);
        return new string(a);
    }

    public static string getTypeName(System.Type type)
    {
        if (type.IsSubclassOf(typeof(Data)))
        {
            return type.Name;
        }
        else
        {
            string strTableName = type.ToString();
            {
                strTableName = strTableName.Replace("+", ".");
            }
            return strTableName;
        }
    }

    public static string getSyncListVariableName(System.Type type)
    {
        // byte
        if (type == typeof(byte))
        {
            return "SyncListByte";
        }
        // sbyte
        if (type == typeof(sbyte))
        {
            return "SyncListSByte";
        }
        // ushort
        if (type == typeof(ushort))
        {
            return "SyncListUShort";
        }
        // bool
        if (type == typeof(bool))
        {
            return "SyncListBool";
        }
        // float
        if (type == typeof(float))
        {
            return "SyncListFloat";
        }
        // int
        if (type == typeof(int))
        {
            return "SyncListInt";
        }
        // string
        if (type == typeof(string))
        {
            return "SyncListString";
        }
        // uint
        if (type == typeof(uint))
        {
            return "SyncListUInt";
        }
        // ulong
        if (type == typeof(ulong))
        {
            return "SyncListUInt64";
        }
        // long
        if (type == typeof(long))
        {
            return "SyncListInt64";
        }

        return "SyncListUnknown";
    }

    public static string getStringCastToDataType(System.Type type)
    {
        // byte
        if (type == typeof(byte))
        {
            return "MyByte.byteConvert";
        }
        // sbyte
        if (type == typeof(sbyte))
        {
            return "MySByte.sbyteConvert";
        }
        // ushort
        if (type == typeof(ushort))
        {
            return "MyUShort.ushortConvert";
        }
        // bool
        if (type == typeof(bool))
        {
            return "";
        }
        // float
        if (type == typeof(float))
        {
            return "";
        }
        // int
        if (type == typeof(int))
        {
            return "";
        }
        // string
        if (type == typeof(string))
        {
            return "";
        }
        // uint
        if (type == typeof(uint))
        {
            return "";
        }
        // ulong
        if (type == typeof(ulong))
        {
            return "MyUInt64.uLongConvert";
        }
        // long
        if (type == typeof(long))
        {
            return "MyInt64.longConvert";
        }

        return "";
    }

    public static string getStringCastToSyncList(System.Type type)
    {
        // byte
        if (type == typeof(byte))
        {
            return "MyByte.myByteConvert";
        }
        // sbyte
        if (type == typeof(sbyte))
        {
            return "MySByte.mySByteConvert";
        }
        // ushort
        if (type == typeof(ushort))
        {
            return "MyUShort.myUShortConvert";
        }
        // bool
        if (type == typeof(bool))
        {
            return "";
        }
        // float
        if (type == typeof(float))
        {
            return "";
        }
        // int
        if (type == typeof(int))
        {
            return "";
        }
        // string
        if (type == typeof(string))
        {
            return "";
        }
        // uint
        if (type == typeof(uint))
        {
            return "";
        }
        // ulong
        if (type == typeof(ulong))
        {
            return "MyUInt64.myUInt64Convert";
        }
        // long
        if (type == typeof(long))
        {
            return "MyInt64.myInt64Convert";
        }

        return "";
    }

    public static string getGlobalCastT(System.Type type)
    {
        // byte
        if (type == typeof(byte))
        {
            return "GlobalCast<T>.CastingMyByte";
        }
        // sbyte
        if (type == typeof(sbyte))
        {
            return "GlobalCast<T>.CastingMySByte";
        }
        // ushort
        if (type == typeof(ushort))
        {
            return "GlobalCast<T>.CastingMyUShort";
        }
        // bool
        if (type == typeof(bool))
        {
            return "GlobalCast<T>.CastingBool";
        }
        // float
        if (type == typeof(float))
        {
            return "GlobalCast<T>.CastingSingle";
        }
        // int
        if (type == typeof(int))
        {
            return "GlobalCast<T>.CastingInt32";
        }
        // string
        else if (type == typeof(string))
        {
            return "GlobalCast<T>.CastingString";
        }
        // uint
        if (type == typeof(uint))
        {
            return "GlobalCast<T>.CastingUInt32";
        }
        // ulong
        if (type == typeof(ulong))
        {
            return "GlobalCast<T>.CastingMyUInt64";
        }
        // long
        if (type == typeof(long))
        {
            return "GlobalCast<T>.CastingMyInt64";
        }
        return "unknown";
    }

    public static void makeIdentity(System.Type type)
    {
        StringBuilder builder = new StringBuilder();
        {
            // SyncVar
            {
                builder.AppendLine("#region SyncVar");
                builder.AppendLine();
                // Field
                {
                    FieldInfo[] fieldInfos = type.GetFields();
                    for (int i = 0; i < fieldInfos.Length; i++)
                    {
                        FieldInfo fieldInfo = fieldInfos[i];
                        /* Debug.Log ("type: " + type + ": fieldInfo: " + fieldInfo.Name
						+ ", " + fieldInfo.DeclaringType + ", " + fieldInfo.Attributes
						+ ", " + fieldInfo.FieldType);*/
                        if (fieldInfo.FieldType.IsSubclassOf(typeof(WrapProperty)))
                        {
                            // Debug.Log ("this is wrapProperty: " + fieldInfo.FieldType);
                            System.Type dataType = fieldInfo.FieldType.GetGenericArguments()[0];
                            if (dataType != null && !dataType.IsSubclassOf(typeof(Data)))
                            {
                                // region
                                {
                                    builder.AppendLine("#region " + fieldInfo.Name);
                                    builder.AppendLine();
                                }
                                // Value Property
                                if (Data.IsSubclassOfRawGeneric(typeof(VP<>), fieldInfo.FieldType))
                                {
                                    // hook
                                    builder.AppendLine(string.Format("[SyncVar(hook=\"onChange{0}\")]", UppercaseFirst(fieldInfo.Name)));
                                    // public
                                    builder.AppendLine(string.Format("public {0} {1};", getTypeName(dataType), fieldInfo.Name));
                                    // method
                                    {
                                        builder.AppendLine();
                                        builder.AppendLine(string.Format("public void onChange{0}({1} new{2})", UppercaseFirst(fieldInfo.Name), getTypeName(dataType), UppercaseFirst(fieldInfo.Name)));
                                        builder.AppendLine("{");
                                        {
                                            builder.AppendLine(string.Format("this.{0} = new{1};", fieldInfo.Name, UppercaseFirst(fieldInfo.Name)));
                                            builder.AppendLine("if (this.netData.clientData != null) {");
                                            {
                                                builder.AppendLine(string.Format("this.netData.clientData.{0}.v = new{1};", fieldInfo.Name, UppercaseFirst(fieldInfo.Name)));
                                            }
                                            builder.AppendLine("} else {");
                                            {
                                                builder.AppendLine("// Debug.LogError (\"clientData null: \"+this);");
                                            }
                                            builder.AppendLine("}");
                                        }
                                        builder.AppendLine("}");
                                        builder.AppendLine();
                                    }

                                }
                                else if (Data.IsSubclassOfRawGeneric(typeof(LP<>), fieldInfo.FieldType))
                                {// listProperty
                                    builder.AppendLine(string.Format("public {0} {1} = new {2}();", getSyncListVariableName(dataType), fieldInfo.Name, getSyncListVariableName(dataType)));
                                    builder.AppendLine();
                                    // method
                                    {
                                        // private void OnByTypeBBChanged(SyncList<System.UInt64>.Operation op, int index)
                                        builder.AppendLine(string.Format("private void On{0}Changed({1}.Operation op, int index)", UppercaseFirst(fieldInfo.Name), getSyncListVariableName(dataType)));
                                        builder.AppendLine("{");
                                        {
                                            builder.AppendLine("if (this.netData.clientData != null) {");
                                            {
                                                string strCastToDataType = getStringCastToDataType(dataType);
                                                builder.AppendLine(string.Format("IdentityUtils.onSyncListChange (this.netData.clientData.{0}, this.{1}, op, index{2});", fieldInfo.Name, fieldInfo.Name, string.IsNullOrEmpty(strCastToDataType) ? "" : ", " + strCastToDataType));
                                            }
                                            builder.AppendLine("} else {");
                                            {
                                                builder.AppendLine("// Debug.LogError (\"clientData null: \" + this);");
                                            }
                                            builder.AppendLine("}");
                                        }
                                        builder.AppendLine("}");
                                    }
                                }
                                // endregion
                                {
                                    builder.AppendLine("#endregion");
                                    builder.AppendLine();
                                }
                            }
                            else
                            {
                                // Debug.Log ("Don't need data type is a column, they need own table: " + dataType);
                            }
                        }
                    }
                }
                // End
                builder.AppendLine("#endregion");
            }
            // netData
            builder.AppendLine();
            {
                builder.AppendLine("#region NetData");
                builder.AppendLine();
                // private NetData<Chess> netData = new NetData<Chess>();
                {
                    builder.AppendLine(string.Format("private NetData<{0}> netData = new NetData<{1}>();", getTypeName(type), getTypeName(type)));
                }
                builder.AppendLine();
                // public override NetDataDelegate getNetData ()
                {
                    builder.AppendLine("public override NetDataDelegate getNetData ()");
                    builder.AppendLine("{");
                    {
                        builder.AppendLine("return this.netData;");
                    }
                    builder.AppendLine("}");
                }
                builder.AppendLine();
                // addSyncListCallBack: chi danh cho listProperty
                {
                    // check need addSyncListCallBack
                    bool needAddSyncListCallBack = false;
                    {
                        FieldInfo[] fieldInfos = type.GetFields();
                        for (int i = 0; i < fieldInfos.Length; i++)
                        {
                            FieldInfo fieldInfo = fieldInfos[i];
                            if (fieldInfo.FieldType.IsSubclassOf(typeof(WrapProperty)))
                            {
                                // Debug.Log ("this is wrapProperty: " + fieldInfo.FieldType);
                                System.Type dataType = fieldInfo.FieldType.GetGenericArguments()[0];
                                if (dataType != null && !dataType.IsSubclassOf(typeof(Data)))
                                {
                                    if (Data.IsSubclassOfRawGeneric(typeof(LP<>), fieldInfo.FieldType))
                                    {
                                        needAddSyncListCallBack = true;
                                    }
                                }
                            }
                        }
                    }
                    if (needAddSyncListCallBack)
                    {
                        builder.AppendLine("public override void addSyncListCallBack ()");
                        builder.AppendLine("{");
                        {
                            builder.AppendLine("base.addSyncListCallBack ();");
                            FieldInfo[] fieldInfos = type.GetFields();
                            for (int i = 0; i < fieldInfos.Length; i++)
                            {
                                FieldInfo fieldInfo = fieldInfos[i];
                                if (fieldInfo.FieldType.IsSubclassOf(typeof(WrapProperty)))
                                {
                                    // Debug.Log ("this is wrapProperty: " + fieldInfo.FieldType);
                                    System.Type dataType = fieldInfo.FieldType.GetGenericArguments()[0];
                                    if (dataType != null && !dataType.IsSubclassOf(typeof(Data)))
                                    {
                                        if (Data.IsSubclassOfRawGeneric(typeof(LP<>), fieldInfo.FieldType))
                                        {
                                            // this.board.Callback = OnBoardChanged;
                                            builder.AppendLine(string.Format("this.{0}.Callback += On{1}Changed;", fieldInfo.Name, UppercaseFirst(fieldInfo.Name)));
                                        }
                                    }
                                }
                            }
                        }
                        builder.AppendLine("}");
                        builder.AppendLine();
                    }
                }
                // Refresh clientData
                {
                    builder.AppendLine("public override void refreshClientData ()");
                    builder.AppendLine("{");
                    {
                        builder.AppendLine("if (this.netData.clientData != null) {");
                        // Field
                        {
                            FieldInfo[] fieldInfos = type.GetFields();
                            for (int i = 0; i < fieldInfos.Length; i++)
                            {
                                FieldInfo fieldInfo = fieldInfos[i];
                                if (fieldInfo.FieldType.IsSubclassOf(typeof(WrapProperty)))
                                {
                                    // Debug.Log ("this is wrapProperty: " + fieldInfo.FieldType);
                                    System.Type dataType = fieldInfo.FieldType.GetGenericArguments()[0];
                                    if (dataType != null && !dataType.IsSubclassOf(typeof(Data)))
                                    {
                                        // valueProperty
                                        if (Data.IsSubclassOfRawGeneric(typeof(VP<>), fieldInfo.FieldType))
                                        {
                                            builder.AppendLine(string.Format("this.onChange{0}(this.{1});", UppercaseFirst(fieldInfo.Name), fieldInfo.Name));
                                        }
                                        // listProperty
                                        else if (Data.IsSubclassOfRawGeneric(typeof(LP<>), fieldInfo.FieldType))
                                        {
                                            string strCastToDataType = getStringCastToDataType(dataType);
                                            builder.AppendLine(string.Format("IdentityUtils.refresh(this.netData.clientData.{0}, this.{1}{2});", fieldInfo.Name, fieldInfo.Name,
                                                string.IsNullOrEmpty(strCastToDataType) ? "" : ", " + strCastToDataType));
                                        }
                                    }
                                    else
                                    {
                                        // Debug.Log ("dataType null");
                                    }
                                }
                            }
                        }
                        builder.AppendLine("} else {");
                        builder.AppendLine("Debug.Log (\"clientData null\");");
                        builder.AppendLine("}");
                    }
                    builder.AppendLine("}");
                }
                builder.AppendLine();
                // refreshDataSize
                {
                    builder.AppendLine("public override int refreshDataSize ()");
                    builder.AppendLine("{");
                    {
                        builder.AppendLine("int ret = GetDataSize (this.netId);");
                        builder.AppendLine("{");
                        // Field
                        {
                            FieldInfo[] fieldInfos = type.GetFields();
                            for (int i = 0; i < fieldInfos.Length; i++)
                            {
                                FieldInfo fieldInfo = fieldInfos[i];
                                if (fieldInfo.FieldType.IsSubclassOf(typeof(WrapProperty)))
                                {
                                    // Debug.Log ("this is wrapProperty: " + fieldInfo.FieldType);
                                    System.Type dataType = fieldInfo.FieldType.GetGenericArguments()[0];
                                    if (dataType != null && !dataType.IsSubclassOf(typeof(Data)))
                                    {
                                        builder.AppendLine(string.Format("ret += GetDataSize (this.{0});", fieldInfo.Name));
                                    }
                                    else
                                    {
                                        // Debug.Log ("dataType null");
                                    }
                                }
                            }
                        }
                        builder.AppendLine("}");
                        builder.AppendLine("return ret;");
                    }
                    builder.AppendLine("}");
                }
                builder.AppendLine();
                builder.AppendLine("#endregion");
            }
            builder.AppendLine();
            // implement callBacks
            {
                builder.AppendLine("#region implemt callback");
                builder.AppendLine();
                string variable = LowercaseFirst(type.Name);
                // onAddCallBack
                {
                    builder.AppendLine("public override void onAddCallBack<T> (T data)");
                    builder.AppendLine("{");
                    {
                        builder.AppendLine("if (data is " + getTypeName(type) + ") {");
                        {
                            builder.AppendLine(string.Format("{0} {1} = data as {2};", getTypeName(type), variable, getTypeName(type)));
                            builder.AppendLine("// Set new parent");
                            builder.AppendLine("this.addTransformToParent();");
                            // Property
                            {
                                builder.AppendLine("// Set property");
                                builder.AppendLine("{");
                                {
                                    // Id
                                    builder.AppendLine(string.Format("this.serialize (this.searchInfor, {0}.makeSearchInforms ());", variable));
                                    // Field
                                    {
                                        FieldInfo[] fieldInfos = type.GetFields();
                                        for (int i = 0; i < fieldInfos.Length; i++)
                                        {
                                            FieldInfo fieldInfo = fieldInfos[i];
                                            if (fieldInfo.FieldType.IsSubclassOf(typeof(WrapProperty)))
                                            {
                                                // Debug.LogError ("this is wrapProperty: " + fieldInfo + "; " + builder.Length);
                                                System.Type dataType = fieldInfo.FieldType.GetGenericArguments()[0];
                                                if (dataType != null && !dataType.IsSubclassOf(typeof(Data)))
                                                {
                                                    // valueProperty
                                                    if (Data.IsSubclassOfRawGeneric(typeof(VP<>), fieldInfo.FieldType))
                                                    {
                                                        builder.AppendLine(string.Format("this.{0} = {1}.{2}.v;", fieldInfo.Name, variable, fieldInfo.Name));
                                                    }
                                                    // listProperty
                                                    else if (Data.IsSubclassOfRawGeneric(typeof(LP<>), fieldInfo.FieldType))
                                                    {
                                                        string strCastToSyncList = getStringCastToSyncList(dataType);
                                                        if (string.IsNullOrEmpty(strCastToSyncList))
                                                        {
                                                            builder.AppendLine(string.Format("IdentityUtils.InitSync(this.{0}, {1}.{2}.vs);", fieldInfo.Name, variable, fieldInfo.Name));
                                                        }
                                                        else
                                                        {
                                                            builder.AppendLine(string.Format("IdentityUtils.InitSync(this.{0}, {1}.{2}, {3});", fieldInfo.Name, variable, fieldInfo.Name, strCastToSyncList));
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    // Debug.Log ("dataType null");
                                                }
                                            }
                                        }
                                    }
                                }
                                builder.AppendLine("}");
                            }
                            // Observer
                            {
                                builder.AppendLine("// Observer");
                                builder.AppendLine("{");
                                {
                                    builder.AppendLine("GameObserver observer = GetComponent<GameObserver> ();");
                                    builder.AppendLine("if (observer != null) {");
                                    {
                                        builder.AppendLine("observer.checkChange = new FollowParentObserver (observer);");
                                        builder.AppendLine(string.Format("observer.setCheckChangeData ({0});", variable));
                                    }
                                    builder.AppendLine("} else {");
                                    {
                                        builder.AppendLine("Debug.LogError (\"observer null: \" + this);");
                                    }
                                    builder.AppendLine("}");
                                }
                                builder.AppendLine("}");
                            }
                            builder.AppendLine("return;");
                        }
                        builder.AppendLine("}");
                    }
                    builder.AppendLine("Debug.LogError (\"Don't process: \" + data + \"; \" + this);");
                    builder.AppendLine("}");
                }
                // OnRemoveCallBack
                builder.AppendLine();
                {
                    builder.AppendLine("public override void onRemoveCallBack<T> (T data, bool isHide)");
                    builder.AppendLine("{");
                    {
                        builder.AppendLine("if (data is " + getTypeName(type) + ") {");
                        {
                            builder.AppendLine(string.Format("// {0} {1} = data as {2};", getTypeName(type), variable, getTypeName(type)));
                            builder.AppendLine("// Observer");
                            builder.AppendLine("{");
                            {
                                builder.AppendLine("GameObserver observer = GetComponent<GameObserver> ();");
                                builder.AppendLine("if (observer != null) {");
                                {
                                    builder.AppendLine("observer.setCheckChangeData (null);");
                                }
                                builder.AppendLine("} else {");
                                {
                                    builder.AppendLine("Debug.LogError (\"observer null: \" + this);");
                                }
                                builder.AppendLine("}");
                            }
                            builder.AppendLine("}");
                        }
                        builder.AppendLine("return;");
                        builder.AppendLine("}");
                        builder.AppendLine("Debug.LogError (\"Don't process: \" + data + \"; \" + this);");
                    }
                    builder.AppendLine("}");
                }
                // OnvalueChange
                builder.AppendLine();
                {
                    builder.AppendLine("public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)");
                    builder.AppendLine("{");
                    {
                        // Check error
                        builder.AppendLine("if (WrapProperty.checkError (wrapProperty)) {\n\t\t\t\treturn;\n\t\t\t}");
                        // WrapProperty
                        {
                            builder.AppendLine("if (wrapProperty.p is " + getTypeName(type) + ") {");
                            builder.AppendLine("switch ((" + getTypeName(type) + ".Property)wrapProperty.n) {");
                            {
                                // Info
                                {
                                    FieldInfo[] fieldInfos = type.GetFields();
                                    for (int i = 0; i < fieldInfos.Length; i++)
                                    {
                                        FieldInfo fieldInfo = fieldInfos[i];
                                        if (fieldInfo.FieldType.IsSubclassOf(typeof(WrapProperty)))
                                        {
                                            builder.AppendLine("case " + getTypeName(type) + ".Property." + fieldInfo.Name + ":");
                                            {
                                                // Debug.Log ("this is wrapProperty: " + fieldInfo.FieldType);
                                                System.Type dataType = fieldInfo.FieldType.GetGenericArguments()[0];
                                                if (dataType != null && !dataType.IsSubclassOf(typeof(Data)))
                                                {
                                                    // valueProperty
                                                    if (Data.IsSubclassOfRawGeneric(typeof(VP<>), fieldInfo.FieldType))
                                                    {
                                                        builder.AppendLine("this." + fieldInfo.Name + " = (" + getTypeName(dataType) + ")wrapProperty.getValue ();");
                                                    }
                                                    // listProperty
                                                    else if (Data.IsSubclassOfRawGeneric(typeof(LP<>), fieldInfo.FieldType))
                                                    {
                                                        builder.AppendLine(string.Format("IdentityUtils.UpdateSyncList (this.{0}, syncs, {1});", fieldInfo.Name, getGlobalCastT(dataType)));
                                                    }
                                                }
                                                else
                                                {
                                                    // Debug.Log ("dataType null");
                                                }
                                            }
                                            builder.AppendLine("break;");
                                        }
                                    }
                                }
                                // default
                                {
                                    builder.AppendLine("default:");
                                    builder.AppendLine("Debug.LogError (\"Unknown wrapProperty: \" + wrapProperty + \"; \" + this);");
                                    builder.AppendLine("break;");
                                }
                            }
                            builder.AppendLine("}");
                            builder.AppendLine("return;");
                        }
                        builder.AppendLine("}");
                        builder.AppendLine("Debug.LogError (\"Don't process: \" + wrapProperty + \"; \" + syncs + \"; \" + this);");
                    }
                    builder.AppendLine("}");
                }
                builder.AppendLine();
                builder.AppendLine("#endregion");
            }
        }
        Debug.LogError("" + builder.ToString());
    }

}