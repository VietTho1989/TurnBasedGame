#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Parameter352675504.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.ElGamalPublicKeyParameters
struct  ElGamalPublicKeyParameters_t3740889069  : public ElGamalKeyParameters_t352675504
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.ElGamalPublicKeyParameters::y
	BigInteger_t4268922522 * ___y_2;

public:
	inline static int32_t get_offset_of_y_2() { return static_cast<int32_t>(offsetof(ElGamalPublicKeyParameters_t3740889069, ___y_2)); }
	inline BigInteger_t4268922522 * get_y_2() const { return ___y_2; }
	inline BigInteger_t4268922522 ** get_address_of_y_2() { return &___y_2; }
	inline void set_y_2(BigInteger_t4268922522 * value)
	{
		___y_2 = value;
		Il2CppCodeGenWriteBarrier(&___y_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
