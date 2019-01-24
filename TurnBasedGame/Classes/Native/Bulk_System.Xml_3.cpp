#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>

#include "class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "mscorlib_System_Array3829468939.h"
#include "System_Xml_System_Xml_XmlWhitespace2557770518.h"
#include "mscorlib_System_String2029220233.h"
#include "System_Xml_System_Xml_XmlDocument3649534162.h"
#include "mscorlib_System_Void1841601450.h"
#include "System_Xml_System_Xml_XmlCharacterData575748506.h"
#include "System_Xml_System_Xml_XmlNodeType739504597.h"
#include "mscorlib_System_Boolean3825574718.h"
#include "mscorlib_System_ArgumentException3259014390.h"
#include "System_Xml_System_Xml_XmlNode616554813.h"
#include "System_Xml_System_Xml_XmlWriter1048088568.h"
#include "mscorlib_System_Object2689449295.h"
#include "System_Xml_System_Xml_XmlSpace2880376877.h"
#include "System_Xml_System_Xml_XmlReader3675626668.h"
#include "mscorlib_System_Int322071877448.h"
#include "System_Xml_System_Xml_ReadState3138905245.h"
#include "System_Xml_System_Xml_XmlException4188277960.h"

// System.Xml.XmlWhitespace
struct XmlWhitespace_t2557770518;
// System.String
struct String_t;
// System.Xml.XmlDocument
struct XmlDocument_t3649534162;
// System.Xml.XmlCharacterData
struct XmlCharacterData_t575748506;
// System.ArgumentException
struct ArgumentException_t3259014390;
// System.Xml.XmlNode
struct XmlNode_t616554813;
// System.Xml.XmlWriter
struct XmlWriter_t1048088568;
// System.Object
struct Il2CppObject;
// System.Xml.XmlReader
struct XmlReader_t3675626668;
// System.Object[]
struct ObjectU5BU5D_t3614634134;
// System.Xml.XmlException
struct XmlException_t4188277960;
extern Il2CppCodeGenString* _stringLiteral598529038;
extern const uint32_t XmlWhitespace_get_LocalName_m544466665_MetadataUsageId;
extern const uint32_t XmlWhitespace_get_Name_m1189472250_MetadataUsageId;
extern Il2CppClass* XmlChar_t1369421061_il2cpp_TypeInfo_var;
extern Il2CppClass* ArgumentException_t3259014390_il2cpp_TypeInfo_var;
extern Il2CppCodeGenString* _stringLiteral3464576676;
extern const uint32_t XmlWhitespace_set_Value_m2476864755_MetadataUsageId;
extern Il2CppClass* XmlWhitespace_t2557770518_il2cpp_TypeInfo_var;
extern const uint32_t XmlWhitespace_CloneNode_m3071418885_MetadataUsageId;
extern Il2CppClass* String_t_il2cpp_TypeInfo_var;
extern const uint32_t XmlWriter_WriteAttributeString_m3169493699_MetadataUsageId;
extern Il2CppClass* ObjectU5BU5D_t3614634134_il2cpp_TypeInfo_var;
extern Il2CppClass* XmlNodeType_t739504597_il2cpp_TypeInfo_var;
extern Il2CppClass* XmlException_t4188277960_il2cpp_TypeInfo_var;
extern Il2CppCodeGenString* _stringLiteral2074996249;
extern Il2CppCodeGenString* _stringLiteral1111970457;
extern Il2CppCodeGenString* _stringLiteral160707941;
extern Il2CppCodeGenString* _stringLiteral2206509877;
extern const uint32_t XmlWriter_WriteNode_m1949395905_MetadataUsageId;

// System.Object[]
struct ObjectU5BU5D_t3614634134  : public Il2CppArray
{
public:
	ALIGN_FIELD (8) Il2CppObject * m_Items[1];

public:
	inline Il2CppObject * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Il2CppObject ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Il2CppObject * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
	inline Il2CppObject * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Il2CppObject ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Il2CppObject * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier(m_Items + index, value);
	}
};



// System.Void System.Xml.XmlCharacterData::.ctor(System.String,System.Xml.XmlDocument)
extern "C"  void XmlCharacterData__ctor_m1128145521 (XmlCharacterData_t575748506 * __this, String_t* ___data0, XmlDocument_t3649534162 * ___doc1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Xml.XmlChar::IsWhitespace(System.String)
extern "C"  bool XmlChar_IsWhitespace_m1819392135 (Il2CppObject * __this /* static, unused */, String_t* ___str0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.ArgumentException::.ctor(System.String)
extern "C"  void ArgumentException__ctor_m3739475201 (ArgumentException_t3259014390 * __this, String_t* p0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Xml.XmlNode System.Xml.XmlNode::get_ParentNode()
extern "C"  XmlNode_t616554813 * XmlNode_get_ParentNode_m1570967687 (XmlNode_t616554813 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Xml.XmlWhitespace::.ctor(System.String,System.Xml.XmlDocument)
extern "C"  void XmlWhitespace__ctor_m674315191 (XmlWhitespace_t2557770518 * __this, String_t* ___strData0, XmlDocument_t3649534162 * ___doc1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Object::.ctor()
extern "C"  void Object__ctor_m2551263788 (Il2CppObject * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Xml.XmlWriter::WriteAttributeString(System.String,System.String,System.String,System.String)
extern "C"  void XmlWriter_WriteAttributeString_m2741345027 (XmlWriter_t1048088568 * __this, String_t* ___prefix0, String_t* ___localName1, String_t* ___ns2, String_t* ___value3, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.String::get_Length()
extern "C"  int32_t String_get_Length_m1606060069 (String_t* __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Xml.XmlWriter::WriteStartElement(System.String)
extern "C"  void XmlWriter_WriteStartElement_m2103041358 (XmlWriter_t1048088568 * __this, String_t* ___localName0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.ArgumentException::.ctor()
extern "C"  void ArgumentException__ctor_m2105824819 (ArgumentException_t3259014390 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Xml.XmlWriter::WriteAttribute(System.Xml.XmlReader,System.Boolean)
extern "C"  void XmlWriter_WriteAttribute_m3300629885 (XmlWriter_t1048088568 * __this, XmlReader_t3675626668 * ___reader0, bool ___defattr1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Concat(System.Object[])
extern "C"  String_t* String_Concat_m3881798623 (Il2CppObject * __this /* static, unused */, ObjectU5BU5D_t3614634134* p0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Xml.XmlException::.ctor(System.String)
extern "C"  void XmlException__ctor_m47652749 (XmlException_t4188277960 * __this, String_t* ___message0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Xml.XmlWhitespace::.ctor(System.String,System.Xml.XmlDocument)
extern "C"  void XmlWhitespace__ctor_m674315191 (XmlWhitespace_t2557770518 * __this, String_t* ___strData0, XmlDocument_t3649534162 * ___doc1, const MethodInfo* method)
{
	{
		String_t* L_0 = ___strData0;
		XmlDocument_t3649534162 * L_1 = ___doc1;
		XmlCharacterData__ctor_m1128145521(__this, L_0, L_1, /*hidden argument*/NULL);
		return;
	}
}
// System.String System.Xml.XmlWhitespace::get_LocalName()
extern "C"  String_t* XmlWhitespace_get_LocalName_m544466665 (XmlWhitespace_t2557770518 * __this, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (XmlWhitespace_get_LocalName_m544466665_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		return _stringLiteral598529038;
	}
}
// System.String System.Xml.XmlWhitespace::get_Name()
extern "C"  String_t* XmlWhitespace_get_Name_m1189472250 (XmlWhitespace_t2557770518 * __this, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (XmlWhitespace_get_Name_m1189472250_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		return _stringLiteral598529038;
	}
}
// System.Xml.XmlNodeType System.Xml.XmlWhitespace::get_NodeType()
extern "C"  int32_t XmlWhitespace_get_NodeType_m2427709928 (XmlWhitespace_t2557770518 * __this, const MethodInfo* method)
{
	{
		return (int32_t)(((int32_t)13));
	}
}
// System.String System.Xml.XmlWhitespace::get_Value()
extern "C"  String_t* XmlWhitespace_get_Value_m387657992 (XmlWhitespace_t2557770518 * __this, const MethodInfo* method)
{
	{
		String_t* L_0 = VirtFuncInvoker0< String_t* >::Invoke(37 /* System.String System.Xml.XmlCharacterData::get_Data() */, __this);
		return L_0;
	}
}
// System.Void System.Xml.XmlWhitespace::set_Value(System.String)
extern "C"  void XmlWhitespace_set_Value_m2476864755 (XmlWhitespace_t2557770518 * __this, String_t* ___value0, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (XmlWhitespace_set_Value_m2476864755_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___value0;
		IL2CPP_RUNTIME_CLASS_INIT(XmlChar_t1369421061_il2cpp_TypeInfo_var);
		bool L_1 = XmlChar_IsWhitespace_m1819392135(NULL /*static, unused*/, L_0, /*hidden argument*/NULL);
		if (L_1)
		{
			goto IL_0016;
		}
	}
	{
		ArgumentException_t3259014390 * L_2 = (ArgumentException_t3259014390 *)il2cpp_codegen_object_new(ArgumentException_t3259014390_il2cpp_TypeInfo_var);
		ArgumentException__ctor_m3739475201(L_2, _stringLiteral3464576676, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2);
	}

IL_0016:
	{
		String_t* L_3 = ___value0;
		VirtActionInvoker1< String_t* >::Invoke(38 /* System.Void System.Xml.XmlCharacterData::set_Data(System.String) */, __this, L_3);
		return;
	}
}
// System.Xml.XmlNode System.Xml.XmlWhitespace::get_ParentNode()
extern "C"  XmlNode_t616554813 * XmlWhitespace_get_ParentNode_m1860633284 (XmlWhitespace_t2557770518 * __this, const MethodInfo* method)
{
	{
		XmlNode_t616554813 * L_0 = XmlNode_get_ParentNode_m1570967687(__this, /*hidden argument*/NULL);
		return L_0;
	}
}
// System.Xml.XmlNode System.Xml.XmlWhitespace::CloneNode(System.Boolean)
extern "C"  XmlNode_t616554813 * XmlWhitespace_CloneNode_m3071418885 (XmlWhitespace_t2557770518 * __this, bool ___deep0, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (XmlWhitespace_CloneNode_m3071418885_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = VirtFuncInvoker0< String_t* >::Invoke(37 /* System.String System.Xml.XmlCharacterData::get_Data() */, __this);
		XmlDocument_t3649534162 * L_1 = VirtFuncInvoker0< XmlDocument_t3649534162 * >::Invoke(20 /* System.Xml.XmlDocument System.Xml.XmlNode::get_OwnerDocument() */, __this);
		XmlWhitespace_t2557770518 * L_2 = (XmlWhitespace_t2557770518 *)il2cpp_codegen_object_new(XmlWhitespace_t2557770518_il2cpp_TypeInfo_var);
		XmlWhitespace__ctor_m674315191(L_2, L_0, L_1, /*hidden argument*/NULL);
		return L_2;
	}
}
// System.Void System.Xml.XmlWriter::.ctor()
extern "C"  void XmlWriter__ctor_m1775977623 (XmlWriter_t1048088568 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Xml.XmlWriter::System.IDisposable.Dispose()
extern "C"  void XmlWriter_System_IDisposable_Dispose_m1394995754 (XmlWriter_t1048088568 * __this, const MethodInfo* method)
{
	{
		VirtActionInvoker1< bool >::Invoke(8 /* System.Void System.Xml.XmlWriter::Dispose(System.Boolean) */, __this, (bool)0);
		return;
	}
}
// System.String System.Xml.XmlWriter::get_XmlLang()
extern "C"  String_t* XmlWriter_get_XmlLang_m2261918262 (XmlWriter_t1048088568 * __this, const MethodInfo* method)
{
	{
		return (String_t*)NULL;
	}
}
// System.Xml.XmlSpace System.Xml.XmlWriter::get_XmlSpace()
extern "C"  int32_t XmlWriter_get_XmlSpace_m867459849 (XmlWriter_t1048088568 * __this, const MethodInfo* method)
{
	{
		return (int32_t)(0);
	}
}
// System.Void System.Xml.XmlWriter::Dispose(System.Boolean)
extern "C"  void XmlWriter_Dispose_m4278548107 (XmlWriter_t1048088568 * __this, bool ___disposing0, const MethodInfo* method)
{
	{
		VirtActionInvoker0::Invoke(7 /* System.Void System.Xml.XmlWriter::Close() */, __this);
		return;
	}
}
// System.Void System.Xml.XmlWriter::WriteAttribute(System.Xml.XmlReader,System.Boolean)
extern "C"  void XmlWriter_WriteAttribute_m3300629885 (XmlWriter_t1048088568 * __this, XmlReader_t3675626668 * ___reader0, bool ___defattr1, const MethodInfo* method)
{
	int32_t V_0 = 0;
	{
		bool L_0 = ___defattr1;
		if (L_0)
		{
			goto IL_0012;
		}
	}
	{
		XmlReader_t3675626668 * L_1 = ___reader0;
		NullCheck(L_1);
		bool L_2 = VirtFuncInvoker0< bool >::Invoke(13 /* System.Boolean System.Xml.XmlReader::get_IsDefault() */, L_1);
		if (!L_2)
		{
			goto IL_0012;
		}
	}
	{
		return;
	}

IL_0012:
	{
		XmlReader_t3675626668 * L_3 = ___reader0;
		NullCheck(L_3);
		String_t* L_4 = VirtFuncInvoker0< String_t* >::Invoke(21 /* System.String System.Xml.XmlReader::get_Prefix() */, L_3);
		XmlReader_t3675626668 * L_5 = ___reader0;
		NullCheck(L_5);
		String_t* L_6 = VirtFuncInvoker0< String_t* >::Invoke(16 /* System.String System.Xml.XmlReader::get_LocalName() */, L_5);
		XmlReader_t3675626668 * L_7 = ___reader0;
		NullCheck(L_7);
		String_t* L_8 = VirtFuncInvoker0< String_t* >::Invoke(18 /* System.String System.Xml.XmlReader::get_NamespaceURI() */, L_7);
		VirtActionInvoker3< String_t*, String_t*, String_t* >::Invoke(19 /* System.Void System.Xml.XmlWriter::WriteStartAttribute(System.String,System.String,System.String) */, __this, L_4, L_6, L_8);
		goto IL_0071;
	}

IL_002f:
	{
		XmlReader_t3675626668 * L_9 = ___reader0;
		NullCheck(L_9);
		int32_t L_10 = VirtFuncInvoker0< int32_t >::Invoke(20 /* System.Xml.XmlNodeType System.Xml.XmlReader::get_NodeType() */, L_9);
		V_0 = L_10;
		int32_t L_11 = V_0;
		switch (((int32_t)((int32_t)L_11-(int32_t)3)))
		{
			case 0:
			{
				goto IL_004f;
			}
			case 1:
			{
				goto IL_0071;
			}
			case 2:
			{
				goto IL_0060;
			}
		}
	}
	{
		goto IL_0071;
	}

IL_004f:
	{
		XmlReader_t3675626668 * L_12 = ___reader0;
		NullCheck(L_12);
		String_t* L_13 = VirtFuncInvoker0< String_t* >::Invoke(25 /* System.String System.Xml.XmlReader::get_Value() */, L_12);
		VirtActionInvoker1< String_t* >::Invoke(21 /* System.Void System.Xml.XmlWriter::WriteString(System.String) */, __this, L_13);
		goto IL_0071;
	}

IL_0060:
	{
		XmlReader_t3675626668 * L_14 = ___reader0;
		NullCheck(L_14);
		String_t* L_15 = VirtFuncInvoker0< String_t* >::Invoke(17 /* System.String System.Xml.XmlReader::get_Name() */, L_14);
		VirtActionInvoker1< String_t* >::Invoke(15 /* System.Void System.Xml.XmlWriter::WriteEntityRef(System.String) */, __this, L_15);
		goto IL_0071;
	}

IL_0071:
	{
		XmlReader_t3675626668 * L_16 = ___reader0;
		NullCheck(L_16);
		bool L_17 = VirtFuncInvoker0< bool >::Invoke(41 /* System.Boolean System.Xml.XmlReader::ReadAttributeValue() */, L_16);
		if (L_17)
		{
			goto IL_002f;
		}
	}
	{
		VirtActionInvoker0::Invoke(13 /* System.Void System.Xml.XmlWriter::WriteEndAttribute() */, __this);
		return;
	}
}
// System.Void System.Xml.XmlWriter::WriteAttributeString(System.String,System.String)
extern "C"  void XmlWriter_WriteAttributeString_m3169493699 (XmlWriter_t1048088568 * __this, String_t* ___localName0, String_t* ___value1, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (XmlWriter_WriteAttributeString_m3169493699_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_0 = ((String_t_StaticFields*)String_t_il2cpp_TypeInfo_var->static_fields)->get_Empty_2();
		String_t* L_1 = ___localName0;
		String_t* L_2 = ___value1;
		XmlWriter_WriteAttributeString_m2741345027(__this, L_0, L_1, (String_t*)NULL, L_2, /*hidden argument*/NULL);
		return;
	}
}
// System.Void System.Xml.XmlWriter::WriteAttributeString(System.String,System.String,System.String,System.String)
extern "C"  void XmlWriter_WriteAttributeString_m2741345027 (XmlWriter_t1048088568 * __this, String_t* ___prefix0, String_t* ___localName1, String_t* ___ns2, String_t* ___value3, const MethodInfo* method)
{
	{
		String_t* L_0 = ___prefix0;
		String_t* L_1 = ___localName1;
		String_t* L_2 = ___ns2;
		VirtActionInvoker3< String_t*, String_t*, String_t* >::Invoke(19 /* System.Void System.Xml.XmlWriter::WriteStartAttribute(System.String,System.String,System.String) */, __this, L_0, L_1, L_2);
		String_t* L_3 = ___value3;
		if (!L_3)
		{
			goto IL_0025;
		}
	}
	{
		String_t* L_4 = ___value3;
		NullCheck(L_4);
		int32_t L_5 = String_get_Length_m1606060069(L_4, /*hidden argument*/NULL);
		if ((((int32_t)L_5) <= ((int32_t)0)))
		{
			goto IL_0025;
		}
	}
	{
		String_t* L_6 = ___value3;
		VirtActionInvoker1< String_t* >::Invoke(21 /* System.Void System.Xml.XmlWriter::WriteString(System.String) */, __this, L_6);
	}

IL_0025:
	{
		VirtActionInvoker0::Invoke(13 /* System.Void System.Xml.XmlWriter::WriteEndAttribute() */, __this);
		return;
	}
}
// System.Void System.Xml.XmlWriter::WriteElementString(System.String,System.String)
extern "C"  void XmlWriter_WriteElementString_m1467633369 (XmlWriter_t1048088568 * __this, String_t* ___localName0, String_t* ___value1, const MethodInfo* method)
{
	{
		String_t* L_0 = ___localName0;
		XmlWriter_WriteStartElement_m2103041358(__this, L_0, /*hidden argument*/NULL);
		String_t* L_1 = ___value1;
		if (!L_1)
		{
			goto IL_0020;
		}
	}
	{
		String_t* L_2 = ___value1;
		NullCheck(L_2);
		int32_t L_3 = String_get_Length_m1606060069(L_2, /*hidden argument*/NULL);
		if ((((int32_t)L_3) <= ((int32_t)0)))
		{
			goto IL_0020;
		}
	}
	{
		String_t* L_4 = ___value1;
		VirtActionInvoker1< String_t* >::Invoke(21 /* System.Void System.Xml.XmlWriter::WriteString(System.String) */, __this, L_4);
	}

IL_0020:
	{
		VirtActionInvoker0::Invoke(14 /* System.Void System.Xml.XmlWriter::WriteEndElement() */, __this);
		return;
	}
}
// System.Void System.Xml.XmlWriter::WriteNode(System.Xml.XmlReader,System.Boolean)
extern "C"  void XmlWriter_WriteNode_m1949395905 (XmlWriter_t1048088568 * __this, XmlReader_t3675626668 * ___reader0, bool ___defattr1, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (XmlWriter_WriteNode_m1949395905_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	{
		XmlReader_t3675626668 * L_0 = ___reader0;
		if (L_0)
		{
			goto IL_000c;
		}
	}
	{
		ArgumentException_t3259014390 * L_1 = (ArgumentException_t3259014390 *)il2cpp_codegen_object_new(ArgumentException_t3259014390_il2cpp_TypeInfo_var);
		ArgumentException__ctor_m2105824819(L_1, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1);
	}

IL_000c:
	{
		XmlReader_t3675626668 * L_2 = ___reader0;
		NullCheck(L_2);
		int32_t L_3 = VirtFuncInvoker0< int32_t >::Invoke(22 /* System.Xml.ReadState System.Xml.XmlReader::get_ReadState() */, L_2);
		if (L_3)
		{
			goto IL_0032;
		}
	}
	{
		XmlReader_t3675626668 * L_4 = ___reader0;
		NullCheck(L_4);
		VirtFuncInvoker0< bool >::Invoke(40 /* System.Boolean System.Xml.XmlReader::Read() */, L_4);
	}

IL_001e:
	{
		XmlReader_t3675626668 * L_5 = ___reader0;
		bool L_6 = ___defattr1;
		VirtActionInvoker2< XmlReader_t3675626668 *, bool >::Invoke(17 /* System.Void System.Xml.XmlWriter::WriteNode(System.Xml.XmlReader,System.Boolean) */, __this, L_5, L_6);
		XmlReader_t3675626668 * L_7 = ___reader0;
		NullCheck(L_7);
		bool L_8 = VirtFuncInvoker0< bool >::Invoke(9 /* System.Boolean System.Xml.XmlReader::get_EOF() */, L_7);
		if (!L_8)
		{
			goto IL_001e;
		}
	}
	{
		return;
	}

IL_0032:
	{
		XmlReader_t3675626668 * L_9 = ___reader0;
		NullCheck(L_9);
		int32_t L_10 = VirtFuncInvoker0< int32_t >::Invoke(20 /* System.Xml.XmlNodeType System.Xml.XmlReader::get_NodeType() */, L_9);
		V_2 = L_10;
		int32_t L_11 = V_2;
		switch (L_11)
		{
			case 0:
			{
				goto IL_01db;
			}
			case 1:
			{
				goto IL_008c;
			}
			case 2:
			{
				goto IL_012c;
			}
			case 3:
			{
				goto IL_012d;
			}
			case 4:
			{
				goto IL_013e;
			}
			case 5:
			{
				goto IL_014f;
			}
			case 6:
			{
				goto IL_01e0;
			}
			case 7:
			{
				goto IL_0160;
			}
			case 8:
			{
				goto IL_0177;
			}
			case 9:
			{
				goto IL_01e0;
			}
			case 10:
			{
				goto IL_0188;
			}
			case 11:
			{
				goto IL_01e0;
			}
			case 12:
			{
				goto IL_01e0;
			}
			case 13:
			{
				goto IL_01ba;
			}
			case 14:
			{
				goto IL_01b5;
			}
			case 15:
			{
				goto IL_01cb;
			}
			case 16:
			{
				goto IL_01d6;
			}
			case 17:
			{
				goto IL_0160;
			}
		}
	}
	{
		goto IL_01e0;
	}

IL_008c:
	{
		XmlReader_t3675626668 * L_12 = ___reader0;
		NullCheck(L_12);
		String_t* L_13 = VirtFuncInvoker0< String_t* >::Invoke(21 /* System.String System.Xml.XmlReader::get_Prefix() */, L_12);
		XmlReader_t3675626668 * L_14 = ___reader0;
		NullCheck(L_14);
		String_t* L_15 = VirtFuncInvoker0< String_t* >::Invoke(16 /* System.String System.Xml.XmlReader::get_LocalName() */, L_14);
		XmlReader_t3675626668 * L_16 = ___reader0;
		NullCheck(L_16);
		String_t* L_17 = VirtFuncInvoker0< String_t* >::Invoke(18 /* System.String System.Xml.XmlReader::get_NamespaceURI() */, L_16);
		VirtActionInvoker3< String_t*, String_t*, String_t* >::Invoke(20 /* System.Void System.Xml.XmlWriter::WriteStartElement(System.String,System.String,System.String) */, __this, L_13, L_15, L_17);
		XmlReader_t3675626668 * L_18 = ___reader0;
		NullCheck(L_18);
		bool L_19 = VirtFuncInvoker0< bool >::Invoke(10 /* System.Boolean System.Xml.XmlReader::get_HasAttributes() */, L_18);
		if (!L_19)
		{
			goto IL_00dc;
		}
	}
	{
		V_0 = 0;
		goto IL_00c9;
	}

IL_00b6:
	{
		XmlReader_t3675626668 * L_20 = ___reader0;
		int32_t L_21 = V_0;
		NullCheck(L_20);
		VirtActionInvoker1< int32_t >::Invoke(33 /* System.Void System.Xml.XmlReader::MoveToAttribute(System.Int32) */, L_20, L_21);
		XmlReader_t3675626668 * L_22 = ___reader0;
		bool L_23 = ___defattr1;
		XmlWriter_WriteAttribute_m3300629885(__this, L_22, L_23, /*hidden argument*/NULL);
		int32_t L_24 = V_0;
		V_0 = ((int32_t)((int32_t)L_24+(int32_t)1));
	}

IL_00c9:
	{
		int32_t L_25 = V_0;
		XmlReader_t3675626668 * L_26 = ___reader0;
		NullCheck(L_26);
		int32_t L_27 = VirtFuncInvoker0< int32_t >::Invoke(5 /* System.Int32 System.Xml.XmlReader::get_AttributeCount() */, L_26);
		if ((((int32_t)L_25) < ((int32_t)L_27)))
		{
			goto IL_00b6;
		}
	}
	{
		XmlReader_t3675626668 * L_28 = ___reader0;
		NullCheck(L_28);
		VirtFuncInvoker0< bool >::Invoke(37 /* System.Boolean System.Xml.XmlReader::MoveToElement() */, L_28);
	}

IL_00dc:
	{
		XmlReader_t3675626668 * L_29 = ___reader0;
		NullCheck(L_29);
		bool L_30 = VirtFuncInvoker0< bool >::Invoke(12 /* System.Boolean System.Xml.XmlReader::get_IsEmptyElement() */, L_29);
		if (!L_30)
		{
			goto IL_00f2;
		}
	}
	{
		VirtActionInvoker0::Invoke(14 /* System.Void System.Xml.XmlWriter::WriteEndElement() */, __this);
		goto IL_0127;
	}

IL_00f2:
	{
		XmlReader_t3675626668 * L_31 = ___reader0;
		NullCheck(L_31);
		int32_t L_32 = VirtFuncInvoker0< int32_t >::Invoke(8 /* System.Int32 System.Xml.XmlReader::get_Depth() */, L_31);
		V_1 = L_32;
		XmlReader_t3675626668 * L_33 = ___reader0;
		NullCheck(L_33);
		VirtFuncInvoker0< bool >::Invoke(40 /* System.Boolean System.Xml.XmlReader::Read() */, L_33);
		XmlReader_t3675626668 * L_34 = ___reader0;
		NullCheck(L_34);
		int32_t L_35 = VirtFuncInvoker0< int32_t >::Invoke(20 /* System.Xml.XmlNodeType System.Xml.XmlReader::get_NodeType() */, L_34);
		if ((((int32_t)L_35) == ((int32_t)((int32_t)15))))
		{
			goto IL_0121;
		}
	}

IL_010d:
	{
		XmlReader_t3675626668 * L_36 = ___reader0;
		bool L_37 = ___defattr1;
		VirtActionInvoker2< XmlReader_t3675626668 *, bool >::Invoke(17 /* System.Void System.Xml.XmlWriter::WriteNode(System.Xml.XmlReader,System.Boolean) */, __this, L_36, L_37);
		int32_t L_38 = V_1;
		XmlReader_t3675626668 * L_39 = ___reader0;
		NullCheck(L_39);
		int32_t L_40 = VirtFuncInvoker0< int32_t >::Invoke(8 /* System.Int32 System.Xml.XmlReader::get_Depth() */, L_39);
		if ((((int32_t)L_38) < ((int32_t)L_40)))
		{
			goto IL_010d;
		}
	}

IL_0121:
	{
		VirtActionInvoker0::Invoke(16 /* System.Void System.Xml.XmlWriter::WriteFullEndElement() */, __this);
	}

IL_0127:
	{
		goto IL_0218;
	}

IL_012c:
	{
		return;
	}

IL_012d:
	{
		XmlReader_t3675626668 * L_41 = ___reader0;
		NullCheck(L_41);
		String_t* L_42 = VirtFuncInvoker0< String_t* >::Invoke(25 /* System.String System.Xml.XmlReader::get_Value() */, L_41);
		VirtActionInvoker1< String_t* >::Invoke(21 /* System.Void System.Xml.XmlWriter::WriteString(System.String) */, __this, L_42);
		goto IL_0218;
	}

IL_013e:
	{
		XmlReader_t3675626668 * L_43 = ___reader0;
		NullCheck(L_43);
		String_t* L_44 = VirtFuncInvoker0< String_t* >::Invoke(25 /* System.String System.Xml.XmlReader::get_Value() */, L_43);
		VirtActionInvoker1< String_t* >::Invoke(10 /* System.Void System.Xml.XmlWriter::WriteCData(System.String) */, __this, L_44);
		goto IL_0218;
	}

IL_014f:
	{
		XmlReader_t3675626668 * L_45 = ___reader0;
		NullCheck(L_45);
		String_t* L_46 = VirtFuncInvoker0< String_t* >::Invoke(17 /* System.String System.Xml.XmlReader::get_Name() */, L_45);
		VirtActionInvoker1< String_t* >::Invoke(15 /* System.Void System.Xml.XmlWriter::WriteEntityRef(System.String) */, __this, L_46);
		goto IL_0218;
	}

IL_0160:
	{
		XmlReader_t3675626668 * L_47 = ___reader0;
		NullCheck(L_47);
		String_t* L_48 = VirtFuncInvoker0< String_t* >::Invoke(17 /* System.String System.Xml.XmlReader::get_Name() */, L_47);
		XmlReader_t3675626668 * L_49 = ___reader0;
		NullCheck(L_49);
		String_t* L_50 = VirtFuncInvoker0< String_t* >::Invoke(25 /* System.String System.Xml.XmlReader::get_Value() */, L_49);
		VirtActionInvoker2< String_t*, String_t* >::Invoke(18 /* System.Void System.Xml.XmlWriter::WriteProcessingInstruction(System.String,System.String) */, __this, L_48, L_50);
		goto IL_0218;
	}

IL_0177:
	{
		XmlReader_t3675626668 * L_51 = ___reader0;
		NullCheck(L_51);
		String_t* L_52 = VirtFuncInvoker0< String_t* >::Invoke(25 /* System.String System.Xml.XmlReader::get_Value() */, L_51);
		VirtActionInvoker1< String_t* >::Invoke(11 /* System.Void System.Xml.XmlWriter::WriteComment(System.String) */, __this, L_52);
		goto IL_0218;
	}

IL_0188:
	{
		XmlReader_t3675626668 * L_53 = ___reader0;
		NullCheck(L_53);
		String_t* L_54 = VirtFuncInvoker0< String_t* >::Invoke(17 /* System.String System.Xml.XmlReader::get_Name() */, L_53);
		XmlReader_t3675626668 * L_55 = ___reader0;
		NullCheck(L_55);
		String_t* L_56 = VirtFuncInvoker1< String_t*, String_t* >::Invoke(14 /* System.String System.Xml.XmlReader::get_Item(System.String) */, L_55, _stringLiteral2074996249);
		XmlReader_t3675626668 * L_57 = ___reader0;
		NullCheck(L_57);
		String_t* L_58 = VirtFuncInvoker1< String_t*, String_t* >::Invoke(14 /* System.String System.Xml.XmlReader::get_Item(System.String) */, L_57, _stringLiteral1111970457);
		XmlReader_t3675626668 * L_59 = ___reader0;
		NullCheck(L_59);
		String_t* L_60 = VirtFuncInvoker0< String_t* >::Invoke(25 /* System.String System.Xml.XmlReader::get_Value() */, L_59);
		VirtActionInvoker4< String_t*, String_t*, String_t*, String_t* >::Invoke(12 /* System.Void System.Xml.XmlWriter::WriteDocType(System.String,System.String,System.String,System.String) */, __this, L_54, L_56, L_58, L_60);
		goto IL_0218;
	}

IL_01b5:
	{
		goto IL_01ba;
	}

IL_01ba:
	{
		XmlReader_t3675626668 * L_61 = ___reader0;
		NullCheck(L_61);
		String_t* L_62 = VirtFuncInvoker0< String_t* >::Invoke(25 /* System.String System.Xml.XmlReader::get_Value() */, L_61);
		VirtActionInvoker1< String_t* >::Invoke(22 /* System.Void System.Xml.XmlWriter::WriteWhitespace(System.String) */, __this, L_62);
		goto IL_0218;
	}

IL_01cb:
	{
		VirtActionInvoker0::Invoke(16 /* System.Void System.Xml.XmlWriter::WriteFullEndElement() */, __this);
		goto IL_0218;
	}

IL_01d6:
	{
		goto IL_0218;
	}

IL_01db:
	{
		goto IL_0218;
	}

IL_01e0:
	{
		ObjectU5BU5D_t3614634134* L_63 = ((ObjectU5BU5D_t3614634134*)SZArrayNew(ObjectU5BU5D_t3614634134_il2cpp_TypeInfo_var, (uint32_t)4));
		NullCheck(L_63);
		ArrayElementTypeCheck (L_63, _stringLiteral160707941);
		(L_63)->SetAt(static_cast<il2cpp_array_size_t>(0), (Il2CppObject *)_stringLiteral160707941);
		ObjectU5BU5D_t3614634134* L_64 = L_63;
		XmlReader_t3675626668 * L_65 = ___reader0;
		NullCheck(L_65);
		String_t* L_66 = VirtFuncInvoker0< String_t* >::Invoke(17 /* System.String System.Xml.XmlReader::get_Name() */, L_65);
		NullCheck(L_64);
		ArrayElementTypeCheck (L_64, L_66);
		(L_64)->SetAt(static_cast<il2cpp_array_size_t>(1), (Il2CppObject *)L_66);
		ObjectU5BU5D_t3614634134* L_67 = L_64;
		NullCheck(L_67);
		ArrayElementTypeCheck (L_67, _stringLiteral2206509877);
		(L_67)->SetAt(static_cast<il2cpp_array_size_t>(2), (Il2CppObject *)_stringLiteral2206509877);
		ObjectU5BU5D_t3614634134* L_68 = L_67;
		XmlReader_t3675626668 * L_69 = ___reader0;
		NullCheck(L_69);
		int32_t L_70 = VirtFuncInvoker0< int32_t >::Invoke(20 /* System.Xml.XmlNodeType System.Xml.XmlReader::get_NodeType() */, L_69);
		int32_t L_71 = L_70;
		Il2CppObject * L_72 = Box(XmlNodeType_t739504597_il2cpp_TypeInfo_var, &L_71);
		NullCheck(L_68);
		ArrayElementTypeCheck (L_68, L_72);
		(L_68)->SetAt(static_cast<il2cpp_array_size_t>(3), (Il2CppObject *)L_72);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_73 = String_Concat_m3881798623(NULL /*static, unused*/, L_68, /*hidden argument*/NULL);
		XmlException_t4188277960 * L_74 = (XmlException_t4188277960 *)il2cpp_codegen_object_new(XmlException_t4188277960_il2cpp_TypeInfo_var);
		XmlException__ctor_m47652749(L_74, L_73, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_74);
	}

IL_0218:
	{
		XmlReader_t3675626668 * L_75 = ___reader0;
		NullCheck(L_75);
		VirtFuncInvoker0< bool >::Invoke(40 /* System.Boolean System.Xml.XmlReader::Read() */, L_75);
		return;
	}
}
// System.Void System.Xml.XmlWriter::WriteStartElement(System.String)
extern "C"  void XmlWriter_WriteStartElement_m2103041358 (XmlWriter_t1048088568 * __this, String_t* ___localName0, const MethodInfo* method)
{
	{
		String_t* L_0 = ___localName0;
		VirtActionInvoker3< String_t*, String_t*, String_t* >::Invoke(20 /* System.Void System.Xml.XmlWriter::WriteStartElement(System.String,System.String,System.String) */, __this, (String_t*)NULL, L_0, (String_t*)NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
