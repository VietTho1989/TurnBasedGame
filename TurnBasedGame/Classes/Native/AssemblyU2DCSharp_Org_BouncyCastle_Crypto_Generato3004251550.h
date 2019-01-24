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
// Org.BouncyCastle.Crypto.Parameters.DsaKeyGenerationParameters
struct DsaKeyGenerationParameters_t4209685231;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Generators.DsaKeyPairGenerator
struct  DsaKeyPairGenerator_t3004251550  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Parameters.DsaKeyGenerationParameters Org.BouncyCastle.Crypto.Generators.DsaKeyPairGenerator::param
	DsaKeyGenerationParameters_t4209685231 * ___param_1;

public:
	inline static int32_t get_offset_of_param_1() { return static_cast<int32_t>(offsetof(DsaKeyPairGenerator_t3004251550, ___param_1)); }
	inline DsaKeyGenerationParameters_t4209685231 * get_param_1() const { return ___param_1; }
	inline DsaKeyGenerationParameters_t4209685231 ** get_address_of_param_1() { return &___param_1; }
	inline void set_param_1(DsaKeyGenerationParameters_t4209685231 * value)
	{
		___param_1 = value;
		Il2CppCodeGenWriteBarrier(&___param_1, value);
	}
};

struct DsaKeyPairGenerator_t3004251550_StaticFields
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Generators.DsaKeyPairGenerator::One
	BigInteger_t4268922522 * ___One_0;

public:
	inline static int32_t get_offset_of_One_0() { return static_cast<int32_t>(offsetof(DsaKeyPairGenerator_t3004251550_StaticFields, ___One_0)); }
	inline BigInteger_t4268922522 * get_One_0() const { return ___One_0; }
	inline BigInteger_t4268922522 ** get_address_of_One_0() { return &___One_0; }
	inline void set_One_0(BigInteger_t4268922522 * value)
	{
		___One_0 = value;
		Il2CppCodeGenWriteBarrier(&___One_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
