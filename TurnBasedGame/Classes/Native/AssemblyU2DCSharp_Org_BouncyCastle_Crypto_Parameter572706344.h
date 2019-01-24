#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Paramete1064568751.h"

// Org.BouncyCastle.Math.EC.ECPoint
struct ECPoint_t626351532;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters
struct  ECPublicKeyParameters_t572706344  : public ECKeyParameters_t1064568751
{
public:
	// Org.BouncyCastle.Math.EC.ECPoint Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters::q
	ECPoint_t626351532 * ___q_5;

public:
	inline static int32_t get_offset_of_q_5() { return static_cast<int32_t>(offsetof(ECPublicKeyParameters_t572706344, ___q_5)); }
	inline ECPoint_t626351532 * get_q_5() const { return ___q_5; }
	inline ECPoint_t626351532 ** get_address_of_q_5() { return &___q_5; }
	inline void set_q_5(ECPoint_t626351532 * value)
	{
		___q_5 = value;
		Il2CppCodeGenWriteBarrier(&___q_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
