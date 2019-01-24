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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlParserContext/ContextItem
struct  ContextItem_t1262420678  : public Il2CppObject
{
public:
	// System.String System.Xml.XmlParserContext/ContextItem::BaseURI
	String_t* ___BaseURI_0;
	// System.String System.Xml.XmlParserContext/ContextItem::XmlLang
	String_t* ___XmlLang_1;
	// System.Xml.XmlSpace System.Xml.XmlParserContext/ContextItem::XmlSpace
	int32_t ___XmlSpace_2;

public:
	inline static int32_t get_offset_of_BaseURI_0() { return static_cast<int32_t>(offsetof(ContextItem_t1262420678, ___BaseURI_0)); }
	inline String_t* get_BaseURI_0() const { return ___BaseURI_0; }
	inline String_t** get_address_of_BaseURI_0() { return &___BaseURI_0; }
	inline void set_BaseURI_0(String_t* value)
	{
		___BaseURI_0 = value;
		Il2CppCodeGenWriteBarrier(&___BaseURI_0, value);
	}

	inline static int32_t get_offset_of_XmlLang_1() { return static_cast<int32_t>(offsetof(ContextItem_t1262420678, ___XmlLang_1)); }
	inline String_t* get_XmlLang_1() const { return ___XmlLang_1; }
	inline String_t** get_address_of_XmlLang_1() { return &___XmlLang_1; }
	inline void set_XmlLang_1(String_t* value)
	{
		___XmlLang_1 = value;
		Il2CppCodeGenWriteBarrier(&___XmlLang_1, value);
	}

	inline static int32_t get_offset_of_XmlSpace_2() { return static_cast<int32_t>(offsetof(ContextItem_t1262420678, ___XmlSpace_2)); }
	inline int32_t get_XmlSpace_2() const { return ___XmlSpace_2; }
	inline int32_t* get_address_of_XmlSpace_2() { return &___XmlSpace_2; }
	inline void set_XmlSpace_2(int32_t value)
	{
		___XmlSpace_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
