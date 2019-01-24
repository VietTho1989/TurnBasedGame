#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.ICipherParameters
struct ICipherParameters_t3082042576;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.ParametersWithRandom
struct  ParametersWithRandom_t16149445  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.ICipherParameters Org.BouncyCastle.Crypto.Parameters.ParametersWithRandom::parameters
	Il2CppObject * ___parameters_0;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Parameters.ParametersWithRandom::random
	SecureRandom_t3117234712 * ___random_1;

public:
	inline static int32_t get_offset_of_parameters_0() { return static_cast<int32_t>(offsetof(ParametersWithRandom_t16149445, ___parameters_0)); }
	inline Il2CppObject * get_parameters_0() const { return ___parameters_0; }
	inline Il2CppObject ** get_address_of_parameters_0() { return &___parameters_0; }
	inline void set_parameters_0(Il2CppObject * value)
	{
		___parameters_0 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_0, value);
	}

	inline static int32_t get_offset_of_random_1() { return static_cast<int32_t>(offsetof(ParametersWithRandom_t16149445, ___random_1)); }
	inline SecureRandom_t3117234712 * get_random_1() const { return ___random_1; }
	inline SecureRandom_t3117234712 ** get_address_of_random_1() { return &___random_1; }
	inline void set_random_1(SecureRandom_t3117234712 * value)
	{
		___random_1 = value;
		Il2CppCodeGenWriteBarrier(&___random_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
