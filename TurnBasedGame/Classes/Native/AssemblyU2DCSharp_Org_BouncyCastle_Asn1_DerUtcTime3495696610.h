#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Object564283626.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerUtcTime
struct  DerUtcTime_t3495696610  : public Asn1Object_t564283626
{
public:
	// System.String Org.BouncyCastle.Asn1.DerUtcTime::time
	String_t* ___time_2;

public:
	inline static int32_t get_offset_of_time_2() { return static_cast<int32_t>(offsetof(DerUtcTime_t3495696610, ___time_2)); }
	inline String_t* get_time_2() const { return ___time_2; }
	inline String_t** get_address_of_time_2() { return &___time_2; }
	inline void set_time_2(String_t* value)
	{
		___time_2 = value;
		Il2CppCodeGenWriteBarrier(&___time_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
