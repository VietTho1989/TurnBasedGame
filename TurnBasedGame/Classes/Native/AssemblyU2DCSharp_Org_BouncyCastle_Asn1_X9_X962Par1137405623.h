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

// Org.BouncyCastle.Asn1.X9.X962Parameters
struct  X962Parameters_t1137405623  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.Asn1Object Org.BouncyCastle.Asn1.X9.X962Parameters::_params
	Asn1Object_t564283626 * ____params_2;

public:
	inline static int32_t get_offset_of__params_2() { return static_cast<int32_t>(offsetof(X962Parameters_t1137405623, ____params_2)); }
	inline Asn1Object_t564283626 * get__params_2() const { return ____params_2; }
	inline Asn1Object_t564283626 ** get_address_of__params_2() { return &____params_2; }
	inline void set__params_2(Asn1Object_t564283626 * value)
	{
		____params_2 = value;
		Il2CppCodeGenWriteBarrier(&____params_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
