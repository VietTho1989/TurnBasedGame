#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Math.EC.ECPoint
struct ECPoint_t626351532;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X9.X9ECPoint
struct  X9ECPoint_t3031020555  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Math.EC.ECPoint Org.BouncyCastle.Asn1.X9.X9ECPoint::p
	ECPoint_t626351532 * ___p_2;

public:
	inline static int32_t get_offset_of_p_2() { return static_cast<int32_t>(offsetof(X9ECPoint_t3031020555, ___p_2)); }
	inline ECPoint_t626351532 * get_p_2() const { return ___p_2; }
	inline ECPoint_t626351532 ** get_address_of_p_2() { return &___p_2; }
	inline void set_p_2(ECPoint_t626351532 * value)
	{
		___p_2 = value;
		Il2CppCodeGenWriteBarrier(&___p_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
