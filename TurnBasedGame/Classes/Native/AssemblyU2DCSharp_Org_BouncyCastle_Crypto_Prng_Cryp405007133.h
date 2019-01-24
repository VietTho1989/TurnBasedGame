#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Security.Cryptography.RandomNumberGenerator
struct RandomNumberGenerator_t2510243513;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Prng.CryptoApiRandomGenerator
struct  CryptoApiRandomGenerator_t405007133  : public Il2CppObject
{
public:
	// System.Security.Cryptography.RandomNumberGenerator Org.BouncyCastle.Crypto.Prng.CryptoApiRandomGenerator::rndProv
	RandomNumberGenerator_t2510243513 * ___rndProv_0;

public:
	inline static int32_t get_offset_of_rndProv_0() { return static_cast<int32_t>(offsetof(CryptoApiRandomGenerator_t405007133, ___rndProv_0)); }
	inline RandomNumberGenerator_t2510243513 * get_rndProv_0() const { return ___rndProv_0; }
	inline RandomNumberGenerator_t2510243513 ** get_address_of_rndProv_0() { return &___rndProv_0; }
	inline void set_rndProv_0(RandomNumberGenerator_t2510243513 * value)
	{
		___rndProv_0 = value;
		Il2CppCodeGenWriteBarrier(&___rndProv_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
