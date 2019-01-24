#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Parameter508500971.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.DHPrivateKeyParameters
struct  DHPrivateKeyParameters_t3120746414  : public DHKeyParameters_t508500971
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.DHPrivateKeyParameters::x
	BigInteger_t4268922522 * ___x_3;

public:
	inline static int32_t get_offset_of_x_3() { return static_cast<int32_t>(offsetof(DHPrivateKeyParameters_t3120746414, ___x_3)); }
	inline BigInteger_t4268922522 * get_x_3() const { return ___x_3; }
	inline BigInteger_t4268922522 ** get_address_of_x_3() { return &___x_3; }
	inline void set_x_3(BigInteger_t4268922522 * value)
	{
		___x_3 = value;
		Il2CppCodeGenWriteBarrier(&___x_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
