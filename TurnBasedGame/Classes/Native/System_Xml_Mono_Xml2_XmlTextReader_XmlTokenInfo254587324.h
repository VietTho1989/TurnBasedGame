#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_Xml_System_Xml_XmlNodeType739504597.h"

// System.String
struct String_t;
// Mono.Xml2.XmlTextReader
struct XmlTextReader_t511376973;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml2.XmlTextReader/XmlTokenInfo
struct  XmlTokenInfo_t254587324  : public Il2CppObject
{
public:
	// System.String Mono.Xml2.XmlTextReader/XmlTokenInfo::valueCache
	String_t* ___valueCache_0;
	// Mono.Xml2.XmlTextReader Mono.Xml2.XmlTextReader/XmlTokenInfo::Reader
	XmlTextReader_t511376973 * ___Reader_1;
	// System.String Mono.Xml2.XmlTextReader/XmlTokenInfo::Name
	String_t* ___Name_2;
	// System.String Mono.Xml2.XmlTextReader/XmlTokenInfo::LocalName
	String_t* ___LocalName_3;
	// System.String Mono.Xml2.XmlTextReader/XmlTokenInfo::Prefix
	String_t* ___Prefix_4;
	// System.String Mono.Xml2.XmlTextReader/XmlTokenInfo::NamespaceURI
	String_t* ___NamespaceURI_5;
	// System.Boolean Mono.Xml2.XmlTextReader/XmlTokenInfo::IsEmptyElement
	bool ___IsEmptyElement_6;
	// System.Char Mono.Xml2.XmlTextReader/XmlTokenInfo::QuoteChar
	Il2CppChar ___QuoteChar_7;
	// System.Int32 Mono.Xml2.XmlTextReader/XmlTokenInfo::LineNumber
	int32_t ___LineNumber_8;
	// System.Int32 Mono.Xml2.XmlTextReader/XmlTokenInfo::LinePosition
	int32_t ___LinePosition_9;
	// System.Int32 Mono.Xml2.XmlTextReader/XmlTokenInfo::ValueBufferStart
	int32_t ___ValueBufferStart_10;
	// System.Int32 Mono.Xml2.XmlTextReader/XmlTokenInfo::ValueBufferEnd
	int32_t ___ValueBufferEnd_11;
	// System.Xml.XmlNodeType Mono.Xml2.XmlTextReader/XmlTokenInfo::NodeType
	int32_t ___NodeType_12;

public:
	inline static int32_t get_offset_of_valueCache_0() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___valueCache_0)); }
	inline String_t* get_valueCache_0() const { return ___valueCache_0; }
	inline String_t** get_address_of_valueCache_0() { return &___valueCache_0; }
	inline void set_valueCache_0(String_t* value)
	{
		___valueCache_0 = value;
		Il2CppCodeGenWriteBarrier(&___valueCache_0, value);
	}

	inline static int32_t get_offset_of_Reader_1() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___Reader_1)); }
	inline XmlTextReader_t511376973 * get_Reader_1() const { return ___Reader_1; }
	inline XmlTextReader_t511376973 ** get_address_of_Reader_1() { return &___Reader_1; }
	inline void set_Reader_1(XmlTextReader_t511376973 * value)
	{
		___Reader_1 = value;
		Il2CppCodeGenWriteBarrier(&___Reader_1, value);
	}

	inline static int32_t get_offset_of_Name_2() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___Name_2)); }
	inline String_t* get_Name_2() const { return ___Name_2; }
	inline String_t** get_address_of_Name_2() { return &___Name_2; }
	inline void set_Name_2(String_t* value)
	{
		___Name_2 = value;
		Il2CppCodeGenWriteBarrier(&___Name_2, value);
	}

	inline static int32_t get_offset_of_LocalName_3() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___LocalName_3)); }
	inline String_t* get_LocalName_3() const { return ___LocalName_3; }
	inline String_t** get_address_of_LocalName_3() { return &___LocalName_3; }
	inline void set_LocalName_3(String_t* value)
	{
		___LocalName_3 = value;
		Il2CppCodeGenWriteBarrier(&___LocalName_3, value);
	}

	inline static int32_t get_offset_of_Prefix_4() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___Prefix_4)); }
	inline String_t* get_Prefix_4() const { return ___Prefix_4; }
	inline String_t** get_address_of_Prefix_4() { return &___Prefix_4; }
	inline void set_Prefix_4(String_t* value)
	{
		___Prefix_4 = value;
		Il2CppCodeGenWriteBarrier(&___Prefix_4, value);
	}

	inline static int32_t get_offset_of_NamespaceURI_5() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___NamespaceURI_5)); }
	inline String_t* get_NamespaceURI_5() const { return ___NamespaceURI_5; }
	inline String_t** get_address_of_NamespaceURI_5() { return &___NamespaceURI_5; }
	inline void set_NamespaceURI_5(String_t* value)
	{
		___NamespaceURI_5 = value;
		Il2CppCodeGenWriteBarrier(&___NamespaceURI_5, value);
	}

	inline static int32_t get_offset_of_IsEmptyElement_6() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___IsEmptyElement_6)); }
	inline bool get_IsEmptyElement_6() const { return ___IsEmptyElement_6; }
	inline bool* get_address_of_IsEmptyElement_6() { return &___IsEmptyElement_6; }
	inline void set_IsEmptyElement_6(bool value)
	{
		___IsEmptyElement_6 = value;
	}

	inline static int32_t get_offset_of_QuoteChar_7() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___QuoteChar_7)); }
	inline Il2CppChar get_QuoteChar_7() const { return ___QuoteChar_7; }
	inline Il2CppChar* get_address_of_QuoteChar_7() { return &___QuoteChar_7; }
	inline void set_QuoteChar_7(Il2CppChar value)
	{
		___QuoteChar_7 = value;
	}

	inline static int32_t get_offset_of_LineNumber_8() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___LineNumber_8)); }
	inline int32_t get_LineNumber_8() const { return ___LineNumber_8; }
	inline int32_t* get_address_of_LineNumber_8() { return &___LineNumber_8; }
	inline void set_LineNumber_8(int32_t value)
	{
		___LineNumber_8 = value;
	}

	inline static int32_t get_offset_of_LinePosition_9() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___LinePosition_9)); }
	inline int32_t get_LinePosition_9() const { return ___LinePosition_9; }
	inline int32_t* get_address_of_LinePosition_9() { return &___LinePosition_9; }
	inline void set_LinePosition_9(int32_t value)
	{
		___LinePosition_9 = value;
	}

	inline static int32_t get_offset_of_ValueBufferStart_10() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___ValueBufferStart_10)); }
	inline int32_t get_ValueBufferStart_10() const { return ___ValueBufferStart_10; }
	inline int32_t* get_address_of_ValueBufferStart_10() { return &___ValueBufferStart_10; }
	inline void set_ValueBufferStart_10(int32_t value)
	{
		___ValueBufferStart_10 = value;
	}

	inline static int32_t get_offset_of_ValueBufferEnd_11() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___ValueBufferEnd_11)); }
	inline int32_t get_ValueBufferEnd_11() const { return ___ValueBufferEnd_11; }
	inline int32_t* get_address_of_ValueBufferEnd_11() { return &___ValueBufferEnd_11; }
	inline void set_ValueBufferEnd_11(int32_t value)
	{
		___ValueBufferEnd_11 = value;
	}

	inline static int32_t get_offset_of_NodeType_12() { return static_cast<int32_t>(offsetof(XmlTokenInfo_t254587324, ___NodeType_12)); }
	inline int32_t get_NodeType_12() const { return ___NodeType_12; }
	inline int32_t* get_address_of_NodeType_12() { return &___NodeType_12; }
	inline void set_NodeType_12(int32_t value)
	{
		___NodeType_12 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
