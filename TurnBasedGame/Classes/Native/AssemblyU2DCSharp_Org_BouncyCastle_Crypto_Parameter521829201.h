#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Paramete1164823134.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.Gost3410PublicKeyParameters
struct  Gost3410PublicKeyParameters_t521829201  : public Gost3410KeyParameters_t1164823134
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.Gost3410PublicKeyParameters::y
	BigInteger_t4268922522 * ___y_3;

public:
	inline static int32_t get_offset_of_y_3() { return static_cast<int32_t>(offsetof(Gost3410PublicKeyParameters_t521829201, ___y_3)); }
	inline BigInteger_t4268922522 * get_y_3() const { return ___y_3; }
	inline BigInteger_t4268922522 ** get_address_of_y_3() { return &___y_3; }
	inline void set_y_3(BigInteger_t4268922522 * value)
	{
		___y_3 = value;
		Il2CppCodeGenWriteBarrier(&___y_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
