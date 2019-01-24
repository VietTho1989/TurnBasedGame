#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Signers.RandomDsaKCalculator
struct  RandomDsaKCalculator_t600049064  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Signers.RandomDsaKCalculator::q
	BigInteger_t4268922522 * ___q_0;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Signers.RandomDsaKCalculator::random
	SecureRandom_t3117234712 * ___random_1;

public:
	inline static int32_t get_offset_of_q_0() { return static_cast<int32_t>(offsetof(RandomDsaKCalculator_t600049064, ___q_0)); }
	inline BigInteger_t4268922522 * get_q_0() const { return ___q_0; }
	inline BigInteger_t4268922522 ** get_address_of_q_0() { return &___q_0; }
	inline void set_q_0(BigInteger_t4268922522 * value)
	{
		___q_0 = value;
		Il2CppCodeGenWriteBarrier(&___q_0, value);
	}

	inline static int32_t get_offset_of_random_1() { return static_cast<int32_t>(offsetof(RandomDsaKCalculator_t600049064, ___random_1)); }
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
