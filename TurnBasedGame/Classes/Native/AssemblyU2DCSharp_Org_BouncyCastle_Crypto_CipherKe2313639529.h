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

// Org.BouncyCastle.Crypto.CipherKeyGenerator
struct  CipherKeyGenerator_t2313639529  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.CipherKeyGenerator::random
	SecureRandom_t3117234712 * ___random_0;
	// System.Int32 Org.BouncyCastle.Crypto.CipherKeyGenerator::strength
	int32_t ___strength_1;
	// System.Boolean Org.BouncyCastle.Crypto.CipherKeyGenerator::uninitialised
	bool ___uninitialised_2;
	// System.Int32 Org.BouncyCastle.Crypto.CipherKeyGenerator::defaultStrength
	int32_t ___defaultStrength_3;

public:
	inline static int32_t get_offset_of_random_0() { return static_cast<int32_t>(offsetof(CipherKeyGenerator_t2313639529, ___random_0)); }
	inline SecureRandom_t3117234712 * get_random_0() const { return ___random_0; }
	inline SecureRandom_t3117234712 ** get_address_of_random_0() { return &___random_0; }
	inline void set_random_0(SecureRandom_t3117234712 * value)
	{
		___random_0 = value;
		Il2CppCodeGenWriteBarrier(&___random_0, value);
	}

	inline static int32_t get_offset_of_strength_1() { return static_cast<int32_t>(offsetof(CipherKeyGenerator_t2313639529, ___strength_1)); }
	inline int32_t get_strength_1() const { return ___strength_1; }
	inline int32_t* get_address_of_strength_1() { return &___strength_1; }
	inline void set_strength_1(int32_t value)
	{
		___strength_1 = value;
	}

	inline static int32_t get_offset_of_uninitialised_2() { return static_cast<int32_t>(offsetof(CipherKeyGenerator_t2313639529, ___uninitialised_2)); }
	inline bool get_uninitialised_2() const { return ___uninitialised_2; }
	inline bool* get_address_of_uninitialised_2() { return &___uninitialised_2; }
	inline void set_uninitialised_2(bool value)
	{
		___uninitialised_2 = value;
	}

	inline static int32_t get_offset_of_defaultStrength_3() { return static_cast<int32_t>(offsetof(CipherKeyGenerator_t2313639529, ___defaultStrength_3)); }
	inline int32_t get_defaultStrength_3() const { return ___defaultStrength_3; }
	inline int32_t* get_address_of_defaultStrength_3() { return &___defaultStrength_3; }
	inline void set_defaultStrength_3(int32_t value)
	{
		___defaultStrength_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
