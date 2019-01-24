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

// Org.BouncyCastle.Crypto.Paddings.X923Padding
struct  X923Padding_t2660499907  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Paddings.X923Padding::random
	SecureRandom_t3117234712 * ___random_0;

public:
	inline static int32_t get_offset_of_random_0() { return static_cast<int32_t>(offsetof(X923Padding_t2660499907, ___random_0)); }
	inline SecureRandom_t3117234712 * get_random_0() const { return ___random_0; }
	inline SecureRandom_t3117234712 ** get_address_of_random_0() { return &___random_0; }
	inline void set_random_0(SecureRandom_t3117234712 * value)
	{
		___random_0 = value;
		Il2CppCodeGenWriteBarrier(&___random_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
