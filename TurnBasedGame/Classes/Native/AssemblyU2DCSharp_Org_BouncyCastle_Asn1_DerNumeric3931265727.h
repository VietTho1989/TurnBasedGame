#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_DerStringB1343648701.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerNumericString
struct  DerNumericString_t3931265727  : public DerStringBase_t1343648701
{
public:
	// System.String Org.BouncyCastle.Asn1.DerNumericString::str
	String_t* ___str_2;

public:
	inline static int32_t get_offset_of_str_2() { return static_cast<int32_t>(offsetof(DerNumericString_t3931265727, ___str_2)); }
	inline String_t* get_str_2() const { return ___str_2; }
	inline String_t** get_address_of_str_2() { return &___str_2; }
	inline void set_str_2(String_t* value)
	{
		___str_2 = value;
		Il2CppCodeGenWriteBarrier(&___str_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
