#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_KeyGenera650995725.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.RsaKeyGenerationParameters
struct  RsaKeyGenerationParameters_t2592312329  : public KeyGenerationParameters_t650995725
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.RsaKeyGenerationParameters::publicExponent
	BigInteger_t4268922522 * ___publicExponent_2;
	// System.Int32 Org.BouncyCastle.Crypto.Parameters.RsaKeyGenerationParameters::certainty
	int32_t ___certainty_3;

public:
	inline static int32_t get_offset_of_publicExponent_2() { return static_cast<int32_t>(offsetof(RsaKeyGenerationParameters_t2592312329, ___publicExponent_2)); }
	inline BigInteger_t4268922522 * get_publicExponent_2() const { return ___publicExponent_2; }
	inline BigInteger_t4268922522 ** get_address_of_publicExponent_2() { return &___publicExponent_2; }
	inline void set_publicExponent_2(BigInteger_t4268922522 * value)
	{
		___publicExponent_2 = value;
		Il2CppCodeGenWriteBarrier(&___publicExponent_2, value);
	}

	inline static int32_t get_offset_of_certainty_3() { return static_cast<int32_t>(offsetof(RsaKeyGenerationParameters_t2592312329, ___certainty_3)); }
	inline int32_t get_certainty_3() const { return ___certainty_3; }
	inline int32_t* get_address_of_certainty_3() { return &___certainty_3; }
	inline void set_certainty_3(int32_t value)
	{
		___certainty_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
