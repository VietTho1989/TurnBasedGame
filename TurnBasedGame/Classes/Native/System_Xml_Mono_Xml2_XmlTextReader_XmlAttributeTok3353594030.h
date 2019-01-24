#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_Mono_Xml2_XmlTextReader_XmlTokenInfo254587324.h"

// System.String
struct String_t;
// System.Text.StringBuilder
struct StringBuilder_t1221177846;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml2.XmlTextReader/XmlAttributeTokenInfo
struct  XmlAttributeTokenInfo_t3353594030  : public XmlTokenInfo_t254587324
{
public:
	// System.Int32 Mono.Xml2.XmlTextReader/XmlAttributeTokenInfo::ValueTokenStartIndex
	int32_t ___ValueTokenStartIndex_13;
	// System.Int32 Mono.Xml2.XmlTextReader/XmlAttributeTokenInfo::ValueTokenEndIndex
	int32_t ___ValueTokenEndIndex_14;
	// System.String Mono.Xml2.XmlTextReader/XmlAttributeTokenInfo::valueCache
	String_t* ___valueCache_15;
	// System.Text.StringBuilder Mono.Xml2.XmlTextReader/XmlAttributeTokenInfo::tmpBuilder
	StringBuilder_t1221177846 * ___tmpBuilder_16;

public:
	inline static int32_t get_offset_of_ValueTokenStartIndex_13() { return static_cast<int32_t>(offsetof(XmlAttributeTokenInfo_t3353594030, ___ValueTokenStartIndex_13)); }
	inline int32_t get_ValueTokenStartIndex_13() const { return ___ValueTokenStartIndex_13; }
	inline int32_t* get_address_of_ValueTokenStartIndex_13() { return &___ValueTokenStartIndex_13; }
	inline void set_ValueTokenStartIndex_13(int32_t value)
	{
		___ValueTokenStartIndex_13 = value;
	}

	inline static int32_t get_offset_of_ValueTokenEndIndex_14() { return static_cast<int32_t>(offsetof(XmlAttributeTokenInfo_t3353594030, ___ValueTokenEndIndex_14)); }
	inline int32_t get_ValueTokenEndIndex_14() const { return ___ValueTokenEndIndex_14; }
	inline int32_t* get_address_of_ValueTokenEndIndex_14() { return &___ValueTokenEndIndex_14; }
	inline void set_ValueTokenEndIndex_14(int32_t value)
	{
		___ValueTokenEndIndex_14 = value;
	}

	inline static int32_t get_offset_of_valueCache_15() { return static_cast<int32_t>(offsetof(XmlAttributeTokenInfo_t3353594030, ___valueCache_15)); }
	inline String_t* get_valueCache_15() const { return ___valueCache_15; }
	inline String_t** get_address_of_valueCache_15() { return &___valueCache_15; }
	inline void set_valueCache_15(String_t* value)
	{
		___valueCache_15 = value;
		Il2CppCodeGenWriteBarrier(&___valueCache_15, value);
	}

	inline static int32_t get_offset_of_tmpBuilder_16() { return static_cast<int32_t>(offsetof(XmlAttributeTokenInfo_t3353594030, ___tmpBuilder_16)); }
	inline StringBuilder_t1221177846 * get_tmpBuilder_16() const { return ___tmpBuilder_16; }
	inline StringBuilder_t1221177846 ** get_address_of_tmpBuilder_16() { return &___tmpBuilder_16; }
	inline void set_tmpBuilder_16(StringBuilder_t1221177846 * value)
	{
		___tmpBuilder_16 = value;
		Il2CppCodeGenWriteBarrier(&___tmpBuilder_16, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
