#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.KeyGenerationParameters
struct  KeyGenerationParameters_t650995725  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.KeyGenerationParameters::random
	SecureRandom_t3117234712 * ___random_0;
	// System.Int32 Org.BouncyCastle.Crypto.KeyGenerationParameters::strength
	int32_t ___strength_1;

public:
	inline static int32_t get_offset_of_random_0() { return static_cast<int32_t>(offsetof(KeyGenerationParameters_t650995725, ___random_0)); }
	inline SecureRandom_t3117234712 * get_random_0() const { return ___random_0; }
	inline SecureRandom_t3117234712 ** get_address_of_random_0() { return &___random_0; }
	inline void set_random_0(SecureRandom_t3117234712 * value)
	{
		___random_0 = value;
		Il2CppCodeGenWriteBarrier(&___random_0, value);
	}

	inline static int32_t get_offset_of_strength_1() { return static_cast<int32_t>(offsetof(KeyGenerationParameters_t650995725, ___strength_1)); }
	inline int32_t get_strength_1() const { return ___strength_1; }
	inline int32_t* get_address_of_strength_1() { return &___strength_1; }
	inline void set_strength_1(int32_t value)
	{
		___strength_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
