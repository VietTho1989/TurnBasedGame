#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlNameEntry
struct  XmlNameEntry_t3745551716  : public Il2CppObject
{
public:
	// System.String System.Xml.XmlNameEntry::Prefix
	String_t* ___Prefix_0;
	// System.String System.Xml.XmlNameEntry::LocalName
	String_t* ___LocalName_1;
	// System.String System.Xml.XmlNameEntry::NS
	String_t* ___NS_2;
	// System.Int32 System.Xml.XmlNameEntry::Hash
	int32_t ___Hash_3;
	// System.String System.Xml.XmlNameEntry::prefixed_name_cache
	String_t* ___prefixed_name_cache_4;

public:
	inline static int32_t get_offset_of_Prefix_0() { return static_cast<int32_t>(offsetof(XmlNameEntry_t3745551716, ___Prefix_0)); }
	inline String_t* get_Prefix_0() const { return ___Prefix_0; }
	inline String_t** get_address_of_Prefix_0() { return &___Prefix_0; }
	inline void set_Prefix_0(String_t* value)
	{
		___Prefix_0 = value;
		Il2CppCodeGenWriteBarrier(&___Prefix_0, value);
	}

	inline static int32_t get_offset_of_LocalName_1() { return static_cast<int32_t>(offsetof(XmlNameEntry_t3745551716, ___LocalName_1)); }
	inline String_t* get_LocalName_1() const { return ___LocalName_1; }
	inline String_t** get_address_of_LocalName_1() { return &___LocalName_1; }
	inline void set_LocalName_1(String_t* value)
	{
		___LocalName_1 = value;
		Il2CppCodeGenWriteBarrier(&___LocalName_1, value);
	}

	inline static int32_t get_offset_of_NS_2() { return static_cast<int32_t>(offsetof(XmlNameEntry_t3745551716, ___NS_2)); }
	inline String_t* get_NS_2() const { return ___NS_2; }
	inline String_t** get_address_of_NS_2() { return &___NS_2; }
	inline void set_NS_2(String_t* value)
	{
		___NS_2 = value;
		Il2CppCodeGenWriteBarrier(&___NS_2, value);
	}

	inline static int32_t get_offset_of_Hash_3() { return static_cast<int32_t>(offsetof(XmlNameEntry_t3745551716, ___Hash_3)); }
	inline int32_t get_Hash_3() const { return ___Hash_3; }
	inline int32_t* get_address_of_Hash_3() { return &___Hash_3; }
	inline void set_Hash_3(int32_t value)
	{
		___Hash_3 = value;
	}

	inline static int32_t get_offset_of_prefixed_name_cache_4() { return static_cast<int32_t>(offsetof(XmlNameEntry_t3745551716, ___prefixed_name_cache_4)); }
	inline String_t* get_prefixed_name_cache_4() const { return ___prefixed_name_cache_4; }
	inline String_t** get_address_of_prefixed_name_cache_4() { return &___prefixed_name_cache_4; }
	inline void set_prefixed_name_cache_4(String_t* value)
	{
		___prefixed_name_cache_4 = value;
		Il2CppCodeGenWriteBarrier(&___prefixed_name_cache_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
