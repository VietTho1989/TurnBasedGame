#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Paramete1064568751.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.ECPrivateKeyParameters
struct  ECPrivateKeyParameters_t3632960452  : public ECKeyParameters_t1064568751
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.ECPrivateKeyParameters::d
	BigInteger_t4268922522 * ___d_5;

public:
	inline static int32_t get_offset_of_d_5() { return static_cast<int32_t>(offsetof(ECPrivateKeyParameters_t3632960452, ___d_5)); }
	inline BigInteger_t4268922522 * get_d_5() const { return ___d_5; }
	inline BigInteger_t4268922522 ** get_address_of_d_5() { return &___d_5; }
	inline void set_d_5(BigInteger_t4268922522 * value)
	{
		___d_5 = value;
		Il2CppCodeGenWriteBarrier(&___d_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
