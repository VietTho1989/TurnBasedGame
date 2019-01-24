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

// Org.BouncyCastle.Asn1.OidTokenizer
struct  OidTokenizer_t1891371977  : public Il2CppObject
{
public:
	// System.String Org.BouncyCastle.Asn1.OidTokenizer::oid
	String_t* ___oid_0;
	// System.Int32 Org.BouncyCastle.Asn1.OidTokenizer::index
	int32_t ___index_1;

public:
	inline static int32_t get_offset_of_oid_0() { return static_cast<int32_t>(offsetof(OidTokenizer_t1891371977, ___oid_0)); }
	inline String_t* get_oid_0() const { return ___oid_0; }
	inline String_t** get_address_of_oid_0() { return &___oid_0; }
	inline void set_oid_0(String_t* value)
	{
		___oid_0 = value;
		Il2CppCodeGenWriteBarrier(&___oid_0, value);
	}

	inline static int32_t get_offset_of_index_1() { return static_cast<int32_t>(offsetof(OidTokenizer_t1891371977, ___index_1)); }
	inline int32_t get_index_1() const { return ___index_1; }
	inline int32_t* get_address_of_index_1() { return &___index_1; }
	inline void set_index_1(int32_t value)
	{
		___index_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
