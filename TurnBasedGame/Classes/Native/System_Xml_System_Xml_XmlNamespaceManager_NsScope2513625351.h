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

// System.Xml.XmlNamespaceManager/NsScope
struct  NsScope_t2513625351 
{
public:
	// System.Int32 System.Xml.XmlNamespaceManager/NsScope::DeclCount
	int32_t ___DeclCount_0;
	// System.String System.Xml.XmlNamespaceManager/NsScope::DefaultNamespace
	String_t* ___DefaultNamespace_1;

public:
	inline static int32_t get_offset_of_DeclCount_0() { return static_cast<int32_t>(offsetof(NsScope_t2513625351, ___DeclCount_0)); }
	inline int32_t get_DeclCount_0() const { return ___DeclCount_0; }
	inline int32_t* get_address_of_DeclCount_0() { return &___DeclCount_0; }
	inline void set_DeclCount_0(int32_t value)
	{
		___DeclCount_0 = value;
	}

	inline static int32_t get_offset_of_DefaultNamespace_1() { return static_cast<int32_t>(offsetof(NsScope_t2513625351, ___DefaultNamespace_1)); }
	inline String_t* get_DefaultNamespace_1() const { return ___DefaultNamespace_1; }
	inline String_t** get_address_of_DefaultNamespace_1() { return &___DefaultNamespace_1; }
	inline void set_DefaultNamespace_1(String_t* value)
	{
		___DefaultNamespace_1 = value;
		Il2CppCodeGenWriteBarrier(&___DefaultNamespace_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Xml.XmlNamespaceManager/NsScope
struct NsScope_t2513625351_marshaled_pinvoke
{
	int32_t ___DeclCount_0;
	char* ___DefaultNamespace_1;
};
// Native definition for COM marshalling of System.Xml.XmlNamespaceManager/NsScope
struct NsScope_t2513625351_marshaled_com
{
	int32_t ___DeclCount_0;
	Il2CppChar* ___DefaultNamespace_1;
};
