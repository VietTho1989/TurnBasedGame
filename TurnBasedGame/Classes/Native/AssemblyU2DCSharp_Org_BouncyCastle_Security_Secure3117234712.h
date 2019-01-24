#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Random1044426839.h"

// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;
// Org.BouncyCastle.Crypto.Prng.IRandomGenerator
struct IRandomGenerator_t860704147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Security.SecureRandom
struct  SecureRandom_t3117234712  : public Random_t1044426839
{
public:
	// Org.BouncyCastle.Crypto.Prng.IRandomGenerator Org.BouncyCastle.Security.SecureRandom::generator
	Il2CppObject * ___generator_5;

public:
	inline static int32_t get_offset_of_generator_5() { return static_cast<int32_t>(offsetof(SecureRandom_t3117234712, ___generator_5)); }
	inline Il2CppObject * get_generator_5() const { return ___generator_5; }
	inline Il2CppObject ** get_address_of_generator_5() { return &___generator_5; }
	inline void set_generator_5(Il2CppObject * value)
	{
		___generator_5 = value;
		Il2CppCodeGenWriteBarrier(&___generator_5, value);
	}
};

struct SecureRandom_t3117234712_StaticFields
{
public:
	// System.Int64 Org.BouncyCastle.Security.SecureRandom::counter
	int64_t ___counter_3;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Security.SecureRandom::master
	SecureRandom_t3117234712 * ___master_4;
	// System.Double Org.BouncyCastle.Security.SecureRandom::DoubleScale
	double ___DoubleScale_6;

public:
	inline static int32_t get_offset_of_counter_3() { return static_cast<int32_t>(offsetof(SecureRandom_t3117234712_StaticFields, ___counter_3)); }
	inline int64_t get_counter_3() const { return ___counter_3; }
	inline int64_t* get_address_of_counter_3() { return &___counter_3; }
	inline void set_counter_3(int64_t value)
	{
		___counter_3 = value;
	}

	inline static int32_t get_offset_of_master_4() { return static_cast<int32_t>(offsetof(SecureRandom_t3117234712_StaticFields, ___master_4)); }
	inline SecureRandom_t3117234712 * get_master_4() const { return ___master_4; }
	inline SecureRandom_t3117234712 ** get_address_of_master_4() { return &___master_4; }
	inline void set_master_4(SecureRandom_t3117234712 * value)
	{
		___master_4 = value;
		Il2CppCodeGenWriteBarrier(&___master_4, value);
	}

	inline static int32_t get_offset_of_DoubleScale_6() { return static_cast<int32_t>(offsetof(SecureRandom_t3117234712_StaticFields, ___DoubleScale_6)); }
	inline double get_DoubleScale_6() const { return ___DoubleScale_6; }
	inline double* get_address_of_DoubleScale_6() { return &___DoubleScale_6; }
	inline void set_DoubleScale_6(double value)
	{
		___DoubleScale_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
