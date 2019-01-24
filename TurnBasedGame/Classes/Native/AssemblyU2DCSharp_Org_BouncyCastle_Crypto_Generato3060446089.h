#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Parameters.ElGamalKeyGenerationParameters
struct ElGamalKeyGenerationParameters_t303785198;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Generators.ElGamalKeyPairGenerator
struct  ElGamalKeyPairGenerator_t3060446089  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Parameters.ElGamalKeyGenerationParameters Org.BouncyCastle.Crypto.Generators.ElGamalKeyPairGenerator::param
	ElGamalKeyGenerationParameters_t303785198 * ___param_0;

public:
	inline static int32_t get_offset_of_param_0() { return static_cast<int32_t>(offsetof(ElGamalKeyPairGenerator_t3060446089, ___param_0)); }
	inline ElGamalKeyGenerationParameters_t303785198 * get_param_0() const { return ___param_0; }
	inline ElGamalKeyGenerationParameters_t303785198 ** get_address_of_param_0() { return &___param_0; }
	inline void set_param_0(ElGamalKeyGenerationParameters_t303785198 * value)
	{
		___param_0 = value;
		Il2CppCodeGenWriteBarrier(&___param_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
