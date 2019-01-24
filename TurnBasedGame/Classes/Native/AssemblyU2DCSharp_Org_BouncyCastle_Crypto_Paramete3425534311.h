#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Asymmetr1663727050.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters
struct  RsaKeyParameters_t3425534311  : public AsymmetricKeyParameter_t1663727050
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters::modulus
	BigInteger_t4268922522 * ___modulus_1;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters::exponent
	BigInteger_t4268922522 * ___exponent_2;

public:
	inline static int32_t get_offset_of_modulus_1() { return static_cast<int32_t>(offsetof(RsaKeyParameters_t3425534311, ___modulus_1)); }
	inline BigInteger_t4268922522 * get_modulus_1() const { return ___modulus_1; }
	inline BigInteger_t4268922522 ** get_address_of_modulus_1() { return &___modulus_1; }
	inline void set_modulus_1(BigInteger_t4268922522 * value)
	{
		___modulus_1 = value;
		Il2CppCodeGenWriteBarrier(&___modulus_1, value);
	}

	inline static int32_t get_offset_of_exponent_2() { return static_cast<int32_t>(offsetof(RsaKeyParameters_t3425534311, ___exponent_2)); }
	inline BigInteger_t4268922522 * get_exponent_2() const { return ___exponent_2; }
	inline BigInteger_t4268922522 ** get_address_of_exponent_2() { return &___exponent_2; }
	inline void set_exponent_2(BigInteger_t4268922522 * value)
	{
		___exponent_2 = value;
		Il2CppCodeGenWriteBarrier(&___exponent_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
