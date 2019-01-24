#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml2.XmlTextReader/TagName
struct  TagName_t2340974457 
{
public:
	// System.String Mono.Xml2.XmlTextReader/TagName::Name
	String_t* ___Name_0;
	// System.String Mono.Xml2.XmlTextReader/TagName::LocalName
	String_t* ___LocalName_1;
	// System.String Mono.Xml2.XmlTextReader/TagName::Prefix
	String_t* ___Prefix_2;

public:
	inline static int32_t get_offset_of_Name_0() { return static_cast<int32_t>(offsetof(TagName_t2340974457, ___Name_0)); }
	inline String_t* get_Name_0() const { return ___Name_0; }
	inline String_t** get_address_of_Name_0() { return &___Name_0; }
	inline void set_Name_0(String_t* value)
	{
		___Name_0 = value;
		Il2CppCodeGenWriteBarrier(&___Name_0, value);
	}

	inline static int32_t get_offset_of_LocalName_1() { return static_cast<int32_t>(offsetof(TagName_t2340974457, ___LocalName_1)); }
	inline String_t* get_LocalName_1() const { return ___LocalName_1; }
	inline String_t** get_address_of_LocalName_1() { return &___LocalName_1; }
	inline void set_LocalName_1(String_t* value)
	{
		___LocalName_1 = value;
		Il2CppCodeGenWriteBarrier(&___LocalName_1, value);
	}

	inline static int32_t get_offset_of_Prefix_2() { return static_cast<int32_t>(offsetof(TagName_t2340974457, ___Prefix_2)); }
	inline String_t* get_Prefix_2() const { return ___Prefix_2; }
	inline String_t** get_address_of_Prefix_2() { return &___Prefix_2; }
	inline void set_Prefix_2(String_t* value)
	{
		___Prefix_2 = value;
		Il2CppCodeGenWriteBarrier(&___Prefix_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of Mono.Xml2.XmlTextReader/TagName
struct TagName_t2340974457_marshaled_pinvoke
{
	char* ___Name_0;
	char* ___LocalName_1;
	char* ___Prefix_2;
};
// Native definition for COM marshalling of Mono.Xml2.XmlTextReader/TagName
struct TagName_t2340974457_marshaled_com
{
	Il2CppChar* ___Name_0;
	Il2CppChar* ___LocalName_1;
	Il2CppChar* ___Prefix_2;
};
