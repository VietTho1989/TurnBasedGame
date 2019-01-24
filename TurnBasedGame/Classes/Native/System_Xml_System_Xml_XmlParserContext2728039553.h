#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_Xml_System_Xml_XmlSpace2880376877.h"

// System.String
struct String_t;
// System.Text.Encoding
struct Encoding_t663144255;
// System.Xml.XmlNamespaceManager
struct XmlNamespaceManager_t486731501;
// System.Xml.XmlNameTable
struct XmlNameTable_t1345805268;
// System.Collections.ArrayList
struct ArrayList_t4252133567;
// Mono.Xml.DTDObjectModel
struct DTDObjectModel_t1113953282;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlParserContext
struct  XmlParserContext_t2728039553  : public Il2CppObject
{
public:
	// System.String System.Xml.XmlParserContext::baseURI
	String_t* ___baseURI_0;
	// System.String System.Xml.XmlParserContext::docTypeName
	String_t* ___docTypeName_1;
	// System.Text.Encoding System.Xml.XmlParserContext::encoding
	Encoding_t663144255 * ___encoding_2;
	// System.String System.Xml.XmlParserContext::internalSubset
	String_t* ___internalSubset_3;
	// System.Xml.XmlNamespaceManager System.Xml.XmlParserContext::namespaceManager
	XmlNamespaceManager_t486731501 * ___namespaceManager_4;
	// System.Xml.XmlNameTable System.Xml.XmlParserContext::nameTable
	XmlNameTable_t1345805268 * ___nameTable_5;
	// System.String System.Xml.XmlParserContext::publicID
	String_t* ___publicID_6;
	// System.String System.Xml.XmlParserContext::systemID
	String_t* ___systemID_7;
	// System.String System.Xml.XmlParserContext::xmlLang
	String_t* ___xmlLang_8;
	// System.Xml.XmlSpace System.Xml.XmlParserContext::xmlSpace
	int32_t ___xmlSpace_9;
	// System.Collections.ArrayList System.Xml.XmlParserContext::contextItems
	ArrayList_t4252133567 * ___contextItems_10;
	// System.Int32 System.Xml.XmlParserContext::contextItemCount
	int32_t ___contextItemCount_11;
	// Mono.Xml.DTDObjectModel System.Xml.XmlParserContext::dtd
	DTDObjectModel_t1113953282 * ___dtd_12;

public:
	inline static int32_t get_offset_of_baseURI_0() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___baseURI_0)); }
	inline String_t* get_baseURI_0() const { return ___baseURI_0; }
	inline String_t** get_address_of_baseURI_0() { return &___baseURI_0; }
	inline void set_baseURI_0(String_t* value)
	{
		___baseURI_0 = value;
		Il2CppCodeGenWriteBarrier(&___baseURI_0, value);
	}

	inline static int32_t get_offset_of_docTypeName_1() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___docTypeName_1)); }
	inline String_t* get_docTypeName_1() const { return ___docTypeName_1; }
	inline String_t** get_address_of_docTypeName_1() { return &___docTypeName_1; }
	inline void set_docTypeName_1(String_t* value)
	{
		___docTypeName_1 = value;
		Il2CppCodeGenWriteBarrier(&___docTypeName_1, value);
	}

	inline static int32_t get_offset_of_encoding_2() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___encoding_2)); }
	inline Encoding_t663144255 * get_encoding_2() const { return ___encoding_2; }
	inline Encoding_t663144255 ** get_address_of_encoding_2() { return &___encoding_2; }
	inline void set_encoding_2(Encoding_t663144255 * value)
	{
		___encoding_2 = value;
		Il2CppCodeGenWriteBarrier(&___encoding_2, value);
	}

	inline static int32_t get_offset_of_internalSubset_3() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___internalSubset_3)); }
	inline String_t* get_internalSubset_3() const { return ___internalSubset_3; }
	inline String_t** get_address_of_internalSubset_3() { return &___internalSubset_3; }
	inline void set_internalSubset_3(String_t* value)
	{
		___internalSubset_3 = value;
		Il2CppCodeGenWriteBarrier(&___internalSubset_3, value);
	}

	inline static int32_t get_offset_of_namespaceManager_4() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___namespaceManager_4)); }
	inline XmlNamespaceManager_t486731501 * get_namespaceManager_4() const { return ___namespaceManager_4; }
	inline XmlNamespaceManager_t486731501 ** get_address_of_namespaceManager_4() { return &___namespaceManager_4; }
	inline void set_namespaceManager_4(XmlNamespaceManager_t486731501 * value)
	{
		___namespaceManager_4 = value;
		Il2CppCodeGenWriteBarrier(&___namespaceManager_4, value);
	}

	inline static int32_t get_offset_of_nameTable_5() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___nameTable_5)); }
	inline XmlNameTable_t1345805268 * get_nameTable_5() const { return ___nameTable_5; }
	inline XmlNameTable_t1345805268 ** get_address_of_nameTable_5() { return &___nameTable_5; }
	inline void set_nameTable_5(XmlNameTable_t1345805268 * value)
	{
		___nameTable_5 = value;
		Il2CppCodeGenWriteBarrier(&___nameTable_5, value);
	}

	inline static int32_t get_offset_of_publicID_6() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___publicID_6)); }
	inline String_t* get_publicID_6() const { return ___publicID_6; }
	inline String_t** get_address_of_publicID_6() { return &___publicID_6; }
	inline void set_publicID_6(String_t* value)
	{
		___publicID_6 = value;
		Il2CppCodeGenWriteBarrier(&___publicID_6, value);
	}

	inline static int32_t get_offset_of_systemID_7() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___systemID_7)); }
	inline String_t* get_systemID_7() const { return ___systemID_7; }
	inline String_t** get_address_of_systemID_7() { return &___systemID_7; }
	inline void set_systemID_7(String_t* value)
	{
		___systemID_7 = value;
		Il2CppCodeGenWriteBarrier(&___systemID_7, value);
	}

	inline static int32_t get_offset_of_xmlLang_8() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___xmlLang_8)); }
	inline String_t* get_xmlLang_8() const { return ___xmlLang_8; }
	inline String_t** get_address_of_xmlLang_8() { return &___xmlLang_8; }
	inline void set_xmlLang_8(String_t* value)
	{
		___xmlLang_8 = value;
		Il2CppCodeGenWriteBarrier(&___xmlLang_8, value);
	}

	inline static int32_t get_offset_of_xmlSpace_9() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___xmlSpace_9)); }
	inline int32_t get_xmlSpace_9() const { return ___xmlSpace_9; }
	inline int32_t* get_address_of_xmlSpace_9() { return &___xmlSpace_9; }
	inline void set_xmlSpace_9(int32_t value)
	{
		___xmlSpace_9 = value;
	}

	inline static int32_t get_offset_of_contextItems_10() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___contextItems_10)); }
	inline ArrayList_t4252133567 * get_contextItems_10() const { return ___contextItems_10; }
	inline ArrayList_t4252133567 ** get_address_of_contextItems_10() { return &___contextItems_10; }
	inline void set_contextItems_10(ArrayList_t4252133567 * value)
	{
		___contextItems_10 = value;
		Il2CppCodeGenWriteBarrier(&___contextItems_10, value);
	}

	inline static int32_t get_offset_of_contextItemCount_11() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___contextItemCount_11)); }
	inline int32_t get_contextItemCount_11() const { return ___contextItemCount_11; }
	inline int32_t* get_address_of_contextItemCount_11() { return &___contextItemCount_11; }
	inline void set_contextItemCount_11(int32_t value)
	{
		___contextItemCount_11 = value;
	}

	inline static int32_t get_offset_of_dtd_12() { return static_cast<int32_t>(offsetof(XmlParserContext_t2728039553, ___dtd_12)); }
	inline DTDObjectModel_t1113953282 * get_dtd_12() const { return ___dtd_12; }
	inline DTDObjectModel_t1113953282 ** get_address_of_dtd_12() { return &___dtd_12; }
	inline void set_dtd_12(DTDObjectModel_t1113953282 * value)
	{
		___dtd_12 = value;
		Il2CppCodeGenWriteBarrier(&___dtd_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
