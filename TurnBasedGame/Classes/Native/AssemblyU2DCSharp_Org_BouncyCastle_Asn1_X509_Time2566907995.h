#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.Asn1Object
struct Asn1Object_t564283626;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.Time
struct  Time_t2566907995  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.Asn1Object Org.BouncyCastle.Asn1.X509.Time::time
	Asn1Object_t564283626 * ___time_2;

public:
	inline static int32_t get_offset_of_time_2() { return static_cast<int32_t>(offsetof(Time_t2566907995, ___time_2)); }
	inline Asn1Object_t564283626 * get_time_2() const { return ___time_2; }
	inline Asn1Object_t564283626 ** get_address_of_time_2() { return &___time_2; }
	inline void set_time_2(Asn1Object_t564283626 * value)
	{
		___time_2 = value;
		Il2CppCodeGenWriteBarrier(&___time_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
