#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters
struct RsaKeyParameters_t3425534311;
// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.RsaBlindingParameters
struct  RsaBlindingParameters_t2682613251  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters Org.BouncyCastle.Crypto.Parameters.RsaBlindingParameters::publicKey
	RsaKeyParameters_t3425534311 * ___publicKey_0;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.RsaBlindingParameters::blindingFactor
	BigInteger_t4268922522 * ___blindingFactor_1;

public:
	inline static int32_t get_offset_of_publicKey_0() { return static_cast<int32_t>(offsetof(RsaBlindingParameters_t2682613251, ___publicKey_0)); }
	inline RsaKeyParameters_t3425534311 * get_publicKey_0() const { return ___publicKey_0; }
	inline RsaKeyParameters_t3425534311 ** get_address_of_publicKey_0() { return &___publicKey_0; }
	inline void set_publicKey_0(RsaKeyParameters_t3425534311 * value)
	{
		___publicKey_0 = value;
		Il2CppCodeGenWriteBarrier(&___publicKey_0, value);
	}

	inline static int32_t get_offset_of_blindingFactor_1() { return static_cast<int32_t>(offsetof(RsaBlindingParameters_t2682613251, ___blindingFactor_1)); }
	inline BigInteger_t4268922522 * get_blindingFactor_1() const { return ___blindingFactor_1; }
	inline BigInteger_t4268922522 ** get_address_of_blindingFactor_1() { return &___blindingFactor_1; }
	inline void set_blindingFactor_1(BigInteger_t4268922522 * value)
	{
		___blindingFactor_1 = value;
		Il2CppCodeGenWriteBarrier(&___blindingFactor_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
